namespace KPS
{
    partial class ModuleMGFrm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("1.诊断试剂购进");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("2.存储");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("3.销售");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("4.售后");
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("5.不合格品记录");
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("6.不良事件");
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("7.质量跟踪");
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("数据录入", new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2,
            treeNode3,
            treeNode4,
            treeNode5,
            treeNode6,
            treeNode7});
            System.Windows.Forms.TreeNode treeNode9 = new System.Windows.Forms.TreeNode("1.诊断试剂购进记录");
            System.Windows.Forms.TreeNode treeNode10 = new System.Windows.Forms.TreeNode("2.存储记录");
            System.Windows.Forms.TreeNode treeNode11 = new System.Windows.Forms.TreeNode("3.销售记录");
            System.Windows.Forms.TreeNode treeNode12 = new System.Windows.Forms.TreeNode("4.售后记录");
            System.Windows.Forms.TreeNode treeNode13 = new System.Windows.Forms.TreeNode("5.不合格品记录");
            System.Windows.Forms.TreeNode treeNode14 = new System.Windows.Forms.TreeNode("6.不良事件");
            System.Windows.Forms.TreeNode treeNode15 = new System.Windows.Forms.TreeNode("7.质量跟踪");
            System.Windows.Forms.TreeNode treeNode16 = new System.Windows.Forms.TreeNode("8.库存查询");
            System.Windows.Forms.TreeNode treeNode17 = new System.Windows.Forms.TreeNode("9.销售汇总");
            System.Windows.Forms.TreeNode treeNode18 = new System.Windows.Forms.TreeNode("综合报表", new System.Windows.Forms.TreeNode[] {
            treeNode9,
            treeNode10,
            treeNode11,
            treeNode12,
            treeNode13,
            treeNode14,
            treeNode15,
            treeNode16,
            treeNode17});
            System.Windows.Forms.TreeNode treeNode19 = new System.Windows.Forms.TreeNode("1.数据库存储设定");
            System.Windows.Forms.TreeNode treeNode20 = new System.Windows.Forms.TreeNode("2.用户管理");
            System.Windows.Forms.TreeNode treeNode21 = new System.Windows.Forms.TreeNode("3.用户权限管理");
            System.Windows.Forms.TreeNode treeNode22 = new System.Windows.Forms.TreeNode("4.修改密码");
            System.Windows.Forms.TreeNode treeNode23 = new System.Windows.Forms.TreeNode("5.数据备份/还原");
            System.Windows.Forms.TreeNode treeNode24 = new System.Windows.Forms.TreeNode("系统设定", new System.Windows.Forms.TreeNode[] {
            treeNode19,
            treeNode20,
            treeNode21,
            treeNode22,
            treeNode23});
            System.Windows.Forms.TreeNode treeNode25 = new System.Windows.Forms.TreeNode("1.产品名称");
            System.Windows.Forms.TreeNode treeNode26 = new System.Windows.Forms.TreeNode("2.产品单位");
            System.Windows.Forms.TreeNode treeNode27 = new System.Windows.Forms.TreeNode("3.生产商");
            System.Windows.Forms.TreeNode treeNode28 = new System.Windows.Forms.TreeNode("4.供应商");
            System.Windows.Forms.TreeNode treeNode29 = new System.Windows.Forms.TreeNode("5.医疗器械分类");
            System.Windows.Forms.TreeNode treeNode30 = new System.Windows.Forms.TreeNode("基础数据", new System.Windows.Forms.TreeNode[] {
            treeNode25,
            treeNode26,
            treeNode27,
            treeNode28,
            treeNode29});
            System.Windows.Forms.TreeNode treeNode31 = new System.Windows.Forms.TreeNode("功能模块/菜单", new System.Windows.Forms.TreeNode[] {
            treeNode8,
            treeNode18,
            treeNode24,
            treeNode30});
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ModuleMGFrm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = global::KPS.Properties.Resources.MainBgImg_V02;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.treeView1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 24);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(530, 450);
            this.panel1.TabIndex = 0;
            // 
            // button2
            // 
            this.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button2.Location = new System.Drawing.Point(420, 408);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 29);
            this.button2.TabIndex = 2;
            this.button2.Text = "取 消";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(331, 408);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 29);
            this.button1.TabIndex = 2;
            this.button1.Text = "确 定";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(34, 20);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(461, 163);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "用户列表";
            // 
            // treeView1
            // 
            this.treeView1.CheckBoxes = true;
            this.treeView1.HotTracking = true;
            this.treeView1.Location = new System.Drawing.Point(34, 201);
            this.treeView1.Name = "treeView1";
            treeNode1.Name = "A1";
            treeNode1.Tag = "1";
            treeNode1.Text = "1.诊断试剂购进";
            treeNode2.Name = "A3";
            treeNode2.Tag = "3";
            treeNode2.Text = "2.存储";
            treeNode3.Name = "A4";
            treeNode3.Tag = "4";
            treeNode3.Text = "3.销售";
            treeNode4.Name = "A6";
            treeNode4.Tag = "6";
            treeNode4.Text = "4.售后";
            treeNode5.Name = "A7";
            treeNode5.Tag = "7";
            treeNode5.Text = "5.不合格品记录";
            treeNode6.Name = "A8";
            treeNode6.Tag = "8";
            treeNode6.Text = "6.不良事件";
            treeNode7.Name = "A9";
            treeNode7.Tag = "9";
            treeNode7.Text = "7.质量跟踪";
            treeNode8.Name = "A_AddDataNode";
            treeNode8.Text = "数据录入";
            treeNode9.Name = "B1";
            treeNode9.Tag = "10";
            treeNode9.Text = "1.诊断试剂购进记录";
            treeNode10.Name = "B3";
            treeNode10.Tag = "12";
            treeNode10.Text = "2.存储记录";
            treeNode11.Name = "B4";
            treeNode11.Tag = "13";
            treeNode11.Text = "3.销售记录";
            treeNode12.Name = "B6";
            treeNode12.Tag = "15";
            treeNode12.Text = "4.售后记录";
            treeNode13.Name = "B7";
            treeNode13.Tag = "16";
            treeNode13.Text = "5.不合格品记录";
            treeNode14.Name = "B8";
            treeNode14.Tag = "17";
            treeNode14.Text = "6.不良事件";
            treeNode15.Name = "B9";
            treeNode15.Tag = "18";
            treeNode15.Text = "7.质量跟踪";
            treeNode16.Name = "B10";
            treeNode16.Tag = "29";
            treeNode16.Text = "8.库存查询";
            treeNode17.Name = "B11";
            treeNode17.Tag = "30";
            treeNode17.Text = "9.销售汇总";
            treeNode18.Name = "B_Report";
            treeNode18.Text = "综合报表";
            treeNode19.Name = "C1";
            treeNode19.Tag = "19";
            treeNode19.Text = "1.数据库存储设定";
            treeNode20.Name = "C2";
            treeNode20.Tag = "20";
            treeNode20.Text = "2.用户管理";
            treeNode21.Name = "C3";
            treeNode21.Tag = "21";
            treeNode21.Text = "3.用户权限管理";
            treeNode22.Name = "C4";
            treeNode22.Tag = "22";
            treeNode22.Text = "4.修改密码";
            treeNode23.Name = "C5";
            treeNode23.Tag = "28";
            treeNode23.Text = "5.数据备份/还原";
            treeNode24.Name = "C_SysSetting";
            treeNode24.Text = "系统设定";
            treeNode25.Name = "D1";
            treeNode25.Tag = "23";
            treeNode25.Text = "1.产品名称";
            treeNode26.Name = "D2";
            treeNode26.Tag = "24";
            treeNode26.Text = "2.产品单位";
            treeNode27.Name = "D3";
            treeNode27.Tag = "25";
            treeNode27.Text = "3.生产商";
            treeNode28.Name = "D4";
            treeNode28.Tag = "26";
            treeNode28.Text = "4.供应商";
            treeNode29.Name = "D5";
            treeNode29.Tag = "27";
            treeNode29.Text = "5.医疗器械分类";
            treeNode30.Name = "D_BasicData";
            treeNode30.Text = "基础数据";
            treeNode31.Name = "RootNode";
            treeNode31.Text = "功能模块/菜单";
            this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode31});
            this.treeView1.Size = new System.Drawing.Size(461, 192);
            this.treeView1.TabIndex = 0;
            this.treeView1.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterCheck);
            // 
            // ModuleMGFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(536, 477);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(536, 477);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(536, 477);
            this.Name = "ModuleMGFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "用户权限管理";
            this.Load += new System.EventHandler(this.TptDeviceMGFrm_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;

    }
}