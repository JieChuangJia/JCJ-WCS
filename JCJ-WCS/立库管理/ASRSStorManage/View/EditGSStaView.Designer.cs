namespace ASRSStorManage.View
{
    partial class EditGSStaView
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
            this.cb_GSTaskType = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cb_GSStatus = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.bt_Sure = new System.Windows.Forms.Button();
            this.bt_Cancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cb_GSTaskType
            // 
            this.cb_GSTaskType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_GSTaskType.FormattingEnabled = true;
            this.cb_GSTaskType.Location = new System.Drawing.Point(118, 24);
            this.cb_GSTaskType.Name = "cb_GSTaskType";
            this.cb_GSTaskType.Size = new System.Drawing.Size(158, 20);
            this.cb_GSTaskType.TabIndex = 23;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(24, 28);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(89, 12);
            this.label7.TabIndex = 22;
            this.label7.Text = "货位任务状态：";
            // 
            // cb_GSStatus
            // 
            this.cb_GSStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_GSStatus.FormattingEnabled = true;
            this.cb_GSStatus.Location = new System.Drawing.Point(118, 51);
            this.cb_GSStatus.Name = "cb_GSStatus";
            this.cb_GSStatus.Size = new System.Drawing.Size(158, 20);
            this.cb_GSStatus.TabIndex = 21;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(24, 54);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(89, 12);
            this.label8.TabIndex = 20;
            this.label8.Text = "货 位  状 态：";
            // 
            // bt_Sure
            // 
            this.bt_Sure.Location = new System.Drawing.Point(118, 86);
            this.bt_Sure.Name = "bt_Sure";
            this.bt_Sure.Size = new System.Drawing.Size(75, 23);
            this.bt_Sure.TabIndex = 24;
            this.bt_Sure.Text = "确定";
            this.bt_Sure.UseVisualStyleBackColor = true;
            this.bt_Sure.Click += new System.EventHandler(this.bt_Sure_Click);
            // 
            // bt_Cancel
            // 
            this.bt_Cancel.Location = new System.Drawing.Point(201, 86);
            this.bt_Cancel.Name = "bt_Cancel";
            this.bt_Cancel.Size = new System.Drawing.Size(75, 23);
            this.bt_Cancel.TabIndex = 25;
            this.bt_Cancel.Text = "取消";
            this.bt_Cancel.UseVisualStyleBackColor = true;
            this.bt_Cancel.Click += new System.EventHandler(this.bt_Cancel_Click);
            // 
            // EditGSStaView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(313, 120);
            this.Controls.Add(this.bt_Cancel);
            this.Controls.Add(this.bt_Sure);
            this.Controls.Add(this.cb_GSTaskType);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cb_GSStatus);
            this.Controls.Add(this.label8);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "EditGSStaView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "货位状态修改";
            this.Load += new System.EventHandler(this.EditGSStaView_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cb_GSTaskType;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cb_GSStatus;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button bt_Sure;
        private System.Windows.Forms.Button bt_Cancel;
    }
}