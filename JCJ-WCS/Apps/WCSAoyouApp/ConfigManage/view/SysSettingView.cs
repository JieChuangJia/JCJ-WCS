using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Xml;
using System.Xml.Linq;
using ModuleCrossPnP;
using LogInterface;
//using CtlDBAccess.BLL;
using MesDBAccess.Model;
using MesDBAccess.BLL;
namespace ConfigManage
{
    public partial class SysSettingView : BaseChildView
    {
        private BatchBll batchBll = new BatchBll();
        private  ProcessStepBll processStepBll = new ProcessStepBll();
        private List<FlowCtlBaseModel.CtlNodeBaseModel> nodeCfgList = new List<FlowCtlBaseModel.CtlNodeBaseModel>();
        #region  公有接口
       // public string CaptionText { get { return captionText; } set { captionText = value; this.Text = captionText; } }
        public SysSettingView(string captionText):base(captionText)
        {
            InitializeComponent();
            //sysCfg = new SysCfgsettingModel();

           
            this.Text = captionText;
            //this.captionText = captionText;
           
           
            

        }
        public void SetCfgNodes(List<FlowCtlBaseModel.CtlNodeBaseModel> cfgNodes)
        {
            nodeCfgList = cfgNodes;
        }
        public override void ChangeRoleID(int roleID)
        {
           
            
        }
        #endregion

        private void buttonCfgApply_Click(object sender, EventArgs e)
        {
            string reStr = "";
            foreach (FlowCtlBaseModel.CtlNodeBaseModel node in nodeCfgList)
            {
                if (node.NodeID == "1001")
                {
                    node.NodeEnabled =this.checkBoxHouseA1.Checked ;
                }
                else if (node.NodeID == "1002")
                {
                    node.NodeEnabled = this.checkBoxHouseA2.Checked;
                }
                else if (node.NodeID == "1003")
                {
                    node.NodeEnabled = this.checkBoxHouseC1.Checked;
                }
                else if (node.NodeID == "1004")
                {
                     node.NodeEnabled=this.checkBoxHouseC2.Checked;
                }
                else
                {
                    break;
                }
                node.SaveCfg();
            }
            if (!SysCfg.SysCfgModel.SaveCfg(ref reStr))
            {
                MessageBox.Show(reStr);
                return;
            }
            OnModifyProcessParams();
            MessageBox.Show("设置已保存！");
            
        }

        private void buttonCancelSet_Click(object sender, EventArgs e)
        {
            
        }

        private void SysSettingView_Load(object sender, EventArgs e)
        {
            
            //this.checkBoxHouseA.Checked = SysCfg.SysCfgModel.HouseEnabledA;
            //this.checkBoxHouseB.Checked = SysCfg.SysCfgModel.HouseEnabledB;
         //   this.textBoxA1BurninTime.Text = SysCfg.SysCfgModel.AsrsStoreTime.ToString();
        //    this.checkBoxUnbind.Checked = SysCfg.SysCfgModel.UnbindMode;
            OnDispProcessParams();

        }

        private void btnRefresBatchCfg_Click(object sender, EventArgs e)
        {
            OnRefreshBatchDisp();
        }

        private void buttonAddBatch_Click(object sender, EventArgs e)
        {
           
        }

        private void buttonCancelBatch_Click(object sender, EventArgs e)
        {
         
        }

        private void btnDelBatchCfg_Click(object sender, EventArgs e)
        {
           
        }
        private void OnRefreshBatchDisp()
        {
            DataSet ds = batchBll.GetAllList();
            DataTable dt = ds.Tables[0];
            
           
            
           
        }
       
