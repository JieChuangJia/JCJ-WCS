using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using System.Data;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using DevAccess;
using FlowCtlBaseModel;
using DevInterface;
using CtlDBAccess.Model;
using CtlDBAccess.BLL;
namespace PrcsCtlModelsAoyou
{
    /// <summary>
    /// 电芯-托盘绑定
    /// </summary>
    public class NodePalletBind:CtlNodeBaseModel
    {
        public const int palletCharNum = 9; //托盘字符数
        public const int batteryCharNum = 35;//电池条码字符数
        //private HKAccess hkAccess = new HKAccess();
        private int hkServerID = 1;
        private const int PalletCapacity = 36;//托盘容量
        //private string rfidUID = string.Empty;
        private List<string> barcodes = new List<string>();
        public IHKAccess hkAccess { get; set; }
        public int HkServerID { get { return hkServerID; } }
        //private BatteryModuleBll batModBll = new BatteryModuleBll();
        //private ModPsRecordBll modPsRecordBll = new ModPsRecordBll();

        public NodePalletBind()
        {
            
        }
        public override bool BuildCfg(System.Xml.Linq.XElement xe, ref string reStr)
        {
            if (!base.BuildCfg(xe, ref reStr))
            {
                return false;
            }
            XElement selfDataXE = xe.Element("SelfDatainfo");
            if(selfDataXE != null)
            {
                if(selfDataXE.Attribute("hkServerID") != null)
                {
                    this.hkServerID = int.Parse(selfDataXE.Attribute("hkServerID").Value.ToString());
                }
            }
            this.dicCommuDataDB1[1].DataDescription = "1:复位，2：装载处理完成，3：任务撤销完成,4:杭可返回装载错误,5：电池为空";
            this.dicCommuDataDB1[2].DataDescription = "1：复位,2：读卡完成,放行空板到装载位置,3：读RFID失败";
            //this.dicCommuDataDB1[2].DataDescription = "1:人工扫码复位，2：扫码绑定中，3:扫码结束，放行，4：模组数据未绑定";
            this.dicCommuDataDB2[1].DataDescription = "1：无板，2：有板";
            this.dicCommuDataDB2[2].DataDescription = "1：复位，2：扫码完成,3:任务撤销";
            for (int i = 0; i < 36 * 20;i++ )
            {
                this.dicCommuDataDB2[3+i].DataDescription = "电池条码";
            }
            currentTaskPhase = 0;

            return true;
        }
        public override bool ExeBusiness(ref string reStr)
        {
            //Console.WriteLine("TES P1");
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
            if(db2Vals[0] != 2)
            {
                db1ValsToSnd[1] = 1;
            }
            //任务撤销
            if (db2Vals[1] == 3 && db1ValsToSnd[0] != 3)
            {
                if (this.currentTask != null && this.currentTaskPhase > 0)
                {
                    this.currentTask.TaskStatus = SysCfg.EnumTaskStatus.任务撤销.ToString();
                    this.currentTask.FinishTime = System.DateTime.Now;
                    ctlTaskBll.Update(this.currentTask);

                    logRecorder.AddDebugLog(this.nodeName, string.Format("装载任务{0}撤销,托盘号：{1}",this.currentTask.TaskID,this.rfidUID));
                    currentTaskDescribe = "装载任务撤销";
                    this.currentTask = null;
                    this.currentTaskPhase = 0;
                }
                Array.Clear(this.db1ValsToSnd, 0, this.db1ValsToSnd.Count());
                db1ValsToSnd[0] = 3;//
              
                return true;
            } 
            if (db1ValsToSnd[0] == 3 && db2Vals[1] == 1)
            {
                //任务撤销命令复位，应答也复位
                db1ValsToSnd[0] = 1;
            }
          
            if(!FillTaskRequire(ref reStr))
            {
                return false;
            }
          //  Console.WriteLine("TES P2");
            //if(this.currentTask == null)
            //{
            //    return true;
            //}
            switch(this.currentTaskPhase)
            {
                case 1:
                    {
                        currentTaskDescribe = "开始执行装载任务";
                        this.db1ValsToSnd[1] = 2;
					    
                        //如果是一次装载，判断是否第一步
                        if(this.nodeID== "3001")
                        {
                            //如果是第1步，则上传MES步次，直接放行。通知PLC不用扫条码
                           
                            ANCStepResult stepRe = MesAcc.GetStep(this.rfidUID);
                            if (stepRe.ResultCode != 0)
                            {
                                this.currentTaskDescribe = "查询MES托盘步次失败:" + stepRe.ResultMsg;
                                break;
                            }

                            if(SysCfg.SysCfgModel.ZhuyeMode == 1) //一步模式
                            {
                                #region 一步模式
                                this.db1ValsToSnd[2] = 2;
                                logRecorder.AddDebugLog(nodeName, string.Format("一次注液一步模式下，托盘{0}当前步次{1},等待装载 ", this.rfidUID, stepRe.Step));
                                #endregion  
                            }
                            else if (SysCfg.SysCfgModel.ZhuyeMode==2) //两步模式
                            {
                                #region 两步模式
                                if (stepRe.Step < 3)
                                {
                                    this.currentTaskDescribe = string.Format("{0}一次注液第1步，将跳过装载", this.rfidUID);
                                    int updateStep = 2;
                                    logRecorder.AddDebugLog(nodeName, string.Format("托盘{0}当前步次{1},完成一次注液第1步后过站，不装载 ", this.rfidUID, stepRe.Step));
                                    VMResult re = MesAcc.UpdateStep(updateStep, this.rfidUID);
                                    if (re.ResultCode != 0)
                                    {
                                        this.currentTaskDescribe = "更新MES步次失败," + re.ResultMsg;
                                        logRecorder.AddDebugLog(nodeName, this.currentTaskDescribe);
                                        break; //zwx ,11-16
                                    }
                                    this.db1ValsToSnd[2] = 1;

                                    this.db1ValsToSnd[0] = 2;
                                    this.currentTaskPhase = 3;
                                    this.currentTask.TaskPhase = this.currentTaskPhase;
                                    this.ctlTaskBll.Update(this.currentTask);
                                    break;
                                }
                                else if (stepRe.Step == 3)
                                {
                                    this.db1ValsToSnd[2] = 2;
                                    logRecorder.AddDebugLog(nodeName, string.Format("一次注液两步模式下，托盘{0}当前步次{1},完成一次注液第2步后装载 ", this.rfidUID, stepRe.Step));
                                }
                                else
                                {
                                    if (this.db1ValsToSnd[2] != 3)
                                    {
                                        logRecorder.AddDebugLog(nodeName, string.Format("托盘{0}步次错误，当前步次:{1} ", this.rfidUID, stepRe.Step));
                                    }

                                    this.db1ValsToSnd[2] = 3;
                                    break;
                                }
                                #endregion
                            }
                            else
                            {
                                if (this.db1ValsToSnd[2] != 3)
                                {
                                    logRecorder.AddDebugLog(nodeName, string.Format("一次注液模式错误,实际为{0}",SysCfg.SysCfgModel.ZhuyeMode));
                                }

                                this.db1ValsToSnd[2] = 3;
                                break;
                            }  
                        }
						
                        this.currentTaskPhase++;
                        this.currentTask.TaskPhase = this.currentTaskPhase;
                        this.ctlTaskBll.Update(this.currentTask);
                        break;
                    }
                case 2:
                    {
                        if(this.db1ValsToSnd[0] ==4)
                        {
                            //装载错误状态
                            break;
                        }
                        //等待扫码完成
                        currentTaskDescribe = "RFID读取完成，等待电池条码数据";
                        if(db2Vals[1] != 2)
                        {
                            break;
                        }
                        if(SysCfg.SysCfgModel.SimMode)
                        {
                            //生成模拟数据
                            GenerateSimBatterys();
                        }
                        //取电池条码数据
                        List<string> batteryList = new List<string>();
                        int validBatNum = 0;
                        for (int i = 0; i < PalletCapacity; i++)
                        {
                            List<byte> batteryBytes = new List<byte>();
                            for(int j=0;j<20;j++)
                            {
                                int indexSt = 2+i*20+j;
                                batteryBytes.Add((byte)(this.db2Vals[indexSt] & 0xff));
                                batteryBytes.Add((byte)((this.db2Vals[indexSt] >> 8) & 0xff));
                            }
                           
                            //字节流转换成字符串
                            string batteryID = System.Text.ASCIIEncoding.UTF8.GetString(batteryBytes.ToArray());
                            batteryID = batteryID.Trim(new char[]{'\0','\r','\n','\t',' '}).ToUpper();
                            if(batteryID.Contains("ERROR"))
                            {
                                batteryID = "";
                            }
                            
                            if (batteryID.Length>22)
                            {
                                validBatNum++;
                                if (batteryID.Length<35 && batteryID.Substring(16, 6).ToUpper() == "17K03C")
                                {
                                    batteryID = batteryID.Insert(22, "1");
                                }
                            }
                            batteryList.Add(batteryID);
                        }
                        if (validBatNum < 1)
                        {
                            if (this.db1ValsToSnd[0]!=5)
                            {
                                logRecorder.AddDebugLog(nodeName, string.Format("{0}电池数据为空",rfidUID));
                            }
                            this.db1ValsToSnd[0] = 5;
                            break;
                        }
						
						
                        #region 调用MES接口上传绑定数据，更新步次
                        int fillSeq = 1;
                        if (this.nodeID == "3002")
                        {
                            fillSeq = 2;
                        }
                        logRecorder.AddDebugLog(nodeName, string.Format("{0}开始上传MES", rfidUID));
                        if (!MESBatteryFill(fillSeq, rfidUID, batteryList, ref reStr))
                        {
                            logRecorder.AddDebugLog(nodeName, string.Format(" {0}MES装载错误:{1}", rfidUID,reStr));
                            this.db1ValsToSnd[0] = 4;//装载错误
                            currentTaskDescribe = string.Format(" 装载错误{0}", reStr);
                            logRecorder.AddDebugLog(nodeName, currentTaskDescribe);
                            break; //zwx,11-16
                          
                        }
                        else
                        {
                            logRecorder.AddDebugLog(nodeName, string.Format("{0}MES装载成功", rfidUID));
                        }

                        ANCStepResult stepRe = MesAcc.GetStep(this.rfidUID);
                        if (stepRe.ResultCode != 0)
                        {
                            this.currentTaskDescribe = "查询MES托盘步次失败:" + stepRe.ResultMsg;
                            logRecorder.AddDebugLog(nodeName, this.currentTaskDescribe);
                            break; //zwx,11-16
                        }
                        int updateStep = 0;
                        if (this.nodeID == "3001")
                        {
                            updateStep = 4;
                           
                        }
                        else
                        {
                            updateStep = 8;
                        }
                        VMResult re = MesAcc.UpdateStep(updateStep, this.rfidUID);
                        if (re.ResultCode != 0)
                        {
                            this.currentTaskDescribe = "更新MES步次失败," + re.ResultMsg;
                            logRecorder.AddDebugLog(nodeName, this.currentTaskDescribe);
                            break; //zwx ,11-16
                        }
	                    #endregion


                        //自动装载都是1次装载
                        #region 上传杭可
                        //string sndStr = "";
                        //if (!hkAccess.BatteryFill(0, this.rfidUID, batteryList, ref sndStr, ref reStr))
                        //{

                        //    logRecorder.AddDebugLog(nodeName, string.Format(" 装载错误:{0},发送数据：{1}", reStr, sndStr));
                        //    this.db1ValsToSnd[0] = 4;//装载错误
                        //    currentTaskDescribe = string.Format(" 装载错误{0}", reStr);
                        //    break;
                        //}
                        #endregion
                        #region 本地数据装载
                        for (int i = 0; i < batteryList.Count(); i++)
                        {
                            string batteryID = batteryList[i];
                            if (string.IsNullOrWhiteSpace(batteryID) || (batteryID.Length < 23))
                            {
                                continue;
                            }
                            MesDBAccess.Model.ProductOnlineModel productModel = null;
                            if (productOnlineBll.Exists(batteryID))
                            {
                                productModel = productOnlineBll.GetModel(batteryID);
                                productModel.productID = batteryID;
                                productModel.palletID = this.rfidUID;
                                productModel.modifyTime = System.DateTime.Now;
                                productModel.processStepID = this.mesProcessStepID[0].ToString();
                                productModel.productCata = SysCfg.EnumProductCata.电芯.ToString();
                                productModel.palletBinded = true;
                                productModel.stationID = this.nodeID;
                                productModel.checkResult = "0";
                                if (batteryID.Length > 22)
                                {
                                    productModel.batchName = batteryID.Substring(16, 6);
                                }

                                int seq = i + 1;
                                productModel.tag1 = seq.ToString();
                                int rowIndex = i / 12 + 1;
                                productModel.tag2 = rowIndex.ToString();
                                int colIndex = i - (rowIndex - 1) * 12 + 1;
                                productModel.tag3 = colIndex.ToString();
                                productModel.tag5 = "0";
                                if (!productOnlineBll.Update(productModel))
                                {
                                    return false;
                                }
                            }
                            else
                            {
                                productModel = new MesDBAccess.Model.ProductOnlineModel();
                                productModel.onlineTime = System.DateTime.Now;
                                productModel.modifyTime = System.DateTime.Now;
                                productModel.productID = batteryID;
                                productModel.palletID = this.rfidUID;
                                productModel.processStepID = this.mesProcessStepID[0].ToString();
                                productModel.productCata = SysCfg.EnumProductCata.电芯.ToString();
                                productModel.palletBinded = true;
                                productModel.stationID = this.nodeID;
                                productModel.checkResult = "0";
                                productModel.tag5 = "0";
                                if (batteryID.Length > 22)
                                {
                                    productModel.batchName = batteryID.Substring(16, 6);
                                }
                                int seq = i + 1;
                                productModel.tag1 = seq.ToString();
                                int rowIndex = i / 12 + 1;
                                productModel.tag2 = rowIndex.ToString();
                                int colIndex = i - (rowIndex - 1) * 12 + 1;
                                productModel.tag3 = colIndex.ToString();
                                if (!productOnlineBll.Add(productModel))
                                {
                                    return false;
                                }
                            }
                        }
                        #endregion

                        logRecorder.AddDebugLog(nodeName, string.Format(" 装载成功{0},更新MES工步：{1}", rfidUID, updateStep));
                        AddProduceRecord(this.rfidUID, string.Format("装载:{0},更新MES步次{1}", nodeName, updateStep));
                        this.currentTaskPhase++;
                        this.currentTask.TaskPhase = this.currentTaskPhase;
                        this.ctlTaskBll.Update(this.currentTask);
                        this.db1ValsToSnd[0] = 2;
                        break;
                    }
                case 3:
                    {
                        currentTaskDescribe = "托盘跟电池条码数据绑定完成，等待扫码完成信号复位";
                        if(this.db2Vals[1] != 1)
                        {
                            break;
                        }
                        DevCmdReset();
                        this.currentTask.TaskStatus = SysCfg.EnumTaskStatus.已完成.ToString();
                        this.ctlTaskBll.Update(this.currentTask);
                        this.currentTask = null;
                        currentTaskPhase = 0;
                        currentTaskDescribe = "等待执行下一个任务";
                        //等待扫码完成
                        break;
                    }
                default:
                    break;
            }
            //Console.WriteLine("TES P3");
            return true;
        }
       
