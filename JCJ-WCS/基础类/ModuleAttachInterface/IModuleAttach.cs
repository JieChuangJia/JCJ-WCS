using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LogInterface;
namespace ModuleCrossPnP
{
    public interface IModuleAttach
    {
      //  string CaptionText { get; set; }
        /// <summary>
        /// 注册菜单
        /// </summary>
        /// <param name="parentMenu"></param>
        /// <param name="rootMenuText"></param>
        void RegisterMenus(MenuStrip parentMenu,string rootMenuText);

        /// <summary>
        /// 设置父窗体
        /// </summary>
        /// <param name="parentContainer"></param>
        /// <param name="parentForm"></param>
        void SetParent(/*Control parentContainer,Form parentForm,*/IParentModule parentPnP);

        /// <summary>
        /// 给模块分配设置日志接口
        /// </summary>
        /// <param name="logWritter">写日志接口</param>
        /// <param name="logDisp">显示日志接口</param>
        void SetLoginterface(ILogRecorder logWritter);
        //void LoadModuleMainform(Control parentConainer);

        /// <summary>
        /// 得到日志源头列表
        /// </summary>
        /// <returns></returns>
        List<string> GetLogsrcList();

        void ChangeRoleID(int roleID);
    }
}
