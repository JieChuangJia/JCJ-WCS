using System;
using System.Data;
using System.Collections.Generic;
 
using AsrsStorDBAcc.Model;
namespace AsrsStorDBAcc.BLL
{
    /// <summary>
    /// View_StockOperate
    /// </summary>
    public partial class View_StockOperateBLL
    {
        private readonly AsrsStorDBAcc.DAL.View_StockOperateDAL dal = new AsrsStorDBAcc.DAL.View_StockOperateDAL();
        public View_StockOperateBLL()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(long StockOperRecdID, long StoreHouseID, string GoodsSitePos, string OPerateType, string OperateDetail, DateTime OPerateTime, string StoreHouseName, string StoreHouseDesc)
        {
            return dal.Exists(StockOperRecdID, StoreHouseID, GoodsSitePos, OPerateType, OperateDetail, OPerateTime, StoreHouseName, StoreHouseDesc);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(AsrsStorDBAcc.Model.View_StockOperateModel model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(AsrsStorDBAcc.Model.View_StockOperateModel model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(long StockOperRecdID, long StoreHouseID, string GoodsSitePos, string OPerateType, string OperateDetail, DateTime OPerateTime, string StoreHouseName, string StoreHouseDesc)
        {

            return dal.Delete(StockOperRecdID, StoreHouseID, GoodsSitePos, OPerateType, OperateDetail, OPerateTime, StoreHouseName, StoreHouseDesc);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public AsrsStorDBAcc.Model.View_StockOperateModel GetModel(long StockOperRecdID, long StoreHouseID, string GoodsSitePos, string OPerateType, string OperateDetail, DateTime OPerateTime, string StoreHouseName, string StoreHouseDesc)
        {

            return dal.GetModel(StockOperRecdID, StoreHouseID, GoodsSitePos, OPerateType, OperateDetail, OPerateTime, StoreHouseName, StoreHouseDesc);
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
        public List<AsrsStorDBAcc.Model.View_StockOperateModel> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<AsrsStorDBAcc.Model.View_StockOperateModel> DataTableToList(DataTable dt)
        {
            List<AsrsStorDBAcc.Model.View_StockOperateModel> modelList = new List<AsrsStorDBAcc.Model.View_StockOperateModel>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                AsrsStorDBAcc.Model.View_StockOperateModel model;
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
        public DataTable GetQueryData(DateTime startTime,DateTime endTime
            ,bool gsChcked,string gsValue,bool likeQueryChecked,string likeQuery ,string batchStr,string operateType,string houseName)
        {
            return dal.GetQueryData(startTime, endTime, gsChcked, gsValue, likeQueryChecked, likeQuery,batchStr, operateType,houseName);
        }
        #endregion  ExtensionMethod
    }
}

