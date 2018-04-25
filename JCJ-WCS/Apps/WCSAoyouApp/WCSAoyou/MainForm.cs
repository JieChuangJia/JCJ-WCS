using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using System.Configuration;
using System.ServiceModel;
using System.ServiceModel.Description;
using LogInterface;
using ModuleCrossPnP;
using LicenceManager;
using LogManage;
using ProductRecordView;
using AsrsControl;

using MonitorViews;
using ConfigManage;
namespace WCSAoyou
{
    public partial class MainForm : Form, ILogDisp, IParentModule, ILicenseNotify,IMainView
    {
        #region 数据
        private string appTitle = "锂电WCS系统-捷创嘉智能物流";
        private string version = "系统版本:1.0.0  2018-4-8";
        private int roleID = 3;
        private string userName = "操作员";
        const int CLOSE_SIZE = 10;
        int iconWidth = 16;
        int iconHeight = 16;

        //控制模块对象
        MainPresenter presenter = null;
        private WMSSvcSim wmsSvcSim = new WMSSvcSim();
        //子窗体相关
        private LicenseMonitor licenseMonitor = null;
        private List<BaseChildView> childViews = null;
        private List<string> childList = null;
        private LogView logView = null;
       // private RecordView recordView = null;
        private ProduceTraceView palletTraceView = null;
        private AsrsCtlView asrsCtlView = null;
       
        private CtlNodeMonitorView nodeMonitorView = null;
        private ConfiManageView configView = null;
        #endregion
       
