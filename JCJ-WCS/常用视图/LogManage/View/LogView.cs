using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Data.SqlClient;
using Excel = Microsoft.Office.Interop.Excel;
using System.Configuration;
using ModuleCrossPnP;
using LogInterface;
namespace LogManage
{
    public partial class LogView :BaseChildView,ILogView
    {
        
        private LogPresenter presenter;
        private WaitDlg waitDlg = null;
        public LogView(string captionText):base(captionText)
        {
            InitializeComponent();
           
            presenter = new LogPresenter(this);
            this.Text = captionText;
           // this.captionText = captionText;
        }
        public void SetLogsrcList(List<string> srcList)
        {
            this.comboBoxNode.Items.Clear();
            this.comboBoxNode.Items.Add("所有");
            this.comboBoxNode.Items.AddRange(srcList.ToArray());
           
            this.comboBoxNode.SelectedIndex = 0;
        }
        public void AddLogsrcList(string[] srcList)
        {
            foreach(string str in srcList)
            {
                if(this.comboBoxNode.Items.Contains(str))
                {
                    continue;
                }
                this.comboBoxNode.Items.Add(str);
            }
            if(this.comboBoxNode.Items.Count>0)
            {
                this.comboBoxNode.SelectedIndex = 0;
            }
            
        }
        #region UI事件
        
        private void LogView_Load(object sender, EventArgs e)
        {
           
            this.comboBoxLevel.Items.AddRange(new string[] { "所有",EnumLoglevel.提示.ToString(), EnumLoglevel.调试.ToString(), EnumLoglevel.警告.ToString(), EnumLoglevel.错误.ToString() });
            this.comboBoxLevel.SelectedIndex = 0;

            //过滤参数绑定
            this.dateTimePicker1.DataBindings.Add("Value", presenter.LogFilter, "StartDate");
            this.dateTimePicker2.DataBindings.Add("Value", presenter.LogFilter, "EndDate");
            this.comboBoxNode.DataBindings.Add("Text", presenter.LogFilter, "LogsrcStationName");
            this.comboBoxLevel.DataBindings.Add("Text", presenter.LogFilter, "LogLevel");
            this.cb_LikeQuery.DataBindings.Add("Checked", presenter.LogFilter, "LikeQueryEnable");
            this.textBoxLikeContent.DataBindings.Add("Text", presenter.LogFilter, "LikeContent");
          
        }
        private void buttonLogRefresh_Click(object sender, EventArgs e)
        {
            presenter.QueryLog();
            //TimeSpan timeSpan = new TimeSpan();
          //  DataTable dt = presenter.QueryLog(ref timeSpan);
           // string timeCost = string.Format("用时：{0}:{1}:{2}.{3}", timeSpan.Hours, timeSpan.Minutes, timeSpan.Seconds, timeSpan.Milliseconds);
           // RefreshLogdt(dt,timeCost);
        }
        private delegate void DelegateDispLog(DataTable dt, string timeCost, int curPage);
        private void RefreshLogdt(DataTable dt, string timeCost, int curPage)
        {
            if(this.dataGridView1.InvokeRequired)
            {
                DelegateDispLog logDelegate = new DelegateDispLog(RefreshLogdt);
                this.Invoke(logDelegate, new object[] { dt,timeCost,curPage});
            }
            else
            {

                this.toolStripLabelTimecost.Text = timeCost;
              //  this.bindingSource1.DataSource = dt;
                //this.bindingNavigator1.BindingSource = this.bindingSource1;
                this.dataGridView1.DataSource = dt;// this.bindingSource1;
                this.dataGridView1.Columns[0].Width = 100;
                this.dataGridView1.Columns[2].Width = 100;
                this.dataGridView1.Columns[3].Width = 100;
                this.dataGridView1.Columns[4].Width = 200;
                this.dataGridView1.Columns[4].DefaultCellStyle.Format = "yyyy-MM-dd HH:mm:ss";
                this.dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                this.toolTextBoxCurpage.Text = curPage.ToString();
            }
        }
        private void toolStripButtonFirstPage_Click(object sender, EventArgs e)
        {
            presenter.FirstPage();
        }

