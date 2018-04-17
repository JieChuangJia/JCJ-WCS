using System;
using System.Data;
using System.Collections.Generic;
using DBAccess.Model;
using DBAccess.DAL;
namespace DBAccess.BLL
{
    /// <summary>
    /// BatteryModel
    /// </summary>
    public partial class BatteryBll
    {
        private readonly DBAccess.DAL.BatteryDal dal = new DBAccess.DAL.BatteryDal();
        public BatteryBll()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string batteryID)
        {
            return dal.Exists(batteryID);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(DBAccess.Model.BatteryModel model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(DBAccess.Model.BatteryModel model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(string batteryID)
        {

            return dal.Delete(batteryID);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string batteryIDlist)
        {
            return dal.DeleteList(batteryIDlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public DBAccess.Model.BatteryModel GetModel(string batteryID)
        {

            return dal.GetModel(batteryID);
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
        public List<DBAccess.Model.BatteryModel> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<DBAccess.Model.BatteryModel> DataTableToList(DataTable dt)
        {
            List<DBAccess.Model.BatteryModel> modelList = new List<DBAccess.Model.BatteryModel>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                DBAccess.Model.BatteryModel model;
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

        #endregion  ExtensionMethod
    }
}

