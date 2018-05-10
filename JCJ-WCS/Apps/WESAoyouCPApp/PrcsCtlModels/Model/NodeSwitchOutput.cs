using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using FlowCtlBaseModel;
using AsrsInterface;
namespace PrcsCtlModelsAoyouCp
{
    public class NodeSwitchOutput : CtlNodeBaseModel
    {
        private short barcodeFailedStat = 1;
        public AsrsInterface.IAsrsManageToCtl AsrsResManage { get; set; }
        public override bool ExeBusiness(ref string reStr)
        {
            if (!devStatusRestore)
            {
                devStatusRestore = DevStatusRestore();
            }
            if (db2Vals[0] == 1)
            {
                db1ValsToSnd[0] = 0;
                currentTaskPhase = 0;
                Array.Clear(this.db1ValsToSnd, 0, this.db1ValsToSnd.Count());
                rfidUID = string.Empty;
                currentTaskDescribe = "等待新的任务";
                //return true;
            }
            if (db2Vals[0] == 2)
            {
                if (currentTaskPhase == 0)
                {
                    currentTaskPhase = 1;
                    currentTaskDescribe = "开始读RFID";
                }
            }
            switch (this.currentTaskPhase)
            {
                case 1:
                    {
                       
                        this.rfidUID = "";
                        if (SysCfg.SysCfgModel.SimMode || SysCfg.SysCfgModel.RfidSimMode)
                        {
                            this.rfidUID = this.SimRfidUID;
                        }
                        else
                        {
                            this.rfidUID = this.barcodeRW.ReadBarcode().Trim();

                        }
                        if (string.IsNullOrWhiteSpace(this.rfidUID))
                        {
                            if (this.db1ValsToSnd[0] != barcodeFailedStat)
                            {
                                logRecorder.AddDebugLog(nodeName, "读料框条码失败");
                            }
                            this.db1ValsToSnd[0] = barcodeFailedStat; 
                            currentTaskDescribe = "读料条码失败，没有读到条码";
                            break;
                        }
                        if(this.nodeID=="4008" || this.nodeID=="4009")
                        {
                            /*if(this.rfidUID.Length!= 9) //检测条码长度
                            {
                                if (this.db1ValsToSnd[0] != barcodeFailedStat)
                                {
                                    currentTaskDescribe = "读料条败长度错误，实际长度:" + this.rfidUID.Length.ToString();
                                    logRecorder.AddDebugLog(nodeName, "读料条败长度错误，实际长度:" + this.rfidUID.Length.ToString());
                                }
                                this.db1ValsToSnd[0] = barcodeFailedStat;
                                break;
                            }*/
                            //检测是否跟库里有重码
                            string[] houseNames= new string[]{"A1库房","A2库房"};
                            foreach(string houseName in houseNames)
                            {
                                string cellIn = AsrsResManage.IsProductCodeInStore(houseName, this.rfidUID, ref reStr);
                                if(!string.IsNullOrWhiteSpace(cellIn))
                                {
                                    if (this.db1ValsToSnd[0] != 3)
                                    {
                                        currentTaskDescribe = string.Format("条码异常，条码{0}已经在库房{1},库位{2}",this.rfidUID.Length.ToString(),houseName,cellIn);
                                        logRecorder.AddDebugLog(nodeName, currentTaskDescribe);
                                    }
                                    this.db1ValsToSnd[0] = 3;
                                    return true;
                                }
                            }
                          
                        }
                        logRecorder.AddDebugLog(this.nodeName, "读到托盘号:" + this.rfidUID);
                        this.currentTaskPhase++;
                        break;
                    }
                case 2:
                    {
                        //分流
                        Int16 re = 0;
                        if(this.nodeID=="4002")
                        {
                            if(!Switch4002(this.rfidUID,ref re,ref reStr))
                            {
                                break;
                            }
                           
                        }
                        else if(this.nodeID=="4003")
                        {
                            if(!Switch4003(this.rfidUID,ref re,ref reStr))
                            {
                                break;
                            }
                           
                        }
                        else if(this.nodeID=="4007")
                        {
                            if (!Switch4007(this.rfidUID, ref re, ref reStr))
                            {
                                break;
                            }
                        }
                        else if(this.nodeID=="4008")
                        {
                            if (!Process4008(this.rfidUID, ref re, ref reStr))
                            {
                                break;
                            }
                            
                        }
                        else if(this.nodeID=="4009")
                        {
                            if (!Process4009(this.rfidUID, ref re, ref reStr))
                            {
                                break;
                            }
                        }
                        else if (this.nodeID=="4010" || this.nodeID == "4011")
                        {
                            if (!Process4010(this.rfidUID, ref re, ref reStr))
                            {
                                break;
                            }
                        }
                        else if (this.nodeID == "4012")
                        {
                            if (!Process4012(this.rfidUID, ref re, ref reStr))
                            {
                                break;
                            }
                        }
                        else
                        {
                            break;
                        }
                        this.db1ValsToSnd[0] = re;
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
        private bool Switch4002(string palletID,ref Int16 switchRe,ref string reStr)
        {
            try
            {
                switchRe = 0;
                int step = 0;
                string desc = "";
                if(!MesAcc.GetStep(palletID,out step,ref reStr))
                {
                    return false;
                }
                if(step<3)
                {
                    switchRe = 2;
                    desc = "满筐进加压化成或空筐回流进注液";
                }
                else
                {
                    switchRe = 3;
                    desc = "满筐进二封";
                }
                string logStr = string.Format("{0}分流结果:{1},{2}", palletID, switchRe,desc);
                logRecorder.AddDebugLog(nodeName, logStr);
                AddProduceRecord(this.rfidUID, logStr);
                return true;
            }
            catch (Exception ex)
            {
                reStr = ex.ToString();
                return false;
               
            }
           
        }
        private bool Switch4003(string palletID, ref Int16 switchRe, ref string reStr)
        {
            try
            {
                switchRe = 0;
                switchRe = 0;
                int step = 0;
                if (!MesAcc.GetStep(palletID, out step, ref reStr))
                {
                    return false;
                }
                string desc = "";
                if(step==2)
                {
                    switchRe = 3;
                    desc = "满筐进加压化成";
                }
                else
                {
                    switchRe = 2;
                    desc = "空筐去注液";
                }
                string logStr = string.Format("{0} {1}分流结果:{2},{3}", this.nodeName,this.rfidUID, switchRe,desc);
                logRecorder.AddDebugLog(nodeName, logStr);
                AddProduceRecord(palletID, logStr);
                return true;
            }
            catch (Exception ex)
            {
                reStr = ex.ToString();
                return false;

            }
        }
        private bool Switch4007(string palletID, ref Int16 switchRe, ref string reStr)
        {
            try
            {
                switchRe = 0;
                switchRe = 0;
                int step = 0;
                if (!MesAcc.GetStep(palletID, out step, ref reStr))
                {
                    return false;
                }
                string desc = "";
                if(step<=8)
                {
                    switchRe = 2;
                    desc = "分流去OCV1";
                }
                else
                {
                    switchRe = 3;
                    desc = "分流去OCV2";
                }
                string logStr = string.Format("{0} {1}分流结果:{2},{3}", this.nodeName,this.rfidUID, switchRe,desc);
                logRecorder.AddDebugLog(nodeName, logStr);
                AddProduceRecord(palletID, logStr);
                return true;
            }
            catch (Exception ex)
            {
                reStr = ex.ToString();
                return false;

            }
        }
        /// <summary>
        /// 化成后修改工步为3
        /// </summary>
       
        private bool Process4008(string palletID, ref Int16 re, ref string reStr)
        {
            try
            {
                re = 0;
                int updateStep = 3;
                if(!MesAcc.UpdateStep(updateStep,palletID,ref reStr))
                {
                    return false;
                }
                re = 2;
                string logStr = string.Format("{0},{1}更新工步{2}",this.nodeName, palletID, updateStep);
                logRecorder.AddDebugLog(nodeName,logStr );
                AddProduceRecord(palletID, logStr);
                return true;
            }
            catch (Exception ex)
            {
                reStr = ex.ToString();
                return false;

            }
        }
        //注液后处理，修改工步为1
        private bool Process4009(string palletID, ref Int16 re, ref string reStr)
        {
            try
            {
                //注销
                re = 0;
                int updateStep = 1;
                if (!MesAcc.UpdateStep(updateStep, palletID, ref reStr))
                {
                    return false;
                }
                re = 2;
                string logStr = string.Format("{0},{1}更新工步{2}", this.nodeName, palletID, updateStep);
                logRecorder.AddDebugLog(nodeName, logStr);
                AddProduceRecord(palletID, logStr);
                return true;
            }
            catch (Exception ex)
            {
                reStr = ex.ToString();
                return false;

            }
        }
        private bool Process4010(string palletID, ref Int16 re, ref string reStr)
        {
            if(palletID.Length<12)
            {
               
                reStr = string.Format("{0}条码长度不足",palletID);
                if(this.db1ValsToSnd[1] != 1)
                {
                    logRecorder.AddDebugLog(nodeName, reStr);
                }
                currentTaskDescribe = reStr;
                this.db1ValsToSnd[1] = 1;
                return false;
            }
            string strRe = MesAcc.ParsePalletID(palletID);
            if(string.IsNullOrWhiteSpace(strRe))
            {
                reStr = string.Format("{0}筐码解析失败,电芯型号未配置",palletID);
                if (this.db1ValsToSnd[1] != 2)
                {
                    logRecorder.AddDebugLog(nodeName, reStr);
                }
                currentTaskDescribe = reStr;
                this.db1ValsToSnd[1] = 2;
                return false;
            }
            JObject parseObj = JsonConvert.DeserializeObject(strRe) as JObject;
             short palletCata = 0;
            if ((parseObj == null) || (parseObj["料筐内衬类型"] == null) || (!short.TryParse(parseObj["料筐内衬PLC值"].ToString(),out palletCata)))
            {
                reStr = string.Format("{0}筐码解析失败,电芯内衬型号未配置",palletID);
                if (this.db1ValsToSnd[1] != 2)
                {
                    logRecorder.AddDebugLog(nodeName, reStr);
                }
                this.db1ValsToSnd[1] = 2;
                return false;
             
            }
            re = (short)(1 + palletCata);
            return true;
        }
      
        private bool Process4012(string palletID, ref Int16 re, ref string reStr)
        {
            //1 先解绑
            int step = 0;
            if (!MesAcc.GetStep(this.rfidUID, out step, ref reStr))
            {
                currentTaskDescribe = "查询MES工步失败:" + reStr;
                return false;
            }
            step = 0;
            if (!MesAcc.UpdateStep(step, this.rfidUID, ref reStr))
            {
                currentTaskDescribe = "更新MES工步失败:" + reStr;
                return false;
            }

            //2 再分流
            return Process4010(palletID, ref re, ref reStr);
           
        }
    }
}
