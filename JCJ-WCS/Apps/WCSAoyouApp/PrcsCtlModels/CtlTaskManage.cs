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
            taskMonitorThread.LoopInterval = 5000;
            taskMonitorThread.SetThreadRoutine(WMSTaskMonitorProc);
            taskMonitorThread.TaskInit();
            foreach(FlowCtlBaseModel.CtlNodeBaseModel node in  NodeManager.MonitorNodeList)
            {
                node.dlgtCreateNextTask = CreateNodeNextTask;
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
        public bool CreateNodeNextTask(FlowCtlBaseModel.CtlNodeBaseModel curNode, CtlDBAccess.Model.ControlTaskModel curTask,ref string reStr)
        {
            try
            {
                CtlDBAccess.Model.MainControlTaskModel mainTask = mainCtlTaskBll.GetModel(curTask.MainTaskID);
                if(mainTask==null)
                {
                    reStr = "主任务为空,不存在的主任务ID:" + curTask.MainTaskID;
                    return false;
                }
                FlowCtlBaseModel.WCSFlowPathModel wcsPath = null;
                if(wcsPathMap.Keys.Contains(mainTask.FlowPathKey))
                {
                    wcsPath = wcsPathMap[mainTask.FlowPathKey];
                }
                else
                {
                    reStr = "路径不存在:"+mainTask.FlowPathKey;
                    return false;
                }
              
                FlowCtlBaseModel.WCSPathNodeModel wcsNode = wcsPath.GetNodeByID(curNode.NodeID);
                if(wcsNode.NodeFlag== "终点")
                {
                    //管理任务完成
                    WMS_Interface.ResposeData res= WmsSvc.UpdateManageTaskStatus(mainTask.WMSTaskID, "已完成");
                    if(!res.Status)
                    {
                        reStr = string.Format("更新WMS任务:{0}状态失败",mainTask.WMSTaskID);
                        return false;
                    }
                    mainTask.TaskStatus = "已完成";
                    if(!mainCtlTaskBll.Update(mainTask))
                    {
                        reStr = string.Format("更新主控制任务:{0}状态失败",mainTask.MainTaskID);
                        return false;
                    }
                    return true;
                }
                FlowCtlBaseModel.CtlNodeBaseModel nextNode= NodeManager.GetNodeByID(wcsNode.NextNodeID);
                if(curNode.DevCata=="站台")
                {
                    if (nextNode.DevCata == "站台")
                    {
                        CtlDBAccess.Model.ControlTaskModel nextCtlTask = CreateConveyorTask(curTask.TaskIndex + 1, mainTask.MainTaskID, curNode as TransDevModel.NodeTransStation, nextNode as TransDevModel.NodeTransStation, curTask.PalletCode, ref reStr);
                        if(nextCtlTask == null)
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
                        if(nextCtlTask==null)
                        {
                            return false;
                        }
                        return ctlTaskBll.Add(nextCtlTask);
                    }
                    else if (nextNode.DevCata == "堆垛机")
                    {

                        CtlDBAccess.Model.ControlTaskModel nextCtlTask = CreateStackerTask(curTask.TaskIndex + 1, mainTask,nextNode.NodeID, curNode as TransDevModel.NodeTransStation, curTask.PalletCode, ref reStr);
                        if(nextCtlTask == null)
                        {
                            return false;
                        }
                        return ctlTaskBll.Add(nextCtlTask);
                    }
                }
                else if(curNode.DevCata=="RGV")
                {
                    if(nextNode.DevCata != "站台")
                    {
                        reStr = "RGV目标设备应该为站台";
                        return false;
                    }
                    FlowCtlBaseModel.WCSPathNodeModel rgvTargetWcsNode = wcsPath.GetNodeByID(wcsNode.NextNodeID);
                    if (rgvTargetWcsNode.NodeFlag == "终点")
                    {
                        //管理任务完成
                        WmsSvc.UpdateManageTaskStatus(mainTask.WMSTaskID, "已完成");
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
                    else if(nextNode2.DevCata=="堆垛机")
                    {
                        CtlDBAccess.Model.ControlTaskModel nextCtlTask = CreateStackerTask(curTask.TaskIndex + 1,mainTask, nextNode2.NodeID, rgvTargetNode as TransDevModel.NodeTransStation, curTask.PalletCode, ref reStr);
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
                else if(curNode.DevCata=="堆垛机")
                {
                    if (nextNode.DevCata != "站台")
                    {
                        reStr = "堆垛机目标设备应该为站台";
                        return false;
                    }
                    FlowCtlBaseModel.WCSPathNodeModel targetWcsNode = wcsPath.GetNodeByID(wcsNode.NextNodeID);
                    if (targetWcsNode.NodeFlag == "终点")
                    {
                        //管理任务完成
                        WmsSvc.UpdateManageTaskStatus(mainTask.WMSTaskID, "已完成");
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
                    else if(nextNode2.DevCata=="RGV")
                    {
                        FlowCtlBaseModel.WCSPathNodeModel targetWcsNode2 = wcsPath.GetNodeByID(nextNode2.NodeID);
                        FlowCtlBaseModel.CtlNodeBaseModel nextNode3 = NodeManager.GetNodeByID(targetWcsNode2.NextNodeID);
                        if(nextNode3==null)
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
                return false;
            }
        }
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
            SysCfg.EnumAsrsTaskType enumTasktype = (SysCfg.EnumAsrsTaskType)Enum.Parse(typeof(SysCfg.EnumAsrsTaskType), mainTask.TaskType);
            
            nextCtlTask.TaskID = System.Guid.NewGuid().ToString();
            nextCtlTask.DeviceID = stackerNodeID;
            nextCtlTask.DeviceCata = "堆垛机";
            nextCtlTask.TaskType = (int)enumTasktype;
            if (mainTask.TaskType == SysCfg.EnumAsrsTaskType.产品入库.ToString() || mainTask.TaskType == SysCfg.EnumAsrsTaskType.空筐入库.ToString())
            {
                nextCtlTask.StDevice = portNode.NodeID;
                nextCtlTask.StDeviceCata = portNode.DevCata;
                nextCtlTask.StDeviceParam = "";
                nextCtlTask.EndDevice = stackerNodeID;
                nextCtlTask.EndDeviceCata = "货位";
                nextCtlTask.EndDeviceParam = mainTask.EndDeviceParam;
            }
            else if (mainTask.TaskType == SysCfg.EnumAsrsTaskType.产品出库.ToString() || mainTask.TaskType == SysCfg.EnumAsrsTaskType.空筐出库.ToString())
            {
                nextCtlTask.StDevice = stackerNodeID;
                nextCtlTask.StDeviceCata = "货位";
                nextCtlTask.StDeviceParam = mainTask.StDeviceParam;
                nextCtlTask.EndDevice = portNode.NodeID;
                nextCtlTask.EndDeviceCata = portNode.DevCata;
                nextCtlTask.EndDeviceParam = "";
            
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
        private void WMSTaskMonitorProc()
        {
            foreach(TaskDeviceModel stDev in wmsStDevList)
            {
                List<ManageTaskModel> wmsTasks= new List<ManageTaskModel>();
                ResposeData res= WmsSvc.GetWaittingToRunTaskList(stDev, ref wmsTasks);
                if(!res.Status)
                {
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
            }
        }


    }
}
