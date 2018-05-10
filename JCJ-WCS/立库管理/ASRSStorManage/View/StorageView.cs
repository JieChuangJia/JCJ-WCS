using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ASRSStorManage.Presenter;
using Storage;
using AsrsStorDBAcc.Model;
using ModuleCrossPnP;
using LogInterface;
using AsrsModel;
using AsrsInterface;

namespace ASRSStorManage.View
{
    public partial class StorageView : BaseChildView
    {
        private StoragePresenter presenter;//逻辑类
        private MoveHouseManulView innerForm = null;
        private Form expandForm = null;
        IAsrsCtlToManage iControl = null;
        IAsrsManageToCtl iStorageManage = null;
        /// <summary>
        /// 是否启用移库功能
        /// </summary>
        private bool isUseMoveHouse = true;
        private delegate void RefreshDataInvoke();
        private delegate  void RefreshPosInvoke(List<Positions> posList);
        private delegate void RefreshGSDetailInvoke(List<View_StockModel> stockList);
        private delegate void RefreshGSStatsuNumInvoke(int nullFrameNum, int productNum, int nullNum, int taskLockNum, int forbitNum, int outAllowNum);
        public StorageView(string captionTxt)
            : base(captionTxt)
        {
            InitializeComponent();
            presenter = new StoragePresenter(this);
            SetFunc();
      
        }
        public void SetInterface(IAsrsManageToCtl iAsrsManageToCtl, IAsrsCtlToManage iAsrsCtlToManage)
        {
            this.iControl = iAsrsCtlToManage;
            this.iStorageManage = iAsrsManageToCtl;
            presenter.IniPresenter(iStorageManage, iControl);
      
        }
        private void SetFunc()
        {
            if(this.isUseMoveHouse == true)
            {
                this.splitContainer1.Panel2Collapsed = false;
                this.手动移库ToolStripMenuItem.Visible = true;
            }
            else
            {
                this.splitContainer1.Panel2Collapsed = true;
                this.手动移库ToolStripMenuItem.Visible = false;
            }
            splitContainer1.SplitterDistance = splitContainer1.Width - splitContainer1.SplitterWidth - 320;//移库控件宽度
        }
        public void SetMenuLimit()
        {
            //if(this.parentPNP.RoleID <=2 )
            //{
            //    this.tsb_GsStatusModify.Visible = true;
            //    this.tsb_UnuseGs.Visible = true;
            //    this.tsb_UsrGs.Visible = true;

            //    this.cms_outputManual.Visible = true;
            //    this.tsmi_ModifyStatus.Visible = true;
            //    this.tsmi_Refresh.Visible = true;
            //    this.tsmi_UnUseGs.Visible = true;
            //    this.tsmi_UseGs.Visible = true;
            //    this.tsb_OutputManual.Visible = true;
            //    //this.tsmi_DeleteStockList.Visible = true;
            //    //this.tsmi_AddStockList.Visible = true;
            //}
            //else
            //{
            //    this.tsb_GsStatusModify.Visible = false;
            //    this.tsb_UnuseGs.Visible = false;
            //    this.tsb_UsrGs.Visible = false;

            //    this.cms_outputManual.Visible = false;
            //    this.tsmi_ModifyStatus.Visible = false;
            //    this.tsmi_Refresh.Visible = false;
            //    this.tsmi_UnUseGs.Visible = false;
            //    this.tsmi_UseGs.Visible = false;
            //    this.tsb_OutputManual.Visible = false;
            //    this.tsmi_DeleteStockList.Visible = false;
            //    this.tsmi_AddStockList.Visible = false;
            //}
          
        }
        private void StorageView_Load(object sender, EventArgs e)
        {
            this.presenter.LoadData();
            this.splitContainer2.SplitterDistance = 0;
            RegisterInnerForm();
        }
   
        public void BindHouseData(List<string> houseList)
        {
            if(null == houseList)
            {
                return;
            }
            this.tscb_StoreHouseName.Items.Clear();
            for(int i=0;i<houseList.Count;i++)
            {
                this.tscb_StoreHouseName.Items.Add(houseList[i]);
            }
            if(this.tscb_StoreHouseName.Items.Count>0)
            {
                this.tscb_StoreHouseName.SelectedIndex = 0;
            }
        }

