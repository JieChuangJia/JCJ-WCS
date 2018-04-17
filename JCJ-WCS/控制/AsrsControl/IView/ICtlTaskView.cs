using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
namespace AsrsControl
{
    public interface ICtlTaskView
    {
        void RefreshTaskDisp(DataTable dt);
    }
}
