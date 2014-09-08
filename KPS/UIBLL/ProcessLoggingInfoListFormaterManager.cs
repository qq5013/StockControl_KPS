using System;
using System.Collections.Generic;

using System.Text;
using KPS.Model;

namespace KPS.UIBLL
{
    /// <summary>
    /// 质量跟踪 格式化处理
    /// </summary>
    public class ProcessLoggingInfoListFormaterManager:IListViewColumnFormater
    {
        public void Formater(BrightIdeasSoftware.ObjectListView listview, BrightIdeasSoftware.OLVColumn column, bool isSHow)
        {
            if (column.Name == "OrderNumber")
            {
                column.AspectGetter = delegate(object x) { return ((ProcessLoggingInfo)x).ProcessID; };
            }
            else
            {

                switch (column.Name)
                {
                    case "ProcessContentInquired":
                        column.AspectGetter = delegate(object x) { return ((ProcessLoggingInfo)x).ProcessContentInquired; };
                        break;
                    case "ProcessCustomerUnit":
                        column.AspectGetter = delegate(object x) { return ((ProcessLoggingInfo)x).ProcessCustomerUnit; };
                        break;
                    case "ProcessDate":
                        column.AspectGetter = delegate(object x) { return ((ProcessLoggingInfo)x).ProcessDate.Value.ToString("yyyy-MM-dd HH:mm:ss"); };
                        break;
                    case "ProcessHandlingSuggestion":
                        column.AspectGetter = delegate(object x) { return ((ProcessLoggingInfo)x).ProcessHandlingSuggestion; };
                        break;
                    case "Processlinkman":
                        column.AspectGetter = delegate(object x) { return ((ProcessLoggingInfo)x).Processlinkman; };
                        break;
                    case "ProcessProductName":
                        column.AspectGetter = delegate(object x) { return ((ProcessLoggingInfo)x).ProcessProductName; };
                        break;
                    case "ProcessPurchasingDate":
                        column.AspectGetter = delegate(object x) { return ((ProcessLoggingInfo)x).ProcessPurchasingDate.Value.ToString("yyyy-MM-dd HH:mm:ss"); };
                        break;
                    case "ProcessServiceUser":
                        column.AspectGetter = delegate(object x) { return ((ProcessLoggingInfo)x).ProcessServiceUser; };
                        break;
                    case "ProcessStandard":
                        column.AspectGetter = delegate(object x) { return ((ProcessLoggingInfo)x).ProcessStandard; };
                        break;
                    case "Processtel":
                        column.AspectGetter = delegate(object x) { return ((ProcessLoggingInfo)x).Processtel; };
                        break;
                    default:
                        column.AspectGetter = delegate(object x) { return ""; };
                        break;
                }
            }
        }
    }
}
