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
    public partial class CCQueryControl :QueryConditonControl
    {
        public override event DelListArg ListLoadingEvent;
        private DeviceInfo thisdevice = null;
        public CCQueryControl(DeviceInfo _deviceinfo)
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
            string strCSName = txtCSName.Text.Trim();//场所名称
            string strJLRName = txtJLR.Text.Trim();//记录人

            string strWhereCondition = string.Format("(s_date>=#{0}# and s_date<=#{1}#)", strBeginTime, strEndTime);

            if (thisdevice != null && !string.IsNullOrEmpty(thisdevice.DeviceType))
            {
                strWhereCondition = strWhereCondition + string.Format(" and DataType={0}", thisdevice.DeviceID);
            }
            if (!string.IsNullOrEmpty(strCSName))
            {
                strWhereCondition = strWhereCondition + string.Format(" and s_csmc like '%{0}%'", strCSName);
            }
            if (!string.IsNullOrEmpty(strJLRName))
            {
                strWhereCondition = strWhereCondition + string.Format(" and s_jlr like '%{0}%'", strJLRName);
            }
          
            CunChuManager manager = new CunChuManager();
            try
            {
                List<CunChuInfo> listData = manager.GetModelList(strWhereCondition);

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

        private void CCQueryControl_Load(object sender, EventArgs e)
        {
            dateTimePicker1.Value = DateTime.Now.AddMonths(-1);
        }
    }
}
