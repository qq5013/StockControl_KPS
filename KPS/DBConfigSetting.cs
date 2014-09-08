using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Text;
using System.Windows.Forms;
using CSharpWin;
using KPS.Model;
using BrightIdeasSoftware;
using KPS.UIModels;
using KPS.UIBLL;
using KPS.DBUtility;
using System.IO;

namespace KPS
{
    /// <summary>
    /// 运输设备管理
    /// </summary>
    public partial class DBConfigSetting : SkinForm
    {
        private string ThisDbpath = "";

        /// <summary>
        /// 保存的数据库路径
        /// </summary>
        public string SavedDbpath
        {
            get { return ThisDbpath; }
        }
        public DBConfigSetting()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 页面窗体加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TptDeviceMGFrm_Load(object sender, EventArgs e)
        {
            InitFormShow();//初始化UI显示
        }

        /// <summary>
        /// 1.初始化显示
        /// </summary>
        private void InitFormShow()
        {
            ThisDbpath=DbHelperOleDb.getDBPath();
            if (string.IsNullOrEmpty(ThisDbpath))
            {
               string strDefaultPath=System.IO.Path.Combine(System.Windows.Forms.Application.StartupPath, "DB/KPSDB.accdb");
               FileInfo file = new FileInfo(strDefaultPath);
               if (file.Exists)
               {
                   ThisDbpath = strDefaultPath;
                   this.openFileDialog1.InitialDirectory = file.Directory.FullName;
               }
            }
            this.textBox1.Text = ThisDbpath;
        }
 
        /// <summary>
        /// 浏览选择数据库路径
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            if(this.openFileDialog1.ShowDialog()==DialogResult.OK)
            {
                this.textBox1.Text = this.openFileDialog1.FileName;   
            }
        }

        /// <summary>
        /// 路径保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (System.IO.File.Exists(textBox1.Text))
            {
                DbHelperOleDb.setDBPath(textBox1.Text);
                ThisDbpath = textBox1.Text;
                MessageBox.Show("保存成功！");
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("文件路径错误！");
            }
        }

    }
}
