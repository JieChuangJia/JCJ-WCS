using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AsrsUtil
{
    /// <summary>
    /// 货位坐标描述
    /// </summary>
    
    public class CellCoordModel
    {
        private int row = 0; //排
        private int col = 0; //列
        private int layer = 0;//层

        public int Row { get { return row; } set { this.row = value; } }

        public int Col { get { return col; } set { this.col = value; } }

        public int Layer { get { return layer; } set { this.layer = value; } }
        public CellCoordModel(int row, int col, int layer)
        {
            this.row = row;
            this.col = col;
            this.layer = layer;
        }
    }

    public class AsrsTaskModel
    {

        public string Taskid { get; set; }
        public int TaskType { get; set; }
        public int targetPortID { get; set; }
        public int InputPort { get; set; }
        public int OutputPort { get; set; }
        public CellCoordModel CellA { get; set; }
        public CellCoordModel CellB{ get; set; }
        public string TaskStatus
        {
            get;
            set;
        }
        /// <summary>
        /// 任务阶段
        /// </summary>
        public int TaskPhase
        {
            get;  set;
        }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }
       
        /// <summary>
        /// 完成时间
        /// </summary>
        public DateTime? FinishTime{get;set;}
       
    }
}
