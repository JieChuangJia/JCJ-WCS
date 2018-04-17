using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using DBAccess.DBUtility;//Please add references
namespace DBAccess.DAL
{
    /// <summary>
    /// 数据访问类:Tb_CheckDataModel
    /// </summary>
    public partial class Tb_CheckDataDal
    {
        public Tb_CheckDataDal()
        { }
        #region  BasicMethod

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string BarCode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Tb_CheckData");
            strSql.Append(" where BarCode=@BarCode ");
            SqlParameter[] parameters = {
					new SqlParameter("@BarCode", SqlDbType.NVarChar,32)			};
            parameters[0].Value = BarCode;

            return DbHelperSQL2.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(DBAccess.Model.Tb_CheckDataModel model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Tb_CheckData(");
            strSql.Append("BarCode,Tf_TrayId,cTray,FileName,fltCapacity,fltVol,fltResistance,tf_CheckGrade,tf_Group,tf_GroupNum,tf_Location,cState,cDate,cStateCode)");
            strSql.Append(" values (");
            strSql.Append("@BarCode,@Tf_TrayId,@cTray,@FileName,@fltCapacity,@fltVol,@fltResistance,@tf_CheckGrade,@tf_Group,@tf_GroupNum,@tf_Location,@cState,@cDate,@cStateCode)");
            SqlParameter[] parameters = {
					new SqlParameter("@BarCode", SqlDbType.NVarChar,32),
					new SqlParameter("@Tf_TrayId", SqlDbType.NVarChar,32),
					new SqlParameter("@cTray", SqlDbType.NVarChar,32),
					new SqlParameter("@FileName", SqlDbType.NVarChar,32),
					new SqlParameter("@fltCapacity", SqlDbType.Float,8),
					new SqlParameter("@fltVol", SqlDbType.Float,8),
					new SqlParameter("@fltResistance", SqlDbType.Float,8),
					new SqlParameter("@tf_CheckGrade", SqlDbType.NVarChar,32),
					new SqlParameter("@tf_Group", SqlDbType.NVarChar,32),
					new SqlParameter("@tf_GroupNum", SqlDbType.Int,4),
					new SqlParameter("@tf_Location", SqlDbType.NVarChar,32),
					new SqlParameter("@cState", SqlDbType.Float,8),
					new SqlParameter("@cDate", SqlDbType.NVarChar,32),
					new SqlParameter("@cStateCode", SqlDbType.NVarChar,32)};
            parameters[0].Value = model.BarCode;
            parameters[1].Value = model.Tf_TrayId;
            parameters[2].Value = model.cTray;
            parameters[3].Value = model.FileName;
            parameters[4].Value = model.fltCapacity;
            parameters[5].Value = model.fltVol;
            parameters[6].Value = model.fltResistance;
            parameters[7].Value = model.tf_CheckGrade;
            parameters[8].Value = model.tf_Group;
            parameters[9].Value = model.tf_GroupNum;
            parameters[10].Value = model.tf_Location;
            parameters[11].Value = model.cState;
            parameters[12].Value = model.cDate;
            parameters[13].Value = model.cStateCode;

            int rows = DbHelperSQL2.ExecuteSql(strSql.ToString(), parameters);
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
        public bool Update(DBAccess.Model.Tb_CheckDataModel model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Tb_CheckData set ");
            strSql.Append("Tf_TrayId=@Tf_TrayId,");
            strSql.Append("cTray=@cTray,");
            strSql.Append("FileName=@FileName,");
            strSql.Append("fltCapacity=@fltCapacity,");
            strSql.Append("fltVol=@fltVol,");
            strSql.Append("fltResistance=@fltResistance,");
            strSql.Append("tf_CheckGrade=@tf_CheckGrade,");
            strSql.Append("tf_Group=@tf_Group,");
            strSql.Append("tf_GroupNum=@tf_GroupNum,");
            strSql.Append("tf_Location=@tf_Location,");
            strSql.Append("cState=@cState,");
            strSql.Append("cDate=@cDate,");
            strSql.Append("cStateCode=@cStateCode");
            strSql.Append(" where BarCode=@BarCode ");
            SqlParameter[] parameters = {
					new SqlParameter("@Tf_TrayId", SqlDbType.NVarChar,32),
					new SqlParameter("@cTray", SqlDbType.NVarChar,32),
					new SqlParameter("@FileName", SqlDbType.NVarChar,32),
					new SqlParameter("@fltCapacity", SqlDbType.Float,8),
					new SqlParameter("@fltVol", SqlDbType.Float,8),
					new SqlParameter("@fltResistance", SqlDbType.Float,8),
					new SqlParameter("@tf_CheckGrade", SqlDbType.NVarChar,32),
					new SqlParameter("@tf_Group", SqlDbType.NVarChar,32),
					new SqlParameter("@tf_GroupNum", SqlDbType.Int,4),
					new SqlParameter("@tf_Location", SqlDbType.NVarChar,32),
					new SqlParameter("@cState", SqlDbType.Float,8),
					new SqlParameter("@cDate", SqlDbType.NVarChar,32),
					new SqlParameter("@cStateCode", SqlDbType.NVarChar,32),
					new SqlParameter("@BarCode", SqlDbType.NVarChar,32)};
            parameters[0].Value = model.Tf_TrayId;
            parameters[1].Value = model.cTray;
            parameters[2].Value = model.FileName;
            parameters[3].Value = model.fltCapacity;
            parameters[4].Value = model.fltVol;
            parameters[5].Value = model.fltResistance;
            parameters[6].Value = model.tf_CheckGrade;
            parameters[7].Value = model.tf_Group;
            parameters[8].Value = model.tf_GroupNum;
            parameters[9].Value = model.tf_Location;
            parameters[10].Value = model.cState;
            parameters[11].Value = model.cDate;
            parameters[12].Value = model.cStateCode;
            parameters[13].Value = model.BarCode;

            int rows = DbHelperSQL2.ExecuteSql(strSql.ToString(), parameters);
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
        public bool Delete(string BarCode)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Tb_CheckData ");
            strSql.Append(" where BarCode=@BarCode ");
            SqlParameter[] parameters = {
					new SqlParameter("@BarCode", SqlDbType.NVarChar,32)			};
            parameters[0].Value = BarCode;

            int rows = DbHelperSQL2.ExecuteSql(strSql.ToString(), parameters);
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
        public bool DeleteList(string BarCodelist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Tb_CheckData ");
            strSql.Append(" where BarCode in (" + BarCodelist + ")  ");
            int rows = DbHelperSQL2.ExecuteSql(strSql.ToString());
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
        public DBAccess.Model.Tb_CheckDataModel GetModel(string BarCode)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 BarCode,Tf_TrayId,cTray,FileName,fltCapacity,fltVol,fltResistance,tf_CheckGrade,tf_Group,tf_GroupNum,tf_Location,cState,cDate,cStateCode from Tb_CheckData ");
            strSql.Append(" where BarCode=@BarCode ");
            SqlParameter[] parameters = {
					new SqlParameter("@BarCode", SqlDbType.NVarChar,32)			};
            parameters[0].Value = BarCode;

            DBAccess.Model.Tb_CheckDataModel model = new DBAccess.Model.Tb_CheckDataModel();
            DataSet ds = DbHelperSQL2.Query(strSql.ToString(), parameters);
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
        public DBAccess.Model.Tb_CheckDataModel DataRowToModel(DataRow row)
        {
            DBAccess.Model.Tb_CheckDataModel model = new DBAccess.Model.Tb_CheckDataModel();
            if (row != null)
            {
                if (row["BarCode"] != null)
                {
                    model.BarCode = row["BarCode"].ToString();
                }
                if (row["Tf_TrayId"] != null)
                {
                    model.Tf_TrayId = row["Tf_TrayId"].ToString();
                }
                if (row["cTray"] != null)
                {
                    model.cTray = row["cTray"].ToString();
                }
                if (row["FileName"] != null)
                {
                    model.FileName = row["FileName"].ToString();
                }
                if (row["fltCapacity"] != null && row["fltCapacity"].ToString() != "")
                {
                    model.fltCapacity = decimal.Parse(row["fltCapacity"].ToString());
                }
                if (row["fltVol"] != null && row["fltVol"].ToString() != "")
                {
                    model.fltVol = decimal.Parse(row["fltVol"].ToString());
                }
                if (row["fltResistance"] != null && row["fltResistance"].ToString() != "")
                {
                    model.fltResistance = decimal.Parse(row["fltResistance"].ToString());
                }
                if (row["tf_CheckGrade"] != null)
                {
                    model.tf_CheckGrade = row["tf_CheckGrade"].ToString();
                }
                if (row["tf_Group"] != null)
                {
                    model.tf_Group = row["tf_Group"].ToString();
                }
                if (row["tf_GroupNum"] != null && row["tf_GroupNum"].ToString() != "")
                {
                    model.tf_GroupNum = int.Parse(row["tf_GroupNum"].ToString());
                }
                if (row["tf_Location"] != null)
                {
                    model.tf_Location = row["tf_Location"].ToString();
                }
                if (row["cState"] != null && row["cState"].ToString() != "")
                {
                    model.cState = decimal.Parse(row["cState"].ToString());
                }
                if (row["cDate"] != null)
                {
                    model.cDate = row["cDate"].ToString();
                }
                if (row["cStateCode"] != null)
                {
                    model.cStateCode = row["cStateCode"].ToString();
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
            strSql.Append("select BarCode,Tf_TrayId,cTray,FileName,fltCapacity,fltVol,fltResistance,tf_CheckGrade,tf_Group,tf_GroupNum,tf_Location,cState,cDate,cStateCode ");
            strSql.Append(" FROM Tb_CheckData ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL2.Query(strSql.ToString());
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
            strSql.Append(" BarCode,Tf_TrayId,cTray,FileName,fltCapacity,fltVol,fltResistance,tf_CheckGrade,tf_Group,tf_GroupNum,tf_Location,cState,cDate,cStateCode ");
            strSql.Append(" FROM Tb_CheckData ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL2.Query(strSql.ToString());
        }

        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM Tb_CheckData ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            object obj = DbHelperSQL2.GetSingle(strSql.ToString());
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }
        #endregion  BasicMethod
        #region  ExtensionMethod

        #endregion  ExtensionMethod
    }
}