        private void toolStripButtonPrepage_Click(object sender, EventArgs e)
        {
            presenter.PrePage();
        }

        private void toolStripButtonNextpage_Click(object sender, EventArgs e)
        {
            presenter.NextPage();
        }

        private void toolStripButtonLastPage_Click(object sender, EventArgs e)
        {
            presenter.LastPage();
        }

        private void toolStripButtonRefresh_Click(object sender, EventArgs e)
        {
            OnRefreshLog();

        }
        private void OnRefreshLog()
        {
            try
            {
                int curPage = int.Parse(toolTextBoxCurpage.Text);
                presenter.CurLogPage = curPage;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
           
        }
        #endregion
        public void SetLogDispInterface(ILogDisp logDisp)
        {
            this.presenter.LogDisp = logDisp;
        }
        public ILogRecorder GetLogrecorder()
        {
            return presenter;
        }
        public void RefreshLogDisp(DataTable dt,string timeSpan,int curPage)
        {
            RefreshLogdt(dt, timeSpan,curPage);
        }
        public void RefreshLogQueryStat(string stat)
        {
            this.toolStripLabelTimecost.Text = stat;// 
        }
        public delegate void DelegateRefreshLogsum(int sumPages, int pageSize);
        public void RefreshLogsumInfo(int sumPages,int pageSize)
        {
            if (this.toolStrip1.InvokeRequired)
            {
                DelegateRefreshLogsum delRefresh = new DelegateRefreshLogsum(RefreshLogsumInfo);
                this.Invoke(delRefresh, new object[] { sumPages, pageSize });
            }
            else
            {
                this.toolLabelQueryresult.Text = string.Format("总共{0}页，每页{1}条记录", sumPages, pageSize);
                this.toolLabelSumpage.Text = string.Format("/{0}", sumPages);
                if(sumPages<1)
                {
                    this.toolStrip1.Enabled = false;
                }
                else
                {
                    this.toolStrip1.Enabled = true;
                }
            }
         
        }
        public void SetDebugMode(bool debugMode)
        {
            presenter.DebugMode = debugMode;
        }
        private void toolTextBoxCurpage_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                OnRefreshLog();
            }
        }
        /// <summary>  
        /// If the supplied excel File does not exist then Create it  
        /// </summary>  
        /// <param name="FileName"></param>  
        private void CreateExcelFile(string FileName,string sheetName)
        {
            //create  
            object Nothing = System.Reflection.Missing.Value;
            var app = new Excel.Application();
            app.Visible = false;
            Excel.Workbook workBook = app.Workbooks.Add(Nothing);
            Excel.Worksheet worksheet = (Excel.Worksheet)workBook.Sheets[1];
            worksheet.Name = sheetName;
            ////headline  
            worksheet.Cells[1, 1] = "日志ID";
            worksheet.Cells[1, 2] = "内容";
            worksheet.Cells[1, 3] = "类别";
            worksheet.Cells[1,4] = "日志来源";
            worksheet.Cells[1, 5] = "时间";

            worksheet.SaveAs(FileName, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Excel.XlSaveAsAccessMode.xlNoChange, Type.Missing, Type.Missing, Type.Missing);
            workBook.Close(false, Type.Missing, Type.Missing);
            app.Quit();
        }

