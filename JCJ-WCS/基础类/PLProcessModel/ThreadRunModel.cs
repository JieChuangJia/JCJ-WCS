using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using DevInterface;
using LogInterface;
namespace FlowCtlBaseModel
{
    /// <summary>
    /// 任务运行建模，相当于操作系统的线程
    /// 封装了任务的操作接口，
    /// 可以动态的增加工位节点，在每个循环内对工位节点执行控制流程
    /// </summary>
    public class ThreadRunModel : ThreadBaseModel,ILogRequired
    {
        #region 内部数据
       
        private List<CtlNodeBaseModel> nodeList = null;
       // private Int64 lastPlcStat = 0;
        #endregion
        #region 属性
        public DelegateThreadRoutine2 threadRoutine2 = null;
        public List<CtlNodeBaseModel> NodeList { get { return nodeList; } }

       // public int ThreadID { get { return threadID; } }
        //public int LoopInterval { get { return loopInterval; } set { this.loopInterval = value; } }
      //  public ILogRecorder LogRecorder { get { return logRecorder; } set { logRecorder = value; } }
        #endregion
        #region 公开接口
        public ThreadRunModel(string taskName):base(taskName)
        {
            
            this.taskName = taskName;
            this.nodeList = new List<CtlNodeBaseModel>();
        }
      
        public bool InsertNode(int insertIndex,CtlNodeBaseModel node,ref string reStr)
        {
            if(this.nodeList.Count()<insertIndex)
            {
                reStr = "线程：" + this.taskName + " 插入控制节点失败，插入索引越界";
                return false;
            }
            this.nodeList.Insert(insertIndex,node);
            return true;
        }
        public void AddNode(CtlNodeBaseModel node)
        {
            this.nodeList.Add(node);
        }
      

        #endregion
        #region 内部接口
        protected override void TaskloopProc()
        {
            while (!exitRunning)
            {
                Thread.Sleep(loopInterval);
                if (pauseFlag)
                {
                    continue;
                }
               
             //   logRecorder.AddDebugLog("线程：" + threadID,"线程：" + threadID+"循环开始：");
               
                //IPlcRW plcRW = nodeList[0].PlcRW;
                //if (!SysCfgModel.SimMode)
                //{
                //    if (lastPlcStat == plcRW.PlcStatCounter)
                //    {
                //        continue;
                //    }
                //}
               
                //if (threadID == 1)
                //{
                //    Console.WriteLine("线程：" + threadID + "循环开始：");
                //}
                for (int nodeIndex = 0; nodeIndex < nodeList.Count(); nodeIndex++)
                {
                    CtlNodeBaseModel node = nodeList[nodeIndex];
                    try
                    {
                        
                        //if(!SysCfgModel.SimMode && SysCfgModel.TestMode)
                        //{
                        //    bool disable = false;
                        //    string[] disableNodes = new string[] {  "4001", "4002", "4003", "4004", "4005", "4006", "4007", "4008","8001"};
                        //    foreach(string disableNodeID in disableNodes)
                        //    {
                        //        if(node.NodeID == disableNodeID)
                        //        {
                        //            disable = true;
                        //            break;
                        //        }
                        //    }
                        //    if(disable)
                        //    {
                        //        continue;
                        //    }
                        //    if(node.GetType().ToString()== "NbProcessCtl.NodeAssemPack"||
                        //        node.GetType().ToString() == "NbProcessCtl.NodeAssemBottom"||
                        //        node.GetType().ToString() == "NbProcessCtl.NodeAssemUpper"||
                        //        node.GetType().ToString()== "NbProcessCtl.NodePalletBind")
                        //    {
                        //        continue;
                        //    }
                        //}
                        string reStr = "";
                        //if (!node.ReadDB1())
                        //{
                        //    continue;
                        //}
                        if(!node.NodeEnabled)
                        {
                            continue;
                        }
                        if (!node.ReadDB2(ref reStr))
                        {
                            continue;
                        }
                        if (!node.ExeBusiness(ref reStr))
                        {
                            continue;
                        }
                        if (!node.NodeCmdCommit(true, ref reStr))
                        {
                            continue;
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(node.NodeName + ex.ToString());
                        node.ThrowErrorStat(ex.ToString(), EnumNodeStatus.设备故障);
                    }

                }
               // lastPlcStat = plcRW.PlcStatCounter;
                //if (threadID == 1)
                //{
                //    Console.WriteLine("线程：" + threadID + "循环结束");
                //}
               
            }
        }
        #endregion
    }
}
