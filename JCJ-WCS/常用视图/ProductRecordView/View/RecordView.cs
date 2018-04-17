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

using DevAccess;
using DevInterface;
namespace ProductRecordView
{
    public partial class RecordView : BaseChildView
    {
        private ProduceTraceView produceRecord = null;
        private ProductDataView productData = null;
        private HkTestForm hkTestView = null;
        public RecordView():base(string.Empty)
        {
            InitializeComponent();
            this.produceRecord = new ProduceTraceView("生产追溯");
            this.productData = new ProductDataView("产品数据");
            hkTestView = new HkTestForm("杭可测试结果");
        }

        public void SetHKAccessObj(IHKAccess hkAccess)
        {
            productData.HkAccess = hkAccess;
        }
        public void SetOcvAccessObj(OcvAccess ocv)
        {
            hkTestView.OcvAccess = ocv;
        }
        #region IModuleAttach接口实现
        public override void RegisterMenus(MenuStrip parentMenu, string rootMenuText)
        {

            ToolStripMenuItem rootMenuItem = new ToolStripMenuItem(rootMenuText);//parentMenu.Items.Add("仓储管理");
            //rootMenuItem.Click += LoadMainform_MenuHandler;
            parentMenu.Items.Add(rootMenuItem);
            ToolStripItem productRecordItem = rootMenuItem.DropDownItems.Add("生产追溯");
            ToolStripItem productDataItem = rootMenuItem.DropDownItems.Add("产品数据");
            ToolStripItem hkOcvTestItem = rootMenuItem.DropDownItems.Add("杭可测试结果");
            productRecordItem.Click += LoadView_MenuHandler;
            productDataItem.Click += LoadView_MenuHandler;
            hkOcvTestItem.Click += LoadView_MenuHandler;
        }
        public override void SetParent(/*Control parentContainer, Form parentForm, */IParentModule parentPnP)
        {
            this.parentPNP = parentPnP;
            
            this.produceRecord.SetParent(parentPnP);
           
        }
        public override void SetLoginterface(ILogRecorder logRecorder)
        {
            this.logRecorder = logRecorder;
            //   lineMonitorPresenter.SetLogRecorder(logRecorder);
            this.produceRecord.SetLoginterface(logRecorder);
            this.productData.SetLoginterface(logRecorder);
            this.hkTestView.SetLoginterface(logRecorder);
        }
       
        #endregion
        private void LoadView_MenuHandler(object sender, EventArgs e)
        {
            ToolStripItem menuItem = sender as ToolStripItem;
            if (menuItem == null)
            {
                return;
            }
            switch (menuItem.Text)
            {
                case "生产追溯":
                    {
                        this.parentPNP.AttachModuleView(this.produceRecord);
                        break;
                    }
                case "产品数据":
                    {
                        this.parentPNP.AttachModuleView(this.productData);
                        break;
                    }
                case "杭可测试结果":
                        {
                            this.parentPNP.AttachModuleView(this.hkTestView);
                            break;
                        }
                default:
                    break;
            }


        }
    }
}
