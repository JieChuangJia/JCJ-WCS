using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Xml;
using System.Xml.Linq;
using System.Threading;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Xml;
using System.Xml.Linq;
using DevInterface;
using DevAccess;
using LogInterface;
using CtlDBAccess.Model;
using CtlDBAccess.BLL;
namespace FlowCtlBaseModel
{
    
    /// <summary>
    /// 控制节点模型基类，定义了所有控制节点对象共有的接口
    /// </summary>
    public abstract class CtlNodeBaseModel : ILogRequired
    {
        public delegate bool DlgtCreateNextCtltask(CtlNodeBaseModel curNode,ControlTaskModel curTask,ref string reStr);
        #region 委托
        public DlgtCreateNextCtltask dlgtCreateNextTask = null;
        #endregion
        #region 私有数据
        protected XElement cfgXE = null;
        protected string devCata = "";

        protected List<string> palletBuffer = new List<string>(); //托盘缓存
        protected List<string> nextNodeids = new List<string>();
        protected ControlTaskModel currentTask = null;
        protected ControlTaskBll ctlTaskBll = null;
        protected MesDBAccess.BLL.ProductOnlineBll productOnlineBll = null;
        protected MesDBAccess.BLL.ProduceRecordBll productRecordBll = null;
        
        protected bool devStatusRestore = false;//是否已经恢复下电前状态
        protected const int db1StatCheckOK = 1;
        protected const int db1StatNG = 2;
     //  protected const int db1StatRfidFailed = 1;
        protected const int db1StatCheckneed = 8;
        protected const int db1StatCheckNoneed = 16;
       // protected int taskPhase = 0; //流程步号（状态机）
        protected CtlNodeStatus currentStat;
        protected ILogRecorder logRecorder = null;
        protected string nodeID = "";
        protected string nodeName = "";
        protected List<int> mesProcessStepID = new List<int>();//MES工序ID
        protected IPlcRW plcRW = null;//设备的plc读写接口
        protected byte rfidID = 0;
        protected int plcID = 0;
        protected int barcodeID = 0;
        protected IrfidRW rfidRW = null;//rfid读写接口
        protected IBarcodeRW barcodeRW= null; //条码枪读写接口

        protected bool nodeEnabled = false; //是否启用
        protected string db1StartAddr = ""; //db1 开始地址
        protected string db2StartAddr = ""; //db2 开始地址
        protected IDictionary<int, PLCDataDef> dicCommuDataDB1 = null;//通信功能项字典，DB1
        protected IDictionary<int, PLCDataDef> dicCommuDataDB2 = null;//通信功能项字典，DB2
        protected int currentTaskPhase = 0;//流程步号（状态机）,
        protected string  rfidUID = ""; //读到的rfid UID
        protected string currentTaskDescribe = "";// 当前任务描述
        protected Int16[] db1ValsToSnd = null; //db1待发送数据
        protected Int16[] db1ValsReal = null; //PLC 实际DB1数据
        protected Int16[] db2Vals = null;
        protected Int16[] db2ValsLast = null;
        /// <summary>
        /// DB1数据区的锁
        /// </summary>
        private object lockDB1 = new object();

        /// <summary>
        /// DB2数据区的锁
        /// </summary>
        private object lockDB2 = new object();
       
      //  protected ModPsRecordBll modPsRecordBll = new ModPsRecordBll();
        #endregion
        #region 属性
        public List<CtlNodeBaseModel> NextNodes { get; set; }
        public List<string> NextNodeids { get { return nextNodeids; } }
        /// <summary>
        /// 入口缓存队列
        /// </summary>
        public List<string> PalletBuffer { get { return palletBuffer; } set { palletBuffer = value; } }

