using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using CtlDBAccess.Model;
using CtlDBAccess.DBUtility;//Please add references
namespace CtlDBAccess.DAL
{
    /// <summary>
    /// 数据访问类:User_ListModel
    /// </summary>
    public partial class User_ListDal
    {
        public User_ListDal()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string UserName)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from User_List");
            strSql.Append(" where UserName=@UserName ");
            SqlParameter[] parameters = {
					new SqlParameter("@UserName", SqlDbType.NVarChar,50)			};
            parameters[0].Value = UserName;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(CtlDBAccess.Model.User_ListModel model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into User_List(");
            strSql.Append("UserName,UserPassWord,RoleID)");
            strSql.Append(" values (");
            strSql.Append("@UserName,@UserPassWord,@RoleID)");
            SqlParameter[] parameters = {
					new SqlParameter("@UserName", SqlDbType.NVarChar,50),
					new SqlParameter("@UserPassWord", SqlDbType.NVarChar,50),
					new SqlParameter("@RoleID", SqlDbType.Int,4)};
            parameters[0].Value = model.UserName;
            parameters[1].Value = model.UserPassWord;
            parameters[2].Value = model.RoleID;

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
        public bool Update(CtlDBAccess.Model.User_ListModel model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update User_List set ");
            strSql.Append("UserPassWord=@UserPassWord,");
            strSql.Append("RoleID=@RoleID");
            strSql.Append(" where UserName=@UserName ");
            SqlParameter[] parameters = {
					new SqlParameter("@UserPassWord", SqlDbType.NVarChar,50),
					new SqlParameter("@RoleID", SqlDbType.Int,4),
					new SqlParameter("@UserID", SqlDbType.Int,4),
					new SqlParameter("@UserName", SqlDbType.NVarChar,50)};
            parameters[0].Value = model.UserPassWord;
            parameters[1].Value = model.RoleID;
            parameters[2].Value = model.UserID;
            parameters[3].Value = model.UserName;

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
        public bool Delete(string UserName)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from User_List ");
            strSql.Append(" where UserName=@UserName ");
            SqlParameter[] parameters = {
					new SqlParameter("@UserName", SqlDbType.NVarChar,50)			};
            parameters[0].Value = UserName;

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
        public bool DeleteList(string UserNamelist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from User_List ");
            strSql.Append(" where UserName in (" + UserNamelist + ")  ");
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
        public CtlDBAccess.Model.User_ListModel GetModel(string UserName)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 UserID,UserName,UserPassWord,RoleID from User_List ");
            strSql.Append(" where UserName=@UserName ");
            SqlParameter[] parameters = {
					new SqlParameter("@UserName", SqlDbType.NVarChar,50)			};
            parameters[0].Value = UserName;

            CtlDBAccess.Model.User_ListModel model = new CtlDBAccess.Model.User_ListModel();
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
        public CtlDBAccess.Model.User_ListModel DataRowToModel(DataRow row)
        {
            CtlDBAccess.Model.User_ListModel model = new CtlDBAccess.Model.User_ListModel();
            if (row != null)
            {
                if (row["UserID"] != null && row["UserID"].ToString() != "")
                {
                    model.UserID = int.Parse(row["UserID"].ToString());
                }
                if (row["UserName"] != null)
                {
                    model.UserName = row["UserName"].ToString();
                }
                if (row["UserPassWord"] != null)
                {
                    model.UserPassWord = row["UserPassWord"].ToString();
                }
                if (row["RoleID"] != null && row["RoleID"].ToString() != "")
                {
                    model.RoleID = int.Parse(row["RoleID"].ToString());
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
            strSql.Append("select UserID,UserName,UserPassWord,RoleID ");
            strSql.Append(" FROM User_List ");
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
            strSql.Append(" UserID,UserName,UserPassWord,RoleID ");
            strSql.Append(" FROM User_List ");
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
            strSql.Append("select count(1) FROM User_List ");
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
                strSql.Append("order by T.UserName desc");
            }
            strSql.Append(")AS Row, T.*  from User_List T ");
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
            parameters[0].Value = "User_List";
            parameters[1].Value = "UserName";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;	
            return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
        }*/

        #endregion  BasicMethod
        #region  ExtensionMethod
        public bool IsUserRegister(int roleID, string userName, string password)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from User_List");
            strSql.Append(" where RoleID=@RoleID");
            strSql.Append(" and UserName=@UserName");
            strSql.Append(" and UserPassWord=@UserPassWord");
            SqlParameter[] parameters = {
					new SqlParameter("@RoleID", SqlDbType.Int,4),
                    new SqlParameter("@UserName", SqlDbType.NVarChar,50),
                    new SqlParameter("@UserPassWord", SqlDbType.NVarChar,50)
			};
            parameters[0].Value = roleID;
            parameters[1].Value = userName;
            parameters[2].Value = password;
            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }
        #endregion  ExtensionMethod
    }
}

