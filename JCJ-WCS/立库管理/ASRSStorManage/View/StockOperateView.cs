using ModuleCrossPnP;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AsrsModel;
using Excel = Microsoft.Office.Interop.Excel;
using AsrsStorDBAcc.BLL;
using System.Data.OleDb;

namespace ASRSStorManage.View
{
    public partial class StockOperateView : BaseChildView
    {
        View_StockOperateBLL bllViewStockOperate = new View_StockOperateBLL();
        View_StockBLL bllViewStock = new View_StockBLL();
        WaitDlg waitDlg = null;
        public StockOperateView(string captionText)
            :base(captionText)
        {
            InitializeComponent();
            this.Text = captionText;
        }
        public void RefreshData(DataTable dt)
        {
            this.dgv_OperateRecord.DataSource =ToDistinctDatable( dt);
        }
        private DataTable ToDistinctDatable(DataTable dt)
        {
            if(dt== null)
            {return null;}
          
            List<string> cols = new List<string>();
           for(int i=0;i<dt.Columns.Count;i++)
           {
            cols.Add(dt.Columns[i].ColumnName);
           }
            DataView dv = dt.DefaultView;
            DataTable distDt = dv.ToTable(true, cols.ToArray());
            return distDt;
        }
        private void StockOperateView_Load(object sender, EventArgs e)
        {
            IniOperateType();
            IniHouseName();
            IniProBatch(this.cb_HouseName.Text.Trim());
            this.dtp_start.Value = DateTime.Now - new TimeSpan(30, 0, 0,0);
        }
        private void IniProBatch(string houseName)
        {
            List<string> batches = bllViewStock.GetAllBatches(houseName);
            this.cb_ProBatch.Items.Clear();
            this.cb_ProBatch.Items.Add("所有");
            for(int i=0;i<batches.Count;i++)
            {
                this.cb_ProBatch.Items.Add(batches[i]);
            }
            if(this.cb_ProBatch.Items.Count>0)
            {
                this.cb_ProBatch.SelectedIndex = 0;
            }
        }
        private void IniHouseName()
        {
            this.cb_HouseName.Items.Clear();
            this.cb_HouseName.Items.Add("所有");
          //  for (int i = 0; i < Enum.GetNames(typeof(EnumStoreHouse)).Count(); i++)
            for (int i = 0; i < SysCfg.SysCfgModel.AsrsHouseList.Count(); i++)
            {
                string typeName = SysCfg.SysCfgModel.AsrsHouseList[i];
                this.cb_HouseName.Items.Add(typeName);
            }
            if (this.cb_HouseName.Items.Count > 0)
            {
                this.cb_HouseName.SelectedIndex = 0;
            }
        }
        private void IniOperateType()
        {
            this.cb_OperateType.Items.Clear();
            this.cb_OperateType.Items.Add("所有");
            for (int i = 0; i < Enum.GetNames(typeof(EnumGSOperateType)).Count(); i++)
            {
                string typeName = Enum.GetNames(typeof(EnumGSOperateType))[i];
                this.cb_OperateType.Items.Add(typeName);
            }
            if(  this.cb_OperateType.Items.Count>0)
            {
                this.cb_OperateType.SelectedIndex = 0;
            }
        }
        private void bt_Query_Click(object sender, EventArgs e)
        {
            bool isGsCheck = false;
            bool isQueryLikeCheck = false;
          
            if(this.cbox_GsName.Checked == true)
            {
                isGsCheck = true;
            }
            if(this.Cbox_ContLikequery.Checked == true)
            {
                isQueryLikeCheck = true;
            }
            
           DataTable dt = bllViewStockOperate.GetQueryData(this.dtp_start.Value, this.dtp_end.Value, isGsCheck
               , this.tb_GsName.Text, isQueryLikeCheck, this.tb_LikeQuery.Text,this.cb_ProBatch.Text.Trim()
               , this.cb_OperateType.Text,this.cb_HouseName.Text);
           this.RefreshData(dt);
        }
        #region excel导出
        private void OnExportData()
        {
            List<DataTable> dts = new List<DataTable>();
            List<string> sheetNames = new List<string>();
            if (this.dgv_OperateRecord.DataSource != null)
            {
                DataTable dt = this.dgv_OperateRecord.DataSource as DataTable;
                dt.TableName = "操作记录";
                dts.Add(dt);
                sheetNames.Add(dt.TableName);
            }
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = "excel files (*.xlsx)|*.xlsx";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string fileName = dlg.FileName;

                    DelegateExportLog dlgtExportLog = new DelegateExportLog(AsyExportLog);
                    dlgtExportLog.BeginInvoke(dts.ToArray(), fileName, sheetNames.ToArray(), CallbackExportlogOK, dlgtExportLog);
                     waitDlg = new WaitDlg();
                     waitDlg.ShowDialog();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        private delegate void DelegateExportLog(DataTable[] dts, string fileName, string[] sheetNames);
        private void CallbackExportlogOK(IAsyncResult ar)
        {
            //结束
            waitDlg.Finished = true;
            //  MessageBox.Show("数据导出成功......");
        }
        private void AsyExportLog(DataTable[] dts, string fileName, string[] sheetNames)
        {
            List<string[]> sheetCols = new List<string[]>();
            for (int i = 0; i < dts.Count(); i++)
            {
                DataTable dt = dts[i];
                string[] colNames = new string[dt.Columns.Count];
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    colNames[j] = dt.Columns[j].ColumnName;
                }
                sheetCols.Add(colNames);
            }
            CreateExcelFile(fileName, sheetNames, sheetCols);
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
                    for (int dtIndex = 0; dtIndex < dts.Count(); dtIndex++)
                    {
                        DataTable dt = dts[dtIndex];

                        string sheetName = sheetNames[dtIndex];
                        // foreach (DataRow dr in dt.Rows)
                        int rowCount = dt.Rows.Count;
                        for (int i = 0; i < rowCount; i++)
                        {
                            int exportProgress = (int)(100 * ((float)i + 1.0) / (float)rowCount);
                            if (waitDlg!=null)
                            {
                                waitDlg.ProgressPercent = exportProgress;
                            }
                         
                            DataRow dr = dt.Rows[i];
                            // string logContent = dr["内容"].ToString();
                            //logContent = logContent.Substring(0, Math.Min(255, logContent.Count()));
                            // ole_cmd.CommandText = string.Format(@"insert into [{0}$](日志ID,内容,类别,日志来源,时间)values('{1}','{2}','{3}','{4}','{5}')", sheetName, dr["日志ID"].ToString(), logContent, dr["类别"].ToString(), dr["日志来源"].ToString(), dr["时间"].ToString());
                            StringBuilder strBuild = new StringBuilder();
                            strBuild.AppendFormat("insert into[{0}$](", sheetName);
                            for (int colIndex = 0; colIndex < dt.Columns.Count; colIndex++)
                            {
                                if (colIndex == dt.Columns.Count - 1)
                                {
                                    strBuild.Append(dt.Columns[colIndex].ColumnName + ")values(");
                                }
                                else
                                {
                                    strBuild.Append(dt.Columns[colIndex].ColumnName + ",");
                                }

                            }
                            for (int colIndex = 0; colIndex < dt.Columns.Count; colIndex++)
                            {
                                if (colIndex == dt.Columns.Count - 1)
                                {
                                    strBuild.Append("'" + dr[colIndex].ToString() + "')");
                                }
                                else
                                {
                                    strBuild.Append("'" + dr[colIndex].ToString() + "',");
                                }
                            }
                            ole_cmd.CommandText = strBuild.ToString();
                            ole_cmd.ExecuteNonQuery();
                        }
                    }

                }
            }
        }
        private void CreateExcelFile(string FileName, string[] sheetName, List<string[]> sheetCols)
        {
            //create  
            object Nothing = System.Reflection.Missing.Value;
            var app = new Excel.Application();
            app.Visible = false;
            Excel.Workbook workBook = app.Workbooks.Add(Nothing);
            for (int i = 0; i < sheetName.Count(); i++)
            {
                Excel.Worksheet worksheet = (Excel.Worksheet)workBook.Sheets[i + 1];
                worksheet.Name = sheetName[i];
                for (int j = 0; j < sheetCols[i].Count(); j++)
                {
                    worksheet.Cells[1, j + 1] = sheetCols[i][j];
                }
                //  worksheet.SaveAs(FileName, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Excel.XlSaveAsAccessMode.xlNoChange, Type.Missing, Type.Missing, Type.Missing);

            }
            workBook.SaveAs(FileName);
            workBook.Close(false, Type.Missing, Type.Missing);
            app.Quit();
        }
        #endregion

        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            OnExportData();
        }

    }
}
