using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ModuleCrossPnP;
using AsrsModel;
using ASRSStorManage.Presenter;
 
using AsrsInterface;
using LogInterface;
using AsrsStorDBAcc.Model;

namespace ASRSStorManage.View
{
    public partial class StockManaView : BaseChildView
    {
        StockManaPresenter presenter;
        IAsrsCtlToManage iControl = null;
        IAsrsManageToCtl iStorageManage =null;
        private Form expandForm = null;
        delegate void DelegateShowProductCount(string productCount);
        public StockManaView(string captionTxt)
            : base(captionTxt)
        {
            InitializeComponent();
            this.Text = captionTxt;
            this.presenter = new StockManaPresenter(this);
    
           
        }

        public void SetMenuLimit()
        {
            //if (this.parentPNP.RoleID <=2)
            //{
            //    this.tsb_deleteStock.Visible = true;
            //    this.tsb_returnOutFac.Visible = true;
            //    this.tsb_GsStatusModify.Visible = true;

            //    this.tsmi_deleteStock.Visible = true;
            //    this.tsmi_OutputManual.Visible = true;
            //    this.tsmi_StockStaModify.Visible = true;
            //    //this.tsmi_delete.Visible = true;
            //    //this.tsmi_addStockList.Visible = true;
            //}
            //else
            //{
            //    this.tsb_deleteStock.Visible = false;
            //    this.tsb_returnOutFac.Visible = false;
            //    this.tsb_GsStatusModify.Visible = false;

            //    this.tsmi_deleteStock.Visible = false;
            //    this.tsmi_OutputManual.Visible = false;
            //    this.tsmi_StockStaModify.Visible = false;
            //    this.tsmi_delete.Visible = false;
            //    this.tsmi_addStockList.Visible = false;
            //}
        }

        public void SetInterface( IAsrsManageToCtl iAsrsManageToCtl,IAsrsCtlToManage iAsrsCtlToManage)
        {
            this.iControl = iAsrsCtlToManage;
            this.iStorageManage = iAsrsManageToCtl;
            this.presenter.IniPresenter(iStorageManage, iControl);
          
        }
        public int AskMessageBox(string mesStr)
        {
            return this.PoupAskmes(mesStr);
        }
        private void StackManaView_Load(object sender, EventArgs e)
        {
            IniStoreHouse();
            IniGSStatus();
            IniGSTaskStatus();

            this.presenter.BindRCLData(this.cb_StoreHouse.Text);
            this.presenter.BindProBatchesData(this.cb_StoreHouse.Text);
        }
        public void AddLog(string logSrc,string logContent,EnumLoglevel logLevel )
        {
            LogModel log = new LogModel(logSrc, logContent, logLevel);
       
            if(this.logRecorder == null)
            {
                return;
            }
            this.logRecorder.AddLog(log);
        }
        private void IniStoreHouse()
        {   
            this.cb_StoreHouse.Items.Clear();
           // for(int i=0;i<Enum.GetNames(typeof(EnumStoreHouse)).Count();i++)
            for (int i = 0; i < SysCfg.SysCfgModel.AsrsHouseList.Count(); i++)
            {
                string houseName = SysCfg.SysCfgModel.AsrsHouseList[i];
                this.cb_StoreHouse.Items.Add(houseName);
            }
            if(this.cb_StoreHouse.Items.Count>0)
            {
                this.cb_StoreHouse.SelectedIndex = 0;
            }
        }
        /// <summary>
        /// 刷新库存看板页面
        /// </summary>
        public void RefreshStorageView()
        {
            Form storageForm = StorageMainView.GetViewByName("StorageView");
            if(storageForm == null)
            {
                return;
            }
            StorageView storageView = (StorageView)storageForm;
            if(storageView == null)
            {
                return;
            }
            storageView.RefreshData();
        }
        private void IniGSStatus()
        {
            this.cb_GSStatus.Items.Clear();
            this.cb_GSStatus.Items.Add("所有");
            for (int i = 0; i < Enum.GetNames(typeof(EnumCellStatus)).Count(); i++)
            {
              
                string cellStatus = Enum.GetNames(typeof(EnumCellStatus))[i];
                if (cellStatus == EnumCellStatus.空闲.ToString())
                {
                    continue;
                }
                this.cb_GSStatus.Items.Add(cellStatus);
            }
            if (this.cb_GSStatus.Items.Count > 0)
            {
                this.cb_GSStatus.SelectedIndex = 0;
            }
        }
        public  void IniProductBatch(List<string> batches)
        {
            this.cb_ProductBatch.Items.Clear();
            this.cb_ProductBatch.Items.Add("所有");
            for (int i = 0; i < batches.Count; i++)
            {
                if(batches[i] == "")
                {
                    continue;
                }
                this.cb_ProductBatch.Items.Add(batches[i]);
            }
            if (this.cb_ProductBatch.Items.Count > 0)
            {
                this.cb_ProductBatch.SelectedIndex = 0;
            }
        }
        public void ShowProductCount(string productCount)
        {
            if(this.InvokeRequired)
            {
                DelegateShowProductCount showPruductCount = new DelegateShowProductCount(ShowProductCount);
                this.Invoke(showPruductCount, new object[1] { productCount });
            }
            else
            {
                this.lb_ProductNum.Text = productCount;
                this.tsb_ProductNum.Enabled = true;
            }
           
        }
        private void IniGSTaskStatus()
        {
            this.cb_GSTaskType.Items.Clear();
            this.cb_GSTaskType.Items.Add("所有");
            for (int i = 0; i < Enum.GetNames(typeof(EnumGSTaskStatus)).Count(); i++)
            {
                string houseName = Enum.GetNames(typeof(EnumGSTaskStatus))[i];
                this.cb_GSTaskType.Items.Add(houseName);
            }
            if (this.cb_GSTaskType.Items.Count > 0)
            {
                this.cb_GSTaskType.SelectedIndex = 0;
            }
        }

