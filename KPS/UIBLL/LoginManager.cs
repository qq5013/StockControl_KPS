using System;
using System.Collections.Generic;

using System.Text;
using KPS.UIModels;
using KPS.Model;
using System.Data;

namespace KPS.UIBLL
{
    /// <summary>
    /// 用户登录管理
    /// </summary>
    public class LoginManager
    {
        private static LoginManager manager = new LoginManager();
        private LoginUserInfo userinfo = null;

        /// <summary>
        /// 用户登录管理实例，单例
        /// </summary>
        public static LoginManager Instance
        {
            get
            {
                return manager;
            }
        }

        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="_userName"></param>
        /// <param name="_pwd"></param>
        public LoginStateEnum Login(string _userName, string _pwd)
        {
            LoginStateEnum _state = LoginStateEnum.Error;
            //处理内容开始
            KPS.BLL.UserInfoManager manager = new BLL.UserInfoManager();
            DataSet _dt= manager.GetList(string.Format("userName='{0}'",_userName));
            if (_dt != null && _dt.Tables[0].Rows.Count > 0)
            {
                int thisuserID=0;
                foreach (DataRow _row in _dt.Tables[0].Rows)
                {
                    if (_row["userPwd"].ToString() == _pwd)
                    {
                        thisuserID=Convert.ToInt32(_row["ID"]);
                        _state = LoginStateEnum.Correct;
                        break;
                    }
                }
                if (_state == LoginStateEnum.Correct)
                {
                    userinfo = new LoginUserInfo(_userName);
                    userinfo.UserID = thisuserID;
                    if (_userName == "admin")
                    {
                        userinfo.IsAdministrator = false;
                        userinfo.UserName = "admin";
                    }

                    //保存登录记录
                    LoginRecordsManager.Instance.SaveRecord(new LoginRecordsInfo(_userName, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")));
                }
            }
            else
            {
                _state = LoginStateEnum.NoExt;
            }
           
            //处理内容结束
            return _state;
        }

        /// <summary>
        /// 获取当前用户的登录信息
        /// </summary>
        /// <returns></returns>
        public LoginUserInfo GetThisUserLoginInfo()
        {
            return userinfo;
        }
    }
}
