using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using CtlDBAccess.DBUtility;//Please add references
namespace CtlDBAccess.Dal
{/// <summary>
    /// 数据访问类:ControlTaskModel
    /// </summary>
    public partial class ControlTaskDal
    {
        public ControlTaskDal()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string TaskID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from ControlTask");
            strSql.Append(" where TaskID='" + TaskID + "' ");
            return DbHelperSQL.Exists(strSql.ToString());
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(CtlDBAccess.Model.ControlTaskModel model)
        {
            StringBuilder strSql = new StringBuilder();
            StringBuilder strSql1 = new StringBuilder();
            StringBuilder strSql2 = new StringBuilder();
            if (model.TaskID != null)
            {
                strSql1.Append("TaskID,");
                strSql2.Append("'" + model.TaskID + "',");
            }
            if (model.DeviceID != null)
            {
                strSql1.Append("DeviceID,");
                strSql2.Append("'" + model.DeviceID + "',");
            }
            if (model.DeviceCata != null)
            {
                strSql1.Append("DeviceCata,");
                strSql2.Append("'" + model.DeviceCata + "',");
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
            if (model.MainTaskID != null)
            {
                strSql1.Append("MainTaskID,");
                strSql2.Append("'" + model.MainTaskID + "',");
            }
            if (model.PalletCode != null)
            {
                strSql1.Append("PalletCode,");
                strSql2.Append("'" + model.PalletCode + "',");
            }
            if (model.ControlID != null)
            {
                strSql1.Append("ControlID,");
                strSql2.Append("" + model.ControlID + ",");
            }
            if (model.TaskIndex != null)
            {
                strSql1.Append("TaskIndex,");
                strSql2.Append("" + model.TaskIndex + ",");
            }
            if (model.TaskType != null)
            {
                strSql1.Append("TaskType,");
                strSql2.Append("" + model.TaskType + ",");
            }
            if (model.TaskParam != null)
            {
                strSql1.Append("TaskParam,");
                strSql2.Append("'" + model.TaskParam + "',");
            }
            if (model.TaskStatus != null)
            {
                strSql1.Append("TaskStatus,");
                strSql2.Append("'" + model.TaskStatus + "',");
            }
            if (model.TaskPhase != null)
            {
                strSql1.Append("TaskPhase,");
                strSql2.Append("" + model.TaskPhase + ",");
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
            if (model.Remark != null)
            {
                strSql1.Append("Remark,");
                strSql2.Append("'" + model.Remark + "',");
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
            strSql.Append("insert into ControlTask(");
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
        public bool Update(CtlDBAccess.Model.ControlTaskModel model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update ControlTask set ");
            if (model.DeviceID != null)
            {
                strSql.Append("DeviceID='" + model.DeviceID + "',");
            }
            if (model.DeviceCata != null)
            {
                strSql.Append("DeviceCata='" + model.DeviceCata + "',");
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
            if (model.MainTaskID != null)
            {
                strSql.Append("MainTaskID='" + model.MainTaskID + "',");
            }
            if (model.PalletCode != null)
            {
                strSql.Append("PalletCode='" + model.PalletCode + "',");
            }
            if (model.ControlID != null)
            {
                strSql.Append("ControlID=" + model.ControlID + ",");
            }
            if (model.TaskIndex != null)
            {
                strSql.Append("TaskIndex=" + model.TaskIndex + ",");
            }
            if (model.TaskType != null)
            {
                strSql.Append("TaskType=" + model.TaskType + ",");
            }
            if (model.TaskParam != null)
            {
                strSql.Append("TaskParam='" + model.TaskParam + "',");
            }
            if (model.TaskStatus != null)
            {
                strSql.Append("TaskStatus='" + model.TaskStatus + "',");
            }
            if (model.TaskPhase != null)
            {
                strSql.Append("TaskPhase=" + model.TaskPhase + ",");
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
            if (model.Remark != null)
            {
                strSql.Append("Remark='" + model.Remark + "',");
            }
            else
            {
                strSql.Append("Remark= null ,");
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
            strSql.Append(" where TaskID='" + model.TaskID + "' ");
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
        public bool Delete(string TaskID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from ControlTask ");
            strSql.Append(" where TaskID='" + TaskID + "' ");
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
        public bool DeleteList(string TaskIDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from ControlTask ");
            strSql.Append(" where TaskID in (" + TaskIDlist + ")  ");
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
        public CtlDBAccess.Model.ControlTaskModel GetModel(string TaskID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1  ");
            strSql.Append(" TaskID,DeviceID,DeviceCata,StDevice,StDeviceCata,StDeviceParam,EndDevice,EndDeviceCata,EndDeviceParam,MainTaskID,PalletCode,ControlID,TaskIndex,TaskType,TaskParam,TaskStatus,TaskPhase,CreateTime,FinishTime,CreateMode,Remark,tag1,tag2,tag3,tag4,tag5 ");
            strSql.Append(" from ControlTask ");
            strSql.Append(" where TaskID='" + TaskID + "' ");
            CtlDBAccess.Model.ControlTaskModel model = new CtlDBAccess.Model.ControlTaskModel();
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
        public CtlDBAccess.Model.ControlTaskModel DataRowToModel(DataRow row)
        {
            CtlDBAccess.Model.ControlTaskModel model = new CtlDBAccess.Model.ControlTaskModel();
            if (row != null)
            {
                if (row["TaskID"] != null)
                {
                    model.TaskID = row["TaskID"].ToString();
                }
                if (row["DeviceID"] != null)
                {
                    model.DeviceID = row["DeviceID"].ToString();
                }
                if (row["DeviceCata"] != null)
                {
                    model.DeviceCata = row["DeviceCata"].ToString();
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
                if (row["MainTaskID"] != null)
                {
                    model.MainTaskID = row["MainTaskID"].ToString();
                }
                if (row["PalletCode"] != null)
                {
                    model.PalletCode = row["PalletCode"].ToString();
                }
                if (row["ControlID"] != null && row["ControlID"].ToString() != "")
                {
                    model.ControlID = int.Parse(row["ControlID"].ToString());
                }
                if (row["TaskIndex"] != null && row["TaskIndex"].ToString() != "")
                {
                    model.TaskIndex = int.Parse(row["TaskIndex"].ToString());
                }
                if (row["TaskType"] != null && row["TaskType"].ToString() != "")
                {
                    model.TaskType = int.Parse(row["TaskType"].ToString());
                }
                if (row["TaskParam"] != null)
                {
                    model.TaskParam = row["TaskParam"].ToString();
                }
                if (row["TaskStatus"] != null)
                {
                    model.TaskStatus = row["TaskStatus"].ToString();
                }
                if (row["TaskPhase"] != null && row["TaskPhase"].ToString() != "")
                {
                    model.TaskPhase = int.Parse(row["TaskPhase"].ToString());
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
                if (row["Remark"] != null)
                {
                    model.Remark = row["Remark"].ToString();
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
            strSql.Append("select TaskID,DeviceID,DeviceCata,StDevice,StDeviceCata,StDeviceParam,EndDevice,EndDeviceCata,EndDeviceParam,MainTaskID,PalletCode,ControlID,TaskIndex,TaskType,TaskParam,TaskStatus,TaskPhase,CreateTime,FinishTime,CreateMode,Remark,tag1,tag2,tag3,tag4,tag5 ");
            strSql.Append(" FROM ControlTask ");
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
            strSql.Append(" TaskID,DeviceID,DeviceCata,StDevice,StDeviceCata,StDeviceParam,EndDevice,EndDeviceCata,EndDeviceParam,MainTaskID,PalletCode,ControlID,TaskIndex,TaskType,TaskParam,TaskStatus,TaskPhase,CreateTime,FinishTime,CreateMode,Remark,tag1,tag2,tag3,tag4,tag5 ");
            strSql.Append(" FROM ControlTask ");
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
            strSql.Append("select count(1) FROM ControlTask ");
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
                strSql.Append("order by T.TaskID desc");
            }
            strSql.Append(")AS Row, T.*  from ControlTask T ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return DbHelperSQL.Query(strSql.ToString());
        }

        #endregion  BasicMethod
        #region  ExtensionMethod
        public long GetMaxControlID()
        {
            //string SELECT MAX(字段) FORM 表格1 WHERE 你的条件
            return DbHelperSQL.GetMaxID("ControlID", "ControlTask");
        }
        #endregion  ExtensionMethod
    }
}
