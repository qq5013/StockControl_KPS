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
    /// 验收
    /// </summary>
    public partial class YS:ModelUserControl
    {
        private UIModels.EntryType _EntryType;
        private YanShouInfo ModelData=null;
        public YS()
        {
            InitializeComponent();
        }
        public YS(YanShouInfo _model)
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
            KPS.Model.YanShouInfo ysinfo = new YanShouInfo();
            ysinfo.y_cpdm = textBox6.Text.Trim();
            ysinfo.y_cpzczh = string.Format("食药监械({0})字 第({1})号", textBox7.Text.Trim(), textBox3.Text.Trim());
            ysinfo.y_date = dateTimePicker1.Value;
            ysinfo.y_dw = textBox14.Text.Trim();
            ysinfo.y_fhrqz = textBox12.Text.Trim();
            ysinfo.y_ggxh = textBox5.Text.Trim();
            ysinfo.y_ghdw = textBox2.Text.Trim();
            ysinfo.y_isHGZ = radioButton1.Checked;
            ysinfo.y_mjph = textBox9.Text.Trim();
            ysinfo.y_pm = textBox1.Text.Trim();
            ysinfo.y_sccj = textBox13.Text.Trim();
            ysinfo.y_scph = textBox8.Text.Trim();
            ysinfo.y_sl = (int)numericUpDown1.Value;
            ysinfo.y_yxq = textBox4.Text.Trim();
            ysinfo.y_zgy = textBox11.Text.Trim();
            ysinfo.y_zlqk = textBox10.Text.Trim();

            return ysinfo;
        }

        /// <summary>
        /// 取消保存
        /// </summary>
        public override void Cancel()
        { 
        
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnFilter_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox1.Text.Trim()))
            {
               
            }
            else
            {
                MessageBox.Show("请输入有效名称！");
            }
            
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
                textBox14.Text = unitfrm.SelUnitInfo.unitname;//选中名称替换
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

        private void YS_Load(object sender, EventArgs e)
        {
            if (ModelData != null)
            {
                textBox6.Text = ModelData.y_cpdm;
                textBox7.Text = ModelData.y_cpzczh.Substring(ModelData.y_cpzczh.IndexOf("(") + 1, (ModelData.y_cpzczh.IndexOf(")") - ModelData.y_cpzczh.IndexOf("(") - 1));
                textBox3.Text = ModelData.y_cpzczh.Substring(ModelData.y_cpzczh.IndexOf("第") + 2, (ModelData.y_cpzczh.IndexOf("号") - ModelData.y_cpzczh.IndexOf("第") - 3));
                dateTimePicker1.Value = (DateTime)ModelData.y_date;
                textBox14.Text=ModelData.y_dw;
                textBox12.Text=ModelData.y_fhrqz;
                textBox5.Text = ModelData.y_ggxh;
                textBox2.Text = ModelData.y_ghdw;
                if (ModelData.y_isHGZ)
                {
                    radioButton1.Checked = true;
                }
                else
                {
                    radioButton2.Checked = true;
                }
                textBox9.Text = ModelData.y_mjph;
                textBox1.Text = ModelData.y_pm;
                textBox13.Text = ModelData.y_sccj;
                textBox8.Text = ModelData.y_scph;
                numericUpDown1.Value = (int)ModelData.y_sl;
                textBox4.Text = ModelData.y_yxq;
                textBox11.Text = ModelData.y_zgy;
                textBox10.Text = ModelData.y_zlqk;
            }
        }

       
    }
}
