using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using FlowCtlBaseModel;
namespace PrcsCtlModelsAoyou
{
    public class NodeVirStation : CtlNodeBaseModel
    {
        private short barcodeFailedStat = 3;
        public NodeVirStation()
        {
            this.currentTaskPhase = 0;
        }
        public override bool ExeBusiness(ref string reStr)
        {
            if(this.nodeID == "4001")
            {
                if (this.db2Vals[1] != SysCfg.SysCfgModel.ZhuyeMode)
                {
                    logRecorder.AddDebugLog(nodeName, string.Format("一次注液模式切换到{0}步模式", this.db2Vals[1]));

                }
                SysCfg.SysCfgModel.ZhuyeMode = this.db2Vals[1];
               
            }
            if(this.nodeID == "4001" || this.nodeID=="4002")
            {
                barcodeFailedStat = 4;
            }
            else
            {
                barcodeFailedStat = 3;
            }
            if (db2Vals[0] == 1)
            {
                currentTaskPhase = 0;
                DevCmdReset();
                db1ValsToSnd[0] = 0;

                rfidUID = string.Empty;
                currentTaskDescribe = "等待新的任务";
                return true;
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
                        if (string.IsNullOrWhiteSpace(this.rfidUID))
                        {
                            if (this.db1ValsToSnd[0] != barcodeFailedStat)
                            {
                                logRecorder.AddDebugLog(nodeName, "读RFID失败");
                            }
                            this.db1ValsToSnd[0] = barcodeFailedStat;
                            currentTaskDescribe = "读RFID失败";
                            break;
                        }
                        this.rfidUID = this.rfidUID.Trim(new char[] { '\0', '\r', '\n', '\t', ' ' });
                        string pattern = @"^[a-zA-Z0-9]*$"; //匹配所有字符都在字母和数字之间  
                        if (!System.Text.RegularExpressions.Regex.IsMatch(this.rfidUID, pattern))
                        {
                            if (this.db1ValsToSnd[0] != barcodeFailedStat)
                            {
                                logRecorder.AddDebugLog(nodeName, "读料框ID错误，含有非法字符 ！" + this.rfidUID);
                            }
                            this.db1ValsToSnd[0] = barcodeFailedStat;
                            return true;
                        }

                        if (this.rfidUID.Length < 9)
                        {
                            if (this.db1ValsToSnd[0] != barcodeFailedStat)
                            {
                                logRecorder.AddDebugLog(nodeName, "读料框RFID错误，长度不足9字符！");
                            }
                            this.db1ValsToSnd[0] = barcodeFailedStat;
                            break;
                        }

                        if (this.rfidUID.Length > 9)
                        {
                            this.rfidUID = this.rfidUID.Substring(0, 9);
                        }
                        logRecorder.AddDebugLog(this.nodeName, "读到托盘号:" + this.rfidUID);
                        currentTaskDescribe = "开始执行分流";
                        string logStr = "";
                        ANCStepResult stepRe = MesAcc.GetStep(this.rfidUID);
                        if (stepRe.ResultCode != 0)
                        {
                            this.currentTaskDescribe = "查询MES托盘步次失败:" + stepRe.ResultMsg;
                            break;
                        }
                        int palletStat = MESPalletStat(this.rfidUID, ref reStr);
                        if(this.nodeID == "4001")
                        {
                            if (stepRe.Step == 0)
                            {
                                this.db1ValsToSnd[0] = 1;
                                logRecorder.AddDebugLog(nodeName, string.Format("托盘{0}分流：空筐", this.rfidUID));
                                
                            }
                            else if (stepRe.Step >= 4)
                            {
                                this.db1ValsToSnd[0] = 3;
                                logRecorder.AddDebugLog(nodeName, string.Format("托盘{0}分流，MES工步：{1},已经完成一次注液第二步",this.rfidUID,stepRe.Step));
                            }
                            else
                            {
                                this.db1ValsToSnd[0] = 2;
                                logRecorder.AddDebugLog(nodeName, string.Format("托盘{0}分流，MES工步：{1},已经完成一次注液第一步", this.rfidUID, stepRe.Step));
                            }
                        }
                        #region 二次注液前分流点
                      
                        else if(this.nodeID == "4002")
                        {
                            if (palletStat == 0)
                            {
                                this.db1ValsToSnd[0] = 1;
                                logRecorder.AddDebugLog(nodeName, string.Format("托盘{0}分流：空筐", this.rfidUID));
                            }
                            else
                            {
                                if (!MesAcc.UnbindTrayCell(this.rfidUID))
                                {
                                    this.db1ValsToSnd[0] = 3;
                                    logStr = string.Format("托盘{0}MES解绑失败", this.rfidUID);
                                    logRecorder.AddDebugLog(nodeName, logStr);
                                }
                                else
                                {
                                    this.db1ValsToSnd[0] = 2;
                                    logStr = string.Format("托盘{0}分流：满筐,调用MES解绑成功", this.rfidUID);
                                    logRecorder.AddDebugLog(nodeName, logStr);
                                }
                                /*
                                if(stepRe.Step<6)
                                {
                                    this.db1ValsToSnd[0] = 3;
                                    logStr = string.Format("托盘{0}工序流程错误，化成未完成，MES工步{1}", this.rfidUID,stepRe.Step);
                                    logRecorder.AddDebugLog(nodeName, logStr);
                                }
                                else
                                {
                                    //调用MES接口解绑
                                    if (!MesAcc.UnbindTrayCell(this.rfidUID))
                                    {
                                        this.db1ValsToSnd[0] = 3;
                                        logStr = string.Format("托盘{0}MES解绑失败", this.rfidUID);
                                        logRecorder.AddDebugLog(nodeName, logStr);
                                    }
                                    else
                                    {
                                        this.db1ValsToSnd[0] = 2;
                                        logStr = string.Format("托盘{0}MES解绑成功", this.rfidUID);
                                        logRecorder.AddDebugLog(nodeName, string.Format("托盘{0}分流：满筐", this.rfidUID));
                                    }
                                    

                                }*/
                            }
                        }
                        #endregion
                        else
                        {
                            if(stepRe.Step<20)
                            {
                                currentTaskDescribe = "OCV2";
                                this.db1ValsToSnd[0] = 1; //OCV2
                                logStr = string.Format("{0},MES工步：{1}，分流信息：OCV2分拣后料框",this.rfidUID,stepRe.Step);
                                logRecorder.AddDebugLog(nodeName, logStr);
                            }
                            else
                            {
                                currentTaskDescribe = "OCV4";
                                this.db1ValsToSnd[0] = 2; //OCV4
                                logStr = string.Format("{0},MES工步：{1}，分流信息：OCV4分拣后料框", this.rfidUID, stepRe.Step);
                                logRecorder.AddDebugLog(nodeName, logStr);
                            }
                            #region 本地工艺流程查询
                            /*
                            string curMesProcessID = this.productOnlineBll.GetProcessIDOfPallet(this.rfidUID);
                            if (string.IsNullOrWhiteSpace(curMesProcessID))
                            {
                                currentTaskDescribe = "OCV2";
                                this.db1ValsToSnd[0] = 1; //OCV2
                                logStr = "分流信息：OCV2分拣后料框";
                            }
                            else
                            {
                                int curSeq = SysCfg.SysCfgModel.stepSeqs.IndexOf(curMesProcessID);
                                int ocv2Seq = SysCfg.SysCfgModel.stepSeqs.IndexOf("PS-70");
                                if (curSeq <= ocv2Seq)
                                {
                                    currentTaskDescribe = "OCV2";
                                    this.db1ValsToSnd[0] = 1; //OCV2
                                    logStr = "分流信息：OCV2分拣后料框";
                                }
                                else
                                {
                                    currentTaskDescribe = "OCV4";
                                    this.db1ValsToSnd[0] = 2; //OCV4
                                    logStr = "分流信息：OCV4分拣后料框";
                                }
                            }*/
                            #endregion
                            
                        }
                       
                        this.currentTaskPhase++;
                        break;
                    }
                case 2:
                    {
                        currentTaskDescribe = "流程完成";
                        break;
                    }
            }
            return true;
        }
    }
}
