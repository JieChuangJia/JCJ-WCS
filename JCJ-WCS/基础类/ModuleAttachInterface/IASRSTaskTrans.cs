using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PLProcessModel;
namespace ModuleCrossPnP
{
    //堆垛机任务请求，出入库
    public interface IASRSTaskTrans
    {
        /// <summary>
        /// 任务申请，仓储模块收到申请后，根据实际情况决定是否要生成控制任务，分配参数
        /// </summary>
        /// <param name="taskEnum"></param>
        /// <param name="reStr"></param>
        /// <returns></returns>
        bool TaskRequire(EnumASRSTask taskEnum,ref CtlSequenceModel task, ref string reStr);

        /// <summary>
        /// 控制任务完成后提交，仓储管理模块需要更新货位状态
        /// </summary>
        /// <param name="taskID">任务ID</param>
        /// <param name="reStr"></param>
        /// <returns></returns>
        bool TaskCompletedCommit(int taskID, CtlSequenceModel task,ref string reStr);
        
    }
}
