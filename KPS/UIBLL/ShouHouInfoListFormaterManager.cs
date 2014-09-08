using System;
using System.Collections.Generic;

using System.Text;
using KPS.Model;

namespace KPS.UIBLL
{
    /// <summary>
    /// 售后 List 格式化
    /// </summary>
    public class ShouHouInfoListFormaterManager:IListViewColumnFormater
    {
        public void Formater(BrightIdeasSoftware.ObjectListView listview, BrightIdeasSoftware.OLVColumn column, bool isSHow)
        {
            if (column.Name == "OrderNumber")
            {
                column.AspectGetter = delegate(object x) { return ((ShouHouInfo)x).ID; };
            }
            else
            {

                switch (column.Name)
                {
                    case "y_cpdm":
                        column.AspectGetter = delegate(object x) { return ((ShouHouInfo)x).y_cpdm; };
                        break;
                    case "y_cpzczh":
                        column.AspectGetter = delegate(object x) { return ((ShouHouInfo)x).y_cpzczh; };
                        break;
                    case "y_date":
                        column.AspectGetter = delegate(object x) { return ((ShouHouInfo)x).y_date.Value.ToString("yyyy-MM-dd HH:mm:ss"); };
                        break;
                    case "y_dw":
                        column.AspectGetter = delegate(object x) { return ((ShouHouInfo)x).y_dw; };
                        break;
                    case "y_fhrqz":
                        column.AspectGetter = delegate(object x) { return ((ShouHouInfo)x).y_fhrqz; };
                        break;
                    case "y_ggxh":
                        column.AspectGetter = delegate(object x) { return ((ShouHouInfo)x).y_ggxh; };
                        break;
                    case "y_ghdw":
                        column.AspectGetter = delegate(object x) { return ((ShouHouInfo)x).y_ghdw; };
                        break;
                    case "y_isHGZ":
                        column.AspectGetter = delegate(object x) { return BoolStateIsHGZ(((ShouHouInfo)x).y_isHGZ); };
                        break;
                    case "y_mjph":
                        column.AspectGetter = delegate(object x) { return ((ShouHouInfo)x).y_mjph; };
                        break;
                    case "y_pm":
                        column.AspectGetter = delegate(object x) { return ((ShouHouInfo)x).y_pm; };
                        break;
                    case "y_sccj":
                        column.AspectGetter = delegate(object x) { return ((ShouHouInfo)x).y_sccj; };
                        break;
                    case "y_scph":
                        column.AspectGetter = delegate(object x) { return ((ShouHouInfo)x).y_scph; };
                        break;
                    case "y_sl":
                        column.AspectGetter = delegate(object x) { return ((ShouHouInfo)x).y_sl; };
                        break;
                    case "y_yxq":
                        column.AspectGetter = delegate(object x) { return ((ShouHouInfo)x).y_yxq; };
                        break;
                    case "y_zgy":
                        column.AspectGetter = delegate(object x) { return ((ShouHouInfo)x).y_zgy; };
                        break;
                    case "y_zlqk":
                        column.AspectGetter = delegate(object x) { return ((ShouHouInfo)x).y_zlqk; };
                        break;
                    case "y_managertype":
                        column.AspectGetter = delegate(object x) { return BoolManagerType(((ShouHouInfo)x).y_managertype); };
                        break;
                    default:
                        column.AspectGetter = delegate(object x) { return ""; };
                        break;
                }
            }
        }

        private string BoolStateIsHGZ(bool _bolvalue)
        {
            if (_bolvalue)
            {
                return "有";
            }
            return "无";
        }

        private string BoolManagerType(bool _bolvalue)
        {
            if (_bolvalue)
            {
                return "退货";
            }
            return "换货";
        }
    }
}
