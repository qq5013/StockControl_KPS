/*
 * 2013-05-31
 * by lj 
 */
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace KPS.DBUtility
{
    public class PageSql
    {
        /// <summary>
        /// 拼接分页sql语句
        /// </summary>
        /// <param name="pageIndex">页码</param>
        /// <param name="pageSize">每页显示条数</param>
        /// <param name="where">条件  </param>
        /// <param name="order">排序条件</param>
        public static string getDataByPage(int pageIndex, int pageSize, string where, string order, string tableName, string key, bool isPage)
        {
            if (where.Trim() != "")
            {
                where = " where " + where + " ";
            }
            if (order.Trim() != "")
            {
                order = " order by " + order + " ";
            }
            StringBuilder str = new System.Text.StringBuilder();
            if (isPage) //需要分页
            {
                if (pageIndex == 1)
                {
                    str.Append(string.Format("select top {0} * from ({1}) {2} {3}", pageSize, tableName, where, order));
                }
                else
                {
                    str.Append(string.Format(" select * from (select top {0} * from (select * from ({1}) {2} {3})) ", pageIndex * pageSize, tableName, where, order));
                    str.Append(string.Format(" where {0} not in", key));
                    str.Append(string.Format("( select top {0} {1} from ({2}) {3} {4})", (pageIndex - 1) * pageSize, key, tableName, where, order));
                }
            }
            else
            {
                str.Append(string.Format("select * from ({0}) {1} {2}", tableName, where, order));
            }
            return str.ToString();
        }
    }
}
