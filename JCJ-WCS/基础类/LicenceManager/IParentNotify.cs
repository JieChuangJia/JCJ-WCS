using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LicenceManager
{
    public interface ILicenseNotify
    {
        void ShowWarninfo(string info);
        void LicenseInvalid(string warnInfo);
        void LicenseReValid(string noteInfo);
    }
}
