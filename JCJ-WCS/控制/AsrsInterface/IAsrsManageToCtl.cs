using AsrsModel;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.ServiceModel;
using System.Runtime.Serialization;
namespace AsrsInterface
{

    [ServiceContract]
    public interface IAsrsManageToCtl
    {
        #region 老版本wms接口
        /// <summary>
        /// 注册外部扩展窗体，控制模块注册
        /// </summary>
        /// <param name="storPanelView">货位看板扩展窗体</param>
        /// <param name="sotrListView">库存列表扩展窗体</param>
       void RegistExtViewStorePanel(Form storPanelView,Form sotrListView); 
        /// <summary>
        /// 库存看板单元格点击事件，控制模块注册
        /// </summary>
       event  EventHandler<CellPositionEventArgs> EventCellClicked; 
        /// <summary>
        /// 库存列表详细扩展事件，控制模块注册
        /// </summary>
       event  EventHandler<StockListProEventArgs> EventStorDetail; 
        /// <summary>
        /// 货位申请
        /// </summary>
        /// <param name="houseName">库名称,管理层、控制层约定好即可</param>
        /// <param name="logicAreaName">库房逻辑区域名称</param>
        /// <param name="cellCoord">若申请成功，返回货位坐标</param>
        /// <param name="reStr">若申请失败，返回原因信息</param>
        /// <returns>申请成功返回true，否则返回false</returns>
        [OperationContract]
        bool CellRequire(string houseName, string logicAreaName, ref CellCoordModel cellCoord, ref string reStr);

        /// <summary>
        ///货位申请
        /// </summary>
        /// <param name="houseName"></param>
        /// <param name="logicAreaName"></param>
        /// <param name="cellCoord"></param>
        /// <param name="reStr"></param>
        /// <returns></returns>
        [OperationContract]
        bool CellRequireByRow(string houseName, string logicAreaName, int row, ref CellCoordModel cellCoord, ref string reStr);

        /// <summary>
        /// 查询入库时间
        /// </summary>
        /// <param name="houseName"></param>
        /// <param name="cellCoord"></param>
        /// <param name="inputDT"></param>
        /// <returns>若货位空，返回false</returns>
        [OperationContract]
        bool GetCellInputTime(string houseName, CellCoordModel cellCoord, ref System.DateTime inputDT);

        /// <summary>
        /// 获取库存货位剩余量
        /// </summary>
        /// <param name="houseName">库房名称</param>
        /// <param name="houseAreaName">逻辑库存名称</param>
        /// <param name="gsCount">货位数量</param>
        /// <returns>查询状态</returns>
        [OperationContract]
        bool GetHouseAreaLeftGs(string houseName, string houseAreaName, ref int gsCount, string reStr);

        /// <summary>
        /// 查询货位状态
        /// </summary>
        /// <param name="houseName">库房名称</param>
        /// <param name="cellCoord">货位位置</param>
        /// <param name="cellStatus">货位状态</param>
        /// <param name="taskStatus">货位任务状态</param>
        /// <returns>查询状态</returns>
        [OperationContract]
        bool GetCellStatus(string houseName, CellCoordModel cellCoord, ref EnumCellStatus cellStatus, ref EnumGSTaskStatus taskStatus);

        /// <summary>
        /// 获取逻辑库区名称
        /// </summary>
        /// <param name="houseName">库房名称</param>
        /// <param name="cell">货位位置</param>
        /// <param name="logicArea">库区名称</param>
        /// <returns>执行状态</returns>
        [OperationContract]
        bool GetLogicAreaName(string houseName, CellCoordModel cell, ref string logicArea);

