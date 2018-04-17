using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Text;
using AsrsModel;
using AsrsInterface;
using CtlDBAccess.BLL;
using CtlDBAccess.Model;
namespace AsrsControl
{
    public class CtlTaskPresenter
    {
        private IAsrsManageToCtl asrsResourceManage = null; //立库管理层接口对象
        private TaskQueryFilterModel taskFilter = null;
        private ICtlTaskView view = null;
        private ControlTaskBll taskBll = new ControlTaskBll();
        private Dictionary<string, string> nodeNameMapID = new Dictionary<string, string>();
        private Dictionary<string, string> nodeIDMapName = new Dictionary<string, string>();
        public TaskQueryFilterModel TaskFilter { get { return taskFilter; } set { taskFilter = value; } }

        public CtlTaskPresenter(ICtlTaskView view)
        {
            taskFilter = new TaskQueryFilterModel();
            this.view = view;
           
        }
        public void SetTaskNodemap(IDictionary<string,string> nodeMap)
        {
            
            foreach(string nodeID in nodeMap.Keys)
            {
                nodeIDMapName[nodeID] = nodeMap[nodeID];
                nodeNameMapID[nodeMap[nodeID]] = nodeID;
            }
        }
        public void SetAsrsResManage(IAsrsManageToCtl asrsResManage)
        {
            this.asrsResourceManage = asrsResManage;
        }
        public void QueryTask()
        {
            StringBuilder strWhere = new StringBuilder();
            strWhere.AppendFormat("CreateTime >= '{0}' and CreateTime<='{1}' ",
               taskFilter.StartDate.ToString("yyyy-MM-dd HH:mm:ss"),
               taskFilter.EndDate.ToString("yyyy-MM-dd HH:mm:ss"));
            if(taskFilter.NodeName != "所有")
            {
                strWhere.AppendFormat(" and DeviceID='{0}'", nodeNameMapID[taskFilter.NodeName]);
            }
            if(taskFilter.TaskType != "所有")
            {
               
                strWhere.AppendFormat(" and TaskType={0}", (int)(Enum.Parse(typeof(SysCfg.EnumAsrsTaskType),taskFilter.TaskType)));
            }
            if(taskFilter.TaskStatus != "所有")
            {
                strWhere.AppendFormat(" and TaskStatus='{0}'", taskFilter.TaskStatus);
            }
            if(taskFilter.CellCondition)
            {
                strWhere.AppendFormat(" and tag2 Like '%{0}%'", taskFilter.Cell);
            }
            if(taskFilter.LikeQuery)
            {
                strWhere.AppendFormat(" and TaskParam Like '%{0}%' ", taskFilter.LikeStr);
            }
            if(taskFilter.PrivelegeType == "由高到低")
            {
                strWhere.AppendFormat(" order by cast(tag4 as INTEGER) desc,CreateTime asc");
            }
            else if(taskFilter.PrivelegeType == "由低到高")
            {
                strWhere.AppendFormat(" order by cast(tag4 as INTEGER) asc,CreateTime asc");
            }
            else
            {
                strWhere.AppendFormat(" order by CreateTime asc");
            }
            DataSet ds = taskBll.GetList(strWhere.ToString());
            DataTable dt = ds.Tables[0];
            dt.Columns["TaskID"].ColumnName= "任务ID";
            dt.Columns["TaskType"].ColumnName = "任务类型";
            dt.Columns["TaskParam"].ColumnName = "任务参数";
            dt.Columns["TaskStatus"].ColumnName = "任务状态";
            dt.Columns["TaskPhase"].ColumnName = "任务当前步号";
            dt.Columns["CreateTime"].ColumnName = "创建时间";
            dt.Columns["FinishTime"].ColumnName = "完成时间";
            dt.Columns["CreateMode"].ColumnName = "创建模式";
            dt.Columns["DeviceID"].ColumnName = "设备ID";
            dt.Columns["tag1"].ColumnName = "库房";
            dt.Columns["tag2"].ColumnName = "货位";
            dt.Columns["tag4"].ColumnName = "优先级";
            dt.Columns.Remove("tag3");
          
            dt.Columns.Remove("tag5");
            dt.Columns["Remark"].ColumnName = "备注";
            dt.Columns.Add("设备");
            foreach(DataRow dr in dt.Rows)
            {
                dr["设备"] = nodeIDMapName[dr["设备ID"].ToString()];
            }
            view.RefreshTaskDisp(dt);
        }
        public void DelTask(List<string> taskIDs)
        {
            foreach(string taskID in taskIDs)
            {
                CtlDBAccess.Model.ControlTaskModel taskModel = taskBll.GetModel(taskID);
                if(taskModel == null )
                {
                    continue;
                }
                if (taskModel.TaskStatus == SysCfg.EnumTaskStatus.执行中.ToString() || taskModel.TaskStatus == SysCfg.EnumTaskStatus.超时.ToString())
                {
                    continue;
                }
                if(taskModel.TaskType >5)
                {
                    continue;
                }
                AsrsTaskParamModel paramModel = new AsrsTaskParamModel();
                string reStr="";
              //  if (!paramModel.ParseParam((SysCfg.EnumAsrsTaskType)taskModel.TaskType, taskModel.TaskParam, ref reStr))
                if (!paramModel.ParseParam(taskModel, ref reStr))
                {
                    Console.WriteLine(string.Format("任务ID：{0}，参数解析失败，无法删除"), taskModel.TaskID);
                    continue;
                }
                if (taskModel.TaskStatus == SysCfg.EnumTaskStatus.待执行.ToString())
                {
                    if(!asrsResourceManage.UpdateGsTaskStatus(taskModel.tag1, paramModel.CellPos1, EnumGSTaskStatus.完成, ref reStr))
                    {
                        Console.WriteLine(string.Format("任务ID:{0},删除失败，因为更新{1}:{2}-{3}-{4}状态失败", taskModel.TaskID, taskModel.tag1, paramModel.CellPos1.Row, paramModel.CellPos1.Col, paramModel.CellPos1.Layer));
                        continue;
                    }
                    if (taskModel.TaskType == (int)SysCfg.EnumAsrsTaskType.移库)
                    {
                        if(!asrsResourceManage.UpdateGsTaskStatus(taskModel.tag1, paramModel.CellPos2, EnumGSTaskStatus.完成, ref reStr))
                        {
                            Console.WriteLine(string.Format("任务ID:{0},删除失败，因为更新{1}:{2}-{3}-{4}状态失败", taskModel.TaskID, taskModel.tag1, paramModel.CellPos2.Row, paramModel.CellPos2.Col, paramModel.CellPos2.Layer));
                            continue;
                        }
                    }
                }
               
                taskBll.Delete(taskID);
            }
            QueryTask();
        }
        public bool ModifyTaskPri(string taskID,int pri,ref string reStr)
        {
            ControlTaskModel taskM= taskBll.GetModel(taskID);
            if(taskM == null)
            {
                reStr = "不存在的任务ID:"+taskID;
                return false;
            }
            taskM.tag4 = pri.ToString();
            return taskBll.Update(taskM);
        }

    }
}
