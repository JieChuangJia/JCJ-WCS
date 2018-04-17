using System;
namespace CtlDBAccess.Model
{
    /// <summary>
    /// 用户登录信息
    /// </summary>
    [Serializable]
    public partial class User_ListModel
    {
        public User_ListModel()
        { }
        #region Model
        private int _userid;
        private string _username;
        private string _userpassword;
        private int _roleid;
        /// <summary>
        /// 用户ID
        /// </summary>
        public int UserID
        {
            set { _userid = value; }
            get { return _userid; }
        }
        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName
        {
            set { _username = value; }
            get { return _username; }
        }
        /// <summary>
        /// 登录密码
        /// </summary>
        public string UserPassWord
        {
            set { _userpassword = value; }
            get { return _userpassword; }
        }
        /// <summary>
        /// 用户角色ID
        /// </summary>
        public int RoleID
        {
            set { _roleid = value; }
            get { return _roleid; }
        }
        #endregion Model

    }
}

