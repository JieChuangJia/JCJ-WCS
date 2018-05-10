namespace ASRSStorManage.View
{
    partial class MoveHouseManulView
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
            this.tb_EndPos = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tb_StartPos = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.bt_MoveHouse = new System.Windows.Forms.Button();
            this.bt_Cancel = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tb_EndPos);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.tb_StartPos);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(287, 104);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "起止货位设置";
            // 
            // tb_EndPos
            // 
            this.tb_EndPos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_EndPos.Location = new System.Drawing.Point(101, 54);
            this.tb_EndPos.Name = "tb_EndPos";
            this.tb_EndPos.ReadOnly = true;
            this.tb_EndPos.Size = new System.Drawing.Size(167, 21);
            this.tb_EndPos.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "移库终止位置：";
            // 
            // tb_StartPos
            // 
            this.tb_StartPos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_StartPos.Location = new System.Drawing.Point(101, 27);
            this.tb_StartPos.Name = "tb_StartPos";
            this.tb_StartPos.ReadOnly = true;
            this.tb_StartPos.Size = new System.Drawing.Size(167, 21);
            this.tb_StartPos.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "移库起始位置：";
            // 
            // bt_MoveHouse
            // 
            this.bt_MoveHouse.Location = new System.Drawing.Point(169, 122);
            this.bt_MoveHouse.Name = "bt_MoveHouse";
            this.bt_MoveHouse.Size = new System.Drawing.Size(61, 27);
            this.bt_MoveHouse.TabIndex = 1;
            this.bt_MoveHouse.Text = "移库";
            this.bt_MoveHouse.UseVisualStyleBackColor = true;
            this.bt_MoveHouse.Click += new System.EventHandler(this.bt_MoveHouse_Click);
            // 
            // bt_Cancel
            // 
            this.bt_Cancel.Location = new System.Drawing.Point(237, 122);
            this.bt_Cancel.Name = "bt_Cancel";
            this.bt_Cancel.Size = new System.Drawing.Size(62, 27);
            this.bt_Cancel.TabIndex = 2;
            this.bt_Cancel.Text = "取消";
            this.bt_Cancel.UseVisualStyleBackColor = true;
            this.bt_Cancel.Click += new System.EventHandler(this.bt_Cancel_Click);
            // 
            // MoveHouseManulView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(311, 167);
            this.Controls.Add(this.bt_Cancel);
            this.Controls.Add(this.bt_MoveHouse);
            this.Controls.Add(this.groupBox1);
            this.Name = "MoveHouseManulView";
            this.Text = "手动移库";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox tb_EndPos;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tb_StartPos;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button bt_MoveHouse;
        private System.Windows.Forms.Button bt_Cancel;
    }
}