using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using MesDBAccess.DBUtility;//Please add references
namespace MesDBAccess.DAL
{
    /// <summary>
    /// 数据访问类:BatchModel
    /// </summary>
    public partial class BatchDal
    {
        public BatchDal()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string batchName)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Batch");
            strSql.Append(" where batchName=@batchName ");
            SqlParameter[] parameters = {
					new SqlParameter("@batchName", SqlDbType.NVarChar,50)			};
            parameters[0].Value = batchName;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(MesDBAccess.Model.BatchModel model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Batch(");
            strSql.Append("batchName,createTime,remark)");
            strSql.Append(" values (");
            strSql.Append("@batchName,@createTime,@remark)");
            SqlParameter[] parameters = {
					new SqlParameter("@batchName", SqlDbType.NVarChar,50),
					new SqlParameter("@createTime", SqlDbType.DateTime),
					new SqlParameter("@remark", SqlDbType.NVarChar,255)};
            parameters[0].Value = model.batchName;
            parameters[1].Value = model.createTime;
            parameters[2].Value = model.remark;

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
        public bool Update(MesDBAccess.Model.BatchModel model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Batch set ");
            strSql.Append("createTime=@createTime,");
            strSql.Append("remark=@remark");
            strSql.Append(" where batchName=@batchName ");
            SqlParameter[] parameters = {
					new SqlParameter("@createTime", SqlDbType.DateTime),
					new SqlParameter("@remark", SqlDbType.NVarChar,255),
					new SqlParameter("@batchName", SqlDbType.NVarChar,50)};
            parameters[0].Value = model.createTime;
            parameters[1].Value = model.remark;
            parameters[2].Value = model.batchName;

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
        public bool Delete(string batchName)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Batch ");
            strSql.Append(" where batchName=@batchName ");
            SqlParameter[] parameters = {
					new SqlParameter("@batchName", SqlDbType.NVarChar,50)			};
            parameters[0].Value = batchName;

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
        public bool DeleteList(string batchNamelist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Batch ");
            strSql.Append(" where batchName in (" + batchNamelist + ")  ");
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
        public MesDBAccess.Model.BatchModel GetModel(string batchName)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 batchName,createTime,remark from Batch ");
            strSql.Append(" where batchName=@batchName ");
            SqlParameter[] parameters = {
					new SqlParameter("@batchName", SqlDbType.NVarChar,50)			};
            parameters[0].Value = batchName;

            MesDBAccess.Model.BatchModel model = new MesDBAccess.Model.BatchModel();
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
        public MesDBAccess.Model.BatchModel DataRowToModel(DataRow row)
        {
            MesDBAccess.Model.BatchModel model = new MesDBAccess.Model.BatchModel();
            if (row != null)
            {
                if (row["batchName"] != null)
                {
                    model.batchName = row["batchName"].ToString();
                }
                if (row["createTime"] != null && row["createTime"].ToString() != "")
                {
                    model.createTime = DateTime.Parse(row["createTime"].ToString());
                }
                if (row["remark"] != null)
                {
                    model.remark = row["remark"].ToString();
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
            strSql.Append("select batchName,createTime,remark");
            strSql.Append(" FROM Batch ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by createTime");
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
            strSql.Append(" batchName,createTime,remark ");
            strSql.Append(" FROM Batch ");
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
            strSql.Append("select count(1) FROM Batch ");
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
                strSql.Append("order by T.batchName desc");
            }
            strSql.Append(")AS Row, T.*  from Batch T ");
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
            parameters[0].Value = "Batch";
            parameters[1].Value = "batchName";
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
