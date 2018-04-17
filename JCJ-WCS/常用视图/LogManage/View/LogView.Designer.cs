namespace LogManage
{
    partial class LogView
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LogView));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolLabelQueryresult = new System.Windows.Forms.ToolStripLabel();
            this.toolStripButtonFirstPage = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonPrepage = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolTextBoxCurpage = new System.Windows.Forms.ToolStripTextBox();
            this.toolLabelSumpage = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonNextpage = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonLastPage = new System.Windows.Forms.ToolStripButton();
            this.toolStripLabelTimecost = new System.Windows.Forms.ToolStripLabel();
            this.toolStripButtonRefresh = new System.Windows.Forms.ToolStripButton();
            this.btnExportCurpage = new System.Windows.Forms.ToolStripButton();
            this.btnExportAll = new System.Windows.Forms.ToolStripButton();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.buttonLogRefresh = new System.Windows.Forms.Button();
            this.cb_LikeQuery = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxLikeContent = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBoxLevel = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBoxNode = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
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
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 102F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 470F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1727, 626);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel1.Controls.Add(this.toolStrip1);
            this.panel1.Controls.Add(this.dataGridView1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(4, 106);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1719, 516);
            this.panel1.TabIndex = 0;
            // 
            // toolStrip1
            // 
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolLabelQueryresult,
            this.toolStripButtonFirstPage,
            this.toolStripButtonPrepage,
            this.toolStripSeparator1,
            this.toolTextBoxCurpage,
            this.toolLabelSumpage,
            this.toolStripSeparator2,
            this.toolStripButtonNextpage,
            this.toolStripButtonLastPage,
            this.toolStripLabelTimecost,
            this.toolStripButtonRefresh,
            this.btnExportCurpage,
            this.btnExportAll});
            this.toolStrip1.Location = new System.Drawing.Point(0, 470);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Padding = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.toolStrip1.Size = new System.Drawing.Size(1719, 46);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolLabelQueryresult
            // 
            this.toolLabelQueryresult.Name = "toolLabelQueryresult";
            this.toolLabelQueryresult.Size = new System.Drawing.Size(100, 43);
            this.toolLabelQueryresult.Text = "查询结果：";
            this.toolLabelQueryresult.ToolTipText = "总项数";
            // 
            // toolStripButtonFirstPage
            // 
            this.toolStripButtonFirstPage.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonFirstPage.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonFirstPage.Image")));
            this.toolStripButtonFirstPage.Margin = new System.Windows.Forms.Padding(100, 1, 0, 2);
            this.toolStripButtonFirstPage.Name = "toolStripButtonFirstPage";
            this.toolStripButtonFirstPage.RightToLeftAutoMirrorImage = true;
            this.toolStripButtonFirstPage.Size = new System.Drawing.Size(24, 43);
            this.toolStripButtonFirstPage.Text = "首页";
            this.toolStripButtonFirstPage.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolStripButtonFirstPage.Click += new System.EventHandler(this.toolStripButtonFirstPage_Click);
            // 
            // toolStripButtonPrepage
            // 
            this.toolStripButtonPrepage.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonPrepage.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonPrepage.Image")));
            this.toolStripButtonPrepage.Name = "toolStripButtonPrepage";
            this.toolStripButtonPrepage.RightToLeftAutoMirrorImage = true;
            this.toolStripButtonPrepage.Size = new System.Drawing.Size(24, 43);
            this.toolStripButtonPrepage.Text = "移到上一页";
            this.toolStripButtonPrepage.Click += new System.EventHandler(this.toolStripButtonPrepage_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 46);
            // 
            // toolTextBoxCurpage
            // 
            this.toolTextBoxCurpage.AccessibleName = "位置";
            this.toolTextBoxCurpage.AutoSize = false;
            this.toolTextBoxCurpage.Name = "toolTextBoxCurpage";
            this.toolTextBoxCurpage.Size = new System.Drawing.Size(73, 30);
            this.toolTextBoxCurpage.Text = "0";
            this.toolTextBoxCurpage.ToolTipText = "当前页";
            this.toolTextBoxCurpage.KeyDown += new System.Windows.Forms.KeyEventHandler(this.toolTextBoxCurpage_KeyDown);
            // 
            // toolLabelSumpage
            // 
            this.toolLabelSumpage.Name = "toolLabelSumpage";
            this.toolLabelSumpage.Size = new System.Drawing.Size(46, 43);
            this.toolLabelSumpage.Text = "/ {0}";
            this.toolLabelSumpage.ToolTipText = "总页数";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 46);
            // 
            // toolStripButtonNextpage
            // 
            this.toolStripButtonNextpage.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonNextpage.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonNextpage.Image")));
            this.toolStripButtonNextpage.Name = "toolStripButtonNextpage";
            this.toolStripButtonNextpage.RightToLeftAutoMirrorImage = true;
            this.toolStripButtonNextpage.Size = new System.Drawing.Size(24, 43);
            this.toolStripButtonNextpage.Text = "移到下一页";
            this.toolStripButtonNextpage.Click += new System.EventHandler(this.toolStripButtonNextpage_Click);
            // 
            // toolStripButtonLastPage
            // 
            this.toolStripButtonLastPage.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonLastPage.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonLastPage.Image")));
            this.toolStripButtonLastPage.Name = "toolStripButtonLastPage";
            this.toolStripButtonLastPage.RightToLeftAutoMirrorImage = true;
            this.toolStripButtonLastPage.Size = new System.Drawing.Size(24, 43);
            this.toolStripButtonLastPage.Text = "末页";
            this.toolStripButtonLastPage.Click += new System.EventHandler(this.toolStripButtonLastPage_Click);
            // 
            // toolStripLabelTimecost
            // 
            this.toolStripLabelTimecost.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripLabelTimecost.Name = "toolStripLabelTimecost";
            this.toolStripLabelTimecost.Size = new System.Drawing.Size(0, 43);
            // 
            // toolStripButtonRefresh
            // 
            this.toolStripButtonRefresh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButtonRefresh.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonRefresh.Image")));
            this.toolStripButtonRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonRefresh.Name = "toolStripButtonRefresh";
            this.toolStripButtonRefresh.Size = new System.Drawing.Size(50, 43);
            this.toolStripButtonRefresh.Text = "刷新";
            this.toolStripButtonRefresh.Click += new System.EventHandler(this.toolStripButtonRefresh_Click);
            // 
            // btnExportCurpage
            // 
            this.btnExportCurpage.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnExportCurpage.Image = ((System.Drawing.Image)(resources.GetObject("btnExportCurpage.Image")));
            this.btnExportCurpage.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnExportCurpage.Name = "btnExportCurpage";
            this.btnExportCurpage.Size = new System.Drawing.Size(104, 43);
            this.btnExportCurpage.Text = "导出当前页";
            this.btnExportCurpage.Click += new System.EventHandler(this.btnExportCurpage_Click);
            // 
            // btnExportAll
            // 
            this.btnExportAll.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnExportAll.Image = ((System.Drawing.Image)(resources.GetObject("btnExportAll.Image")));
            this.btnExportAll.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnExportAll.Name = "btnExportAll";
            this.btnExportAll.Size = new System.Drawing.Size(86, 43);
            this.btnExportAll.Text = "导出全部";
            this.btnExportAll.Click += new System.EventHandler(this.btnExportAll_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dataGridView1.Location = new System.Drawing.Point(0, 4);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(1723, 466);
            this.dataGridView1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.panel2.Controls.Add(this.buttonLogRefresh);
            this.panel2.Controls.Add(this.cb_LikeQuery);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.textBoxLikeContent);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.comboBoxLevel);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.comboBoxNode);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.dateTimePicker2);
            this.panel2.Controls.Add(this.dateTimePicker1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Font = new System.Drawing.Font("宋体", 12F);
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1721, 96);
            this.panel2.TabIndex = 1;
            // 
            // buttonLogRefresh
            // 
            this.buttonLogRefresh.Location = new System.Drawing.Point(1172, 5);
            this.buttonLogRefresh.Margin = new System.Windows.Forms.Padding(4);
            this.buttonLogRefresh.Name = "buttonLogRefresh";
            this.buttonLogRefresh.Size = new System.Drawing.Size(220, 74);
            this.buttonLogRefresh.TabIndex = 3;
            this.buttonLogRefresh.Text = " 查  询";
            this.buttonLogRefresh.UseVisualStyleBackColor = true;
            this.buttonLogRefresh.Click += new System.EventHandler(this.buttonLogRefresh_Click);
            // 
            // cb_LikeQuery
            // 
            this.cb_LikeQuery.AutoSize = true;
            this.cb_LikeQuery.Location = new System.Drawing.Point(403, 56);
            this.cb_LikeQuery.Margin = new System.Windows.Forms.Padding(30, 4, 4, 4);
            this.cb_LikeQuery.Name = "cb_LikeQuery";
            this.cb_LikeQuery.Size = new System.Drawing.Size(132, 28);
            this.cb_LikeQuery.TabIndex = 24;
            this.cb_LikeQuery.Text = "模糊查询";
            this.cb_LikeQuery.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(906, 13);
            this.label4.Margin = new System.Windows.Forms.Padding(15, 4, 4, 4);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 24);
            this.label4.TabIndex = 0;
            this.label4.Text = "类别：";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // textBoxLikeContent
            // 
            this.textBoxLikeContent.Location = new System.Drawing.Point(538, 49);
            this.textBoxLikeContent.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxLikeContent.Name = "textBoxLikeContent";
            this.textBoxLikeContent.Size = new System.Drawing.Size(613, 35);
            this.textBoxLikeContent.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(396, 18);
            this.label3.Margin = new System.Windows.Forms.Padding(15, 4, 4, 4);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(130, 24);
            this.label3.TabIndex = 0;
            this.label3.Text = "日志来源：";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // comboBoxLevel
            // 
            this.comboBoxLevel.FormattingEnabled = true;
            this.comboBoxLevel.Location = new System.Drawing.Point(996, 5);
            this.comboBoxLevel.Margin = new System.Windows.Forms.Padding(4);
            this.comboBoxLevel.Name = "comboBoxLevel";
            this.comboBoxLevel.Size = new System.Drawing.Size(152, 32);
            this.comboBoxLevel.TabIndex = 1;
            this.comboBoxLevel.SelectedIndexChanged += new System.EventHandler(this.comboBoxLevel_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 62);
            this.label2.Margin = new System.Windows.Forms.Padding(15, 4, 4, 4);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(130, 24);
            this.label2.TabIndex = 0;
            this.label2.Text = "结束时间：";
            // 
            // comboBoxNode
            // 
            this.comboBoxNode.FormattingEnabled = true;
            this.comboBoxNode.Location = new System.Drawing.Point(538, 10);
            this.comboBoxNode.Margin = new System.Windows.Forms.Padding(4);
            this.comboBoxNode.Name = "comboBoxNode";
            this.comboBoxNode.Size = new System.Drawing.Size(349, 32);
            this.comboBoxNode.TabIndex = 1;
            this.comboBoxNode.SelectedIndexChanged += new System.EventHandler(this.comboBoxNode_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 19);
            this.label1.Margin = new System.Windows.Forms.Padding(4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(130, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "起始时间：";
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.CustomFormat = "yyyy-MM-dd HH:mm";
            this.dateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker2.Location = new System.Drawing.Point(146, 53);
            this.dateTimePicker2.Margin = new System.Windows.Forms.Padding(4);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.ShowUpDown = true;
            this.dateTimePicker2.Size = new System.Drawing.Size(231, 35);
            this.dateTimePicker2.TabIndex = 0;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Cursor = System.Windows.Forms.Cursors.Default;
            this.dateTimePicker1.CustomFormat = "yyyy-MM-dd HH:mm";
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(146, 10);
            this.dateTimePicker1.Margin = new System.Windows.Forms.Padding(4);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.ShowUpDown = true;
            this.dateTimePicker1.Size = new System.Drawing.Size(231, 35);
            this.dateTimePicker1.TabIndex = 0;
            // 
            // LogView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1727, 626);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "LogView";
            this.Text = "LogMainForm";
            this.Load += new System.EventHandler(this.LogView_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel toolLabelQueryresult;
        private System.Windows.Forms.ToolStripButton toolStripButtonFirstPage;
        private System.Windows.Forms.ToolStripButton toolStripButtonPrepage;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripTextBox toolTextBoxCurpage;
        private System.Windows.Forms.ToolStripLabel toolLabelSumpage;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton toolStripButtonNextpage;
        private System.Windows.Forms.ToolStripButton toolStripButtonLastPage;
        private System.Windows.Forms.ToolStripLabel toolStripLabelTimecost;
        private System.Windows.Forms.ToolStripButton btnExportCurpage;
        private System.Windows.Forms.ToolStripButton btnExportAll;
        private System.Windows.Forms.ToolStripButton toolStripButtonRefresh;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button buttonLogRefresh;
        private System.Windows.Forms.CheckBox cb_LikeQuery;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxLikeContent;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBoxLevel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBoxNode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
    }
}