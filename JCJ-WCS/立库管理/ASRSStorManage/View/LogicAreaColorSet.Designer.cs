namespace ASRSStorManage.View
{
    partial class LogicAreaColorSet
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pb_AreaColor = new System.Windows.Forms.PictureBox();
            this.bt_SelectColor = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.bt_AreaSet = new System.Windows.Forms.Button();
            this.cb_HouseArea = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.bt_Cancel = new System.Windows.Forms.Button();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            ((System.ComponentModel.ISupportInitialize)(this.pb_AreaColor)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pb_AreaColor
            // 
            this.pb_AreaColor.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.pb_AreaColor.Location = new System.Drawing.Point(134, 53);
            this.pb_AreaColor.Name = "pb_AreaColor";
            this.pb_AreaColor.Size = new System.Drawing.Size(63, 21);
            this.pb_AreaColor.TabIndex = 25;
            this.pb_AreaColor.TabStop = false;
            // 
            // bt_SelectColor
            // 
            this.bt_SelectColor.Location = new System.Drawing.Point(203, 53);
            this.bt_SelectColor.Name = "bt_SelectColor";
            this.bt_SelectColor.Size = new System.Drawing.Size(131, 22);
            this.bt_SelectColor.TabIndex = 24;
            this.bt_SelectColor.Text = "选择颜色";
            this.bt_SelectColor.UseVisualStyleBackColor = true;
            this.bt_SelectColor.Click += new System.EventHandler(this.bt_SelectColor_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(19, 58);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(101, 12);
            this.label6.TabIndex = 23;
            this.label6.Text = "货位逻辑库区颜色";
            // 
            // bt_AreaSet
            // 
            this.bt_AreaSet.Location = new System.Drawing.Point(225, 122);
            this.bt_AreaSet.Name = "bt_AreaSet";
            this.bt_AreaSet.Size = new System.Drawing.Size(68, 27);
            this.bt_AreaSet.TabIndex = 20;
            this.bt_AreaSet.Text = "设定";
            this.bt_AreaSet.UseVisualStyleBackColor = true;
            this.bt_AreaSet.Click += new System.EventHandler(this.bt_AreaSet_Click);
            // 
            // cb_HouseArea
            // 
            this.cb_HouseArea.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_HouseArea.FormattingEnabled = true;
            this.cb_HouseArea.Location = new System.Drawing.Point(134, 25);
            this.cb_HouseArea.Name = "cb_HouseArea";
            this.cb_HouseArea.Size = new System.Drawing.Size(199, 20);
            this.cb_HouseArea.TabIndex = 21;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 12);
            this.label2.TabIndex = 22;
            this.label2.Text = "货位逻辑库区";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.pb_AreaColor);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.bt_SelectColor);
            this.groupBox1.Controls.Add(this.cb_HouseArea);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(355, 104);
            this.groupBox1.TabIndex = 26;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "信息";
            // 
            // bt_Cancel
            // 
            this.bt_Cancel.Location = new System.Drawing.Point(299, 122);
            this.bt_Cancel.Name = "bt_Cancel";
            this.bt_Cancel.Size = new System.Drawing.Size(68, 27);
            this.bt_Cancel.TabIndex = 27;
            this.bt_Cancel.Text = "取消";
            this.bt_Cancel.UseVisualStyleBackColor = true;
            this.bt_Cancel.Click += new System.EventHandler(this.bt_Cancel_Click);
            // 
            // LogicAreaColorSet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(370, 164);
            this.Controls.Add(this.bt_Cancel);
            this.Controls.Add(this.bt_AreaSet);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "LogicAreaColorSet";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "逻辑库区颜色设置";
            ((System.ComponentModel.ISupportInitialize)(this.pb_AreaColor)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pb_AreaColor;
        private System.Windows.Forms.Button bt_SelectColor;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button bt_AreaSet;
        private System.Windows.Forms.ComboBox cb_HouseArea;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button bt_Cancel;
        private System.Windows.Forms.ColorDialog colorDialog1;
    }
}