        public void BindRowData(List<int> rowList)
        {
            if (null == rowList)
            {
                return;
            }
            this.tscb_Rowth.Items.Clear();
            for (int i = 0; i < rowList.Count; i++)
            {
                this.tscb_Rowth.Items.Add(rowList[i].ToString());
            }
            if (this.tscb_Rowth.Items.Count > 0)
            {
                this.tscb_Rowth.SelectedIndex = 0;
            }
        }

        public void BindColData(List<int> colList)
        {
            if (null == colList)
            {
                return;
            }
            this.tscb_Columnth.Items.Clear();
            for (int i = 0; i < colList.Count; i++)
            {
                this.tscb_Columnth.Items.Add(colList[i].ToString());
            }
            if (this.tscb_Columnth.Items.Count > 0)
            {
                this.tscb_Columnth.SelectedIndex = 0;
            }
        }

        public void BindLayerData(List<int> layerList)
        {
            if (null == layerList)
            {
                return;
            }
            this.tscb_Layerth.Items.Clear();
            for (int i = 0; i < layerList.Count; i++)
            {
                this.tscb_Layerth.Items.Add(layerList[i].ToString());
            }
            if (this.tscb_Layerth.Items.Count > 0)
            {
                this.tscb_Layerth.SelectedIndex = 0;
            }
        }

        /// <summary>
        /// 刷新界面货位
        /// </summary>
        /// <param name="posList"></param>
        public void RefreshPos(List<Positions> posList)
        {
            if(this.storageControl1.InvokeRequired)
            {
                RefreshPosInvoke rpi = new RefreshPosInvoke(RefreshPos);
                this.storageControl1.Invoke(rpi, new object[1] { posList });
            }
            else
            {
                this.storageControl1.DataSour = posList;
            }
        }
    
        public void RefreshData()
        {
            if (this.InvokeRequired)
            {
                RefreshDataInvoke rdi = new RefreshDataInvoke(RefreshData);
                this.Invoke(rdi);
            }
            else
            {
                if (this.tscb_Rowth.Text == "")
                { return; }
                int queryRow = int.Parse(this.tscb_Rowth.Text);
                this.presenter.RefreshPos(this.tscb_StoreHouseName.Text, queryRow);
            }
          
        }
        private void tsb_RefreshData_Click(object sender, EventArgs e)
        {
            RefreshData();
        }

        private void tscb_StoreHouseName_SelectedIndexChanged(object sender, EventArgs e)
        {
            string houseName = this.tscb_StoreHouseName.Text;
            this.presenter.ChangeHouse(houseName);
            if(this.innerForm!= null)//切换库房时清除移库参数
            {
                this.innerForm.ClearMoveParam();
            }
       

        }
    
        private void storageControl1_PositionsClick(object sender, StorageControl.ClickPositionsEventArgs e)
        {
            this.storageControl1.selectPositions = e.Positions;
            if (this.storageControl1.selectPositions != null && this.storageControl1.selectPositions.Visible == true)
            {
                this.presenter.GetGSDetail(e.Positions.GoodsSiteID);
                OnShowExterProperty();
            }
            
        }

