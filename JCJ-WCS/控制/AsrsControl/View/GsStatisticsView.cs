using AsrsInterface;
using AsrsModel;
using ModuleCrossPnP;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AsrsControl
{
    public partial class GsStatisticsView : BaseChildView,IGsStatisticsView
    {
        private GsStatisticsPresenter presenter = null;
        public GsStatisticsView(string captionText):base(captionText)
        {
            InitializeComponent();
            this.Text = captionText;
            this.presenter = new GsStatisticsPresenter(this);
            IniView();
        }
        public void SetAsrsResManage(IAsrsManageToCtl asrsResManage)
        {
            this.presenter.SetAsrsResManage(asrsResManage);
        }
        public void RefreshGs(DataTable dt)
        {
            this.dgv_GsSta.DataSource = dt;
            this.dgv_GsSta.Columns["操作时间"].DefaultCellStyle.Format = "yyyy-MM-dd HH:mm:ss";
            this.dgv_GsSta.Columns["操作时间"].SortMode = DataGridViewColumnSortMode.Automatic;
            this.dgv_GsSta.Sort(this.dgv_GsSta.Columns["操作时间"], ListSortDirection.Ascending);
        }
        public void ShowStatistics(string num)
        {
            if (this.cb_GsOperate.Text == "所有")
            {
                this.lb_OperateGsType.Text = "出入库及待出库统计";
            }
            else
            {
                this.lb_OperateGsType.Text = this.cb_GsOperate.Text+"统计";
            }
           
            this.lb_GsOperateNum.Text = num;
        }
        private void ClearDgvData()
        {
            this.dgv_GsSta.DataSource = null;
        }
        private void ClearStatistics()
        {
            this.lb_OperateGsType.Text = "出入库统计";
            this.lb_GsOperateNum.Text = "0";
        }
        private void IniView()
        {
            IniHouseName();
            IniHouseArea();
            IniGsOperate();
         
            this.dtp_start.Value = DateTime.Now.Date + new TimeSpan(8, 0, 0);
            this.dtp_end.Value = DateTime.Now.Date + new TimeSpan(20,0,0);
        }
        private void IniHouseArea()
        {

            this.cb_HouseArea.Items.Clear();
            this.cb_HouseArea.Items.Add("所有");
           // for (int i = 0; i < Enum.GetNames(typeof(EnumLogicArea)).Count(); i++)
            for (int i = 0; i < SysCfg.SysCfgModel.AsrsAreaList.Count(); i++)
            {
                string houseName = SysCfg.SysCfgModel.AsrsAreaList[i];//Enum.GetNames(typeof(EnumLogicArea))[i];
                this.cb_HouseArea.Items.Add(houseName);
            }
            if (this.cb_HouseArea.Items.Count > 0)
            {
                this.cb_HouseArea.SelectedIndex = 0;
            }
        }
      
        private void IniHouseName()
        {
            this.cb_HouseName.Items.Clear();
            this.cb_HouseName.Items.Add("所有");
            //for (int i = 0; i < Enum.GetNames(typeof(EnumStoreHouse)).Count(); i++)
            for (int i = 0; i <SysCfg.SysCfgModel.AsrsHouseList.Count(); i++)
            {
                string houseName = SysCfg.SysCfgModel.AsrsHouseList[i];
                this.cb_HouseName.Items.Add(houseName);
            }
            if (this.cb_HouseName.Items.Count > 0)
            {
                this.cb_HouseName.SelectedIndex = 0;
            }

        }
        private void IniGsOperate()
        {
            this.cb_GsOperate.Items.Clear();
            this.cb_GsOperate.Items.Add("所有");
            this.cb_GsOperate.Items.Add(SysCfg.EnumAsrsTaskType.产品出库.ToString());
            this.cb_GsOperate.Items.Add(SysCfg.EnumAsrsTaskType.产品入库.ToString());
            this.cb_GsOperate.Items.Add(GsStatisticsPresenter.WAITOUTPRODUCT);
            this.cb_GsOperate.SelectedIndex = 0;
        }

        private void bt_Query_Click(object sender, EventArgs e)
        {
            ClearDgvData();
            ClearStatistics();
            if(this.cb_HouseArea.Text != "所有"&&this.cb_HouseName.Text=="所有")
            {
                MessageBox.Show("请选择指定库房！", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            this.presenter.QueryStatistics(this.dtp_start.Value, this.dtp_end.Value, this.cb_HouseName.Text, this.cb_HouseArea.Text, this.textBox_GsName.Text, this.cb_GsOperate.Text);
        }

      
    }
}
