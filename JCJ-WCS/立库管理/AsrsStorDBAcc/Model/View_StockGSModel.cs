using System;
namespace AsrsStorDBAcc.Model
{
    /// <summary>
    /// View_StockGS:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class View_StockGSModel
    {
        public View_StockGSModel()
        { }
        #region Model
        private long _goodssiteid;
        private long _storehouseid;
        private string _goodssitename;
        private int _goodssitecolumn;
        private int _goodssitelayer;
        private int _goodssiterow;
        private string _goodssitetaskstatus;
        private bool _gsenabled;
        private string _goodssitetype;
        private string _goodssitepos;
        private string _goodssitestatus;
        private string _goodssiteoperate;
        private string _storehousename;
        private string _storehousedesc;
        private long _stockid;
        private string _trayid;
        private bool _isfull;
        private string _storehouseareaname;
        private long _storehouselogicareaid;
        private string _storehouseareadesc;
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
        public long StoreHouseID
        {
            set { _storehouseid = value; }
            get { return _storehouseid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string GoodsSiteName
        {
            set { _goodssitename = value; }
            get { return _goodssitename; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int GoodsSiteColumn
        {
            set { _goodssitecolumn = value; }
            get { return _goodssitecolumn; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int GoodsSiteLayer
        {
            set { _goodssitelayer = value; }
            get { return _goodssitelayer; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int GoodsSiteRow
        {
            set { _goodssiterow = value; }
            get { return _goodssiterow; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string GoodsSiteTaskStatus
        {
            set { _goodssitetaskstatus = value; }
            get { return _goodssitetaskstatus; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool GsEnabled
        {
            set { _gsenabled = value; }
            get { return _gsenabled; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string GoodsSiteType
        {
            set { _goodssitetype = value; }
            get { return _goodssitetype; }
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
        public string GoodsSiteStatus
        {
            set { _goodssitestatus = value; }
            get { return _goodssitestatus; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string GoodsSiteOperate
        {
            set { _goodssiteoperate = value; }
            get { return _goodssiteoperate; }
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
        /// <summary>
        /// 
        /// </summary>
        public long StockID
        {
            set { _stockid = value; }
            get { return _stockid; }
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
        /// 
        /// </summary>
        public string StoreHouseAreaName
        {
            set { _storehouseareaname = value; }
            get { return _storehouseareaname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public long StoreHouseLogicAreaID
        {
            set { _storehouselogicareaid = value; }
            get { return _storehouselogicareaid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string StoreHouseAreaDesc
        {
            set { _storehouseareadesc = value; }
            get { return _storehouseareadesc; }
        }
        #endregion Model

    }
}

