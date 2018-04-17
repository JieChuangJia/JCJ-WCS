using System;
using System.Data;
using System.Collections.Generic;
using MesDBAccess.Model;
namespace MesDBAccess.BLL
{
    /// <summary>
    /// palletModel
    /// </summary>
    public partial class palletBll
    {
        private readonly MesDBAccess.DAL.palletDal dal = new MesDBAccess.DAL.palletDal();
        public palletBll()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string palletID)
        {
            return dal.Exists(palletID);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(MesDBAccess.Model.palletModel model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(MesDBAccess.Model.palletModel model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(string palletID)
        {

            return dal.Delete(palletID);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string palletIDlist)
        {
            return dal.DeleteList(palletIDlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public MesDBAccess.Model.palletModel GetModel(string palletID)
        {

            return dal.GetModel(palletID);
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
        public List<MesDBAccess.Model.palletModel> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<MesDBAccess.Model.palletModel> DataTableToList(DataTable dt)
        {
            List<MesDBAccess.Model.palletModel> modelList = new List<MesDBAccess.Model.palletModel>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                MesDBAccess.Model.palletModel model;
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

