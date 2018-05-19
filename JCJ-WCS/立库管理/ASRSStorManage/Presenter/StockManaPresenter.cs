using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ASRSStorManage.View;
using AsrsStorDBAcc.BLL;
using AsrsStorDBAcc.Model;
using AsrsModel;
using AsrsInterface;
using System.Data;
using MesDBAccess.BLL;
using System.Threading;

namespace ASRSStorManage.Presenter
{
    public class StockManaPresenter
    {
        string currHouseName = "A库房";
        string currHouseArea = "所有";
        string currRowth = "所有";
        string currColth = "所有";
        string currLayerth = "所有";
        string gsStatus = "所有";
        string gsTaskSta = "所有";
        string currProBatch = "所有";
        //add 20180112
        string materialBoxCode = "所有";
        bool isChecked = false;
        IAsrsManageToCtl iStorageManager;
        IAsrsCtlToManage iControl;
        StockManaView view;
        GoodsSiteBLL bllGs = new GoodsSiteBLL();
        View_GoodsSiteBLL bllViewGS = new View_GoodsSiteBLL();

        StockBLL bllStock = new StockBLL();
        StoreHouseBLL bllStoreHouse = new StoreHouseBLL();
        View_StockBLL bllViewStock = new View_StockBLL();
        StockListBLL bllStockList = new StockListBLL();
        View_StockGSBLL bllViewStockGs = new View_StockGSBLL();
        StockDetailBLL bllStockDetail = new StockDetailBLL();
        ProductOnlineBll bllProductOnLine = new ProductOnlineBll();
        public StockManaPresenter(StockManaView view)
        {
            this.view = view;
        }
        public void IniPresenter(IAsrsManageToCtl iAsrsManageToCtl,IAsrsCtlToManage iAsrsCtlToManage)
        {
            this.iControl = iAsrsCtlToManage;
            this.iStorageManager = iAsrsManageToCtl;

            //this.iStorageManager.EventStockListAddExpandForm += ShowExpandProFormEventHandler;
        }
        private void ShowExpandProFormEventHandler(object sender, ExpandFormEventArgs e)
        {
           // this.view.ShowExtForm(e.ExpandForm);
        }
        public void OnCellExpandPro(string productCode, string stockListID)
        {
            StockListModel slm = bllStockList.GetModel(long.Parse(stockListID));
            if (slm == null)
            {
                return;
            }
            StockModel sm = bllStock.GetModel(slm.StockID);
            if (sm == null)
            {
                return;
            }
            View_GoodsSiteModel viewGSM = bllViewGS.GetModelByGSID(sm.GoodsSiteID);
            if (viewGSM == null)
            {
                return;
            }
            StockListProEventArgs slpea = new StockListProEventArgs();
            slpea.HouseName = viewGSM.StoreHouseName;
            slpea.CellCoord = new CellCoordModel(viewGSM.GoodsSiteRow, viewGSM.GoodsSiteColumn, viewGSM.GoodsSiteLayer);

            slpea.ProductCode = productCode;
            StorageMainView.storageMana.OnEventStorDetail(slpea);
            this.view.ShowExtForm(ExtendFormCate.外部);//直接打开页面
        }
        public void BindRCLData(string houseName)
        {
             if(houseName == "")
            {
                return;
            }
            StoreHouseModel house = bllStoreHouse.GetModelByName(houseName);
            if (null == house)
            {
                return;
            }
            List<int> rowList = bllGs.GetGsRCLData(house.StoreHouseID, 0);
            List<int> colList = bllGs.GetGsRCLData(house.StoreHouseID, 1);
            List<int> layerList = bllGs.GetGsRCLData(house.StoreHouseID, 2);
           this.view.BindRowData(rowList);
           this.view.BindColData(colList);
           this.view.BindLayerData(layerList);
        }

        public void BindHouseAreaData(string houseName)
        {
            if (houseName == "")
            {
                return;
            }
            StoreHouseModel house = bllStoreHouse.GetModelByName(houseName);
            if (null == house)
            {
                return;
            }
            List<StoreHouseLogicAreaModel> houseAreaList = bllViewGS.GetHouseArea(house.StoreHouseID);
            this.view.BindHouseAreaData(houseAreaList);
        }

