using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Data;
namespace PrcsCtlModelsAoyouCp
{
    /// <summary>
    /// 界面配色
    /// </summary>
    class ViewThemColor
    { 
        public Color FormBkgColor = System.Drawing.SystemColors.Control; //整个窗体背景色
        public Color picSampleColor = System.Drawing.SystemColors.Control; //图例区域背景色
        public Color controlZoneBack = System.Drawing.Color.WhiteSmoke;
        public Color nodeMonitorZoneBack = System.Drawing.SystemColors.GradientInactiveCaption;
 
        public ViewThemColor()
        {

        }
        
    }
}
