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
using KPS.Model;
using KPS.BLL;

namespace KPS
{
    public partial class DataBackRevFrm:SkinForm
    {
        private bool backRestoreEnd = true;
 
        public DataBackRevFrm(bool IsSel)
        {
            InitializeComponent();
        }
        /// <summary>
        /// 页面加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UnitManagerFrm_Load(object sender, EventArgs e)
        {
            InitList();//初始化List显示
            LoadALLList();
        }

      
 
        private ObjectListView _RecordListView = null;
        private List<UIModels.DataBaseBackInfo> RecordList = null;
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
            ColumnArray.Add(new ListColumnInfo("文件名称", "BackDataFileName",200, HorizontalAlignment.Left, true));
            ColumnArray.Add(new ListColumnInfo("备份时间", "DataBackTime", 120, HorizontalAlignment.Left, true));
 
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
            manager.Init(this._RecordListView, ColumnArray, new BackRecordListFormaterManager());
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
            }
        }

        /// <summary>
        /// 加载所有列表
        /// </summary>
        private void LoadALLList()
        {
            //调用BLL获取所有的用户列表

            RecordList = UIBLL.DataBackManager.Instance.GetDataBackRecords();

            ReaLoadSpList();//重新加载列表
        }

        /// <summary>
        /// 删除项
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ItemDel_Click(object sender, EventArgs e)
        {
            UIModels.DataBaseBackInfo _ItemInfo = null;
            if (this._RecordListView.SelectedObjects != null && this._RecordListView.SelectedObjects.Count > 0)
            {
                _ItemInfo = (DataBaseBackInfo)this._RecordListView.SelectedObjects[0];
            }
            else
            {
                MessageBox.Show("请选中项后再试！");
            }
 
            ConfirmFrm confirm = new ConfirmFrm("提示", "您确定需要删除此选中项？", "确定", "取消", 3);
            if (confirm.ShowDialog() == DialogResult.OK)
            {
                //1.调用bll,从模块对应的权限列表中移除
  
                if (UIBLL.DataBackManager.Instance.DelBackRecord(_ItemInfo))
                {
                    RecordList.Remove(_ItemInfo);
                    //从列表中移除

                    //2.从列表中移除
                    this._RecordListView.RemoveObject(_ItemInfo);//将原生从列表中移除
                }
                else
                {
                    MessageBox.Show("操作失败！");
                }
            }
        }
 
        /// <summary>
        /// 新增备份
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBack_Click(object sender, EventArgs e)
        {
            backRestoreEnd = false;
            btnBack.Enabled = false;
            button3.Enabled = false;
            SortpanalBar.Visible = true;

            UIBLL.DataBaseBackRestoreManager manager = new DataBaseBackRestoreManager();
            manager.BackEndEvent += new DataBaseBackRestoreManager.DelBackRestorStateArg(manager_BackEndEvent);
            manager.CreateLocalBackVesion();
        }

        /// <summary>
        /// 事件处理
        /// </summary>
        /// <param name="_state"></param>
        /// <param name="_MsgInfo"></param>
        void manager_BackEndEvent(bool _state, string _MsgInfo)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new UIBLL.DataBaseBackRestoreManager.DelBackRestorStateArg(ShowManagerState), new object[] { _state, _MsgInfo });
            }
            else
            {
                ShowManagerState(_state, _MsgInfo);
            }
        }

        private void ShowManagerState(bool _state, string _MsgInfo)
        {
            MessageBox.Show(_MsgInfo);
            btnBack.Enabled = true;
            button3.Enabled = true;
            backRestoreEnd = true;
            SortpanalBar.Visible = false;

            LoadALLList();//重新加载列表
        }

        /// <summary>
        /// 还原
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ItemRestore_Click(object sender, EventArgs e)
        {
            UIModels.DataBaseBackInfo _ItemInfo = null;
            if (this._RecordListView.SelectedObjects != null && this._RecordListView.SelectedObjects.Count > 0)
            {
                _ItemInfo = (DataBaseBackInfo)this._RecordListView.SelectedObjects[0];
            }
            else
            {
                MessageBox.Show("请选中项后再试！");
            }

            ConfirmFrm confirm = new ConfirmFrm("提示", "您确定要还原到所选的版本？", "确定", "取消", 3);
            if (confirm.ShowDialog() == DialogResult.OK)
            {
                backRestoreEnd = false;
                btnBack.Enabled = false;
                button3.Enabled = false;
                SortpanalBar.Visible = true;

                UIBLL.DataBaseBackRestoreManager manager = new DataBaseBackRestoreManager();
                manager.RestoreEndEvent += new DataBaseBackRestoreManager.DelBackRestorStateArg(manager_RestoreEndEvent);
                manager.RestoreByLocalVesion(_ItemInfo);
            }
        }

        void manager_RestoreEndEvent(bool _state, string _MsgInfo)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new UIBLL.DataBaseBackRestoreManager.DelBackRestorStateArg(ShowManagerState), new object[] { _state, _MsgInfo });
            }
            else
            {
                ShowManagerState(_state, _MsgInfo);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (!backRestoreEnd) 
            {
                button3.DialogResult = DialogResult.None;
            }
        }

      
    }
}
