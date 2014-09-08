using System;
using System.Collections.Generic;

using System.Text;
using KPS.Model;
using KPS.UIModels;

namespace KPS.ListFilter
{
    /// <summary>
    /// 不良事件列表筛选
    /// </summary>
    public class BuLiangShiJianListFilter : IListFilterManager
    {
        public System.Collections.ICollection FilterList(System.Collections.ICollection _List, ListFilterCondition _conditon)
        {
            List<BuLiangShiJianInfo> list = (List<BuLiangShiJianInfo>)_List;
            List<BuLiangShiJianInfo> returnlist = new List<BuLiangShiJianInfo>();
            foreach (BuLiangShiJianInfo _gjinfo in list)
            {
                if (AddRecordByTime(_gjinfo.b_bgsj.Value, _conditon))
                {
                    if (_gjinfo.b_bgr.Contains(_conditon.FilterText))
                    {
                        returnlist.Add(_gjinfo);
                        continue;
                    }
                    if (_gjinfo.b_cpdm.Contains(_conditon.FilterText))
                    {
                        returnlist.Add(_gjinfo);
                        continue;
                    }
                    if (_gjinfo.b_fzr.Contains(_conditon.FilterText))
                    {
                        returnlist.Add(_gjinfo);
                        continue;
                    }
                    if (_gjinfo.b_fzrqz.Contains(_conditon.FilterText))
                    {
                        returnlist.Add(_gjinfo);
                        continue;
                    }
                    if (_gjinfo.b_ggxh.Contains(_conditon.FilterText))
                    {
                        returnlist.Add(_gjinfo);
                        continue;
                    }
                    if (_gjinfo.b_qyzgfzryj.Contains(_conditon.FilterText))
                    {
                        returnlist.Add(_gjinfo);
                        continue;
                    }
                    if (_gjinfo.b_sccj.Contains(_conditon.FilterText))
                    {
                        returnlist.Add(_gjinfo);
                        continue;
                    }
                    if (_gjinfo.b_scrq.Contains(_conditon.FilterText))
                    {
                        returnlist.Add(_gjinfo);
                        continue;
                    }
                    if (_gjinfo.b_sydw.Contains(_conditon.FilterText))
                    {
                        returnlist.Add(_gjinfo);
                        continue;
                    }
                    if (_gjinfo.b_sydwyj.Contains(_conditon.FilterText))
                    {
                        returnlist.Add(_gjinfo);
                        continue;
                    }
                    if (_gjinfo.b_ylqxmc.Contains(_conditon.FilterText))
                    {
                        returnlist.Add(_gjinfo);
                        continue;
                    }
                    if (_gjinfo.b_zgclqk.Contains(_conditon.FilterText))
                    {
                        returnlist.Add(_gjinfo);
                        continue;
                    }
                    if (_gjinfo.b_zgjbr.Contains(_conditon.FilterText))
                    {
                        returnlist.Add(_gjinfo);
                        continue;
                    }
                    if (_gjinfo.b_zlsgqk.Contains(_conditon.FilterText))
                    {
                        returnlist.Add(_gjinfo);
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
