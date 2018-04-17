using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using System.Data;
using DevAccess;
using DevInterface;
using FlowCtlBaseModel;
namespace AsrsUtil
{
    public class MainPresenter
    {
        public static bool SimMode = false;
        IMainView view = null;
        public IPlcRW plcRW = null;
        private ThreadBaseModel runThread = null;
        private StackerModel stacker = new StackerModel();
        public StackerModel Stacker { get { return stacker; } }
        public MainPresenter(IMainView view)
        {
            this.view = view;
            runThread = new ThreadBaseModel("任务线程1");
            runThread.LoopInterval = 200;
            runThread.SetThreadRoutine(TaskRunLoop);
            runThread.TaskInit();
        }
        public bool Init()
        {
            try
            {
              
                string xmlCfgFile = AppDomain.CurrentDomain.BaseDirectory + @"\data\AsrsUtil.xml";
                XElement rootXE = XElement.Load(xmlCfgFile);
                if(rootXE == null)
                {
                    return false;
                }
                XElement sysSetXE = rootXE.Element("sysSet");
                XElement runModeXE = sysSetXE.Element("RunMode");
                if(runModeXE.Attribute("sim").Value.ToString().ToUpper() == "TRUE")
                {
                    SimMode = true;
                }
                else
                {
                    SimMode = false;
                }
               


                stacker = new StackerModel();
                XElement stackerXE = rootXE.Element("StackerCfg");
                string reStr = "";
                if(!stacker.BuildCfg(stackerXE,ref reStr))
                {
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
        }
        public bool ConnPlc(string ip, int port, EnumPlcCata plcCata,EnumNetProto proto)
        {
            try
            {
                if(SimMode)
                {
                    plcRW = new PlcRWSim();
                }
                else
                {
                    PLCRwMCPro plcRwMC = new PLCRwMCPro(plcCata, 20, 20);
                    plcRW = plcRwMC;
                    
                    plcRwMC.PlcCata = plcCata;

                    plcRwMC.ConnStr = ip + ":" + port.ToString();
                }
                stacker.PlcRW = plcRW;
                string reStr="";
                if(plcRW.ConnectPLC( ref reStr))
                {
                    Console.WriteLine("PLC连接成功！");
                    return true;
                }
                else
                {
                    Console.WriteLine("PLC连接失败！");
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
        }
        public bool Start()
        {
            string reStr = "";
            if(!runThread.TaskStart(ref reStr))
            {
                Console.WriteLine("系统流程启动失败：" + reStr);
                return false;
            }
            else
            {
                Console.WriteLine("系统流程启动!");
                return true;
            }
        }
        public void Pause()
        {
            runThread.TaskPause();
            
        }
        public void Exit()
        {
            string reStr = "";
            runThread.TaskExit(ref reStr);
        }
        public void GetRunningInfo(ref DataTable db1Dt, ref DataTable db2Dt, ref string taskDetail)
        {
            db1Dt = stacker.GetDB1DataDetail();
            db2Dt = stacker.GetDB2DataDetail();
            taskDetail = stacker.GetRunningTaskDetail();
        
        }
        public bool Reset()
        {
            return this.stacker.DevReset();
        }

        private void TaskRunLoop()
        {
          //  Console.WriteLine("hello");
            string reStr = "";
            if(!stacker.ReadDB2(ref reStr))
            {
                return;
            }
            if(!stacker.ExeBusiness(ref reStr))
            {
                return;
            }
            if (!stacker.NodeCmdCommit(false, ref reStr))
            {
                Console.WriteLine("提交命令数据失败");
            }
        }
    }
}
