using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
namespace ASRSStorManage.Model
{
   public class ExtendFormEventArgs:EventArgs
   {
       public Form StorForm { get; set; }
       public Form StorListForm { get; set; }
   }
}
