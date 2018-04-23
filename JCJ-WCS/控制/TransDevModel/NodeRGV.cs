using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FlowCtlBaseModel;
namespace TransDevModel
{
    public class NodeRGV:CtlNodeBaseModel
    {
        public NodeRGV()
        {
            devCata = "RGV";
        }
        public override bool ExeBusiness(ref string reStr)
        {
            if (!devStatusRestore)
            {
                devStatusRestore = DevStatusRestore();
            }
          //  Console.WriteLine("{0}", nodeName);
            if (!devStatusRestore)
            {
                return false;
            }
            if (this.db2Vals[1] == 1 && this.currentTask == null) //设备空闲
            {
                List<CtlDBAccess.Model.ControlTaskModel> taskList = ctlTaskBll.GetTaskToRunList((int)SysCfg.EnumAsrsTaskType.RGV上下料, SysCfg.EnumTaskStatus.待执行.ToString(), this.NodeID, true);
                if(taskList != null && taskList.Count()>0)
                {
                    this.currentTask = taskList[0];
                    this.currentTaskPhase = 0;
                }
            }
          
            switch(this.currentTaskPhase)
            {
                case 0:
                    {
                        currentTaskDescribe = "等待新的任务";
                        if (currentTask == null)
                        {
                            break;
                        }
                        currentTaskDescribe = "等待设备空闲状态";
                        short stDevID = short.Parse(currentTask.StDevice);
                        short endDevID = short.Parse(currentTask.EndDevice);
                        if (this.db2Vals[1] == 1)
                        {
                            this.db1ValsToSnd[2] = (short)currentTask.TaskType;
                            this.db1ValsToSnd[3] = stDevID;
                            this.db1ValsToSnd[4] = endDevID;
                            this.db1ValsToSnd[5] = (short)currentTask.ControlID;
                        }
                        string logInfo = string.Format("开始执行任务:{0},上料站台：{1}，下料站台:{2}", ((SysCfg.EnumAsrsTaskType)currentTask.TaskType).ToString(),stDevID,endDevID);
                        logRecorder.AddDebugLog(nodeName, logInfo);

                        this.currentTaskPhase++;
                        this.currentTask.TaskPhase = currentTaskPhase;
                        ctlTaskBll.Update(currentTask);
                        break;
                    }
                case 1:
                    {
                        currentTaskDescribe = "开始发送参数";
                        this.db1ValsToSnd[0] = 2;
                        if (!NodeCmdCommit(true, ref reStr))
                        {
                            Console.WriteLine("发送参数失败");
                            break;
                        }
                        logRecorder.AddDebugLog(nodeName, "参数发送完成");
                        this.currentTaskPhase++;
                        this.currentTask.TaskPhase = currentTaskPhase;
                        ctlTaskBll.Update(currentTask);
                        break;
                    }
                case 2:
                    {
                        currentTaskDescribe = "等待设备进入工作状态";
                        if (db2Vals[1] != 2)
                        {
                            //必须进入工作状态
                            break;
                        }
                        db1ValsToSnd[0] = 1;
                        currentTaskDescribe = "等待任务完成";
                        if(this.db2Vals[2] !=2)
                        {
                            break;
                        }
                        if(dlgtCreateNextTask != null)
                        {
                            if(!dlgtCreateNextTask(this,this.currentTask,ref reStr))
                            {
                                break;
                            }
                        }
                        string logInfo = string.Format("任务完成:{0},上料站台：{1}，下料站台:{2}", ((SysCfg.EnumAsrsTaskType)currentTask.TaskType).ToString(),this.currentTask.StDevice,this.currentTask.EndDevice);
                        this.db1ValsToSnd[1] = 2;
                        for (int i = 3; i < db1ValsToSnd.Count(); i++)
                        {
                            db1ValsToSnd[i] = 0;
                        }

                        logRecorder.AddDebugLog(nodeName, logInfo);
                        currentTaskDescribe = "任务完成";
                        this.currentTask.TaskStatus = "已完成";
                        this.currentTaskPhase++;
                        this.currentTask.TaskPhase = currentTaskPhase;
                        ctlTaskBll.Update(currentTask);
                        break;
                    }
                case 3:
                    {
                        currentTaskDescribe = "等待任务完成信号复位";
                        if (db2Vals[2] != 1)
                        {
                            break;
                        }
                        Array.Clear(this.db1ValsToSnd, 0, this.db1ValsToSnd.Count());
                        this.db1ValsToSnd[0] = 1;
                        this.db1ValsToSnd[1] = 1;
                        this.currentTaskPhase++;
                        this.currentTask.TaskPhase = currentTaskPhase;
                        ctlTaskBll.Update(currentTask);

                        currentTask = null;
                        currentTaskPhase = 0;
                        currentTaskDescribe = "等待执行下一个任务";
                        logRecorder.AddDebugLog(nodeName, currentTaskDescribe);
                        break;
                    }
          
                default:
                    break;
            }
            return true;
        }
    }
}
