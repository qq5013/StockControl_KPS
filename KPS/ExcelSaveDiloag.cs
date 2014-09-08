using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Text;
using System.Windows.Forms;
using CSharpWin;
using System.IO;

namespace KPS
{
    public partial class ExcelSaveDiloag:SkinForm
    {
        private string exportExcelPath;

        /// <summary>
        /// 导出到Excel的路径
        /// </summary>
        public string ExportExcelPath
        {
            get { return exportExcelPath; }
        }
        public ExcelSaveDiloag()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim()!="")
            {
                exportExcelPath = textBox1.Text.Trim();
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("请点击浏览按钮选中导出Excel的保存路径！");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = saveFileDialog1.FileName;
            }
        }
    }
}
