using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using CtlDBAccess.DBUtility;//Please add references
using CtlDBAccess.Model;
namespace CtlDBAccess.BLL
{/// <summary>
    /// 控制任务表
    /// </summary>
    public partial class ControlTaskBll
    {
        private readonly CtlDBAccess.Dal.ControlTaskDal dal = new CtlDBAccess.Dal.ControlTaskDal();
        public ControlTaskBll()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string TaskID)
        {
            return dal.Exists(TaskID);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(CtlDBAccess.Model.ControlTaskModel model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(CtlDBAccess.Model.ControlTaskModel model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(string TaskID)
        {

            return dal.Delete(TaskID);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string TaskIDlist)
        {
            return dal.DeleteList(TaskIDlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public CtlDBAccess.Model.ControlTaskModel GetModel(string TaskID)
        {

            return dal.GetModel(TaskID);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            return dal.GetList(Top, strWhere, filedOrder);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<CtlDBAccess.Model.ControlTaskModel> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<CtlDBAccess.Model.ControlTaskModel> DataTableToList(DataTable dt)
        {
            List<CtlDBAccess.Model.ControlTaskModel> modelList = new List<CtlDBAccess.Model.ControlTaskModel>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                CtlDBAccess.Model.ControlTaskModel model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = dal.DataRowToModel(dt.Rows[n]);
                    if (model != null)
                    {
                        modelList.Add(model);
                    }
                }
            }
            return modelList;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetAllList()
        {
            return GetList("");
        }

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            return dal.GetRecordCount(strWhere);
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            return dal.GetListByPage(strWhere, orderby, startIndex, endIndex);
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        //public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        //{
        //return dal.GetList(PageSize,PageIndex,strWhere);
        //}

        #endregion  BasicMethod
        #region  ExtensionMethod
        /// <summary>
        /// 得到待执行的任务,按时间排序，得到最前的
        /// </summary>
        /// <param name="taskType">业务流程类型</param>
        /// <returns></returns>
        public List<ControlTaskModel> GetTaskToRunList(int taskType,string taskStatus,string devID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("TaskType={0} and TaskStatus='{1}' and DeviceID='{2}' ", taskType, taskStatus,devID);
            strSql.Append("order by CreateTime asc");
           
            //DataSet ds = dal.GetList(strSql.ToString());
            //if(ds == null || ds.Tables== null || ds.Tables.Count<1 )
            //{
            //    return null;
            //}
            //if(ds.Tables[0].Rows.Count<1)
            //{
            //    return null;
            //}
            //return dal.DataRowToModel(ds.Tables[0].Rows[0]);
            return GetModelList(strSql.ToString());
        }
        public List<ControlTaskModel> GetTaskToRunList(int taskType, string taskStatus, string devID,bool priOrder=false)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("TaskType={0} and TaskStatus='{1}' and DeviceID='{2}' ", taskType, taskStatus, devID);
            if(priOrder)
            {
                strSql.AppendFormat(" order by cast(tag4 as INTEGER) desc,CreateTime asc");
            }
            else
            {
                strSql.AppendFormat(" order by CreateTime asc");
            }
            //DataSet ds = dal.GetList(strSql.ToString());
            //if(ds == null || ds.Tables== null || ds.Tables.Count<1 )
            //{
            //    return null;
            //}
            //if(ds.Tables[0].Rows.Count<1)
            //{
            //    return null;
            //}
            //return dal.DataRowToModel(ds.Tables[0].Rows[0]);
            return GetModelList(strSql.ToString());
        }
        public List<ControlTaskModel> GetEmerTaskToRunList(string taskStatus, string devID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("TaskStatus='{0}' and DeviceID='{1}' and tag5='1'", taskStatus, devID);
            strSql.Append("order by CreateTime asc");
            return GetModelList(strSql.ToString());
        }
        public ControlTaskModel GetFirstRequiredTask(string strWhere)
        {
        //    string strWhere = "TaskStatus='执行中' or TaskStatus='超时'";
            DataSet ds = dal.GetList(strWhere);
            if (ds == null || ds.Tables == null || ds.Tables.Count < 1)
            {
                return null;
            }
            if (ds.Tables[0].Rows.Count < 1)
            {
                return null;
            }
            return dal.DataRowToModel(ds.Tables[0].Rows[0]);
        }
        public void ClearHistorydata(string[] taskStats)
        {
//if (dal.GetRecordCount("") > 10000)
            //{
            foreach(string taskStat in taskStats)
            {
                  System.TimeSpan ts = new TimeSpan(30, 0, 0, 0); 
                System.DateTime delDate = System.DateTime.Now - ts;
                string strWhere = string.Format("delete from  ControlTask where CreateTime<'{0}' and TaskStatus='{1}'", delDate.ToString("yyyy-MM-dd"), taskStat);

                DbHelperSQL.ExecuteSql(strWhere);
            }
              
           // }
        }
        public UInt16 GetUnusedControlID()
        {
            long maxID = dal.GetMaxControlID();
            UInt16 nextID = 0;
            if(maxID>10000)
            {
                ClearHistorydata(new string[] { "已完成", "任务撤销" });
            }
            maxID = dal.GetMaxControlID();
            if(maxID>20000) //大于20000
            {
                for (UInt16 i = 1000; i < 20000; i++)
                {
                    UInt16 controlID = i;
                    DataSet ds = GetList(string.Format("ControlID = '{0}' and (TaskStatus='执行中' or TaskStatus='待执行')", controlID));
                    if (ds.Tables[0].Rows.Count == 0)
                    {
                        nextID = controlID;
                        break;
                    }
                }
               
            }
            else
            {
                nextID = (UInt16)(maxID + 1);
               
            }
            return nextID;
           
        }
        #endregion  ExtensionMethod
    }
}
