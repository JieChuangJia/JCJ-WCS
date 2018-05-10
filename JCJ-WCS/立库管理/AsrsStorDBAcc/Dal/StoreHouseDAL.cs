using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
 
namespace AsrsStorDBAcc.DAL
{
    /// <summary>
    /// 数据访问类:StoreHouse
    /// </summary>
    public partial class StoreHouseDAL
    {
        public StoreHouseDAL()
        { }
        #region  BasicMethod

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(long StoreHouseID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from StoreHouse");
            strSql.Append(" where StoreHouseID=@StoreHouseID ");
            SqlParameter[] parameters = {
					new SqlParameter("@StoreHouseID", SqlDbType.BigInt,8)			};
            parameters[0].Value = StoreHouseID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(AsrsStorDBAcc.Model.StoreHouseModel model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into StoreHouse(");
            strSql.Append("StoreHouseID,StoreHouseName,StoreHouseDesc,Reserve)");
            strSql.Append(" values (");
            strSql.Append("@StoreHouseID,@StoreHouseName,@StoreHouseDesc,@Reserve)");
            SqlParameter[] parameters = {
					new SqlParameter("@StoreHouseID", SqlDbType.BigInt,8),
					new SqlParameter("@StoreHouseName", SqlDbType.NVarChar,50),
					new SqlParameter("@StoreHouseDesc", SqlDbType.NVarChar,100),
					new SqlParameter("@Reserve", SqlDbType.NVarChar,200)};
            parameters[0].Value = model.StoreHouseID;
            parameters[1].Value = model.StoreHouseName;
            parameters[2].Value = model.StoreHouseDesc;
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
        public bool Update(AsrsStorDBAcc.Model.StoreHouseModel model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update StoreHouse set ");
            strSql.Append("StoreHouseName=@StoreHouseName,");
            strSql.Append("StoreHouseDesc=@StoreHouseDesc,");
            strSql.Append("Reserve=@Reserve");
            strSql.Append(" where StoreHouseID=@StoreHouseID ");
            SqlParameter[] parameters = {
					new SqlParameter("@StoreHouseName", SqlDbType.NVarChar,50),
					new SqlParameter("@StoreHouseDesc", SqlDbType.NVarChar,100),
					new SqlParameter("@Reserve", SqlDbType.NVarChar,200),
					new SqlParameter("@StoreHouseID", SqlDbType.BigInt,8)};
            parameters[0].Value = model.StoreHouseName;
            parameters[1].Value = model.StoreHouseDesc;
            parameters[2].Value = model.Reserve;
            parameters[3].Value = model.StoreHouseID;

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
        public bool Delete(long StoreHouseID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from StoreHouse ");
            strSql.Append(" where StoreHouseID=@StoreHouseID ");
            SqlParameter[] parameters = {
					new SqlParameter("@StoreHouseID", SqlDbType.BigInt,8)			};
            parameters[0].Value = StoreHouseID;

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
        public bool DeleteList(string StoreHouseIDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from StoreHouse ");
            strSql.Append(" where StoreHouseID in (" + StoreHouseIDlist + ")  ");
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
        public AsrsStorDBAcc.Model.StoreHouseModel GetModel(long StoreHouseID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 StoreHouseID,StoreHouseName,StoreHouseDesc,Reserve from StoreHouse ");
            strSql.Append(" where StoreHouseID=@StoreHouseID ");
            SqlParameter[] parameters = {
					new SqlParameter("@StoreHouseID", SqlDbType.BigInt,8)			};
            parameters[0].Value = StoreHouseID;

            AsrsStorDBAcc.Model.StoreHouseModel model = new AsrsStorDBAcc.Model.StoreHouseModel();
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
        public AsrsStorDBAcc.Model.StoreHouseModel DataRowToModel(DataRow row)
        {
            AsrsStorDBAcc.Model.StoreHouseModel model = new AsrsStorDBAcc.Model.StoreHouseModel();
            if (row != null)
            {
                if (row["StoreHouseID"] != null && row["StoreHouseID"].ToString() != "")
                {
                    model.StoreHouseID = long.Parse(row["StoreHouseID"].ToString());
                }
                if (row["StoreHouseName"] != null)
                {
                    model.StoreHouseName = row["StoreHouseName"].ToString();
                }
                if (row["StoreHouseDesc"] != null)
                {
                    model.StoreHouseDesc = row["StoreHouseDesc"].ToString();
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
            strSql.Append("select StoreHouseID,StoreHouseName,StoreHouseDesc,Reserve ");
            strSql.Append(" FROM StoreHouse ");
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
            strSql.Append(" StoreHouseID,StoreHouseName,StoreHouseDesc,Reserve ");
            strSql.Append(" FROM StoreHouse ");
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
            strSql.Append("select count(1) FROM StoreHouse ");
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
                strSql.Append("order by T.StoreHouseID desc");
            }
            strSql.Append(")AS Row, T.*  from StoreHouse T ");
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
            parameters[0].Value = "StoreHouse";
            parameters[1].Value = "StoreHouseID";
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

