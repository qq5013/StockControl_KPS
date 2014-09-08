using System;
using System.Collections.Generic;

using System.Text;
using KPS.Model;

namespace KPS.UIBLL
{
    /// <summary>
    /// 不合格品记录 List 格式化
    /// </summary>
    public class BuHeGePinJiLuInfoListFormatManager:IListViewColumnFormater
    {
        public void Formater(BrightIdeasSoftware.ObjectListView listview, BrightIdeasSoftware.OLVColumn column, bool isSHow)
        {
            if (column.Name == "OrderNumber")
            {
                column.AspectGetter = delegate(object x) { return ((BuHeGePinJiLuInfo)x).ID; };
            }
            else
            {

                switch (column.Name)
                {
                    case "y_cpdm":
                        column.AspectGetter = delegate(object x) { return ((BuHeGePinJiLuInfo)x).y_cpdm; };
                        break;
                    case "y_cpzczh":
                        column.AspectGetter = delegate(object x) { return ((BuHeGePinJiLuInfo)x).y_cpzczh; };
                        break;
                    case "y_date":
                        column.AspectGetter = delegate(object x) { return ((BuHeGePinJiLuInfo)x).y_date.Value.ToString("yyyy-MM-dd HH:mm:ss"); };
                        break;
                    case "y_dw":
                        column.AspectGetter = delegate(object x) { return ((BuHeGePinJiLuInfo)x).y_dw; };
                        break;
                    case "y_fhrqz":
                        column.AspectGetter = delegate(object x) { return ((BuHeGePinJiLuInfo)x).y_fhrqz; };
                        break;
                    case "y_ggxh":
                        column.AspectGetter = delegate(object x) { return ((BuHeGePinJiLuInfo)x).y_ggxh; };
                        break;
                    case "y_ghdw":
                        column.AspectGetter = delegate(object x) { return ((BuHeGePinJiLuInfo)x).y_ghdw; };
                        break;
                    case "y_isHGZ":
                        column.AspectGetter = delegate(object x) { return BuHeGePinJiLuInfoIsHGZ((BuHeGePinJiLuInfo)x); };
                        break;
                    case "y_mjph":
                        column.AspectGetter = delegate(object x) { return ((BuHeGePinJiLuInfo)x).y_mjph; };
                        break;
                    case "y_pm":
                        column.AspectGetter = delegate(object x) { return ((BuHeGePinJiLuInfo)x).y_pm; };
                        break;
                    case "y_sccj":
                        column.AspectGetter = delegate(object x) { return ((BuHeGePinJiLuInfo)x).y_sccj; };
                        break;
                    case "y_scph":
                        column.AspectGetter = delegate(object x) { return ((BuHeGePinJiLuInfo)x).y_scph; };
                        break;
                    case "y_sl":
                        column.AspectGetter = delegate(object x) { return ((BuHeGePinJiLuInfo)x).y_sl; };
                        break;
                    case "y_yxq":
                        column.AspectGetter = delegate(object x) { return ((BuHeGePinJiLuInfo)x).y_yxq; };
                        break;
                    case "y_zgy":
                        column.AspectGetter = delegate(object x) { return ((BuHeGePinJiLuInfo)x).y_zgy; };
                        break;
                    case "y_zlqk":
                        column.AspectGetter = delegate(object x) { return ((BuHeGePinJiLuInfo)x).y_zlqk; };
                        break;
                    default:
                        column.AspectGetter = delegate(object x) { return ""; };
                        break;
                }
            }
        }

        private string BuHeGePinJiLuInfoIsHGZ(BuHeGePinJiLuInfo _bu)
        {
            if (_bu.y_isHGZ)
            {
                return "有";
            }
            return "无";
        }
    }
}
