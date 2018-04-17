using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
namespace CtlMonitorInterface
{
    [ServiceContract]
    public interface IWESMonitorSvc:ICommDevMonitor,ICtlnodeMonitor,IAsrsMonitor
    {
         [OperationContract]
        string hello();

        [OperationContract]
        string[] GetLogSrcList();
        
    }
}
