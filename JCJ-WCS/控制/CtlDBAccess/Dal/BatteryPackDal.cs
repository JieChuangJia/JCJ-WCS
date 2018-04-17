using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using DBAccess.DBUtility;//Please add references
namespace DBAccess.DAL
{
    /// <summary>
    /// 数据访问类:BatteryPackModel
    /// </summary>
    public partial class BatteryPackDal
    {
        public BatteryPackDal()
        { }
        #region  BasicMethod

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string batPackID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from BatteryPack");
            strSql.Append(" where batPackID=@batPackID ");
            SqlParameter[] parameters = {
					new SqlParameter("@batPackID", SqlDbType.NVarChar,50)			};
            parameters[0].Value = batPackID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(DBAccess.Model.BatteryPackModel model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into BatteryPack(");
            strSql.Append("batPackID,packAsmTime,opWorkerID)");
            strSql.Append(" values (");
            strSql.Append("@batPackID,@packAsmTime,@opWorkerID)");
            SqlParameter[] parameters = {
					new SqlParameter("@batPackID", SqlDbType.NVarChar,50),
					new SqlParameter("@packAsmTime", SqlDbType.DateTime),
					new SqlParameter("@opWorkerID", SqlDbType.NVarChar,50)};
            parameters[0].Value = model.batPackID;
            parameters[1].Value = model.packAsmTime;
            parameters[2].Value = model.opWorkerID;

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
        public bool Update(DBAccess.Model.BatteryPackModel model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update BatteryPack set ");
            strSql.Append("packAsmTime=@packAsmTime,");
            strSql.Append("opWorkerID=@opWorkerID");
            strSql.Append(" where batPackID=@batPackID ");
            SqlParameter[] parameters = {
					new SqlParameter("@packAsmTime", SqlDbType.DateTime),
					new SqlParameter("@opWorkerID", SqlDbType.NVarChar,50),
					new SqlParameter("@batPackID", SqlDbType.NVarChar,50)};
            parameters[0].Value = model.packAsmTime;
            parameters[1].Value = model.opWorkerID;
            parameters[2].Value = model.batPackID;

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
        public bool Delete(string batPackID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from BatteryPack ");
            strSql.Append(" where batPackID=@batPackID ");
            SqlParameter[] parameters = {
					new SqlParameter("@batPackID", SqlDbType.NVarChar,50)			};
            parameters[0].Value = batPackID;

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
        public bool DeleteList(string batPackIDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from BatteryPack ");
            strSql.Append(" where batPackID in (" + batPackIDlist + ")  ");
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
        public DBAccess.Model.BatteryPackModel GetModel(string batPackID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 batPackID,packAsmTime,opWorkerID from BatteryPack ");
            strSql.Append(" where batPackID=@batPackID ");
            SqlParameter[] parameters = {
					new SqlParameter("@batPackID", SqlDbType.NVarChar,50)			};
            parameters[0].Value = batPackID;

            DBAccess.Model.BatteryPackModel model = new DBAccess.Model.BatteryPackModel();
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
        public DBAccess.Model.BatteryPackModel DataRowToModel(DataRow row)
        {
            DBAccess.Model.BatteryPackModel model = new DBAccess.Model.BatteryPackModel();
            if (row != null)
            {
                if (row["batPackID"] != null)
                {
                    model.batPackID = row["batPackID"].ToString();
                }
                if (row["packAsmTime"] != null && row["packAsmTime"].ToString() != "")
                {
                    model.packAsmTime = DateTime.Parse(row["packAsmTime"].ToString());
                }
                if (row["opWorkerID"] != null)
                {
                    model.opWorkerID = row["opWorkerID"].ToString();
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
            strSql.Append("select batPackID,packAsmTime,opWorkerID ");
            strSql.Append(" FROM BatteryPack ");
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
            strSql.Append(" batPackID,packAsmTime,opWorkerID ");
            strSql.Append(" FROM BatteryPack ");
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
            strSql.Append("select count(1) FROM BatteryPack ");
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
                strSql.Append("order by T.batPackID desc");
            }
            strSql.Append(")AS Row, T.*  from BatteryPack T ");
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
            parameters[0].Value = "BatteryPack";
            parameters[1].Value = "batPackID";
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

