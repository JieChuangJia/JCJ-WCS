namespace LicenceManager
{
    partial class ActivativeFormView
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
            this.label1 = new System.Windows.Forms.Label();
            this.tb_DesKeyCode = new System.Windows.Forms.TextBox();
            this.bt_ActiveCancel = new System.Windows.Forms.Button();
            this.bt_ActiveTrue = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 94);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "输入激活码：";
            // 
            // tb_DesKeyCode
            // 
            this.tb_DesKeyCode.Location = new System.Drawing.Point(86, 85);
            this.tb_DesKeyCode.Name = "tb_DesKeyCode";
            this.tb_DesKeyCode.Size = new System.Drawing.Size(417, 21);
            this.tb_DesKeyCode.TabIndex = 1;
            // 
            // bt_ActiveCancel
            // 
            this.bt_ActiveCancel.Location = new System.Drawing.Point(437, 118);
            this.bt_ActiveCancel.Name = "bt_ActiveCancel";
            this.bt_ActiveCancel.Size = new System.Drawing.Size(75, 23);
            this.bt_ActiveCancel.TabIndex = 2;
            this.bt_ActiveCancel.Text = "取消";
            this.bt_ActiveCancel.UseVisualStyleBackColor = true;
            this.bt_ActiveCancel.Click += new System.EventHandler(this.bt_ActiveCancel_Click);
            // 
            // bt_ActiveTrue
            // 
            this.bt_ActiveTrue.Location = new System.Drawing.Point(356, 118);
            this.bt_ActiveTrue.Name = "bt_ActiveTrue";
            this.bt_ActiveTrue.Size = new System.Drawing.Size(75, 23);
            this.bt_ActiveTrue.TabIndex = 3;
            this.bt_ActiveTrue.Text = "激活";
            this.bt_ActiveTrue.UseVisualStyleBackColor = true;
            this.bt_ActiveTrue.Click += new System.EventHandler(this.bt_ActiveTrue_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(7, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(399, 32);
            this.label2.TabIndex = 4;
            this.label2.Text = "软件使用期限已到，请付尾款！\r\n最终解释权归沈阳新松机器人自动化股份有限公司。";
            // 
            // ActivativeFormView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(588, 162);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.bt_ActiveTrue);
            this.Controls.Add(this.bt_ActiveCancel);
            this.Controls.Add(this.tb_DesKeyCode);
            this.Controls.Add(this.label1);
            this.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.MaximizeBox = false;
            this.Name = "ActivativeFormView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "系统激活";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.ActivativeFormView_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tb_DesKeyCode;
        private System.Windows.Forms.Button bt_ActiveCancel;
        private System.Windows.Forms.Button bt_ActiveTrue;
        private System.Windows.Forms.Label label2;
    }
}