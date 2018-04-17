using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using LogInterface;
using CtlDBAccess.BLL;
using CtlDBAccess.Model;
namespace LogManage
{
    public class LogPresenter:ILogRecorder
    {
        #region 私有
        private bool debugMode = false;
        private LogFilterModel logFilter = null;
        private ILogView view;
        private ILogDisp logDisp = null;
        private SysLogBll logBll = null;
        private int curlogPage = 1;//分页索引，从开始编号
        private int SumLogPage = 0;
        private int pageSize = 100;
        private string logQueryCondition = "";
        private DataTable curLogPageDT = null;
        
        #endregion
        #region 公有
        public bool DebugMode { get { return debugMode; } set { debugMode = value; } }
        public ILogDisp LogDisp
        {
            get { return logDisp; }
            set { logDisp = value; }
        }
        public LogFilterModel LogFilter
        {
            get { return logFilter; }
            set { logFilter = value; }
        }
        public int CurLogPage
        {
            get { return curlogPage; }
            set { 
                if(curlogPage != value)
                {
                    curlogPage = value;
                    if(curlogPage<1)
                    {
                        curlogPage = 1;
                    }
                    if(curlogPage>SumLogPage)
                    {
                        curlogPage = SumLogPage;
                    }
                    LoadLog();
                }
               
            }
        }
        public DataTable CurLogDT { get { return curLogPageDT; } }
        public LogPresenter(ILogView view)
        {
            logFilter = new LogFilterModel();
            logBll = new SysLogBll();
            this.view = view;
        }
        public delegate string DelegateQueryLog(string strWhere, int pageSize, int pageIndex, bool orderAsc);
        public void QueryLog(/*ref TimeSpan timeSpan*/)
        {
           
          
            SumLogPage = 0;
            StringBuilder strWhere = new StringBuilder();
            strWhere.AppendFormat("LogTime >= '{0}' and LogTime<= '{1}' ",
                logFilter.StartDate.ToString("yyyy-MM-dd HH:mm:ss"),
                logFilter.EndDate.ToString("yyyy-MM-dd HH:mm:ss"));
            if (logFilter.LogsrcStationName != "所有")
            {
                strWhere.AppendFormat("and LogSourceObject = '{0}'", logFilter.LogsrcStationName);
            }
            if (logFilter.LogLevel != "所有")
            {
                strWhere.AppendFormat("and LogLevel='{0}'", logFilter.LogLevel);
            }
            if (logFilter.LikeQueryEnable)
            {
                strWhere.AppendFormat("and LogContent like '%{0}%'", logFilter.LikeContent);
            }
            logQueryCondition = strWhere.ToString();
            int recordNum = logBll.GetRecordCount(strWhere.ToString());
            int pageNum = recordNum / pageSize;
            if (pageNum * pageSize < recordNum)
            {
                pageNum++;
            }
            this.SumLogPage = pageNum;
            this.CurLogPage = 1;
            view.RefreshLogsumInfo(pageNum, pageSize);
            LoadLog();
           
        }
        public DataTable SynQueryLog()
        {
            StringBuilder strWhere = new StringBuilder();
            strWhere.AppendFormat("LogTime between '{0}' and '{1}' ",
                logFilter.StartDate.ToString("yyyy-MM-dd HH:MM:00"),
                logFilter.EndDate.ToString("yyyy-MM-dd HH:MM:00"));
            if (logFilter.LogsrcStationName != "所有")
            {
                strWhere.AppendFormat("and LogSourceObject = '{0}'", logFilter.LogsrcStationName);
            }
            if (logFilter.LogLevel != "所有")
            {
                strWhere.AppendFormat("and LogLevel='{0}'", logFilter.LogLevel);
            }
            if (logFilter.LikeQueryEnable)
            {
                strWhere.AppendFormat("and LogContent like '%{0}%'", logFilter.LikeContent);
            }
            logQueryCondition = strWhere.ToString();
            DataSet ds = logBll.GetList(logQueryCondition);
            if(ds != null && ds.Tables.Count>0)
            {
                return ds.Tables[0];
            }
            else
            {
                return null;
            }
        }
        public void FirstPage()
        {
            CurLogPage = 1;
        }
        public void LastPage()
        {
            CurLogPage = SumLogPage;
        }
        public void PrePage()
        {
            CurLogPage--;
        }
        public void NextPage()
        {
            CurLogPage++;
        }
        
        #endregion
        #region 接口实现
        public void AddLog(LogModel log)
        {
            //throw new NotImplementedException();
            //存储
            SysLog dbLogModel = new SysLog();
            dbLogModel.LogContent = log.LogContent;
            dbLogModel.LogSourceObject = log.LogSource;
            dbLogModel.LogTime = log.LogTime;
            dbLogModel.LogLevel = log.LogLevel.ToString();
            //dbLogModel.LogSourceModule = log.
            logBll.Add(dbLogModel);
            //调显示接口
            if(logDisp != null)
            {
                logDisp.DispLog(log);
            }
            
        }
        public  void AddDebugLog(string logSrc,string logStr)
        {
           // if()
            LogModel log = new LogModel(logSrc, logStr, EnumLoglevel.调试);
            AddLog(log);
        }
        #endregion
        #region 私有
        //private string AnsyQueryLog()
        //{
           
        //    return LoadLogPage(strWhere.ToString(), pageSize, curlogPage, false);
          
        //}
        private void LoadLog()
        {
            DelegateQueryLog del = new DelegateQueryLog(AnsyLoadLogPage);
            IAsyncResult ar = del.BeginInvoke(logQueryCondition, this.pageSize, this.curlogPage, false, new AsyncCallback(CallbackQuerylogOK), del);
        }
        private void CallbackQuerylogOK(IAsyncResult ar)
        {
            DelegateQueryLog del = (DelegateQueryLog)ar.AsyncState;
            string re = del.EndInvoke(ar);
           // AddDebugLog("日志模块", re);
            view.RefreshLogQueryStat(re);
            //view.RefreshLogDisp(dt, "0");
        }
        private string AnsyLoadLogPage(string strWhere,int pageSize,int pageIndex,bool orderAsc)
        {
            view.RefreshLogQueryStat("正在查询中...");
            DateTime dt1 = System.DateTime.Now;
            DataSet ds = logBll.GetModelsByPage(pageSize, curlogPage, strWhere, false);//logBll.GetList(strWhere.ToString());
            DateTime dt2 = System.DateTime.Now;
            TimeSpan timeSpan = dt2 - dt1;
            string strTimespan = string.Format("查询完成，用时：{0}:{1}:{2}.{3}", timeSpan.Hours, timeSpan.Minutes, timeSpan.Seconds, timeSpan.Milliseconds);
            view.RefreshLogDisp(ds.Tables[0], strTimespan,curlogPage);
            this.curLogPageDT = ds.Tables[0];
            return strTimespan;
        }
        #endregion

    }
}
