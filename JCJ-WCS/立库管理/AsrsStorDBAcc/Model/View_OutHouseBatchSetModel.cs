using System;
namespace AsrsStorDBAcc.Model
{
    /// <summary>
    /// View_OutHouseBatchSet:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class View_OutHouseBatchSetModel
    {
        public View_OutHouseBatchSetModel()
        { }
        #region Model
        private string _storehousename;
        private string _storehousedesc;
        private long _storehouseid;
        private long _storehouselogicareaid;
        private string _storehouseareaname;
        private string _storehouseareadesc;
        private string _batch;
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
        public long StoreHouseID
        {
            set { _storehouseid = value; }
            get { return _storehouseid; }
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
        /// 
        /// </summary>
        public string Batch
        {
            set { _batch = value; }
            get { return _batch; }
        }
        #endregion Model

    }
}

