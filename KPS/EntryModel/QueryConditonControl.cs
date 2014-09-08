using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;

using System.Text;
using System.Windows.Forms;

namespace KPS.EntryModel
{
    public partial class QueryConditonControl : UserControl
    {
        public delegate void DelListArg(System.Collections.ICollection _list, bool State,string _msg);
        public virtual event  DelListArg ListLoadingEvent;
        public QueryConditonControl()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 初始化类型
        /// </summary>
        /// <param name="_EntryType"></param>
        public virtual void InitType(UIModels.EntryType _EntryType)
        { 
        
        }
        /// <summary>
        /// 更改医疗器械类型
        /// </summary>
        /// <param name="_Device"></param>
        public virtual void ChangeDeviceType(KPS.Model.DeviceInfo _Device)
        {
        }
    }
}
