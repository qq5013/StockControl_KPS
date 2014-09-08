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
using KPS.BLL;

namespace KPS
{
    /// <summary>
    /// 运输设备管理
    /// </summary>
    public partial class UserInfoMGFrm : SkinForm
    {
        public UserInfoMGFrm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 页面窗体加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TptDeviceMGFrm_Load(object sender, EventArgs e)
        {
            InitFormShow();//初始化UI显示
        }

        /// <summary>
        /// 1.初始化显示
        /// </summary>
        private void InitFormShow()
        {
            InitList();//初始化List显示
            LoadALLList();
        }
 
        #region 2.用户 显示/添加/修改/删除 处理
        private ObjectListView _RecordListView = null;
        private List<KPS.Model.UserInfo> RecordList = null;

        /// <summary>
        /// 2.1 方式添加
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            string strUserName = textBox1.Text.Trim();
            string strPwd = textBox2.Text.Trim();
            if (string.IsNullOrEmpty(strUserName) || string.IsNullOrEmpty(strPwd))
            {
                MessageBox.Show("用户名和密码不可为空！");
                return;
            }

            //1.调用用户的业务逻辑，实现用户信息添加
            UserInfo _user = new UserInfo();
            _user.userName = strUserName;
            _user.userPwd = strPwd;

            UserInfoManager usermanager = new UserInfoManager();
            DataSet _Dt = usermanager.GetList(string.Format("userName='{0}'", strUserName));
            if (_Dt.Tables != null && _Dt.Tables[0].Rows.Count > 0)
            {
                MessageBox.Show("同名称用户已存在，请输入其它用户名！");
                return;
            }
            if (usermanager.Add(_user))
            {
                _user.ID = usermanager.GetMaxId();
            }
            else
            {
                MessageBox.Show("添加失败！");
            }

            //2.添加成功将用户信息(需要获取此)添加到当前_RecordListView和RecordList列表中
            if (RecordList == null)
            {
                RecordList = new List<UserInfo>();
            }
            RecordList.Add(_user);

            _RecordListView.AddObject(_user);//刷新ListView 列表
        }

        /// <summary>
        /// 2.2.加载所有的记录
        /// </summary>
        private void LoadALLList()
        {
            //调用BLL获取所有的用户列表
            UserInfoManager manager = new UserInfoManager();
            RecordList =manager.GetModelLIst("");
 
            ReaLoadSpList();//重新加载列表
        }
 
        
        /// <summary>
        /// 2.4.初始化List显示
        /// </summary>
        private void InitList()
        {
            this._RecordListView = new FastObjectListView();
            this._RecordListView.VirtualMode = true;
            this._RecordListView.Cursor = System.Windows.Forms.Cursors.Default;
            this._RecordListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this._RecordListView.GridLines = true;
            this._RecordListView.FullRowSelect = true;
            this._RecordListView.HeaderUsesThemes = false;
            this._RecordListView.HeaderWordWrap = true;
            this._RecordListView.HideSelection = false;
            this._RecordListView.Location = new System.Drawing.Point(0, 110);
            this._RecordListView.Name = "PInfoListView";
            this._RecordListView.ShowGroups = false;
            this._RecordListView.UseCompatibleStateImageBehavior = false;
            this._RecordListView.UseHotItem = true;
            this._RecordListView.View = System.Windows.Forms.View.Details;
            this._RecordListView.OwnerDraw = true;
            this._RecordListView.MultiSelect = false;

            List<ListColumnInfo> ColumnArray = new List<ListColumnInfo>();
            ColumnArray.Add(new ListColumnInfo("NO", "OrderNumber", 80, HorizontalAlignment.Left, true));
            ColumnArray.Add(new ListColumnInfo("用户名", "userName",214, HorizontalAlignment.Left, true));
            ColumnArray.Add(new ListColumnInfo("密码", "userPwd", 214, HorizontalAlignment.Left, true));

            this.InitializedListColumn(ColumnArray);//初始化栏位信息
            groupBox2.Controls.Add(this._RecordListView);
            this._RecordListView.ContextMenuStrip = this.contextMenuStrip1;
        }

        /// <summary>
        ///  1.3 初始化栏位
        /// </summary>
        /// <param name="ColumnArray"></param>
        private void InitializedListColumn(List<ListColumnInfo> ColumnArray)
        {
            InitListViewColumnManager manager = new InitListViewColumnManager();
            manager.Init(this._RecordListView, ColumnArray, new UserListFormaterManager());
        }
 

        /// <summary>
        /// 2.5.重新加载列表
        /// </summary>
        private void ReaLoadSpList()
        {
            if (RecordList != null && RecordList.Count > 0)
            {
                _RecordListView.AddObjects(RecordList);
            }
            else
            {
                _RecordListView.Items.Clear();
                _RecordListView.ClearObjects();
            }
        }

        /// <summary>
        ///删除用户
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuItemDel_Click(object sender, EventArgs e)
        {
            UserInfo _ItemInfo = null;
            if (this._RecordListView.SelectedObjects != null && this._RecordListView.SelectedObjects.Count > 0)
            {
                _ItemInfo = (UserInfo)this._RecordListView.SelectedObjects[0];
            }
            else
            {
                MessageBox.Show("请选中项后再试！");
            }
            //if (_ItemInfo.userName == "admin")
            //{
            //    MessageBox.Show("管理员不可删除！");
            //    return;
            //}
            ConfirmFrm confirm = new ConfirmFrm("提示", string.Format("您确定需要删除用户 {0}？",_ItemInfo.userName), "确定", "取消", 3);
            if (confirm.ShowDialog() == DialogResult.OK)
            {
                PermissionManager manager = new PermissionManager();
                bool bolsucced = manager.DeleteItemByUserName(_ItemInfo.userName);

                //1.调用bll,从模块对应的权限列表中移除
                UserInfoManager usermanager = new UserInfoManager();
                bolsucced=usermanager.Delete(_ItemInfo.ID);
                if (bolsucced)
                {
                    RecordList.Remove(_ItemInfo);
                    //从用户权限列表中移除

                    //2.从列表中移除
                    this._RecordListView.RemoveObject(_ItemInfo);//将原生从列表中移除
                }
                else
                {
                    MessageBox.Show("操作失败！");
                }

            }
        }
        #endregion

       

    }
}
