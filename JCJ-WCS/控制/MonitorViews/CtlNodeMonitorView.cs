using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FlowCtlBaseModel;
using ModuleCrossPnP;
using CtlMonitorInterface;
namespace MonitorViews
{
    public delegate void DelgateCtlEnable(bool enabled);
    public partial class CtlNodeMonitorView:BaseChildView
    {
        private delegate void DlgtRefreshPLCComm();
        private delegate void DelegateRefreshMonitor();
        private delegate void DelegateRefreshRgvStatus(int rgvIndex, bool conn, string mark);
        private delegate void DelegateRefreshCommDevStatus();
        public delegate bool DlgtCommitWMSTask(DataTable dt,ref string reStr);
        #region 数据
        private delegate void DlgtPopupWelcome();
        public DlgtCommitWMSTask dlgtWMSTaskCommit = null;
        private WelcomeForm welcomeDlg = new WelcomeForm();
       // private List<CtlNodeStatus> nodeStatusList = null;
        private DevConnMonitorView devMonitorView = new DevConnMonitorView();
        public DevConnMonitorView DevMonitorView { get { return devMonitorView; } }
         
        #endregion
        #region 公有接口
        public ICtlnodeMonitor NodeMonitor { get; set; }
        public IAsrsMonitor AsrsMonitor { get; set; }
        public CtlNodeMonitorView(string captionText)
            : base(captionText)
        {
            InitializeComponent();
            this.Text = captionText;
            
        }
        public void InitDevDic(IDictionary<string,DevConnStat> devConnDic)
        {
            this.devMonitorView.InitDevDic(devConnDic);
        }
        public  bool Init()
        {
            this.comboBoxDevList.Items.AddRange(NodeMonitor.GetMonitorNodeNames().ToArray());
            this.comboBoxDevList.SelectedIndex = 0;
            DataTable dt = new DataTable("模拟WMS任务列表");
            dt.Columns.AddRange(new DataColumn[]{new DataColumn("管理任务ID"),new DataColumn("任务类型"),new DataColumn("任务状态"),new DataColumn("托盘码"),
            new DataColumn("起始设备号"),new DataColumn("起始设备类型"),new DataColumn("起始设备参数"),new DataColumn("目标设备号"),
            new DataColumn("目标设备类型"),new DataColumn("目标设备参数"),new DataColumn("备注")});

            DataRow dr = dt.Rows.Add();
            dr["管理任务ID"] = System.Guid.NewGuid().ToString();
            dr["任务类型"] = "产品入库";
            dr["任务状态"] = "待执行";
            dr["托盘码"] = "TP2018040412";
            dr["起始设备号"] = "12112";
            dr["起始设备类型"] = "工位";
            dr["起始设备参数"] = "";
            dr["目标设备号"] = "11001";
            dr["目标设备类型"] = "货位";
            dr["目标设备参数"] = "1-1-1";
            dr["备注"] = "";
            this.dataGridView1.DataSource = dt;
            this.dataGridView1.AutoSizeColumnsMode= DataGridViewAutoSizeColumnsMode.AllCells;
            return true;
        }
        
        private delegate void DlgtAbortApp();
        public void AbortApp()
        {
            

        }
     
        public void SetAsrsMonitors(List<UserControl> asrsMonitors)
        {
            this.flowLayoutPanelAsrs.Controls.AddRange(asrsMonitors.ToArray());
        }
        public void SetAsrsBatchSetCtl(UserControl asrsBatchSet)
        {
            this.panel14.Controls.Clear();
            this.panel14.Controls.Add(asrsBatchSet);
            asrsBatchSet.Dock = DockStyle.Fill;
        }
        public void StartMonitor()
        {
            this.timerNodeStatus.Start();
        }
        public void StopMonitor()
        {
            this.timerNodeStatus.Stop();
        }
        #endregion
        #region IMonitorView接口实现
      
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
       
        #endregion
        #region UI事件
        private void ProcessMonitorView_Load(object sender, EventArgs e)
        {
            //仿真模拟
            if (SysCfg.SysCfgModel.SimMode)
            {
                this.comboBoxDB2.Items.Clear();
                for (int i = 0; i < 5; i++)
                {
                    this.comboBoxDB2.Items.Add((i + 1).ToString());
                }
                this.comboBoxDB2.SelectedIndex = 0;

                this.comboBoxBarcodeGun.Items.AddRange(new string[] { "1", "2", "3" });
                this.comboBoxBarcodeGun.SelectedIndex = 0;
            }
            else 
            { 
                //this.groupBoxCtlSim.Visible = false;
                foreach(Control ctl in this.groupBoxCtlSim.Controls)
                {
                    ctl.Visible = false;
                }
            }
            if (SysCfg.SysCfgModel.RfidSimMode)
            {
                label7.Visible = true;
                this.textBoxRfidVal.Visible = true;
                this.buttonRfidSimWrite.Visible = true;
            }
            this.panelDevConn.Controls.Add(devMonitorView);
            devMonitorView.Dock = DockStyle.Fill;
           
        }
        private void bt_StartSystem_Click(object sender, EventArgs e)
        {
           
           
        }

