using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LogInterface
{
    /// <summary>
    /// 写日志接口
    /// </summary>
    public interface ILogRecorder
    {
        void AddLog(LogModel log);
       
        void AddDebugLog(string logSrc,string logStr); //增加调试日志
    }
}
