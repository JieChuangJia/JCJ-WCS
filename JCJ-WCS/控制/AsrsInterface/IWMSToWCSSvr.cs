 
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using AsrsInterface;
namespace WMS_Interface
{
  //public interface IAsrsManageToCtl
  //{
  //    #region 老版本wms接口
  //    /// <summary>
  //    /// 注册外部扩展窗体，控制模块注册
  //    /// </summary>
  //    /// <param name="storPanelView">货位看板扩展窗体</param>
  //    /// <param name="sotrListView">库存列表扩展窗体</param>
  //    //void RegistExtViewStorePanel(Form storPanelView,Form sotrListView); 
  //    /// <summary>
  //    /// 库存看板单元格点击事件，控制模块注册
  //    /// </summary>
  //    //event  EventHandler<CellPositionEventArgs> EventCellClicked; 
  //    /// <summary>
  //    /// 库存列表详细扩展事件，控制模块注册
  //    /// </summary>
  //    //event  EventHandler<StockListProEventArgs> EventStorDetail; 
  //    /// <summary>
  //    /// 货位申请
  //    /// </summary>
  //    /// <param name="houseName">库名称,管理层、控制层约定好即可</param>
  //    /// <param name="logicAreaName">库房逻辑区域名称</param>
  //    /// <param name="cellCoord">若申请成功，返回货位坐标</param>
  //    /// <param name="reStr">若申请失败，返回原因信息</param>
  //    /// <returns>申请成功返回true，否则返回false</returns>
  //    bool CellRequire(string houseName, string logicAreaName, ref CellCoordModel cellCoord, ref string reStr);

  //    /// <summary>
  //    ///货位申请
  //    /// </summary>
  //    /// <param name="houseName"></param>
  //    /// <param name="logicAreaName"></param>
  //    /// <param name="cellCoord"></param>
  //    /// <param name="reStr"></param>
  //    /// <returns></returns>
  //    bool CellRequireByRow(string houseName, string logicAreaName, int row, ref CellCoordModel cellCoord, ref string reStr);

  //    /// <summary>
  //    /// 查询入库时间
  //    /// </summary>
  //    /// <param name="houseName"></param>
  //    /// <param name="cellCoord"></param>
  //    /// <param name="inputDT"></param>
  //    /// <returns>若货位空，返回false</returns>
  //    bool GetCellInputTime(string houseName, CellCoordModel cellCoord, ref System.DateTime inputDT);

  //    /// <summary>
  //    /// 获取库存货位剩余量
  //    /// </summary>
  //    /// <param name="houseName">库房名称</param>
  //    /// <param name="houseAreaName">逻辑库存名称</param>
  //    /// <param name="gsCount">货位数量</param>
  //    /// <returns>查询状态</returns>
  //    bool GetHouseAreaLeftGs(string houseName, string houseAreaName, ref int gsCount, string reStr);

  //    /// <summary>
  //    /// 查询货位状态
  //    /// </summary>
  //    /// <param name="houseName">库房名称</param>
  //    /// <param name="cellCoord">货位位置</param>
  //    /// <param name="cellStatus">货位状态</param>
  //    /// <param name="taskStatus">货位任务状态</param>
  //    /// <returns>查询状态</returns>
  //    bool GetCellStatus(string houseName, CellCoordModel cellCoord, ref EnumCellStatus cellStatus, ref EnumGSTaskStatus taskStatus);

  //    /// <summary>
  //    /// 获取逻辑库区名称
  //    /// </summary>
  //    /// <param name="houseName">库房名称</param>
  //    /// <param name="cell">货位位置</param>
  //    /// <param name="logicArea">库区名称</param>
  //    /// <returns>执行状态</returns>
  //    bool GetLogicAreaName(string houseName, CellCoordModel cell, ref string logicArea);

