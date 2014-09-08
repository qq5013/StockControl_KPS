using System;
using System.Collections.Generic;

using System.Text;
using KPS.UIModels;

namespace KPS.ListFilter
{
    public interface IListFilterManager
    {
        /// <summary>
        /// 筛选列表
        /// </summary>
        /// <param name="_List"></param>
        /// <param name="_FilterTxt"></param>
        System.Collections.ICollection FilterList(System.Collections.ICollection _List, ListFilterCondition _condition);
    }
}
