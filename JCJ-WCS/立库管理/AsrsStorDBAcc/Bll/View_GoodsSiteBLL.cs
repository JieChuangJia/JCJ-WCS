using System;
using System.Data;
using System.Collections.Generic;
 
using AsrsStorDBAcc.Model;
using AsrsModel;
namespace AsrsStorDBAcc.BLL
{
    /// <summary>
    /// View_GoodsSite
    /// </summary>
    public partial class View_GoodsSiteBLL
    {
        private readonly AsrsStorDBAcc.DAL.View_GoodsSiteDAL dal = new AsrsStorDBAcc.DAL.View_GoodsSiteDAL();
        public View_GoodsSiteBLL()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(long GoodsSiteID, long StoreHouseID, string GoodsSiteName, int GoodsSiteLayer, int GoodsSiteColumn, int GoodsSiteRow, string GoodsSiteTaskStatus, string GoodsSiteType, string GoodsSitePos, string GoodsSiteStatus, string GoodsSiteOperate, string StoreHouseName, string StoreHouseDesc, bool GsEnabled, long StoreHouseLogicAreaID, string StoreHouseAreaName, string StoreHouseAreaDesc, string GoodsSite_Reserve)
        {
            return dal.Exists(GoodsSiteID, StoreHouseID, GoodsSiteName, GoodsSiteLayer, GoodsSiteColumn, GoodsSiteRow, GoodsSiteTaskStatus, GoodsSiteType, GoodsSitePos, GoodsSiteStatus, GoodsSiteOperate, StoreHouseName, StoreHouseDesc, GsEnabled, StoreHouseLogicAreaID, StoreHouseAreaName, StoreHouseAreaDesc, GoodsSite_Reserve);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(AsrsStorDBAcc.Model.View_GoodsSiteModel model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(AsrsStorDBAcc.Model.View_GoodsSiteModel model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(long GoodsSiteID, long StoreHouseID, string GoodsSiteName, int GoodsSiteLayer, int GoodsSiteColumn, int GoodsSiteRow, string GoodsSiteTaskStatus, string GoodsSiteType, string GoodsSitePos, string GoodsSiteStatus, string GoodsSiteOperate, string StoreHouseName, string StoreHouseDesc, bool GsEnabled, long StoreHouseLogicAreaID, string StoreHouseAreaName, string StoreHouseAreaDesc, string GoodsSite_Reserve)
        {

            return dal.Delete(GoodsSiteID, StoreHouseID, GoodsSiteName, GoodsSiteLayer, GoodsSiteColumn, GoodsSiteRow, GoodsSiteTaskStatus, GoodsSiteType, GoodsSitePos, GoodsSiteStatus, GoodsSiteOperate, StoreHouseName, StoreHouseDesc, GsEnabled, StoreHouseLogicAreaID, StoreHouseAreaName, StoreHouseAreaDesc, GoodsSite_Reserve);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public AsrsStorDBAcc.Model.View_GoodsSiteModel GetModel(long GoodsSiteID, long StoreHouseID, string GoodsSiteName, int GoodsSiteLayer, int GoodsSiteColumn, int GoodsSiteRow, string GoodsSiteTaskStatus, string GoodsSiteType, string GoodsSitePos, string GoodsSiteStatus, string GoodsSiteOperate, string StoreHouseName, string StoreHouseDesc, bool GsEnabled, long StoreHouseLogicAreaID, string StoreHouseAreaName, string StoreHouseAreaDesc, string GoodsSite_Reserve)
        {

            return dal.GetModel(GoodsSiteID, StoreHouseID, GoodsSiteName, GoodsSiteLayer, GoodsSiteColumn, GoodsSiteRow, GoodsSiteTaskStatus, GoodsSiteType, GoodsSitePos, GoodsSiteStatus, GoodsSiteOperate, StoreHouseName, StoreHouseDesc, GsEnabled, StoreHouseLogicAreaID, StoreHouseAreaName, StoreHouseAreaDesc, GoodsSite_Reserve);
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
        public List<AsrsStorDBAcc.Model.View_GoodsSiteModel> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<AsrsStorDBAcc.Model.View_GoodsSiteModel> DataTableToList(DataTable dt)
        {
            List<AsrsStorDBAcc.Model.View_GoodsSiteModel> modelList = new List<AsrsStorDBAcc.Model.View_GoodsSiteModel>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                AsrsStorDBAcc.Model.View_GoodsSiteModel model;
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
        public List<StoreHouseLogicAreaModel> GetHouseArea(long storeHouseID)
        {
            List<StoreHouseLogicAreaModel> areaList = dal.GetHouseArea(storeHouseID);
            return areaList;
        }
        public List<View_GoodsSiteModel> GetModelListByTaskSta(long storeHouseID, string gsTaskStatus)
        {
            string sqlStr = "GoodsSiteTaskStatus = '" + gsTaskStatus + "' and StoreHouseID = " + storeHouseID;
            List<View_GoodsSiteModel> viewList = GetModelList(sqlStr);
            return viewList;
        }
        /// <summary>
        /// 从第一排第一列第一层开始查找
        /// </summary>
        /// <param name="logicAreaID">逻辑区域ID</param>
        /// <param name="gsStoreStatus">存储状态</param>
        /// <param name="gsType">货位类型</param>
        /// <param name="requireCellRule">申请货位规则，1：从最小列开始申请；2：从大列开始申请</param>
        /// <returns></returns>
        public View_GoodsSiteModel ApplyGoodsSite(string houseName,string houseAreaName,int requireCellRule)
        {
            View_GoodsSiteModel goodsSite = null;
            string strSql = " GoodsSiteStatus ='" + EnumCellStatus.空闲.ToString() + "'and GoodsSiteTaskStatus ='"
                    + EnumGSTaskStatus.完成.ToString() + "'";
            
            if (houseName != "所有")//没有分区
            {
                strSql += " and StoreHouseName = '" +houseName+"'";
            }
            if(houseAreaName!= "所有")
            {
                strSql += " and StoreHouseAreaName='" + houseAreaName + "'";
            }
            if (requireCellRule == 1)
            {
                strSql += " and GsEnabled =1 order by GoodsSiteColumn asc,"
                  + "GoodsSiteRow asc,GoodsSiteLayer asc";
            }
            else if (requireCellRule == 2)
            {
                strSql += " and GsEnabled =1 order by GoodsSiteColumn Desc,"
                + "GoodsSiteRow asc,GoodsSiteLayer asc";
            }
            else
            {
                strSql += " and GsEnabled =1 order by GoodsSiteColumn asc,"
                + "GoodsSiteRow asc,GoodsSiteLayer asc";
            }
        
            List<View_GoodsSiteModel> goodsSiteList = GetModelList(strSql);
            if (goodsSiteList.Count > 0)
            {
                goodsSite = goodsSiteList[0];
            }

            return goodsSite;
        }

        public View_GoodsSiteModel ApplyGoodsSiteByRow(string houseName, string houseAreaName, int row,int requireCellRule)
        {
            View_GoodsSiteModel goodsSite = null;
            string strSql = " GoodsSiteStatus ='" + EnumCellStatus.空闲.ToString() + "'and GoodsSiteTaskStatus ='"
                    + EnumGSTaskStatus.完成.ToString() + "'";
            strSql += string.Format(" and GoodsSiteRow={0} ", row);

            if (houseName != "所有")//没有分区
            {
                strSql += " and StoreHouseName = '" + houseName + "'";
            }
            if (houseAreaName != "所有")
            {
                strSql += " and StoreHouseAreaName='" + houseAreaName + "'";
            }
            if (requireCellRule == 1)
            {
                strSql += " and GsEnabled =1 order by GoodsSiteColumn asc,"
                  + "GoodsSiteRow asc,GoodsSiteLayer asc";
            }
            else if (requireCellRule == 2)
            {
                strSql += " and GsEnabled =1 order by GoodsSiteColumn Desc,"
                + "GoodsSiteRow asc,GoodsSiteLayer asc";
            }
            else
            {
                strSql += " and GsEnabled =1 order by GoodsSiteColumn asc,"
                + "GoodsSiteRow asc,GoodsSiteLayer asc";
            }

            List<View_GoodsSiteModel> goodsSiteList = GetModelList(strSql);
            if (goodsSiteList.Count > 0)
            {
                goodsSite = goodsSiteList[0];
            }

            return goodsSite;
        }

        /// <summary>
        /// 获取剩余货位数量
        /// </summary>
        /// <param name="houseName"></param>
        /// <param name="houseAreaName"></param>
        /// <returns></returns>
        public int GetHouseAreaLeftGs(string houseName,string houseAreaName)
        {
            int leftGs = 0;
            string sqlStr = " GoodsSiteStatus ='" + EnumCellStatus.空闲.ToString() + "'and GoodsSiteTaskStatus ='"
                   + EnumGSTaskStatus.完成.ToString() + "'";
            if (houseName != "所有")
            {
                sqlStr += " and StoreHouseName= '" + houseName + "'";
            }
            if (houseAreaName != "所有")
            {
                sqlStr += " and StoreHouseAreaName= '" +houseAreaName+"'";
            }

            sqlStr += " and GsEnabled =1 order by GoodsSiteColumn asc,GoodsSiteRow asc,GoodsSiteLayer asc";
            List<View_GoodsSiteModel> gsList = GetModelList(sqlStr);
            if(gsList!= null&&gsList.Count>0)
            {
                leftGs = gsList.Count;
            }
            return leftGs;
        }
        public View_GoodsSiteModel GetModelByHouseAndAreaName(string houseName, string storeHouseAreaName)
        {
            string sqlStr = "1=1";
            if(storeHouseAreaName != "所有")
            {
                 sqlStr   += " and StoreHouseName = '" + houseName + "'" ;
            }
            if (houseName!="所有")
            { 
                sqlStr  += " and StoreHouseAreaName = '" + storeHouseAreaName+"'";
            }
         
            List<View_GoodsSiteModel> viewList = GetModelList(sqlStr);
            if (viewList != null && viewList.Count > 0)
            {
                return viewList[0];
            }
            else
            {
                return null;
            }
        }
     

        public View_GoodsSiteModel GetModelByGSID(long gsID)
        {
            string sqlStr = "GoodsSiteID = " + gsID ;
            List<View_GoodsSiteModel> viewList = GetModelList(sqlStr);
            if (viewList != null && viewList.Count > 0)
            {
                return viewList[0];
            }
            else
            {
                return null;
            }
        }
        public View_GoodsSiteModel GetModelByBoxCode(string boxCode)
        {
            string sqlStr = "MeterialboxCode = '" + boxCode + "'";
            List<View_GoodsSiteModel> viewList = GetModelList(sqlStr);
            if (viewList != null && viewList.Count > 0)
            {
                return viewList[0];
            }
            else
            {
                return null;
            }
        }
        #endregion  ExtensionMethod
    }
}

