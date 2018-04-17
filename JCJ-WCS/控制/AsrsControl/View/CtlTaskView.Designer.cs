namespace AsrsControl
{
    partial class CtlTaskView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlTaskView));
            this.label3 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.buttonRecord = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.btnDelTask = new System.Windows.Forms.Button();
            this.labelQueryStat = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigator1 = new System.Windows.Forms.BindingNavigator(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.textBoxMohu = new System.Windows.Forms.TextBox();
            this.textBoxPrivilege = new System.Windows.Forms.TextBox();
            this.textBoxCell = new System.Windows.Forms.TextBox();
            this.checkBoxMohu = new System.Windows.Forms.CheckBox();
            this.checkBoxCell = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.buttonModifyPri = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.comboBoxOrderType = new System.Windows.Forms.ComboBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).BeginInit();
            this.bindingNavigator1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(420, 12);
            this.label3.Margin = new System.Windows.Forms.Padding(15, 4, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(106, 24);
            this.label3.TabIndex = 5;
            this.label3.Text = "设备选择";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(533, 5);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(4);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(164, 32);
            this.comboBox1.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(2, 15);
            this.label1.Margin = new System.Windows.Forms.Padding(30, 4, 4, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(130, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "起始时间：";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(139, 4);
            this.dateTimePicker1.Margin = new System.Windows.Forms.Padding(4);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.ShowUpDown = true;
            this.dateTimePicker1.Size = new System.Drawing.Size(227, 35);
            this.dateTimePicker1.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(2, 57);
            this.label2.Margin = new System.Windows.Forms.Padding(15, 4, 4, 4);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(130, 24);
            this.label2.TabIndex = 0;
            this.label2.Text = "结束时间：";
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.CustomFormat = "yyyy-MM-dd HH:mm";
            this.dateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker2.Location = new System.Drawing.Point(139, 49);
            this.dateTimePicker2.Margin = new System.Windows.Forms.Padding(4);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.ShowUpDown = true;
            this.dateTimePicker2.Size = new System.Drawing.Size(227, 35);
            this.dateTimePicker2.TabIndex = 0;
            // 
            // buttonRecord
            // 
            this.buttonRecord.Image = ((System.Drawing.Image)(resources.GetObject("buttonRecord.Image")));
            this.buttonRecord.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonRecord.Location = new System.Drawing.Point(1399, 42);
            this.buttonRecord.Margin = new System.Windows.Forms.Padding(4);
            this.buttonRecord.Name = "buttonRecord";
            this.buttonRecord.Size = new System.Drawing.Size(112, 42);
            this.buttonRecord.TabIndex = 4;
            this.buttonRecord.Text = "查询";
            this.buttonRecord.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonRecord.UseVisualStyleBackColor = true;
            this.buttonRecord.Click += new System.EventHandler(this.buttonRefresh_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(418, 54);
            this.label4.Margin = new System.Windows.Forms.Padding(15, 4, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(106, 24);
            this.label4.TabIndex = 5;
            this.label4.Text = "任务类型";
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(534, 44);
            this.comboBox2.Margin = new System.Windows.Forms.Padding(4);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(163, 32);
            this.comboBox2.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(704, 11);
            this.label5.Margin = new System.Windows.Forms.Padding(15, 4, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(106, 24);
            this.label5.TabIndex = 5;
            this.label5.Text = "任务状态";
            // 
            // comboBox3
            // 
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Location = new System.Drawing.Point(829, 5);
            this.comboBox3.Margin = new System.Windows.Forms.Padding(4);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(123, 32);
            this.comboBox3.TabIndex = 6;
            // 
            // btnDelTask
            // 
            this.btnDelTask.Image = ((System.Drawing.Image)(resources.GetObject("btnDelTask.Image")));
            this.btnDelTask.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDelTask.Location = new System.Drawing.Point(1519, 42);
            this.btnDelTask.Margin = new System.Windows.Forms.Padding(4);
            this.btnDelTask.Name = "btnDelTask";
            this.btnDelTask.Size = new System.Drawing.Size(102, 42);
            this.btnDelTask.TabIndex = 4;
            this.btnDelTask.Text = "删除";
            this.btnDelTask.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDelTask.UseVisualStyleBackColor = true;
            this.btnDelTask.Click += new System.EventHandler(this.btnDelTask_Click);
            // 
            // labelQueryStat
            // 
            this.labelQueryStat.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.labelQueryStat.Margin = new System.Windows.Forms.Padding(0, 1, 20, 2);
            this.labelQueryStat.Name = "labelQueryStat";
            this.labelQueryStat.Size = new System.Drawing.Size(82, 27);
            this.labelQueryStat.Text = "查询状态";
            // 
            // bindingNavigatorSeparator2
            // 
            this.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator2";
            this.bindingNavigatorSeparator2.Size = new System.Drawing.Size(6, 30);
            // 
            // bindingNavigatorMoveLastItem
            // 
            this.bindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveLastItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveLastItem.Image")));
            this.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
            this.bindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveLastItem.Size = new System.Drawing.Size(24, 27);
            this.bindingNavigatorMoveLastItem.Text = "移到最后一条记录";
            // 
            // bindingNavigatorMoveNextItem
            // 
            this.bindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveNextItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveNextItem.Image")));
            this.bindingNavigatorMoveNextItem.Name = "bindingNavigatorMoveNextItem";
            this.bindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveNextItem.Size = new System.Drawing.Size(24, 27);
            this.bindingNavigatorMoveNextItem.Text = "移到下一条记录";
            // 
            // bindingNavigatorSeparator1
            // 
            this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator1";
            this.bindingNavigatorSeparator1.Size = new System.Drawing.Size(6, 30);
            // 
            // bindingNavigatorPositionItem
            // 
            this.bindingNavigatorPositionItem.AccessibleName = "位置";
            this.bindingNavigatorPositionItem.AutoSize = false;
            this.bindingNavigatorPositionItem.Name = "bindingNavigatorPositionItem";
            this.bindingNavigatorPositionItem.Size = new System.Drawing.Size(73, 30);
            this.bindingNavigatorPositionItem.Text = "0";
            this.bindingNavigatorPositionItem.ToolTipText = "当前位置";
            // 
            // bindingNavigatorSeparator
            // 
            this.bindingNavigatorSeparator.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator.Size = new System.Drawing.Size(6, 30);
            // 
            // bindingNavigatorMovePreviousItem
            // 
            this.bindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMovePreviousItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMovePreviousItem.Image")));
            this.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
            this.bindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMovePreviousItem.Size = new System.Drawing.Size(24, 27);
            this.bindingNavigatorMovePreviousItem.Text = "移到上一条记录";
            // 
            // bindingNavigatorMoveFirstItem
            // 
            this.bindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveFirstItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveFirstItem.Image")));
            this.bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem";
            this.bindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveFirstItem.Size = new System.Drawing.Size(24, 27);
            this.bindingNavigatorMoveFirstItem.Text = "移到第一条记录";
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(46, 27);
            this.bindingNavigatorCountItem.Text = "/ {0}";
            this.bindingNavigatorCountItem.ToolTipText = "总项数";
            // 
            // bindingNavigator1
            // 
            this.bindingNavigator1.AddNewItem = null;
            this.bindingNavigator1.CountItem = this.bindingNavigatorCountItem;
            this.bindingNavigator1.DeleteItem = null;
            this.bindingNavigator1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bindingNavigator1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.bindingNavigator1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem,
            this.bindingNavigatorSeparator2,
            this.labelQueryStat});
            this.bindingNavigator1.Location = new System.Drawing.Point(0, 551);
            this.bindingNavigator1.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.bindingNavigator1.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.bindingNavigator1.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.bindingNavigator1.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.bindingNavigator1.Name = "bindingNavigator1";
            this.bindingNavigator1.Padding = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.bindingNavigator1.PositionItem = this.bindingNavigatorPositionItem;
            this.bindingNavigator1.Size = new System.Drawing.Size(1727, 30);
            this.bindingNavigator1.TabIndex = 0;
            this.bindingNavigator1.Text = "bindingNavigator1";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel1.Controls.Add(this.dataGridView1);
            this.panel1.Controls.Add(this.bindingNavigator1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(4, 105);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1727, 581);
            this.panel1.TabIndex = 0;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(-4, 0);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(1727, 539);
            this.dataGridView1.TabIndex = 1;
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
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 101F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 472F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1735, 690);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.panel2.Controls.Add(this.textBoxMohu);
            this.panel2.Controls.Add(this.textBoxPrivilege);
            this.panel2.Controls.Add(this.textBoxCell);
            this.panel2.Controls.Add(this.checkBoxMohu);
            this.panel2.Controls.Add(this.checkBoxCell);
            this.panel2.Controls.Add(this.buttonRecord);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.buttonModifyPri);
            this.panel2.Controls.Add(this.btnDelTask);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.comboBox3);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.comboBox2);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.comboBoxOrderType);
            this.panel2.Controls.Add(this.comboBox1);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.dateTimePicker2);
            this.panel2.Controls.Add(this.dateTimePicker1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Font = new System.Drawing.Font("宋体", 12F);
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1729, 95);
            this.panel2.TabIndex = 2;
            // 
            // textBoxMohu
            // 
            this.textBoxMohu.Location = new System.Drawing.Point(1089, 44);
            this.textBoxMohu.Name = "textBoxMohu";
            this.textBoxMohu.Size = new System.Drawing.Size(291, 35);
            this.textBoxMohu.TabIndex = 8;
            // 
            // textBoxPrivilege
            // 
            this.textBoxPrivilege.Location = new System.Drawing.Point(1358, 3);
            this.textBoxPrivilege.Name = "textBoxPrivilege";
            this.textBoxPrivilege.Size = new System.Drawing.Size(126, 35);
            this.textBoxPrivilege.TabIndex = 8;
            // 
            // textBoxCell
            // 
            this.textBoxCell.Location = new System.Drawing.Point(1089, 3);
            this.textBoxCell.Name = "textBoxCell";
            this.textBoxCell.Size = new System.Drawing.Size(160, 35);
            this.textBoxCell.TabIndex = 8;
            // 
            // checkBoxMohu
            // 
            this.checkBoxMohu.AutoSize = true;
            this.checkBoxMohu.Location = new System.Drawing.Point(986, 48);
            this.checkBoxMohu.Name = "checkBoxMohu";
            this.checkBoxMohu.Size = new System.Drawing.Size(108, 28);
            this.checkBoxMohu.TabIndex = 7;
            this.checkBoxMohu.Text = "关键字";
            this.checkBoxMohu.UseVisualStyleBackColor = true;
            // 
            // checkBoxCell
            // 
            this.checkBoxCell.AutoSize = true;
            this.checkBoxCell.Location = new System.Drawing.Point(987, 6);
            this.checkBoxCell.Name = "checkBoxCell";
            this.checkBoxCell.Size = new System.Drawing.Size(84, 28);
            this.checkBoxCell.TabIndex = 7;
            this.checkBoxCell.Text = "货位";
            this.checkBoxCell.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(1269, 11);
            this.label7.Margin = new System.Windows.Forms.Padding(15, 4, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(82, 24);
            this.label7.TabIndex = 5;
            this.label7.Text = "优先级";
            // 
            // buttonModifyPri
            // 
            this.buttonModifyPri.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonModifyPri.Location = new System.Drawing.Point(1491, 0);
            this.buttonModifyPri.Margin = new System.Windows.Forms.Padding(4);
            this.buttonModifyPri.Name = "buttonModifyPri";
            this.buttonModifyPri.Size = new System.Drawing.Size(154, 42);
            this.buttonModifyPri.TabIndex = 4;
            this.buttonModifyPri.Text = "修改优先级";
            this.buttonModifyPri.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonModifyPri.UseVisualStyleBackColor = true;
            this.buttonModifyPri.Click += new System.EventHandler(this.buttonModifyPri_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(696, 51);
            this.label6.Margin = new System.Windows.Forms.Padding(15, 4, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(130, 24);
            this.label6.TabIndex = 5;
            this.label6.Text = "优先级排序";
            // 
            // comboBoxOrderType
            // 
            this.comboBoxOrderType.FormattingEnabled = true;
            this.comboBoxOrderType.Location = new System.Drawing.Point(829, 44);
            this.comboBoxOrderType.Margin = new System.Windows.Forms.Padding(4);
            this.comboBoxOrderType.Name = "comboBoxOrderType";
            this.comboBoxOrderType.Size = new System.Drawing.Size(123, 32);
            this.comboBoxOrderType.TabIndex = 6;
            // 
            // toolTip1
            // 
            this.toolTip1.AutoPopDelay = 5000;
            this.toolTip1.InitialDelay = 50;
            this.toolTip1.ReshowDelay = 100;
            // 
            // CtlTaskView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1735, 690);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "CtlTaskView";
            this.Text = "CtlTaskView";
            this.Load += new System.EventHandler(this.CtlTaskView_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).EndInit();
            this.bindingNavigator1.ResumeLayout(false);
            this.bindingNavigator1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.Button buttonRecord;
        private System.Windows.Forms.ToolStripLabel labelQueryStat;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.BindingNavigator bindingNavigator1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboBox3;
        private System.Windows.Forms.Button btnDelTask;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.CheckBox checkBoxCell;
        private System.Windows.Forms.TextBox textBoxCell;
        private System.Windows.Forms.TextBox textBoxMohu;
        private System.Windows.Forms.CheckBox checkBoxMohu;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox comboBoxOrderType;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBoxPrivilege;
        private System.Windows.Forms.Button buttonModifyPri;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}