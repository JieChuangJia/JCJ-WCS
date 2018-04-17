using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MonitorViews
{
    public partial class ClosingWaitDlg : Form
    {
        private int timeOut = 25;
        private int timerInterval = 1000;
        private int counter = 0;
        public ClosingWaitDlg()
        {
            InitializeComponent();
            this.timer1.Interval = timerInterval;

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            int max = timeOut * 1000 / timerInterval;
            counter++;
            int left = max - counter;
            this.label2.Text = left.ToString();
            if(left<1)
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        //private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        //{
        //    this.linkLabel1.Links[0].LinkData = this.linkLabel1.Text;
        //    System.Diagnostics.Process.Start(e.Link.LinkData.ToString());    
        //}

        private void WelcomeDlg_Load(object sender, EventArgs e)
        {
             int max = timeOut * 1000 / timerInterval;
             this.label2.Text = max.ToString();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
