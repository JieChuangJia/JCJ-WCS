using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
 
namespace AsrsStorDBAcc.DAL
{
    /// <summary>
    /// 数据访问类:GSOperRecord
    /// </summary>
    public partial class StackOperRecdDAL
    {
        public StackOperRecdDAL()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(long StockOperRecdID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from StockOperRecd");
            strSql.Append(" where StockOperRecdID=@StockOperRecdID");
            SqlParameter[] parameters = {
					new SqlParameter("@StockOperRecdID", SqlDbType.BigInt)
			};
            parameters[0].Value = StockOperRecdID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public long Add(AsrsStorDBAcc.Model.StockOperRecdModel model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into StockOperRecd(");
            strSql.Append("StoreHouseID,GoodsSitePos,OPerateType,OperateDetail,OPerateTime,Reserve)");
            strSql.Append(" values (");
            strSql.Append("@StoreHouseID,@GoodsSitePos,@OPerateType,@OperateDetail,@OPerateTime,@Reserve)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@StoreHouseID", SqlDbType.BigInt,8),
					new SqlParameter("@GoodsSitePos", SqlDbType.NVarChar,50),
					new SqlParameter("@OPerateType", SqlDbType.NVarChar,50),
					new SqlParameter("@OperateDetail", SqlDbType.NVarChar,200),
					new SqlParameter("@OPerateTime", SqlDbType.DateTime),
					new SqlParameter("@Reserve", SqlDbType.NVarChar,200)};
            parameters[0].Value = model.StoreHouseID;
            parameters[1].Value = model.GoodsSitePos;
            parameters[2].Value = model.OPerateType;
            parameters[3].Value = model.OperateDetail;
            parameters[4].Value = model.OPerateTime;
            parameters[5].Value = model.Reserve;

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
        public bool Update(AsrsStorDBAcc.Model.StockOperRecdModel model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update StockOperRecd set ");
            strSql.Append("StoreHouseID=@StoreHouseID,");
            strSql.Append("GoodsSitePos=@GoodsSitePos,");
            strSql.Append("OPerateType=@OPerateType,");
            strSql.Append("OperateDetail=@OperateDetail,");
            strSql.Append("OPerateTime=@OPerateTime,");
            strSql.Append("Reserve=@Reserve");
            strSql.Append(" where StockOperRecdID=@StockOperRecdID");
            SqlParameter[] parameters = {
					new SqlParameter("@StoreHouseID", SqlDbType.BigInt,8),
					new SqlParameter("@GoodsSitePos", SqlDbType.NVarChar,50),
					new SqlParameter("@OPerateType", SqlDbType.NVarChar,50),
					new SqlParameter("@OperateDetail", SqlDbType.NVarChar,200),
					new SqlParameter("@OPerateTime", SqlDbType.DateTime),
					new SqlParameter("@Reserve", SqlDbType.NVarChar,200),
					new SqlParameter("@StockOperRecdID", SqlDbType.BigInt,8)};
            parameters[0].Value = model.StoreHouseID;
            parameters[1].Value = model.GoodsSitePos;
            parameters[2].Value = model.OPerateType;
            parameters[3].Value = model.OperateDetail;
            parameters[4].Value = model.OPerateTime;
            parameters[5].Value = model.Reserve;
            parameters[6].Value = model.StockOperRecdID;

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
        public bool Delete(long StockOperRecdID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from StockOperRecd ");
            strSql.Append(" where StockOperRecdID=@StockOperRecdID");
            SqlParameter[] parameters = {
					new SqlParameter("@StockOperRecdID", SqlDbType.BigInt)
			};
            parameters[0].Value = StockOperRecdID;

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
        public bool DeleteList(string StockOperRecdIDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from StockOperRecd ");
            strSql.Append(" where StockOperRecdID in (" + StockOperRecdIDlist + ")  ");
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
        public AsrsStorDBAcc.Model.StockOperRecdModel GetModel(long StockOperRecdID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 StockOperRecdID,StoreHouseID,GoodsSitePos,OPerateType,OperateDetail,OPerateTime,Reserve from StockOperRecd ");
            strSql.Append(" where StockOperRecdID=@StockOperRecdID");
            SqlParameter[] parameters = {
					new SqlParameter("@StockOperRecdID", SqlDbType.BigInt)
			};
            parameters[0].Value = StockOperRecdID;

            AsrsStorDBAcc.Model.StockOperRecdModel model = new AsrsStorDBAcc.Model.StockOperRecdModel();
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
        public AsrsStorDBAcc.Model.StockOperRecdModel DataRowToModel(DataRow row)
        {
            AsrsStorDBAcc.Model.StockOperRecdModel model = new AsrsStorDBAcc.Model.StockOperRecdModel();
            if (row != null)
            {
                if (row["StockOperRecdID"] != null && row["StockOperRecdID"].ToString() != "")
                {
                    model.StockOperRecdID = long.Parse(row["StockOperRecdID"].ToString());
                }
                if (row["StoreHouseID"] != null && row["StoreHouseID"].ToString() != "")
                {
                    model.StoreHouseID = long.Parse(row["StoreHouseID"].ToString());
                }
                if (row["GoodsSitePos"] != null)
                {
                    model.GoodsSitePos = row["GoodsSitePos"].ToString();
                }
                if (row["OPerateType"] != null)
                {
                    model.OPerateType = row["OPerateType"].ToString();
                }
                if (row["OperateDetail"] != null)
                {
                    model.OperateDetail = row["OperateDetail"].ToString();
                }
                if (row["OPerateTime"] != null && row["OPerateTime"].ToString() != "")
                {
                    model.OPerateTime = DateTime.Parse(row["OPerateTime"].ToString());
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
            strSql.Append("select StockOperRecdID,StoreHouseID,GoodsSitePos,OPerateType,OperateDetail,OPerateTime,Reserve ");
            strSql.Append(" FROM StockOperRecd ");
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
            strSql.Append(" StockOperRecdID,StoreHouseID,GoodsSitePos,OPerateType,OperateDetail,OPerateTime,Reserve ");
            strSql.Append(" FROM StockOperRecd ");
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
            strSql.Append("select count(1) FROM StockOperRecd ");
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
                strSql.Append("order by T.StockOperRecdID desc");
            }
            strSql.Append(")AS Row, T.*  from StockOperRecd T ");
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
            parameters[0].Value = "StockOperRecd";
            parameters[1].Value = "StockOperRecdID";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;	
            return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
        }*/

        #endregion  BasicMethod
        #region  ExtensionMethod
        public bool DeletePreviousData(int days)
        {

            StringBuilder strSql = new StringBuilder();
            string nowTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            strSql.Append("delete from StockOperRecd ");
            strSql.Append(" where datediff(day,OPerateTime,'" + nowTime + "') >= " + days);
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
        #endregion  ExtensionMethod
    }
}

