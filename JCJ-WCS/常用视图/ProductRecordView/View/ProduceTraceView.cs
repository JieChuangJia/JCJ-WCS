using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ModuleCrossPnP;
using MesDBAccess.BLL;
using MesDBAccess.Model;
using FlowCtlBaseModel;
using LogInterface;
namespace ProductRecordView
{
    public partial class ProduceTraceView : BaseChildView
    {
        #region 数据
        MesAccWrapper mesAcc = new MesAccWrapper();
        private TraceQueryFilter queryFilter = null;
        private ProduceRecordBll modRecordBll = new ProduceRecordBll();
      //  private BatteryBll batBll = new BatteryBll();
     //   private BatteryModuleBll batModBll = new BatteryModuleBll();
      //  private ProduceRecordBll recordBll = null;
        #endregion
        public ProduceTraceView(string captionText)
            : base(captionText)
        {
            InitializeComponent();
            queryFilter = new TraceQueryFilter();
            this.Text = captionText;
            //  this.captionText = captionText;


        }
        #region UI事件
        private void ProduceReccordView_Load(object sender, EventArgs e)
        {
            //过滤参数绑定
            this.comboBox1.Items.AddRange(new string[] {"料框","电芯"});
            this.comboBox1.SelectedIndex = 0;
            queryFilter.Cata = "料框";
            this.comboBox1.DataBindings.Add("Text", queryFilter, "Cata");
            this.textBoxBarcode.DataBindings.Add("Text", queryFilter, "BarCode");
            
        }

        private void buttonTrace_Click(object sender, EventArgs e)
        {
            OnRecordQuery();
        }
        private void OnRecordQuery()
        {


            string strWhere = string.Format("productID='{0}' and productCata='{1}' order by recordTime asc ", queryFilter.BarCode,queryFilter.Cata);
            DataSet ds = modRecordBll.GetList(strWhere);
            this.dataGridView1.DataSource = ds.Tables[0];
            
            this.dataGridView1.Columns["recordID"].Visible = false;
            this.dataGridView1.Columns["stationID"].Visible = false;
            this.dataGridView1.Columns["recordCata"].Visible = false;
            this.dataGridView1.Columns["tag2"].Visible = false;
            this.dataGridView1.Columns["tag3"].Visible = false;
            this.dataGridView1.Columns["tag4"].Visible = false;
            this.dataGridView1.Columns["tag5"].Visible = false;

            this.dataGridView1.Columns["checkResult"].HeaderText = "检测结果";
            this.dataGridView1.Columns["productID"].HeaderText = "条码";
            this.dataGridView1.Columns["productID"].Width = 200;
            this.dataGridView1.Columns["productCata"].HeaderText = "物料类别";
            this.dataGridView1.Columns["tag1"].HeaderText = "记录信息";
            this.dataGridView1.Columns["tag1"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridView1.Columns["tag2"].HeaderText = "料框条码";
            this.dataGridView1.Columns["recordTime"].HeaderText = "记录时间";
            this.dataGridView1.Columns["recordTime"].DefaultCellStyle.Format = "yyyy-MM-dd HH:mm:ss";
            this.dataGridView1.Columns["recordTime"].Width = 200;
        }
        #endregion

        private void buttonGetStep_Click(object sender, EventArgs e)
        {
            try
            {
                MesDBAccess.BLL.palletBll palletDBAcc = new palletBll();
                string palletID = this.textBoxBarcode.Text;
                int step = 0;
                string reStr = "";
                mesAcc.GetStep(palletID, out step, ref reStr);

                this.textBoxStep.Text = step.ToString();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
           
        }

        private void buttonModifyStep_Click(object sender, EventArgs e)
        {
            try
            {
               
                MesDBAccess.BLL.palletBll palletDBAcc = new palletBll();
                string palletID = this.textBoxBarcode.Text;
                if(string.IsNullOrWhiteSpace(palletID))
                {
                    return;
                }
                int step = int.Parse(this.textBoxStep.Text);
                string reStr = "";
                mesAcc.UpdateStep(step, palletID, ref reStr);
                logRecorder.AddDebugLog("手动操作",string.Format("手动操作，修改{0} 步号为{1}",palletID,step));
                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
           
        }

        #region 私有方法
        public override void ChangeRoleID(int roleID)
        {
             if(roleID>2)
             {
                 this.buttonModifyStep.Enabled = false;
             }
             else
             {
                 this.buttonModifyStep.Enabled = true;
             }
        }
      
        #endregion


    }
}
