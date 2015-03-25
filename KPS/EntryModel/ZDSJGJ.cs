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
    /// 诊断试剂购进
    /// </summary>
    public partial class ZDSJGJ:ModelUserControl
    {
        private UIModels.EntryType _EntryType;
        private GouJinInfo _ThisModel = null;
        public ZDSJGJ()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 诊断试剂购进信息编辑
        /// </summary>
        /// <param name="_GJModel"></param>
        public ZDSJGJ(GouJinInfo _GJModel)
        {
            _ThisModel = _GJModel;
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
            KPS.Model.GouJinInfo gjinfo = new GouJinInfo();
            gjinfo.p_clmc = textBox13.Text.Trim();
            gjinfo.p_cpmc = txtbox1.Text.Trim();
            gjinfo.p_date = dateTimePicker1.Value;
            gjinfo.p_dw = textBox1.Text.Trim();
            gjinfo.p_ggxh = txtbox2.Text.Trim();
            gjinfo.p_gys = textBox2.Text.Trim();
            gjinfo.p_jsr = textBox5.Text.Trim();
            gjinfo.p_mjph = textBox9.Text.Trim();
            gjinfo.p_ph = textBox14.Text.Trim();
            gjinfo.p_sl1 =(int)numericUpDown1.Value;
            gjinfo.p_sl2 =numericUpDown2.Value.ToString("0.00");
            gjinfo.p_zczh = string.Format("食药监械({0})字 第({1})号", textBox7.Text.Trim(),textBox3.Text.Trim());
            gjinfo.p_zzs = textBox4.Text.Trim();
            gjinfo.RemarkInfo = txtRemark.Text.Trim();//备注信息
            gjinfo.Reconfirm = txtreconfirm.Text.Trim();//复核人
            gjinfo.p_valid = dtimevalid.Value;//有效期
            return gjinfo;
        }

        /// <summary>
        /// 取消保存
        /// </summary>
        public override void Cancel()
        { 
        
        }

        /// <summary>
        /// 选择名称
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LinkbtnSelProName_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ProductManagerFrm profrm = new ProductManagerFrm(true);
            if (profrm.ShowDialog() == DialogResult.OK)
            {
                txtbox1.Text = profrm.SelproductInfo.productname;//选中名称替换
            }
        }

        private void LinkBtnUnit_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            UnitManagerFrm unitfrm = new UnitManagerFrm(true);
            if (unitfrm.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = unitfrm.SelUnitInfo.unitname;//选中名称替换
            }
        }

        private void LinkMaFacoter_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ManufacturerFrm manufrm = new ManufacturerFrm(true);
            if (manufrm.ShowDialog() == DialogResult.OK)
            {
                textBox4.Text = manufrm.SelfacturerInfo.manufacturerName;//选中名称替换
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

        /// <summary>
        /// 加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ZDSJGJ_Load(object sender, EventArgs e)
        {
            if (_ThisModel != null)
            { 
                textBox13.Text=_ThisModel.p_clmc;
                txtbox1.Text = _ThisModel.p_cpmc;
                dateTimePicker1.Value =(DateTime)_ThisModel.p_date;
                textBox1.Text = _ThisModel.p_dw;
                txtbox2.Text = _ThisModel.p_ggxh;
                textBox2.Text=_ThisModel.p_gys;
                textBox5.Text = _ThisModel.p_jsr;
                textBox9.Text = _ThisModel.p_mjph;
                textBox14.Text = _ThisModel.p_ph;
                numericUpDown1.Value=(int)_ThisModel.p_sl1;
                numericUpDown2.Value=Convert.ToDecimal(_ThisModel.p_sl2);
                textBox7.Text = _ThisModel.p_zczh.Substring(_ThisModel.p_zczh.IndexOf("(") + 1,(_ThisModel.p_zczh.IndexOf(")") - _ThisModel.p_zczh.IndexOf("(")-1));
                textBox3.Text = _ThisModel.p_zczh.Substring(_ThisModel.p_zczh.IndexOf("第") + 2,(_ThisModel.p_zczh.IndexOf("号") - _ThisModel.p_zczh.IndexOf("第")-3));
                textBox4.Text = _ThisModel.p_zzs;
                txtRemark.Text = _ThisModel.RemarkInfo;
                txtreconfirm.Text = _ThisModel.Reconfirm;//复核人
                dtimevalid.Value = (DateTime)_ThisModel.p_date;//有效期
            }
           
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
            string strReturnValue = "0.00";
            double TotalValue = _price * _Number;
            strReturnValue = string.Format("{0}",TotalValue.ToString("n"));
            return strReturnValue;
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            int NumberValue = Convert.ToInt32(this.numericUpDown1.Value);
            double Doublevalue = Convert.ToDouble(numericUpDown2.Value);
            this.lblMerMoney.Text = TotalMoney(NumberValue, Doublevalue);
        }


    }
}
