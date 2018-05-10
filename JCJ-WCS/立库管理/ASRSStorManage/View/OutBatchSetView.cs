using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ASRSStorManage.Presenter;
using AsrsStorDBAcc.Model;
namespace ASRSStorManage.View
{
    public partial class OutBatchSetView : UserControl
    {
        OutBatchSetPresenter presenter;
        public OutBatchSetView()
        {
            InitializeComponent();
            this.presenter = new OutBatchSetPresenter();

        }
        private void OutBatchSetView_Load(object sender, EventArgs e)
        {
            IniHouse();
            IniBatchSet();
        }
        private void IniHouse()
        {
            List<StoreHouseModel> houseList = this.presenter.GetStoreHouse();
            this.cb_House.DataSource = houseList;
            this.cb_House.DisplayMember = "StoreHouseName"; 
            this.cb_House.ValueMember = "StoreHouseID";
            if(this.cb_House.Items.Count>0)
            {
                this.cb_House.SelectedIndex = 0;
            }
           
        }
        private void IniHouseArea(List<StoreHouseLogicAreaModel> logicAreaList)
        {
            this.cb_HouseArea.DataSource = logicAreaList;
            this.cb_HouseArea.DisplayMember = "StoreHouseAreaName";
            this.cb_HouseArea.ValueMember = "StoreHouseLogicAreaID";
            if (this.cb_HouseArea.Items.Count>0)
            {
                this.cb_HouseArea.SelectedIndex = 0;
            }
            
        }
        private void IniBatchSet()
        {
            this.dgv_OutBatchSet.Rows.Clear();
            List<View_OutHouseBatchSetModel> batches = this.presenter.GetBatchSet();

            if(batches == null)
            {
                return;
            }
            for(int i=0;i<batches.Count;i++)
            {
                this.dgv_OutBatchSet.Rows.Add();
                this.dgv_OutBatchSet.Rows[i].Cells["Col_House"].Value = batches[i].StoreHouseName;
                this.dgv_OutBatchSet.Rows[i].Cells["col_HouseArea"].Value = batches[i].StoreHouseAreaName;
                this.dgv_OutBatchSet.Rows[i].Cells["col_OutBatch"].Value = batches[i].Batch;
            }
        }
        private void IniBatch(List<string> batches)
        {
            this.cb_batch.Items.Clear();
            this.cb_batch.Items.Add("空");
            for(int i=0;i<batches.Count;i++)
            {
                this.cb_batch.Items.Add(batches[i]);
            }
          
            this.cb_batch.Items.Add("所有");
            this.cb_batch.SelectedIndex = 0;
        }

        private void cb_House_SelectedIndexChanged(object sender, EventArgs e)
        {
            long houseID = ((StoreHouseModel)this.cb_House.SelectedItem).StoreHouseID;
            List<StoreHouseLogicAreaModel> areaList = this.presenter.GetHouseAreaList(houseID);
            if(areaList != null && areaList.Count()>0)
            {
                IniHouseArea(areaList);
            }
        }

        private void cb_HouseArea_SelectedIndexChanged(object sender, EventArgs e)
        {
            long houseID = ((StoreHouseModel)this.cb_House.SelectedItem).StoreHouseID;
            long houseAreaID = ((StoreHouseLogicAreaModel)this.cb_HouseArea.SelectedItem).StoreHouseLogicAreaID;
            List<string> batches = this.presenter.GetBatch(houseID, houseAreaID);
            IniBatch(batches);
        }

        private void bt_OutBatchSet_Click(object sender, EventArgs e)
        {
            long houseID = ((StoreHouseModel)this.cb_House.SelectedItem).StoreHouseID;
            long houseAreaID = ((StoreHouseLogicAreaModel)this.cb_HouseArea.SelectedItem).StoreHouseLogicAreaID;
            string batch = this.cb_batch.Text.Trim();
            this.presenter.SetBatch(houseID, houseAreaID, batch);
            IniBatchSet();
        }

    }
}
