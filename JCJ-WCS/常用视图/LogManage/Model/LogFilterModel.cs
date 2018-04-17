using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LogInterface;
namespace LogManage
{
    /// <summary>
    /// 日志查询，过滤参数封装
    /// </summary>
    public class LogFilterModel
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string LogsrcStationName { get; set; }
        public string LogLevel { get; set; }
        public string LikeContent { get; set; }
        public bool LikeQueryEnable { get; set; }
        public LogFilterModel()
        {
            StartDate = System.DateTime.Now - (new TimeSpan(30, 0, 0, 0));
            EndDate = System.DateTime.Now+new TimeSpan(1,0,0,0);
            LogLevel = "所有";
            LogsrcStationName = "所有";
            LikeContent = "";
            LikeQueryEnable = false;
        }
    }
}
