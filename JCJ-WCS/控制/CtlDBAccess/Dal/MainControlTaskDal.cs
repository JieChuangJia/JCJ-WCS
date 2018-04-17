using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using CtlDBAccess.DBUtility;//Please add references
namespace CtlDBAccess.DAL
{
    /// <summary>
    /// 数据访问类:MainControlTaskDal
    /// </summary>
    public partial class MainControlTaskDal
    {
        public MainControlTaskDal()
        { }
        #region  Method

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string MainTaskID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from MainControlTask");
            strSql.Append(" where MainTaskID='" + MainTaskID + "' ");
            return DbHelperSQL.Exists(strSql.ToString());
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(CtlDBAccess.Model.MainControlTaskModel model)
        {
            StringBuilder strSql = new StringBuilder();
            StringBuilder strSql1 = new StringBuilder();
            StringBuilder strSql2 = new StringBuilder();
            if (model.MainTaskID != null)
            {
                strSql1.Append("MainTaskID,");
                strSql2.Append("'" + model.MainTaskID + "',");
            }
            if (model.WMSTaskID != null)
            {
                strSql1.Append("WMSTaskID,");
                strSql2.Append("'" + model.WMSTaskID + "',");
            }
            if (model.FlowPathKey != null)
            {
                strSql1.Append("FlowPathKey,");
                strSql2.Append("'" + model.FlowPathKey + "',");
            }
            if (model.PalletCode != null)
            {
                strSql1.Append("PalletCode,");
                strSql2.Append("'" + model.PalletCode + "',");
            }
            if (model.TaskStatus != null)
            {
                strSql1.Append("TaskStatus,");
                strSql2.Append("'" + model.TaskStatus + "',");
            }
            if (model.TaskType != null)
            {
                strSql1.Append("TaskType,");
                strSql2.Append("'" + model.TaskType + "',");
            }
            if (model.StDevice != null)
            {
                strSql1.Append("StDevice,");
                strSql2.Append("'" + model.StDevice + "',");
            }
            if (model.StDeviceCata != null)
            {
                strSql1.Append("StDeviceCata,");
                strSql2.Append("'" + model.StDeviceCata + "',");
            }
            if (model.StDeviceParam != null)
            {
                strSql1.Append("StDeviceParam,");
                strSql2.Append("'" + model.StDeviceParam + "',");
            }
            if (model.EndDevice != null)
            {
                strSql1.Append("EndDevice,");
                strSql2.Append("'" + model.EndDevice + "',");
            }
            if (model.EndDeviceCata != null)
            {
                strSql1.Append("EndDeviceCata,");
                strSql2.Append("'" + model.EndDeviceCata + "',");
            }
            if (model.EndDeviceParam != null)
            {
                strSql1.Append("EndDeviceParam,");
                strSql2.Append("'" + model.EndDeviceParam + "',");
            }
            if (model.CreateTime != null)
            {
                strSql1.Append("CreateTime,");
                strSql2.Append("'" + model.CreateTime + "',");
            }
            if (model.FinishTime != null)
            {
                strSql1.Append("FinishTime,");
                strSql2.Append("'" + model.FinishTime + "',");
            }
            if (model.CreateMode != null)
            {
                strSql1.Append("CreateMode,");
                strSql2.Append("'" + model.CreateMode + "',");
            }
            if (model.tag1 != null)
            {
                strSql1.Append("tag1,");
                strSql2.Append("'" + model.tag1 + "',");
            }
            if (model.tag2 != null)
            {
                strSql1.Append("tag2,");
                strSql2.Append("'" + model.tag2 + "',");
            }
            if (model.tag3 != null)
            {
                strSql1.Append("tag3,");
                strSql2.Append("'" + model.tag3 + "',");
            }
            if (model.tag4 != null)
            {
                strSql1.Append("tag4,");
                strSql2.Append("'" + model.tag4 + "',");
            }
            if (model.tag5 != null)
            {
                strSql1.Append("tag5,");
                strSql2.Append("'" + model.tag5 + "',");
            }
            strSql.Append("insert into MainControlTask(");
            strSql.Append(strSql1.ToString().Remove(strSql1.Length - 1));
            strSql.Append(")");
            strSql.Append(" values (");
            strSql.Append(strSql2.ToString().Remove(strSql2.Length - 1));
            strSql.Append(")");
            int rows = DbHelperSQL.ExecuteSql(strSql.ToString());
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(CtlDBAccess.Model.MainControlTaskModel model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update MainControlTask set ");
            if (model.WMSTaskID != null)
            {
                strSql.Append("WMSTaskID='" + model.WMSTaskID + "',");
            }
            if (model.FlowPathKey != null)
            {
                strSql.Append("FlowPathKey='" + model.FlowPathKey + "',");
            }
            if (model.PalletCode != null)
            {
                strSql.Append("PalletCode='" + model.PalletCode + "',");
            }
            if (model.TaskStatus != null)
            {
                strSql.Append("TaskStatus='" + model.TaskStatus + "',");
            }
            if (model.TaskType != null)
            {
                strSql.Append("TaskType='" + model.TaskType + "',");
            }
            if (model.StDevice != null)
            {
                strSql.Append("StDevice='" + model.StDevice + "',");
            }
            if (model.StDeviceCata != null)
            {
                strSql.Append("StDeviceCata='" + model.StDeviceCata + "',");
            }
            if (model.StDeviceParam != null)
            {
                strSql.Append("StDeviceParam='" + model.StDeviceParam + "',");
            }
            else
            {
                strSql.Append("StDeviceParam= null ,");
            }
            if (model.EndDevice != null)
            {
                strSql.Append("EndDevice='" + model.EndDevice + "',");
            }
            if (model.EndDeviceCata != null)
            {
                strSql.Append("EndDeviceCata='" + model.EndDeviceCata + "',");
            }
            if (model.EndDeviceParam != null)
            {
                strSql.Append("EndDeviceParam='" + model.EndDeviceParam + "',");
            }
            else
            {
                strSql.Append("EndDeviceParam= null ,");
            }
            if (model.CreateTime != null)
            {
                strSql.Append("CreateTime='" + model.CreateTime + "',");
            }
            if (model.FinishTime != null)
            {
                strSql.Append("FinishTime='" + model.FinishTime + "',");
            }
            else
            {
                strSql.Append("FinishTime= null ,");
            }
            if (model.CreateMode != null)
            {
                strSql.Append("CreateMode='" + model.CreateMode + "',");
            }
            if (model.tag1 != null)
            {
                strSql.Append("tag1='" + model.tag1 + "',");
            }
            else
            {
                strSql.Append("tag1= null ,");
            }
            if (model.tag2 != null)
            {
                strSql.Append("tag2='" + model.tag2 + "',");
            }
            else
            {
                strSql.Append("tag2= null ,");
            }
            if (model.tag3 != null)
            {
                strSql.Append("tag3='" + model.tag3 + "',");
            }
            else
            {
                strSql.Append("tag3= null ,");
            }
            if (model.tag4 != null)
            {
                strSql.Append("tag4='" + model.tag4 + "',");
            }
            else
            {
                strSql.Append("tag4= null ,");
            }
            if (model.tag5 != null)
            {
                strSql.Append("tag5='" + model.tag5 + "',");
            }
            else
            {
                strSql.Append("tag5= null ,");
            }
            int n = strSql.ToString().LastIndexOf(",");
            strSql.Remove(n, 1);
            strSql.Append(" where MainTaskID='" + model.MainTaskID + "' ");
            int rowsAffected = DbHelperSQL.ExecuteSql(strSql.ToString());
            if (rowsAffected > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(string MainTaskID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from MainControlTask ");
            strSql.Append(" where MainTaskID='" + MainTaskID + "' ");
            int rowsAffected = DbHelperSQL.ExecuteSql(strSql.ToString());
            if (rowsAffected > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }		/// <summary>
        /// 批量删除数据
        /// </summary>
        public bool DeleteList(string MainTaskIDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from MainControlTask ");
            strSql.Append(" where MainTaskID in (" + MainTaskIDlist + ")  ");
            int rows = DbHelperSQL.ExecuteSql(strSql.ToString());
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public CtlDBAccess.Model.MainControlTaskModel GetModel(string MainTaskID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1  ");
            strSql.Append(" MainTaskID,WMSTaskID,FlowPathKey,PalletCode,TaskStatus,TaskType,StDevice,StDeviceCata,StDeviceParam,EndDevice,EndDeviceCata,EndDeviceParam,CreateTime,FinishTime,CreateMode,tag1,tag2,tag3,tag4,tag5 ");
            strSql.Append(" from MainControlTask ");
            strSql.Append(" where MainTaskID='" + MainTaskID + "' ");
            CtlDBAccess.Model.MainControlTaskModel model = new CtlDBAccess.Model.MainControlTaskModel();
            DataSet ds = DbHelperSQL.Query(strSql.ToString());
            if (ds.Tables[0].Rows.Count > 0)
            {
                return DataRowToModel(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public CtlDBAccess.Model.MainControlTaskModel DataRowToModel(DataRow row)
        {
            CtlDBAccess.Model.MainControlTaskModel model = new CtlDBAccess.Model.MainControlTaskModel();
            if (row != null)
            {
                if (row["MainTaskID"] != null)
                {
                    model.MainTaskID = row["MainTaskID"].ToString();
                }
                if (row["WMSTaskID"] != null)
                {
                    model.WMSTaskID = row["WMSTaskID"].ToString();
                }
                if (row["FlowPathKey"] != null)
                {
                    model.FlowPathKey = row["FlowPathKey"].ToString();
                }
                if (row["PalletCode"] != null)
                {
                    model.PalletCode = row["PalletCode"].ToString();
                }
                if (row["TaskStatus"] != null)
                {
                    model.TaskStatus = row["TaskStatus"].ToString();
                }
                if (row["TaskType"] != null)
                {
                    model.TaskType = row["TaskType"].ToString();
                }
                if (row["StDevice"] != null)
                {
                    model.StDevice = row["StDevice"].ToString();
                }
                if (row["StDeviceCata"] != null)
                {
                    model.StDeviceCata = row["StDeviceCata"].ToString();
                }
                if (row["StDeviceParam"] != null)
                {
                    model.StDeviceParam = row["StDeviceParam"].ToString();
                }
                if (row["EndDevice"] != null)
                {
                    model.EndDevice = row["EndDevice"].ToString();
                }
                if (row["EndDeviceCata"] != null)
                {
                    model.EndDeviceCata = row["EndDeviceCata"].ToString();
                }
                if (row["EndDeviceParam"] != null)
                {
                    model.EndDeviceParam = row["EndDeviceParam"].ToString();
                }
                if (row["CreateTime"] != null && row["CreateTime"].ToString() != "")
                {
                    model.CreateTime = DateTime.Parse(row["CreateTime"].ToString());
                }
                if (row["FinishTime"] != null && row["FinishTime"].ToString() != "")
                {
                    model.FinishTime = DateTime.Parse(row["FinishTime"].ToString());
                }
                if (row["CreateMode"] != null)
                {
                    model.CreateMode = row["CreateMode"].ToString();
                }
                if (row["tag1"] != null)
                {
                    model.tag1 = row["tag1"].ToString();
                }
                if (row["tag2"] != null)
                {
                    model.tag2 = row["tag2"].ToString();
                }
                if (row["tag3"] != null)
                {
                    model.tag3 = row["tag3"].ToString();
                }
                if (row["tag4"] != null)
                {
                    model.tag4 = row["tag4"].ToString();
                }
                if (row["tag5"] != null)
                {
                    model.tag5 = row["tag5"].ToString();
                }
            }
            return model;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select MainTaskID,WMSTaskID,FlowPathKey,PalletCode,TaskStatus,TaskType,StDevice,StDeviceCata,StDeviceParam,EndDevice,EndDeviceCata,EndDeviceParam,CreateTime,FinishTime,CreateMode,tag1,tag2,tag3,tag4,tag5 ");
            strSql.Append(" FROM MainControlTask ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" MainTaskID,WMSTaskID,FlowPathKey,PalletCode,TaskStatus,TaskType,StDevice,StDeviceCata,StDeviceParam,EndDevice,EndDeviceCata,EndDeviceParam,CreateTime,FinishTime,CreateMode,tag1,tag2,tag3,tag4,tag5 ");
            strSql.Append(" FROM MainControlTask ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM MainControlTask ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            object obj = DbHelperSQL.GetSingle(strSql.ToString());
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM ( ");
            strSql.Append(" SELECT ROW_NUMBER() OVER (");
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                strSql.Append("order by T." + orderby);
            }
            else
            {
                strSql.Append("order by T.MainTaskID desc");
            }
            strSql.Append(")AS Row, T.*  from MainControlTask T ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return DbHelperSQL.Query(strSql.ToString());
        }

        /*
        */

        #endregion  Method
        #region  MethodEx

        #endregion  MethodEx
    }
}

