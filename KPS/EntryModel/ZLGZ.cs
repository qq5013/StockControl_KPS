using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;

using System.Text;
using System.Windows.Forms;
using KPS.BLL;
using KPS.Model;

namespace KPS.EntryModel
{
    /// <summary>
    /// 质量跟踪
    /// </summary>
    public partial class ZLGZ:ModelUserControl
    {
        private UIModels.EntryType _EntryType;
        private ProcessLoggingInfo ModelData;
        public ZLGZ()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 质量跟踪信息编辑
        /// </summary>
        /// <param name="_model"></param>
        public ZLGZ(ProcessLoggingInfo _model)
        {
            ModelData = _model;
            InitializeComponent();
        }

        /// <summary>
        /// 录入类型
        /// </summary>
        /// <param name="_type"></param>
        public override void SetEntryType(UIModels.EntryType _type)
        {
            _EntryType = _type;
        }

        /// <summary>
        /// 保存表单数据
        /// </summary>
        public override object GetSaveData()
        {
            KPS.Model.ProcessLoggingInfo plinfo = new ProcessLoggingInfo();
            plinfo.ProcessContentInquired = textBox1.Text.Trim();
            plinfo.ProcessCustomerUnit = textBox2.Text.Trim();
            plinfo.ProcessDate = dateTimePicker1.Value;
            plinfo.ProcessHandlingSuggestion = textBox5.Text.Trim();
            plinfo.Processlinkman = textBox13.Text.Trim();
            plinfo.ProcessProductName = textBox4.Text.Trim();
            plinfo.ProcessPurchasingDate = dateTimePicker2.Value;
            plinfo.ProcessServiceUser = textBox7.Text.Trim();
            plinfo.ProcessStandard = textBox3.Text.Trim();
            plinfo.Processtel = textBox14.Text.Trim();


            return plinfo;
        }

        /// <summary>
        /// 取消保存
        /// </summary>
        public override void Cancel()
        { 
        
        }

        private void LinkbtnSelProName_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ProductManagerFrm profrm = new ProductManagerFrm(true);
            if (profrm.ShowDialog() == DialogResult.OK)
            {
                textBox4.Text = profrm.SelproductInfo.productname;//选中名称替换
            }
        }

        private void ZLGZ_Load(object sender, EventArgs e)
        {
            if (ModelData != null)
            {
                textBox1.Text=ModelData.ProcessContentInquired;
                textBox2.Text=ModelData.ProcessCustomerUnit;
                dateTimePicker1.Value=(DateTime)ModelData.ProcessDate;
                textBox5.Text=ModelData.ProcessHandlingSuggestion;
                textBox13.Text=ModelData.Processlinkman;
                textBox4.Text=ModelData.ProcessProductName;
                dateTimePicker2.Value=(DateTime)ModelData.ProcessPurchasingDate;
                textBox7.Text=ModelData.ProcessServiceUser;
                textBox3.Text=ModelData.ProcessStandard;
                textBox14.Text=ModelData.Processtel;
            }
        }
    }
}
