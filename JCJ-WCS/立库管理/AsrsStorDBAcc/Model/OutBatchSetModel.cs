using System;
namespace AsrsStorDBAcc.Model
{
    /// <summary>
    /// OutBatchSet:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class OutBatchSetModel
    {
        public OutBatchSetModel()
        { }
        #region Model
        private long _outbatchsetid;
        private long _storehouseid;
        private long _storehouselogicareaid;
        private string _batch;
        private string _resever1;
        private string _resever2;
        private string _resever3;
        private string _resever4;
        private string _resever5;
        private string _resever6;
        private string _resever7;
        private string _resever8;
        /// <summary>
        /// 出库批次设置
        /// </summary>
        public long OutBatchSetID
        {
            set { _outbatchsetid = value; }
            get { return _outbatchsetid; }
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
        /// 库区ID
        /// </summary>
        public long StoreHouseLogicAreaID
        {
            set { _storehouselogicareaid = value; }
            get { return _storehouselogicareaid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Batch
        {
            set { _batch = value; }
            get { return _batch; }
        }
        /// <summary>
        /// 备用1
        /// </summary>
        public string Resever1
        {
            set { _resever1 = value; }
            get { return _resever1; }
        }
        /// <summary>
        /// 备用2
        /// </summary>
        public string Resever2
        {
            set { _resever2 = value; }
            get { return _resever2; }
        }
        /// <summary>
        /// 备用3
        /// </summary>
        public string Resever3
        {
            set { _resever3 = value; }
            get { return _resever3; }
        }
        /// <summary>
        /// 备用4
        /// </summary>
        public string Resever4
        {
            set { _resever4 = value; }
            get { return _resever4; }
        }
        /// <summary>
        /// 备用5
        /// </summary>
        public string Resever5
        {
            set { _resever5 = value; }
            get { return _resever5; }
        }
        /// <summary>
        /// 备用6
        /// </summary>
        public string Resever6
        {
            set { _resever6 = value; }
            get { return _resever6; }
        }
        /// <summary>
        /// 备用7
        /// </summary>
        public string Resever7
        {
            set { _resever7 = value; }
            get { return _resever7; }
        }
        /// <summary>
        /// 备用8
        /// </summary>
        public string Resever8
        {
            set { _resever8 = value; }
            get { return _resever8; }
        }
        #endregion Model

    }
}

