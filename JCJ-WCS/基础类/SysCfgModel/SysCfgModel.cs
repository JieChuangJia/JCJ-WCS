using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml;
using System.Xml.Linq;
namespace SysCfg
{
    public static class SysCfgModel
    {
        public static XElement rootXE = null;
       // private static string CfgFile = "";
        public const string SysCfgFileName = "SysCfgFile";
        public static string cfgFilefullPath = "";
        public static string xmlCfgStr = "";
        public static AsrsStepCfg asrsStepCfg = null;
        public static bool PlcCommSynMode = true;//同步通信模式
        public static bool UnbindMode = true;//ASRS动作调试模式，没有数据绑定
        public static bool RfidSimMode = false;
        public static int ZhuyeMode = 0; //注液模式，1：一次注液分一步模式，2:一次注液分两步模式
        public static bool MesOnlineMode = false; //MES联机模式
        public static int TrayChannelMax = 40;
        //工艺参数配置字典，从数据库获取
        public static IDictionary<string, MesDBAccess.Model.ProcessStepModel> stepParamDic = new Dictionary<string, MesDBAccess.Model.ProcessStepModel>();
        public static List<int> stepSeqs = new List<int>();
        public static bool SimMode { get; set; }
       // public static bool TestMode = true;
        public static float AsrsStoreTime { get; set; } //默认统一静置时间
        public static List<string> AsrsHouseList = new List<string>();
        public static List<string> AsrsAreaList = new List<string>();
        public static Dictionary<string, string> CheckoutBatchDic { get; set; }
        public static Dictionary<string, string> CheckinBatchDic { get; set; }
     //   public static bool HouseEnabledA { get; set; }
     //   public static bool HouseEnabledB { get; set; }
        public static bool SaveCfg(ref string reStr)
        {
            try
            {
               
                rootXE.Save(cfgFilefullPath);
                
                return true;
            }
            catch (Exception ex)
            {
                reStr = ex.ToString();
                return false;
            }
        }
        public static bool LoadCfg(ref XElement root,ref string reStr)
        {
            try
            {
                CheckinBatchDic = new Dictionary<string, string>();
                CheckoutBatchDic = new Dictionary<string, string>();
                stepSeqs.Clear();
                /*
                CtlDBAccess.BLL.SysCfgBll sysCfgBll = new CtlDBAccess.BLL.SysCfgBll();
                CtlDBAccess.Model.SysCfgDBModel cfgModel = sysCfgBll.GetModel(SysCfg.SysCfgModel.SysCfgFileName);
              
                //SysCfgModel.CfgFile = cfgFile;
                if (cfgModel == null)
                {
                    reStr = "系统配置不存在";
                    return false;
                }
                 xmlCfgStr = cfgModel.cfgFile;
                */
                if(!File.Exists(cfgFilefullPath))
                {
                    reStr = "配置文件不存在";
                    return false;
                }
                xmlCfgStr = File.ReadAllText(cfgFilefullPath);
                root = XElement.Parse(xmlCfgStr);
                if(root == null)
                {
                    reStr = "系统配置不存在!";
                    return false;
                }

                rootXE = root;
                
               

                XElement asrsStoreCfgXE = root.Element("sysSet").Element("AsrsStoreCfg");
                
                IEnumerable<XElement> houseArea = root.Element("sysSet").Element("HouseAreaColorSet").Elements("HouseArea");
                foreach (XElement element in houseArea)
                {
                    string areaName = element.Attribute("areaName").Value;
                    if(!AsrsAreaList.Contains(areaName))
                    {
                        AsrsAreaList.Add(areaName);
                    }
                }
                XElement runModeXE = root.Element("sysSet").Element("RunMode");
                string simStr = runModeXE.Attribute("sim").Value.ToString().ToUpper();
                if (simStr == "TRUE")
                {
                    SimMode = true;
                }
                else
                {
                    SimMode = false;
                }
                if (runModeXE.Attribute("RfidSimMode") != null)
                {
                    string strRfidSim = runModeXE.Attribute("RfidSimMode").Value.ToString().ToUpper();
                    if(strRfidSim == "TRUE")
                    {
                        RfidSimMode = true;
                    }
                    else
                    {
                        RfidSimMode = false;
                    }
                }
                if(runModeXE.Attribute("UnBindedMode")!= null)
                {
                    string unbindedStr = runModeXE.Attribute("UnBindedMode").Value.ToString().ToUpper();
                    if (unbindedStr == "TRUE")
                    {
                        UnbindMode = true;
                    }
                    else
                    {
                        UnbindMode = false;
                    }
                }
               //if(root.Element("sysSet").Element("AsrsBatchSet") != null && 
               //    root.Element("sysSet").Element("AsrsBatchSet").Element("CheckInBatch") != null)
               //{
                   
               //}
                //XElement asrsBatchCfgXE = root.Element("sysSet").Element("AsrsBatchCfg");
                //CheckinBatchDic["A1库房"] = asrsBatchCfgXE.Attribute("HouseACheckin").Value.ToString();
                //CheckinBatchDic["B1库房"] = asrsBatchCfgXE.Attribute("HouseBCheckin").Value.ToString();
                //CheckinBatchDic["C1库房"] = asrsBatchCfgXE.Attribute("HouseC1Checkin").Value.ToString();
                //CheckinBatchDic["C2库房"] = asrsBatchCfgXE.Attribute("HouseC2Checkin").Value.ToString(); ;

                //CheckoutBatchDic["A1库房"] = asrsBatchCfgXE.Attribute("HouseACheckout").Value.ToString();
                //CheckoutBatchDic["B1库房"] = asrsBatchCfgXE.Attribute("HouseBCheckout").Value.ToString();
                //CheckoutBatchDic["C1库房"] = asrsBatchCfgXE.Attribute("HouseC1Checkout").Value.ToString();
                //CheckoutBatchDic["C2库房"] = asrsBatchCfgXE.Attribute("HouseC2Checkout").Value.ToString();
              
                return true;
            }
            catch (Exception ex)
            {
                reStr = ex.ToString();
                return false;
            }
           
        }
        public static bool SaveCfg(string xmlCfg,ref string reStr)
        {
            XElement root = XElement.Parse(xmlCfg);
            if (root == null)
            {
                return false;
            }
            rootXE = root;
            xmlCfgStr = xmlCfg;
            rootXE.Save(cfgFilefullPath);
            return true;
            //CtlDBAccess.BLL.SysCfgBll sysCfgBll = new CtlDBAccess.BLL.SysCfgBll();
            //CtlDBAccess.Model.SysCfgDBModel cfgModel = sysCfgBll.GetModel(SysCfg.SysCfgModel.SysCfgFileName);
           
            //  string xmlCfgFile = SysCfgModel.CfgFile;// System.AppDomain.CurrentDomain.BaseDirectory + @"data/NBssCfg.xml";
            //if (cfgModel == null)
            //{
            //    reStr = "系统配置不存在!";
            //    return false;
            //}
            //cfgModel.cfgFile = xmlCfg;
            //return sysCfgBll.Update(cfgModel);

        }
    }
    public enum EnumProductCata
    {
        电芯,
        模组,
        PACK,
        其它
    }
    /// <summary>
    /// 任务执行状态（控制任务、管理任务）
    /// </summary>
    public enum EnumTaskStatus
    {
        待执行,
        执行中,
        已完成,
        超时, //任务在规定时间内未完成
        错误, //任务发生错误，不可能再继续执行了，必须人工清理掉
        任务撤销
    }
   
    public enum EnumAsrsTaskType
    {
        空 = 0,
        产品入库 = 1,
        空筐入库 = 2,
        产品出库 = 3,
        空筐出库 = 4,
        移库 = 5,

        RGV上料=11,
        RGV下料=12,
        RGV上下料=13,
        输送机送出=21
    }
}
