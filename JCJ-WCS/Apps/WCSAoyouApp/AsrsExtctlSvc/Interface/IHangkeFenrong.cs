using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.ServiceModel;
namespace AsrsExtctlSvc.Interface
{
     [ServiceContract]
    public interface IHangkeFenrong
    {
        /// <summary>
        /// 查询接口库版本号
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        string GetInterfaceVersion();

        /// <summary>
        /// 查询货位是否就绪（可以分容）
        /// </summary>
        /// <param name="row">立库排号（从1开始）</param>
        /// <param name="col">立库列（从1开始）</param>
        /// <param name="layer">立库层（从1开始）</param>
        /// <param name="barCodes">模组条码，每个工装板带两个模组，按照约定摆放顺序</param>
        /// <param name="isReady">（out) 是否就绪</param>
        /// <param name="reStr">(out)若接口调用失败返回失败信息</param>
        /// <returns>true：接口调用成功，false：接口调用失败</returns>
        [OperationContract]
        bool IsAsrsCellReady(int row, int col, int layer, ref string[] barCodes, ref bool isReady, ref string reStr);

        /// <summary>
        /// 通知WCS货位是否可用,比如分容柜有故障要维修，可以再分容系统软件调用此接口禁用对应的货位。待故障解除后，再调用此接口启用该货位。
        /// </summary>
        /// <param name="row">立库排号（从1开始）</param>
        /// <param name="col">立库列（从1开始）</param>
        /// <param name="layer">立库层（从1开始）</param>
        /// <param name="cellValid">货位是否可用</param>
        /// <param name="reason">货位不可用的解释</param>
        /// <param name="reStr">(out)若接口调用失败返回失败信息</param>
        /// <returns>true：接口调用成功，false：接口调用失败</returns>
         [OperationContract]
        bool CellValidStatNotify(int row, int col, int layer, bool cellValid, string reason, ref string reStr);
        
         /// <summary> 
        /// 通知WCS分容完成 
        /// </summary>
        /// <param name="row">立库排号（从1开始）</param>
        /// <param name="col">立库列（从1开始）</param>
        /// <param name="layer">立库层（从1开始）</param>
        /// <param name="reStr">(out)若接口调用失败返回失败信息</param>
        /// <returns>true：接口调用成功，false：接口调用失败</returns>
         [OperationContract]
        bool FenrongOk(int row, int col, int layer, ref string reStr);

         /// <summary>
         /// 通知WCS货位是否有货。
         /// </summary>
         /// <param name="row">立库排号（从1开始）</param>
         /// <param name="col">立库列（从1开始）</param>
         /// <param name="layer">立库层（从1开始）</param>
         /// <param name="stat">货位状态，1：无货，2:有货,</param>
         /// <param name="reStr">(out)若接口调用失败返回失败信息</param>
         /// <returns>true：接口调用成功，false：接口调用失败</returns>
         [OperationContract]
         bool CellStoreStateNotify(int row, int col, int layer, int stat, ref string reStr);

    }
}
