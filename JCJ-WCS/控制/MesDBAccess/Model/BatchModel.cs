using System;
namespace MesDBAccess.Model
{
    /// <summary>
    /// Batch:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class BatchModel
    {
        public BatchModel()
        { }
        #region Model
        private string _batchname;
        private DateTime _createtime;
        private string _remark;
        /// <summary>
        /// 
        /// </summary>
        public string batchName
        {
            set { _batchname = value; }
            get { return _batchname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime createTime
        {
            set { _createtime = value; }
            get { return _createtime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string remark
        {
            set { _remark = value; }
            get { return _remark; }
        }
        #endregion Model

    }
}

