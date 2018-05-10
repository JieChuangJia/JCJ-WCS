namespace NbssECAMS
{
    partial class LoginView2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginView2));
            this.label4 = new System.Windows.Forms.Label();
            this.tb_userPassword = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.bt_cancel = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.bt_login = new System.Windows.Forms.Button();
            this.cb_UserRole = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.Image = ((System.Drawing.Image)(resources.GetObject("label4.Image")));
            this.label4.Location = new System.Drawing.Point(12, 10);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(298, 53);
            this.label4.TabIndex = 13;
            // 
            // tb_userPassword
            // 
            this.tb_userPassword.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tb_userPassword.Location = new System.Drawing.Point(84, 106);
            this.tb_userPassword.Name = "tb_userPassword";
            this.tb_userPassword.PasswordChar = '*';
            this.tb_userPassword.Size = new System.Drawing.Size(226, 26);
            this.tb_userPassword.TabIndex = 12;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(25, 109);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 16);
            this.label3.TabIndex = 11;
            this.label3.Text = "密  码";
            // 
            // bt_cancel
            // 
            this.bt_cancel.Location = new System.Drawing.Point(210, 148);
            this.bt_cancel.Name = "bt_cancel";
            this.bt_cancel.Size = new System.Drawing.Size(100, 41);
            this.bt_cancel.TabIndex = 8;
            this.bt_cancel.Text = "取消";
            this.bt_cancel.UseVisualStyleBackColor = true;
            this.bt_cancel.Click += new System.EventHandler(this.bt_cancel_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(25, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 16);
            this.label2.TabIndex = 10;
            this.label2.Text = "用户名";
            // 
            // bt_login
            // 
            this.bt_login.Location = new System.Drawing.Point(96, 148);
            this.bt_login.Name = "bt_login";
            this.bt_login.Size = new System.Drawing.Size(103, 41);
            this.bt_login.TabIndex = 7;
            this.bt_login.Text = "登录";
            this.bt_login.UseVisualStyleBackColor = true;
            this.bt_login.Click += new System.EventHandler(this.bt_login_Click);
            // 
            // cb_UserRole
            // 
            this.cb_UserRole.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_UserRole.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cb_UserRole.FormattingEnabled = true;
            this.cb_UserRole.Location = new System.Drawing.Point(84, 74);
            this.cb_UserRole.Name = "cb_UserRole";
            this.cb_UserRole.Size = new System.Drawing.Size(226, 24);
            this.cb_UserRole.TabIndex = 9;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.cb_UserRole);
            this.panel1.Controls.Add(this.tb_userPassword);
            this.panel1.Controls.Add(this.bt_login);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.bt_cancel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(320, 194);
            this.panel1.TabIndex = 14;
            // 
            // LoginView2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(320, 194);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.Name = "LoginView2";
            this.Text = "用户登录";
            this.Load += new System.EventHandler(this.LoginView2_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tb_userPassword;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button bt_cancel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button bt_login;
        private System.Windows.Forms.ComboBox cb_UserRole;
        private System.Windows.Forms.Panel panel1;
    }
}