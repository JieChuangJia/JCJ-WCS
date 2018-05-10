namespace ConfigManage
{
    partial class SysSettingView
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.checkBoxHouseA1 = new System.Windows.Forms.CheckBox();
            this.checkBoxHouseC2 = new System.Windows.Forms.CheckBox();
            this.checkBoxHouseC1 = new System.Windows.Forms.CheckBox();
            this.checkBoxHouseA2 = new System.Windows.Forms.CheckBox();
            this.btnDispProcessParams = new System.Windows.Forms.Button();
            this.buttonCfgApply = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.checkBoxHouseB1 = new System.Windows.Forms.CheckBox();
            this.checkBoxHouseC3 = new System.Windows.Forms.CheckBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1673, 621);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.groupBox1);
            this.panel2.Controls.Add(this.btnDispProcessParams);
            this.panel2.Controls.Add(this.buttonCfgApply);
            this.panel2.Controls.Add(this.groupBox2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1673, 621);
            this.panel2.TabIndex = 7;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.checkBoxHouseA1);
            this.groupBox1.Controls.Add(this.checkBoxHouseC3);
            this.groupBox1.Controls.Add(this.checkBoxHouseC2);
            this.groupBox1.Controls.Add(this.checkBoxHouseC1);
            this.groupBox1.Controls.Add(this.checkBoxHouseB1);
            this.groupBox1.Controls.Add(this.checkBoxHouseA2);
            this.groupBox1.Location = new System.Drawing.Point(22, 61);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1648, 90);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "启用设置";
            // 
            // checkBoxHouseA1
            // 
            this.checkBoxHouseA1.AutoSize = true;
            this.checkBoxHouseA1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.checkBoxHouseA1.Location = new System.Drawing.Point(11, 39);
            this.checkBoxHouseA1.Margin = new System.Windows.Forms.Padding(4);
            this.checkBoxHouseA1.Name = "checkBoxHouseA1";
            this.checkBoxHouseA1.Size = new System.Drawing.Size(252, 28);
            this.checkBoxHouseA1.TabIndex = 4;
            this.checkBoxHouseA1.Text = "A1库(1号高温）启用";
            this.checkBoxHouseA1.UseVisualStyleBackColor = true;
            // 
            // checkBoxHouseC2
            // 
            this.checkBoxHouseC2.AutoSize = true;
            this.checkBoxHouseC2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.checkBoxHouseC2.Location = new System.Drawing.Point(1101, 39);
            this.checkBoxHouseC2.Margin = new System.Windows.Forms.Padding(4);
            this.checkBoxHouseC2.Name = "checkBoxHouseC2";
            this.checkBoxHouseC2.Size = new System.Drawing.Size(252, 28);
            this.checkBoxHouseC2.TabIndex = 4;
            this.checkBoxHouseC2.Text = "C2库(2号常温）启用";
            this.checkBoxHouseC2.UseVisualStyleBackColor = true;
            // 
            // checkBoxHouseC1
            // 
            this.checkBoxHouseC1.AutoSize = true;
            this.checkBoxHouseC1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.checkBoxHouseC1.Location = new System.Drawing.Point(817, 39);
            this.checkBoxHouseC1.Margin = new System.Windows.Forms.Padding(4);
            this.checkBoxHouseC1.Name = "checkBoxHouseC1";
            this.checkBoxHouseC1.Size = new System.Drawing.Size(252, 28);
            this.checkBoxHouseC1.TabIndex = 4;
            this.checkBoxHouseC1.Text = "C1库（1号常温)启用";
            this.checkBoxHouseC1.UseVisualStyleBackColor = true;
            // 
            // checkBoxHouseA2
            // 
            this.checkBoxHouseA2.AutoSize = true;
            this.checkBoxHouseA2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.checkBoxHouseA2.Location = new System.Drawing.Point(282, 39);
            this.checkBoxHouseA2.Margin = new System.Windows.Forms.Padding(4);
            this.checkBoxHouseA2.Name = "checkBoxHouseA2";
            this.checkBoxHouseA2.Size = new System.Drawing.Size(252, 28);
            this.checkBoxHouseA2.TabIndex = 4;
            this.checkBoxHouseA2.Text = "A2库（2号高温)启用";
            this.checkBoxHouseA2.UseVisualStyleBackColor = true;
            // 
            // btnDispProcessParams
            // 
            this.btnDispProcessParams.BackColor = System.Drawing.Color.MediumSpringGreen;
            this.btnDispProcessParams.Font = new System.Drawing.Font("宋体", 13F);
            this.btnDispProcessParams.Location = new System.Drawing.Point(22, 13);
            this.btnDispProcessParams.Margin = new System.Windows.Forms.Padding(4);
            this.btnDispProcessParams.Name = "btnDispProcessParams";
            this.btnDispProcessParams.Size = new System.Drawing.Size(234, 41);
            this.btnDispProcessParams.TabIndex = 1;
            this.btnDispProcessParams.Text = "刷新";
            this.btnDispProcessParams.UseVisualStyleBackColor = false;
            this.btnDispProcessParams.Click += new System.EventHandler(this.btnDispProcessParams_Click_1);
            // 
            // buttonCfgApply
            // 
            this.buttonCfgApply.BackColor = System.Drawing.Color.MediumSpringGreen;
            this.buttonCfgApply.Font = new System.Drawing.Font("宋体", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonCfgApply.Location = new System.Drawing.Point(301, 12);
            this.buttonCfgApply.Name = "buttonCfgApply";
            this.buttonCfgApply.Size = new System.Drawing.Size(257, 41);
            this.buttonCfgApply.TabIndex = 1;
            this.buttonCfgApply.Text = "应用";
            this.buttonCfgApply.UseVisualStyleBackColor = false;
            this.buttonCfgApply.Click += new System.EventHandler(this.buttonCfgApply_Click_1);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dataGridView1);
            this.groupBox2.Location = new System.Drawing.Point(22, 158);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(871, 410);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "老化时间设置";
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(9, 29);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(841, 350);
            this.dataGridView1.TabIndex = 0;
            // 
            // checkBoxHouseB1
            // 
            this.checkBoxHouseB1.AutoSize = true;
            this.checkBoxHouseB1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.checkBoxHouseB1.Location = new System.Drawing.Point(556, 39);
            this.checkBoxHouseB1.Margin = new System.Windows.Forms.Padding(4);
            this.checkBoxHouseB1.Name = "checkBoxHouseB1";
            this.checkBoxHouseB1.Size = new System.Drawing.Size(240, 28);
            this.checkBoxHouseB1.TabIndex = 4;
            this.checkBoxHouseB1.Text = "B1库（分容库)启用";
            this.checkBoxHouseB1.UseVisualStyleBackColor = true;
            // 
            // checkBoxHouseC3
            // 
            this.checkBoxHouseC3.AutoSize = true;
            this.checkBoxHouseC3.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.checkBoxHouseC3.Location = new System.Drawing.Point(1386, 39);
            this.checkBoxHouseC3.Margin = new System.Windows.Forms.Padding(4);
            this.checkBoxHouseC3.Name = "checkBoxHouseC3";
            this.checkBoxHouseC3.Size = new System.Drawing.Size(252, 28);
            this.checkBoxHouseC3.TabIndex = 4;
            this.checkBoxHouseC3.Text = "C3库(3号常温）启用";
            this.checkBoxHouseC3.UseVisualStyleBackColor = true;
            // 
            // SysSettingView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1673, 621);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "SysSettingView";
            this.Text = "系统设置";
            this.Load += new System.EventHandler(this.SysSettingView_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox checkBoxHouseC2;
        private System.Windows.Forms.Button btnDispProcessParams;
        private System.Windows.Forms.CheckBox checkBoxHouseA2;
        private System.Windows.Forms.Button buttonCfgApply;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.CheckBox checkBoxHouseA1;
        private System.Windows.Forms.CheckBox checkBoxHouseC1;
        private System.Windows.Forms.CheckBox checkBoxHouseC3;
        private System.Windows.Forms.CheckBox checkBoxHouseB1;
    }
}