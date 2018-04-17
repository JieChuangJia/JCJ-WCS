using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using System.ServiceModel;
using System.ServiceModel.Description;
using CtlMonitorInterface;
using ModuleCrossPnP;
using LogInterface;
using AsrsInterface;
namespace AsrsControl
{
    public partial class AsrsMonitorView : BaseChildView,IAsrsCtlView
    {

       // private AsrsCtlPresenter presenter = null;
       // private CtlTaskView ctlTaskView = null;
        private PortBufferMonitorView portBufView = null;
        private GsStatisticsView gsStaView = null;
       // private AsrsControl.View.AsrsBatchSettingControl asrsBatchSettingCtl = null;
        private List<UserControl> asrsMonitors = new List<UserControl>();
        public List<UserControl> AsrsMonitors { get { return asrsMonitors; } }
        public IAsrsMonitor AsrsMonitor { get; set; }
       // public AsrsControl.View.AsrsBatchSettingControl AsrsBatchSettingCtl { get { return asrsBatchSettingCtl; } }
        public AsrsMonitorView(string captionText)
            : base(captionText)
        {
            InitializeComponent();
            this.Text = captionText;
           // presenter = new AsrsCtlPresenter(this);
           
           // this.ctlTaskView = new CtlTaskView("控制任务");
            portBufView = new PortBufferMonitorView("入库口缓存信息");
            this.gsStaView = new GsStatisticsView("出入库统计");
        }
        #region 公有接口
        //  public void SetTaskNodeNames(IDictionary<string,string> nodeMap)
        //{
        //    ctlTaskView.SetNodeNames(nodeMap);
        //}
        //public void SetAsrsPresenter(AsrsCtlPresenter presenter)
        //{
        //    this.presenter = presenter;
        //}
        public void SetAsrsResManage(IAsrsManageToCtl asrsResManage)
        {

           // this.ctlTaskView.SetAsrsResManage(asrsResManage);
            this.gsStaView.SetAsrsResManage(asrsResManage);
          //  this.asrsBatchSettingCtl.Init(asrsResManage);
        }
        public void SetAsrsMonitor(IAsrsMonitor asrsMonitor)
        {
            this.AsrsMonitor = asrsMonitor;
            portBufView.AsrsMonitor = asrsMonitor;
        }
        public void Init()
        {
            if(AsrsMonitor != null)
            {
                string[] houseNames = AsrsMonitor.GetAllAsrsHousNames();
                foreach(string houseName in houseNames)
                {
                    AsrsStatUserCtl statUserCtl = new AsrsStatUserCtl();
                    statUserCtl.ID = houseName;
                    asrsMonitors.Add(statUserCtl);
                }
            }
           
            //
           // this.portBufView.AsrsPorts = presenter.AsrsPorts;

   

        }
        public override void ChangeRoleID(int roleID)
        {
            this.portBufView.ChangeRoleID(roleID);
            //this.ctlTaskView.ChangeRoleID(roleID);
        }
        #endregion
        #region IAsrsCtlView接口实现
         public void StartMonitor()
        {
            
            timer1.Start();
        }
        public void StopMonitor()
        {
           
            timer1.Stop();
        }
        #endregion
        #region IModuleAttach接口实现
        //public override List<string> GetLogsrcList()
        //{
        //    //return presenter.GetLogsrcList();
        //}
         public override void RegisterMenus(MenuStrip parentMenu, string rootMenuText)
        {
           
            ToolStripMenuItem rootMenuItem = new ToolStripMenuItem(rootMenuText);//parentMenu.Items.Add("仓储管理");
            //rootMenuItem.Click += LoadMainform_MenuHandler;
            parentMenu.Items.Add(rootMenuItem);
            string[] menuItems = new string[] { "控制任务管理", "入库口缓存管理", "出入库统计" };
            foreach(string menuStr in menuItems)
            {
                ToolStripItem menuItem = rootMenuItem.DropDownItems.Add(menuStr);
                menuItem.Click += LoadView_MenuHandler;
            }
          
        }
        public override void SetParent(/*Control parentContainer, Form parentForm, */IParentModule parentPnP)
        {
            this.parentPNP = parentPnP;
          //  ctlTaskView.SetParent(parentPnP);
            
        }
        public override void SetLoginterface(ILogRecorder logRecorder)
        {
            this.logRecorder = logRecorder;
         //   lineMonitorPresenter.SetLogRecorder(logRecorder);
          //  this.ctlTaskView.SetLoginterface(logRecorder);
            this.portBufView.SetLoginterface(logRecorder);
        }
        #endregion
        #region 私有接口
        private void AsrsCtlView_Load(object sender, EventArgs e)
        {
            //presenter.CtlInit();
        }
        private void LoadView_MenuHandler(object sender, EventArgs e)
        {
            ToolStripItem menuItem = sender as ToolStripItem;
            if (menuItem == null)
            {
                return;
            }
            switch (menuItem.Text)
            {
                //case "控制任务管理":
                //    {
                //        this.parentPNP.AttachModuleView(this.ctlTaskView);
                //        break;
                //    }
                case "入库口缓存管理":
                    {
                        this.parentPNP.AttachModuleView(this.portBufView);
                        break;
                    }
                case "出入库统计":
                    {
                        this.parentPNP.AttachModuleView(this.gsStaView);
                        break;
                    }
                default:
                    break;
            }


        }
        #endregion

        private void RefreshMonitor()
        {
            foreach(UserControl ctl in asrsMonitors)
            {
                AsrsStatUserCtl asrsUserCtl = ctl as AsrsStatUserCtl;
                string houseName = asrsUserCtl.ID;
                int errCode = 0;
                string[] status = null;
                if(!AsrsMonitor.GetAsrsStat(houseName, ref errCode, ref status))
                {
                    Console.WriteLine("获取{0}状态失败", houseName);
                    continue;
                }
                List<StatItem> asrsStatItems = new List<StatItem>();
                if(status.Count()<3)
                {
                    continue;
                }
                StatItem stat = new StatItem();
                stat.statDesc = status[0];
                if (errCode > 0)
                {
                    stat.bkgColor = Color.Red;
                }
                asrsStatItems.Add(stat);
                stat = new StatItem();
                stat.statDesc = status[1];
               
                asrsStatItems.Add(stat);
                stat = new StatItem();
                stat.statDesc = status[2];
                asrsStatItems.Add(stat);
                asrsUserCtl.UpdateAsrsStat(asrsStatItems.ToArray());
            }
           
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            RefreshMonitor();
        }
        
    }
}
