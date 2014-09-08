using System;
using System.Collections.Generic;

using System.Text;
using KPS.UIModels;

namespace KPS.ListFilter
{
    /// <summary>
    /// 不合格品记录列表筛选
    /// </summary>
    public class BuHeGePinJiluListFilter:IListFilterManager
    {

        public System.Collections.ICollection FilterList(System.Collections.ICollection _List, ListFilterCondition _condition)
        {
            List<KPS.Model.BuHeGePinJiLuInfo> oldlist = (List<KPS.Model.BuHeGePinJiLuInfo>)_List;
            List<KPS.Model.BuHeGePinJiLuInfo> _returnlist = new List<Model.BuHeGePinJiLuInfo>();
            if (oldlist != null && oldlist.Count > 0)
            {
                foreach (KPS.Model.BuHeGePinJiLuInfo _item in oldlist)
                {
                    if (AddRecordByTime(_item.y_date.Value, _condition))
                    {
                        if (_item.y_cpdm.Contains(_condition.FilterText))
                        {
                            _returnlist.Add(_item);
                            continue;
                        }
                        if (_item.y_cpzczh.Contains(_condition.FilterText))
                        {
                            _returnlist.Add(_item);
                            continue;
                        }
                        if (_item.y_dw.Contains(_condition.FilterText))
                        {
                            _returnlist.Add(_item);
                            continue;
                        }
                        if (_item.y_fhrqz.Contains(_condition.FilterText))
                        {
                            _returnlist.Add(_item);
                            continue;
                        }
                        if (_item.y_ggxh.Contains(_condition.FilterText))
                        {
                            _returnlist.Add(_item);
                            continue;
                        }
                        if (_item.y_ghdw.Contains(_condition.FilterText))
                        {
                            _returnlist.Add(_item);
                            continue;
                        }
                        if (_item.y_mjph.Contains(_condition.FilterText))
                        {
                            _returnlist.Add(_item);
                            continue;
                        }
                        if (_item.y_pm.Contains(_condition.FilterText))
                        {
                            _returnlist.Add(_item);
                            continue;
                        }
                        if (_item.y_sccj.Contains(_condition.FilterText))
                        {
                            _returnlist.Add(_item);
                            continue;
                        }
                        if (_item.y_scph.Contains(_condition.FilterText))
                        {
                            _returnlist.Add(_item);
                            continue;
                        }
                        if (_item.y_yxq.Contains(_condition.FilterText))
                        {
                            _returnlist.Add(_item);
                            continue;
                        }
                        if (_item.y_zgy.Contains(_condition.FilterText))
                        {
                            _returnlist.Add(_item);
                            continue;
                        }
                        if (_item.y_zlqk.Contains(_condition.FilterText))
                        {
                            _returnlist.Add(_item);
                            continue;
                        }
                    }
                }
            }

            return _returnlist;
    
        }
        
        /// <summary>
        /// 判断记录是否符合时间范围
        /// </summary>
        /// <param name="_dtime"></param>
        /// <param name="_conditon"></param>
        private bool AddRecordByTime(DateTime _dtime, ListFilterCondition _conditon)
        {
            bool _IsBolMerg = false;
            if(_dtime>=_conditon.StartTime && _dtime<=_conditon.EndTime)
            {
                _IsBolMerg = true;
            }
            return _IsBolMerg;
        }
    }
}
