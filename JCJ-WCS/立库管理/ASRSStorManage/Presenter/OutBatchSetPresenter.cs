using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AsrsStorDBAcc.BLL;
using AsrsStorDBAcc.Model;

namespace ASRSStorManage.Presenter
{
    public class OutBatchSetPresenter
    {
        OutBatchSetBLL bllBatchSet = new OutBatchSetBLL();
        StoreHouseBLL bllStoreHouse = new StoreHouseBLL();
        StoreHouseLogicAreaBLL bllStoreHouseArea = new StoreHouseLogicAreaBLL();
        View_GoodsSiteBLL bllViewGoodSite = new View_GoodsSiteBLL();
        StockListBLL bllStcokList = new StockListBLL();
        View_StockBLL bllViewStock = new View_StockBLL();
        OutBatchSetBLL bllOutBatchSet = new OutBatchSetBLL();
        View_OutHouseBatchSetBLL bllViewOutHouseBatch = new View_OutHouseBatchSetBLL();
        public OutBatchSetPresenter()
        { }
        public List<StoreHouseModel> GetStoreHouse()
        {
            return bllStoreHouse.GetModelList("");
        }
        public List<StoreHouseLogicAreaModel> GetHouseAreaList(long houseID)
        {
            return bllViewGoodSite.GetHouseArea(houseID);
        }
        public List<string> GetBatch(long houseId,long houseAreaID)
        {
            return bllViewStock.GetBatches(houseId, houseAreaID);
        }
        public List<View_OutHouseBatchSetModel> GetBatchSet()
        {
            return bllViewOutHouseBatch.GetModelList("");
        }
        public void SetBatch(long storeHouseID,long storeAreaID,string batch )
        {
            OutBatchSetModel batchModel = bllOutBatchSet.GetModel(storeHouseID,storeAreaID);
           
            if(batchModel == null)
            {
                batchModel = new OutBatchSetModel();
                batchModel.StoreHouseID = storeHouseID;
                batchModel.StoreHouseLogicAreaID = storeAreaID;
                batchModel.Batch = batch;
                bllOutBatchSet.Add(batchModel);
            }
            else
            {
                batchModel.Batch = batch;
                bllOutBatchSet.Update(batchModel);
            }
           
        }


    }
}
