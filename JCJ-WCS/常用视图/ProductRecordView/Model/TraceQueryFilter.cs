using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProductRecordView
{
    /// <summary>
    /// 生产记录查询过滤参数
    /// </summary>
    public class TraceQueryFilter
    {
       public string Cata { get; set; }
        public string BarCode { get; set; }

        public TraceQueryFilter()
        { 
            Cata = "";
        }
    }
}
