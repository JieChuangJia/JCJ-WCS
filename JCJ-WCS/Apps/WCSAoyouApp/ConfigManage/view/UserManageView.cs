using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ModuleCrossPnP;
using LogInterface;
using CtlDBAccess.Model;
using CtlDBAccess.BLL;
namespace ConfigManage
{
    
    public partial class UserManageView : BaseChildView
    {
        User_ListBll userBll = null;
        public UserManageView(string captionText):base(captionText)
        {
            InitializeComponent();
            this.Text = captionText;
            //this.captionText = captionText;
            userBll = new User_ListBll();
            
        }

        private void UserManageView_Load(object sender, EventArgs e)
        {
            this.textBoxUser.Enabled = false;
            this.textBoxUser.Text = parentPNP.CurUsername;
        }
        private void OnModifyUserpswd()
        {
            User_ListModel userM = userBll.GetModel(this.textBoxUser.Text);
            if(userM == null)
            {
                MessageBox.Show("用户不存在:" + this.textBoxUser.Text);
                return;
            }
            if(userM.UserPassWord != this.textBoxOldpswd.Text)
            {
                MessageBox.Show("旧密码不正确");
                return;
            }
            if(this.textBoxNewPswd.Text != this.textBoxRePswd.Text)
            {
                MessageBox.Show("两次输入密码不一致");
                return;
            }
            userM.UserPassWord = this.textBoxRePswd.Text;
            if(this.userBll.Update(userM))
            {
                MessageBox.Show("密码修改成功！");
                ClearInput();
            }
            else
            {
                MessageBox.Show("密码修改失败!");
            }
          
        }
        private void buttonModify_Click(object sender, EventArgs e)
        {
            OnModifyUserpswd();
        }
        private void ClearInput()
        {
            this.textBoxRePswd.Text = "";
            this.textBoxOldpswd.Text = "";
            this.textBoxNewPswd.Text = "";
        }
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            ClearInput();
        }
    }
}
