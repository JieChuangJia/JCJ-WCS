using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace CtlDBAccess.Model
{
    /// <summary>
    /// SysLog:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class SysLog
    {
        public SysLog()
        { }
        #region Model
        private long _logid;
        private string _logcontent;
        private DateTime _logtime;
        private string _loglevel;
        private string _logsourceobject;
        private string _logsourcemodule;
        /// <summary>
        /// 
        /// </summary>
        public long LogID
        {
            set { _logid = value; }
            get { return _logid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string LogContent
        {
            set { _logcontent = value; }
            get { return _logcontent; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime LogTime
        {
            set { _logtime = value; }
            get { return _logtime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string LogLevel
        {
            set { _loglevel = value; }
            get { return _loglevel; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string LogSourceObject
        {
            set { _logsourceobject = value; }
            get { return _logsourceobject; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string LogSourceModule
        {
            set { _logsourcemodule = value; }
            get { return _logsourcemodule; }
        }
        #endregion Model

    }
}


