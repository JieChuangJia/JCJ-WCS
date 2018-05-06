using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using System.Data;
using FlowCtlBaseModel;
using CtlMonitorInterface;
namespace CtlManage
{
    public class CtlNodeManage : ICtlnodeMonitor
    {
        private List<CtlNodeBaseModel> monitorNodeList = null;
        private List<ThreadRunModel> threadList = null;
        public List<CtlNodeBaseModel> MonitorNodeList { get { return monitorNodeList; } }
        public CtlManage.CommDevManage DevCommManager { get; set; }
        #region 公共接口
        public CtlNodeManage()
        {
            monitorNodeList = new List<CtlNodeBaseModel>();
            threadList = new List<ThreadRunModel>();
        }
        public void StartNodeRun()
        {
            string reStr = "";
            foreach (ThreadRunModel threadObj in this.threadList)
            {

                if (!threadObj.TaskStart(ref reStr))
                {
                    Console.WriteLine(reStr);
                }
            }
        }
        public void PauseNodeRun()
        {
            foreach (ThreadRunModel threadObj in this.threadList)
            {
                threadObj.TaskPause();
            }
        }
        public void ExitRun()
        {
            string reStr = "";
            foreach (ThreadRunModel threadObj in this.threadList)
            {
                if (!threadObj.TaskExit(ref reStr))
                {
                    Console.WriteLine(reStr);
                }
            }
        }
        public CtlNodeBaseModel GetNodeByID(string nodeID)
        {
            foreach (CtlNodeBaseModel node in monitorNodeList)
            {
                if (node.NodeID == nodeID)
                {
                    return node;
                }
            }
            return null;
        }
        public CtlNodeBaseModel GetNodeByName(string nodeName)
        {
            foreach (CtlNodeBaseModel node in monitorNodeList)
            {
                if (node.NodeName == nodeName)
                {
                    return node;
                }
            }
            return null;
        }
        public void AddCtlNode(CtlNodeBaseModel ctlNode)
        {
            if (ctlNode != null)
            {
                monitorNodeList.Add(ctlNode);
            }
        }
        public void AddCtlNodeRange(IList<CtlNodeBaseModel> ctlNodes)
        {
            if (ctlNodes != null && ctlNodes.Count() > 0)
            {
                foreach (CtlNodeBaseModel node in ctlNodes)
                {
                    if (monitorNodeList.Contains(node))
                    {
                        continue;
                    }
                    monitorNodeList.Add(node);
                }

            }

        }
        public void AllocateCommdev()
        {
            foreach (CtlNodeBaseModel node in monitorNodeList)
            {
                if (node.PlcID > 0)
                {
                    node.PlcRW = DevCommManager.GetPlcByID(node.PlcID);
                }
                if (node.RfidID > 0)
                {
                    node.RfidRW = DevCommManager.GetRfidByID(node.RfidID);
                }
                if (node.BarcodeID > 0)
                {
                    node.BarcodeRW = DevCommManager.GetBarcoderRWByID(node.BarcodeID);
                }
            }
        }
        public void BuildNodePath()
        {
            foreach(CtlNodeBaseModel node in monitorNodeList)
            {
                foreach (string nextNodeID in node.NextNodeids)
                {
                    CtlNodeBaseModel nextNode = GetNodeByID(nextNodeID);
                    if(nextNode != null)
                    {
                        node.NextNodes.Add(nextNode);
                    }
                }
            }
            foreach(CtlNodeBaseModel node in monitorNodeList)
            {
                node.BuildPathList();
            }
        }
        public bool ParseTheadNodes(XElement ThreadnodeRoot, ref string reStr)
        {
            if (ThreadnodeRoot == null)
            {
                reStr = "系统配置文件错误，不存在ThreadAlloc节点";
                return false;
            }
            try
            {
                IEnumerable<XElement> nodeXEList =
                from el in ThreadnodeRoot.Elements()
                where el.Name == "Thread"
                select el;
                foreach (XElement el in nodeXEList)
                {
                    string threadName = el.Attribute("name").Value;
                    int threadID = int.Parse(el.Attribute("id").Value);
                    int loopInterval = int.Parse(el.Attribute("loopInterval").Value);
                    ThreadRunModel threadObj = new ThreadRunModel(threadName);
                    //  ThreadBaseModel threadObj = new ThreadBaseModel(threadID, threadName);
                    threadObj.TaskInit();
                    threadObj.LoopInterval = loopInterval;
                    XElement nodeContainer = el.Element("NodeContainer");

                    IEnumerable<XElement> nodeListAlloc =
                    from nodeEL in nodeContainer.Elements()
                    where nodeEL.Name == "NodeID"
                    select nodeEL;
                    foreach (XElement nodeEL in nodeListAlloc)
                    {
                        string nodeID = nodeEL.Value;
                        CtlNodeBaseModel node = GetNodeByID(nodeID);

                        if (node != null)
                        {
                            threadObj.AddNode(node);
                        }
                    }
                    this.threadList.Add(threadObj);
                }
                return true;
            }
            catch (Exception ex)
            {
                reStr = ex.ToString();
                return false;
            }
        }
        #endregion
        #region ICtlnodeMonitor接口实现
        public List<string> GetMonitorNodeNames()
        {
            List<string> nodeNames = new List<string>();
            foreach(CtlNodeBaseModel node in monitorNodeList)
            {
                nodeNames.Add(node.NodeName);
            }
            return nodeNames;
        }

