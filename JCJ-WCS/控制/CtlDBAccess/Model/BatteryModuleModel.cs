using System;
namespace DBAccess.Model
{
    /// <summary>
    /// BatteryModule:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class BatteryModuleModel
    {
        public BatteryModuleModel()
        { }
        #region Model
        private string _batmoduleid;
        private string _batchname;
        private DateTime _asmtime;
        private string _curprocessstage;
        private string _batpackid;
        private string _topcapopworkerid;
        private string _downcapopworkerid;
        private string _palletid;
        private bool _palletbinded;
        private int? _topcapWelderID;
        private int? _bottomcapWelderID;
        private int? _checkresult;
        /// <summary>
        /// 模组条码
        /// </summary>
        public string batModuleID
        {
            set { _batmoduleid = value; }
            get { return _batmoduleid; }
        }
        /// <summary>
        /// 批次
        /// </summary>
        public string batchName
        {
            set { _batchname = value; }
            get { return _batchname; }
        }
        /// <summary>
        /// 组装时间
        /// </summary>
        public DateTime asmTime
        {
            set { _asmtime = value; }
            get { return _asmtime; }
        }
        /// <summary>
        /// 当前所在工艺
        /// </summary>
        public string curProcessStage
        {
            set { _curprocessstage = value; }
            get { return _curprocessstage; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string batPackID
        {
            set { _batpackid = value; }
            get { return _batpackid; }
        }
        /// <summary>
        /// 封上盖操作的员工编号
        /// </summary>
        public string topcapOPWorkerID
        {
            set { _topcapopworkerid = value; }
            get { return _topcapopworkerid; }
        }
        /// <summary>
        /// 封下盖操作的员工编号
        /// </summary>
        public string downcapOPWorkerID
        {
            set { _downcapopworkerid = value; }
            get { return _downcapopworkerid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string palletID
        {
            set { _palletid = value; }
            get { return _palletid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool palletBinded
        {
            set { _palletbinded = value; }
            get { return _palletbinded; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? topcapWelderID
        {
            set { _topcapWelderID = value; }
            get { return _topcapWelderID; }
        }
        public int? bottomcapWelderID
        {
            set { _bottomcapWelderID = value; }
            get { return _bottomcapWelderID; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? checkResult
        {
            set { _checkresult = value; }
            get { return _checkresult; }
        }
        #endregion Model

    }
}

