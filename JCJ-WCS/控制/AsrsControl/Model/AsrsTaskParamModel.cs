using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AsrsModel;
namespace AsrsControl
{
    public class AsrsTaskParamModel
    {
        private string strTaskParam = "";
        private CellCoordModel cellPos1 = null;
        private CellCoordModel cellPos2 = null;
        private int inputPort = 0;
        private int outputPort = 0;
        private string[] inputCellGoods = null;
        private List<Int16> reserveParams = new List<Int16>();
        public CellCoordModel CellPos1 { get { return cellPos1; } set { cellPos1 = value; } }
        public CellCoordModel CellPos2 { get { return cellPos2; } set { cellPos2=value; } }
        public int InputPort { get { return inputPort; } set { inputPort = value; } }
        public int OutputPort { get { return outputPort; } set { outputPort = value; } }
        public string[] InputCellGoods { get { return inputCellGoods; } set { inputCellGoods = value; } }
        public List<Int16> ReserveParams { get { return reserveParams; } set { reserveParams = value; } }
        public AsrsTaskParamModel()
        {
            
        }
        public bool ParseParam(CtlDBAccess.Model.ControlTaskModel ctlTask,ref string reStr)
        {
            try
            {
                SysCfg.EnumAsrsTaskType taskType = (SysCfg.EnumAsrsTaskType)ctlTask.TaskType;
                if(ctlTask.DeviceCata != "堆垛机")
                {
                    reStr = "设备类型不支持，要求为 '堆垛机'类型,实际："+ctlTask.DeviceCata;
                    return false;
                }
                if (taskType == SysCfg.EnumAsrsTaskType.产品入库 || taskType == SysCfg.EnumAsrsTaskType.空筐入库)
                {
                    inputPort = int.Parse(ctlTask.StDevice);
                     string[] cellPos = ctlTask.EndDeviceParam.Split(new string[] { "-" }, StringSplitOptions.RemoveEmptyEntries);
                    if (cellPos == null || cellPos.Count() < 3)
                    {
                        reStr = "出入库参数解析错误";
                        return false;
                    }
                    short row = short.Parse(cellPos[0]);
                    short col = short.Parse(cellPos[1]);
                    short layer = short.Parse(cellPos[2]);
                    this.cellPos1 = new CellCoordModel(row, col, layer);
                }
                else if (taskType == SysCfg.EnumAsrsTaskType.产品出库 || taskType == SysCfg.EnumAsrsTaskType.空筐出库)
                {
                    outputPort = int.Parse(ctlTask.EndDevice);
                    string[] cellPos = ctlTask.StDeviceParam.Split(new string[] { "-" }, StringSplitOptions.RemoveEmptyEntries);
                    if (cellPos == null || cellPos.Count() < 3)
                    {
                        reStr = "出入库参数解析错误";
                        return false;
                    }
                    short row = short.Parse(cellPos[0]);
                    short col = short.Parse(cellPos[1]);
                    short layer = short.Parse(cellPos[2]);
                    this.cellPos1 = new CellCoordModel(row, col, layer);
                }
                else if(taskType== SysCfg.EnumAsrsTaskType.移库)
                {
                    string[] cellPos = ctlTask.StDeviceParam.Split(new string[] { "-" }, StringSplitOptions.RemoveEmptyEntries);
                    if (cellPos == null || cellPos.Count() < 3)
                    {
                        reStr = "出入库参数解析错误";
                        return false;
                    }
                    short row = short.Parse(cellPos[0]);
                    short col = short.Parse(cellPos[1]);
                    short layer = short.Parse(cellPos[2]);
                    this.cellPos1 = new CellCoordModel(row, col, layer);

                    cellPos = ctlTask.EndDeviceParam.Split(new string[] { "-" }, StringSplitOptions.RemoveEmptyEntries);
                    if (cellPos == null || cellPos.Count() < 3)
                    {
                        reStr = "出入库参数解析错误";
                        return false;
                    }
                    row = short.Parse(cellPos[0]);
                    col = short.Parse(cellPos[1]);
                    layer = short.Parse(cellPos[2]);
                    this.cellPos2 = new CellCoordModel(row, col, layer);
                }
                else
                {
                     reStr = "任务参数解析失败,不识别的任务类型："+taskType.ToString();
                    return false;
                }
                this.inputCellGoods = ctlTask.PalletCode.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
                return true;
            }
            catch (Exception ex)
            {
                reStr = ex.ToString();
                return false;
            }
        }
        public bool ParseParam(SysCfg.EnumAsrsTaskType taskType,string strParam,ref string reStr)
        {
            try
            {
                //任务参数格式 ""
                this.strTaskParam = strParam;
                string[] taskParamArray = this.strTaskParam.Split(new string[] { ";" }, StringSplitOptions.None);
                if (taskParamArray == null || taskParamArray.Count() < 3)
                {
                    reStr="出入库参数解析错误";
                    return false;
                }
                inputPort = int.Parse(taskParamArray[0]);
                outputPort = int.Parse(taskParamArray[1]);
                string[] cellPos = taskParamArray[2].Split(new string[] { "-" }, StringSplitOptions.RemoveEmptyEntries);
                if (cellPos == null || cellPos.Count() < 3)
                {
                    reStr = "出入库参数解析错误";
                    return false;
                }
                
                short row = short.Parse(cellPos[0]);
                short col = short.Parse(cellPos[1]);
                short layer = short.Parse(cellPos[2]);
                this.cellPos1 = new CellCoordModel(row,col,layer);
                switch(taskType)
                {
                    case SysCfg.EnumAsrsTaskType.产品入库:
                        {
                            //产品入库
                          //  this.inputPort = 1;
                            if(taskParamArray.Count()>3)
                            {
                                string strGoods = taskParamArray[3];
                                this.inputCellGoods = strGoods.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
                            }
                            
                            break;
                        }
                    case SysCfg.EnumAsrsTaskType.空筐入库:
                        {
                            //空筐入库
                            if (taskParamArray.Count() > 3)
                            {
                                string strGoods = taskParamArray[3];
                                this.inputCellGoods = strGoods.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
                            }
                           
                            break;
                        }
                    case SysCfg.EnumAsrsTaskType.产品出库:
                        {
                            //产品出库

                            if (taskParamArray.Count() > 3)
                            {
                                string strGoods = taskParamArray[3];
                                this.inputCellGoods = strGoods.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
                            }
                            if (taskParamArray.Count() > 4)
                            {
                                string[] strReserveParams = taskParamArray[4].Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
                                foreach (string strP in strReserveParams)
                                {
                                    Int16 reserveParam = Int16.Parse(strP);
                                    reserveParams.Add(reserveParam);
                                }
                            }
                            break;
                        }
                    case SysCfg.EnumAsrsTaskType.空筐出库:
                        {
                            //空筐出库
                            if (taskParamArray.Count() > 3)
                            {
                                string strGoods = taskParamArray[3];
                                this.inputCellGoods = strGoods.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
                            }
                            break;

                        }
                    case SysCfg.EnumAsrsTaskType.移库:
                        {
                            
                            string[] cellTargetPos = taskParamArray[3].Split(new string[] { "-" }, StringSplitOptions.RemoveEmptyEntries);
                            if (cellTargetPos == null || cellTargetPos.Count() < 3)
                            {
                                reStr="移库参数解析错误";
                                return false;
                            }
                            row = short.Parse(cellTargetPos[0]);
                            col = short.Parse(cellTargetPos[1]);
                            layer = short.Parse(cellTargetPos[2]);
                            this.cellPos2 = new CellCoordModel(row, col, layer);
                            if (taskParamArray.Count() > 4)
                            {
                                string strGoods = taskParamArray[4];
                                this.inputCellGoods = strGoods.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
                            }
                            break;
                        }
                    default:
                        {
                            reStr = "入库参数错误，不可识别的任务类型：" + taskType.ToString();
                            return false;
                           
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
        public string ConvertoStr(SysCfg.EnumAsrsTaskType taskType)
        {
            StringBuilder strBuild = new StringBuilder();
            strBuild.AppendFormat("{0};{1};", inputPort, outputPort);
            strBuild.AppendFormat("{0}-{1}-{2};", cellPos1.Row, cellPos1.Col, cellPos1.Layer);
            if (taskType == SysCfg.EnumAsrsTaskType.移库)
            {
                strBuild.AppendFormat("{0}-{1}-{2};", cellPos2.Row, cellPos2.Col, cellPos2.Layer);
            }
            if(inputCellGoods != null && inputCellGoods.Count()>0)
            {
                string goodsStr = "";
                foreach(string str in inputCellGoods)
                {
                    goodsStr=goodsStr+str+",";
                }
                if(!string.IsNullOrEmpty(goodsStr))
                {
                    if (goodsStr[goodsStr.Count() - 1] == ',')
                    {
                        goodsStr = goodsStr.Remove(goodsStr.Count() - 1, 1);
                    }
                    strBuild.AppendFormat("{0};",goodsStr);
                }
            }
            if (reserveParams != null && reserveParams.Count() > 0)
            {
                for (int i = 0; i < reserveParams.Count();i++ )
                {
                    strBuild.AppendFormat("{0},", reserveParams[i]);
                }
            }
            return strBuild.ToString();
        }
    }
}