        public MainForm()
        {
            this.IsMdiContainer = true;
            InitializeComponent();
           
            this.menuStrip1.BackColor = Color.FromArgb(0x2D, 0x5B, 0x86);
            this.panel2.BackColor = Color.FromArgb(0x2D, 0x5B, 0x86);
            this.menuStrip1.ForeColor = Color.FromArgb(255, 255, 255);
          //  this.label5.ForeColor = Color.FromArgb(0x2D, 0x5B, 0x86);
            this.Text = appTitle;
        }
        #region 接口实现
        public string CurUsername { get { return this.userName; } }
        public int RoleID { get { return this.roleID; } }
        private delegate void DelegateDispLog(LogModel log);//委托，显示日志
        public void DispLog(LogModel log)
        {
            if (this.richTextBoxLog.InvokeRequired)
            {
                DelegateDispLog delegateLog = new DelegateDispLog(DispLog);
                this.Invoke(delegateLog, new object[] { log });
            }
            else
            {
                if (this.richTextBoxLog.Text.Count() > 10000)
                {
                    this.richTextBoxLog.Text = "";
                }
                this.richTextBoxLog.Text += (string.Format("[{0:yyyy-MM-dd HH:mm:ss.fff}]{1},{2}", log.LogTime, log.LogSource, log.LogContent) + "\r\n");
            }

        }
        public void AttachModuleView(System.Windows.Forms.Form childView)
        {
            TabPage tabPage = null;
            if (this.childList.Contains(childView.Text))
            {
                tabPage = this.MainTabControl.TabPages[childView.Text];
                this.MainTabControl.SelectedTab = tabPage;
                return;
            }

            this.MainTabControl.TabPages.Add(childView.Text, childView.Text);
            tabPage = this.MainTabControl.TabPages[childView.Text];
            tabPage.Controls.Clear();
            this.MainTabControl.SelectedTab = tabPage;
            childView.MdiParent = this;

            tabPage.Controls.Add(childView);
            this.childList.Add(childView.Text);
            childView.Dock = DockStyle.Fill;
            childView.Size = this.panelCenterview.Size;
            childView.Show();

        }
        public void RemoveModuleView(System.Windows.Forms.Form childView)
        {
            TabPage tabPage = null;
            if (this.childList.Contains(childView.Text))
            {
                tabPage = this.MainTabControl.TabPages[childView.Text];
                this.childList.Remove(childView.Text);
                this.MainTabControl.TabPages.Remove(tabPage);
                
            }
        }
        #endregion
        #region ILicenseNotify接口实现
        public void ShowWarninfo(string info)
        {
            LogModel log = new LogModel("其它", info, EnumLoglevel.警告);
            logView.GetLogrecorder().AddLog(log);
        }
        public void LicenseInvalid(string warnInfo)
        {
          //  nodeMonitorView.AbortApp();
            LogModel log = new LogModel("其它", warnInfo, EnumLoglevel.警告);
            logView.GetLogrecorder().AddLog(log);
        }
        public void LicenseReValid(string noteInfo)
        {


            LogModel log = new LogModel("其它", noteInfo, EnumLoglevel.提示);
            logView.GetLogrecorder().AddLog(log);
        }
        #endregion
        #region UI事件
        private void PublicMonitorSvc()
        {
            Uri _baseAddress = new Uri("http://localhost:8801/JCJ/WESMonitorSvc/");
            EndpointAddress _Address = new EndpointAddress(_baseAddress);
            BasicHttpBinding _Binding = new BasicHttpBinding();
            ContractDescription _Contract = ContractDescription.GetContract(typeof(CtlMonitorInterface.IWESMonitorSvc));
            ServiceEndpoint endpoint = new ServiceEndpoint(_Contract, _Binding, _Address);
          

            //添加终结点ABC
            ServiceHost host = new ServiceHost(presenter, _baseAddress);
            host.Description.Endpoints.Add(endpoint);
            //启用元数据交换
            ServiceMetadataBehavior meta = new ServiceMetadataBehavior();

            meta.HttpGetEnabled = true;
            host.Description.Behaviors.Add(meta);
            host.Open();
            Console.WriteLine("WES 系统监控状态服务启动!");
        }
        private void MainForm_Load(object sender, EventArgs e)
        {
            try
            {
                this.WindowState = FormWindowState.Maximized;
                this.btnPause.Enabled = false;
                this.labelVersion.Text = this.version;
                #region 数据库配置
                string dbSrc = ConfigurationManager.AppSettings["DBSource"];
                //CtlDBAccess.DBUtility.PubConstant.ConnectionString = string.Format(@"{0}Initial Catalog=ACEcams;User ID=sa;Password=123456;", dbSrc);
                string dbConn1 = string.Format(@"{0}Initial Catalog=AoyouWCS;User ID=AoyouWcsSA;Password=jcj8421;", dbSrc);
                CtlDBAccess.DBUtility.DbHelperSQL.SetConnstr(dbConn1);
                string dbConn2 = string.Format(@"{0}Initial Catalog=AoyouLocalMes;User ID=AoyouWcsSA;Password=jcj8421;", dbSrc);
                MesDBAccess.DBUtility.DbHelperSQL.SetConnstr(dbConn2);
              
                #endregion

                presenter = new MainPresenter(this);
                presenter.WmsSvc = this.wmsSvcSim;
                childList = new List<string>();
                childViews = new List<BaseChildView>();

                Console.SetOut(new TextBoxWriter(this.richTextBoxLog));

                // corePresenter = new CtlcorePresenter();

                this.labelUser.Text = "当前用户：" + this.userName;
                this.MainTabControl.DrawMode = TabDrawMode.OwnerDrawFixed;
                this.MainTabControl.Padding = new System.Drawing.Point(CLOSE_SIZE, CLOSE_SIZE);
                this.MainTabControl.DrawItem += new DrawItemEventHandler(this.tabControlMain_DrawItem);
                this.MainTabControl.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tabControlMain_MouseDown);
                if (!presenter.SysCtlInit())
                {
                    return;
                }
             
                if (!LoadModules())//加载子模块
                {
                    MessageBox.Show("子模块加载错误");

                    return;
                }
                this.configView.BatteryCfgView.dlgtSndPalletCfg = presenter.SendDevlinePalletCfg;
                this.configView.BatteryCfgView.dlgtGetPalletCfg = presenter.ReadPalletCfgFromPlc;
                List<string> logSrcs = new List<string>();
                logSrcs.AddRange(presenter.GetLogSrcList());
               
                logView.SetLogsrcList(logSrcs);

                presenter.SetLogRecorder(logView.GetLogrecorder());
                AllocateModuleInface();
                nodeMonitorView.Init();
                nodeMonitorView.dlgtWMSTaskCommit = wmsSvcSim.WMSTaskCommit;
                this.nodeMonitorView.InitDevDic(presenter.DevCommManager.GetPLCConnStatDic());
                this.nodeMonitorView.DevMonitorView.devCommMonitor = presenter.DevCommManager;
                //string[] taskNodeIDS = new string[] {"1001","1002","1003","1004","1005","1006","6001","6002","6003" };
                IDictionary<string, string> taskNodeMap = new Dictionary<string, string>();
               
              //  foreach(string nodeID in taskNodeIDS)
                foreach (FlowCtlBaseModel.CtlNodeBaseModel node in presenter.CtlNodeManager.MonitorNodeList)
                {
                    //FlowCtlBaseModel.CtlNodeBaseModel node = presenter.CtlNodeManager.GetNodeByID(nodeID);
                    if(node != null)
                    {
                        taskNodeMap[node.NodeID] = node.NodeName;
                    }
                }
                asrsCtlView.SetTaskNodeNames(taskNodeMap);

                string licenseFile = AppDomain.CurrentDomain.BaseDirectory + @"\NBSSLicense.lic";
                this.licenseMonitor = new LicenseMonitor(this, 60000, licenseFile, "zzkeyFT1");
                if (!this.licenseMonitor.StartMonitor())
                {
                    throw new Exception("license 监控失败");
                }
                string reStr = "";
                if (!this.licenseMonitor.IslicenseValid(ref reStr))
                {
                    MessageBox.Show(reStr);
                    return;
                }
             //   presenter.LoadAsrsExtSvc();

                //宿主状态监控服务
                PublicMonitorSvc();
                Console.WriteLine("系统初始化完成!");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                
            }
           
        }
        private void panelCenterview_SizeChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.panelCenterview.Controls.Count < 1)
                {
                    return;
                }
                Control child = this.panelCenterview.Controls[0];
                if (child != null)
                {
                    child.Size = this.panelCenterview.Size;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                // throw;
            }


        }
        private void richTextBoxLog_TextChanged(object sender, EventArgs e)
        {
            this.richTextBoxLog.SelectionStart = this.richTextBoxLog.Text.Length; //Set the current caret position at the end
            this.richTextBoxLog.ScrollToCaret();
        }
        private void tabControlMain_DrawItem(object sender, DrawItemEventArgs e)
        {
            try
            {

                Image icon = this.imageList1.Images[0];
                Brush biaocolor = Brushes.Transparent; //选项卡的背景色
                Graphics g = e.Graphics;
                Rectangle r = MainTabControl.GetTabRect(e.Index);
                if (e.Index == this.MainTabControl.SelectedIndex)    //当前选中的Tab页，设置不同的样式以示选中
                {
                    Brush selected_color = Brushes.Wheat; //选中的项的背景色
                    g.FillRectangle(selected_color, r); //改变选项卡标签的背景色
                    string title = MainTabControl.TabPages[e.Index].Text + "  ";

                    g.DrawString(title, this.Font, new SolidBrush(Color.Black), new PointF(r.X, r.Y + 6));//PointF选项卡标题的位置

                    r.Offset(r.Width - iconWidth - 3, 2);
                    g.DrawImage(icon, new Point(r.X + 2, r.Y + 2));//选项卡上的图标的位置 fntTab = new System.Drawing.Font(e.Font, FontStyle.Bold);
                }
                else//非选中的
                {
                    g.FillRectangle(biaocolor, r); //改变选项卡标签的背景色
                    string title = this.MainTabControl.TabPages[e.Index].Text + "  ";

                    g.DrawString(title, this.Font, new SolidBrush(Color.Black), new PointF(r.X, r.Y + 6));//PointF选项卡标题的位置
                    r.Offset(r.Width - iconWidth - 3, 2);
                    g.DrawImage(icon, new Point(r.X + 2, r.Y + 2));//选项卡上的图标的位置
                }
                //Rectangle myTabRect = this.MainTabControl.GetTabRect(e.Index);

                ////先添加TabPage属性   
                //e.Graphics.DrawString(this.MainTabControl.TabPages[e.Index].Text
                //, this.Font, SystemBrushes.ControlText, myTabRect.X + 2, myTabRect.Y + 2);

                //myTabRect.Offset(myTabRect.Width - (CLOSE_SIZE + 3), 2);
                //myTabRect.Width = CLOSE_SIZE;
                //myTabRect.Height = CLOSE_SIZE;
                ////再画一个矩形框
                //using (Pen p = new Pen(Color.Red))
                //{

                //    //  e.Graphics.DrawRectangle(p, myTabRect);
                //}


                ////画关闭符号
                //using (Pen objpen = new Pen(Color.DarkGray, 1.0f))
                //{
                //    //"\"线
                //    Point p1 = new Point(myTabRect.X + 3, myTabRect.Y + 3);
                //    Point p2 = new Point(myTabRect.X + myTabRect.Width - 3, myTabRect.Y + myTabRect.Height - 3);
                //    e.Graphics.DrawLine(objpen, p1, p2);

                //    //"/"线
                //    Point p3 = new Point(myTabRect.X + 3, myTabRect.Y + myTabRect.Height - 3);
                //    Point p4 = new Point(myTabRect.X + myTabRect.Width - 3, myTabRect.Y + 3);
                //    e.Graphics.DrawLine(objpen, p3, p4);
                //}

                //e.Graphics.Dispose();
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.ToString());
            }
        }
        private void tabControlMain_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Point p = e.Location;
                Rectangle r = MainTabControl.GetTabRect(this.MainTabControl.SelectedIndex);
                r.Offset(r.Width - iconWidth, 4);
                r.Width = iconWidth;
                r.Height = iconHeight;
                if (this.MainTabControl.SelectedTab.Text == nodeMonitorView.Text)
                {
                    return;
                }
                string tabText = this.MainTabControl.SelectedTab.Text;

                if (r.Contains(p))
                {
                    this.childList.Remove(tabText);
                    this.MainTabControl.TabPages.RemoveAt(this.MainTabControl.SelectedIndex);
                }

                //int x = e.X, y = e.Y;

                ////计算关闭区域   
                //Rectangle myTabRect = this.MainTabControl.GetTabRect(this.MainTabControl.SelectedIndex);

                //myTabRect.Offset(myTabRect.Width - (CLOSE_SIZE + 3), 2);
                //myTabRect.Width = CLOSE_SIZE;
                //myTabRect.Height = CLOSE_SIZE;

                ////如果鼠标在区域内就关闭选项卡   
                //bool isClose = x > myTabRect.X && x < myTabRect.Right
                // && y > myTabRect.Y && y < myTabRect.Bottom;

                //if (isClose == true)
                //{
                //    if (this.MainTabControl.SelectedTab.Text == nodeMonitorView.Text)
                //    {
                //        return;
                //    }
                //    string tabText = this.MainTabControl.SelectedTab.Text;
                //    this.childList.Remove(tabText);
                //    this.MainTabControl.TabPages.Remove(this.MainTabControl.SelectedTab);

                //}
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            this.richTextBoxLog.Text = string.Empty;
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {

        }
        private void btnStart_Click(object sender, EventArgs e)
        {
            OnStart();
        }

        private void btnPause_Click(object sender, EventArgs e)
        {
            OnStop();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            OnExit();
        }
        #endregion
         private void OnStart()
        {
            
            presenter.StartRun();
            nodeMonitorView.StartMonitor();
            asrsCtlView.StartMonitor();
            this.btnPause.Enabled = true;
            this.btnStart.Enabled = false;
            this.label6.Text = "系统已经启动！";
        }
        private void OnStop()
         {
             presenter.PauseRun();
             this.nodeMonitorView.StopMonitor();
             this.btnPause.Enabled = false;
             this.btnStart.Enabled = true;
             this.label6.Text = "系统已经暂停！";
         }
        public bool OnExit()
        {
            if (0 == PoupAskmes("确定要退出系统？"))
            {
                return false;
            }
            // if (presenter.NeedSafeClosing())
            {
                ClosingWaitDlg dlg = new ClosingWaitDlg();
                if (DialogResult.Cancel == dlg.ShowDialog())
                {
                    return false;
                }
            }
            OnStop();
            this.presenter.ExitSystem();
            System.Environment.Exit(0);
            return true;
        }
        private bool LoadModules()
        {
            logView = new LogView("日志");
            childViews.Add(logView);
            logView.SetParent(this);
            logView.RegisterMenus(this.menuStrip1, "日志查询");
            logView.SetLogDispInterface(this);
            presenter.logRecorder = logView.GetLogrecorder();


            configView = new ConfiManageView();
            childViews.Add(configView);
            configView.SetParent(this);
            configView.RegisterMenus(this.menuStrip1, "配置管理");
            configView.SetLoginterface(logView.GetLogrecorder());

            palletTraceView = new ProduceTraceView("托盘追溯");
            childViews.Add(palletTraceView);
            palletTraceView.SetParent(this);
            palletTraceView.RegisterMenus(this.menuStrip1, "托盘追溯");
            palletTraceView.SetLoginterface(logView.GetLogrecorder());

            asrsCtlView = new AsrsCtlView("立库控制");
            childViews.Add(asrsCtlView);
            asrsCtlView.SetParent(this);
            asrsCtlView.RegisterMenus(this.menuStrip1, "立库控制");
            asrsCtlView.SetLoginterface(logView.GetLogrecorder());
            asrsCtlView.SetAsrsPresenter(presenter.AsrsPresenter);
            asrsCtlView.Init();

            nodeMonitorView = new CtlNodeMonitorView("流程监控");
            childViews.Add(nodeMonitorView);
            nodeMonitorView.SetParent(this);
            nodeMonitorView.RegisterMenus(this.menuStrip1, "流程监控");
            nodeMonitorView.SetLoginterface(logView.GetLogrecorder());
            nodeMonitorView.SetAsrsMonitors(asrsCtlView.AsrsMonitors);

            

            AsrsInterface.IAsrsManageToCtl asrsResManage = wmsSvcSim;
            AsrsInterface.IAsrsCtlToManage asrsCtl = presenter.GetAsrsCtlInterfaceObj();
            asrsCtlView.SetAsrsResManage(asrsResManage);

            AttachModuleView(nodeMonitorView);
            foreach (BaseChildView childView in childViews)
            {
                childView.ChangeRoleID(this.roleID);
            }
            presenter.SetAsrsResManage(asrsResManage);

            string[] nodeEnableCfgIDS = new string[] { "1001", "1002", "1003", "1004","1005","1006" };
            List<FlowCtlBaseModel.CtlNodeBaseModel> nodeEnableCfgs = new List<FlowCtlBaseModel.CtlNodeBaseModel>();
            foreach (string nodeID in nodeEnableCfgIDS)
            {
                nodeEnableCfgs.Add(presenter.CtlNodeManager.GetNodeByID(nodeID));
            }
            configView.SetCfgNodes(nodeEnableCfgs);

            return true;
        }  
        private void AllocateModuleInface()
        {
            this.nodeMonitorView.NodeMonitor = presenter.CtlNodeManager;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="info"></param>
        /// <returns>1：确定,其它：取消</returns>
        protected int PoupAskmes(string info)
        {
            if (DialogResult.OK == MessageBox.Show(info, "提示", MessageBoxButtons.OKCancel))
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
        private void toolStripButton1_Click_1(object sender, EventArgs e)
        {
            this.richTextBoxLog.Text = "";
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!OnExit())
            {
                e.Cancel = true;
            }
        }

        private void 切换用户ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OnChangeRoleID();
        }
        private void OnChangeRoleID()
        {
            try
            {
                NbssECAMS.LoginView2 logView2 = new NbssECAMS.LoginView2();
                if (DialogResult.OK == logView2.ShowDialog())
                {
                    string tempUserName = "";
                    int tempRoleID = logView2.GetLoginRole(ref tempUserName);
                    if (tempRoleID < 1)
                    {
                        return;
                    }
                    this.roleID = tempRoleID;
                    this.userName = tempUserName;
                    this.labelUser.Text = "当前用户：" + this.userName;
                    foreach (BaseChildView childView in childViews)
                    {
                        childView.ChangeRoleID(this.roleID);
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}