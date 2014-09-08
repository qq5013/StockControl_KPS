using System;
using System.Collections.Generic;

using System.Text;

namespace KPS.UIBLL
{
    /// <summary>
    /// UI 列表数据获取处理
    /// </summary>
    public class UIListDataManager
    {
        public delegate void DelListDataArg(System.Collections.ICollection _List, bool _State, string _Msg);
        public event DelListDataArg ListDataLoadingEndEvent;

        private UIModels.EntryType ThisType;
        private KPS.Model.DeviceInfo DeviceInfo;
        private System.Threading.Thread _thread = null;
        public void GetListData(UIModels.EntryType _type,KPS.Model.DeviceInfo _device)
        {
            ThisType = _type;
            DeviceInfo = _device;

            _thread = new System.Threading.Thread(new System.Threading.ThreadStart(ThreadStart));
            _thread.IsBackground = true;
            _thread.Start();
        }

          /// <summary>
        /// 开始获取数据
        /// </summary>
        private void ThreadStart()
        {
            switch (ThisType)
            { 
                case UIModels.EntryType.ZDSJGJ:
                    getZDSJGJListData();
                    break;
                case UIModels.EntryType.YS:
                    getYSListData();
                    break;
                case UIModels.EntryType.CC:
                    getCCListData();
                    break;
                case UIModels.EntryType.XS:
                    getXSListData();
                    break;
                case UIModels.EntryType.CK:
                    getCKListData();
                    break;
                case UIModels.EntryType.SH:
                    getSHListData();
                    break;
                case UIModels.EntryType.BHGPJL:
                    getBHGPJLListData();
                    break;
                case UIModels.EntryType.BLSJ:
                    getBLSJListData();
                    break;
                case UIModels.EntryType.ZLGZ:
                    getZLGZListData();
                    break;
            }
        }

        /// <summary>
        /// 1.诊断试剂数据
        /// </summary>
        private void getZDSJGJListData()
        {
            KPS.BLL.GouJinManager manager=new BLL.GouJinManager();
            try
            {
                string strDataTypeObj = string.Format("DataType={0}", DeviceInfo.DeviceID);
                System.Collections.ICollection _List = manager.GetModelList(strDataTypeObj);
                if (ListDataLoadingEndEvent != null)
                {
                    ListDataLoadingEndEvent(_List, true, "获取列表成功");
                }
            }
            catch (Exception ex)
            {
                if (ListDataLoadingEndEvent != null)
                {
                    ListDataLoadingEndEvent(null, false, ex.Message);
                }
            }
        }

        /// <summary>
        /// 2.验收数据
        /// </summary>
        private void getYSListData()
        {
            KPS.BLL.YanShouManager manager = new BLL.YanShouManager();
            try
            {
                string strDataTypeObj = string.Format("DataType={0}", DeviceInfo.DeviceID);
                System.Collections.ICollection _List = manager.GetModelList(strDataTypeObj);
                if (ListDataLoadingEndEvent != null)
                {
                    ListDataLoadingEndEvent(_List, true, "获取列表成功");
                }
            }
            catch (Exception ex)
            {
                if (ListDataLoadingEndEvent != null)
                {
                    ListDataLoadingEndEvent(null, false, ex.Message);
                }
            }
        }

        /// <summary>
        /// 3.存储
        /// </summary>
        private void getCCListData()
        {
            KPS.BLL.CunChuManager manager = new BLL.CunChuManager();
            try
            {
                string strDataTypeObj = string.Format("DataType={0}", DeviceInfo.DeviceID);
                System.Collections.ICollection _List = manager.GetModelList(strDataTypeObj);
                if (ListDataLoadingEndEvent != null)
                {
                    ListDataLoadingEndEvent(_List, true, "获取列表成功");
                }
            }
            catch (Exception ex)
            {
                if (ListDataLoadingEndEvent != null)
                {
                    ListDataLoadingEndEvent(null, false, ex.Message);
                }
            }
        }

