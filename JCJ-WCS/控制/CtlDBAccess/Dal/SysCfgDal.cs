using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using CtlDBAccess.DBUtility;//Please add references
namespace CtlDBAccess.DAL
{
    /// <summary>
    /// 数据访问类:SysCfgModel
    /// </summary>
    public partial class SysCfgDal
    {
        public SysCfgDal()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string sysCfgName)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from SysCfg");
            strSql.Append(" where sysCfgName=@sysCfgName ");
            SqlParameter[] parameters = {
					new SqlParameter("@sysCfgName", SqlDbType.NVarChar,50)			};
            parameters[0].Value = sysCfgName;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(CtlDBAccess.Model.SysCfgDBModel model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into SysCfg(");
            strSql.Append("sysCfgName,cfgFile,modifyTime,tag1,tag2)");
            strSql.Append(" values (");
            strSql.Append("@sysCfgName,@cfgFile,@modifyTime,@tag1,@tag2)");
            SqlParameter[] parameters = {
					new SqlParameter("@sysCfgName", SqlDbType.NVarChar,50),
					new SqlParameter("@cfgFile", SqlDbType.Text),
					new SqlParameter("@modifyTime", SqlDbType.DateTime),
					new SqlParameter("@tag1", SqlDbType.NChar,10),
					new SqlParameter("@tag2", SqlDbType.NChar,10)};
            parameters[0].Value = model.sysCfgName;
            parameters[1].Value = model.cfgFile;
            parameters[2].Value = model.modifyTime;
            parameters[3].Value = model.tag1;
            parameters[4].Value = model.tag2;

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
        public bool Update(CtlDBAccess.Model.SysCfgDBModel model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update SysCfg set ");
            strSql.Append("cfgFile=@cfgFile,");
            strSql.Append("modifyTime=@modifyTime,");
            strSql.Append("tag1=@tag1,");
            strSql.Append("tag2=@tag2");
            strSql.Append(" where sysCfgName=@sysCfgName ");
            SqlParameter[] parameters = {
					new SqlParameter("@cfgFile", SqlDbType.Text),
					new SqlParameter("@modifyTime", SqlDbType.DateTime),
					new SqlParameter("@tag1", SqlDbType.NChar,10),
					new SqlParameter("@tag2", SqlDbType.NChar,10),
					new SqlParameter("@sysCfgName", SqlDbType.NVarChar,50)};
            parameters[0].Value = model.cfgFile;
            parameters[1].Value = model.modifyTime;
            parameters[2].Value = model.tag1;
            parameters[3].Value = model.tag2;
            parameters[4].Value = model.sysCfgName;

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
        public bool Delete(string sysCfgName)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from SysCfg ");
            strSql.Append(" where sysCfgName=@sysCfgName ");
            SqlParameter[] parameters = {
					new SqlParameter("@sysCfgName", SqlDbType.NVarChar,50)			};
            parameters[0].Value = sysCfgName;

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
        public bool DeleteList(string sysCfgNamelist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from SysCfg ");
            strSql.Append(" where sysCfgName in (" + sysCfgNamelist + ")  ");
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
        public CtlDBAccess.Model.SysCfgDBModel GetModel(string sysCfgName)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 sysCfgName,cfgFile,modifyTime,tag1,tag2 from SysCfg ");
            strSql.Append(" where sysCfgName=@sysCfgName ");
            SqlParameter[] parameters = {
					new SqlParameter("@sysCfgName", SqlDbType.NVarChar,50)			};
            parameters[0].Value = sysCfgName;

            CtlDBAccess.Model.SysCfgDBModel model = new CtlDBAccess.Model.SysCfgDBModel();
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
        public CtlDBAccess.Model.SysCfgDBModel DataRowToModel(DataRow row)
        {
            CtlDBAccess.Model.SysCfgDBModel model = new CtlDBAccess.Model.SysCfgDBModel();
            if (row != null)
            {
                if (row["sysCfgName"] != null)
                {
                    model.sysCfgName = row["sysCfgName"].ToString();
                }
                if (row["cfgFile"] != null)
                {
                    model.cfgFile = row["cfgFile"].ToString();
                }
                if (row["modifyTime"] != null && row["modifyTime"].ToString() != "")
                {
                    model.modifyTime = DateTime.Parse(row["modifyTime"].ToString());
                }
                if (row["tag1"] != null)
                {
                    model.tag1 = row["tag1"].ToString();
                }
                if (row["tag2"] != null)
                {
                    model.tag2 = row["tag2"].ToString();
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
            strSql.Append("select sysCfgName,cfgFile,modifyTime,tag1,tag2 ");
            strSql.Append(" FROM SysCfg ");
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
            strSql.Append(" sysCfgName,cfgFile,modifyTime,tag1,tag2 ");
            strSql.Append(" FROM SysCfg ");
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
            strSql.Append("select count(1) FROM SysCfg ");
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
                strSql.Append("order by T.sysCfgName desc");
            }
            strSql.Append(")AS Row, T.*  from SysCfg T ");
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
            parameters[0].Value = "SysCfg";
            parameters[1].Value = "sysCfgName";
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

