using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Text;
using System.Windows.Forms;
using KPS.Model;
using KPS.BLL;
using KPS.UIModels;
using CSharpWin;

namespace KPS
{
    /// <summary>
    /// 表单录入界面
    /// </summary>
    public partial class EntryForm:SkinForm
    {
        /// <summary>
        /// 表单类型
        /// </summary>
        private UIModels.EntryType ThisEntryType;
        private EntryModel.ModelUserControl _control;
        private object ModelData = null;
        private DeviceInfo thisdeviceinfo = null;

        /// <summary>
        /// 添加新项成功
        /// </summary>
        public event EventHandler AddItemSuccedEvent; 

        /// <summary>
        /// 新增表单
        /// </summary>
        /// <param name="_entrytype"></param>
        public EntryForm(UIModels.EntryType _entrytype,DeviceInfo _deviceinfo)
        {
            ThisEntryType = _entrytype;
            //thisdeviceinfo = _deviceinfo;
            InitializeComponent();

            LoadDeviceItems();
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
                int selectedindex = 0;
                int forindex = 0;
                foreach (KPS.Model.DeviceInfo _device in listdevicelist)
                {
                    if (thisdeviceinfo != null && thisdeviceinfo.DeviceID == _device.DeviceID) 
                    {
                        selectedindex = forindex;
                    }
                    CmboxDeviceClass.Items.Add(_device.DeviceType);
                    forindex++;
                }

                CmboxDeviceClass.Tag = listdevicelist;
                CmboxDeviceClass.SelectedIndex = selectedindex;
                thisdeviceinfo = listdevicelist[selectedindex];
            }
        }
        
        /// <summary>
        /// 编辑表单信息
        /// </summary>
        /// <param name="_entrytype"></param>
        /// <param name="_Model"></param>
        public EntryForm(UIModels.EntryType _entrytype, object _Model, DeviceInfo _deviceinfo)
        {
            ThisEntryType = _entrytype;
            ModelData = _Model;
            thisdeviceinfo = _deviceinfo;
            InitializeComponent();

            LoadDeviceItems();
        }

        /// <summary>
        /// 页面加载处理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EntryForm_Load(object sender, EventArgs e)
        {
            //1.初始化UI显示
            InitUITipsInfo();
            
            //2.获取对应类型表单的历史记录信息(全部/部分)
            //GetFormRecords();
        }

        private string ThisFromTitle = "产品采购记录";
        /// <summary>
        /// 初始化UI提示信息显示
        /// </summary>
        private void InitUITipsInfo()
        {
            switch (ThisEntryType)
            { 
                case UIModels.EntryType.ZDSJGJ:
                    ThisFromTitle = "购进";
                    _control = new EntryModel.ZDSJGJ((GouJinInfo)ModelData);
                    btnPrint.Visible = true;
                    break;
                case UIModels.EntryType.YS:
                    ThisFromTitle = "验收";
                    _control = new EntryModel.YS((YanShouInfo)ModelData);
                    break;
                case UIModels.EntryType.CC:
                    ThisFromTitle = "存储";
                    _control = new EntryModel.CC((CunChuInfo)ModelData);
                    break;
                case UIModels.EntryType.XS:
                        ThisFromTitle = "销售";
                        _control = new EntryModel.XS((XiaoShouInfo)ModelData);
                    break;
                case UIModels.EntryType.CK:
                    ThisFromTitle = "出库";
                    _control = new EntryModel.CK((ChuKuInfo)ModelData);
                    break;
                case UIModels.EntryType.SH:
                    _control = new EntryModel.SH((ShouHouInfo)ModelData);
                    ThisFromTitle = "退换货";
                    break;
                case UIModels.EntryType.BHGPJL:
                    _control = new EntryModel.BHGPJL((BuHeGePinJiLuInfo)ModelData);
                    ThisFromTitle = "不合格品记录";
                    break;
                case UIModels.EntryType.BLSJ:
                    _control = new EntryModel.BLSJ((BuLiangShiJianInfo)ModelData);
                    ThisFromTitle = "不良事件";
                    break;
                case UIModels.EntryType.ZLGZ:
                    ThisFromTitle = "质量跟踪";
                    _control = new EntryModel.ZLGZ((ProcessLoggingInfo)ModelData);
                    break;
                default:
                    ThisFromTitle = "诊断试剂购进";
                    break;
            }
            _control.SetEntryType(ThisEntryType);
            groupBox1.Controls.Add(_control);
            _control.Dock = DockStyle.Fill;


            if (ModelData != null)
            {
                this.Text = string.Format("{0}{1} 信息编辑", thisdeviceinfo.DeviceType, ThisFromTitle);
            }
            else 
            {
                //窗体标题
                this.Text = string.Format("{0}{1}", thisdeviceinfo.DeviceType, ThisFromTitle);
            }
 
            if (_control != null)
            {
                groupBox1.Controls.Add(_control);
                _control.Dock = DockStyle.Fill;
            }

        }

