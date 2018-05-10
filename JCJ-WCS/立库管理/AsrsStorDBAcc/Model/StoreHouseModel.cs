using System;
namespace AsrsStorDBAcc.Model
{
    /// <summary>
    /// StoreHouse:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class StoreHouseModel
    {
        public StoreHouseModel()
        { }
        #region Model
        private long _storehouseid;
        private string _storehousename;
        private string _storehousedesc;
        private string _reserve;
        /// <summary>
        /// 库房ID
        /// </summary>
        public long StoreHouseID
        {
            set { _storehouseid = value; }
            get { return _storehouseid; }
        }
        /// <summary>
        /// 库房名称
        /// </summary>
        public string StoreHouseName
        {
            set { _storehousename = value; }
            get { return _storehousename; }
        }
        /// <summary>
        /// 库房描述
        /// </summary>
        public string StoreHouseDesc
        {
            set { _storehousedesc = value; }
            get { return _storehousedesc; }
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

