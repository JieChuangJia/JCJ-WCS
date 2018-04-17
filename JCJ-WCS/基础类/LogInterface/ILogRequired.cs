using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LogInterface
{
    /// <summary>
    /// 强制实现日志需求的接口
    /// </summary>
    public interface ILogRequired
    {
        //protected ILogRecorder logRecorder = null;
        //public ILogRecorder LogRecorder { get { return logRecorder; } set { logRecorder = value; } }
        ILogRecorder LogRecorder { get; set; }
    }
}
