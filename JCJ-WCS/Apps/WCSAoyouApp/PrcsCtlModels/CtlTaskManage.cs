using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using WMS_Interface;
using AsrsInterface;
namespace PrcsCtlModelsAoyou
{
    /// <summary>
    /// 实现WMS-wcs之间的任务管理，根据配置的路径，分解WMS任务成控制任务序列，控制执行的顺序。
    /// </summary>
    public class CtlTaskManage
    {
        private FlowCtlBaseModel.ThreadBaseModel taskMonitorThread = null; //WMS管理任务监控线程
        private CtlDBAccess.BLL.MainControlTaskBll mainCtlTaskBll = new CtlDBAccess.BLL.MainControlTaskBll();
        private CtlDBAccess.BLL.ControlTaskBll ctlTaskBll = new CtlDBAccess.BLL.ControlTaskBll();
        private List<TaskDeviceModel> wmsStDevList = new List<TaskDeviceModel>();
        private object pathCheckLock = new object();
        private Dictionary<string, FlowCtlBaseModel.WCSFlowPathModel> wcsPathMap = new Dictionary<string, FlowCtlBaseModel.WCSFlowPathModel>();
        public WMS_Interface.IWMSToWCSSvr WmsSvc{get;set;}
       
        public CtlManage.CtlNodeManage NodeManager { get; set; } 
        public CtlTaskManage()
        {

        }
        public bool Init()
        {
            wmsStDevList.AddRange(new TaskDeviceModel[] { new TaskDeviceModel("12112","工位"),new TaskDeviceModel("11001","货位"), new TaskDeviceModel("11002","货位"),new TaskDeviceModel("11003","货位"),
                new TaskDeviceModel( "11004","货位"),new TaskDeviceModel("11005","货位"), new TaskDeviceModel("11006","货位"), new TaskDeviceModel("11007","货位") });
            taskMonitorThread = new FlowCtlBaseModel.ThreadBaseModel("WMS任务监控线程");
            taskMonitorThread.LoopInterval = 2000;
            taskMonitorThread.SetThreadRoutine(WMSTaskMonitorProc);
            taskMonitorThread.TaskInit();
            foreach(FlowCtlBaseModel.CtlNodeBaseModel node in  NodeManager.MonitorNodeList)
            {
                node.dlgtCreateNextTask = CreateNodeNextTask;
                if(node.DevCata=="RGV")
                {
                    (node as TransDevModel.NodeRGV).dlgtTaskAllocate = RgvTasksndAllocate;
                }
                node.dlgtPathLockcheck = TaskLockCheck;
               
            }
            return true;
        }
        public bool StartRun()
        {
            string reStr = "";
            if(!taskMonitorThread.TaskStart(ref reStr))
            {
                Console.WriteLine("启动WMS任务监控线程失败," + reStr);
                return false;
            }
            return true;
        }
        public void PauseRun()
        {
            taskMonitorThread.TaskPause();
        }
         public bool ExitRun()
        {
            string reStr = "";
            return taskMonitorThread.TaskExit(ref reStr);
        }
        public bool BuildFlowPath(XElement root,ref string reStr)
        {
            try
            {
                IEnumerable<XElement> pathXES = root.Elements("Path");
                foreach(XElement pathXE in pathXES)
                {
                    FlowCtlBaseModel.WCSFlowPathModel wcsPath = new FlowCtlBaseModel.WCSFlowPathModel();
                    if(!wcsPath.BuildPath(pathXE,ref reStr))
                    {
                        return false;
                    }
                    foreach(FlowCtlBaseModel.WCSPathNodeModel wcsNode in wcsPath.NodeList)
                    {
                        FlowCtlBaseModel.CtlNodeBaseModel node = NodeManager.GetNodeByID(wcsNode.NodeID);
                        if(node.DevCata == "堆垛机")
                        {
                            wcsNode.DevCata = "库房";
                        }
                        else
                        {
                            wcsNode.DevCata = node.DevCata;
                        }
                        if(wcsNode.NodeFlag=="起点")
                        {
                            if(wcsNode.DevCata=="站台")
                            {
                                wcsPath.PathCata = "上架";
                            }
                            else
                            {
                                wcsPath.PathCata = "下架";
                            }
                        }
                    }
                    wcsPathMap[wcsPath.PathKey] = wcsPath;
                }
                return true;
            }
            catch (Exception ex)
            {
                reStr = ex.ToString();
                return false;
               
            }
           
        }
        #region 委托实现
        /// <summary>
        /// 设备执行任务之前，检查是否路径被锁定，防止上下架冲突
        /// </summary>
        /// <param name="curNode"></param>
        /// <param name="curTask"></param>
        /// <param name="reStr">若可用，返回0,1：路径被锁定，不可用,2:其它错误,-1:系统异常</param>
        /// <returns></returns>
        public int TaskLockCheck(FlowCtlBaseModel.CtlNodeBaseModel curNode,CtlDBAccess.Model.ControlTaskModel curTask, ref string reStr)
        {
            try
            {
                lock(pathCheckLock)
                {
                    if(curTask==null)
                    {
                        reStr = "任务为空";
                        return 2;
                    }
                    CtlDBAccess.Model.MainControlTaskModel mainTask= mainCtlTaskBll.GetModel(curTask.MainTaskID);
                    if(!wcsPathMap.Keys.Contains(mainTask.FlowPathKey))
                    {
                        reStr = "不存在的路径：" + mainTask.FlowPathKey;
                        return 2;
                    }
                    FlowCtlBaseModel.WCSFlowPathModel wcsPath = wcsPathMap[mainTask.FlowPathKey];
                    if(wcsPath.PathCata =="上架")
                    {
                       // List<CtlDBAccess.Model.MainControlTaskModel> lockedMaintaskList = GetLockedTaskList(curNode, "下架");
                        if (!NodeLockedBytask(curNode,"下架"))
                        {
                            return 0;
                        }
                        else
                        {
                            return 1;
                        }
                    }
                    else if(wcsPath.PathCata=="下架")
                    {
                        //List<CtlDBAccess.Model.MainControlTaskModel> lockedMaintaskList = GetLockedTaskList(curNode, "上架");
                        if (!NodeLockedBytask(curNode, "上架"))
                        {
                            return 0;
                        }
                        else
                        {
                            return 1;
                        }
                    }
                    else
                    {
                        return 0;
                    }
                    
                }
            }
            catch (Exception ex)
            {
                reStr = ex.ToString();
                return -1;
               
            }
            
        }
        public bool CreateNodeNextTask(FlowCtlBaseModel.CtlNodeBaseModel curNode, CtlDBAccess.Model.ControlTaskModel curTask, ref string reStr)
        {
            try
            {
                CtlDBAccess.Model.MainControlTaskModel mainTask = mainCtlTaskBll.GetModel(curTask.MainTaskID);
                if (mainTask == null)
                {
                    reStr = "主任务为空,不存在的主任务ID:" + curTask.MainTaskID;
                    return false;
                }
                FlowCtlBaseModel.WCSFlowPathModel wcsPath = null;
                if (wcsPathMap.Keys.Contains(mainTask.FlowPathKey))
                {
                    wcsPath = wcsPathMap[mainTask.FlowPathKey];
                }
                else
                {
                    reStr = "路径不存在:" + mainTask.FlowPathKey;
                    return false;
                }

                FlowCtlBaseModel.WCSPathNodeModel wcsNode = wcsPath.GetNodeByID(curNode.NodeID);
                if (wcsNode.NodeFlag == "终点")
                {
                    //管理任务完成
                    WMS_Interface.ResposeData res = WmsSvc.UpdateManageTaskStatus(mainTask.WMSTaskID, "已完成");
                    if (!res.Status)
                    {
                        reStr = string.Format("更新WMS任务:{0}状态失败,{1}", mainTask.WMSTaskID, res.Describe);
                        return false;
                    }
                    mainTask.TaskStatus = "已完成";
                    mainTask.FinishTime = System.DateTime.Now;
                    if (!mainCtlTaskBll.Update(mainTask))
                    {
                        reStr = string.Format("更新主控制任务:{0}状态失败", mainTask.MainTaskID);
                        return false;
                    }
                    return true;
                }
                FlowCtlBaseModel.CtlNodeBaseModel nextNode = NodeManager.GetNodeByID(wcsNode.NextNodeID);
                if (curNode.DevCata == "站台")
                {
                    if (nextNode.DevCata == "站台")
                    {
                        CtlDBAccess.Model.ControlTaskModel nextCtlTask = CreateConveyorTask(curTask.TaskIndex + 1, mainTask.MainTaskID, curNode as TransDevModel.NodeTransStation, nextNode as TransDevModel.NodeTransStation, curTask.PalletCode, ref reStr);
                        if (nextCtlTask == null)
                        {
                            return false;
                        }
                        return ctlTaskBll.Add(nextCtlTask);
                    }
                    else if (nextNode.DevCata == "RGV")
                    {
                        FlowCtlBaseModel.WCSPathNodeModel rgvTargetWcsNode = wcsPath.GetNodeByID(wcsNode.NextNodeID);
                        FlowCtlBaseModel.CtlNodeBaseModel nextNode2 = NodeManager.GetNodeByID(rgvTargetWcsNode.NextNodeID);
                        if (nextNode2 == null)
                        {
                            reStr = "不存在的设备号：" + wcsNode.NextNodeID;
                            return false;
                        }
                        FlowCtlBaseModel.WCSPathNodeModel nextWcsNode = wcsPath.GetNodeByID(nextNode2.NodeID);
                        if (nextWcsNode == null)
                        {
                            reStr = "路径配置，RGV路径缺少下料站台";
                            return false;
                        }
                        CtlDBAccess.Model.ControlTaskModel nextCtlTask = CreateRGVTask(curTask.TaskIndex + 1, mainTask.MainTaskID, nextNode as TransDevModel.NodeRGV, curNode as TransDevModel.NodeTransStation, nextNode2 as TransDevModel.NodeTransStation, curTask.PalletCode, ref reStr);
                        if (nextCtlTask == null)
                        {
                            return false;
                        }
                        return ctlTaskBll.Add(nextCtlTask);
                    }
                    else if (nextNode.DevCata == "堆垛机")
                    {

                        CtlDBAccess.Model.ControlTaskModel nextCtlTask = CreateStackerTask(curTask.TaskIndex + 1, mainTask, nextNode.NodeID, curNode as TransDevModel.NodeTransStation, curTask.PalletCode, ref reStr);
                        if (nextCtlTask == null)
                        {
                            return false;
                        }
                        return ctlTaskBll.Add(nextCtlTask);
                    }
                }
                else if (curNode.DevCata == "RGV")
                {
                    if (nextNode.DevCata != "站台")
                    {
                        reStr = "RGV目标设备应该为站台";
                        return false;
                    }
                    FlowCtlBaseModel.WCSPathNodeModel rgvTargetWcsNode = wcsPath.GetNodeByID(wcsNode.NextNodeID);
                    if (rgvTargetWcsNode.NodeFlag == "终点")
                    {
                        mainTask.TaskStatus = "已完成";
                        mainTask.FinishTime = System.DateTime.Now;
                        if (!mainCtlTaskBll.Update(mainTask))
                        {
                            reStr = string.Format("更新主控制任务:{0}状态失败", mainTask.MainTaskID);
                            return false;
                        }
                        //管理任务完成
                        WMS_Interface.ResposeData res = WmsSvc.UpdateManageTaskStatus(mainTask.WMSTaskID, "已完成");
                        if (!res.Status)
                        {
                            reStr = string.Format("更新WMS任务:{0}状态失败,{1}", mainTask.WMSTaskID, res.Describe);
                            return false;
                        }
                        return true;
                    }
                    FlowCtlBaseModel.CtlNodeBaseModel rgvTargetNode = NodeManager.GetNodeByID(rgvTargetWcsNode.NodeID);
                    FlowCtlBaseModel.CtlNodeBaseModel nextNode2 = NodeManager.GetNodeByID(rgvTargetWcsNode.NextNodeID);
                    if (nextNode2.DevCata == "站台")
                    {
                        CtlDBAccess.Model.ControlTaskModel nextCtlTask = CreateConveyorTask(curTask.TaskIndex + 1, mainTask.MainTaskID, rgvTargetNode as TransDevModel.NodeTransStation, nextNode2 as TransDevModel.NodeTransStation, curTask.PalletCode, ref reStr);
                        if (nextCtlTask == null)
                        {
                            return false;
                        }
                        return ctlTaskBll.Add(nextCtlTask);
                    }
                    else if (nextNode2.DevCata == "堆垛机")
                    {
                        CtlDBAccess.Model.ControlTaskModel nextCtlTask = CreateStackerTask(curTask.TaskIndex + 1, mainTask, nextNode2.NodeID, rgvTargetNode as TransDevModel.NodeTransStation, curTask.PalletCode, ref reStr);
                        if (nextCtlTask == null)
                        {
                            return false;
                        }
                        return ctlTaskBll.Add(nextCtlTask);
                    }
                    else
                    {
                        reStr = "错误的路径配置，两台RGV不允许共用一个接驳站台";
                        return false;
                    }
                }
                else if (curNode.DevCata == "堆垛机")
                {
                    if (nextNode.DevCata != "站台")
                    {
                        reStr = "堆垛机目标设备应该为站台";
                        return false;
                    }
                    FlowCtlBaseModel.WCSPathNodeModel targetWcsNode = wcsPath.GetNodeByID(wcsNode.NextNodeID);
                    if (targetWcsNode.NodeFlag == "终点")
                    {
                        mainTask.TaskStatus = "已完成";
                        mainTask.FinishTime = System.DateTime.Now;
                        if (!mainCtlTaskBll.Update(mainTask))
                        {
                            reStr = string.Format("更新主控制任务:{0}状态失败", mainTask.MainTaskID);
                            return false;
                        }
                        //管理任务完成
                        WMS_Interface.ResposeData res = WmsSvc.UpdateManageTaskStatus(mainTask.WMSTaskID, "已完成");
                        if (!res.Status)
                        {
                            reStr = string.Format("更新WMS任务:{0}状态失败,{1}", mainTask.WMSTaskID, res.Describe);
                            return false;
                        }
                        return true;
                    }
                    FlowCtlBaseModel.CtlNodeBaseModel nextNode2 = NodeManager.GetNodeByID(targetWcsNode.NextNodeID);
                    if (nextNode2.DevCata == "站台")
                    {
                        CtlDBAccess.Model.ControlTaskModel nextCtlTask = CreateConveyorTask(curTask.TaskIndex + 1, mainTask.MainTaskID, nextNode as TransDevModel.NodeTransStation, nextNode2 as TransDevModel.NodeTransStation, curTask.PalletCode, ref reStr);
                        if (nextCtlTask == null)
                        {
                            return false;
                        }
                        return ctlTaskBll.Add(nextCtlTask);
                    }
                    else if (nextNode2.DevCata == "RGV")
                    {
                        FlowCtlBaseModel.WCSPathNodeModel targetWcsNode2 = wcsPath.GetNodeByID(nextNode2.NodeID);
                        FlowCtlBaseModel.CtlNodeBaseModel nextNode3 = NodeManager.GetNodeByID(targetWcsNode2.NextNodeID);
                        if (nextNode3 == null)
                        {
                            return false;
                        }
                        CtlDBAccess.Model.ControlTaskModel nextCtlTask = CreateRGVTask(curTask.TaskIndex + 1, mainTask.MainTaskID, nextNode2 as TransDevModel.NodeRGV, nextNode as TransDevModel.NodeTransStation, nextNode3 as TransDevModel.NodeTransStation, curTask.PalletCode, ref reStr);
                        if (nextCtlTask == null)
                        {
                            return false;
                        }
                        return ctlTaskBll.Add(nextCtlTask);
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                reStr = ex.ToString();
                Console.WriteLine(ex.ToString());
                return false;
            }
        }
        #endregion
        private bool NodeLockedBytask(FlowCtlBaseModel.CtlNodeBaseModel curNode,string mainTaskCata)
        {
            foreach (string pathKey in wcsPathMap.Keys)
            {
                FlowCtlBaseModel.WCSFlowPathModel wcsPath = wcsPathMap[pathKey];
                if (wcsPath.PathCata != mainTaskCata)
                {
                    continue;
                }
                if(!wcsPath.ContainNode(curNode.NodeID))
                {
                    continue;
                }
                List<CtlDBAccess.Model.MainControlTaskModel> taskList =mainCtlTaskBll.GetModelList(string.Format("FlowPathKey ='{0}' and TaskStatus='执行中'", pathKey));
                if(taskList != null && taskList.Count()>0)
                {
                    return true;
                }
            }
            return false;
        }
        //private List<CtlDBAccess.Model.MainControlTaskModel>  GetLockedTaskList(FlowCtlBaseModel.CtlNodeBaseModel curNode,string mainTaskCata)
        //{
        //    List<CtlDBAccess.Model.MainControlTaskModel> lockedTaskList = new List<CtlDBAccess.Model.MainControlTaskModel>();
        //    foreach(string pathKey in wcsPathMap.Keys)
        //    {
        //        FlowCtlBaseModel.WCSFlowPathModel wcsPath = wcsPathMap[pathKey];
        //        if(wcsPath.PathCata != mainTaskCata)
        //        {
        //            continue;
        //        }
                
        //    }
        //}
        private CtlDBAccess.Model.ControlTaskModel CreateConveyorTask(int taskIndex, string mainTaskID, TransDevModel.NodeTransStation stNode, TransDevModel.NodeTransStation targetNode, string palletID, ref string reStr)
        {
           
            CtlDBAccess.Model.ControlTaskModel nextCtlTask = new CtlDBAccess.Model.ControlTaskModel();
            short nextCtlID = (short)ctlTaskBll.GetUnusedControlID();
            if (nextCtlID == 0)
            {
                reStr = "没有可用的控制ID";
                return null;
            }
            nextCtlTask.TaskID = System.Guid.NewGuid().ToString();
            nextCtlTask.DeviceID = stNode.NodeID;
            nextCtlTask.DeviceCata = stNode.DevCata;
            nextCtlTask.StDevice = stNode.NodeID;
            nextCtlTask.StDeviceCata = stNode.DevCata;
            nextCtlTask.StDeviceParam = "";
            nextCtlTask.EndDevice = targetNode.NodeID;
            nextCtlTask.EndDeviceCata = targetNode.DevCata;
            nextCtlTask.EndDeviceParam = "";
            nextCtlTask.MainTaskID = mainTaskID;
            nextCtlTask.PalletCode = palletID;
            nextCtlTask.ControlID = nextCtlID;
            nextCtlTask.TaskIndex = taskIndex;
            nextCtlTask.TaskType = 21;
            nextCtlTask.TaskParam = "";
            nextCtlTask.TaskStatus = "待执行";
            nextCtlTask.TaskPhase = 0;
            nextCtlTask.CreateTime = System.DateTime.Now;
            nextCtlTask.CreateMode = "自动";
            return nextCtlTask;
        }
        private CtlDBAccess.Model.ControlTaskModel CreateRGVTask(int taskIndex, string mainTaskID, TransDevModel.NodeRGV rgv, TransDevModel.NodeTransStation stNode, TransDevModel.NodeTransStation targetNode, string palletID, ref string reStr)
        {
            CtlDBAccess.Model.ControlTaskModel nextCtlTask = new CtlDBAccess.Model.ControlTaskModel();
            short nextCtlID = (short)ctlTaskBll.GetUnusedControlID();
            if (nextCtlID == 0)
            {
                reStr = "没有可用的控制ID";
                return null;
            }
            nextCtlTask.TaskID = System.Guid.NewGuid().ToString();
            nextCtlTask.DeviceID = rgv.NodeID;
            nextCtlTask.DeviceCata = rgv.DevCata;
            nextCtlTask.StDevice = stNode.NodeID;
            nextCtlTask.StDeviceCata = stNode.DevCata;
            nextCtlTask.StDeviceParam = "";
            nextCtlTask.EndDevice = targetNode.NodeID;
            nextCtlTask.EndDeviceCata = targetNode.DevCata;
            nextCtlTask.EndDeviceParam = "";
            nextCtlTask.MainTaskID = mainTaskID;
            nextCtlTask.PalletCode = palletID;
            nextCtlTask.ControlID = nextCtlID;
            nextCtlTask.TaskIndex = taskIndex;
            nextCtlTask.TaskType = 13;
            nextCtlTask.TaskParam = "";
            nextCtlTask.TaskStatus = "待执行";
            nextCtlTask.TaskPhase = 0;
            nextCtlTask.CreateTime = System.DateTime.Now;
            nextCtlTask.CreateMode = "自动";
            return nextCtlTask;
        }
        private CtlDBAccess.Model.ControlTaskModel CreateStackerTask(int taskIndex, CtlDBAccess.Model.MainControlTaskModel mainTask, string stackerNodeID,TransDevModel.NodeTransStation portNode, string palletID,ref string reStr)
        {
            CtlDBAccess.Model.ControlTaskModel nextCtlTask = new CtlDBAccess.Model.ControlTaskModel();
            short nextCtlID = (short)ctlTaskBll.GetUnusedControlID();
            if (nextCtlID == 0)
            {
                reStr = "没有可用的控制ID";
                return null;
            }

            nextCtlTask.TaskID = System.Guid.NewGuid().ToString();
            nextCtlTask.DeviceID = stackerNodeID;
            nextCtlTask.DeviceCata = "堆垛机";
           
            if (mainTask.TaskType == "上架")
            {
                nextCtlTask.StDevice = portNode.NodeID;
                nextCtlTask.StDeviceCata = portNode.DevCata;
                nextCtlTask.StDeviceParam = "";
                nextCtlTask.EndDevice = stackerNodeID;
                nextCtlTask.EndDeviceCata = "货位";
                nextCtlTask.EndDeviceParam = mainTask.EndDeviceParam;
                nextCtlTask.TaskType = (int)SysCfg.EnumAsrsTaskType.产品入库;
            }
            else if (mainTask.TaskType == "下架")
            {
                nextCtlTask.StDevice = stackerNodeID;
                nextCtlTask.StDeviceCata = "货位";
                nextCtlTask.StDeviceParam = mainTask.StDeviceParam;
                nextCtlTask.EndDevice = portNode.NodeID;
                nextCtlTask.EndDeviceCata = portNode.DevCata;
                nextCtlTask.EndDeviceParam = "";
                nextCtlTask.TaskType = (int)SysCfg.EnumAsrsTaskType.产品出库;
            
            }
            else
            {
                throw new NotImplementedException();
            }
            nextCtlTask.MainTaskID = mainTask.MainTaskID;
            nextCtlTask.PalletCode = palletID;
            nextCtlTask.ControlID = nextCtlID;
            nextCtlTask.TaskIndex = taskIndex;
            nextCtlTask.TaskParam = "";
            nextCtlTask.TaskStatus = "待执行";
            nextCtlTask.TaskPhase = 0;
            nextCtlTask.CreateTime = System.DateTime.Now;
            nextCtlTask.CreateMode = "自动";
            return nextCtlTask;
        }
       
        /// <summary>
       /// RGV任务调度
       /// </summary>
       /// <param name="ctlTaskList"></param>
       /// <param name="reStr"></param>
       /// <returns></returns>
        private CtlDBAccess.Model.ControlTaskModel RgvTasksndAllocate(TransDevModel.NodeRGV rgv, ref string reStr)
        {
            CtlDBAccess.Model.ControlTaskModel ctlTask = null;
            List<CtlDBAccess.Model.ControlTaskModel> taskList = ctlTaskBll.GetTaskToRunList((int)SysCfg.EnumAsrsTaskType.RGV上下料, SysCfg.EnumTaskStatus.待执行.ToString(), rgv.NodeID, true);
            foreach(CtlDBAccess.Model.ControlTaskModel taskModel in taskList)
            {
                if(0 != TaskLockCheck(rgv,taskModel,ref reStr))
                {
                    continue;
                }
                string devSt = taskModel.StDevice;
                string devTarget = taskModel.EndDevice;
                FlowCtlBaseModel.CtlNodeBaseModel stNode= NodeManager.GetNodeByID(devSt);
                FlowCtlBaseModel.CtlNodeBaseModel targetNode = NodeManager.GetNodeByID(devTarget);
                if(stNode == null || stNode.DevCata != "站台")
                {
                    continue;
                }
                if(targetNode == null || targetNode.DevCata != "站台")
                {
                    continue;
                }
                //起点有板，终点空闲，无板
                if(stNode.Db2Vals[0] == 2 && targetNode.Db2Vals[0] ==1)
                {
                    ctlTask = taskModel;
                    break;
                }

            }
            return ctlTask;
        }
        private void WMSTaskMonitorProc()
        {
            foreach(TaskDeviceModel stDev in wmsStDevList)
            {
                List<ManageTaskModel> wmsTasks= new List<ManageTaskModel>();
                ResposeData res= WmsSvc.GetWaittingToRunTaskList(stDev, ref wmsTasks);
                if(!res.Status)
                {
                    Console.WriteLine("获取{0}待执行管理任务失败{1}",stDev.DeviceCode,res.Describe);
                    continue;
                }
                foreach(ManageTaskModel wmsTask in wmsTasks)
                {
                    if(mainCtlTaskBll.Exists(wmsTask.TaskID))
                    {
                        continue;
                    }
                    CtlDBAccess.Model.MainControlTaskModel mainCtlTask = new CtlDBAccess.Model.MainControlTaskModel();
                    mainCtlTask.WMSTaskID = wmsTask.TaskID;
                    mainCtlTask.MainTaskID = wmsTask.TaskID;
                    mainCtlTask.FlowPathKey = wmsTask.StartDevice.DeviceCode + "-" + wmsTask.TargetDevice.DeviceCode;
                    mainCtlTask.PalletCode = wmsTask.PalletCode;
                    mainCtlTask.TaskStatus = "待执行";
                    //if(wmsTask.Type == "下架")
                    //{
                    //    mainCtlTask.TaskType = "产品出库";
                    //}
                    //else if(wmsTask.Type=="上架")
                    //{
                    //    mainCtlTask.TaskType = "产品入库";
                    //}
                    //else
                    //{
                    //    mainCtlTask.TaskType = wmsTask.Type;
                    //}
                    mainCtlTask.TaskType = wmsTask.Type;
     
                    mainCtlTask.StDevice = wmsTask.StartDevice.DeviceCode;
                    mainCtlTask.StDeviceCata = wmsTask.StartDevice.DeviceType;
                    mainCtlTask.EndDevice = wmsTask.TargetDevice.DeviceCode;
                    mainCtlTask.EndDeviceCata = wmsTask.TargetDevice.DeviceType;
                    if(wmsTask.StartDevice.DeviceType=="货位")
                    {
                        mainCtlTask.StDeviceParam = wmsTask.StartDevice.ExtParam;
                    }
                    if(wmsTask.TargetDevice.DeviceType=="货位")
                    {
                        mainCtlTask.EndDeviceParam = wmsTask.TargetDevice.ExtParam;
                    }
                    mainCtlTask.CreateTime = System.DateTime.Now;
                    mainCtlTask.CreateMode = "自动";
                    mainCtlTaskBll.Add(mainCtlTask);

                }
            }
            string reStr = "";
            //分解主控制任务
            List<CtlDBAccess.Model.MainControlTaskModel> mainTasks = mainCtlTaskBll.GetModelList("TaskStatus = '待启动'");
            foreach (CtlDBAccess.Model.MainControlTaskModel mainTask in mainTasks)
            {
                string pathKey = mainTask.FlowPathKey;
                if (!wcsPathMap.Keys.Contains(pathKey))
                {
                    Console.WriteLine("不存在的路径配置：{0}", pathKey);
                    continue;
                }
                FlowCtlBaseModel.WCSFlowPathModel wcsPath = wcsPathMap[pathKey];
                if (wcsPath.NodeList.Count() < 1)
                {
                    continue;
                }
                FlowCtlBaseModel.WCSPathNodeModel stNode = wcsPath.NodeList[0];
                if (stNode.NodeFlag != "起点")
                {
                    continue;
                }
                string nodeID = stNode.NodeID;
                FlowCtlBaseModel.CtlNodeBaseModel node = NodeManager.GetNodeByID(nodeID);
                if (node == null)
                {
                    continue;
                }
                if(node.DevCata=="站台")
                {
                    if(node.Db2Vals[0] !=2)
                    {
                        continue;
                    }
                }
                if (!node.WCSMainTaskStart(mainTask, wcsPath, ref reStr))
                {
                    Console.WriteLine("{0} 启动任务：{1}失败,{2}", node.NodeName, mainTask.WMSTaskID, reStr);
                }
                else
                {
                    WmsSvc.UpdateManageTaskStatus(mainTask.WMSTaskID, "执行中");
                    Console.WriteLine("主控制任务{0},{1}->{2}准备启动", mainTask.MainTaskID, mainTask.StDevice, mainTask.EndDevice);
                }
            }
            /*
            foreach(string pathKey in wcsPathMap.Keys)
            {
                FlowCtlBaseModel.WCSFlowPathModel wcsPath = wcsPathMap[pathKey];
                if(wcsPath.NodeList.Count()<1)
                {
                    continue;
                }
                
                FlowCtlBaseModel.WCSPathNodeModel stNode= wcsPath.NodeList[0];
                if(stNode.NodeFlag !="起点")
                {
                    continue;
                }
                string nodeID = stNode.NodeID;
                FlowCtlBaseModel.CtlNodeBaseModel node = NodeManager.GetNodeByID(nodeID);
                if(node == null)
                {
                    continue;
                }
                //生成第一个控制任务
                List<CtlDBAccess.Model.MainControlTaskModel> mainTasks= mainCtlTaskBll.GetModelList(string.Format("TaskStatus = '待执行' and StDevice='{0}'", nodeID));
                foreach(CtlDBAccess.Model.MainControlTaskModel mainTask in mainTasks)
                {
                    if(!node.WCSMainTaskStart(mainTask, wcsPath, ref reStr))
                    {
                        Console.WriteLine("{0} 启动任务：{1}失败,{2}", node.NodeName, mainTask.WMSTaskID,reStr);
                    }
                    else
                    {
                        WmsSvc.UpdateManageTaskStatus(mainTask.WMSTaskID, "执行中");
                    }
                }
            }*/
        }
    }
}
