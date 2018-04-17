using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AsrsModel;
using ModuleCrossPnP;
using AsrsInterface;
namespace AsrsControl
{
    public partial class CtlTaskView : BaseChildView,ICtlTaskView
    {
        private CtlTaskPresenter taskPresenter = null;
       
        public CtlTaskView(string captionText):base(captionText)
        {
            InitializeComponent();
            this.Text = captionText;
            this.taskPresenter = new CtlTaskPresenter(this);
        }
        public void SetNodeNames(IDictionary<string, string> nodeMap)
        {
            this.comboBox1.Items.Clear();
            foreach(string nodeID in nodeMap.Keys)
            {
                this.comboBox1.Items.Add(nodeMap[nodeID]);

            }
            if(this.comboBox1.Items.Count>0)
            {
                this.comboBox1.SelectedIndex = 0;
            }
            taskPresenter.SetTaskNodemap(nodeMap);
            
        }
        public void SetAsrsResManage(IAsrsManageToCtl asrsResManage)
        {
            this.taskPresenter.SetAsrsResManage(asrsResManage);
        }
        #region ICtlTaskView接口实现
        public void RefreshTaskDisp(DataTable dt)
        {
            BindingSource bs = new BindingSource();
            bs.DataSource = dt;
            bindingNavigator1.BindingSource = bs;
            dataGridView1.DataSource = bs;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }
     
        #endregion
        #region UI事件

        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            taskPresenter.TaskFilter.CellCondition = checkBoxCell.Checked;
            taskPresenter.TaskFilter.PrivelegeType = this.comboBoxOrderType.Text;
            if (checkBoxCell.Checked)
            {
                taskPresenter.TaskFilter.Cell = this.textBoxCell.Text;
            }
            taskPresenter.TaskFilter.LikeQuery = checkBoxMohu.Checked;
            if(checkBoxMohu.Checked)
            {
                taskPresenter.TaskFilter.LikeStr = this.textBoxMohu.Text;
            }
           
            taskPresenter.QueryTask();
        }

        private void CtlTaskView_Load(object sender, EventArgs e)
        {
            //this.comboBox1.Items.Clear();
            //this.comboBox1.Items.AddRange(new string[] {"所有","A1库","B1库","C1库","C2库","托盘绑定1","托盘绑定2","分拣1","分拣2","分拣3" });
            //this.comboBox1.SelectedIndex = 0;

            this.comboBox2.Items.AddRange(new string[] { "所有", SysCfg.EnumAsrsTaskType.产品入库.ToString(), 
                SysCfg.EnumAsrsTaskType.产品出库.ToString(), 
                SysCfg.EnumAsrsTaskType.空筐入库.ToString(), 
                SysCfg.EnumAsrsTaskType.空筐出库.ToString(), 
                SysCfg.EnumAsrsTaskType.移库.ToString()});

            this.comboBox3.Items.AddRange(new string[] { "所有", SysCfg.EnumTaskStatus.待执行.ToString(), SysCfg.EnumTaskStatus.执行中.ToString(), SysCfg.EnumTaskStatus.已完成.ToString(), SysCfg.EnumTaskStatus.超时.ToString(), SysCfg.EnumTaskStatus.任务撤销.ToString() });
            this.comboBoxOrderType.Items.AddRange(new string[] { "无","由高到低","由低到高"});
            this.comboBoxOrderType.SelectedIndex = 0;
            
            this.comboBox2.SelectedIndex = 0;
            this.comboBox3.SelectedIndex = 0;
            taskPresenter.TaskFilter.NodeName = this.comboBox1.Text;
            taskPresenter.TaskFilter.TaskType = this.comboBox2.Text;
            taskPresenter.TaskFilter.TaskStatus = this.comboBox3.Text;
            this.dateTimePicker1.DataBindings.Add("Value", taskPresenter.TaskFilter, "StartDate");
            this.dateTimePicker2.DataBindings.Add("Value", taskPresenter.TaskFilter, "EndDate");
            this.comboBox1.DataBindings.Add("Text", taskPresenter.TaskFilter, "NodeName");
            this.comboBox2.DataBindings.Add("Text", taskPresenter.TaskFilter, "TaskType");
            this.comboBox3.DataBindings.Add("Text", taskPresenter.TaskFilter, "TaskStatus");
            this.toolTip1.SetToolTip(this.textBoxPrivilege,"请输入0~1000的数值，数值越大，优先级越高");
           
          
        }
        private void btnDelTask_Click(object sender, EventArgs e)
        {
            OnDelTask();
        }
        private void OnDelTask()
        {
            if(parentPNP.RoleID>2)
            {
                MessageBox.Show("没有足够的权限，请切换到管理员用户");
                return;
            }
            List<string> taskIds = new List<string>();
            foreach(DataGridViewRow dr in dataGridView1.SelectedRows)
            {
                taskIds.Add(dr.Cells["任务ID"].Value.ToString());
            }
            if(taskIds.Count()>0)
            {
                taskPresenter.DelTask(taskIds);
            }
        }
        #endregion   

        private void buttonModifyPri_Click(object sender, EventArgs e)
        {
            try
            {
                int pri = 0;
                if (!int.TryParse(this.textBoxPrivilege.Text, out pri))
                {
                    MessageBox.Show("请输入正确的优先级值0~1000,值越大优先级越高!");
                    return;
                }
                if (pri < 0 || pri > 1000)
                {
                    MessageBox.Show("请输入正确的优先级值0~1000,值越大优先级越高!");
                    return;
                }
                foreach (DataGridViewRow dr in this.dataGridView1.SelectedRows)
                {
                    string taskID = dr.Cells["任务ID"].Value.ToString();
                    string reStr="";
                    if(!taskPresenter.ModifyTaskPri(taskID, pri,ref reStr))
                    {
                        MessageBox.Show(reStr);
                        return;
                    }
                }
                taskPresenter.QueryTask();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString()) ;
            }
           
        }
    }
}
