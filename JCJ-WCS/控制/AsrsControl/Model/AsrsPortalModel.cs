using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using FlowCtlBaseModel;
using TransDevModel;
using DevInterface;
namespace AsrsControl
{
    /// <summary>
    /// 立库出入口控制模型
    /// </summary>
    public class AsrsPortalModel : NodeTransStation
    {
       
      //  private IrfidRW rfidRW = null;
      //  public IrfidRW RfidRW { get { return rfidRW; } set { rfidRW = value; } }
       
      //  private string palletWaitting = ""; //在读卡位置待处理的托盘号
        private object portBufLock = new object();
        private int portCata = 1; //1：入口，2：出口，3：出入口共用
        private int portSeq = 1;//编号，从1开始
        private SysCfg.EnumAsrsTaskType bindedTaskInput = SysCfg.EnumAsrsTaskType.空;
        private SysCfg.EnumAsrsTaskType bindedTaskOutput = SysCfg.EnumAsrsTaskType.空;
     //   private bool inputPort = true;
    //    public bool InputPort { get { return inputPort; } set { inputPort = value; } }
        private AsrsCtlModel asrsCtlModel = null;
        public int PortCata { get { return portCata; } set { portCata = value; } }
        public int PortSeq { get { return portSeq; } }
        
       // public string PalletWaiting { get { return palletWaitting; } set { palletWaitting = value; } }
        public SysCfg.EnumAsrsTaskType BindedTaskInput { get { return bindedTaskInput; } set { bindedTaskInput = value; } }
        public SysCfg.EnumAsrsTaskType BindedTaskOutput { get { return bindedTaskOutput; } set { bindedTaskOutput = value; } }
        public AsrsCtlModel AsrsCtl { get { return asrsCtlModel; } }
        /// <summary>
        /// 入口缓存托盘最大数量
        /// </summary>
        public int PortinBufCapacity { get; set; }
        public bool EmptyPalletInputEnabled { get; set; }
        public bool BarcodeScanRequire { get; set; }
        public AsrsPortalModel(AsrsCtlModel asrsCtl)
        {
            PortinBufCapacity = 1; //默认最大容量是1
            this.asrsCtlModel = asrsCtl;
            EmptyPalletInputEnabled = false;
            BarcodeScanRequire = false;
        }
        public override bool ExeBusiness(ref string reStr)
        {
            if(!base.ExeBusiness(ref reStr))
            {
                return false;
            }

            return true ;
        }
        public override bool DevStatusRestore()
        {
          
            MesDBAccess.BLL.AsrsPortBufferBll bufBll = new MesDBAccess.BLL.AsrsPortBufferBll();
            MesDBAccess.Model.AsrsPortBufferModel buf = bufBll.GetModel(this.nodeID);
            this.palletBuffer = new List<string>();
            if(buf != null)
            {
                if(!string.IsNullOrWhiteSpace(buf.palletBuffers))
                {
                    string[] strArray = buf.palletBuffers.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
                    if(strArray != null && strArray.Count()>0)
                    {
                        this.palletBuffer.AddRange(strArray);
                    }
                }
                
            }
            if (!base.DevStatusRestore())
            {
                return false;
            }
            return true;
        }
        public override bool BuildCfg(System.Xml.Linq.XElement xe, ref string reStr)
        {
            if(!base.BuildCfg(xe, ref reStr))
            {
                return false;
            }
            XElement selfDataXE = xe.Element("SelfDatainfo");
            this.portCata = int.Parse(selfDataXE.Element("PortType").Value.ToString());
            
            
            if (selfDataXE.Attribute("portSeq")!=null)
            {
                this.portSeq = int.Parse(selfDataXE.Attribute("portSeq").Value.ToString());
            }
            if (selfDataXE.Attribute("capacity")!= null)
            {
                this.PortinBufCapacity = int.Parse(selfDataXE.Attribute("capacity").Value.ToString());
            }
            if (selfDataXE.Attribute("emptyPalletCheckIn") != null)
            {
                if (selfDataXE.Attribute("emptyPalletCheckIn").Value.ToString().ToUpper() == "TRUE")
                {
                    this.EmptyPalletInputEnabled = true;
                }
            }
            
            if (selfDataXE.Attribute("bindedTask") !=null)
            {
                string[] strArray=selfDataXE.Attribute("bindedTask").Value.ToString().Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
                if(strArray != null)
                {
                    if(strArray.Count()>0)
                    {
                        if(this.portCata == 1)
                        {
                            this.bindedTaskInput = (SysCfg.EnumAsrsTaskType)Enum.Parse(typeof(SysCfg.EnumAsrsTaskType), strArray[0]);
                        }
                        else if(this.portCata == 2)
                        {
                            this.bindedTaskOutput = (SysCfg.EnumAsrsTaskType)Enum.Parse(typeof(SysCfg.EnumAsrsTaskType), strArray[0]);
                        }
                        else if(this.portCata == 3)
                        {
                            this.bindedTaskInput = (SysCfg.EnumAsrsTaskType)Enum.Parse(typeof(SysCfg.EnumAsrsTaskType), strArray[0]);
                            if(strArray.Count()>1)
                            {
                                this.bindedTaskOutput = (SysCfg.EnumAsrsTaskType)Enum.Parse(typeof(SysCfg.EnumAsrsTaskType), strArray[1]);
                            }
                        }
                    }
                }
            }
            if (selfDataXE.Attribute("barcodeScanRequire") != null)
            {
               if(selfDataXE.Attribute("barcodeScanRequire").Value.ToString().ToUpper()=="TRUE")
               {
                   BarcodeScanRequire = true;
               }
            }
            return true;
        }
        public override bool IsPathOpened(string palletID,ref string reStr)
        {
           if(!base.IsPathOpened(palletID,ref reStr))
           {
               return false;
           }
           lock(portBufLock)
           {
               //先判断入口实际信号
               bool portCrowd = true;
               for (int i = 0; i < PortinBufCapacity; i++)
               {
                   if(db2Vals[i] ==1)
                   {
                       portCrowd = false;
                       break;
                   }
               }
               if(portCrowd) //入口拥堵
               {
                   return false;
               }
               //再判断数据
               if (this.palletBuffer.Count() >= PortinBufCapacity)
               {
                   reStr = "缓存已满";
                   return false;
               }
              if(PortinBufCapacity>1) //只有入口最大允许缓存数量大于1时才考虑库区，批次
              {
                  if (this.palletBuffer.Count() > 0)
                  {
                      //1 判断是否同一个库区
                      string lastPalletID = this.palletBuffer[0];
                      int lastStep = 0;
                      if (!MesAcc.GetStep(lastPalletID, out lastStep, ref reStr))
                      {
                          return false;
                      }
                      int step = 0;
                      if (!MesAcc.GetStep(palletID, out step, ref reStr))
                      {
                          return false;
                      }
                      string areaLast = asrsCtlModel.GetAreaToCheckin(lastPalletID,lastStep).ToString();// AsrsModel.EnumLogicArea.注液高温区.ToString();
                      // areaLast=SysCfg.SysCfgModel.asrsStepCfg.AsrsAreaSwitch(lastStep);
                      string areaCur = asrsCtlModel.GetAreaToCheckin(palletID,step).ToString();//AsrsModel.EnumLogicArea.注液高温区.ToString(); ;
                      //     areaCur=SysCfg.SysCfgModel.asrsStepCfg.AsrsAreaSwitch(step);

                      if (areaLast != areaCur)
                      {
                          reStr = string.Format("托盘{0}待进入的立库分区{1},跟当前缓存托盘待进入的分区{2}不同", palletID, areaCur, areaLast);
                          return false;
                      }
                      //2 是否同批
                      string batchLast = "";
                      string batch = "";
                      if (!MesAcc.GetTrayCellLotNO(palletID, out batch, ref reStr))
                      {
                          return false;
                      }
                      if (!MesAcc.GetTrayCellLotNO(lastPalletID, out batchLast, ref reStr))
                      {
                          return false;
                      }
                      if (batchLast == batch)
                      {
                          return true;
                      }
                      else
                      {
                          reStr = string.Format("托盘{0} 批次{1},与入口缓存的托盘{2} 批次{3}不同", palletID, batch, lastPalletID, batchLast);
                          return false;
                      }
                  }
              }
            
               return true;
           }
           
          
        }
        public override int PathValidWeight(string palletID, ref string reStr)
        {
            int step =0;
            int weight = 0;
            if (!MesAcc.GetStep(palletID, out step, ref reStr))
            {
                return -1;
            }
            if(palletBuffer.Count()>0)
            {
                weight = 100000;
            }
            /*
            string batchName="";
            if(this.palletBuffer.Count()>0)
            {
                string curPalletID=this.palletBuffer[0];
                MesDBAccess.BLL.palletBll palletDBAcc = new MesDBAccess.BLL.palletBll();
                MesDBAccess.Model.palletModel palletM = palletDBAcc.GetModel(curPalletID);
                string curBatch="";
                if(MesAcc.GetTrayCellLotNO(curPalletID,out curBatch,ref reStr))
                {
                    if(MesAcc.GetTrayCellLotNO(palletID,out batchName,ref reStr))
                    {
                        if(curBatch == batchName)
                        {
                            weight=100000;
                        }
                    }
                }
            }
           */
            string storeAreaZone = "注液高温区"; 
            storeAreaZone = asrsCtlModel.GetAreaToCheckin(palletID,step);//(AsrsModel.EnumLogicArea)Enum.Parse(typeof(AsrsModel.EnumLogicArea), SysCfg.SysCfgModel.asrsStepCfg.AsrsAreaSwitch(step)); //AsrsModel.EnumLogicArea.注液高温区; //此处需要根据步号判断
            
            int cellEmptCounts = 0;
            if(!asrsCtlModel.AsrsResManage.GetHouseAreaLeftGs(asrsCtlModel.HouseName, storeAreaZone.ToString(), ref cellEmptCounts, reStr))
            {
                reStr = string.Format("查询{0}库房，{1}剩余货位失败,{2}", asrsCtlModel.HouseName, storeAreaZone.ToString(), reStr);
                return -1;
            }
            weight += cellEmptCounts;
            return weight;
        }
        public bool ClearBufPallets(ref string reStr)
        {
            try
            {
                lock(portBufLock)
                {
                    this.palletBuffer.Clear();
                    MesDBAccess.BLL.AsrsPortBufferBll bufBll = new MesDBAccess.BLL.AsrsPortBufferBll();
                    MesDBAccess.Model.AsrsPortBufferModel buf = bufBll.GetModel(this.nodeID);
                    if (buf != null)
                    {
                        buf.palletBuffers = "";
                        bufBll.Update(buf);
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
        public void PushPalletID(string palletID)
        {
            lock(portBufLock)
            {
                if (this.palletBuffer.Contains(palletID))
                {
                    return;
                }
                if (this.palletBuffer.Count() >= PortinBufCapacity)
                {
                    this.palletBuffer.RemoveAt(0);
                }
                this.palletBuffer.Add(palletID);
                string strPallets = "";
                for (int i = 0; i < this.palletBuffer.Count(); i++)
                {
                    strPallets += this.palletBuffer[i];
                    if (palletBuffer.Count() > 1 && i < this.palletBuffer.Count() - 1)
                    {
                        strPallets += ",";
                    }
                }
                MesDBAccess.BLL.AsrsPortBufferBll bufBll = new MesDBAccess.BLL.AsrsPortBufferBll();
                MesDBAccess.Model.AsrsPortBufferModel buf = bufBll.GetModel(this.nodeID);
                if (buf == null)
                {
                    buf = new MesDBAccess.Model.AsrsPortBufferModel();
                    buf.houseName = this.AsrsCtl.HouseName;
                    buf.nodeID = this.nodeID;
                    buf.palletBuffers = strPallets;
                    bufBll.Add(buf);
                }
                else
                {
                    buf.palletBuffers = strPallets;
                    bufBll.Update(buf);
                }
            }
        }
        public bool AsrsInputEnabled(ref SysCfg.EnumAsrsTaskType asrsTaskType)
        {
            lock(portBufLock)
            {
                if (this.portCata == 2)
                {
                    return false;
                }
                if (this.db1ValsToSnd[0] == 2)
                {
                    return false;
                }
     
                if (asrsTaskType == SysCfg.EnumAsrsTaskType.产品入库)
                {
                    if (this.PortinBufCapacity > 1)
                    {
                        //缓存满，并且入口有料，并且手动强制入库
                        if (this.db2Vals[this.PortinBufCapacity] == 2)
                        {
                            if ((this.palletBuffer.Count() > 0) && (this.db2Vals[0]==2 || this.db2Vals[1]==2) )
                            {
                                return true;
                            }
                            else
                            {
                                return false;
                            }
                        }
                        else if (this.palletBuffer.Count() >= this.PortinBufCapacity) 
                        {
                            for (int j = 0; j < Math.Min(PalletBuffer.Count(), PortinBufCapacity); j++)
                            {
                                if (this.Db2Vals[j] != 2)
                                {
                                    return false;

                                }
                            }
                            return true;
                        }
                        else
                        {
                            return false;
                        }

                    }
                    else
                    {
                        if (this.palletBuffer.Count() > 0 && this.db2Vals[0] == 2)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
                else
                {
                    if (this.PortinBufCapacity > 1)
                    {
                        if ((this.db2Vals[this.PortinBufCapacity] == 2))
                        {
                             return true;
                        }
                        else
                        {
                            for (int j = 0; j < PortinBufCapacity; j++)
                            {
                                if (this.Db2Vals[j] != 2)
                                {
                                    return false;
                                }
                            }
                            return true;
                        }
                        
                    }
                    else
                    {
                        if(this.db2Vals[0] == 2)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }

                }
                
            }
           
        }

    }
}
