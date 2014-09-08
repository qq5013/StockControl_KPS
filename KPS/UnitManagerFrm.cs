﻿using System;
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
    public partial class UnitManagerFrm:SkinForm
    {
        private bool isSelUnit = false;
        private Unit selUnitInfo = null;
        /// <summary>
        /// 选中的单位信息
        /// </summary>
        public Unit SelUnitInfo
        {
            get { return selUnitInfo; }
        }
        public UnitManagerFrm(bool IsSel)
        {
            isSelUnit = IsSel;
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

            if (isSelUnit)
            {
                groupBox1.Text = " 单位筛选 ";
                button1.Text = "筛 选";
            }
            else
            {
                groupBox1.Text = "新增单位";
                button1.Text = "新 增";
            }
        }

      
 
        private ObjectListView _RecordListView = null;
        private List<KPS.Model.Unit> RecordList = null;
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
            ColumnArray.Add(new ListColumnInfo("单位", "unitname", 320, HorizontalAlignment.Left, true));
 
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
            manager.Init(this._RecordListView, ColumnArray, new UnitListFormaterManager());
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
            KPS.BLL.UnitManager manager = new BLL.UnitManager();
            RecordList = manager.GetModelList("");

            ReaLoadSpList();//重新加载列表
        }

        /// <summary>
        /// 删除项
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ItemDel_Click(object sender, EventArgs e)
        {
            Unit _ItemInfo = null;
            if (this._RecordListView.SelectedObjects != null && this._RecordListView.SelectedObjects.Count > 0)
            {
                _ItemInfo = (Unit)this._RecordListView.SelectedObjects[0];
            }
            else
            {
                MessageBox.Show("请选中项后再试！");
            }
 
            ConfirmFrm confirm = new ConfirmFrm("提示", "您确定需要删除此选中项？", "确定", "取消", 3);
            if (confirm.ShowDialog() == DialogResult.OK)
            {
                //1.调用bll,从模块对应的权限列表中移除
                UnitManager manager = new UnitManager();
                if (manager.Delete(_ItemInfo.unitid))
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
        /// 添加
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox1.Text.Trim()))
            {
                KPS.Model.Unit unitinfo=new Model.Unit();
                unitinfo.unitname=textBox1.Text.Trim();
                if (isSelUnit)
                {
                    //调用BLL获取所有的用户列表
                    KPS.BLL.UnitManager manager = new BLL.UnitManager();
                    RecordList = manager.GetModelList(string.Format("unitname  like '%{0}%'", unitinfo.unitname));

                    ReaLoadSpList();//重新加载列表
                }
                else
                {
                    //调用BLL获取所有的用户列表
                    KPS.BLL.UnitManager manager = new BLL.UnitManager();
                    if (manager.Add(unitinfo))
                    {
                        unitinfo.unitid = manager.GetMaxId();
                    }
                    if (unitinfo.unitid != null && unitinfo.unitid != 0)
                    {
                        if (RecordList == null)
                        {
                            RecordList = new List<Model.Unit>();
                        }
                        RecordList.Add(unitinfo);

                        ReaLoadSpList();
                        MessageBox.Show("添加成功!");
                    }
                    else
                    {
                        MessageBox.Show("添加失败!");
                    }
                }
            }
            else
            {
                MessageBox.Show("名称不可为空!");
            }
        }

        /// <summary>
        /// 确定
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            if (!isSelUnit)
            {
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                if (this._RecordListView.SelectedObjects != null && this._RecordListView.SelectedObjects.Count > 0)
                {
                    selUnitInfo = (Unit)this._RecordListView.SelectedObjects[0];
                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    MessageBox.Show("您未选择任何项，请选择对应项后再试！");
                }
            }
        }

      
    }
}