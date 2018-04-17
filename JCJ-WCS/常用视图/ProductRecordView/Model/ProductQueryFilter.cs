using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProductRecordView
{
    public class ProductQueryFilter
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
       // public string Cata { get; set; }
        public string PalletBarCode { get; set; }
        public string BatteryBarCode { get; set; }
        public bool PalletBarcodeCheck { get; set; }
        public bool BatteryBarcodeCheck { get; set; }
        public string BatchName { get; set; }
        public bool BatchCheck { get; set; }
        public ProductQueryFilter()
        {
            StartDate = System.DateTime.Now - (new TimeSpan(30, 0, 0, 0));
            EndDate = System.DateTime.Now + new TimeSpan(1, 0, 0, 0);

          //  Cata = "模组";
        }
    }
}
