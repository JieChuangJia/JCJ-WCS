using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
namespace LogManage
{
    public interface ILogView
    {
        /// <summary>
        /// 刷新日志汇总信息
        /// </summary>
        /// <param name="baseInfo"></param>
        void RefreshLogsumInfo(int sumPages,int pageSize);

        /// <summary>
        /// 刷新日志显示
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="timeSpan"></param>
        void RefreshLogDisp(DataTable dt,string timeSpan,int curPage);

        /// <summary>
        /// 刷新日志查询状态
        /// </summary>
        /// <param name="stat"></param>
        void RefreshLogQueryStat(string stat);
    }
}
