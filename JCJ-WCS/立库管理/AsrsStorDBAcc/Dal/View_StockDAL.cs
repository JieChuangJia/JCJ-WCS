using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic;
 
 
namespace AsrsStorDBAcc.DAL
{
    /// <summary>
    /// 数据访问类:View_Stock
    /// </summary>
    public partial class View_StockDAL
    {
        public View_StockDAL()
        { }
        #region  BasicMethod

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(long StoreHouseID, long GoodsSiteID, string GoodsSiteName, int GoodsSiteLayer, int GoodsSiteColumn, string StoreHouseName, string StoreHouseDesc, int GoodsSiteRow, string GoodsSiteTaskStatus, string GoodsSiteType, string GoodsSitePos, string GoodsSiteStatus, string GoodsSiteOperate, long StockID, string TrayID, bool IsFull, DateTime InHouseTime, string MeterialboxCode, string MeterialBatch, string MeterialStatus, long StockListID, bool GsEnabled, long StoreHouseLogicAreaID, string StoreHouseAreaName, string StoreHouseAreaDesc, string GoodsSite_Reserve)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from View_Stock");
            strSql.Append(" where StoreHouseID=@StoreHouseID and GoodsSiteID=@GoodsSiteID and GoodsSiteName=@GoodsSiteName and GoodsSiteLayer=@GoodsSiteLayer and GoodsSiteColumn=@GoodsSiteColumn and StoreHouseName=@StoreHouseName and StoreHouseDesc=@StoreHouseDesc and GoodsSiteRow=@GoodsSiteRow and GoodsSiteTaskStatus=@GoodsSiteTaskStatus and GoodsSiteType=@GoodsSiteType and GoodsSitePos=@GoodsSitePos and GoodsSiteStatus=@GoodsSiteStatus and GoodsSiteOperate=@GoodsSiteOperate and StockID=@StockID and TrayID=@TrayID and IsFull=@IsFull and InHouseTime=@InHouseTime and MeterialboxCode=@MeterialboxCode and MeterialBatch=@MeterialBatch and MeterialStatus=@MeterialStatus and StockListID=@StockListID and GsEnabled=@GsEnabled and StoreHouseLogicAreaID=@StoreHouseLogicAreaID and StoreHouseAreaName=@StoreHouseAreaName and StoreHouseAreaDesc=@StoreHouseAreaDesc and GoodsSite_Reserve=@GoodsSite_Reserve ");
            SqlParameter[] parameters = {
					new SqlParameter("@StoreHouseID", SqlDbType.BigInt,8),
					new SqlParameter("@GoodsSiteID", SqlDbType.BigInt,8),
					new SqlParameter("@GoodsSiteName", SqlDbType.NVarChar,50),
					new SqlParameter("@GoodsSiteLayer", SqlDbType.Int,4),
					new SqlParameter("@GoodsSiteColumn", SqlDbType.Int,4),
					new SqlParameter("@StoreHouseName", SqlDbType.NVarChar,50),
					new SqlParameter("@StoreHouseDesc", SqlDbType.NVarChar,100),
					new SqlParameter("@GoodsSiteRow", SqlDbType.Int,4),
					new SqlParameter("@GoodsSiteTaskStatus", SqlDbType.NVarChar,50),
					new SqlParameter("@GoodsSiteType", SqlDbType.NVarChar,50),
					new SqlParameter("@GoodsSitePos", SqlDbType.NVarChar,50),
					new SqlParameter("@GoodsSiteStatus", SqlDbType.NVarChar,50),
					new SqlParameter("@GoodsSiteOperate", SqlDbType.NVarChar,50),
					new SqlParameter("@StockID", SqlDbType.BigInt,8),
					new SqlParameter("@TrayID", SqlDbType.NVarChar,50),
					new SqlParameter("@IsFull", SqlDbType.Bit,1),
					new SqlParameter("@InHouseTime", SqlDbType.DateTime),
					new SqlParameter("@MeterialboxCode", SqlDbType.NVarChar,50),
					new SqlParameter("@MeterialBatch", SqlDbType.NVarChar,50),
					new SqlParameter("@MeterialStatus", SqlDbType.NVarChar,50),
					new SqlParameter("@StockListID", SqlDbType.BigInt,8),
					new SqlParameter("@GsEnabled", SqlDbType.Bit,1),
					new SqlParameter("@StoreHouseLogicAreaID", SqlDbType.BigInt,8),
					new SqlParameter("@StoreHouseAreaName", SqlDbType.NVarChar,50),
					new SqlParameter("@StoreHouseAreaDesc", SqlDbType.NVarChar,100),
					new SqlParameter("@GoodsSite_Reserve", SqlDbType.NVarChar,200)			};
            parameters[0].Value = StoreHouseID;
            parameters[1].Value = GoodsSiteID;
            parameters[2].Value = GoodsSiteName;
            parameters[3].Value = GoodsSiteLayer;
            parameters[4].Value = GoodsSiteColumn;
            parameters[5].Value = StoreHouseName;
            parameters[6].Value = StoreHouseDesc;
            parameters[7].Value = GoodsSiteRow;
            parameters[8].Value = GoodsSiteTaskStatus;
            parameters[9].Value = GoodsSiteType;
            parameters[10].Value = GoodsSitePos;
            parameters[11].Value = GoodsSiteStatus;
            parameters[12].Value = GoodsSiteOperate;
            parameters[13].Value = StockID;
            parameters[14].Value = TrayID;
            parameters[15].Value = IsFull;
            parameters[16].Value = InHouseTime;
            parameters[17].Value = MeterialboxCode;
            parameters[18].Value = MeterialBatch;
            parameters[19].Value = MeterialStatus;
            parameters[20].Value = StockListID;
            parameters[21].Value = GsEnabled;
            parameters[22].Value = StoreHouseLogicAreaID;
            parameters[23].Value = StoreHouseAreaName;
            parameters[24].Value = StoreHouseAreaDesc;
            parameters[25].Value = GoodsSite_Reserve;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(AsrsStorDBAcc.Model.View_StockModel model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into View_Stock(");
            strSql.Append("StoreHouseID,GoodsSiteID,GoodsSiteName,GoodsSiteLayer,GoodsSiteColumn,StoreHouseName,StoreHouseDesc,GoodsSiteRow,GoodsSiteTaskStatus,GoodsSiteType,GoodsSitePos,GoodsSiteStatus,GoodsSiteOperate,StockID,TrayID,IsFull,InHouseTime,MeterialboxCode,MeterialBatch,MeterialStatus,StockListID,GsEnabled,StoreHouseLogicAreaID,StoreHouseAreaName,StoreHouseAreaDesc,GoodsSite_Reserve)");
            strSql.Append(" values (");
            strSql.Append("@StoreHouseID,@GoodsSiteID,@GoodsSiteName,@GoodsSiteLayer,@GoodsSiteColumn,@StoreHouseName,@StoreHouseDesc,@GoodsSiteRow,@GoodsSiteTaskStatus,@GoodsSiteType,@GoodsSitePos,@GoodsSiteStatus,@GoodsSiteOperate,@StockID,@TrayID,@IsFull,@InHouseTime,@MeterialboxCode,@MeterialBatch,@MeterialStatus,@StockListID,@GsEnabled,@StoreHouseLogicAreaID,@StoreHouseAreaName,@StoreHouseAreaDesc,@GoodsSite_Reserve)");
            SqlParameter[] parameters = {
					new SqlParameter("@StoreHouseID", SqlDbType.BigInt,8),
					new SqlParameter("@GoodsSiteID", SqlDbType.BigInt,8),
					new SqlParameter("@GoodsSiteName", SqlDbType.NVarChar,50),
					new SqlParameter("@GoodsSiteLayer", SqlDbType.Int,4),
					new SqlParameter("@GoodsSiteColumn", SqlDbType.Int,4),
					new SqlParameter("@StoreHouseName", SqlDbType.NVarChar,50),
					new SqlParameter("@StoreHouseDesc", SqlDbType.NVarChar,100),
					new SqlParameter("@GoodsSiteRow", SqlDbType.Int,4),
					new SqlParameter("@GoodsSiteTaskStatus", SqlDbType.NVarChar,50),
					new SqlParameter("@GoodsSiteType", SqlDbType.NVarChar,50),
					new SqlParameter("@GoodsSitePos", SqlDbType.NVarChar,50),
					new SqlParameter("@GoodsSiteStatus", SqlDbType.NVarChar,50),
					new SqlParameter("@GoodsSiteOperate", SqlDbType.NVarChar,50),
					new SqlParameter("@StockID", SqlDbType.BigInt,8),
					new SqlParameter("@TrayID", SqlDbType.NVarChar,50),
					new SqlParameter("@IsFull", SqlDbType.Bit,1),
					new SqlParameter("@InHouseTime", SqlDbType.DateTime),
					new SqlParameter("@MeterialboxCode", SqlDbType.NVarChar,50),
					new SqlParameter("@MeterialBatch", SqlDbType.NVarChar,50),
					new SqlParameter("@MeterialStatus", SqlDbType.NVarChar,50),
					new SqlParameter("@StockListID", SqlDbType.BigInt,8),
					new SqlParameter("@GsEnabled", SqlDbType.Bit,1),
					new SqlParameter("@StoreHouseLogicAreaID", SqlDbType.BigInt,8),
					new SqlParameter("@StoreHouseAreaName", SqlDbType.NVarChar,50),
					new SqlParameter("@StoreHouseAreaDesc", SqlDbType.NVarChar,100),
					new SqlParameter("@GoodsSite_Reserve", SqlDbType.NVarChar,200)};
            parameters[0].Value = model.StoreHouseID;
            parameters[1].Value = model.GoodsSiteID;
            parameters[2].Value = model.GoodsSiteName;
            parameters[3].Value = model.GoodsSiteLayer;
            parameters[4].Value = model.GoodsSiteColumn;
            parameters[5].Value = model.StoreHouseName;
            parameters[6].Value = model.StoreHouseDesc;
            parameters[7].Value = model.GoodsSiteRow;
            parameters[8].Value = model.GoodsSiteTaskStatus;
            parameters[9].Value = model.GoodsSiteType;
            parameters[10].Value = model.GoodsSitePos;
            parameters[11].Value = model.GoodsSiteStatus;
            parameters[12].Value = model.GoodsSiteOperate;
            parameters[13].Value = model.StockID;
            parameters[14].Value = model.TrayID;
            parameters[15].Value = model.IsFull;
            parameters[16].Value = model.InHouseTime;
            parameters[17].Value = model.MeterialboxCode;
            parameters[18].Value = model.MeterialBatch;
            parameters[19].Value = model.MeterialStatus;
            parameters[20].Value = model.StockListID;
            parameters[21].Value = model.GsEnabled;
            parameters[22].Value = model.StoreHouseLogicAreaID;
            parameters[23].Value = model.StoreHouseAreaName;
            parameters[24].Value = model.StoreHouseAreaDesc;
            parameters[25].Value = model.GoodsSite_Reserve;

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
        public bool Update(AsrsStorDBAcc.Model.View_StockModel model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update View_Stock set ");
            strSql.Append("StoreHouseID=@StoreHouseID,");
            strSql.Append("GoodsSiteID=@GoodsSiteID,");
            strSql.Append("GoodsSiteName=@GoodsSiteName,");
            strSql.Append("GoodsSiteLayer=@GoodsSiteLayer,");
            strSql.Append("GoodsSiteColumn=@GoodsSiteColumn,");
            strSql.Append("StoreHouseName=@StoreHouseName,");
            strSql.Append("StoreHouseDesc=@StoreHouseDesc,");
            strSql.Append("GoodsSiteRow=@GoodsSiteRow,");
            strSql.Append("GoodsSiteTaskStatus=@GoodsSiteTaskStatus,");
            strSql.Append("GoodsSiteType=@GoodsSiteType,");
            strSql.Append("GoodsSitePos=@GoodsSitePos,");
            strSql.Append("GoodsSiteStatus=@GoodsSiteStatus,");
            strSql.Append("GoodsSiteOperate=@GoodsSiteOperate,");
            strSql.Append("StockID=@StockID,");
            strSql.Append("TrayID=@TrayID,");
            strSql.Append("IsFull=@IsFull,");
            strSql.Append("InHouseTime=@InHouseTime,");
            strSql.Append("MeterialboxCode=@MeterialboxCode,");
            strSql.Append("MeterialBatch=@MeterialBatch,");
            strSql.Append("MeterialStatus=@MeterialStatus,");
            strSql.Append("StockListID=@StockListID,");
            strSql.Append("GsEnabled=@GsEnabled,");
            strSql.Append("StoreHouseLogicAreaID=@StoreHouseLogicAreaID,");
            strSql.Append("StoreHouseAreaName=@StoreHouseAreaName,");
            strSql.Append("StoreHouseAreaDesc=@StoreHouseAreaDesc,");
            strSql.Append("GoodsSite_Reserve=@GoodsSite_Reserve");
            strSql.Append(" where StoreHouseID=@StoreHouseID and GoodsSiteID=@GoodsSiteID and GoodsSiteName=@GoodsSiteName and GoodsSiteLayer=@GoodsSiteLayer and GoodsSiteColumn=@GoodsSiteColumn and StoreHouseName=@StoreHouseName and StoreHouseDesc=@StoreHouseDesc and GoodsSiteRow=@GoodsSiteRow and GoodsSiteTaskStatus=@GoodsSiteTaskStatus and GoodsSiteType=@GoodsSiteType and GoodsSitePos=@GoodsSitePos and GoodsSiteStatus=@GoodsSiteStatus and GoodsSiteOperate=@GoodsSiteOperate and StockID=@StockID and TrayID=@TrayID and IsFull=@IsFull and InHouseTime=@InHouseTime and MeterialboxCode=@MeterialboxCode and MeterialBatch=@MeterialBatch and MeterialStatus=@MeterialStatus and StockListID=@StockListID and GsEnabled=@GsEnabled and StoreHouseLogicAreaID=@StoreHouseLogicAreaID and StoreHouseAreaName=@StoreHouseAreaName and StoreHouseAreaDesc=@StoreHouseAreaDesc and GoodsSite_Reserve=@GoodsSite_Reserve ");
            SqlParameter[] parameters = {
					new SqlParameter("@StoreHouseID", SqlDbType.BigInt,8),
					new SqlParameter("@GoodsSiteID", SqlDbType.BigInt,8),
					new SqlParameter("@GoodsSiteName", SqlDbType.NVarChar,50),
					new SqlParameter("@GoodsSiteLayer", SqlDbType.Int,4),
					new SqlParameter("@GoodsSiteColumn", SqlDbType.Int,4),
					new SqlParameter("@StoreHouseName", SqlDbType.NVarChar,50),
					new SqlParameter("@StoreHouseDesc", SqlDbType.NVarChar,100),
					new SqlParameter("@GoodsSiteRow", SqlDbType.Int,4),
					new SqlParameter("@GoodsSiteTaskStatus", SqlDbType.NVarChar,50),
					new SqlParameter("@GoodsSiteType", SqlDbType.NVarChar,50),
					new SqlParameter("@GoodsSitePos", SqlDbType.NVarChar,50),
					new SqlParameter("@GoodsSiteStatus", SqlDbType.NVarChar,50),
					new SqlParameter("@GoodsSiteOperate", SqlDbType.NVarChar,50),
					new SqlParameter("@StockID", SqlDbType.BigInt,8),
					new SqlParameter("@TrayID", SqlDbType.NVarChar,50),
					new SqlParameter("@IsFull", SqlDbType.Bit,1),
					new SqlParameter("@InHouseTime", SqlDbType.DateTime),
					new SqlParameter("@MeterialboxCode", SqlDbType.NVarChar,50),
					new SqlParameter("@MeterialBatch", SqlDbType.NVarChar,50),
					new SqlParameter("@MeterialStatus", SqlDbType.NVarChar,50),
					new SqlParameter("@StockListID", SqlDbType.BigInt,8),
					new SqlParameter("@GsEnabled", SqlDbType.Bit,1),
					new SqlParameter("@StoreHouseLogicAreaID", SqlDbType.BigInt,8),
					new SqlParameter("@StoreHouseAreaName", SqlDbType.NVarChar,50),
					new SqlParameter("@StoreHouseAreaDesc", SqlDbType.NVarChar,100),
					new SqlParameter("@GoodsSite_Reserve", SqlDbType.NVarChar,200)};
            parameters[0].Value = model.StoreHouseID;
            parameters[1].Value = model.GoodsSiteID;
            parameters[2].Value = model.GoodsSiteName;
            parameters[3].Value = model.GoodsSiteLayer;
            parameters[4].Value = model.GoodsSiteColumn;
            parameters[5].Value = model.StoreHouseName;
            parameters[6].Value = model.StoreHouseDesc;
            parameters[7].Value = model.GoodsSiteRow;
            parameters[8].Value = model.GoodsSiteTaskStatus;
            parameters[9].Value = model.GoodsSiteType;
            parameters[10].Value = model.GoodsSitePos;
            parameters[11].Value = model.GoodsSiteStatus;
            parameters[12].Value = model.GoodsSiteOperate;
            parameters[13].Value = model.StockID;
            parameters[14].Value = model.TrayID;
            parameters[15].Value = model.IsFull;
            parameters[16].Value = model.InHouseTime;
            parameters[17].Value = model.MeterialboxCode;
            parameters[18].Value = model.MeterialBatch;
            parameters[19].Value = model.MeterialStatus;
            parameters[20].Value = model.StockListID;
            parameters[21].Value = model.GsEnabled;
            parameters[22].Value = model.StoreHouseLogicAreaID;
            parameters[23].Value = model.StoreHouseAreaName;
            parameters[24].Value = model.StoreHouseAreaDesc;
            parameters[25].Value = model.GoodsSite_Reserve;

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
        public bool Delete(long StoreHouseID, long GoodsSiteID, string GoodsSiteName, int GoodsSiteLayer, int GoodsSiteColumn, string StoreHouseName, string StoreHouseDesc, int GoodsSiteRow, string GoodsSiteTaskStatus, string GoodsSiteType, string GoodsSitePos, string GoodsSiteStatus, string GoodsSiteOperate, long StockID, string TrayID, bool IsFull, DateTime InHouseTime, string MeterialboxCode, string MeterialBatch, string MeterialStatus, long StockListID, bool GsEnabled, long StoreHouseLogicAreaID, string StoreHouseAreaName, string StoreHouseAreaDesc, string GoodsSite_Reserve)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from View_Stock ");
            strSql.Append(" where StoreHouseID=@StoreHouseID and GoodsSiteID=@GoodsSiteID and GoodsSiteName=@GoodsSiteName and GoodsSiteLayer=@GoodsSiteLayer and GoodsSiteColumn=@GoodsSiteColumn and StoreHouseName=@StoreHouseName and StoreHouseDesc=@StoreHouseDesc and GoodsSiteRow=@GoodsSiteRow and GoodsSiteTaskStatus=@GoodsSiteTaskStatus and GoodsSiteType=@GoodsSiteType and GoodsSitePos=@GoodsSitePos and GoodsSiteStatus=@GoodsSiteStatus and GoodsSiteOperate=@GoodsSiteOperate and StockID=@StockID and TrayID=@TrayID and IsFull=@IsFull and InHouseTime=@InHouseTime and MeterialboxCode=@MeterialboxCode and MeterialBatch=@MeterialBatch and MeterialStatus=@MeterialStatus and StockListID=@StockListID and GsEnabled=@GsEnabled and StoreHouseLogicAreaID=@StoreHouseLogicAreaID and StoreHouseAreaName=@StoreHouseAreaName and StoreHouseAreaDesc=@StoreHouseAreaDesc and GoodsSite_Reserve=@GoodsSite_Reserve ");
            SqlParameter[] parameters = {
					new SqlParameter("@StoreHouseID", SqlDbType.BigInt,8),
					new SqlParameter("@GoodsSiteID", SqlDbType.BigInt,8),
					new SqlParameter("@GoodsSiteName", SqlDbType.NVarChar,50),
					new SqlParameter("@GoodsSiteLayer", SqlDbType.Int,4),
					new SqlParameter("@GoodsSiteColumn", SqlDbType.Int,4),
					new SqlParameter("@StoreHouseName", SqlDbType.NVarChar,50),
					new SqlParameter("@StoreHouseDesc", SqlDbType.NVarChar,100),
					new SqlParameter("@GoodsSiteRow", SqlDbType.Int,4),
					new SqlParameter("@GoodsSiteTaskStatus", SqlDbType.NVarChar,50),
					new SqlParameter("@GoodsSiteType", SqlDbType.NVarChar,50),
					new SqlParameter("@GoodsSitePos", SqlDbType.NVarChar,50),
					new SqlParameter("@GoodsSiteStatus", SqlDbType.NVarChar,50),
					new SqlParameter("@GoodsSiteOperate", SqlDbType.NVarChar,50),
					new SqlParameter("@StockID", SqlDbType.BigInt,8),
					new SqlParameter("@TrayID", SqlDbType.NVarChar,50),
					new SqlParameter("@IsFull", SqlDbType.Bit,1),
					new SqlParameter("@InHouseTime", SqlDbType.DateTime),
					new SqlParameter("@MeterialboxCode", SqlDbType.NVarChar,50),
					new SqlParameter("@MeterialBatch", SqlDbType.NVarChar,50),
					new SqlParameter("@MeterialStatus", SqlDbType.NVarChar,50),
					new SqlParameter("@StockListID", SqlDbType.BigInt,8),
					new SqlParameter("@GsEnabled", SqlDbType.Bit,1),
					new SqlParameter("@StoreHouseLogicAreaID", SqlDbType.BigInt,8),
					new SqlParameter("@StoreHouseAreaName", SqlDbType.NVarChar,50),
					new SqlParameter("@StoreHouseAreaDesc", SqlDbType.NVarChar,100),
					new SqlParameter("@GoodsSite_Reserve", SqlDbType.NVarChar,200)			};
            parameters[0].Value = StoreHouseID;
            parameters[1].Value = GoodsSiteID;
            parameters[2].Value = GoodsSiteName;
            parameters[3].Value = GoodsSiteLayer;
            parameters[4].Value = GoodsSiteColumn;
            parameters[5].Value = StoreHouseName;
            parameters[6].Value = StoreHouseDesc;
            parameters[7].Value = GoodsSiteRow;
            parameters[8].Value = GoodsSiteTaskStatus;
            parameters[9].Value = GoodsSiteType;
            parameters[10].Value = GoodsSitePos;
            parameters[11].Value = GoodsSiteStatus;
            parameters[12].Value = GoodsSiteOperate;
            parameters[13].Value = StockID;
            parameters[14].Value = TrayID;
            parameters[15].Value = IsFull;
            parameters[16].Value = InHouseTime;
            parameters[17].Value = MeterialboxCode;
            parameters[18].Value = MeterialBatch;
            parameters[19].Value = MeterialStatus;
            parameters[20].Value = StockListID;
            parameters[21].Value = GsEnabled;
            parameters[22].Value = StoreHouseLogicAreaID;
            parameters[23].Value = StoreHouseAreaName;
            parameters[24].Value = StoreHouseAreaDesc;
            parameters[25].Value = GoodsSite_Reserve;

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
        public AsrsStorDBAcc.Model.View_StockModel GetModel(long StoreHouseID, long GoodsSiteID, string GoodsSiteName, int GoodsSiteLayer, int GoodsSiteColumn, string StoreHouseName, string StoreHouseDesc, int GoodsSiteRow, string GoodsSiteTaskStatus, string GoodsSiteType, string GoodsSitePos, string GoodsSiteStatus, string GoodsSiteOperate, long StockID, string TrayID, bool IsFull, DateTime InHouseTime, string MeterialboxCode, string MeterialBatch, string MeterialStatus, long StockListID, bool GsEnabled, long StoreHouseLogicAreaID, string StoreHouseAreaName, string StoreHouseAreaDesc, string GoodsSite_Reserve)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 StoreHouseID,GoodsSiteID,GoodsSiteName,GoodsSiteLayer,GoodsSiteColumn,StoreHouseName,StoreHouseDesc,GoodsSiteRow,GoodsSiteTaskStatus,GoodsSiteType,GoodsSitePos,GoodsSiteStatus,GoodsSiteOperate,StockID,TrayID,IsFull,InHouseTime,MeterialboxCode,MeterialBatch,MeterialStatus,StockListID,GsEnabled,StoreHouseLogicAreaID,StoreHouseAreaName,StoreHouseAreaDesc,GoodsSite_Reserve from View_Stock ");
            strSql.Append(" where StoreHouseID=@StoreHouseID and GoodsSiteID=@GoodsSiteID and GoodsSiteName=@GoodsSiteName and GoodsSiteLayer=@GoodsSiteLayer and GoodsSiteColumn=@GoodsSiteColumn and StoreHouseName=@StoreHouseName and StoreHouseDesc=@StoreHouseDesc and GoodsSiteRow=@GoodsSiteRow and GoodsSiteTaskStatus=@GoodsSiteTaskStatus and GoodsSiteType=@GoodsSiteType and GoodsSitePos=@GoodsSitePos and GoodsSiteStatus=@GoodsSiteStatus and GoodsSiteOperate=@GoodsSiteOperate and StockID=@StockID and TrayID=@TrayID and IsFull=@IsFull and InHouseTime=@InHouseTime and MeterialboxCode=@MeterialboxCode and MeterialBatch=@MeterialBatch and MeterialStatus=@MeterialStatus and StockListID=@StockListID and GsEnabled=@GsEnabled and StoreHouseLogicAreaID=@StoreHouseLogicAreaID and StoreHouseAreaName=@StoreHouseAreaName and StoreHouseAreaDesc=@StoreHouseAreaDesc and GoodsSite_Reserve=@GoodsSite_Reserve ");
            SqlParameter[] parameters = {
					new SqlParameter("@StoreHouseID", SqlDbType.BigInt,8),
					new SqlParameter("@GoodsSiteID", SqlDbType.BigInt,8),
					new SqlParameter("@GoodsSiteName", SqlDbType.NVarChar,50),
					new SqlParameter("@GoodsSiteLayer", SqlDbType.Int,4),
					new SqlParameter("@GoodsSiteColumn", SqlDbType.Int,4),
					new SqlParameter("@StoreHouseName", SqlDbType.NVarChar,50),
					new SqlParameter("@StoreHouseDesc", SqlDbType.NVarChar,100),
					new SqlParameter("@GoodsSiteRow", SqlDbType.Int,4),
					new SqlParameter("@GoodsSiteTaskStatus", SqlDbType.NVarChar,50),
					new SqlParameter("@GoodsSiteType", SqlDbType.NVarChar,50),
					new SqlParameter("@GoodsSitePos", SqlDbType.NVarChar,50),
					new SqlParameter("@GoodsSiteStatus", SqlDbType.NVarChar,50),
					new SqlParameter("@GoodsSiteOperate", SqlDbType.NVarChar,50),
					new SqlParameter("@StockID", SqlDbType.BigInt,8),
					new SqlParameter("@TrayID", SqlDbType.NVarChar,50),
					new SqlParameter("@IsFull", SqlDbType.Bit,1),
					new SqlParameter("@InHouseTime", SqlDbType.DateTime),
					new SqlParameter("@MeterialboxCode", SqlDbType.NVarChar,50),
					new SqlParameter("@MeterialBatch", SqlDbType.NVarChar,50),
					new SqlParameter("@MeterialStatus", SqlDbType.NVarChar,50),
					new SqlParameter("@StockListID", SqlDbType.BigInt,8),
					new SqlParameter("@GsEnabled", SqlDbType.Bit,1),
					new SqlParameter("@StoreHouseLogicAreaID", SqlDbType.BigInt,8),
					new SqlParameter("@StoreHouseAreaName", SqlDbType.NVarChar,50),
					new SqlParameter("@StoreHouseAreaDesc", SqlDbType.NVarChar,100),
					new SqlParameter("@GoodsSite_Reserve", SqlDbType.NVarChar,200)			};
            parameters[0].Value = StoreHouseID;
            parameters[1].Value = GoodsSiteID;
            parameters[2].Value = GoodsSiteName;
            parameters[3].Value = GoodsSiteLayer;
            parameters[4].Value = GoodsSiteColumn;
            parameters[5].Value = StoreHouseName;
            parameters[6].Value = StoreHouseDesc;
            parameters[7].Value = GoodsSiteRow;
            parameters[8].Value = GoodsSiteTaskStatus;
            parameters[9].Value = GoodsSiteType;
            parameters[10].Value = GoodsSitePos;
            parameters[11].Value = GoodsSiteStatus;
            parameters[12].Value = GoodsSiteOperate;
            parameters[13].Value = StockID;
            parameters[14].Value = TrayID;
            parameters[15].Value = IsFull;
            parameters[16].Value = InHouseTime;
            parameters[17].Value = MeterialboxCode;
            parameters[18].Value = MeterialBatch;
            parameters[19].Value = MeterialStatus;
            parameters[20].Value = StockListID;
            parameters[21].Value = GsEnabled;
            parameters[22].Value = StoreHouseLogicAreaID;
            parameters[23].Value = StoreHouseAreaName;
            parameters[24].Value = StoreHouseAreaDesc;
            parameters[25].Value = GoodsSite_Reserve;

            AsrsStorDBAcc.Model.View_StockModel model = new AsrsStorDBAcc.Model.View_StockModel();
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
        public AsrsStorDBAcc.Model.View_StockModel DataRowToModel(DataRow row)
        {
            AsrsStorDBAcc.Model.View_StockModel model = new AsrsStorDBAcc.Model.View_StockModel();
            if (row != null)
            {
                if (row["StoreHouseID"] != null && row["StoreHouseID"].ToString() != "")
                {
                    model.StoreHouseID = long.Parse(row["StoreHouseID"].ToString());
                }
                if (row["GoodsSiteID"] != null && row["GoodsSiteID"].ToString() != "")
                {
                    model.GoodsSiteID = long.Parse(row["GoodsSiteID"].ToString());
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
                if (row["StoreHouseName"] != null)
                {
                    model.StoreHouseName = row["StoreHouseName"].ToString();
                }
                if (row["StoreHouseDesc"] != null)
                {
                    model.StoreHouseDesc = row["StoreHouseDesc"].ToString();
                }
                if (row["GoodsSiteRow"] != null && row["GoodsSiteRow"].ToString() != "")
                {
                    model.GoodsSiteRow = int.Parse(row["GoodsSiteRow"].ToString());
                }
                if (row["GoodsSiteTaskStatus"] != null)
                {
                    model.GoodsSiteTaskStatus = row["GoodsSiteTaskStatus"].ToString();
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
                if (row["StockListID"] != null && row["StockListID"].ToString() != "")
                {
                    model.StockListID = long.Parse(row["StockListID"].ToString());
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
                if (row["GoodsSite_Reserve"] != null)
                {
                    model.GoodsSite_Reserve = row["GoodsSite_Reserve"].ToString();
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
            strSql.Append("select StoreHouseID,GoodsSiteID,GoodsSiteName,GoodsSiteLayer,GoodsSiteColumn,StoreHouseName,StoreHouseDesc,GoodsSiteRow,GoodsSiteTaskStatus,GoodsSiteType,GoodsSitePos,GoodsSiteStatus,GoodsSiteOperate,StockID,TrayID,IsFull,InHouseTime,MeterialboxCode,MeterialBatch,MeterialStatus,StockListID,GsEnabled,StoreHouseLogicAreaID,StoreHouseAreaName,StoreHouseAreaDesc,GoodsSite_Reserve ");
            strSql.Append(" FROM View_Stock ");
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
            strSql.Append(" StoreHouseID,GoodsSiteID,GoodsSiteName,GoodsSiteLayer,GoodsSiteColumn,StoreHouseName,StoreHouseDesc,GoodsSiteRow,GoodsSiteTaskStatus,GoodsSiteType,GoodsSitePos,GoodsSiteStatus,GoodsSiteOperate,StockID,TrayID,IsFull,InHouseTime,MeterialboxCode,MeterialBatch,MeterialStatus,StockListID,GsEnabled,StoreHouseLogicAreaID,StoreHouseAreaName,StoreHouseAreaDesc,GoodsSite_Reserve ");
            strSql.Append(" FROM View_Stock ");
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
            strSql.Append("select count(1) FROM View_Stock ");
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
                strSql.Append("order by T.GoodsSite_Reserve desc");
            }
            strSql.Append(")AS Row, T.*  from View_Stock T ");
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
            parameters[0].Value = "View_Stock";
            parameters[1].Value = "GoodsSite_Reserve";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;	
            return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
        }*/

        #endregion  BasicMethod
        #region  ExtensionMethod
        public List<string> GetAllBatches(string houseName)
        {
            List<string> batches = new List<string>();
            string sqlStr = "";
            if (houseName != "所有")
            {
                 sqlStr = "select distinct MeterialBatch from View_Stock where StoreHouseName ='" + houseName + "'";
            }
            else
            {
                sqlStr = "select distinct MeterialBatch from View_Stock";
            }
         
            DataSet ds = DbHelperSQL.Query(sqlStr);
            if (ds != null && ds.Tables.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    batches.Add(ds.Tables[0].Rows[i]["MeterialBatch"].ToString());
                }
            }
            return batches;
        }

        public DataTable GetData(string houseName,string houseArea, string rowth,
           string colth, string layerth, string gsStatus, string gsTaskSta, string proBatch,bool isChecked,string materialBoxCode)
        {
            //string sqlStr = " SELECT B.StockID as 库存ID, B.StoreHouseName as 库房名称, B.GoodsSiteName as 货位名称, B.GoodsSitePos as 货位位置 ,B.MeterialBatch as 产品批次,"
            //+"B.GoodsSiteRow as 排, B.GoodsSiteColumn as 列,B.GoodsSiteLayer as 层,B.GoodsSiteStatus as 货位状态 ,"
            //+"B.GoodsSiteTaskStatus as 货位任务状态,LEFT(StockList,LEN(StockList)-1) as 料框条码 ,"
            //+ "B.InHouseTime as 入库时间 FROM (SELECT GoodsSitePos,InHouseTime,MeterialBatch,StoreHouseName,GoodsSiteRow,GoodsSiteColumn,StockID,"
            //+"GoodsSiteLayer,GoodsSiteStatus,GoodsSiteTaskStatus,GoodsSiteName,"
            //+"(SELECT View_Stock.MeterialboxCode+',' FROM View_Stock "
            //+" WHERE View_Stock.GoodsSitePos=A.GoodsSitePos FOR XML PATH('')) AS StockList "
            //+ " FROM View_Stock A GROUP BY GoodsSitePos,InHouseTime,MeterialBatch,GoodsSiteRow,GoodsSiteColumn,StoreHouseName,StockID,"
            //+"GoodsSiteLayer,GoodsSiteStatus,GoodsSiteTaskStatus,GoodsSiteName) B where 1=1";

            string sqlStr = "SELECT  StockID as 库存ID, StoreHouseName as 库房名称,StoreHouseAreaName as 库区, GsEnabled as 启用状态,"
             + " GoodsSiteName as 货位名称, GoodsSitePos as 货位位置 "
             + ",MeterialBatch as 产品批次,GoodsSiteRow as 排, GoodsSiteColumn as 列,"
             + " GoodsSiteLayer as 层,GoodsSiteStatus as 货位状态 ,GoodsSiteTaskStatus as 货位任务状态,"
             + " MeterialboxCode as 料框条码 ,InHouseTime as 入库时间 "
             + " FROM [View_Stock]  where 1=1 ";

            if (proBatch != "所有")
            {
                sqlStr += " and  MeterialBatch = '" + proBatch + "'";
            }

            if(houseArea!="所有")
            {
                sqlStr += " and  StoreHouseAreaName = '" + houseArea + "'";
            }

            if (houseName != "所有")
            {
                sqlStr += " and StoreHouseName = '" + houseName + "'";
            }
            if (rowth != "所有")
            {
                sqlStr += " and GoodsSiteRow = " + rowth;
            }
            if (colth != "所有")
            {
                sqlStr += " and GoodsSiteColumn = " + colth;
            }
            if (layerth != "所有")
            {
                sqlStr += " and GoodsSiteLayer = " + layerth;
            }
            if (gsStatus != "所有")
            {
                sqlStr += " and GoodsSiteStatus = '" + gsStatus + "'";
            }
            if (gsTaskSta != "所有")
            {
                sqlStr += " and GoodsSiteTaskStatus = '" + gsTaskSta + "'";
            }
            if(isChecked == true)
            {
                sqlStr += " and MeterialboxCode = '" + materialBoxCode + "'";
            }

            sqlStr += " order by StockID asc";
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

        public List<string> GetBatches(long houseID, long houseAreaID)
        {
            List<string> batches = new List<string>();

            string sqlStr = "select distinct MeterialBatch from View_Stock where StoreHouseID =" + houseID
        + " and StoreHouseLogicAreaID = " + houseAreaID;


            DataSet ds = DbHelperSQL.Query(sqlStr);
            if (ds != null && ds.Tables.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    string batch = ds.Tables[0].Rows[i]["MeterialBatch"].ToString();
                    if (batch == "")
                    {
                        continue;
                    }
                    batches.Add(batch);
                }
            }
            return batches;
        }
        #endregion  ExtensionMethod
    }
}

