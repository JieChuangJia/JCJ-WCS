using System;
using System.Data;
using System.Collections.Generic;
using CtlDBAccess.Model;
namespace CtlDBAccess.BLL
{
    /// <summary>
    /// SysCfgModel
    /// </summary>
    public partial class SysCfgBll
    {
        private readonly CtlDBAccess.DAL.SysCfgDal dal = new CtlDBAccess.DAL.SysCfgDal();
        public SysCfgBll()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string sysCfgName)
        {
            return dal.Exists(sysCfgName);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(CtlDBAccess.Model.SysCfgDBModel model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(CtlDBAccess.Model.SysCfgDBModel model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(string sysCfgName)
        {

            return dal.Delete(sysCfgName);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string sysCfgNamelist)
        {
            return dal.DeleteList(sysCfgNamelist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public CtlDBAccess.Model.SysCfgDBModel GetModel(string sysCfgName)
        {

            return dal.GetModel(sysCfgName);
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
        public List<CtlDBAccess.Model.SysCfgDBModel> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<CtlDBAccess.Model.SysCfgDBModel> DataTableToList(DataTable dt)
        {
            List<CtlDBAccess.Model.SysCfgDBModel> modelList = new List<CtlDBAccess.Model.SysCfgDBModel>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                CtlDBAccess.Model.SysCfgDBModel model;
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

        #endregion  ExtensionMethod
    }
}

