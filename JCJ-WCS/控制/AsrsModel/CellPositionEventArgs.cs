using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AsrsModel;

namespace AsrsModel
{
    public class CellPositionEventArgs:EventArgs
    {
        /// <summary>
        /// 库房名称
        /// </summary>
        public string HouseName { get; set; }
        /// <summary>
        /// 货位位置
        /// </summary>
        public CellCoordModel CellCoord { get; set; }
       
    }
    public class StockListProEventArgs:EventArgs
    {
        /// <summary>
        /// 库房名称
        /// </summary>
        public string HouseName { get; set; }
        /// <summary>
        /// 货位位置
        /// </summary>
        public CellCoordModel CellCoord { get; set; }
        /// <summary>
        /// 产品码
        /// </summary>
        public string ProductCode { get; set; }
    }
}