        public void BindProBatchesData(string houseName)
        {
          List<string> batches =   bllViewStock.GetAllBatches(houseName);
          this.view.IniProductBatch(batches);
        }
        public void RefreshStockList(long stockID)
        {
            List<StockListModel> stockList = bllStockList.GetListByStockID(stockID);
            this.view.RefreshStockList(stockList);
        }
        public void ModifyGsStatus(List<GsPosModel> gsList, string gsStatus, string gsTaskStatus)
        {
            string reStr = "";
            for (int i = 0; i < gsList.Count; i++)
            {
                StoreHouseModel house = bllStoreHouse.GetModelByName(gsList[i].HouseName);
                if (null == house)
                {
                    return;
                }
                GoodsSiteModel oldgsm = bllGs.GetModelByRCL(house.StoreHouseID, gsList[i].Rowth, gsList[i].Colth, gsList[i].Layerth);
                if (oldgsm == null)
                {
                    return;
                }
                if (oldgsm.GsEnabled == false)
                {
                    this.view.AddLog("库存列表", "被禁用的货位不允许修改状态!", LogInterface.EnumLoglevel.提示);
                    return;
                }
                bllGs.UpdateGSStatusByRCL(gsList[i].HouseName, gsList[i].Rowth, gsList[i].Colth, gsList[i].Layerth, (EnumCellStatus)Enum.Parse(typeof(EnumCellStatus), gsStatus));
                bllGs.UpdateGsTaskStatusByRCL(gsList[i].HouseName, gsList[i].Rowth, gsList[i].Colth, gsList[i].Layerth, (EnumGSTaskStatus)Enum.Parse(typeof(EnumGSTaskStatus), gsTaskStatus));
                if (gsTaskStatus == EnumGSTaskStatus.出库允许.ToString())
                {
                    bllGs.UpdateOperateByRCL(gsList[i].HouseName, gsList[i].Rowth, gsList[i].Colth, gsList[i].Layerth, EnumGSOperate.出库);
                }
                string operteDetail = "[" + oldgsm.GoodsSiteName + "]货位状态由《" + oldgsm.GoodsSiteStatus + "》变更为《" + gsStatus + "》；" + "货位任务状态由《" + oldgsm.GoodsSiteTaskStatus + "》变更为《" + gsTaskStatus + "》";

                this.iStorageManager.AddGSOperRecord(gsList[i].HouseName, new CellCoordModel(gsList[i].Rowth, gsList[i].Colth, gsList[i].Layerth), EnumGSOperateType.手动修改状态, operteDetail, ref reStr);


                QueryStock(this.currHouseName, this.currHouseArea, this.currRowth, this.currColth, this.currLayerth, this.gsStatus, this.gsTaskSta, this.currProBatch,this.isChecked, this.materialBoxCode);
                this.view.AddLog("库存管理", operteDetail, LogInterface.EnumLoglevel.提示);
            }
        }
      
