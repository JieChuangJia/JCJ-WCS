using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using MesDBAccess.DBUtility;//Please add references
namespace MesDBAccess.DAL
{
    /// <summary>
    /// 数据访问类:ViewProduct_PSModel
    /// </summary>
    public partial class ViewProduct_PSDal
    {
        public ViewProduct_PSDal()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string productID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from ViewProduct_PS");
            strSql.Append(" where productID=@productID ");
            SqlParameter[] parameters = {
					new SqlParameter("@productID", SqlDbType.NVarChar,50)			};
            parameters[0].Value = productID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public MesDBAccess.Model.ViewProduct_PSModel GetModel(string productID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 productID,productCata,processStepID,processSeq,stepCata,processStepName,stationName,cellName,ProcessParam1,ProcessParam2,batchName,palletID,palletBinded,positionSeq,positionRow,positionCol,checkResult,onlineTime,modifyTime from ViewProduct_PS ");
            strSql.Append(" where productID=@productID ");
            SqlParameter[] parameters = {
					new SqlParameter("@productID", SqlDbType.NVarChar,50)			};
            parameters[0].Value = productID;


            MesDBAccess.Model.ViewProduct_PSModel model = new MesDBAccess.Model.ViewProduct_PSModel();
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
        public MesDBAccess.Model.ViewProduct_PSModel DataRowToModel(DataRow row)
        {
            MesDBAccess.Model.ViewProduct_PSModel model = new MesDBAccess.Model.ViewProduct_PSModel();
            if (row != null)
            {
                if (row["productID"] != null)
                {
                    model.productID = row["productID"].ToString();
                }
                if (row["productCata"] != null)
                {
                    model.productCata = row["productCata"].ToString();
                }
                if (row["processStepID"] != null)
                {
                    model.processStepID = row["processStepID"].ToString();
                }
                if (row["processSeq"] != null && row["processSeq"].ToString() != "")
                {
                    model.processSeq = int.Parse(row["processSeq"].ToString());
                }
                if (row["stepCata"] != null)
                {
                    model.stepCata = row["stepCata"].ToString();
                }
                if (row["processStepName"] != null)
                {
                    model.processStepName = row["processStepName"].ToString();
                }
                if (row["stationName"] != null)
                {
                    model.stationName = row["stationName"].ToString();
                }
                if (row["cellName"] != null)
                {
                    model.cellName = row["cellName"].ToString();
                }
                if (row["ProcessParam1"] != null)
                {
                    model.ProcessParam1 = row["ProcessParam1"].ToString();
                }
                if (row["ProcessParam2"] != null)
                {
                    model.ProcessParam2 = row["ProcessParam2"].ToString();
                }
                if (row["batchName"] != null)
                {
                    model.batchName = row["batchName"].ToString();
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
                if (row["positionSeq"] != null)
                {
                    model.positionSeq = row["positionSeq"].ToString();
                }
                if (row["positionRow"] != null)
                {
                    model.positionRow = row["positionRow"].ToString();
                }
                if (row["positionCol"] != null)
                {
                    model.positionCol = row["positionCol"].ToString();
                }
                if (row["checkResult"] != null)
                {
                    model.checkResult = row["checkResult"].ToString();
                }
                if (row["onlineTime"] != null && row["onlineTime"].ToString() != "")
                {
                    model.onlineTime = DateTime.Parse(row["onlineTime"].ToString());
                }
                if (row["modifyTime"] != null && row["modifyTime"].ToString() != "")
                {
                    model.modifyTime = DateTime.Parse(row["modifyTime"].ToString());
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
            strSql.Append("select productID,productCata,processStepID,processSeq,stepCata,processStepName,stationName,cellName,ProcessParam1,ProcessParam2,batchName,palletID,palletBinded,positionSeq,positionRow,positionCol,checkResult,onlineTime,modifyTime ");
            strSql.Append(" FROM ViewProduct_PS ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by CAST(positionSeq as integer)");
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
            strSql.Append(" productID,productCata,processStepID,processSeq,stepCata,processStepName,stationName,cellName,ProcessParam1,ProcessParam2,batchName,palletID,palletBinded,positionSeq,positionRow,positionCol,checkResult,onlineTime,modifyTime ");
            strSql.Append(" FROM ViewProduct_PS ");
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
            strSql.Append("select count(1) FROM ViewProduct_PS ");
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
                strSql.Append("order by T.productID desc");
            }
            strSql.Append(")AS Row, T.*  from ViewProduct_PS T ");
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
            parameters[0].Value = "ViewProduct_PS";
            parameters[1].Value = "productID";
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

