using System;
using System.Collections.Generic;

using System.Text;
using KPS.Model;
using KPS.UIModels;

namespace KPS.ListFilter
{
    /// <summary>
    /// 存储 列表筛选
    /// </summary>
    public class CunChuListFilter : IListFilterManager
    {
        public System.Collections.ICollection FilterList(System.Collections.ICollection _List, ListFilterCondition _conditon)
        {
            List<CunChuInfo> list = (List<CunChuInfo>)_List;
            List<CunChuInfo> returnlist = new List<CunChuInfo>();
            foreach (CunChuInfo _item in list)
            {
                if (AddRecordByTime(_item.s_date.Value, _conditon))
                {
                    if (_item.s_cqcs.Contains(_conditon.FilterText))
                    {
                        returnlist.Add(_item);
                        continue;
                    }
                    if (_item.s_csmc.Contains(_conditon.FilterText))
                    {
                        returnlist.Add(_item);
                        continue;
                    }
                    if (_item.s_jlr.Contains(_conditon.FilterText))
                    {
                        returnlist.Add(_item);
                        continue;
                    }
                    if (_item.s_sd.Contains(_conditon.FilterText))
                    {
                        returnlist.Add(_item);
                        continue;
                    }
                    if (_item.s_sded.Contains(_conditon.FilterText))
                    {
                        returnlist.Add(_item);
                        continue;
                    }
                    if (_item.s_sywdfw.Contains(_conditon.FilterText))
                    {
                        returnlist.Add(_item);
                        continue;
                    }
                    if (_item.s_syxdsdfw.Contains(_conditon.FilterText))
                    {
                        returnlist.Add(_item);
                        continue;
                    }
                    if (_item.s_wd.Contains(_conditon.FilterText))
                    {
                        returnlist.Add(_item);
                        continue;
                    }
                    if (_item.s_wded.Contains(_conditon.FilterText))
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
