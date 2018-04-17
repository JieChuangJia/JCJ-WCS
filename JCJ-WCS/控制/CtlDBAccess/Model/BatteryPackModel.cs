using System;
namespace DBAccess.Model
{
    /// <summary>
    /// BatteryPackModel:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class BatteryPackModel
    {
        public BatteryPackModel()
        { }
        #region Model
        private string _batpackid;
        private DateTime _packasmtime;
        private string _opworkerid;
        /// <summary>
        /// 
        /// </summary>
        public string batPackID
        {
            set { _batpackid = value; }
            get { return _batpackid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime packAsmTime
        {
            set { _packasmtime = value; }
            get { return _packasmtime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string opWorkerID
        {
            set { _opworkerid = value; }
            get { return _opworkerid; }
        }
        #endregion Model

    }
}

