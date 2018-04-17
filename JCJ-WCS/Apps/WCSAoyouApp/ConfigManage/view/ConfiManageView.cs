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
namespace ConfigManage
{
    public partial class ConfiManageView : BaseChildView
    {
        
        private UserManageView userManageView = null;
        private SysSettingView sysSettignView = null;
        private BatteryCataCfgView batteryCfgView = null;
        
        #region 公共接口
        public BatteryCataCfgView BatteryCfgView { get { return batteryCfgView; } }
        //public string CaptionText { get { return captionText; } set { captionText = value; this.Text = captionText; } }
        public ConfiManageView():base(string.Empty)
        {
            InitializeComponent();
          
            userManageView = new UserManageView("用户管理");
            sysSettignView = new SysSettingView("系统设置");
            batteryCfgView = new BatteryCataCfgView("电芯型号配置");
        }
        public void SetCfgNodes(List<FlowCtlBaseModel.CtlNodeBaseModel> cfgNodes)
        {
            sysSettignView.SetCfgNodes(cfgNodes);
        }
        #endregion
       
        #region IModuleAttach接口实现
        public override void RegisterMenus(MenuStrip parentMenu, string rootMenuText)
        {
           
            ToolStripMenuItem rootMenuItem = new ToolStripMenuItem(rootMenuText);//parentMenu.Items.Add("仓储管理");
            //rootMenuItem.Click += LoadMainform_MenuHandler;
            parentMenu.Items.Add(rootMenuItem);
          
           
            ToolStripItem userItem = rootMenuItem.DropDownItems.Add("修改密码");
            ToolStripItem sysSetItem = rootMenuItem.DropDownItems.Add("系统设置");
            ToolStripItem batteryCfgItem = rootMenuItem.DropDownItems.Add("电芯型号配置");
           
            userItem.Click += LoadView_MenuHandler;
            sysSetItem.Click += LoadView_MenuHandler;
            batteryCfgItem.Click += LoadView_MenuHandler;
        }
        public override void SetParent(/*Control parentContainer, Form parentForm, */IParentModule parentPnP)
        {
            this.parentPNP = parentPnP;
            //if (parentPNP.RoleID == 1)
            //{
            //    sysDefineView = new SysDefineView("系统维护");
            //    this.sysDefineView.SetParent(parentPnP);
            //}
           
            this.sysSettignView.SetParent(parentPnP);
            this.userManageView.SetParent(parentPnP);
            this.batteryCfgView.SetParent(parentPnP);
        }
        public override void SetLoginterface(ILogRecorder logRecorder)
        {
            this.logRecorder = logRecorder;
         //   lineMonitorPresenter.SetLogRecorder(logRecorder);
           
            this.sysSettignView.SetLoginterface(logRecorder);
            this.userManageView.SetLoginterface(logRecorder);
            this.batteryCfgView.SetLoginterface(logRecorder);
        }
        public override void ChangeRoleID(int roleID)
        {
            //if(roleID>2)
            //{
            //    this.sysSettignView.Close();
            //    this.batteryCfgView.Close();
            //    this.userManageView.Close();
            //}
            this.sysSettignView.ChangeRoleID(roleID);
            this.userManageView.ChangeRoleID(roleID);
            this.batteryCfgView.ChangeRoleID(roleID);
            if(roleID>2)
            {
                parentPNP.RemoveModuleView(this.sysSettignView);
                parentPNP.RemoveModuleView(this.batteryCfgView);
                parentPNP.RemoveModuleView(this.userManageView);
            }
        }
        #endregion
        private void LoadView_MenuHandler(object sender, EventArgs e)
        {
            ToolStripItem menuItem = sender as ToolStripItem;
            if(menuItem == null)
            {
                return;
            }
            switch(menuItem.Text)
            {
                case "修改密码":
                    {
                        this.parentPNP.AttachModuleView(this.userManageView);
                        break;
                    }
                case "系统设置":
                    {
                        if (parentPNP.RoleID <3)
                        {
                            this.parentPNP.AttachModuleView(this.sysSettignView);
                        }
                        else
                        {
                            Console.WriteLine("没有访问权限！请切换到管理员模式");
                        }
                        break;
                    }
                case "电芯型号配置":
                    {
                        if (parentPNP.RoleID < 3)
                        {
                            this.parentPNP.AttachModuleView(this.batteryCfgView);
                        }
                        else
                        {
                            Console.WriteLine("没有访问权限！请切换到管理员模式");
                        }
                        break;
                    }
                //case "系统维护":
                //    {
                //        if (parentPNP.RoleID != 1)
                //        {
                //            Console.WriteLine("请切换到系统维护用户");
                //            break;
                //        }
                //        this.parentPNP.AttachModuleView(this.sysDefineView);
                //        break;
                //    }
              
                default:
                    break;
            }
            
            
        }
    }
}
