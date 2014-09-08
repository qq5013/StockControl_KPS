using System;
using System.Collections.Generic;

using System.Text;
using KPS.Model;

namespace KPS.UIBLL
{
    /// <summary>
    /// 存储 List 格式化
    /// </summary>
    public class CunChuInfoListFormatManager:IListViewColumnFormater
    {
        public void Formater(BrightIdeasSoftware.ObjectListView listview, BrightIdeasSoftware.OLVColumn column, bool isSHow)
        {
            if (column.Name == "OrderNumber")
            {
                column.AspectGetter = delegate(object x) { return ((CunChuInfo)x).ID; };
            }
            else
            {

                switch (column.Name)
                {
                    case "s_cqcs":
                        column.AspectGetter = delegate(object x) { return ((CunChuInfo)x).s_cqcs; };
                        break;
                    case "s_csmc":
                        column.AspectGetter = delegate(object x) { return ((CunChuInfo)x).s_csmc; };
                        break;
                    case "s_date":
                        column.AspectGetter = delegate(object x) { return ((CunChuInfo)x).s_date.Value.ToString("yyyy-MM-dd HH:mm:ss"); };
                        break;
                    case "s_jlr":
                        column.AspectGetter = delegate(object x) { return ((CunChuInfo)x).s_jlr; };
                        break;
                    case "s_sd":
                        column.AspectGetter = delegate(object x) { return ((CunChuInfo)x).s_sd; };
                        break;
                    case "s_sded":
                        column.AspectGetter = delegate(object x) { return ((CunChuInfo)x).s_sded; };
                        break;
                    case "s_sworxw":
                        column.AspectGetter = delegate(object x) { return GetTimeStrByState((int)((CunChuInfo)x).s_sworxw); };
                        break;
                    case "s_sywdfw":
                        column.AspectGetter = delegate(object x) { return ((CunChuInfo)x).s_sywdfw;};
                        break;
                    case "s_syxdsdfw":
                        column.AspectGetter = delegate(object x) { return ((CunChuInfo)x).s_syxdsdfw; };
                        break;
                    case "s_wd":
                        column.AspectGetter = delegate(object x) { return ((CunChuInfo)x).s_wd; };
                        break;
                    case "s_wded":
                        column.AspectGetter = delegate(object x) { return ((CunChuInfo)x).s_wded; };
                        break;
                    default:
                        column.AspectGetter = delegate(object x) { return ""; };
                        break;
                }
            }
        }

        private string GetTimeStrByState(int _intValue)
        {
            if (_intValue == 0)
            {
                return "上午";
            }
            return "下午";
        }
    }
}
