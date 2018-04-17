using System;
namespace DBAccess.Model
{
    /// <summary>
    /// Battery:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class BatteryModel
    {
        public BatteryModel()
        { }
        #region Model
        private string _batteryid;
        private string _batmoduleid;
        private string _batpackid;
        private DateTime _batmoduleasmtime;
        /// <summary>
        /// 
        /// </summary>
        public string batteryID
        {
            set { _batteryid = value; }
            get { return _batteryid; }
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
        public DateTime batModuleAsmTime
        {
            set { _batmoduleasmtime = value; }
            get { return _batmoduleasmtime; }
        }
        #endregion Model

    }
}