  //    /// <summary>
  //    ///查询货位启用状态
  //    /// </summary>
  //    /// <param name="houseName">库房名称</param>
  //    /// <param name="celCoord">货位位置</param>
  //    /// <param name="gsEnabledStatus">货位启用状态</param>
  //    /// <returns>查询状态</returns>
  //    bool GetCellEnabledStatus(string houseName, CellCoordModel celCoord, ref EnumGSEnabledStatus gsEnabledStatus);
  //    /// <summary>
  //    /// 获取库存料框条码列表
  //    /// </summary>
  //    /// <param name="houseName">库房名称</param>
  //    /// <param name="cellCoord">货位位置</param>
  //    /// <param name="boxCodeList">料框条码列表</param>
  //    /// <returns>查询状态</returns>
  //    bool GetStockDetail(string houseName, CellCoordModel cellCoord, ref List<string> boxCodeList);

  //    /// <summary>
  //    /// 更新货位状态
  //    /// </summary>
  //    /// <param name="houseName">库房名称</param>
  //    /// <param name="cellCoord">货位位置</param>
  //    /// <param name="cellStat">货位状态</param>
  //    /// <param name="taskStatus">货位任务状态</param>
  //    /// <param name="reStr">执行状态描述</param>
  //    /// <returns>执行状态结果</returns>
  //    bool UpdateCellStatus(string houseName, CellCoordModel cellCoord, EnumCellStatus cellStat, EnumGSTaskStatus taskStatus, ref string reStr);
  //    /// <summary>
  //    /// 更新货位状态，货位申请、出库、入库等改变货位状态后需要调用
  //    /// </summary>
  //    /// <param name="houseName">库房名称</param>
  //    /// <param name="cellCoord">货位位置</param>
  //    /// <param name="cellStat">货位状态</param>
  //    /// <param name="reStr">执行状态描述</param>
  //    /// <returns>执行结果</returns>
  //    bool UpdateGsStatus(string houseName, CellCoordModel cellCoord, EnumCellStatus cellStat, ref string reStr);
  //    /// <summary>
  //    /// 更新货位任务状态，货位申请、出库、入库等改变货位状态后需要调用
  //    /// </summary>
  //    /// <param name="houseName">库房名称</param>
  //    /// <param name="cellCoord">货位位置</param>
  //    /// <param name="taskStatus">货位任务状态</param>
  //    /// <param name="reStr">执行状态描述</param>
  //    /// <returns>执行结果</returns>
  //    bool UpdateGsTaskStatus(string houseName, CellCoordModel cellCoord, EnumGSTaskStatus taskStatus, ref string reStr);
  //    /// <summary>
  //    /// 更新货位启用状态
  //    /// </summary>
  //    /// <param name="houseName">库房名称</param>
  //    /// <param name="cellCoord">货位位置</param>
  //    /// <param name="enabledStatus">货位禁用状态</param>
  //    /// <param name="reStr">执行状态描述</param>
  //    /// <returns>执行状态</returns>
  //    bool UpdateGsEnabledStatus(string houseName, CellCoordModel cellCoord, EnumGSEnabledStatus enabledStatus, ref string reStr);
  //    /// <summary>
  //    /// 更新货位操作，任务申请，完成后调用
  //    /// </summary>
  //    /// <param name="houseName">库房名称</param>
  //    /// <param name="cellCoord">库存位置</param>
  //    /// <param name="gsOper">库存操作</param>
  //    /// <param name="reStr">执行状态描述</param>
  //    /// <returns>执行状态结果</returns>
  //    bool UpdateGSOper(string houseName, CellCoordModel cellCoord, EnumGSOperate gsOper, ref string reStr);

  //    /// <summary>
  //    /// 添加货位操作记录，任务完成时调用
  //    /// </summary>
  //    /// <param name="houseName">库房名称</param>
  //    /// <param name="cellCoord">库存位置</param>
  //    /// <param name="gsOperType">货位操作类型</param>
  //    /// <param name="gsOperType">货位操作详细可为空</param>
  //    /// <param name="reStr">执行状态描述</param>
  //    /// <returns>执行状态结果</returns>
  //    bool AddGSOperRecord(string houseName, CellCoordModel cellCoord, EnumGSOperateType gsOperType, string operateDetail, ref string reStr);
  //    /// <summary>
  //    /// 添加库存
  //    /// </summary>
  //    /// <param name="houseName">库房名称</param>
  //    /// <param name="cellCoord">货位位置</param>
  //    /// <param name="goodsInfo">库存信息</param>
  //    /// <param name="reStr">执行状态描述</param>
  //    /// <returns>执行状态结果</returns>
  //    bool AddStack(string houseName, CellCoordModel cellCoord, string proBatch, string[] goodsInfo, ref string reStr);

