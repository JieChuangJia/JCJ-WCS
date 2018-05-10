using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;

namespace AsrsStorDBAcc.DAL
{
    /// <summary>
    /// 数据访问类:OutBatchSet
    /// </summary>
    public partial class OutBatchSetDAL
    {
        public OutBatchSetDAL()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(long OutBatchSetID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from OutBatchSet");
            strSql.Append(" where OutBatchSetID=@OutBatchSetID");
            SqlParameter[] parameters = {
					new SqlParameter("@OutBatchSetID", SqlDbType.BigInt)
			};
            parameters[0].Value = OutBatchSetID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public long Add(AsrsStorDBAcc.Model.OutBatchSetModel model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into OutBatchSet(");
            strSql.Append("StoreHouseID,StoreHouseLogicAreaID,Batch,Resever1,Resever2,Resever3,Resever4,Resever5,Resever6,Resever7,Resever8)");
            strSql.Append(" values (");
            strSql.Append("@StoreHouseID,@StoreHouseLogicAreaID,@Batch,@Resever1,@Resever2,@Resever3,@Resever4,@Resever5,@Resever6,@Resever7,@Resever8)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@StoreHouseID", SqlDbType.BigInt,8),
					new SqlParameter("@StoreHouseLogicAreaID", SqlDbType.BigInt,8),
					new SqlParameter("@Batch", SqlDbType.NVarChar,200),
					new SqlParameter("@Resever1", SqlDbType.NVarChar,50),
					new SqlParameter("@Resever2", SqlDbType.NVarChar,50),
					new SqlParameter("@Resever3", SqlDbType.NVarChar,50),
					new SqlParameter("@Resever4", SqlDbType.NVarChar,50),
					new SqlParameter("@Resever5", SqlDbType.NVarChar,50),
					new SqlParameter("@Resever6", SqlDbType.NVarChar,50),
					new SqlParameter("@Resever7", SqlDbType.NVarChar,50),
					new SqlParameter("@Resever8", SqlDbType.NVarChar,50)};
            parameters[0].Value = model.StoreHouseID;
            parameters[1].Value = model.StoreHouseLogicAreaID;
            parameters[2].Value = model.Batch;
            parameters[3].Value = model.Resever1;
            parameters[4].Value = model.Resever2;
            parameters[5].Value = model.Resever3;
            parameters[6].Value = model.Resever4;
            parameters[7].Value = model.Resever5;
            parameters[8].Value = model.Resever6;
            parameters[9].Value = model.Resever7;
            parameters[10].Value = model.Resever8;

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
        public bool Update(AsrsStorDBAcc.Model.OutBatchSetModel model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update OutBatchSet set ");
            strSql.Append("StoreHouseID=@StoreHouseID,");
            strSql.Append("StoreHouseLogicAreaID=@StoreHouseLogicAreaID,");
            strSql.Append("Batch=@Batch,");
            strSql.Append("Resever1=@Resever1,");
            strSql.Append("Resever2=@Resever2,");
            strSql.Append("Resever3=@Resever3,");
            strSql.Append("Resever4=@Resever4,");
            strSql.Append("Resever5=@Resever5,");
            strSql.Append("Resever6=@Resever6,");
            strSql.Append("Resever7=@Resever7,");
            strSql.Append("Resever8=@Resever8");
            strSql.Append(" where OutBatchSetID=@OutBatchSetID");
            SqlParameter[] parameters = {
					new SqlParameter("@StoreHouseID", SqlDbType.BigInt,8),
					new SqlParameter("@StoreHouseLogicAreaID", SqlDbType.BigInt,8),
					new SqlParameter("@Batch", SqlDbType.NVarChar,200),
					new SqlParameter("@Resever1", SqlDbType.NVarChar,50),
					new SqlParameter("@Resever2", SqlDbType.NVarChar,50),
					new SqlParameter("@Resever3", SqlDbType.NVarChar,50),
					new SqlParameter("@Resever4", SqlDbType.NVarChar,50),
					new SqlParameter("@Resever5", SqlDbType.NVarChar,50),
					new SqlParameter("@Resever6", SqlDbType.NVarChar,50),
					new SqlParameter("@Resever7", SqlDbType.NVarChar,50),
					new SqlParameter("@Resever8", SqlDbType.NVarChar,50),
					new SqlParameter("@OutBatchSetID", SqlDbType.BigInt,8)};
            parameters[0].Value = model.StoreHouseID;
            parameters[1].Value = model.StoreHouseLogicAreaID;
            parameters[2].Value = model.Batch;
            parameters[3].Value = model.Resever1;
            parameters[4].Value = model.Resever2;
            parameters[5].Value = model.Resever3;
            parameters[6].Value = model.Resever4;
            parameters[7].Value = model.Resever5;
            parameters[8].Value = model.Resever6;
            parameters[9].Value = model.Resever7;
            parameters[10].Value = model.Resever8;
            parameters[11].Value = model.OutBatchSetID;

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
        public bool Delete(long OutBatchSetID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from OutBatchSet ");
            strSql.Append(" where OutBatchSetID=@OutBatchSetID");
            SqlParameter[] parameters = {
					new SqlParameter("@OutBatchSetID", SqlDbType.BigInt)
			};
            parameters[0].Value = OutBatchSetID;

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
        public bool DeleteList(string OutBatchSetIDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from OutBatchSet ");
            strSql.Append(" where OutBatchSetID in (" + OutBatchSetIDlist + ")  ");
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
        public AsrsStorDBAcc.Model.OutBatchSetModel GetModel(long OutBatchSetID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 OutBatchSetID,StoreHouseID,StoreHouseLogicAreaID,Batch,Resever1,Resever2,Resever3,Resever4,Resever5,Resever6,Resever7,Resever8 from OutBatchSet ");
            strSql.Append(" where OutBatchSetID=@OutBatchSetID");
            SqlParameter[] parameters = {
					new SqlParameter("@OutBatchSetID", SqlDbType.BigInt)
			};
            parameters[0].Value = OutBatchSetID;

            AsrsStorDBAcc.Model.OutBatchSetModel model = new AsrsStorDBAcc.Model.OutBatchSetModel();
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
        public AsrsStorDBAcc.Model.OutBatchSetModel DataRowToModel(DataRow row)
        {
            AsrsStorDBAcc.Model.OutBatchSetModel model = new AsrsStorDBAcc.Model.OutBatchSetModel();
            if (row != null)
            {
                if (row["OutBatchSetID"] != null && row["OutBatchSetID"].ToString() != "")
                {
                    model.OutBatchSetID = long.Parse(row["OutBatchSetID"].ToString());
                }
                if (row["StoreHouseID"] != null && row["StoreHouseID"].ToString() != "")
                {
                    model.StoreHouseID = long.Parse(row["StoreHouseID"].ToString());
                }
                if (row["StoreHouseLogicAreaID"] != null && row["StoreHouseLogicAreaID"].ToString() != "")
                {
                    model.StoreHouseLogicAreaID = long.Parse(row["StoreHouseLogicAreaID"].ToString());
                }
                if (row["Batch"] != null)
                {
                    model.Batch = row["Batch"].ToString();
                }
                if (row["Resever1"] != null)
                {
                    model.Resever1 = row["Resever1"].ToString();
                }
                if (row["Resever2"] != null)
                {
                    model.Resever2 = row["Resever2"].ToString();
                }
                if (row["Resever3"] != null)
                {
                    model.Resever3 = row["Resever3"].ToString();
                }
                if (row["Resever4"] != null)
                {
                    model.Resever4 = row["Resever4"].ToString();
                }
                if (row["Resever5"] != null)
                {
                    model.Resever5 = row["Resever5"].ToString();
                }
                if (row["Resever6"] != null)
                {
                    model.Resever6 = row["Resever6"].ToString();
                }
                if (row["Resever7"] != null)
                {
                    model.Resever7 = row["Resever7"].ToString();
                }
                if (row["Resever8"] != null)
                {
                    model.Resever8 = row["Resever8"].ToString();
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
            strSql.Append("select OutBatchSetID,StoreHouseID,StoreHouseLogicAreaID,Batch,Resever1,Resever2,Resever3,Resever4,Resever5,Resever6,Resever7,Resever8 ");
            strSql.Append(" FROM OutBatchSet ");
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
            strSql.Append(" OutBatchSetID,StoreHouseID,StoreHouseLogicAreaID,Batch,Resever1,Resever2,Resever3,Resever4,Resever5,Resever6,Resever7,Resever8 ");
            strSql.Append(" FROM OutBatchSet ");
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
            strSql.Append("select count(1) FROM OutBatchSet ");
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
                strSql.Append("order by T.OutBatchSetID desc");
            }
            strSql.Append(")AS Row, T.*  from OutBatchSet T ");
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
            parameters[0].Value = "OutBatchSet";
            parameters[1].Value = "OutBatchSetID";
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

