using System;
using System.Collections.Generic;

using System.Text;
using KPS.Model;
using KPS.UIModels;

namespace KPS.ListFilter
{
    /// <summary>
    /// 出库列表筛选
    /// </summary>
    public class ChuKuListFilter : IListFilterManager
    {
        public System.Collections.ICollection FilterList(System.Collections.ICollection _List, ListFilterCondition _Condition)
        {
            List<ChuKuInfo> list = (List<ChuKuInfo>)_List;
            List<ChuKuInfo> returnlist = new List<ChuKuInfo>();
            foreach (ChuKuInfo _item in list)
            {
                if (AddRecordByTime(_item.y_date.Value, _Condition))
                {
                    if (_item.y_cpdm.Contains(_Condition.FilterText))
                    {
                        returnlist.Add(_item);
                        continue;
                    }
                    if (_item.y_cpzczh.Contains(_Condition.FilterText))
                    {
                        returnlist.Add(_item);
                        continue;
                    }
                    if (_item.y_dw.Contains(_Condition.FilterText))
                    {
                        returnlist.Add(_item);
                        continue;
                    }
                    if (_item.y_fhrqz.Contains(_Condition.FilterText))
                    {
                        returnlist.Add(_item);
                        continue;
                    }
                    if (_item.y_ggxh.Contains(_Condition.FilterText))
                    {
                        returnlist.Add(_item);
                        continue;
                    }
                    if (_item.y_ghdw.Contains(_Condition.FilterText))
                    {
                        returnlist.Add(_item);
                        continue;
                    }
                    if (_item.y_mjph.Contains(_Condition.FilterText))
                    {
                        returnlist.Add(_item);
                        continue;
                    }
                    if (_item.y_pm.Contains(_Condition.FilterText))
                    {
                        returnlist.Add(_item);
                        continue;
                    }
                    if (_item.y_sccj.Contains(_Condition.FilterText))
                    {
                        returnlist.Add(_item);
                        continue;
                    }
                    if (_item.y_scph.Contains(_Condition.FilterText))
                    {
                        returnlist.Add(_item);
                        continue;
                    }
                    if (_item.y_yxq.Contains(_Condition.FilterText))
                    {
                        returnlist.Add(_item);
                        continue;
                    }
                    if (_item.y_zgy.Contains(_Condition.FilterText))
                    {
                        returnlist.Add(_item);
                        continue;
                    }
                    if (_item.y_zlqk.Contains(_Condition.FilterText))
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
