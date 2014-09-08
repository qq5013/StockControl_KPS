using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace KPS.UIBLL
{
    /// <summary>
    /// 登录记录管理
    /// </summary>
    public class LoginRecordsManager
    {
        private static LoginRecordsManager manager = new LoginRecordsManager();
        /// <summary>
        /// 登录记录管理 实例 单例
        /// </summary>
        public static LoginRecordsManager Instance
        {
            get
            {
                return manager;
            }
        }

        /// <summary>
        /// 获取最后一次登录记录
        /// </summary>
        /// <returns></returns>
        public LoginRecordsInfo GetLastRecord()
        {
            LoginRecordsInfo _recordinfo = null;
            try
            {
                _recordinfo = new LoginRecordsInfo();
                if (System.IO.File.Exists("LoginInfo.xml"))
                {
                    XmlDocument doc = new XmlDocument();
                    doc.Load("LoginInfo.xml");
                    XmlNodeList retrunDataList = doc.GetElementsByTagName("UserName"); //取得节点名为UserName的XmlNode集合
                    if (retrunDataList != null && retrunDataList.Count > 0)
                    {
                        _recordinfo.UserName = retrunDataList[0].InnerText;
                    }
                    retrunDataList = doc.GetElementsByTagName("LoginTime"); //取得节点名为LoginTime的XmlNode集合
                    if (retrunDataList != null && retrunDataList.Count > 0)
                    {
                        _recordinfo.LoginTime = retrunDataList[0].InnerText;
                    }
                }
                else
                {
                    _recordinfo.UserName = "admin";
                    _recordinfo.LoginTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return _recordinfo;
        }

        /// <summary>
        /// 保存登录记录
        /// </summary>
        /// <param name="_records"></param>
        /// <returns></returns>
        public bool SaveRecord(LoginRecordsInfo _records)
        {
            bool _bolSucced = false;
            try
            {
                XmlDocument doc = new XmlDocument();
                XmlElement Root = doc.CreateElement("LoginInfo");//主内容

                XmlElement UserNameNode = doc.CreateElement("UserName");//用户名
                UserNameNode.InnerText = _records.UserName;
                Root.AppendChild(UserNameNode);

                XmlElement LoginTimeNode = doc.CreateElement("LoginTime");//最后登录时间
                LoginTimeNode.InnerText = _records.LoginTime;
                Root.AppendChild(LoginTimeNode);

                doc.AppendChild(Root);
                doc.Save("LoginInfo.xml");//保存/覆盖配置文件
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return _bolSucced;
        }
    }

    /// <summary>
    /// 登录记录信息
    /// </summary>
    public class LoginRecordsInfo
    {
        public LoginRecordsInfo()
        { 
        }
        
        /// <summary>
        /// 登录信息 构造函数
        /// </summary>
        /// <param name="strusername">用户名</param>
        /// <param name="strloginTime">登录时间</param>
        public LoginRecordsInfo(string strusername, string strloginTime)
        {
            _UserName = strusername;
            _LoginTime = strloginTime;
        }

        private string _UserName;
        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName
        {
            get { return _UserName; }
            set { _UserName = value; }
        }
        private string _LoginTime;
        /// <summary>
        /// 最后登录时间
        /// </summary>
        public string LoginTime
        {
            get { return _LoginTime; }
            set { _LoginTime = value; }
        }
    }
}
