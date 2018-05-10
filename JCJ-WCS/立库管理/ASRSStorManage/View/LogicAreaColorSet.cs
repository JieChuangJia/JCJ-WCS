using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ASRSStorManage.Presenter;
using AsrsModel;
namespace ASRSStorManage.View
{
    public partial class LogicAreaColorSet : Form
    {  
        StoragePresenter presenter=null;
        public LogicAreaColorSet(StoragePresenter presenter)
        {
            InitializeComponent();
            this.presenter = presenter;
          
            IniHouseAreaList();
        }

        private void bt_SelectColor_Click(object sender, EventArgs e)
        {
            this.colorDialog1.ShowDialog();
            this.pb_AreaColor.BackColor = this.colorDialog1.Color;
        }
        private void IniHouseAreaList()
        {
            this.cb_HouseArea.Items.Clear();
           // for (int i = 0; i < Enum.GetNames(typeof(EnumLogicArea)).Length; i++)
            for (int i = 0; i < SysCfg.SysCfgModel.AsrsAreaList.Count(); i++)
            {
                string areaName = SysCfg.SysCfgModel.AsrsAreaList[i];//Enum.GetNames(typeof(EnumLogicArea))[i];
                this.cb_HouseArea.Items.Add(areaName);
            }
            if (this.cb_HouseArea.Items.Count > 0)
            {
                this.cb_HouseArea.SelectedIndex = 0;
            }
        }
        private void bt_AreaSet_Click(object sender, EventArgs e)
        {
            string restr = "";
            bool status = this.presenter.SetAreaColorCfg(this.cb_HouseArea.Text, this.pb_AreaColor.BackColor, ref restr);
            if (status == true)
            {

                MessageBox.Show("设置成功", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
            {
                MessageBox.Show(restr, "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }

        private void bt_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