        public MesAccWrapper MesAcc { get; set; } //MES服务接口
        public string NodeID { get { return nodeID; } set { nodeID = value; } }
        public int PlcID { get { return plcID; } set { plcID = value; } }
        public string NodeName { get { return nodeName; } set { nodeName = value; } }
        public ControlTaskModel CurrentTask
        {
            get
            {
                return currentTask;
            }
        }
        public IPlcRW PlcRW
        {
            get { return this.plcRW; }
            set { this.plcRW = value; }
        }
        public IrfidRW RfidRW
        {
            get { return rfidRW; }
            set { rfidRW = value; }
        }
        public IBarcodeRW BarcodeRW
        {
            get { return barcodeRW; }
            set { barcodeRW = value; }
        }
        public IDictionary<int, PLCDataDef> DicCommuDataDB1
        {
            get { return dicCommuDataDB1; }
            set { dicCommuDataDB1 = value; }
        }
        public IDictionary<int, PLCDataDef> DicCommuDataDB2
        {
            get { return dicCommuDataDB2; }
            set { dicCommuDataDB2 = value; }
        }
        public short[] Db1ValsToSnd 
        {
            get { return db1ValsToSnd; }
            set { db1ValsToSnd = value; }
        }
        public short[] Db2Vals
        {
            get { return db2Vals; }
            set { db2Vals = value; }
        }
        public short[] Db2ValsLast { get { return db2ValsLast; } set { db2ValsLast = value; } }
        public string Db1StartAddr { get { return db1StartAddr; } }
        public string Db2StartAddr { get { return db2StartAddr; } }
        public ILogRecorder LogRecorder { get { return logRecorder; } set { logRecorder = value; } }

        public CtlNodeStatus CurrentStat { get { return currentStat; } set { currentStat = value; } }
        public string CurrentTaskDescribe { get { return currentTaskDescribe; } set { currentTaskDescribe = value; } }
        public bool NodeEnabled { get { return nodeEnabled; } set { nodeEnabled = value; } }
        public string SimRfidUID { get; set; }
        public string SimBarcode { get; set; }
        public byte RfidID { get { return rfidID; } set { rfidID = value; } }
        public string RfidUID { get { return rfidUID; } set { rfidUID = value; } }
        public int BarcodeID { get { return barcodeID; } set { barcodeID = value; } }
        public List<int> MesProcessStepID { get { return mesProcessStepID; } set { mesProcessStepID = value; } }
        public string DevCata { get { return devCata; } }
        #endregion
        #region 公开接口
        public CtlNodeBaseModel()
        {
            NextNodes = new List<CtlNodeBaseModel>();
            nextNodeids = new List<string>();
            productOnlineBll = new MesDBAccess.BLL.ProductOnlineBll();
            productRecordBll = new MesDBAccess.BLL.ProduceRecordBll();
            ctlTaskBll = new ControlTaskBll();
        }
        public virtual bool ReadDB1()
        {
            int blockNum = this.dicCommuDataDB1.Count();
            if(!SysCfg.SysCfgModel.SimMode)
            {

                if (SysCfg.SysCfgModel.PlcCommSynMode)
                {
                    short[] vals = null;
                    //同步通信
                    if (!plcRW.ReadMultiDB(db1StartAddr, blockNum, ref vals))
                    {
                        // refreshStatusOK = false;
                        ThrowErrorStat(this.nodeName + "读PLC数据(DB1）失败", EnumNodeStatus.设备故障);
                        return false;
                    }
                    for (int i = 0; i < blockNum; i++)
                    {
                        int commID = i + 1;
                        this.dicCommuDataDB1[commID].Val = vals[i];
                        this.db1ValsReal[i] = vals[i];
                        this.db1ValsToSnd[i] = vals[i];
                    }
                }
                else
                {
                    int addrSt = int.Parse(this.db1StartAddr.Substring(1)) - 2001;

                    for (int i = 0; i < blockNum; i++)
                    {
                        int commID = i + 1;
                        this.db1ValsReal[i] = plcRW.Db1Vals[addrSt + i];//.db1v//plcRwMx.db1Vals[addrSt+i];
                        this.db1ValsToSnd[i] = this.db1ValsReal[i];
                        this.dicCommuDataDB1[commID].Val = this.db1ValsReal[i];

                    }
                }
            }
            else
            {
                    for (int i = 0; i < blockNum; i++)
                    {
                        this.db1ValsReal[i] = this.db1ValsToSnd[i];
                    }
            }
            return true;
          
            
        }
       