        public void BindRowData(List<int> rowList)
        {
            if (null == rowList)
            {
                return;
            }
            this.cb_StockRow.Items.Clear();
            this.cb_StockRow.Items.Add("所有");
            for (int i = 0; i < rowList.Count; i++)
            {
                this.cb_StockRow.Items.Add(rowList[i].ToString());
            }
            if (this.cb_StockRow.Items.Count > 0)
            {
                this.cb_StockRow.SelectedIndex = 0;
            }
        }

        public void BindColData(List<int> colList)
        {
            if (null == colList)
            {
                return;
            }
            this.cb_StockColumn.Items.Clear();
            this.cb_StockColumn.Items.Add("所有");
            for (int i = 0; i < colList.Count; i++)
            {
                this.cb_StockColumn.Items.Add(colList[i].ToString());
            }
            if (this.cb_StockColumn.Items.Count > 0)
            {
                this.cb_StockColumn.SelectedIndex = 0;
            }
        }
        public void BindHouseAreaData(List<StoreHouseLogicAreaModel> areaList)
        {
            this.cb_HouseArea.Items.Clear();
            this.cb_HouseArea.Items.Add("所有");
            if(areaList == null)
            {
                return;
            }
            for(int i=0;i<areaList.Count;i++)
            {
                this.cb_HouseArea.Items.Add(areaList[i].StoreHouseAreaName);
            }
            if (this.cb_HouseArea.Items.Count > 0)
            {
                this.cb_HouseArea.SelectedIndex = 0;
            }
        }
        public void BindLayerData(List<int> layerList)
        {
            if (null == layerList)
            {
                return;
            }
            this.cb_StockLayer.Items.Clear();
            this.cb_StockLayer.Items.Add("所有");
            for (int i = 0; i < layerList.Count; i++)
            {
                this.cb_StockLayer.Items.Add(layerList[i].ToString());
            }
            if (this.cb_StockLayer.Items.Count > 0)
            {
                this.cb_StockLayer.SelectedIndex = 0;
            }
        }
        public void RefreshStockList(List<StockListModel> stockList)
        {
            //if (stockList == null)
            //{
            //    return;
            //}
            //this.dgv_StockList.Rows.Clear();
            //for (int i = 0; i < stockList.Count; i++)
            //{
            //    this.dgv_StockList.Rows.Add();
            //    this.dgv_StockList.Rows[i].Cells["StockListID"].Value = stockList[i].StockListID;
            //    this.dgv_StockList.Rows[i].Cells["MeterialBoxID"].Value = stockList[i].MeterialboxCode;

            //    this.dgv_StockList.Rows[i].Cells["InHouseTime"].Value = stockList[i].InHouseTime;
            //}
        }
        public void DeletesStockListRow(int rowIndex)
        {
        //    if (this.dgv_StockList.Rows.Count > rowIndex)
        //    {
        //        this.dgv_StockList.Rows.RemoveAt(rowIndex);
        //    }
        }
        /// <summary>
        /// 更新库存统计
        /// </summary>
        /// <param name="gsNum"></param>
        /// <param name="productNum"></param>
        public void RefreshStatisticsData(string gsNum, string productNum)
        {
            this.lb_GSNum.Text = gsNum;
            this.lb_PalletNum.Text = productNum;
        }
        public void ClearStockDetailView()
        {
            //if(this.dgv_StockInfor.SelectedRows.Count == 0)
            //{
            //    this.dgv_StockList.Rows.Clear();
            //}
        }
        //public void RefreshStock(DataTable stockList)
        //{
           
