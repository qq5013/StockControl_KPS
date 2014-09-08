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
using System.Drawing.Drawing2D;

namespace KPS
{
    public partial class DataQueryFrm:SkinForm
    {
        /// <summary>
        /// 当前表单类型 
        /// </summary>
        private UIModels.EntryType ThisType;
        private System.Collections.ICollection ThisList =null;
        private KPS.Model.DeviceInfo ThisDevice = null;
        private string ModelTypeText = "";

        public DataQueryFrm(UIModels.EntryType _Type,KPS.Model.DeviceInfo _device)
        {
            ThisType = _Type;
            //ThisDevice = _device;
            InitializeComponent();
        }
        /// <summary>
        /// 加载医疗器械类型列表
        /// </summary>
        private void LoadDeviceItems()
        {
            DeviceCacheInstanceManager devicemanager = new DeviceCacheInstanceManager();
            List<KPS.Model.DeviceInfo> listdevicelist = devicemanager.DeviceList;
            CmboxDeviceClass.Items.Clear();
            if (listdevicelist != null && listdevicelist.Count > 0)
            {
                foreach (KPS.Model.DeviceInfo _device in listdevicelist)
                {
                    CmboxDeviceClass.Items.Add(_device.DeviceType);
                }

                CmboxDeviceClass.Tag = listdevicelist;
                CmboxDeviceClass.SelectedIndex = 0;
                ThisDevice = listdevicelist[0];
            }
        }

        /// <summary>
        /// 窗体加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DataQueryFrm_Load(object sender, EventArgs e)
        {
            LoadDeviceItems();//仪器器械类型列表加载

            InitQueryCondition();//初始化查询条件栏位显示

            InitRecordList(ThisType);//初始化列表显示
        }

        EntryModel.QueryConditonControl _conditoncontrol = null;
        private string strThisTitleTxt = "";
        /// <summary>
        /// 查询条件栏位显示
        /// </summary>
        private void InitQueryCondition()
        {
            switch (ThisType)
            { 
                case EntryType.ZDSJGJ:
                    _conditoncontrol = new EntryModel.ZDSJGJQueryControl(ThisDevice);
                    strThisTitleTxt = "购进";
                    TolMenuPrint.Visible = true;
                    break;
                case EntryType.YS:
                    _conditoncontrol = new EntryModel.YSQueryControl(ThisDevice);
                    strThisTitleTxt = "验收";
                    break;
                case EntryType.CC:
                    _conditoncontrol = new EntryModel.CCQueryControl(ThisDevice);
                    strThisTitleTxt = "存储";
                    break;
                case EntryType.XS:
                    _conditoncontrol = new EntryModel.XSQueryControl(ThisDevice);
                    strThisTitleTxt = "销售";
                    TolMenuPrint.Visible = true;
                    break;
                case EntryType.CK:
                    _conditoncontrol = new EntryModel.CKQueryControl(ThisDevice);
                    strThisTitleTxt = "出库";
                    break;
                case EntryType.SH:
                    _conditoncontrol = new EntryModel.SHQueryControl(ThisDevice);
                    strThisTitleTxt = "换货";
                    break;
                case EntryType.BHGPJL:
                    _conditoncontrol = new EntryModel.BHGPQueryControl(ThisDevice);
                    strThisTitleTxt = "不合格品记录";
                    break;
                case EntryType.BLSJ:
                    _conditoncontrol = new EntryModel.BLSJQueryControl(ThisDevice);
                    strThisTitleTxt = "不良事件";
                    break;
                case EntryType.ZLGZ:
                    _conditoncontrol = new EntryModel.ZLGZQueryControl(ThisDevice);
                    strThisTitleTxt = "质量跟踪";
                    break;
                case EntryType.Inventory:
                    _conditoncontrol = new EntryModel.InventoryQueryControl(ThisDevice);
                    strThisTitleTxt = "库存查询";
                    break;
                default:
                    break;
            }
            ModelTypeText = string.Format("{0} {1}", ThisDevice.DeviceType,strThisTitleTxt);

            _conditoncontrol.InitType(ThisType);//初始化类型
            _conditoncontrol.Dock = DockStyle.Fill;
            _conditoncontrol.ListLoadingEvent += new EntryModel.QueryConditonControl.DelListArg(_conditoncontrol_ListLoadingEvent);
            this.groupBox1.Controls.Add(_conditoncontrol);
            this.Text = string.Format("{0} {1}", ThisDevice.DeviceType, strThisTitleTxt);
        }


