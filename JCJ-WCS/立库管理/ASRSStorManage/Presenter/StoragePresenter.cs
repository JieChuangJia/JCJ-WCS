using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

using ASRSStorManage.View;
using Storage;
using AsrsStorDBAcc.BLL;
using AsrsStorDBAcc.Model;
using AsrsModel;
using System.Data;
using LogInterface;
using AsrsInterface;
using System.Xml.Linq;
using System.Xml;
namespace ASRSStorManage.Presenter
{
    public class StoragePresenter
    {
        StorageView view;
        GoodsSiteBLL bllGs = new GoodsSiteBLL();
        StoreHouseBLL bllStoreHouse = new StoreHouseBLL();
        View_GoodsSiteBLL bllViewGs = new View_GoodsSiteBLL();
        View_StockBLL bllViewStock = new View_StockBLL();
        View_StockGSBLL bllViewStockGs = new View_StockGSBLL();
     

        StockListBLL bllStockList = new StockListBLL();
        StockBLL bllStock = new StockBLL();

        StoreHouseLogicAreaBLL bllLogicArea = new StoreHouseLogicAreaBLL();
        Dictionary<string, Color> gsStatusColor = new Dictionary<string, Color>();
        Dictionary<long, Color> areaColor = new Dictionary<long, Color>();
         
        IAsrsCtlToManage iControl = null;
        IAsrsManageToCtl iStorageManage = null;
        string currHouseName = "A库房";
        int currRowth = 1;
        string filePath = AppDomain.CurrentDomain.BaseDirectory + @"\data\GoogsSiteCfg.xml";
        XMLOperater xmlOper = null;
        public StoragePresenter(StorageView view)
        {
            this.view = view;
            gsStatusColor[EnumCellStatus.空料框.ToString()] = Color.Yellow;
            gsStatusColor[EnumCellStatus.空闲.ToString()] = Color.Transparent;
            gsStatusColor[EnumCellStatus.满位.ToString()] = Color.Green;
            gsStatusColor[EnumGSEnabledStatus.禁用.ToString()] = Color.Red;
            gsStatusColor[EnumGSTaskStatus.锁定.ToString()] = Color.Blue;
            gsStatusColor[EnumGSTaskStatus.出库允许.ToString()] = Color.Blue;

            IniAreaColorDic();
            string rstr="";
            LoadAreaColorCfg(ref rstr);
            xmlOper = new XMLOperater(filePath);
          
        }

        private void IniAreaColorDic()
        {
            List<StoreHouseLogicAreaModel> allLogicArea = bllLogicArea.GetModelList("");
            if (allLogicArea == null)
            {
                return;
                
            }
            //if(allLogicArea.Count!=2)
            //{
            //    return;
            //}
            for (int i = 0; i < allLogicArea.Count;i++ )//动态生成分区颜色
            {
                int interval = 128 / allLogicArea.Count;
                int r = 128 +i * interval;
                int g = 128 - i * interval;
                int b = 0 + i * interval;
                if(r>=255)
                {
                    r = 255;
                }
                if(g<=0)
                {
                    g = 0;
                }
                if(b>=255)
                {
                    b = 255;
                }
                areaColor[allLogicArea[i].StoreHouseLogicAreaID] = Color.FromArgb(r, g, b);

              //  areaColor[allLogicArea[1].StoreHouseLogicAreaID] = Color.FromArgb(60, 179, 113);
            }

              

        }
        public void IniPresenter(IAsrsManageToCtl iAsrsManageToCtl, IAsrsCtlToManage iAsrsCtlToManage)
        {
            this.iControl = iAsrsCtlToManage;
            this.iStorageManage = iAsrsManageToCtl; 
            StorageMainView.storageMana.EventUpateGsStatus += UpdateGsStatusEventHandler;
          //  this.iStorageManage.EventStorageViewAddExpandForm += ShowExpandProFormEventHandler;
           
        }
        public void LoadData()
        {
            /*List<StoreHouseModel> houseModelList = bllStoreHouse.GetModelList("");
            List<string> houseList = new List<string>();
            if (houseModelList == null)
            {
                return;
            }
            for (int i = 0; i < houseModelList.Count; i++)
            {
                houseList.Add(houseModelList[i].StoreHouseName);
            }
            this.view.BindHouseData(houseList);*/
            XmlNodeList houseNodeList = xmlOper.GetNodesByName("StoreHouse");
            if (null == houseNodeList)
            {
                return;
            }

            List<string> houseList = new List<string>();
            for (int i = 0; i < houseNodeList.Count; i++)
            {
                XmlNode house = houseNodeList[i];
                foreach (XmlAttribute xmlAttri in house.Attributes)
                {
                    houseList.Add(xmlAttri.Value);
                }
            }
            this.view.BindHouseData(houseList);
        }

