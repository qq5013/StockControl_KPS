using System;
using System.Collections.Generic;

using System.Text;
using KPS.Model;

namespace KPS.UIBLL
{
    /// <summary>
    /// 用户信息列表格式化
    /// </summary>
    public class UserListFormaterManager:IListViewColumnFormater
    {
        public void Formater(BrightIdeasSoftware.ObjectListView listview, BrightIdeasSoftware.OLVColumn column, bool isSHow)
        {
            if (column.Name == "OrderNumber")
            {
                column.AspectGetter = delegate(object x) { return ((UserInfo)x).ID; };
            }
            else
            {
                switch (column.Name)
                {
                    case "userName":
                        column.AspectGetter = delegate(object x) { return ((UserInfo)x).userName; };
                        break;
                    case "userPwd":
                        column.AspectGetter = delegate(object x) { return ((UserInfo)x).userPwd; };
                        break;
                    default:
                        column.AspectGetter = delegate(object x) { return ""; };
                        break;
                }
            }
        }
    }
}
