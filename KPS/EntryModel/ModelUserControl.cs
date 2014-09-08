using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;

using System.Text;
using System.Windows.Forms;

namespace KPS.EntryModel
{
    public partial class ModelUserControl : UserControl
    {
        private UIModels.EntryType _EntryType;
        public ModelUserControl()
        {
            InitializeComponent();
        }

        public virtual void SetEntryType(UIModels.EntryType _type)
        {
            _EntryType = _type;
        }

        /// <summary>
        /// 保存表单数据
        /// </summary>
        /// <returns></returns>
        public virtual object GetSaveData()
        {
            return null;
        }

        /// <summary>
        /// 取消保存
        /// </summary>
        public virtual void Cancel()
        {

        }
    }
}
