using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevAccess;
using DevInterface;
namespace AsrsUtil
{
    public partial class Form1 : Form,IMainView
    {
        private string version = "系统版本:1.0.0  2018-3-7";
        private delegate void DlgtRefreshPLCComm();
        MainPresenter presenter = null;
        public Form1()
        {
          
            InitializeComponent();
            presenter = new MainPresenter(this);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        private bool OnConnPlc()
        {
            try
            {

                string PlcIP = this.textBoxPlcIP.Text;//ConfigurationManager.AppSettings["plcIP"];
                int PlcPort = int.Parse(this.textBoxPlcPort.Text);
                EnumNetProto proto = EnumNetProto.TCP;
                EnumPlcCata plcCata = EnumPlcCata.FX5U;
                if (this.radionTcp.Checked)
                {
                    proto = EnumNetProto.TCP;
                }
                else
                {
                    proto = EnumNetProto.UDP;
                }
                switch (cbxPlcCata.Text)
                {
                    case "FX5U":
                        {
                            plcCata = EnumPlcCata.FX5U;
                            break;
                        }
                    case "Q系列":
                        {
                            plcCata = EnumPlcCata.Qn;
                            break;
                        }
                    case "Fx3uNET模块":
                        {
                            plcCata = EnumPlcCata.FX3UENET;
                            break;
                        }
                    default:
                        break;
                }
                if(presenter.ConnPlc(PlcIP, PlcPort, plcCata, proto))
                {
                    label2.Text = "PLC 连接成功！";
                    this.buttonClosePlc.Enabled = true;
                    this.buttonConnectPlc.Enabled = false;
                    return true;
                }
                else
                {
                    label2.Text = "PLC 连接失败！";
                    return false;
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
        }
        private void buttonConnectPlc_Click(object sender, EventArgs e)
        {
            if(OnConnPlc())
            {
                this.btnStartRun.Enabled = true;
            }
            else
            {
                this.btnStartRun.Enabled = false;
            }
        }
        private void OnClosePlc()
        {
            presenter.plcRW.CloseConnect();
            this.buttonClosePlc.Enabled = false;
            this.buttonConnectPlc.Enabled = true;
            this.label2.Text = "PLC 通信关闭!";
        }
        private void buttonClosePlc_Click(object sender, EventArgs e)
        {
            OnClosePlc();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.labelVersion.Text = this.version;
            this.btnStartRun.Enabled = false;
            if(!presenter.Init())
            {
                Console.WriteLine("初始化错误!");
                return;
            }
            this.comboBoxTasks.Items.AddRange(new string[] {"产品入库","产品出库" });
            this.comboBoxTasks.SelectedIndex = 0;
            if(MainPresenter.SimMode)
            {
                for(int i=0;i<10;i++)
                {
                    this.comboBoxDB2.Items.Add((i + 1).ToString());
                }
                this.comboBoxDB2.SelectedIndex = 0;
                
            }
            else
            {
                this.panelSim.Visible = false;
            }
            this.cbxPlcCata.Items.AddRange(new string[] { "FX5U", "Q系列", "Fx3uNET模块" });
            this.cbxPlcCata.SelectedIndex = 0;
            Console.SetOut(new TextBoxWriter(this.richTextBoxLog));
        }

        private void btnStartRun_Click(object sender, EventArgs e)
        {
            if(presenter.plcRW == null)
            {
                return;
            }
            this.timerNodeStatus.Start();
            presenter.Start();
            label3.Text = "系统已经启动!";
        }

        private void btnPauseRun_Click(object sender, EventArgs e)
        {
            this.timerNodeStatus.Stop();
            presenter.Pause();
            label3.Text = "系统已经停止!";
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            this.richTextBoxLog.Text = "";
        }

        private void richTextBoxLog_TextChanged(object sender, EventArgs e)
        {
            this.richTextBoxLog.SelectionStart = this.richTextBoxLog.Text.Length; //Set the current caret position at the end
            this.richTextBoxLog.ScrollToCaret();
        }
        private void RefreshPLCComm()
        {
            if (this.dataGridViewDevDB1.InvokeRequired)
            {
                DlgtRefreshPLCComm dlgtRefresh = new DlgtRefreshPLCComm(RefreshPLCComm);
                this.Invoke(dlgtRefresh);
            }
            else
            {
               
                DataTable dt1 = null;
                DataTable dt2 = null;
                //DataTable dtTask = null;
                string taskDetail = "";
                presenter.GetRunningInfo(ref dt1, ref dt2, ref taskDetail);
               
                this.dataGridViewDevDB1.DataSource = dt1;
                for (int i = 0; i < this.dataGridViewDevDB1.Columns.Count; i++)
                {
                    this.dataGridViewDevDB1.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
                    this.dataGridViewDevDB1.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                }
                this.dataGridViewDevDB1.Columns[this.dataGridViewDevDB1.Columns.Count - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                this.dataGridViewDevDB2.DataSource = dt2;
                for (int i = 0; i < this.dataGridViewDevDB2.Columns.Count; i++)
                {
                    this.dataGridViewDevDB2.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
                    this.dataGridViewDevDB2.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                }
                this.dataGridViewDevDB2.Columns[this.dataGridViewDevDB2.Columns.Count - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                this.richTextBoxTaskInfo.Text = taskDetail;


            }

        }

        private void buttonRefreshDevStat_Click(object sender, EventArgs e)
        {
            RefreshPLCComm();
        }

        private void timerNodeStatus_Tick(object sender, EventArgs e)
        {
            RefreshPLCComm();
        }

        private void checkBoxAutorefresh_CheckedChanged(object sender, EventArgs e)
        {

        }
        private void buttonDB2SimSet_Click(object sender, EventArgs e)
        {
            try
            {
                int itemID = int.Parse(comboBoxDB2.Text);
                presenter.Stacker.SimSetDB2(itemID, int.Parse(this.textBoxDB2ItemVal.Text));
                RefreshPLCComm();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
           
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (DialogResult.OK != MessageBox.Show("确定要关闭系统吗?", "提示", MessageBoxButtons.OKCancel))
            {
                e.Cancel = true;
            }
           
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            presenter.Exit();
        }

        private void buttonMultiReadPlc_Click(object sender, EventArgs e)
        {
            string addrStart = this.textBoxPlcAddrStart.Text;
            int blockNum = int.Parse(this.textBoxPlcBlockNum.Text);
            short[] reVals = null;

            if (!presenter.plcRW.IsConnect)
            {
                string reStr = "";
                presenter.plcRW.ConnectPLC(ref reStr);
            }
            if (presenter.plcRW.ReadMultiDB(addrStart, blockNum, ref reVals))
            {
                string strVal = "";
                for (int i = 0; i < blockNum; i++)
                {
                    strVal += reVals[i].ToString() + ",";
                }
                this.richTextBoxMultiDBVal.Text = strVal;
            }
            else
            {
                Console.WriteLine("批量读取PLC数据失败");
            }
        }

        private void buttonMultiWritePlc_Click(object sender, EventArgs e)
        {
            string addrStart = this.textBoxPlcAddrStart.Text;
            int blockNum = int.Parse(this.textBoxPlcBlockNum.Text);
            string[] splitStr = new string[] { ",", ":", "-", ";" };
            string strVals = this.richTextBoxMultiDBVal.Text;
            string[] strArray = strVals.Split(splitStr, StringSplitOptions.RemoveEmptyEntries);
            if (strArray == null || strArray.Count() < 1)
            {
                MessageBox.Show("输入数据错误");
                return;
            }
            short[] vals = new short[strArray.Count()];
            for (int i = 0; i < vals.Count(); i++)
            {
                vals[i] = short.Parse(strArray[i]);
            }
            if (!presenter.plcRW.IsConnect)
            {
                string reStr = "";
                presenter.plcRW.ConnectPLC(ref reStr);
            }
            if (presenter.plcRW.WriteMultiDB(addrStart, blockNum, vals))
            {
                Console.WriteLine("批量写入成功");
            }
            else
            {
                Console.WriteLine("批量写入失败");
            }
        }

        private void buttonPLCDBReset_Click(object sender, EventArgs e)
        {

        }

        private void OnGenerateTask()
        {
            try
            {
                AsrsTaskModel task = new AsrsTaskModel();
                string reStr = "";
                task.TaskPhase = 0;
                task.TaskStatus = "待执行";
                EnumAsrsTaskType taskType = (EnumAsrsTaskType)Enum.Parse(typeof(EnumAsrsTaskType), this.comboBoxTasks.Text);
                task.TaskType = (int)taskType;
                if(taskType == EnumAsrsTaskType.产品入库)
                {
                    task.InputPort = int.Parse(this.textBoxPortID.Text);
                }
                else
                {
                    task.OutputPort = int.Parse(this.textBoxPortID.Text);
                }
                task.CellA = new CellCoordModel(int.Parse(textBoxRow.Text),int.Parse(textBoxCol.Text),int.Parse(textBoxLayer.Text));
               
                if (presenter.Stacker.FillTask(task, ref reStr))
                {
                    Console.WriteLine("分配{0}任务成功",taskType.ToString());
                    this.label11.Text = string.Format("当前任务:{0} ,站台号:{1},货位地址：{2}-{3}-{4}", taskType.ToString(), this.textBoxPortID.Text, task.CellA.Row, task.CellA.Col, task.CellA.Layer);
                }
                else
                {
                    Console.WriteLine("分配{0}任务失败,{1}",taskType.ToString(),reStr);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
           
        }
        private void button3_Click(object sender, EventArgs e)
        {
            OnGenerateTask();
        }
        private void OnDevReset()
        {
            if(presenter.Reset())
            {
                Console.WriteLine("设备复位成功");
            }
            else
            {
                Console.WriteLine("设备复位失败");
            }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            OnDevReset();
        }
       
    }
}
