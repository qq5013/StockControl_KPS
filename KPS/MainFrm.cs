using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Text;
using System.Windows.Forms;
using BrightIdeasSoftware;
using KPS.UIModels;
using CSharpWin;
using KPS.UIBLL;
using System.Diagnostics;
using System.IO;

namespace KPS
{
    public partial class MainFrm :SkinForm
    {
        #region 主页面相关环境变量
        /// <summary>
        /// 1.1
        /// </summary>
        private UIModels.EntryType _thisListtype;
        private KPS.Model.DeviceInfo SelectedDevice = new Model.DeviceInfo();
        #endregion

        public MainFrm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 主页面加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainFrm_Load(object sender, EventArgs e)
        {
            DeviceCacheInstanceManager devicemanager = new DeviceCacheInstanceManager();
            List<KPS.Model.DeviceInfo> listdevicelist = devicemanager.DeviceList;
            if (listdevicelist != null && listdevicelist.Count > 0)
            {
                SelectedDevice = listdevicelist[0];
            }

            MenuShowByUser();//3.根据用户权限显示禁用相关菜单
        }

        /// <summary>
        /// 菜单显示与禁用
        /// </summary>
        private void MenuShowByUser()
        {
            LoginUserInfo userinfo = LoginManager.Instance.GetThisUserLoginInfo();
            TolStatuLblUser.Text = userinfo.UserName;
            MenuInitShow();//菜单禁用/启用
        }

        /// <summary>
        /// 页面关闭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainFrm_FormClosing(object sender, FormClosingEventArgs e)
        {
            ConfirmFrm confirm = new ConfirmFrm("提示", "您确定要退出系统？", "确定", "取消", 3);
            if (confirm.ShowDialog() == DialogResult.OK)
            {
                this.Dispose();
            }
            else
            {
                e.Cancel = true;
            }
        }

        #region 2.主界面相关选择和输入控件事件处理
        /// <summary>
        /// 2.2.表单录入类型选择事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void InsertDataMenu1_Click(object sender, EventArgs e)
        {
            if (sender is ToolStripDropDownItem)
            {
                string TypeValue = ((ToolStripDropDownItem)sender).Tag.ToString();
                UIModels.EntryType _etype = UIModels.EntryType.ZDSJGJ;
                switch (TypeValue)
                {
                    case "1":
                        _etype = UIModels.EntryType.ZDSJGJ;
                        break;
                    case "2":
                        _etype = UIModels.EntryType.YS;
                        break;
                    case "3":
                        _etype = UIModels.EntryType.CC;
                        break;
                    case "4":
                        _etype = UIModels.EntryType.XS;
                        break;
                    case "5":
                        _etype = UIModels.EntryType.CK;
                        break;
                    case "6":
                        _etype = UIModels.EntryType.SH;
                        break;
                    case "7":
                        _etype = UIModels.EntryType.BHGPJL;
                        break;
                    case "8":
                        _etype = UIModels.EntryType.BLSJ;
                        break;
                    case "9":
                        _etype = UIModels.EntryType.ZLGZ;
                        break;
                    default:
                        break;
                }

                //显示表单录入界面
                ShowEntryFrom(_etype);
            }
        }

        /// <summary>
        /// 2.3.调用显示表单录入界面方法
        /// </summary>
        /// <param name="_etype"></param>
        private void ShowEntryFrom(UIModels.EntryType _etype)
        {
            EntryForm efrm = new EntryForm(_etype, SelectedDevice);
            efrm.ShowDialog();
        }

        ///// <summary>
        ///// 2.4.是否分组
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //private void checkBox1_CheckedChanged(object sender, EventArgs e)
        //{
        //    this.RecordListView.ShowGroups = this.checkBox1.Checked;
        //    this.RecordListView.BuildList();
        //}
        #endregion


        #region 4.工具设定