        /// <summary>
        ///查询货位启用状态
        /// </summary>
        /// <param name="houseName">库房名称</param>
        /// <param name="celCoord">货位位置</param>
        /// <param name="gsEnabledStatus">货位启用状态</param>
        /// <returns>查询状态</returns>
        [OperationContract]
        bool GetCellEnabledStatus(string houseName, CellCoordModel celCoord, ref EnumGSEnabledStatus gsEnabledStatus);
        /// <summary>
        /// 获取库存料框条码列表
        /// </summary>
        /// <param name="houseName">库房名称</param>
        /// <param name="cellCoord">货位位置</param>
        /// <param name="boxCodeList">料框条码列表</param>
        /// <returns>查询状态</returns>
        [OperationContract]
        bool GetStockDetail(string houseName, CellCoordModel cellCoord, ref List<string> boxCodeList);

        /// <summary>
        /// 更新货位状态
        /// </summary>
        /// <param name="houseName">库房名称</param>
        /// <param name="cellCoord">货位位置</param>
        /// <param name="cellStat">货位状态</param>
        /// <param name="taskStatus">货位任务状态</param>
        /// <param name="reStr">执行状态描述</param>
        /// <returns>执行状态结果</returns>
        [OperationContract]
        bool UpdateCellStatus(string houseName, CellCoordModel cellCoord, EnumCellStatus cellStat, EnumGSTaskStatus taskStatus, ref string reStr);
        /// <summary>
        /// 更新货位状态，货位申请、出库、入库等改变货位状态后需要调用
        /// </summary>
        /// <param name="houseName">库房名称</param>
        /// <param name="cellCoord">货位位置</param>
        /// <param name="cellStat">货位状态</param>
        /// <param name="reStr">执行状态描述</param>
        /// <returns>执行结果</returns>
        [OperationContract]
        bool UpdateGsStatus(string houseName, CellCoordModel cellCoord, EnumCellStatus cellStat, ref string reStr);
        /// <summary>
        /// 更新货位任务状态，货位申请、出库、入库等改变货位状态后需要调用
        /// </summary>
        /// <param name="houseName">库房名称</param>
        /// <param name="cellCoord">货位位置</param>
        /// <param name="taskStatus">货位任务状态</param>
        /// <param name="reStr">执行状态描述</param>
        /// <returns>执行结果</returns>
        bool UpdateGsTaskStatus(string houseName, CellCoordModel cellCoord, EnumGSTaskStatus taskStatus, ref string reStr);
        /// <summary>
        /// 更新货位启用状态
        /// </summary>
        /// <param name="houseName">库房名称</param>
        /// <param name="cellCoord">货位位置</param>
        /// <param name="enabledStatus">货位禁用状态</param>
        /// <param name="reStr">执行状态描述</param>
        /// <returns>执行状态</returns>
        [OperationContract]
        bool UpdateGsEnabledStatus(string houseName, CellCoordModel cellCoord, EnumGSEnabledStatus enabledStatus, ref string reStr);
        /// <summary>
        /// 更新货位操作，任务申请，完成后调用
        /// </summary>
        /// <param name="houseName">库房名称</param>
        /// <param name="cellCoord">库存位置</param>
        /// <param name="gsOper">库存操作</param>
        /// <param name="reStr">执行状态描述</param>
        /// <returns>执行状态结果</returns>
        [OperationContract]
        bool UpdateGSOper(string houseName, CellCoordModel cellCoord, EnumGSOperate gsOper, ref string reStr);

        /// <summary>
        /// 添加货位操作记录，任务完成时调用
        /// </summary>
        /// <param name="houseName">库房名称</param>
        /// <param name="cellCoord">库存位置</param>
        /// <param name="gsOperType">货位操作类型</param>
        /// <param name="gsOperType">货位操作详细可为空</param>
        /// <param name="reStr">执行状态描述</param>
        /// <returns>执行状态结果</returns>
        [OperationContract]
        bool AddGSOperRecord(string houseName, CellCoordModel cellCoord, EnumGSOperateType gsOperType, string operateDetail, ref string reStr);
        /// <summary>
        /// 添加库存
        /// </summary>
        /// <param name="houseName">库房名称</param>
        /// <param name="cellCoord">货位位置</param>
        /// <param name="goodsInfo">库存信息</param>
        /// <param name="reStr">执行状态描述</param>
        /// <returns>执行状态结果</returns>
        [OperationContract]
        bool AddStack(string houseName, CellCoordModel cellCoord, string proBatch, string[] goodsInfo, ref string reStr);