        //    this.dgv_StockInfor.DataSource = stockList;
        //}
        public void RefreshStock(DataTable stockList)
        { 
            if(stockList == null)
            {
                return;
            }
            string stayHouseTime = "在库时间";
            string inHouseTime ="入库时间";
            stockList.Columns.Add(stayHouseTime);
            for(int i=0;i<stockList.Rows.Count;i++)
            {
                stockList.Rows[i][stayHouseTime] = (DateTime.Now - DateTime.Parse(stockList.Rows[i][inHouseTime].ToString())).TotalHours.ToString("0.00");
            }
            BindingSource bs = new BindingSource();
            bs.DataSource = stockList;
           
            this.bindingNavigator1.BindingSource = bs;
            this.dgv_StockInfor.DataSource = bs;
            //if (stockList == null)
            //{
            //    return;
            //}
            //this.dgv_StockInfor.Rows.Clear();
            //for (int i = 0; i < stockList.Rows.Count; i++)
            //{
            //    this.dgv_StockInfor.Rows.Add();
            //    this.dgv_StockInfor.Rows[i].Cells["StockID"].Value = stockList.Rows[i]["库存ID"].ToString();
            //    this.dgv_StockInfor.Rows[i].Cells["GoodsSiteName"].Value = stockList.Rows[i]["货位名称"].ToString();
            //    this.dgv_StockInfor.Rows[i].Cells["rowth"].Value = stockList.Rows[i]["排"].ToString();
            //    this.dgv_StockInfor.Rows[i].Cells["colth"].Value = stockList.Rows[i]["列"].ToString();
            //    this.dgv_StockInfor.Rows[i].Cells["layerth"].Value = stockList.Rows[i]["层"].ToString();
            //    this.dgv_StockInfor.Rows[i].Cells["ProductBatch"].Value = stockList.Rows[i]["产品批次"].ToString();
            //    this.dgv_StockInfor.Rows[i].Cells["gs_Status"].Value = stockList.Rows[i]["货位状态"].ToString();
            //    this.dgv_StockInfor.Rows[i].Cells["gs_TaskStatus"].Value = stockList.Rows[i]["货位任务状态"];
            //    this.dgv_StockInfor.Rows[i].Cells["col_ProductCode"].Value = stockList.Rows[i]["料框条码"];
            //    this.dgv_StockInfor.Rows[i].Cells["col_HouseName"].Value = stockList.Rows[i]["库房名称"];
            //    this.dgv_StockInfor.Rows[i].Cells["col_HouseArea"].Value = stockList.Rows[i]["库区"];
            //    this.dgv_StockInfor.Rows[i].Cells["col_InHousetime"].Value = stockList.Rows[i]["入库时间"];
            //    if (stockList.Rows[i]["启用状态"].ToString().ToUpper() == "FALSE")
            //    {
            //        this.dgv_StockInfor.Rows[i].Cells["col_StartStatus"].Value = "禁用";
            //    }
            //    else
            //    {
            //        this.dgv_StockInfor.Rows[i].Cells["col_StartStatus"].Value = "启用";
            //    }

            //}
        }
        private void cb_StoreHouse_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.presenter.BindRCLData(this.cb_StoreHouse.Text);
            this.presenter.BindProBatchesData(this.cb_StoreHouse.Text);
            this.presenter.BindHouseAreaData(this.cb_StoreHouse.Text);
        }
        /// <summary>
        ///出厂设置 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsb_returnOutFac_Click(object sender, EventArgs e)
        {
            if (this.parentPNP.RoleID > 2)
            {
                MessageBox.Show("当前用户没有此功能的操作权限！", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (PoupAskmes("您确定要恢复出厂设置么？恢复出厂设置将还原所有货位为初始状态，并清空所有库存！") != 1)
            {
                return;
            }
            this.presenter.ReturnFac();
        }
 
        private void tsb_QueryStock_Click(object sender, EventArgs e)
        {

            this.presenter.QueryStock(this.cb_StoreHouse.Text, this.cb_HouseArea.Text,this.cb_StockRow.Text, this.cb_StockColumn.Text, this.cb_StockLayer.Text
                , this.cb_GSStatus.Text, this.cb_GSTaskType.Text,this.cb_ProductBatch.Text,this.cb_boxCode.Checked,this.tb_BoxCode.Text);
        }

        private void dgv_StockInfor_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //if(this.dgv_StockInfor.CurrentRow == null)
            //{
            //    return;
            //}
            //int currRow = this.dgv_StockInfor.CurrentRow.Index;
            //string stockId = this.dgv_StockInfor.Rows[currRow].Cells["StockID"].Value.ToString();
            //this.presenter.RefreshStockList(long.Parse(stockId));

        }
        private void ModifyGsStatus()
        {
            if (this.dgv_StockInfor.SelectedRows.Count == 0)
            {
                MessageBox.Show("请选中要要修改的货位！", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            EditGSStaView egsv = new EditGSStaView();
            egsv.ShowDialog();
            if (egsv.IsSure == true)
            {
                if (PoupAskmes("您确定要修改选中货位状态么？") != 1)
                {
                    return;
                }
                List<GsPosModel> gsList = new List<GsPosModel>();
                for (int i = 0; i < this.dgv_StockInfor.SelectedRows.Count; i++)
                {
                    GsPosModel gsPos = new GsPosModel();
                  
                    int rowth = int.Parse(this.dgv_StockInfor.SelectedRows[i].Cells["排"].Value.ToString());
                    int colth = int.Parse(this.dgv_StockInfor.SelectedRows[i].Cells["列"].Value.ToString());
                    int layerth = int.Parse(this.dgv_StockInfor.SelectedRows[i].Cells["层"].Value.ToString());

                    gsPos.HouseName = this.cb_StoreHouse.Text;
                    gsPos.Rowth=rowth;
                    gsPos.Colth = colth;
                    gsPos.Layerth = layerth;
                    gsList.Add(gsPos);
                }
                this.presenter.ModifyGsStatus(gsList, egsv.GSStatus, egsv.GSTaskStatus);
            }
        }
        private void tsb_GsStaModify_Click(object sender, EventArgs e)
        {
            if (this.parentPNP.RoleID > 1)
            {
                MessageBox.Show("当前用户没有此功能的操作权限！", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            ModifyGsStatus();
        }
      
        public void RegisterExtForm(Form expandForm)
        {
            if (expandForm == null)
            {
                return;
            }
            //  this.pl_ExterProParent.Controls.Clear();
            this.gb_Model.Text = expandForm.Text;
            this.expandForm = expandForm;
            expandForm.TopLevel = false;
            expandForm.Visible = false;//默认不显示
            expandForm.Dock = DockStyle.Fill;
            expandForm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.pl_ExterProParent.Controls.Add(expandForm);
            //expandForm.Show();
        }
        public void ShowExtForm(ExtendFormCate formCate)
        {
            for (int i = 0; i < this.pl_ExterProParent.Controls.Count; i++)
            {
                Form fm = (Form)this.pl_ExterProParent.Controls[i];
                if (fm == null)
                {
                    continue;
                }
                fm.Visible = false;
            }
            if (formCate == ExtendFormCate.外部)
            {
                 if(this.expandForm == null)
                 {
                     return;
                 }
                 this.expandForm.Visible = true;
                 this.expandForm.Show();
                 this.gb_Model.Text = this.expandForm.Text;
            }
            else//内部,暂时没有内部扩展窗体
            {
                
            }
        }
        private void OutputManual()
        {
            if (this.dgv_StockInfor.SelectedRows.Count == 0)
            {
                MessageBox.Show("请选中要出库的库存！", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (PoupAskmes("您确定要手动出库选中库存么？") != 1)
            {
                return;
            }
            List<long> stockList = new List<long>();
    
            for (int i = 0; i < this.dgv_StockInfor.SelectedRows.Count; i++)
            {
                string stockIDStr = this.dgv_StockInfor.SelectedRows[i].Cells["库存ID"].Value.ToString();
                string outputManual = this.dgv_StockInfor.SelectedRows[i].Cells["货位任务状态"].Value.ToString();
                long stockID = long.Parse(stockIDStr);     
                stockList.Add(stockID);
            }
           

            this.presenter.OutputManual(stockList);

        }
        private void tsb_OutputManual_Click(object sender, EventArgs e)
        {
            if (this.parentPNP.RoleID > 2)
            {
                MessageBox.Show("当前用户没有此功能的操作权限！", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            OutputManual();

        }
        private void DeleteStock()
        {
            if (this.dgv_StockInfor.SelectedRows.Count == 0)
            {
                MessageBox.Show("请选中要出库的库存！", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (PoupAskmes("您确定要删除选中库存么？") != 1)
            {
                return;
            }
            List<long> stockList = new List<long>();

            for (int i = 0; i < this.dgv_StockInfor.SelectedRows.Count; i++)
            {
                string stockIDStr = this.dgv_StockInfor.SelectedRows[i].Cells["库存ID"].Value.ToString();

                long stockID = long.Parse(stockIDStr);

                stockList.Add(stockID);
            }

            this.presenter.DeleteStock(stockList);
        }
         
        private void tsb_deleteStock_Click(object sender, EventArgs e)
        {
            if (this.parentPNP.RoleID > 1)
            {
                MessageBox.Show("当前用户没有此功能的操作权限！", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            DeleteStock();
        }

        private void tsmi_StockStaModify_Click(object sender, EventArgs e)
        {
            if (this.parentPNP.RoleID > 1)
            {
                MessageBox.Show("当前用户没有此功能的操作权限！", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            ModifyGsStatus();
        }

        private void tsmi_OutputManual_Click(object sender, EventArgs e)
        {
            if (this.parentPNP.RoleID > 2)
            {
                MessageBox.Show("当前用户没有此功能的操作权限！", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            OutputManual();
        }

        private void tsmi_deleteStock_Click(object sender, EventArgs e)
        {
            if (this.parentPNP.RoleID > 2)
            {
                MessageBox.Show("当前用户没有此功能的操作权限！", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            DeleteStock();
        }

        private void 料框详细ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void tsmi_delete_Click(object sender, EventArgs e)
        {
            if (this.parentPNP.RoleID > 2)
            {
                MessageBox.Show("当前用户没有此功能的操作权限！", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            //if (this.dgv_StockList.CurrentRow == null)
            //{
            //    return;
            //}
            //int currRow = this.dgv_StockList.CurrentRow.Index;
            //string gsDetailID = this.dgv_StockList.Rows[currRow].Cells["StockListID"].Value.ToString();
            //this.presenter.DeleteStockList(gsDetailID, currRow);
        }

        private void tsmi_addStockList_Click(object sender, EventArgs e)
        {
            if (this.parentPNP.RoleID > 2)
            {
                MessageBox.Show("当前用户没有此功能的操作权限！", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (this.dgv_StockInfor.CurrentRow == null)
            {
                return;
            }
            int currRow = this.dgv_StockInfor.CurrentRow.Index;
            string stockID = this.dgv_StockInfor.Rows[currRow].Cells["StockID"].Value.ToString();
            AddStockListView aslv = new AddStockListView();
            aslv.ShowDialog();
            if(aslv.IsSure == true)
            {
                this.presenter.AddStockList(stockID, aslv.StockListStr);
            }
        
        }

        private void bt_CloseExpandView_Click(object sender, EventArgs e)
        {
            this.splitContainer1.Panel2Collapsed = true;
        }
 

        private void tsb_UseGS_Click(object sender, EventArgs e)
        {
            UsePos();
        }
        private void UsePos()
        {
            if (this.parentPNP.RoleID > 2)
            {
                MessageBox.Show("当前用户没有此功能的操作权限！", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (this.dgv_StockInfor.CurrentRow == null)
            {
                return;
            }
            List<string> stockIDList = new List<string>();
            for (int i = 0; i < this.dgv_StockInfor.SelectedRows.Count; i++)
            {
                string stockID = this.dgv_StockInfor.SelectedRows[i].Cells["库存ID"].Value.ToString();
                stockIDList.Add(stockID);
            }
            this.presenter.SetGsUseStatus(stockIDList, true);
        }
        private void tsmi_StockListPro_Click(object sender, EventArgs e)
        {
            if (this.parentPNP.RoleID > 2)
            {
                MessageBox.Show("当前用户没有此功能的操作权限！", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            //   if (this.dgv_StockList.CurrentRow == null)
            //{
            //    return;
            //}
            //   int currRow = this.dgv_StockList.CurrentRow.Index;
            //string productCode = this.dgv_StockList.Rows[currRow].Cells["MeterialBoxID"].Value.ToString();
            //string stockListID = this.dgv_StockList.Rows[currRow].Cells["StockListID"].Value.ToString();
         
            //this.splitContainer1.Panel2Collapsed = false;
            //this.presenter.OnCellExpandPro(productCode, stockListID);
        }

        private void tsb_UnuseGs_Click(object sender, EventArgs e)
        {
            UnUse();
        }
        private void UnUse()
        {
            if (this.parentPNP.RoleID > 2)
            {
                MessageBox.Show("当前用户没有此功能的操作权限！", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (this.dgv_StockInfor.CurrentRow == null)
            {
                return;
            }
            if (PoupAskmes("您确定要禁用当前选中库存的货位么？") != 1)
            {
                return;
            }
            List<string> stockIDList = new List<string>();
            for (int i = 0; i < this.dgv_StockInfor.SelectedRows.Count; i++)
            {
                string stockID = this.dgv_StockInfor.SelectedRows[i].Cells["库存ID"].Value.ToString();
                stockIDList.Add(stockID);
            }
            this.presenter.SetGsUseStatus(stockIDList, false);

        }
        private void bt_RefreshBatch_Click(object sender, EventArgs e)
        {
            this.presenter.BindProBatchesData(this.cb_StoreHouse.Text);
        }
 
        private void tsb_ProductNum_Click(object sender, EventArgs e)
        {
            this.tsb_ProductNum.Enabled = false;
            this.lb_ProductNum.Text = "查询中，请稍后！";
            QueryStockParamModel queryStockParamModel = new QueryStockParamModel();
            queryStockParamModel.HouseArea = this.cb_HouseArea.Text;
            queryStockParamModel.HouseName = this.cb_StoreHouse.Text;
            queryStockParamModel.Rowth = this.cb_StockRow.Text;
            queryStockParamModel.Colth = this.cb_StockColumn.Text;
            queryStockParamModel.Layerth = this.cb_StockLayer.Text;
            queryStockParamModel.GsStatus = this.cb_GSStatus.Text;
            queryStockParamModel.GsTaskStatus = this.cb_GSTaskType.Text;
            queryStockParamModel.Batch = this.cb_ProductBatch.Text;
            queryStockParamModel.IsCheck = this.cb_boxCode.Checked;
            queryStockParamModel.MaterialBoxCode = this.tb_BoxCode.Text;
            this.presenter.QueryProductCount(queryStockParamModel);
        }
 

        private void cb_StockRow_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void cb_StockColumn_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void tsmi_ModifyCode_Click(object sender, EventArgs e)
        {
            if (this.parentPNP.RoleID > 2)
            {
                MessageBox.Show("当前用户没有此功能的操作权限！", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (this.dgv_StockInfor.CurrentRow == null)
            {
                return;
            }
            int currRow = this.dgv_StockInfor.CurrentRow.Index;

            BindingSource bs = new BindingSource();
            bs = (BindingSource)this.dgv_StockInfor.DataSource;
            DataTable stockList = (DataTable)bs.DataSource;

            string stockID = stockList.Rows[currRow]["库存ID"].ToString();
            string codestr = stockList.Rows[currRow]["料框条码"].ToString();
            AddStockListView aslv = new AddStockListView();
            aslv.SetCode(codestr);
            aslv.ShowDialog();
            if (aslv.IsSure == true)
            {
                this.presenter.ModifyStockList(stockID, codestr, aslv.StockListStr);
            }
        }
 
 
    }
}