        public void ChangeHouse(string houseName)
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
        public void RefreshPos(string houseName,int queryRow)
        {
            List<Positions> allPos = new List<Positions>();
            StoreHouseModel house= bllStoreHouse.GetModelByName(houseName);
            if(null == house)
            {
                return;
            }
            List<GoodsSiteModel> gsList = bllGs.GetModelListByRow(house.StoreHouseID, queryRow);
            if (gsList == null)
            {
                return;
            }
            for (int i = 0; i < gsList.Count; i++)
            {
                GoodsSiteModel gsModel = gsList[i];
                Positions pos = new Positions();
                bool status = CreatePos(gsModel, ref pos);
                if(status == false)
                {
                    continue;
                }
                allPos.Add(pos);
            }
            this.view.RefreshPos(allPos);
            this.currHouseName = houseName;
            this.currRowth = queryRow;
            RefreshGsStatusNum(house.StoreHouseID, queryRow);
        }
        private void UpdateGsStatusEventHandler(object sender,EventArgs e)
        {
            this.view.RefreshData();
        }
        //private void ShowExpandProFormEventHandler(object sender,ExpandFormEventArgs e)
        //{
        //    this.view.ShowExpandForm(e.ExpandForm);
        //}
        public void OnCellExpandPro(Positions pos)
        {
          
            if(pos == null)
            {
                return;
            }
            View_GoodsSiteModel viewGS = bllViewGs.GetModelByGSID(pos.GoodsSiteID);
            if (viewGS == null)
            {
                return;
            }
            CellPositionEventArgs cpea = new CellPositionEventArgs();
            cpea.HouseName = viewGS.StoreHouseName;
            cpea.CellCoord = new CellCoordModel(viewGS.GoodsSiteRow, viewGS.GoodsSiteColumn, viewGS.GoodsSiteLayer);
            this.view.ShowExtForm(ExtendFormCate.外部);
            StorageMainView.storageMana.OnEventCellClicked(cpea);
          
        }
        /// <summary>
        /// 启用单列
        /// </summary>
        /// <param name="houseName">库房名称</param>
        /// <param name="rowth">排</param>
        /// <param name="colth">列</param>
        public void UseOrForbitSingleColGs(string houseName, int rowth, int stCol,int edCol, bool status)
        {
            string reStr = "";
            for(int i=stCol;i<=edCol;i++)
            {
                bool updateStatus = bllGs.SetMultiGsSinleColEnbledStatus(houseName, rowth, i, status);
                if (updateStatus == true)
                {
                    if (status == true)
                    {
                        this.iStorageManage.AddGSOperRecord(houseName, new CellCoordModel(rowth, i, 1), EnumGSOperateType.手动启用货位, "手动批量启用第" + i + "列货位", ref reStr);
                    }
                    else
                    {
                        this.iStorageManage.AddGSOperRecord(houseName, new CellCoordModel(rowth, i, 1), EnumGSOperateType.手动禁用货位, "手动批量禁用第" + i + "列货位", ref reStr);
                    }
                }
            }
           
            RefreshPos(this.currHouseName, this.currRowth);
          
        }
        /// <summary>
        /// 启用单层
        /// </summary>
        /// <param name="houseName">库房名称</param>
        /// <param name="rowth">排</param>
        /// <param name="layerth">层</param>
        public void UseOrForbitSingleLayerGs(string houseName, int rowth, int layerth, bool status)
        {
            string reStr = "";
            bool updateStatus = bllGs.SetMultiGsSinleLayerEnbledStatus(houseName, rowth, layerth, status);
            if (updateStatus == true)
            {
                if (status == true)
                {
                  
                    this.iStorageManage.AddGSOperRecord(houseName, new CellCoordModel(rowth, 1, layerth), EnumGSOperateType.手动启用货位, "手动批量启用第" + layerth + "层货位", ref reStr);
                }
                else
                {
                    this.iStorageManage.AddGSOperRecord(houseName, new CellCoordModel(rowth, 1, layerth), EnumGSOperateType.手动禁用货位, "手动批量禁用第" + layerth + "层货位", ref reStr);
                }
                RefreshPos(this.currHouseName, this.currRowth);
            }
        }

