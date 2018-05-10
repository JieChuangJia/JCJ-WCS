using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;

namespace AsrsStorDBAcc.DAL
{
    /// <summary>
    /// 数据访问类:View_OutHouseBatchSet
    /// </summary>
    public partial class View_OutHouseBatchSetDAL
    {
        public View_OutHouseBatchSetDAL()
        { }
        #region  BasicMethod

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string StoreHouseName, string StoreHouseDesc, long StoreHouseID, long StoreHouseLogicAreaID, string StoreHouseAreaName, string StoreHouseAreaDesc, string Batch)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from View_OutHouseBatchSet");
            strSql.Append(" where StoreHouseName=@StoreHouseName and StoreHouseDesc=@StoreHouseDesc and StoreHouseID=@StoreHouseID and StoreHouseLogicAreaID=@StoreHouseLogicAreaID and StoreHouseAreaName=@StoreHouseAreaName and StoreHouseAreaDesc=@StoreHouseAreaDesc and Batch=@Batch ");
            SqlParameter[] parameters = {
					new SqlParameter("@StoreHouseName", SqlDbType.NVarChar,50),
					new SqlParameter("@StoreHouseDesc", SqlDbType.NVarChar,100),
					new SqlParameter("@StoreHouseID", SqlDbType.BigInt,8),
					new SqlParameter("@StoreHouseLogicAreaID", SqlDbType.BigInt,8),
					new SqlParameter("@StoreHouseAreaName", SqlDbType.NVarChar,50),
					new SqlParameter("@StoreHouseAreaDesc", SqlDbType.NVarChar,100),
					new SqlParameter("@Batch", SqlDbType.NVarChar,200)			};
            parameters[0].Value = StoreHouseName;
            parameters[1].Value = StoreHouseDesc;
            parameters[2].Value = StoreHouseID;
            parameters[3].Value = StoreHouseLogicAreaID;
            parameters[4].Value = StoreHouseAreaName;
            parameters[5].Value = StoreHouseAreaDesc;
            parameters[6].Value = Batch;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(AsrsStorDBAcc.Model.View_OutHouseBatchSetModel model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into View_OutHouseBatchSet(");
            strSql.Append("StoreHouseName,StoreHouseDesc,StoreHouseID,StoreHouseLogicAreaID,StoreHouseAreaName,StoreHouseAreaDesc,Batch)");
            strSql.Append(" values (");
            strSql.Append("@StoreHouseName,@StoreHouseDesc,@StoreHouseID,@StoreHouseLogicAreaID,@StoreHouseAreaName,@StoreHouseAreaDesc,@Batch)");
            SqlParameter[] parameters = {
					new SqlParameter("@StoreHouseName", SqlDbType.NVarChar,50),
					new SqlParameter("@StoreHouseDesc", SqlDbType.NVarChar,100),
					new SqlParameter("@StoreHouseID", SqlDbType.BigInt,8),
					new SqlParameter("@StoreHouseLogicAreaID", SqlDbType.BigInt,8),
					new SqlParameter("@StoreHouseAreaName", SqlDbType.NVarChar,50),
					new SqlParameter("@StoreHouseAreaDesc", SqlDbType.NVarChar,100),
					new SqlParameter("@Batch", SqlDbType.NVarChar,200)};
            parameters[0].Value = model.StoreHouseName;
            parameters[1].Value = model.StoreHouseDesc;
            parameters[2].Value = model.StoreHouseID;
            parameters[3].Value = model.StoreHouseLogicAreaID;
            parameters[4].Value = model.StoreHouseAreaName;
            parameters[5].Value = model.StoreHouseAreaDesc;
            parameters[6].Value = model.Batch;

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
        public bool Update(AsrsStorDBAcc.Model.View_OutHouseBatchSetModel model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update View_OutHouseBatchSet set ");
            strSql.Append("StoreHouseName=@StoreHouseName,");
            strSql.Append("StoreHouseDesc=@StoreHouseDesc,");
            strSql.Append("StoreHouseID=@StoreHouseID,");
            strSql.Append("StoreHouseLogicAreaID=@StoreHouseLogicAreaID,");
            strSql.Append("StoreHouseAreaName=@StoreHouseAreaName,");
            strSql.Append("StoreHouseAreaDesc=@StoreHouseAreaDesc,");
            strSql.Append("Batch=@Batch");
            strSql.Append(" where StoreHouseName=@StoreHouseName and StoreHouseDesc=@StoreHouseDesc and StoreHouseID=@StoreHouseID and StoreHouseLogicAreaID=@StoreHouseLogicAreaID and StoreHouseAreaName=@StoreHouseAreaName and StoreHouseAreaDesc=@StoreHouseAreaDesc and Batch=@Batch ");
            SqlParameter[] parameters = {
					new SqlParameter("@StoreHouseName", SqlDbType.NVarChar,50),
					new SqlParameter("@StoreHouseDesc", SqlDbType.NVarChar,100),
					new SqlParameter("@StoreHouseID", SqlDbType.BigInt,8),
					new SqlParameter("@StoreHouseLogicAreaID", SqlDbType.BigInt,8),
					new SqlParameter("@StoreHouseAreaName", SqlDbType.NVarChar,50),
					new SqlParameter("@StoreHouseAreaDesc", SqlDbType.NVarChar,100),
					new SqlParameter("@Batch", SqlDbType.NVarChar,200)};
            parameters[0].Value = model.StoreHouseName;
            parameters[1].Value = model.StoreHouseDesc;
            parameters[2].Value = model.StoreHouseID;
            parameters[3].Value = model.StoreHouseLogicAreaID;
            parameters[4].Value = model.StoreHouseAreaName;
            parameters[5].Value = model.StoreHouseAreaDesc;
            parameters[6].Value = model.Batch;

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
        public bool Delete(string StoreHouseName, string StoreHouseDesc, long StoreHouseID, long StoreHouseLogicAreaID, string StoreHouseAreaName, string StoreHouseAreaDesc, string Batch)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from View_OutHouseBatchSet ");
            strSql.Append(" where StoreHouseName=@StoreHouseName and StoreHouseDesc=@StoreHouseDesc and StoreHouseID=@StoreHouseID and StoreHouseLogicAreaID=@StoreHouseLogicAreaID and StoreHouseAreaName=@StoreHouseAreaName and StoreHouseAreaDesc=@StoreHouseAreaDesc and Batch=@Batch ");
            SqlParameter[] parameters = {
					new SqlParameter("@StoreHouseName", SqlDbType.NVarChar,50),
					new SqlParameter("@StoreHouseDesc", SqlDbType.NVarChar,100),
					new SqlParameter("@StoreHouseID", SqlDbType.BigInt,8),
					new SqlParameter("@StoreHouseLogicAreaID", SqlDbType.BigInt,8),
					new SqlParameter("@StoreHouseAreaName", SqlDbType.NVarChar,50),
					new SqlParameter("@StoreHouseAreaDesc", SqlDbType.NVarChar,100),
					new SqlParameter("@Batch", SqlDbType.NVarChar,200)			};
            parameters[0].Value = StoreHouseName;
            parameters[1].Value = StoreHouseDesc;
            parameters[2].Value = StoreHouseID;
            parameters[3].Value = StoreHouseLogicAreaID;
            parameters[4].Value = StoreHouseAreaName;
            parameters[5].Value = StoreHouseAreaDesc;
            parameters[6].Value = Batch;

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
        public AsrsStorDBAcc.Model.View_OutHouseBatchSetModel GetModel(string StoreHouseName, string StoreHouseDesc, long StoreHouseID, long StoreHouseLogicAreaID, string StoreHouseAreaName, string StoreHouseAreaDesc, string Batch)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 StoreHouseName,StoreHouseDesc,StoreHouseID,StoreHouseLogicAreaID,StoreHouseAreaName,StoreHouseAreaDesc,Batch from View_OutHouseBatchSet ");
            strSql.Append(" where StoreHouseName=@StoreHouseName and StoreHouseDesc=@StoreHouseDesc and StoreHouseID=@StoreHouseID and StoreHouseLogicAreaID=@StoreHouseLogicAreaID and StoreHouseAreaName=@StoreHouseAreaName and StoreHouseAreaDesc=@StoreHouseAreaDesc and Batch=@Batch ");
            SqlParameter[] parameters = {
					new SqlParameter("@StoreHouseName", SqlDbType.NVarChar,50),
					new SqlParameter("@StoreHouseDesc", SqlDbType.NVarChar,100),
					new SqlParameter("@StoreHouseID", SqlDbType.BigInt,8),
					new SqlParameter("@StoreHouseLogicAreaID", SqlDbType.BigInt,8),
					new SqlParameter("@StoreHouseAreaName", SqlDbType.NVarChar,50),
					new SqlParameter("@StoreHouseAreaDesc", SqlDbType.NVarChar,100),
					new SqlParameter("@Batch", SqlDbType.NVarChar,200)			};
            parameters[0].Value = StoreHouseName;
            parameters[1].Value = StoreHouseDesc;
            parameters[2].Value = StoreHouseID;
            parameters[3].Value = StoreHouseLogicAreaID;
            parameters[4].Value = StoreHouseAreaName;
            parameters[5].Value = StoreHouseAreaDesc;
            parameters[6].Value = Batch;

            AsrsStorDBAcc.Model.View_OutHouseBatchSetModel model = new AsrsStorDBAcc.Model.View_OutHouseBatchSetModel();
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
        public AsrsStorDBAcc.Model.View_OutHouseBatchSetModel DataRowToModel(DataRow row)
        {
            AsrsStorDBAcc.Model.View_OutHouseBatchSetModel model = new AsrsStorDBAcc.Model.View_OutHouseBatchSetModel();
            if (row != null)
            {
                if (row["StoreHouseName"] != null)
                {
                    model.StoreHouseName = row["StoreHouseName"].ToString();
                }
                if (row["StoreHouseDesc"] != null)
                {
                    model.StoreHouseDesc = row["StoreHouseDesc"].ToString();
                }
                if (row["StoreHouseID"] != null && row["StoreHouseID"].ToString() != "")
                {
                    model.StoreHouseID = long.Parse(row["StoreHouseID"].ToString());
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
                if (row["Batch"] != null)
                {
                    model.Batch = row["Batch"].ToString();
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
            strSql.Append("select StoreHouseName,StoreHouseDesc,StoreHouseID,StoreHouseLogicAreaID,StoreHouseAreaName,StoreHouseAreaDesc,Batch ");
            strSql.Append(" FROM View_OutHouseBatchSet ");
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
            strSql.Append(" StoreHouseName,StoreHouseDesc,StoreHouseID,StoreHouseLogicAreaID,StoreHouseAreaName,StoreHouseAreaDesc,Batch ");
            strSql.Append(" FROM View_OutHouseBatchSet ");
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
            strSql.Append("select count(1) FROM View_OutHouseBatchSet ");
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
                strSql.Append("order by T.Batch desc");
            }
            strSql.Append(")AS Row, T.*  from View_OutHouseBatchSet T ");
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
            parameters[0].Value = "View_OutHouseBatchSet";
            parameters[1].Value = "Batch";
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

