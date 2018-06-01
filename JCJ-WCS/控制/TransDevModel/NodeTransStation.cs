using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using FlowCtlBaseModel;
namespace TransDevModel
{
    /// <summary>
    /// 输送机站台，主要功能是传递控制任务号，系统将托盘码绑定在控制任务中，根据控制任务号查询托盘码，可以实现托盘号传递。
    /// </summary>
    public class NodeTransStation : CtlNodeBaseModel
    {
        /// <summary>
        /// 委托
        /// </summary>
        /// <param name="mainTask">主控制任务</param>
        /// <param name="height">高度,1:低货，2:高货</param>
        /// <param name="reStr"></param>
        /// <returns></returns>
        public delegate bool DlgtHeightChecked(CtlDBAccess.Model.MainControlTaskModel mainTask,int height,ref string reStr);
        private int taskMode = 0;
        private int recvTaskPhase = 0;
        protected int transMode = 0; //输送站台任务模式,0:不发任务，也不收任务，1：只发任务，2：只收任务
        protected bool barcodeCheck = false;
        public DlgtHeightChecked dlgtHeightChecked;
        public NodeTransStation()
        {
            devCata = "站台";
        }
        public override bool BuildCfg(System.Xml.Linq.XElement xe, ref string reStr)
        {
            if(!base.BuildCfg(xe, ref reStr))
            {
                return false;
            }
            XElement selfDataXE = xe.Element("SelfDatainfo");
            if(selfDataXE != null)
            {
                if(selfDataXE.Attribute("transMode") != null)
                {
                    transMode = int.Parse(selfDataXE.Attribute("transMode").Value.ToString());
                }
                if(selfDataXE.Attribute("barcodeCheck") != null)
                {
                    if(selfDataXE.Attribute("barcodeCheck").Value.ToString().ToUpper() == "TRUE")
                    {
                        barcodeCheck = true;
                    }
                    else
                    {
                        barcodeCheck = false;
                    }
                }
            }

            return true;
        }
        public override bool ExeBusiness(ref string reStr)
        {
            try
            {
                if (!nodeEnabled)
                {
                    return true;
                }
                //if (!devStatusRestore)
                //{
                //    devStatusRestore = DevStatusRestore();
                //}
                //Console.WriteLine("{0}", nodeName);
               
                if(this.db2Vals[5] == 0)
                {
                    return true;
                }
                /*
                if(transMode == 0)
                {
                    if (this.db2Vals[6] == 1 && this.db2Vals[5] == 1 && this.db2Vals[7] == 0) //空闲,没有收到任务号，检查是否有任务待发送
                    {

                        if (this.db2Vals[0] == 1)
                        {
                            this.currentTaskPhase = 0;
                            currentTask = null;

                        }
                        else if (this.db2Vals[0] == 2)
                        {
                            taskMode = 1;// 发送任务流程;
                            if (this.currentTaskPhase == 0)
                            {
                                this.currentTaskDescribe = "设备空闲，等待发送输送任务";
                                this.currentTaskPhase = 1;
                            }
                        }
                    }
                    else if (this.db2Vals[6] == 3 && this.db2Vals[5] == 1) //任务完成
                    {

                        if (this.db2Vals[0] == 1)
                        {
                            recvTaskPhase = 0;
                            currentTask = null;

                        }
                        else if (this.db2Vals[0] == 2)
                        {
                            taskMode = 2;// 接收任务流程;
                            this.currentTaskDescribe = "等待处理已经完成的输送任务";
                            if (this.currentTaskPhase == 0)
                            {
                                recvTaskPhase = 1;
                            }
                        }
                    }
                }
                else*/
                //{
                    
               // }
                taskMode = transMode;
                if (taskMode == 1)
                {
                    if (this.db2Vals[0] == 1)
                    {
                        this.db1ValsToSnd[5] = 0;
                        this.db1ValsToSnd[6] = 1;
                        this.db1ValsToSnd[7] = 0;
                        this.db1ValsToSnd[8] = 0;
                        this.db1ValsToSnd[9] = 0;
                        this.currentTaskDescribe = "设备空闲，等待新的任务";
                        this.currentTaskPhase = 0;
                        currentTask = null;

                    }
                    else if (this.db2Vals[0] == 2)
                    {
                        if (this.currentTaskPhase == 0)
                        {
                            this.currentTaskDescribe = "设备空闲，等待发送输送任务";
                            this.currentTaskPhase = 1;
                        }
                    }
                    return ExeSndTaskBusiness(ref reStr);
                }
                else if(taskMode==2)
                {
                    if (this.db2Vals[0] == 1)
                    {
                        if (this.recvTaskPhase>0&&this.recvTaskPhase < 3)
                        {
                            logRecorder.AddDebugLog(nodeName, string.Format("流程异常,当前流程执行到第{0}步,有板信号复位", this.recvTaskPhase));
                        }
                        this.currentTaskDescribe = "设备空闲，等待新的任务";
                        recvTaskPhase = 0;
                        currentTask = null;
                        this.db1ValsToSnd[0] = 0;
                        this.db1ValsToSnd[6] = 1;
                    }
                    else if (this.db2Vals[0] == 2)
                    {
                        this.currentTaskDescribe = "等待处理已经完成的输送任务";
                        if (recvTaskPhase == 0)
                        {
                            recvTaskPhase = 1;
                        }
                    }
                    return ExeRecvTaskBusiness(ref reStr);
                }
                return true;
            }
            catch (Exception ex)
            {
                reStr = ex.ToString();
                return false;
            }
            
        }
        public override string GetRunningTaskDetail()
        {
             string taskInfo="";
            if(taskMode==2)
            {
                taskInfo = string.Format("流程执行到第{0}步", this.recvTaskPhase) + ":" + currentTaskDescribe;
            }
            else
            {
                taskInfo = string.Format("流程执行到第{0}步", this.currentTaskPhase) + ":" + currentTaskDescribe;
            }
            return taskInfo;

        }
        private bool ExeSndTaskBusiness(ref string reStr)
        {
            try
            {
                switch (this.currentTaskPhase)
                {
                    case 1:
                        {
                            this.currentTaskDescribe = "等待有板信号";
                            this.rfidUID = "";
                            this.db1ValsToSnd[5] = 0;
                            this.db1ValsToSnd[6]=1;
                            this.db1ValsToSnd[7] = 0;
                            this.db1ValsToSnd[8] = 0;
                            this.db1ValsToSnd[9] = 0;
                            if(this.db2Vals[0] != 2)
                            {
                                break;
                            }
                            if (SysCfg.SysCfgModel.SimMode)
                            {
                                this.rfidUID = this.SimRfidUID;
                                logRecorder.AddDebugLog(this.nodeName, "读到托盘号:" + this.rfidUID);
                            }
                            else
                            {
                                if (this.barcodeRW != null && barcodeCheck)
                                {
                                    this.rfidUID = this.barcodeRW.ReadBarcode().Trim();//this.barcodeRW.Trim();
                                    if (string.IsNullOrWhiteSpace(this.rfidUID))
                                    {
                                        break;
                                    }
                                    logRecorder.AddDebugLog(this.nodeName, "读到托盘号:" + this.rfidUID);
                                }

                            }
                            this.currentTaskPhase++;
                            break;
                        }
                    case 2:
                        {
                           
                            this.currentTask = null;
                            currentTaskDescribe = "等待检索待执行任务";
                            List<CtlDBAccess.Model.ControlTaskModel> taskList = ctlTaskBll.GetTaskToRunList((int)SysCfg.EnumAsrsTaskType.输送机送出, "待执行", this.nodeID);
                          //  CtlDBAccess.Model.ControlTaskModel taskToRun = null;
                            
                            foreach (CtlDBAccess.Model.ControlTaskModel task in taskList)
                            {
                                if(0 != dlgtPathLockcheck(this,task,ref reStr))
                                {
                                    continue;
                                }
                                if(barcodeCheck)
                                {
                                    if (task.PalletCode == this.rfidUID)
                                    {
                                        this.currentTask = task;
                                        break;
                                    }
                                }
                                else
                                {
                                    this.currentTask = task;
                                    break;
                                }

                            }
                            if (this.currentTask == null)
                            {
                                this.currentTaskDescribe = string.Format("没有匹配托盘{0}的任务", this.rfidUID);
                                if (this.barcodeRW != null && barcodeCheck)
                                {
                                    if (SysCfg.SysCfgModel.SimMode)
                                    {
                                        this.rfidUID = this.SimRfidUID;
                                    }
                                    else
                                    {
                                        this.rfidUID = this.barcodeRW.ReadBarcode().Trim();//this.barcodeRW.Trim();
                                    }
                                   
                                    if (string.IsNullOrWhiteSpace(this.rfidUID))
                                    {
                                        break;
                                    }
                                }
                                break;
                            }
                            if (this.currentTask.TaskIndex == 1)
                            {
                                CtlDBAccess.BLL.MainControlTaskBll mainTaskBll = new CtlDBAccess.BLL.MainControlTaskBll();
                                CtlDBAccess.Model.MainControlTaskModel mainTask = mainTaskBll.GetModel(this.currentTask.MainTaskID);
                                if (dlgtHeightChecked != null)
                                {
                                    if(!dlgtHeightChecked(mainTask,db2Vals[2],ref reStr))
                                    {
                                        string strHeightExceed = string.Format("货物{0}超高，与{1}目标货位{2}冲突", this.rfidUID, mainTask.EndDevice, mainTask.EndDeviceParam);
                                        if(this.db1ValsToSnd[0] != 3)
                                        {
                                            logRecorder.AddDebugLog(nodeName, strHeightExceed);
                                        }
                                        this.currentTaskDescribe = strHeightExceed;
                                        this.db1ValsToSnd[0] = 3;
                                        break;
                                    }
                                }
                                if (mainTask != null)
                                {
                                    mainTask.TaskStatus = "执行中";
                                    mainTaskBll.Update(mainTask);
                                }
                            }
                            //发送任务参数
                            this.db1ValsToSnd[6] = 1;
                            this.db1ValsToSnd[7] = 21;
                            this.db1ValsToSnd[8] = (short)this.currentTask.ControlID;
                            this.db1ValsToSnd[9] = short.Parse(this.currentTask.EndDevice);
                            if (!string.IsNullOrWhiteSpace(this.rfidUID))
                            {
                                logRecorder.AddDebugLog(this.nodeName, "读到托盘号:" + this.rfidUID);
                            }
                            logRecorder.AddDebugLog(nodeName, string.Format("控制ID{0}执行到第2步,发送参数，等待PLC读数据完成",this.currentTask.ControlID));
                            this.currentTaskPhase++;
                            break;
                        }
                    case 3:
                        {
                            

                            this.db1ValsToSnd[5] = 1; //写入数据
                            this.currentTask.TaskStatus = "执行中";
                            ctlTaskBll.Update(currentTask);
                            //等待PLC 读数据完成
                            this.currentTaskDescribe = "等待输送机读数据完成";
                            if (this.db2Vals[5] != 2)
                            {
                                break;
                            }
                            this.db1ValsToSnd[5] = 2;
                            this.db1ValsToSnd[7] = 0;
                            this.db1ValsToSnd[8] = 0;
                            this.db1ValsToSnd[9] = 0;
                            logRecorder.AddDebugLog(nodeName, string.Format("控制ID{0}任务执行到第3步,参数复位",this.currentTask.ControlID));
                            this.currentTaskPhase++;
                            ctlTaskBll.Update(currentTask);
                            break;
                        }
                    case 4:
                        {
                            this.currentTaskDescribe = "输送任务发送完毕";
                            
                            currentTask = null;
                            break;
                        }
                    default:
                        {
                            break;
                        }
                }
                return true;
            }
            catch (Exception ex)
            {
                reStr = ex.ToString();
                return false;
            }
             
        }
        private bool ExeRecvTaskBusiness(ref string reStr)
        {
            try
            {
                switch (recvTaskPhase)
                {
                    case 1:
                        {
                            short controlID = this.db2Vals[7];
                            List<CtlDBAccess.Model.ControlTaskModel> taskList = ctlTaskBll.GetModelList(string.Format("TaskStatus='执行中' and ControlID={0} ", controlID));
                            if(taskList == null || taskList.Count()<1)
                            {
                                this.currentTaskDescribe = string.Format("不存在的任务号:{0}", controlID);
                                if(this.db1ValsToSnd[0] != 1)
                                {
                                    logRecorder.AddDebugLog(nodeName, string.Format("设备号{0}接收任务错误,不存在的控制ID{1}", nodeID, currentTask.ControlID));
                                }
                                this.db1ValsToSnd[0] = 1; //异常，1：不存在的控制ID
                                break;
                            }
                            else
                            {
                                //创建新的任务
                                 this.currentTask = taskList[0];
                                if(!dlgtCreateNextTask(this,this.currentTask,ref reStr))
                                {
                                    this.db1ValsToSnd[0] = 2;
                                    currentTaskDescribe = string.Format("发送下一步任务失败,主任务ID{0},{1}", this.currentTask.MainTaskID, reStr);
                                    Console.WriteLine(reStr);
                                    break;
                                }
                                this.currentTask.FinishTime = System.DateTime.Now;
                                this.currentTask.TaskStatus = "已完成";
                                this.db1ValsToSnd[6] = 2;
                                this.ctlTaskBll.Update(this.currentTask);
                                recvTaskPhase++;
                            }
                            break;
                        }
                    case 2:
                        {
                            //等待读写标志2
                            this.currentTaskDescribe = "等待读写标志：2";
                            if(this.db2Vals[5] !=2)
                            {
                                break;
                            }
                            logRecorder.AddDebugLog(nodeName, string.Format("控制ID{0} 任务完成收到", this.currentTask.ControlID));
                            this.db1ValsToSnd[6] = 1;
                            this.db1ValsToSnd[0] = 0;
                            recvTaskPhase++;
                            break;
                        }
                    case 3:
                        {
                            this.currentTaskDescribe = "任务处理完";
                            break;
                        }
                    default:
                        {
                            break;
                        }
                }
                return true;
            }
            catch (Exception ex)
            {
                reStr = ex.ToString();
                return false;
            }
        }

