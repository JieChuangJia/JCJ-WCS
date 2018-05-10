using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FlowCtlBaseModel;
using AsrsControl;
namespace PrcsCtlModelsAoyouCp
{
    public class NodeSwitchInput : CtlNodeBaseModel
    {
        public delegate string DlgtGetAsrsLogicArea(string palletID, AsrsCtlModel asrsCtl, int curStep);
        private short barcodeFailedStat = 1;
        public DlgtGetAsrsLogicArea dlgtGetLogicArea = null;
        private List<FlowPathModel> flowPathList = new List<FlowPathModel>();
        public AsrsInterface.IAsrsManageToCtl AsrsResManage { get; set; }
        /// <summary>
        /// 建立路径列表，只建两级路径，分流点-入口-堆垛机
        /// </summary>
        public override void BuildPathList()
        {
            int pathSeq = 1;
            foreach(CtlNodeBaseModel node in NextNodes)
            {
                foreach(CtlNodeBaseModel nextNode in node.NextNodes)
                {
                     FlowPathModel path = new FlowPathModel();
                     path.PathSeq = pathSeq;
                     path.AddNode(node);
                     path.AddNode(nextNode);
                     flowPathList.Add(path);
                     pathSeq++;
                }
            }
        }
        public override bool ExeBusiness(ref string reStr)
        {
            if (!devStatusRestore)
            {
                devStatusRestore = DevStatusRestore();
            }
            if (db2Vals[0] == 1)
            {
             
                currentTaskPhase = 0;
                Array.Clear(this.db1ValsToSnd, 0, this.db1ValsToSnd.Count());
                rfidUID = string.Empty;
                currentTaskDescribe = "等待新的任务";
                //return true;
            }
            //if(db1ValsToSnd[0] >1) //分流完成后
            //{
            //    return true;
            //}
            if (db2Vals[0] == 2)
            {
                if (currentTaskPhase == 0)
                {
                    currentTaskPhase = 1;
                }
            }
            switch(this.currentTaskPhase)
            {
                case 1:
                    {
                        currentTaskDescribe = "开始读RFID";
                        this.rfidUID = "";
                        if (SysCfg.SysCfgModel.UnbindMode)
                        {
                            this.rfidUID = System.Guid.NewGuid().ToString();
                        }
                        else
                        {
                            if (SysCfg.SysCfgModel.SimMode || SysCfg.SysCfgModel.RfidSimMode)
                            {
                                this.rfidUID = this.SimRfidUID;
                            }
                            else
                            {
                                this.rfidUID = this.barcodeRW.ReadBarcode();
                               
                            }
                        }
                        if (string.IsNullOrWhiteSpace(this.rfidUID))
                        {
                            if (this.db1ValsToSnd[0] != barcodeFailedStat)
                            {
                                logRecorder.AddDebugLog(nodeName, "读料框条码失败");
                            }
                            this.db1ValsToSnd[0] = barcodeFailedStat;
                            break;
                        }
                        /*
                        //检测是否跟库里有重码
                        string[] houseNames = new string[] { AsrsModel.EnumStoreHouse.A1库房.ToString(), AsrsModel.EnumStoreHouse.A2库房.ToString(),
                            AsrsModel.EnumStoreHouse.B1库房.ToString(), AsrsModel.EnumStoreHouse.C1库房.ToString(),AsrsModel.EnumStoreHouse.C2库房.ToString(),AsrsModel.EnumStoreHouse.C3库房.ToString() };
                        foreach (string houseName in houseNames)
                        {
                            string cellIn = AsrsResManage.IsProductCodeInStore(houseName, this.rfidUID, ref reStr);
                            if (!string.IsNullOrWhiteSpace(cellIn))
                            {
                                if (this.db1ValsToSnd[0] != 3)
                                {
                                    currentTaskDescribe = string.Format("条码异常，条码{0}已经在库房{1},库位{2}", this.rfidUID.Length.ToString(), houseName, cellIn);
                                    logRecorder.AddDebugLog(nodeName, currentTaskDescribe);
                                }
                                this.db1ValsToSnd[0] = 3;
                                return true;
                            }
                        }*/

                        logRecorder.AddDebugLog(this.nodeName, "读到托盘号:" + this.rfidUID);
                        this.currentTaskPhase++;
                        break;
                    }
                case 2:
                    {
                        //分流
                        currentTaskDescribe = "等待分流";
                        int switchRe = 0;
                        int step = 0;
                        if (!MesAcc.GetStep(this.rfidUID, out step, ref reStr))
                        {
                            currentTaskDescribe = "查询MES工步失败:" + reStr;
                            break;
                        }
                        if(this.nodeID=="4001")
                        {
                            step = 14;
                            if (!MesAcc.UpdateStep(step, this.rfidUID, ref reStr))
                            {
                                currentTaskDescribe = "更新MES工步失败:" + reStr;
                                break;
                            }
                        }
                        else if (this.nodeID == "4002")
                        {
                            step = 0;
                            if (!MesAcc.UpdateStep(step, this.rfidUID, ref reStr))
                            {
                                currentTaskDescribe = "更新MES工步失败:" + reStr;
                                break;
                            }

                        }
                       
                        FlowPathModel switchPath = FindFirstValidPath(this.rfidUID, ref reStr);
                        if(switchPath == null)
                        {
                            switchRe = 0; //无可用路径，等待
                            this.db1ValsToSnd[0] = (short)switchRe;
                            break;
                        }
                        else
                        {
                            
                            CtlNodeBaseModel node = switchPath.NodeList[0];
                            switchRe = switchPath.PathSeq + 1;
                            if (node.GetType().ToString() == "AsrsControl.AsrsPortalModel")
                            {
                                (node as AsrsControl.AsrsPortalModel).PushPalletID(this.rfidUID);

                            }
                            this.db1ValsToSnd[0] = (short)switchRe;
                            string logStr = string.Format("{0}分流，进入{1}", this.rfidUID, switchPath.NodeList[0].NodeName);
                            logRecorder.AddDebugLog(nodeName, logStr);
                            AddProduceRecord(this.rfidUID, logStr); 
                        }
                       
                        this.currentTaskPhase++;
                        break;
                    }
                case 3:
                    {
                        currentTaskDescribe = "分流完成";
                        break;
                    }
                default:
                    break;
            }
            return true;
        }
        /// <summary>
        /// 搜索第一条可用路径
        /// </summary>
        /// <param name="palletID"></param>
        /// <param name="reStr"></param>
        /// <returns></returns>
        private FlowPathModel FindFirstValidPath(string palletID,ref string reStr)
        {
            List<FlowPathModel> validPathList = new List<FlowPathModel>();

            foreach (FlowPathModel path in flowPathList)
            {
                if (path.IsPathConnected(palletID, ref reStr))
                {
                    validPathList.Add(path);
                }
            }
            if(validPathList.Count()==0)
            {
                reStr = "没有可用分流路径";
                return null;
            }
            //排序
            FlowPathModel rePath = validPathList[0];
            if (validPathList.Count()>1)
            {
                CtlNodeBaseModel node1 = rePath.NodeList[0];
                int weight1 = node1.PathValidWeight(palletID, ref reStr);

                for(int i=1;i<validPathList.Count();i++)
                {
                    FlowPathModel path = validPathList[i];
                 
                    CtlNodeBaseModel node2 = path.NodeList[0];
                    int weight2 = node2.PathValidWeight(palletID, ref reStr);
                    if(weight2>weight1)
                    {
                        rePath = path;
                        weight1 = weight2;
                    }

                }
            }
            return rePath;
        }
        
       
    }
}