  //    /// <summary>
  //    /// 移除库存
  //    /// </summary>
  //    /// <param name="houseName">库房信息</param>
  //    /// <param name="cellCoord">货位位置</param>
  //    /// <param name="reStr">执行状态描述</param>
  //    /// <returns>执行状态结果</returns>
  //    bool RemoveStack(string houseName, CellCoordModel cellCoord, ref string reStr);
  //    /// <summary>
  //    /// 添加空料筐库存
  //    /// </summary>
  //    /// <param name="houseName">库房名称</param>
  //    /// <param name="cellCoord">货位位置</param>
  //    /// <param name="reStr">执行状态描述</param>
  //    /// <returns>执行状态结果</returns>
  //    bool AddEmptyMeterialBox(string houseName, CellCoordModel cellCoord, ref string reStr);

  //    /// <summary>
  //    /// 获取所有可以出库的货位，自动出库时调用
  //    /// </summary>
  //    /// <param name="houseName">库房名称</param>
  //    /// <param name="gsList">货位列表</param>
  //    /// <param name="reStr">执行状态描述</param>
  //    /// <returns>执行状态结果</returns>
  //    bool GetAllowLeftHouseGs(string houseName, ref List<CellCoordModel> gsList, ref string reStr);

  //    /// <summary>
  //    /// 查询当前库存的产品批次
  //    /// </summary>
  //    /// <param name="houseName">库房名称</param>
  //    /// <param name="batchList">批次列表</param>
  //    /// <returns>执行状态结果</returns>
  //    bool GetStockProductBatch(string houseName, ref  List<string> batchList);
  //    /// <summary>
  //    /// 删除过时的数据
  //    /// </summary>
  //    /// <param name="days">天</param>
  //    /// <returns>删除状态</returns>
  //    bool DeletePreviousData(int days);


  //    /// <summary>
  //    /// 获取立库单元格数量情况
  //    /// </summary>
  //    /// <param name="houseName">库房名称</param>
  //    /// <param name="row">排 </param>
  //    /// <param name="col">列</param>
  //    /// <param name="layer">层</param>
  //    /// <param name="reStr">若失败，返回错误信息</param>
  //    /// <returns></returns>
  //    bool GetCellCount(string houseName, ref int row, ref int col, ref int layer, ref string reStr);

  //    /// <summary>
  //    ///  获取所有货位信息
  //    /// </summary>
  //    /// <param name="gsTempDic">所有货位信息字典，示例：key为库房名称+":"+货位位置
  //    /// 如：A库房:1-3-13 value：为GSMemTempModel类</param>
  //    /// <param name="reStr"></param>
  //    /// <returns></returns>
  //    bool GetAllGsModel(ref  Dictionary<string, GSMemTempModel> gsTempDic, ref string reStr);

  //    /// <summary>
  //    /// 获取指定库区的出库批次号
  //    /// </summary>
  //    /// <param name="houseName">库房名称</param>
  //    /// <param name="houseAreaName">库区名称</param>
  //    /// <param name="batch">批次</param>
  //    /// <returns>执行状态</returns>
  //    bool GetOutBatch(string houseName, string houseAreaName, ref string batch, ref string reStr);

