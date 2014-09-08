using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Text;
using System.Windows.Forms;
using System.Configuration;
using System.IO;
using KPS.DBUtility;

namespace KPS
{
    public partial class LoginFrm:Form
    {
        public LoginFrm()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLogin_Click(object sender, EventArgs e)
        {
            string strDefaultPath = System.IO.Path.Combine(System.Windows.Forms.Application.StartupPath, "DB/KPSDB.accdb");
            FileInfo file = new FileInfo(strDefaultPath);
            if (file.Exists)
            {
                DbFilepath = file.FullName;
                DbHelperOleDb.setDBPath(DbFilepath);
            }
            if (!string.IsNullOrEmpty(DbFilepath) && System.IO.File.Exists(DbFilepath))
            {
                string strUserName = txtuserName.Text.Trim();
                string strPwd = TxtPwd.Text.Trim();
                if (!string.IsNullOrEmpty(strUserName) && !string.IsNullOrEmpty(strPwd))
                {
                    UIModels.LoginStateEnum _state = UIBLL.LoginManager.Instance.Login(strUserName, strPwd);
                    switch (_state)
                    {
                        case UIModels.LoginStateEnum.NoExt:
                            lblTipInfo.Text = "用户名不存在！";
                            this.DialogResult = DialogResult.None;
                            break;
                        case UIModels.LoginStateEnum.Error:
                            lblTipInfo.Text = "用户名或密码错误！";
                            this.DialogResult = DialogResult.None;
                            break;
                        case UIModels.LoginStateEnum.Correct:
                            break;
                        default:
                            lblTipInfo.Text = "用户名或密码错误！";
                            this.DialogResult = DialogResult.None;
                            break;
                    }
                }
                else
                {
                    lblTipInfo.Text = "用户名和密码不可为空！";
                    this.DialogResult = DialogResult.None;
                }
            }
            else
            {
                ConfirmFrm confirm = new ConfirmFrm("提示", "请先点击左下角的【数据库设定】，选择需要连接数据库后再尝试登录，谢谢！", "确定", "取消", 3);
                if (confirm.ShowDialog() == DialogResult.OK)
                {
                    this.DialogResult = DialogResult.None;
                }
                else
                {
                    this.DialogResult = DialogResult.Cancel;
                }
            }
        }

        /// <summary>
        /// 数据存储设定
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LinkDbSetting_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //if (!System.IO.File.Exists(DbFilepath))
            //{
                DBConfigSetting dbsettingfrm = new DBConfigSetting();
                if (dbsettingfrm.ShowDialog() == DialogResult.OK)
                {
                    //DbFilepath = ConfigurationManager.AppSettings["ConnectionString"].ToString();
                    DbFilepath = dbsettingfrm.SavedDbpath;
                }
            //}
        }

        private string DbFilepath = "";
        /// <summary>
        /// 窗体加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LoginFrm_Load(object sender, EventArgs e)
        {
            //1.默认数据存储路径
            DbFilepath = ConfigurationManager.AppSettings["ConnectionString"].ToString();

            UIBLL.LoginRecordsInfo _record = UIBLL.LoginRecordsManager.Instance.GetLastRecord();
            if (_record != null)
            {
                this.txtuserName.Text = _record.UserName;
            }
            else 
            {
                this.txtuserName.Text = "admin";
            }
        }
    }
}
