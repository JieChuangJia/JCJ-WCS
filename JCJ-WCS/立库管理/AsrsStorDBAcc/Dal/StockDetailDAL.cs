using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
 
namespace AsrsStorDBAcc.DAL
{
    /// <summary>
    /// 数据访问类:StockDetail
    /// </summary>
    public partial class StockDetailDAL
    {
        public StockDetailDAL()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(long StockDetailID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from StockDetail");
            strSql.Append(" where StockDetailID=@StockDetailID");
            SqlParameter[] parameters = {
					new SqlParameter("@StockDetailID", SqlDbType.BigInt)
			};
            parameters[0].Value = StockDetailID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public long Add(AsrsStorDBAcc.Model.StockDetailModel model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into StockDetail(");
            strSql.Append("StockListID,MeterialName,MeterialCode,MeterialPos,Reserve)");
            strSql.Append(" values (");
            strSql.Append("@StockListID,@MeterialName,@MeterialCode,@MeterialPos,@Reserve)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@StockListID", SqlDbType.BigInt,8),
					new SqlParameter("@MeterialName", SqlDbType.NVarChar,50),
					new SqlParameter("@MeterialCode", SqlDbType.NVarChar,50),
					new SqlParameter("@MeterialPos", SqlDbType.NVarChar,50),
					new SqlParameter("@Reserve", SqlDbType.NVarChar,200)};
            parameters[0].Value = model.StockListID;
            parameters[1].Value = model.MeterialName;
            parameters[2].Value = model.MeterialCode;
            parameters[3].Value = model.MeterialPos;
            parameters[4].Value = model.Reserve;

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
        public bool Update(AsrsStorDBAcc.Model.StockDetailModel model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update StockDetail set ");
            strSql.Append("StockListID=@StockListID,");
            strSql.Append("MeterialName=@MeterialName,");
            strSql.Append("MeterialCode=@MeterialCode,");
            strSql.Append("MeterialPos=@MeterialPos,");
            strSql.Append("Reserve=@Reserve");
            strSql.Append(" where StockDetailID=@StockDetailID");
            SqlParameter[] parameters = {
					new SqlParameter("@StockListID", SqlDbType.BigInt,8),
					new SqlParameter("@MeterialName", SqlDbType.NVarChar,50),
					new SqlParameter("@MeterialCode", SqlDbType.NVarChar,50),
					new SqlParameter("@MeterialPos", SqlDbType.NVarChar,50),
					new SqlParameter("@Reserve", SqlDbType.NVarChar,200),
					new SqlParameter("@StockDetailID", SqlDbType.BigInt,8)};
            parameters[0].Value = model.StockListID;
            parameters[1].Value = model.MeterialName;
            parameters[2].Value = model.MeterialCode;
            parameters[3].Value = model.MeterialPos;
            parameters[4].Value = model.Reserve;
            parameters[5].Value = model.StockDetailID;

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
        public bool Delete(long StockDetailID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from StockDetail ");
            strSql.Append(" where StockDetailID=@StockDetailID");
            SqlParameter[] parameters = {
					new SqlParameter("@StockDetailID", SqlDbType.BigInt)
			};
            parameters[0].Value = StockDetailID;

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
        public bool DeleteList(string StockDetailIDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from StockDetail ");
            strSql.Append(" where StockDetailID in (" + StockDetailIDlist + ")  ");
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
        public AsrsStorDBAcc.Model.StockDetailModel GetModel(long StockDetailID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 StockDetailID,StockListID,MeterialName,MeterialCode,MeterialPos,Reserve from StockDetail ");
            strSql.Append(" where StockDetailID=@StockDetailID");
            SqlParameter[] parameters = {
					new SqlParameter("@StockDetailID", SqlDbType.BigInt)
			};
            parameters[0].Value = StockDetailID;

            AsrsStorDBAcc.Model.StockDetailModel model = new AsrsStorDBAcc.Model.StockDetailModel();
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
        public AsrsStorDBAcc.Model.StockDetailModel DataRowToModel(DataRow row)
        {
            AsrsStorDBAcc.Model.StockDetailModel model = new AsrsStorDBAcc.Model.StockDetailModel();
            if (row != null)
            {
                if (row["StockDetailID"] != null && row["StockDetailID"].ToString() != "")
                {
                    model.StockDetailID = long.Parse(row["StockDetailID"].ToString());
                }
                if (row["StockListID"] != null && row["StockListID"].ToString() != "")
                {
                    model.StockListID = long.Parse(row["StockListID"].ToString());
                }
                if (row["MeterialName"] != null)
                {
                    model.MeterialName = row["MeterialName"].ToString();
                }
                if (row["MeterialCode"] != null)
                {
                    model.MeterialCode = row["MeterialCode"].ToString();
                }
                if (row["MeterialPos"] != null)
                {
                    model.MeterialPos = row["MeterialPos"].ToString();
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
            strSql.Append("select StockDetailID,StockListID,MeterialName,MeterialCode,MeterialPos,Reserve ");
            strSql.Append(" FROM StockDetail ");
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
            strSql.Append(" StockDetailID,StockListID,MeterialName,MeterialCode,MeterialPos,Reserve ");
            strSql.Append(" FROM StockDetail ");
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
            strSql.Append("select count(1) FROM StockDetail ");
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
                strSql.Append("order by T.StockDetailID desc");
            }
            strSql.Append(")AS Row, T.*  from StockDetail T ");
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
            parameters[0].Value = "StockDetail";
            parameters[1].Value = "StockDetailID";
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

