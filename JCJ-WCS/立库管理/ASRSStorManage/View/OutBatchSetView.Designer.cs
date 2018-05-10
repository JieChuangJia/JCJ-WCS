namespace ASRSStorManage.View
{
    partial class OutBatchSetView
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

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.bt_OutBatchSet = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.dgv_OutBatchSet = new System.Windows.Forms.DataGridView();
            this.Col_House = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_HouseArea = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_OutBatch = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cb_House = new System.Windows.Forms.ComboBox();
            this.cb_batch = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cb_HouseArea = new System.Windows.Forms.ComboBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_OutBatchSet)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.bt_OutBatchSet);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.dgv_OutBatchSet);
            this.groupBox1.Controls.Add(this.cb_House);
            this.groupBox1.Controls.Add(this.cb_batch);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.cb_HouseArea);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.ForeColor = System.Drawing.Color.Black;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Size = new System.Drawing.Size(330, 558);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "出库批次设置";
            // 
            // bt_OutBatchSet
            // 
            this.bt_OutBatchSet.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.bt_OutBatchSet.Location = new System.Drawing.Point(24, 515);
            this.bt_OutBatchSet.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.bt_OutBatchSet.Name = "bt_OutBatchSet";
            this.bt_OutBatchSet.Size = new System.Drawing.Size(302, 44);
            this.bt_OutBatchSet.TabIndex = 7;
            this.bt_OutBatchSet.Text = "设置";
            this.bt_OutBatchSet.UseVisualStyleBackColor = true;
            this.bt_OutBatchSet.Click += new System.EventHandler(this.bt_OutBatchSet_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 28);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "库房";
            // 
            // dgv_OutBatchSet
            // 
            this.dgv_OutBatchSet.AllowUserToAddRows = false;
            this.dgv_OutBatchSet.AllowUserToDeleteRows = false;
            this.dgv_OutBatchSet.AllowUserToResizeRows = false;
            this.dgv_OutBatchSet.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv_OutBatchSet.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_OutBatchSet.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.dgv_OutBatchSet.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgv_OutBatchSet.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Col_House,
            this.col_HouseArea,
            this.col_OutBatch});
            this.dgv_OutBatchSet.Location = new System.Drawing.Point(24, 123);
            this.dgv_OutBatchSet.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgv_OutBatchSet.Name = "dgv_OutBatchSet";
            this.dgv_OutBatchSet.RowHeadersVisible = false;
            this.dgv_OutBatchSet.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgv_OutBatchSet.RowTemplate.Height = 23;
            this.dgv_OutBatchSet.Size = new System.Drawing.Size(298, 383);
            this.dgv_OutBatchSet.TabIndex = 6;
            // 
            // Col_House
            // 
            this.Col_House.FillWeight = 87.15582F;
            this.Col_House.HeaderText = "库房";
            this.Col_House.Name = "Col_House";
            // 
            // col_HouseArea
            // 
            this.col_HouseArea.FillWeight = 91.01678F;
            this.col_HouseArea.HeaderText = "库区";
            this.col_HouseArea.Name = "col_HouseArea";
            // 
            // col_OutBatch
            // 
            this.col_OutBatch.FillWeight = 121.8274F;
            this.col_OutBatch.HeaderText = "批次";
            this.col_OutBatch.Name = "col_OutBatch";
            // 
            // cb_House
            // 
            this.cb_House.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cb_House.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_House.FormattingEnabled = true;
            this.cb_House.Location = new System.Drawing.Point(74, 24);
            this.cb_House.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cb_House.Name = "cb_House";
            this.cb_House.Size = new System.Drawing.Size(247, 26);
            this.cb_House.TabIndex = 1;
            this.cb_House.SelectedIndexChanged += new System.EventHandler(this.cb_House_SelectedIndexChanged);
            // 
            // cb_batch
            // 
            this.cb_batch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cb_batch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_batch.FormattingEnabled = true;
            this.cb_batch.Location = new System.Drawing.Point(74, 88);
            this.cb_batch.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cb_batch.Name = "cb_batch";
            this.cb_batch.Size = new System.Drawing.Size(247, 26);
            this.cb_batch.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 60);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 18);
            this.label2.TabIndex = 2;
            this.label2.Text = "库区";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 93);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 18);
            this.label3.TabIndex = 4;
            this.label3.Text = "批次";
            // 
            // cb_HouseArea
            // 
            this.cb_HouseArea.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cb_HouseArea.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_HouseArea.FormattingEnabled = true;
            this.cb_HouseArea.Location = new System.Drawing.Point(74, 56);
            this.cb_HouseArea.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cb_HouseArea.Name = "cb_HouseArea";
            this.cb_HouseArea.Size = new System.Drawing.Size(247, 26);
            this.cb_HouseArea.TabIndex = 3;
            this.cb_HouseArea.SelectedIndexChanged += new System.EventHandler(this.cb_HouseArea_SelectedIndexChanged);
            // 
            // OutBatchSetView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "OutBatchSetView";
            this.Size = new System.Drawing.Size(330, 558);
            this.Load += new System.EventHandler(this.OutBatchSetView_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_OutBatchSet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button bt_OutBatchSet;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgv_OutBatchSet;
        private System.Windows.Forms.ComboBox cb_House;
        private System.Windows.Forms.ComboBox cb_batch;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cb_HouseArea;
        private System.Windows.Forms.DataGridViewTextBoxColumn Col_House;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_HouseArea;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_OutBatch;
    }
}
