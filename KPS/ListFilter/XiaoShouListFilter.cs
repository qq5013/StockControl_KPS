using System;
using System.Collections.Generic;

using System.Text;
using KPS.Model;
using KPS.UIModels;

namespace KPS.ListFilter
{
    /// <summary>
    /// 销售 列表筛选
    /// </summary>
    public class XiaoShouListFilter : IListFilterManager
    {
        public System.Collections.ICollection FilterList(System.Collections.ICollection _List, ListFilterCondition _conditon)
        {
            List<XiaoShouInfo> list = (List<XiaoShouInfo>)_List;
            List<XiaoShouInfo> returnlist = new List<XiaoShouInfo>();
            foreach (XiaoShouInfo _item in list)
            {
                if (AddRecordByTime(_item.p_date.Value, _conditon))
                {
                    if (_item.p_clmc.Contains(_conditon.FilterText))
                    {
                        returnlist.Add(_item);
                        continue;
                    }
                    if (_item.p_cpmc.Contains(_conditon.FilterText))
                    {
                        returnlist.Add(_item);
                        continue;
                    }
                    if (_item.p_dw.Contains(_conditon.FilterText))
                    {
                        returnlist.Add(_item);
                        continue;
                    }
                    if (_item.p_ggxh.Contains(_conditon.FilterText))
                    {
                        returnlist.Add(_item);
                        continue;
                    }
                    if (_item.p_gys.Contains(_conditon.FilterText))
                    {
                        returnlist.Add(_item);
                        continue;
                    }
                    if (_item.p_jsr.Contains(_conditon.FilterText))
                    {
                        returnlist.Add(_item);
                        continue;
                    }
                    if (_item.p_mjph.Contains(_conditon.FilterText))
                    {
                        returnlist.Add(_item);
                        continue;
                    }
                    if (_item.p_ph.Contains(_conditon.FilterText))
                    {
                        returnlist.Add(_item);
                        continue;
                    }
                    if (_item.p_zczh.Contains(_conditon.FilterText))
                    {
                        returnlist.Add(_item);
                        continue;
                    }
                    if (_item.p_zzs.Contains(_conditon.FilterText))
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
