using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
namespace LicenceManager
{
    public class LicenseMonitor
    {
        #region 数据
        private int loopInterval = 5000; //循环检查周期，5秒
        private string licenseFilePath = "";
        private LicenceModel licenceModel = null;
        private string encryKey = "zwx";
       // private int threadID = 0;
        private Thread threadHandler = null; //线程句柄
        private bool exitRunning = false; //退出标志
        private bool pauseFlag = false;//暂停标志
        private ILicenseNotify parentNotify = null;
        #endregion
        #region 公共接口
        public LicenseMonitor(ILicenseNotify parentNotify,int loopInterval, string licenseFile, string encryKey)
        {
            this.parentNotify = parentNotify;
            this.loopInterval = loopInterval;
            if(loopInterval<1000)
            {
                loopInterval = 1000;
            }
            if(loopInterval>60000)
            {
                loopInterval = 60000;
            }
            this.licenseFilePath = licenseFile;
            this.encryKey = encryKey;
            this.licenceModel = new LicenceModel(this.encryKey,this.licenseFilePath);

            this.threadHandler = new Thread(new ThreadStart(TaskloopProc));
            this.threadHandler.IsBackground = true;
            this.threadHandler.Name = "";
            this.pauseFlag = false;
            this.exitRunning = false;
        }
         public bool IslicenseValid(ref string reStr)
        {
            if(licenceModel == null)
            {
                reStr = "license文件无效";
                return false;
            }
            if (!licenceModel.IsLicenceValid(ref reStr))
            {
                reStr = "license文件过期";
                return false;
            }
            return true;
        }
        public bool StartMonitor()
        {
            this.pauseFlag = false;
            if (this.threadHandler.ThreadState == (ThreadState.Unstarted | ThreadState.Background))
            {
                this.threadHandler.Start();
            }
            licenceModel = licenceModel.LoadLicence();
            return true;
        }
        #endregion
        #region 内部接口
        private void TaskloopProc()
        {
            while (!exitRunning)
            {
                Thread.Sleep(loopInterval);
                if (pauseFlag)
                {
                    continue;
                }
                string errorStr = "";
                if (licenceModel == null)
                {
                    this.parentNotify.LicenseInvalid("license文件无效！");
                    continue;
                }
                else if(!licenceModel.IsLicenceValid(ref errorStr))
                {
                    this.parentNotify.LicenseInvalid("软件使用期限已到！");
                    Console.WriteLine("软件使用期限已到！");
                    // this.LicenceTime.Enabled = false;
                    this.pauseFlag = true;
                    ActivativeFormView activativeFrom = new ActivativeFormView(this.licenceModel);
                    activativeFrom.ShowDialog();
                    this.pauseFlag = false;
                    if(this.licenceModel.IsLicenceValid(ref errorStr))
                    {
                        parentNotify.LicenseReValid("license 重新激活");
                        Console.WriteLine("license 重新激活");
                    }
                    continue;
                }
                else
                {
                    DateTime deadLine = DateTime.Parse(licenceModel.Decrypt(licenceModel.LicenceEndTime));
                    if (deadLine != null)
                    {
                        TimeSpan leftTime = deadLine - DateTime.Now;
                        if (leftTime.TotalDays < 7.0)
                        {
                            StringBuilder info = new StringBuilder();
                            info.AppendFormat("软件授权即将到期，将截止到{0},请联系厂家，以避免不必要的损失！", deadLine);
                            //parentNotify.ShowWarninfo(info.ToString());
                            Console.WriteLine(info.ToString());
                        }
                    }
                    else
                    {
                        //this.parentNotify.LicenseInvalid("license文件无效！");
                        Console.WriteLine("license文件无效！");
                       
                    }
                }
                
            }
        }
        #endregion
    }
}
