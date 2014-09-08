using System;
using System.Collections.Generic;

using System.Text;
using KPS.Model;

namespace KPS.UIBLL
{
    /// <summary>
    /// 不良事件 List 格式化
    /// </summary>
    public class BuLiangShiJianInfoListFormatManager:IListViewColumnFormater
    {
        public void Formater(BrightIdeasSoftware.ObjectListView listview, BrightIdeasSoftware.OLVColumn column, bool isSHow)
        {
            if (column.Name == "OrderNumber")
            {
                column.AspectGetter = delegate(object x) { return ((BuLiangShiJianInfo)x).ID; };
            }
            else
            {

                switch (column.Name)
                {
                    case "b_bgr":
                        column.AspectGetter = delegate(object x) { return ((BuLiangShiJianInfo)x).b_bgr; };
                        break;
                    case "b_bgsj":
                        column.AspectGetter = delegate(object x) { return ((BuLiangShiJianInfo)x).b_bgsj; };
                        break;
                    case "b_cpdm":
                        column.AspectGetter = delegate(object x) { return ((BuLiangShiJianInfo)x).b_cpdm; };
                        break;
                    case "b_fzr":
                        column.AspectGetter = delegate(object x) { return ((BuLiangShiJianInfo)x).b_fzr; };
                        break;
                    case "b_fzrqz":
                        column.AspectGetter = delegate(object x) { return ((BuLiangShiJianInfo)x).b_fzrqz; };
                        break;
                    case "b_fzrqzsj":
                        column.AspectGetter = delegate(object x) { return ((BuLiangShiJianInfo)x).b_fzrqzsj; };
                        break;
                    case "b_ggxh":
                        column.AspectGetter = delegate(object x) { return ((BuLiangShiJianInfo)x).b_ggxh; };
                        break;
                    case "b_qyzgfzryj":
                        column.AspectGetter = delegate(object x) { return ((BuLiangShiJianInfo)x).b_qyzgfzryj; };
                        break;
                    case "b_resj":
                        column.AspectGetter = delegate(object x) { return ((BuLiangShiJianInfo)x).b_resj; };
                        break;
                    case "b_sccj":
                        column.AspectGetter = delegate(object x) { return ((BuLiangShiJianInfo)x).b_sccj; };
                        break;
                    case "b_scrq":
                        column.AspectGetter = delegate(object x) { return ((BuLiangShiJianInfo)x).b_scrq; };
                        break;
                    case "b_sl":
                        column.AspectGetter = delegate(object x) { return ((BuLiangShiJianInfo)x).b_sl; };
                        break;
                    case "b_sydw":
                        column.AspectGetter = delegate(object x) { return ((BuLiangShiJianInfo)x).b_sydw; };
                        break;
                    case "b_sydwyj":
                        column.AspectGetter = delegate(object x) { return ((BuLiangShiJianInfo)x).b_sydwyj; };
                        break;
                    case "b_ylqxmc":
                        column.AspectGetter = delegate(object x) { return ((BuLiangShiJianInfo)x).b_ylqxmc; };
                        break;
                    case "b_zgclqk":
                        column.AspectGetter = delegate(object x) { return ((BuLiangShiJianInfo)x).b_zgclqk; };
                        break;
                    case "b_zgjbr":
                        column.AspectGetter = delegate(object x) { return ((BuLiangShiJianInfo)x).b_zgjbr; };
                        break;
                    case "b_zgjbsj":
                        column.AspectGetter = delegate(object x) { return ((BuLiangShiJianInfo)x).b_zgjbsj.Value.ToString("yyyy-MM-dd HH:mm:ss"); };
                        break;
                    case "b_zlsgqk":
                        column.AspectGetter = delegate(object x) { return ((BuLiangShiJianInfo)x).b_zlsgqk; };
                        break;
                    default:
                        column.AspectGetter = delegate(object x) { return ""; };
                        break;
                }
            }
        }
    }
}
