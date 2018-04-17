namespace AsrsControl
{
    partial class GsStatisticsView
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
            this.label4 = new System.Windows.Forms.Label();
            this.cb_HouseName = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dtp_end = new System.Windows.Forms.DateTimePicker();
            this.dtp_start = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.cb_HouseArea = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.bt_Query = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.cb_GsOperate = new System.Windows.Forms.ComboBox();
            this.lb_OperateGsType = new System.Windows.Forms.Label();
            this.lb_GsOperateNum = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgv_GsSta = new System.Windows.Forms.DataGridView();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.textBox_GsName = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_GsSta)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(381, 20);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(106, 24);
            this.label4.TabIndex = 20;
            this.label4.Text = "库    房";
            // 
            // cb_HouseName
            // 
            this.cb_HouseName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_HouseName.FormattingEnabled = true;
            this.cb_HouseName.Location = new System.Drawing.Point(502, 14);
            this.cb_HouseName.Margin = new System.Windows.Forms.Padding(4);
            this.cb_HouseName.Name = "cb_HouseName";
            this.cb_HouseName.Size = new System.Drawing.Size(174, 32);
            this.cb_HouseName.TabIndex = 19;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 63);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 24);
            this.label2.TabIndex = 18;
            this.label2.Text = "结束时间";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 22);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 24);
            this.label1.TabIndex = 17;
            this.label1.Text = "开始时间";
            // 
            // dtp_end
            // 
            this.dtp_end.CustomFormat = "yyyy-MM-dd HH:mm";
            this.dtp_end.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp_end.Location = new System.Drawing.Point(122, 57);
            this.dtp_end.Margin = new System.Windows.Forms.Padding(4);
            this.dtp_end.Name = "dtp_end";
            this.dtp_end.ShowUpDown = true;
            this.dtp_end.Size = new System.Drawing.Size(252, 35);
            this.dtp_end.TabIndex = 16;
            this.dtp_end.Value = new System.DateTime(2018, 1, 7, 20, 0, 0, 0);
            // 
            // dtp_start
            // 
            this.dtp_start.CustomFormat = "yyyy-MM-dd HH:mm";
            this.dtp_start.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp_start.Location = new System.Drawing.Point(122, 16);
            this.dtp_start.Margin = new System.Windows.Forms.Padding(4);
            this.dtp_start.Name = "dtp_start";
            this.dtp_start.ShowUpDown = true;
            this.dtp_start.Size = new System.Drawing.Size(252, 35);
            this.dtp_start.TabIndex = 15;
            this.dtp_start.Value = new System.DateTime(2018, 1, 7, 8, 0, 0, 0);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(382, 60);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(106, 24);
            this.label3.TabIndex = 22;
            this.label3.Text = "库    区";
            // 
            // cb_HouseArea
            // 
            this.cb_HouseArea.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_HouseArea.FormattingEnabled = true;
            this.cb_HouseArea.Location = new System.Drawing.Point(502, 54);
            this.cb_HouseArea.Margin = new System.Windows.Forms.Padding(4);
            this.cb_HouseArea.Name = "cb_HouseArea";
            this.cb_HouseArea.Size = new System.Drawing.Size(174, 32);
            this.cb_HouseArea.TabIndex = 21;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(718, 14);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(106, 24);
            this.label5.TabIndex = 23;
            this.label5.Text = "货    位";
            // 
            // bt_Query
            // 
            this.bt_Query.Location = new System.Drawing.Point(1020, 9);
            this.bt_Query.Margin = new System.Windows.Forms.Padding(4);
            this.bt_Query.Name = "bt_Query";
            this.bt_Query.Size = new System.Drawing.Size(198, 69);
            this.bt_Query.TabIndex = 25;
            this.bt_Query.Text = "查  询";
            this.bt_Query.UseVisualStyleBackColor = true;
            this.bt_Query.Click += new System.EventHandler(this.bt_Query_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(718, 62);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(106, 24);
            this.label6.TabIndex = 26;
            this.label6.Text = "货位操作";
            // 
            // cb_GsOperate
            // 
            this.cb_GsOperate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_GsOperate.FormattingEnabled = true;
            this.cb_GsOperate.Location = new System.Drawing.Point(826, 56);
            this.cb_GsOperate.Margin = new System.Windows.Forms.Padding(4);
            this.cb_GsOperate.Name = "cb_GsOperate";
            this.cb_GsOperate.Size = new System.Drawing.Size(174, 32);
            this.cb_GsOperate.TabIndex = 27;
            // 
            // lb_OperateGsType
            // 
            this.lb_OperateGsType.AutoSize = true;
            this.lb_OperateGsType.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lb_OperateGsType.Location = new System.Drawing.Point(4, 0);
            this.lb_OperateGsType.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lb_OperateGsType.Name = "lb_OperateGsType";
            this.lb_OperateGsType.Size = new System.Drawing.Size(160, 24);
            this.lb_OperateGsType.TabIndex = 28;
            this.lb_OperateGsType.Text = "货位操作数量";
            // 
            // lb_GsOperateNum
            // 
            this.lb_GsOperateNum.AutoSize = true;
            this.lb_GsOperateNum.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lb_GsOperateNum.Location = new System.Drawing.Point(304, 0);
            this.lb_GsOperateNum.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lb_GsOperateNum.Name = "lb_GsOperateNum";
            this.lb_GsOperateNum.Size = new System.Drawing.Size(23, 24);
            this.lb_GsOperateNum.TabIndex = 29;
            this.lb_GsOperateNum.Text = "0";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.groupBox1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(8, 124);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1364, 562);
            this.tableLayoutPanel1.TabIndex = 30;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.dgv_GsSta);
            this.groupBox1.Location = new System.Drawing.Point(4, 4);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(1356, 509);
            this.groupBox1.TabIndex = 32;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "出入库统计";
            // 
            // dgv_GsSta
            // 
            this.dgv_GsSta.AllowUserToAddRows = false;
            this.dgv_GsSta.AllowUserToDeleteRows = false;
            this.dgv_GsSta.AllowUserToResizeRows = false;
            this.dgv_GsSta.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_GsSta.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_GsSta.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_GsSta.Location = new System.Drawing.Point(4, 25);
            this.dgv_GsSta.Margin = new System.Windows.Forms.Padding(4);
            this.dgv_GsSta.Name = "dgv_GsSta";
            this.dgv_GsSta.RowTemplate.Height = 23;
            this.dgv_GsSta.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_GsSta.Size = new System.Drawing.Size(1348, 480);
            this.dgv_GsSta.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 300F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 600F));
            this.tableLayoutPanel2.Controls.Add(this.lb_OperateGsType, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.lb_GsOperateNum, 1, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(4, 521);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(494, 36);
            this.tableLayoutPanel2.TabIndex = 31;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.panel1.Controls.Add(this.textBox_GsName);
            this.panel1.Controls.Add(this.dtp_start);
            this.panel1.Controls.Add(this.dtp_end);
            this.panel1.Controls.Add(this.cb_GsOperate);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.bt_Query);
            this.panel1.Controls.Add(this.cb_HouseName);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.cb_HouseArea);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Font = new System.Drawing.Font("宋体", 12F);
            this.panel1.Location = new System.Drawing.Point(9, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1362, 105);
            this.panel1.TabIndex = 31;
            // 
            // textBox_GsName
            // 
            this.textBox_GsName.Location = new System.Drawing.Point(832, 9);
            this.textBox_GsName.Name = "textBox_GsName";
            this.textBox_GsName.Size = new System.Drawing.Size(168, 35);
            this.textBox_GsName.TabIndex = 28;
            // 
            // GsStatisticsView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1383, 687);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "GsStatisticsView";
            this.Text = "出入库统计";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_GsSta)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cb_HouseName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtp_end;
        private System.Windows.Forms.DateTimePicker dtp_start;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cb_HouseArea;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button bt_Query;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cb_GsOperate;
        private System.Windows.Forms.Label lb_OperateGsType;
        private System.Windows.Forms.Label lb_GsOperateNum;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgv_GsSta;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox textBox_GsName;

    }
}