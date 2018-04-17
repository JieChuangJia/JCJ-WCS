using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using DBAccess.DBUtility;//Please add references
namespace DBAccess.DAL
{
    /// <summary>
    /// 数据访问类:ModPsRecordModel
    /// </summary>
    public partial class ModPsRecordDal
    {
        public ModPsRecordDal()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string RecordID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from ModPsRecord");
            strSql.Append(" where RecordID=@RecordID ");
            SqlParameter[] parameters = {
					new SqlParameter("@RecordID", SqlDbType.NVarChar,255)			};
            parameters[0].Value = RecordID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(DBAccess.Model.ModPsRecordModel model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into ModPsRecord(");
            strSql.Append("RecordID,batModuleID,processRecord,recordTime)");
            strSql.Append(" values (");
            strSql.Append("@RecordID,@batModuleID,@processRecord,@recordTime)");
            SqlParameter[] parameters = {
					new SqlParameter("@RecordID", SqlDbType.NVarChar,255),
					new SqlParameter("@batModuleID", SqlDbType.NVarChar,50),
					new SqlParameter("@processRecord", SqlDbType.NVarChar,50),
					new SqlParameter("@recordTime", SqlDbType.DateTime)};
            parameters[0].Value = model.RecordID;
            parameters[1].Value = model.batModuleID;
            parameters[2].Value = model.processRecord;
            parameters[3].Value = model.recordTime;

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
        public bool Update(DBAccess.Model.ModPsRecordModel model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update ModPsRecord set ");
            strSql.Append("batModuleID=@batModuleID,");
            strSql.Append("processRecord=@processRecord,");
            strSql.Append("recordTime=@recordTime");
            strSql.Append(" where RecordID=@RecordID ");
            SqlParameter[] parameters = {
					new SqlParameter("@batModuleID", SqlDbType.NVarChar,50),
					new SqlParameter("@processRecord", SqlDbType.NVarChar,50),
					new SqlParameter("@recordTime", SqlDbType.DateTime),
					new SqlParameter("@RecordID", SqlDbType.NVarChar,255)};
            parameters[0].Value = model.batModuleID;
            parameters[1].Value = model.processRecord;
            parameters[2].Value = model.recordTime;
            parameters[3].Value = model.RecordID;

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
        public bool Delete(string RecordID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from ModPsRecord ");
            strSql.Append(" where RecordID=@RecordID ");
            SqlParameter[] parameters = {
					new SqlParameter("@RecordID", SqlDbType.NVarChar,255)			};
            parameters[0].Value = RecordID;

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
        public bool DeleteList(string RecordIDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from ModPsRecord ");
            strSql.Append(" where RecordID in (" + RecordIDlist + ")  ");
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
        public DBAccess.Model.ModPsRecordModel GetModel(string RecordID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 RecordID,batModuleID,processRecord,recordTime from ModPsRecord ");
            strSql.Append(" where RecordID=@RecordID ");
            SqlParameter[] parameters = {
					new SqlParameter("@RecordID", SqlDbType.NVarChar,255)			};
            parameters[0].Value = RecordID;

            DBAccess.Model.ModPsRecordModel model = new DBAccess.Model.ModPsRecordModel();
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
        public DBAccess.Model.ModPsRecordModel DataRowToModel(DataRow row)
        {
            DBAccess.Model.ModPsRecordModel model = new DBAccess.Model.ModPsRecordModel();
            if (row != null)
            {
                if (row["RecordID"] != null)
                {
                    model.RecordID = row["RecordID"].ToString();
                }
                if (row["batModuleID"] != null)
                {
                    model.batModuleID = row["batModuleID"].ToString();
                }
                if (row["processRecord"] != null)
                {
                    model.processRecord = row["processRecord"].ToString();
                }
                if (row["recordTime"] != null && row["recordTime"].ToString() != "")
                {
                    model.recordTime = DateTime.Parse(row["recordTime"].ToString());
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
            strSql.Append("select RecordID,batModuleID,processRecord,recordTime ");
            strSql.Append(" FROM ModPsRecord ");
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
            strSql.Append(" RecordID,batModuleID,processRecord,recordTime ");
            strSql.Append(" FROM ModPsRecord ");
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
            strSql.Append("select count(1) FROM ModPsRecord ");
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
                strSql.Append("order by T.RecordID desc");
            }
            strSql.Append(")AS Row, T.*  from ModPsRecord T ");
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
            parameters[0].Value = "ModPsRecord";
            parameters[1].Value = "RecordID";
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

