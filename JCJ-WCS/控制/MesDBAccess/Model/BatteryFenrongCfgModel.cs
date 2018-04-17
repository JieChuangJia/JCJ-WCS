using System;
namespace MesDBAccess.Model
{
    /// <summary>
    /// BatteryFenrongCfgModel:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class BatteryFenrongCfgModel
    {
        public BatteryFenrongCfgModel()
        { }
        #region Model
        private string _fenrongcfgid;
        private string _batterycatacode;
        private string _fenrongzone;
        private string _mark;
        private string _tag1;
        private string _tag2;
        private string _tag3;
        private string _tag4;
        private string _tag5;
        /// <summary>
        /// 
        /// </summary>
        public string fenrongCfgID
        {
            set { _fenrongcfgid = value; }
            get { return _fenrongcfgid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string batteryCataCode
        {
            set { _batterycatacode = value; }
            get { return _batterycatacode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string fenrongZone
        {
            set { _fenrongzone = value; }
            get { return _fenrongzone; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string mark
        {
            set { _mark = value; }
            get { return _mark; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string tag1
        {
            set { _tag1 = value; }
            get { return _tag1; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string tag2
        {
            set { _tag2 = value; }
            get { return _tag2; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string tag3
        {
            set { _tag3 = value; }
            get { return _tag3; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string tag4
        {
            set { _tag4 = value; }
            get { return _tag4; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string tag5
        {
            set { _tag5 = value; }
            get { return _tag5; }
        }
        #endregion Model

    }
}

