using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
namespace CtlMonitorInterface
{
    [ServiceContract]
    public interface ICommDevMonitor
    {
         [OperationContract]
        IDictionary<string, DevConnStat> GetPLCConnStatDic();
    }
}
