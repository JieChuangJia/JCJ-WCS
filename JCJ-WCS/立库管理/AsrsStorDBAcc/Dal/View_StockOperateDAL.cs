using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
 
namespace AsrsStorDBAcc.DAL
{
    /// <summary>
    /// 数据访问类:View_StockOperate
    /// </summary>
    public partial class View_StockOperateDAL
    {
        public View_StockOperateDAL()
        { }
        #region  BasicMethod

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(long StockOperRecdID, long StoreHouseID, string GoodsSitePos, string OPerateType, string OperateDetail, DateTime OPerateTime, string StoreHouseName, string StoreHouseDesc)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from View_StockOperate");
            strSql.Append(" where StockOperRecdID=@StockOperRecdID and StoreHouseID=@StoreHouseID and GoodsSitePos=@GoodsSitePos and OPerateType=@OPerateType and OperateDetail=@OperateDetail and OPerateTime=@OPerateTime and StoreHouseName=@StoreHouseName and StoreHouseDesc=@StoreHouseDesc ");
            SqlParameter[] parameters = {
					new SqlParameter("@StockOperRecdID", SqlDbType.BigInt,8),
					new SqlParameter("@StoreHouseID", SqlDbType.BigInt,8),
					new SqlParameter("@GoodsSitePos", SqlDbType.NVarChar,50),
					new SqlParameter("@OPerateType", SqlDbType.NVarChar,50),
					new SqlParameter("@OperateDetail", SqlDbType.NVarChar,200),
					new SqlParameter("@OPerateTime", SqlDbType.DateTime),
					new SqlParameter("@StoreHouseName", SqlDbType.NVarChar,50),
					new SqlParameter("@StoreHouseDesc", SqlDbType.NVarChar,100)			};
            parameters[0].Value = StockOperRecdID;
            parameters[1].Value = StoreHouseID;
            parameters[2].Value = GoodsSitePos;
            parameters[3].Value = OPerateType;
            parameters[4].Value = OperateDetail;
            parameters[5].Value = OPerateTime;
            parameters[6].Value = StoreHouseName;
            parameters[7].Value = StoreHouseDesc;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(AsrsStorDBAcc.Model.View_StockOperateModel model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into View_StockOperate(");
            strSql.Append("StockOperRecdID,StoreHouseID,GoodsSitePos,OPerateType,OperateDetail,OPerateTime,StoreHouseName,StoreHouseDesc)");
            strSql.Append(" values (");
            strSql.Append("@StockOperRecdID,@StoreHouseID,@GoodsSitePos,@OPerateType,@OperateDetail,@OPerateTime,@StoreHouseName,@StoreHouseDesc)");
            SqlParameter[] parameters = {
					new SqlParameter("@StockOperRecdID", SqlDbType.BigInt,8),
					new SqlParameter("@StoreHouseID", SqlDbType.BigInt,8),
					new SqlParameter("@GoodsSitePos", SqlDbType.NVarChar,50),
					new SqlParameter("@OPerateType", SqlDbType.NVarChar,50),
					new SqlParameter("@OperateDetail", SqlDbType.NVarChar,200),
					new SqlParameter("@OPerateTime", SqlDbType.DateTime),
					new SqlParameter("@StoreHouseName", SqlDbType.NVarChar,50),
					new SqlParameter("@StoreHouseDesc", SqlDbType.NVarChar,100)};
            parameters[0].Value = model.StockOperRecdID;
            parameters[1].Value = model.StoreHouseID;
            parameters[2].Value = model.GoodsSitePos;
            parameters[3].Value = model.OPerateType;
            parameters[4].Value = model.OperateDetail;
            parameters[5].Value = model.OPerateTime;
            parameters[6].Value = model.StoreHouseName;
            parameters[7].Value = model.StoreHouseDesc;

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
        public bool Update(AsrsStorDBAcc.Model.View_StockOperateModel model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update View_StockOperate set ");
            strSql.Append("StockOperRecdID=@StockOperRecdID,");
            strSql.Append("StoreHouseID=@StoreHouseID,");
            strSql.Append("GoodsSitePos=@GoodsSitePos,");
            strSql.Append("OPerateType=@OPerateType,");
            strSql.Append("OperateDetail=@OperateDetail,");
            strSql.Append("OPerateTime=@OPerateTime,");
            strSql.Append("StoreHouseName=@StoreHouseName,");
            strSql.Append("StoreHouseDesc=@StoreHouseDesc");
            strSql.Append(" where StockOperRecdID=@StockOperRecdID and StoreHouseID=@StoreHouseID and GoodsSitePos=@GoodsSitePos and OPerateType=@OPerateType and OperateDetail=@OperateDetail and OPerateTime=@OPerateTime and StoreHouseName=@StoreHouseName and StoreHouseDesc=@StoreHouseDesc ");
            SqlParameter[] parameters = {
					new SqlParameter("@StockOperRecdID", SqlDbType.BigInt,8),
					new SqlParameter("@StoreHouseID", SqlDbType.BigInt,8),
					new SqlParameter("@GoodsSitePos", SqlDbType.NVarChar,50),
					new SqlParameter("@OPerateType", SqlDbType.NVarChar,50),
					new SqlParameter("@OperateDetail", SqlDbType.NVarChar,200),
					new SqlParameter("@OPerateTime", SqlDbType.DateTime),
					new SqlParameter("@StoreHouseName", SqlDbType.NVarChar,50),
					new SqlParameter("@StoreHouseDesc", SqlDbType.NVarChar,100)};
            parameters[0].Value = model.StockOperRecdID;
            parameters[1].Value = model.StoreHouseID;
            parameters[2].Value = model.GoodsSitePos;
            parameters[3].Value = model.OPerateType;
            parameters[4].Value = model.OperateDetail;
            parameters[5].Value = model.OPerateTime;
            parameters[6].Value = model.StoreHouseName;
            parameters[7].Value = model.StoreHouseDesc;

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
        public bool Delete(long StockOperRecdID, long StoreHouseID, string GoodsSitePos, string OPerateType, string OperateDetail, DateTime OPerateTime, string StoreHouseName, string StoreHouseDesc)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from View_StockOperate ");
            strSql.Append(" where StockOperRecdID=@StockOperRecdID and StoreHouseID=@StoreHouseID and GoodsSitePos=@GoodsSitePos and OPerateType=@OPerateType and OperateDetail=@OperateDetail and OPerateTime=@OPerateTime and StoreHouseName=@StoreHouseName and StoreHouseDesc=@StoreHouseDesc ");
            SqlParameter[] parameters = {
					new SqlParameter("@StockOperRecdID", SqlDbType.BigInt,8),
					new SqlParameter("@StoreHouseID", SqlDbType.BigInt,8),
					new SqlParameter("@GoodsSitePos", SqlDbType.NVarChar,50),
					new SqlParameter("@OPerateType", SqlDbType.NVarChar,50),
					new SqlParameter("@OperateDetail", SqlDbType.NVarChar,200),
					new SqlParameter("@OPerateTime", SqlDbType.DateTime),
					new SqlParameter("@StoreHouseName", SqlDbType.NVarChar,50),
					new SqlParameter("@StoreHouseDesc", SqlDbType.NVarChar,100)			};
            parameters[0].Value = StockOperRecdID;
            parameters[1].Value = StoreHouseID;
            parameters[2].Value = GoodsSitePos;
            parameters[3].Value = OPerateType;
            parameters[4].Value = OperateDetail;
            parameters[5].Value = OPerateTime;
            parameters[6].Value = StoreHouseName;
            parameters[7].Value = StoreHouseDesc;

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
        public AsrsStorDBAcc.Model.View_StockOperateModel GetModel(long StockOperRecdID, long StoreHouseID, string GoodsSitePos, string OPerateType, string OperateDetail, DateTime OPerateTime, string StoreHouseName, string StoreHouseDesc)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 StockOperRecdID,StoreHouseID,GoodsSitePos,OPerateType,OperateDetail,OPerateTime,StoreHouseName,StoreHouseDesc from View_StockOperate ");
            strSql.Append(" where StockOperRecdID=@StockOperRecdID and StoreHouseID=@StoreHouseID and GoodsSitePos=@GoodsSitePos and OPerateType=@OPerateType and OperateDetail=@OperateDetail and OPerateTime=@OPerateTime and StoreHouseName=@StoreHouseName and StoreHouseDesc=@StoreHouseDesc ");
            SqlParameter[] parameters = {
					new SqlParameter("@StockOperRecdID", SqlDbType.BigInt,8),
					new SqlParameter("@StoreHouseID", SqlDbType.BigInt,8),
					new SqlParameter("@GoodsSitePos", SqlDbType.NVarChar,50),
					new SqlParameter("@OPerateType", SqlDbType.NVarChar,50),
					new SqlParameter("@OperateDetail", SqlDbType.NVarChar,200),
					new SqlParameter("@OPerateTime", SqlDbType.DateTime),
					new SqlParameter("@StoreHouseName", SqlDbType.NVarChar,50),
					new SqlParameter("@StoreHouseDesc", SqlDbType.NVarChar,100)			};
            parameters[0].Value = StockOperRecdID;
            parameters[1].Value = StoreHouseID;
            parameters[2].Value = GoodsSitePos;
            parameters[3].Value = OPerateType;
            parameters[4].Value = OperateDetail;
            parameters[5].Value = OPerateTime;
            parameters[6].Value = StoreHouseName;
            parameters[7].Value = StoreHouseDesc;

            AsrsStorDBAcc.Model.View_StockOperateModel model = new AsrsStorDBAcc.Model.View_StockOperateModel();
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
        public AsrsStorDBAcc.Model.View_StockOperateModel DataRowToModel(DataRow row)
        {
            AsrsStorDBAcc.Model.View_StockOperateModel model = new AsrsStorDBAcc.Model.View_StockOperateModel();
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
                if (row["StoreHouseName"] != null)
                {
                    model.StoreHouseName = row["StoreHouseName"].ToString();
                }
                if (row["StoreHouseDesc"] != null)
                {
                    model.StoreHouseDesc = row["StoreHouseDesc"].ToString();
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
            strSql.Append("select StockOperRecdID,StoreHouseID,GoodsSitePos,OPerateType,OperateDetail,OPerateTime,StoreHouseName,StoreHouseDesc ");
            strSql.Append(" FROM View_StockOperate ");
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
            strSql.Append(" StockOperRecdID,StoreHouseID,GoodsSitePos,OPerateType,OperateDetail,OPerateTime,StoreHouseName,StoreHouseDesc ");
            strSql.Append(" FROM View_StockOperate ");
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
            strSql.Append("select count(1) FROM View_StockOperate ");
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
                strSql.Append("order by T.StoreHouseDesc desc");
            }
            strSql.Append(")AS Row, T.*  from View_StockOperate T ");
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
            parameters[0].Value = "View_StockOperate";
            parameters[1].Value = "StoreHouseDesc";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;	
            return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
        }*/

        #endregion  BasicMethod
        #region  ExtensionMethod
        public DataTable GetQueryData(DateTime startTime, DateTime endTime
          , bool gsChcked, string gsValue, bool likeQueryChecked, string likeQueryValue,string batchStr, string operateType, string houseName)
        {
            string sqlStr = "select View_StockOperate.StoreHouseName as 库房,View_StockOperate.GoodsSitePos as 货位位置,View_StockOperate.OPerateType as 操作类型,View_StockOperate.OperateDetail as 操作详细 ,View_StockOperate.OPerateTime as 操作时间 from View_StockOperate";

            if (batchStr != "所有")
            {
                sqlStr += " INNER JOIN dbo.View_Stock ON dbo.View_Stock.StoreHouseID = dbo.View_StockOperate.StoreHouseID  " +
      "and dbo.View_Stock.GoodsSitePos = dbo.View_StockOperate.GoodsSitePos where dbo.View_Stock.MeterialBatch = '" + batchStr + "'";
                sqlStr += " and OPerateTime between '" + startTime.ToString("yyyy-MM-dd 0:00:00") + "' and '" + endTime.ToString("yyyy-MM-dd 23:59:59") + "'";
            }
            else
            {
                sqlStr += " where OPerateTime between '" + startTime.ToString("yyyy-MM-dd 0:00:00") + "' and '" + endTime.ToString("yyyy-MM-dd 23:59:59") + "'";
            }
             
         

            
            if(operateType !="所有")
            {
                sqlStr += " and View_StockOperate.OPerateType = '" + operateType + "'";
            }
            if(gsChcked == true)
            {
                sqlStr += " and View_StockOperate.GoodsSitePos ='" + gsValue + "'";
            }
            if(likeQueryChecked == true)
            {
                sqlStr += " and View_StockOperate.OperateDetail like '%" + likeQueryValue + "%'";
            }
            if (houseName != "所有")
            {
                sqlStr += " and View_StockOperate.StoreHouseName = '" + houseName + "'";
            }

            sqlStr += " order by View_StockOperate.OPerateTime desc";
            DataSet ds = DbHelperSQL.Query(sqlStr);
            if(ds!= null && ds.Tables.Count>0)
            {
                return ds.Tables[0];
            }
            else
            { return null; }
        }
        #endregion  ExtensionMethod
    }
}

