using System;
namespace AsrsStorDBAcc.Model
{
    /// <summary>
    /// StockDetail:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class StockDetailModel
    {
        public StockDetailModel()
        { }
        #region Model
        private long _stockdetailid;
        private long _stocklistid;
        private string _meterialname;
        private string _meterialcode;
        private string _meterialpos;
        private string _reserve;
        /// <summary>
        /// 库存详细ID
        /// </summary>
        public long StockDetailID
        {
            set { _stockdetailid = value; }
            get { return _stockdetailid; }
        }
        /// <summary>
        /// 库存ID
        /// </summary>
        public long StockListID
        {
            set { _stocklistid = value; }
            get { return _stocklistid; }
        }
        /// <summary>
        /// 物料名称
        /// </summary>
        public string MeterialName
        {
            set { _meterialname = value; }
            get { return _meterialname; }
        }
        /// <summary>
        /// 物料条码
        /// </summary>
        public string MeterialCode
        {
            set { _meterialcode = value; }
            get { return _meterialcode; }
        }
        /// <summary>
        /// 物料在料框的位置
        /// </summary>
        public string MeterialPos
        {
            set { _meterialpos = value; }
            get { return _meterialpos; }
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

