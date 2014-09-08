using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Text;
using System.Windows.Forms;
using CSharpWin;
using KPS.UIModels;
using KPS.UIBLL;
using BrightIdeasSoftware;
using System.Drawing.Drawing2D;

namespace KPS
{
    public partial class SellRecordsQueryFrm:SkinForm
    {
        private System.Collections.ICollection ThisList =null;
        private KPS.Model.DeviceInfo ThisDevice = null;
        private string ModelTypeText = "";

        public SellRecordsQueryFrm(KPS.Model.DeviceInfo _device)
        {
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

            InitRecordList();//初始化列表显示
        }

        private string strThisTitleTxt = "";
        /// <summary>
        /// 查询条件栏位显示
        /// </summary>
        private void InitQueryCondition()
        {
            strThisTitleTxt = "销售汇总";
            dateTimePicker1.Value = DateTime.Now.AddMonths(-1);

            ModelTypeText = string.Format("{0} {1}", ThisDevice.DeviceType,strThisTitleTxt);

            this.Text = string.Format("{0} {1}", ThisDevice.DeviceType, strThisTitleTxt);
        }

        #region 1.列表显示相关

        /// <summary>
        /// 1.1 初始化列表显示
        /// </summary>
        /// <param name="_Type"></param>
        private void InitRecordList()
        {
            this.RecordListView.SelectionChanged += new EventHandler(RecordListView_SelectionChanged);
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
                RecordListView.AddObjects(_list);
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
                    TolMsgInfo.Text = "表单数据导出中，请稍候....";

                    ExPortDataToExcel exprotdatatoexcel = new ExPortDataToExcel(_list,_conditon.TotalType, excelsave.ExportExcelPath);
                    exprotdatatoexcel.ExportListDataEndEvent += new ExPortDataToExcel.DelExportDataArg(exprotdatatoexcel_ExportListDataEndEvent);
                    exprotdatatoexcel.Start();
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

        #region 仪器器械类型切换
        private void CmboxDeviceClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CmboxDeviceClass.Items != null && CmboxDeviceClass.Items.Count > 0)
            {
                ThisDevice = ((List<KPS.Model.DeviceInfo>)CmboxDeviceClass.Tag)[CmboxDeviceClass.SelectedIndex];
                _conditon.DeviceType = ThisDevice.DeviceID;
                ModelTypeText = string.Format("{0} {1}", ThisDevice.DeviceType, strThisTitleTxt);
                this.Text = ModelTypeText;

                StartQueryData();
            }
        }
        #endregion

        #region 查询数据

        SellTotalCondition _conditon = new SellTotalCondition();
        /// <summary>
        /// 点击查询按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            _conditon.DeviceType = ((List<KPS.Model.DeviceInfo>)CmboxDeviceClass.Tag)[CmboxDeviceClass.SelectedIndex].DeviceID;
            _conditon.StartTime = dateTimePicker1.Value;
            _conditon.EndTime = dateTimePicker2.Value;
            _conditon.TotalType = GetTypeByRadioButtons();

            string strTotalTypeName = "";
            switch (_conditon.TotalType)
            {
                case SellTotalType.Customer:
                    strTotalTypeName = "客户名称";
                    break;
                case SellTotalType.Product:
                    strTotalTypeName = "产品名称";
                    break;
                case SellTotalType.ProductAndType:
                    strTotalTypeName = "产品名称+规格型号";
                    break;
                default:
                    strTotalTypeName = "产品名称";
                    break;
            }
            this.GroupName.Text = strTotalTypeName;

            StartQueryData();
        }

        private SellTotalType GetTypeByRadioButtons()
        {
            if (RbtnC.Checked)
            {
                return SellTotalType.Customer;
            }
            else
            {
                if (RbtnP.Checked)
                {
                    return SellTotalType.Product;
                }
                else
                {
                    return SellTotalType.ProductAndType;
                }
            }
        }
        
        private void StartQueryData()
        {
            SortpanalBar.Visible = true;//隐藏loading..
            CmboxDeviceClass.Enabled = false;

            SellRecordsQueryManager manager = new SellRecordsQueryManager();
            manager.QueryEndEvent += new SellRecordsQueryManager.DelSellRecordQueryEndArg(manager_QueryEndEvent);
            manager.TotalSellRecords(_conditon);
        }

        /// <summary>
        /// 查询返回结果
        /// </summary>
        /// <param name="_recors"></param>
        /// <param name="_Succed"></param>
        /// <param name="_MsgInfo"></param>
        void manager_QueryEndEvent(List<SellRecordInfo> _recors,TotalSumInfo _sumInfo, bool _Succed, string _MsgInfo)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new SellRecordsQueryManager.DelSellRecordQueryEndArg(SellRecordListQueryEndManager), new object[] { _recors,_sumInfo, _Succed, _MsgInfo });

            }
            else
            {
                SellRecordListQueryEndManager(_recors,_sumInfo, _Succed, _MsgInfo);
            }
        }

        /// <summary>
        /// 列表显示
        /// </summary>
        /// <param name="_list"></param>
        /// <param name="_state"></param>
        /// <param name="_strMsg"></param>
        private void SellRecordListQueryEndManager(List<SellRecordInfo> _list,TotalSumInfo _sumInfo, bool _state, string _strMsg)
        {
            if (_state)
            {
                ListViewReloadData(_list);
                TolMsgInfo.Text = _strMsg;
            }
            else
            {
                TolMsgInfo.Text = _strMsg;
            }
            ShowTotalSumInfo(_sumInfo);

            SortpanalBar.Visible = false;//隐藏loading..
            CmboxDeviceClass.Enabled = true;
            ThisList = _list;
        }

        /// <summary>
        /// 显示统计合计信息
        /// </summary>
        /// <param name="_sumInfo"></param>
        private void ShowTotalSumInfo(TotalSumInfo _sumInfo)
        {
            if (_sumInfo != null)
            {
                lblTotalNumber.Text = _sumInfo.TotalSumNumber.ToString();
                lblTotalMoney.Text = _sumInfo.TotalSumMoney.ToString();
                lblTotalProfit.Text = _sumInfo.TOtalSumProfit.ToString();
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
             //this.listViewPrinter1.CellFormat = null;
             //this.listViewPrinter1.ListFont = new Font("Ms Sans Serif", 9);
             //this.listViewPrinter1.ListGridPen = new Pen(Color.DarkGray, 0.5f);

             //this.listViewPrinter1.HeaderFormat = BlockFormat.Header(new Font("Verdana", 24, FontStyle.Bold));
             //this.listViewPrinter1.HeaderFormat.BackgroundBrush = new LinearGradientBrush(new Rectangle(0, 0, 1, 1), Color.DarkBlue, Color.White, LinearGradientMode.Horizontal);

             //this.listViewPrinter1.FooterFormat = BlockFormat.Footer();
             //this.listViewPrinter1.FooterFormat.BackgroundBrush = new LinearGradientBrush(new Rectangle(0, 0, 1, 1), Color.White, Color.DarkBlue, LinearGradientMode.Horizontal);

             //this.listViewPrinter1.GroupHeaderFormat = BlockFormat.GroupHeader();
             //this.listViewPrinter1.ListHeaderFormat = BlockFormat.ListHeader(new Font("Verdana", 12));

             //this.listViewPrinter1.WatermarkFont = null;
             //this.listViewPrinter1.WatermarkColor = Color.Empty;

             //this.listViewPrinter1.PrintPreview();
            ListPrint newprint = new ListPrint(ThisList);
            newprint.ShowDialog();

        }

    }
}
