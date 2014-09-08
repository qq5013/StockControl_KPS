using System;
using System.Collections.Generic;
using System.Text;

namespace KPS.Model
{
    /// <summary>
    /// 仪器器械类型
    /// </summary>
    public class DeviceInfo
    {
        public DeviceInfo()
        { 
        
        }
        public DeviceInfo(int _id,string _devicetype)
        {
            _DeviceID = _id;
            _DeviceType = _devicetype;
        }

        private int _DeviceID;
        /// <summary>
        /// 类型编号
        /// </summary>
        public int DeviceID
        {
            get { return _DeviceID; }
            set { _DeviceID = value; }
        }
        private string _DeviceType;
        /// <summary>
        /// 类型名称
        /// </summary>
        public string DeviceType
        {
            get { return _DeviceType; }
            set { _DeviceType = value; }
        }
    }
}
