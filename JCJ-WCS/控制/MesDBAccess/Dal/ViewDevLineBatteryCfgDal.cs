using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using MesDBAccess.DBUtility;//Please add references
namespace MesDBAccess.DAL
{
    /// <summary>
    /// 数据访问类:ViewDevLineBatteryCfgModel
    /// </summary>
    public partial class ViewDevLineBatteryCfgDal
    {
        public ViewDevLineBatteryCfgDal()
        { }
        #region  BasicMethod
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select DevBatteryCfgID,ShopSection,LineID,mark,batteryCataCode,palletCataID,plcDefVal ");
            strSql.Append(" FROM ViewDevLineBatteryCfg ");
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
            strSql.Append(" DevBatteryCfgID,ShopSection,LineID,mark,batteryCataCode,palletCataID,plcDefVal ");
            strSql.Append(" FROM ViewDevLineBatteryCfg ");
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
            strSql.Append("select count(1) FROM ViewDevLineBatteryCfg ");
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
                strSql.Append("order by T.plcDefVal desc");
            }
            strSql.Append(")AS Row, T.*  from ViewDevLineBatteryCfg T ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return DbHelperSQL.Query(strSql.ToString());
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public MesDBAccess.Model.ViewDevLineBatteryCfgModel DataRowToModel(DataRow row)
        {
            MesDBAccess.Model.ViewDevLineBatteryCfgModel model = new MesDBAccess.Model.ViewDevLineBatteryCfgModel();
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
                if (row["mark"] != null)
                {
                    model.mark = row["mark"].ToString();
                }
                if (row["batteryCataCode"] != null)
                {
                    model.batteryCataCode = row["batteryCataCode"].ToString();
                }
                if (row["palletCataID"] != null)
                {
                    model.palletCataID = row["palletCataID"].ToString();
                }
                if (row["plcDefVal"] != null && row["plcDefVal"].ToString() != "")
                {
                    model.plcDefVal = int.Parse(row["plcDefVal"].ToString());
                }
            }
            return model;
        }
        /*
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        {
            SqlParameter[] parameters = {
                    new SqlParameter("SQL2012tblName", SqlDbType.VarChar, 255),
                    new SqlParameter("SQL2012fldName", SqlDbType.VarChar, 255),
                    new SqlParameter("SQL2012PageSize", SqlDbType.Int),
                    new SqlParameter("SQL2012PageIndex", SqlDbType.Int),
                    new SqlParameter("SQL2012IsReCount", SqlDbType.Bit),
                    new SqlParameter("SQL2012OrderType", SqlDbType.Bit),
                    new SqlParameter("SQL2012strWhere", SqlDbType.VarChar,1000),
                    };
            parameters[0].Value = "ViewDevLineBatteryCfg";
            parameters[1].Value = "plcDefVal";
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

