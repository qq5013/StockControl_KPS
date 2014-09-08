using System;
using System.Collections.Generic;

using System.Text;
using KPS.Model;
using KPS.UIModels;

namespace KPS.ListFilter
{
    /// <summary>
    /// 质量跟踪 列表筛选
    /// </summary>
    public class ProcessLoggingListFilter : IListFilterManager
    {
        public System.Collections.ICollection FilterList(System.Collections.ICollection _List, ListFilterCondition _conditon)
        {
            List<ProcessLoggingInfo> list = (List<ProcessLoggingInfo>)_List;
            List<ProcessLoggingInfo> returnlist = new List<ProcessLoggingInfo>();
            foreach (ProcessLoggingInfo _item in list)
            {
                if (AddRecordByTime(_item.ProcessDate.Value, _conditon))
                {
                    if (_item.ProcessContentInquired.Contains(_conditon.FilterText))
                    {
                        returnlist.Add(_item);
                        continue;
                    }
                    if (_item.ProcessCustomerUnit.Contains(_conditon.FilterText))
                    {
                        returnlist.Add(_item);
                        continue;
                    }
                    if (_item.ProcessHandlingSuggestion.Contains(_conditon.FilterText))
                    {
                        returnlist.Add(_item);
                        continue;
                    }
                    if (_item.Processlinkman.Contains(_conditon.FilterText))
                    {
                        returnlist.Add(_item);
                        continue;
                    }
                    if (_item.ProcessProductName.Contains(_conditon.FilterText))
                    {
                        returnlist.Add(_item);
                        continue;
                    }
                    if (_item.ProcessPurchasingDate.Value.ToString("yyyy-MM-dd HH:mm:ss").Contains(_conditon.FilterText))
                    {
                        returnlist.Add(_item);
                        continue;
                    }
                    if (_item.ProcessServiceUser.Contains(_conditon.FilterText))
                    {
                        returnlist.Add(_item);
                        continue;
                    }
                    if (_item.ProcessStandard.Contains(_conditon.FilterText))
                    {
                        returnlist.Add(_item);
                        continue;
                    }
                    if (_item.Processtel.Contains(_conditon.FilterText))
                    {
                        returnlist.Add(_item);
                        continue;
                    }
                }
            }
            return returnlist;
        }

        /// <summary>
        /// 判断记录是否符合时间范围
        /// </summary>
        /// <param name="_dtime"></param>
        /// <param name="_conditon"></param>
        private bool AddRecordByTime(DateTime _dtime, ListFilterCondition _conditon)
        {
            bool _IsBolMerg = false;
            if (_dtime >= _conditon.StartTime && _dtime <= _conditon.EndTime)
            {
                _IsBolMerg = true;
            }
            return _IsBolMerg;
        }
    }
}
