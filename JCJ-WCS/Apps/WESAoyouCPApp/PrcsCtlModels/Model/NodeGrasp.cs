using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json.Linq;
using DevAccess;
using FlowCtlBaseModel;
using CtlDBAccess.Model;
using CtlDBAccess.BLL;
namespace PrcsCtlModelsAoyouCp
{
    //OCV测试后分拣
    public class NodeGrasp : CtlNodeBaseModel
    {
        private const int channelSum = 36; //最大通道数量
        private OcvAccess ocvAccess = null;
        List<int> vals = null;
        public OcvAccess OcvAccess { get { return ocvAccess; } set { ocvAccess = value; } }
      
        public NodeGrasp()
        {
            ctlTaskBll = new ControlTaskBll();
            
        }
        public override bool BuildCfg(System.Xml.Linq.XElement xe, ref string reStr)
        {
            if (!base.BuildCfg(xe, ref reStr))
            {
                return false;
            }
            this.dicCommuDataDB1[1].DataDescription = "1:未完成，2：写入完成，3：读RFID失败，4:托盘信息不存在";
            this.dicCommuDataDB1[2].DataDescription = "1:未处理完成，2：处理完成,3:任务撤销";
            if(this.nodeID=="6002")
            {
                this.dicCommuDataDB1[3].DataDescription = "OCV标识，1:OCV2,2:OCV4";
                for (int i = 0; i < 36; i++)
                {
                    this.dicCommuDataDB1[4 + i].DataDescription = string.Format("通道:{0}状态，1:合格，2：NG，3：该位置无电芯，4：需要补电", i + 1);
                }
            }
            else
            {
                for (int i = 0; i < 36; i++)
                {
                    this.dicCommuDataDB1[3 + i].DataDescription = string.Format("通道:{0}状态，1:合格，2：NG，3：该位置无电芯，4：需要补电", i + 1);
                }
            }
            this.dicCommuDataDB2[1].DataDescription = "1：无板，2：有板";
            this.dicCommuDataDB2[2].DataDescription = "1：复位，2：分拣完成，3: 撤销处理完成，4：无需分拣模式完成";
          
               
            currentTaskPhase = 0;

            return true;
        }
        public override bool ExeBusiness(ref string reStr)
        {
            if (!nodeEnabled)
            {
                return true;
            }
            if (!devStatusRestore)
            {
                devStatusRestore = DevStatusRestore();
            }
            if (!devStatusRestore)
            {
                return false;
            }
            if (db2Vals[0] != 2)
            {
                db1ValsToSnd[0] = 1;
            }

            //任务撤销
            if (db2Vals[1] == 3 && db1ValsToSnd[1] != 3)
            {
                if (this.currentTask != null && this.currentTaskPhase > 0)
                {
                    this.currentTask.TaskStatus = SysCfg.EnumTaskStatus.任务撤销.ToString();
                    this.currentTask.FinishTime = System.DateTime.Now;
                    ctlTaskBll.Update(this.currentTask);

                    logRecorder.AddDebugLog(this.nodeName, string.Format("分拣任务{0}撤销,托盘号：{1}",this.currentTask.TaskID,this.rfidUID));
                    currentTaskDescribe = "分拣任务撤销，等待任务撤销信号复位";
                    this.currentTask = null;
                    this.currentTaskPhase = 0;
                }
                Array.Clear(this.db1ValsToSnd, 0, this.db1ValsToSnd.Count());
                db1ValsToSnd[1] = 3;//

                return true;
            }
            if (db1ValsToSnd[1] == 3 && db2Vals[1] !=2)
            {
                //任务撤销命令复位，应答也复位
                db1ValsToSnd[1] = 1;
            }

            if(!GraspTaskRequire(ref reStr))
            {
                return false;
            }
            if (this.currentTask == null)
            {
                return true;
            }
            /*
            switch(this.currentTaskPhase)
            {
                case 1:
                    {
                        currentTaskDescribe = "开始执行分拣任务";
                      
                      
                       // int ocvProcessID = 1;//zwx,临时
                        List<int> ocvTestSeqIDS = new List<int>();
                        int testValStIndex = 2;
                        
						ANCStepResult stepRe = MesAcc.GetStep(this.rfidUID);
                        if (stepRe.ResultCode != 0)
                        {
                            this.currentTaskDescribe = "查询MES托盘步次失败:" + stepRe.ResultMsg;
                            break;
                        }
						
                       if(this.nodeID=="6002")
                       {
					      
					      //查询MES，当前步次，是OCV2还是OCV4分拣
                           testValStIndex = 3;
                           if(stepRe.Step<19)
                           {
                               this.db1ValsToSnd[2] = 1; //OCV2
                              
                           }
                           else
                           {
                                this.db1ValsToSnd[2] = 2; //OCV4
                           }
                           #region 判断本地工艺步号
                          
                           #endregion

                       }
                     
                       #endregion
                      
                      
					   //查询MES分拣数据
                       vals = new List<int>();
                       if (SysCfg.SysCfgModel.SimMode)
                       {
                           for (int i = 0; i < 36; i++)
                           {
                               vals.Add(1);
                           }
                       }
                       else
                       {   
                           int step = 0;
                           if(this.nodeID == "6001")
                           {
                               step = 9;
                           }
                           else if(this.nodeID == "6002")
                           {
                               if(stepRe.Step<14)
                               {
                                    step = 13;
                               }
                               else
                               {
                                   step=19;
                               }
                           }
                           else
                           {
                               step=16;
                           }
                           
                           if (!MESGetGraspVals(step, this.rfidUID, ref vals, ref reStr))
                           {
                               this.currentTaskDescribe = reStr;
                               break;
                           }
                       }
					   
                        //发送分拣参数
                        for (int i = 0; i < Math.Max(channelSum, vals.Count()); i++)
                        {
                            Int16 re =(short)vals[i];
                            db1ValsToSnd[testValStIndex + i] = re;
                        }
                        db1ValsToSnd[0] = 2;
                        AddGraspRecord(this.rfidUID, vals); //记录分拣发送详细
                        currentTaskDescribe = "分拣参数发送完成";
                        this.currentTaskPhase++;
                        this.currentTask.TaskPhase = this.currentTaskPhase;
                        this.ctlTaskBll.Update(this.currentTask);
                        break;
                    }
              
                case 2:
                    {
                        //等待任务完成
                        currentTaskDescribe = "等待分拣完成";
                        if(this.db2Vals[1] != 2 && this.db2Vals[1] != 4)
                        {
                            break;
                        }
                        if (this.db2Vals[1] == 4)
                        {
                            AddProduceRecord(this.rfidUID, string.Format("无需分拣模式:{0}", nodeName));
                            logRecorder.AddDebugLog(nodeName, string.Format("由人工处理，{0}无需挑选放行", this.rfidUID));
                          
                        }
                        
                        //if (db2Vals[1] == 2)
                        //{
                        //    ANCStepResult stepRe = MesAcc.GetStep(this.rfidUID);
                        //    if (stepRe.ResultCode != 0)
                        //    {
                        //        this.currentTaskDescribe = "查询MES托盘步次失败:" + stepRe.ResultMsg;
                        //        logRecorder.AddDebugLog(nodeName, this.currentTaskDescribe);
                        //        break; //zwx,11-16
                        //    }
                           
                        //}
                       
                        UpdateOnlineProductInfo(this.rfidUID);
                       
                        this.currentTaskPhase++;
                      
                        this.currentTask.TaskPhase = this.currentTaskPhase;
                        this.ctlTaskBll.Update(this.currentTask);
                       
                        break;
                    }
                case 3:
                    {
                        //更新MES步号
                        
                        ANCStepResult stepRe = MesAcc.GetStep(this.rfidUID);
                        if (stepRe.ResultCode != 0)
                        {
                            this.currentTaskDescribe = "查询MES托盘步次失败:" + stepRe.ResultMsg;
                            logRecorder.AddDebugLog(nodeName, this.currentTaskDescribe);
                            break; //zwx,11-16
                        }

                        int stepUp = 0;
                        if (this.nodeID == "6001")
                        {
                            stepUp = 10;
                        }
                        else if (this.nodeID == "6002")
                        {
                            if (stepRe.Step <=14)
                            {
                                stepUp = 14;
                            }
                            else
                            {
                                stepUp = 20;
                            }
                        }
                        else
                        {
                            stepUp = 17;
                        }
                        VMResult re = MesAcc.UpdateStep(stepUp, this.rfidUID);
                        if(re.ResultCode != 0)
                        {
                            this.currentTaskDescribe = "更新MES步号失败," + re.ResultMsg;
                            logRecorder.AddDebugLog(nodeName, this.currentTaskDescribe);
                            break; //zwx,11-16
                        }
                      

                        db1ValsToSnd[1] = 2;
                        string grasp = "";
                        if (stepRe.Step < 20)
                        {
                            grasp = string.Format("OCV2 分拣完成,更新步次{0}", stepUp);
                        }
                        else
                        {
                            grasp = string.Format("OCV4 分拣完成,更新步次{0}", stepUp);
                        }
                        AddProduceRecord(this.rfidUID, string.Format("正常分拣:{0}", grasp));
                        logRecorder.AddDebugLog(nodeName, string.Format("{0},分拣完成,{1}", this.rfidUID, grasp));

                        this.currentTaskPhase++;

                        this.currentTask.TaskPhase = this.currentTaskPhase;
                        this.ctlTaskBll.Update(this.currentTask);
                        
                        
                        break;
                    }
                case 4:
                    {
                        currentTaskDescribe = "分拣流程完成，等待分拣完成信号复位";
                        if (this.db2Vals[1] != 1)
                        {
                            break;
                        }
                        DevCmdReset();
                        this.currentTask.TaskStatus = SysCfg.EnumTaskStatus.已完成.ToString();
                        this.ctlTaskBll.Update(this.currentTask);

                        this.currentTask = null;
                        currentTaskPhase = 0;
                        currentTaskDescribe = "等待执行下一个任务";
                        break;
                    }
                default:
                    break;
            }*/
            return true;
        }
       
