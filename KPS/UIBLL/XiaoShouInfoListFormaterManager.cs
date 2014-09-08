using System;
using System.Collections.Generic;

using System.Text;
using KPS.Model;

namespace KPS.UIBLL
{
    /// <summary>
    /// 销售 List 格式化
    /// </summary>
    public class XiaoShouInfoListFormaterManager:IListViewColumnFormater
    {
        public void Formater(BrightIdeasSoftware.ObjectListView listview, BrightIdeasSoftware.OLVColumn column, bool isSHow)
        {
            if (column.Name == "OrderNumber")
            {
                column.AspectGetter = delegate(object x) { return ((XiaoShouInfo)x).ID; };
            }
            else
            {

                switch (column.Name)
                {
                    case "p_clmc":
                        column.AspectGetter = delegate(object x) { return ((XiaoShouInfo)x).p_clmc; };
                        break;
                    case "p_cpmc":
                        column.AspectGetter = delegate(object x) { return ((XiaoShouInfo)x).p_cpmc; };
                        break;
                    case "p_date":
                        column.AspectGetter = delegate(object x) { return ((XiaoShouInfo)x).p_date.Value.ToString("yyyy-MM-dd HH:mm:ss"); };
                        break;
                    case "p_dw":
                        column.AspectGetter = delegate(object x) { return ((XiaoShouInfo)x).p_dw; };
                        break;
                    case "p_ggxh":
                        column.AspectGetter = delegate(object x) { return ((XiaoShouInfo)x).p_ggxh; };
                        break;
                    case "p_gys":
                        column.AspectGetter = delegate(object x) { return ((XiaoShouInfo)x).p_gys; };
                        break;
                    case "p_jsr":
                        column.AspectGetter = delegate(object x) { return ((XiaoShouInfo)x).p_jsr; };
                        break;
                    case "p_mjph":
                        column.AspectGetter = delegate(object x) { return ((XiaoShouInfo)x).p_mjph; };
                        break;
                    case "p_ph":
                        column.AspectGetter = delegate(object x) { return ((XiaoShouInfo)x).p_ph; };
                        break;
                    case "p_sl1":
                        column.AspectGetter = delegate(object x) { return ((XiaoShouInfo)x).p_sl1; };
                        break;
                    case "p_sl2":
                        column.AspectGetter = delegate(object x) { return FormatDoubleBalue(((XiaoShouInfo)x).p_sl2); };
                        break;
                    case "p_zczh":
                        column.AspectGetter = delegate(object x) { return ((XiaoShouInfo)x).p_zczh; };
                        break;
                    case "p_zzs":
                        column.AspectGetter = delegate(object x) { return ((XiaoShouInfo)x).p_zzs; };
                        break;
                    case "RemarkInfo":
                        column.AspectGetter = delegate(object x) { return ((XiaoShouInfo)x).RemarkInfo; };
                        break;
                    case "ToltalMoney":
                        column.AspectGetter = delegate(object x) { return TotalMoney((XiaoShouInfo)x); };
                        break;
                    default:
                        column.AspectGetter = delegate(object x) { return ""; };
                        break;
                }
            }
        }

        private string TotalMoney(XiaoShouInfo _goujinInfo)
        {
            string strReturnValue = "0.00";
            try
            {
                int _Number = _goujinInfo.p_sl1.Value;
                double _price = Convert.ToDouble(_goujinInfo.p_sl2);
                double TotalValue = _price * _Number;
                strReturnValue = string.Format("{0}", TotalValue.ToString("n"));
            }
            catch (Exception ex)
            {
            }
            return strReturnValue;
        }
        private string FormatDoubleBalue(string _Price)
        {
            string strReturnValue = "0.00";
            try
            {
                double _price = Convert.ToDouble(_Price);
                strReturnValue =_price.ToString("n");
            }
            catch (Exception ex)
            {
            }
            return strReturnValue;
        }
    }
}