        public void QueryStock(string houseName, string houseArea,string rowth, string colth, string layerth, string gsStatus, string gsTaskSta,string proBatch,bool isChecked,string materialBoxCode)
        {
            DataTable stockView = bllViewStock.GetData(houseName, houseArea, rowth, colth, layerth, gsStatus, gsTaskSta, proBatch,isChecked, materialBoxCode);
            DataTable stockMerge = stockView.Clone();
            if(stockView==null)
            {
                return;
            }
            string lastStockID ="First";
            for (int i = 0; i < stockView.Rows.Count;i++ )
            {
                string currStockID = "";
                if (lastStockID == "First")
                {
                    stockMerge.ImportRow(stockView.Rows[i]);
                    currStockID = stockView.Rows[i]["库存ID"].ToString();
                }
                else
                {

                    currStockID = stockView.Rows[i]["库存ID"].ToString();
                    if (lastStockID == currStockID)
                    {
                        string boxCode = stockView.Rows[i]["料框条码"].ToString();
                        stockMerge.Rows[stockMerge.Rows.Count - 1]["料框条码"] += "," + boxCode;
                    }
                    else
                    {
                        stockMerge.ImportRow(stockView.Rows[i]);
                    }
                  
                }
               
                lastStockID = currStockID;
            }

            this.view.RefreshStock(stockMerge);
            ////查询所有产品
           //  DataTable stockListDt = bllViewStockGs.GetListByCondition(houseName, rowth, colth, layerth, gsStatus, gsTaskSta, proBatch);

            //DataView dv = stockListDt.DefaultView;

            //List<string> paramList = new List<string>();
            //paramList.Add("StockID");
            //paramList.Add("GoodsSiteName");
            //paramList.Add("GoodsSiteRow");
            //paramList.Add("GoodsSiteColumn");
            //paramList.Add("GoodsSiteLayer");
            //paramList.Add("MeterialBatch");
            //paramList.Add("GoodsSiteStatus");
            //paramList.Add("GoodsSiteTaskStatus");

            //DataTable distinctData = dv.ToTable(true, paramList.ToArray());//删除重复库存
            //this.view.RefreshStock(distinctData);

            if (stockView != null && stockMerge != null)
            {
                string gsCount = stockMerge.Rows.Count.ToString();
                string productCount = stockView.Rows.Count.ToString();
                this.view.RefreshStatisticsData(gsCount, productCount);
            }
            this.currHouseName = houseName;
            this.currRowth = rowth;
            this.currColth = colth;
            this.currLayerth = layerth;
            this.gsStatus = gsStatus;
            this.gsTaskSta = gsTaskSta;
            this.currProBatch = proBatch;
            this.materialBoxCode = materialBoxCode;
            this.isChecked = isChecked;
        }
        public void DeleteStock(List<long> stockIDList)
        {
            string reStr = "";
            if(stockIDList == null)
            {
                return;
            }
            for(int i=0;i<stockIDList.Count;i++)
            { 
                StockModel sm = bllStock.GetModel(stockIDList[i]);
                View_StockGSModel vsgsm = bllViewStockGs.GetModelByStockID(stockIDList[i]);
                if(vsgsm== null)
                {
                    return;
                }
                bllStock.Delete(stockIDList[i]);

                this.iStorageManager.AddGSOperRecord(vsgsm.StoreHouseName, new CellCoordModel(vsgsm.GoodsSiteRow, vsgsm.GoodsSiteColumn,
                    vsgsm.GoodsSiteLayer), EnumGSOperateType.手动删除货位, "手动删除货位:" + vsgsm.GoodsSiteName, ref reStr);
                this.view.AddLog("库存管理", "手动删除货位:" + vsgsm.GoodsSiteName+"成功！", LogInterface.EnumLoglevel.提示);

                //bllGs.UpdateGSStatusByRCL(vsgsm.StoreHouseName, vsgsm.GoodsSiteRow, vsgsm.GoodsSiteColumn,vsgsm.GoodsSiteLayer,EnumCellStatus.空闲);
                //bllGs.UpdateGsTaskStatusByRCL(vsgsm.StoreHouseName, vsgsm.GoodsSiteRow, vsgsm.GoodsSiteColumn,vsgsm.GoodsSiteLayer, EnumGSTaskStatus.完成);
                //string operteDetail = "[" + vsgsm.GoodsSiteName + "]货位状态由《" + vsgsm.GoodsSiteStatus + "》变更为《" + EnumCellStatus.空闲.ToString()
                //    + "》；" + "货位任务状态由《" + vsgsm.GoodsSiteTaskStatus + "》变更为《" + EnumGSTaskStatus.完成.ToString() + "》";

                //this.iStorageManager.AddGSOperRecord(vsgsm.StoreHouseName, new CellCoordModel(vsgsm.GoodsSiteRow, vsgsm.GoodsSiteColumn, vsgsm.GoodsSiteLayer)
                //    , EnumGSOperateType.手动修改状态, operteDetail, ref reStr);
                //this.view.AddLog("库存管理", "手动删除货位，同时更新货位状态" + operteDetail + "成功！", LogInterface.EnumLoglevel.提示);

            }
            QueryStock(this.currHouseName,this.currHouseArea, this.currRowth, this.currColth, this.currLayerth, this.gsStatus, this.gsTaskSta,this.currProBatch,this.isChecked,this.materialBoxCode);
            this.view.ClearStockDetailView();
        
        }
        Thread queryProductCountThread = null;
        public void QueryProductCount(object obj)
        {
            queryProductCountThread = new Thread(new ParameterizedThreadStart(QueryProductCountMethod));
            queryProductCountThread.IsBackground = true;

            queryProductCountThread.Start(obj);
        }
        private void QueryProductCountMethod(object obj)
        {
            QueryStockParamModel queryStockModel = (QueryStockParamModel)obj;
            DataTable stockView = bllViewStock.GetData(queryStockModel.HouseName,queryStockModel.HouseArea, queryStockModel.Rowth
                , queryStockModel.Colth, queryStockModel.Layerth, queryStockModel.GsStatus, queryStockModel.GsTaskStatus, queryStockModel.Batch,queryStockModel.IsCheck, queryStockModel.MaterialBoxCode);
            List<string> palletList = new List<string>();
            for(int i=0;i<stockView.Rows.Count;i++)
            {
                string pallet = stockView.Rows[i]["料框条码"].ToString();
                palletList.Add(pallet);
            }
            int productCount = GetProductCount(palletList);
            this.view.ShowProductCount(productCount.ToString());
            this.queryProductCountThread.Abort();
        }
        private int GetProductCount(List<string> palletIDs)
        {
            if(palletIDs==null)
            {
                return 0;
            }
            int productCount=0;
            for(int i=0;i<palletIDs.Count;i++)
            {
                productCount += bllProductOnLine.GetPalletProductCount(palletIDs[i]);
            }
            return productCount;
        }

