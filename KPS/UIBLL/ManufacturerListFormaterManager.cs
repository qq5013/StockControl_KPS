using System;
using System.Collections.Generic;

using System.Text;
using KPS.Model;

namespace KPS.UIBLL
{
    /// <summary>
    /// 生产 列表格式化
    /// </summary>
    public class ManufacturerListFormaterManager : IListViewColumnFormater
    {
        public void Formater(BrightIdeasSoftware.ObjectListView listview, BrightIdeasSoftware.OLVColumn column, bool isSHow)
        {
            if (column.Name == "OrderNumber")
            {
                column.AspectGetter = delegate(object x) { return ((Manufacturer)x).manufacturerID; };
            }
            else
            {
                switch (column.Name)
                {
                    case "manufacturerName":
                        column.AspectGetter = delegate(object x) { return ((Manufacturer)x).manufacturerName; };
                        break;
                    case "manufacturerTel":
                        column.AspectGetter = delegate(object x) { return ((Manufacturer)x).manufacturerTel; };
                        break;
                    case "manufacturerAdd":
                        column.AspectGetter = delegate(object x) { return ((Manufacturer)x).manufacturerAdd; };
                        break;
                    default:
                        column.AspectGetter = delegate(object x) { return ""; };
                        break;
                }
            }
        }
    }
}