        /// <summary>
        /// 获取历史表单列表
        /// </summary>
        private void GetFormRecords()
        {
            
        }

        /// <summary>
        /// 保存 表单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            switch (ThisEntryType)
            { 
                case EntryType.ZDSJGJ:
                    ManagerZDSJGJ();
                    break;
                case EntryType.YS:
                    ManagerYS();
                    break;
                case EntryType.CC:
                    ManagerCC();
                    break;
                case EntryType.XS:
                    ManagerXS();
                    break;
                case EntryType.CK:
                    ManagerCK();
                    break;
                case EntryType.SH:
                    ManagerSH();
                    break;
                case EntryType.BHGPJL:
                    ManagerBHGPJL();
                    break;
                case EntryType.BLSJ:
                    ManagerBLSJ();
                    break;
                case EntryType.ZLGZ:
                    ManagerZLGZ();
                    break;
                default:
                    break;
            }
            
        }

   

        #region 1.表单录入处理

        /// <summary>
        /// 显示状态信息
        /// </summary>
        /// <param name="_state"></param>
        /// <param name="_ModelInfo"></param>
        private void ShowMsgStateInfo(bool _state, object _ModelInfo)
        {
            if (_state)
            {
                if (_ModelInfo != null)
                {
                    MessageBox.Show("编辑成功！");
                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    if (AddItemSuccedEvent != null)
                    {
                        AddItemSuccedEvent(null, null);
                    }
                    MessageBox.Show("添加记录成功！");
                    this.DialogResult = DialogResult.OK;
                }
            }
            else
            {
                if (_ModelInfo != null)
                {
                    MessageBox.Show("编辑失败！");
                }
                else
                {
                    MessageBox.Show("添加记录失败！");
                }
            }
        }
        /// <summary>
        /// 1.诊断试剂购进
        /// </summary>
        private void ManagerZDSJGJ()
        {
            bool bolState = false;

            try
            {
                KPS.Model.GouJinInfo _Modelinfo = (KPS.Model.GouJinInfo)_control.GetSaveData();
                _Modelinfo.DataType = thisdeviceinfo.DeviceID;

                KPS.BLL.GouJinManager gjmanager = new GouJinManager();
                if (ModelData != null)
                {
                    _Modelinfo.ID = ((GouJinInfo)ModelData).ID;
                    bolState = gjmanager.Update(_Modelinfo);
                }
                else
                {
                    bolState = gjmanager.Add(_Modelinfo);
                    if (bolState)
                    {
                        //库存中新增购进记录
                        KPS.BLL.InventoryManager inventorymg = new InventoryManager();
                        inventorymg.Add(_Modelinfo);
                    }
                }
            }
            catch (Exception ex)
            {
                bolState = false;
            }

            ShowMsgStateInfo(bolState, ModelData);
        }

        /// <summary>
        /// 2.验收(产品采购记录)
        /// </summary>
        private void ManagerYS()
        {
            bool bolState = false;
            try
            {
                KPS.Model.YanShouInfo _Modelinfo = (KPS.Model.YanShouInfo)_control.GetSaveData();
                _Modelinfo.DataType = thisdeviceinfo.DeviceID;

                KPS.BLL.YanShouManager ysmanager = new YanShouManager();
                if (ModelData != null)
                {
                    _Modelinfo.ID = ((YanShouInfo)ModelData).ID;
                    bolState = ysmanager.Update(_Modelinfo);
                }
                else
                {
                    bolState = ysmanager.Add(_Modelinfo);
                }
               
            }
            catch (Exception ex)
            {
                bolState = false;
            }

            ShowMsgStateInfo(bolState, ModelData);
        }
        /// <summary>
        /// 3.存储
        /// </summary>
         private void ManagerCC()
        {
            bool bolState = false;
            try
            {
                CunChuInfo cunchuinfo =(KPS.Model.CunChuInfo)_control.GetSaveData();
                cunchuinfo.DataType = thisdeviceinfo.DeviceID;

                KPS.BLL.CunChuManager cunchumanager = new CunChuManager();
 
                if (ModelData != null)
                {
                    cunchuinfo.ID = ((CunChuInfo)ModelData).ID;
                    bolState = cunchumanager.Update(cunchuinfo);
                }
                else
                {
                    bolState = cunchumanager.Add(cunchuinfo);
                }
            }
            catch (Exception ex)
            {
                bolState = false;
            }

            ShowMsgStateInfo(bolState, ModelData);
        }

        /// <summary>
        /// 4.销售
        /// </summary>
        private void ManagerXS()
        {
            bool bolState = false;
            try
            {
                KPS.Model.XiaoShouInfo _Modelinfo = (KPS.Model.XiaoShouInfo)_control.GetSaveData();
                _Modelinfo.DataType = thisdeviceinfo.DeviceID;

                KPS.BLL.XiaoShouManager xiaoshoumanager = new XiaoShouManager();
                if (ModelData != null)
                {
                    _Modelinfo.ID = ((XiaoShouInfo)ModelData).ID;
                    bolState = xiaoshoumanager.Update(_Modelinfo);

                     ShowMsgStateInfo(bolState, ModelData);
                }
                else
                {
                    KPS.BLL.InventoryManager InventoryMg = new InventoryManager();
                    InventoryUpState _stateinfo= InventoryMg.Sell(_Modelinfo);
                    switch (_stateinfo)
                    { 
                        case InventoryUpState.Succed:
                            bolState = xiaoshoumanager.Add(_Modelinfo);
                            ShowMsgStateInfo(bolState, ModelData);
                            break;
                        case InventoryUpState.ProductLacking:
                            MessageBox.Show("库存不足，无法新增销售记录!(可通过新增购进记录来增加库存)");
                            break;
                        case InventoryUpState.ProductNoExt:
                            MessageBox.Show("未找到符合条件的产品购进记录!(请核对 产品名称+生产厂家+注册证号+批号 是否正确)");
                            break;
                        case InventoryUpState.SysTemError:
                            MessageBox.Show("处理失败！");
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                ShowMsgStateInfo(bolState, ModelData);
                bolState = false;
            }
        }

        /// <summary>
        /// 5.出库
        /// </summary>
        private void ManagerCK()
        {
            bool bolState = false;
            try
            {
                KPS.Model.ChuKuInfo _Modelinfo = (KPS.Model.ChuKuInfo)_control.GetSaveData();
                _Modelinfo.DataType = thisdeviceinfo.DeviceID;

                KPS.BLL.ChuKuManager chukumnager = new ChuKuManager();
                if (ModelData != null)
                {
                    _Modelinfo.ID = ((ChuKuInfo)ModelData).ID;
                    bolState = chukumnager.Update(_Modelinfo);
                }
                else
                {
                    bolState = chukumnager.Add(_Modelinfo);
                }
            }
            catch (Exception ex)
            {
                bolState = false;
            }

            ShowMsgStateInfo(bolState, ModelData);
        }

        /// <summary>
        /// 6.售后
        /// </summary>
        private void ManagerSH()
        {
            bool bolState = false;
            try
            {
                KPS.Model.ShouHouInfo _Modelinfo = (KPS.Model.ShouHouInfo)_control.GetSaveData();
                _Modelinfo.DataType = thisdeviceinfo.DeviceID;

                KPS.BLL.ShouHouManager shouhoumanager = new ShouHouManager();
                if (ModelData != null)
                {
                    _Modelinfo.ID = ((ShouHouInfo)ModelData).ID;
                    bolState = shouhoumanager.Update(_Modelinfo);
                }
                else
                {
                    bolState = shouhoumanager.Add(_Modelinfo);
                }
            }
            catch (Exception ex)
            {
                bolState = false;
            }

            ShowMsgStateInfo(bolState, ModelData);
        }

        /// <summary>
        /// 7.处理不合格品记录
        /// </summary>
        private void ManagerBHGPJL()
        {
            bool bolState = false;
            try
            {
                KPS.Model.BuHeGePinJiLuInfo _Modelinfo = (KPS.Model.BuHeGePinJiLuInfo)_control.GetSaveData();
                _Modelinfo.DataType = thisdeviceinfo.DeviceID;

                KPS.BLL.BuHeGePinJiLuManager bhgpmanager = new BuHeGePinJiLuManager();
                if (ModelData != null)
                {
                    _Modelinfo.ID = ((BuHeGePinJiLuInfo)ModelData).ID;
                    bolState = bhgpmanager.Update(_Modelinfo);
                }
                else
                {
                    bolState = bhgpmanager.Add(_Modelinfo);
                }
            }
            catch (Exception ex)
            {
                bolState = false;
            }

            ShowMsgStateInfo(bolState, ModelData);
        }

        /// <summary>
        /// 8.不良事件
        /// </summary>
        private void ManagerBLSJ()
        {
            bool bolState = false;
            try
            {
                KPS.Model.BuLiangShiJianInfo _Modelinfo = (KPS.Model.BuLiangShiJianInfo)_control.GetSaveData();
                _Modelinfo.DataType = thisdeviceinfo.DeviceID;

                KPS.BLL.BuLiangShiJianManager blsjmanager = new BuLiangShiJianManager();
                if (ModelData != null)
                {
                    _Modelinfo.ID = ((BuLiangShiJianInfo)ModelData).ID;
                    bolState = blsjmanager.Update(_Modelinfo);
                }
                else
                {
                    bolState = blsjmanager.Add(_Modelinfo);
                }
            }
            catch (Exception ex)
            {
                bolState = false;
            }

            ShowMsgStateInfo(bolState, ModelData);
        }

        /// <summary>
        /// 9.质量跟踪
        /// </summary>
        private void ManagerZLGZ()
        {
            bool bolState = false;
            try
            {
                KPS.Model.ProcessLoggingInfo _Modelinfo = (KPS.Model.ProcessLoggingInfo)_control.GetSaveData();
                _Modelinfo.DataType = thisdeviceinfo.DeviceID;

                KPS.BLL.ProcessLoggingManager plmanager = new ProcessLoggingManager();
                if (ModelData != null)
                {
                    _Modelinfo.ProcessID = ((ProcessLoggingInfo)ModelData).ProcessID;
                    bolState = plmanager.Update(_Modelinfo);
                }
                else
                {
                    bolState = plmanager.Add(_Modelinfo);
                }
            }
            catch (Exception ex)
            {
                bolState = false;
            }

            ShowMsgStateInfo(bolState, ModelData);
        }

        /// <summary>
        /// 取消
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {

        }
        #endregion

        #region 医疗仪器类型更改
        private void CmboxDeviceClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CmboxDeviceClass.Items != null && CmboxDeviceClass.Items.Count > 0)
            {
                thisdeviceinfo = ((List<KPS.Model.DeviceInfo>)CmboxDeviceClass.Tag)[CmboxDeviceClass.SelectedIndex];

                if (ModelData != null)
                {
                    this.Text = string.Format("{0}{1} 信息编辑", thisdeviceinfo.DeviceType, ThisFromTitle);
                }
                else
                {
                    //窗体标题
                    this.Text = string.Format("{0}{1}", thisdeviceinfo.DeviceType, ThisFromTitle);
                }
            }
        }
        #endregion

        List<Control> _Linklabels = new List<Control>();
        /// <summary>
        /// 打印
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPrint_Click(object sender, EventArgs e)
        {
            KPS.Model.GouJinInfo _Modelinfo = (KPS.Model.GouJinInfo)_control.GetSaveData();
            ListPrint print = new ListPrint(_Modelinfo);
            print.ShowDialog();
        }
    }
}
