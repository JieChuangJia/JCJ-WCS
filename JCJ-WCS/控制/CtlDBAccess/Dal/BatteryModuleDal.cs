using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using DBAccess.DBUtility;//Please add references
namespace DBAccess.DAL
{
    /// <summary>
    /// 数据访问类:BatteryModuleModel
    /// </summary>
    public partial class BatteryModuleDal
    {
        public BatteryModuleDal()
        { }
        #region  BasicMethod

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string batModuleID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from BatteryModule");
            strSql.Append(" where batModuleID=@batModuleID ");
            SqlParameter[] parameters = {
					new SqlParameter("@batModuleID", SqlDbType.NVarChar,50)			};
            parameters[0].Value = batModuleID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(DBAccess.Model.BatteryModuleModel model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into BatteryModule(");
            strSql.Append("batModuleID,batchName,asmTime,curProcessStage,batPackID,topcapOPWorkerID,downcapOPWorkerID,palletID,palletBinded,topcapWelderID,bottomcapWelderID)");
            strSql.Append(" values (");
            strSql.Append("@batModuleID,@batchName,@asmTime,@curProcessStage,@batPackID,@topcapOPWorkerID,@downcapOPWorkerID,@palletID,@palletBinded,@topcapWelderID,@bottomcapWelderID)");
            SqlParameter[] parameters = {
					new SqlParameter("@batModuleID", SqlDbType.NVarChar,50),
					new SqlParameter("@batchName", SqlDbType.NVarChar,50),
					new SqlParameter("@asmTime", SqlDbType.DateTime),
					new SqlParameter("@curProcessStage", SqlDbType.NVarChar,50),
					new SqlParameter("@batPackID", SqlDbType.NVarChar,50),
					new SqlParameter("@topcapOPWorkerID", SqlDbType.NVarChar,50),
					new SqlParameter("@downcapOPWorkerID", SqlDbType.NVarChar,50),
					new SqlParameter("@palletID", SqlDbType.NVarChar,50),
					new SqlParameter("@palletBinded", SqlDbType.Bit,1),
					new SqlParameter("@topcapWelderID", SqlDbType.Int,4),
					new SqlParameter("@bottomcapWelderID", SqlDbType.Int,4)};
            parameters[0].Value = model.batModuleID;
            parameters[1].Value = model.batchName;
            parameters[2].Value = model.asmTime;
            parameters[3].Value = model.curProcessStage;
            parameters[4].Value = model.batPackID;
            parameters[5].Value = model.topcapOPWorkerID;
            parameters[6].Value = model.downcapOPWorkerID;
            parameters[7].Value = model.palletID;
            parameters[8].Value = model.palletBinded;
            parameters[9].Value = model.topcapWelderID;
            parameters[10].Value = model.bottomcapWelderID;

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
        public bool Update(DBAccess.Model.BatteryModuleModel model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update BatteryModule set ");
            strSql.Append("batchName=@batchName,");
            strSql.Append("asmTime=@asmTime,");
            strSql.Append("curProcessStage=@curProcessStage,");
            strSql.Append("batPackID=@batPackID,");
            strSql.Append("topcapOPWorkerID=@topcapOPWorkerID,");
            strSql.Append("downcapOPWorkerID=@downcapOPWorkerID,");
            strSql.Append("palletID=@palletID,");
            strSql.Append("palletBinded=@palletBinded,");
            strSql.Append("topcapWelderID=@topcapWelderID,");
            strSql.Append("bottomcapWelderID=@bottomcapWelderID,");
            strSql.Append("checkResult=@checkResult");
            strSql.Append(" where batModuleID=@batModuleID ");
            SqlParameter[] parameters = {
					new SqlParameter("@batchName", SqlDbType.NVarChar,50),
					new SqlParameter("@asmTime", SqlDbType.DateTime),
					new SqlParameter("@curProcessStage", SqlDbType.NVarChar,50),
					new SqlParameter("@batPackID", SqlDbType.NVarChar,50),
					new SqlParameter("@topcapOPWorkerID", SqlDbType.NVarChar,50),
					new SqlParameter("@downcapOPWorkerID", SqlDbType.NVarChar,50),
					new SqlParameter("@palletID", SqlDbType.NVarChar,50),
					new SqlParameter("@palletBinded", SqlDbType.Bit,1),
					new SqlParameter("@topcapWelderID", SqlDbType.Int,4),
					new SqlParameter("@bottomcapWelderID", SqlDbType.Int,4),
					new SqlParameter("@checkResult", SqlDbType.Int,4),
					new SqlParameter("@batModuleID", SqlDbType.NVarChar,50)};
            parameters[0].Value = model.batchName;
            parameters[1].Value = model.asmTime;
            parameters[2].Value = model.curProcessStage;
            parameters[3].Value = model.batPackID;
            parameters[4].Value = model.topcapOPWorkerID;
            parameters[5].Value = model.downcapOPWorkerID;
            parameters[6].Value = model.palletID;
            parameters[7].Value = model.palletBinded;
            parameters[8].Value = model.topcapWelderID;
            parameters[9].Value = model.bottomcapWelderID;
            parameters[10].Value = model.checkResult;
            parameters[11].Value = model.batModuleID;

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
        public bool Delete(string batModuleID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from BatteryModule ");
            strSql.Append(" where batModuleID=@batModuleID ");
            SqlParameter[] parameters = {
					new SqlParameter("@batModuleID", SqlDbType.NVarChar,50)			};
            parameters[0].Value = batModuleID;

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
        public bool DeleteList(string batModuleIDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from BatteryModule ");
            strSql.Append(" where batModuleID in (" + batModuleIDlist + ")  ");
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
        public DBAccess.Model.BatteryModuleModel GetModel(string batModuleID)
        {


            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 batModuleID,batchName,asmTime,curProcessStage,batPackID,topcapOPWorkerID,downcapOPWorkerID,palletID,palletBinded,topcapWelderID,bottomcapWelderID,checkResult from BatteryModule ");
            strSql.Append(" where batModuleID=@batModuleID ");
            SqlParameter[] parameters = {
					new SqlParameter("@batModuleID", SqlDbType.NVarChar,50)			};
            parameters[0].Value = batModuleID;

            DBAccess.Model.BatteryModuleModel model = new DBAccess.Model.BatteryModuleModel();
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
        public DBAccess.Model.BatteryModuleModel DataRowToModel(DataRow row)
        {
            DBAccess.Model.BatteryModuleModel model = new DBAccess.Model.BatteryModuleModel();
            if (row != null)
            {

                if (row["batModuleID"] != null)
                {
                    model.batModuleID = row["batModuleID"].ToString();
                }
                if (row["batchName"] != null)
                {
                    model.batchName = row["batchName"].ToString();
                }
                if (row["asmTime"] != null && row["asmTime"].ToString() != "")
                {
                    model.asmTime = DateTime.Parse(row["asmTime"].ToString());
                }
                if (row["curProcessStage"] != null)
                {
                    model.curProcessStage = row["curProcessStage"].ToString();
                }
                if (row["batPackID"] != null)
                {
                    model.batPackID = row["batPackID"].ToString();
                }
                if (row["topcapOPWorkerID"] != null)
                {
                    model.topcapOPWorkerID = row["topcapOPWorkerID"].ToString();
                }
                if (row["downcapOPWorkerID"] != null)
                {
                    model.downcapOPWorkerID = row["downcapOPWorkerID"].ToString();
                }
                if (row["palletID"] != null)
                {
                    model.palletID = row["palletID"].ToString();
                }
                if (row["palletBinded"] != null && row["palletBinded"].ToString() != "")
                {
                    if ((row["palletBinded"].ToString() == "1") || (row["palletBinded"].ToString().ToLower() == "true"))
                    {
                        model.palletBinded = true;
                    }
                    else
                    {
                        model.palletBinded = false;
                    }
                }
                if (row["topcapWelderID"] != null && row["topcapWelderID"].ToString() != "")
                {
                    model.topcapWelderID = int.Parse(row["topcapWelderID"].ToString());
                }
                if (row["bottomcapWelderID"] != null && row["bottomcapWelderID"].ToString() != "")
                {
                    model.bottomcapWelderID = int.Parse(row["bottomcapWelderID"].ToString());
                }
                if (row["checkResult"] != null && row["checkResult"].ToString() != "")
                {
                    model.checkResult = int.Parse(row["checkResult"].ToString());
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
            strSql.Append("select batModuleID,batchName,asmTime,curProcessStage,batPackID,topcapOPWorkerID,downcapOPWorkerID,palletID,palletBinded,topcapWelderID,bottomcapWelderID,checkResult ");
            strSql.Append(" FROM BatteryModule ");
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
            strSql.Append(" batModuleID,batchName,asmTime,curProcessStage,batPackID,topcapOPWorkerID,downcapOPWorkerID,palletID,palletBinded,topcapWelderID,bottomcapWelderID,checkResult ");
            strSql.Append(" FROM BatteryModule ");
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
            strSql.Append("select count(1) FROM BatteryModule ");
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
                strSql.Append("order by T.batModuleID desc");
            }
            strSql.Append(")AS Row, T.*  from BatteryModule T ");
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
            parameters[0].Value = "BatteryModule";
            parameters[1].Value = "batModuleID";
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

