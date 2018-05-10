using System;
using System.Data;
using System.Collections.Generic;
 
using AsrsStorDBAcc.Model;
namespace AsrsStorDBAcc.BLL
{
    /// <summary>
    /// Stock
    /// </summary>
    public partial class StockBLL
    {
        private readonly AsrsStorDBAcc.DAL.StockDAL dal = new AsrsStorDBAcc.DAL.StockDAL();
        public StockBLL()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(long StockID)
        {
            return dal.Exists(StockID);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public long Add(AsrsStorDBAcc.Model.StockModel model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(AsrsStorDBAcc.Model.StockModel model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(long StockID)
        {

            return dal.Delete(StockID);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string StockIDlist)
        {
            return dal.DeleteList(StockIDlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public AsrsStorDBAcc.Model.StockModel GetModel(long StockID)
        {

            return dal.GetModel(StockID);
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
        public List<AsrsStorDBAcc.Model.StockModel> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<AsrsStorDBAcc.Model.StockModel> DataTableToList(DataTable dt)
        {
            List<AsrsStorDBAcc.Model.StockModel> modelList = new List<AsrsStorDBAcc.Model.StockModel>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                AsrsStorDBAcc.Model.StockModel model;
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
        public bool DeleteModelByGSID(long gsID)
        {
            return dal.DeleteModelByGSID(gsID);
        }

        public StockModel GetModelByGSID(long gsID)
        {
            return dal.GetModelByGSID(gsID);
        }
        public bool DeleteAll()
        {
            return dal.DeleteAll();
        }
        public List<StockModel> GetListByCondition(string houseName, string rowth, string colth, string layerth, string gsStatus, string gsTaskSta)
        {
            string sqlStr = "1=1 ";
            if (houseName != "所有")
            {
                sqlStr += " and StoreHouseName = '" + houseName + "'";
            }
            if (rowth != "所有")
            {
                sqlStr += " and GoodsSiteRow = " + rowth;
            }
            if (colth != "所有")
            {
                sqlStr += " and GoodsSiteColumn = " + colth;
            }
            if (layerth != "所有")
            {
                sqlStr += " and GoodsSiteLayer = " + layerth;
            }
            if (gsStatus != "所有")
            {
                sqlStr += " and GoodsSiteStatus = '" + gsStatus + "'";
            }
            if (gsTaskSta != "所有")
            {
                sqlStr += " and GoodsSiteTaskStatus = '" + gsTaskSta + "'";
            }
            return GetModelList(sqlStr);
        }
        #endregion  ExtensionMethod
    }
}

