using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using AsrsModel;
namespace AsrsInterface
{
    /// <summary>
    /// 控制层提供给管理层的接口
    /// </summary>
    [ServiceContract]
    public interface IAsrsCtlToManage
    {
        /// <summary>
        /// 手动生成出库任务
        /// </summary>
        /// <param name="houseName">库房名称</param>
        /// <param name="cell">货位单元</param>
        /// <param name="reStr">返回信息</param>
        /// <returns>生成成功则返回true，否则返回false</returns>
        [OperationContract]
        bool CreateManualOutputTask(string houseName, CellCoordModel cell, ref string reStr);
        /// <summary>
        /// 手动生成移库任务
        /// </summary>
        /// <param name="startHouseName">开始货位所在库房名称</param>
        /// <param name="startCell">开始货位位置</param>
        /// <param name="endHouseName">结束货位库房名称</param>
        /// <param name="endCell">结束货位位置</param>
        /// <param name="reStr">执行状态描述</param>
        /// <returns>执行结果</returns>
        [OperationContract]
        bool CreateManualMoveGSTask(string startHouseName, CellCoordModel startCell, string endHouseName, CellCoordModel endCell, ref string reStr);
    }
}
