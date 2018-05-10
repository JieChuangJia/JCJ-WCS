using System;
namespace AsrsStorDBAcc.Model
{
    /// <summary>
    /// GSOperRecord:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class StockOperRecdModel
    {
        public StockOperRecdModel()
        { }
        #region Model
        private long _stockoperrecdid;
        private long _storehouseid;
        private string _goodssitepos;
        private string _operatetype;
        private string _operatedetail;
        private DateTime _operatetime;
        private string _reserve;
        /// <summary>
        /// 库存操作记录ID
        /// </summary>
        public long StockOperRecdID
        {
            set { _stockoperrecdid = value; }
            get { return _stockoperrecdid; }
        }
        /// <summary>
        /// 库房ID
        /// </summary>
        public long StoreHouseID
        {
            set { _storehouseid = value; }
            get { return _storehouseid; }
        }
        /// <summary>
        /// 货位位置排、列、层（12-2-2）
        /// </summary>
        public string GoodsSitePos
        {
            set { _goodssitepos = value; }
            get { return _goodssitepos; }
        }
        /// <summary>
        /// 操作类型（申请入库，实际入库，申请出库，实际出库，人工出库等等）
        /// </summary>
        public string OPerateType
        {
            set { _operatetype = value; }
            get { return _operatetype; }
        }
        /// <summary>
        /// 操作详细
        /// </summary>
        public string OperateDetail
        {
            set { _operatedetail = value; }
            get { return _operatedetail; }
        }
        /// <summary>
        /// 操作时间
        /// </summary>
        public DateTime OPerateTime
        {
            set { _operatetime = value; }
            get { return _operatetime; }
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

