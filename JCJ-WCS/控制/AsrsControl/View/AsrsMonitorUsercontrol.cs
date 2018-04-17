using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AsrsControl;
namespace AsrsControl.View
{
    public partial class AsrsMonitorUsercontrol : UserControl
    {
        private delegate void DelegateRefreshCommDevStatus();
        private AsrsCtlModel asrsCtl = null;
        public AsrsMonitorUsercontrol(AsrsCtlModel asrsCtl)
        {
            InitializeComponent();
            this.asrsCtl = asrsCtl;
            this.groupBox1.Text = asrsCtl.HouseName;
            this.timer1.Interval = 500;
        }
        public void StartMonitor()
        {
            this.timer1.Enabled = true;
        }
        public void StopMonitor()
        {
            this.timer1.Enabled = false;
        }

        private void btnWarnReset_Click(object sender, EventArgs e)
        {
            string reStr = "";
            if(!this.asrsCtl.StackDevice.ErrorReset(ref reStr))
            {
                MessageBox.Show(reStr);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                RefreshStackerStatus(); 
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
          
        }
        private void RefreshStackerStatus()
        {
            if (this.groupBox1.InvokeRequired)
            {
                DelegateRefreshCommDevStatus dlgt = new DelegateRefreshCommDevStatus(RefreshStackerStatus);
                this.Invoke(dlgt, null);
            }
            else
            {
                string[] status = null;
                int errCode1 = 0;
                asrsCtl.StackDevice.GetRunningStatus(ref errCode1, ref status);

                if (errCode1 == 0)
                {
                    this.label31.BackColor = Color.Transparent;
                }
                else
                {
                    this.label31.BackColor = Color.Red;
                }
                this.label31.Text = status[0];
                this.label32.Text = status[1];
                this.label33.Text = status[2];
                this.Refresh();

            }
        }
    }
}