        public string GetNodeName(string nodeID)
        {
            CtlNodeBaseModel node = GetNodeByID(nodeID);
            if(node==null)
            {
                return string.Empty;
            }
            return node.NodeName;
        }
        public  List<string> GetMonitorNodeIDS()
        {
            List<string> nodeIDS = new List<string>();
            foreach (CtlNodeBaseModel node in monitorNodeList)
            {
                nodeIDS.Add(node.NodeID);
            }
            return nodeIDS;
        }
        public bool DevReset(string nodeName, ref string reStr)
        {
            CtlNodeBaseModel node = GetNodeByName(nodeName);
            if(node==null)
            {
                reStr = "不存在:" + reStr;
                return false;
            }
            return node.DevReset(ref reStr);
        }
       
        public bool GetDevRunningInfo(string nodeName, ref DataTable db1Dt, ref DataTable db2Dt, ref string taskDetail)
        {
            CtlNodeBaseModel node = GetMonitorNode(nodeName);
            if (node == null)
            {
                return false;
            }
            //任务
            db1Dt = node.GetDB1DataDetail();
            db2Dt = node.GetDB2DataDetail();
            taskDetail = node.GetRunningTaskDetail();
            return true;
        }
        public bool GetDevRunningInfoByID(string nodeID, ref DataTable db1Dt, ref DataTable db2Dt, ref string taskDetail)
        {
            CtlNodeBaseModel node =GetNodeByID(nodeID);
            if (node == null)
            {
                return false;
            }
            //任务
            db1Dt = node.GetDB1DataDetail();
            db2Dt = node.GetDB2DataDetail();
            taskDetail = node.GetRunningTaskDetail();
            return true;
        }
        public void SimSetBarcode(string nodeName, string barcode)
        {
            CtlNodeBaseModel node = GetMonitorNode(nodeName);
            if (node == null)
            {
                Console.WriteLine("工位：" + nodeName + " 不存在");
                return;
            }
            node.SimBarcode = barcode;
        }
        public void SimSetRFID(string nodeName, string strUID)
        {
            //if(rfidID<1 || rfidID>rfidRWs.Count())
            //{
            //    Console.WriteLine("RFID ID错误");
            //    return;
            //}
            CtlNodeBaseModel node = GetMonitorNode(nodeName);
            if (node == null)
            {
                Console.WriteLine("工位：" + nodeName + " 不存在");
                return;
            }
            node.SimRfidUID = strUID;

        }
        public bool SimSetDB2(string nodeName, int dbItemID, int val)
        {
            CtlNodeBaseModel node = GetMonitorNode(nodeName);
            if (node == null)
            {
                Console.WriteLine("工位：" + nodeName + " 不存在");
                return false;
            }
            node.DicCommuDataDB2[dbItemID].Val = val;
            return true;
        }
        #endregion
        #region 私有
        private CtlNodeBaseModel GetMonitorNode(string nodeName)
        {

            foreach (CtlNodeBaseModel node in monitorNodeList)
            {
                if (node.NodeName == nodeName)
                {
                    return node;
                }
            }
            return null;
        }
        #endregion

    }
}
