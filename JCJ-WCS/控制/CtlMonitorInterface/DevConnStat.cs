using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CtlMonitorInterface
{
    public class DevConnStat
    {
        public string devID = "";
        public string devName = "通信设备";
        public int connStat = 1; //1：联通，2：断开
    }
}
