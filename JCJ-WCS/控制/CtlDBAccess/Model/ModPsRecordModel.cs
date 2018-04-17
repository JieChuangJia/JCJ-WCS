using System;
namespace DBAccess.Model
{
    /// <summary>
    /// ModPsRecordModel:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class ModPsRecordModel
    {
        public ModPsRecordModel()
        { }
        #region Model
        private string _recordid;
        private string _batmoduleid;
        private string _processrecord;
        private DateTime _recordtime;
        /// <summary>
        /// 
        /// </summary>
        public string RecordID
        {
            set { _recordid = value; }
            get { return _recordid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string batModuleID
        {
            set { _batmoduleid = value; }
            get { return _batmoduleid; }
        }
        /// <summary>
        /// 工艺 过程描述
        /// </summary>
        public string processRecord
        {
            set { _processrecord = value; }
            get { return _processrecord; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime recordTime
        {
            set { _recordtime = value; }
            get { return _recordtime; }
        }
        #endregion Model

    }
}

