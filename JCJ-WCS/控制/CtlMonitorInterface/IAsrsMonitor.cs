using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
namespace CtlMonitorInterface
{
    /// <summary>
    /// 立库监控相关接口
    /// </summary>
    [ServiceContract]
    public interface IAsrsMonitor
    {
        [OperationContract]
        string[] GetAllAsrsHousNames();
        [OperationContract]
        IDictionary<string,string> GetAllAsrsPortNames();
        [OperationContract]
        bool GetAsrsStat(string asrsHoseName, ref int errCode, ref string[] status);
        [OperationContract]
        void SetPortBuffer(string portName,string[] barcodes);
        [OperationContract]
        void ClearPortBuffer(string portName);

    }
}