        private delegate void DelegateExportLog(DataTable dt, string fileName, string sheetName);
        private void OnExportLog(DataTable dt)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = "excel files (*.xlsx)|*.xlsx";
            if (dlg.ShowDialog() == DialogResult.OK)
            {

                try
                {
                    string fileName = dlg.FileName;
                    string sheetName = "Log";
                    DelegateExportLog dlgtExportLog = new DelegateExportLog(AsyExportLog);
                    dlgtExportLog.BeginInvoke(dt, fileName, sheetName,CallbackExportlogOK, dlgtExportLog);
                    waitDlg = new WaitDlg();
                    waitDlg.ShowDialog();
                    //CreateExcelFile(fileName, sheetName);
                    ////string strConn = "Provider=Microsoft.Jet.OLEDB.4.0;" +
                    ////"Data Source=" + fileName + ";" +
                    ////"Extended Properties='Excel 8.0; HDR=Yes; IMEX=2'";
                    //string strConn = "Provider=Microsoft.ACE.OLEDB.12.0;" +
                    //"Data Source=" + fileName + ";" +
                    //"Extended Properties='Excel 12.0; HDR=Yes; IMEX=0'";
                    //using (OleDbConnection ole_conn = new OleDbConnection(strConn))
                    //{
                    //    ole_conn.Open();
                    //    using (OleDbCommand ole_cmd = ole_conn.CreateCommand())
                    //    {
                    //        foreach (DataRow dr in dt.Rows)
                    //        {
                    //            string logContent = dr["内容"].ToString();
                    //            logContent = logContent.Substring(0, Math.Min(255, logContent.Count()));
                    //            ole_cmd.CommandText = string.Format(@"insert into [{0}$](日志ID,内容,类别,日志来源,时间)values('{1}','{2}','{3}','{4}','{5}')", sheetName, dr["日志ID"].ToString(), logContent, dr["类别"].ToString(), dr["日志来源"].ToString(), dr["时间"].ToString());
                    //            ole_cmd.ExecuteNonQuery();
                    //        }
                          
                    //        MessageBox.Show("数据导出成功......");
                    //    }
                    //}
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
               
            }
        }
        private void CallbackExportlogOK(IAsyncResult ar)
        {
            //结束
            waitDlg.Finished = true;
          //  MessageBox.Show("数据导出成功......");
        }
        private void AsyExportLog(DataTable dt,string fileName,string sheetName)
        {
            CreateExcelFile(fileName, sheetName);
            //string strConn = "Provider=Microsoft.Jet.OLEDB.4.0;" +
            //"Data Source=" + fileName + ";" +
            //"Extended Properties='Excel 8.0; HDR=Yes; IMEX=2'";
            string strConn = "Provider=Microsoft.ACE.OLEDB.12.0;" +
            "Data Source=" + fileName + ";" +
            "Extended Properties='Excel 12.0; HDR=Yes; IMEX=0'";
            using (OleDbConnection ole_conn = new OleDbConnection(strConn))
            {
                ole_conn.Open();
                using (OleDbCommand ole_cmd = ole_conn.CreateCommand())
                {
                   // foreach (DataRow dr in dt.Rows)
                    int rowCount = dt.Rows.Count;
                    for (int i = 0; i < rowCount; i++)
                    {
                        int exportProgress = (int)(100*((float)i+1.0) / (float)rowCount);
                        waitDlg.ProgressPercent = exportProgress;
                        DataRow dr = dt.Rows[i];
                        string logContent = dr["内容"].ToString();
                        logContent = logContent.Substring(0, Math.Min(255, logContent.Count()));
                        ole_cmd.CommandText = string.Format(@"insert into [{0}$](日志ID,内容,类别,日志来源,时间)values('{1}','{2}','{3}','{4}','{5}')", sheetName, dr["日志ID"].ToString(), logContent, dr["类别"].ToString(), dr["日志来源"].ToString(), dr["时间"].ToString());
                        ole_cmd.ExecuteNonQuery();
                    }

                    
                }
            }
        }
        private void btnExportCurpage_Click(object sender, EventArgs e)
        {
            DataTable dt = presenter.CurLogDT;// (DataTable)this.dataGridView1.DataSource; 
            if(dt == null)
            {
                MessageBox.Show("数据为空");
                return;
            }
            OnExportLog(dt);
        }
        private void OnExportAllLog()
        {
            DataTable dt = presenter.SynQueryLog();
            if(dt == null)
            {
                MessageBox.Show("数据为空");
                return;
            }
            else
            {
                OnExportLog(dt);
            }
        }
        private void btnExportAll_Click(object sender, EventArgs e)
        {
            OnExportAllLog();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void comboBoxNode_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void comboBoxLevel_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
