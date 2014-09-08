using System;
using System.Collections.Generic;

using System.Text;

namespace KPS.UIModels
{
    /// <summary>
    /// 列表字段信息
    /// </summary>
    public class ListColumnInfo
    {
        private string columnTitle;
        /// <summary>
        /// 字段显示名称
        /// </summary>
        public string ColumnTitle
        {
            get { return columnTitle; }
            set { columnTitle = value; }
        }
        private string columnName;
        /// <summary>
        /// 字段名(英文)
        /// </summary>
        public string ColumnName
        {
            get { return columnName; }
            set { columnName = value; }
        }
        private int columnLength=120;
        /// <summary>
        /// 字段列宽度
        /// </summary>
        public int ColumnLength
        {
            get { return columnLength; }
            set { columnLength = value; }
        }

        private System.Windows.Forms.HorizontalAlignment hAlign = System.Windows.Forms.HorizontalAlignment.Left;
        /// <summary>
        /// 对齐方式
        /// </summary>
        public System.Windows.Forms.HorizontalAlignment HAlign
        {
            get { return hAlign; }
            set { hAlign = value; }
        }

        private bool visble=true;
        /// <summary>
        /// 是否显示
        /// </summary>
        public bool Visble
        {
            get { return visble; }
            set { visble = value; }
        }

        /// <summary>
        /// 列信息构造函数 
        /// </summary>
        /// <param name="_title">显示名称</param>
        /// <param name="_name">字段名称</param>
        /// <param name="_length">字段列显示宽度</param>
        /// <param name="_align">对齐方式</param>
        /// <param name="_visble">是否显示</param>
        public ListColumnInfo(string _title, string _name, int _length, System.Windows.Forms.HorizontalAlignment _align, bool _visble)
        {
            columnTitle = _title;
            columnName = _name;
            columnLength = _length;
            hAlign = _align;
            visble = _visble;
        }

        /// <summary>
        /// 列信息构造函数 
        /// </summary>
        /// <param name="_title">显示名称</param>
        /// <param name="_name">字段名称</param>
        /// <param name="_length">字段列显示宽度</param>
        /// <param name="_align">对齐方式</param>
        /// <param name="_visble">是否显示</param>
        public ListColumnInfo(string _title, string _name)
        {
            columnTitle = _title;
            columnName = _name;
        }
    }
}
