namespace ASRSStorManage.View
{
    partial class StockOperateView
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgv_OperateRecord = new System.Windows.Forms.DataGridView();
            this.dtp_start = new System.Windows.Forms.DateTimePicker();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cb_ProBatch = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cb_HouseName = new System.Windows.Forms.ComboBox();
            this.tb_GsName = new System.Windows.Forms.TextBox();
            this.cbox_GsName = new System.Windows.Forms.CheckBox();
            this.bt_Query = new System.Windows.Forms.Button();
            this.Cbox_ContLikequery = new System.Windows.Forms.CheckBox();
            this.tb_LikeQuery = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cb_OperateType = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dtp_end = new System.Windows.Forms.DateTimePicker();
            this.btnExportExcel = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_OperateRecord)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.dgv_OperateRecord);
            this.groupBox1.Location = new System.Drawing.Point(0, 110);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(773, 296);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "操作记录";
            // 
            // dgv_OperateRecord
            // 
            this.dgv_OperateRecord.AllowUserToAddRows = false;
            this.dgv_OperateRecord.AllowUserToDeleteRows = false;
            this.dgv_OperateRecord.AllowUserToResizeRows = false;
            this.dgv_OperateRecord.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_OperateRecord.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_OperateRecord.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_OperateRecord.Location = new System.Drawing.Point(3, 17);
            this.dgv_OperateRecord.MultiSelect = false;
            this.dgv_OperateRecord.Name = "dgv_OperateRecord";
            this.dgv_OperateRecord.RowHeadersVisible = false;
            this.dgv_OperateRecord.RowTemplate.Height = 23;
            this.dgv_OperateRecord.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_OperateRecord.Size = new System.Drawing.Size(767, 276);
            this.dgv_OperateRecord.TabIndex = 0;
            // 
            // dtp_start
            // 
            this.dtp_start.Location = new System.Drawing.Point(82, 21);
            this.dtp_start.Name = "dtp_start";
            this.dtp_start.Size = new System.Drawing.Size(120, 21);
            this.dtp_start.TabIndex = 2;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnExportExcel);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.cb_ProBatch);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.cb_HouseName);
            this.groupBox2.Controls.Add(this.tb_GsName);
            this.groupBox2.Controls.Add(this.cbox_GsName);
            this.groupBox2.Controls.Add(this.bt_Query);
            this.groupBox2.Controls.Add(this.Cbox_ContLikequery);
            this.groupBox2.Controls.Add(this.tb_LikeQuery);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.cb_OperateType);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.dtp_end);
            this.groupBox2.Controls.Add(this.dtp_start);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(778, 104);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "查询条件";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(212, 52);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 16;
            this.label5.Text = "产品批次";
            // 
            // cb_ProBatch
            // 
            this.cb_ProBatch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_ProBatch.FormattingEnabled = true;
            this.cb_ProBatch.Location = new System.Drawing.Point(275, 48);
            this.cb_ProBatch.Name = "cb_ProBatch";
            this.cb_ProBatch.Size = new System.Drawing.Size(145, 20);
            this.cb_ProBatch.TabIndex = 15;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(19, 77);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 14;
            this.label4.Text = "库    房";
            // 
            // cb_HouseName
            // 
            this.cb_HouseName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_HouseName.FormattingEnabled = true;
            this.cb_HouseName.Location = new System.Drawing.Point(82, 73);
            this.cb_HouseName.Name = "cb_HouseName";
            this.cb_HouseName.Size = new System.Drawing.Size(117, 20);
            this.cb_HouseName.TabIndex = 13;
            // 
            // tb_GsName
            // 
            this.tb_GsName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_GsName.Location = new System.Drawing.Point(275, 73);
            this.tb_GsName.Name = "tb_GsName";
            this.tb_GsName.Size = new System.Drawing.Size(145, 21);
            this.tb_GsName.TabIndex = 12;
            // 
            // cbox_GsName
            // 
            this.cbox_GsName.AutoSize = true;
            this.cbox_GsName.Location = new System.Drawing.Point(214, 75);
            this.cbox_GsName.Name = "cbox_GsName";
            this.cbox_GsName.Size = new System.Drawing.Size(48, 16);
            this.cbox_GsName.TabIndex = 11;
            this.cbox_GsName.Text = "货位";
            this.cbox_GsName.UseVisualStyleBackColor = true;
            // 
            // bt_Query
            // 
            this.bt_Query.Location = new System.Drawing.Point(430, 59);
            this.bt_Query.Name = "bt_Query";
            this.bt_Query.Size = new System.Drawing.Size(151, 35);
            this.bt_Query.TabIndex = 10;
            this.bt_Query.Text = "查  询";
            this.bt_Query.UseVisualStyleBackColor = true;
            this.bt_Query.Click += new System.EventHandler(this.bt_Query_Click);
            // 
            // Cbox_ContLikequery
            // 
            this.Cbox_ContLikequery.AutoSize = true;
            this.Cbox_ContLikequery.Location = new System.Drawing.Point(430, 23);
            this.Cbox_ContLikequery.Name = "Cbox_ContLikequery";
            this.Cbox_ContLikequery.Size = new System.Drawing.Size(72, 16);
            this.Cbox_ContLikequery.TabIndex = 9;
            this.Cbox_ContLikequery.Text = "模糊查询";
            this.Cbox_ContLikequery.UseVisualStyleBackColor = true;
            // 
            // tb_LikeQuery
            // 
            this.tb_LikeQuery.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_LikeQuery.Location = new System.Drawing.Point(508, 21);
            this.tb_LikeQuery.Name = "tb_LikeQuery";
            this.tb_LikeQuery.Size = new System.Drawing.Size(170, 21);
            this.tb_LikeQuery.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(212, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 7;
            this.label3.Text = "操作类型";
            // 
            // cb_OperateType
            // 
            this.cb_OperateType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_OperateType.FormattingEnabled = true;
            this.cb_OperateType.Location = new System.Drawing.Point(275, 21);
            this.cb_OperateType.Name = "cb_OperateType";
            this.cb_OperateType.Size = new System.Drawing.Size(145, 20);
            this.cb_OperateType.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 5;
            this.label2.Text = "结束时间";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "开始时间";
            // 
            // dtp_end
            // 
            this.dtp_end.Location = new System.Drawing.Point(82, 48);
            this.dtp_end.Name = "dtp_end";
            this.dtp_end.Size = new System.Drawing.Size(120, 21);
            this.dtp_end.TabIndex = 3;
            // 
            // btnExportExcel
            // 
            this.btnExportExcel.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnExportExcel.Location = new System.Drawing.Point(587, 59);
            this.btnExportExcel.Name = "btnExportExcel";
            this.btnExportExcel.Size = new System.Drawing.Size(91, 34);
            this.btnExportExcel.TabIndex = 17;
            this.btnExportExcel.Text = "导出Excel";
            this.btnExportExcel.UseVisualStyleBackColor = true;
            this.btnExportExcel.Click += new System.EventHandler(this.btnExportExcel_Click);
            // 
            // StockOperateView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(778, 407);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "StockOperateView";
            this.Text = "库存操作详细";
            this.Load += new System.EventHandler(this.StockOperateView_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_OperateRecord)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgv_OperateRecord;
        private System.Windows.Forms.DateTimePicker dtp_start;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button bt_Query;
        private System.Windows.Forms.CheckBox Cbox_ContLikequery;
        private System.Windows.Forms.TextBox tb_LikeQuery;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cb_OperateType;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtp_end;
        private System.Windows.Forms.TextBox tb_GsName;
        private System.Windows.Forms.CheckBox cbox_GsName;
        private System.Windows.Forms.ComboBox cb_HouseName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cb_ProBatch;
        private System.Windows.Forms.Button btnExportExcel;

    }
}