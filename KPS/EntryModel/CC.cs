using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;

using System.Text;
using System.Windows.Forms;
using KPS.Model;

namespace KPS.EntryModel
{
    /// <summary>
    /// 不合格品记录
    /// </summary>
    public partial class CC:ModelUserControl
    {
        private UIModels.EntryType _EntryType;
        private CunChuInfo ModelData;
        public CC()
        {
            InitializeComponent();
 
        }
        public CC(CunChuInfo _model)
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
            CunChuInfo cunchuinfo = new CunChuInfo();
            cunchuinfo.s_cqcs = textBox6.Text.Trim();
            cunchuinfo.s_csmc = textBox1.Text.Trim();
            cunchuinfo.s_date =Convert.ToDateTime(dateTimePicker1.Value.ToString("yyyy-MM-dd 00:00:00"));
            cunchuinfo.s_jlr = textBox9.Text.Trim();
            cunchuinfo.s_sd = textBox4.Text.Trim();
            cunchuinfo.s_sded = textBox7.Text.Trim();
            cunchuinfo.s_sworxw = 0;
            if (!radioButton1.Checked)
            {
                cunchuinfo.s_sworxw = 1;
            }
            cunchuinfo.s_sywdfw = textBox3.Text.Trim();
            cunchuinfo.s_syxdsdfw = textBox2.Text.Trim();
            cunchuinfo.s_wd = textBox5.Text.Trim();
            cunchuinfo.s_wded = textBox8.Text.Trim();
            
            return cunchuinfo;
        }

        /// <summary>
        /// 取消保存
        /// </summary>
        public override void Cancel()
        { 
        
        }

        private void CC_Load(object sender, EventArgs e)
        {
            //textBox7.Text = ModelData.y_cpzczh.Substring(ModelData.y_cpzczh.IndexOf("(") + 1, (ModelData.y_cpzczh.IndexOf(")") - ModelData.y_cpzczh.IndexOf("(") - 1));
            //textBox3.Text = ModelData.y_cpzczh.Substring(ModelData.y_cpzczh.IndexOf("第") + 2, (ModelData.y_cpzczh.IndexOf("号") - ModelData.y_cpzczh.IndexOf("第") - 3));
            if (ModelData != null)
            {
                textBox6.Text = ModelData.s_cqcs;
                textBox1.Text = ModelData.s_csmc;
                dateTimePicker1.Value = (DateTime)ModelData.s_date;
                textBox9.Text = ModelData.s_jlr;
                textBox4.Text = ModelData.s_sd;
                textBox7.Text = ModelData.s_sded;
                if (ModelData.s_sworxw == 0)
                {
                    radioButton1.Checked = true;
                }
                else
                {
                    radioButton2.Checked = true;
                }
                textBox3.Text = ModelData.s_sywdfw;
                textBox2.Text = ModelData.s_syxdsdfw;
                textBox5.Text = ModelData.s_wd;
                textBox8.Text = ModelData.s_wded;
            }
        }

   
    }
}
