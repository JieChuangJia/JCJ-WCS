namespace ASRSStorManage.View
{
    partial class MultiGsEnabledSet
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
            this.cb_ColSTList = new System.Windows.Forms.ComboBox();
            this.rb_singleCol = new System.Windows.Forms.RadioButton();
            this.rb_SingleLayer = new System.Windows.Forms.RadioButton();
            this.cb_LayerList = new System.Windows.Forms.ComboBox();
            this.bt_GsFobit = new System.Windows.Forms.Button();
            this.bt_UseGs = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.cb_EndLayer = new System.Windows.Forms.ComboBox();
            this.cb_startLayer = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cb_ColListEDArea = new System.Windows.Forms.ComboBox();
            this.bt_AreaSet = new System.Windows.Forms.Button();
            this.cb_HouseArea = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cb_ColListSTArea = new System.Windows.Forms.ComboBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cb_ColEDList = new System.Windows.Forms.ComboBox();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // cb_ColSTList
            // 
            this.cb_ColSTList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_ColSTList.FormattingEnabled = true;
            this.cb_ColSTList.Location = new System.Drawing.Point(152, 25);
            this.cb_ColSTList.Name = "cb_ColSTList";
            this.cb_ColSTList.Size = new System.Drawing.Size(51, 20);
            this.cb_ColSTList.TabIndex = 3;
            // 
            // rb_singleCol
            // 
            this.rb_singleCol.AutoSize = true;
            this.rb_singleCol.Checked = true;
            this.rb_singleCol.Location = new System.Drawing.Point(20, 30);
            this.rb_singleCol.Name = "rb_singleCol";
            this.rb_singleCol.Size = new System.Drawing.Size(47, 16);
            this.rb_singleCol.TabIndex = 11;
            this.rb_singleCol.TabStop = true;
            this.rb_singleCol.Text = "单列";
            this.rb_singleCol.UseVisualStyleBackColor = true;
            // 
            // rb_SingleLayer
            // 
            this.rb_SingleLayer.AutoSize = true;
            this.rb_SingleLayer.Location = new System.Drawing.Point(20, 53);
            this.rb_SingleLayer.Name = "rb_SingleLayer";
            this.rb_SingleLayer.Size = new System.Drawing.Size(47, 16);
            this.rb_SingleLayer.TabIndex = 12;
            this.rb_SingleLayer.Text = "单层";
            this.rb_SingleLayer.UseVisualStyleBackColor = true;
            // 
            // cb_LayerList
            // 
            this.cb_LayerList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_LayerList.FormattingEnabled = true;
            this.cb_LayerList.Location = new System.Drawing.Point(107, 53);
            this.cb_LayerList.Name = "cb_LayerList";
            this.cb_LayerList.Size = new System.Drawing.Size(199, 20);
            this.cb_LayerList.TabIndex = 5;
            // 
            // bt_GsFobit
            // 
            this.bt_GsFobit.Location = new System.Drawing.Point(241, 79);
            this.bt_GsFobit.Name = "bt_GsFobit";
            this.bt_GsFobit.Size = new System.Drawing.Size(60, 27);
            this.bt_GsFobit.TabIndex = 3;
            this.bt_GsFobit.Text = "禁用";
            this.bt_GsFobit.UseVisualStyleBackColor = true;
            this.bt_GsFobit.Click += new System.EventHandler(this.bt_GsFobit_Click);
            // 
            // bt_UseGs
            // 
            this.bt_UseGs.Location = new System.Drawing.Point(175, 79);
            this.bt_UseGs.Name = "bt_UseGs";
            this.bt_UseGs.Size = new System.Drawing.Size(60, 27);
            this.bt_UseGs.TabIndex = 9;
            this.bt_UseGs.Text = "启用";
            this.bt_UseGs.UseVisualStyleBackColor = true;
            this.bt_UseGs.Click += new System.EventHandler(this.bt_UseGs_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.cb_EndLayer);
            this.groupBox2.Controls.Add(this.cb_startLayer);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.cb_ColListEDArea);
            this.groupBox2.Controls.Add(this.bt_AreaSet);
            this.groupBox2.Controls.Add(this.cb_HouseArea);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.cb_ColListSTArea);
            this.groupBox2.Location = new System.Drawing.Point(3, 122);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(327, 165);
            this.groupBox2.TabIndex = 15;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "逻辑库区设置";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(185, 55);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 12);
            this.label6.TabIndex = 20;
            this.label6.Text = "终止层";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(52, 55);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 12);
            this.label7.TabIndex = 19;
            this.label7.Text = "起始层";
            // 
            // cb_EndLayer
            // 
            this.cb_EndLayer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_EndLayer.FormattingEnabled = true;
            this.cb_EndLayer.Location = new System.Drawing.Point(229, 51);
            this.cb_EndLayer.Name = "cb_EndLayer";
            this.cb_EndLayer.Size = new System.Drawing.Size(58, 20);
            this.cb_EndLayer.TabIndex = 18;
            // 
            // cb_startLayer
            // 
            this.cb_startLayer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_startLayer.FormattingEnabled = true;
            this.cb_startLayer.Location = new System.Drawing.Point(96, 51);
            this.cb_startLayer.Name = "cb_startLayer";
            this.cb_startLayer.Size = new System.Drawing.Size(51, 20);
            this.cb_startLayer.TabIndex = 17;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(185, 29);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 16;
            this.label3.Text = "终止列";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(52, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 15;
            this.label1.Text = "起始列";
            // 
            // cb_ColListEDArea
            // 
            this.cb_ColListEDArea.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_ColListEDArea.FormattingEnabled = true;
            this.cb_ColListEDArea.Location = new System.Drawing.Point(229, 25);
            this.cb_ColListEDArea.Name = "cb_ColListEDArea";
            this.cb_ColListEDArea.Size = new System.Drawing.Size(58, 20);
            this.cb_ColListEDArea.TabIndex = 14;
            // 
            // bt_AreaSet
            // 
            this.bt_AreaSet.Location = new System.Drawing.Point(238, 132);
            this.bt_AreaSet.Name = "bt_AreaSet";
            this.bt_AreaSet.Size = new System.Drawing.Size(68, 27);
            this.bt_AreaSet.TabIndex = 9;
            this.bt_AreaSet.Text = "设定";
            this.bt_AreaSet.UseVisualStyleBackColor = true;
            this.bt_AreaSet.Click += new System.EventHandler(this.bt_AreaSet_Click);
            // 
            // cb_HouseArea
            // 
            this.cb_HouseArea.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_HouseArea.FormattingEnabled = true;
            this.cb_HouseArea.Location = new System.Drawing.Point(113, 101);
            this.cb_HouseArea.Name = "cb_HouseArea";
            this.cb_HouseArea.Size = new System.Drawing.Size(199, 20);
            this.cb_HouseArea.TabIndex = 13;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 105);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 12);
            this.label2.TabIndex = 13;
            this.label2.Text = "货位逻辑库区";
            // 
            // cb_ColListSTArea
            // 
            this.cb_ColListSTArea.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_ColListSTArea.FormattingEnabled = true;
            this.cb_ColListSTArea.Location = new System.Drawing.Point(96, 25);
            this.cb_ColListSTArea.Name = "cb_ColListSTArea";
            this.cb_ColListSTArea.Size = new System.Drawing.Size(51, 20);
            this.cb_ColListSTArea.TabIndex = 3;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.cb_ColEDList);
            this.groupBox3.Controls.Add(this.cb_ColSTList);
            this.groupBox3.Controls.Add(this.rb_singleCol);
            this.groupBox3.Controls.Add(this.bt_UseGs);
            this.groupBox3.Controls.Add(this.rb_SingleLayer);
            this.groupBox3.Controls.Add(this.bt_GsFobit);
            this.groupBox3.Controls.Add(this.cb_LayerList);
            this.groupBox3.Location = new System.Drawing.Point(3, 7);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(327, 112);
            this.groupBox3.TabIndex = 16;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "货位启禁用设置";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(208, 29);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 18;
            this.label5.Text = "终止列";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(106, 29);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 17;
            this.label4.Text = "起始列";
            // 
            // cb_ColEDList
            // 
            this.cb_ColEDList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_ColEDList.FormattingEnabled = true;
            this.cb_ColEDList.Location = new System.Drawing.Point(254, 25);
            this.cb_ColEDList.Name = "cb_ColEDList";
            this.cb_ColEDList.Size = new System.Drawing.Size(51, 20);
            this.cb_ColEDList.TabIndex = 13;
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label8.Location = new System.Drawing.Point(20, 80);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(295, 3);
            this.label8.TabIndex = 21;
            // 
            // MultiGsEnabledSet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(336, 297);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.MaximizeBox = false;
            this.Name = "MultiGsEnabledSet";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "货位批量修改";
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cb_LayerList;
        private System.Windows.Forms.ComboBox cb_ColSTList;
        private System.Windows.Forms.RadioButton rb_SingleLayer;
        private System.Windows.Forms.RadioButton rb_singleCol;
        private System.Windows.Forms.Button bt_UseGs;
        private System.Windows.Forms.Button bt_GsFobit;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox cb_HouseArea;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cb_ColListSTArea;
        private System.Windows.Forms.Button bt_AreaSet;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cb_ColListEDArea;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cb_ColEDList;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cb_EndLayer;
        private System.Windows.Forms.ComboBox cb_startLayer;
        private System.Windows.Forms.Label label8;
    }
}