using System;
namespace CtlDBAccess.Model
{
    /// <summary>
    /// 用户角色表
    /// </summary>
    [Serializable]
    public partial class User_RoleModel
    {
        public User_RoleModel()
        { }
        #region Model
        private int _roleid;
        private string _rolename;
        private string _remarks;
        /// <summary>
        /// 用户角色ID
        /// </summary>
        public int RoleID
        {
            set { _roleid = value; }
            get { return _roleid; }
        }
        /// <summary>
        /// 用户角色名称
        /// </summary>
        public string RoleName
        {
            set { _rolename = value; }
            get { return _rolename; }
        }
        /// <summary>
        /// 备注
        /// </summary>
        public string Remarks
        {
            set { _remarks = value; }
            get { return _remarks; }
        }
        #endregion Model

    }
}

