using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using ModuleCrossPnP;
using LogInterface;
using AsrsInterface;
using ASRSStorManage.Model;


namespace ASRSStorManage.View
{
    public partial class StorageMainView : BaseChildView
    {
        private static List<Form> ViewList = new List<Form>();
        StockManaView stockManaView;
        StorageView storageView;
        StockOperateView stockOperteView;
        public  IAsrsCtlToManage iControl;
        public  IAsrsManageToCtl iManage = null;
        public static StorageManager storageMana = null;
        private UserControl batchSetControl = null;
        public UserControl BatchSetControl { get { return this.batchSetControl; } }
        public StorageMainView()
        {
           
            InitializeComponent();
            stockManaView = new StockManaView("库存列表");
            storageView = new StorageView("货位看板");
            stockOperteView = new StockOperateView("操作记录");
            ViewList.Add(stockManaView);
            ViewList.Add(storageView);
            ViewList.Add(stockOperteView);
            this.batchSetControl = new OutBatchSetView();
        }
        public static Form GetViewByName(string formName)
        {
            Form reForm = null;
            foreach(Form fm in ViewList)
            {
                if (fm.Name == formName)
                {
                    reForm = fm;
                    break;
                }
            }
            return reForm;
        }
        /// <summary>
        /// 库存模块初始化
        /// </summary>
        /// <param name="iControl">控制层接口</param>
        /// <param name="iStorage">管理层接口</param>
        public bool Init( IAsrsCtlToManage iControl,ref IAsrsManageToCtl iStorage,ref string reStr )
        {
          
            this.iControl = iControl;
            StorageManager storage = new StorageManager();
            iStorage = (IAsrsManageToCtl)storage;
            iManage = iStorage;
            storageMana = storage;

            bool iniStatus = storage.Initialize(ref reStr);
            this.stockManaView.SetInterface(iManage, iControl);
            this.storageView.SetInterface(iManage, iControl);
            storage.eventRegistForm += RegistExtendFormEventHandler;
            return iniStatus;
        }
        private void RegistExtendFormEventHandler(object sender,ExtendFormEventArgs e)
        {
            this.storageView.RegisterExtForm(e.StorForm);
            this.stockManaView.RegisterExtForm(e.StorListForm);
        }
        /// <summary>
        /// 添加日志接口
        /// </summary>
        /// <param name="log"></param>
        public void ShowLog(LogModel log )
        {
            if(this.logRecorder== null)
            {
                return;
            }
            this.logRecorder.AddLog(log);
        }

        #region IModuleAttach接口实现
        public override void RegisterMenus(MenuStrip parentMenu, string rootMenuText)
        {

            ToolStripMenuItem rootMenuItem = new ToolStripMenuItem(rootMenuText);//parentMenu.Items.Add("仓储管理");
            //rootMenuItem.Click += LoadMainform_MenuHandler;
            parentMenu.Items.Add(rootMenuItem);
            ToolStripItem stockQuery = rootMenuItem.DropDownItems.Add("库存列表");
            ToolStripItem storageView = rootMenuItem.DropDownItems.Add("货位看板");

            //if (parentPNP.RoleID == 1)
            //{

                ToolStripItem sysDefineItem = rootMenuItem.DropDownItems.Add("操作记录");
                sysDefineItem.Click += LoadView_MenuHandler;
            //}
            stockQuery.Click += LoadView_MenuHandler;
            storageView.Click += LoadView_MenuHandler;
            //userItem.Click += LoadView_MenuHandler;
            //sysSetItem.Click += LoadView_MenuHandler;
            //detectCodeItem.Click += LoadView_MenuHandler;
        }
        public override void SetParent(/*Control parentContainer, Form parentForm, */IParentModule parentPnP)
        {
            this.parentPNP = parentPnP;
            this.storageView.SetParent(this.parentPNP);
            this.stockManaView.SetParent(this.parentPNP);
            //if (parentPNP.RoleID == 1)
            //{
            //    sysDefineView = new SysDefineView("系统维护");
            //    this.sysDefineView.SetParent(parentPnP);
            //}
            //this.productDSview.SetParent(parentPnP);
            //this.sysSettignView.SetParent(parentPnP);
            //this.userManageView.SetParent(parentPnP);
            //this.detectCodeView.SetParent(parentPNP);
        }
        public override void SetLoginterface(ILogRecorder logRecorder)
        {
            this.logRecorder = logRecorder;
            this.stockManaView.SetLoginterface(logRecorder);
            this.storageView.SetLoginterface(logRecorder);
        }

        private void LoadView_MenuHandler(object sender, EventArgs e)
        {
            ToolStripItem menuItem = sender as ToolStripItem;
         
            if (menuItem == null)
            {
                return;
            }
            switch (menuItem.Text)
            {
                case "库存列表":
                    {
                        this.parentPNP.AttachModuleView(this.stockManaView);
                        this.stockManaView.SetMenuLimit();
                        break;
                    }
                case "货位看板":
                    {
                        this.parentPNP.AttachModuleView(this.storageView);
                        this.storageView.SetMenuLimit();
                        break;
                    }
                case "操作记录":
                    {
                        if (this.parentPNP.RoleID > 2)
                        {
                            MessageBox.Show("当前用户没有此功能的操作权限！", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            break;
                        }
                        this.parentPNP.AttachModuleView(this.stockOperteView);
                        break;
                    }
                default:
                    break;
            }


        }
        #endregion
    }
}
