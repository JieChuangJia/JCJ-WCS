using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Data.SqlClient;
using Excel = Microsoft.Office.Interop.Excel;
using ModuleCrossPnP;
using MesDBAccess.BLL;
using MesDBAccess.Model;
using LogInterface;
using DevAccess;
using DevInterface;
namespace ProductRecordView
{
    public partial class ProductDataView : BaseChildView
    {
        #region 数据
        private ProductQueryFilter queryFilter = null;
        private ProductOnlineBll productBll = null;
        private LogManage.WaitDlg waitDlg = null;
        public IHKAccess HkAccess { get; set; }
        //private BatteryBll batBll = new BatteryBll();
        //private BatteryModuleBll batModBll = new BatteryModuleBll();
        //private BatteryPackBll batPackBll = new BatteryPackBll();
     //   private ProduceRecordBll recordBll = null;
        #endregion
        public ProductDataView(string captionText)
            : base(captionText)
        {
            InitializeComponent();
            queryFilter = new ProductQueryFilter();
            this.Text = captionText;
          //  this.captionText = captionText;
          //  recordBll = new ProduceRecordBll();
            productBll = new ProductOnlineBll();
            //HkAccess = new HKAccess(2, "192.168.126.30", 13535);
        }
        private delegate void DelegateQueryRecord(string strWhere);
        /// <summary>
        /// 异步查询
        /// </summary>
        public void AsyQueryRecord(string logQueryCondition)
        {
            
            //RefreshQueryStat("正在查询...");
            //DateTime dt1 = System.DateTime.Now;
            //DataSet ds = recordBll.GetList(logQueryCondition);
            //DateTime dt2 = System.DateTime.Now;
            //TimeSpan timeCost = dt2 - dt1;
            //string strTimespan = string.Format("查询完成，用时：{0}:{1}:{2}.{3}", timeCost.Hours, timeCost.Minutes, timeCost.Seconds, timeCost.Milliseconds);
            //if(ds != null && ds.Tables.Count>0)
            //{
            //    RefreshQueryContent(ds.Tables[0]);
            //}
           
            //RefreshQueryStat(strTimespan);
            //this.bindingNavigator1.BindingSource = new BindingSource()
        }

        
        #region UI事件