        public override bool WCSMainTaskStart(CtlDBAccess.Model.MainControlTaskModel mainTask, WCSFlowPathModel wcsPath, ref string reStr)
        {
            if (!base.WCSMainTaskStart(mainTask, wcsPath, ref reStr))
            {
                return false;
            }
            WCSPathNodeModel wcsNode= wcsPath.GetNodeByID(nodeID);
            WCSPathNodeModel wcsNodeNext = wcsPath.GetNodeByID(wcsNode.NextNodeID);
            CtlDBAccess.Model.ControlTaskModel ctlTask=null;
            ctlTask = new CtlDBAccess.Model.ControlTaskModel();
            ctlTask.TaskID = System.Guid.NewGuid().ToString();
            ctlTask.StDevice = nodeID;
            ctlTask.StDeviceCata = devCata;
            ctlTask.StDeviceParam = mainTask.StDeviceParam;
            ctlTask.EndDevice = wcsNode.NextNodeID;
            ctlTask.EndDeviceCata = wcsNodeNext.DevCata;
            ctlTask.EndDeviceParam = mainTask.EndDeviceParam;
            ctlTask.MainTaskID = mainTask.MainTaskID;
            ctlTask.PalletCode = mainTask.PalletCode;
            UInt16 controlID = ctlTaskBll.GetUnusedControlID();
            if (controlID < 1)
            {
                reStr = "没有可用的控制任务ID";
                return false;
            }
            ctlTask.ControlID = controlID;
            ctlTask.TaskIndex = 1;
            ctlTask.TaskParam = "";
            ctlTask.TaskStatus = "待执行";
            ctlTask.TaskPhase = 0;
            ctlTask.CreateTime = System.DateTime.Now;
            ctlTask.CreateMode = "自动";

            if(wcsNodeNext.DevCata=="库房")
            {
                ctlTask.DeviceID = wcsNodeNext.NodeID;
                ctlTask.DeviceCata ="堆垛机";
                ctlTask.TaskType = (int)SysCfg.EnumAsrsTaskType.产品入库;

            }
            else if(wcsNodeNext.DevCata=="RGV")
            {
                ctlTask.DeviceID = wcsNodeNext.NodeID;
                ctlTask.DeviceCata = wcsNodeNext.DevCata;
                ctlTask.TaskType = (int)SysCfg.EnumAsrsTaskType.RGV上下料;
            }
            else
            {
               
                ctlTask.DeviceID = nodeID;
                ctlTask.DeviceCata = devCata;
                ctlTask.TaskType = (int)SysCfg.EnumAsrsTaskType.输送机送出;
               
            }
            if(ctlTask == null)
            {
                return false;
            }
            bool re=ctlTaskBll.Add(ctlTask);
           // return re;
            if (re)
            {
                mainTask.TaskStatus = "已启动";
                CtlDBAccess.BLL.MainControlTaskBll mainTaskBll = new CtlDBAccess.BLL.MainControlTaskBll();
                return mainTaskBll.Update(mainTask);
            }
            else
            {
                return false;
            }

        }
       
    }
}
