using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AsrsControl
{
    public class TaskQueryFilterModel
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string NodeName { get; set; }
        public string TaskType { get; set; }
        public string TaskStatus { get; set; }
        public bool CellCondition { get; set; }
        public bool LikeQuery { get; set; }
        public string Cell { get; set; }
        public string LikeStr { get; set; }
        public string PrivelegeType { get; set; }
        public TaskQueryFilterModel()
        {
            StartDate = System.DateTime.Now - (new TimeSpan(30, 0, 0, 0));
            EndDate = System.DateTime.Now + new TimeSpan(1, 0, 0, 0);
        }
    }
}
