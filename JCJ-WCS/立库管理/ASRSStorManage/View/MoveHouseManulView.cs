using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AsrsModel;

namespace ASRSStorManage.View
{
    public partial class MoveHouseManulView : Form
    {
        private Presenter.StoragePresenter presenter;
        /// <summary>
        /// 起点库房名称
        /// </summary>
        public string StartGsHouseName { get; set; }
        public string EndGsHouseName
        {
            get;
            set;

        }
     
        /// <summary>
        /// 终点位置
        /// </summary>
        private CellCoordModel startGsPos = new CellCoordModel(1,1,1);
        public CellCoordModel StartGsPos
        {
            get { return this.startGsPos; }
            set {
                this.startGsPos = value;
               this.tb_StartPos.Text =  StartGsHouseName + "," + startGsPos.Row+ "排" + startGsPos.Col + "列" + startGsPos.Layer + "层";
            }
        }
        private CellCoordModel endGsPos = new CellCoordModel(1, 1, 1);
        public CellCoordModel EndGsPos
        {
            get {
                return this.endGsPos;
            } 
            set 
            {
                this.endGsPos = value;
               this.tb_EndPos.Text = EndGsHouseName + "," + endGsPos.Row + "排" + endGsPos.Col + "列" + endGsPos.Layer + "层";
            }
        }
        public void ClearMoveParam()
        {
            this.tb_EndPos.Text = "";
            this.tb_StartPos.Text = "";
        }
        public MoveHouseManulView(Presenter.StoragePresenter pres)
        {
            InitializeComponent();
            this.presenter = pres;
        }
      

        private void bt_MoveHouse_Click(object sender, EventArgs e)
        {
            if(this.presenter == null)
            {
                return;
            }
            if(this.tb_StartPos.Text.Trim() == "")
            {
                MessageBox.Show("起始位置不能为空！", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (this.tb_EndPos.Text.Trim() == "")
            {
                MessageBox.Show("终止位置不能为空！", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (this.StartGsHouseName == this.EndGsHouseName && this.startGsPos.Row == this.endGsPos.Row
                && this.startGsPos.Col == this.endGsPos.Col && this.startGsPos.Layer == this.endGsPos.Layer)
            {
                MessageBox.Show("同一个位置不需要移库！", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            this.presenter.MoveGsManual(this.StartGsHouseName, this.startGsPos, this.EndGsHouseName, this.endGsPos);
        }

        private void bt_Cancel_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }
    }
}
