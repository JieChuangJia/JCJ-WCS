using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LogManage
{
    public partial class WaitDlg : Form
    {
        public bool Finished { get; set; }
        public int ProgressPercent { get; set; }
        public WaitDlg()
        {
            InitializeComponent();
            Finished = false;
            ProgressPercent = 0;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.progressBar1.Value = ProgressPercent;
            this.label2.Text = string.Format("{0}%",ProgressPercent);
            if(Finished)
            {
                this.Close();

            }
        }

        private void WaitDlg_Load(object sender, EventArgs e)
        {
            this.timer1.Interval = 100;
            this.timer1.Start();
        }
    }
}
