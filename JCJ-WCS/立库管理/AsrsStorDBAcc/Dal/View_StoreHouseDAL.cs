using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
 
namespace AsrsStorDBAcc.DAL
{
    /// <summary>
    /// 数据访问类:View_StoreHouse
    /// </summary>
    public partial class View_StoreHouseDAL
    {
        public View_StoreHouseDAL()
        { }
        #region  BasicMethod

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(long StoreHouseID, string StoreHouseName, string StoreHouseDesc, long StoreHouseAreaID, string StoreHouseAreaName)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from View_StoreHouse");
            strSql.Append(" where StoreHouseID=@StoreHouseID and StoreHouseName=@StoreHouseName and StoreHouseDesc=@StoreHouseDesc and StoreHouseAreaID=@StoreHouseAreaID and StoreHouseAreaName=@StoreHouseAreaName ");
            SqlParameter[] parameters = {
					new SqlParameter("@StoreHouseID", SqlDbType.BigInt,8),
					new SqlParameter("@StoreHouseName", SqlDbType.NVarChar,50),
					new SqlParameter("@StoreHouseDesc", SqlDbType.NVarChar,100),
					new SqlParameter("@StoreHouseAreaID", SqlDbType.BigInt,8),
					new SqlParameter("@StoreHouseAreaName", SqlDbType.NVarChar,50)			};
            parameters[0].Value = StoreHouseID;
            parameters[1].Value = StoreHouseName;
            parameters[2].Value = StoreHouseDesc;
            parameters[3].Value = StoreHouseAreaID;
            parameters[4].Value = StoreHouseAreaName;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(AsrsStorDBAcc.Model.View_StoreHouseModel model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into View_StoreHouse(");
            strSql.Append("StoreHouseID,StoreHouseName,StoreHouseDesc,StoreHouseAreaID,StoreHouseAreaName)");
            strSql.Append(" values (");
            strSql.Append("@StoreHouseID,@StoreHouseName,@StoreHouseDesc,@StoreHouseAreaID,@StoreHouseAreaName)");
            SqlParameter[] parameters = {
					new SqlParameter("@StoreHouseID", SqlDbType.BigInt,8),
					new SqlParameter("@StoreHouseName", SqlDbType.NVarChar,50),
					new SqlParameter("@StoreHouseDesc", SqlDbType.NVarChar,100),
					new SqlParameter("@StoreHouseAreaID", SqlDbType.BigInt,8),
					new SqlParameter("@StoreHouseAreaName", SqlDbType.NVarChar,50)};
            parameters[0].Value = model.StoreHouseID;
            parameters[1].Value = model.StoreHouseName;
            parameters[2].Value = model.StoreHouseDesc;
            parameters[3].Value = model.StoreHouseAreaID;
            parameters[4].Value = model.StoreHouseAreaName;

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
        public bool Update(AsrsStorDBAcc.Model.View_StoreHouseModel model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update View_StoreHouse set ");
            strSql.Append("StoreHouseID=@StoreHouseID,");
            strSql.Append("StoreHouseName=@StoreHouseName,");
            strSql.Append("StoreHouseDesc=@StoreHouseDesc,");
            strSql.Append("StoreHouseAreaID=@StoreHouseAreaID,");
            strSql.Append("StoreHouseAreaName=@StoreHouseAreaName");
            strSql.Append(" where StoreHouseID=@StoreHouseID and StoreHouseName=@StoreHouseName and StoreHouseDesc=@StoreHouseDesc and StoreHouseAreaID=@StoreHouseAreaID and StoreHouseAreaName=@StoreHouseAreaName ");
            SqlParameter[] parameters = {
					new SqlParameter("@StoreHouseID", SqlDbType.BigInt,8),
					new SqlParameter("@StoreHouseName", SqlDbType.NVarChar,50),
					new SqlParameter("@StoreHouseDesc", SqlDbType.NVarChar,100),
					new SqlParameter("@StoreHouseAreaID", SqlDbType.BigInt,8),
					new SqlParameter("@StoreHouseAreaName", SqlDbType.NVarChar,50)};
            parameters[0].Value = model.StoreHouseID;
            parameters[1].Value = model.StoreHouseName;
            parameters[2].Value = model.StoreHouseDesc;
            parameters[3].Value = model.StoreHouseAreaID;
            parameters[4].Value = model.StoreHouseAreaName;

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
        public bool Delete(long StoreHouseID, string StoreHouseName, string StoreHouseDesc, long StoreHouseAreaID, string StoreHouseAreaName)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from View_StoreHouse ");
            strSql.Append(" where StoreHouseID=@StoreHouseID and StoreHouseName=@StoreHouseName and StoreHouseDesc=@StoreHouseDesc and StoreHouseAreaID=@StoreHouseAreaID and StoreHouseAreaName=@StoreHouseAreaName ");
            SqlParameter[] parameters = {
					new SqlParameter("@StoreHouseID", SqlDbType.BigInt,8),
					new SqlParameter("@StoreHouseName", SqlDbType.NVarChar,50),
					new SqlParameter("@StoreHouseDesc", SqlDbType.NVarChar,100),
					new SqlParameter("@StoreHouseAreaID", SqlDbType.BigInt,8),
					new SqlParameter("@StoreHouseAreaName", SqlDbType.NVarChar,50)			};
            parameters[0].Value = StoreHouseID;
            parameters[1].Value = StoreHouseName;
            parameters[2].Value = StoreHouseDesc;
            parameters[3].Value = StoreHouseAreaID;
            parameters[4].Value = StoreHouseAreaName;

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
        /// 得到一个对象实体
        /// </summary>
        public AsrsStorDBAcc.Model.View_StoreHouseModel GetModel(long StoreHouseID, string StoreHouseName, string StoreHouseDesc, long StoreHouseAreaID, string StoreHouseAreaName)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 StoreHouseID,StoreHouseName,StoreHouseDesc,StoreHouseAreaID,StoreHouseAreaName from View_StoreHouse ");
            strSql.Append(" where StoreHouseID=@StoreHouseID and StoreHouseName=@StoreHouseName and StoreHouseDesc=@StoreHouseDesc and StoreHouseAreaID=@StoreHouseAreaID and StoreHouseAreaName=@StoreHouseAreaName ");
            SqlParameter[] parameters = {
					new SqlParameter("@StoreHouseID", SqlDbType.BigInt,8),
					new SqlParameter("@StoreHouseName", SqlDbType.NVarChar,50),
					new SqlParameter("@StoreHouseDesc", SqlDbType.NVarChar,100),
					new SqlParameter("@StoreHouseAreaID", SqlDbType.BigInt,8),
					new SqlParameter("@StoreHouseAreaName", SqlDbType.NVarChar,50)			};
            parameters[0].Value = StoreHouseID;
            parameters[1].Value = StoreHouseName;
            parameters[2].Value = StoreHouseDesc;
            parameters[3].Value = StoreHouseAreaID;
            parameters[4].Value = StoreHouseAreaName;

            AsrsStorDBAcc.Model.View_StoreHouseModel model = new AsrsStorDBAcc.Model.View_StoreHouseModel();
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
        public AsrsStorDBAcc.Model.View_StoreHouseModel DataRowToModel(DataRow row)
        {
            AsrsStorDBAcc.Model.View_StoreHouseModel model = new AsrsStorDBAcc.Model.View_StoreHouseModel();
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
                if (row["StoreHouseAreaID"] != null && row["StoreHouseAreaID"].ToString() != "")
                {
                    model.StoreHouseAreaID = long.Parse(row["StoreHouseAreaID"].ToString());
                }
                if (row["StoreHouseAreaName"] != null)
                {
                    model.StoreHouseAreaName = row["StoreHouseAreaName"].ToString();
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
            strSql.Append("select StoreHouseID,StoreHouseName,StoreHouseDesc,StoreHouseAreaID,StoreHouseAreaName ");
            strSql.Append(" FROM View_StoreHouse ");
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
            strSql.Append(" StoreHouseID,StoreHouseName,StoreHouseDesc,StoreHouseAreaID,StoreHouseAreaName ");
            strSql.Append(" FROM View_StoreHouse ");
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
            strSql.Append("select count(1) FROM View_StoreHouse ");
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
                strSql.Append("order by T.StoreHouseAreaName desc");
            }
            strSql.Append(")AS Row, T.*  from View_StoreHouse T ");
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
            parameters[0].Value = "View_StoreHouse";
            parameters[1].Value = "StoreHouseAreaName";
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

