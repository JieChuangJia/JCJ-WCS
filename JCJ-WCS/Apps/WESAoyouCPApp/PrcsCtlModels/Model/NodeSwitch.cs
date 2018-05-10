using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using DevAccess;
using FlowCtlBaseModel;
namespace PrcsCtlModelsAoyou
{
    //C1/C2入库前分流
    public class NodeSwitch : CtlNodeBaseModel
    {
        private Dictionary<int, string> ocvSeqDic = new Dictionary<int, string>();
        private OcvAccess ocvAccess = null;
        private AsrsInterface.IAsrsManageToCtl asrsResManage = null;
        private List<string> targetPortIDs = new List<string>();
       // private DateTime switchSt = DateTime.Now;
        private List<AsrsControl.AsrsPortalModel> targetPorts = new List<AsrsControl.AsrsPortalModel>();
        public List<AsrsControl.AsrsPortalModel> TargetPorts { get { return targetPorts; } set { targetPorts = value; } }
        public List<string> TargetPortIDs { get { return targetPortIDs; } }
        public AsrsInterface.IAsrsManageToCtl AsrsResManage { get { return asrsResManage; } set { asrsResManage = value; } }
        public OcvAccess OcvAccess { get { return ocvAccess; } set { ocvAccess = value; } }
        public override bool BuildCfg(System.Xml.Linq.XElement xe, ref string reStr)
        {
            ocvSeqDic[1] = "PS-40";
            ocvSeqDic[2] = "PS-70";
            ocvSeqDic[3] = "PS-80";
            ocvSeqDic[4] = "PS-90";
            ocvSeqDic[5] = "PS-110";
            if (!base.BuildCfg(xe, ref reStr))
            {
                return false;
            }
            XElement selfDataXE = xe.Element("SelfDatainfo");
            if (selfDataXE.Attribute("targetPorts") != null)
            {
                string[] portIDS = selfDataXE.Attribute("targetPorts").Value.ToString().Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
                if(portIDS != null && portIDS.Count()>0)
                {
                    this.targetPortIDs.Clear();
                    this.targetPortIDs.AddRange(portIDS);
                }
            }
            this.dicCommuDataDB1[1].DataDescription = "0：复位,1：流向C1库,2：流向C2库,3: 等待,4：读卡失败,5: 不可识别的料框托盘号,6：入库申请失败 ";
            this.dicCommuDataDB2[1].DataDescription = "1：无板，2：有板";
            //this.dicCommuDataDB2[1].DataDescription = "1：无请求，2：RFID读取/扫码开始,3：只有一个模组";
            //this.dicCommuDataDB2[2].DataDescription = "1：无请求，2：只有一个模组";
            currentTaskPhase = 0;

            return true;
        }
        
        public override bool ExeBusiness(ref string reStr)
        {

            if (db2Vals[0] == 1)
            {
                currentTaskPhase = 0;
                DevCmdReset();
                db1ValsToSnd[0] = 0;

                rfidUID = string.Empty;
                currentTaskDescribe = "等待新的任务";
                //return true;
            }
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
                            this.rfidUID=System.Guid.NewGuid().ToString();
                
                        }
                        else
                        {
                            if (SysCfg.SysCfgModel.SimMode || SysCfg.SysCfgModel.RfidSimMode)
                            {
                                this.rfidUID = this.SimRfidUID;
                            }
                            else
                            {
                                if (this.barcodeRW != null)
                                {
                                    this.rfidUID = this.barcodeRW.ReadBarcode();
                                }
                                else
                                {
                                    this.rfidUID = rfidRW.ReadStrData();// rfidRW.ReadUID();
                                }

                            }
                        }
                        
