using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using System.Windows.Forms;
using CtlMonitorInterface;
using MonitorViews;
using DevInterface;
using DevAccess;
namespace CtlManage
{
    public class CommDevManage : ICommDevMonitor
    {
        #region 通信对象
        private List<IPlcRW> plcRWs = null; //plc读写对象列表
        private List<IrfidRW> rfidRWs = null;//rfid读写对象列表
        private List<IBarcodeRW> barcodeRWList = null;
        private delegate void DlgtPopupWelcome();

        private WelcomeForm welcomeDlg = new WelcomeForm();

        #endregion
        public CommDevManage()
        {

        }
        #region 公有接口
        public bool InitDev(string xmlDevCfg)
        {
            throw new NotImplementedException();
        }
        public bool ParseCommdev(XElement commDevRoot,ref string reStr)
        {
            try
            {
                //1 PLC
                plcRWs = new List<IPlcRW>();
                XElement plcRoot = commDevRoot.Element("PLCCfg");
                IEnumerable<XElement> plcXES = plcRoot.Elements("PLC");
                int plcSum = plcXES.Count();
                foreach (XElement plcXE in plcXES)
                {
                    string connStr = plcXE.Value.ToString();
                    int db1Len = 100, db2Len = 100;
                    db1Len = int.Parse(plcXE.Attribute("db1Len").Value.ToString());
                    db2Len = int.Parse(plcXE.Attribute("db2Len").Value.ToString());
                    int plcID = int.Parse(plcXE.Attribute("id").Value.ToString());
                    EnumPlcCata plcCata = EnumPlcCata.FX5U;
                    if (plcXE.Attribute("cata") != null)
                    {
                        string strPlcCata = plcXE.Attribute("cata").Value.ToString();
                        plcCata = (EnumPlcCata)Enum.Parse(typeof(EnumPlcCata), strPlcCata);

                    }
                    if(SysCfg.SysCfgModel.SimMode)
                    {
                        PlcRWSim plcRW = new PlcRWSim();
                        plcRW.PlcID = plcID;
                        plcRW.PlcRole = plcXE.Attribute("role").Value.ToString();
                        plcRWs.Add(plcRW);
                    }
                    else
                    {
                        PLCRwMCPro plcRW = new PLCRwMCPro(plcCata, db1Len, db2Len);
                        plcRW.PlcRole = plcXE.Attribute("role").Value.ToString();
                        // PLCRwMCPro2 plcRW = new PLCRwMCPro2(db1Len, db2Len);
                        plcRW.ConnStr = plcXE.Value.ToString();
                        plcRW.PlcID = plcID;
                        plcRWs.Add(plcRW);
                    }
                    
                }

                //2 rfid
                XElement rfidRootXE = commDevRoot.Element("RfidCfg");
                IEnumerable<XElement> rfidXES = rfidRootXE.Elements("RFID");
                this.rfidRWs = new List<IrfidRW>();
                foreach (XElement rfidXE in rfidXES)
                {
                    byte id = byte.Parse(rfidXE.Attribute("id").Value.ToString());
                    string addr = rfidXE.Attribute("CommAddr").Value.ToString();
                    string[] strAddrArray = addr.Split(new string[] { ":" }, StringSplitOptions.RemoveEmptyEntries);
                    string ip = strAddrArray[0];
                    ushort port = ushort.Parse(strAddrArray[1]);
                    //WqwlRfidRW rfidRW = new WqwlRfidRW(EnumTag.TagEPCC1G2, id, ip, port);
                    WqRfidUdp rfidRW = new WqRfidUdp(EnumTag.TagEPCC1G2, id, ip, port, (uint)(9000 + id));

                   
                    //SygoleHFReaderIF.HFReaderIF readerIF = new SygoleHFReaderIF.HFReaderIF();
                    //SgrfidRW rfidRW = new SgrfidRW(id);
                    //rfidRW.ReaderIF = readerIF;
                    //rfidRW.ReaderIF.ComPort = commPort;
                    rfidRWs.Add(rfidRW);
                }

                //3 条码枪
                XElement barcoderRootXE = commDevRoot.Element("BarScannerCfg");
                IEnumerable<XElement> barcodes = barcoderRootXE.Elements("BarScanner");
                barcodeRWList = new List<IBarcodeRW>();
                foreach (XElement barcodeXE in barcodes)
                {
                    byte id = byte.Parse(barcodeXE.Attribute("id").Value.ToString());
                    string commPort = barcodeXE.Attribute("CommAddr").Value.ToString();
                    if(SysCfg.SysCfgModel.SimMode)
                    {
                        BarcodeRWSim barSim = new BarcodeRWSim(id);
                        barSim.Role = barcodeXE.Attribute("role").Value.ToString();
                        barcodeRWList.Add(barSim);
                    }
                    else
                    {
                        BarcodeRWHonevor barcodeReader = new BarcodeRWHonevor(id);
                        barcodeReader.TriggerMode = EnumTriggerMode.程序命令触发;
                        barcodeReader.Role = barcodeXE.Attribute("role").Value.ToString();
                        //System.IO.Ports.SerialPort comPort = new System.IO.Ports.SerialPort(commPort);
                        //comPort.BaudRate = 115200;
                        //comPort.DataBits = 8;
                        //comPort.StopBits = System.IO.Ports.StopBits.One;
                        //comPort.Parity = System.IO.Ports.Parity.None;
                        barcodeReader.ComPortObj.PortName = commPort;
                        barcodeReader.ComPortObj.BaudRate = 115200;
                        barcodeReader.ComPortObj.DataBits = 8;
                        barcodeReader.ComPortObj.StopBits = System.IO.Ports.StopBits.One;
                        barcodeReader.ComPortObj.Parity = System.IO.Ports.Parity.None;
                        barcodeRWList.Add(barcodeReader);
                    }
                    
                }
                return true;
            }
            catch (Exception ex)
            {
                reStr = "通信设备配置解析失败,发生系统异常：" + ex.ToString();
                return false;
                
            }
        }