        public void UseOrForbitSingleGs(string houseName,string gsName,bool status)
        {
            string reStr = "";
            bool updateStatus =  bllGs.SetMultiGsSinleGsEnbledStatus(houseName, gsName, status);

            if (updateStatus == true)
            {
                string[] posList= gsName.Split('-');
                if (status == true)
                {
                    this.iStorageManage.AddGSOperRecord(houseName, new CellCoordModel(int.Parse(posList[0]), int.Parse(posList[1]), int.Parse(posList[2])), EnumGSOperateType.手动启用货位, "手动批量启用:" + gsName + "货位", ref reStr);
                }
                else
                {
                    this.iStorageManage.AddGSOperRecord(houseName, new CellCoordModel(int.Parse(posList[0]), int.Parse(posList[1]), int.Parse(posList[2])), EnumGSOperateType.手动禁用货位, "手动批量禁用" + gsName + "货位", ref reStr);
                }

            }
        }
        public void MoveGsManual(string startHouseName, CellCoordModel startGsPos, string endHouseName, CellCoordModel endGsPos)
        {
            string reStr = "";
            
            if (this.iControl == null)
            {
                return;
            }
            bool status = this.iControl.CreateManualMoveGSTask(startHouseName, startGsPos, endHouseName, endGsPos, ref reStr);
            string operateStr = "手动移库：从" + startHouseName+"," + startGsPos.Row+"排"+startGsPos.Col+"列"+startGsPos.Layer+"层"
                + "移至" + endHouseName + "," + endGsPos.Row + "排" + endGsPos.Col + "列" + endGsPos.Layer + "层";
            if (status == true)
            {
                this.iStorageManage.AddGSOperRecord(startHouseName, startGsPos, EnumGSOperateType.手动移出库房, operateStr, ref reStr);
                this.view.AddLog("库存管理", operateStr+"成功！", LogInterface.EnumLoglevel.提示);
            }
            else
            {
                this.view.AddLog("库存管理", operateStr + "失败！", LogInterface.EnumLoglevel.提示);
            }
            RefreshPos(this.currHouseName,this.currRowth);//刷新
        }
        public void OutputManual(long gsID)
        {
            string reStr = "";
            //View_StockGSModel skGsModel = bllViewStockGs.GetModelByGSID(gsID);
            //if (skGsModel == null)
            //{
            //    this.view.AddLog("库存管理", "手动出库货失败，没有库存！", LogInterface.EnumLoglevel.提示);
            //    return;
            //}
            try
            {
                View_GoodsSiteModel vgsm = bllViewGs.GetModelByGSID(gsID);
                if (vgsm == null)
                {
                    this.view.AddLog("库存管理", "货位错误！", LogInterface.EnumLoglevel.提示);
                    return;
                }

                CellCoordModel cell = new CellCoordModel(vgsm.GoodsSiteRow, vgsm.GoodsSiteColumn, vgsm.GoodsSiteLayer);
                if (this.iControl == null)
                {
                    return;
                }
                bool status = this.iControl.CreateManualOutputTask(vgsm.StoreHouseName, cell, ref reStr);
                if (status == true)
                {
                    this.view.AddLog("库存管理", "手动出库货位：" + vgsm.GoodsSiteName + "成功！", LogInterface.EnumLoglevel.提示);
                    this.iStorageManage.AddGSOperRecord(vgsm.StoreHouseName, cell, EnumGSOperateType.手动出库, "手动出库货位：" + vgsm.GoodsSiteName, ref reStr);
                }
                else
                {
                    this.view.AddLog("库存管理", "手动出库货位：" + vgsm.GoodsSiteName + "失败！" + reStr, LogInterface.EnumLoglevel.提示);
                    this.iStorageManage.AddGSOperRecord(vgsm.StoreHouseName, cell, EnumGSOperateType.手动出库, "手动出库货位：" + vgsm.GoodsSiteName + "失败" + reStr, ref reStr);
                }

                RefreshPos(vgsm.StoreHouseName, vgsm.GoodsSiteRow);//刷新
            }
            catch (Exception ex)
            {
                Console.WriteLine("发生异常：" + ex.ToString());
            }
           
        }
        public void ModifyStockCode(long stockListID,long gsID,string boxCode)
        {
            StockListModel slm = bllStockList.GetModel(stockListID);
            if(slm == null)
            {
                return;
            }
            slm.MeterialboxCode = boxCode;
            bllStockList.Update(slm);
            
            GetGSDetail(gsID);
        }
        public void AddStockList(long  gsID,string boxCodeList)
        {
            GoodsSiteModel gsm = bllGs.GetModel(gsID);
            if(gsm == null)
            {
                return;
            }
            if(gsm.GoodsSiteStatus == EnumCellStatus.空料框.ToString())
            {
                this.view.ShowMessage("空料框状态不允许修改库存信息，若需求更改库存请更改货位状态为非空料框状态！");
                return;
            }
            List<View_StockModel> stockView = bllViewStock.GetModelListByGSID(gsID);
            char[] splitArr = { ',', '，' };

            string[] stockListStr = boxCodeList.Split(splitArr);
            long stockID = 0;
            if (stockView == null||stockView.Count==0)//没有增加stock
            {
                StockModel stock = new StockModel();
                stock.GoodsSiteID = gsID;
                stock.IsFull = true;
                stockID = bllStock.Add(stock);
            }
            else//更新原有stock
            {
                stockID = stockView[0].StockID;
            }

            for (int i = 0; i < stockListStr.Length; i++)
            {
                StockListModel slm = new StockListModel();
                slm.StockID = stockID;
                slm.MeterialboxCode = stockListStr[i];
                slm.InHouseTime = DateTime.Now;
                bllStockList.Add(slm);
            }
            string reStr = "";
            this.iStorageManage.AddGSOperRecord(this.currHouseName, new CellCoordModel(gsm.GoodsSiteRow, gsm.GoodsSiteColumn, gsm.GoodsSiteLayer), EnumGSOperateType.手动增加库存, "手动增加或者修改库存信息！", ref reStr);
            GetGSDetail(gsID);
        }
        public void SearchBoxByCode(string boxCode)
        {
            if(boxCode == "")
            {
                this.view.ShowMessage("请输入要查询的条码！");
                return;
            }

            View_StockModel gsModel = bllViewStock.GetModelByBoxCode(boxCode);
            if (null == gsModel)
            {
                this.view.ShowMessage("查无此条码！");
                return; 
            }

            RefreshPos(gsModel.StoreHouseName, gsModel.GoodsSiteRow);
            this.view.GsSearch(gsModel.GoodsSiteColumn, gsModel.GoodsSiteLayer);

        }
        /// <summary>
        /// 设置单个货位的逻辑区域
        /// </summary>
        /// <param name="houseName"></param>
        /// <param name="gsName"></param>
        /// <returns></returns>
        public bool SetSingleGsArea(string houseName,string gsName,string logicAreaName )
        {
            string reStr = "";
            StoreHouseModel house = bllStoreHouse.GetModelByName(houseName);
            if (null == house)
            {
                return false;
            }
            StoreHouseLogicAreaModel logicArea =bllLogicArea.GetModelByName(logicAreaName);
            if(logicArea == null)
            {
                return false;
            }
            bool status = bllGs.SetSingleGsArea(house.StoreHouseID, logicArea.StoreHouseLogicAreaID, gsName);
            if(status ==  true)
            {
                string[] rcl = gsName.Split('-');
                this.iStorageManage.AddGSOperRecord(houseName, new CellCoordModel(int.Parse(rcl[0]), int.Parse(rcl[1]), int.Parse(rcl[2]))
                    , EnumGSOperateType.库存区域设置, "手动单货位库存区域设置:货位" + gsName + "为：" + logicArea.StoreHouseAreaName, ref reStr);
                RefreshPos(this.currHouseName, currRowth);
                return true;
            }
            else
            {
                return false;
            }
          
        }
        /// <summary>
        /// 设置整列逻辑区域
        /// </summary>
        /// <param name="houseName"></param>
        /// <param name="colth"></param>
        /// <returns></returns>
        public bool SetMulLayerMulColArea(string houseName,int rowth, int stCol,int edCol,int stLayer,int edLayer,string logicAreaName)
        {
            string reStr = "";
            StoreHouseModel house = bllStoreHouse.GetModelByName(houseName);
            if (null == house)
            {
                return false;
            }
            StoreHouseLogicAreaModel logicArea = bllLogicArea.GetModelByName(logicAreaName);
            if (logicArea == null)
            {
                return false;
            }
            //for (int i = stCol; i <= edCol; i++)
            //{

             bool status = bllGs.SetMulLayerMulColGsArea(house.StoreHouseID, logicArea.StoreHouseLogicAreaID, rowth, stCol,edCol,stLayer,edLayer);
                if (status == false)
                {
                    return false;
                }
                //for (int layer = stLayer; layer <= edLayer;layer ++ )
                //{
                //    for(int col = stCol;col<=edCol;col++)
                //    {
                this.iStorageManage.AddGSOperRecord(houseName, new CellCoordModel(rowth, stCol, stLayer)
                    , EnumGSOperateType.库存区域设置, "手动多层多列库存区域设置:起始列[" + stCol + "]终止列["+edCol+"] 起始层["+stLayer+"]"
                    +"终止层[" +edLayer+"] 为->"+ logicArea.StoreHouseAreaName, ref reStr);
                //    }
                //}
                

            //}
            RefreshPos(this.currHouseName, currRowth);
            return true;
             
        }
        /// <summary>
        /// 设置整行逻辑区域
        /// </summary>
        /// <param name="houseName"></param>
        /// <param name="layerth"></param>
        /// <returns></returns>
        public bool SetSingleLayerArea(string houseName, int rowth,int layerth, string logicAreaName)
        {
            string reStr = "";
            StoreHouseModel house = bllStoreHouse.GetModelByName(houseName);
            if (null == house)
            {
                return false;
            }
            StoreHouseLogicAreaModel logicArea = bllLogicArea.GetModelByName(logicAreaName);
            if (logicArea == null)
            {
                return false;
            }
            bool status = bllGs.SetSingleLayerGsArea(house.StoreHouseID, logicArea.StoreHouseLogicAreaID,rowth, layerth);
            if (status == true)
            {

                this.iStorageManage.AddGSOperRecord(houseName, new CellCoordModel(rowth, 1, 1)
                   , EnumGSOperateType.库存区域设置, "手动单层库存区域设置:货位层" + layerth + "为：" + logicArea.StoreHouseAreaName, ref reStr);
                RefreshPos(this.currHouseName, currRowth);
                return true;
            }
            else
            {
                return false;
            }
             
        }
        public void ModifyGsStatus(string houseName,long gsID, string gsStatus, string gsTaskStatus)
        {
            string reStr = "";
            StoreHouseModel house = bllStoreHouse.GetModelByName(houseName);
            if (null == house)
            {
                return;
            }
            GoodsSiteModel oldgsm = bllGs.GetModel(gsID);
            if (oldgsm == null)
            {
                return;
            }
            if (oldgsm.GsEnabled == false)
            {
                this.view.AddLog("库存看板", "被禁用的货位不允许修改状态!", LogInterface.EnumLoglevel.提示);
                return;
            }
            bllGs.UpdateGSStatusByRCL(houseName, oldgsm.GoodsSiteRow, oldgsm.GoodsSiteColumn, oldgsm.GoodsSiteLayer, (EnumCellStatus)Enum.Parse(typeof(EnumCellStatus), gsStatus));
            bllGs.UpdateGsTaskStatusByRCL(houseName, oldgsm.GoodsSiteRow, oldgsm.GoodsSiteColumn, oldgsm.GoodsSiteLayer, (EnumGSTaskStatus)Enum.Parse(typeof(EnumGSTaskStatus), gsTaskStatus));

            if(gsTaskStatus == EnumGSTaskStatus.出库允许.ToString())
            {
                bllGs.UpdateOperateByRCL(houseName, oldgsm.GoodsSiteRow, oldgsm.GoodsSiteColumn, oldgsm.GoodsSiteLayer, EnumGSOperate.出库);
            }
            string operteDetail = "[" + oldgsm.GoodsSiteName + "]货位状态由《" + oldgsm.GoodsSiteStatus + "》变更为《" + gsStatus + "》；" + "货位任务状态由《" + oldgsm.GoodsSiteTaskStatus + "》变更为《" + gsTaskStatus + "》";

            this.iStorageManage.AddGSOperRecord(houseName, new CellCoordModel(oldgsm.GoodsSiteRow, oldgsm.GoodsSiteColumn, oldgsm.GoodsSiteLayer), EnumGSOperateType.手动修改状态, operteDetail, ref reStr);

            this.view.AddLog("库存看板", operteDetail, LogInterface.EnumLoglevel.提示);

            RefreshPos(houseName, oldgsm.GoodsSiteRow);
        }
        private void RefreshGsStatusNum(long houseID, int rowth)
        {
            //DataTable dtStatusNum = bllGs.GetStatusNum(houseID, rowth);
            //DataTable gsLockNum = bllGs.GetGsLockCount(houseID, rowth);
            //DataTable fobitNum = bllGs.GetForbitGsCount(houseID, rowth);


            int nullBoxNum = bllGs.GetNullBoxCount(houseID, rowth);
            int productNum = bllGs.GetFullGsCount(houseID, rowth);
            int idleNum = bllGs.GetIdleGsCount(houseID, rowth);
            int taskLockNum = bllGs.GetGsLockCount(houseID, rowth);
            int forbitNum = bllGs.GetForbitGsCount(houseID, rowth);
            int outAllowNum = bllGs.GetOutAllowCount(houseID, rowth);

            //for (int i = 0; i < gsLockNum.Rows.Count; i++)
            //{
            //    taskLockNum += int.Parse(gsLockNum.Rows[i][0].ToString());
            //}
            //for (int i = 0; i < fobitNum.Rows.Count; i++)
            //{
            //    forbitNum += int.Parse(fobitNum.Rows[i][0].ToString());
            //}

            //for (int i = 0; i < dtStatusNum.Rows.Count; i++)
            //{
            //    nullNum += int.Parse(dtStatusNum.Rows[i][0].ToString());
            //    productNum += int.Parse(dtStatusNum.Rows[i][1].ToString());
            //    nullFramNum += int.Parse(dtStatusNum.Rows[i][2].ToString());
            //    // taskLockNum += int.Parse(dtStatusNum.Rows[i][3].ToString());
            //    //  forbitNum += int.Parse(dtStatusNum.Rows[i][4].ToString());
            //}
            this.view.RefreshGSStatsuNum(nullBoxNum, productNum, idleNum, taskLockNum, forbitNum, outAllowNum);
        }
        public void GetGSDetail(long goodsSiteID)
        {
            List<View_StockModel> modelList = bllViewStock.GetModelListByGSID(goodsSiteID);
            this.view.RefreshGSDetail(modelList);
            if(modelList!= null&&modelList.Count>0)
            {
                this.currHouseName = modelList[0].StoreHouseName;
                this.currRowth = modelList[0].GoodsSiteRow;
            }
         
        }

