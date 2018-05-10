using System;
using System.Data;
using System.Collections.Generic;
 
using AsrsStorDBAcc.Model;
namespace AsrsStorDBAcc.BLL
{
    /// <summary>
    /// View_Stock
    /// </summary>
    public partial class View_StockBLL
    {
        private readonly AsrsStorDBAcc.DAL.View_StockDAL dal = new AsrsStorDBAcc.DAL.View_StockDAL();
        public View_StockBLL()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(long StoreHouseID, long GoodsSiteID, string GoodsSiteName, int GoodsSiteLayer, int GoodsSiteColumn, string StoreHouseName, string StoreHouseDesc, int GoodsSiteRow, string GoodsSiteTaskStatus, string GoodsSiteType, string GoodsSitePos, string GoodsSiteStatus, string GoodsSiteOperate, long StockID, string TrayID, bool IsFull, DateTime InHouseTime, string MeterialboxCode, string MeterialBatch, string MeterialStatus, long StockListID, bool GsEnabled, long StoreHouseLogicAreaID, string StoreHouseAreaName, string StoreHouseAreaDesc, string GoodsSite_Reserve)
        {
            return dal.Exists(StoreHouseID, GoodsSiteID, GoodsSiteName, GoodsSiteLayer, GoodsSiteColumn, StoreHouseName, StoreHouseDesc, GoodsSiteRow, GoodsSiteTaskStatus, GoodsSiteType, GoodsSitePos, GoodsSiteStatus, GoodsSiteOperate, StockID, TrayID, IsFull, InHouseTime, MeterialboxCode, MeterialBatch, MeterialStatus, StockListID, GsEnabled, StoreHouseLogicAreaID, StoreHouseAreaName, StoreHouseAreaDesc, GoodsSite_Reserve);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(AsrsStorDBAcc.Model.View_StockModel model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(AsrsStorDBAcc.Model.View_StockModel model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(long StoreHouseID, long GoodsSiteID, string GoodsSiteName, int GoodsSiteLayer, int GoodsSiteColumn, string StoreHouseName, string StoreHouseDesc, int GoodsSiteRow, string GoodsSiteTaskStatus, string GoodsSiteType, string GoodsSitePos, string GoodsSiteStatus, string GoodsSiteOperate, long StockID, string TrayID, bool IsFull, DateTime InHouseTime, string MeterialboxCode, string MeterialBatch, string MeterialStatus, long StockListID, bool GsEnabled, long StoreHouseLogicAreaID, string StoreHouseAreaName, string StoreHouseAreaDesc, string GoodsSite_Reserve)
        {

            return dal.Delete(StoreHouseID, GoodsSiteID, GoodsSiteName, GoodsSiteLayer, GoodsSiteColumn, StoreHouseName, StoreHouseDesc, GoodsSiteRow, GoodsSiteTaskStatus, GoodsSiteType, GoodsSitePos, GoodsSiteStatus, GoodsSiteOperate, StockID, TrayID, IsFull, InHouseTime, MeterialboxCode, MeterialBatch, MeterialStatus, StockListID, GsEnabled, StoreHouseLogicAreaID, StoreHouseAreaName, StoreHouseAreaDesc, GoodsSite_Reserve);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public AsrsStorDBAcc.Model.View_StockModel GetModel(long StoreHouseID, long GoodsSiteID, string GoodsSiteName, int GoodsSiteLayer, int GoodsSiteColumn, string StoreHouseName, string StoreHouseDesc, int GoodsSiteRow, string GoodsSiteTaskStatus, string GoodsSiteType, string GoodsSitePos, string GoodsSiteStatus, string GoodsSiteOperate, long StockID, string TrayID, bool IsFull, DateTime InHouseTime, string MeterialboxCode, string MeterialBatch, string MeterialStatus, long StockListID, bool GsEnabled, long StoreHouseLogicAreaID, string StoreHouseAreaName, string StoreHouseAreaDesc, string GoodsSite_Reserve)
        {

            return dal.GetModel(StoreHouseID, GoodsSiteID, GoodsSiteName, GoodsSiteLayer, GoodsSiteColumn, StoreHouseName, StoreHouseDesc, GoodsSiteRow, GoodsSiteTaskStatus, GoodsSiteType, GoodsSitePos, GoodsSiteStatus, GoodsSiteOperate, StockID, TrayID, IsFull, InHouseTime, MeterialboxCode, MeterialBatch, MeterialStatus, StockListID, GsEnabled, StoreHouseLogicAreaID, StoreHouseAreaName, StoreHouseAreaDesc, GoodsSite_Reserve);
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
        public List<AsrsStorDBAcc.Model.View_StockModel> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<AsrsStorDBAcc.Model.View_StockModel> DataTableToList(DataTable dt)
        {
            List<AsrsStorDBAcc.Model.View_StockModel> modelList = new List<AsrsStorDBAcc.Model.View_StockModel>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                AsrsStorDBAcc.Model.View_StockModel model;
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
        public List<View_StockModel> GetModelListByGSID(long gsID)
        {
            string sqlStr = "GoodsSiteID = " + gsID;
            List<View_StockModel> viewList = GetModelList(sqlStr);
            return viewList;
        }
      
        public List<View_StockModel> GetStockDetail(string houseName,int rowth,int colth,int layerth)
        {
            string sqlStr = " StoreHouseName ='" + houseName + "' and GoodsSiteRow = " + rowth + " and GoodsSiteColumn =" 
                + colth + " and GoodsSiteLayer = "+ layerth;
            List<View_StockModel> viewList = GetModelList(sqlStr);
            return viewList;
        }
        public View_StockModel GetModelByStockListID(long stockListID)
        {
            string sqlStr = "StockListID = '" + stockListID + "'";
            List<View_StockModel> viewList = GetModelList(sqlStr);
            if (viewList != null && viewList.Count > 0)
            {
                return viewList[0];
            }
            else
            {
                return null;
            }
        }
        public View_StockModel GetModelByBoxCode(string boxCode)
        {
            string sqlStr = "MeterialboxCode = '" + boxCode + "'";
            List<View_StockModel> viewList = GetModelList(sqlStr);
            if (viewList != null && viewList.Count > 0)
            {
                return viewList[0];
            }
            else
            {
                return null;
            }
        }

        public View_StockModel GetModel(string houseName,string boxCode)
        {
            string sqlStr = "MeterialboxCode = '" + boxCode + "' and StoreHouseName = '" + houseName + "'";
            List<View_StockModel> viewList = GetModelList(sqlStr);
            if (viewList != null && viewList.Count > 0)
            {
                return viewList[0];
            }
            else
            {
                return null;
            }
        }
        public List<string> GetAllBatches(string houseName)
        {
            return dal.GetAllBatches(houseName);
        }
        public List<string> GetBatches(long houseID,long houseAreaID)
        {
            return dal.GetBatches(houseID, houseAreaID);
        }
        public DataTable GetData(string houseName,string houseArea, string rowth,
             string colth, string layerth, string gsStatus, string gsTaskSta, string proBatch,bool isChecked,string materialBoxCode)
        {
            return dal.GetData(houseName, houseArea, rowth, colth, layerth, gsStatus, gsTaskSta, proBatch,isChecked, materialBoxCode);
        }
        #endregion  ExtensionMethod
    }
}

