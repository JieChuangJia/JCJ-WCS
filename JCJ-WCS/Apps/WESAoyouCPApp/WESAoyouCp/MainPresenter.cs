using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Xml;
using System.Xml.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Data;
using CtlMonitorInterface;
using AsrsModel;
using AsrsInterface;
using AsrsControl;
//using AsrsExtctlSvc;
namespace WESAoyou
{
     [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class MainPresenter : IWESMonitorSvc
    {
        #region 数据
        private IMainView view = null;
        private PrcsCtlModelsAoyouCp.PrsCtlnodeManage prsNodeManager = null; //流水线控制节点管理对象
        private AsrsControl.AsrsCtlPresenter asrsPresenter = null; //立库控制管理对象
        private CtlManage.CtlNodeManage ctlNodeManager = null; // 总的控制节点管理对象
        private CtlManage.CommDevManage devCommManager = null; //通信设备管理对象
        private FlowCtlBaseModel.MesAccWrapper mesAcc = null;
        private AsrsInterface.IAsrsManageToCtl asrsResManage = null;
     
       // private HkFenrongSvc hkFenrongSvc = null;
        #endregion
        #region 公有方法
        public string[] ExtLogSrc { get; set; }
        public LogInterface.ILogRecorder logRecorder { get; set; }
        public AsrsControl.AsrsCtlPresenter AsrsPresenter { get { return asrsPresenter; } }
        public CtlManage.CtlNodeManage CtlNodeManager { get { return ctlNodeManager; } }
        public CtlManage.CommDevManage DevCommManager { get { return devCommManager; } }
        public MainPresenter(IMainView view)
        {
            this.view = view;
            devCommManager = new CtlManage.CommDevManage();
            prsNodeManager = new PrcsCtlModelsAoyouCp.PrsCtlnodeManage();
            asrsPresenter = new AsrsControl.AsrsCtlPresenter();
            ctlNodeManager = new CtlManage.CtlNodeManage();
        }
        public AsrsInterface.IAsrsCtlToManage GetAsrsCtlInterfaceObj()
        {
            return asrsPresenter;
        }
       public void SetAsrsResManage(AsrsInterface.IAsrsManageToCtl asrsRes)
        {
            asrsPresenter.SetAsrsResManage(asrsRes);
            prsNodeManager.SetAsrsResManage(asrsRes);
            this.asrsResManage = asrsRes;
        }
        /// <summary>
        /// 系统控制初始化
        /// </summary>
        /// <returns></returns>
        public bool SysCtlInit()
        {
            try
            {
                SysCfg.SysCfgModel.pathMode = SysCfg.EnumConPathMode.实时模式;
                mesAcc = new PrcsCtlModelsAoyouCp.MesAccAoyou();
               
                ctlNodeManager.DevCommManager = devCommManager;
                // 1加载配置文件
                string reStr = "";
                XElement root = null;
                SysCfg.SysCfgModel.cfgFilefullPath = AppDomain.CurrentDomain.BaseDirectory + @"\data\AoyouCfgCp.xml";
                if (!SysCfg.SysCfgModel.LoadCfg(ref root, ref reStr))
                {
                    Console.WriteLine("系统配置解析错误,{0}", reStr);
                    return false;
                }
               
                if (root.Element("sysSet").Element("ExtLogSrc") != null)
                {
                    string logSrcStr = root.Element("sysSet").Element("ExtLogSrc").Value.ToString();
                    ExtLogSrc = logSrcStr.Split(new string[] { ",", ";" }, StringSplitOptions.RemoveEmptyEntries);
                }
               
               
                //2 初始化通信模块
                XElement commDevXERoot = root.Element("CommDevCfg");
                if (!devCommManager.ParseCommdev(commDevXERoot, ref reStr))
                {
                    Console.WriteLine("通信设备配置参数解析设备:" + reStr);
                    return false;
                }
                devCommManager.CommDevConnect();
                //3 初始化立库控制系统

                XElement asrsRoot = root.Element("AsrsNodes");
                if(!asrsPresenter.CtlInit(asrsRoot,ref reStr))
                {
                    Console.WriteLine("立库控制系统初始化失败:"+reStr);
                    return false;
                }
                foreach (AsrsControl.AsrsCtlModel asrsCtl in asrsPresenter.AsrsCtls)
                {
                    asrsCtl.dlgtAsrsOutportBusiness = AsrsOutportBusiness;
                    asrsCtl.dlgtAsrsOutTaskPost = AsrsOutTaskBusiness;
                    asrsCtl.dlgtGetLogicArea = AsrsAreaToCheckin;
                    asrsCtl.dlgtAsrsCheckoutLoop = AsrsCheckoutLoop;
                   
                }

                //4 初始化流水线控制系统
                XElement prcsNodeRoot = root.Element("CtlNodes");
                if(!prsNodeManager.CtlInit(prcsNodeRoot,ref reStr))
                {
                    Console.WriteLine("流水线系统初始化失败:" + reStr);
                    return false;
                }
               
                //5 注册控制节点
                ctlNodeManager.AddCtlNodeRange(prsNodeManager.GetAllCtlNodes());
                ctlNodeManager.AddCtlNodeRange(asrsPresenter.GetAllCtlNodes());
                foreach (FlowCtlBaseModel.CtlNodeBaseModel node in ctlNodeManager.MonitorNodeList)
                {
                    node.MesAcc = mesAcc;
                }
                foreach(AsrsControl.AsrsCtlModel asrsCtl in asrsPresenter.AsrsCtls)
                {
                    asrsCtl.MesAcc = mesAcc;
                }
               
                //6 通信设备分配
                ctlNodeManager.AllocateCommdev();

                asrsPresenter.DevStatusRestore();
                prsNodeManager.DevStatusRestore();

                //建立节点路径
                ctlNodeManager.BuildNodePath();

                //7 线程分配
                XElement threadRoot = root.Element("ThreadAlloc");
                if(!ctlNodeManager.ParseTheadNodes(threadRoot,ref reStr))
                {
                    Console.WriteLine("分配线程时出现错误");
                    return false;
                }

                
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("控制系统初始化错误:"+ex.ToString());
                return false;
                
            }

        }
        /*public bool LoadAsrsExtSvc()
        {
            try
            {
               
                //杭可分容服务部署
                // hkFenrongSvc = new HkFenrongSvc(this.asrsResManage);
                Uri _baseAddress = new Uri("http://localhost:8999/JCJ/AoyouFenrongSvc/");
                EndpointAddress _Address = new EndpointAddress(_baseAddress);
                BasicHttpBinding _Binding = new BasicHttpBinding();
                ContractDescription _Contract = ContractDescription.GetContract(typeof(AsrsExtctlSvc.Interface.IHangkeFenrong));
                ServiceEndpoint endpoint = new ServiceEndpoint(_Contract, _Binding, _Address);
                AsrsExtctlSvc.HkFenrongSvc hkFenrongSvc = new AsrsExtctlSvc.HkFenrongSvc(this.asrsResManage, "B1库房");
                hkFenrongSvc.logRecorder = logRecorder;
                hkFenrongSvc.AsrsCtl = asrsPresenter.GetAsrsCtlByName("B1库房");
                //添加终结点ABC
                ServiceHost host = new ServiceHost(hkFenrongSvc, _baseAddress);
                host.Description.Endpoints.Add(endpoint);
                //启用元数据交换
                ServiceMetadataBehavior meta = new ServiceMetadataBehavior();

                meta.HttpGetEnabled = true;
                host.Description.Behaviors.Add(meta);
                host.Open();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("部署分容服务失败:" + ex.ToString());
                return false;
               
            }
           
        }*/
        public void StartRun()
        {
            this.ctlNodeManager.StartNodeRun();
            asrsPresenter.StartRun();
        }
        public void PauseRun()
        {
            this.ctlNodeManager.PauseNodeRun();
            asrsPresenter.PauseRun();
        }
        public void ExitSystem()
        {
            try
            {
                this.ctlNodeManager.ExitRun();
                asrsPresenter.ExitRun();
            }
            catch (Exception ex)
            {
                Console.WriteLine("退出时发生异常：" + ex.ToString());
              
            }
            
        }
        public void SetLogRecorder(LogInterface.ILogRecorder logRecorder)
        {
            asrsPresenter.SetLogRecorder(logRecorder);
            prsNodeManager.SetLogRecorder(logRecorder);
        }
        
        #endregion
        #region IMonitorSvc方法
        
        public string hello()
        {
            return "hello,WES监控服务已经启动";
        }
        public string[] GetLogSrcList()
        {

            //List<string> storLogSrcs = storageView.GetLogsrcList();
            //if(storLogSrcs != null)
            //{
            //    logSrcs.AddRange(logSrcs);
            //}

            //logView.SetLogsrcList(logSrcs);

            List<string> logSrcs = ctlNodeManager.GetMonitorNodeNames();
            logSrcs.AddRange(ExtLogSrc);
            return logSrcs.ToArray();
        }
        public bool DevReset(string nodeName, ref string reStr)
        {
            return true;
        }
        public List<string> GetMonitorNodeNames()
        {
            return ctlNodeManager.GetMonitorNodeNames();
        }
        public string GetNodeName(string nodeID)
        {
            return ctlNodeManager.GetNodeName(nodeID);

        }
        public List<string> GetMonitorNodeIDS()
        {
            return ctlNodeManager.GetMonitorNodeIDS();

        }
        public bool GetDevRunningInfo(string nodeName, ref DataTable db1Dt, ref DataTable db2Dt, ref string taskDetail)
        {
            return ctlNodeManager.GetDevRunningInfo(nodeName, ref db1Dt, ref db2Dt, ref taskDetail);
        }
        public bool GetDevRunningInfoByID(string nodeID, ref DataTable db1Dt, ref DataTable db2Dt, ref string taskDetail)
        {
            return ctlNodeManager.GetDevRunningInfoByID(nodeID, ref db1Dt, ref db2Dt, ref taskDetail);
        }
        public bool SimSetDB2(string nodeName, int dbItemID, int val)
        {
            return ctlNodeManager.SimSetDB2(nodeName, dbItemID, val);
        }
        
        public void SimSetRFID(string nodeName, string strUID)
        {
            ctlNodeManager.SimSetRFID(nodeName, strUID);
        }
         
        public void SimSetBarcode(string nodeName, string barcode)
        {
            ctlNodeManager.SimSetBarcode(nodeName, barcode);
        }
       
        public IDictionary<string, DevConnStat> GetPLCConnStatDic()
        {
            return devCommManager.GetPLCConnStatDic();
        }

        public string[] GetAllAsrsHousNames()
        {
            List<string> houseNameList = new List<string>();
            foreach(AsrsCtlModel asrsCtl in  asrsPresenter.AsrsCtls)
            {
                houseNameList.Add(asrsCtl.HouseName);
            }
            return houseNameList.ToArray();
        }
        public IDictionary<string, string> GetAllAsrsPortNames()
        {
            IDictionary<string, string> portNameMap = new Dictionary<string, string>();
            foreach(AsrsCtlModel asrsCtl in  asrsPresenter.AsrsCtls)
            {
                foreach(AsrsPortalModel port in asrsCtl.Ports)
                {
                    if(port.PortCata != 2)
                    {
                        portNameMap[port.NodeName]=port.NodeID;
                    }
                }
            }
            return portNameMap;
        }
         public bool GetAsrsStat(string asrsHoseName, ref int errCode, ref string[] status)
        {
            AsrsCtlModel asrsCtl = asrsPresenter.GetAsrsCtlByName(asrsHoseName);
            if(asrsCtl == null)
            {
                return false;
            }
            return asrsCtl.StackDevice.GetRunningStatus(ref errCode, ref status);

        }
         public void SetPortBuffer(string portName,string[] barcodes)
         {

         }
         public void ClearPortBuffer(string portName)
         {

         }
        #endregion
       
        #region 立库逻辑扩展
         /// <summary>
         /// 控制出库任务的生成，包括产品出库，空筐出库
         /// </summary>
         /// <param name="asrsCtl"></param>
         /// <param name="reStr"></param>
         /// <returns></returns>
         private bool AsrsCheckoutLoop(AsrsControl.AsrsCtlModel asrsCtl,SysCfg.EnumAsrsTaskType taskType,ref string reStr)
         {
             try
             {
                 CtlDBAccess.BLL.ControlTaskBll ctlTaskBll = new CtlDBAccess.BLL.ControlTaskBll();
               //  SysCfg.EnumAsrsTaskType taskType = SysCfg.EnumAsrsTaskType.产品出库;
                 // 1产品出库
                 List<AsrsPortalModel> ports = asrsCtl.GetOutPortsOfBindedtask(taskType);
                 string houseName = asrsCtl.HouseName;
                 AsrsModel.EnumCellStatus targetStoreStatus = EnumCellStatus.满位;
                 if(taskType== SysCfg.EnumAsrsTaskType.空筐出库)
                 {
                     targetStoreStatus = EnumCellStatus.空料框;
                 }
                 foreach (AsrsPortalModel port in ports)
                 {
                     if (taskType == SysCfg.EnumAsrsTaskType.空筐出库)
                     {
                         if (port.Db2Vals[0] != 2 || port.Db2Vals[2] != 1) //禁止出库
                         {
                             continue;
                         }
                     }
                     else //禁止出库
                     {
                         if (port.Db2Vals[0] != 2 || port.Db2Vals[1] != 1)
                         {
                             continue;
                         }
                         
                     }
                     //查询是否有待执行或者执行中的任务
                     string str = string.Format("DeviceID='{0}' and EndDevice='{1}' and TaskType={2} and (TaskStatus='待执行' or TaskStatus='执行中')", asrsCtl.StackDevice.NodeID, port.NodeID, (int)taskType);
                     List<CtlDBAccess.Model.ControlTaskModel> taskList = ctlTaskBll.GetModelList(str);
                     if (taskList != null && taskList.Count() > 0)
                     {
                         continue;
                     }
                     //遍历所有库位，判断材料类别，按照先入先出规则，匹配出库的货位。
                     Dictionary<string, AsrsModel.GSMemTempModel> asrsStatDic = new Dictionary<string, AsrsModel.GSMemTempModel>();
                     if (!asrsResManage.GetAllGsModel(ref asrsStatDic, ref reStr))
                     {
                         Console.WriteLine(string.Format("{0} 获取货位状态失败", houseName));
                         return false;
                     }
                     List<AsrsModel.GSMemTempModel> validCells = new List<AsrsModel.GSMemTempModel>();

                     int r = 1, c = 1, L = 1;
                     //先查询所有可出库货位
                     for (r = 1; r < asrsCtl.AsrsRow + 1; r++)
                     {
                         for (c = 1; c < asrsCtl.AsrsCol + 1; c++)
                         {
                             for (L = 1; L < asrsCtl.AsrsLayer + 1; L++)
                             {
                                 string strKey = string.Format("{0}:{1}-{2}-{3}", houseName, r, c, L);
                                 AsrsModel.GSMemTempModel cellStat = null;
                                 if (!asrsStatDic.Keys.Contains(strKey))
                                 {
                                     continue;
                                 }
                                 cellStat = asrsStatDic[strKey];
                                 if ((!cellStat.GSEnabled) || (cellStat.GSTaskStatus == AsrsModel.EnumGSTaskStatus.锁定.ToString()) || (cellStat.GSStatus != targetStoreStatus.ToString()))
                                 {
                                     // reStr = string.Format("货位{0}-{1}-{2}禁用,无法生成出库任务", cell.Row, cell.Col, cell.Layer);
                                     continue;
                                 }
                                 AsrsModel.CellCoordModel cell = new AsrsModel.CellCoordModel(r, c, L);
                                 validCells.Add(cellStat);
                             }
                         }
                     }
                     //再按照先入先出原则生成出库任务
                     if (validCells.Count() > 0)
                     {
                         //排序，按照先入先出
                         AsrsModel.GSMemTempModel firstGS = validCells[0];
                         if (validCells.Count() > 1)
                         {
                             for (int i = 1; i < validCells.Count(); i++)
                             {
                                 AsrsModel.GSMemTempModel tempGS = validCells[i];
                                 if (tempGS.InHouseDate < firstGS.InHouseDate)
                                 {
                                     firstGS = tempGS;
                                 }
                             }
                         }
                         //生成出库任务
                         string[] strCellArray = firstGS.GSPos.Split(new string[] { "-" }, StringSplitOptions.RemoveEmptyEntries);
                         int row = int.Parse(strCellArray[0]);
                         int col = int.Parse(strCellArray[1]);
                         int layer = int.Parse(strCellArray[2]);
                         AsrsModel.CellCoordModel cell = new AsrsModel.CellCoordModel(row, col, layer);
                         List<string> storGoods = new List<string>();
                         if(!asrsResManage.GetStockDetail(houseName, cell, ref storGoods))
                         {
                             return false;
                         }
                         string palletIDStr = "";
                         for (int i = 0; i < storGoods.Count(); i++)
                         {
                             if (storGoods.Count() > 1 && (i == storGoods.Count() - 1))
                             {
                                 palletIDStr = palletIDStr + storGoods[i];
                             }
                             else
                             {
                                 palletIDStr = palletIDStr + storGoods[i] + ",";
                             }
                         }

                        return asrsCtl.CreateStackerTask(port, taskType, cell, palletIDStr, ref reStr);
                       
                         
                         //if (asrsCtl.GenerateOutputTask(cell, port.BindedTaskOutput, true, port.PortSeq, ref reStr, new List<short> { palletCata }))
                         //{
                         //    port.Db1ValsToSnd[0] = 2;
                         //}
                         //else
                         //{
                         //    Console.WriteLine("生成任务{0}失败,{1}", port.BindedTaskOutput.ToString(), reStr);
                         //}

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

        private bool AsrsOutportBusiness(AsrsControl.AsrsPortalModel port, ref string reStr)
        {
            try
            {
                
                if(port.PortCata == 2)
                {
                    //出口，无板时，出库完成信号复位
                    if (port.Db2Vals[0] == 2) //无板时，DB1复位
                    {
                        // port.DevCmdReset();
                        port.Db1ValsToSnd[0] = 1;
                        port.Db1ValsToSnd[1] = 0;
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
        //出库后任务处理，通知物流线是空筐还是满筐
        private bool AsrsOutTaskBusiness(AsrsControl.AsrsPortalModel outPort, CtlDBAccess.Model.ControlTaskModel task, ref string reStr)
        {
            try
            {
                if (task == null)
                {
                    reStr = "任务为空";
                    return false;
                }
                if (task.TaskType == (int)SysCfg.EnumAsrsTaskType.产品出库)
                {
                    outPort.Db1ValsToSnd[1] = 2;
                }
                else if (task.TaskType == (int)SysCfg.EnumAsrsTaskType.空筐出库)
                {
                    outPort.Db1ValsToSnd[1] = 1;
                }
                if (!outPort.NodeCmdCommit(true, ref reStr))
                {
                    reStr = string.Format("出库站台{0}状态'出库完成'提交失败", outPort.PortSeq);
                    return false;
                }
                System.Threading.Thread.Sleep(500);

                return true;
            }
            catch (Exception ex)
            {
                reStr = ex.ToString();
                return false;
            }

        }
       
        private string AsrsAreaToCheckin(string palletID,AsrsControl.AsrsCtlModel asrsCtl,int step)
        {
            string area = "";
            if (step == 0)
            {
                area = "空筐区";
                //if (asrsCtl.HouseName == "C1库房" || asrsCtl.HouseName == "C2库房" || asrsCtl.HouseName == "C3库房")
                //{
                //    area = "空筐区";
                //}
                //else
                //{
                //    area = SysCfg.SysCfgModel.asrsStepCfg.AsrsAreaSwitch(step); 
                //}
            }
            else
            {
                if (asrsCtl.HouseName == "B1库房")
                {
                    string batteryCata = "";
                    if (palletID.Length >= 11)
                    {
                        batteryCata = palletID.Substring(0, 4);
                    }
                    else
                    {
                        //return area;
                        batteryCata = "F33A";
                    }
                    MesDBAccess.BLL.BatteryFenrongCfgBll batteryFenrongBll = new MesDBAccess.BLL.BatteryFenrongCfgBll();
                    string strWhere = string.Format("batteryCataCode = '{0}'", batteryCata);
                    List<MesDBAccess.Model.BatteryFenrongCfgModel> batteryFenrongList = batteryFenrongBll.GetModelList(strWhere, "fenrongZone");
                    foreach (MesDBAccess.Model.BatteryFenrongCfgModel cfgM in batteryFenrongList)
                    {
                        string areaCheckin = cfgM.fenrongZone;
                        int validCells = 0;
                        string reStr = "";
                        if (!asrsResManage.GetHouseAreaLeftGs(asrsCtl.HouseName, areaCheckin, ref validCells, reStr))
                        {
                            Console.WriteLine("{0}获取 {1} 剩余货位数量失败", asrsCtl.HouseName, areaCheckin);
                            continue;
                        }
                        if (validCells > 0)
                        {
                            area = areaCheckin;
                            break;
                        }
                    }
                }
                else
                {
                    area = SysCfg.SysCfgModel.asrsStepCfg.AsrsAreaSwitch(step); 
                }
                
            }
            return area;
        }
        #endregion
        #region 产线配置扩展
       public bool SendDevlinePalletCfg(string shopSection, ref string reStr)
        {
            //throw new NotImplementedException();
            Console.WriteLine("发送{0} ", shopSection);
           
            if(SysCfg.SysCfgModel.SimMode)
            {
                return true;
            }
            MesDBAccess.BLL.ViewDevLineBatteryCfgBll devLineCfgBll = new MesDBAccess.BLL.ViewDevLineBatteryCfgBll();
            string[] addrSts = new string[] { "D4001", "D4011", "D4021" };
            short[] blockNums = new short[] { 4, 6, 4 };
            string[] shopSections = new string[] { "注液", "化成", "二封" };
            List<DevInterface.IPlcRW> plcRWS = new List<DevInterface.IPlcRW>();
            plcRWS.Add(devCommManager.GetPlcByID(11));
            plcRWS.Add(devCommManager.GetPlcByID(12));
            plcRWS.Add(devCommManager.GetPlcByID(13));
            for (int i = 0; i < 3; i++)
            {
                if (shopSection != "所有")
                {
                    if (shopSection != shopSections[i])
                    {
                        continue;
                    }
                }
                short[] vals = new short[blockNums[i]];
                List<MesDBAccess.Model.ViewDevLineBatteryCfgModel> cfgList = devLineCfgBll.GetModelList(string.Format(" ShopSection='{0}' ", shopSections[i]));
                foreach (MesDBAccess.Model.ViewDevLineBatteryCfgModel m in cfgList)
                {
                    int valIndex = int.Parse(m.LineID) - 1;
                    vals[valIndex] = (short)m.plcDefVal;
                }
               
                if (!plcRWS[i].WriteMultiDB(addrSts[i], vals.Count(), vals))
                {
                    reStr = string.Format("发送{0}料筐配置失败", shopSections[i]);
                    return false;
                }
                //}
                //else
                //{
                //    if (!plcRW2.WriteMultiDB(addrSts[i], vals.Count(), vals))
                //    {
                //        reStr = string.Format("发送{0}料筐配置失败", shopSections[i]);
                //        return false;
                //    }
                //}
            }
            return true;
        }
       public bool ReadPalletCfgFromPlc(string shopSection,ref DataTable dt,ref string reStr)
       {
          // Console.WriteLine("读{0}", shopSection);
           DevInterface.IPlcRW plcRW1 = devCommManager.GetPlcByID(7);
           DevInterface.IPlcRW plcRW2 = devCommManager.GetPlcByID(10);
           
           string[] addrSts = new string[] { "D4001", "D4011", "D4021" };
           short[] blockNums = new short[] { 4, 6, 4 };
           string[] shopSections = new string[] { "注液", "化成", "二封" };
           dt = new DataTable("产线料筐型号配置表");
           
           dt.Columns.AddRange(new DataColumn[] {new DataColumn("标识"), new DataColumn("索引"),  new DataColumn("地址"),  new DataColumn("内容"),  new DataColumn("描述") });
           if (SysCfg.SysCfgModel.SimMode)
           {
               return true;
           }
           List<DevInterface.IPlcRW> plcRWS = new List<DevInterface.IPlcRW>();
           plcRWS.Add(devCommManager.GetPlcByID(11));
           plcRWS.Add(devCommManager.GetPlcByID(12));
           plcRWS.Add(devCommManager.GetPlcByID(13));
            int index = 1;
           for(int shopIndex=0;shopIndex<3;shopIndex++)
           {
               short[] vals = null;
               //注液

               if (!plcRWS[shopIndex].ReadMultiDB(addrSts[shopIndex], blockNums[shopIndex], ref vals))
                {
                    return false;
                }
             
               for (int i = 0; i < blockNums[shopIndex]; i++)
               {
                   string addr = string.Format("D{0}", int.Parse(addrSts[shopIndex].Substring(1)));
                   string secName=string.Format("{0}{1}线",shopSections[shopIndex],i+1);
                   dt.Rows.Add(secName,index++, addr, vals[i], "1:A筐，2：B筐");
               }
           }
           return true;
       }
        #endregion

    }
}
