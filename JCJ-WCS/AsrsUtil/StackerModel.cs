using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using System.Data;
using DevInterface;
namespace AsrsUtil
{
    public class StackerModel
    {
        protected AsrsTaskModel currentTask = null;
        protected int currentTaskPhase = 0;//流程步号（状态机）,
        protected string currentTaskDescribe = "";// 当前任务描述

        protected IDictionary<int, PLCDataDef> dicCommuDataDB1 = null;//通信功能项字典，DB1
        protected IDictionary<int, PLCDataDef> dicCommuDataDB2 = null;//通信功能项字典，DB2
        protected Int16[] db1ValsToSnd = null; //db1待发送数据
        protected Int16[] db1ValsReal = null; //PLC 实际DB1数据
        protected Int16[] db2Vals = null;
 
        /// DB1数据区的锁
        private object lockDB1 = new object();
        /// DB2数据区的锁
        private object lockDB2 = new object();
        protected IDictionary<int, string> errcodeMap = null;

        protected string db1StartAddr = ""; //db1 开始地址
        protected string db2StartAddr = ""; //db2 开始地址
        protected IPlcRW plcRW = null;//设备的plc读写接口
        protected string nodeID = "";
        protected string nodeName = "";
        protected bool devStatusRestore = false;//是否已经恢复下电前状态
        public IPlcRW PlcRW
        {
            get { return this.plcRW; }
            set { this.plcRW = value; }
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
        public string Db1StartAddr { get { return db1StartAddr; } }
        public string Db2StartAddr { get { return db2StartAddr; } }
        public StackerModel()
        {
            db1StartAddr = "D2001";
            db2StartAddr = "3001";

        }
        public virtual bool BuildCfg(XElement xe, ref string reStr)
        {
            this.nodeID = xe.Attribute("id").Value;
           
            XElement baseDataXE = xe.Element("BaseDatainfo");
            if (baseDataXE == null)
            {
                reStr = this.nodeID + "，没有BaseDatainfo节点配置信息";
                return false;
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
                commData.DataAddr = "D" + (db1Start + i).ToString();
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
            if (selfDataXE != null)
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
               
                
            }
            this.dicCommuDataDB1[1].DataDescription = "参数写入标志，1：复位，2：写入完成";
            this.dicCommuDataDB1[2].DataDescription = "任务处理完成标志，1：复位，2：处理完成,3:撤销处理完成";
            this.dicCommuDataDB1[3].DataDescription = "任务类型标志，1：产品入库，2：空筐入库,3:产品出库，4：空筐出库，5：移库";
            this.dicCommuDataDB1[4].DataDescription = "入口编号（从1开始）";
            this.dicCommuDataDB1[5].DataDescription = "出口编号（从1开始）";
            this.dicCommuDataDB1[6].DataDescription = "货位编号 ：排（从1开始）";
            this.dicCommuDataDB1[7].DataDescription = "货位编号 ：列（从1开始）";
            this.dicCommuDataDB1[8].DataDescription = "货位编号 ：层（从1开始）";

            this.dicCommuDataDB1[9].DataDescription = "货位编号2（移库时用） ：排（从1开始）";
            this.dicCommuDataDB1[10].DataDescription = "货位编号2 （移库时用）：列（从1开始）";
            this.dicCommuDataDB1[11].DataDescription = "位编号2（移库时用） ：层（从1开始）";
            this.dicCommuDataDB1[12].DataDescription = "1:故障处理未完成,2：故障处理完成";
            this.dicCommuDataDB1[13].DataDescription = "预留参数1";
            this.dicCommuDataDB1[14].DataDescription = "预留参数2";
            this.dicCommuDataDB1[15].DataDescription = "预留参数3";
            return true;
        }
        public virtual bool ReadDB1()
        {
            int blockNum = this.dicCommuDataDB1.Count(); 
            short[] vals = null;
            //同步通信
            if (!plcRW.ReadMultiDB(db1StartAddr, blockNum, ref vals))
            {
                // refreshStatusOK = false;
                Console.WriteLine("读PLC数据(DB1）失败");
                return false;
            }
            for (int i = 0; i < blockNum; i++)
            {
                int commID = i + 1;
                this.dicCommuDataDB1[commID].Val = vals[i];
                this.db1ValsReal[i] = vals[i];
            }
                
             
            return true;


        }
        public virtual bool ReadDB2(ref string reStr)
        {
            int blockNum = this.dicCommuDataDB2.Count();  
            short[] vals = null;
            if(MainPresenter.SimMode)
            {
                for (int i = 0; i < blockNum; i++)
                {
                    int commID = i + 1;
                    this.db2Vals[i] = short.Parse(this.dicCommuDataDB2[commID].Val.ToString());
                }

            }
            else
            {
                if (!plcRW.IsConnect)
                {
                    if (!plcRW.ConnectPLC(ref reStr))
                    {
                        Console.WriteLine("PLC连接失败");
                        return false;
                    }
                }
                //同步通信
                if (!plcRW.ReadMultiDB(db2StartAddr, blockNum, ref vals))
                {
                    Console.WriteLine("读PLC数据(DB2）失败");
                    return false;
                }
                for (int i = 0; i < blockNum; i++)
                {
                    int commID = i + 1;
                    this.dicCommuDataDB2[commID].Val = vals[i];
                    this.db2Vals[i] = vals[i];
                }
            }
           
            return true;


        }
        public DataTable GetDB1DataDetail()
        {
            DataTable dt = new DataTable();
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
            DataTable dt = new DataTable();
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
        public string GetRunningTaskDetail()
        {

            string taskInfo = string.Format("流程执行到第{0}步", this.currentTaskPhase) + ":" + currentTaskDescribe;
            return taskInfo;

        }
        public void  SimSetDB2(int dbItemID, int val)
        {
            DicCommuDataDB2[dbItemID].Val = val;
        }
        public bool DevReset()
        {
            try
            {
                Array.Clear(db1ValsToSnd, 0, db1ValsToSnd.Count());
                db1ValsToSnd[0] = 1;
                db1ValsToSnd[1] = 1;
                string reStr = "";
                if(!NodeCmdCommit(false, ref reStr))
                {
                    Console.WriteLine("提交命令数据错误:"+reStr);
                    return false;
                }
                this.currentTask = null;
                currentTaskDescribe = "等待新的任务";
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
        }
        public virtual bool DevStatusRestore()
        {
            
            bool readDB1OK = false;
          
            {
                if (!ReadDB1())
                {
                    Console.WriteLine(string.Format("恢复设备状态失败，读DB1区数据失败,{0}", this.nodeName));
                   
                }
                else
                {
                    readDB1OK = true;
                   
                }

            }
            if (!readDB1OK)
            {
                devStatusRestore = false;
               
                return false;
            }
            devStatusRestore = true;
          
            return true;

        }

        /// <summary>
        /// 控制流程的命令数据提交
        /// </summary>
        /// <param name="reStr"></param>
        /// <returns></returns>
        public virtual bool NodeCmdCommit(bool diffSnd, ref string reStr)
        {
            int blockNum = this.dicCommuDataDB1.Count();
            if (!plcRW.IsConnect)
            {
                if (!plcRW.ConnectPLC(ref reStr))
                {
                    Console.WriteLine("PLC连接失败");
                    return false;
                }
            }

            if (!plcRW.WriteMultiDB(this.db1StartAddr, blockNum, this.db1ValsToSnd))
            {
                Console.WriteLine("发送设备命令失败！");
                return false;
            }
            for (int i = 0; i < blockNum; i++)
            {
                int commID = i + 1;
                this.dicCommuDataDB1[commID].Val = this.db1ValsToSnd[i];

                // this.db1ValsReal[i] = vals[i];
            }
            
            return true;

        }
        public bool FillTask(AsrsTaskModel task, ref string reStr)
        {
            if (this.currentTask != null)
            {
                reStr = "当前任务未执行完，不能接受新的任务";
                return false;
            }
            this.currentTask = task;
            return true;
        }
        private void TaskReback()
        {
            if (this.currentTask != null && this.currentTaskPhase > 0)
            {
               
                this.currentTask = null;
                this.currentTaskPhase = 0;
            }
            if (db1ValsToSnd[1] != 3)
            {
                ///DevCmdReset();
                Array.Clear(this.db1ValsToSnd, 0, this.db1ValsToSnd.Count());
                db1ValsToSnd[1] = 3;//
            }

            currentTaskDescribe = "任务撤销，等待'撤销信号'复位";

        }
        public bool ExeBusiness(ref string reStr)
        {
            if (!devStatusRestore)
            {
                devStatusRestore = DevStatusRestore();
            }
            if (!devStatusRestore)
            {
                return false;
            }
            //任务撤销
            if (db2Vals[2] == 3 && db1ValsToSnd[1] != 3)
            {
                TaskReback();
                return true;
            }
            if (db1ValsToSnd[1] == 3 && db2Vals[2] == 1)
            {
                //任务撤销命令复位，应答也复位
                db1ValsToSnd[1] = 1;
            }
            //if (currentTask != null)
            //{
            //    this.currentStat.Status = EnumNodeStatus.设备使用中;

            //}
            //else
            //{
            //    this.currentStat.Status = EnumNodeStatus.设备空闲;
            //}
            if (this.db2Vals[0] != 0)
            {
                this.db1ValsToSnd[11] = 1;
                currentTaskDescribe = "设备故障";
                return true;
            }
            switch (currentTaskPhase)
            {
                case 0:
                    {
                        currentTaskDescribe = "等待新的任务";
                        if (currentTask == null)
                        {
                            break;
                        }
                        currentTaskDescribe = "等待设备空闲状态";
                        if (this.db2Vals[1] == 1) //设备处于空闲状态，可以 接受新的任务
                        {
                            //写入参数
                            string logInfo = string.Format("开始执行任务:{0},{1}-{2}-{3}", ((EnumAsrsTaskType)currentTask.TaskType).ToString(), this.currentTask.CellA.Row, this.currentTask.CellA.Col, this.currentTask.CellA.Layer);
                            if (WriteTaskParam())
                            {
                                this.currentTaskPhase++;
                                this.currentTask.TaskStatus = EnumTaskStatus.执行中.ToString();
                                this.currentTask.TaskPhase = currentTaskPhase;
                             
                            }

                        }

                        break;
                    }
                case 1:
                    {
                        //参数写入完成
                        currentTaskDescribe = "开始发送参数";
                        this.db1ValsToSnd[0] = 2;
                        if (!NodeCmdCommit(true, ref reStr))
                        {
                            Console.WriteLine("发送参数失败");
                            break;
                        }
                        currentTask.TaskPhase = currentTaskPhase;
                        Console.WriteLine("{0}参数发送完成");
                        this.currentTaskPhase++;
                        this.currentTask.TaskPhase = currentTaskPhase;
                  
                        break;
                    }
                case 2:
                    {
                        //等待任务完成
                        currentTaskDescribe = "等待设备进入工作状态";
                        if (db2Vals[1] != 2)
                        {
                            //必须进入工作状态
                            break;
                        }
                        

                        db1ValsToSnd[0] = 1;
                        currentTaskDescribe = "等待任务完成";
                        if (db2Vals[2] == 2)
                        {

                            for (int i = 3; i < db1ValsToSnd.Count(); i++)
                            {
                                db1ValsToSnd[i] = 0;
                            }
                            //处理任务
                            
                            //if (!TaskCompletedProcess(this.taskParamModel, this.currentTask))
                            //{
                            //    logRecorder.AddDebugLog(nodeName, "任务完成后处理失败!");
                            //    break;
                            //}
                            db1ValsToSnd[1] = 2;
                            if (!NodeCmdCommit(true, ref reStr))
                            {
                                Console.WriteLine("发送任务处理完成状态失败");
                                break;
                            }
                            // string debugLog = string.Format("任务ID：{0}，{1}完成！", currentTask.TaskID, currentTask.Remark);
                            string debugLog = string.Format("任务:{0},{1}-{2}-{3}完成", ((EnumAsrsTaskType)currentTask.TaskType).ToString(), this.currentTask.CellA.Row, this.currentTask.CellA.Col, this.currentTask.CellA.Layer);
                            Console.WriteLine(debugLog);
                            currentTaskDescribe = "任务完成";
                            this.currentTaskPhase++;
                        }

                        currentTask.TaskPhase = currentTaskPhase;
                       
                        break;
                    }
                case 3:
                    {
                        currentTaskDescribe = "等待任务完成信号复位";
                        if (db2Vals[2] != 1)
                        {
                            break;
                        }

                        DevReset();
                        currentTask = null;
                        currentTaskPhase = 0;
                        currentTaskDescribe = "等待执行下一个任务";
                        break;
                    }
                default:
                    break;
            }
            return true;
        }
        private bool WriteTaskParam()
        {
           

            //1 任务类型码
            this.db1ValsToSnd[2] = (short)this.currentTask.TaskType;

            this.db1ValsToSnd[3] = (short)this.currentTask.InputPort;
            this.db1ValsToSnd[4] = (short)this.currentTask.OutputPort;

            this.db1ValsToSnd[5] = (short)this.currentTask.CellA.Row;
            this.db1ValsToSnd[6] = (short)this.currentTask.CellA.Col;
            this.db1ValsToSnd[7] = (short)this.currentTask.CellA.Layer;

            return true;
        }
      
    }
}
