using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using AsrsStorDBAcc.Model;
using System.Collections.Generic;

namespace AsrsStorDBAcc.DAL
{
    /// <summary>
    /// 数据访问类:GoodsSite
    /// </summary>
    public partial class GoodsSiteDAL
    {
        public GoodsSiteDAL()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(long GoodsSiteID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from GoodsSite");
            strSql.Append(" where GoodsSiteID=@GoodsSiteID");
            SqlParameter[] parameters = {
					new SqlParameter("@GoodsSiteID", SqlDbType.BigInt)
			};
            parameters[0].Value = GoodsSiteID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public long Add(AsrsStorDBAcc.Model.GoodsSiteModel model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into GoodsSite(");
            strSql.Append("StoreHouseID,StoreHouseLogicAreaID,GoodsSiteName,GoodsSiteLayer,GoodsSiteColumn,GoodsSiteRow,GoodsSiteTaskStatus,GsEnabled,GoodsSiteType,GoodsSitePos,GoodsSiteStatus,GoodsSiteOperate,Reserve)");
            strSql.Append(" values (");
            strSql.Append("@StoreHouseID,@StoreHouseLogicAreaID,@GoodsSiteName,@GoodsSiteLayer,@GoodsSiteColumn,@GoodsSiteRow,@GoodsSiteTaskStatus,@GsEnabled,@GoodsSiteType,@GoodsSitePos,@GoodsSiteStatus,@GoodsSiteOperate,@Reserve)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@StoreHouseID", SqlDbType.BigInt,8),
					new SqlParameter("@StoreHouseLogicAreaID", SqlDbType.BigInt,8),
					new SqlParameter("@GoodsSiteName", SqlDbType.NVarChar,50),
					new SqlParameter("@GoodsSiteLayer", SqlDbType.Int,4),
					new SqlParameter("@GoodsSiteColumn", SqlDbType.Int,4),
					new SqlParameter("@GoodsSiteRow", SqlDbType.Int,4),
					new SqlParameter("@GoodsSiteTaskStatus", SqlDbType.NVarChar,50),
					new SqlParameter("@GsEnabled", SqlDbType.Bit,1),
					new SqlParameter("@GoodsSiteType", SqlDbType.NVarChar,50),
					new SqlParameter("@GoodsSitePos", SqlDbType.NVarChar,50),
					new SqlParameter("@GoodsSiteStatus", SqlDbType.NVarChar,50),
					new SqlParameter("@GoodsSiteOperate", SqlDbType.NVarChar,50),
					new SqlParameter("@Reserve", SqlDbType.NVarChar,200)};
            parameters[0].Value = model.StoreHouseID;
            parameters[1].Value = model.StoreHouseLogicAreaID;
            parameters[2].Value = model.GoodsSiteName;
            parameters[3].Value = model.GoodsSiteLayer;
            parameters[4].Value = model.GoodsSiteColumn;
            parameters[5].Value = model.GoodsSiteRow;
            parameters[6].Value = model.GoodsSiteTaskStatus;
            parameters[7].Value = model.GsEnabled;
            parameters[8].Value = model.GoodsSiteType;
            parameters[9].Value = model.GoodsSitePos;
            parameters[10].Value = model.GoodsSiteStatus;
            parameters[11].Value = model.GoodsSiteOperate;
            parameters[12].Value = model.Reserve;

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
        public bool Update(AsrsStorDBAcc.Model.GoodsSiteModel model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update GoodsSite set ");
            strSql.Append("StoreHouseID=@StoreHouseID,");
            strSql.Append("StoreHouseLogicAreaID=@StoreHouseLogicAreaID,");
            strSql.Append("GoodsSiteName=@GoodsSiteName,");
            strSql.Append("GoodsSiteLayer=@GoodsSiteLayer,");
            strSql.Append("GoodsSiteColumn=@GoodsSiteColumn,");
            strSql.Append("GoodsSiteRow=@GoodsSiteRow,");
            strSql.Append("GoodsSiteTaskStatus=@GoodsSiteTaskStatus,");
            strSql.Append("GsEnabled=@GsEnabled,");
            strSql.Append("GoodsSiteType=@GoodsSiteType,");
            strSql.Append("GoodsSitePos=@GoodsSitePos,");
            strSql.Append("GoodsSiteStatus=@GoodsSiteStatus,");
            strSql.Append("GoodsSiteOperate=@GoodsSiteOperate,");
            strSql.Append("Reserve=@Reserve");
            strSql.Append(" where GoodsSiteID=@GoodsSiteID");
            SqlParameter[] parameters = {
					new SqlParameter("@StoreHouseID", SqlDbType.BigInt,8),
					new SqlParameter("@StoreHouseLogicAreaID", SqlDbType.BigInt,8),
					new SqlParameter("@GoodsSiteName", SqlDbType.NVarChar,50),
					new SqlParameter("@GoodsSiteLayer", SqlDbType.Int,4),
					new SqlParameter("@GoodsSiteColumn", SqlDbType.Int,4),
					new SqlParameter("@GoodsSiteRow", SqlDbType.Int,4),
					new SqlParameter("@GoodsSiteTaskStatus", SqlDbType.NVarChar,50),
					new SqlParameter("@GsEnabled", SqlDbType.Bit,1),
					new SqlParameter("@GoodsSiteType", SqlDbType.NVarChar,50),
					new SqlParameter("@GoodsSitePos", SqlDbType.NVarChar,50),
					new SqlParameter("@GoodsSiteStatus", SqlDbType.NVarChar,50),
					new SqlParameter("@GoodsSiteOperate", SqlDbType.NVarChar,50),
					new SqlParameter("@Reserve", SqlDbType.NVarChar,200),
					new SqlParameter("@GoodsSiteID", SqlDbType.BigInt,8)};
            parameters[0].Value = model.StoreHouseID;
            parameters[1].Value = model.StoreHouseLogicAreaID;
            parameters[2].Value = model.GoodsSiteName;
            parameters[3].Value = model.GoodsSiteLayer;
            parameters[4].Value = model.GoodsSiteColumn;
            parameters[5].Value = model.GoodsSiteRow;
            parameters[6].Value = model.GoodsSiteTaskStatus;
            parameters[7].Value = model.GsEnabled;
            parameters[8].Value = model.GoodsSiteType;
            parameters[9].Value = model.GoodsSitePos;
            parameters[10].Value = model.GoodsSiteStatus;
            parameters[11].Value = model.GoodsSiteOperate;
            parameters[12].Value = model.Reserve;
            parameters[13].Value = model.GoodsSiteID;

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
        public bool Delete(long GoodsSiteID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from GoodsSite ");
            strSql.Append(" where GoodsSiteID=@GoodsSiteID");
            SqlParameter[] parameters = {
					new SqlParameter("@GoodsSiteID", SqlDbType.BigInt)
			};
            parameters[0].Value = GoodsSiteID;

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
        public bool DeleteList(string GoodsSiteIDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from GoodsSite ");
            strSql.Append(" where GoodsSiteID in (" + GoodsSiteIDlist + ")  ");
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
        public AsrsStorDBAcc.Model.GoodsSiteModel GetModel(long GoodsSiteID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 GoodsSiteID,StoreHouseID,StoreHouseLogicAreaID,GoodsSiteName,GoodsSiteLayer,GoodsSiteColumn,GoodsSiteRow,GoodsSiteTaskStatus,GsEnabled,GoodsSiteType,GoodsSitePos,GoodsSiteStatus,GoodsSiteOperate,Reserve from GoodsSite ");
            strSql.Append(" where GoodsSiteID=@GoodsSiteID");
            SqlParameter[] parameters = {
					new SqlParameter("@GoodsSiteID", SqlDbType.BigInt)
			};
            parameters[0].Value = GoodsSiteID;

            AsrsStorDBAcc.Model.GoodsSiteModel model = new AsrsStorDBAcc.Model.GoodsSiteModel();
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
        public AsrsStorDBAcc.Model.GoodsSiteModel DataRowToModel(DataRow row)
        {
            AsrsStorDBAcc.Model.GoodsSiteModel model = new AsrsStorDBAcc.Model.GoodsSiteModel();
            if (row != null)
            {
                if (row["GoodsSiteID"] != null && row["GoodsSiteID"].ToString() != "")
                {
                    model.GoodsSiteID = long.Parse(row["GoodsSiteID"].ToString());
                }
                if (row["StoreHouseID"] != null && row["StoreHouseID"].ToString() != "")
                {
                    model.StoreHouseID = long.Parse(row["StoreHouseID"].ToString());
                }
                if (row["StoreHouseLogicAreaID"] != null && row["StoreHouseLogicAreaID"].ToString() != "")
                {
                    model.StoreHouseLogicAreaID = long.Parse(row["StoreHouseLogicAreaID"].ToString());
                }
                if (row["GoodsSiteName"] != null)
                {
                    model.GoodsSiteName = row["GoodsSiteName"].ToString();
                }
                if (row["GoodsSiteLayer"] != null && row["GoodsSiteLayer"].ToString() != "")
                {
                    model.GoodsSiteLayer = int.Parse(row["GoodsSiteLayer"].ToString());
                }
                if (row["GoodsSiteColumn"] != null && row["GoodsSiteColumn"].ToString() != "")
                {
                    model.GoodsSiteColumn = int.Parse(row["GoodsSiteColumn"].ToString());
                }
                if (row["GoodsSiteRow"] != null && row["GoodsSiteRow"].ToString() != "")
                {
                    model.GoodsSiteRow = int.Parse(row["GoodsSiteRow"].ToString());
                }
                if (row["GoodsSiteTaskStatus"] != null)
                {
                    model.GoodsSiteTaskStatus = row["GoodsSiteTaskStatus"].ToString();
                }
                if (row["GsEnabled"] != null && row["GsEnabled"].ToString() != "")
                {
                    if ((row["GsEnabled"].ToString() == "1") || (row["GsEnabled"].ToString().ToLower() == "true"))
                    {
                        model.GsEnabled = true;
                    }
                    else
                    {
                        model.GsEnabled = false;
                    }
                }
                if (row["GoodsSiteType"] != null)
                {
                    model.GoodsSiteType = row["GoodsSiteType"].ToString();
                }
                if (row["GoodsSitePos"] != null)
                {
                    model.GoodsSitePos = row["GoodsSitePos"].ToString();
                }
                if (row["GoodsSiteStatus"] != null)
                {
                    model.GoodsSiteStatus = row["GoodsSiteStatus"].ToString();
                }
                if (row["GoodsSiteOperate"] != null)
                {
                    model.GoodsSiteOperate = row["GoodsSiteOperate"].ToString();
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
            strSql.Append("select GoodsSiteID,StoreHouseID,StoreHouseLogicAreaID,GoodsSiteName,GoodsSiteLayer,GoodsSiteColumn,GoodsSiteRow,GoodsSiteTaskStatus,GsEnabled,GoodsSiteType,GoodsSitePos,GoodsSiteStatus,GoodsSiteOperate,Reserve ");
            strSql.Append(" FROM GoodsSite ");
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
            strSql.Append(" GoodsSiteID,StoreHouseID,StoreHouseLogicAreaID,GoodsSiteName,GoodsSiteLayer,GoodsSiteColumn,GoodsSiteRow,GoodsSiteTaskStatus,GsEnabled,GoodsSiteType,GoodsSitePos,GoodsSiteStatus,GoodsSiteOperate,Reserve ");
            strSql.Append(" FROM GoodsSite ");
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
            strSql.Append("select count(1) FROM GoodsSite ");
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
                strSql.Append("order by T.GoodsSiteID desc");
            }
            strSql.Append(")AS Row, T.*  from GoodsSite T ");
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
            parameters[0].Value = "GoodsSite";
            parameters[1].Value = "GoodsSiteID";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;	
            return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
        }*/

        #endregion  BasicMethod
        #region  ExtensionMethod
        public bool DeleteUnnecessaryGs(long houseID, int totalRow, int totalCol, int totalLayer)
        {
            string sqlStr = "delete from GoodsSite where  GoodsSiteRow > " + totalRow
                + " or GoodsSiteColumn >" + totalCol + " or GoodsSiteLayer > " + totalLayer + " and StoreHouseID = "+houseID;


            int rows = DbHelperSQL.ExecuteSql(sqlStr);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool UpdateModelByRCL(string houseName,long storeHouseID, int row, int col, int layer, string cellStatus,string gsStatus)
        {
            string sqlStr = "update GoodsSite set GoodsSiteStatus = '" + cellStatus
              + "', GoodsSiteTaskStatus = '" + gsStatus + "' where StoreHouseID = " + storeHouseID + " and GoodsSiteColumn = " + col + " and GoodsSiteRow ="
           + row + " and GoodsSiteLayer =" + layer ;

            int rows = DbHelperSQL.ExecuteSql(sqlStr);
            if (row > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool UpdateOperateByRCL(string houseName, long storeHouseID, int row, int col, int layer, string operate)
        {
            string sqlStr = "update GoodsSite set GoodsSiteOperate = '" + operate
           + "' where StoreHouseID = " + storeHouseID + " and GoodsSiteColumn = " + col + " and GoodsSiteRow ="
           + row + " and GoodsSiteLayer =" + layer;

            int rows = DbHelperSQL.ExecuteSql(sqlStr);
            if (row > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

       
        public bool DeleteModelByRCL(string houseName,long storeHouseID,int row,int col,int layer)
        {
            string sqlStr = "delete from GoodsSite  where StoreHouseID = " + storeHouseID 
                + " and GoodsSiteColumn = " + col + " and GoodsSiteRow ="
              + row + " and GoodsSiteLayer =" + layer ;

            int rows = DbHelperSQL.ExecuteSql(sqlStr);
            if (row > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        //public int GetGSStatusCount(long storeHouseID, int rowth, string gsStatus)
        //{
        //    string sqlStr = "select count(GoodsSiteID) from GoodsSite where StoreHouseID ="
        //        + storeHouseID + " and GsEnabled =1 and GoodsSiteRow = " + rowth + " and GoodsSiteStatus ='" + gsStatus + "'"
        //        + " and  GoodsSiteTaskStatus !='锁定'";
        //    DataSet ds = DbHelperSQL.Query(sqlStr);
        //    if (ds != null && ds.Tables[0].Rows.Count > 0)
        //    {
        //        return int.Parse(ds.Tables[0].Rows[0][0].ToString());
        //    }
        //    else
        //    {
        //        return 0;
        //    }

        //}
        public int GetNullFrameCount(long storeHouseID, int rowth, string gsStatus)
        {
            string sqlStr = "select count(GoodsSiteID) from GoodsSite where StoreHouseID ="
                + storeHouseID + " and GsEnabled =1 and GoodsSiteRow = " + rowth + " and GoodsSiteStatus ='" + gsStatus + "'"
                + " and  GoodsSiteTaskStatus !='锁定'";
            DataSet ds = DbHelperSQL.Query(sqlStr);
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                return int.Parse(ds.Tables[0].Rows[0][0].ToString());
            }
            else
            {
                return 0;
            }
        }

        public int GetFullGSCount(long storeHouseID, int rowth, string gsStatus)
        {
            string sqlStr = "select count(GoodsSiteID) from GoodsSite where StoreHouseID ="
                + storeHouseID + " and GsEnabled =1 and GoodsSiteRow = " + rowth + " and GoodsSiteStatus ='" + gsStatus + "'"
                + " and  GoodsSiteTaskStatus !='锁定'";//可以为完成或者出库允许
            DataSet ds = DbHelperSQL.Query(sqlStr);
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                return int.Parse(ds.Tables[0].Rows[0][0].ToString());
            }
            else
            {
                return 0;
            }
        }

        public int GetIdleGSCount(long storeHouseID, int rowth, string gsStatus)
        {
            string sqlStr = "select count(GoodsSiteID) from GoodsSite where StoreHouseID ="
                + storeHouseID + " and GsEnabled =1 and GoodsSiteRow = " + rowth + " and GoodsSiteStatus ='" + gsStatus + "'"
                + " and  GoodsSiteTaskStatus ='完成'";
            DataSet ds = DbHelperSQL.Query(sqlStr);
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                return int.Parse(ds.Tables[0].Rows[0][0].ToString());
            }
            else
            {
                return 0;
            }
        }
        public int GetForbitGsCount(long houseID, int rowth)
        {
            string sqlStr = "select count(GoodsSiteID) from GoodsSite where StoreHouseID ="
             + houseID + " and GoodsSiteRow = " + rowth + " and GsEnabled = 0";
            DataSet ds = DbHelperSQL.Query(sqlStr);
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                return int.Parse(ds.Tables[0].Rows[0][0].ToString());
            }
            else
            {
                return 0;
            }
            //string sqlStr = "select (case when GsEnabled =0  then count(GsEnabled) else 0 end) as  禁用";

            //sqlStr += " from GoodsSite where  StoreHouseID =" + houseID + " and GoodsSiteRow = " + rowth + " group by GsEnabled";
            //DataSet ds = DbHelperSQL.Query(sqlStr);
            //if (ds.Tables[0].Rows.Count > 0)
            //{
            //    return ds.Tables[0];
            //}
            //else
            //{
            //    return null;
            //}
        }

        public int GetOutAllowCount(long houseID, int rowth)
        {
            string sqlStr = "select count(GoodsSiteID) from GoodsSite where StoreHouseID ="
                 + houseID + " and GsEnabled =1 and GoodsSiteRow = " + rowth + " and GoodsSiteTaskStatus ='出库允许'";
            DataSet ds = DbHelperSQL.Query(sqlStr);
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                return int.Parse(ds.Tables[0].Rows[0][0].ToString());
            }
            else
            {
                return 0;
            }
        }

        public int GetGsLockCount(long houseID, int rowth)
        {
            string sqlStr = "select count(GoodsSiteStatus) from GoodsSite where StoreHouseID ="
               + houseID + " and GsEnabled =1 and GoodsSiteRow = " + rowth + " and GoodsSiteTaskStatus ='锁定'";
            DataSet ds = DbHelperSQL.Query(sqlStr);
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                return int.Parse(ds.Tables[0].Rows[0][0].ToString());
            }
            else
            {
                return 0;
            }
            //string sqlStr = "select (case when GoodsSiteTaskStatus ='锁定'  then count(GoodsSiteTaskStatus) else 0 end) as  锁定";

            //sqlStr += " from GoodsSite where  StoreHouseID =" + houseID + " and GsEnabled=1 and GoodsSiteRow = " + rowth + " group by GoodsSiteTaskStatus";
            //DataSet ds = DbHelperSQL.Query(sqlStr);
            //if (ds.Tables[0].Rows.Count > 0)
            //{
            //    return ds.Tables[0];
            //}
            //else
            //{
            //    return null;
            //}
        }
        public bool GsReturnFac(string gsStatus,string gsTaskSta,string gsOperate)
        {
            string sqlStr = "update GoodsSite set GoodsSiteStatus = '" + gsStatus
             + "', GoodsSiteTaskStatus = '" + gsTaskSta + "', GoodsSiteOperate ='" + gsOperate + "',  StoreHouseLogicAreaID =null , GsEnabled =1 ";

            int rows = DbHelperSQL.ExecuteSql(sqlStr);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool SetMultiGsSinleColEnbledStatus(long houseID, int rowth, int colth,bool status)
        {
            int intSta = 0;
            if (status == true)
            {
                intSta = 1;
            }
            string sqlStr = "update GoodsSite set GsEnabled = " + intSta
         + " where StoreHouseID = " + houseID + " and GoodsSiteColumn = " + colth + " and GoodsSiteRow ="+ rowth  ;

            int rows = DbHelperSQL.ExecuteSql(sqlStr);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool SetMultiGsSinleLayerEnbledStatus(long houseID, int rowth, int layerth, bool status)
        {
            int intSta = 0;
            if (status == true)
            {
                intSta = 1;
            }
            string sqlStr = "update GoodsSite set GsEnabled = " + intSta
        + " where StoreHouseID = " + houseID + " and GoodsSiteLayer = " + layerth + " and GoodsSiteRow =" + rowth;

            int rows = DbHelperSQL.ExecuteSql(sqlStr);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool SetMultiGsSinleGsEnbledStatus(long houseID,string gsName,bool status)
        {
            int intSta = 0;
            if(status == true)
            {
                intSta = 1;
            }
            string sqlStr = "update GoodsSite set GsEnabled = " + intSta
     + " where StoreHouseID = " + houseID + " and GoodsSitePos ='" + gsName+"'";

            int rows = DbHelperSQL.ExecuteSql(sqlStr);
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

