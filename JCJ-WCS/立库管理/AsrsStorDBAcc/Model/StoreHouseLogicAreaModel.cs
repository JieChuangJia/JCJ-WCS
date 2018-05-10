using System;
namespace AsrsStorDBAcc.Model
{
    /// <summary>
    /// StoreHouseLogicArea:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class StoreHouseLogicAreaModel
    {
        public StoreHouseLogicAreaModel()
        { }
        #region Model
        private long _storehouselogicareaid;
        private string _storehouseareaname;
        private string _storehouseareadesc;
        private string _reserve;
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
        public string StoreHouseAreaName
        {
            set { _storehouseareaname = value; }
            get { return _storehouseareaname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string StoreHouseAreaDesc
        {
            set { _storehouseareadesc = value; }
            get { return _storehouseareadesc; }
        }
        /// <summary>
        /// 描述
        /// </summary>
        public string Reserve
        {
            set { _reserve = value; }
            get { return _reserve; }
        }
        #endregion Model

    }
}

