using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
 
namespace AsrsStorDBAcc.DAL
{
    /// <summary>
    /// 数据访问类:StoreHouseLogicArea
    /// </summary>
    public partial class StoreHouseLogicAreaDAL
    {
        public StoreHouseLogicAreaDAL()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(long StoreHouseLogicAreaID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from StoreHouseLogicArea");
            strSql.Append(" where StoreHouseLogicAreaID=@StoreHouseLogicAreaID");
            SqlParameter[] parameters = {
					new SqlParameter("@StoreHouseLogicAreaID", SqlDbType.BigInt)
			};
            parameters[0].Value = StoreHouseLogicAreaID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public long Add(AsrsStorDBAcc.Model.StoreHouseLogicAreaModel model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into StoreHouseLogicArea(");
            strSql.Append("StoreHouseAreaName,StoreHouseAreaDesc,Reserve)");
            strSql.Append(" values (");
            strSql.Append("@StoreHouseAreaName,@StoreHouseAreaDesc,@Reserve)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@StoreHouseAreaName", SqlDbType.NVarChar,50),
					new SqlParameter("@StoreHouseAreaDesc", SqlDbType.NVarChar,100),
					new SqlParameter("@Reserve", SqlDbType.NVarChar,200)};
            parameters[0].Value = model.StoreHouseAreaName;
            parameters[1].Value = model.StoreHouseAreaDesc;
            parameters[2].Value = model.Reserve;

            object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt64(obj);
            }
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(AsrsStorDBAcc.Model.StoreHouseLogicAreaModel model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update StoreHouseLogicArea set ");
            strSql.Append("StoreHouseAreaName=@StoreHouseAreaName,");
            strSql.Append("StoreHouseAreaDesc=@StoreHouseAreaDesc,");
            strSql.Append("Reserve=@Reserve");
            strSql.Append(" where StoreHouseLogicAreaID=@StoreHouseLogicAreaID");
            SqlParameter[] parameters = {
					new SqlParameter("@StoreHouseAreaName", SqlDbType.NVarChar,50),
					new SqlParameter("@StoreHouseAreaDesc", SqlDbType.NVarChar,100),
					new SqlParameter("@Reserve", SqlDbType.NVarChar,200),
					new SqlParameter("@StoreHouseLogicAreaID", SqlDbType.BigInt,8)};
            parameters[0].Value = model.StoreHouseAreaName;
            parameters[1].Value = model.StoreHouseAreaDesc;
            parameters[2].Value = model.Reserve;
            parameters[3].Value = model.StoreHouseLogicAreaID;

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
        public bool Delete(long StoreHouseLogicAreaID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from StoreHouseLogicArea ");
            strSql.Append(" where StoreHouseLogicAreaID=@StoreHouseLogicAreaID");
            SqlParameter[] parameters = {
					new SqlParameter("@StoreHouseLogicAreaID", SqlDbType.BigInt)
			};
            parameters[0].Value = StoreHouseLogicAreaID;

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
        public bool DeleteList(string StoreHouseLogicAreaIDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from StoreHouseLogicArea ");
            strSql.Append(" where StoreHouseLogicAreaID in (" + StoreHouseLogicAreaIDlist + ")  ");
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
        public AsrsStorDBAcc.Model.StoreHouseLogicAreaModel GetModel(long StoreHouseLogicAreaID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 StoreHouseLogicAreaID,StoreHouseAreaName,StoreHouseAreaDesc,Reserve from StoreHouseLogicArea ");
            strSql.Append(" where StoreHouseLogicAreaID=@StoreHouseLogicAreaID");
            SqlParameter[] parameters = {
					new SqlParameter("@StoreHouseLogicAreaID", SqlDbType.BigInt)
			};
            parameters[0].Value = StoreHouseLogicAreaID;

            AsrsStorDBAcc.Model.StoreHouseLogicAreaModel model = new AsrsStorDBAcc.Model.StoreHouseLogicAreaModel();
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
        public AsrsStorDBAcc.Model.StoreHouseLogicAreaModel DataRowToModel(DataRow row)
        {
            AsrsStorDBAcc.Model.StoreHouseLogicAreaModel model = new AsrsStorDBAcc.Model.StoreHouseLogicAreaModel();
            if (row != null)
            {
                if (row["StoreHouseLogicAreaID"] != null && row["StoreHouseLogicAreaID"].ToString() != "")
                {
                    model.StoreHouseLogicAreaID = long.Parse(row["StoreHouseLogicAreaID"].ToString());
                }
                if (row["StoreHouseAreaName"] != null)
                {
                    model.StoreHouseAreaName = row["StoreHouseAreaName"].ToString();
                }
                if (row["StoreHouseAreaDesc"] != null)
                {
                    model.StoreHouseAreaDesc = row["StoreHouseAreaDesc"].ToString();
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
            strSql.Append("select StoreHouseLogicAreaID,StoreHouseAreaName,StoreHouseAreaDesc,Reserve ");
            strSql.Append(" FROM StoreHouseLogicArea ");
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
            strSql.Append(" StoreHouseLogicAreaID,StoreHouseAreaName,StoreHouseAreaDesc,Reserve ");
            strSql.Append(" FROM StoreHouseLogicArea ");
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
            strSql.Append("select count(1) FROM StoreHouseLogicArea ");
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
                strSql.Append("order by T.StoreHouseLogicAreaID desc");
            }
            strSql.Append(")AS Row, T.*  from StoreHouseLogicArea T ");
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
            parameters[0].Value = "StoreHouseLogicArea";
            parameters[1].Value = "StoreHouseLogicAreaID";
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