        /// <summary>
        /// 查询节点的状态数据（DB2）
        /// </summary>
        /// <param name="reStr"></param>
        /// <returns></returns>
        public virtual bool ReadDB2(ref string reStr)
        {
            //if(devStatusRestore)
            //{
            //    Array.Copy(db2Vals, db2ValsLast, db2Vals.Count());
            //}
            int blockNum = this.dicCommuDataDB2.Count();
            if (!SysCfg.SysCfgModel.SimMode)
            {
                if (SysCfg.SysCfgModel.PlcCommSynMode)
                {
                    short[] vals = null;
                    if(!plcRW.IsConnect)
                    {
                        if(!plcRW.ConnectPLC(ref reStr))
                        {
                            ThrowErrorStat(this.nodeName + "PLC连接失败", EnumNodeStatus.设备故障);
                            return false;
                        }
                    }
                    //同步通信
                    if (!plcRW.ReadMultiDB(db2StartAddr, blockNum, ref vals))
                    {
                        // refreshStatusOK = false;
                        ThrowErrorStat(this.nodeName + "读PLC数据(DB2）失败", EnumNodeStatus.设备故障);
                        return false;
                    }
                    for (int i = 0; i < blockNum; i++)
                    {
                        int commID = i + 1;
                        this.dicCommuDataDB2[commID].Val = vals[i];
                        this.db2Vals[i] = vals[i];  
                    }
                }
                else
                {
                    //异步通信
                    int addrStInt = 3000;
                    int addrSt = int.Parse(this.db2StartAddr.Substring(1)) - addrStInt; 
                    for (int i = 0; i < blockNum; i++)
                    {
                        this.db2Vals[i] = this.plcRW.Db2Vals[addrSt + i];
                        int commID = i + 1;
                        this.dicCommuDataDB2[commID].Val = this.db2Vals[i];

                    }
                }
                
            }
            else
            {
                for (int i = 0; i < blockNum; i++)
                {
                    int commID = i + 1;
                    this.db2Vals[i] = short.Parse(this.dicCommuDataDB2[commID].Val.ToString());
                }
            }
           
            return true;
            
           
        }
        public DataTable GetDB1DataDetail()
        {
            DataTable dt = new DataTable("Dt1");
            dt.Columns.Add("索引");
            dt.Columns.Add("地址");
            dt.Columns.Add("内容");
            dt.Columns.Add("描述");
            int index = 1;

            for (int i = 0; i < dicCommuDataDB1.Count(); i++)
            {
                PLCDataDef commObj = dicCommuDataDB1[i + 1];
                dt.Rows.Add(index++, commObj.DataAddr, commObj.Val, commObj.DataDescription);
            }


            return dt;
        }
        public DataTable GetDB2DataDetail()
        {
            DataTable dt = new DataTable("Dt2");
            dt.Columns.Add("索引");
            dt.Columns.Add("地址");
            dt.Columns.Add("内容");
            dt.Columns.Add("描述");
            int index = 1;
            for (int i = 0; i < dicCommuDataDB2.Count(); i++)
            {
                PLCDataDef commObj = dicCommuDataDB2[i + 1];

                dt.Rows.Add(index++, commObj.DataAddr, commObj.Val, commObj.DataDescription);
            }
            return dt;

        }
        /// <summary>
        /// 获取当前任务的详细信息
        /// </summary>
        /// <returns></returns>
        public string GetRunningTaskDetail()
        {
          
            string taskInfo =string.Format("流程执行到第{0}步",this.currentTaskPhase)+":"+currentTaskDescribe;
            return taskInfo;

        }
        public void ClearErrorStat(string content)
        {
            this.currentStat.StatDescribe = content;
            this.currentStat.Status = EnumNodeStatus.设备空闲;
            LogModel log = new LogModel(this.nodeName, content, EnumLoglevel.提示);
            this.logRecorder.AddLog(log);
        }
        public void ThrowErrorStat(string statDescribe, EnumNodeStatus statEnum)
        {
            if (statEnum != EnumNodeStatus.设备故障)
            {
                return;
            }
            if (this.currentStat.Status == EnumNodeStatus.设备空闲 || this.currentStat.Status == EnumNodeStatus.设备使用中)
            {
                //增加日志提示
                LogModel log = new LogModel(this.nodeName, statDescribe, EnumLoglevel.错误);
                this.logRecorder.AddLog(log);
            }
            this.currentStat.Status = statEnum;
            this.currentStat.StatDescribe = statDescribe;
        }
        //public bool AddProcessRecord(string batModID,string processName)
        //{
        //    ModPsRecordModel modRecord = new ModPsRecordModel();
        //    modRecord.RecordID = System.Guid.NewGuid().ToString();
        //    modRecord.processRecord = processName;
        //    modRecord.batModuleID = batModID;
        //    modRecord.recordTime = System.DateTime.Now;
        //    return modPsRecordBll.Add(modRecord);
           
