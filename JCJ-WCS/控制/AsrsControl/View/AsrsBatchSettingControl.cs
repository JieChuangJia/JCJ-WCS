using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AsrsInterface;
namespace AsrsControl.View
{
    public partial class AsrsBatchSettingControl : UserControl
    {
        private IAsrsManageToCtl asrsResourceManage = null; //立库管理层接口对象
        public AsrsBatchSettingControl()
        {
            InitializeComponent();
        }
        public void Init(IAsrsManageToCtl asrsResManage)
        {
            this.asrsResourceManage = asrsResManage;
            this.cb_HouseName.Items.AddRange(new string[] { "A1库房", "B1库房", "C1库房", "C2库房" });
            this.cb_HouseName.SelectedIndex = 0;
            OnRefreshBatchList();
            DispBatchSet();
        }
        private void bt_RefreshBatch_Click(object sender, EventArgs e)
        {
            OnRefreshBatchList();
        }
        private void OnRefreshBatchList()
        {
            //在库批次
            this.cb_CheckoutBatchs.Items.Clear();
            this.cb_CheckoutBatchs.Items.Add("空");
            List<string> storeBatchs = null;// presenter.GetStoreBatchs(this.cb_HouseName.Text);
            string houseName = this.cb_HouseName.Text;
         
            if (!this.asrsResourceManage.GetStockProductBatch(houseName, ref storeBatchs))
            {
                MessageBox.Show("获取批次列表失败");
                return;
            }
            if (storeBatchs != null && storeBatchs.Count() > 0)
            {
             
                foreach (string str in storeBatchs)
                {
                    if (string.IsNullOrWhiteSpace(str))
                    {
                        continue;
                    }
                    this.cb_CheckoutBatchs.Items.Add(str);
                }

                this.cb_CheckoutBatchs.SelectedIndex = 0;
            }
            this.cb_CheckoutBatchs.Items.Add("所有");
            //this.cb_CheckoutBatchs
            //BatchBll batchBll = new BatchBll();
            //List<BatchModel> batchList = batchBll.GetModelList(" ");

            //List<string> batchNames=new List<string>();
            //foreach(BatchModel batch in batchList)
            //{
            //    batchNames.Add(batch.batchName);
            //}
            //this.cb_CheckinBatchList.Items.Clear();
            //this.cb_CheckinBatchList.Items.Add("空");
            //this.cb_CheckinBatchList.Items.AddRange(batchNames.ToArray());
            //if (this.cb_CheckinBatchList.Items.Count>0)
            //{
            //    this.cb_CheckinBatchList.SelectedIndex = 0;
            //}

        }
        private void bt_BatchSet_Click(object sender, EventArgs e)
        {
            OnSetBatch();
        }
        private void OnSetBatch()
        {

            SysCfg.SysCfgModel.CheckoutBatchDic[this.cb_HouseName.Text] = this.cb_CheckoutBatchs.Text;
            DispBatchSet();
            string reStr = "";
            if (!SysCfg.SysCfgModel.SaveCfg(ref reStr))
            {
                MessageBox.Show("保存设置失败:" + reStr);
            }
        }
        private void DispBatchSet()
        {
            // this.lb_A1CheckInBatch.Text = SysCfgModel.CheckinBatchHouseA;
            this.lb_A1OutBatch.Text = SysCfg.SysCfgModel.CheckoutBatchDic["A1库房"];
            // this.lb_B1CheckinBatch.Text = SysCfgModel.CheckinBatchHouseB;
            this.lb_B1OutBatch.Text = SysCfg.SysCfgModel.CheckoutBatchDic["B1库房"];
            this.lb_C1OutBatch.Text = SysCfg.SysCfgModel.CheckoutBatchDic["C1库房"];
            this.lb_C2OutBatch.Text = SysCfg.SysCfgModel.CheckoutBatchDic["C2库房"];
        }

        private void cb_HouseName_SelectedIndexChanged(object sender, EventArgs e)
        {
            OnRefreshBatchList();

        }

    }
}
