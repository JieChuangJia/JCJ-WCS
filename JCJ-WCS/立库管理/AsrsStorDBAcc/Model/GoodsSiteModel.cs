using System;
namespace AsrsStorDBAcc.Model
{
    /// <summary>
    /// 货位信息表
    /// </summary>
    [Serializable]
    public partial class GoodsSiteModel
    {
        public GoodsSiteModel()
        { }
        #region Model
        private long _goodssiteid;
        private long _storehouseid;
        private long? _storehouselogicareaid;
        private string _goodssitename;
        private int _goodssitelayer;
        private int _goodssitecolumn;
        private int _goodssiterow;
        private string _goodssitetaskstatus;
        private bool _gsenabled;
        private string _goodssitetype;
        private string _goodssitepos;
        private string _goodssitestatus;
        private string _goodssiteoperate;
        private string _reserve;
        /// <summary>
        /// 货位ID
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
        /// 逻辑库区ID可以为空
        /// </summary>
        public long? StoreHouseLogicAreaID
        {
            set { _storehouselogicareaid = value; }
            get { return _storehouselogicareaid; }
        }
        /// <summary>
        /// 货位名称
        /// </summary>
        public string GoodsSiteName
        {
            set { _goodssitename = value; }
            get { return _goodssitename; }
        }
        /// <summary>
        /// 货位层
        /// </summary>
        public int GoodsSiteLayer
        {
            set { _goodssitelayer = value; }
            get { return _goodssitelayer; }
        }
        /// <summary>
        /// 货位列
        /// </summary>
        public int GoodsSiteColumn
        {
            set { _goodssitecolumn = value; }
            get { return _goodssitecolumn; }
        }
        /// <summary>
        /// 货位排
        /// </summary>
        public int GoodsSiteRow
        {
            set { _goodssiterow = value; }
            get { return _goodssiterow; }
        }
        /// <summary>
        /// 货位任务类型
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
        /// 货位类型
        /// </summary>
        public string GoodsSiteType
        {
            set { _goodssitetype = value; }
            get { return _goodssitetype; }
        }
        /// <summary>
        /// 设备ID
        /// </summary>
        public string GoodsSitePos
        {
            set { _goodssitepos = value; }
            get { return _goodssitepos; }
        }
        /// <summary>
        /// 货位存储状态：有货、空货位、空料框
        /// </summary>
        public string GoodsSiteStatus
        {
            set { _goodssitestatus = value; }
            get { return _goodssitestatus; }
        }
        /// <summary>
        /// 库存操作
        /// </summary>
        public string GoodsSiteOperate
        {
            set { _goodssiteoperate = value; }
            get { return _goodssiteoperate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Reserve
        {
            set { _reserve = value; }
            get { return _reserve; }
        }
        #endregion Model

    }
}