  //    /// <summary>
  //    /// 产品条码是否在库
  //    /// </summary>
  //    /// <param name="houseName">库房名称</param>
  //    /// <param name="productCode">产品二维码</param>
  //    /// <param name="reStr">执行结果描述</param>
  //    /// <returns>若在库则返回在库货位，否则返回空字符串</returns>
  //    string IsProductCodeInStore(string houseName, string productCode, ref string reStr);
  //    #endregion
  //}
    /// <summary>
    /// 立库管理层提供给控制层的接口
    /// </summary>
  public interface IWMSToWCSSvr : IAsrsManageToCtl
 // public interface IWMSToWCSSvr
  {

      #region 新版wms接口
      /// <summary>
      /// 获取所有待执行任务,wcs分解完一个管理任务后要将此任务状态更新为执行中状态
      /// 
      /// </summary>
      /// <param name="manageTaskList"></param>
      /// <param name="stDevice">起始设备</param>
      /// <returns></returns>
      ResposeData GetWaittingToRunTaskList(TaskDeviceModel stDevice,ref List<ManageTaskModel> manageTaskList);
      /// <summary>
      /// 更新指定管理任务状态
      /// </summary>
      /// <param name="manageTaskID">管理任务ID</param>
      /// <param name="taskStatus">管理任务状态：待执行,执行中,完成</param>
      /// <returns></returns>
      ResposeData UpdateManageTaskStatus(string manageTaskID,string taskStatus);
      /// <summary>
      /// wcs向wms请求任务
      /// </summary>
      /// <param name="applyTask"></param>
      /// <returns></returns>
      ResposeData RequireTask(RequireTaskModel requireTask);

      #endregion

  }
    /// <summary>
    /// 接口返回类
    /// </summary>
    public class ResposeData
    {
        public bool Status { get; set; }
        public string Describe { get; set; }
    }
    /// <summary>
    /// 申请任务模型
    /// </summary>
    public class RequireTaskModel
    {
        /// <summary>
        /// 托盘条码
        /// </summary>
        public string PalletCode { get; set; }
        /// <summary>
        /// 申请类型：空筐入库,空筐出库,产品入库
        /// 1、空筐入库：根据设备编号定位入哪个库房，可配置
        /// 2、空筐出库：由WMS分配从哪个库房出库
        /// 3、产品入库：预留
        /// </summary>
        public string RequireType { get; set; }
        /// <summary>
        /// 请求设备模型,请求的设备类型目前都为工位
        /// </summary>
        public TaskDeviceModel DeviceCode { get; set; }
        /// <summary>
        ///备用参数
        /// </summary>
        public string Remark { get; set; }
        public RequireTaskModel()
        { }
    }
    public class ManageTaskModel
    {
        /// <summary>
        /// 管理任务ID
        /// </summary>
        public string TaskID { get; set; }
        /// <summary>
        /// 管理任务类型:产品入库(需要配盘),空筐入库,产品出库,空筐出库,移库
        /// wcs根据需求转换为内部需要的类型
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// 管理任务状态：待执行,执行中,完成
        /// </summary>
        public string Status { get; set; }
       
        /// <summary>
        /// 托盘条码
        /// </summary>
        public string PalletCode { get; set; }
        /// <summary>
        /// 起点设备
        /// </summary>
        public TaskDeviceModel StartDevice{get;set;}
        /// <summary>
        /// 目标点设备
        /// </summary>
        public TaskDeviceModel TargetDevice{get;set;}

        /// <summary>
        /// 备用参数
        /// </summary>
        public string Remark { get; set; }

        public ManageTaskModel()
        { }
    }
    /// <summary>
    /// 管理任务设备模型
    /// </summary>
    public class TaskDeviceModel
    {
       
        /// <summary>
        /// 设备编码：若设备类型为货位，用库房编码（默认跟堆垛机编号相同),注意：不用名称
        /// 若设备类型为工位：2001表示工位编码；
        /// </summary>
        public string DeviceCode { get; set; }
        /// <summary>
        /// 设备类型：工位、货位
        /// </summary>
        public string DeviceType { get; set; }
        public string ExtParam { get; set; } //仅当设备类型为货位有效，例如"1-2-3"表示为1排2列3排
        public TaskDeviceModel(string devCode,string devType)
        {
            DeviceCode = devCode;
            DeviceType = devType;
        }
        public TaskDeviceModel()
        { }
    }
}