        private void ProductDataView_Load(object sender, EventArgs e)
        {

            
            this.tabControl1.TabPages.Remove(this.tabPage2);
            this.tabPage2.Parent = null;
            this.dateTimePicker1.DataBindings.Add("Value", queryFilter, "StartDate");
            this.dateTimePicker2.DataBindings.Add("Value", queryFilter, "EndDate");
            //this.checkBoxBatch.DataBindings.Add("Checked", queryFilter, "BatchCheck");
            //this.checkboxPallet.DataBindings.Add("Checked", queryFilter, "PalletBarcodeCheck");
            //this.checkboxBattery.DataBindings.Add("Checked", queryFilter, "BatteryBarcodeCheck");
            //this.textboxBattery.DataBindings.Add("Text", queryFilter, "BatteryBarCode");
            //this.textboxPallet.DataBindings.Add("Text", queryFilter, "PalletBarCode");
            //this.cbxBatchs.DataBindings.Add("Text", queryFilter, "BatchName");
            OnRefreshBatch();
        }
        private void buttonQuery_Click(object sender, EventArgs e)
        {
            OnQuery("电芯");
        }
        private void OnQuery(string cata)
        {
            try
            {
                if (cata == "电芯")
                {
                    ViewProduct_PSBll productViewBll = new ViewProduct_PSBll();
                    
                    this.dataGridView2.DataSource = null;
                    this.queryFilter.BatchCheck = this.checkBoxBatch.Checked;
                    this.queryFilter.PalletBarcodeCheck = this.checkboxPallet.Checked;
                    this.queryFilter.BatteryBarcodeCheck = this.checkboxBattery.Checked;
                    this.queryFilter.BatteryBarCode = this.textboxBattery.Text;
                    this.queryFilter.PalletBarCode = this.textboxPallet.Text;
                    this.queryFilter.BatchName = this.cbxBatchs.Text;

                    string strWhere = string.Format("onlineTime between '{0}' and '{1}'", this.queryFilter.StartDate.ToString("yyyy-MM-dd 0:00:00"), this.queryFilter.EndDate.ToString("yyyy-MM-dd 0:00:00"));
                    if (queryFilter.PalletBarcodeCheck)
                    {
                        strWhere += string.Format(" and palletID='{0}'", queryFilter.PalletBarCode);
                    }
                    if (queryFilter.BatteryBarcodeCheck)
                    {

                        strWhere += string.Format(" and productID LIKE '%{0}%'", queryFilter.BatteryBarCode);

                    }
                    if (queryFilter.BatchCheck)
                    {
                        strWhere += string.Format(" and batchName='{0}' ", queryFilter.BatchName);
                    }
                    DataSet ds = productViewBll.GetList(strWhere);//productBll.GetListByView(strWhere);
                    DataTable dt = ds.Tables[0];
                    dt.Columns.Remove("productCata");
                    dt.Columns.Remove("processStepID");
                    dt.Columns.Remove("processSeq");
                    dt.Columns.Remove("stepCata");
                    dt.Columns.Remove("cellName");
                    dt.Columns.Remove("ProcessParam2");

                    dt.Columns["productID"].ColumnName = "电芯条码";
                    dt.Columns["processStepName"].ColumnName = "当前工艺";
                    dt.Columns["stationName"].ColumnName = "当前设备";
                    dt.Columns["ProcessParam1"].ColumnName = "设定老化时间";
                    dt.Columns["batchName"].ColumnName = "批次";
                    dt.Columns["palletID"].ColumnName = "料框条码";
                    dt.Columns["palletBinded"].ColumnName = "是否绑定料框";
                    dt.Columns["positionSeq"].ColumnName = "托盘内位置序号";
                    dt.Columns["positionRow"].ColumnName = "托盘内行号";
                    dt.Columns["positionCol"].ColumnName = "托盘内列号";
                    dt.Columns["checkResult"].ColumnName = "检测结果";
                    dt.Columns["onlineTime"].ColumnName = "上线时间";
                    dt.Columns["modifyTime"].ColumnName = "最后更新时间";
                  
                    this.dataGridView2.DataSource = dt;
                    this.dataGridView2.Columns["上线时间"].DefaultCellStyle.Format = "yyyy-MM-dd HH:mm:ss";
                    this.dataGridView2.Columns["最后更新时间"].DefaultCellStyle.Format = "yyyy-MM-dd HH:mm:ss";
                    this.dataGridView2.Columns["电芯条码"].Width = 200;
                    this.label3.Text = "合计:" + dt.Rows.Count.ToString();
                    //this.dataGridView2.Columns["productID"].HeaderText = "电芯条码";
                    //this.dataGridView2.Columns["productID"].Width = 200;
                    //this.dataGridView2.Columns["productCata"].Visible = false;

                    //this.dataGridView2.Columns["processStepID"].Visible = false;
                    //this.dataGridView2.Columns["processSeq"].Visible = false;
                    //this.dataGridView2.Columns["stepCata"].Visible = false;
                    //this.dataGridView2.Columns["processStepName"].HeaderText = "当前工艺";
                    //this.dataGridView2.Columns["stationName"].HeaderText = "当前设备";
                    //this.dataGridView2.Columns["cellName"].Visible = false;
                    //this.dataGridView2.Columns["ProcessParam1"].HeaderText = "设定老化时间";
                    //this.dataGridView2.Columns["ProcessParam2"].Visible = false;
                    //this.dataGridView2.Columns["batchName"].HeaderText = "批次";
                    //this.dataGridView2.Columns["palletID"].HeaderText = "托盘号";
                    //this.dataGridView2.Columns["palletBinded"].HeaderText = "绑定";
                    //this.dataGridView2.Columns["positionSeq"].HeaderText = "托盘内位置序号";

                    //this.dataGridView2.Columns["positionRow"].HeaderText = "托盘内行号";
                    //this.dataGridView2.Columns["positionCol"].HeaderText = "托盘内列号";
                    //this.dataGridView2.Columns["checkResult"].HeaderText = "检测结果";
                    //this.dataGridView2.Columns["onlineTime"].HeaderText = "上线时间";
                    //this.dataGridView2.Columns["modifyTime"].HeaderText = "最后更新时间";
                    //this.dataGridView2.Columns["onlineTime"].DefaultCellStyle.Format = "yyyy-MM-dd HH:mm:ss";
                    //this.dataGridView2.Columns["modifyTime"].DefaultCellStyle.Format = "yyyy-MM-dd HH:mm:ss";


                }
                else
                {
                    this.dataGridView1.DataSource = null;
                    string strWhere = string.Format("onlineTime between '{0}' and '{1}'", this.queryFilter.StartDate.ToString("yyyy-MM-dd 0:00:00"), this.queryFilter.EndDate.ToString("yyyy-MM-dd 0:00:00"));
                    if (queryFilter.BatteryBarcodeCheck)
                    {

                        strWhere += string.Format(" and productID LIKE '%{0}%'", queryFilter.BatteryBarCode);

                    }
                    if (queryFilter.BatchCheck)
                    {
                        strWhere += string.Format(" and batchName='{0}' ", queryFilter.BatchName);
                    }
                    DataSet ds = productBll.GetPallets(strWhere);
                    DataTable dt = ds.Tables[0];
                    this.dataGridView1.DataSource = dt;
                    this.label1.Text = "合计:" + dt.Rows.Count.ToString();
                    // this.dataGridView1.Columns["productCata"].Visible = false;
                    //  this.dataGridView1.Columns["batchName"].HeaderText = "批次";
                    this.dataGridView1.Columns["palletID"].HeaderText = "托盘号";
                    this.dataGridView1.Columns["palletID"].Width = 200;
                }

               

                //if(!queryFilter.PalletBarcodeCheck)
                //{
                //    strWhere = "";
                //    if (queryFilter.BatchCheck)
                //    {
                //        strWhere += string.Format("batchName='{0}' ", queryFilter.BatchName);
                //    }

                //  //  this.dataGridView1.Columns["stationName"].HeaderText = "当前设备";
                //   // this.dataGridView1.Columns["processStepName"].HeaderText = "当前工艺";
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridView2_SelectionChanged(object sender, EventArgs e)
        {
           
           
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
        #endregion

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
           
        }
        private void OnUnbind()
        {
             string palletID=this.textBoxPallet_BL.Text;
            if(string.IsNullOrWhiteSpace(palletID))
            {
                MessageBox.Show("托盘号不能为空!");
                return;
            }
            int askRe=PoupAskmes("确定要解绑吗？");
            if(askRe != 1)
            {
                return;
            }
            string reStr="";
            if(!productBll.UnbindPallet(palletID,ref reStr))
            {
                logRecorder.AddDebugLog(this.Text, string.Format("解绑{0}失败,{1}", palletID, reStr));
               
            }
            else
            {
                logRecorder.AddDebugLog(this.Text, string.Format("二次装载操作，手动解绑{0}成功", palletID));
                
            }
            OnClearBatteryDisp();
        }
        private void buttonUnbind_Click(object sender, EventArgs e)
        {
            OnUnbind();
        }
        private  void AddProduceRecord(string containerID, string comment)
        {
            MesDBAccess.BLL.ProductOnlineBll productOnlineBll = new MesDBAccess.BLL.ProductOnlineBll();
            MesDBAccess.BLL.ProduceRecordBll productRecordBll = new MesDBAccess.BLL.ProduceRecordBll();
            //throw new NotImplementedException();
            string strSql = string.Format(@"palletID='{0}' and palletBinded=1 ", containerID);
            List<MesDBAccess.Model.ProductOnlineModel> products = productOnlineBll.GetModelList(strSql);
           // string nextStepID = GetNextStepID(containerID);
            MesDBAccess.Model.ProduceRecordModel record = new MesDBAccess.Model.ProduceRecordModel();
            record.recordID = System.Guid.NewGuid().ToString("N");
            record.productID = containerID;
            record.recordTime = System.DateTime.Now;
            record.productCata = "料框";
            record.stationID = "";
            record.tag1 = comment;
            productRecordBll.Add(record);
            if (products != null && products.Count() > 0)
            {
                foreach (MesDBAccess.Model.ProductOnlineModel product in products)
                {
                    record = new MesDBAccess.Model.ProduceRecordModel();
                    record.recordID = System.Guid.NewGuid().ToString("N");
                    record.productID = product.productID;
                    record.productCata = product.productCata;
                    record.recordTime = System.DateTime.Now;
                    record.stationID = "";
                    record.checkResult = product.checkResult;
                    record.tag1 = comment;
                    record.tag2 = product.palletID;
                    productRecordBll.Add(record);
                }
            }
        }

        private void OnFill()
        {
            if(this.HkAccess== null)
            {
                return;
            }
            string palletID = this.textBoxPallet_BL.Text;
            if (string.IsNullOrWhiteSpace(palletID))
            {
                MessageBox.Show("托盘号不能为空!");
                return;
            }
            string reStr = "";
            if (palletID.Length != 9 || palletID.Substring(0, 2) != "TP")
            {
                MessageBox.Show("托盘条码输入错误，检查是否以TP开始，后面7位数字");
                return;
            }
            List<ProductOnlineModel> productsBinded = productBll.GetProductsInPallet(palletID);
            if (productsBinded !=null && productsBinded.Count>0)
            {
                int askRe = PoupAskmes(string.Format("托盘{0}处于绑定状态，确定重新装载？现有电池-托盘绑定信息将清除", palletID));
                if(1 != askRe)
                {
                    return;
                }
                if (!productBll.UnbindPallet(palletID, ref reStr))
                {
                    logRecorder.AddDebugLog(this.Text, string.Format("解绑{0}失败,{1}", palletID, reStr));
                    return;
                }
                else
                {
                    logRecorder.AddDebugLog(this.Text, string.Format("二次装载操作，手动解绑{0}成功", palletID));

                }
            }
            List<string> batterList = new List<string>();
            string[] batteryIDS = new string[36];
            int index = 0;
            for (int i = 0; i < Math.Min(3, this.dataGridViewBatterys_BL.RowCount); i++)
            {
                DataGridViewRow rw = this.dataGridViewBatterys_BL.Rows[i];
                if (rw == null)
                {
                    index += 12;
                    continue;
                }
                for (int j = 0; j < 12; j++)
                {
                    if (rw.Cells[j].Value == null)
                    {
                        batteryIDS[index] = string.Empty;
                    }
                    else
                    {
          
                        batteryIDS[index] = rw.Cells[j].Value.ToString().Trim(new char[]{' ','\r','\n','t'}).ToUpper();
                        if(batteryIDS[index].Length>22 && batteryIDS[index].Length<35 && batteryIDS[index].Substring(16,6).ToUpper()=="17K03C")
                        {
                            batteryIDS[index] = batteryIDS[index].Insert(22, "1");
                        }
                        //由12位条码改为13位，modify by zwx,2015-07-22
                        //if (batteryIDS[index].Length > 13)
                        //{
                        //    batteryIDS[index] = batteryIDS[index].Substring(0, 13);
                        //}
                    }
                    index++;
                }
            }
            for(int i=0;i<batteryIDS.Count();i++)
            {
                batterList.Add(batteryIDS[i]);
                
            }
            string sndStr="";
            
            //本地绑定数据存储
            for (int i = 0; i < batterList.Count();i++ )
            {
                string batteryID = batterList[i];
                if(string.IsNullOrWhiteSpace(batteryID))
                {
                    continue;
                }
                if(batteryID.Trim().Length <35)
                {
                    continue;
                }
                batteryID = batteryID.Substring(0, 35);
                MesDBAccess.Model.ProductOnlineModel productModel = null;
                if (productBll.Exists(batteryID))
                {
                    productModel = productBll.GetModel(batteryID);
                    productModel.productID = batteryID;
                    productModel.palletID = palletID;
                    productModel.modifyTime = System.DateTime.Now;
                    productModel.stepNO= 0;
                    productModel.productCata = "电芯";
                    productModel.palletBinded = true;
                    productModel.stationID = "3002";
                    productModel.tag4 = "二次绑定";
                    productModel.checkResult = "0";
                    if (batteryID.Length > 22)
                    {
                        productModel.batchName = batteryID.Substring(16, 6);
                    }

                    int seq = i + 1;
                    productModel.tag1 = seq.ToString();
                    int rowIndex = i / 12 + 1;
                    productModel.tag2 = rowIndex.ToString();
                    int colIndex = i - (rowIndex - 1) * 12 + 1;
                    productModel.tag3 = colIndex.ToString();
                    if (!productBll.Update(productModel))
                    {
                        continue;
                    }
                }
                else
                {
                    productModel = new MesDBAccess.Model.ProductOnlineModel();
                    productModel.onlineTime = System.DateTime.Now;
                    productModel.modifyTime = System.DateTime.Now;
                    productModel.productID = batteryID;
                    productModel.palletID = palletID;
                    productModel.stepNO = 0;
                    productModel.productCata = "电芯";
                    productModel.palletBinded = true;
                    productModel.stationID = "3002";
                    productModel.tag4 = "二次绑定";
                    productModel.checkResult = "0";
                    if (batteryID.Length > 22)
                    {
                        productModel.batchName = batteryID.Substring(16, 6);
                    }
                    int seq = i + 1;
                    productModel.tag1 = seq.ToString();
                    int rowIndex = i / 12 + 1;
                    productModel.tag2 = rowIndex.ToString();
                    int colIndex = i - (rowIndex - 1) * 12 + 1;
                    productModel.tag3 = colIndex.ToString();
                    if (!productBll.Add(productModel))
                    {
                        continue;
                    }
                }
                           
            }
            //杭可2次装载
            if (!HkAccess.BatteryFill(1, palletID, batterList, ref sndStr, ref reStr))
            {
                logRecorder.AddDebugLog(this.Text, string.Format("手动装载失败，{0},返回错误{1},原始发送数据：{2}", palletID, reStr, sndStr));

            }
            else
            {
                logRecorder.AddDebugLog(this.Text, string.Format("手动装载成功，{0}", palletID));
                AddProduceRecord(palletID, "手动装载");
            }

        }
        private void buttonFill_Click(object sender, EventArgs e)
        {
            OnFill();
        }
        private void OnClearBatteryDisp()
        {
            this.dataGridViewBatterys_BL.AllowUserToAddRows = true;
            this.dataGridViewBatterys_BL.Rows.Clear();
           
        }
        private void buttonClear_BL_Click(object sender, EventArgs e)
        {
            OnClearBatteryDisp();
        }

        private void dataGridViewBatterys_BL_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void dataGridViewBatterys_BL_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            this.dataGridViewBatterys_BL.BeginEdit(true);
            this.dataGridViewBatterys_BL.CurrentCell = this.dataGridViewBatterys_BL.Rows[e.RowIndex].Cells[e.ColumnIndex];
        }

        private void dataGridViewBatterys_BL_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                SendKeys.Send("{Tab}");
                this.dataGridViewBatterys_BL.BeginEdit(true);
                e.Handled = true;
            }
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData) //激活回车键
        {
            if (this.dataGridViewBatterys_BL.Rows.Count > 4)
            {
                this.dataGridViewBatterys_BL.AllowUserToAddRows = false;

            }
            if (keyData == Keys.Enter)    //监听回车事件   
            {

                if (this.dataGridViewBatterys_BL.IsCurrentCellInEditMode)
                {
                    if (this.dataGridViewBatterys_BL.CurrentRow.Index < 3 && this.dataGridViewBatterys_BL.SelectedCells[0].ColumnIndex == 11)
                    {
                        int rowIndex = this.dataGridViewBatterys_BL.CurrentRow.Index + 1;
                        if (rowIndex >= this.dataGridViewBatterys_BL.RowCount)
                        {
                            this.dataGridViewBatterys_BL.Rows.Add();

                        }
                        if (rowIndex >= this.dataGridViewBatterys_BL.RowCount)
                        {
                            return false;
                        }
                        this.dataGridViewBatterys_BL.CurrentCell = this.dataGridViewBatterys_BL[0, rowIndex];
                        this.dataGridViewBatterys_BL.CurrentCell.Selected = true;
                    }
                    else
                    {
                        // SendKeys.Send("{Up}");
                        SendKeys.Send("{Tab}");
                        this.dataGridViewBatterys_BL.BeginEdit(true);
                        return true;
                    }

                }

            }

            return base.ProcessCmdKey(ref msg, keyData);

        }

