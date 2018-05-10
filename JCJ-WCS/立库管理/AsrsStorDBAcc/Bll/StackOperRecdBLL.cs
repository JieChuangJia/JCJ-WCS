using System;
using System.Data;
using System.Collections.Generic;
 
using AsrsStorDBAcc.Model;
namespace AsrsStorDBAcc.BLL
{
    /// <summary>
    /// GSOperRecord
    /// </summary>
    public partial class StackOperRecdBLL
    {
        private readonly AsrsStorDBAcc.DAL.StackOperRecdDAL dal = new AsrsStorDBAcc.DAL.StackOperRecdDAL();
        public StackOperRecdBLL()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(long StockOperRecdID)
        {
            return dal.Exists(StockOperRecdID);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public long Add(AsrsStorDBAcc.Model.StockOperRecdModel model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(AsrsStorDBAcc.Model.StockOperRecdModel model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(long StockOperRecdID)
        {

            return dal.Delete(StockOperRecdID);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string StockOperRecdIDlist)
        {
            return dal.DeleteList(StockOperRecdIDlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public AsrsStorDBAcc.Model.StockOperRecdModel GetModel(long StockOperRecdID)
        {

            return dal.GetModel(StockOperRecdID);
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
        public List<AsrsStorDBAcc.Model.StockOperRecdModel> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<AsrsStorDBAcc.Model.StockOperRecdModel> DataTableToList(DataTable dt)
        {
            List<AsrsStorDBAcc.Model.StockOperRecdModel> modelList = new List<AsrsStorDBAcc.Model.StockOperRecdModel>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                AsrsStorDBAcc.Model.StockOperRecdModel model;
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
        public bool DeletePreviousData(int days)
        {
            return dal.DeletePreviousData(days);
        }
        #endregion  ExtensionMethod
    }
}

