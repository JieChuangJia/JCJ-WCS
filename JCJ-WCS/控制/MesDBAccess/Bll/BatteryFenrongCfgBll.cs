using System;
using System.Data;
using System.Collections.Generic;
using MesDBAccess.Model;
namespace MesDBAccess.BLL
{
    /// <summary>
    /// BatteryFenrongCfgModel
    /// </summary>
    public partial class BatteryFenrongCfgBll
    {
        private readonly MesDBAccess.DAL.BatteryFenrongCfgDal dal = new MesDBAccess.DAL.BatteryFenrongCfgDal();
        public BatteryFenrongCfgBll()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string fenrongCfgID)
        {
            return dal.Exists(fenrongCfgID);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(MesDBAccess.Model.BatteryFenrongCfgModel model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(MesDBAccess.Model.BatteryFenrongCfgModel model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(string fenrongCfgID)
        {

            return dal.Delete(fenrongCfgID);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string fenrongCfgIDlist)
        {
            return dal.DeleteList(fenrongCfgIDlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public MesDBAccess.Model.BatteryFenrongCfgModel GetModel(string fenrongCfgID)
        {

            return dal.GetModel(fenrongCfgID);
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
        public List<MesDBAccess.Model.BatteryFenrongCfgModel> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<MesDBAccess.Model.BatteryFenrongCfgModel> DataTableToList(DataTable dt)
        {
            List<MesDBAccess.Model.BatteryFenrongCfgModel> modelList = new List<MesDBAccess.Model.BatteryFenrongCfgModel>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                MesDBAccess.Model.BatteryFenrongCfgModel model;
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
        /// 获得数据列表
        /// </summary>
        public List<MesDBAccess.Model.BatteryFenrongCfgModel> GetModelList(string strWhere,string filedOrder)
        {
            DataSet ds = dal.GetList(-1,strWhere,filedOrder);
            return DataTableToList(ds.Tables[0]);
        }
        public bool Exist(string batteryCata,string fenrongZone)
        {
            List<MesDBAccess.Model.BatteryFenrongCfgModel> fenrongList=GetModelList(string.Format("batteryCataCode='{0}' and fenrongZone='{1}' ", batteryCata, fenrongZone));
            if(fenrongList.Count>0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool Del(string batteryCata,string fenrongZone)
        {
            List<MesDBAccess.Model.BatteryFenrongCfgModel> fenrongList = GetModelList(string.Format("batteryCataCode='{0}' and fenrongZone='{1}' ", batteryCata, fenrongZone));
            if (fenrongList.Count > 0)
            {
                foreach(MesDBAccess.Model.BatteryFenrongCfgModel m in fenrongList)
                {
                    dal.Delete(m.fenrongCfgID);
                }
                return true;
            }
            else { return false; }
        }
        #endregion  ExtensionMethod
    }
}