        private void OnRefreshBatch()
        {
            List<string> batchList = productBll.GetBatchList();
            this.cbxBatchs.Items.Clear();
            this.cbxBatchs.Items.AddRange(batchList.ToArray());
            this.cbxBatchs.SelectedIndex = 0;
        }
        private void btnRefreshBatch_Click(object sender, EventArgs e)
        {
            OnRefreshBatch();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           if(e.RowIndex<0 || e.ColumnIndex<0)
           {
               return;
           }
            if (this.dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex] != null)
            {
                string str = this.dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                this.textboxPallet.Text = str;
            }
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OnQuery("料框");
        }

        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            OnExportData();
        }
        private void OnExportData()
        {
            List<DataTable> dts = new List<DataTable>();
            List<string> sheetNames = new List<string>();
            if (this.dataGridView2.DataSource != null)
            {
                DataTable dt = this.dataGridView2.DataSource as DataTable;
                dt.TableName = "电芯数据";
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
                    waitDlg = new LogManage.WaitDlg();
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
                        Console.WriteLine("准备写入{0} {1}条记录", sheetName, rowCount);
                        for (int i = 0; i < rowCount; i++)
                        {
                            int exportProgress = (int)(100 * ((float)i + 1.0) / (float)rowCount);
                            waitDlg.ProgressPercent = exportProgress;
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
            try
            {
                Console.WriteLine("开始创建文件：" + FileName);
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
                Console.WriteLine("创建完成！");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
           

        }
      
    }
}