        public void SetGsUseStatus(List<string> stockIDList, bool status)
        {
            string reStr = "";
            if(stockIDList == null)
            {
                return;
            }
            for(int i=0;i<stockIDList.Count;i++)
            {
                string stockID = stockIDList[i];
                View_StockGSModel stockGs = bllViewStockGs.GetModelByStockID(long.Parse(stockID));
                if(stockGs == null)
                {
                    continue;
                }
              
                bllGs.UpdateGSEnabledStatusByID(stockGs.GoodsSiteID, status);
                if(status == true)
                {
                    this.iStorageManager.AddGSOperRecord(stockGs.StoreHouseName, new CellCoordModel(stockGs.GoodsSiteRow,
                      stockGs.GoodsSiteColumn, stockGs.GoodsSiteLayer)
                     , EnumGSOperateType.手动启用货位, "手动启用货位", ref reStr);
                    this.view.AddLog("库存列表", "手动启用货位" + stockGs.GoodsSiteName, LogInterface.EnumLoglevel.提示);
                }
                else
                {
                    this.iStorageManager.AddGSOperRecord(stockGs.StoreHouseName, new CellCoordModel(stockGs.GoodsSiteRow,
                      stockGs.GoodsSiteColumn, stockGs.GoodsSiteLayer)
                     , EnumGSOperateType.手动禁用货位, "手动禁用货位", ref reStr);
                    this.view.AddLog("库存列表", "手动禁用货位" + stockGs.GoodsSiteName, LogInterface.EnumLoglevel.提示);
                }
              
            }
           //出完后库要再次查询防止重复出库
            QueryStock(this.currHouseName,this.currHouseArea, this.currRowth, this.currColth, this.currLayerth, this.gsStatus, this.gsTaskSta,this.currProBatch,this.isChecked,this.materialBoxCode);
        
            this.view.RefreshStorageView();
        }
        public void OutputManual(List<long> stockList)
        {
            string reStr = "";
            for (int i = 0; i < stockList.Count; i++)
            {
                View_StockGSModel skGsModel = bllViewStockGs.GetModelByStockID(stockList[i]);
                if (skGsModel == null)
                {
                    continue;
                }

                CellCoordModel cell = new CellCoordModel(skGsModel.GoodsSiteRow, skGsModel.GoodsSiteColumn, skGsModel.GoodsSiteLayer);
                if (this.iControl == null)
                {
                    return;
                }
                bool status = this.iControl.CreateManualOutputTask(skGsModel.StoreHouseName, cell, ref reStr);
                if(status == true)
                {
                    this.view.AddLog("库存管理", "手动出库货位：" + skGsModel.GoodsSiteName, LogInterface.EnumLoglevel.提示);
                    this.iStorageManager.AddGSOperRecord(skGsModel.StoreHouseName, cell, EnumGSOperateType.手动出库, "手动出库货位：" + skGsModel.GoodsSiteName, ref reStr);
                }
                else
                {
                    this.view.AddLog("库存管理", "手动出库货位：" + skGsModel.GoodsSiteName+"失败!" + reStr, LogInterface.EnumLoglevel.提示);
                    this.iStorageManager.AddGSOperRecord(skGsModel.StoreHouseName, cell, EnumGSOperateType.手动出库, "手动出库货位：" + skGsModel.GoodsSiteName + "失败" + reStr, ref reStr);
                }
           
            }
            //出完后库要再次查询防止重复出库
            QueryStock(this.currHouseName,this.currHouseArea, this.currRowth, this.currColth, this.currLayerth, this.gsStatus, this.gsTaskSta,this.currProBatch,this.isChecked,this.materialBoxCode);
        }
        /// <summary>
        /// 库存模块出厂设置，数据表格式化到初始值，清除库存，更新货位信息
        /// </summary>
        public void ReturnFac()
        {
            string reStr = "";
            bllGs.GsReturnFac();
            bllStock.DeleteAll();
            QueryStock(this.currHouseName, this.currHouseArea,this.currRowth, this.currColth, this.currLayerth, this.gsStatus, this.gsTaskSta,this.currProBatch,this.isChecked,this.materialBoxCode);
            this.view.AddLog("库存管理", "恢复出厂设置成功!", LogInterface.EnumLoglevel.提示);
            this.iStorageManager.AddGSOperRecord(this.currHouseName,new CellCoordModel(1,1,1),EnumGSOperateType.出厂设置,"恢复出厂设置",ref reStr);
        }

