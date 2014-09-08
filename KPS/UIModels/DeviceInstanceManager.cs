using System;
using System.Collections.Generic;
using System.Text;

namespace KPS.UIModels
{
    /// <summary>
    /// 医疗仪器分类
    /// </summary>
    public class DeviceCacheInstanceManager
    {
        private static DeviceCacheInstanceManager manager = new DeviceCacheInstanceManager();
        private List<KPS.Model.DeviceInfo> _DeviceList;
        /// <summary>
        /// 医疗仪器分类处理实例，单例
        /// </summary>
        public static DeviceCacheInstanceManager Instance
        {
            get
            {
                return manager;
            }
        }

        /// <summary>
        /// 更新医疗仪器分类缓存
        /// </summary>
        public void UpdateDeviceCache()
        {
            KPS.BLL.DeviceInfoManager dmanager = new BLL.DeviceInfoManager();
            _DeviceList = dmanager.GetModelList("");
        }
        /// <summary>
        /// 医疗仪器分类列表获取
        /// </summary>
        public List<KPS.Model.DeviceInfo> DeviceList
        {
            get
            {
                if (_DeviceList == null) 
                {
                    UpdateDeviceCache();
                }
                return _DeviceList;
            }
        }
    }
}
