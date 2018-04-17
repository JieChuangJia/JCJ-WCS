using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CtlMonitorInterface;
using AsrsModel;
using ModuleCrossPnP;
using MesDBAccess.BLL;
using MesDBAccess.Model;
namespace AsrsControl
{
    public partial class PortBufferMonitorView : BaseChildView
    {
        private IDictionary<string, string> portNameMap = null;
      //  public List<AsrsPortalModel>  AsrsPorts{ get; set; }
        public IAsrsMonitor AsrsMonitor { get; set; }
        public PortBufferMonitorView(string captionText)
            : base(captionText)
        {
           
            InitializeComponent();
            this.Text = captionText;
           
        }
        public override void ChangeRoleID(int roleID)
        {
            if(roleID>2)
            {
                this.btnAddPallet.Enabled = false;
                this.btnDel.Enabled = false;
                this.btnSave.Enabled = false;
                this.btnClearBuf.Enabled = false;
            }
            else
            {
                this.btnAddPallet.Enabled = true;
                this.btnDel.Enabled = true;
                this.btnSave.Enabled = true;
                this.btnClearBuf.Enabled = true;
            }
        }
        private void PortBufferView_Load(object sender, EventArgs e)
        {
            portNameMap = AsrsMonitor.GetAllAsrsPortNames();
     
        
            if (portNameMap.Keys.Count() > 0)
            {
                this.comboBoxPortin.Items.AddRange(portNameMap.Keys.ToArray());
                this.comboBoxPortin.SelectedIndex = 0;
            }
            ContextMenuStrip listboxMenu = new ContextMenuStrip();
            ToolStripMenuItem rightMenu = new ToolStripMenuItem("复制");
            rightMenu.Click += new EventHandler(Copy_Click);
            listboxMenu.Items.AddRange(new ToolStripItem[] { rightMenu });
            this.listBoxPallet.ContextMenuStrip = listboxMenu;
        }
        private void Copy_Click(object sender, EventArgs e)
        {
            string CopyText = "";
            if(this.listBoxPallet.SelectedItems.Count>0)
            {
                CopyText = this.listBoxPallet.SelectedItems[0].ToString();
            }
           
            Clipboard.SetText(CopyText);
        }
        private void btnRefresh_Click(object sender, EventArgs e)
        {

        }
        private void OnDispPortbuffer()
        {
            MesDBAccess.BLL.AsrsPortBufferBll portBufBll = new AsrsPortBufferBll();
            if (!portNameMap.Keys.Contains(this.comboBoxPortin.Text))
            {
                MessageBox.Show("不存在的入库口");
                return;
            }
            this.listBoxPallet.Items.Clear();
            string portID = portNameMap[this.comboBoxPortin.Text];
            AsrsPortBufferModel bufModel = portBufBll.GetModel(portID);
            if(bufModel == null)
            {
                MessageBox.Show("数据库不存在该入口对象ID："+portID);
                return;
            }
            string[] palletArray = bufModel.palletBuffers.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
            if(palletArray != null && palletArray.Count()>0)
            {
                this.listBoxPallet.Items.AddRange(palletArray);
            }
        }
        private void btnModify_Click(object sender, EventArgs e)
        {

        }
        private void OnModifyPortbuffer()
        {

        }

        private void btnDispBuf_Click(object sender, EventArgs e)
        {
            OnDispPortbuffer();
        }

        private void comboBoxPortin_SelectedIndexChanged(object sender, EventArgs e)
        {
            OnDispPortbuffer();
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (this.listBoxPallet.SelectedIndex>=0)
            {
                logRecorder.AddDebugLog("人工操作", string.Format("手动移除入口{0}缓存托盘数据{1}", this.comboBoxPortin.Text, this.listBoxPallet.SelectedItem.ToString()));
                this.listBoxPallet.Items.RemoveAt(this.listBoxPallet.SelectedIndex);
            }
            
        }

        private void btnAddPallet_Click(object sender, EventArgs e)
        {
            OnAddPallet();
        }
        private void OnAddPallet()
        {
           
            string pallet = this.textBoxPallet.Text;
            if(string.IsNullOrWhiteSpace(pallet))
            {
                return;
            }
            if (this.listBoxPallet.Items.Count > 1)
            {
                MessageBox.Show("托盘数量已经达到上限");
                return;
            }
            if(this.listBoxPallet.Items.Contains(pallet))
            {
                MessageBox.Show("已经存在托盘：" + pallet);
                return;
            }
            this.listBoxPallet.Items.Add(pallet);
            logRecorder.AddDebugLog("人工操作", string.Format("手动添加托盘{0}到入口{1}缓存", pallet, this.comboBoxPortin.Text));
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                OnSave();
                logRecorder.AddDebugLog("人工操作", string.Format("手动操作,入口{0}托盘数据修正，已保存",this.comboBoxPortin.Text));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            
        }
        private void OnSave()
        {
            MesDBAccess.BLL.AsrsPortBufferBll portBufBll = new AsrsPortBufferBll();
            string portName = this.comboBoxPortin.Text;
            if (!portNameMap.Keys.Contains(portName))
            {
                MessageBox.Show("不存在的入库口");
                return;
            }
           
            string portID = portNameMap[portName];
            //AsrsPortalModel asrsPort = GetPortByID(portID);
            //if(asrsPort == null)
            //{
            //    MessageBox.Show("不存在的入库口对象");
            //    return;
            //}
            

            AsrsPortBufferModel bufModel = portBufBll.GetModel(portID);
            if (bufModel == null)
            {
                MessageBox.Show("数据库不存在该入口对象ID：" + portID);
                return;
            }
            string strPallets = "";
            AsrsMonitor.ClearPortBuffer(portName);
            List<string> pallets = new List<string>();
            for(int i=0;i<this.listBoxPallet.Items.Count;i++)
            {
                pallets.Add(this.listBoxPallet.Items[i].ToString());
                if(i==(this.listBoxPallet.Items.Count-1))
                {
                    strPallets += this.listBoxPallet.Items[i].ToString();
                }
                else
                {
                    strPallets += this.listBoxPallet.Items[i].ToString()+",";
                }
            }
            if (pallets.Count()>0)
            {
                AsrsMonitor.SetPortBuffer(portName, pallets.ToArray());
            }
            
            bufModel.palletBuffers = strPallets;
            portBufBll.Update(bufModel);
           
            
        }

        private void btnClearBuf_Click(object sender, EventArgs e)
        {
            this.listBoxPallet.Items.Clear();
        }
        private void label15_Click(object sender, EventArgs e)
        {

        }

    }
}
