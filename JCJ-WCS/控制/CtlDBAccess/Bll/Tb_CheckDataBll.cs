using System;
using System.Data;
using System.Collections.Generic;
using DBAccess.Model;
namespace DBAccess.BLL
{
    /// <summary>
    /// Tb_CheckDataModel
    /// </summary>
    public partial class Tb_CheckDataBll
    {
        private readonly DBAccess.DAL.Tb_CheckDataDal dal = new DBAccess.DAL.Tb_CheckDataDal();
        public Tb_CheckDataBll()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string BarCode)
        {
            return dal.Exists(BarCode);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(DBAccess.Model.Tb_CheckDataModel model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(DBAccess.Model.Tb_CheckDataModel model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(string BarCode)
        {

            return dal.Delete(BarCode);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string BarCodelist)
        {
            return dal.DeleteList(BarCodelist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public DBAccess.Model.Tb_CheckDataModel GetModel(string BarCode)
        {

            return dal.GetModel(BarCode);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            return dal.GetList(Top, strWhere, filedOrder);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<DBAccess.Model.Tb_CheckDataModel> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<DBAccess.Model.Tb_CheckDataModel> DataTableToList(DataTable dt)
        {
            List<DBAccess.Model.Tb_CheckDataModel> modelList = new List<DBAccess.Model.Tb_CheckDataModel>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                DBAccess.Model.Tb_CheckDataModel model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = dal.DataRowToModel(dt.Rows[n]);
                    if (model != null)
                    {
                        modelList.Add(model);
                    }
                }
            }
            return modelList;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetAllList()
        {
            return GetList("");
        }

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            return dal.GetRecordCount(strWhere);
        }
      
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        //public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        //{
        //return dal.GetList(PageSize,PageIndex,strWhere);
        //}

        #endregion  BasicMethod
        #region  ExtensionMethod

        #endregion  ExtensionMethod
    }
}

