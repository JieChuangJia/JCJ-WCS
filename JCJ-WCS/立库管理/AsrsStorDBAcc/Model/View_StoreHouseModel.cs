using System;
namespace AsrsStorDBAcc.Model
{
    /// <summary>
    /// View_StoreHouse:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class View_StoreHouseModel
    {
        public View_StoreHouseModel()
        { }
        #region Model
        private long _storehouseid;
        private string _storehousename;
        private string _storehousedesc;
        private long _storehouseareaid;
        private string _storehouseareaname;
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
        public long StoreHouseAreaID
        {
            set { _storehouseareaid = value; }
            get { return _storehouseareaid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string StoreHouseAreaName
        {
            set { _storehouseareaname = value; }
            get { return _storehouseareaname; }
        }
        #endregion Model

    }
}

