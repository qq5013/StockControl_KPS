using System;
using System.Collections.Generic;

using System.Text;

namespace KPS.UIModels
{
    /// <summary>
    /// 登录用户信息
    /// </summary>
    public class LoginUserInfo
    {
        /// <summary>
        /// 登录用户信息 构造函数
        /// </summary>
        /// <param name="_loginName">用户登录名</param>
        public LoginUserInfo(string _loginName)
        {
            loginName = _loginName;
            userName = _loginName;
            loginTime = DateTime.Now;
        }
       
        /// <summary>
        /// 登录用户信息 构造函数
        /// </summary>
        /// <param name="_loginName">登录用户名</param>
        /// <param name="_username">用户姓名</param>
        /// <param name="_date">登录时间</param>
        /// <param name="_isAdmin">是否为管理员</param>
        public LoginUserInfo(string _loginName, string _username, DateTime _date, bool _isAdmin)
        {
            loginTime =_date;
            loginName = _loginName;
            userName = _username;
            isAdministrator = _isAdmin;
        }

        private DateTime loginTime;
        /// <summary>
        /// 登录时间
        /// </summary>
        public DateTime LoginTime
        {
            get { return loginTime; }
            set { loginTime = value; }
        }
        private int userID;
        /// <summary>
        /// 用户编号
        /// </summary>
        public int UserID
        {
            get { return userID; }
            set { userID = value; }
        }
        private string loginName;
        /// <summary>
        /// 登录用户名
        /// </summary>
        public string LoginName
        {
            get { return loginName; }
            set { loginName = value; }
        }
        private string userName;
        /// <summary>
        /// 姓名
        /// </summary>
        public string UserName
        {
            get { return userName; }
            set { userName = value; }
        }
        private bool isAdministrator;
        /// <summary>
        /// 是否为管理员
        /// </summary>
        public bool IsAdministrator
        {
            get { return isAdministrator; }
            set { isAdministrator = value; }
        }
    }
}
