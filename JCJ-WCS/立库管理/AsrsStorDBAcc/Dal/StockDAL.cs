using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
 
namespace AsrsStorDBAcc.DAL
{
    /// <summary>
    /// 数据访问类:Stock
    /// </summary>
    public partial class StockDAL
    {
        public StockDAL()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(long StockID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Stock");
            strSql.Append(" where StockID=@StockID");
            SqlParameter[] parameters = {
					new SqlParameter("@StockID", SqlDbType.BigInt)
			};
            parameters[0].Value = StockID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public long Add(AsrsStorDBAcc.Model.StockModel model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Stock(");
            strSql.Append("GoodsSiteID,TrayID,IsFull,Reserve)");
            strSql.Append(" values (");
            strSql.Append("@GoodsSiteID,@TrayID,@IsFull,@Reserve)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@GoodsSiteID", SqlDbType.BigInt,8),
					new SqlParameter("@TrayID", SqlDbType.NVarChar,50),
					new SqlParameter("@IsFull", SqlDbType.Bit,1),
					new SqlParameter("@Reserve", SqlDbType.NVarChar,200)};
            parameters[0].Value = model.GoodsSiteID;
            parameters[1].Value = model.TrayID;
            parameters[2].Value = model.IsFull;
            parameters[3].Value = model.Reserve;

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
        public bool Update(AsrsStorDBAcc.Model.StockModel model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Stock set ");
            strSql.Append("GoodsSiteID=@GoodsSiteID,");
            strSql.Append("TrayID=@TrayID,");
            strSql.Append("IsFull=@IsFull,");
            strSql.Append("Reserve=@Reserve");
            strSql.Append(" where StockID=@StockID");
            SqlParameter[] parameters = {
					new SqlParameter("@GoodsSiteID", SqlDbType.BigInt,8),
					new SqlParameter("@TrayID", SqlDbType.NVarChar,50),
					new SqlParameter("@IsFull", SqlDbType.Bit,1),
					new SqlParameter("@Reserve", SqlDbType.NVarChar,200),
					new SqlParameter("@StockID", SqlDbType.BigInt,8)};
            parameters[0].Value = model.GoodsSiteID;
            parameters[1].Value = model.TrayID;
            parameters[2].Value = model.IsFull;
            parameters[3].Value = model.Reserve;
            parameters[4].Value = model.StockID;

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
        public bool Delete(long StockID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Stock ");
            strSql.Append(" where StockID=@StockID");
            SqlParameter[] parameters = {
					new SqlParameter("@StockID", SqlDbType.BigInt)
			};
            parameters[0].Value = StockID;

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
        public bool DeleteList(string StockIDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Stock ");
            strSql.Append(" where StockID in (" + StockIDlist + ")  ");
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
        public AsrsStorDBAcc.Model.StockModel GetModel(long StockID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 StockID,GoodsSiteID,TrayID,IsFull,Reserve from Stock ");
            strSql.Append(" where StockID=@StockID");
            SqlParameter[] parameters = {
					new SqlParameter("@StockID", SqlDbType.BigInt)
			};
            parameters[0].Value = StockID;

            AsrsStorDBAcc.Model.StockModel model = new AsrsStorDBAcc.Model.StockModel();
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
        public AsrsStorDBAcc.Model.StockModel DataRowToModel(DataRow row)
        {
            AsrsStorDBAcc.Model.StockModel model = new AsrsStorDBAcc.Model.StockModel();
            if (row != null)
            {
                if (row["StockID"] != null && row["StockID"].ToString() != "")
                {
                    model.StockID = long.Parse(row["StockID"].ToString());
                }
                if (row["GoodsSiteID"] != null && row["GoodsSiteID"].ToString() != "")
                {
                    model.GoodsSiteID = long.Parse(row["GoodsSiteID"].ToString());
                }
                if (row["TrayID"] != null)
                {
                    model.TrayID = row["TrayID"].ToString();
                }
                if (row["IsFull"] != null && row["IsFull"].ToString() != "")
                {
                    if ((row["IsFull"].ToString() == "1") || (row["IsFull"].ToString().ToLower() == "true"))
                    {
                        model.IsFull = true;
                    }
                    else
                    {
                        model.IsFull = false;
                    }
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
            strSql.Append("select StockID,GoodsSiteID,TrayID,IsFull,Reserve ");
            strSql.Append(" FROM Stock ");
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
            strSql.Append(" StockID,GoodsSiteID,TrayID,IsFull,Reserve ");
            strSql.Append(" FROM Stock ");
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
            strSql.Append("select count(1) FROM Stock ");
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
                strSql.Append("order by T.StockID desc");
            }
            strSql.Append(")AS Row, T.*  from Stock T ");
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
            parameters[0].Value = "Stock";
            parameters[1].Value = "StockID";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;	
            return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
        }*/

        #endregion  BasicMethod
        #region  ExtensionMethod
        public bool DeleteModelByGSID(long gsID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Stock where  GoodsSiteID = " + gsID);

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

        public bool DeleteAll()
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Stock ");

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

        public AsrsStorDBAcc.Model.StockModel GetModelByGSID(long gsID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 StockID,GoodsSiteID,TrayID,IsFull,Reserve from Stock ");
            strSql.Append(" where GoodsSiteID=@GoodsSiteID");
            SqlParameter[] parameters = {
					new SqlParameter("@GoodsSiteID", SqlDbType.BigInt)
			};
            parameters[0].Value = gsID;

            AsrsStorDBAcc.Model.StockModel model = new AsrsStorDBAcc.Model.StockModel();
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
        #endregion  ExtensionMethod
    }
}

