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
    public partial class ZLGZQueryControl :QueryConditonControl
    {
        public override event DelListArg ListLoadingEvent;
        private DeviceInfo thisdevice = null;
        public ZLGZQueryControl(DeviceInfo _deviceinfo)
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
            string strUserUnit = txtUserUnit.Text.Trim();//用户单位
            string strServiceName = txtServiceName.Text.Trim();//服务人员

            string strWhereCondition = string.Format("(ProcessDate>=#{0}# and ProcessDate<=#{1}#)", strBeginTime, strEndTime);

            if (thisdevice != null && !string.IsNullOrEmpty(thisdevice.DeviceType))
            {
                strWhereCondition = strWhereCondition + string.Format(" and DataType={0}", thisdevice.DeviceID);
            }
            if (!string.IsNullOrEmpty(strServiceName))
            {
                strWhereCondition = strWhereCondition + string.Format(" and ProcessServiceUser like '%{0}%'", strServiceName);
            }
            if (!string.IsNullOrEmpty(strUserUnit))
            {
                strWhereCondition = strWhereCondition + string.Format(" and ProcessCustomerUnit like '%{0}%'", strUserUnit);
            }
            if (!string.IsNullOrEmpty(strProductName))
            {
                strWhereCondition = strWhereCondition + string.Format(" and ProcessProductName like '%{0}%'", strProductName);
            }

            ProcessLoggingManager manager = new ProcessLoggingManager();
            try
            {
                List<ProcessLoggingInfo> listData = manager.GetModelList(strWhereCondition);

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

        private void ZLGZQueryControl_Load(object sender, EventArgs e)
        {
            dateTimePicker1.Value = DateTime.Now.AddMonths(-1);
        }
    }
}