        public void DeleteStockList(long stockListID,int index)
        {
            bool deleteSta = bllStockList.Delete(stockListID);
            if(deleteSta == true)
            {
                this.view.DeleteStockListRow(index);
            }
        }
        public void SetGsStatus(long gsID, bool status)
        {
            string reStr = "";
            bllGs.UpdateGSEnabledStatusByID(gsID,status);
            GoodsSiteModel gsm = bllGs.GetModel(gsID);
            if(gsm == null)
            {
                return;
            }
            StoreHouseModel house = bllStoreHouse.GetModel(gsm.StoreHouseID);
            if(house == null)
            {
                return;
            }
            if(status == true)
            {
                this.view.AddLog("库存看板", "货位《" + gsm.GoodsSiteName + "》启用！" , EnumLoglevel.提示);

                this.iStorageManage.AddGSOperRecord(house.StoreHouseName, new CellCoordModel(gsm.GoodsSiteRow,
                      gsm.GoodsSiteColumn, gsm.GoodsSiteLayer)
                     , EnumGSOperateType.手动启用货位, "手动启用货位", ref reStr);
            }
            else
            {
                this.iStorageManage.AddGSOperRecord(house.StoreHouseName, new CellCoordModel(gsm.GoodsSiteRow,
                   gsm.GoodsSiteColumn, gsm.GoodsSiteLayer)
                  , EnumGSOperateType.手动禁用货位, "手动禁用货位", ref reStr);
                this.view.AddLog("库存看板", "货位《" + gsm.GoodsSiteName + "》禁用！", EnumLoglevel.提示);
            }
           
        }
        