        /// <summary>
        ///4.1.数据存储路径
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HeadTolMenu_DBSetting_Click(object sender, EventArgs e)
        {
            DBConfigSetting Dbsetfrm = new DBConfigSetting();
            Dbsetfrm.ShowDialog();
        }
       
        /// <summary>
        /// 4.2.用户管理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HeadTolMenu_User_Click(object sender, EventArgs e)
        {
            UserInfoMGFrm userfrm = new UserInfoMGFrm();
            userfrm.ShowDialog();
        }
        /// <summary>
        /// 4.3.模块管理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HeadTolMenu_Modul_Click(object sender, EventArgs e)
        {
           ModuleMGFrm MDFrm = new ModuleMGFrm();
           MDFrm.ShowDialog();
        }
        /// <summary>
        /// 4.4.修改密码
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TolMenuItem_UpPwd_Click(object sender, EventArgs e)
        {
            PasswordChangeFrm pwdchangefrm = new PasswordChangeFrm();
            pwdchangefrm.ShowDialog();
        }

        /// <summary>
        /// 4.5 数据备份/还原
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TolMenuItem_BackRev_Click(object sender, EventArgs e)
        {
            DataBackRevFrm bakrevfrm = new DataBackRevFrm(false);
            bakrevfrm.ShowDialog();
        }
        #endregion

        #region 5.报表查询

        /// <summary>
        /// 5.1.综合报表查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HeadDataQueryMenu_CPCG_Click(object sender, EventArgs e)
        {
            if (sender is ToolStripDropDownItem)
            {
                string TypeValue = ((ToolStripDropDownItem)sender).Tag.ToString();
                EntryType typevalue = EntryType.ZDSJGJ;
                switch (TypeValue)
                {
                    case "1":
                        typevalue = UIModels.EntryType.ZDSJGJ;
                        break;
                    case "2":
                        typevalue = UIModels.EntryType.YS;
                        break;
                    case "3":
                        typevalue = UIModels.EntryType.CC;
                        break;
                    case "4":
                        typevalue = UIModels.EntryType.XS;
                        break;
                    case "5":
                        typevalue = UIModels.EntryType.CK;
                        break;
                    case "6":
                        typevalue = UIModels.EntryType.SH;
                        break;
                    case "7":
                        typevalue = UIModels.EntryType.BHGPJL;
                        break;
                    case "8":
                        typevalue = UIModels.EntryType.BLSJ;
                        break;
                    case "9":
                        typevalue = UIModels.EntryType.ZLGZ;
                        break;
                    case "10":
                         typevalue = UIModels.EntryType.Inventory;
                        break;
                    default:
                        break;
                }
                DataQueryFrm queryfrm = new DataQueryFrm(typevalue,SelectedDevice);
                queryfrm.WindowState = FormWindowState.Maximized;
                queryfrm.Show();
            }
        }
        #endregion

        #region 6.权限应用/菜单禁用
        /// <summary>
        /// 菜单初始化显示
        /// </summary>
        private void MenuInitShow()
        {
            LoginUserInfo _user = LoginManager.Instance.GetThisUserLoginInfo();//当前登录用户
            //if (!_user.IsAdministrator)
            //{
                #region 菜单禁用
                foreach (ToolStripItem _item in HeadInsertDataMenu.DropDownItems)
                {
                    _item.Enabled = false;
                }
                foreach (ToolStripItem _item in HeadDataQueryMenu.DropDownItems)
                {
                    _item.Enabled = false;
                }
                foreach (ToolStripItem _item in HeadTolMenu.DropDownItems)
                {
                    _item.Enabled = false;
                }
                foreach (ToolStripItem _item in TolMenuData.DropDownItems)
                {
                    _item.Enabled = false;
                }

                btnBuyInsert.Enabled = false;
                btnBuyQuery.Enabled = false;
                btnSellInsert.Enabled = false;
                btnSellQuery.Enabled = false;
                btnInventoryQuery.Enabled = false;
                btnInventoryQueryTotal.Enabled = false;

                #endregion
                KPS.BLL.PermissionManager Pmanager = new BLL.PermissionManager();
                List<KPS.Model.PermissionInfo> Authlist = Pmanager.GetModelList(string.Format("userName='{0}'", _user.LoginName));
                if (Authlist != null && Authlist.Count > 0)
                {
                    foreach (KPS.Model.PermissionInfo _pinfo in Authlist)
                    {
                        MenuEnableTrue(_pinfo);
                    }
                }
            //}
        }