        /// <summary>
        /// 移除库存
        /// </summary>
        /// <param name="houseName">库房信息</param>
        /// <param name="cellCoord">货位位置</param>
        /// <param name="reStr">执行状态描述</param>
        /// <returns>执行状态结果</returns>
        [OperationContract]
        bool RemoveStack(string houseName, CellCoordModel cellCoord, ref string reStr);
        /// <summary>
        /// 添加空料筐库存
        /// </summary>
        /// <param name="houseName">库房名称</param>
        /// <param name="cellCoord">货位位置</param>
        /// <param name="reStr">执行状态描述</param>
        /// <returns>执行状态结果</returns>
        [OperationContract]
        bool AddEmptyMeterialBox(string houseName, CellCoordModel cellCoord, ref string reStr);

        /// <summary>
        /// 获取所有可以出库的货位，自动出库时调用
        /// </summary>
        /// <param name="houseName">库房名称</param>
        /// <param name="gsList">货位列表</param>
        /// <param name="reStr">执行状态描述</param>
        /// <returns>执行状态结果</returns>
        [OperationContract]
        bool GetAllowLeftHouseGs(string houseName, ref List<CellCoordModel> gsList, ref string reStr);

        /// <summary>
        /// 查询当前库存的产品批次
        /// </summary>
        /// <param name="houseName">库房名称</param>
        /// <param name="batchList">批次列表</param>
        /// <returns>执行状态结果</returns>
        [OperationContract]
        bool GetStockProductBatch(string houseName, ref  List<string> batchList);
        /// <summary>
        /// 删除过时的数据
        /// </summary>
        /// <param name="days">天</param>
        /// <returns>删除状态</returns>
        [OperationContract]
        bool DeletePreviousData(int days);


        /// <summary>
        /// 获取立库单元格数量情况
        /// </summary>
        /// <param name="houseName">库房名称</param>
        /// <param name="row">排 </param>
        /// <param name="col">列</param>
        /// <param name="layer">层</param>
        /// <param name="reStr">若失败，返回错误信息</param>
        /// <returns></returns>
        [OperationContract]
        bool GetCellCount(string houseName, ref int row, ref int col, ref int layer, ref string reStr);

        /// <summary>
        ///  获取所有货位信息
        /// </summary>
        /// <param name="gsTempDic">所有货位信息字典，示例：key为库房名称+":"+货位位置
        /// 如：A库房:1-3-13 value：为GSMemTempModel类</param>
        /// <param name="reStr"></param>
        /// <returns></returns>
        [OperationContract]
        bool GetAllGsModel(ref  Dictionary<string, GSMemTempModel> gsTempDic, ref string reStr);

        /// <summary>
        /// 获取指定库区的出库批次号
        /// </summary>
        /// <param name="houseName">库房名称</param>
        /// <param name="houseAreaName">库区名称</param>
        /// <param name="batch">批次</param>
        /// <returns>执行状态</returns>
        [OperationContract]
        bool GetOutBatch(string houseName, string houseAreaName, ref string batch, ref string reStr);

        /// <summary>
        /// 产品条码是否在库
        /// </summary>
        /// <param name="houseName">库房名称</param>
        /// <param name="productCode">产品二维码</param>
        /// <param name="reStr">执行结果描述</param>
        /// <returns>若在库则返回在库货位，否则返回空字符串</returns>
        [OperationContract]
        string IsProductCodeInStore(string houseName, string productCode, ref string reStr);
        #endregion
    }
}
