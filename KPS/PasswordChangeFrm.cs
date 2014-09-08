using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Text;
using System.Windows.Forms;
using CSharpWin;
using KPS.Model;
using BrightIdeasSoftware;
using KPS.UIModels;
using KPS.UIBLL;
using KPS.DBUtility;
using System.IO;

namespace KPS
{
    /// <summary>
    /// 运输设备管理
    /// </summary>
    public partial class PasswordChangeFrm : SkinForm
    {
        private string ThisDbpath = "";
        public PasswordChangeFrm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 保存修改
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtPwd1.Text.Trim() != "" && txtPwd2.Text.Trim() != "")
            {
                if (txtPwd1.Text.Trim() != txtPwd2.Text.Trim())
                {
                    MessageBox.Show("两次输入的密码不一致！");
                    return;
                }
                UIModels.LoginUserInfo _loginfo=LoginManager.Instance.GetThisUserLoginInfo();

                KPS.Model.UserInfo _user=new UserInfo();
                _user.ID=_loginfo.UserID;
                _user.userName=_loginfo.LoginName;
                _user.userPwd=txtPwd1.Text.Trim();

                KPS.BLL.UserInfoManager manager = new BLL.UserInfoManager();
                if (manager.Update(_user))
                {
                    MessageBox.Show("修改成功！");
                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    MessageBox.Show("修改失败！");
                }
            }
            else
            {
                MessageBox.Show("新密码和确认密码都不可为空！");
            }
        }

    }
}