        /// <summary>
        /// 菜单
        /// </summary>
        /// <param name="_Pinfo"></param>
        private void MenuEnableTrue(KPS.Model.PermissionInfo _Pinfo)
        {
            switch (_Pinfo.moduleInfoID)
            { 
                case 1:
                    InsertDataMenu1.Enabled = true;
                    btnBuyInsert.Enabled = true;
                    break;
                case 2:
                    XSDataMenu1.Enabled = true;
                    break;
                case 3:
                    InsertDataMenu2.Enabled = true;
                    break;
                case 4:
                    InsertDataMenu3.Enabled = true;
                    btnSellInsert.Enabled = true;
                    break;
                case 5:
                    InsertDataMenu9.Enabled = true;
                    break;
                case 6:
                    ToolStripMenuItemSH.Enabled = true;
                    break;
                case 7:
                    ToolStripMenuItemBHGPJL.Enabled = true;
                    break;
                case 8:
                    toolStripMenuItem1.Enabled = true;
                    break;
                case 9:
                    toolStripMenuItem2.Enabled = true;
                    break;
                case 10:
                    HeadDataQueryMenu_CPCG.Enabled = true;
                    btnBuyQuery.Enabled =true;
                    break;
                case 11:
                    HeadDataQueryMenu_CPSC.Enabled = true;
                    break;
                case 12:
                    HeadDataQueryMenu_CPTH.Enabled = true;
                    break;
                case 13:
                    HeadDataQueryMenu_CPHH.Enabled = true;
                    btnSellQuery.Enabled = true;
                    break;
                case 14:
                    toolStripMenuItem5.Enabled = true;
                    break;
                case 15:
                    toolStripMenuItem4.Enabled = true;
                    break;
                case 16:
                    toolStripMenuItem6.Enabled = true;
                    break;
                case 17:
                    toolStripMenuItem3.Enabled = true;
                    break;
                case 18:
                    HeadDataQueryMenu_Unqualified.Enabled = true;
                    break;
                case 19:
                    HeadTolMenu_DBSetting.Enabled = true;
                    break;
                case 20:
                    HeadTolMenu_User.Enabled = true;
                    break;
                case 21:
                    HeadTolMenu_Modul.Enabled = true;
                    break; 
                case 22:
                    TolMenuItem_UpPwd.Enabled = true;
                    break;
                case 23:
                    TolMenuData_ProName.Enabled = true;
                    break;
                case 24:
                    TolMenuData_ProUnit.Enabled = true;
                    break;
                case 25:
                    TolMenuData_ProM.Enabled = true;
                    break;
                case 26:
                    TolMenuData_Supper.Enabled = true;
                    break;
                case 27:
                    TolMenuDevice_Class.Enabled = true;
                    break;
                case 28:
                    TolMenuItem_BackRev.Enabled = true;
                    break;
                case 29:
                    HeadDataQueryMenu_Inventory.Enabled = true;
                    btnInventoryQuery.Enabled = true;
                    break;
                case 30:
                    btnInventoryQueryTotal.Enabled = true;
                    break;
                default:
                    break;
            }
        }
        #endregion

