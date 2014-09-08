using System;
using System.Collections.Generic;

using System.Text;
using KPS.Model;
using KPS.UIModels;

namespace KPS.ListFilter
{
    /// <summary>
    /// 验收 列表筛选
    /// </summary>
    public class YanShouListFilter : IListFilterManager
    {
        public System.Collections.ICollection FilterList(System.Collections.ICollection _List, ListFilterCondition _conditon)
        {
            List<YanShouInfo> list = (List<YanShouInfo>)_List;
            List<YanShouInfo> returnlist = new List<YanShouInfo>();
            foreach (YanShouInfo _item in list)
            {
                if (AddRecordByTime(_item.y_date.Value, _conditon))
                {
                    if (_item.y_cpdm.Contains(_conditon.FilterText))
                    {
                        returnlist.Add(_item);
                        continue;
                    }
                    if (_item.y_cpzczh.Contains(_conditon.FilterText))
                    {
                        returnlist.Add(_item);
                        continue;
                    }
                    if (_item.y_dw.Contains(_conditon.FilterText))
                    {
                        returnlist.Add(_item);
                        continue;
                    }
                    if (_item.y_fhrqz.Contains(_conditon.FilterText))
                    {
                        returnlist.Add(_item);
                        continue;
                    }
                    if (_item.y_ggxh.Contains(_conditon.FilterText))
                    {
                        returnlist.Add(_item);
                        continue;
                    }
                    if (_item.y_ghdw.Contains(_conditon.FilterText))
                    {
                        returnlist.Add(_item);
                        continue;
                    }
                    if (_item.y_mjph.Contains(_conditon.FilterText))
                    {
                        returnlist.Add(_item);
                        continue;
                    }
                    if (_item.y_pm.Contains(_conditon.FilterText))
                    {
                        returnlist.Add(_item);
                        continue;
                    }
                    if (_item.y_sccj.Contains(_conditon.FilterText))
                    {
                        returnlist.Add(_item);
                        continue;
                    }
                    if (_item.y_scph.Contains(_conditon.FilterText))
                    {
                        returnlist.Add(_item);
                        continue;
                    }
                    if (_item.y_yxq.Contains(_conditon.FilterText))
                    {
                        returnlist.Add(_item);
                        continue;
                    }
                    if (_item.y_zgy.Contains(_conditon.FilterText))
                    {
                        returnlist.Add(_item);
                        continue;
                    }
                    if (_item.y_zlqk.Contains(_conditon.FilterText))
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
