using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AsrsUtil
{
    public enum EnumAsrsTaskType
    {
        空 = 0,
        产品入库 = 1,
        空筐入库 = 2,
        产品出库 = 3,
        空筐出库 = 4,
        移库 = 5,
        托盘装载 = 6,
        OCV测试分拣 = 7
    }
    public enum EnumTaskStatus
    {
        待执行,
        执行中,
        已完成,
        超时, //任务在规定时间内未完成
        错误, //任务发生错误，不可能再继续执行了，必须人工清理掉
        任务撤销
    }
    public class SysCfg
    {
    }
}
