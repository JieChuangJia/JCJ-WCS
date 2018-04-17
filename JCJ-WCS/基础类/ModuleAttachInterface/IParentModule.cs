using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
namespace ModuleCrossPnP
{
    /// <summary>
    /// 父窗体模块接口，供子窗体模块调用
    /// </summary>
    public interface IParentModule
    {
        string CurUsername { get; }
        int RoleID { get; }
        void AttachModuleView(System.Windows.Forms.Form childView);
        void RemoveModuleView(System.Windows.Forms.Form childView);
    }
}