        private void btnModifyBatch_Click(object sender, EventArgs e)
        {
          
            MessageBox.Show("修改完成");
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void buttonImportCfg_Click(object sender, EventArgs e)
        {
            
        }
      
        private void buttonDispCfg_Click(object sender, EventArgs e)
        {
           
        }
      
        private void buttonSaveCfg_Click(object sender, EventArgs e)
        {
            OnSaveCfg();
        }
        private void OnSaveCfg()
        {
            
        }

     
        private void btnDispProcessParams_Click(object sender, EventArgs e)
        {
            OnDispProcessParams();
        }
        private void OnDispProcessParams()
        {
            foreach (FlowCtlBaseModel.CtlNodeBaseModel node in nodeCfgList)
            {
                if (node.NodeID == "1001")
                {
                    this.checkBoxHouseA1.Checked = node.NodeEnabled;
                }
                else if (node.NodeID == "1002")
                {
                    this.checkBoxHouseA2.Checked = node.NodeEnabled;
                }
                else if (node.NodeID == "1003")
                {
                    this.checkBoxHouseB1.Checked = node.NodeEnabled;
                }
                else if (node.NodeID == "1004")
                {
                    this.checkBoxHouseC1.Checked = node.NodeEnabled;
                }
                else if (node.NodeID == "1005")
                {
                    this.checkBoxHouseC2.Checked = node.NodeEnabled;
                }
                else if (node.NodeID == "1006")
                {
                    this.checkBoxHouseC3.Checked = node.NodeEnabled;
                }
                else
                {
                    break;
                }
            }



            string strWhere = string.Format("stepCata='{0}'","存储");
            DataSet ds = processStepBll.GetList(1000,strWhere, "stepNO");
            DataTable dt = ds.Tables[0];
            this.dataGridView1.DataSource = dt;
            this.dataGridView1.Columns["stepNO"].HeaderText = "工步号";

            this.dataGridView1.Columns["stepCata"].Visible = false;
           
            this.dataGridView1.Columns["tag2"].Visible = false;
            this.dataGridView1.Columns["tag3"].Visible = false;
            this.dataGridView1.Columns["tag4"].Visible = false;
            this.dataGridView1.Columns["tag5"].Visible = false;
            this.dataGridView1.Columns["processStepName"].ReadOnly = true;
            this.dataGridView1.Columns["processStepName"].HeaderText = "老化工艺";
            this.dataGridView1.Columns["tag1"].HeaderText = "老化时间（小时）";
            this.dataGridView1.Columns["processStepName"].Width = 200;
            this.dataGridView1.Columns["tag1"].Width = 200;
            this.dataGridView1.Columns["tag1"].ValueType = typeof(float);
        }
        private void OnModifyProcessParams()
        {
            
            DataTable dt = this.dataGridView1.DataSource as DataTable;
            if(dt == null || dt.Rows.Count<1)
            {
                return;
            }
            foreach(DataRow dr in dt.Rows)
            {
                int processID = int.Parse(dr["stepNO"].ToString());
                ProcessStepModel process = processStepBll.GetModel(processID);
                if(process == null)
                {
                    continue;
                }
                float processVal= 0;
                if(!float.TryParse(dr["tag1"].ToString(),out processVal))
                {
                    continue;
                }
                process.tag1 = dr["tag1"].ToString();
                processStepBll.Update(process);
            }
        }

        private void btnDispProcessParams_Click_1(object sender, EventArgs e)
        {
            OnDispProcessParams();
        }
        private void OnCfgApply()
        {
            string reStr = "";

            foreach (FlowCtlBaseModel.CtlNodeBaseModel node in nodeCfgList)
            {
                if (node.NodeID == "1001")
                {
                    node.NodeEnabled = this.checkBoxHouseA1.Checked;
                }
                else if (node.NodeID == "1002")
                {
                    node.NodeEnabled = this.checkBoxHouseA2.Checked;
                }
                else if (node.NodeID == "1003")
                {
                    node.NodeEnabled = this.checkBoxHouseB1.Checked;
                }
                else if (node.NodeID == "1004")
                {
                    node.NodeEnabled = this.checkBoxHouseC1.Checked;
                }
                else if (node.NodeID == "1005")
                {
                    node.NodeEnabled = this.checkBoxHouseC2.Checked;
                }
                else if (node.NodeID == "1006")
                {
                    node.NodeEnabled = this.checkBoxHouseC3.Checked;
                }
                else
                {
                    break;
                }
                node.SaveCfg();
            }
           
            OnModifyProcessParams();
            if (!SysCfg.SysCfgModel.SaveCfg(ref reStr))
            {
                MessageBox.Show(reStr);
                return;
            }
            MessageBox.Show("设置已保存！");
        }
        private void buttonCfgApply_Click_1(object sender, EventArgs e)
        {
            OnCfgApply();
        }
    }
}
