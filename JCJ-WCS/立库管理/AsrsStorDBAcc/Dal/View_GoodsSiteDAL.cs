using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using AsrsStorDBAcc.Model;
using System.Collections.Generic;
 
namespace AsrsStorDBAcc.DAL
{
    /// <summary>
    /// 数据访问类:View_GoodsSite
    /// </summary>
    public partial class View_GoodsSiteDAL
    {
        public View_GoodsSiteDAL()
        { }
        #region  BasicMethod

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(long GoodsSiteID, long StoreHouseID, string GoodsSiteName, int GoodsSiteLayer, int GoodsSiteColumn, int GoodsSiteRow, string GoodsSiteTaskStatus, string GoodsSiteType, string GoodsSitePos, string GoodsSiteStatus, string GoodsSiteOperate, string StoreHouseName, string StoreHouseDesc, bool GsEnabled, long StoreHouseLogicAreaID, string StoreHouseAreaName, string StoreHouseAreaDesc, string GoodsSite_Reserve)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from View_GoodsSite");
            strSql.Append(" where GoodsSiteID=@GoodsSiteID and StoreHouseID=@StoreHouseID and GoodsSiteName=@GoodsSiteName and GoodsSiteLayer=@GoodsSiteLayer and GoodsSiteColumn=@GoodsSiteColumn and GoodsSiteRow=@GoodsSiteRow and GoodsSiteTaskStatus=@GoodsSiteTaskStatus and GoodsSiteType=@GoodsSiteType and GoodsSitePos=@GoodsSitePos and GoodsSiteStatus=@GoodsSiteStatus and GoodsSiteOperate=@GoodsSiteOperate and StoreHouseName=@StoreHouseName and StoreHouseDesc=@StoreHouseDesc and GsEnabled=@GsEnabled and StoreHouseLogicAreaID=@StoreHouseLogicAreaID and StoreHouseAreaName=@StoreHouseAreaName and StoreHouseAreaDesc=@StoreHouseAreaDesc and GoodsSite_Reserve=@GoodsSite_Reserve ");
            SqlParameter[] parameters = {
					new SqlParameter("@GoodsSiteID", SqlDbType.BigInt,8),
					new SqlParameter("@StoreHouseID", SqlDbType.BigInt,8),
					new SqlParameter("@GoodsSiteName", SqlDbType.NVarChar,50),
					new SqlParameter("@GoodsSiteLayer", SqlDbType.Int,4),
					new SqlParameter("@GoodsSiteColumn", SqlDbType.Int,4),
					new SqlParameter("@GoodsSiteRow", SqlDbType.Int,4),
					new SqlParameter("@GoodsSiteTaskStatus", SqlDbType.NVarChar,50),
					new SqlParameter("@GoodsSiteType", SqlDbType.NVarChar,50),
					new SqlParameter("@GoodsSitePos", SqlDbType.NVarChar,50),
					new SqlParameter("@GoodsSiteStatus", SqlDbType.NVarChar,50),
					new SqlParameter("@GoodsSiteOperate", SqlDbType.NVarChar,50),
					new SqlParameter("@StoreHouseName", SqlDbType.NVarChar,50),
					new SqlParameter("@StoreHouseDesc", SqlDbType.NVarChar,100),
					new SqlParameter("@GsEnabled", SqlDbType.Bit,1),
					new SqlParameter("@StoreHouseLogicAreaID", SqlDbType.BigInt,8),
					new SqlParameter("@StoreHouseAreaName", SqlDbType.NVarChar,50),
					new SqlParameter("@StoreHouseAreaDesc", SqlDbType.NVarChar,100),
					new SqlParameter("@GoodsSite_Reserve", SqlDbType.NVarChar,200)			};
            parameters[0].Value = GoodsSiteID;
            parameters[1].Value = StoreHouseID;
            parameters[2].Value = GoodsSiteName;
            parameters[3].Value = GoodsSiteLayer;
            parameters[4].Value = GoodsSiteColumn;
            parameters[5].Value = GoodsSiteRow;
            parameters[6].Value = GoodsSiteTaskStatus;
            parameters[7].Value = GoodsSiteType;
            parameters[8].Value = GoodsSitePos;
            parameters[9].Value = GoodsSiteStatus;
            parameters[10].Value = GoodsSiteOperate;
            parameters[11].Value = StoreHouseName;
            parameters[12].Value = StoreHouseDesc;
            parameters[13].Value = GsEnabled;
            parameters[14].Value = StoreHouseLogicAreaID;
            parameters[15].Value = StoreHouseAreaName;
            parameters[16].Value = StoreHouseAreaDesc;
            parameters[17].Value = GoodsSite_Reserve;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(AsrsStorDBAcc.Model.View_GoodsSiteModel model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into View_GoodsSite(");
            strSql.Append("GoodsSiteID,StoreHouseID,GoodsSiteName,GoodsSiteLayer,GoodsSiteColumn,GoodsSiteRow,GoodsSiteTaskStatus,GoodsSiteType,GoodsSitePos,GoodsSiteStatus,GoodsSiteOperate,StoreHouseName,StoreHouseDesc,GsEnabled,StoreHouseLogicAreaID,StoreHouseAreaName,StoreHouseAreaDesc,GoodsSite_Reserve)");
            strSql.Append(" values (");
            strSql.Append("@GoodsSiteID,@StoreHouseID,@GoodsSiteName,@GoodsSiteLayer,@GoodsSiteColumn,@GoodsSiteRow,@GoodsSiteTaskStatus,@GoodsSiteType,@GoodsSitePos,@GoodsSiteStatus,@GoodsSiteOperate,@StoreHouseName,@StoreHouseDesc,@GsEnabled,@StoreHouseLogicAreaID,@StoreHouseAreaName,@StoreHouseAreaDesc,@GoodsSite_Reserve)");
            SqlParameter[] parameters = {
					new SqlParameter("@GoodsSiteID", SqlDbType.BigInt,8),
					new SqlParameter("@StoreHouseID", SqlDbType.BigInt,8),
					new SqlParameter("@GoodsSiteName", SqlDbType.NVarChar,50),
					new SqlParameter("@GoodsSiteLayer", SqlDbType.Int,4),
					new SqlParameter("@GoodsSiteColumn", SqlDbType.Int,4),
					new SqlParameter("@GoodsSiteRow", SqlDbType.Int,4),
					new SqlParameter("@GoodsSiteTaskStatus", SqlDbType.NVarChar,50),
					new SqlParameter("@GoodsSiteType", SqlDbType.NVarChar,50),
					new SqlParameter("@GoodsSitePos", SqlDbType.NVarChar,50),
					new SqlParameter("@GoodsSiteStatus", SqlDbType.NVarChar,50),
					new SqlParameter("@GoodsSiteOperate", SqlDbType.NVarChar,50),
					new SqlParameter("@StoreHouseName", SqlDbType.NVarChar,50),
					new SqlParameter("@StoreHouseDesc", SqlDbType.NVarChar,100),
					new SqlParameter("@GsEnabled", SqlDbType.Bit,1),
					new SqlParameter("@StoreHouseLogicAreaID", SqlDbType.BigInt,8),
					new SqlParameter("@StoreHouseAreaName", SqlDbType.NVarChar,50),
					new SqlParameter("@StoreHouseAreaDesc", SqlDbType.NVarChar,100),
					new SqlParameter("@GoodsSite_Reserve", SqlDbType.NVarChar,200)};
            parameters[0].Value = model.GoodsSiteID;
            parameters[1].Value = model.StoreHouseID;
            parameters[2].Value = model.GoodsSiteName;
            parameters[3].Value = model.GoodsSiteLayer;
            parameters[4].Value = model.GoodsSiteColumn;
            parameters[5].Value = model.GoodsSiteRow;
            parameters[6].Value = model.GoodsSiteTaskStatus;
            parameters[7].Value = model.GoodsSiteType;
            parameters[8].Value = model.GoodsSitePos;
            parameters[9].Value = model.GoodsSiteStatus;
            parameters[10].Value = model.GoodsSiteOperate;
            parameters[11].Value = model.StoreHouseName;
            parameters[12].Value = model.StoreHouseDesc;
            parameters[13].Value = model.GsEnabled;
            parameters[14].Value = model.StoreHouseLogicAreaID;
            parameters[15].Value = model.StoreHouseAreaName;
            parameters[16].Value = model.StoreHouseAreaDesc;
            parameters[17].Value = model.GoodsSite_Reserve;

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
        public bool Update(AsrsStorDBAcc.Model.View_GoodsSiteModel model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update View_GoodsSite set ");
            strSql.Append("GoodsSiteID=@GoodsSiteID,");
            strSql.Append("StoreHouseID=@StoreHouseID,");
            strSql.Append("GoodsSiteName=@GoodsSiteName,");
            strSql.Append("GoodsSiteLayer=@GoodsSiteLayer,");
            strSql.Append("GoodsSiteColumn=@GoodsSiteColumn,");
            strSql.Append("GoodsSiteRow=@GoodsSiteRow,");
            strSql.Append("GoodsSiteTaskStatus=@GoodsSiteTaskStatus,");
            strSql.Append("GoodsSiteType=@GoodsSiteType,");
            strSql.Append("GoodsSitePos=@GoodsSitePos,");
            strSql.Append("GoodsSiteStatus=@GoodsSiteStatus,");
            strSql.Append("GoodsSiteOperate=@GoodsSiteOperate,");
            strSql.Append("StoreHouseName=@StoreHouseName,");
            strSql.Append("StoreHouseDesc=@StoreHouseDesc,");
            strSql.Append("GsEnabled=@GsEnabled,");
            strSql.Append("StoreHouseLogicAreaID=@StoreHouseLogicAreaID,");
            strSql.Append("StoreHouseAreaName=@StoreHouseAreaName,");
            strSql.Append("StoreHouseAreaDesc=@StoreHouseAreaDesc,");
            strSql.Append("GoodsSite_Reserve=@GoodsSite_Reserve");
            strSql.Append(" where GoodsSiteID=@GoodsSiteID and StoreHouseID=@StoreHouseID and GoodsSiteName=@GoodsSiteName and GoodsSiteLayer=@GoodsSiteLayer and GoodsSiteColumn=@GoodsSiteColumn and GoodsSiteRow=@GoodsSiteRow and GoodsSiteTaskStatus=@GoodsSiteTaskStatus and GoodsSiteType=@GoodsSiteType and GoodsSitePos=@GoodsSitePos and GoodsSiteStatus=@GoodsSiteStatus and GoodsSiteOperate=@GoodsSiteOperate and StoreHouseName=@StoreHouseName and StoreHouseDesc=@StoreHouseDesc and GsEnabled=@GsEnabled and StoreHouseLogicAreaID=@StoreHouseLogicAreaID and StoreHouseAreaName=@StoreHouseAreaName and StoreHouseAreaDesc=@StoreHouseAreaDesc and GoodsSite_Reserve=@GoodsSite_Reserve ");
            SqlParameter[] parameters = {
					new SqlParameter("@GoodsSiteID", SqlDbType.BigInt,8),
					new SqlParameter("@StoreHouseID", SqlDbType.BigInt,8),
					new SqlParameter("@GoodsSiteName", SqlDbType.NVarChar,50),
					new SqlParameter("@GoodsSiteLayer", SqlDbType.Int,4),
					new SqlParameter("@GoodsSiteColumn", SqlDbType.Int,4),
					new SqlParameter("@GoodsSiteRow", SqlDbType.Int,4),
					new SqlParameter("@GoodsSiteTaskStatus", SqlDbType.NVarChar,50),
					new SqlParameter("@GoodsSiteType", SqlDbType.NVarChar,50),
					new SqlParameter("@GoodsSitePos", SqlDbType.NVarChar,50),
					new SqlParameter("@GoodsSiteStatus", SqlDbType.NVarChar,50),
					new SqlParameter("@GoodsSiteOperate", SqlDbType.NVarChar,50),
					new SqlParameter("@StoreHouseName", SqlDbType.NVarChar,50),
					new SqlParameter("@StoreHouseDesc", SqlDbType.NVarChar,100),
					new SqlParameter("@GsEnabled", SqlDbType.Bit,1),
					new SqlParameter("@StoreHouseLogicAreaID", SqlDbType.BigInt,8),
					new SqlParameter("@StoreHouseAreaName", SqlDbType.NVarChar,50),
					new SqlParameter("@StoreHouseAreaDesc", SqlDbType.NVarChar,100),
					new SqlParameter("@GoodsSite_Reserve", SqlDbType.NVarChar,200)};
            parameters[0].Value = model.GoodsSiteID;
            parameters[1].Value = model.StoreHouseID;
            parameters[2].Value = model.GoodsSiteName;
            parameters[3].Value = model.GoodsSiteLayer;
            parameters[4].Value = model.GoodsSiteColumn;
            parameters[5].Value = model.GoodsSiteRow;
            parameters[6].Value = model.GoodsSiteTaskStatus;
            parameters[7].Value = model.GoodsSiteType;
            parameters[8].Value = model.GoodsSitePos;
            parameters[9].Value = model.GoodsSiteStatus;
            parameters[10].Value = model.GoodsSiteOperate;
            parameters[11].Value = model.StoreHouseName;
            parameters[12].Value = model.StoreHouseDesc;
            parameters[13].Value = model.GsEnabled;
            parameters[14].Value = model.StoreHouseLogicAreaID;
            parameters[15].Value = model.StoreHouseAreaName;
            parameters[16].Value = model.StoreHouseAreaDesc;
            parameters[17].Value = model.GoodsSite_Reserve;

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
        public bool Delete(long GoodsSiteID, long StoreHouseID, string GoodsSiteName, int GoodsSiteLayer, int GoodsSiteColumn, int GoodsSiteRow, string GoodsSiteTaskStatus, string GoodsSiteType, string GoodsSitePos, string GoodsSiteStatus, string GoodsSiteOperate, string StoreHouseName, string StoreHouseDesc, bool GsEnabled, long StoreHouseLogicAreaID, string StoreHouseAreaName, string StoreHouseAreaDesc, string GoodsSite_Reserve)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from View_GoodsSite ");
            strSql.Append(" where GoodsSiteID=@GoodsSiteID and StoreHouseID=@StoreHouseID and GoodsSiteName=@GoodsSiteName and GoodsSiteLayer=@GoodsSiteLayer and GoodsSiteColumn=@GoodsSiteColumn and GoodsSiteRow=@GoodsSiteRow and GoodsSiteTaskStatus=@GoodsSiteTaskStatus and GoodsSiteType=@GoodsSiteType and GoodsSitePos=@GoodsSitePos and GoodsSiteStatus=@GoodsSiteStatus and GoodsSiteOperate=@GoodsSiteOperate and StoreHouseName=@StoreHouseName and StoreHouseDesc=@StoreHouseDesc and GsEnabled=@GsEnabled and StoreHouseLogicAreaID=@StoreHouseLogicAreaID and StoreHouseAreaName=@StoreHouseAreaName and StoreHouseAreaDesc=@StoreHouseAreaDesc and GoodsSite_Reserve=@GoodsSite_Reserve ");
            SqlParameter[] parameters = {
					new SqlParameter("@GoodsSiteID", SqlDbType.BigInt,8),
					new SqlParameter("@StoreHouseID", SqlDbType.BigInt,8),
					new SqlParameter("@GoodsSiteName", SqlDbType.NVarChar,50),
					new SqlParameter("@GoodsSiteLayer", SqlDbType.Int,4),
					new SqlParameter("@GoodsSiteColumn", SqlDbType.Int,4),
					new SqlParameter("@GoodsSiteRow", SqlDbType.Int,4),
					new SqlParameter("@GoodsSiteTaskStatus", SqlDbType.NVarChar,50),
					new SqlParameter("@GoodsSiteType", SqlDbType.NVarChar,50),
					new SqlParameter("@GoodsSitePos", SqlDbType.NVarChar,50),
					new SqlParameter("@GoodsSiteStatus", SqlDbType.NVarChar,50),
					new SqlParameter("@GoodsSiteOperate", SqlDbType.NVarChar,50),
					new SqlParameter("@StoreHouseName", SqlDbType.NVarChar,50),
					new SqlParameter("@StoreHouseDesc", SqlDbType.NVarChar,100),
					new SqlParameter("@GsEnabled", SqlDbType.Bit,1),
					new SqlParameter("@StoreHouseLogicAreaID", SqlDbType.BigInt,8),
					new SqlParameter("@StoreHouseAreaName", SqlDbType.NVarChar,50),
					new SqlParameter("@StoreHouseAreaDesc", SqlDbType.NVarChar,100),
					new SqlParameter("@GoodsSite_Reserve", SqlDbType.NVarChar,200)			};
            parameters[0].Value = GoodsSiteID;
            parameters[1].Value = StoreHouseID;
            parameters[2].Value = GoodsSiteName;
            parameters[3].Value = GoodsSiteLayer;
            parameters[4].Value = GoodsSiteColumn;
            parameters[5].Value = GoodsSiteRow;
            parameters[6].Value = GoodsSiteTaskStatus;
            parameters[7].Value = GoodsSiteType;
            parameters[8].Value = GoodsSitePos;
            parameters[9].Value = GoodsSiteStatus;
            parameters[10].Value = GoodsSiteOperate;
            parameters[11].Value = StoreHouseName;
            parameters[12].Value = StoreHouseDesc;
            parameters[13].Value = GsEnabled;
            parameters[14].Value = StoreHouseLogicAreaID;
            parameters[15].Value = StoreHouseAreaName;
            parameters[16].Value = StoreHouseAreaDesc;
            parameters[17].Value = GoodsSite_Reserve;

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
        public AsrsStorDBAcc.Model.View_GoodsSiteModel GetModel(long GoodsSiteID, long StoreHouseID, string GoodsSiteName, int GoodsSiteLayer, int GoodsSiteColumn, int GoodsSiteRow, string GoodsSiteTaskStatus, string GoodsSiteType, string GoodsSitePos, string GoodsSiteStatus, string GoodsSiteOperate, string StoreHouseName, string StoreHouseDesc, bool GsEnabled, long StoreHouseLogicAreaID, string StoreHouseAreaName, string StoreHouseAreaDesc, string GoodsSite_Reserve)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 GoodsSiteID,StoreHouseID,GoodsSiteName,GoodsSiteLayer,GoodsSiteColumn,GoodsSiteRow,GoodsSiteTaskStatus,GoodsSiteType,GoodsSitePos,GoodsSiteStatus,GoodsSiteOperate,StoreHouseName,StoreHouseDesc,GsEnabled,StoreHouseLogicAreaID,StoreHouseAreaName,StoreHouseAreaDesc,GoodsSite_Reserve from View_GoodsSite ");
            strSql.Append(" where GoodsSiteID=@GoodsSiteID and StoreHouseID=@StoreHouseID and GoodsSiteName=@GoodsSiteName and GoodsSiteLayer=@GoodsSiteLayer and GoodsSiteColumn=@GoodsSiteColumn and GoodsSiteRow=@GoodsSiteRow and GoodsSiteTaskStatus=@GoodsSiteTaskStatus and GoodsSiteType=@GoodsSiteType and GoodsSitePos=@GoodsSitePos and GoodsSiteStatus=@GoodsSiteStatus and GoodsSiteOperate=@GoodsSiteOperate and StoreHouseName=@StoreHouseName and StoreHouseDesc=@StoreHouseDesc and GsEnabled=@GsEnabled and StoreHouseLogicAreaID=@StoreHouseLogicAreaID and StoreHouseAreaName=@StoreHouseAreaName and StoreHouseAreaDesc=@StoreHouseAreaDesc and GoodsSite_Reserve=@GoodsSite_Reserve ");
            SqlParameter[] parameters = {
					new SqlParameter("@GoodsSiteID", SqlDbType.BigInt,8),
					new SqlParameter("@StoreHouseID", SqlDbType.BigInt,8),
					new SqlParameter("@GoodsSiteName", SqlDbType.NVarChar,50),
					new SqlParameter("@GoodsSiteLayer", SqlDbType.Int,4),
					new SqlParameter("@GoodsSiteColumn", SqlDbType.Int,4),
					new SqlParameter("@GoodsSiteRow", SqlDbType.Int,4),
					new SqlParameter("@GoodsSiteTaskStatus", SqlDbType.NVarChar,50),
					new SqlParameter("@GoodsSiteType", SqlDbType.NVarChar,50),
					new SqlParameter("@GoodsSitePos", SqlDbType.NVarChar,50),
					new SqlParameter("@GoodsSiteStatus", SqlDbType.NVarChar,50),
					new SqlParameter("@GoodsSiteOperate", SqlDbType.NVarChar,50),
					new SqlParameter("@StoreHouseName", SqlDbType.NVarChar,50),
					new SqlParameter("@StoreHouseDesc", SqlDbType.NVarChar,100),
					new SqlParameter("@GsEnabled", SqlDbType.Bit,1),
					new SqlParameter("@StoreHouseLogicAreaID", SqlDbType.BigInt,8),
					new SqlParameter("@StoreHouseAreaName", SqlDbType.NVarChar,50),
					new SqlParameter("@StoreHouseAreaDesc", SqlDbType.NVarChar,100),
					new SqlParameter("@GoodsSite_Reserve", SqlDbType.NVarChar,200)			};
            parameters[0].Value = GoodsSiteID;
            parameters[1].Value = StoreHouseID;
            parameters[2].Value = GoodsSiteName;
            parameters[3].Value = GoodsSiteLayer;
            parameters[4].Value = GoodsSiteColumn;
            parameters[5].Value = GoodsSiteRow;
            parameters[6].Value = GoodsSiteTaskStatus;
            parameters[7].Value = GoodsSiteType;
            parameters[8].Value = GoodsSitePos;
            parameters[9].Value = GoodsSiteStatus;
            parameters[10].Value = GoodsSiteOperate;
            parameters[11].Value = StoreHouseName;
            parameters[12].Value = StoreHouseDesc;
            parameters[13].Value = GsEnabled;
            parameters[14].Value = StoreHouseLogicAreaID;
            parameters[15].Value = StoreHouseAreaName;
            parameters[16].Value = StoreHouseAreaDesc;
            parameters[17].Value = GoodsSite_Reserve;

            AsrsStorDBAcc.Model.View_GoodsSiteModel model = new AsrsStorDBAcc.Model.View_GoodsSiteModel();
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
        public AsrsStorDBAcc.Model.View_GoodsSiteModel DataRowToModel(DataRow row)
        {
            AsrsStorDBAcc.Model.View_GoodsSiteModel model = new AsrsStorDBAcc.Model.View_GoodsSiteModel();
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
            strSql.Append("select GoodsSiteID,StoreHouseID,GoodsSiteName,GoodsSiteLayer,GoodsSiteColumn,GoodsSiteRow,GoodsSiteTaskStatus,GoodsSiteType,GoodsSitePos,GoodsSiteStatus,GoodsSiteOperate,StoreHouseName,StoreHouseDesc,GsEnabled,StoreHouseLogicAreaID,StoreHouseAreaName,StoreHouseAreaDesc,GoodsSite_Reserve ");
            strSql.Append(" FROM View_GoodsSite ");
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
            strSql.Append(" GoodsSiteID,StoreHouseID,GoodsSiteName,GoodsSiteLayer,GoodsSiteColumn,GoodsSiteRow,GoodsSiteTaskStatus,GoodsSiteType,GoodsSitePos,GoodsSiteStatus,GoodsSiteOperate,StoreHouseName,StoreHouseDesc,GsEnabled,StoreHouseLogicAreaID,StoreHouseAreaName,StoreHouseAreaDesc,GoodsSite_Reserve ");
            strSql.Append(" FROM View_GoodsSite ");
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
            strSql.Append("select count(1) FROM View_GoodsSite ");
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
            strSql.Append(")AS Row, T.*  from View_GoodsSite T ");
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
            parameters[0].Value = "View_GoodsSite";
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
         public List<StoreHouseLogicAreaModel> GetHouseArea(long storeHouseID)
        {
            string sqlStr = "select distinct(StoreHouseLogicAreaID) ,StoreHouseAreaName ,StoreHouseAreaDesc from View_GoodsSite where StoreHouseID = " +storeHouseID;
            List<StoreHouseLogicAreaModel> houseAreaList = new List<StoreHouseLogicAreaModel>();
             
            DataSet ds = DbHelperSQL.Query(sqlStr);
            if (ds!=null&&ds.Tables.Count > 0)
            {
                for(int i=0;i<ds.Tables[0].Rows.Count;i++)
                {
                    long areaID =long.Parse( ds.Tables[0].Rows[i]["StoreHouseLogicAreaID"].ToString());
                    string houseAreaName = ds.Tables[0].Rows[i]["StoreHouseAreaName"].ToString();
                    string storeHouseAreaDesc = ds.Tables[0].Rows[i]["StoreHouseAreaDesc"].ToString();
                    StoreHouseLogicAreaModel sglam = new StoreHouseLogicAreaModel();
                    sglam.StoreHouseLogicAreaID = areaID;
                    sglam.StoreHouseAreaName = houseAreaName;
                    sglam.StoreHouseAreaDesc = storeHouseAreaDesc;
                    houseAreaList.Add(sglam);
                }
            }
            return houseAreaList;
        }
        #endregion  ExtensionMethod
    }
}

