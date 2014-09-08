using System;
using System.Collections.Generic;

using System.Text;
using KPS.Model;

namespace KPS.UIBLL
{
    /// <summary>
    /// 供应商 列表格式化
    /// </summary>
    public class SupplierListFormaterManager : IListViewColumnFormater
    {
        public void Formater(BrightIdeasSoftware.ObjectListView listview, BrightIdeasSoftware.OLVColumn column, bool isSHow)
        {
            if (column.Name == "OrderNumber")
            {
                column.AspectGetter = delegate(object x) { return ((Supplier)x).supplierID; };
            }
            else
            {
                switch (column.Name)
                {
                    case "supplierName":
                        column.AspectGetter = delegate(object x) { return ((Supplier)x).supplierName; };
                        break;
                    default:
                        column.AspectGetter = delegate(object x) { return ""; };
                        break;
                }
            }
        }
    }
}
