using System;
using System.Collections.Generic;

using System.Text;
using BrightIdeasSoftware;
using KPS.UIModels;
using System.Windows.Forms;

namespace KPS.UIBLL
{
    public class InitListViewColumnManager
    {
        /// <summary>
        /// 开始初始化
        /// </summary>
        /// <param name="_Listview"></param>
        /// <param name="_listcolumns"></param>
        /// <param name="_formater">字段格式化类</param>
        public void Init(ObjectListView _Listview, List<ListColumnInfo> _listcolumns,IListViewColumnFormater _formater)
        {
            if (_Listview.Columns != null && _Listview.Columns.Count > 0)
            {
                _Listview.Columns.Clear();
            }


            List<OLVColumn> _Columns = new List<OLVColumn>();
            foreach (ListColumnInfo _Column in _listcolumns)
            {
                _Columns.Add(InitializationOLVCOlumn(_Column.ColumnTitle, _Column.ColumnName, _Column.ColumnName, _Column.HAlign, true, _Column.ColumnLength, _Column.ColumnName, true,_Listview,_formater));
            }


            AddColumnsToListVIew(_Listview, _Columns);//向ListView 中填充栏位
        }

        /// <summary>
        /// 1.2.初始化一个栏位
        /// </summary>
        /// <param name="Title">显示的名称</param>
        /// <param name="aspect">名称代码</param>
        /// <param name="Name">栏位名称</param>
        /// <param name="alig">对齐方式</param>
        /// <param name="bolleter">超出界限部分是否显示省略号</param>
        /// <param name="with">栏位宽度</param>
        /// <param name="columnobj">栏位对象</param>
        /// <param name="isSHow">是否显示</param>
        private OLVColumn InitializationOLVCOlumn(string Title, string aspect, string Name, HorizontalAlignment alig, bool bolleter, int with, object columnobj, bool isSHow,ObjectListView listview,IListViewColumnFormater _formater)
        {
            OLVColumn newcolumn = new OLVColumn();
            newcolumn.HeaderTextAlign = alig;
            newcolumn.UseInitialLetterForGroup = bolleter;
            newcolumn.Text = Title;
            newcolumn.Name = Name;
            newcolumn.Width = with;
            newcolumn.Tag = columnobj;
            newcolumn.IsVisible = isSHow;//是否显示

            _formater.Formater(listview,newcolumn, isSHow);

            return newcolumn;
        }

        /// <summary>
        /// 1.3. 向ListView 中添加栏位
        /// </summary>
        /// <param name="_ColumnList"></param>
        private void AddColumnsToListVIew(ObjectListView _Listview, List<OLVColumn> _ColumnList)
        {
            if (_ColumnList != null && _ColumnList.Count > 0)
            {
                foreach (OLVColumn _Column in _ColumnList)
                {
                    _Listview.Columns.Add(_Column);
                }
            }
        } 
    }
}