                        if (string.IsNullOrWhiteSpace(this.rfidUID))
                        {
                            if (this.db1ValsToSnd[0] != 4)
                            {
                                logRecorder.AddDebugLog(nodeName, "读料框条码失败");
                            }
                            this.db1ValsToSnd[0] = 4;
                            break;
                        }
                        if(this.rfidUID.Length<9)
                        {
                            if (this.db1ValsToSnd[0] != 4)
                            {
                                logRecorder.AddDebugLog(nodeName, "读料框条码错误，长度不足9字符！");
                            }
                            this.db1ValsToSnd[0] = 4;
                            break;
                        }
                        this.rfidUID = this.rfidUID.Trim(new char[] { '\0', '\r', '\n', '\t', ' ' });
                        string pattern = @"^[a-zA-Z0-9]*$"; //匹配所有字符都在字母和数字之间  
                        if (!System.Text.RegularExpressions.Regex.IsMatch(this.rfidUID, pattern))
                        {
                            if (this.db1ValsToSnd[1] != 3)
                            {
                                logRecorder.AddDebugLog(nodeName, "读料框ID错误，含有非法字符 ！" + this.rfidUID);
                            }
                            this.db1ValsToSnd[1] = 3;
                            return true;
                        }
                        if (this.rfidUID.Length > 9)
                        {
                            this.rfidUID = this.rfidUID.Substring(0, 9);
                        }
                        logRecorder.AddDebugLog(this.nodeName, "读到托盘号:" + this.rfidUID);
                       /*
                        if (!SysCfg.SysCfgModel.UnbindMode)
                        {
                            List<MesDBAccess.Model.ProductOnlineModel> productList = this.productOnlineBll.GetModelList(string.Format("palletID='{0}' and palletBinded=1 ", this.rfidUID));
                            if (productList == null || productList.Count() < 1)
                            {
                                if (this.db1ValsToSnd[0] != 5)
                                {
                                    logRecorder.AddDebugLog(nodeName, "工装板绑定数据为空,"+rfidUID);
                                }
                                db1ValsToSnd[0] = 5;
                                this.CurrentStat.Status = EnumNodeStatus.设备故障;
                                this.CurrentStat.StatDescribe = "工装板绑定数据为空";
                                this.CurrentTaskDescribe = "工装板绑定数据为空";
                                break;
                            }
                        }
                        */
                        this.currentTaskPhase++;
                        break;
                    }
                case 2:
                    {
                        
                        //查询杭可ocv测试数据库，得到当前工艺步号，更新产品记录表
                        if(!SysCfg.SysCfgModel.SimMode)
                        {
                            int ocvSeq = ocvAccess.GetOcvStepSeq(this.rfidUID, ref reStr);
                            if (ocvSeq > 0 && (!SysCfg.SysCfgModel.SimMode))
                            {
                                string strSql = string.Format(@"palletID='{0}' and palletBinded=1 ", this.rfidUID);
                                List<MesDBAccess.Model.ProductOnlineModel> products = productOnlineBll.GetModelList(strSql);
                                foreach (MesDBAccess.Model.ProductOnlineModel m in products)
                                {
                                    m.processStepID = ocvSeqDic[ocvSeq];
                                    productOnlineBll.Update(m);
                                }
                            }
                        }

                        DateTime switchSt = DateTime.Now;
                        int switchRe = GetSwitchDecision(this.rfidUID,ref reStr);
                        if(switchRe<1)
                        {
                            this.db1ValsToSnd[0] = 3;
                            currentTaskDescribe = reStr;
                            break;
                        }
                        if(switchRe == 3 && this.db1ValsToSnd[0] != 3)
                        {
                            string port1Buffer = "";
                            string port2Buffer="";
                            if(targetPorts[0].PalletBuffer.Count>0)
                            {
                                foreach(string str in targetPorts[0].PalletBuffer)
                                {
                                    port1Buffer += (str+",");
                                }
                            }
                            if(targetPorts[1].PalletBuffer.Count>0)
                            {
                                foreach(string str in targetPorts[1].PalletBuffer)
                                {
                                    port2Buffer += (str+",");
                                }
                            }
                            currentTaskDescribe = string.Format(@"托盘{0}分流口需要等待,C1库入口缓存：{1},C2库入口缓存：{2}", this.rfidUID, port1Buffer, port2Buffer);
                            logRecorder.AddDebugLog(nodeName, string.Format(@"托盘{0}分流口需要等待,C1库入口缓存：{1},C2库入口缓存：{2}", this.rfidUID, port1Buffer, port2Buffer));
                        }
                        DateTime curTime = DateTime.Now;
                        TimeSpan ts = curTime - switchSt;
                        if(ts.TotalSeconds>5)
                        {
                            logRecorder.AddDebugLog(nodeName, string.Format(@"托盘{0} 计算分流方向耗时：{1},分流方向：{2}", this.rfidUID, ts.TotalSeconds,switchRe));
                        }
                        this.db1ValsToSnd[0] = (short)switchRe;
                        if (switchRe == 1 || switchRe == 2)
                        {
                             string logStr = string.Format("{0}分流，进入{1}", this.rfidUID,targetPorts[this.db1ValsToSnd[0] - 1].NodeName);
                             targetPorts[switchRe-1].PushPalletID(this.rfidUID);
                             logRecorder.AddDebugLog(nodeName, logStr);
                             AddProduceRecord(this.rfidUID, logStr);
                             this.currentTaskDescribe = logStr;
                            // Console.WriteLine(logStr); 
                             this.rfidUID = "";
                        }
                        else if (this.db1ValsToSnd[0]==3)
                        {
                            //this.currentTaskDescribe = "等待分流";
                            break;
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

            AsrsCheckinRequire();
            
            return true;
        }
        private void AsrsCheckinRequire()
        {
            //foreach(AsrsControl.AsrsPortalModel port in targetPorts)
            for (int i = 0; i < targetPorts.Count();i++ )
            {
                AsrsControl.AsrsPortalModel port = targetPorts[i];
                if(port.AsrsCtl.StackDevice.Db2Vals[0] >0 || port.AsrsCtl.StackDevice.Db2Vals[1]>2)
                {
                    continue;
                }
                if (port.PalletBuffer.Count() < 1)
                {
                    continue;
                }
               
                bool checkInRequire = false;
                if (port.PalletBuffer.Count() >= port.PortinBufCapacity)
                {
                    checkInRequire = true;
                }
                else
                {
                    if (db1ValsToSnd[0] == 3 && port.Db2Vals[0] == 2)
                    {
                        checkInRequire = true;
                    }
                }
                for (int j = 0; j < Math.Min(port.PalletBuffer.Count(), port.PortinBufCapacity); j++)
                {
                    if (port.Db2Vals[j] != 2)
                    {
                        checkInRequire = false;
                        break;
                    }
                }
                if(port.Db2Vals[2] == 2) //手动入库按钮请求
                {
                    checkInRequire = true;
                }
                if (!checkInRequire)
                {
                    continue;
                }
                string palletID = port.PalletBuffer[0];
                #region 查询本地应该进入哪个分区
                /*
                string nextProcessID = port.AsrsCtl.GetNextStepID(palletID);
                int nextProcessSeq = SysCfg.SysCfgModel.stepSeqs.IndexOf(nextProcessID);
                int curSeq = SysCfg.SysCfgModel.stepSeqs.IndexOf(port.AsrsCtl.MesProcessStepID[0]);
                AsrsModel.EnumLogicArea logicArea = AsrsModel.EnumLogicArea.冷却区;
                if (nextProcessSeq > curSeq)
                {
                    logicArea = AsrsModel.EnumLogicArea.常温区;
                }*/
                #endregion
                #region 查询MES应该进入哪个库区
                
				//在MES中查询入口处的第一个托盘当前工步，判断应该进入哪个库区
                int step = 0;
                //ANCStepResult stepRe = MesAcc.GetStep(palletID);
                //if (stepRe.ResultCode != 0)
                //{
                //    port.CurrentTaskDescribe = "查询MES托盘步次失败:" + stepRe.ResultMsg;
                //    continue;
                //}

                AsrsModel.EnumLogicArea logicArea = AsrsModel.EnumLogicArea.分容常温区;
                if(step<12)
                {
                    logicArea = AsrsModel.EnumLogicArea.分容常温区;
                }
                else
                {
                    logicArea = AsrsModel.EnumLogicArea.OCV常温区;
                }
                #endregion
               
                string reStr = "";
                SysCfg.EnumAsrsTaskType taskType = SysCfg.EnumAsrsTaskType.产品入库;
                if (port.AsrsCtl.AsrsCheckinTaskRequire(port, logicArea, taskType, port.PalletBuffer.ToArray(), ref reStr))
                {
                    //port.PalletBuffer.Clear();
                    if (!port.ClearBufPallets(ref reStr))
                    {
                        logRecorder.AddDebugLog(port.NodeName, "清理入口缓存数据失败" + reStr);
                    }
                    
                }
                else
                {
                    string logStr = string.Format("{0}申请失败,因为：{1}", taskType.ToString(), reStr);
                    logRecorder.AddDebugLog(port.NodeName, logStr);
                }
            }
        }
        private int GetSwitchDecision(string palletID,ref string reStr)
        {
            int re = 0;
            #region 查询本地应该进入哪个分区
            /*
            string nextMesStepID = targetPorts[0].AsrsCtl.GetNextStepID(this.rfidUID);
            string currentMesStepID = GetCurrentStepID(this.rfidUID);
            int curSeq = SysCfg.SysCfgModel.stepSeqs.IndexOf(currentMesStepID);
            int nextSeq = SysCfg.SysCfgModel.stepSeqs.IndexOf(nextMesStepID);
            string storeAreaZone = AsrsModel.EnumLogicArea.常温区.ToString();
            int seq1 = SysCfg.SysCfgModel.stepSeqs.IndexOf("PS-60");
            //int seq2 = SysCfg.SysCfgModel.stepSeqs.IndexOf("PS-100");
            if (nextSeq <= seq1)
            {
                storeAreaZone = AsrsModel.EnumLogicArea.冷却区.ToString();
            }
            else
            {

                storeAreaZone = AsrsModel.EnumLogicArea.常温区.ToString();
            }*/
            #endregion
            #region 查询MES 下一步应该进哪个库区
            string storeAreaZone = AsrsModel.EnumLogicArea.通用分区.ToString();

            ANCStepResult stepRe = MesAcc.GetStep(palletID);
            if (stepRe.ResultCode != 0)
            {
                reStr = string.Format("查询MES托盘{0}步次失败:{1}", palletID, stepRe.ResultMsg);
                return -1;
            }
            if (stepRe.Step < 12)
            {
                storeAreaZone = AsrsModel.EnumLogicArea.分容常温区.ToString();
            }
            else
            {
                storeAreaZone = AsrsModel.EnumLogicArea.OCV常温区.ToString();
            }
	        #endregion
            if (targetPorts[0].PalletBuffer.Count() == 0 && targetPorts[1].PalletBuffer.Count() == 0)
            {
                //查询C1,C2库剩余货位数量
                    
                int cellEmptCounts1 = 0, cellEmptCounts2 = 0;
         
                this.asrsResManage.GetHouseAreaLeftGs("C1库房", storeAreaZone, ref cellEmptCounts1, reStr);
                this.asrsResManage.GetHouseAreaLeftGs("C2库房", storeAreaZone, ref cellEmptCounts2, reStr);
                if (cellEmptCounts1 >= cellEmptCounts2 && cellEmptCounts1 > 0 && targetPorts[0].Db2Vals[0] != 2 && targetPorts[0].Db2Vals[1]!=2)
                {
                    re = 1;//流向C1,  this.db1ValsToSnd[0] = 1;
                }
                else if (cellEmptCounts1 < cellEmptCounts2 && cellEmptCounts2 > 0 && targetPorts[1].Db2Vals[0] != 2 && targetPorts[1].Db2Vals[1] != 2)
                {
                    re = 2;//流向C2,  this.db1ValsToSnd[0] = 2;
                   

                }
                else
                {
                    re = 3;//等待 this.db1ValsToSnd[0] = 3;

                }
            }
            else
            {
                bool switchStat = false;
                for (int i = 0; i < targetPorts.Count(); i++)
                {
                    if (targetPorts[i].PalletBuffer.Count() > 0 && targetPorts[i].PalletBuffer.Count() < targetPorts[i].PortinBufCapacity)
                    {
                        string lastPalletID = targetPorts[i].PalletBuffer[targetPorts[i].PalletBuffer.Count() - 1];
                        
                        #region 查询MES应该进入那个分区,及批次
                         string storeAreaZoneLast = AsrsModel.EnumLogicArea.分容常温区.ToString();
                         stepRe = MesAcc.GetStep(lastPalletID);
                         if (stepRe.ResultCode != 0)
                         {
                             reStr = "查询MES托盘步次失败:" + stepRe.ResultMsg;
                             return -1;
                         }
                         if(stepRe.Step<12)
                         {
                             storeAreaZoneLast = AsrsModel.EnumLogicArea.分容常温区.ToString();
                         }
                         else
                         {
                             storeAreaZoneLast = AsrsModel.EnumLogicArea.OCV常温区.ToString();
                         }

                         
                         VMResultLot reLast = MesAcc.GetTrayCellLotNO(lastPalletID);
                         VMResultLot reCur = MesAcc.GetTrayCellLotNO(this.rfidUID);
                         if(reLast.ResultCode != 0)
                         {
                             reStr = string.Format("查询MES 托盘号{0}的批次失败,{1}", lastPalletID, reLast.ResultMsg);
                             break;
                         }
                         if(reCur.ResultCode != 0)
                         {
                             reStr = string.Format("查询MES 托盘号{0}的批次失败,{1}", this.rfidUID, reCur.ResultMsg);
                             break;
                         }
                         string preBatch = reLast.LotNO;//productOnlineBll.GetBatchNameofPallet(lastPalletID);
                         string curBatch = reCur.LotNO;//productOnlineBll.GetBatchNameofPallet(this.rfidUID);
                        #endregion
                        #region 查询MES应该进入那个分区,本地批次信息
                         /*
                        string preBatch = productOnlineBll.GetBatchNameofPallet(lastPalletID);
                        string curBatch = productOnlineBll.GetBatchNameofPallet(this.rfidUID);
                        string nextMesStepIDLast = targetPorts[0].AsrsCtl.GetNextStepID(lastPalletID);
                        string currentMesStepIDLast = GetCurrentStepID(lastPalletID);
                        int curSeqLast = SysCfg.SysCfgModel.stepSeqs.IndexOf(currentMesStepIDLast);
                        int nextSeqLast = SysCfg.SysCfgModel.stepSeqs.IndexOf(nextMesStepIDLast);
                        string storeAreaZoneLast = AsrsModel.EnumLogicArea.冷却区.ToString();
                        int seq1Last = SysCfg.SysCfgModel.stepSeqs.IndexOf("PS-60");
                        //int seq2 = SysCfg.SysCfgModel.stepSeqs.IndexOf("PS-100");
                        if (nextSeqLast <= seq1Last)
                        {
                            storeAreaZoneLast = AsrsModel.EnumLogicArea.冷却区.ToString();
                        }
                        else
                        {

                            storeAreaZoneLast = AsrsModel.EnumLogicArea.常温区.ToString();
                        }*/
                        #endregion
                        if (preBatch == curBatch && (storeAreaZone == storeAreaZoneLast))
                        {
                            re = (Int16)(i + 1);//this.db1ValsToSnd[0] = 
                            //targetPorts[i].PushPalletID(this.rfidUID);
                            switchStat = true;
                            break;
                        }
                    }
                  

                }
                if (!switchStat) //遍历各入口未能满足2筐入库规则，则选择缓存为空的入口
                {
                    for (int i = 0; i < targetPorts.Count(); i++)
                    {
                        //if (targetPorts[i].PalletBuffer.Count() == 0 && ((targetPorts[i].AsrsCtl.StackDevice.Db2Vals[1] < 3) || (targetPorts[i].AsrsCtl.StackDevice.Db2Vals[0] > 0)))
                        if ((targetPorts[i].PalletBuffer.Count() == 0) && (targetPorts[i].Db2Vals[0] < 2))//入口缓存数据为空，并且入口处无板（光眼信号判断）。
                        {
                            int cellEmptCounts = 0;
                           
                            if (!this.asrsResManage.GetHouseAreaLeftGs(targetPorts[i].AsrsCtl.HouseName, storeAreaZone, ref cellEmptCounts, reStr))
                            {
                                continue;
                            }
                            if (cellEmptCounts <= 0)
                            {
                                continue;
                            }
                            re = (Int16)(i + 1);//this.db1ValsToSnd[0] =
                            // targetPorts[i].PushPalletID(this.rfidUID);
                            switchStat = true;
                            break;
                        }
                    }
                }

                if (!switchStat)
                {
                    re = 3;// this.db1ValsToSnd[0] = 3;
                    //this.currentTaskDescribe = "等待分流";
                    //break;
                }
            }
            return re;
        }
    }
}
