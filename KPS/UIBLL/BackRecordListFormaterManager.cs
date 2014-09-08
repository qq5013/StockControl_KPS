using System;
using System.Collections.Generic;

using System.Text;
using KPS.Model;

namespace KPS.UIBLL
{
    /// <summary>
    /// 数据备份记录 列表格式化
    /// </summary>
    public class BackRecordListFormaterManager : IListViewColumnFormater
    {
        public void Formater(BrightIdeasSoftware.ObjectListView listview, BrightIdeasSoftware.OLVColumn column, bool isSHow)
        {
            if (column.Name == "OrderNumber")
            {
                column.AspectGetter = delegate(object x) { return ((UIModels.DataBaseBackInfo)x).SortNo; };
            }
            else
            {
                switch (column.Name)
                {
                    case "BackDataFileName":
                        column.AspectGetter = delegate(object x) { return ((UIModels.DataBaseBackInfo)x).BackDataFileName; };
                        break;
                    case "DataBackTime":
                        column.AspectGetter = delegate(object x) { return ((UIModels.DataBaseBackInfo)x).DataBackTime; };
                        break;
                    default:
                        column.AspectGetter = delegate(object x) { return ""; };
                        break;
                }
            }
        }
    }
}
