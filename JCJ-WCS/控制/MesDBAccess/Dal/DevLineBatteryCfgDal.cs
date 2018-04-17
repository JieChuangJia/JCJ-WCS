using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using MesDBAccess.DBUtility;//Please add references
namespace MesDBAccess.DAL
{
    /// <summary>
    /// 数据访问类:DevLineBatteryCfgModel
    /// </summary>
    public partial class DevLineBatteryCfgDal
    {
        public DevLineBatteryCfgDal()
        { }
        #region  Method

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string DevBatteryCfgID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from DevLineBatteryCfg");
            strSql.Append(" where DevBatteryCfgID='" + DevBatteryCfgID + "' ");
            return DbHelperSQL.Exists(strSql.ToString());
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(MesDBAccess.Model.DevLineBatteryCfgModel model)
        {
            StringBuilder strSql = new StringBuilder();
            StringBuilder strSql1 = new StringBuilder();
            StringBuilder strSql2 = new StringBuilder();
            if (model.DevBatteryCfgID != null)
            {
                strSql1.Append("DevBatteryCfgID,");
                strSql2.Append("'" + model.DevBatteryCfgID + "',");
            }
            if (model.ShopSection != null)
            {
                strSql1.Append("ShopSection,");
                strSql2.Append("'" + model.ShopSection + "',");
            }
            if (model.LineID != null)
            {
                strSql1.Append("LineID,");
                strSql2.Append("'" + model.LineID + "',");
            }
            if (model.batteryCataCode != null)
            {
                strSql1.Append("batteryCataCode,");
                strSql2.Append("'" + model.batteryCataCode + "',");
            }
            if (model.mark != null)
            {
                strSql1.Append("mark,");
                strSql2.Append("'" + model.mark + "',");
            }
            if (model.tag1 != null)
            {
                strSql1.Append("tag1,");
                strSql2.Append("'" + model.tag1 + "',");
            }
            if (model.tag2 != null)
            {
                strSql1.Append("tag2,");
                strSql2.Append("'" + model.tag2 + "',");
            }
            if (model.tag3 != null)
            {
                strSql1.Append("tag3,");
                strSql2.Append("'" + model.tag3 + "',");
            }
            if (model.tag4 != null)
            {
                strSql1.Append("tag4,");
                strSql2.Append("'" + model.tag4 + "',");
            }
            if (model.tag5 != null)
            {
                strSql1.Append("tag5,");
                strSql2.Append("'" + model.tag5 + "',");
            }
            strSql.Append("insert into DevLineBatteryCfg(");
            strSql.Append(strSql1.ToString().Remove(strSql1.Length - 1));
            strSql.Append(")");
            strSql.Append(" values (");
            strSql.Append(strSql2.ToString().Remove(strSql2.Length - 1));
            strSql.Append(")");
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
        /// 更新一条数据
        /// </summary>
        public bool Update(MesDBAccess.Model.DevLineBatteryCfgModel model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update DevLineBatteryCfg set ");
            if (model.ShopSection != null)
            {
                strSql.Append("ShopSection='" + model.ShopSection + "',");
            }
            if (model.LineID != null)
            {
                strSql.Append("LineID='" + model.LineID + "',");
            }
            if (model.batteryCataCode != null)
            {
                strSql.Append("batteryCataCode='" + model.batteryCataCode + "',");
            }
            if (model.mark != null)
            {
                strSql.Append("mark='" + model.mark + "',");
            }
            else
            {
                strSql.Append("mark= null ,");
            }
            if (model.tag1 != null)
            {
                strSql.Append("tag1='" + model.tag1 + "',");
            }
            else
            {
                strSql.Append("tag1= null ,");
            }
            if (model.tag2 != null)
            {
                strSql.Append("tag2='" + model.tag2 + "',");
            }
            else
            {
                strSql.Append("tag2= null ,");
            }
            if (model.tag3 != null)
            {
                strSql.Append("tag3='" + model.tag3 + "',");
            }
            else
            {
                strSql.Append("tag3= null ,");
            }
            if (model.tag4 != null)
            {
                strSql.Append("tag4='" + model.tag4 + "',");
            }
            else
            {
                strSql.Append("tag4= null ,");
            }
            if (model.tag5 != null)
            {
                strSql.Append("tag5='" + model.tag5 + "',");
            }
            else
            {
                strSql.Append("tag5= null ,");
            }
            int n = strSql.ToString().LastIndexOf(",");
            strSql.Remove(n, 1);
            strSql.Append(" where DevBatteryCfgID='" + model.DevBatteryCfgID + "' ");
            int rowsAffected = DbHelperSQL.ExecuteSql(strSql.ToString());
            if (rowsAffected > 0)
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
        public bool Delete(string DevBatteryCfgID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from DevLineBatteryCfg ");
            strSql.Append(" where DevBatteryCfgID='" + DevBatteryCfgID + "' ");
            int rowsAffected = DbHelperSQL.ExecuteSql(strSql.ToString());
            if (rowsAffected > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }		/// <summary>
        /// 批量删除数据
        /// </summary>
        public bool DeleteList(string DevBatteryCfgIDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from DevLineBatteryCfg ");
            strSql.Append(" where DevBatteryCfgID in (" + DevBatteryCfgIDlist + ")  ");
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
        public MesDBAccess.Model.DevLineBatteryCfgModel GetModel(string DevBatteryCfgID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1  ");
            strSql.Append(" DevBatteryCfgID,ShopSection,LineID,batteryCataCode,mark,tag1,tag2,tag3,tag4,tag5 ");
            strSql.Append(" from DevLineBatteryCfg ");
            strSql.Append(" where DevBatteryCfgID='" + DevBatteryCfgID + "' ");
            MesDBAccess.Model.DevLineBatteryCfgModel model = new MesDBAccess.Model.DevLineBatteryCfgModel();
            DataSet ds = DbHelperSQL.Query(strSql.ToString());
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
        public MesDBAccess.Model.DevLineBatteryCfgModel DataRowToModel(DataRow row)
        {
            MesDBAccess.Model.DevLineBatteryCfgModel model = new MesDBAccess.Model.DevLineBatteryCfgModel();
            if (row != null)
            {
                if (row["DevBatteryCfgID"] != null)
                {
                    model.DevBatteryCfgID = row["DevBatteryCfgID"].ToString();
                }
                if (row["ShopSection"] != null)
                {
                    model.ShopSection = row["ShopSection"].ToString();
                }
                if (row["LineID"] != null)
                {
                    model.LineID = row["LineID"].ToString();
                }
                if (row["batteryCataCode"] != null)
                {
                    model.batteryCataCode = row["batteryCataCode"].ToString();
                }
                if (row["mark"] != null)
                {
                    model.mark = row["mark"].ToString();
                }
                if (row["tag1"] != null)
                {
                    model.tag1 = row["tag1"].ToString();
                }
                if (row["tag2"] != null)
                {
                    model.tag2 = row["tag2"].ToString();
                }
                if (row["tag3"] != null)
                {
                    model.tag3 = row["tag3"].ToString();
                }
                if (row["tag4"] != null)
                {
                    model.tag4 = row["tag4"].ToString();
                }
                if (row["tag5"] != null)
                {
                    model.tag5 = row["tag5"].ToString();
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
            strSql.Append("select DevBatteryCfgID,ShopSection,LineID,batteryCataCode,mark,tag1,tag2,tag3,tag4,tag5 ");
            strSql.Append(" FROM DevLineBatteryCfg ");
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
            strSql.Append(" DevBatteryCfgID,ShopSection,LineID,batteryCataCode,mark,tag1,tag2,tag3,tag4,tag5 ");
            strSql.Append(" FROM DevLineBatteryCfg ");
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
            strSql.Append("select count(1) FROM DevLineBatteryCfg ");
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
                strSql.Append("order by T.DevBatteryCfgID desc");
            }
            strSql.Append(")AS Row, T.*  from DevLineBatteryCfg T ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return DbHelperSQL.Query(strSql.ToString());
        }

        /*
        */

        #endregion  Method
        #region  MethodEx

        #endregion  MethodEx
    }
}

