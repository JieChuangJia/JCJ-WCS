using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CtlMonitorInterface;
namespace MonitorViews
{
    
    public partial class DevConnMonitorView : UserControl
    {
        public ICommDevMonitor devCommMonitor { get; set; }
        private delegate void DlgtRefreshDev();
        private IDictionary<string, DevConnStat> devConnStatDic = null;
        public DevConnMonitorView()
        {
            InitializeComponent();
        }
        public void InitDevDic(IDictionary<string,DevConnStat> devConnDic)
        {
            devConnStatDic = devConnDic;
            this.tableLayoutPanel7.RowStyles.Clear();
            this.tableLayoutPanel7.RowCount = devConnDic.Count()+1;
            int rowIndex = 0;
            foreach(string strKey in devConnDic.Keys)
            {
                DevConnStat devStat = devConnDic[strKey];
           
                Label labelTemp = new System.Windows.Forms.Label();
                labelTemp.AutoSize = true;
                labelTemp.Dock = DockStyle.Fill;
                labelTemp.Location = new System.Drawing.Point(4, 1);
                labelTemp.Name = devStat.devID;
                labelTemp.Size = new System.Drawing.Size(62, 18);
                labelTemp.TabIndex = 0;
                labelTemp.Text = devStat.devName;
                this.tableLayoutPanel7.Controls.Add(labelTemp,0 ,rowIndex);

                System.Windows.Forms.PictureBox picBox = new PictureBox();
                picBox.BackColor = System.Drawing.Color.Red;
                picBox.Dock = System.Windows.Forms.DockStyle.Fill;
               
                picBox.Name = "PIC"+devStat.devID;
                picBox.Size = new System.Drawing.Size(61, 45);
                this.tableLayoutPanel7.Controls.Add(picBox, 1,rowIndex);
                this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
                rowIndex++;
            }
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50));

        }
        public void RefreshDevDic()
        {
            try
            {
                if (this.tableLayoutPanel7.InvokeRequired)
                {
                    DlgtRefreshDev dlgt = new DlgtRefreshDev(RefreshDevDic);
                    this.Invoke(dlgt, null);
                }
                else
                {
                    devConnStatDic = devCommMonitor.GetPLCConnStatDic();
                    foreach (string strKey in devConnStatDic.Keys)
                    {
                        DevConnStat devConn = devConnStatDic[strKey];
                        PictureBox pic = this.tableLayoutPanel7.Controls["PIC" + devConn.devID] as PictureBox;

                        if (devConn.connStat == 1)
                        {
                            pic.BackColor = Color.Green;
                        }
                        else
                        {
                            pic.BackColor = Color.Red;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("刷新PLC通信状态，发生异常：" + ex.Message);
            }
          
        }
    }
  
}
