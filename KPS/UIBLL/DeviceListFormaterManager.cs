using System;
using System.Collections.Generic;

using System.Text;
using KPS.Model;

namespace KPS.UIBLL
{
    /// <summary>
    /// 单位信息列表格式化
    /// </summary>
    public class DeviceListFormaterManager : IListViewColumnFormater
    {
        public void Formater(BrightIdeasSoftware.ObjectListView listview, BrightIdeasSoftware.OLVColumn column, bool isSHow)
        {
            if (column.Name == "OrderNumber")
            {
                column.AspectGetter = delegate(object x) { return ((DeviceInfo)x).DeviceID; };
            }
            else
            {
                switch (column.Name)
                {
                    case "DeviceType":
                        column.AspectGetter = delegate(object x) { return ((DeviceInfo)x).DeviceType; };
                        break;
                    default:
                        column.AspectGetter = delegate(object x) { return ""; };
                        break;
                }
            }
        }
    }
}
