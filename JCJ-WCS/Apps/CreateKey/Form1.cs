using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using LicenceManager;

namespace CreateKey
{
    public partial class Form1 : Form
    {
        private static string licenceFilePath = AppDomain.CurrentDomain.BaseDirectory + @"\NAPLSlicense.lic";
        LicenceModel licenceModel = new LicenceModel("zzkeyFT1", licenceFilePath);
        public Form1()
        {
            InitializeComponent();
        }

        private void bt_CreateKey_Click(object sender, EventArgs e)
        {
            string desKeyStr = CreateKey(DateTime.Parse(this.dateTimePicker1.Value.ToString("yyyy-MM-dd HH:00:00")).ToString());
            this.tb_KeyTxt.Text = desKeyStr;
        }

        private string CreateKey(string dateTimeStr)
        {
            string desKeyStr = "";
            licenceModel.Encrypt(dateTimeStr,ref desKeyStr);
           
            return desKeyStr;
        }

        private void bt_createLicenceFile_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = ".lic|*.lic";
            if (saveFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                licenceModel.LastRunTime = CreateKey(DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd HH:00:00")).ToString());
                string timeLimit = "yyyy-MM-dd "+this.textBoxTime.Text;//:00:00";
                licenceModel.LicenceEndTime = CreateKey(DateTime.Parse(this.dateTimePicker1.Value.ToString(timeLimit)).ToString());
                licenceModel.CreateLicenceFile(saveFileDialog.FileName);
                MessageBox.Show("文件生成成功！", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void bt_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bt_readEndDate_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openFile = new OpenFileDialog();
                openFile.Filter = ".lic|*.lic";
                if (openFile.ShowDialog() == DialogResult.OK)
                {
                    LicenceModel licenceModelTemp = this.licenceModel.LoadLicence(openFile.FileName);
                    string endDate = licenceModelTemp.Decrypt(licenceModelTemp.LicenceEndTime);
                    DateTime dt = DateTime.Parse(endDate);
                    this.dateTimePicker1.Value = dt;
                    this.textBoxTime.Text = dt.ToString("HH:mm");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("读取授权文件失败！"+ex.Message, "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void buttonEntry_Click(object sender, EventArgs e)
        {
            LicenceModel licenseModel = new LicenceModel(this.textBoxKey.Text, null);
            string strEntry = "";
            if (licenseModel.Encrypt(this.richTextBox1.Text, ref strEntry))
            {
                this.richTextBox2.Text = strEntry;
            }
            else
            {
                MessageBox.Show("加密失败");
            }
        }
            

        private void buttonDes_Click(object sender, EventArgs e)
        {
            LicenceModel licenseModel = new LicenceModel(this.textBoxKey.Text, null);
            string strDec = licenseModel.Decrypt(this.richTextBox2.Text);
            this.richTextBox1.Text = strDec;
            
        }
    }
}
