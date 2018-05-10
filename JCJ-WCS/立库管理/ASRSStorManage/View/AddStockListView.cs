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
    public partial class AddStockListView : Form
    {
        public bool IsSure { get; set; }
        public string StockListStr { get; set; }
        public AddStockListView()
        {
            InitializeComponent();
        }
        public void SetCode(string code)
        {
            this.tb_StockListStr.Text = code;
        }

        private void bt_Sure_Click(object sender, EventArgs e)
        {
            this.IsSure = true;
            this.StockListStr = this.tb_StockListStr.Text;
            this.Close();
        }

        private void bt_cancel_Click(object sender, EventArgs e)
        {
            this.IsSure = false;
            this.Close();
        }
    }
}
