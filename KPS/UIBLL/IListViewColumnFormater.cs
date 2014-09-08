using System;
using System.Collections.Generic;

using System.Text;
using BrightIdeasSoftware;

namespace KPS.UIBLL
{
    /// <summary>
    /// ListView 字段格式化接口
    /// </summary>
    public interface IListViewColumnFormater
    {
        void Formater(ObjectListView listview, OLVColumn column, bool isSHow);
    }
}
