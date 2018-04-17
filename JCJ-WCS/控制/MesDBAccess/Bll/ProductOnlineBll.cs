using System;
using System.Data;
using System.Collections.Generic;
using MesDBAccess.Model;
namespace MesDBAccess.BLL
{
    /// <summary>
    /// ProductOnlineModel
    /// </summary>
    public partial class ProductOnlineBll
    {
        private readonly MesDBAccess.DAL.ProductOnlineDal dal = new MesDBAccess.DAL.ProductOnlineDal();
        public ProductOnlineBll()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string productID)
        {
            return dal.Exists(productID);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(MesDBAccess.Model.ProductOnlineModel model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(MesDBAccess.Model.ProductOnlineModel model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(string productID)
        {

            return dal.Delete(productID);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string productIDlist)
        {
            return dal.DeleteList(productIDlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public MesDBAccess.Model.ProductOnlineModel GetModel(string productID)
        {

            return dal.GetModel(productID);
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
        public List<MesDBAccess.Model.ProductOnlineModel> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<MesDBAccess.Model.ProductOnlineModel> DataTableToList(DataTable dt)
        {
            List<MesDBAccess.Model.ProductOnlineModel> modelList = new List<MesDBAccess.Model.ProductOnlineModel>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                MesDBAccess.Model.ProductOnlineModel model;
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
        /// 获得托盘内绑定的所有产品数据
        /// </summary>
        /// <param name="palletID"></param>
        /// <returns></returns>
        public List<ProductOnlineModel> GetProductsInPallet(string palletID)
        {
            string strSql = string.Format("palletID='{0}' and palletBinded=1", palletID);
            return GetModelList(strSql);
        }

        /// <summary>
        /// 获得托盘批次
        /// </summary>
        /// <param name="palletID"></param>
        /// <returns></returns>
        public string GetBatchNameofPallet(string palletID)
        {
            List<ProductOnlineModel> products = GetProductsInPallet(palletID);
            if(products == null || products.Count==0)
            {
                return string.Empty;
            }
            string batch = "";
            foreach(ProductOnlineModel p in products)
            {
                if(string.IsNullOrWhiteSpace(p.batchName))
                {
                    continue;
                }
                else
                {
                    batch = p.batchName;
                }
            }
            return batch;
        }
        public int GetPalletProductCount(string palletID)
        {
            return dal.GetPalletProductCount(palletID);
        }
        public int GetProcessIDOfPallet(string palletID)
        {
            List<ProductOnlineModel> products = GetProductsInPallet(palletID);
            if (products == null || products.Count == 0)
            {
                return 0;
            }
            return products[0].stepNO;
        }
        public bool UnbindPallet(string palletID,ref string reStr)
        {
            try
            {
                List<ProductOnlineModel> products = GetProductsInPallet(palletID);
                if (products == null || products.Count == 0)
                {
                    return true;
                }
                foreach(ProductOnlineModel product in products)
                {
                    if(!Delete(product.productID))
                    {
                        return false;
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                reStr = ex.ToString();
               
                return false;
            }
           
        }
        public List<string> GetBatchList()
        {
            DataSet ds = dal.GetBatchList();
            DataTable dt = ds.Tables[0];
            int rowsCount = dt.Rows.Count;
            List<string> batchList = new List<string>();
            if (rowsCount > 0)
            {

                for (int n = 0; n < rowsCount; n++)
                {
                    string batch = dt.Rows[n]["batchName"].ToString();
                    if (!string.IsNullOrWhiteSpace(batch))
                    {
                        batchList.Add(batch);
                    }
                }
            }
            batchList.Sort();
            return batchList;
        }
        public DataSet GetPallets(string strWhere)
        {
            return dal.GetPallets(strWhere);
        }
        public DataSet GetListByView(string strWhere)
        {
            return dal.GetListByView(strWhere);
        }
        #endregion  ExtensionMethod
    }
}

