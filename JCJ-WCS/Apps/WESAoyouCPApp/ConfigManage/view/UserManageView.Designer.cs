namespace ConfigManage
{
    partial class UserManageView
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
            this.textBoxUser = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxOldpswd = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxNewPswd = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonModify = new System.Windows.Forms.Button();
            this.textBoxRePswd = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(85, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "用户名";
            // 
            // textBoxUser
            // 
            this.textBoxUser.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBoxUser.Location = new System.Drawing.Point(205, 17);
            this.textBoxUser.Name = "textBoxUser";
            this.textBoxUser.Size = new System.Drawing.Size(171, 28);
            this.textBoxUser.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(85, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 19);
            this.label2.TabIndex = 0;
            this.label2.Text = "旧密码";
            // 
            // textBoxOldpswd
            // 
            this.textBoxOldpswd.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBoxOldpswd.Location = new System.Drawing.Point(205, 63);
            this.textBoxOldpswd.Name = "textBoxOldpswd";
            this.textBoxOldpswd.PasswordChar = '*';
            this.textBoxOldpswd.Size = new System.Drawing.Size(171, 28);
            this.textBoxOldpswd.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(85, 120);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 19);
            this.label3.TabIndex = 0;
            this.label3.Text = "新密码";
            // 
            // textBoxNewPswd
            // 
            this.textBoxNewPswd.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBoxNewPswd.Location = new System.Drawing.Point(205, 107);
            this.textBoxNewPswd.Name = "textBoxNewPswd";
            this.textBoxNewPswd.PasswordChar = '*';
            this.textBoxNewPswd.Size = new System.Drawing.Size(171, 28);
            this.textBoxNewPswd.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.buttonCancel);
            this.panel1.Controls.Add(this.buttonModify);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.textBoxRePswd);
            this.panel1.Controls.Add(this.textBoxNewPswd);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.textBoxOldpswd);
            this.panel1.Controls.Add(this.textBoxUser);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(379, 326);
            this.panel1.TabIndex = 2;
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(206, 215);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(124, 43);
            this.buttonCancel.TabIndex = 2;
            this.buttonCancel.Text = "清空输入";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonModify
            // 
            this.buttonModify.Location = new System.Drawing.Point(65, 215);
            this.buttonModify.Name = "buttonModify";
            this.buttonModify.Size = new System.Drawing.Size(124, 43);
            this.buttonModify.TabIndex = 2;
            this.buttonModify.Text = "确定";
            this.buttonModify.UseVisualStyleBackColor = true;
            this.buttonModify.Click += new System.EventHandler(this.buttonModify_Click);
            // 
            // textBoxRePswd
            // 
            this.textBoxRePswd.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBoxRePswd.Location = new System.Drawing.Point(205, 150);
            this.textBoxRePswd.Name = "textBoxRePswd";
            this.textBoxRePswd.PasswordChar = '*';
            this.textBoxRePswd.Size = new System.Drawing.Size(171, 28);
            this.textBoxRePswd.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(85, 156);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(104, 19);
            this.label4.TabIndex = 0;
            this.label4.Text = "重复新密码";
            // 
            // UserManageView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(379, 326);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "UserManageView";
            this.Text = "用户管理";
            this.Load += new System.EventHandler(this.UserManageView_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxUser;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxOldpswd;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxNewPswd;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox textBoxRePswd;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonModify;
    }
}