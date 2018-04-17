using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ModuleCrossPnP
{
    public interface IMessageRoute
    {
        bool SendMessage(int srcModuleID,int dstModuleID,string mesContent);
    }
}
