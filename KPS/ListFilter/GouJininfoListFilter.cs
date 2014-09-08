using System;
using System.Collections.Generic;

using System.Text;
using KPS.Model;
using KPS.UIModels;

namespace KPS.ListFilter
{
    /// <summary>
    /// 诊断试剂购进筛选
    /// </summary>
    public class GouJininfoListFilter:IListFilterManager
    {
        public System.Collections.ICollection FilterList(System.Collections.ICollection _List, ListFilterCondition _conditon)
        {
            List<GouJinInfo> list = (List<GouJinInfo>)_List;
            List<GouJinInfo> returnlist=new List<GouJinInfo>();
            foreach (GouJinInfo _gjinfo in list)
            {
                if (AddRecordByTime(_gjinfo.p_date.Value, _conditon))
                {
                    if (_gjinfo.p_clmc.Contains(_conditon.FilterText))
                    {
                        returnlist.Add(_gjinfo);
                        continue;
                    }
                    if (_gjinfo.p_cpmc.Contains(_conditon.FilterText))
                    {
                        returnlist.Add(_gjinfo);
                        continue;
                    }
                    if (_gjinfo.p_date.Value.ToString("yyyy-MM-dd HH:mm:ss").Contains(_conditon.FilterText))
                    {
                        returnlist.Add(_gjinfo);
                        continue;
                    }
                    if (_gjinfo.p_dw.Contains(_conditon.FilterText))
                    {
                        returnlist.Add(_gjinfo);
                        continue;
                    }
                    if (_gjinfo.p_ggxh.Contains(_conditon.FilterText))
                    {
                        returnlist.Add(_gjinfo);
                        continue;
                    }
                    if (_gjinfo.p_gys.Contains(_conditon.FilterText))
                    {
                        returnlist.Add(_gjinfo);
                        continue;
                    }
                    if (_gjinfo.p_jsr.Contains(_conditon.FilterText))
                    {
                        returnlist.Add(_gjinfo);
                        continue;
                    }
                    if (_gjinfo.p_mjph.Contains(_conditon.FilterText))
                    {
                        returnlist.Add(_gjinfo);
                        continue;
                    }
                    if (_gjinfo.p_ph.Contains(_conditon.FilterText))
                    {
                        returnlist.Add(_gjinfo);
                        continue;
                    }
                    if (_gjinfo.p_zczh.Contains(_conditon.FilterText))
                    {
                        returnlist.Add(_gjinfo);
                        continue;
                    }
                    if (_gjinfo.p_zzs.Contains(_conditon.FilterText))
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