        #region 8.基础数据录入
        private void TolMenuData_Click(object sender, EventArgs e)
        {
            if (sender is ToolStripDropDownItem && ((ToolStripDropDownItem)sender).Tag!=null)
            {
                string TypeValue = ((ToolStripDropDownItem)sender).Tag.ToString();
                switch (TypeValue)
                {
                    case "1":
                        ProductManagerFrm pdmanagerfrm = new ProductManagerFrm(false);
                        pdmanagerfrm.ShowDialog();
                        break;
                    case "2":
                        UnitManagerFrm unitmanagerfrm = new UnitManagerFrm(false);
                        unitmanagerfrm.ShowDialog();
                        break;
                    case "3":
                        ManufacturerFrm manufactfrm = new ManufacturerFrm(false);
                        manufactfrm.ShowDialog();
                        break;
                    case "4":
                        SupperManagerFrm spmanagerfrm = new SupperManagerFrm(false);
                        spmanagerfrm.ShowDialog();
                        break;
                    case "5":
                        DeviceTypeManagerFrm devicmanagerfrm = new DeviceTypeManagerFrm(false);
                        devicmanagerfrm.ShowDialog();
                        break;
                    default:
                        break;
                }
            }
        }
        #endregion

        #region 9.帮助菜单
        private void HelpMenu_F1_Click(object sender, EventArgs e)
        {
            string strHelpFile = Path.Combine(System.Windows.Forms.Application.StartupPath, "help.pdf");
            if (File.Exists(strHelpFile))
            {
                try
                {
                    //打开文件
                    System.Diagnostics.Process.Start(strHelpFile);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            else 
            {
                MessageBox.Show("帮助文件不存在！");
            }
        }
        #endregion

        #region 10.按钮样式
        private void button1_MouseEnter(object sender, EventArgs e)
        {
            if (sender is Button)
            {
                Button _thisbutton = (Button)sender;
                _thisbutton.BackgroundImage = KPS.Properties.Resources.button_2;
                _thisbutton.ForeColor = Color.DarkOrange;
                _thisbutton.Refresh();
            }
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            if (sender is Button)
            {
                Button _thisbutton = (Button)sender;
                _thisbutton.BackgroundImage = KPS.Properties.Resources.button_1;
                _thisbutton.ForeColor = Color.Black;
                _thisbutton.Refresh();
            }
        }
        #endregion

        #region 11.主界面快捷按钮事件处理

        /// <summary>
        /// 购进记录添加
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBuyInsert_Click(object sender, EventArgs e)
        {
            ShowEntryFrom(EntryType.ZDSJGJ);
        }

        /// <summary>
        /// 购进记录查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBuyQuery_Click(object sender, EventArgs e)
        {
            DataQueryFrm queryfrm = new DataQueryFrm(EntryType.ZDSJGJ, SelectedDevice);
            queryfrm.WindowState = FormWindowState.Maximized;
            queryfrm.Show();
        }

        /// <summary>
        /// 销售记录增加
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSellInsert_Click(object sender, EventArgs e)
        {
            ShowEntryFrom(EntryType.XS);
        }
        /// <summary>
        /// 销售记录查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSellQuery_Click(object sender, EventArgs e)
        {
            DataQueryFrm queryfrm = new DataQueryFrm(EntryType.XS, SelectedDevice);
            queryfrm.WindowState = FormWindowState.Maximized;
            queryfrm.Show();
        }

        /// <summary>
        /// 库存查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnInventoryQuery_Click(object sender, EventArgs e)
        {
            DataQueryFrm queryfrm = new DataQueryFrm(EntryType.Inventory, SelectedDevice);
            queryfrm.WindowState = FormWindowState.Maximized;
            queryfrm.Show();
        }
        /// <summary>
        /// 销售汇总
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnInventoryQueryTotal_Click(object sender, EventArgs e)
        {
            SellRecordsQueryFrm queryfrm = new SellRecordsQueryFrm(SelectedDevice);
            queryfrm.WindowState = FormWindowState.Maximized;
            queryfrm.Show();
        }
        #endregion

        

    }
}