        //}
        public void SaveCfg()
        {
            this.cfgXE.Attribute("enabled").Value = nodeEnabled.ToString();
        }
        #endregion
        #region 虚接口
        /// <summary>
        /// 业务逻辑，控制节点的流程执行
        /// </summary>
        /// <param name="reStr"></param>
        /// <returns></returns>
        public abstract bool ExeBusiness(ref string reStr);
       
        /// <summary>
        /// 路径节点是否畅通
        /// </summary>
        /// <param name="palletID"> 将要同行的托盘ID</param>
        /// <param name="reStr">禁止同行时的解释</param>
        /// <returns></returns>
        public virtual bool IsPathOpened(string palletID,ref string reStr)
        {
            if(!nodeEnabled)
            {
                reStr = "节点已经被禁用";
                return false;
            }
            return true;
        }
         /// <summary>
         /// 节点权重
         /// </summary>
         /// <param name="palletID">尝试分流的托盘号</param>
         /// <param name="reStr"></param>
         /// <returns></returns>
        public virtual int PathValidWeight(string palletID,ref string reStr)
        {
            return 0;
        }
        /// <summary>
        /// 控制流程的命令数据提交
        /// </summary>
        /// <param name="reStr"></param>
        /// <returns></returns>
        public virtual bool NodeCmdCommit(bool diffSnd,ref string reStr)
        {
            if (!SysCfg.SysCfgModel.SimMode)
            {
                int blockNum = this.dicCommuDataDB1.Count();
                if (SysCfg.SysCfgModel.PlcCommSynMode)
                {
                    if (!plcRW.IsConnect)
                    {
                        if (!plcRW.ConnectPLC(ref reStr))
                        {
                            ThrowErrorStat(this.nodeName + "PLC连接失败", EnumNodeStatus.设备故障);
                            return false;
                        }
                    }

                    if(!plcRW.WriteMultiDB(this.db1StartAddr,blockNum,this.db1ValsToSnd))
                    {
                        ThrowErrorStat("发送设备命令失败！", EnumNodeStatus.设备故障);
                        return false;
                    }
                    for (int i = 0; i < blockNum; i++)
                    {
                        int commID = i + 1;
                        this.dicCommuDataDB1[commID].Val = this.db1ValsToSnd[i];
                      
                        // this.db1ValsReal[i] = vals[i];
                    }
                }
                else
                {
                    int addrSt = int.Parse(this.db1StartAddr.Substring(1)) - 2000;
                    for (int i = 0; i < blockNum; i++)
                    {
                        int commID = i + 1;
                        this.dicCommuDataDB1[commID].Val = this.db1ValsToSnd[i];
                        plcRW.Db1Vals[addrSt + i] = this.db1ValsToSnd[i];
                        // this.db1ValsReal[i] = vals[i];
                    }
                }
                  
            }
            else
            {
                for (int i = 0; i < dicCommuDataDB1.Count(); i++)
                {
                    int commID = i + 1;
                    PLCDataDef commObj = dicCommuDataDB1[commID];
                    commObj.Val = db1ValsToSnd[i];

                }
            }
                   
            return true;
             
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="xe"></param>
        /// <returns></returns>
        public virtual bool BuildCfg(XElement xe,ref string reStr)
        {
            this.cfgXE = xe;
            this.nodeID = xe.Attribute("id").Value;
            this.nodeEnabled = bool.Parse(xe.Attribute("enabled").Value);
            XElement baseDataXE = xe.Element("BaseDatainfo");
            if(baseDataXE == null)
            {
                reStr = this.nodeID + "，没有BaseDatainfo节点配置信息";
                return false;
            }

            XAttribute attr = baseDataXE.Attribute("barcodeScanner");
            if(attr != null)
            {
                this.barcodeID = int.Parse(attr.Value);
            }
            attr = baseDataXE.Attribute("rfid");
            if (attr != null)
            {
                this.rfidID = byte.Parse(attr.Value);
            }

            attr = baseDataXE.Attribute("plcID");
            if(attr != null)
            {
                this.plcID = int.Parse(attr.Value);
            }
            attr = baseDataXE.Attribute("mesStep");
            if(attr != null)
            {
                this.mesProcessStepID.Clear();
                string[] strMesSteps = attr.Value.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
                foreach(string strStep in strMesSteps)
                {
                    this.mesProcessStepID.Add(int.Parse(strStep.Trim()));
                }
            }
            this.nodeName = baseDataXE.Element("NodeName").Value;
            
            //mes nodeid，nodename
            
            XElement db1XE = baseDataXE.Element("DB1Addr");
            string db1StartStr = db1XE.Attribute("addrStart").Value;
            this.db1StartAddr = db1StartStr;
            int db1Start = int.Parse(db1StartStr.Substring(1));
            int db1BlockNum = int.Parse(db1XE.Attribute("blockNum").Value);
            int db1ID = 1;
            this.dicCommuDataDB1 = new Dictionary<int, PLCDataDef>();
            db1ValsReal = new Int16[db1BlockNum];
            db1ValsToSnd = new Int16[db1BlockNum];
            for (int i = 0; i < db1BlockNum; i++)
            {
                PLCDataDef commData = new PLCDataDef();
                commData.CommuID = db1ID++;
                commData.CommuMethod = EnumCommMethod.PLC_MIT_COMMU;
                commData.DataByteLen = 2;
                commData.DataDescription = "";
                commData.DataTypeDef = EnumCommuDataType.DEVCOM_short;
                commData.Val = 0;
                commData.DataAddr = "D" + (db1Start+i).ToString();
                dicCommuDataDB1[commData.CommuID] = commData;
                //db1Vals[i] = 0;
            }
            XElement db2XE = baseDataXE.Element("DB2Addr");
            string db2StartStr = db2XE.Attribute("addrStart").Value;
            this.db2StartAddr = db2StartStr;
            int db2Start = int.Parse(db2StartStr.Substring(1));
            int db2BlockNum = int.Parse(db2XE.Attribute("blockNum").Value);
            int db2ID = 1;
            this.dicCommuDataDB2 = new Dictionary<int, PLCDataDef>();
            db2Vals = new Int16[db2BlockNum];
            db2ValsLast = new Int16[db2BlockNum];
            for (int i = 0; i < db2BlockNum; i++)
            {
                PLCDataDef commData = new PLCDataDef();
                commData.CommuID = db2ID++;
                commData.CommuMethod = EnumCommMethod.PLC_MIT_COMMU;
                commData.DataByteLen = 2;
                commData.DataDescription = "";
                commData.DataTypeDef = EnumCommuDataType.DEVCOM_short;
                commData.Val = 0;
                db2Vals[i] = 0;
                commData.DataAddr = "D" + (db2Start + i).ToString();
                dicCommuDataDB2[commData.CommuID] = commData;
            }
            XElement selfDataXE = xe.Element("SelfDatainfo");
            if(selfDataXE != null)
            {
                if (selfDataXE.Element("Db1Desc") != null)
                {
                    string dbDesc = selfDataXE.Element("Db1Desc").Value.ToString();
                    string[] dbDescArray = dbDesc.Split(new string[] { ";" }, StringSplitOptions.RemoveEmptyEntries);
                    if (dbDescArray != null && dbDescArray.Count() > 0)
                    {
                        for (int i = 0; i < Math.Min(dbDescArray.Count(), this.dicCommuDataDB1.Count()); i++)
                        {
                            this.dicCommuDataDB1[1 + i].DataDescription = dbDescArray[i];
                        }
                    }
                }
                if (selfDataXE.Element("Db2Desc") != null)
                {
                    string dbDesc = selfDataXE.Element("Db2Desc").Value.ToString();
                    string[] dbDescArray = dbDesc.Split(new string[] { ";" }, StringSplitOptions.RemoveEmptyEntries);
                    if (dbDescArray != null && dbDescArray.Count() > 0)
                    {
                        for (int i = 0; i < Math.Min(dbDescArray.Count(), this.dicCommuDataDB2.Count()); i++)
                        {
                            this.dicCommuDataDB2[1 + i].DataDescription = dbDescArray[i];
                        }
                    }
                }
                if(selfDataXE.Element("SwitchPath") != null)
                {
                    string strPath = selfDataXE.Element("SwitchPath").Value.ToString();
                    string[] strArray = strPath.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
                    if(strArray != null && strArray.Count()>0)
                    {
                        nextNodeids.AddRange(strArray);
                    }
                }
            }
            
            this.currentStat = new CtlNodeStatus(nodeName);
            this.currentStat.Status = EnumNodeStatus.设备空闲;
            this.currentStat.StatDescribe = "空闲状态";
            return true;
        }
	
        public virtual void BuildPathList()
        {

        }
        public virtual void DevCmdReset()
        {
            Array.Clear(db1ValsToSnd, 0, db1ValsToSnd.Count());
            string reStr = "";
            NodeCmdCommit(false,ref reStr);
        }

        /// <summary>
        /// 增加工位生产记录
        /// </summary>
        public virtual void AddProduceRecord(string containerID,string comment)
        {
            //throw new NotImplementedException();
            string strSql = string.Format(@"palletID='{0}' and palletBinded=1 ", containerID);
            List<MesDBAccess.Model.ProductOnlineModel> products = productOnlineBll.GetModelList(strSql);
            //string nextStepID = GetNextStepID(containerID);
            MesDBAccess.Model.ProduceRecordModel record = new MesDBAccess.Model.ProduceRecordModel();
            record.recordID = System.Guid.NewGuid().ToString("N");
            record.productID = containerID;
            record.recordTime = System.DateTime.Now;
            record.productCata = "料框";
            record.stationID = nodeID;
            record.tag1 = comment;
            productRecordBll.Add(record);
            if (products != null && products.Count() > 0)
            {
                foreach (MesDBAccess.Model.ProductOnlineModel product in products)
                {
                    record = new MesDBAccess.Model.ProduceRecordModel();
                    record.recordID = System.Guid.NewGuid().ToString("N");
                    record.productID = product.productID;
                    record.productCata = product.productCata;
                    record.recordTime = System.DateTime.Now;
                    record.stationID = nodeID;
                    record.checkResult = product.checkResult;
                    record.tag1 = comment;
                    record.tag2 = product.palletID;
                    productRecordBll.Add(record);
                }
            }
        }
        /// <summary>
        /// 更新产品工艺状态信息，出库时更新
        /// </summary>
        /// <param name="containerID"></param>
       

        /// <summary>
        /// 系统启动后，先回复设备运行状态
        /// </summary>
        /// <param name="errStr"></param>
        /// <returns></returns>
        public virtual bool DevStatusRestore()
        {
            if(!this.nodeEnabled)
            {
                return false;
            }
            bool readDB1OK = false;
            //for (int i = 0; i < 5; i++)
            {
                if (!ReadDB1())
                {
                    Console.WriteLine(string.Format("恢复设备状态失败，读DB1区数据失败,{0}", this.nodeName));
                    logRecorder.AddDebugLog(nodeName, string.Format("恢复设备状态失败，读DB1区数据失败,{0}", this.nodeName));
                    //return false;
                }
                else
                {
                    readDB1OK = true;
                   // break;
                }

            }
            if (!readDB1OK)
            {
                devStatusRestore = false;
                this.currentTaskDescribe = "恢复下电前状态失败，该设备将禁用，请尝试重启软件!";
                return false;
            }
            string reStr = "";
            if(!ReadDB2(ref reStr))
            {
                devStatusRestore = false;
                this.currentTaskDescribe = "恢复下电前状态失败，该设备将禁用，请尝试重启软件!";
                return false;
            }
            Array.Copy(db2Vals, db2ValsLast,db2Vals.Count());
            devStatusRestore = true;
            string strWhere = string.Format("(TaskStatus='执行中' or TaskStatus='超时') and DeviceID='{0}' order by CreateTime ", this.nodeID);
            this.currentTask = ctlTaskBll.GetFirstRequiredTask(strWhere);
            if (this.currentTask != null)
            {
                this.currentTaskPhase = this.currentTask.TaskPhase;
                this.rfidUID = this.currentTask.TaskParam;
            }

            return true;

        }
        public virtual bool WCSMainTaskStart(CtlDBAccess.Model.MainControlTaskModel mainTask,FlowCtlBaseModel.WCSFlowPathModel wcsPath,ref string reStr)
        {
            return true;
        }
        #endregion
        #region 内部功能接口
        //public int GetNextStepID(string palletID)
        //{
        //    string strSql = string.Format(@"palletID='{0}' and palletBinded=1 ", palletID);
        //    List<MesDBAccess.Model.ProductOnlineModel> products = productOnlineBll.GetModelList(strSql);
        //    int nextStepID = 0;
           
        //    return nextStepID;
        //}
       
        /// <summary>
        /// 查询是否存在未完成的任务，包括待执行的
        /// </summary>
        /// <param name="taskType"></param>
        /// <returns></returns>
        protected bool ExistUnCompletedTask(int taskType)
        {
            string strWhere = string.Format("TaskType={0} and DeviceID='{1}' and TaskStatus<>'{2}' and TaskStatus<>'{3}'",
                taskType, this.nodeID, SysCfg.EnumTaskStatus.已完成.ToString(), SysCfg.EnumTaskStatus.任务撤销.ToString());
            DataSet ds = ctlTaskBll.GetList(strWhere);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        ///// <summary>
        ///// db1 条码赋值
        ///// </summary>
        ///// <param name="barcode"></param>
        ///// <param name="db1StIndex">db1地址块索引起始，从0开始编号</param>
        //protected void BarcodeFillDB1(string barcode,int db1StIndex)
        //{
        //    byte[] barcodeBytes = System.Text.UTF8Encoding.Default.GetBytes(barcode);
        //    for (int i = 0; i < barcodeBytes.Count(); i++)
        //    {
        //        db1ValsToSnd[db1StIndex + i] = barcodeBytes[i];
        //    }
        //}

        ///// <summary>
        ///// 分析工位状态
        ///// </summary>
        ///// <param name="reStr"></param>
        ///// <returns></returns>
        //protected virtual bool NodeStatParse(ref string reStr)
        //{
           
        //    return true;
        //}
        #endregion
        #region MES接口的再封装

        /// <summary>
        /// 查询绑定数据
        /// </summary>
        /// <param name="palletID"></param>
        /// <returns></returns>
        protected bool MESGetProductsInPallet(string palletID,ref List<MesDBAccess.Model.ProductOnlineModel> batteryList,ref string reStr)
        {
            batteryList = new List<MesDBAccess.Model.ProductOnlineModel>();
            string strJsonCells = "";
            bool re = MesAcc.GetTrayBindingCell(palletID,out strJsonCells,ref reStr);
            if(!re)
            {
                reStr = "查询MES托盘电芯数据错误" + reStr;
                return false;
            }
            JObject jsonCellObj = (JObject)JsonConvert.DeserializeObject(strJsonCells);
            if(jsonCellObj == null)
            {
                return true;
            }
            for (int i = 0; i < SysCfg.SysCfgModel.TrayChannelMax; i++)
            {
                int channel = i + 1;
                string channelKey = "Cell" + channel.ToString();
                if (jsonCellObj[channelKey] == null)
                {
                    continue;
                }
                MesDBAccess.Model.ProductOnlineModel battery = new MesDBAccess.Model.ProductOnlineModel();
                battery.palletID = palletID;
                battery.palletBinded = true;
                battery.productID = jsonCellObj[channelKey].ToString().ToUpper();
                batteryList.Add(battery);
            }
            return true;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="palletID"></param>
        /// <param name="reStr"></param>
        /// <returns>0:空筐，1：满筐，-1：错误</returns>
        protected int MESPalletStat(string palletID,ref string reStr)
        {
            int re = -1;
            List<MesDBAccess.Model.ProductOnlineModel> batteryList = new List<MesDBAccess.Model.ProductOnlineModel>();
            if(MESGetProductsInPallet(palletID,ref batteryList,ref reStr))
            {
                if(batteryList.Count()>0)
                {
                    re = 1;
                }
                else
                {
                    re = 0;
                }
            }
            else
            {
                re = -1;
            }
            return re;
        }
        /// <summary>
        /// 查询MES分拣数据
        /// </summary>
        /// <param name="step"></param>
        /// <param name="palletID"></param>
        /// <param name="vals">只能查到NG的电芯，其它都认为OK,1:ok,2:NG</param>
        /// <param name="reStr"></param>
        /// <returns></returns>
        protected bool MESGetGraspVals(int step,string palletID,ref List<int> vals,ref string reStr)
        {
            try
            {
                int channelMax =SysCfg.SysCfgModel.TrayChannelMax;
                //JObject paramObj = new JObject(new JProperty("Step", "19"), new JProperty("TrayNo", "TP2001"));
                //paramObj["Step"] = step.ToString();
                //paramObj["TrayNo"] = palletID;
                //string jsonParam = string.Format(" \"Step\":\"{0}\",\"TrayNo\":\"{1}\" ", step, palletID);
                string jsonCellList = "";
                bool graspRe = this.MesAcc.GetCellSeparation(step, palletID, ref jsonCellList,ref reStr);
                if (!graspRe)
                {
                    reStr = "查询MES分拣结果，返回失败，" + reStr;
                    return false;
                }
                JArray graspArray = (JArray)JsonConvert.DeserializeObject(jsonCellList);
                if (graspArray == null)
                {
                    reStr = "解析分拣数据失败";
                    return false;
                }
                vals = new List<int>();
                for (int i = 0; i < channelMax; i++)
                {
                    int channel = i + 1;
                    bool schOk = false;
                    foreach (JObject cellObj in graspArray)
                    {
                        if (cellObj["CHANNEL"].ToString() == channel.ToString())
                        {
                            vals.Add(2);
                            schOk = true;
                            break;
                        }
                    }
                    if (!schOk)
                    {
                        vals.Add(1);
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
        #endregion
    }
}
