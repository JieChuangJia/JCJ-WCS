using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using LogInterface;
namespace FlowCtlBaseModel
{
    public delegate void DelegateThreadRoutine();
    public delegate void DelegateThreadRoutine2(int threadIndex);
    public class ThreadBaseModel
    {
         #region 内部数据
        protected ILogRecorder logRecorder = null;
    //    protected int threadID = 0;
        protected string taskName = "";
        protected Thread threadHandler = null; //线程句柄
        protected bool exitRunning = false; //退出标志
        protected bool pauseFlag = false;//暂停标志
        protected int loopInterval = 100; //任务循环周期
        
        DelegateThreadRoutine threadRoutine = null;
        #endregion
        #region 属性
       // public int ThreadID { get { return threadID; } }
        public int LoopInterval { get { return loopInterval; } set { this.loopInterval = value; } }
        public ILogRecorder LogRecorder { get { return logRecorder; } set { logRecorder = value; } }
        #endregion
        #region 公开接口
        public ThreadBaseModel( string taskName)
        {
           // this.threadID = id;
            this.taskName = taskName;
            //this.nodeList = new List<CtlNodeBaseModel>();
        }
        public void SetThreadRoutine(DelegateThreadRoutine routine)
        {
            this.threadRoutine = routine;
        }
        public bool TaskInit()
        {
            this.threadHandler = new Thread(new ThreadStart(TaskloopProc));
            this.threadHandler.IsBackground = true;
            this.threadHandler.Name = this.taskName;
            this.pauseFlag = false;
            this.exitRunning = false;
            return true;
        }
        public bool TaskExit(ref string reStr)
        {
            this.exitRunning = true;
            try
            {
                if (threadHandler.ThreadState == (ThreadState.Running | ThreadState.Background))
                {
                    if (!threadHandler.Join(500))
                    {
                        threadHandler.Abort();
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                reStr = ex.ToString();
                return false;
            }
            
        }
        public bool TaskStart(ref string reStr)
        {
            try
            {
                this.pauseFlag = false;
                if (this.threadHandler.ThreadState == (ThreadState.Unstarted | ThreadState.Background))
                {
                    //this.threadHandler.Apartment = ApartmentState.STA;
                    //    this.threadHandler.SetApartmentState(ApartmentState.STA); //线程单元模型
                    this.threadHandler.Start();
                }

                return true;
            }
            catch (Exception ex)
            {
                reStr = ex.ToString();
                return false;
            }
           
        }
        public void TaskPause()
        {
            this.pauseFlag = true;
          
        }
        #endregion
        #region 内部接口
        protected  virtual void TaskloopProc()
        {
            while (!exitRunning)
            {
                Thread.Sleep(loopInterval);
                if (pauseFlag)
                {
                    continue;
                }
                if(this.threadRoutine != null)
                {
                    this.threadRoutine();
                }
            }
        }
        #endregion
    }
}
