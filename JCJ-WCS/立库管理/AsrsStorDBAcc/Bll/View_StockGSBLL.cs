using System;
using System.Data;
using System.Collections.Generic;
 
using AsrsStorDBAcc.Model;
namespace AsrsStorDBAcc.BLL
{
    /// <summary>
    /// View_StockGS
    /// </summary>
    public partial class View_StockGSBLL
    {
        private readonly AsrsStorDBAcc.DAL.View_StockGSDAL dal = new AsrsStorDBAcc.DAL.View_StockGSDAL();
        public View_StockGSBLL()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(long GoodsSiteID, long StoreHouseID, string GoodsSiteName, int GoodsSiteColumn, int GoodsSiteLayer, int GoodsSiteRow, string GoodsSiteTaskStatus, bool GsEnabled, string GoodsSiteType, string GoodsSitePos, string GoodsSiteStatus, string GoodsSiteOperate, string StoreHouseName, string StoreHouseDesc, long StockID, string TrayID, bool IsFull, string StoreHouseAreaName, long StoreHouseLogicAreaID, string StoreHouseAreaDesc)
        {
            return dal.Exists(GoodsSiteID, StoreHouseID, GoodsSiteName, GoodsSiteColumn, GoodsSiteLayer, GoodsSiteRow, GoodsSiteTaskStatus, GsEnabled, GoodsSiteType, GoodsSitePos, GoodsSiteStatus, GoodsSiteOperate, StoreHouseName, StoreHouseDesc, StockID, TrayID, IsFull, StoreHouseAreaName, StoreHouseLogicAreaID, StoreHouseAreaDesc);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(AsrsStorDBAcc.Model.View_StockGSModel model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(AsrsStorDBAcc.Model.View_StockGSModel model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(long GoodsSiteID, long StoreHouseID, string GoodsSiteName, int GoodsSiteColumn, int GoodsSiteLayer, int GoodsSiteRow, string GoodsSiteTaskStatus, bool GsEnabled, string GoodsSiteType, string GoodsSitePos, string GoodsSiteStatus, string GoodsSiteOperate, string StoreHouseName, string StoreHouseDesc, long StockID, string TrayID, bool IsFull, string StoreHouseAreaName, long StoreHouseLogicAreaID, string StoreHouseAreaDesc)
        {

            return dal.Delete(GoodsSiteID, StoreHouseID, GoodsSiteName, GoodsSiteColumn, GoodsSiteLayer, GoodsSiteRow, GoodsSiteTaskStatus, GsEnabled, GoodsSiteType, GoodsSitePos, GoodsSiteStatus, GoodsSiteOperate, StoreHouseName, StoreHouseDesc, StockID, TrayID, IsFull, StoreHouseAreaName, StoreHouseLogicAreaID, StoreHouseAreaDesc);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public AsrsStorDBAcc.Model.View_StockGSModel GetModel(long GoodsSiteID, long StoreHouseID, string GoodsSiteName, int GoodsSiteColumn, int GoodsSiteLayer, int GoodsSiteRow, string GoodsSiteTaskStatus, bool GsEnabled, string GoodsSiteType, string GoodsSitePos, string GoodsSiteStatus, string GoodsSiteOperate, string StoreHouseName, string StoreHouseDesc, long StockID, string TrayID, bool IsFull, string StoreHouseAreaName, long StoreHouseLogicAreaID, string StoreHouseAreaDesc)
        {

            return dal.GetModel(GoodsSiteID, StoreHouseID, GoodsSiteName, GoodsSiteColumn, GoodsSiteLayer, GoodsSiteRow, GoodsSiteTaskStatus, GsEnabled, GoodsSiteType, GoodsSitePos, GoodsSiteStatus, GoodsSiteOperate, StoreHouseName, StoreHouseDesc, StockID, TrayID, IsFull, StoreHouseAreaName, StoreHouseLogicAreaID, StoreHouseAreaDesc);
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
        public List<AsrsStorDBAcc.Model.View_StockGSModel> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<AsrsStorDBAcc.Model.View_StockGSModel> DataTableToList(DataTable dt)
        {
            List<AsrsStorDBAcc.Model.View_StockGSModel> modelList = new List<AsrsStorDBAcc.Model.View_StockGSModel>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                AsrsStorDBAcc.Model.View_StockGSModel model;
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
        public View_StockGSModel GetModelByGSID(long gsID)
        {
            string sqlStr = " GoodsSiteID = " + gsID;
            List<View_StockGSModel> modelList = GetModelList(sqlStr);
            if (modelList != null && modelList.Count > 0)
            {
                return modelList[0];
            }
            else
            {
                return null;
            }
        }
        public View_StockGSModel GetModelByStockID(long stockID)
        {
            string sqlStr = " StockID = " + stockID;
            List<View_StockGSModel> modelList = GetModelList(sqlStr);
            if(modelList!= null&& modelList.Count>0)
            {
                return modelList[0];
            }
            else
            {
                return null;
            }
        }

        public DataTable GetListByCondition(string houseName, string rowth, 
            string colth, string layerth, string gsStatus, string gsTaskSta,string proBatch)
        {
            DataTable dt = dal.GetListByCondition(houseName, rowth, colth, layerth, gsStatus, gsTaskSta, proBatch);
            return dt;
            //string sqlStr = "1=1 ";
            //if (houseName != "所有")
            //{
            //    sqlStr += " and StoreHouseName = '" + houseName + "'";
            //}
            //if (rowth != "所有")
            //{
            //    sqlStr += " and GoodsSiteRow = " + rowth;
            //}
            //if (colth != "所有")
            //{
            //    sqlStr += " and GoodsSiteColumn = " + colth;
            //}
            //if (layerth != "所有")
            //{
            //    sqlStr += " and GoodsSiteLayer = " + layerth;
            //}
            //if (gsStatus != "所有")
            //{
            //    sqlStr += " and GoodsSiteStatus = '" + gsStatus + "'";
            //}
            //if (gsTaskSta != "所有")
            //{
            //    sqlStr += " and GoodsSiteTaskStatus = '" + gsTaskSta + "'";
            //}
            //if(proBatch!= "所有")
            //{
            //    sqlStr += " and MeterialBatch  = '" + proBatch + "'";
            //}
            //return GetModelList(sqlStr);
        }
       
      
        #endregion  ExtensionMethod
    }
}

