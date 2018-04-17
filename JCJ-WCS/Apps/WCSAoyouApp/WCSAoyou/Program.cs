using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Diagnostics;
namespace WCSAoyou
{
    static class Program
    {
        /// <summary>
        /// 判断该程序是否已有实例运行
        /// </summary>
        /// <param name="fileName">实例文件名</param>
        /// <returns>是否有运行实例</returns>
        public static bool HasRunningInstance(string fileName)
        {
            Process current = Process.GetCurrentProcess();
            Process[] processes = Process.GetProcessesByName(current.ProcessName);

            foreach (Process process in processes)
            {
                if (process.Id != current.Id)
                {
                    if (fileName == current.MainModule.FileName)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            string appName = Application.ExecutablePath;
            if (HasRunningInstance(appName))
            {
                MessageBox.Show("该软件只允许一个实例运行!");
                return;
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}
