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
    /// 不良事件
    /// </summary>
    public partial class BLSJ:ModelUserControl
    {
        private UIModels.EntryType _EntryType;
        private BuLiangShiJianInfo ModelData;
        public BLSJ()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 不良事件记录编辑
        /// </summary>
        /// <param name="_model"></param>
        public BLSJ(BuLiangShiJianInfo _model)
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
            KPS.Model.BuLiangShiJianInfo blsjinfo = new BuLiangShiJianInfo();
            blsjinfo.b_bgr = textBox9.Text.Trim();//质量事故情况 报告人
            blsjinfo.b_bgsj = dateTimePicker4.Value;//质量事故情况 报告日期

            blsjinfo.b_cpdm = textBox14.Text.Trim();//产品代码
            blsjinfo.b_fzr = textBox10.Text.Trim(); //使用单位意见 负责人
            blsjinfo.b_fzrqz = textBox15.Text.Trim();//企业主管质量负责人意见 签字

            blsjinfo.b_fzrqzsj = dateTimePicker3.Value;//企业主管质量负责人意见 签字时间
            blsjinfo.b_ggxh = textBox5.Text.Trim();//规格型号
            blsjinfo.b_qyzgfzryj = textBox6.Text.Trim();//企业主管质量负责人意见

            blsjinfo.b_resj = dateTimePicker1.Value;//使用单位意见 签字时间

            blsjinfo.b_sccj = textBox13.Text.Trim();//生产厂家
            blsjinfo.b_scrq = textBox8.Text.Trim();//生产日期
            blsjinfo.b_sl =(int)numericUpDown1.Value;//数量
            blsjinfo.b_sydw = textBox2.Text.Trim();//使用单位
            blsjinfo.b_sydwyj = textBox7.Text.Trim();//使用单位意见
            blsjinfo.b_ylqxmc = textBox1.Text.Trim();//医疗器械名称
            blsjinfo.b_zgclqk = textBox12.Text.Trim();//最终处理情况
            blsjinfo.b_zgjbr = textBox11.Text.Trim();//最终处理情况 经办人

            blsjinfo.b_zgjbsj = dateTimePicker1.Value; //最终处理情况 签字时间
            blsjinfo.b_zlsgqk = textBox3.Text.Trim(); //质量事故情况内容
            

            return blsjinfo;
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
          
            
        }

        
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
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

        private void LinkSupper_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SupperManagerFrm superfrm = new SupperManagerFrm(true);
            if (superfrm.ShowDialog() == DialogResult.OK)
            {
                textBox13.Text = superfrm.SelSupplierInfo.supplierName;//选中名称替换
            }
        }

        private void BLSJ_Load(object sender, EventArgs e)
        {
            if (ModelData != null)
            {
                textBox9.Text=ModelData.b_bgr;//质量事故情况 报告人
                dateTimePicker4.Value=(DateTime)ModelData.b_bgsj;//质量事故情况 报告日期

                textBox14.Text=ModelData.b_cpdm;//产品代码
                textBox10.Text=ModelData.b_fzr; //使用单位意见 负责人
                textBox15.Text=ModelData.b_fzrqz;//企业主管质量负责人意见 签字

                dateTimePicker3.Value=(DateTime)ModelData.b_fzrqzsj;//企业主管质量负责人意见 签字时间
                textBox5.Text=ModelData.b_ggxh;//规格型号
                textBox6.Text=ModelData.b_qyzgfzryj;//企业主管质量负责人意见

                dateTimePicker1.Value=(DateTime)ModelData.b_resj;//使用单位意见 签字时间

                textBox13.Text=ModelData.b_sccj;//生产厂家
                textBox8.Text=ModelData.b_scrq;//生产日期
                numericUpDown1.Value=(int)ModelData.b_sl;//数量
                textBox2.Text=ModelData.b_sydw;//使用单位
                textBox7.Text=ModelData.b_sydwyj;//使用单位意见
                textBox1.Text=ModelData.b_ylqxmc;//医疗器械名称
                textBox12.Text=ModelData.b_zgclqk;//最终处理情况
                textBox11.Text=ModelData.b_zgjbr;//最终处理情况 经办人

                dateTimePicker1.Value=(DateTime)ModelData.b_zgjbsj; //最终处理情况 签字时间
                textBox3.Text=ModelData.b_zlsgqk; //质量事故情况内容
            }
        }
    }
}
