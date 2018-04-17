using System;
namespace CtlDBAccess.Model
{
    /// <summary>
    /// SysCfg:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class SysCfgDBModel
    {
        public SysCfgDBModel()
        { }
        #region Model
        private string _syscfgname;
        private string _cfgfile;
        private DateTime _modifytime;
        private string _tag1;
        private string _tag2;
        /// <summary>
        /// 
        /// </summary>
        public string sysCfgName
        {
            set { _syscfgname = value; }
            get { return _syscfgname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cfgFile
        {
            set { _cfgfile = value; }
            get { return _cfgfile; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime modifyTime
        {
            set { _modifytime = value; }
            get { return _modifytime; }
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
        #endregion Model

    }
}

