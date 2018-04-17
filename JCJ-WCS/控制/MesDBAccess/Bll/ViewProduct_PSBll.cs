using System;
using System.Data;
using System.Collections.Generic;
using MesDBAccess.Model;
namespace MesDBAccess.BLL
{
    /// <summary>
    /// ViewProduct_PSModel
    /// </summary>
    public partial class ViewProduct_PSBll
    {
        private readonly MesDBAccess.DAL.ViewProduct_PSDal dal = new MesDBAccess.DAL.ViewProduct_PSDal();
        public ViewProduct_PSBll()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string productID)
        {
            return dal.Exists(productID);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public MesDBAccess.Model.ViewProduct_PSModel GetModel(string productID)
        {

            return dal.GetModel(productID);
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
        public List<MesDBAccess.Model.ViewProduct_PSModel> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<MesDBAccess.Model.ViewProduct_PSModel> DataTableToList(DataTable dt)
        {
            List<MesDBAccess.Model.ViewProduct_PSModel> modelList = new List<MesDBAccess.Model.ViewProduct_PSModel>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                MesDBAccess.Model.ViewProduct_PSModel model;
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
        public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            return dal.GetListByPage(strWhere, orderby, startIndex, endIndex);
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
        public MesDBAccess.Model.ViewProduct_PSModel GetFirstProductInPallet(string palletID)
        {
            string strSql = string.Format("palletID='{0}' and palletBinded=1", palletID);
            List<MesDBAccess.Model.ViewProduct_PSModel> ps = GetModelList(strSql);
            if(ps != null && ps.Count>0)
            {
                return ps[0];
            }
            return null;
        }

        #endregion  ExtensionMethod
    }
}

