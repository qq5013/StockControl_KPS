using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Text;
using System.Windows.Forms;
using CSharpWin;

namespace KPS
{
    /// <summary>
    /// 确认窗口
    /// </summary>
    public partial class ConfirmFrm :SkinForm
    {
        /// <summary>
        /// 确认窗口
        /// </summary>
        /// <param name="_TitleTxt">窗体显示名称</param>
        /// <param name="_TipTxt">提示文本</param>
        /// <param name="_btnYesTxt">确认按钮文本</param>
        /// <param name="_btnNoTxt">取消按钮文本</param>
        /// <param name="_TipType">提示类型</param>
        public ConfirmFrm(string _TitleTxt,string _TipTxt,string _btnYesTxt,string _btnNoTxt,int _TipType)
        {
            InitializeComponent();

            this.Text = _TitleTxt;
            this.lblTipDetail.Text = _TipTxt;
            this.btnQuery.Text = _btnYesTxt;
            this.btnCancel.Text = _btnNoTxt;
            this.picState.Image = TipTypeImgList.Images[_TipType - 1];
        }
    }
}