        /// <summary>
        /// 4.销售
        /// </summary>
        private void getXSListData()
        {
            KPS.BLL.XiaoShouManager  manager = new BLL.XiaoShouManager();
            try
            {
                string strDataTypeObj = string.Format("DataType={0}", DeviceInfo.DeviceID);
                System.Collections.ICollection _List = manager.GetModelList(strDataTypeObj);
                if (ListDataLoadingEndEvent != null)
                {
                    ListDataLoadingEndEvent(_List, true, "获取列表成功");
                }
            }
            catch (Exception ex)
            {
                if (ListDataLoadingEndEvent != null)
                {
                    ListDataLoadingEndEvent(null, false, ex.Message);
                }
            }
        }

        /// <summary>
        /// 5.出库
        /// </summary>
        private void getCKListData()
        {
            KPS.BLL.ChuKuManager  manager = new BLL.ChuKuManager();
            try
            {
                string strDataTypeObj = string.Format("DataType={0}", DeviceInfo.DeviceID);
                System.Collections.ICollection _List = manager.GetModelList(strDataTypeObj);
                if (ListDataLoadingEndEvent != null)
                {
                    ListDataLoadingEndEvent(_List, true, "获取列表成功");
                }
            }
            catch (Exception ex)
            {
                if (ListDataLoadingEndEvent != null)
                {
                    ListDataLoadingEndEvent(null, false, ex.Message);
                }
            }
        }

        /// <summary>
        /// 6.售后
        /// </summary>
        private void getSHListData()
        {
            KPS.BLL.ShouHouManager  manager = new BLL.ShouHouManager ();
            try
            {
                string strDataTypeObj = string.Format("DataType={0}", DeviceInfo.DeviceID);
                System.Collections.ICollection _List = manager.GetModelList(strDataTypeObj);
                if (ListDataLoadingEndEvent != null)
                {
                    ListDataLoadingEndEvent(_List, true, "获取列表成功");
                }
            }
            catch (Exception ex)
            {
                if (ListDataLoadingEndEvent != null)
                {
                    ListDataLoadingEndEvent(null, false, ex.Message);
                }
            }
        }

        /// <summary>
        /// 7.不合格品记录
        /// </summary>
        private void getBHGPJLListData()
        {
            KPS.BLL.BuHeGePinJiLuManager manager = new BLL.BuHeGePinJiLuManager();
            try
            {
                string strDataTypeObj = string.Format("DataType={0}", DeviceInfo.DeviceID);
                System.Collections.ICollection _List = manager.GetModelList(strDataTypeObj);
                if (ListDataLoadingEndEvent != null)
                {
                    ListDataLoadingEndEvent(_List, true, "获取列表成功");
                }
            }
            catch (Exception ex)
            {
                if (ListDataLoadingEndEvent != null)
                {
                    ListDataLoadingEndEvent(null, false, ex.Message);
                }
            }
        }

        /// <summary>
        /// 8.不良事件
        /// </summary>
        private void getBLSJListData()
        {
            KPS.BLL.BuLiangShiJianManager manager = new BLL.BuLiangShiJianManager();
            try
            {
                string strDataTypeObj = string.Format("DataType={0}", DeviceInfo.DeviceID);
                System.Collections.ICollection _List = manager.GetModelList(strDataTypeObj);
                if (ListDataLoadingEndEvent != null)
                {
                    ListDataLoadingEndEvent(_List, true, "获取列表成功");
                }
            }
            catch (Exception ex)
            {
                if (ListDataLoadingEndEvent != null)
                {
                    ListDataLoadingEndEvent(null, false, ex.Message);
                }
            }
        }
        
        /// <summary>
        /// 质量跟踪
        /// </summary>
        private void getZLGZListData()
        {
            KPS.BLL.ProcessLoggingManager manager = new BLL.ProcessLoggingManager();
            try
            {
                string strDataTypeObj = string.Format("DataType={0}", DeviceInfo.DeviceID);
                System.Collections.ICollection _List = manager.GetModelList(strDataTypeObj);
                if (ListDataLoadingEndEvent != null)
                {
                    ListDataLoadingEndEvent(_List, true, "获取列表成功");
                }
            }
            catch (Exception ex)
            {
                if (ListDataLoadingEndEvent != null)
                {
                    ListDataLoadingEndEvent(null, false, ex.Message);
                }
            }
        }

    }
}
