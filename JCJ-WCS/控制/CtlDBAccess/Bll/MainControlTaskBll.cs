using System;
using System.Data;
using System.Collections.Generic;
using CtlDBAccess.Model;
namespace CtlDBAccess.BLL
{
    /// <summary>
    /// MainControlTaskModel
    /// </summary>
    public partial class MainControlTaskBll
    {
        private readonly CtlDBAccess.DAL.MainControlTaskDal dal = new CtlDBAccess.DAL.MainControlTaskDal();
        public MainControlTaskBll()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string MainTaskID)
        {
            return dal.Exists(MainTaskID);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(CtlDBAccess.Model.MainControlTaskModel model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(CtlDBAccess.Model.MainControlTaskModel model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(string MainTaskID)
        {

            return dal.Delete(MainTaskID);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string MainTaskIDlist)
        {
            return dal.DeleteList(MainTaskIDlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public CtlDBAccess.Model.MainControlTaskModel GetModel(string MainTaskID)
        {

            return dal.GetModel(MainTaskID);
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
        public List<CtlDBAccess.Model.MainControlTaskModel> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<CtlDBAccess.Model.MainControlTaskModel> DataTableToList(DataTable dt)
        {
            List<CtlDBAccess.Model.MainControlTaskModel> modelList = new List<CtlDBAccess.Model.MainControlTaskModel>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                CtlDBAccess.Model.MainControlTaskModel model;
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
        public List<CtlDBAccess.Model.MainControlTaskModel> GetModelList(string strWhere,string filedOrder)
        {
            DataSet ds = dal.GetList(0,strWhere,filedOrder);
            return DataTableToList(ds.Tables[0]);
        }
        #endregion  ExtensionMethod
    }
}

