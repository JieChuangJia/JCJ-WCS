using System;
using System.Data;
using System.Collections.Generic;
 
using AsrsStorDBAcc.Model;
namespace AsrsStorDBAcc.BLL
{
    /// <summary>
    /// StoreHouseLogicArea
    /// </summary>
    public partial class StoreHouseLogicAreaBLL
    {
        private readonly AsrsStorDBAcc.DAL.StoreHouseLogicAreaDAL dal = new AsrsStorDBAcc.DAL.StoreHouseLogicAreaDAL();
        public StoreHouseLogicAreaBLL()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(long StoreHouseLogicAreaID)
        {
            return dal.Exists(StoreHouseLogicAreaID);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public long Add(AsrsStorDBAcc.Model.StoreHouseLogicAreaModel model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(AsrsStorDBAcc.Model.StoreHouseLogicAreaModel model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(long StoreHouseLogicAreaID)
        {

            return dal.Delete(StoreHouseLogicAreaID);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string StoreHouseLogicAreaIDlist)
        {
            return dal.DeleteList(StoreHouseLogicAreaIDlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public AsrsStorDBAcc.Model.StoreHouseLogicAreaModel GetModel(long StoreHouseLogicAreaID)
        {

            return dal.GetModel(StoreHouseLogicAreaID);
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
        public List<AsrsStorDBAcc.Model.StoreHouseLogicAreaModel> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<AsrsStorDBAcc.Model.StoreHouseLogicAreaModel> DataTableToList(DataTable dt)
        {
            List<AsrsStorDBAcc.Model.StoreHouseLogicAreaModel> modelList = new List<AsrsStorDBAcc.Model.StoreHouseLogicAreaModel>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                AsrsStorDBAcc.Model.StoreHouseLogicAreaModel model;
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
        public StoreHouseLogicAreaModel GetModelByName(string logicName)
        {
            string sqlStr = "StoreHouseAreaName = '" + logicName + "'";
            List<StoreHouseLogicAreaModel> modelList = GetModelList(sqlStr);
            if(modelList!= null&&modelList.Count>0)
            {
                return modelList[0];
            }
            else
            { return null;
            }
        }
        #endregion  ExtensionMethod
    }
}

