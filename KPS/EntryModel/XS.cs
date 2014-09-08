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
    ///销售
    /// </summary>
    public partial class XS:ModelUserControl
    {
        private UIModels.EntryType _EntryType;
        private XiaoShouInfo ModelData;
        public XS()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 销售记录信息编辑
        /// </summary>
        /// <param name="_model"></param>
        public XS(XiaoShouInfo _model)
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
            XiaoShouInfo xsinfo = new XiaoShouInfo();
            xsinfo.p_clmc = textBox13.Text.Trim();
            xsinfo.p_cpmc = textBox1.Text.Trim();
            xsinfo.p_date = dateTimePicker1.Value;
            xsinfo.p_dw = textBox6.Text.Trim();
            xsinfo.p_ggxh = textBox2.Text.Trim();
            xsinfo.p_gys = textBox4.Text.Trim();
            xsinfo.p_jsr = textBox5.Text.Trim();
            xsinfo.p_mjph = textBox9.Text.Trim();
            xsinfo.p_ph = textBox14.Text.Trim();
            xsinfo.p_sl1 = (int)numericUpDown1.Value;
            xsinfo.p_sl2 = numericUpDown2.Value.ToString();
            xsinfo.p_zczh = string.Format("食药监械({0})字 第({1})号", textBox7.Text.Trim(), textBox3.Text.Trim());
            xsinfo.p_zzs = textBox8.Text.Trim();
            xsinfo.RemarkInfo = txtRemark.Text.Trim();//备注信息
            return xsinfo;
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
                textBox6.Text = unitfrm.SelUnitInfo.unitname;//选中名称替换
            }
        }

        private void LinkMaFacoter_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ManufacturerFrm manufrm = new ManufacturerFrm(true);
            if (manufrm.ShowDialog() == DialogResult.OK)
            {
                textBox8.Text = manufrm.SelfacturerInfo.manufacturerName;//选中名称替换
            }
        }

        private void XS_Load(object sender, EventArgs e)
        {
            if (ModelData != null)
            {
                textBox13.Text=ModelData.p_clmc;
                textBox1.Text=ModelData.p_cpmc;
                dateTimePicker1.Value=(DateTime)ModelData.p_date;
                textBox6.Text=ModelData.p_dw;
                textBox2.Text=ModelData.p_ggxh;
                textBox4.Text=ModelData.p_gys;
                textBox5.Text=ModelData.p_jsr;
                textBox9.Text=ModelData.p_mjph;
                textBox14.Text=ModelData.p_ph;
                numericUpDown1.Value=(int)ModelData.p_sl1;
                numericUpDown2.Value=Convert.ToInt32(ModelData.p_sl2);
                textBox7.Text = ModelData.p_zczh.Substring(ModelData.p_zczh.IndexOf("(") + 1, (ModelData.p_zczh.IndexOf(")") - ModelData.p_zczh.IndexOf("(") - 1));
                textBox3.Text = ModelData.p_zczh.Substring(ModelData.p_zczh.IndexOf("第") + 2, (ModelData.p_zczh.IndexOf("号") - ModelData.p_zczh.IndexOf("第") - 3));
                textBox4.Text = ModelData.p_zzs;
                txtRemark.Text = ModelData.RemarkInfo;
            }
           
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            int NumberValue = Convert.ToInt32(this.numericUpDown1.Value);
            double Doublevalue = Convert.ToDouble(numericUpDown2.Value);
            this.lblMerMoney.Text = TotalMoney(NumberValue, Doublevalue);
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            int NumberValue = Convert.ToInt32(this.numericUpDown1.Value);
            double Doublevalue = Convert.ToDouble(numericUpDown2.Value);
            this.lblMerMoney.Text = TotalMoney(NumberValue, Doublevalue);
        }

        /// <summary>
        /// 计算合计金额显示
        /// </summary>
        /// <param name="_Number"></param>
        /// <param name="_price"></param>
        /// <returns></returns>
        private string TotalMoney(int _Number, double _price)
        {
            string strReturnValue = "0.00(元)";
            double TotalValue = _price * _Number;
            strReturnValue = string.Format("{0}(元)", TotalValue.ToString("n"));
            return strReturnValue;
        }
    }
}
