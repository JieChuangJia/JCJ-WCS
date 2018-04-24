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
        private int taskMode = 0;
        private int recvTaskPhase = 0;
        protected int transMode = 0; //输送站台任务模式,0:不发任务，也不收任务，1：只发任务，2：只收任务
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
                        this.currentTaskDescribe = "设备空闲，等待新的任务";
                        recvTaskPhase = 0;
                        currentTask = null;

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
        private bool ExeSndTaskBusiness(ref string reStr)
        {
            try
            {
                switch (this.currentTaskPhase)
                {
                    case 1:
                        {
                            this.currentTaskDescribe = "等待有板信号";
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
                                if(this.barcodeRW != null)
                                {
                                    this.rfidUID = this.barcodeRW.ReadBarcode().Trim();//this.barcodeRW.Trim();
                                }
                                logRecorder.AddDebugLog(this.nodeName, "读到托盘号:" + this.rfidUID);
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
                                if(string.IsNullOrWhiteSpace(this.rfidUID))
                                {
                                    this.currentTask = task;
                                    break;
                                }
                                else
                                {
                                    if (task.PalletCode == this.rfidUID)
                                    {
                                        this.currentTask = task;
                                        break;
                                    }
                                }
                                
                            }
                            if (this.currentTask == null)
                            {
                                this.currentTaskDescribe = string.Format("没有匹配托盘{0}的任务", this.rfidUID);
                                break;
                            }
                            //发送任务参数
                            this.db1ValsToSnd[6] = 1;
                            this.db1ValsToSnd[7] = 21;
                            this.db1ValsToSnd[8] = (short)this.currentTask.ControlID;
                            this.db1ValsToSnd[9] = short.Parse(this.currentTask.EndDevice);

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
                            }
                            else
                            {
                                //创建新的任务
                                 this.currentTask = taskList[0];
                                if(!dlgtCreateNextTask(this,this.currentTask,ref reStr))
                                {
                                    break;
                                }
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
                            this.db1ValsToSnd[6] = 1;
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
            CtlDBAccess.Model.ControlTaskModel ctlTask = new CtlDBAccess.Model.ControlTaskModel();
            ctlTask.TaskID = System.Guid.NewGuid().ToString();
            ctlTask.DeviceID = nodeID;
            ctlTask.DeviceCata = devCata;
            ctlTask.StDevice = nodeID;
            ctlTask.StDeviceCata = devCata;
            ctlTask.StDeviceParam = "";
            ctlTask.EndDevice = wcsNode.NextNodeID;
            ctlTask.EndDeviceCata = wcsNodeNext.DevCata;
            ctlTask.EndDeviceParam = "";
            ctlTask.MainTaskID = mainTask.MainTaskID;
            ctlTask.PalletCode = mainTask.PalletCode;
            UInt16 controlID= ctlTaskBll.GetUnusedControlID();
            if(controlID<1)
            {
                reStr = "没有可用的控制任务ID";
                return false;
            }
            ctlTask.ControlID = controlID;
            ctlTask.TaskIndex = 1;
            ctlTask.TaskType = (int)SysCfg.EnumAsrsTaskType.输送机送出;
            ctlTask.TaskParam = "";
            ctlTask.TaskStatus = "待执行";
            ctlTask.TaskPhase = 0;
            ctlTask.CreateTime = System.DateTime.Now;
            ctlTask.CreateMode = "自动";
            bool re=ctlTaskBll.Add(ctlTask);
            if(re)
            {
                mainTask.TaskStatus = "执行中";
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