        private void bt_StopSystem_Click(object sender, EventArgs e)
        {
          
        }

        private void bt_ExitSys_Click(object sender, EventArgs e)
        {
            OnExit();
            //presenter.ExitSystem();
        }
        private bool OnStart()
        {
           
            this.timerNodeStatus.Start();
            return true;
        }
        private bool OnStop()
        {
            this.timerNodeStatus.Stop();
          
            return true;
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
            
            System.Environment.Exit(0);
            return true;
        }

        private void timerNodeStatus_Tick(object sender, EventArgs e)
        {
            DelegateRefreshMonitor dlgtRefreshMonitor = new DelegateRefreshMonitor(AsynRefreshMonitorView);
            dlgtRefreshMonitor.BeginInvoke(null, dlgtRefreshMonitor);

            
            // RefreshNodeStatus();

            //if (this.checkBoxAutorefresh.Checked)
            //{
            //    RefreshPLCComm();
            //}
        }
        private void AsynRefreshMonitorView()
        {
            // RefreshNodeStatus();

            if (this.checkBoxAutorefresh.Checked)
            {
                RefreshPLCComm();
            }
            devMonitorView.RefreshDevDic();
            
        }
       

        #endregion
        #region 通信数据监控与流程仿真
        private void buttonRefreshDevStatus_Click(object sender, EventArgs e)
        {
            RefreshPLCComm();

        }
        private void buttonDB2SimSet_Click(object sender, EventArgs e)
        {
            if (!SysCfg.SysCfgModel.SimMode)
            {
                MessageBox.Show("当前不处于仿真模式");
                return;
            }
            try
            {
                string devID = this.comboBoxDevList.Text;
                int itemID = int.Parse(comboBoxDB2.Text);
                NodeMonitor.SimSetDB2(devID, itemID, int.Parse(this.textBoxDB2ItemVal.Text));

                RefreshPLCComm();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }
        private void comboBoxDevList_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshPLCComm();
        }
    
        private void RefreshPLCComm()
        {
            if(this.dataGridViewDevDB1.InvokeRequired)
            {
                DlgtRefreshPLCComm dlgtRefresh = new DlgtRefreshPLCComm(RefreshPLCComm);
                this.Invoke(dlgtRefresh);
            }
            else
            {
                string nodeName = this.comboBoxDevList.Text;

                DataTable dt1 = null;
                DataTable dt2 = null;
                //DataTable dtTask = null;
                string taskDetail = "";
                if(!NodeMonitor.GetDevRunningInfo(nodeName, ref dt1, ref dt2, ref taskDetail))
                {
                    Console.WriteLine("刷新工位信息失败");
                    return;
                }
                this.dataGridViewDevDB1.DataSource = dt1;
                for (int i = 0; i < this.dataGridViewDevDB1.Columns.Count; i++)
                {
                    this.dataGridViewDevDB1.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
                    this.dataGridViewDevDB1.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                }
                this.dataGridViewDevDB1.Columns[this.dataGridViewDevDB1.Columns.Count - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                this.dataGridViewDevDB2.DataSource = dt2;
                for (int i = 0; i < this.dataGridViewDevDB2.Columns.Count; i++)
                {
                    this.dataGridViewDevDB2.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
                    this.dataGridViewDevDB2.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                }
                this.dataGridViewDevDB2.Columns[this.dataGridViewDevDB2.Columns.Count - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                this.richTextBoxTaskInfo.Text = taskDetail;

               
            }
            
        }
       
       
     
        private void buttonRfidSimWrite_Click(object sender, EventArgs e)
        {
            try
            {
                string nodeName = this.comboBoxDevList.Text;
                string rfidVal = this.textBoxRfidVal.Text;
                NodeMonitor.SimSetRFID(nodeName, rfidVal);
                string barcode = this.textBoxBarcode.Text;
                NodeMonitor.SimSetBarcode(nodeName, barcode);
             
                
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
        private void flowLayoutPanelAsrs_SizeChanged(object sender, EventArgs e)
        {
            int ctlNum = this.flowLayoutPanelAsrs.Controls.Count;
            foreach(Control ctl in this.flowLayoutPanelAsrs.Controls)
            {
                ctl.Width = this.flowLayoutPanelAsrs.Width / 2 - 20;
                ctl.Height = (int)(this.flowLayoutPanelAsrs.Height /(ctlNum/2.0f)) - 20;
            }
        }
        #endregion     
        #region 委托调用
        private void button1_Click(object sender, EventArgs e)
        {
            if(dlgtWMSTaskCommit != null)
            {
                string reStr = "";
                if(dlgtWMSTaskCommit(this.dataGridView1.DataSource as DataTable,ref reStr))
                {
                    MessageBox.Show("WMS任务模拟数据提交成功");
                }
                else
                {
                    MessageBox.Show("WMS任务模拟数据提交失败,"+reStr);
                }
            }
        }
        #endregion
    }
}
