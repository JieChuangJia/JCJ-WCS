using System;
using System.Data;
using System.Collections.Generic;

using AsrsStorDBAcc.Model;
using AsrsModel;
namespace AsrsStorDBAcc.BLL
{
    /// <summary>
    /// 货位信息表
    /// </summary>
    public partial class GoodsSiteBLL
    {
        private readonly AsrsStorDBAcc.DAL.GoodsSiteDAL dal = new AsrsStorDBAcc.DAL.GoodsSiteDAL();
        //private View_GoodsSiteBLL bllViewGs = new View_GoodsSiteBLL();
        private StoreHouseBLL bllStoreHouse = new StoreHouseBLL();
        public GoodsSiteBLL()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(long GoodsSiteID)
        {
            return dal.Exists(GoodsSiteID);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public long Add(AsrsStorDBAcc.Model.GoodsSiteModel model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(AsrsStorDBAcc.Model.GoodsSiteModel model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(long GoodsSiteID)
        {

            return dal.Delete(GoodsSiteID);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string GoodsSiteIDlist)
        {
            return dal.DeleteList(GoodsSiteIDlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public AsrsStorDBAcc.Model.GoodsSiteModel GetModel(long GoodsSiteID)
        {

            return dal.GetModel(GoodsSiteID);
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
        public List<AsrsStorDBAcc.Model.GoodsSiteModel> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<AsrsStorDBAcc.Model.GoodsSiteModel> DataTableToList(DataTable dt)
        {
            List<AsrsStorDBAcc.Model.GoodsSiteModel> modelList = new List<AsrsStorDBAcc.Model.GoodsSiteModel>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                AsrsStorDBAcc.Model.GoodsSiteModel model;
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
        
        /// <summary>
        /// 从第一排第一列第一层开始查找
        /// </summary>
        /// <param name="logicAreaID">逻辑区域ID</param>
        /// <param name="gsStoreStatus">存储状态</param>
        /// <param name="gsType">货位类型</param>
        /// <returns></returns>
        public GoodsSiteModel ApplyGoodsSite(long storeHouseID,long? storeLogicAreaID )
        {
            GoodsSiteModel goodsSite = null;
            string wereStr = "";
            if (storeLogicAreaID == null)//没有分区
            {
                wereStr = "StoreHouseID=" + storeHouseID + " and GoodsSiteStatus ='"
                    + EnumCellStatus.空闲.ToString() + "'and GoodsSiteTaskStatus ='"
                    + EnumGSTaskStatus.完成.ToString() + "' and GsEnabled =1 order by GoodsSiteColumn asc,"
                    + "GoodsSiteRow asc,GoodsSiteLayer asc";
            }
            else
            {
                wereStr = "StoreHouseID=" + storeHouseID + "and StoreHouseLogicAreaID=" + storeLogicAreaID + " and GoodsSiteStatus ='"
                    + EnumCellStatus.空闲.ToString() + "'and GoodsSiteTaskStatus ='"
                    + EnumGSTaskStatus.完成.ToString() + "' and GsEnabled =1 order by GoodsSiteColumn asc,"
                    + "GoodsSiteRow asc,GoodsSiteLayer asc";
            }
        
            List<AsrsStorDBAcc.Model.GoodsSiteModel > goodsSiteList = GetModelList(wereStr);
            if (goodsSiteList.Count > 0)
            {
                goodsSite = goodsSiteList[0];
            }
         
            return goodsSite;
        }
        public GoodsSiteModel GetModelByRCL(long storeHouseID,int row,int col,int layer)
        {
            GoodsSiteModel goodsSite = null;

            string sqlStr = "StoreHouseID = " + storeHouseID + " and GoodsSiteColumn = " + col + " and GoodsSiteRow ="
                + row + " and GoodsSiteLayer =" + layer;

            List<AsrsStorDBAcc.Model.GoodsSiteModel> goodsSiteList = GetModelList(sqlStr);
            if (goodsSiteList.Count > 0)
            {
                goodsSite = goodsSiteList[0];
            }
            return goodsSite;
        }
        public GoodsSiteModel GetModelByRCL_ExtProp(long storeHouseID, int row, int col, int layer,string extProp)
        {
            GoodsSiteModel goodsSite = null;

            string sqlStr = "StoreHouseID = " + storeHouseID + " and GoodsSiteColumn = " + col + " and GoodsSiteRow ="
                + row + " and GoodsSiteLayer =" + layer + " and Reserve = '" +extProp + "'";

            List<AsrsStorDBAcc.Model.GoodsSiteModel> goodsSiteList = GetModelList(sqlStr);
            if (goodsSiteList.Count > 0)
            {
                goodsSite = goodsSiteList[0];
            }
            return goodsSite;
        }



        public List<GoodsSiteModel> GetModelListByRow(long storeHouseID,int row)
        {
            string sqlStr = "StoreHouseID = " + storeHouseID + " and GoodsSiteRow = " + row;

            List<AsrsStorDBAcc.Model.GoodsSiteModel> goodsSiteList = GetModelList(sqlStr);
            return goodsSiteList;
        }
        public GoodsSiteModel GetOutHouseGSByRCL(long storeHouseID,int row,int col,int layer)
        {
            GoodsSiteModel goodsSite = null;

            string sqlStr = "StoreHouseID = " + storeHouseID + " and GoodsSiteColumn = " + col + " and GoodsSiteRow ="
                + row + " and GoodsSiteLayer =" + layer + " and GoodsSiteStatus = '"+ EnumCellStatus.满位.ToString()+"'";

            List<AsrsStorDBAcc.Model.GoodsSiteModel> goodsSiteList = GetModelList(sqlStr);
            if (goodsSiteList.Count > 0)
            {
                goodsSite = goodsSiteList[0];
            }
            return goodsSite;
        }
        /// <summary>
        /// 通过库房名称及排列层更新货位
        /// </summary>
        /// <param name="houseName"></param>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <param name="layer"></param>
        /// <param name="cellStatus"></param>
        /// <returns></returns>
        public bool UpdateModelByRCL(string houseName,int row,int col,int layer,EnumCellStatus cellStatus,EnumGSTaskStatus gsStatus)
        {

           // View_GoodsSiteModel gsModel =  bllViewGs.GetModelByHouseName(houseName);
            StoreHouseModel house = bllStoreHouse.GetModelByName(houseName);
            if(house == null)
            {
                return false;
            }

            return dal.UpdateModelByRCL(houseName, house.StoreHouseID, row, col, layer, cellStatus.ToString(), gsStatus.ToString());
         
        }
        public bool UpdateGsTaskStatusByRCL(string houseName,int row,int col,int layer,EnumGSTaskStatus gsTaskStatus)
        {
            StoreHouseModel house = bllStoreHouse.GetModelByName(houseName);
            if (house == null)
            {
                return false;
            }
            GoodsSiteModel gsm = GetModelByRCL(house.StoreHouseID, row, col, layer);
            if (gsm == null)
            {
                return false;
            }
            gsm.GoodsSiteTaskStatus = gsTaskStatus.ToString();
            return Update(gsm);
        }
        public bool UpdateGSStatusByRCL(string houseName,int row,int col,int layer,EnumCellStatus cellStatus)
        {
            StoreHouseModel house = bllStoreHouse.GetModelByName(houseName);
            if (house == null)
            {
                return false;
            }
             GoodsSiteModel gsm = GetModelByRCL(house.StoreHouseID, row,col,layer);
             if (gsm == null)
             {
                 return false;
             }
             gsm.GoodsSiteStatus = cellStatus.ToString();
             return  Update(gsm);
        }
        public bool UpdateOperateByRCL(string houseName, int row, int col, int layer,EnumGSOperate operate)
        {
            StoreHouseModel house = bllStoreHouse.GetModelByName(houseName);
            if (house == null)
            {
                return false;
            }

            return dal.UpdateOperateByRCL(houseName, house.StoreHouseID, row, col, layer, operate.ToString());
        }

      
        public bool UpdateGSEnabledStatusByID(long gsID,bool status)
        {
            GoodsSiteModel gsm = GetModel(gsID);
            if(gsm==null)
            {
                return false;
            }
            gsm.GsEnabled = status;
            return Update(gsm);
        }

        public bool DeleteUnnecessaryGs(string houseName,int totalRow,int totalCol,int totalLayer)
        {
            StoreHouseModel house = bllStoreHouse.GetModelByName(houseName);
            if (house == null)
            {
                return false;
            }
            return dal.DeleteUnnecessaryGs(house.StoreHouseID, totalRow, totalCol, totalLayer);
        }
        public bool DeleteModelByRCL(string houseName,int row,int col,int layer)
        {
            StoreHouseModel house = bllStoreHouse.GetModelByName(houseName);
        
            if (house == null)
            {
                return false;
            }
            return dal.DeleteModelByRCL(houseName, house.StoreHouseID, row, col, layer);
        }
        /// <summary>
        /// 当货位没有创建才创建，已经创建的就不再创建了
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool AddModelUntilRemove(GoodsSiteModel model)
        {
            if(model == null)
            {
                return false;
            }

            GoodsSiteModel gsm = GetModelByRCL(model.StoreHouseID, model.GoodsSiteRow, model.GoodsSiteColumn, model.GoodsSiteLayer);
            if(gsm==null)
            {
                Add(model);
            }
            return true;
        }
        public bool SetMultiGsSinleColEnbledStatus(string houseName,int rowth,int colth,bool status)
        { 
            StoreHouseModel house = bllStoreHouse.GetModelByName(houseName);
            if (house == null)
            {
                return false;
            }
            return dal.SetMultiGsSinleColEnbledStatus(house.StoreHouseID, rowth, colth, status);
        }
        public bool SetMultiGsSinleLayerEnbledStatus(string houseName, int rowth, int layerth, bool status)
        {
            StoreHouseModel house = bllStoreHouse.GetModelByName(houseName);
            if (house == null)
            {
                return false;
            }
            return dal.SetMultiGsSinleLayerEnbledStatus(house.StoreHouseID, rowth, layerth, status);
        }
        public bool SetMultiGsSinleGsEnbledStatus(string houseName,string gsName,bool status)
        {
            StoreHouseModel house = bllStoreHouse.GetModelByName(houseName);
            if (house == null)
            {
                return false;
            }
            return dal.SetMultiGsSinleGsEnbledStatus(house.StoreHouseID, gsName, status);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="houseName">库房名称</param>
        /// <param name="cate">0：查询排数量；1：查询列数量；2：查询层数量</param>
        /// <returns></returns>
        public List<int> GetGsRCLData(long houseID, int cate)
        {
            List<int> data = new List<int>();
            string sqlStr = "select distinct";
            if (0 == cate)// 获取排数量
            {
                sqlStr += " GoodsSiteRow from GoodsSite";
            }
            else if (1 == cate)// 获取列数量
            {
                sqlStr += " GoodsSiteColumn from GoodsSite";
            }
            else if (2 == cate)// 获取层数量
            {
                sqlStr += " GoodsSiteLayer from GoodsSite";
            }
            else
            {
                return null;
            }
            sqlStr += " where StoreHouseID = " + houseID;
            DataSet ds = DbHelperSQL.Query(sqlStr);
            if (ds != null && ds.Tables.Count > 0)
            {

                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    int rowth = int.Parse(ds.Tables[0].Rows[i][0].ToString());
                    data.Add(rowth);
                }
            }
            else
            {
                return null;
            }
            data.Sort();
            return data;
        }
        //public int GetStatusNum(long houseID, int rowth, EnumCellStatus cellstatus)
        //{
        //    return dal.GetGSStatusCount(houseID, rowth, cellstatus.ToString());
        //}
        public int GetNullBoxCount(long houseID, int rowth)
        {
            return dal.GetNullFrameCount(houseID, rowth, EnumCellStatus.空料框.ToString());
        }
        public int GetIdleGsCount(long houseID, int rowth)
        {
            return dal.GetIdleGSCount(houseID, rowth, EnumCellStatus.空闲.ToString());
        }
        public int GetFullGsCount(long houseID, int rowth)
        {
            return dal.GetFullGSCount(houseID, rowth, EnumCellStatus.满位.ToString());
        }
        public DataTable GetModelListByTaskSta(long storeHouseID, string gsTaskStatus)
        {
            //string sqlStr = "select *  from GoodsSite ,Stock,StockList,StoreHouse where GoodsSite.GoodsSiteID =Stock.GoodsSiteID and Stock.StockID = StockList.StockID and StoreHouse.StoreHouseID = GoodsSite.StoreHouseID ";
            //sqlStr += " and  GoodsSite.GoodsSiteTaskStatus = '" + gsTaskStatus + "' and StoreHouse.StoreHouseID = " + storeHouseID + " and GsEnabled = 1";
            string sqlStr = "select *  from GoodsSite ,StoreHouse where StoreHouse.StoreHouseID = GoodsSite.StoreHouseID ";
            sqlStr += " and  GoodsSite.GoodsSiteTaskStatus = '" + gsTaskStatus + "' and StoreHouse.StoreHouseID = " + storeHouseID + " and GsEnabled = 1";
            //sqlStr += " order by StockList.InHouseTime asc ";

            DataSet ds = DbHelperSQL.Query(sqlStr);
            if (ds != null && ds.Tables.Count > 0)
            {
                List<string> itemList = new List<string>();
                itemList.Add("GoodsSiteID");
                itemList.Add("GoodsSiteRow");
                itemList.Add("GoodsSiteColumn");
                itemList.Add("GoodsSiteLayer");
                DataView dv = ds.Tables[0].DefaultView;
                DataTable distinctData = dv.ToTable(true, itemList.ToArray());//删除重复库存
                return distinctData;
            }
            else
            {
                return null;
            }

        }
        //public List<GoodsSiteModel> GetModelListByTaskSta(long storeHouseID, string gsTaskStatus)
        //{
        //    string sqlStr = "GoodsSiteTaskStatus = '" + gsTaskStatus + "' and StoreHouseID = " + storeHouseID;
        //    List<GoodsSiteModel> viewList = GetModelList(sqlStr);
        //    return viewList;
        //}

        public bool GsReturnFac()
        {
            return dal.GsReturnFac(EnumCellStatus.空闲.ToString(), EnumGSTaskStatus.完成.ToString(), EnumGSOperate.无.ToString());
        }
         public int GetGsLockCount(long houseID,int rowth)
        {
            return dal.GetGsLockCount(houseID, rowth);
        }
        public int GetForbitGsCount(long houseID, int rowth)
         {
             return dal.GetForbitGsCount(houseID, rowth);
         }

        public int GetOutAllowCount(long houseID, int rowth)
        {
            return dal.GetOutAllowCount(houseID, rowth);
        }

        public bool SetSingleGsArea(long houseID, long houseAreaID, string gsName)
        {
            string strSql = "StoreHouseID =" + houseID + " and GoodsSitePos ='" + gsName + "'";
            List<GoodsSiteModel> gsList = GetModelList(strSql);
            if (gsList == null)
            {
                return false;
            }
            for (int i = 0; i < gsList.Count; i++)
            {
                gsList[i].StoreHouseLogicAreaID = houseAreaID;
                Update(gsList[i]);
            }

            return true;
        }
        public bool SetSingleColGsArea(long houseID, long houseAreaID,int rowth, int colth)
        {
            string strSql = "StoreHouseID =" + houseID + " and GoodsSiteRow = "+rowth + " and GoodsSiteColumn =" + colth;
            List<GoodsSiteModel> gsList = GetModelList(strSql);
            if (gsList == null)
            {
                return false;
            }
            for (int i = 0; i < gsList.Count; i++)
            {
                gsList[i].StoreHouseLogicAreaID = houseAreaID;
                Update(gsList[i]);
            }
            return true;
        }
        public bool SetMulLayerMulColGsArea(long houseID, long houseAreaID, int rowth, int stCol,int edCol,int stLayer,int edLayer)
        {
            string strSql = "StoreHouseID =" + houseID + " and GoodsSiteRow = " + rowth + " and GoodsSiteColumn >=" + stCol + " and GoodsSiteColumn<= " + edCol
                + " and GoodsSiteLayer>= " + stLayer + " and GoodsSiteLayer<= " +edLayer;
            List<GoodsSiteModel> gsList = GetModelList(strSql);
            if (gsList == null)
            {
                return false;
            }
            for (int i = 0; i < gsList.Count; i++)
            {
                gsList[i].StoreHouseLogicAreaID = houseAreaID;
                Update(gsList[i]);
            }
            return true;
        }
        public bool SetSingleLayerGsArea(long houseID, long houseAreaID,int rowth, int layer)
        {
            string strSql = "StoreHouseID =" + houseID + " and GoodsSiteRow = "+ rowth  +" and GoodsSiteLayer =" + layer;
            List<GoodsSiteModel> gsList = GetModelList(strSql);
            if (gsList == null)
            {
                return false;
            }
            for (int i = 0; i < gsList.Count; i++)
            {
                gsList[i].StoreHouseLogicAreaID = houseAreaID;
                Update(gsList[i]);
            }
            return true;
        }
        #endregion  ExtensionMethod
    }
}