        /// <summary>
        /// 分拣任务申请
        /// </summary>
        private bool GraspTaskRequire(ref string reStr)
        {

            //if (db2Vals[0] == 1)
            //{
            //    currentTaskPhase = 0;
            //    db1ValsToSnd[0] = 1;

            //    rfidUID = string.Empty;
            //    currentTaskDescribe = "等待新的任务";
            //    return;
            //}
            if (db2Vals[0] ==2 && db1ValsToSnd[1] != 2)
            {
                if(this.currentTask != null )
                {
                    return true;
                }
                //if (ExistUnCompletedTask((int)SysCfg.EnumAsrsTaskType.OCV测试分拣))
                //{
                //    return true;
                //}
                //先读RFID卡
                currentTaskDescribe = "开始读RFID";
                this.rfidUID = "";
                if (SysCfg.SysCfgModel.SimMode || SysCfg.SysCfgModel.RfidSimMode)
                {
                    this.rfidUID = this.SimRfidUID;
                }
                else
                {
                    if(this.barcodeRW != null)
                    {
                        this.rfidUID = this.barcodeRW.ReadBarcode();
                    }
                    else
                    {
                        this.rfidUID = rfidRW.ReadStrData();// rfidRW.ReadUID();
                    }
                    
                   
                }
                if (string.IsNullOrWhiteSpace(this.rfidUID))
                {
                    if (this.db1ValsToSnd[0] != 3)
                    {
                        logRecorder.AddDebugLog(nodeName, "读RFID失败");
                        this.currentTaskDescribe = "读RFID失败";
                    }
                    this.db1ValsToSnd[0] = 3;
                    return true;
                }
                this.rfidUID = this.rfidUID.Trim(new char[] { '\0', '\r', '\n', '\t', ' ' });
                string pattern = @"^[a-zA-Z0-9]*$"; //匹配所有字符都在字母和数字之间  
                if (!System.Text.RegularExpressions.Regex.IsMatch(this.rfidUID, pattern))
                {
                    if (this.db1ValsToSnd[1] != 3)
                    {
                        logRecorder.AddDebugLog(nodeName, "读料框ID错误，含有非法字符 ！" + this.rfidUID);
                    }
                    this.db1ValsToSnd[1] = 3;
                    return true;
                }
                if (this.rfidUID.Length < 9)
                {
                    if (this.db1ValsToSnd[0] != 3)
                    {
                        logRecorder.AddDebugLog(nodeName, "读料框RFID错误，长度不足9字符！");
                    }
                    this.db1ValsToSnd[0] = 3;
                    return true;
                }

                if (this.rfidUID.Length > 9)
                {
                    this.rfidUID = this.rfidUID.Substring(0, 9);
                }
                if(db1ValsToSnd[0] == 1 || db1ValsToSnd[0] == 3)
                {
                    logRecorder.AddDebugLog(this.nodeName, "读到托盘号:" + this.rfidUID);
                    this.currentTaskDescribe = "读到托盘号:" + this.rfidUID;
                }
               /*
                List<MesDBAccess.Model.ProductOnlineModel> bindedProducts = productOnlineBll.GetProductsInPallet(this.rfidUID);
                if(bindedProducts == null || bindedProducts.Count()<1)
                {
                    this.db1ValsToSnd[0] = 4;
                    this.currentTaskDescribe = string.Format("{0}无绑定数据",this.rfidUID);
                    return true;
                }*/
                //生成新任务
                this.currentTaskPhase = 1;
                ControlTaskModel task = new ControlTaskModel();
                task.DeviceID = this.nodeID;
                task.CreateMode = "自动";
                task.CreateTime = System.DateTime.Now;
                task.TaskID = System.Guid.NewGuid().ToString("N");
                task.TaskStatus = SysCfg.EnumTaskStatus.待执行.ToString();
                task.TaskType = (int)SysCfg.EnumAsrsTaskType.OCV测试分拣;
                task.TaskParam = this.rfidUID;
                task.TaskPhase = this.currentTaskPhase;
                task.TaskStatus = SysCfg.EnumTaskStatus.执行中.ToString();
                this.ctlTaskBll.Add(task);
                this.currentTask = task;
                currentTaskDescribe = "分拣任务生成";
                return true;
            }
            if (db2Vals[0] == 1 && this.currentTask == null)
            {
                this.db1ValsToSnd[0] = 1;
            }
            return true;
        }
        private void AddGraspRecord(string palletID,List<int> graspVals)
        {
           // List<MesDBAccess.Model.ProductOnlineModel> products = productOnlineBll.GetProductsInPallet(palletID);
            string str = string.Format("托盘{0}分拣记录：",palletID);
            for (int i = 0; i < channelSum; i++)
            {
                 int channel = i + 1;
               //  foreach(MesDBAccess.Model.ProductOnlineModel p in products)
                 {
                     if(vals[i] == 2)
                     {
                         str += string.Format("Cell[{0}],", channel);
                     }
                 }
            }
            logRecorder.AddDebugLog(nodeName, str);
        }
    }
}
