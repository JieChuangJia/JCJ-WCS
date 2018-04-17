using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using DBAccess.DBUtility;//Please add references
namespace DBAccess.DAL
{
    /// <summary>
    /// 数据访问类:BatteryModel
    /// </summary>
    public partial class BatteryDal
    {
        public BatteryDal()
        { }
        #region  BasicMethod

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string batteryID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Battery");
            strSql.Append(" where batteryID=@batteryID ");
            SqlParameter[] parameters = {
					new SqlParameter("@batteryID", SqlDbType.NVarChar,50)			};
            parameters[0].Value = batteryID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(DBAccess.Model.BatteryModel model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Battery(");
            strSql.Append("batteryID,batModuleID,batPackID,batModuleAsmTime)");
            strSql.Append(" values (");
            strSql.Append("@batteryID,@batModuleID,@batPackID,@batModuleAsmTime)");
            SqlParameter[] parameters = {
					new SqlParameter("@batteryID", SqlDbType.NVarChar,50),
					new SqlParameter("@batModuleID", SqlDbType.NVarChar,50),
					new SqlParameter("@batPackID", SqlDbType.NVarChar,50),
					new SqlParameter("@batModuleAsmTime", SqlDbType.DateTime)};
            parameters[0].Value = model.batteryID;
            parameters[1].Value = model.batModuleID;
            parameters[2].Value = model.batPackID;
            parameters[3].Value = model.batModuleAsmTime;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
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
        public bool Update(DBAccess.Model.BatteryModel model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Battery set ");
            strSql.Append("batModuleID=@batModuleID,");
            strSql.Append("batPackID=@batPackID,");
            strSql.Append("batModuleAsmTime=@batModuleAsmTime");
            strSql.Append(" where batteryID=@batteryID ");
            SqlParameter[] parameters = {
					new SqlParameter("@batModuleID", SqlDbType.NVarChar,50),
					new SqlParameter("@batPackID", SqlDbType.NVarChar,50),
					new SqlParameter("@batModuleAsmTime", SqlDbType.DateTime),
					new SqlParameter("@batteryID", SqlDbType.NVarChar,50)};
            parameters[0].Value = model.batModuleID;
            parameters[1].Value = model.batPackID;
            parameters[2].Value = model.batModuleAsmTime;
            parameters[3].Value = model.batteryID;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
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
        /// 删除一条数据
        /// </summary>
        public bool Delete(string batteryID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Battery ");
            strSql.Append(" where batteryID=@batteryID ");
            SqlParameter[] parameters = {
					new SqlParameter("@batteryID", SqlDbType.NVarChar,50)			};
            parameters[0].Value = batteryID;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
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
        /// 批量删除数据
        /// </summary>
        public bool DeleteList(string batteryIDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Battery ");
            strSql.Append(" where batteryID in (" + batteryIDlist + ")  ");
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
        public DBAccess.Model.BatteryModel GetModel(string batteryID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 batteryID,batModuleID,batPackID,batModuleAsmTime from Battery ");
            strSql.Append(" where batteryID=@batteryID ");
            SqlParameter[] parameters = {
					new SqlParameter("@batteryID", SqlDbType.NVarChar,50)			};
            parameters[0].Value = batteryID;

            DBAccess.Model.BatteryModel model = new DBAccess.Model.BatteryModel();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
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
        public DBAccess.Model.BatteryModel DataRowToModel(DataRow row)
        {
            DBAccess.Model.BatteryModel model = new DBAccess.Model.BatteryModel();
            if (row != null)
            {
                if (row["batteryID"] != null)
                {
                    model.batteryID = row["batteryID"].ToString();
                }
                if (row["batModuleID"] != null)
                {
                    model.batModuleID = row["batModuleID"].ToString();
                }
                if (row["batPackID"] != null)
                {
                    model.batPackID = row["batPackID"].ToString();
                }
                if (row["batModuleAsmTime"] != null && row["batModuleAsmTime"].ToString() != "")
                {
                    model.batModuleAsmTime = DateTime.Parse(row["batModuleAsmTime"].ToString());
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
            strSql.Append("select batteryID,batModuleID,batPackID,batModuleAsmTime ");
            strSql.Append(" FROM Battery ");
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
            strSql.Append(" batteryID,batModuleID,batPackID,batModuleAsmTime ");
            strSql.Append(" FROM Battery ");
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
            strSql.Append("select count(1) FROM Battery ");
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
                strSql.Append("order by T.batteryID desc");
            }
            strSql.Append(")AS Row, T.*  from Battery T ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return DbHelperSQL.Query(strSql.ToString());
        }

        /*
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        {
            SqlParameter[] parameters = {
                    new SqlParameter("@tblName", SqlDbType.VarChar, 255),
                    new SqlParameter("@fldName", SqlDbType.VarChar, 255),
                    new SqlParameter("@PageSize", SqlDbType.Int),
                    new SqlParameter("@PageIndex", SqlDbType.Int),
                    new SqlParameter("@IsReCount", SqlDbType.Bit),
                    new SqlParameter("@OrderType", SqlDbType.Bit),
                    new SqlParameter("@strWhere", SqlDbType.VarChar,1000),
                    };
            parameters[0].Value = "Battery";
            parameters[1].Value = "batteryID";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;	
            return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
        }*/

        #endregion  BasicMethod
        #region  ExtensionMethod

        #endregion  ExtensionMethod
    }
}