        private void GenerateSimBatterys()
        {
           // batterys = new List<string>();
            int batterySum = productOnlineBll.GetRecordCount("");
            for(int i=0;i<PalletCapacity;i++)
            {
                batterySum++;
                string batteryID = string.Format("36ANCCB23140160n{0}16C3101{1}","16A002",batterySum.ToString().PadLeft(6,'0'));
              //  batterys.Add(batteryID);
               
                byte[] byteArray = System.Text.ASCIIEncoding.UTF8.GetBytes(batteryID);
                Int16[] vals = new Int16[20];
                Array.Clear(vals, 0, 20);
                int blockAlloc = byteArray.Count() / 2;
                for (int blockIndex = 0; blockIndex < blockAlloc; blockIndex++)
                {
                    vals[blockIndex] = (Int16)(byteArray[blockIndex * 2] + (byteArray[blockIndex * 2 + 1]<<8));
                }
                if (blockAlloc * 2 < byteArray.Count())
                {
                    vals[blockAlloc] = byteArray[byteArray.Count() - 1];
                    blockAlloc++;
                }

                int db2St = 2+i*20;
                Array.Copy(vals, 0, this.db2Vals, db2St, blockAlloc);
            }
        }
        
        /// <summary>
        /// 装载任务申请
        /// </summary>
        private bool FillTaskRequire(ref string reStr)
        {
           
            //if (db2Vals[0] == 1)
            //{
            //    currentTaskPhase = 0;
            //    db1ValsToSnd[0] = 1;

            //    rfidUID = string.Empty;
            //    currentTaskDescribe = "等待新的任务";
            //    return;
            //}
            if (db2Vals[0] == 2 && db1ValsToSnd[0] != 2)
            {
                if (ExistUnCompletedTask((int)SysCfg.EnumAsrsTaskType.托盘装载))
                {
                    return true;
                }
                //先读RFID卡
                currentTaskDescribe = "开始读RFID";
                this.rfidUID = "";
     
                if (SysCfg.SysCfgModel.SimMode || SysCfg.SysCfgModel.RfidSimMode)
                {
                    this.rfidUID = this.SimRfidUID;
                }
                else
                {
                    if (this.barcodeRW != null)
                    {
                        this.rfidUID = this.barcodeRW.ReadBarcode();
                    }
                    else
                    {
                        this.rfidUID = rfidRW.ReadStrData();// rfidRW.ReadUID();
                    } 
                  
                }
                
                if(string.IsNullOrWhiteSpace(this.rfidUID))
                {
                    if(this.db1ValsToSnd[1]!= 3)
                    {
                        logRecorder.AddDebugLog(nodeName, "读RFID失败");
                    }
                    this.db1ValsToSnd[1] = 3;
                    return true;
                }
                this.rfidUID = this.rfidUID.Trim(new char[] { '\0', '\r', '\n', '\t', ' ' });
                string pattern = @"^[a-zA-Z0-9]*$"; //匹配所有字符都在字母和数字之间  
                if (!System.Text.RegularExpressions.Regex.IsMatch(this.rfidUID, pattern))
                {
                    if (this.db1ValsToSnd[1] != 3)
                    {
                        logRecorder.AddDebugLog(nodeName, "读料框RFID错误，含有非法字符 ！"+this.rfidUID);
                    }
                    this.db1ValsToSnd[1] = 3;
                    return true;
                }
                if (this.rfidUID.Length < 9)
                {
                    if (this.db1ValsToSnd[1] != 3)
                    {
                        logRecorder.AddDebugLog(nodeName, "读料框ID错误，长度不足9字符！");
                    }
                    this.db1ValsToSnd[1] = 3;
                    return true;
                }
                string palletCata = "1";
                if(this.nodeID == "3002")
                {
                    palletCata = "2";
                }
                if(this.rfidUID.Substring(2,1) != palletCata)
                {
                    if (this.db1ValsToSnd[1] != 3)
                    {
                        logRecorder.AddDebugLog(nodeName, string.Format("料框错误，应该为TP{0}XXXXXX,实际为{1}",palletCata,this.rfidUID));
                        this.currentTaskDescribe = string.Format("料框错误，应该为TP{0}XXXXXX,实际为{1}", palletCata, this.rfidUID);
                    }
                    this.db1ValsToSnd[1] = 3;
                    return true;
                }
                if (this.rfidUID.Length > 9)
                {
                    //this.rfidUID = this.rfidUID.Substring(this.rfidUID.Length - 9, 9);
                    this.rfidUID = this.rfidUID.Substring(0, 9);
                }
                logRecorder.AddDebugLog(this.nodeName, "读到托盘号:" + this.rfidUID);
                //解绑
                currentTaskDescribe = "开始解绑";
                if (!productOnlineBll.UnbindPallet(this.rfidUID, ref reStr))
                {
                    logRecorder.AddDebugLog(nodeName, reStr);
                    return false;
                }
                //生成新任务
                this.currentTaskPhase = 1;
                ControlTaskModel task = new ControlTaskModel();
                task.DeviceID = this.nodeID;
                task.CreateMode = "自动";
                task.CreateTime = System.DateTime.Now;
                task.TaskID = System.Guid.NewGuid().ToString("N");
                task.TaskStatus = SysCfg.EnumTaskStatus.待执行.ToString();
                task.TaskType = (int)SysCfg.EnumAsrsTaskType.托盘装载;
                task.TaskParam = this.rfidUID;
                task.TaskPhase = this.currentTaskPhase;
                task.TaskStatus = SysCfg.EnumTaskStatus.执行中.ToString();
                this.ctlTaskBll.Add(task);
                this.currentTask = task;
                currentTaskDescribe = "装载任务生成";  
                return true;
            }
            if (db2Vals[0] == 1 && this.currentTask == null)
            {
                this.db1ValsToSnd[1] = 1;
            }
            return true;
        }
        private bool MESBatteryFill(int fillSeq, string palletID, List<string> batteryList, ref string reStr)
        {
            try
            {
                return true;
                /*ANCStepResult stepRe = MesAcc.GetStep(palletID);
                if (stepRe.ResultCode != 0)
                {
                    reStr = stepRe.ResultMsg;
                    return false;
                }

                int channelMax = 36;
                JObject jsonObj = new JObject(new JProperty("Type", "One"), new JProperty("TrayNO", palletID));
                if (fillSeq > 1)
                {
                    jsonObj["Type"] = "Two";
                }
                for (int i = 0; i < Math.Min(channelMax, batteryList.Count()); i++)
                {
                    jsonObj.Add("Cell" + (i + 1).ToString(), batteryList[i]);
                }
                VMResult re = MesAcc.UploadTrayCellInfo(jsonObj.ToString());
                if(re.ResultCode != 0)
                {
                    reStr = re.ResultMsg;
                    return false;
                }
                else
                {
                    return true;
                }*/
            }
            catch (Exception ex)
            {
                reStr = ex.ToString();
                return false;
            }
        }
    }
}
