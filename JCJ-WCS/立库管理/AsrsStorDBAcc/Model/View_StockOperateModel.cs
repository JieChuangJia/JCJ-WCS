using System;
namespace AsrsStorDBAcc.Model
{
    /// <summary>
    /// View_StockOperate:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class View_StockOperateModel
    {
        public View_StockOperateModel()
        { }
        #region Model
        private long _stockoperrecdid;
        private long _storehouseid;
        private string _goodssitepos;
        private string _operatetype;
        private string _operatedetail;
        private DateTime _operatetime;
        private string _storehousename;
        private string _storehousedesc;
        /// <summary>
        /// 
        /// </summary>
        public long StockOperRecdID
        {
            set { _stockoperrecdid = value; }
            get { return _stockoperrecdid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public long StoreHouseID
        {
            set { _storehouseid = value; }
            get { return _storehouseid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string GoodsSitePos
        {
            set { _goodssitepos = value; }
            get { return _goodssitepos; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string OPerateType
        {
            set { _operatetype = value; }
            get { return _operatetype; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string OperateDetail
        {
            set { _operatedetail = value; }
            get { return _operatedetail; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime OPerateTime
        {
            set { _operatetime = value; }
            get { return _operatetime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string StoreHouseName
        {
            set { _storehousename = value; }
            get { return _storehousename; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string StoreHouseDesc
        {
            set { _storehousedesc = value; }
            get { return _storehousedesc; }
        }
        #endregion Model

    }
}

