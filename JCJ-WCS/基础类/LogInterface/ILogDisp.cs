using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LogInterface
{
    /// <summary>
    /// 日志显示
    /// </summary>
    public interface ILogDisp
    {
       void DispLog(LogModel log);
    }
}
