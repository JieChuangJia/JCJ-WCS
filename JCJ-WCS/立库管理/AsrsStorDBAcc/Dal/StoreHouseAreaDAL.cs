using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
 
namespace AsrsStorDBAcc.DAL
{
    /// <summary>
    /// 数据访问类:StoreHouseArea
    /// </summary>
    public partial class StoreHouseAreaDAL
    {
        public StoreHouseAreaDAL()
        { }
        #region  BasicMethod

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(long StoreHouseAreaID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from StoreHouseArea");
            strSql.Append(" where StoreHouseAreaID=@StoreHouseAreaID ");
            SqlParameter[] parameters = {
					new SqlParameter("@StoreHouseAreaID", SqlDbType.BigInt,8)			};
            parameters[0].Value = StoreHouseAreaID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(AsrsStorDBAcc.Model.StoreHouseAreaModel model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into StoreHouseArea(");
            strSql.Append("StoreHouseAreaID,StoreHouseID,StoreHouseAreaName,Reserve)");
            strSql.Append(" values (");
            strSql.Append("@StoreHouseAreaID,@StoreHouseID,@StoreHouseAreaName,@Reserve)");
            SqlParameter[] parameters = {
					new SqlParameter("@StoreHouseAreaID", SqlDbType.BigInt,8),
					new SqlParameter("@StoreHouseID", SqlDbType.BigInt,8),
					new SqlParameter("@StoreHouseAreaName", SqlDbType.NVarChar,50),
					new SqlParameter("@Reserve", SqlDbType.NVarChar,200)};
            parameters[0].Value = model.StoreHouseAreaID;
            parameters[1].Value = model.StoreHouseID;
            parameters[2].Value = model.StoreHouseAreaName;
            parameters[3].Value = model.Reserve;

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
        public bool Update(AsrsStorDBAcc.Model.StoreHouseAreaModel model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update StoreHouseArea set ");
            strSql.Append("StoreHouseID=@StoreHouseID,");
            strSql.Append("StoreHouseAreaName=@StoreHouseAreaName,");
            strSql.Append("Reserve=@Reserve");
            strSql.Append(" where StoreHouseAreaID=@StoreHouseAreaID ");
            SqlParameter[] parameters = {
					new SqlParameter("@StoreHouseID", SqlDbType.BigInt,8),
					new SqlParameter("@StoreHouseAreaName", SqlDbType.NVarChar,50),
					new SqlParameter("@Reserve", SqlDbType.NVarChar,200),
					new SqlParameter("@StoreHouseAreaID", SqlDbType.BigInt,8)};
            parameters[0].Value = model.StoreHouseID;
            parameters[1].Value = model.StoreHouseAreaName;
            parameters[2].Value = model.Reserve;
            parameters[3].Value = model.StoreHouseAreaID;

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
        public bool Delete(long StoreHouseAreaID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from StoreHouseArea ");
            strSql.Append(" where StoreHouseAreaID=@StoreHouseAreaID ");
            SqlParameter[] parameters = {
					new SqlParameter("@StoreHouseAreaID", SqlDbType.BigInt,8)			};
            parameters[0].Value = StoreHouseAreaID;

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
        public bool DeleteList(string StoreHouseAreaIDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from StoreHouseArea ");
            strSql.Append(" where StoreHouseAreaID in (" + StoreHouseAreaIDlist + ")  ");
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
        public AsrsStorDBAcc.Model.StoreHouseAreaModel GetModel(long StoreHouseAreaID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 StoreHouseAreaID,StoreHouseID,StoreHouseAreaName,Reserve from StoreHouseArea ");
            strSql.Append(" where StoreHouseAreaID=@StoreHouseAreaID ");
            SqlParameter[] parameters = {
					new SqlParameter("@StoreHouseAreaID", SqlDbType.BigInt,8)			};
            parameters[0].Value = StoreHouseAreaID;

            AsrsStorDBAcc.Model.StoreHouseAreaModel model = new AsrsStorDBAcc.Model.StoreHouseAreaModel();
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
        public AsrsStorDBAcc.Model.StoreHouseAreaModel DataRowToModel(DataRow row)
        {
            AsrsStorDBAcc.Model.StoreHouseAreaModel model = new AsrsStorDBAcc.Model.StoreHouseAreaModel();
            if (row != null)
            {
                if (row["StoreHouseAreaID"] != null && row["StoreHouseAreaID"].ToString() != "")
                {
                    model.StoreHouseAreaID = long.Parse(row["StoreHouseAreaID"].ToString());
                }
                if (row["StoreHouseID"] != null && row["StoreHouseID"].ToString() != "")
                {
                    model.StoreHouseID = long.Parse(row["StoreHouseID"].ToString());
                }
                if (row["StoreHouseAreaName"] != null)
                {
                    model.StoreHouseAreaName = row["StoreHouseAreaName"].ToString();
                }
                if (row["Reserve"] != null)
                {
                    model.Reserve = row["Reserve"].ToString();
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
            strSql.Append("select StoreHouseAreaID,StoreHouseID,StoreHouseAreaName,Reserve ");
            strSql.Append(" FROM StoreHouseArea ");
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
            strSql.Append(" StoreHouseAreaID,StoreHouseID,StoreHouseAreaName,Reserve ");
            strSql.Append(" FROM StoreHouseArea ");
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
            strSql.Append("select count(1) FROM StoreHouseArea ");
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
                strSql.Append("order by T.StoreHouseAreaID desc");
            }
            strSql.Append(")AS Row, T.*  from StoreHouseArea T ");
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
            parameters[0].Value = "StoreHouseArea";
            parameters[1].Value = "StoreHouseAreaID";
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

