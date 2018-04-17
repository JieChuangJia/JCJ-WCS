using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AsrsControl
{
    
    public partial class AsrsStatUserCtl : UserControl
    {
        private StatItem[] asrsStatItems = null;
        public string ID { get; set; }
        public AsrsStatUserCtl()
        {
            InitializeComponent();
        }
        public void UpdateAsrsStat(StatItem[] statItems)
        {
            //asrsStatItems = statItems;
            //this.flowLayoutPanel1.Controls.Clear();
            //foreach(StatItem item in statItems)
            //{
            //    Label itemLabel = new Label();
            //    itemLabel.Text = item.statDesc;
            //    itemLabel.BackColor = item.bkgColor;
            //    itemLabel.AutoSize = false;
            //    this.flowLayoutPanel1.Controls.Add(itemLabel);
            //}
            label1.Text = statItems[1].statDesc;
            label1.BackColor = statItems[1].bkgColor;
            label2.Text = statItems[0].statDesc;
            label2.BackColor = statItems[0].bkgColor;
            label3.Text = statItems[2].statDesc;
            label3.BackColor = statItems[2].bkgColor;
        }
    }
    public class StatItem
    {
        public string statDesc = "";
        public Color bkgColor = Color.Transparent;

    }
}
