using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Text;
using System.Windows.Forms;
using CSharpWin;
using BrightIdeasSoftware;
using KPS.UIModels;
using KPS.UIBLL;

namespace KPS
{
    /// <summary>
    /// 运输设备管理
    /// </summary>
    public partial class ModuleMGFrm : SkinForm
    {
        public ModuleMGFrm()
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
        #region 列表显示处理
        private ObjectListView _RecordListView = null;
        private List<KPS.Model.UserInfo> RecordList = null;

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
            ColumnArray.Add(new ListColumnInfo("用户名", "userName",365, HorizontalAlignment.Left, true));

            this.InitializedListColumn(ColumnArray);//初始化栏位信息
            groupBox1.Controls.Add(this._RecordListView);

            this._RecordListView.SelectionChanged += new EventHandler(_RecordListView_SelectionChanged);
        }

        private KPS.Model.UserInfo _SelUser = null;
        private List<KPS.Model.PermissionInfo> UserListPerms = null;
        /// <summary>
        /// 选中项发生更改
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void _RecordListView_SelectionChanged(object sender, EventArgs e)
        {
            if (this._RecordListView.SelectedObjects != null && this._RecordListView.SelectedObjects.Count > 0)
            {
                _SelUser = (KPS.Model.UserInfo)this._RecordListView.SelectedObjects[0];

                KPS.BLL.PermissionManager Pmanager = new BLL.PermissionManager();
                UserListPerms = Pmanager.GetModelList(string.Format("userName='{0}'", _SelUser.userName));

                ShowUserAuthMenu(UserListPerms, _SelUser);//显示用户权限菜单
            }
        }


        /// <summary>
        ///  2.4.1. 初始化栏位
        /// </summary>
        /// <param name="ColumnArray"></param>
        private void InitializedListColumn(List<ListColumnInfo> ColumnArray)
        {
            InitListViewColumnManager manager = new InitListViewColumnManager();
            manager.Init(this._RecordListView, ColumnArray, new UserListFormaterManager());
        }


        /// <summary>
        /// 加载列表
        /// </summary>
        private void LoadALLList()
        {
            KPS.BLL.UserInfoManager usermanager = new BLL.UserInfoManager();
            RecordList = usermanager.GetModelLIst("");

            ReaLoadSpList();//List View 显示用户列表
        }


        /// <summary>
        /// 2.5.重新加载列表
        /// </summary>
        private void ReaLoadSpList()
        {
            _RecordListView.Items.Clear();
            _RecordListView.ClearObjects();
            if (RecordList != null && RecordList.Count > 0)
            {
                _RecordListView.AddObjects(RecordList);

                _RecordListView.SelectedObject = RecordList[0];
            }
        }
        #endregion

        #region 权限菜单选中处理
        private void treeView1_AfterCheck(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Nodes != null)
            {
                foreach (TreeNode _node in e.Node.Nodes)
                {
                    _node.Checked = e.Node.Checked;
                }
            }
        }

        /// <summary>
        /// 显示用户权限菜单
        /// </summary>
        /// <param name="ListPerms"></param>
        /// <param name="_seluser"></param>
        private void ShowUserAuthMenu(List<Model.PermissionInfo> ListPerms, Model.UserInfo _seluser)
        {
            //if (_seluser.userName == "admin")
            //{
            //    treeView1.Nodes[0].Checked = true;
            //}
            //else
            //{
                treeView1.Nodes[0].Checked = false;
            //}
            if (ListPerms != null && ListPerms.Count > 0)
            {
                List<int> MIDlist = new List<int>();
                foreach (KPS.Model.PermissionInfo _pers in ListPerms)
                {
                    MIDlist.Add(Convert.ToInt32(_pers.moduleInfoID));
                }

                SelectedNode(treeView1.Nodes[0], MIDlist);//选中节点
            }
        }

        /// <summary>
        /// 选中节点
        /// </summary>
        /// <param name="treeNode"></param>
        /// <param name="MIDlist"></param>
        private void SelectedNode(TreeNode _treeNode, List<int> _MIDlist)
        {
            if (_treeNode.Tag != null && _treeNode.Tag.ToString() != "")
            {
                if (_MIDlist.Contains(Convert.ToInt32(_treeNode.Tag)))
                {
                    _treeNode.Checked = true;
                }
            }
            if (_treeNode.Nodes != null && _treeNode.Nodes.Count > 0)
            {
                foreach (TreeNode _node in _treeNode.Nodes)
                {
                    SelectedNode(_node, _MIDlist);
                }
            }
        }

        /// <summary>
        /// 获得用户设置后的权限列表
        /// </summary>
        /// <returns></returns>
        private List<Model.PermissionInfo> GetSelectNodesAuth()
        {
            List<Model.PermissionInfo> listpers = new List<Model.PermissionInfo>();
            GetSelecttNodeCheckedState(this.treeView1.Nodes[0], listpers);
            return listpers;
        }

        /// <summary>
        /// 获得选中的菜单权限列表
        /// </summary>
        /// <param name="_treenode"></param>
        /// <param name="_pers"></param>
        private void GetSelecttNodeCheckedState(TreeNode _treenode,List<Model.PermissionInfo> _persList)
        {
            if (_treenode.Checked && _treenode.Tag != null)
            { 
                Model.PermissionInfo _pers=new Model.PermissionInfo();
                _pers.moduleInfoID=Convert.ToInt32(_treenode.Tag);
                _pers.userName = _SelUser.userName;
                _persList.Add(_pers);
            }
            if (_treenode.Nodes != null && _treenode.Nodes.Count > 0)
            {
                foreach (TreeNode _node in _treenode.Nodes)
                {
                    GetSelecttNodeCheckedState(_node, _persList);
                }
            }
        }

        /// <summary>
        /// 保存权限
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            if (_SelUser != null)
            {
                //if (_SelUser.userName == "admin")
                //{
                //    MessageBox.Show("管理员权限不可设置！");
                //}
                //else
                //{
                    List<Model.PermissionInfo> list = GetSelectNodesAuth();
                    
                    //1.删除原用户权限
                    string strPIDList="";
                    if(UserListPerms!=null && UserListPerms.Count>0)
                    {
                        foreach(KPS.Model.PermissionInfo _pinfo in UserListPerms)
                        {
                            strPIDList=strPIDList+_pinfo.permissionID+",";
                        }
                        strPIDList=strPIDList.Substring(0,strPIDList.Length-1);
                    }
                    KPS.BLL.PermissionManager pmanager = new BLL.PermissionManager();
                    bool _bolstate = true;
                    try
                    {
                        if (strPIDList != "") 
                        {
                            _bolstate = pmanager.DeleteList(strPIDList);
                        }
 
                        //2.重新添加用户权限
                        if (_bolstate)
                        {
                            foreach (KPS.Model.PermissionInfo _pinfo in list)
                            {
                                if (!pmanager.Add(_pinfo))
                                {
                                    _bolstate = false;
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    { 
                    }
                    if (_bolstate)
                    {
                        MessageBox.Show("保存成功！");
                    }
                    else
                    {
                        MessageBox.Show("保存失败！");
                    }

                //}
            }
            else
            {
                MessageBox.Show("您未选择任何用户！");
            }
        }
        #endregion


    }
}
