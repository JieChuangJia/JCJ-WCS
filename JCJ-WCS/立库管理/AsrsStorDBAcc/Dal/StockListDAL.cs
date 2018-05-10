using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic;
 
namespace AsrsStorDBAcc.DAL
{
    /// <summary>
    /// 数据访问类:StockList
    /// </summary>
    public partial class StockListDAL
    {
        public StockListDAL()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(long StockListID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from StockList");
            strSql.Append(" where StockListID=@StockListID");
            SqlParameter[] parameters = {
					new SqlParameter("@StockListID", SqlDbType.BigInt)
			};
            parameters[0].Value = StockListID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public long Add(AsrsStorDBAcc.Model.StockListModel model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into StockList(");
            strSql.Append("StockID,InHouseTime,MeterialboxCode,MeterialBatch,MeterialStatus,Reserve)");
            strSql.Append(" values (");
            strSql.Append("@StockID,@InHouseTime,@MeterialboxCode,@MeterialBatch,@MeterialStatus,@Reserve)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@StockID", SqlDbType.BigInt,8),
					new SqlParameter("@InHouseTime", SqlDbType.DateTime),
					new SqlParameter("@MeterialboxCode", SqlDbType.NVarChar,50),
					new SqlParameter("@MeterialBatch", SqlDbType.NVarChar,50),
					new SqlParameter("@MeterialStatus", SqlDbType.NVarChar,50),
					new SqlParameter("@Reserve", SqlDbType.NVarChar,200)};
            parameters[0].Value = model.StockID;
            parameters[1].Value = model.InHouseTime;
            parameters[2].Value = model.MeterialboxCode;
            parameters[3].Value = model.MeterialBatch;
            parameters[4].Value = model.MeterialStatus;
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
        public bool Update(AsrsStorDBAcc.Model.StockListModel model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update StockList set ");
            strSql.Append("StockID=@StockID,");
            strSql.Append("InHouseTime=@InHouseTime,");
            strSql.Append("MeterialboxCode=@MeterialboxCode,");
            strSql.Append("MeterialBatch=@MeterialBatch,");
            strSql.Append("MeterialStatus=@MeterialStatus,");
            strSql.Append("Reserve=@Reserve");
            strSql.Append(" where StockListID=@StockListID");
            SqlParameter[] parameters = {
					new SqlParameter("@StockID", SqlDbType.BigInt,8),
					new SqlParameter("@InHouseTime", SqlDbType.DateTime),
					new SqlParameter("@MeterialboxCode", SqlDbType.NVarChar,50),
					new SqlParameter("@MeterialBatch", SqlDbType.NVarChar,50),
					new SqlParameter("@MeterialStatus", SqlDbType.NVarChar,50),
					new SqlParameter("@Reserve", SqlDbType.NVarChar,200),
					new SqlParameter("@StockListID", SqlDbType.BigInt,8)};
            parameters[0].Value = model.StockID;
            parameters[1].Value = model.InHouseTime;
            parameters[2].Value = model.MeterialboxCode;
            parameters[3].Value = model.MeterialBatch;
            parameters[4].Value = model.MeterialStatus;
            parameters[5].Value = model.Reserve;
            parameters[6].Value = model.StockListID;

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
        public bool Delete(long StockListID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from StockList ");
            strSql.Append(" where StockListID=@StockListID");
            SqlParameter[] parameters = {
					new SqlParameter("@StockListID", SqlDbType.BigInt)
			};
            parameters[0].Value = StockListID;

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
        public bool DeleteList(string StockListIDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from StockList ");
            strSql.Append(" where StockListID in (" + StockListIDlist + ")  ");
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
        public AsrsStorDBAcc.Model.StockListModel GetModel(long StockListID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 StockListID,StockID,InHouseTime,MeterialboxCode,MeterialBatch,MeterialStatus,Reserve from StockList ");
            strSql.Append(" where StockListID=@StockListID");
            SqlParameter[] parameters = {
					new SqlParameter("@StockListID", SqlDbType.BigInt)
			};
            parameters[0].Value = StockListID;

            AsrsStorDBAcc.Model.StockListModel model = new AsrsStorDBAcc.Model.StockListModel();
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
        public AsrsStorDBAcc.Model.StockListModel DataRowToModel(DataRow row)
        {
            AsrsStorDBAcc.Model.StockListModel model = new AsrsStorDBAcc.Model.StockListModel();
            if (row != null)
            {
                if (row["StockListID"] != null && row["StockListID"].ToString() != "")
                {
                    model.StockListID = long.Parse(row["StockListID"].ToString());
                }
                if (row["StockID"] != null && row["StockID"].ToString() != "")
                {
                    model.StockID = long.Parse(row["StockID"].ToString());
                }
                if (row["InHouseTime"] != null && row["InHouseTime"].ToString() != "")
                {
                    model.InHouseTime = DateTime.Parse(row["InHouseTime"].ToString());
                }
                if (row["MeterialboxCode"] != null)
                {
                    model.MeterialboxCode = row["MeterialboxCode"].ToString();
                }
                if (row["MeterialBatch"] != null)
                {
                    model.MeterialBatch = row["MeterialBatch"].ToString();
                }
                if (row["MeterialStatus"] != null)
                {
                    model.MeterialStatus = row["MeterialStatus"].ToString();
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
            strSql.Append("select StockListID,StockID,InHouseTime,MeterialboxCode,MeterialBatch,MeterialStatus,Reserve ");
            strSql.Append(" FROM StockList ");
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
            strSql.Append(" StockListID,StockID,InHouseTime,MeterialboxCode,MeterialBatch,MeterialStatus,Reserve ");
            strSql.Append(" FROM StockList ");
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
            strSql.Append("select count(1) FROM StockList ");
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
                strSql.Append("order by T.StockListID desc");
            }
            strSql.Append(")AS Row, T.*  from StockList T ");
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
            parameters[0].Value = "StockList";
            parameters[1].Value = "StockListID";
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

