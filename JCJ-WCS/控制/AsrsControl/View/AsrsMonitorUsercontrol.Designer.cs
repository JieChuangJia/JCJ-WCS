namespace AsrsControl.View
{
    partial class AsrsMonitorUsercontrol
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AsrsMonitorUsercontrol));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label33 = new System.Windows.Forms.Label();
            this.label32 = new System.Windows.Forms.Label();
            this.label31 = new System.Windows.Forms.Label();
            this.btnWarnReset = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.InfoText;
            this.groupBox1.Controls.Add(this.label33);
            this.groupBox1.Controls.Add(this.label32);
            this.groupBox1.Controls.Add(this.label31);
            this.groupBox1.Controls.Add(this.btnWarnReset);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(627, 206);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // label33
            // 
            this.label33.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label33.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label33.Location = new System.Drawing.Point(9, 147);
            this.label33.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(607, 47);
            this.label33.TabIndex = 43;
            this.label33.Text = "状态：";
            // 
            // label32
            // 
            this.label32.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label32.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label32.Location = new System.Drawing.Point(226, 26);
            this.label32.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(390, 57);
            this.label32.TabIndex = 44;
            this.label32.Text = "当前任务：";
            // 
            // label31
            // 
            this.label31.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label31.BackColor = System.Drawing.Color.Transparent;
            this.label31.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label31.ForeColor = System.Drawing.SystemColors.Info;
            this.label31.Location = new System.Drawing.Point(9, 100);
            this.label31.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(607, 42);
            this.label31.TabIndex = 45;
            this.label31.Text = "故障码：";
            // 
            // btnWarnReset
            // 
            this.btnWarnReset.BackColor = System.Drawing.Color.Chartreuse;
            this.btnWarnReset.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnWarnReset.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnWarnReset.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnWarnReset.Image = ((System.Drawing.Image)(resources.GetObject("btnWarnReset.Image")));
            this.btnWarnReset.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnWarnReset.Location = new System.Drawing.Point(9, 20);
            this.btnWarnReset.Margin = new System.Windows.Forms.Padding(4);
            this.btnWarnReset.Name = "btnWarnReset";
            this.btnWarnReset.Size = new System.Drawing.Size(192, 63);
            this.btnWarnReset.TabIndex = 42;
            this.btnWarnReset.Text = "报警复位";
            this.btnWarnReset.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnWarnReset.UseVisualStyleBackColor = false;
            this.btnWarnReset.Click += new System.EventHandler(this.btnWarnReset_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // AsrsMonitorUsercontrol
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "AsrsMonitorUsercontrol";
            this.Size = new System.Drawing.Size(627, 206);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnWarnReset;
        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.Timer timer1;
    }
}
