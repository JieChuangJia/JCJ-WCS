using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace AsrsControl
{
    public interface IGsStatisticsView
    {
        void RefreshGs(DataTable dt);
        void ShowStatistics(string num);
    }
}
