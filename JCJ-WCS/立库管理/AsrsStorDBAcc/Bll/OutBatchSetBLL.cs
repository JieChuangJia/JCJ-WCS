using System;
using System.Data;
using System.Collections.Generic;

using AsrsStorDBAcc.Model;
namespace AsrsStorDBAcc.BLL
{
    /// <summary>
    /// OutBatchSet
    /// </summary>
    public partial class OutBatchSetBLL
    {
        private readonly AsrsStorDBAcc.DAL.OutBatchSetDAL dal = new AsrsStorDBAcc.DAL.OutBatchSetDAL();
        public OutBatchSetBLL()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(long OutBatchSetID)
        {
            return dal.Exists(OutBatchSetID);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public long Add(AsrsStorDBAcc.Model.OutBatchSetModel model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(AsrsStorDBAcc.Model.OutBatchSetModel model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(long OutBatchSetID)
        {

            return dal.Delete(OutBatchSetID);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string OutBatchSetIDlist)
        {
            return dal.DeleteList(OutBatchSetIDlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public AsrsStorDBAcc.Model.OutBatchSetModel GetModel(long OutBatchSetID)
        {

            return dal.GetModel(OutBatchSetID);
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
        public List<AsrsStorDBAcc.Model.OutBatchSetModel> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<AsrsStorDBAcc.Model.OutBatchSetModel> DataTableToList(DataTable dt)
        {
            List<AsrsStorDBAcc.Model.OutBatchSetModel> modelList = new List<AsrsStorDBAcc.Model.OutBatchSetModel>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                AsrsStorDBAcc.Model.OutBatchSetModel model;
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
        public OutBatchSetModel GetModel(long storeHouseID, long storeAreaID)
        {
            string sqlStr = " StoreHouseID =" + storeHouseID + " and  StoreHouseLogicAreaID = " + storeAreaID;
            List<OutBatchSetModel> batches = GetModelList(sqlStr);
            if(batches!= null&&batches.Count>0)
            {
                return batches[0];
            }
            else
            {
                return null;
            }
        }
        #endregion  ExtensionMethod
    }
}

