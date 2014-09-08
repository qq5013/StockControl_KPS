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
    /// 退换货记录
    /// </summary>
    public partial class SH:ModelUserControl
    {
        private UIModels.EntryType _EntryType;
        private ShouHouInfo ModelData;
        public SH()
        {
            InitializeComponent();
        }
        public SH(ShouHouInfo _model)
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
            ShouHouInfo shinfo = new ShouHouInfo();
            shinfo.y_cpdm = textBox14.Text.Trim();
            shinfo.y_cpzczh = string.Format("食药监械({0})字 第({1})号", textBox7.Text.Trim(), textBox3.Text.Trim());
            shinfo.y_date = dateTimePicker1.Value;
            shinfo.y_dw = textBox15.Text.Trim();
            shinfo.y_fhrqz = textBox12.Text.Trim();
            shinfo.y_ggxh = textBox5.Text.Trim();
            shinfo.y_ghdw = textBox2.Text.Trim();
            shinfo.y_isHGZ = radioButton1.Checked;
            shinfo.y_mjph = textBox9.Text.Trim();
            shinfo.y_pm = textBox1.Text.Trim();
            shinfo.y_sccj = textBox13.Text.Trim();
            shinfo.y_scph = textBox8.Text.Trim();
            shinfo.y_sl =(int)numericUpDown1.Value;
            shinfo.y_yxq = textBox4.Text.Trim();
            shinfo.y_zgy = textBox11.Text.Trim();
            shinfo.y_zlqk = textBox10.Text.Trim();
            shinfo.y_managertype = radioButton4.Checked;
            return shinfo;
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
                textBox15.Text = unitfrm.SelUnitInfo.unitname;//选中名称替换
            }
        }

        private void LinkSupper_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SupperManagerFrm superfrm = new SupperManagerFrm(true);
            if (superfrm.ShowDialog() == DialogResult.OK)
            {
                textBox2.Text = superfrm.SelSupplierInfo.supplierName;//选中名称替换
            }
        }

        private void LinkMaFacoter_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            ManufacturerFrm manufrm = new ManufacturerFrm(true);
            if (manufrm.ShowDialog() == DialogResult.OK)
            {
                textBox13.Text = manufrm.SelfacturerInfo.manufacturerName;//选中名称替换
            }
        }

        private void SH_Load(object sender, EventArgs e)
        {
            if (ModelData != null)
            {
                textBox14.Text=ModelData.y_cpdm;
                textBox7.Text = ModelData.y_cpzczh.Substring(ModelData.y_cpzczh.IndexOf("(") + 1,(ModelData.y_cpzczh.IndexOf(")") - ModelData.y_cpzczh.IndexOf("(")-1));
                textBox3.Text = ModelData.y_cpzczh.Substring(ModelData.y_cpzczh.IndexOf("第") + 2,(ModelData.y_cpzczh.IndexOf("号") - ModelData.y_cpzczh.IndexOf("第")-3));
                
                dateTimePicker1.Value=(DateTime)ModelData.y_date;
                textBox15.Text=ModelData.y_dw;
                textBox12.Text=ModelData.y_fhrqz;
                textBox5.Text=ModelData.y_ggxh;
                textBox2.Text=ModelData.y_ghdw;
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
                textBox13.Text=ModelData.y_sccj;
                textBox8.Text=ModelData.y_scph;
                numericUpDown1.Value=(int)ModelData.y_sl;
                textBox4.Text=ModelData.y_yxq;
                textBox11.Text=ModelData.y_zgy;
                textBox10.Text=ModelData.y_zlqk;
                if (ModelData.y_managertype)
                {
                    radioButton4.Checked = true;
                }
                else
                {
                    radioButton3.Checked = true;
                }
            }
        }

        
    }
}
