using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LogInterface
{
    public enum EnumLoglevel
    {
        调试,
        提示,
        警告,
        错误
    }
    /// <summary>
    /// 日志模型
    /// </summary>
    public class LogModel
    {
        private string logSource;
        private string logContent;
        private DateTime logtime;
        private EnumLoglevel logLevel;
        public LogModel(string logSrc,string content,EnumLoglevel logLevel)
        {
            this.logSource = logSrc;
            this.logLevel = logLevel;
            this.logContent = content;
            this.logtime = DateTime.Now;
        }
        public string LogSource { get { return logSource; } set { logSource = value; } }
        public string LogContent { get { return logContent; } }
        public DateTime LogTime { get { return logtime; } }
        public EnumLoglevel LogLevel { get { return logLevel; } set { logLevel = value; } }

    }
}
