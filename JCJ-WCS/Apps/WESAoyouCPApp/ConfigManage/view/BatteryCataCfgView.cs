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
    
    public partial class BatteryCataCfgView :BaseChildView
    {
        public delegate bool dlgtSendDevlinePalletCfg(string shopSection, ref string reStr); //下发产线-料筐类型配置
        public delegate bool dlgtGetPalletCfgFromPlc(string shopSection, ref DataTable dt, ref string reStr); //从PLC 读产线-料筐型号配置
        #region 公有接口
        public dlgtSendDevlinePalletCfg dlgtSndPalletCfg;
        public dlgtGetPalletCfgFromPlc dlgtGetPalletCfg;
        public BatteryCataCfgView(string captionText)
            : base(captionText)
        {
            InitializeComponent();
            this.Text = captionText;
            this.comboBox3.Items.AddRange(new string[] { "所有", "注液", "化成", "二封" });
            this.comboBox3.SelectedIndex = 0;
            this.comboBox2.Items.AddRange(new string[] { "分容A区", "分容B区", "分容C区", "分容D区" });
            this.comboBox2.SelectedIndex = 0;
        }
        public override void ChangeRoleID(int roleID)
        {
            if(roleID==1)
            {
                if(!tabControl1.TabPages.Contains(this.tabPage3))
                {
                    tabControl1.TabPages.Insert(0,tabPage3);
                    tabPage3.Parent = this.tabControl1;
                    
                }
            }
            else
            {
                tabControl1.TabPages.Remove(tabPage3);
                tabPage3.Parent = null;
            }
            

        }
        #endregion
        private void BatteryCataCfgView_Load(object sender, EventArgs e)
        {
            RefreshDevCfg();
        }
        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void buttonPalletSndCfg_Click(object sender, EventArgs e)
        {
            if(dlgtSndPalletCfg != null)
            {
                string reStr = "";
                dlgtSndPalletCfg("所有",ref reStr);
            }
        }

        private void buttonReadPlcCfg_Click(object sender, EventArgs e)
        {
            DataTable dt = null;
            string reStr="";
            if(this.dlgtGetPalletCfg != null)
            {
                if(!dlgtGetPalletCfg(this.comboBox3.Text,ref dt,ref reStr))
                {
                    Console.WriteLine("读PLC配置失败"+reStr);
                    return;
                }
                this.dataGridView4.DataSource = dt;
   
                this.dataGridView4.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
                this.dataGridView4.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            }
        }
        private void RefreshDevCfg()
        {
            MesDBAccess.BLL.BatteryCataBll batCataBll = new MesDBAccess.BLL.BatteryCataBll();
            List <string> batCatas=GetBatteryCataList();
            this.comboBox4.Items.Clear();
            if(batCatas.Count>0)
            {
                this.comboBox4.Items.AddRange(batCatas.ToArray());
            }
            
            if(this.comboBox4.Items.Count>0)
            {
                this.comboBox4.SelectedIndex = 0;
            }
            MesDBAccess.BLL.ViewDevLineBatteryCfgBll devLineCfgBll = new MesDBAccess.BLL.ViewDevLineBatteryCfgBll();
            string strWhere="";
            if(comboBox3.Text != "所有")
            {
                strWhere = string.Format("ShopSection='{0}' ",comboBox3.Text);
            }
            DataSet ds = devLineCfgBll.GetList(strWhere);
            this.dataGridView2.DataSource = ds.Tables[0];
            this.dataGridView2.Columns["DevBatteryCfgID"].HeaderText = "产线配置ID";
            this.dataGridView2.Columns["ShopSection"].HeaderText = "工段名称";
            this.dataGridView2.Columns["LineID"].HeaderText = "产线序号";
            this.dataGridView2.Columns["mark"].HeaderText = "描述";
            this.dataGridView2.Columns["batteryCataCode"].HeaderText = "电芯型号";
            this.dataGridView2.Columns["palletCataID"].HeaderText = "料筐型号";
            this.dataGridView2.Columns["plcDefVal"].HeaderText = "PLC值";
            this.dataGridView2.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

        }
        private void buttonRefreshDevCfg_Click(object sender, EventArgs e)
        {
            RefreshDevCfg();
        }

        private void dataGridView2_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            //Console.WriteLine("hh{0}",e.RowIndex);
            string id=this.dataGridView2.Rows[e.RowIndex].Cells["DevBatteryCfgID"].Value.ToString();
            MesDBAccess.BLL.DevLineBatteryCfgBll devCfgBll = new MesDBAccess.BLL.DevLineBatteryCfgBll();
            MesDBAccess.Model.DevLineBatteryCfgModel devCfgModel= devCfgBll.GetModel(id);
            if(devCfgModel == null)
            {
                Console.WriteLine("不存在的配置：{0}", id);
                return;
            }
            this.textBox5.Text = devCfgModel.DevBatteryCfgID;
            this.comboBox4.Text = devCfgModel.batteryCataCode;
            this.textBox4.Text = devCfgModel.mark;
        }
        private void OnModifyDevCfg()
        {
            string id = this.textBox5.Text;
            MesDBAccess.BLL.DevLineBatteryCfgBll devCfgBll = new MesDBAccess.BLL.DevLineBatteryCfgBll();
            MesDBAccess.Model.DevLineBatteryCfgModel devCfgModel = devCfgBll.GetModel(id);
            if (devCfgModel == null)
            {
                MessageBox.Show(string.Format("不存在的配置：{0}", id),"提示");
                return;
            }
            devCfgModel.batteryCataCode = this.comboBox4.Text;
            devCfgModel.mark = this.textBox4.Text;
            devCfgBll.Update(devCfgModel);
        }
        private void button5_Click(object sender, EventArgs e)
        {
            OnModifyDevCfg();
            RefreshDevCfg();
        }
        private void OnRefreshBatteryCata()
        {
            MesDBAccess.BLL.PalletCataBll palletCataBll = new MesDBAccess.BLL.PalletCataBll();
            List<MesDBAccess.Model.PalletCataModel> palletCatas= palletCataBll.GetModelList("");
            this.comboBox6.Items.Clear();
            foreach(MesDBAccess.Model.PalletCataModel m in palletCatas)
            {
                this.comboBox6.Items.Add(m.PalletCataID);
            }
            if (this.comboBox6.Items.Count > 0)
            {
                this.comboBox6.SelectedIndex = 0;
            }
            MesDBAccess.BLL.BatteryCataBll batCatBll = new MesDBAccess.BLL.BatteryCataBll();
            DataSet ds= batCatBll.GetAllList();
            this.dataGridView3.DataSource = ds.Tables[0];
            this.dataGridView3.Columns["batteryCataCode"].HeaderText = "电芯型号";
            this.dataGridView3.Columns["palletCataID"].HeaderText = "料筐型号";
            this.dataGridView3.Columns["mark"].HeaderText = "备注";
            this.dataGridView3.Columns["tag1"].Visible=false;
            this.dataGridView3.Columns["tag2"].Visible = false;
            this.dataGridView3.Columns["tag3"].Visible = false;
            this.dataGridView3.Columns["tag4"].Visible = false;
            this.dataGridView3.Columns["tag5"].Visible = false;
            this.dataGridView3.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView3.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

        }
        private void button11_Click(object sender, EventArgs e)
        {
            OnRefreshBatteryCata();
        }

        private void OnAddBatteryCata()
        {
            string batteryCata = this.textBox2.Text;
            if(string.IsNullOrWhiteSpace(batteryCata))
            {
                MessageBox.Show("电芯型号不能为空,请重新输入");
                return;
            }
            MesDBAccess.BLL.BatteryCataBll batCatBll = new MesDBAccess.BLL.BatteryCataBll();
            if(batCatBll.Exists(batteryCata))
            {
                MessageBox.Show(string.Format("电芯型号{0}已经存在",batteryCata));
                return;
            }
            try
            {
                MesDBAccess.Model.BatteryCataModel batCataModel = new MesDBAccess.Model.BatteryCataModel();
                batCataModel.batteryCataCode = batteryCata;
                batCataModel.palletCataID = this.comboBox6.Text;
                batCataModel.mark = this.textBox1.Text;
                batCatBll.Add(batCataModel);
                OnRefreshBatteryCata();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                
            }
           
        }
        private void button8_Click(object sender, EventArgs e)
        {
            OnAddBatteryCata();
        }
        private void OnModifyBatteryCata()
        {
            string batteryCata = this.textBox2.Text;
            if (string.IsNullOrWhiteSpace(batteryCata))
            {
                MessageBox.Show("电芯型号不能为空,请重新输入");
                return;
            }
            try
            {
                MesDBAccess.BLL.BatteryCataBll batCatBll = new MesDBAccess.BLL.BatteryCataBll();
                MesDBAccess.Model.BatteryCataModel batCataModel = batCatBll.GetModel(batteryCata);
                if (batCataModel == null)
                {
                    MessageBox.Show(string.Format("电芯型号{0}不存在", batteryCata));
                    return;
                }
                batCataModel.palletCataID = this.comboBox6.Text;
                batCataModel.mark = this.textBox1.Text;
                if(batCatBll.Update(batCataModel))
                {
                    MessageBox.Show("修改成功！");
                    OnRefreshBatteryCata();
                }
                else
                {
                    MessageBox.Show("修改失败！");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            
        }
        private void button6_Click(object sender, EventArgs e)
        {
            OnModifyBatteryCata();
        }
        private List<string> GetBatteryCataList()
        {
            MesDBAccess.BLL.BatteryCataBll batCataBll = new MesDBAccess.BLL.BatteryCataBll();
            List<MesDBAccess.Model.BatteryCataModel> batCatas = batCataBll.GetModelList("");
            List<string> batCataList = new List<string>();
            foreach (MesDBAccess.Model.BatteryCataModel m in batCatas)
            {
                batCataList.Add(m.batteryCataCode);
            }
            return batCataList;
        }
        private void button7_Click(object sender, EventArgs e)
        {
            List<string> batCatas = GetBatteryCataList();
            this.comboBox1.Items.Clear();
            if (batCatas.Count > 0)
            {
                this.comboBox1.Items.AddRange(batCatas.ToArray());
                this.comboBox1.SelectedIndex = 0;
            }
        }

        private void OnRefreshFenrongCfgs(string strWhere)
        {
            MesDBAccess.BLL.BatteryFenrongCfgBll fenrongCfgBll = new MesDBAccess.BLL.BatteryFenrongCfgBll();
            DataSet ds= fenrongCfgBll.GetList(strWhere);
            this.dataGridView1.DataSource = ds.Tables[0];
            this.dataGridView1.Columns["fenrongCfgID"].HeaderText = "配置ID";
            this.dataGridView1.Columns["batteryCataCode"].HeaderText = "电芯型号";
            this.dataGridView1.Columns["fenrongZone"].HeaderText = "分容库区";
            this.dataGridView1.Columns["mark"].HeaderText = "备注";
            this.dataGridView1.Columns["tag1"].Visible=false;
            this.dataGridView1.Columns["tag2"].Visible = false;
            this.dataGridView1.Columns["tag3"].Visible = false;
            this.dataGridView1.Columns["tag4"].Visible = false;
            this.dataGridView1.Columns["tag5"].Visible = false;
            this.dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            OnRefreshFenrongCfgs("");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OnRefreshFenrongCfgs(string.Format("batteryCataCode='{0}'",this.comboBox1.Text));
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OnRefreshFenrongCfgs(string.Format("fenrongZone='{0}'", this.comboBox2.Text));
        }

        private void OnAddFenrongCfg()
        {
            string batteryCata = this.comboBox1.Text;
            string fenrongZone = this.comboBox2.Text;
            if(string.IsNullOrWhiteSpace(batteryCata) || string.IsNullOrWhiteSpace(fenrongZone))
            {
                MessageBox.Show("输入为空，请重新输入");
                return;
            }
            MesDBAccess.BLL.BatteryFenrongCfgBll fenrongCfgBll = new MesDBAccess.BLL.BatteryFenrongCfgBll();
            if(fenrongCfgBll.Exist(batteryCata,fenrongZone))
            {
                MessageBox.Show(string.Format("已经存在{0}-{1}配置", batteryCata, fenrongZone), "提示");
                return;
            }
            MesDBAccess.Model.BatteryFenrongCfgModel fenrongCfg = new MesDBAccess.Model.BatteryFenrongCfgModel();
            fenrongCfg.batteryCataCode = batteryCata;
            fenrongCfg.fenrongZone = fenrongZone;
            fenrongCfg.fenrongCfgID = System.Guid.NewGuid().ToString();
            fenrongCfg.mark = textBox3.Text;
            fenrongCfgBll.Add(fenrongCfg);
        }
        private void button4_Click(object sender, EventArgs e)
        {
            OnAddFenrongCfg();
            OnRefreshFenrongCfgs(string.Format("batteryCataCode='{0}'", this.comboBox1.Text));
        }
        private void OnDelFenrongCfg()
        {
            string batteryCata = this.comboBox1.Text;
            string fenrongZone = this.comboBox2.Text;
            if (string.IsNullOrWhiteSpace(batteryCata) || string.IsNullOrWhiteSpace(fenrongZone))
            {
                MessageBox.Show("输入为空，请重新输入");
                return;
            }
            MesDBAccess.BLL.BatteryFenrongCfgBll fenrongCfgBll = new MesDBAccess.BLL.BatteryFenrongCfgBll();
            if (!fenrongCfgBll.Exist(batteryCata, fenrongZone))
            {
                MessageBox.Show(string.Format("{0}-{1}配置不存在", batteryCata, fenrongZone), "提示");
                return;
            }
            if(PoupAskmes("确定要删除？") != 1)
            {
                return;
            }
            if(fenrongCfgBll.Del(batteryCata, fenrongZone))
            {
                MessageBox.Show("删除成功!");
                OnRefreshFenrongCfgs(string.Format("batteryCataCode='{0}'", this.comboBox1.Text));
            }
        }
        private void button12_Click(object sender, EventArgs e)
        {
            OnDelFenrongCfg();
        }

        private void button10_Click(object sender, EventArgs e)
        {

        }
    }
}