        private bool CreatePos(GoodsSiteModel gsModel,ref Positions posRef)
        {
            if(gsModel == null)
            {
                return false;
            }
            Positions pos = new Positions();
            pos.Columnth = gsModel.GoodsSiteColumn;
            pos.Layer = gsModel.GoodsSiteLayer;
            pos.Rowth = gsModel.GoodsSiteRow;
            pos.StoreStatus = gsModel.GoodsSiteStatus;
            pos.TaskType = gsModel.GoodsSiteTaskStatus;
            pos.GoodsSiteID = gsModel.GoodsSiteID;
            pos.enbled = gsModel.GsEnabled;
            pos.Visible = true;
            posRef = pos;
           //此处增加库房和库房区域ID

            pos.Color = gsStatusColor[gsModel.GoodsSiteStatus];

            if (gsModel.StoreHouseLogicAreaID == null)
            {
                pos.BorderColor = Color.Black;//没有分区默认为黑色
            }
            else
            {
                pos.BorderColor = areaColor[(long)gsModel.StoreHouseLogicAreaID];
            }
           
           // pos.BorderColor = Color.LightGray;
            if (gsModel.GoodsSiteTaskStatus == EnumGSTaskStatus.锁定.ToString())
            {

                pos.Color = gsStatusColor[gsModel.GoodsSiteTaskStatus];
                if (gsModel.GoodsSiteOperate == EnumGSOperate.出库.ToString())
                {
                    pos.PosText ="出";
                }
                else if (gsModel.GoodsSiteOperate == EnumGSOperate.入库.ToString())
                {
                    pos.PosText = "入";
                }
                else if(gsModel.GoodsSiteOperate == EnumGSOperate.移入库.ToString())
                { }
                else if(gsModel.GoodsSiteOperate == EnumGSOperate.移出库.ToString())
                { }
                else
                { }

                
            }
            if (gsModel.GoodsSiteTaskStatus == EnumGSTaskStatus.出库允许.ToString())
            {
                pos.Style = 2;
            }
            else
            {
                pos.Style = 1;
            }

            if(pos.Enbled == false)
            {
                pos.Color = gsStatusColor[EnumGSEnabledStatus.禁用.ToString()];
            }
            return true;
        }
        public List<string> GetLogicAreaList()
        {
            List<string> logicArea = new List<string>();
            List<StoreHouseLogicAreaModel> allLogicArea = bllLogicArea.GetModelList("");
            if (allLogicArea == null)
            {
                return null;
            }
            for(int i=0;i<allLogicArea.Count;i++)
            {
                logicArea.Add(allLogicArea[i].StoreHouseAreaName);
            }
            return logicArea;
        }
        public bool SetAreaColorCfg(string logicAreaName, Color color, ref string reStr)
        {
            StoreHouseLogicAreaModel logicArea = bllLogicArea.GetModelByName(logicAreaName);
            if (logicArea == null)
            {
                return false;
            }
            if (this.areaColor.Keys.Contains(logicArea.StoreHouseLogicAreaID) == true)
            {
                foreach (Color col in this.areaColor.Values)
                {
                    if (col.R == color.R && col.G == color.G&&col.B == color.B)
                    {
                        reStr = "已经存在相同库区颜色！";

                        return false;
                    }
                }

            }
            this.areaColor[logicArea.StoreHouseLogicAreaID] = color;

            //CtlDBAccess.BLL.SysCfgBll sysCfgBll = new CtlDBAccess.BLL.SysCfgBll();
            //CtlDBAccess.Model.SysCfgDBModel cfgModel = sysCfgBll.GetModel(SysCfg.SysCfgModel.SysCfgFileName);
            //XElement root = null;

            //if (cfgModel == null)
            //{
            //    reStr = "系统配置不存在!";
            //    return false;
            //}
            XElement root = XElement.Parse(SysCfg.SysCfgModel.xmlCfgStr);
            if (root == null)
            {
                reStr = "系统配置不存在!";
                return false;
            }
            XElement houseAreaColorSet = root.Element("sysSet").Element("HouseAreaColorSet");
            if (houseAreaColorSet == null)
            {
                reStr = "系统逻辑库存颜色信息不存在!";
                return false;
            }
            houseAreaColorSet.Elements().Remove();//移除所有节点
           foreach(KeyValuePair<long,Color> kv in this.areaColor)
           {
               long logicID =kv.Key;
               StoreHouseLogicAreaModel logicAreaModel = bllLogicArea.GetModel(logicID);
               if (logicAreaModel == null)
               {
                   continue;
               }
               string rgb = kv.Value.R +","+ kv.Value.G+","+ kv.Value.B;
               XElement element = new XElement("HouseArea", new XAttribute("houseAreaID", logicID), new XAttribute("areaName", logicAreaModel.StoreHouseAreaName));
               element.Value = rgb;
               houseAreaColorSet.Add(element);
           }
           //if (cfgModel != null)
           //{
           //    cfgModel.cfgFile = root.ToString();
           //    sysCfgBll.Update(cfgModel);
           //}
         
           SysCfg.SysCfgModel.SaveCfg(root.ToString(),ref reStr);
           ShowAreaColor();
           RefreshPos(this.currHouseName, currRowth);
            return true;
        }
        private  bool LoadAreaColorCfg(ref string reStr)
        {
            try
            {
                //CtlDBAccess.BLL.SysCfgBll sysCfgBll = new CtlDBAccess.BLL.SysCfgBll();
                //CtlDBAccess.Model.SysCfgDBModel cfgModel = sysCfgBll.GetModel(SysCfg.SysCfgModel.SysCfgFileName);
                //XElement root = null;

                //if (cfgModel == null)
                //{
                //    reStr = "系统配置不存在!";
                //    return false;
                //}

                XElement root = XElement.Parse(SysCfg.SysCfgModel.xmlCfgStr);
                if (root == null)
                {
                    reStr = "系统配置不存在!";
                    return false;
                }
                IEnumerable<XElement> houseArea = root.Element("sysSet").Element("HouseAreaColorSet").Elements("HouseArea");

                if (houseArea == null)
                {
                    reStr = "系统逻辑库存颜色信息不存在!";
                    return false;
                }
                 
                foreach (XElement element in houseArea)
                {
                    string houseAreaID = element.Attribute("houseAreaID").Value;
                    string areaName = element.Attribute("areaName").Value;
                    string[] rgbArr = element.Value.Split(',');
                    //if (this.areaColor.Keys.Contains(long.Parse(houseAreaID))==true)
                    //{
                    //    continue;
                    //}
                    this.areaColor[long.Parse(houseAreaID)] =Color.FromArgb(int.Parse( rgbArr[0]),int.Parse(rgbArr[1]),int.Parse(rgbArr[2]));
                  
                }
                ShowAreaColor();
               
                return true;
            }
            catch (Exception ex)
            {
                reStr = ex.ToString();
                return false;
            }
        }

        private void ShowAreaColor()
        {
            Dictionary<string, Color> areaColor = new Dictionary<string, Color>();
            foreach (KeyValuePair<long, Color> kv in this.areaColor)
            {
                long logicID = kv.Key;
                StoreHouseLogicAreaModel logicAreaModel = bllLogicArea.GetModel(logicID);
                if (logicAreaModel == null)
                {
                    continue;
                }
                areaColor[logicAreaModel.StoreHouseAreaName] = kv.Value;
            }
            this.view.ShowLogicAreaColor(areaColor);
        }
    }
}
