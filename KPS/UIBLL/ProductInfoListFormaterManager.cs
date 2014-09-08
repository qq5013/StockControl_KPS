using System;
using System.Collections.Generic;

using System.Text;
using KPS.Model;

namespace KPS.UIBLL
{
    /// <summary>
    /// 产品信息列表格式化
    /// </summary>
    public class ProductInfoListFormaterManager : IListViewColumnFormater
    {
        public void Formater(BrightIdeasSoftware.ObjectListView listview, BrightIdeasSoftware.OLVColumn column, bool isSHow)
        {
            if (column.Name == "OrderNumber")
            {
                column.AspectGetter = delegate(object x) { return ((ProductInfo)x).productid; };
            }
            else
            {
                switch (column.Name)
                {
                    case "productname":
                        column.AspectGetter = delegate(object x) { return ((ProductInfo)x).productname; };
                        break;
                    case "promoney":
                        column.AspectGetter = delegate(object x) { return ((ProductInfo)x).promoney; };
                        break;
                    default:
                        column.AspectGetter = delegate(object x) { return ""; };
                        break;
                }
            }
        }
    }
}
