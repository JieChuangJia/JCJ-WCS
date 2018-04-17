namespace CreateKey
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.bt_CreateKey = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tb_KeyTxt = new System.Windows.Forms.TextBox();
            this.bt_Cancel = new System.Windows.Forms.Button();
            this.bt_createLicenceFile = new System.Windows.Forms.Button();
            this.bt_readEndDate = new System.Windows.Forms.Button();
            this.textBoxTime = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxKey = new System.Windows.Forms.TextBox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.richTextBox2 = new System.Windows.Forms.RichTextBox();
            this.buttonEntry = new System.Windows.Forms.Button();
            this.buttonDes = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(154, 13);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(155, 21);
            this.dateTimePicker1.TabIndex = 0;
            // 
            // bt_CreateKey
            // 
            this.bt_CreateKey.Location = new System.Drawing.Point(334, 148);
            this.bt_CreateKey.Name = "bt_CreateKey";
            this.bt_CreateKey.Size = new System.Drawing.Size(75, 20);
            this.bt_CreateKey.TabIndex = 1;
            this.bt_CreateKey.Text = "生成激活码";
            this.bt_CreateKey.UseVisualStyleBackColor = true;
            this.bt_CreateKey.Click += new System.EventHandler(this.bt_CreateKey_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(59, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "授权截止日期：";
            // 
            // tb_KeyTxt
            // 
            this.tb_KeyTxt.Location = new System.Drawing.Point(58, 39);
            this.tb_KeyTxt.Multiline = true;
            this.tb_KeyTxt.Name = "tb_KeyTxt";
            this.tb_KeyTxt.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tb_KeyTxt.Size = new System.Drawing.Size(467, 99);
            this.tb_KeyTxt.TabIndex = 3;
            // 
            // bt_Cancel
            // 
            this.bt_Cancel.Location = new System.Drawing.Point(418, 147);
            this.bt_Cancel.Name = "bt_Cancel";
            this.bt_Cancel.Size = new System.Drawing.Size(75, 23);
            this.bt_Cancel.TabIndex = 4;
            this.bt_Cancel.Text = "取消";
            this.bt_Cancel.UseVisualStyleBackColor = true;
            this.bt_Cancel.Click += new System.EventHandler(this.bt_Cancel_Click);
            // 
            // bt_createLicenceFile
            // 
            this.bt_createLicenceFile.Location = new System.Drawing.Point(209, 147);
            this.bt_createLicenceFile.Name = "bt_createLicenceFile";
            this.bt_createLicenceFile.Size = new System.Drawing.Size(116, 23);
            this.bt_createLicenceFile.TabIndex = 5;
            this.bt_createLicenceFile.Text = "生成License文件";
            this.bt_createLicenceFile.UseVisualStyleBackColor = true;
            this.bt_createLicenceFile.Click += new System.EventHandler(this.bt_createLicenceFile_Click);
            // 
            // bt_readEndDate
            // 
            this.bt_readEndDate.Location = new System.Drawing.Point(84, 147);
            this.bt_readEndDate.Name = "bt_readEndDate";
            this.bt_readEndDate.Size = new System.Drawing.Size(116, 23);
            this.bt_readEndDate.TabIndex = 6;
            this.bt_readEndDate.Text = "读license文件";
            this.bt_readEndDate.UseVisualStyleBackColor = true;
            this.bt_readEndDate.Click += new System.EventHandler(this.bt_readEndDate_Click);
            // 
            // textBoxTime
            // 
            this.textBoxTime.Location = new System.Drawing.Point(378, 12);
            this.textBoxTime.Name = "textBoxTime";
            this.textBoxTime.Size = new System.Drawing.Size(148, 21);
            this.textBoxTime.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(315, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 12);
            this.label2.TabIndex = 8;
            this.label2.Text = "HH(24):MM";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(749, 285);
            this.tabControl1.TabIndex = 9;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.panel1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(579, 191);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "授权";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.buttonDes);
            this.tabPage2.Controls.Add(this.buttonEntry);
            this.tabPage2.Controls.Add(this.richTextBox2);
            this.tabPage2.Controls.Add(this.richTextBox1);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.textBoxKey);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(741, 259);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "加密解密";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.dateTimePicker1);
            this.panel1.Controls.Add(this.textBoxTime);
            this.panel1.Controls.Add(this.bt_CreateKey);
            this.panel1.Controls.Add(this.bt_readEndDate);
            this.panel1.Controls.Add(this.tb_KeyTxt);
            this.panel1.Controls.Add(this.bt_createLicenceFile);
            this.panel1.Controls.Add(this.bt_Cancel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(573, 185);
            this.panel1.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(37, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 0;
            this.label3.Text = "密钥";
            // 
            // textBoxKey
            // 
            this.textBoxKey.Location = new System.Drawing.Point(39, 39);
            this.textBoxKey.Name = "textBoxKey";
            this.textBoxKey.Size = new System.Drawing.Size(100, 21);
            this.textBoxKey.TabIndex = 1;
            this.textBoxKey.Text = "zzkeyFT1";
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(206, 49);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(238, 134);
            this.richTextBox1.TabIndex = 2;
            this.richTextBox1.Text = "";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(204, 24);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 0;
            this.label4.Text = "原文";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(464, 24);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 12);
            this.label5.TabIndex = 0;
            this.label5.Text = "密文";
            // 
            // richTextBox2
            // 
            this.richTextBox2.Location = new System.Drawing.Point(466, 49);
            this.richTextBox2.Name = "richTextBox2";
            this.richTextBox2.Size = new System.Drawing.Size(238, 134);
            this.richTextBox2.TabIndex = 2;
            this.richTextBox2.Text = "";
            // 
            // buttonEntry
            // 
            this.buttonEntry.Location = new System.Drawing.Point(39, 84);
            this.buttonEntry.Name = "buttonEntry";
            this.buttonEntry.Size = new System.Drawing.Size(100, 34);
            this.buttonEntry.TabIndex = 3;
            this.buttonEntry.Text = "加密";
            this.buttonEntry.UseVisualStyleBackColor = true;
            this.buttonEntry.Click += new System.EventHandler(this.buttonEntry_Click);
            // 
            // buttonDes
            // 
            this.buttonDes.Location = new System.Drawing.Point(39, 129);
            this.buttonDes.Name = "buttonDes";
            this.buttonDes.Size = new System.Drawing.Size(100, 34);
            this.buttonDes.TabIndex = 3;
            this.buttonDes.Text = "解密";
            this.buttonDes.UseVisualStyleBackColor = true;
            this.buttonDes.Click += new System.EventHandler(this.buttonDes_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(749, 285);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "生成激活码";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Button bt_CreateKey;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tb_KeyTxt;
        private System.Windows.Forms.Button bt_Cancel;
        private System.Windows.Forms.Button bt_createLicenceFile;
        private System.Windows.Forms.Button bt_readEndDate;
        private System.Windows.Forms.TextBox textBoxTime;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button buttonDes;
        private System.Windows.Forms.Button buttonEntry;
        private System.Windows.Forms.RichTextBox richTextBox2;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxKey;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
    }
}

