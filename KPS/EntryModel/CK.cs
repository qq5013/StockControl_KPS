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
    /// 出库
    /// </summary>
    public partial class CK:ModelUserControl
    {
        private UIModels.EntryType _EntryType;
        private ChuKuInfo ModelData;
        public CK()
        {
            InitializeComponent();

        }
        public CK(ChuKuInfo _model)
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
            ChuKuInfo chukuinfo = new ChuKuInfo();
            chukuinfo.y_cpdm = textBox6.Text.Trim();
            chukuinfo.y_cpzczh = string.Format("食药监械({0})字 第({1})号", textBox7.Text.Trim(), textBox3.Text.Trim());
            chukuinfo.y_date = dateTimePicker1.Value;
            chukuinfo.y_dw = textBox5.Text.Trim();
            chukuinfo.y_fhrqz = textBox12.Text.Trim();
            chukuinfo.y_ggxh = textBox2.Text.Trim();
            chukuinfo.y_ghdw = textBox15.Text.Trim();
            chukuinfo.y_isHGZ = radioButton1.Checked;
            chukuinfo.y_mjph = textBox9.Text.Trim();
            chukuinfo.y_pm = textBox1.Text.Trim();
            chukuinfo.y_sccj = textBox16.Text.Trim();
            chukuinfo.y_scph = textBox8.Text.Trim();
            chukuinfo.y_sl = (int)numericUpDown1.Value;
            chukuinfo.y_yxq = textBox4.Text.Trim();
            chukuinfo.y_zgy = textBox11.Text.Trim();
            chukuinfo.y_zlqk = textBox10.Text.Trim();

            return chukuinfo;
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
                textBox1.Text = profrm.SelproductInfo.productname;//选中名称替换
            }
        }

        private void LinkBtnUnit_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            UnitManagerFrm unitfrm = new UnitManagerFrm(true);
            if (unitfrm.ShowDialog() == DialogResult.OK)
            {
                textBox5.Text = unitfrm.SelUnitInfo.unitname;//选中名称替换
            }
        }

        private void LinkMaFacoter_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ManufacturerFrm manufrm = new ManufacturerFrm(true);
            if (manufrm.ShowDialog() == DialogResult.OK)
            {
                textBox16.Text = manufrm.SelfacturerInfo.manufacturerName;//选中名称替换
            }
        }

        private void CK_Load(object sender, EventArgs e)
        {
            if (ModelData != null)
            {
                textBox6.Text=ModelData.y_cpdm;
                textBox7.Text = ModelData.y_cpzczh.Substring(ModelData.y_cpzczh.IndexOf("(") + 1,(ModelData.y_cpzczh.IndexOf(")") - ModelData.y_cpzczh.IndexOf("(")-1));
                textBox3.Text = ModelData.y_cpzczh.Substring(ModelData.y_cpzczh.IndexOf("第") + 2,(ModelData.y_cpzczh.IndexOf("号") - ModelData.y_cpzczh.IndexOf("第")-3));
                dateTimePicker1.Value=(DateTime)ModelData.y_date;
                textBox5.Text=ModelData.y_dw;
                textBox12.Text=ModelData.y_fhrqz;
                textBox2.Text=ModelData.y_ggxh;
                textBox15.Text=ModelData.y_ghdw;
                if (ModelData.y_isHGZ)
                {
                    radioButton1.Checked = true;
                }
                else
                {
                    radioButton2.Checked = true;
                }
                textBox9.Text=ModelData.y_mjph;
                textBox1.Text=ModelData.y_pm;
                textBox16.Text=ModelData.y_sccj;
                textBox8.Text=ModelData.y_scph;
                numericUpDown1.Value=(int)ModelData.y_sl;
                textBox4.Text=ModelData.y_yxq;
                textBox11.Text=ModelData.y_zgy;
                textBox10.Text=ModelData.y_zlqk;
            }
            
        }
    }
}
