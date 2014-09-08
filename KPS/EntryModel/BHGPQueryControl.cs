using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;

using System.Text;
using System.Windows.Forms;
using KPS.Model;
using KPS.BLL;
using KPS.UIModels;

namespace KPS.EntryModel
{
    public partial class BHGPQueryControl :QueryConditonControl
    {
        public override event DelListArg ListLoadingEvent;
        private DeviceInfo thisdevice = null;
        public BHGPQueryControl(DeviceInfo _deviceinfo)
        {
            thisdevice = _deviceinfo;
            InitializeComponent();
        }

        private UIModels.EntryType _ThisTypevalue;
        /// <summary>
        /// 初始化类型
        /// </summary>
        /// <param name="_EntryType"></param>
        public override void InitType(UIModels.EntryType _EntryType)
        {
            _ThisTypevalue = _EntryType;
        }
        /// <summary>
        /// 更改医疗器械类型
        /// </summary>
        /// <param name="_Device"></param>
        public override void ChangeDeviceType(KPS.Model.DeviceInfo _Device)
        {
            thisdevice = _Device;

            button1_Click(null, null);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string strBeginTime = dateTimePicker1.Value.ToString("yyyy-MM-dd 00:00:00");
            string strEndTime = dateTimePicker2.Value.ToString("yyyy-MM-dd 23:59:59");
            string strProductName = txtProductName.Text.Trim();//去除空格,产品名称
            string strGYSName = txtGYS.Text.Trim();//去除空格，供应商
            string strSCSName = txtSCS.Text.Trim();//去除空格，生产/制造商

            string strWhereCondition = string.Format("(y_date>=#{0}# and y_date<=#{1}#)", strBeginTime, strEndTime);

            if (thisdevice != null && !string.IsNullOrEmpty(thisdevice.DeviceType))
            {
                strWhereCondition = strWhereCondition + string.Format(" and DataType={0}", thisdevice.DeviceID);
            }
            if (!string.IsNullOrEmpty(strSCSName))
            {
                strWhereCondition = strWhereCondition + string.Format(" and y_sccj like '%{0}%'", strSCSName);
            }
            if (!string.IsNullOrEmpty(strGYSName))
            {
                strWhereCondition = strWhereCondition + string.Format(" and y_ghdw like '%{0}%'", strGYSName);
            }
            if (!string.IsNullOrEmpty(strProductName))
            {
                strWhereCondition = strWhereCondition + string.Format(" and y_pm like '%{0}%'", strProductName);
            }

            BuHeGePinJiLuManager manager = new BuHeGePinJiLuManager();
            try
            {
                List<BuHeGePinJiLuInfo> listData = manager.GetModelList(strWhereCondition);

                if (ListLoadingEvent != null)
                {
                    ListLoadingEvent(listData, true, "获取记录列表成功！");
                }
            }
            catch (Exception ex)
            {
                if (ListLoadingEvent != null)
                {
                    ListLoadingEvent(null,false,ex.Message);
                }
            }
 
        }

        private void BHGPQueryControl_Load(object sender, EventArgs e)
        {
            dateTimePicker1.Value = DateTime.Now.AddMonths(-1);
        }
    }
}
