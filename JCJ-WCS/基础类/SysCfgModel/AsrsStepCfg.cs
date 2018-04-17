using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;
namespace SysCfg
{
    public class AsrsPortCfg
    {
        public string houseName = "";
        public int inPortSeq = 0;
        public int outPortSeq = 0;

    }
    public class ProcStep
    {
        public int StepNO = 0;
        public string AsrsArea = "";
        public string Describe = "";
        public Dictionary<string, AsrsPortCfg> asrsPortCfgDic = new Dictionary<string, AsrsPortCfg>();
        public bool LoadCfg(XElement root, ref string reStr)
        {
            try
            {
                StepNO = int.Parse(root.Attribute("stepNO").Value.ToString());
                AsrsArea = root.Attribute("asrsArea").Value.ToString();
                Describe = root.Attribute("describe").Value.ToString();

                IEnumerable<XElement> portCfgXES = root.Elements("AsrsPortCfg");
                if(portCfgXES == null)
                {
                    reStr = "立库流程配置错误，出入口配置没有数据";
                    return false;
                }
                
                foreach(XElement xe in portCfgXES)
                {
                    AsrsPortCfg portCfg = new AsrsPortCfg();
                    portCfg.houseName = xe.Attribute("houseName").Value.ToString();
                    portCfg.inPortSeq = int.Parse(xe.Attribute("inPort").Value.ToString());
                    portCfg.outPortSeq = int.Parse(xe.Attribute("outPort").Value.ToString());
                    asrsPortCfgDic[portCfg.houseName] = portCfg;
                }
                return true;
            }
            catch (Exception ex)
            {
                reStr = ex.ToString();
                return false;
            }
        }
    }
    public class AsrsStepCfg
    {
        public Dictionary<int, ProcStep> asrsStepCfgDic = new Dictionary<int, ProcStep>();
        public List<int> stepList = new List<int>();
        public List<string> areaList = new List<string>();
        public Dictionary<string, float> asrsStoreTimeDic = new Dictionary<string, float>(); 
        public AsrsStepCfg()
        {

        }
        public bool LoadCfg(XElement root,ref string reStr)
        {
            try
            {
                MesDBAccess.BLL.ProcessStepBll processBll = new MesDBAccess.BLL.ProcessStepBll();
                IEnumerable<XElement> stepCfgXES = root.Elements("ProcStep");
                if(stepCfgXES == null)
                {
                    reStr = "立库流程配置错误，没有配置数据";
                    return false;
                }
                foreach(XElement stepXE in stepCfgXES)
                {
                    ProcStep stepCfg = new ProcStep();
                    if(!stepCfg.LoadCfg(stepXE,ref reStr))
                    {
                        return false;
                    }
                    asrsStepCfgDic[stepCfg.StepNO] = stepCfg;
                    MesDBAccess.Model.ProcessStepModel processModel =  processBll.GetModel(stepCfg.StepNO);
                    if(processModel == null)
                    {
                        continue;
                    }
                    float storeHours = float.Parse(processModel.tag1);
                    string strArea = stepCfg.AsrsArea;
                    foreach (string houseName in stepCfg.asrsPortCfgDic.Keys)
                    {
                        string strKey = houseName + "-" + strArea;
                        asrsStoreTimeDic[strKey] = storeHours;
                    }
                }
                stepList.AddRange(asrsStepCfgDic.Keys.ToArray());
                foreach(int step in stepList)
                {
                    areaList.Add(asrsStepCfgDic[step].AsrsArea);
                }
                return true;
            }
            catch (Exception ex)
            {
                reStr = ex.ToString();
                return false;
            }
        }
        public int GetNextStep(int curStep)
        {
            int schIndex = 0;
            bool schOK = false;
            int nextStep = 0;
            if(curStep==0)
            {
                return nextStep;
            }
            for (int i = 0; i < stepList.Count(); i++)
            {
                if (curStep < stepList[i])
                {
                    schIndex = i;
                    schOK = true;
              
                    break;
                }
            }
            if (!schOK)
            {
                schIndex = 0;
            }
            nextStep = stepList[schIndex];
            return nextStep;
        }
        /// <summary>
        /// 下一步应该进入的库区
        /// </summary>
        /// <param name="step"></param>
        /// <returns></returns>
        public string AsrsAreaSwitch(int step)
        {
            string area = "";
            int nextStep=GetNextStep(step);
            if(asrsStepCfgDic.Keys.Contains(nextStep))
            {
                area = asrsStepCfgDic[nextStep].AsrsArea;
            }
            
            return area;
        }
        /// <summary>
        /// 获取当前工步的库区配置
        /// </summary>
        /// <param name="step"></param>
        /// <returns></returns>
        public string GetAsrsArea(int step)
        {
            string area = "";
            if (asrsStepCfgDic.Keys.Contains(step))
            {
                area = asrsStepCfgDic[step].AsrsArea;
            }
            return area;
        }
    }
}