        public void CommDevConnect()
        {
            try
            {
                if(!SysCfg.SysCfgModel.SimMode)
                {
                    WelcomePopup();
                   
                    AsyCommDevConnect();
                    WelcomeClose();
                }
              
            }
            catch (Exception ex)
            {
                PopupMes(ex.ToString());
            }

           
            
            
        }
        public void AsyCommDevConnect()
        {
            

            if (SysCfg.SysCfgModel.SimMode)
            {
                return;
            }
            for (int i = 0; i < this.barcodeRWList.Count(); i++)
            {
                string logStr = "";
                string reStr = "";
                if (!this.barcodeRWList[i].StartMonitor(ref reStr))
                {
                    logStr = string.Format("{0} 号条码枪端口打开失败,{1}", this.barcodeRWList[i].Role, reStr);
                    Console.WriteLine(logStr);
                }
                else
                {
                    logStr = string.Format("{0} 号条码枪端口打开成功！", this.barcodeRWList[i].Role);
                    Console.WriteLine(logStr);
                }
                WelcomeAddStartinfo(logStr);
            }
            for (int i = 0; i < plcRWs.Count(); i++)
            {
                string reStr = "";
                string logStr = "";
                if (!plcRWs[i].ConnectPLC(ref reStr))
                {
                    logStr = string.Format("{0} PLC连接失败,{1}", plcRWs[i].PlcRole, reStr);
                    Console.WriteLine(logStr);
                    WelcomeAddStartinfo(logStr);
                    //  logRecorder.AddLog(new LogModel(objectName, logStr, EnumLoglevel.错误));
                }
                else
                {
                    logStr = string.Format("{0} PLC连接成功", plcRWs[i].PlcRole);
                    Console.WriteLine(logStr);
                    WelcomeAddStartinfo(logStr);
                    // logRecorder.AddLog(new LogModel(objectName, logStr, EnumLoglevel.提示));
                }
            }

        }
        public IPlcRW GetPlcByID(int plcID)
        {
            foreach (IPlcRW plcRW in plcRWs)
            {
                if (plcID == plcRW.PlcID)
                {
                    return plcRW;
                }
            }
            return null;
        }
        public IrfidRW GetRfidByID(int rfidID)
        {
            foreach (IrfidRW rfidRW in rfidRWs)
            {
                if (rfidID == rfidRW.ReaderID)
                {
                    return rfidRW;
                }
            }
            return null;
        }
        public IBarcodeRW GetBarcoderRWByID(int barcodReaderID)
        {
            foreach (IBarcodeRW barcodeReader in barcodeRWList)
            {
                if (barcodeReader != null && barcodeReader.ReaderID == barcodReaderID)
                {
                    return barcodeReader;
                }
            }
            return null;
        }
        public IDictionary<string,DevConnStat> GetPLCConnStatDic()
        {
            IDictionary<string, DevConnStat> devConnDic = new Dictionary<string, DevConnStat>();
            foreach(IPlcRW plcRW in plcRWs)
            {
                string devID = "PLC:" + plcRW.PlcID;
                DevConnStat devStat = new DevConnStat();
                devStat.devID = devID;
                devStat.devName = "PLC:"+plcRW.PlcRole;
                if(plcRW.IsConnect)
                {
                    devStat.connStat = 1;
                }
                else
                {
                    devStat.connStat = 2;
                }
                devConnDic[devID] = devStat;
            }
            return devConnDic;
        }
        #endregion
        public void PopupMes(string strMes)
        {
            MessageBox.Show(strMes);
        }
        public void WelcomeAddStartinfo(string info)
        {
            this.welcomeDlg.AddDispContent(info);
        }
        public void WelcomeDispCurinfo(string info)
        {

            this.welcomeDlg.DispCurrentInfo(info);
        }
        public void AsynWelcomePopup()
        {

            this.welcomeDlg.ShowDialog();
        }
        public void WelcomePopup()
        {

            DlgtPopupWelcome dlgt = new DlgtPopupWelcome(AsynWelcomePopup);
            dlgt.BeginInvoke(null, null);

        }
        public void WelcomeClose()
        {
            this.welcomeDlg.CloseDisp();
            this.welcomeDlg = null;
        }
        
    }
}
