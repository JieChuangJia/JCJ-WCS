using System;
namespace AsrsStorDBAcc.Model
{
    /// <summary>
    /// StoreHouseArea:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class StoreHouseAreaModel
    {
        public StoreHouseAreaModel()
        { }
        #region Model
        private long _storehouseareaid;
        private long _storehouseid;
        private string _storehouseareaname;
        private string _reserve;
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
        public long StoreHouseID
        {
            set { _storehouseid = value; }
            get { return _storehouseid; }
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
        public string Reserve
        {
            set { _reserve = value; }
            get { return _reserve; }
        }
        #endregion Model

    }
}

