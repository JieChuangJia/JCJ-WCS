using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic;
 
namespace AsrsStorDBAcc.DAL
{
    /// <summary>
    /// 数据访问类:View_StockGS
    /// </summary>
    public partial class View_StockGSDAL
    {
        public View_StockGSDAL()
        { }
        #region  BasicMethod

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(long GoodsSiteID, long StoreHouseID, string GoodsSiteName, int GoodsSiteColumn, int GoodsSiteLayer, int GoodsSiteRow, string GoodsSiteTaskStatus, bool GsEnabled, string GoodsSiteType, string GoodsSitePos, string GoodsSiteStatus, string GoodsSiteOperate, string StoreHouseName, string StoreHouseDesc, long StockID, string TrayID, bool IsFull, string StoreHouseAreaName, long StoreHouseLogicAreaID, string StoreHouseAreaDesc)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from View_StockGS");
            strSql.Append(" where GoodsSiteID=@GoodsSiteID and StoreHouseID=@StoreHouseID and GoodsSiteName=@GoodsSiteName and GoodsSiteColumn=@GoodsSiteColumn and GoodsSiteLayer=@GoodsSiteLayer and GoodsSiteRow=@GoodsSiteRow and GoodsSiteTaskStatus=@GoodsSiteTaskStatus and GsEnabled=@GsEnabled and GoodsSiteType=@GoodsSiteType and GoodsSitePos=@GoodsSitePos and GoodsSiteStatus=@GoodsSiteStatus and GoodsSiteOperate=@GoodsSiteOperate and StoreHouseName=@StoreHouseName and StoreHouseDesc=@StoreHouseDesc and StockID=@StockID and TrayID=@TrayID and IsFull=@IsFull and StoreHouseAreaName=@StoreHouseAreaName and StoreHouseLogicAreaID=@StoreHouseLogicAreaID and StoreHouseAreaDesc=@StoreHouseAreaDesc ");
            SqlParameter[] parameters = {
					new SqlParameter("@GoodsSiteID", SqlDbType.BigInt,8),
					new SqlParameter("@StoreHouseID", SqlDbType.BigInt,8),
					new SqlParameter("@GoodsSiteName", SqlDbType.NVarChar,50),
					new SqlParameter("@GoodsSiteColumn", SqlDbType.Int,4),
					new SqlParameter("@GoodsSiteLayer", SqlDbType.Int,4),
					new SqlParameter("@GoodsSiteRow", SqlDbType.Int,4),
					new SqlParameter("@GoodsSiteTaskStatus", SqlDbType.NVarChar,50),
					new SqlParameter("@GsEnabled", SqlDbType.Bit,1),
					new SqlParameter("@GoodsSiteType", SqlDbType.NVarChar,50),
					new SqlParameter("@GoodsSitePos", SqlDbType.NVarChar,50),
					new SqlParameter("@GoodsSiteStatus", SqlDbType.NVarChar,50),
					new SqlParameter("@GoodsSiteOperate", SqlDbType.NVarChar,50),
					new SqlParameter("@StoreHouseName", SqlDbType.NVarChar,50),
					new SqlParameter("@StoreHouseDesc", SqlDbType.NVarChar,100),
					new SqlParameter("@StockID", SqlDbType.BigInt,8),
					new SqlParameter("@TrayID", SqlDbType.NVarChar,50),
					new SqlParameter("@IsFull", SqlDbType.Bit,1),
					new SqlParameter("@StoreHouseAreaName", SqlDbType.NVarChar,50),
					new SqlParameter("@StoreHouseLogicAreaID", SqlDbType.BigInt,8),
					new SqlParameter("@StoreHouseAreaDesc", SqlDbType.NVarChar,100)			};
            parameters[0].Value = GoodsSiteID;
            parameters[1].Value = StoreHouseID;
            parameters[2].Value = GoodsSiteName;
            parameters[3].Value = GoodsSiteColumn;
            parameters[4].Value = GoodsSiteLayer;
            parameters[5].Value = GoodsSiteRow;
            parameters[6].Value = GoodsSiteTaskStatus;
            parameters[7].Value = GsEnabled;
            parameters[8].Value = GoodsSiteType;
            parameters[9].Value = GoodsSitePos;
            parameters[10].Value = GoodsSiteStatus;
            parameters[11].Value = GoodsSiteOperate;
            parameters[12].Value = StoreHouseName;
            parameters[13].Value = StoreHouseDesc;
            parameters[14].Value = StockID;
            parameters[15].Value = TrayID;
            parameters[16].Value = IsFull;
            parameters[17].Value = StoreHouseAreaName;
            parameters[18].Value = StoreHouseLogicAreaID;
            parameters[19].Value = StoreHouseAreaDesc;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(AsrsStorDBAcc.Model.View_StockGSModel model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into View_StockGS(");
            strSql.Append("GoodsSiteID,StoreHouseID,GoodsSiteName,GoodsSiteColumn,GoodsSiteLayer,GoodsSiteRow,GoodsSiteTaskStatus,GsEnabled,GoodsSiteType,GoodsSitePos,GoodsSiteStatus,GoodsSiteOperate,StoreHouseName,StoreHouseDesc,StockID,TrayID,IsFull,StoreHouseAreaName,StoreHouseLogicAreaID,StoreHouseAreaDesc)");
            strSql.Append(" values (");
            strSql.Append("@GoodsSiteID,@StoreHouseID,@GoodsSiteName,@GoodsSiteColumn,@GoodsSiteLayer,@GoodsSiteRow,@GoodsSiteTaskStatus,@GsEnabled,@GoodsSiteType,@GoodsSitePos,@GoodsSiteStatus,@GoodsSiteOperate,@StoreHouseName,@StoreHouseDesc,@StockID,@TrayID,@IsFull,@StoreHouseAreaName,@StoreHouseLogicAreaID,@StoreHouseAreaDesc)");
            SqlParameter[] parameters = {
					new SqlParameter("@GoodsSiteID", SqlDbType.BigInt,8),
					new SqlParameter("@StoreHouseID", SqlDbType.BigInt,8),
					new SqlParameter("@GoodsSiteName", SqlDbType.NVarChar,50),
					new SqlParameter("@GoodsSiteColumn", SqlDbType.Int,4),
					new SqlParameter("@GoodsSiteLayer", SqlDbType.Int,4),
					new SqlParameter("@GoodsSiteRow", SqlDbType.Int,4),
					new SqlParameter("@GoodsSiteTaskStatus", SqlDbType.NVarChar,50),
					new SqlParameter("@GsEnabled", SqlDbType.Bit,1),
					new SqlParameter("@GoodsSiteType", SqlDbType.NVarChar,50),
					new SqlParameter("@GoodsSitePos", SqlDbType.NVarChar,50),
					new SqlParameter("@GoodsSiteStatus", SqlDbType.NVarChar,50),
					new SqlParameter("@GoodsSiteOperate", SqlDbType.NVarChar,50),
					new SqlParameter("@StoreHouseName", SqlDbType.NVarChar,50),
					new SqlParameter("@StoreHouseDesc", SqlDbType.NVarChar,100),
					new SqlParameter("@StockID", SqlDbType.BigInt,8),
					new SqlParameter("@TrayID", SqlDbType.NVarChar,50),
					new SqlParameter("@IsFull", SqlDbType.Bit,1),
					new SqlParameter("@StoreHouseAreaName", SqlDbType.NVarChar,50),
					new SqlParameter("@StoreHouseLogicAreaID", SqlDbType.BigInt,8),
					new SqlParameter("@StoreHouseAreaDesc", SqlDbType.NVarChar,100)};
            parameters[0].Value = model.GoodsSiteID;
            parameters[1].Value = model.StoreHouseID;
            parameters[2].Value = model.GoodsSiteName;
            parameters[3].Value = model.GoodsSiteColumn;
            parameters[4].Value = model.GoodsSiteLayer;
            parameters[5].Value = model.GoodsSiteRow;
            parameters[6].Value = model.GoodsSiteTaskStatus;
            parameters[7].Value = model.GsEnabled;
            parameters[8].Value = model.GoodsSiteType;
            parameters[9].Value = model.GoodsSitePos;
            parameters[10].Value = model.GoodsSiteStatus;
            parameters[11].Value = model.GoodsSiteOperate;
            parameters[12].Value = model.StoreHouseName;
            parameters[13].Value = model.StoreHouseDesc;
            parameters[14].Value = model.StockID;
            parameters[15].Value = model.TrayID;
            parameters[16].Value = model.IsFull;
            parameters[17].Value = model.StoreHouseAreaName;
            parameters[18].Value = model.StoreHouseLogicAreaID;
            parameters[19].Value = model.StoreHouseAreaDesc;

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
        public bool Update(AsrsStorDBAcc.Model.View_StockGSModel model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update View_StockGS set ");
            strSql.Append("GoodsSiteID=@GoodsSiteID,");
            strSql.Append("StoreHouseID=@StoreHouseID,");
            strSql.Append("GoodsSiteName=@GoodsSiteName,");
            strSql.Append("GoodsSiteColumn=@GoodsSiteColumn,");
            strSql.Append("GoodsSiteLayer=@GoodsSiteLayer,");
            strSql.Append("GoodsSiteRow=@GoodsSiteRow,");
            strSql.Append("GoodsSiteTaskStatus=@GoodsSiteTaskStatus,");
            strSql.Append("GsEnabled=@GsEnabled,");
            strSql.Append("GoodsSiteType=@GoodsSiteType,");
            strSql.Append("GoodsSitePos=@GoodsSitePos,");
            strSql.Append("GoodsSiteStatus=@GoodsSiteStatus,");
            strSql.Append("GoodsSiteOperate=@GoodsSiteOperate,");
            strSql.Append("StoreHouseName=@StoreHouseName,");
            strSql.Append("StoreHouseDesc=@StoreHouseDesc,");
            strSql.Append("StockID=@StockID,");
            strSql.Append("TrayID=@TrayID,");
            strSql.Append("IsFull=@IsFull,");
            strSql.Append("StoreHouseAreaName=@StoreHouseAreaName,");
            strSql.Append("StoreHouseLogicAreaID=@StoreHouseLogicAreaID,");
            strSql.Append("StoreHouseAreaDesc=@StoreHouseAreaDesc");
            strSql.Append(" where GoodsSiteID=@GoodsSiteID and StoreHouseID=@StoreHouseID and GoodsSiteName=@GoodsSiteName and GoodsSiteColumn=@GoodsSiteColumn and GoodsSiteLayer=@GoodsSiteLayer and GoodsSiteRow=@GoodsSiteRow and GoodsSiteTaskStatus=@GoodsSiteTaskStatus and GsEnabled=@GsEnabled and GoodsSiteType=@GoodsSiteType and GoodsSitePos=@GoodsSitePos and GoodsSiteStatus=@GoodsSiteStatus and GoodsSiteOperate=@GoodsSiteOperate and StoreHouseName=@StoreHouseName and StoreHouseDesc=@StoreHouseDesc and StockID=@StockID and TrayID=@TrayID and IsFull=@IsFull and StoreHouseAreaName=@StoreHouseAreaName and StoreHouseLogicAreaID=@StoreHouseLogicAreaID and StoreHouseAreaDesc=@StoreHouseAreaDesc ");
            SqlParameter[] parameters = {
					new SqlParameter("@GoodsSiteID", SqlDbType.BigInt,8),
					new SqlParameter("@StoreHouseID", SqlDbType.BigInt,8),
					new SqlParameter("@GoodsSiteName", SqlDbType.NVarChar,50),
					new SqlParameter("@GoodsSiteColumn", SqlDbType.Int,4),
					new SqlParameter("@GoodsSiteLayer", SqlDbType.Int,4),
					new SqlParameter("@GoodsSiteRow", SqlDbType.Int,4),
					new SqlParameter("@GoodsSiteTaskStatus", SqlDbType.NVarChar,50),
					new SqlParameter("@GsEnabled", SqlDbType.Bit,1),
					new SqlParameter("@GoodsSiteType", SqlDbType.NVarChar,50),
					new SqlParameter("@GoodsSitePos", SqlDbType.NVarChar,50),
					new SqlParameter("@GoodsSiteStatus", SqlDbType.NVarChar,50),
					new SqlParameter("@GoodsSiteOperate", SqlDbType.NVarChar,50),
					new SqlParameter("@StoreHouseName", SqlDbType.NVarChar,50),
					new SqlParameter("@StoreHouseDesc", SqlDbType.NVarChar,100),
					new SqlParameter("@StockID", SqlDbType.BigInt,8),
					new SqlParameter("@TrayID", SqlDbType.NVarChar,50),
					new SqlParameter("@IsFull", SqlDbType.Bit,1),
					new SqlParameter("@StoreHouseAreaName", SqlDbType.NVarChar,50),
					new SqlParameter("@StoreHouseLogicAreaID", SqlDbType.BigInt,8),
					new SqlParameter("@StoreHouseAreaDesc", SqlDbType.NVarChar,100)};
            parameters[0].Value = model.GoodsSiteID;
            parameters[1].Value = model.StoreHouseID;
            parameters[2].Value = model.GoodsSiteName;
            parameters[3].Value = model.GoodsSiteColumn;
            parameters[4].Value = model.GoodsSiteLayer;
            parameters[5].Value = model.GoodsSiteRow;
            parameters[6].Value = model.GoodsSiteTaskStatus;
            parameters[7].Value = model.GsEnabled;
            parameters[8].Value = model.GoodsSiteType;
            parameters[9].Value = model.GoodsSitePos;
            parameters[10].Value = model.GoodsSiteStatus;
            parameters[11].Value = model.GoodsSiteOperate;
            parameters[12].Value = model.StoreHouseName;
            parameters[13].Value = model.StoreHouseDesc;
            parameters[14].Value = model.StockID;
            parameters[15].Value = model.TrayID;
            parameters[16].Value = model.IsFull;
            parameters[17].Value = model.StoreHouseAreaName;
            parameters[18].Value = model.StoreHouseLogicAreaID;
            parameters[19].Value = model.StoreHouseAreaDesc;

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
        public bool Delete(long GoodsSiteID, long StoreHouseID, string GoodsSiteName, int GoodsSiteColumn, int GoodsSiteLayer, int GoodsSiteRow, string GoodsSiteTaskStatus, bool GsEnabled, string GoodsSiteType, string GoodsSitePos, string GoodsSiteStatus, string GoodsSiteOperate, string StoreHouseName, string StoreHouseDesc, long StockID, string TrayID, bool IsFull, string StoreHouseAreaName, long StoreHouseLogicAreaID, string StoreHouseAreaDesc)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from View_StockGS ");
            strSql.Append(" where GoodsSiteID=@GoodsSiteID and StoreHouseID=@StoreHouseID and GoodsSiteName=@GoodsSiteName and GoodsSiteColumn=@GoodsSiteColumn and GoodsSiteLayer=@GoodsSiteLayer and GoodsSiteRow=@GoodsSiteRow and GoodsSiteTaskStatus=@GoodsSiteTaskStatus and GsEnabled=@GsEnabled and GoodsSiteType=@GoodsSiteType and GoodsSitePos=@GoodsSitePos and GoodsSiteStatus=@GoodsSiteStatus and GoodsSiteOperate=@GoodsSiteOperate and StoreHouseName=@StoreHouseName and StoreHouseDesc=@StoreHouseDesc and StockID=@StockID and TrayID=@TrayID and IsFull=@IsFull and StoreHouseAreaName=@StoreHouseAreaName and StoreHouseLogicAreaID=@StoreHouseLogicAreaID and StoreHouseAreaDesc=@StoreHouseAreaDesc ");
            SqlParameter[] parameters = {
					new SqlParameter("@GoodsSiteID", SqlDbType.BigInt,8),
					new SqlParameter("@StoreHouseID", SqlDbType.BigInt,8),
					new SqlParameter("@GoodsSiteName", SqlDbType.NVarChar,50),
					new SqlParameter("@GoodsSiteColumn", SqlDbType.Int,4),
					new SqlParameter("@GoodsSiteLayer", SqlDbType.Int,4),
					new SqlParameter("@GoodsSiteRow", SqlDbType.Int,4),
					new SqlParameter("@GoodsSiteTaskStatus", SqlDbType.NVarChar,50),
					new SqlParameter("@GsEnabled", SqlDbType.Bit,1),
					new SqlParameter("@GoodsSiteType", SqlDbType.NVarChar,50),
					new SqlParameter("@GoodsSitePos", SqlDbType.NVarChar,50),
					new SqlParameter("@GoodsSiteStatus", SqlDbType.NVarChar,50),
					new SqlParameter("@GoodsSiteOperate", SqlDbType.NVarChar,50),
					new SqlParameter("@StoreHouseName", SqlDbType.NVarChar,50),
					new SqlParameter("@StoreHouseDesc", SqlDbType.NVarChar,100),
					new SqlParameter("@StockID", SqlDbType.BigInt,8),
					new SqlParameter("@TrayID", SqlDbType.NVarChar,50),
					new SqlParameter("@IsFull", SqlDbType.Bit,1),
					new SqlParameter("@StoreHouseAreaName", SqlDbType.NVarChar,50),
					new SqlParameter("@StoreHouseLogicAreaID", SqlDbType.BigInt,8),
					new SqlParameter("@StoreHouseAreaDesc", SqlDbType.NVarChar,100)			};
            parameters[0].Value = GoodsSiteID;
            parameters[1].Value = StoreHouseID;
            parameters[2].Value = GoodsSiteName;
            parameters[3].Value = GoodsSiteColumn;
            parameters[4].Value = GoodsSiteLayer;
            parameters[5].Value = GoodsSiteRow;
            parameters[6].Value = GoodsSiteTaskStatus;
            parameters[7].Value = GsEnabled;
            parameters[8].Value = GoodsSiteType;
            parameters[9].Value = GoodsSitePos;
            parameters[10].Value = GoodsSiteStatus;
            parameters[11].Value = GoodsSiteOperate;
            parameters[12].Value = StoreHouseName;
            parameters[13].Value = StoreHouseDesc;
            parameters[14].Value = StockID;
            parameters[15].Value = TrayID;
            parameters[16].Value = IsFull;
            parameters[17].Value = StoreHouseAreaName;
            parameters[18].Value = StoreHouseLogicAreaID;
            parameters[19].Value = StoreHouseAreaDesc;

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
        public AsrsStorDBAcc.Model.View_StockGSModel GetModel(long GoodsSiteID, long StoreHouseID, string GoodsSiteName, int GoodsSiteColumn, int GoodsSiteLayer, int GoodsSiteRow, string GoodsSiteTaskStatus, bool GsEnabled, string GoodsSiteType, string GoodsSitePos, string GoodsSiteStatus, string GoodsSiteOperate, string StoreHouseName, string StoreHouseDesc, long StockID, string TrayID, bool IsFull, string StoreHouseAreaName, long StoreHouseLogicAreaID, string StoreHouseAreaDesc)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 GoodsSiteID,StoreHouseID,GoodsSiteName,GoodsSiteColumn,GoodsSiteLayer,GoodsSiteRow,GoodsSiteTaskStatus,GsEnabled,GoodsSiteType,GoodsSitePos,GoodsSiteStatus,GoodsSiteOperate,StoreHouseName,StoreHouseDesc,StockID,TrayID,IsFull,StoreHouseAreaName,StoreHouseLogicAreaID,StoreHouseAreaDesc from View_StockGS ");
            strSql.Append(" where GoodsSiteID=@GoodsSiteID and StoreHouseID=@StoreHouseID and GoodsSiteName=@GoodsSiteName and GoodsSiteColumn=@GoodsSiteColumn and GoodsSiteLayer=@GoodsSiteLayer and GoodsSiteRow=@GoodsSiteRow and GoodsSiteTaskStatus=@GoodsSiteTaskStatus and GsEnabled=@GsEnabled and GoodsSiteType=@GoodsSiteType and GoodsSitePos=@GoodsSitePos and GoodsSiteStatus=@GoodsSiteStatus and GoodsSiteOperate=@GoodsSiteOperate and StoreHouseName=@StoreHouseName and StoreHouseDesc=@StoreHouseDesc and StockID=@StockID and TrayID=@TrayID and IsFull=@IsFull and StoreHouseAreaName=@StoreHouseAreaName and StoreHouseLogicAreaID=@StoreHouseLogicAreaID and StoreHouseAreaDesc=@StoreHouseAreaDesc ");
            SqlParameter[] parameters = {
					new SqlParameter("@GoodsSiteID", SqlDbType.BigInt,8),
					new SqlParameter("@StoreHouseID", SqlDbType.BigInt,8),
					new SqlParameter("@GoodsSiteName", SqlDbType.NVarChar,50),
					new SqlParameter("@GoodsSiteColumn", SqlDbType.Int,4),
					new SqlParameter("@GoodsSiteLayer", SqlDbType.Int,4),
					new SqlParameter("@GoodsSiteRow", SqlDbType.Int,4),
					new SqlParameter("@GoodsSiteTaskStatus", SqlDbType.NVarChar,50),
					new SqlParameter("@GsEnabled", SqlDbType.Bit,1),
					new SqlParameter("@GoodsSiteType", SqlDbType.NVarChar,50),
					new SqlParameter("@GoodsSitePos", SqlDbType.NVarChar,50),
					new SqlParameter("@GoodsSiteStatus", SqlDbType.NVarChar,50),
					new SqlParameter("@GoodsSiteOperate", SqlDbType.NVarChar,50),
					new SqlParameter("@StoreHouseName", SqlDbType.NVarChar,50),
					new SqlParameter("@StoreHouseDesc", SqlDbType.NVarChar,100),
					new SqlParameter("@StockID", SqlDbType.BigInt,8),
					new SqlParameter("@TrayID", SqlDbType.NVarChar,50),
					new SqlParameter("@IsFull", SqlDbType.Bit,1),
					new SqlParameter("@StoreHouseAreaName", SqlDbType.NVarChar,50),
					new SqlParameter("@StoreHouseLogicAreaID", SqlDbType.BigInt,8),
					new SqlParameter("@StoreHouseAreaDesc", SqlDbType.NVarChar,100)			};
            parameters[0].Value = GoodsSiteID;
            parameters[1].Value = StoreHouseID;
            parameters[2].Value = GoodsSiteName;
            parameters[3].Value = GoodsSiteColumn;
            parameters[4].Value = GoodsSiteLayer;
            parameters[5].Value = GoodsSiteRow;
            parameters[6].Value = GoodsSiteTaskStatus;
            parameters[7].Value = GsEnabled;
            parameters[8].Value = GoodsSiteType;
            parameters[9].Value = GoodsSitePos;
            parameters[10].Value = GoodsSiteStatus;
            parameters[11].Value = GoodsSiteOperate;
            parameters[12].Value = StoreHouseName;
            parameters[13].Value = StoreHouseDesc;
            parameters[14].Value = StockID;
            parameters[15].Value = TrayID;
            parameters[16].Value = IsFull;
            parameters[17].Value = StoreHouseAreaName;
            parameters[18].Value = StoreHouseLogicAreaID;
            parameters[19].Value = StoreHouseAreaDesc;

            AsrsStorDBAcc.Model.View_StockGSModel model = new AsrsStorDBAcc.Model.View_StockGSModel();
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
        public AsrsStorDBAcc.Model.View_StockGSModel DataRowToModel(DataRow row)
        {
            AsrsStorDBAcc.Model.View_StockGSModel model = new AsrsStorDBAcc.Model.View_StockGSModel();
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
                if (row["GoodsSiteName"] != null)
                {
                    model.GoodsSiteName = row["GoodsSiteName"].ToString();
                }
                if (row["GoodsSiteColumn"] != null && row["GoodsSiteColumn"].ToString() != "")
                {
                    model.GoodsSiteColumn = int.Parse(row["GoodsSiteColumn"].ToString());
                }
                if (row["GoodsSiteLayer"] != null && row["GoodsSiteLayer"].ToString() != "")
                {
                    model.GoodsSiteLayer = int.Parse(row["GoodsSiteLayer"].ToString());
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
                if (row["StoreHouseName"] != null)
                {
                    model.StoreHouseName = row["StoreHouseName"].ToString();
                }
                if (row["StoreHouseDesc"] != null)
                {
                    model.StoreHouseDesc = row["StoreHouseDesc"].ToString();
                }
                if (row["StockID"] != null && row["StockID"].ToString() != "")
                {
                    model.StockID = long.Parse(row["StockID"].ToString());
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
                if (row["StoreHouseAreaName"] != null)
                {
                    model.StoreHouseAreaName = row["StoreHouseAreaName"].ToString();
                }
                if (row["StoreHouseLogicAreaID"] != null && row["StoreHouseLogicAreaID"].ToString() != "")
                {
                    model.StoreHouseLogicAreaID = long.Parse(row["StoreHouseLogicAreaID"].ToString());
                }
                if (row["StoreHouseAreaDesc"] != null)
                {
                    model.StoreHouseAreaDesc = row["StoreHouseAreaDesc"].ToString();
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
            strSql.Append("select GoodsSiteID,StoreHouseID,GoodsSiteName,GoodsSiteColumn,GoodsSiteLayer,GoodsSiteRow,GoodsSiteTaskStatus,GsEnabled,GoodsSiteType,GoodsSitePos,GoodsSiteStatus,GoodsSiteOperate,StoreHouseName,StoreHouseDesc,StockID,TrayID,IsFull,StoreHouseAreaName,StoreHouseLogicAreaID,StoreHouseAreaDesc ");
            strSql.Append(" FROM View_StockGS ");
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
            strSql.Append(" GoodsSiteID,StoreHouseID,GoodsSiteName,GoodsSiteColumn,GoodsSiteLayer,GoodsSiteRow,GoodsSiteTaskStatus,GsEnabled,GoodsSiteType,GoodsSitePos,GoodsSiteStatus,GoodsSiteOperate,StoreHouseName,StoreHouseDesc,StockID,TrayID,IsFull,StoreHouseAreaName,StoreHouseLogicAreaID,StoreHouseAreaDesc ");
            strSql.Append(" FROM View_StockGS ");
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
            strSql.Append("select count(1) FROM View_StockGS ");
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
                strSql.Append("order by T.StoreHouseAreaDesc desc");
            }
            strSql.Append(")AS Row, T.*  from View_StockGS T ");
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
            parameters[0].Value = "View_StockGS";
            parameters[1].Value = "StoreHouseAreaDesc";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;	
            return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
        }*/

        #endregion  BasicMethod
        #region  ExtensionMethod

        public DataTable GetListByCondition(string houseName, string rowth,
            string colth, string layerth, string gsStatus, string gsTaskSta, string proBatch)
        {
           string sqlStr = "select *  from GoodsSite ,Stock,StockList,StoreHouse where GoodsSite.GoodsSiteID =Stock.GoodsSiteID and Stock.StockID = StockList.StockID and StoreHouse.StoreHouseID = GoodsSite.StoreHouseID ";

            if (proBatch != "所有")
            {
              sqlStr += " and  StockList.MeterialBatch= '" + proBatch + "'";
            }
          
            if (houseName != "所有")
            {
                sqlStr += " and StoreHouse.StoreHouseName = '" + houseName + "'";
            }
            if (rowth != "所有")
            {
                sqlStr += " and GoodsSite.GoodsSiteRow = " + rowth;
            }
            if (colth != "所有")
            {
                sqlStr += " and GoodsSite.GoodsSiteColumn = " + colth;
            }
            if (layerth != "所有")
            {
                sqlStr += " and GoodsSite.GoodsSiteLayer = " + layerth;
            }
            if (gsStatus != "所有")
            {
                sqlStr += " and GoodsSite.GoodsSiteStatus = '" + gsStatus + "'";
            }
            if (gsTaskSta != "所有")
            {
                sqlStr += " and GoodsSite.GoodsSiteTaskStatus = '" + gsTaskSta + "'";
            }
           
            DataSet ds = DbHelperSQL.Query(sqlStr);
            if (ds != null && ds.Tables.Count > 0)
            {
                return ds.Tables[0];
            }
            else
            {
                return null;
            }

        }
     
        #endregion  ExtensionMethod
    }
}