        private void tsb_Query_Click(object sender, EventArgs e)
        {
            int columnth = int.Parse(tscb_Columnth.Text.Trim()) ;
            int layerth = int.Parse(this.tscb_Layerth.Text.Trim()) ;
            GsSearch(columnth, layerth);

        }
        private void OnShowExterProperty()
        {
            //if (this.parentPNP.RoleID > 2)
            //{
            //    MessageBox.Show("当前用户没有此功能的操作权限！", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    return;
            //}
            if (this.storageControl1.selectPositions == null)
            {
                return;
            }
            //this.splitContainer1.Panel2Collapsed = false;
            this.presenter.OnCellExpandPro(this.storageControl1.selectPositions);
        }
        public void RefreshGSDetail(List<View_StockModel> stockList)
        {
            if(this.dgv_GoodsSiteDetail.InvokeRequired)
            {
                RefreshGSDetailInvoke rgsdi = new RefreshGSDetailInvoke(RefreshGSDetail);
                this.dgv_GoodsSiteDetail.Invoke(rgsdi, new object[1] { stockList });
            }
            else
            {
                this.dgv_GoodsSiteDetail.Rows.Clear();
                if (null == stockList)
                {
                    return;
                }
                for (int i = 0; i < stockList.Count; i++)
                {
                    this.dgv_GoodsSiteDetail.Rows.Add();
                    this.dgv_GoodsSiteDetail.Rows[i].Cells["goodsSiteID"].Value = stockList[i].GoodsSiteID.ToString();
                    this.dgv_GoodsSiteDetail.Rows[i].Cells["TrayID"].Value = stockList[i].MeterialboxCode;
                    this.dgv_GoodsSiteDetail.Rows[i].Cells["GsName"].Value = stockList[i].GoodsSiteName;
                    this.dgv_GoodsSiteDetail.Rows[i].Cells["gsStatus"].Value = stockList[i].GoodsSiteStatus;
                    this.dgv_GoodsSiteDetail.Rows[i].Cells["col_ProductBatch"].Value = stockList[i].MeterialBatch;
                    this.dgv_GoodsSiteDetail.Rows[i].Cells["StockListID"].Value = stockList[i].StockListID;
                    this.dgv_GoodsSiteDetail.Rows[i].Cells["updateTime"].Value = stockList[i].InHouseTime;
                    this.dgv_GoodsSiteDetail.Rows[i].Cells["col_StayHouseTime"].Value = (DateTime.Now - stockList[i].InHouseTime).TotalHours.ToString("0.00");
                    this.dgv_GoodsSiteDetail.Rows[i].Cells["Col_Remark"].Value = stockList[i].GoodsSite_Reserve ;
                }
            }
      
               
        }
        public void AddLog(string logSrc, string logContent, EnumLoglevel logLevel)
        {
            LogModel log = new LogModel(logSrc, logContent, logLevel);

            if (this.logRecorder == null)
            {
                return;
            }
            this.logRecorder.AddLog(log);
        }
        public void ShowLogicAreaColor(Dictionary<string ,Color > logicDic)
        {
            if(logicDic ==null)
            {
                return;
            }
            this.gb_LogicGs.Controls.Clear();
            int index =0;
            int rowIndx= 1;
            int width = 100;
            int height=20;
            foreach(KeyValuePair<string,Color> keyValue in logicDic)
            {
                index++;
                Label label = new Label();
                label.Text = keyValue.Key;
                label.BackColor = keyValue.Value;
                label.Size = new System.Drawing.Size(width,height);

                int colIndex = index%3;
             
                if(colIndex == 0)
                {
                  
                    int x = (3 - 1) * (width + 20) + 20;
                    int y = (rowIndx-1) * (height + 10) + 30;
                    label.Location = new Point(x, y);
                    rowIndx++;
                }
                else
                {
                    int x = (colIndex - 1) * (width + 20) + 20;
                    int y = (rowIndx - 1) * (height + 10) + 30;
                    label.Location = new Point(x, y);
                }
                label.ForeColor = Color.White;
             
                
                this.gb_LogicGs.Controls.Add(label);
            }
            
        }
        /// <summary>
        /// 更新货位有货、空料框、待用数量
        /// </summary>
        /// <param name="nullFrameNum">空料框数量</param>
        /// <param name="productNum">有货数量</param>
        /// <param name="nullNum">空货位数量</param>
        public void RefreshGSStatsuNum(int nullFrameNum, int productNum, int nullNum, int taskLockNum, int forbitNum,int outAllowNum)
        {
         
            if( this.lb_NullFrameNum.InvokeRequired
                   ||this.lb_PrductNum.InvokeRequired
                  ||this.lb_NullGsNum.InvokeRequired
                  ||this.lb_TaskLock.InvokeRequired
                  ||this.lb_ForbitNum.InvokeRequired
                  ||this.lb_OutAllowNum.InvokeRequired
                )
            {
                RefreshGSStatsuNumInvoke rgsnumi = new RefreshGSStatsuNumInvoke(RefreshGSStatsuNum);
                this.Invoke(rgsnumi, new object[6] { nullFrameNum, productNum, nullNum, taskLockNum, forbitNum, outAllowNum });
            }
            else
            {
                this.lb_NullFrameNum.Text = nullFrameNum.ToString();
                this.lb_PrductNum.Text = productNum.ToString();
                this.lb_NullGsNum.Text = nullNum.ToString();
                this.lb_TaskLock.Text = taskLockNum.ToString();
                this.lb_ForbitNum.Text = forbitNum.ToString();
                this.lb_OutAllowNum.Text = outAllowNum.ToString();
            }
        
        }
        public void GsSearch(int columnth, int layerth)
        {
          
            Positions pos = this.storageControl1.GetPositionsByCL(columnth-1, layerth-1);
            if (pos != null)
            {
                this.storageControl1.selectPositions = pos;

                if (pos.Location.X + pos.Width > this.storageControl1.Width - 10)//垂直滚动条宽度10
                {
                    int hScrollValue = pos.Location.X + pos.Width - this.storageControl1.Width + 50;
                    if (hScrollValue > this.storageControl1.HorizontalScroll.Maximum)
                    {
                        hScrollValue = this.storageControl1.HorizontalScroll.Maximum;
                    }
                    this.storageControl1.HorizontalScroll.Value = hScrollValue;
                    this.storageControl1.HorizontalScroll.Value = hScrollValue;
                }
                else
                {
                    this.storageControl1.HorizontalScroll.Value = 0;
                    this.storageControl1.HorizontalScroll.Value = 0;
                }
                if (pos.Location.Y + pos.Height > this.storageControl1.Height - 10)//横向滚动条宽度10
                {
                    int vScrollValue = pos.Location.Y - this.storageControl1.Height + 50;
                    if (vScrollValue > this.storageControl1.VerticalScroll.Maximum)
                    {
                        vScrollValue = this.storageControl1.VerticalScroll.Maximum;
                    }
                    this.storageControl1.VerticalScroll.Value = vScrollValue;//设置两次才好使
                    this.storageControl1.VerticalScroll.Value = vScrollValue;
                }
                else
                {
                    this.storageControl1.VerticalScroll.Value = 0;
                    this.storageControl1.VerticalScroll.Value = 0;
                }
                this.storageControl1.Invalidate();
                this.storageControl1.Invalidate();
            }
        }

