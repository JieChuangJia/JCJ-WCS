using System;
using System.Data;
using System.Collections.Generic;

using AsrsStorDBAcc.Model;
namespace AsrsStorDBAcc.BLL
{
    /// <summary>
    /// View_OutHouseBatchSet
    /// </summary>
    public partial class View_OutHouseBatchSetBLL
    {
        private readonly AsrsStorDBAcc.DAL.View_OutHouseBatchSetDAL dal = new AsrsStorDBAcc.DAL.View_OutHouseBatchSetDAL();
        public View_OutHouseBatchSetBLL()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string StoreHouseName, string StoreHouseDesc, long StoreHouseID, long StoreHouseLogicAreaID, string StoreHouseAreaName, string StoreHouseAreaDesc, string Batch)
        {
            return dal.Exists(StoreHouseName, StoreHouseDesc, StoreHouseID, StoreHouseLogicAreaID, StoreHouseAreaName, StoreHouseAreaDesc, Batch);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(AsrsStorDBAcc.Model.View_OutHouseBatchSetModel model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(AsrsStorDBAcc.Model.View_OutHouseBatchSetModel model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(string StoreHouseName, string StoreHouseDesc, long StoreHouseID, long StoreHouseLogicAreaID, string StoreHouseAreaName, string StoreHouseAreaDesc, string Batch)
        {

            return dal.Delete(StoreHouseName, StoreHouseDesc, StoreHouseID, StoreHouseLogicAreaID, StoreHouseAreaName, StoreHouseAreaDesc, Batch);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public AsrsStorDBAcc.Model.View_OutHouseBatchSetModel GetModel(string StoreHouseName, string StoreHouseDesc, long StoreHouseID, long StoreHouseLogicAreaID, string StoreHouseAreaName, string StoreHouseAreaDesc, string Batch)
        {

            return dal.GetModel(StoreHouseName, StoreHouseDesc, StoreHouseID, StoreHouseLogicAreaID, StoreHouseAreaName, StoreHouseAreaDesc, Batch);
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
        public List<AsrsStorDBAcc.Model.View_OutHouseBatchSetModel> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<AsrsStorDBAcc.Model.View_OutHouseBatchSetModel> DataTableToList(DataTable dt)
        {
            List<AsrsStorDBAcc.Model.View_OutHouseBatchSetModel> modelList = new List<AsrsStorDBAcc.Model.View_OutHouseBatchSetModel>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                AsrsStorDBAcc.Model.View_OutHouseBatchSetModel model;
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
        public View_OutHouseBatchSetModel GetModel(string houseName,string houseAreaName)
        {
            string sqlStr = "StoreHouseName ='" + houseName + "' and StoreHouseAreaName ='" +houseAreaName+"'";
            List<View_OutHouseBatchSetModel> modelList = GetModelList(sqlStr);
            if(modelList!=null&&modelList.Count>0)
            {
                return modelList[0];
            }
            else
            {
                return null;
            }
        }
        #endregion  ExtensionMethod
    }
}

