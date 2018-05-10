using System;
namespace AsrsStorDBAcc.Model
{
    /// <summary>
    /// Stock:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class StockModel
    {
        public StockModel()
        { }
        #region Model
        private long _stockid;
        private long _goodssiteid;
        private string _trayid;
        private bool _isfull;
        private string _reserve;
        /// <summary>
        /// 库存ID，一个托盘只能放一个货位
        /// </summary>
        public long StockID
        {
            set { _stockid = value; }
            get { return _stockid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public long GoodsSiteID
        {
            set { _goodssiteid = value; }
            get { return _goodssiteid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string TrayID
        {
            set { _trayid = value; }
            get { return _trayid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool IsFull
        {
            set { _isfull = value; }
            get { return _isfull; }
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

