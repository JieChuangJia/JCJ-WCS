using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.ServiceModel;
namespace CtlMonitorInterface
{
    [ServiceContract]
    public interface ICtlnodeMonitor
    {
        [OperationContract]
        List<string> GetMonitorNodeNames();
         [OperationContract]
        bool GetDevRunningInfo(string nodeName, ref DataTable db1Dt, ref DataTable db2Dt, ref string taskDetail);
         [OperationContract]
        bool SimSetDB2(string nodeName, int dbItemID, int val);
         [OperationContract]
        void SimSetRFID(string nodeName, string strUID);
         [OperationContract]
        void SimSetBarcode(string nodeName, string barcode);
    }
}