        /// <summary>
        /// 1.数据查询结果 绑定处理
        /// </summary>
        /// <param name="_list"></param>
        /// <param name="State"></param>
        /// <param name="_msg"></param>
        void _conditoncontrol_ListLoadingEvent(System.Collections.ICollection _list, bool State, string _msg)
        {
         
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new EntryModel.QueryConditonControl.DelListArg(Conditoncontrol_ListLoadingEndManager), new object[] { _list, State, _msg });

            }
            else
            {
                Conditoncontrol_ListLoadingEndManager(_list, State, _msg);
            }
        }

        /// <summary>
        /// 显示处理
        /// </summary>
        /// <param name="_list"></param>
        /// <param name="State"></param>
        /// <param name="_msg"></param>
        private void Conditoncontrol_ListLoadingEndManager(System.Collections.ICollection _list, bool State, string _msg)
        {
            SortpanalBar.Visible = false;//隐藏loading..
            CmboxDeviceClass.Enabled =true;
            ThisList = _list;
            ListViewReloadData(_list);
            ShowRecordListDetail();//显示记录详情

            if (State)
            {
                TolMsgInfo.Text = string.Format("获取列表数据成功，共有 {0} 条符合条件的记录！", _list.Count);
            }
            else
            {
                TolMsgInfo.Text = "加载列表失败，原因：" + _msg;
            }
        }
 

        #region 1.列表显示相关
        /// <summary>
        /// 显示列表
        /// </summary>
        private ObjectListView RecordListView = null;

        /// <summary>
        /// 1.1 初始化列表显示
        /// </summary>
        /// <param name="_Type"></param>
        private void InitRecordList(UIModels.EntryType _Type)
        {
            List<ListColumnInfo> ColumnArray = new List<ListColumnInfo>();
            //右键菜单是否可用
            bool ContextMenuStripState = true;
            switch (_Type)
            {
                case UIModels.EntryType.ZDSJGJ://1诊断试剂购进
                    ColumnArray = GetZDSJGJColumns();
                    ContextMenuStripState = false;
                    break;
                case UIModels.EntryType.YS://2验收
                    ColumnArray = GetYSColumns();
                    break;
                case UIModels.EntryType.CC://3存储,仓库
                    ColumnArray = GetCCColumns();
                    break;
                case UIModels.EntryType.XS://4.销售
                    ColumnArray = GetXSColumns();
                    ContextMenuStripState = false;
                    break;
                case EntryType.CK://5.出库
                    ColumnArray = GetCKColumns();
                    break;
                case EntryType.SH://6.售后
                    ColumnArray = GetSHColumns();
                    break;
                case EntryType.BHGPJL://7.不合格品记录
                    ColumnArray = GetBHGPJLColumns();
                    break;
                case EntryType.BLSJ://8.不合格品记录
                    ColumnArray = GetBLSJColumns();
                    break;
                case EntryType.ZLGZ://9.质量跟踪
                    ColumnArray = GetZLGZColumns();
                    break;
                case EntryType.Inventory://库存查询
                    ColumnArray = GetInventoryColumns();
                    ContextMenuStripState = false;
                    break;
                default:
                    ColumnArray = GetZDSJGJColumns();
                    break;
            }
            if (this.RecordListView != null)
            {
                panel2.Controls.Remove(this.RecordListView);
            }
            this.RecordListView = null;
            this.RecordListView = new FastObjectListView();
            this.RecordListView.VirtualMode = true;
            this.RecordListView.Cursor = System.Windows.Forms.Cursors.Default;
            this.RecordListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RecordListView.GridLines = true;
            this.RecordListView.FullRowSelect = true;
            this.RecordListView.HeaderUsesThemes = false;
            this.RecordListView.HeaderWordWrap = true;
            this.RecordListView.HideSelection = false;
            this.RecordListView.Location = new System.Drawing.Point(0, 110);
            this.RecordListView.Name = "PInfoListView";
            this.RecordListView.ShowGroups = false;
            this.RecordListView.UseCompatibleStateImageBehavior = false;
            this.RecordListView.UseHotItem = true;
            this.RecordListView.View = System.Windows.Forms.View.Details;
            this.RecordListView.OwnerDraw = true;
            //this.RecordListView.ShowGroups =true;

            this.InitializedListColumn(ColumnArray, _Type);//初始化栏位信息
            panel2.Controls.Add(this.RecordListView);
            this.RecordListView.SelectionChanged += new EventHandler(RecordListView_SelectionChanged);

            if (!ContextMenuStripState)
            {
                this.RecordListView.ContextMenuStrip = null;
            }
            else
            {
                this.RecordListView.ContextMenuStrip = this.contextMenuStrip1;
            }

            //列表打印初始化
            listViewPrinter1.ListView = this.RecordListView;

        }

        /// <summary>
        ///  选中项发生更改
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void RecordListView_SelectionChanged(object sender, EventArgs e)
        {
            int count = 0;
            if (this.RecordListView.SelectedObjects != null && this.RecordListView.SelectedObjects.Count > 0)
            {
                count = this.RecordListView.SelectedObjects.Count;
            }
            this.TolMsgInfo.Text = string.Format("当前选中 {0} 条记录！",count);
        }

        private void ShowRecordListDetail()
        {
            int RecordCount = 0;
            if (ThisList != null && ThisList.Count > 0)
            {
                RecordCount = ThisList.Count;
            }
            tolModelInfo.Text = string.Format("报表类型： {0}  符合条件记录数{1} ", ModelTypeText, RecordCount);
        }

        #region 字段栏位初始化
        /// <summary>
        /// 1.1.诊断试剂购进 字段列表
        /// </summary>
        /// <returns></returns>
        private List<ListColumnInfo> GetZDSJGJColumns()
        {
            List<ListColumnInfo> ColumnArray = new List<ListColumnInfo>();
            ColumnArray.Add(new ListColumnInfo("NO", "OrderNumber", 40, HorizontalAlignment.Left, true));
            ColumnArray.Add(new ListColumnInfo("材料名称", "p_clmc", 120, HorizontalAlignment.Left, true));
            ColumnArray.Add(new ListColumnInfo("产品名称", "p_cpmc", 120, HorizontalAlignment.Left, true));
            ColumnArray.Add(new ListColumnInfo("购进时间", "p_date", 120, HorizontalAlignment.Left, true));
            ColumnArray.Add(new ListColumnInfo("单位", "p_dw", 60, HorizontalAlignment.Left, true));
            ColumnArray.Add(new ListColumnInfo("规格型号", "p_ggxh", 80, HorizontalAlignment.Left, true));
            ColumnArray.Add(new ListColumnInfo("供应商", "p_gys", 120, HorizontalAlignment.Left, true));
            ColumnArray.Add(new ListColumnInfo("灭菌批号", "p_mjph", 100, HorizontalAlignment.Left, true));
            ColumnArray.Add(new ListColumnInfo("批号(系列号)", "p_ph", 100, HorizontalAlignment.Left, true));
            ColumnArray.Add(new ListColumnInfo("数量", "p_sl1", 60, HorizontalAlignment.Left, true));

            ColumnArray.Add(new ListColumnInfo("进价", "p_sl2", 60, HorizontalAlignment.Left, true));
            ColumnArray.Add(new ListColumnInfo("总金额", "ToltalMoney", 80, HorizontalAlignment.Left, true));
            ColumnArray.Add(new ListColumnInfo("备注", "RemarkInfo", 120, HorizontalAlignment.Left, true));
            
            ColumnArray.Add(new ListColumnInfo("注册证号", "p_zczh", 120, HorizontalAlignment.Left, true));
            ColumnArray.Add(new ListColumnInfo("生产商", "p_zzs", 120, HorizontalAlignment.Left, true));
            ColumnArray.Add(new ListColumnInfo("经手人", "p_jsr", 100, HorizontalAlignment.Left, true));
            return ColumnArray;

        }
       
        /// <summary>
        /// 1.2.验收
        /// </summary>
        /// <returns></returns>
        private List<ListColumnInfo> GetYSColumns()
        {
            KPS.Model.YanShouInfo yanshou = new Model.YanShouInfo();
            List<ListColumnInfo> ColumnArray = new List<ListColumnInfo>();
            ColumnArray.Add(new ListColumnInfo("NO", "OrderNumber", 40, HorizontalAlignment.Left, true));
            ColumnArray.Add(new ListColumnInfo("品名", "y_pm", 120, HorizontalAlignment.Left, true));
            ColumnArray.Add(new ListColumnInfo("产品代码", "y_cpdm", 80, HorizontalAlignment.Left, true));
            ColumnArray.Add(new ListColumnInfo("产品注册号", "y_cpzczh", 120, HorizontalAlignment.Left, true));
            ColumnArray.Add(new ListColumnInfo("日期", "y_date", 120, HorizontalAlignment.Left, true));
            ColumnArray.Add(new ListColumnInfo("单位", "y_dw", 40, HorizontalAlignment.Left, true));
            ColumnArray.Add(new ListColumnInfo("复核人", "y_fhrqz", 80, HorizontalAlignment.Left, true));
            ColumnArray.Add(new ListColumnInfo("规格型号", "y_ggxh", 80, HorizontalAlignment.Left, true));
            ColumnArray.Add(new ListColumnInfo("供应商", "y_ghdw", 80, HorizontalAlignment.Left, true));
            ColumnArray.Add(new ListColumnInfo("合格证", "y_isHGZ", 80, HorizontalAlignment.Left, true));
            ColumnArray.Add(new ListColumnInfo("灭菌批号", "y_mjph", 80, HorizontalAlignment.Left, true));
            ColumnArray.Add(new ListColumnInfo("生产商", "y_sccj", 80, HorizontalAlignment.Left, true));
            ColumnArray.Add(new ListColumnInfo("生产批号", "y_scph", 80, HorizontalAlignment.Left, true));
            ColumnArray.Add(new ListColumnInfo("数量", "y_sl", 40, HorizontalAlignment.Left, true));
            ColumnArray.Add(new ListColumnInfo("有效期", "y_yxq", 60, HorizontalAlignment.Left, true));
            ColumnArray.Add(new ListColumnInfo("质量管理员", "y_zgy", 80, HorizontalAlignment.Left, true));
            ColumnArray.Add(new ListColumnInfo("质量情况", "y_zlqk", 100, HorizontalAlignment.Left, true));
            return ColumnArray;
        }

        /// <summary>
        /// 1.3.存储
        /// </summary>
        /// <returns></returns>
        private List<ListColumnInfo> GetCCColumns()
        {
            List<ListColumnInfo> ColumnArray = new List<ListColumnInfo>();
            ColumnArray.Add(new ListColumnInfo("NO", "OrderNumber", 40, HorizontalAlignment.Left, true));
            ColumnArray.Add(new ListColumnInfo("场所名称", "s_csmc", 80, HorizontalAlignment.Left, true));
            ColumnArray.Add(new ListColumnInfo("时间", "s_sworxw", 100, HorizontalAlignment.Left, true));
            ColumnArray.Add(new ListColumnInfo("日期", "s_date", 100, HorizontalAlignment.Left, true));
            ColumnArray.Add(new ListColumnInfo("温度", "s_wd", 60, HorizontalAlignment.Left, true));
            ColumnArray.Add(new ListColumnInfo("湿度", "s_sd", 60, HorizontalAlignment.Left, true));
            ColumnArray.Add(new ListColumnInfo("适宜温度范围", "s_sywdfw", 120, HorizontalAlignment.Left, true));
            ColumnArray.Add(new ListColumnInfo("适宜相对湿度范围", "s_syxdsdfw", 140, HorizontalAlignment.Left, true));
            ColumnArray.Add(new ListColumnInfo("采取措施", "s_cqcs", 100, HorizontalAlignment.Left, true));
            ColumnArray.Add(new ListColumnInfo("采取措施后温度", "s_wded", 140, HorizontalAlignment.Left, true));
            ColumnArray.Add(new ListColumnInfo("采取措施后湿度", "s_sded", 140, HorizontalAlignment.Left, true));
            ColumnArray.Add(new ListColumnInfo("记录人", "s_jlr", 80, HorizontalAlignment.Left, true));
            return ColumnArray;
        }

        /// <summary>
        /// 1.4.销售
        /// </summary>
        /// <returns></returns>
        private List<ListColumnInfo> GetXSColumns()
        {
            List<ListColumnInfo> ColumnArray = new List<ListColumnInfo>();
            ColumnArray.Add(new ListColumnInfo("NO", "OrderNumber", 40, HorizontalAlignment.Left, true));
            ColumnArray.Add(new ListColumnInfo("产品名称", "p_cpmc", 100, HorizontalAlignment.Left, true));
            ColumnArray.Add(new ListColumnInfo("时间", "p_date", 100, HorizontalAlignment.Left, true));
            ColumnArray.Add(new ListColumnInfo("单位", "p_dw", 60, HorizontalAlignment.Left, true));
            ColumnArray.Add(new ListColumnInfo("材料名称", "p_clmc", 100, HorizontalAlignment.Left, true));
            ColumnArray.Add(new ListColumnInfo("规格型号", "p_ggxh", 80, HorizontalAlignment.Left, true));
            ColumnArray.Add(new ListColumnInfo("采购单位", "p_gys", 80, HorizontalAlignment.Left, true));
            ColumnArray.Add(new ListColumnInfo("经手人", "p_jsr", 80, HorizontalAlignment.Left, true));
            ColumnArray.Add(new ListColumnInfo("灭菌批号", "p_mjph", 80, HorizontalAlignment.Left, true));
            ColumnArray.Add(new ListColumnInfo("批号", "p_ph", 80, HorizontalAlignment.Left, true));
            ColumnArray.Add(new ListColumnInfo("数量", "p_sl1", 40, HorizontalAlignment.Left, true));

            ColumnArray.Add(new ListColumnInfo("单价", "p_sl2", 60, HorizontalAlignment.Left, true));
            ColumnArray.Add(new ListColumnInfo("总金额", "ToltalMoney", 80, HorizontalAlignment.Left, true));
            ColumnArray.Add(new ListColumnInfo("备注", "RemarkInfo", 120, HorizontalAlignment.Left, true));

            ColumnArray.Add(new ListColumnInfo("注册证号", "p_zczh", 100, HorizontalAlignment.Left, true));
            ColumnArray.Add(new ListColumnInfo("生产商", "p_zzs", 80, HorizontalAlignment.Left, true));
            return ColumnArray;
        }

        /// <summary>
        /// 1.5.出库
        /// </summary>
        /// <returns></returns>
        private List<ListColumnInfo> GetCKColumns()
        {
            List<ListColumnInfo> ColumnArray = new List<ListColumnInfo>();
            ColumnArray.Add(new ListColumnInfo("NO", "OrderNumber", 40, HorizontalAlignment.Left, true));
            ColumnArray.Add(new ListColumnInfo("品名", "y_pm", 100, HorizontalAlignment.Left, true));
            ColumnArray.Add(new ListColumnInfo("产品代码", "y_cpdm", 80, HorizontalAlignment.Left, true));
            ColumnArray.Add(new ListColumnInfo("产品注册证号", "y_cpzczh", 100, HorizontalAlignment.Left, true));
            ColumnArray.Add(new ListColumnInfo("日期", "y_date", 100, HorizontalAlignment.Left, true));
            ColumnArray.Add(new ListColumnInfo("单位", "y_dw", 40, HorizontalAlignment.Left, true));
            ColumnArray.Add(new ListColumnInfo("复核人", "y_fhrqz", 80, HorizontalAlignment.Left, true));
            ColumnArray.Add(new ListColumnInfo("规格型号", "y_ggxh", 80, HorizontalAlignment.Left, true));
            ColumnArray.Add(new ListColumnInfo("供应商", "y_ghdw", 80, HorizontalAlignment.Left, true));
            ColumnArray.Add(new ListColumnInfo("合格证", "y_isHGZ", 80, HorizontalAlignment.Left, true));
            ColumnArray.Add(new ListColumnInfo("灭菌批号", "y_mjph", 80, HorizontalAlignment.Left, true));
            ColumnArray.Add(new ListColumnInfo("生产商", "y_sccj", 80, HorizontalAlignment.Left, true));
            ColumnArray.Add(new ListColumnInfo("生产批号", "y_scph", 80, HorizontalAlignment.Left, true));
            ColumnArray.Add(new ListColumnInfo("数量", "y_sl", 40, HorizontalAlignment.Left, true));
            ColumnArray.Add(new ListColumnInfo("有效期", "y_yxq", 80, HorizontalAlignment.Left, true));
            ColumnArray.Add(new ListColumnInfo("质管员", "y_zgy", 80, HorizontalAlignment.Left, true));
            ColumnArray.Add(new ListColumnInfo("质量情况", "y_zlqk", 100, HorizontalAlignment.Left, true));
            return ColumnArray;
        }

        /// <summary>
        /// 1.6.售后
        /// </summary>
        /// <returns></returns>
        private List<ListColumnInfo> GetSHColumns()
        {
            List<ListColumnInfo> ColumnArray = new List<ListColumnInfo>();
            ColumnArray.Add(new ListColumnInfo("NO", "OrderNumber", 40, HorizontalAlignment.Left, true));
            ColumnArray.Add(new ListColumnInfo("品名", "y_pm", 100, HorizontalAlignment.Left, true));
            ColumnArray.Add(new ListColumnInfo("类型", "y_managertype", 60, HorizontalAlignment.Left, true));
            ColumnArray.Add(new ListColumnInfo("日期", "y_date", 80, HorizontalAlignment.Left, true));
            ColumnArray.Add(new ListColumnInfo("产品代码", "y_cpdm", 80, HorizontalAlignment.Left, true));
            ColumnArray.Add(new ListColumnInfo("产品注册证号", "y_cpzczh", 100, HorizontalAlignment.Left, true));
            ColumnArray.Add(new ListColumnInfo("单位", "y_dw", 60, HorizontalAlignment.Left, true));
            ColumnArray.Add(new ListColumnInfo("复核人", "y_fhrqz", 80, HorizontalAlignment.Left, true));
            ColumnArray.Add(new ListColumnInfo("规格型号", "y_ggxh", 80, HorizontalAlignment.Left, true));
            ColumnArray.Add(new ListColumnInfo("供应商", "y_ghdw", 80, HorizontalAlignment.Left, true));
            ColumnArray.Add(new ListColumnInfo("合格证", "y_isHGZ", 60, HorizontalAlignment.Left, true));
            ColumnArray.Add(new ListColumnInfo("灭菌批号", "y_mjph", 80, HorizontalAlignment.Left, true));
            ColumnArray.Add(new ListColumnInfo("生产商", "y_sccj", 80, HorizontalAlignment.Left, true));
            ColumnArray.Add(new ListColumnInfo("生产批号", "y_scph", 80, HorizontalAlignment.Left, true));
            ColumnArray.Add(new ListColumnInfo("数量", "y_sl", 40, HorizontalAlignment.Left, true));
            ColumnArray.Add(new ListColumnInfo("有效期", "y_yxq", 80, HorizontalAlignment.Left, true));
            ColumnArray.Add(new ListColumnInfo("质管员", "y_zgy", 80, HorizontalAlignment.Left, true));
            ColumnArray.Add(new ListColumnInfo("质量情况", "y_zlqk", 100, HorizontalAlignment.Left, true));
            return ColumnArray;
        }

        /// <summary>
        /// 1.7.不合格品记录
        /// </summary>
        /// <returns></returns>
        private List<ListColumnInfo> GetBHGPJLColumns()
        {
            List<ListColumnInfo> ColumnArray = new List<ListColumnInfo>();
            ColumnArray.Add(new ListColumnInfo("NO", "OrderNumber", 40, HorizontalAlignment.Left, true));
            ColumnArray.Add(new ListColumnInfo("品名", "y_pm", 100, HorizontalAlignment.Left, true));
            ColumnArray.Add(new ListColumnInfo("日期", "y_date", 100, HorizontalAlignment.Left, true));
            ColumnArray.Add(new ListColumnInfo("许可证", "y_cpdm", 80, HorizontalAlignment.Left, true));
            ColumnArray.Add(new ListColumnInfo("产品注册证号", "y_cpzczh", 100, HorizontalAlignment.Left, true));
            ColumnArray.Add(new ListColumnInfo("单位", "y_dw", 60, HorizontalAlignment.Left, true));
            ColumnArray.Add(new ListColumnInfo("复核人", "y_fhrqz", 80, HorizontalAlignment.Left, true));
            ColumnArray.Add(new ListColumnInfo("规格型号", "y_ggxh", 80, HorizontalAlignment.Left, true));
            ColumnArray.Add(new ListColumnInfo("供应商", "y_ghdw", 80, HorizontalAlignment.Left, true));
            ColumnArray.Add(new ListColumnInfo("合格证", "y_isHGZ", 80, HorizontalAlignment.Left, true));
            ColumnArray.Add(new ListColumnInfo("灭菌批号", "y_mjph", 80, HorizontalAlignment.Left, true));
            ColumnArray.Add(new ListColumnInfo("生产商", "y_sccj", 80, HorizontalAlignment.Left, true));
            ColumnArray.Add(new ListColumnInfo("生产批号", "y_scph", 80, HorizontalAlignment.Left, true));
            ColumnArray.Add(new ListColumnInfo("数量", "y_sl", 40, HorizontalAlignment.Left, true));
            ColumnArray.Add(new ListColumnInfo("有效期", "y_yxq", 80, HorizontalAlignment.Left, true));
            ColumnArray.Add(new ListColumnInfo("质管员", "y_zgy", 80, HorizontalAlignment.Left, true));
            ColumnArray.Add(new ListColumnInfo("质量情况", "y_zlqk", 80, HorizontalAlignment.Left, true));
            return ColumnArray;
        }

        /// <summary>
        /// 1.8.不良事件
        /// </summary>
        /// <returns></returns>
        private List<ListColumnInfo> GetBLSJColumns()
        {
            List<ListColumnInfo> ColumnArray = new List<ListColumnInfo>();
            ColumnArray.Add(new ListColumnInfo("NO", "OrderNumber", 40, HorizontalAlignment.Left, true));


            ColumnArray.Add(new ListColumnInfo("医疗器械名称", "b_ylqxmc", 100, HorizontalAlignment.Left, true));
            ColumnArray.Add(new ListColumnInfo("产品代码", "b_cpdm", 80, HorizontalAlignment.Left, true));
            ColumnArray.Add(new ListColumnInfo("规格型号", "b_ggxh", 80, HorizontalAlignment.Left, true));

            ColumnArray.Add(new ListColumnInfo("生产商", "b_sccj", 80, HorizontalAlignment.Left, true));
            ColumnArray.Add(new ListColumnInfo("使用单位", "b_sydw", 80, HorizontalAlignment.Left, true));
            ColumnArray.Add(new ListColumnInfo("生产日期", "b_scrq", 80, HorizontalAlignment.Left, true));
            ColumnArray.Add(new ListColumnInfo("数量", "b_sl", 40, HorizontalAlignment.Left, true));

            ColumnArray.Add(new ListColumnInfo("质量事故情况说明", "b_zlsgqk", 120, HorizontalAlignment.Left, true));
            ColumnArray.Add(new ListColumnInfo("报告人", "b_bgr", 80, HorizontalAlignment.Left, true));
            ColumnArray.Add(new ListColumnInfo("报告时间", "b_bgsj", 80, HorizontalAlignment.Left, true));

            ColumnArray.Add(new ListColumnInfo("使用单位负责人", "b_fzr", 100, HorizontalAlignment.Left, true));
            ColumnArray.Add(new ListColumnInfo("使用单位意见", "b_sydwyj", 100, HorizontalAlignment.Left, true));
            ColumnArray.Add(new ListColumnInfo("使用单位意见反馈时间", "b_resj", 150, HorizontalAlignment.Left, true));

            ColumnArray.Add(new ListColumnInfo("企业质量负责人", "b_fzrqz", 120, HorizontalAlignment.Left, true));
            ColumnArray.Add(new ListColumnInfo("企业质量负责人意见", "b_qyzgfzryj", 150, HorizontalAlignment.Left, true));
            ColumnArray.Add(new ListColumnInfo("企业质量负责人签字时间", "b_fzrqzsj", 150, HorizontalAlignment.Left, true));

            ColumnArray.Add(new ListColumnInfo("处理情况", "b_zgclqk", 80, HorizontalAlignment.Left, true));
            ColumnArray.Add(new ListColumnInfo("经办人", "b_zgjbr", 80, HorizontalAlignment.Left, true));
            ColumnArray.Add(new ListColumnInfo("最终处理时间", "b_zgjbsj", 100, HorizontalAlignment.Left, true));


            return ColumnArray;
        }

        /// <summary>
        /// 1.9.质量跟踪
        /// </summary>
        /// <returns></returns>
        private List<ListColumnInfo> GetZLGZColumns()
        {

            List<ListColumnInfo> ColumnArray = new List<ListColumnInfo>();
            ColumnArray.Add(new ListColumnInfo("NO", "OrderNumber", 40, HorizontalAlignment.Left, true));
            ColumnArray.Add(new ListColumnInfo("产品名称", "ProcessProductName", 80, HorizontalAlignment.Left, true));
            ColumnArray.Add(new ListColumnInfo("时间", "ProcessDate", 80, HorizontalAlignment.Left, true));
            ColumnArray.Add(new ListColumnInfo("客户单位", "ProcessCustomerUnit", 80, HorizontalAlignment.Left, true));
            ColumnArray.Add(new ListColumnInfo("查询内容", "ProcessContentInquired", 150, HorizontalAlignment.Left, true));

            ColumnArray.Add(new ListColumnInfo("处理意见", "ProcessHandlingSuggestion", 150, HorizontalAlignment.Left, true));
            ColumnArray.Add(new ListColumnInfo("联系人", "Processlinkman", 80, HorizontalAlignment.Left, true));
            ColumnArray.Add(new ListColumnInfo("购买日期", "ProcessPurchasingDate", 100, HorizontalAlignment.Left, true));

            ColumnArray.Add(new ListColumnInfo("服务人员", "ProcessServiceUser", 80, HorizontalAlignment.Left, true));
            ColumnArray.Add(new ListColumnInfo("规格型号", "ProcessStandard", 80, HorizontalAlignment.Left, true));
            ColumnArray.Add(new ListColumnInfo("电话", "Processtel", 100, HorizontalAlignment.Left, true));

            return ColumnArray;
        }

        /// <summary>
        /// 1.10.库存查询 字段列表
        /// </summary>
        /// <returns></returns>
        private List<ListColumnInfo> GetInventoryColumns()
        {
            List<ListColumnInfo> ColumnArray = new List<ListColumnInfo>();
            ColumnArray.Add(new ListColumnInfo("NO", "OrderNumber", 40, HorizontalAlignment.Left, true));
            ColumnArray.Add(new ListColumnInfo("产品名称", "p_cpmc", 120, HorizontalAlignment.Left, true));
            ColumnArray.Add(new ListColumnInfo("生产商", "p_zzs", 120, HorizontalAlignment.Left, true));
            ColumnArray.Add(new ListColumnInfo("规格型号", "p_ggxh", 80, HorizontalAlignment.Left, true));
            ColumnArray.Add(new ListColumnInfo("材料名称", "p_clmc", 120, HorizontalAlignment.Left, true));
            ColumnArray.Add(new ListColumnInfo("注册证号", "p_zczh", 120, HorizontalAlignment.Left, true));
            ColumnArray.Add(new ListColumnInfo("数量", "p_sl1", 100, HorizontalAlignment.Left, true));
            ColumnArray.Add(new ListColumnInfo("更新时间", "p_date", 120, HorizontalAlignment.Left, true));
            return ColumnArray;

        }
        #endregion

        /// <summary>
        ///  1.3 初始化栏位
        /// </summary>
        /// <param name="ColumnArray">列数组</param>
        /// <param name="_Type">类型</param>
        private void InitializedListColumn(List<ListColumnInfo> ColumnArray, UIModels.EntryType _Type)
        {
            if (this.RecordListView.Columns != null && this.RecordListView.Columns.Count > 0)
            {
                this.RecordListView.Columns.Clear();
            }
            IListViewColumnFormater iformater = null;
            switch (_Type)
            {
                case EntryType.ZDSJGJ:
                    iformater = new UIBLL.GouJinInfoListFormater();
                    break;
                case EntryType.YS:
                    iformater = new UIBLL.YanShouInfoListFormaterManager();
                    break;
                case EntryType.CC:
                    iformater = new UIBLL.CunChuInfoListFormatManager();
                    break;
                case EntryType.XS:
                    iformater = new UIBLL.XiaoShouInfoListFormaterManager();
                    break;
                case EntryType.CK:
                    iformater = new UIBLL.ChuKuInfoListFormatManager();
                    break;
                case EntryType.SH:
                    iformater = new UIBLL.ShouHouInfoListFormaterManager();
                    break;
                case EntryType.BHGPJL:
                    iformater = new UIBLL.BuHeGePinJiLuInfoListFormatManager();
                    break;
                case EntryType.BLSJ:
                    iformater = new UIBLL.BuLiangShiJianInfoListFormatManager();
                    break;
                case EntryType.ZLGZ:
                    iformater = new UIBLL.ProcessLoggingInfoListFormaterManager();
                    break;
                case EntryType.Inventory:
                    iformater = new UIBLL.InventoryInfoListFormaterManager();
                    break;
                default:
                    break;
            }
            InitListViewColumnManager manager = new InitListViewColumnManager();
            manager.Init(this.RecordListView, ColumnArray, iformater);
        }



        /// <summary>
        /// 1.5. 向ListView 中添加栏位
        /// </summary>
        /// <param name="_ColumnList"></param>
        private void AddColumnsToListVIew(List<OLVColumn> _ColumnList)
        {
            if (_ColumnList != null && _ColumnList.Count > 0)
            {
                foreach (OLVColumn _Column in _ColumnList)
                {
                    this.RecordListView.Columns.Add(_Column);
                }
            }
        }
 
       
        /// <summary>
        /// List View 数据重新加载
        /// </summary>
        /// <param name="_list"></param>
        private void ListViewReloadData(System.Collections.ICollection _list)
        {
            this.RecordListView.Items.Clear();
            this.RecordListView.ClearObjects();
            if (_list != null && _list.Count > 0)
            { 
                this.RecordListView.AddObjects(_list);
            }
      
        }

        #endregion


        #region 导出数据
        /// <summary>
        /// 导出所有项
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TolMenuSaveAS_ALL_Click(object sender, EventArgs e)
        {
            SaveListToExcel(ThisList);
        }

        /// <summary>
        /// 导出选中项
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TolMenuSaveAS_Selected_Click(object sender, EventArgs e)
        {
            if (this.RecordListView.SelectedObjects != null && this.RecordListView.SelectedObjects.Count > 0)
            {
                SaveListToExcel(this.RecordListView.SelectedObjects);
            }
            else
            {
                MessageBox.Show("您未选择任何项，请重新选择后再试！");
            }
        }

        private void SaveListToExcel(System.Collections.ICollection _list)
        {
            if (_list != null && _list.Count > 0)
            {
                ExcelSaveDiloag excelsave = new ExcelSaveDiloag();
                if (excelsave.ShowDialog() == DialogResult.OK)
                {
                    ExPortDataToExcel exprotdatatoexcel = new ExPortDataToExcel(_list, ThisType, excelsave.ExportExcelPath);
                    exprotdatatoexcel.ExportListDataEndEvent += new ExPortDataToExcel.DelExportDataArg(exprotdatatoexcel_ExportListDataEndEvent);
                    exprotdatatoexcel.Start();

                    TolMsgInfo.Text = "表单数据导出中，请稍候....";
                }
            }
            else
            {
                MessageBox.Show("当前列表无数据或您未选择任何项，请选中数据项后再试！");
            }
        }

        void exprotdatatoexcel_ExportListDataEndEvent(bool _statevalue, string _MsgInfo)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new ExPortDataToExcel.DelExportDataArg(ShowExportDataEndInfo), new object[] { _statevalue, _MsgInfo });

            }
            else
            {
                ShowExportDataEndInfo(_statevalue, _MsgInfo);
            }
            
        }

        private void ShowExportDataEndInfo(bool _statevalue, string _MsgInfo)
        {
            if (_statevalue)
            {
                MessageBox.Show("导出成功!");
            }
            else
            {
                MessageBox.Show("导出失败！");
            }

            int listcount = 0;
            if (ThisList != null)
            {
                listcount = ThisList.Count;
            }
            TolMsgInfo.Text = string.Format("获取列表数据成功，共有 {0} 条符合条件的记录！", listcount);
        }
        #endregion

        #region 3.右键菜单 编辑/删除
        /// <summary>
        /// 3.1.编辑
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ListItem_Edit_Click(object sender, EventArgs e)
        {
            if (this.RecordListView.SelectedObjects != null && this.RecordListView.SelectedObjects.Count > 0)
            {
                EntryForm efrm = new EntryForm(ThisType, this.RecordListView.SelectedObjects[0],ThisDevice);
                efrm.ShowDialog();
            }
            else
            {
                MessageBox.Show("请选中项后再试！");
            }
        }

        /// <summary>
        /// 3.2.删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ListItem_Delete_Click(object sender, EventArgs e)
        {
            if (this.RecordListView.SelectedObjects != null && this.RecordListView.SelectedObjects.Count > 0)
            {
                int RecordCount = this.RecordListView.SelectedObjects.Count;
                string strThisTipTxt = "";
                switch (ThisType)
                {
                    case EntryType.ZDSJGJ:
                        strThisTipTxt = "诊断试剂购进";
                        DelZDSJGJ(this.RecordListView.SelectedObjects, strThisTipTxt);
                        break;
                    case EntryType.YS:
                        strThisTipTxt = "诊断试剂验收";
                        DelYS(this.RecordListView.SelectedObjects, strThisTipTxt);
                        break;
                    case EntryType.CC:
                        strThisTipTxt = "诊断试剂存储";
                        DelCC(this.RecordListView.SelectedObjects, strThisTipTxt);
                        break;
                    case EntryType.XS:
                        strThisTipTxt = "诊断试剂销售";
                        DelXS(this.RecordListView.SelectedObjects, strThisTipTxt);
                        break;
                    case EntryType.CK:
                        strThisTipTxt = "诊断试剂出库";
                        DelCK(this.RecordListView.SelectedObjects, strThisTipTxt);
                        break;
                    case EntryType.SH:
                        strThisTipTxt = "诊断试剂退换货";
                        DelSH(this.RecordListView.SelectedObjects, strThisTipTxt);
                        break;
                    case EntryType.BHGPJL:
                        strThisTipTxt = "不合格品记录";
                        DelBHGPJL(this.RecordListView.SelectedObjects, strThisTipTxt);
                        break;
                    case EntryType.BLSJ:
                        strThisTipTxt = "不良事件";
                        DelBLSJ(this.RecordListView.SelectedObjects, strThisTipTxt);
                        break;
                    case EntryType.ZLGZ:
                        strThisTipTxt = "质量跟踪";
                        DelZLGZ(this.RecordListView.SelectedObjects, strThisTipTxt);
                        break;
                    default:
                        break;
                }
 
            }
            else
            {
                MessageBox.Show("请选中项后再试！");
            }

        }

        #region 3.2. 表单记录删除

        /// <summary>
        /// 3.2.1.删除诊断试剂购进记录删除
        /// </summary>
        /// <param name="_list"></param>
        private void DelZDSJGJ(System.Collections.IList _list, string strTpeName)
        {
            if (new ConfirmFrm("确认删除", string.Format("您确定需要删除所选的 {0} 条【{1}】记录？", _list.Count, strTpeName), "是", "否", 3).ShowDialog() == DialogResult.OK)
            {
                string strIDList = "";
                foreach (object _obj in _list)
                {
                    if (_obj is KPS.Model.GouJinInfo)
                    {
                        strIDList = strIDList + ((KPS.Model.GouJinInfo)_obj).ID + ",";
                    }
                }
                if (strIDList.Contains(","))
                {
                    strIDList = strIDList.Substring(0, strIDList.Length - 1);
                }
                
                if (strIDList.Length > 0)
                {
                    KPS.BLL.GouJinManager gjmanager = new BLL.GouJinManager();
                    if (gjmanager.DeleteList(strIDList))
                    {
                        MessageBox.Show("删除成功！");
                        this.RecordListView.RemoveObjects(_list);
                    }
                    else
                    {
                        MessageBox.Show("删除失败！");
                    }
                }
            }
        }

        /// <summary>
        /// 3.2.2.删除诊断试剂验收记录
        /// </summary>
        /// <param name="_list"></param>
        /// <param name="strTpeName">类型名称</param>
        private void DelYS(System.Collections.IList _list, string strTpeName)
        {
            if (new ConfirmFrm("确认删除", string.Format("您确定需要删除所选的 {0} 条【{1}】记录？", _list.Count, strTpeName), "是", "否", 3).ShowDialog() == DialogResult.OK)
            {
                string strIDList = "";
                foreach (object _obj in _list)
                {
                    if (_obj is KPS.Model.YanShouInfo)
                    {
                        strIDList = strIDList + ((KPS.Model.YanShouInfo)_obj).ID + ",";
                    }
                }
                if (strIDList.Contains(","))
                {
                    strIDList = strIDList.Substring(0, strIDList.Length - 1);
                }

                if (strIDList.Length > 0)
                {
                    KPS.BLL.YanShouManager manager = new BLL.YanShouManager();
                    if (manager.DeleteList(strIDList))
                    {
                        MessageBox.Show("删除成功！");
                        this.RecordListView.RemoveObjects(_list);
                    }
                    else
                    {
                        MessageBox.Show("删除失败！");
                    }
                }
            }
        }

        /// <summary>
        /// 3.2.3.删除诊断试剂存储记录
        /// </summary>
        /// <param name="_list"></param>
        /// <param name="strTpeName">类型名称</param>
        private void DelCC(System.Collections.IList _list, string strTpeName)
        {
            if (new ConfirmFrm("确认删除", string.Format("您确定需要删除所选的 {0} 条【{1}】记录？", _list.Count, strTpeName), "是", "否", 3).ShowDialog() == DialogResult.OK)
            {
                string strIDList = "";
                foreach (object _obj in _list)
                {
                    if (_obj is KPS.Model.CunChuInfo)
                    {
                        strIDList = strIDList + ((KPS.Model.CunChuInfo)_obj).ID + ",";
                    }
                }
                if (strIDList.Contains(","))
                {
                    strIDList = strIDList.Substring(0, strIDList.Length - 1);
                }

                if (strIDList.Length > 0)
                {
                    KPS.BLL.CunChuManager manager = new BLL.CunChuManager();
                    if (manager.DeleteList(strIDList))
                    {
                        MessageBox.Show("删除成功！");
                        this.RecordListView.RemoveObjects(_list);
                    }
                    else
                    {
                        MessageBox.Show("删除失败！");
                    }
                }
            }
        }

        /// <summary>
        /// 3.2.4.删除诊断试剂销售记录
        /// </summary>
        /// <param name="_list"></param>
        /// <param name="strTpeName">类型名称</param>
        private void DelXS(System.Collections.IList _list, string strTpeName)
        {
            if (new ConfirmFrm("确认删除", string.Format("您确定需要删除所选的 {0} 条【{1}】记录？", _list.Count, strTpeName), "是", "否", 3).ShowDialog() == DialogResult.OK)
            {
                string strIDList = "";
                foreach (object _obj in _list)
                {
                    if (_obj is KPS.Model.XiaoShouInfo)
                    {
                        strIDList = strIDList + ((KPS.Model.XiaoShouInfo)_obj).ID + ",";
                    }
                }
                if (strIDList.Contains(","))
                {
                    strIDList = strIDList.Substring(0, strIDList.Length - 1);
                }

                if (strIDList.Length > 0)
                {
                    KPS.BLL.XiaoShouManager manager = new BLL.XiaoShouManager();
                    if (manager.DeleteList(strIDList))
                    {
                        MessageBox.Show("删除成功！");
                        this.RecordListView.RemoveObjects(_list);
                    }
                    else
                    {
                        MessageBox.Show("删除失败！");
                    }
                }
            }
        }

        /// <summary>
        /// 3.2.5.删除诊断试剂销售记录
        /// </summary>
        /// <param name="_list"></param>
        /// <param name="strTpeName">类型名称</param>
        private void DelCK(System.Collections.IList _list, string strTpeName)
        {
            if (new ConfirmFrm("确认删除", string.Format("您确定需要删除所选的 {0} 条【{1}】记录？", _list.Count, strTpeName), "是", "否", 3).ShowDialog() == DialogResult.OK)
            {
                string strIDList = "";
                foreach (object _obj in _list)
                {
                    if (_obj is KPS.Model.ChuKuInfo)
                    {
                        strIDList = strIDList + ((KPS.Model.ChuKuInfo)_obj).ID + ",";
                    }
                }
                if (strIDList.Contains(","))
                {
                    strIDList = strIDList.Substring(0, strIDList.Length - 1);
                }

                if (strIDList.Length > 0)
                {
                    KPS.BLL.ChuKuManager manager = new BLL.ChuKuManager();
                    if (manager.DeleteList(strIDList))
                    {
                        MessageBox.Show("删除成功！");
                        this.RecordListView.RemoveObjects(_list);
                    }
                    else
                    {
                        MessageBox.Show("删除失败！");
                    }
                }
            }
        }

        /// <summary>
        /// 3.2.6.删除诊断试剂出库记录
        /// </summary>
        /// <param name="_list"></param>
        /// <param name="strTpeName">类型名称</param>
        private void DelSH(System.Collections.IList _list, string strTpeName)
        {
            if (new ConfirmFrm("确认删除", string.Format("您确定需要删除所选的 {0} 条【{1}】记录？", _list.Count, strTpeName), "是", "否", 3).ShowDialog() == DialogResult.OK)
            {
                string strIDList = "";
                foreach (object _obj in _list)
                {
                    if (_obj is KPS.Model.ShouHouInfo)
                    {
                        strIDList = strIDList + ((KPS.Model.ShouHouInfo)_obj).ID + ",";
                    }
                }
                if (strIDList.Contains(","))
                {
                    strIDList = strIDList.Substring(0, strIDList.Length - 1);
                }

                if (strIDList.Length > 0)
                {
                    KPS.BLL.ShouHouManager manager = new BLL.ShouHouManager();
                    if (manager.DeleteList(strIDList))
                    {
                        MessageBox.Show("删除成功！");
                        this.RecordListView.RemoveObjects(_list);
                    }
                    else
                    {
                        MessageBox.Show("删除失败！");
                    }
                }
            }
        }

        /// <summary>
        /// 3.2.7.删除不合格品记录
        /// </summary>
        /// <param name="_list"></param>
        /// <param name="strTpeName">类型名称</param>
        private void DelBHGPJL(System.Collections.IList _list, string strTpeName)
        {
            if (new ConfirmFrm("确认删除", string.Format("您确定需要删除所选的 {0} 条【{1}】记录？", _list.Count, strTpeName), "是", "否", 3).ShowDialog() == DialogResult.OK)
            {
                string strIDList = "";
                foreach (object _obj in _list)
                {
                    if (_obj is KPS.Model.BuHeGePinJiLuInfo)
                    {
                        strIDList = strIDList + ((KPS.Model.BuHeGePinJiLuInfo)_obj).ID + ",";
                    }
                }
                if (strIDList.Contains(","))
                {
                    strIDList = strIDList.Substring(0, strIDList.Length - 1);
                }

                if (strIDList.Length > 0)
                {
                    KPS.BLL.BuHeGePinJiLuManager manager = new BLL.BuHeGePinJiLuManager();
                    if (manager.DeleteList(strIDList))
                    {
                        MessageBox.Show("删除成功！");
                        this.RecordListView.RemoveObjects(_list);
                    }
                    else
                    {
                        MessageBox.Show("删除失败！");
                    }
                }
            }
        }

        /// <summary>
        /// 3.2.8.删除不良事件记录
        /// </summary>
        /// <param name="_list"></param>
        /// <param name="strTpeName">类型名称</param>
        private void DelBLSJ(System.Collections.IList _list, string strTpeName)
        {
            if (new ConfirmFrm("确认删除", string.Format("您确定需要删除所选的 {0} 条【{1}】记录？", _list.Count, strTpeName), "是", "否", 3).ShowDialog() == DialogResult.OK)
            {
                string strIDList = "";
                foreach (object _obj in _list)
                {
                    if (_obj is KPS.Model.BuLiangShiJianInfo)
                    {
                        strIDList = strIDList + ((KPS.Model.BuLiangShiJianInfo)_obj).ID + ",";
                    }
                }
                if (strIDList.Contains(","))
                {
                    strIDList = strIDList.Substring(0, strIDList.Length - 1);
                }

                if (strIDList.Length > 0)
                {
                    KPS.BLL.BuLiangShiJianManager manager = new BLL.BuLiangShiJianManager();
                    if (manager.DeleteList(strIDList))
                    {
                        MessageBox.Show("删除成功！");
                        this.RecordListView.RemoveObjects(_list);
                    }
                    else
                    {
                        MessageBox.Show("删除失败！");
                    }
                }
            }
        }
        
        /// <summary>
        /// 3.2.9.质量跟踪记录
        /// </summary>
        /// <param name="_list"></param>
        /// <param name="strTpeName">类型名称</param>
        private void DelZLGZ(System.Collections.IList _list, string strTpeName)
        {
            if (new ConfirmFrm("确认删除", string.Format("您确定需要删除所选的 {0} 条【{1}】记录？", _list.Count, strTpeName), "是", "否", 3).ShowDialog() == DialogResult.OK)
            {
                string strIDList = "";
                foreach (object _obj in _list)
                {
                    if (_obj is KPS.Model.ProcessLoggingInfo)
                    {
                        strIDList = strIDList + ((KPS.Model.ProcessLoggingInfo)_obj).ProcessID + ",";
                    }
                }
                if (strIDList.Contains(","))
                {
                    strIDList = strIDList.Substring(0, strIDList.Length - 1);
                }

                if (strIDList.Length > 0)
                {
                    KPS.BLL.ProcessLoggingManager manager = new BLL.ProcessLoggingManager();
                    if (manager.DeleteList(strIDList))
                    {
                        MessageBox.Show("删除成功！");
                        this.RecordListView.RemoveObjects(_list);
                    }
                    else
                    {
                        MessageBox.Show("删除失败！");
                    }
                }
            }
        }
        #endregion

      

        #endregion

        #region 仪器器械类型切换
        private void CmboxDeviceClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CmboxDeviceClass.Items != null && CmboxDeviceClass.Items.Count > 0)
            {
                ThisDevice = ((List<KPS.Model.DeviceInfo>)CmboxDeviceClass.Tag)[CmboxDeviceClass.SelectedIndex];

                ModelTypeText = string.Format("{0} {1}", ThisDevice.DeviceType, strThisTitleTxt);
                this.Text = ModelTypeText;
                if (_conditoncontrol != null) 
                {
                    CmboxDeviceClass.Enabled = false;

                    _conditoncontrol.ChangeDeviceType(ThisDevice);
                }
            }
        }
        #endregion

        /// <summary>
        /// 打印预览
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PrintTol_List_Click(object sender, EventArgs e)
        {
            //if (ThisType == EntryType.Inventory)
            //{
            //    if(ThisList is List<Model.GouJinInfo>)
            //    {
            //        ListPrint print = new ListPrint((List<Model.GouJinInfo>)ThisList);
            //        print.ShowDialog();
            //    }
               
            //}
            //else
            //{
            //    this.listViewPrinter1.CellFormat = null;
            //    this.listViewPrinter1.ListFont = new Font("Ms Sans Serif", 9);
            //    this.listViewPrinter1.ListGridPen = new Pen(Color.DarkGray, 0.5f);

            //    this.listViewPrinter1.HeaderFormat = BlockFormat.Header(new Font("Verdana", 24, FontStyle.Bold));
            //    this.listViewPrinter1.HeaderFormat.BackgroundBrush = new LinearGradientBrush(new Rectangle(0, 0, 1, 1), Color.DarkBlue, Color.White, LinearGradientMode.Horizontal);

            //    this.listViewPrinter1.FooterFormat = BlockFormat.Footer();
            //    this.listViewPrinter1.FooterFormat.BackgroundBrush = new LinearGradientBrush(new Rectangle(0, 0, 1, 1), Color.White, Color.DarkBlue, LinearGradientMode.Horizontal);

            //    this.listViewPrinter1.GroupHeaderFormat = BlockFormat.GroupHeader();
            //    this.listViewPrinter1.ListHeaderFormat = BlockFormat.ListHeader(new Font("Verdana", 12));

            //    this.listViewPrinter1.WatermarkFont = null;
            //    this.listViewPrinter1.WatermarkColor = Color.Empty;

            //    this.listViewPrinter1.PrintPreview();
            //}

            ListPrint newprint = new ListPrint(ThisList);
            newprint.ShowDialog();
        }

    }
}
