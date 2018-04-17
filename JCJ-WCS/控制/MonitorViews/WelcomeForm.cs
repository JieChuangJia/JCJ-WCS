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
    public partial class WelcomeForm : Form
    {
        private delegate void DlgtDisp(string s);
        private delegate void DlgtCloseWnd();
        public WelcomeForm()
        {
            InitializeComponent();
        }
        public void CloseDisp()
        {
            if(this.InvokeRequired)
            {
                DlgtCloseWnd dlgt = new DlgtCloseWnd(CloseDisp);
                this.Invoke(dlgt, null);
            }
            else
            {
                this.Close();
            }
           
        }
        public void AddDispContent(string cont)
        {
            if(this.listBox1.InvokeRequired)
            {
                DlgtDisp dlgt = new DlgtDisp(AddDispContent);
                this.Invoke(dlgt, new object[] { cont });
               
            }
            else
            {
                this.listBox1.Items.Add(cont);
            }
            //Func<string> dlgtAdd = delegate(string s)
            //{ this.listBox1.Items.Add(s); };
            //dlgtAdd(cont);
            //this.listBox1.Items.Add(cont);
        }
        public void DispCurrentInfo(string curInfo)
        {
            if(this.label2.InvokeRequired)
            {
                DlgtDisp dlgt = new DlgtDisp(DispCurrentInfo);
                this.Invoke(dlgt, new object[] { curInfo });
            }
            else
            {
                this.label2.Text = curInfo;
            }
           
        }
    }
}