        private void tscb_Rowth_SelectedIndexChanged(object sender, EventArgs e)
        {
            int queryRow = int.Parse(this.tscb_Rowth.Text);
            if(queryRow == 1)
            {
                this.storageControl1.BackColor = Color.Black;
            }
            else if(queryRow == 2)
            {
                this.storageControl1.BackColor = Color.FromArgb(8,46,84);
            }
            else
            { }

            this.presenter.RefreshPos(this.tscb_StoreHouseName.Text, queryRow);
        }

        private void tsb_TrayCodeSearch_Click(object sender, EventArgs e)
        {
            string boxCode = this.tb_trayCode.Text;
            this.presenter.SearchBoxByCode(boxCode);
        }
       
        public void ShowMessage(string mess)
        {
            MessageBox.Show(mess, "信息显示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void UnUserGs()
        {
            if (this.parentPNP.RoleID > 2)
            {
                MessageBox.Show("当前用户没有此功能的操作权限！", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (PoupAskmes("您确定要禁用当前选中的货位么？") != 1)
            {
                return;
            }
            if (null == this.storageControl1.selectPositions)
            {
                ShowMessage("请选择要禁用的货位！");
                return;
            }
            this.presenter.SetGsStatus(this.storageControl1.selectPositions.GoodsSiteID, false);
            if (this.tscb_Rowth.Text == "")
            { return; }
            int queryRow = int.Parse(this.tscb_Rowth.Text);
            this.presenter.RefreshPos(this.tscb_StoreHouseName.Text, queryRow);
        }
        private void tsb_UnuseGs_Click(object sender, EventArgs e)
        {
            UnUserGs();
        }
        private void UseGs()
        {
            if (PoupAskmes("您确定要启用当前选中的货位么？") != 1)
            {
                return;
            }
            if (null == this.storageControl1.selectPositions)
            {
                ShowMessage("请选择要启用的货位！");
                return;
            }
            this.presenter.SetGsStatus(this.storageControl1.selectPositions.GoodsSiteID, true);
            if (this.tscb_Rowth.Text == "")
            { return; }
            int queryRow = int.Parse(this.tscb_Rowth.Text);
            this.presenter.RefreshPos(this.tscb_StoreHouseName.Text, queryRow);
        }

        private void tsb_UsrGs_Click(object sender, EventArgs e)
        {
            if (this.parentPNP.RoleID > 2)
            {
                MessageBox.Show("当前用户没有此功能的操作权限！", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            UseGs();
        }

        private void tsb_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void ModifyGsStatus()
        {
            if (this.storageControl1.selectPositions == null)
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

                long gsID = this.storageControl1.selectPositions.GoodsSiteID;
                this.presenter.ModifyGsStatus(this.tscb_StoreHouseName.Text, gsID, egsv.GSStatus, egsv.GSTaskStatus);

            }
        }
        private void tsb_GsStatusModify_Click(object sender, EventArgs e)
        {
            if (this.parentPNP.RoleID > 1)
            {
                MessageBox.Show("当前用户没有此功能的操作权限！", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            ModifyGsStatus();
        }
        private void OutputManual()
        {
            if (this.storageControl1.selectPositions == null)
            {
                MessageBox.Show("请选中要要修改的货位！", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (PoupAskmes("您确定要手动出库选中货位么？") != 1)
            {
                return;
            }
            long gsID = this.storageControl1.selectPositions.GoodsSiteID;
            this.presenter.OutputManual(gsID);
        }
        private void cms_outputManual_Click(object sender, EventArgs e)
        {
            if (this.parentPNP.RoleID > 2)
            {
                MessageBox.Show("当前用户没有此功能的操作权限！", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            OutputManual();
        }

        private void tsmi_ModifyStatus_Click(object sender, EventArgs e)
        {
            if (this.parentPNP.RoleID > 1)
            {
                MessageBox.Show("当前用户没有此功能的操作权限！", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            ModifyGsStatus();
        }

        private void tsmi_UnUseGs_Click(object sender, EventArgs e)
        {
            if (this.parentPNP.RoleID > 2)
            {
                MessageBox.Show("当前用户没有此功能的操作权限！", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            UnUserGs();
        }

        private void tsmi_UseGs_Click(object sender, EventArgs e)
        {
            if (this.parentPNP.RoleID > 2)
            {
                MessageBox.Show("当前用户没有此功能的操作权限！", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            UseGs();
        }

        private void tsmi_Refresh_Click(object sender, EventArgs e)
        {
            RefreshData();
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
        private void RegisterInnerForm()
        {
            innerForm = new MoveHouseManulView(this.presenter);
            //this.gb_Model.Text = expandForm.Text;
            innerForm.TopLevel = false;
            innerForm.Visible = true;//默认不显示
            innerForm.Dock = DockStyle.Fill;
            innerForm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.splitContainer2.SplitterDistance = this.splitContainer1.Height;
            this.pl_InnerParent.Controls.Add(innerForm);
        }
        public void RegisterExtForm(Form expandForm)
        {
            if (expandForm == null)
            {
                return;
            }
            //  this.pl_ExterProParent.Controls.Clear();
            this.expandForm = expandForm;
            this.gb_Model.Text = expandForm.Text;
            expandForm.TopLevel = false;
            expandForm.Visible = true;//默认不显示
            expandForm.Dock = DockStyle.Fill;
            expandForm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.pl_ExterProParent.Controls.Add(expandForm);
            //expandForm.Show();
        }
        public void ShowExtForm(ExtendFormCate formCate)
        {
            //for (int i = 0; i < this.pl_ExterProParent.Controls.Count; i++)
            //{
            //    Form fm = (Form)this.pl_ExterProParent.Controls[i];
            //    if (fm == null)
            //    {
            //        continue;
            //    }
            //    fm.Visible = false;
            //}
            if (formCate == ExtendFormCate.外部)
            {
                if (expandForm == null)
                {
                    return;
                }
                this.expandForm.Visible = true;
                this.expandForm.Show();
                this.gb_Model.Text = this.expandForm.Text;
            }
            else
            {
                if (this.innerForm == null)
                {
                    return;
                }
                this.innerForm.Visible = true;
                this.innerForm.Show();
                this.gb_Model.Text = this.innerForm.Text;

            }
        }
  
        private void button1_Click(object sender, EventArgs e)
        {
            //string str = "";
            //CellCoordModel cell = new CellCoordModel(1, 3, 5);
            ////this.iStorageManage.UpdateGsEnabledStatus("A库房", cell, EnumGSEnabledStatus.启用, ref str);
            //this.iStorageManage.UpdateGsStatus("A库房", cell, EnumCellStatus.满位, ref str);
            this.iStorageManage.EventCellClicked += ShowCellExpandEventHandler;
          
        }
        private void ShowCellExpandEventHandler(object sender,CellPositionEventArgs e)
        {
            EditGSStaView egssv = new EditGSStaView();
            ExpandFormEventArgs efea = new ExpandFormEventArgs();
            efea.ExpandForm = egssv;
           // this.iStorageManage.EventStorageViewAddExpandForm.Invoke(this, efea);
        }
        private void tsmi_DeleteStockList_Click(object sender, EventArgs e)
        {
            if (this.parentPNP.RoleID > 2)
            {
                MessageBox.Show("当前用户没有此功能的操作权限！", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (this.dgv_GoodsSiteDetail.CurrentRow == null)
            {
                return;
            }
            if (this.dgv_GoodsSiteDetail.SelectedRows.Count == 0)
            {
                MessageBox.Show("请选中要出库的库存！", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (PoupAskmes("您确定要删除选中货位信息么？") != 1)
            {
                return;
            }
            int currRow = this.dgv_GoodsSiteDetail.CurrentRow.Index;
            string gsDetailID = this.dgv_GoodsSiteDetail.Rows[currRow].Cells["StockListID"].Value.ToString();
            this.presenter.DeleteStockList(long.Parse(gsDetailID),currRow);
        }

        public void DeleteStockListRow(int index)
        {
            if(this.dgv_GoodsSiteDetail.Rows.Count>index)
            {
                this.dgv_GoodsSiteDetail.Rows.RemoveAt(index);
            }
        }

        private void tsmi_AddStockList_Click(object sender, EventArgs e)
        {
            if (this.parentPNP.RoleID > 2)
            {
                MessageBox.Show("当前用户没有此功能的操作权限！", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            } 
            if (this.storageControl1.selectPositions == null)
            {
                return;
            }
            
            AddStockListView aslv = new AddStockListView();
            aslv.ShowDialog();
            if (aslv.IsSure == true)
            {
                this.presenter.AddStockList(this.storageControl1.selectPositions.GoodsSiteID, aslv.StockListStr);
            }
        }

        private void tsb_MultiUseFobit_Click(object sender, EventArgs e)
        {
            if (this.parentPNP.RoleID > 2)
            {
                MessageBox.Show("当前用户没有此功能的操作权限！", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            List<string> layerList = new List<string>();
            List<string> colList = new List<string>();

            for (int i = 0; i < this.tscb_Layerth.Items.Count; i++)
            {
                layerList.Add(this.tscb_Layerth.Items[i].ToString());
            }
            for (int i = 0; i < this.tscb_Columnth.Items.Count; i++)
            {
                colList.Add(this.tscb_Columnth.Items[i].ToString());
            }
            int rowth = int.Parse(this.tscb_Rowth.Text);
            MultiGsEnabledSet mges = new MultiGsEnabledSet(this.tscb_StoreHouseName.Text, rowth, this.presenter, colList, layerList);
            mges.ShowDialog();
            //if (mges.IsModify == true)
            //{
            //    RefreshData();//刷新数据
            //}
        }

        private void tsmi_Property_Click(object sender, EventArgs e)
        {
            if (this.parentPNP.RoleID > 2)
            {
                MessageBox.Show("当前用户没有此功能的操作权限！", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
           if( this.storageControl1.selectPositions== null)
           {
               return;
           }
           this.splitContainer1.Panel2Collapsed = false;
           this.presenter.OnCellExpandPro(this.storageControl1.selectPositions);
        }

        private void bt_CloseExpandView_Click(object sender, EventArgs e)
        {
            this.splitContainer1.Panel2Collapsed = true;
        }

        private void tsmi_StartPos_Click(object sender, EventArgs e)
        {
            if (this.parentPNP.RoleID > 1)
            {
                MessageBox.Show("当前用户没有此功能的操作权限！", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            innerForm.Visible = true;
            this.splitContainer1.Panel2Collapsed = false;
            Positions pos = this.storageControl1.selectPositions;
            if (pos == null)
            {
                return;
            }
  
            this.innerForm.StartGsHouseName = this.tscb_StoreHouseName.Text;

            if (CheckMoveHouse() == false)
            {
                MessageBox.Show("移库只能在同一个库房内操作！", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

                return;
            }
            this.innerForm.StartGsPos = new CellCoordModel(int.Parse(tscb_Rowth.Text), pos.Columnth, pos.Layer); ;
          
        }

        private void tsmi_EndPos_Click(object sender, EventArgs e)
        {
            if (this.parentPNP.RoleID > 1)
            {
                MessageBox.Show("当前用户没有此功能的操作权限！", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (this.storageControl1.selectPositions == null)
            {
                return;
            }
            innerForm.Visible = true;
            Positions pos = this.storageControl1.selectPositions;
            if(pos == null)
            {
                return;
            }
           
    
            this.innerForm.EndGsHouseName = this.tscb_StoreHouseName.Text;

           if(CheckMoveHouse() == false)
           {
               MessageBox.Show("移库只能在同一个库房内操作！", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
              
               return;
           }
            this.innerForm.EndGsPos = new CellCoordModel(int.Parse(tscb_Rowth.Text), pos.Columnth, pos.Layer); 
          
        }
        private bool CheckMoveHouse()
        {
            if (this.innerForm.StartGsHouseName !=null && this.innerForm.EndGsHouseName != null)
            {
                if (this.innerForm.StartGsHouseName != this.innerForm.EndGsHouseName)
                {
                    return false;
                }
            }
            return true;
        }
        
        private void bt_InnerExpend_Click(object sender, EventArgs e)
        {
            this.splitContainer2.SplitterDistance = this.splitContainer1.Height;
            if(this.innerForm!= null)
            {
                this.gb_Model.Text = this.innerForm.Text;
            }
         
        }

        private void bt_InnerShrink_Click(object sender, EventArgs e)
        {
            this.splitContainer2.SplitterDistance =0;
            if(this.expandForm!= null)
            {
                this.gb_Model.Text = this.expandForm.Text;
            }

        }

        private void tsb_LogicAreaColorSet_Click(object sender, EventArgs e)
        {
            if (this.parentPNP.RoleID > 2)
            {
                MessageBox.Show("当前用户没有此功能的操作权限！", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            LogicAreaColorSet mges = new LogicAreaColorSet(this.presenter);
            mges.ShowDialog();
        }

        private void tsmi_ModifyCode_Click(object sender, EventArgs e)
        {
            if (this.parentPNP.RoleID > 2)
            {
                MessageBox.Show("当前用户没有此功能的操作权限！", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (this.storageControl1.selectPositions == null)
            {
                return;
            }

            AddStockListView aslv = new AddStockListView();
          
            int currRow = this.dgv_GoodsSiteDetail.CurrentRow.Index;
            string code = this.dgv_GoodsSiteDetail.Rows[currRow].Cells["TrayID"].Value.ToString();
            string stockListID = this.dgv_GoodsSiteDetail.Rows[currRow].Cells["StockListID"].Value.ToString();
         
            aslv.SetCode(code);
            aslv.ShowDialog();
            if (aslv.IsSure == true)
            {
                this.presenter.ModifyStockCode(long.Parse(stockListID), this.storageControl1.selectPositions.GoodsSiteID, aslv.StockListStr.Trim());
            }
        }

     
 
     

    }
}
