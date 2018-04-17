using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ModuleCrossPnP;
using DevAccess;
namespace ProductRecordView
{
    public partial class HkTestForm : BaseChildView
    {
        private HKAccess hkAccess = new HKAccess();
        private OcvAccess ocvAccess = null;
        int batterySum=0;
        public OcvAccess OcvAccess { get { return ocvAccess; } set { ocvAccess = value; } }
        public HkTestForm(string captionText)
            : base(captionText)
        {
            InitializeComponent();
            this.Text = captionText;
           // string ocvDBConn = "Data Source = 192.168.100.20;Initial Catalog=SRANCH;User ID=L_Guest;Password=Guest@123;";
          //  ocvAccess = new OcvAccess(ocvDBConn,36);
          //  this.textBox5.Text = ocvDBConn;
        }
        private void OnInit()
        {
            try
            {
              
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {

            OnInit();
            
        }

        private void buttonConn_Click(object sender, EventArgs e)
        {
            string reStr = "";
            if(hkAccess.Conn(ref reStr))
            {
                Console.WriteLine("杭可装载服务器连接成功");
            }
            else
            {
                Console.WriteLine("杭可装载服务器连接失败");
            }
        }

        private void buttonDisconn_Click(object sender, EventArgs e)
        {
            string reStr = "";
            if(hkAccess.Disconn(ref reStr))
            {
                Console.WriteLine("杭可装载服务器断开成功");
            }
            else
            {
                Console.WriteLine("杭可装载服务器断开失败");
            }
        }
        private void HkTestForm_Load(object sender, EventArgs e)
        {
            OnInit();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            
        }
        private void textBox3_KeyDown(object sender, KeyEventArgs e)
        {
           // Console.WriteLine("key down：" + e.KeyCode.ToString());
        }

        private void HkTestForm_KeyDown(object sender, KeyEventArgs e)
        {
           // Console.WriteLine("key down：" + e.KeyCode.ToString());
        }

        private void OnQueryOCV()
        {
            this.dataGridView1.DataSource = null;
            this.dataGridView2.DataSource = null;
           // ocvAccess.ocvDBConn = this.textBox5.Text;
            string palletID = this.textBox4.Text;
            if(string.IsNullOrWhiteSpace(palletID))
            {
                Console.WriteLine("托盘号为空!");
                return;
            }
            List<int> testSeqIDS = new List<int>();
            if(this.checkBox2.Checked)
            {
                testSeqIDS.Add(1);
            }
            if (this.checkBox3.Checked)
            {
                testSeqIDS.Add(2);
            }
            if (this.checkBox4.Checked)
            {
                testSeqIDS.Add(3);
            }
            if (this.checkBox5.Checked)
            {
                testSeqIDS.Add(4);
            }
            if (this.checkBox6.Checked)
            {
                testSeqIDS.Add(5);
            }
            string reStr="";
            DataTable dt = ocvAccess.GetOcvTestDt(palletID,ref reStr);
            if(dt == null)
            {
                Console.WriteLine("无结果"+reStr);
                return;
            }
            else
            {
                this.dataGridView1.DataSource = dt;
            }
            DataTable dtChannel = new DataTable("通道测试结果");
            dtChannel.Columns.Add("通道号");
            dtChannel.Columns.Add("测试结果");
            List<int> reVals = new List<int>();
            if(ocvAccess.GetCheckResult(palletID,testSeqIDS,ref reVals,ref reStr))
            {
                for(int i=0;i<reVals.Count();i++)
                {
                    string val = "合格";
                    if(reVals[i] == 1)
                    {
                        val="合格";
                    }
                    else if(reVals[i] == 2)
                    {
                        val="异常";
                    }
                    else
                    {
                        val="空";
                    }
                    dtChannel.Rows.Add(new string[] { (i + 1).ToString(), val });
                }
                this.dataGridView2.DataSource = dtChannel;
            }
            else
            {
                Console.WriteLine("错误"+reStr);
            }
           
        }
        private void button5_Click(object sender, EventArgs e)
        {
            OnQueryOCV();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(this.checkBox1.Checked)
            {
                this.checkBox2.Checked = true;
                this.checkBox3.Checked = true;
                this.checkBox4.Checked = true;
                this.checkBox5.Checked = true;
                this.checkBox6.Checked = true;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            //string str = "3444fef\n\t  ";
            //Console.WriteLine(str);
            //Console.WriteLine(str.Length.ToString());
            //str = str.Trim(new char[] { '\r', '\n', '\t', ' ' });
            //Console.WriteLine(str);
            //Console.WriteLine(str.Length.ToString());
            //try
            //{
            //    List<byte> buf = new List<byte>();
            //    buf.Add(1);
            //    for (int i = 0; i < 10; i++)
            //    {
            //        buf.RemoveAt(0);
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
            
        }
    }
}
