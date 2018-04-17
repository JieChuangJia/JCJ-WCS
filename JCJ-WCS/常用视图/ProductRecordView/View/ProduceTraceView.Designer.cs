namespace ProductRecordView
{
    partial class ProduceTraceView
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.buttonTrace = new System.Windows.Forms.Button();
            this.textBoxBarcode = new System.Windows.Forms.TextBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxStep = new System.Windows.Forms.TextBox();
            this.buttonGetStep = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.buttonModifyStep = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.SystemColors.Control;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 99F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 474F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1529, 630);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel1.Controls.Add(this.dataGridView1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(4, 103);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1521, 523);
            this.panel1.TabIndex = 0;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(1521, 523);
            this.dataGridView1.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.buttonModifyStep);
            this.panel2.Controls.Add(this.buttonGetStep);
            this.panel2.Controls.Add(this.buttonTrace);
            this.panel2.Controls.Add(this.textBoxStep);
            this.panel2.Controls.Add(this.textBoxBarcode);
            this.panel2.Controls.Add(this.comboBox1);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(4, 4);
            this.panel2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1521, 91);
            this.panel2.TabIndex = 1;
            // 
            // buttonTrace
            // 
            this.buttonTrace.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonTrace.Location = new System.Drawing.Point(772, 24);
            this.buttonTrace.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonTrace.Name = "buttonTrace";
            this.buttonTrace.Size = new System.Drawing.Size(198, 51);
            this.buttonTrace.TabIndex = 3;
            this.buttonTrace.Text = "追溯查询";
            this.buttonTrace.UseVisualStyleBackColor = true;
            this.buttonTrace.Click += new System.EventHandler(this.buttonTrace_Click);
            // 
            // textBoxBarcode
            // 
            this.textBoxBarcode.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBoxBarcode.Location = new System.Drawing.Point(250, 36);
            this.textBoxBarcode.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxBarcode.Name = "textBoxBarcode";
            this.textBoxBarcode.Size = new System.Drawing.Size(474, 35);
            this.textBoxBarcode.TabIndex = 2;
            // 
            // comboBox1
            // 
            this.comboBox1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(16, 36);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(180, 32);
            this.comboBox1.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(248, 9);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 24);
            this.label2.TabIndex = 0;
            this.label2.Text = "条码";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(14, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "类别选择";
            // 
            // textBoxStep
            // 
            this.textBoxStep.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBoxStep.Location = new System.Drawing.Point(1031, 35);
            this.textBoxStep.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxStep.Name = "textBoxStep";
            this.textBoxStep.Size = new System.Drawing.Size(132, 35);
            this.textBoxStep.TabIndex = 2;
            // 
            // buttonGetStep
            // 
            this.buttonGetStep.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonGetStep.Location = new System.Drawing.Point(1182, 24);
            this.buttonGetStep.Margin = new System.Windows.Forms.Padding(4);
            this.buttonGetStep.Name = "buttonGetStep";
            this.buttonGetStep.Size = new System.Drawing.Size(134, 47);
            this.buttonGetStep.TabIndex = 3;
            this.buttonGetStep.Text = "工步查询";
            this.buttonGetStep.UseVisualStyleBackColor = true;
            this.buttonGetStep.Click += new System.EventHandler(this.buttonGetStep_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(1030, 7);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 24);
            this.label3.TabIndex = 4;
            this.label3.Text = "工步";
            // 
            // buttonModifyStep
            // 
            this.buttonModifyStep.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonModifyStep.Location = new System.Drawing.Point(1324, 24);
            this.buttonModifyStep.Margin = new System.Windows.Forms.Padding(4);
            this.buttonModifyStep.Name = "buttonModifyStep";
            this.buttonModifyStep.Size = new System.Drawing.Size(134, 47);
            this.buttonModifyStep.TabIndex = 3;
            this.buttonModifyStep.Text = "工步修改";
            this.buttonModifyStep.UseVisualStyleBackColor = true;
            this.buttonModifyStep.Click += new System.EventHandler(this.buttonModifyStep_Click);
            // 
            // ProduceTraceView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1529, 630);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "ProduceTraceView";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.ProduceReccordView_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button buttonTrace;
        private System.Windows.Forms.TextBox textBoxBarcode;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button buttonModifyStep;
        private System.Windows.Forms.Button buttonGetStep;
        private System.Windows.Forms.TextBox textBoxStep;
    }
}

