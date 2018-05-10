using System;
namespace AsrsStorDBAcc.Model
{
    /// <summary>
    /// StockList:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class StockListModel
    {
        public StockListModel()
        { }
        #region Model
        private long _stocklistid;
        private long _stockid;
        private DateTime _inhousetime;
        private string _meterialboxcode;
        private string _meterialbatch;
        private string _meterialstatus;
        private string _reserve;
        /// <summary>
        /// 库存列表ID
        /// </summary>
        public long StockListID
        {
            set { _stocklistid = value; }
            get { return _stocklistid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public long StockID
        {
            set { _stockid = value; }
            get { return _stockid; }
        }
        /// <summary>
        /// 实际入库时间
        /// </summary>
        public DateTime InHouseTime
        {
            set { _inhousetime = value; }
            get { return _inhousetime; }
        }
        /// <summary>
        /// 料框条码
        /// </summary>
        public string MeterialboxCode
        {
            set { _meterialboxcode = value; }
            get { return _meterialboxcode; }
        }
        /// <summary>
        /// 产品批次
        /// </summary>
        public string MeterialBatch
        {
            set { _meterialbatch = value; }
            get { return _meterialbatch; }
        }
        /// <summary>
        /// 产品状态
        /// </summary>
        public string MeterialStatus
        {
            set { _meterialstatus = value; }
            get { return _meterialstatus; }
        }
        /// <summary>
        /// 备用
        /// </summary>
        public string Reserve
        {
            set { _reserve = value; }
            get { return _reserve; }
        }
        #endregion Model

    }
}

