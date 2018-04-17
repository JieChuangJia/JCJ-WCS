using System;
using System.Data;
using System.Collections.Generic;
using MesDBAccess.Model;
namespace MesDBAccess.BLL
{
    /// <summary>
    /// ProduceRecordModel
    /// </summary>
    public partial class ProduceRecordBll
    {
        private readonly MesDBAccess.DAL.ProduceRecordDal dal = new MesDBAccess.DAL.ProduceRecordDal();
        public ProduceRecordBll()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string recordID)
        {
            return dal.Exists(recordID);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(MesDBAccess.Model.ProduceRecordModel model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(MesDBAccess.Model.ProduceRecordModel model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(string recordID)
        {

            return dal.Delete(recordID);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string recordIDlist)
        {
            return dal.DeleteList(recordIDlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public MesDBAccess.Model.ProduceRecordModel GetModel(string recordID)
        {

            return dal.GetModel(recordID);
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
        public List<MesDBAccess.Model.ProduceRecordModel> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<MesDBAccess.Model.ProduceRecordModel> DataTableToList(DataTable dt)
        {
            List<MesDBAccess.Model.ProduceRecordModel> modelList = new List<MesDBAccess.Model.ProduceRecordModel>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                MesDBAccess.Model.ProduceRecordModel model;
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
        public void ClearHistorydata(int daysStore)
        {
            System.TimeSpan ts = new TimeSpan(daysStore, 0, 0, 0); //15天
            System.DateTime delDate = System.DateTime.Now - ts;
           // string strWhere = string.Format("delete from ProduceRecord where recordTime <'{0}' ", delDate.ToString("yyyy-MM-dd"));
          //  string strWhere = string.Format("delete from ProduceRecord where recordID in (SELECT TOP 1000 recordID ProduceRecord where recordTime<'{0}' order by recordTime asc)", delDate.ToString("yyyy-MM-dd"));
           // DBUtility.DbHelperSQL.ExecuteSql(strWhere);
            string strWhere = string.Format(" recordTime < '{0}'", delDate.ToString("yyyy-MM-dd"));
            DataSet ds = dal.GetList(10000,strWhere,"recordTime");
            DataTable dt = ds.Tables[0];
            if(dt.Rows.Count>0)
            {
                foreach(DataRow dr in dt.Rows)
                {
                    string id=dr["recordID"].ToString();
                    dal.Delete(id);
                }
            }
           // DBUtility.DbHelperSQL.ExecuteSqlByTime(strWhere, 200);
        }
        #endregion  ExtensionMethod
    }
}