        public void DeleteStockList(string stockListID, int rowIndex)
        {
            string reStr = "";
            if (this.view.AskMessageBox("您确定要删除当前选中库存么？") != 1)
            {
                return;
            }
            View_StockModel viewStock = bllViewStock.GetModelByStockListID(long.Parse(stockListID));
            if(viewStock == null)
            {
                return;
            }
            bool deletesta = bllStockList.Delete(long.Parse(stockListID));
            if (deletesta == true)
            {
                this.iStorageManager.AddGSOperRecord(this.currHouseName
                    , new CellCoordModel(viewStock.GoodsSiteRow,viewStock.GoodsSiteColumn,viewStock.GoodsSiteRow), EnumGSOperateType.手动删除库存, "手动删除库存", ref reStr);
                this.view.DeletesStockListRow(rowIndex);
            }
        }
        public void ModifyStockList(string stockID, string oldCode,string newCode)
        {
            char[] splitArr = { ',', '，' };
            string[] stockListStr = newCode.Split(splitArr);
            StockModel sm = bllStock.GetModel(long.Parse(stockID));
            if (sm == null)//没有库存信息
            {

                return;
            }
        
            List<StockListModel> stockList = bllStockList.GetListByStockID(long.Parse(stockID));
            if (stockList.Count != stockListStr.Length)
            {
                this.view.AddLog("库存管理", "料框条码个数错误！", LogInterface.EnumLoglevel.提示);
                return;
            }
            for (int i = 0; i < stockList.Count; i++)
            {
                StockListModel slm = stockList[i];
                if (stockListStr.Length > i)
                {
                    slm.MeterialboxCode = stockListStr[i];
                    bllStockList.Update(slm);

                }

            }
            this.view.AddLog("库存管理", "库存料框条码由："+oldCode + "手动修改为：" + newCode , LogInterface.EnumLoglevel.提示);
            
            //RefreshStockList(long.Parse(stockID));
            QueryStock(this.currHouseName, this.currHouseArea, this.currRowth, this.currColth, this.currLayerth, this.gsStatus, this.gsTaskSta, this.currProBatch,this.isChecked, this.materialBoxCode);
        }
        public void AddStockList(string stockID,string boxCodeList)
        {
            char[] splitArr = {',','，'};
            string[] stockList = boxCodeList.Split(splitArr);
            StockModel sm = bllStock.GetModel(long.Parse(stockID));
            if(sm == null)//没有库存信息
            {
              
                return;
            }
            for(int i=0;i<stockList.Length;i++)
            {
                StockListModel slm = new StockListModel();
                slm.StockID = long.Parse(stockID);
                slm.MeterialboxCode = stockList[i];
                slm.InHouseTime = DateTime.Now;
                bllStockList.Add(slm);
            }
            RefreshStockList(long.Parse(stockID));
        }
        
    }
}
