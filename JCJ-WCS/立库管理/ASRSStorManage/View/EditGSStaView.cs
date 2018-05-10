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

namespace ASRSStorManage.View
{
    public partial class EditGSStaView : BaseChildView
    {
        public bool IsSure = false;
        public string GSStatus { get; set; }
        public string GSTaskStatus { get; set; }
        public EditGSStaView()
        {
            InitializeComponent();
        }

        private void EditGSStaView_Load(object sender, EventArgs e)
        {
            IniGSStatus();
            IniGSTaskStatus();
        }
        private void IniGSStatus()
        {
            this.cb_GSStatus.Items.Clear();
            
            for (int i = 0; i < Enum.GetNames(typeof(EnumCellStatus)).Count(); i++)
            {
                string houseName = Enum.GetNames(typeof(EnumCellStatus))[i];
                this.cb_GSStatus.Items.Add(houseName);
            }
            if (this.cb_GSStatus.Items.Count > 0)
            {
                this.cb_GSStatus.SelectedIndex = 0;
            }
        }

        private void IniGSTaskStatus()
        {
            this.cb_GSTaskType.Items.Clear();
           
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

        private void bt_Sure_Click(object sender, EventArgs e)
        {
            this.GSStatus = this.cb_GSStatus.Text;
            this.GSTaskStatus = this.cb_GSTaskType.Text;

            this.IsSure = true;
            this.Close();
        }

        private void bt_Cancel_Click(object sender, EventArgs e)
        {
            this.IsSure = false;
            this.Close();
        }

    }
}
