namespace KPS
{
    partial class DataQueryFrm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DataQueryFrm));
            this.miniToolStrip = new System.Windows.Forms.MenuStrip();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.SortpanalBar = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblMatrixbar = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.PanelDevice = new System.Windows.Forms.Panel();
            this.CmboxDeviceClass = new System.Windows.Forms.ComboBox();
            this.LblDeviceLabel = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tolModelInfo = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.TolMsgInfo = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.TolMenuSaveAS = new System.Windows.Forms.ToolStripMenuItem();
            this.TolMenuSaveAS_ALL = new System.Windows.Forms.ToolStripMenuItem();
            this.TolMenuSaveAS_Selected = new System.Windows.Forms.ToolStripMenuItem();
            this.TolMenuPrint = new System.Windows.Forms.ToolStripMenuItem();
            this.PrintTol_List = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ListItem_Edit = new System.Windows.Forms.ToolStripMenuItem();
            this.ListItem_Delete = new System.Windows.Forms.ToolStripMenuItem();
            this.listViewPrinter1 = new BrightIdeasSoftware.ListViewPrinter();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SortpanalBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.PanelDevice.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // miniToolStrip
            // 
            this.miniToolStrip.AutoSize = false;
            this.miniToolStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.miniToolStrip.Location = new System.Drawing.Point(6, 2);
            this.miniToolStrip.Name = "miniToolStrip";
            this.miniToolStrip.Size = new System.Drawing.Size(952, 24);
            this.miniToolStrip.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.PanelDevice);
            this.panel1.Controls.Add(this.statusStrip1);
            this.panel1.Controls.Add(this.menuStrip1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 24);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(952, 667);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.SortpanalBar);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 139);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(952, 502);
            this.panel2.TabIndex = 6;
            // 
            // SortpanalBar
            // 
            this.SortpanalBar.BackColor = System.Drawing.Color.Transparent;
            this.SortpanalBar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.SortpanalBar.Controls.Add(this.pictureBox1);
            this.SortpanalBar.Controls.Add(this.lblMatrixbar);
            this.SortpanalBar.Location = new System.Drawing.Point(323, 176);
            this.SortpanalBar.Name = "SortpanalBar";
            this.SortpanalBar.Size = new System.Drawing.Size(306, 191);
            this.SortpanalBar.TabIndex = 22;
            this.SortpanalBar.Visible = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(118, 76);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(64, 64);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 18;
            this.pictureBox1.TabStop = false;
            // 
            // lblMatrixbar
            // 
            this.lblMatrixbar.AutoSize = true;
            this.lblMatrixbar.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblMatrixbar.ForeColor = System.Drawing.Color.DodgerBlue;
            this.lblMatrixbar.Location = new System.Drawing.Point(64, 51);
            this.lblMatrixbar.Name = "lblMatrixbar";
            this.lblMatrixbar.Size = new System.Drawing.Size(161, 17);
            this.lblMatrixbar.TabIndex = 17;
            this.lblMatrixbar.Text = "正在为您加载数据，请稍候...";
            // 
            // groupBox1
            // 
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 61);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(952, 78);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = " 查询条件 ";
            // 
            // PanelDevice
            // 
            this.PanelDevice.Controls.Add(this.CmboxDeviceClass);
            this.PanelDevice.Controls.Add(this.LblDeviceLabel);
            this.PanelDevice.Dock = System.Windows.Forms.DockStyle.Top;
            this.PanelDevice.Location = new System.Drawing.Point(0, 25);
            this.PanelDevice.Name = "PanelDevice";
            this.PanelDevice.Size = new System.Drawing.Size(952, 36);
            this.PanelDevice.TabIndex = 4;
            // 
            // CmboxDeviceClass
            // 
            this.CmboxDeviceClass.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmboxDeviceClass.FormattingEnabled = true;
            this.CmboxDeviceClass.Location = new System.Drawing.Point(114, 5);
            this.CmboxDeviceClass.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.CmboxDeviceClass.Name = "CmboxDeviceClass";
            this.CmboxDeviceClass.Size = new System.Drawing.Size(148, 25);
            this.CmboxDeviceClass.TabIndex = 12;
            this.CmboxDeviceClass.SelectedIndexChanged += new System.EventHandler(this.CmboxDeviceClass_SelectedIndexChanged);
            // 
            // LblDeviceLabel
            // 
            this.LblDeviceLabel.AutoSize = true;
            this.LblDeviceLabel.Location = new System.Drawing.Point(16, 10);
            this.LblDeviceLabel.Name = "LblDeviceLabel";
            this.LblDeviceLabel.Size = new System.Drawing.Size(92, 17);
            this.LblDeviceLabel.TabIndex = 0;
            this.LblDeviceLabel.Text = "医疗器械类型：";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tolModelInfo,
            this.toolStripStatusLabel2,
            this.TolMsgInfo});
            this.statusStrip1.Location = new System.Drawing.Point(0, 641);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(952, 26);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tolModelInfo
            // 
            this.tolModelInfo.AutoSize = false;
            this.tolModelInfo.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.tolModelInfo.BorderStyle = System.Windows.Forms.Border3DStyle.Bump;
            this.tolModelInfo.Name = "tolModelInfo";
            this.tolModelInfo.Size = new System.Drawing.Size(400, 21);
            this.tolModelInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.toolStripStatusLabel2.BorderStyle = System.Windows.Forms.Border3DStyle.Sunken;
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(72, 21);
            this.toolStripStatusLabel2.Text = "状态信息：";
            // 
            // TolMsgInfo
            // 
            this.TolMsgInfo.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.TolMsgInfo.BorderStyle = System.Windows.Forms.Border3DStyle.Sunken;
            this.TolMsgInfo.Name = "TolMsgInfo";
            this.TolMsgInfo.Size = new System.Drawing.Size(465, 21);
            this.TolMsgInfo.Spring = true;
            this.TolMsgInfo.Text = "加载成功....";
            this.TolMsgInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TolMenuSaveAS,
            this.TolMenuPrint});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(952, 25);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // TolMenuSaveAS
            // 
            this.TolMenuSaveAS.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TolMenuSaveAS_ALL,
            this.TolMenuSaveAS_Selected});
            this.TolMenuSaveAS.Name = "TolMenuSaveAS";
            this.TolMenuSaveAS.Size = new System.Drawing.Size(68, 21);
            this.TolMenuSaveAS.Text = "报表导出";
            // 
            // TolMenuSaveAS_ALL
            // 
            this.TolMenuSaveAS_ALL.Name = "TolMenuSaveAS_ALL";
            this.TolMenuSaveAS_ALL.Size = new System.Drawing.Size(152, 22);
            this.TolMenuSaveAS_ALL.Text = "1.导出所有项";
            this.TolMenuSaveAS_ALL.Click += new System.EventHandler(this.TolMenuSaveAS_ALL_Click);
            // 
            // TolMenuSaveAS_Selected
            // 
            this.TolMenuSaveAS_Selected.Name = "TolMenuSaveAS_Selected";
            this.TolMenuSaveAS_Selected.Size = new System.Drawing.Size(152, 22);
            this.TolMenuSaveAS_Selected.Text = "2.导出选中项";
            this.TolMenuSaveAS_Selected.Click += new System.EventHandler(this.TolMenuSaveAS_Selected_Click);
            // 
            // TolMenuPrint
            // 
            this.TolMenuPrint.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.PrintTol_List});
            this.TolMenuPrint.Name = "TolMenuPrint";
            this.TolMenuPrint.Size = new System.Drawing.Size(44, 21);
            this.TolMenuPrint.Text = "打印";
            this.TolMenuPrint.Visible = false;
            // 
            // PrintTol_List
            // 
            this.PrintTol_List.Name = "PrintTol_List";
            this.PrintTol_List.Size = new System.Drawing.Size(152, 22);
            this.PrintTol_List.Text = "1.打印列表";
            this.PrintTol_List.Click += new System.EventHandler(this.PrintTol_List_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ListItem_Edit,
            this.ListItem_Delete});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(101, 48);
            // 
            // ListItem_Edit
            // 
            this.ListItem_Edit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ListItem_Edit.Image = global::KPS.Properties.Resources.ItemEdit;
            this.ListItem_Edit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ListItem_Edit.Name = "ListItem_Edit";
            this.ListItem_Edit.Size = new System.Drawing.Size(100, 22);
            this.ListItem_Edit.Text = "编辑";
            this.ListItem_Edit.Click += new System.EventHandler(this.ListItem_Edit_Click);
            // 
            // ListItem_Delete
            // 
            this.ListItem_Delete.Image = global::KPS.Properties.Resources.ItemDel;
            this.ListItem_Delete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ListItem_Delete.Name = "ListItem_Delete";
            this.ListItem_Delete.Size = new System.Drawing.Size(100, 22);
            this.ListItem_Delete.Text = "删除";
            this.ListItem_Delete.Click += new System.EventHandler(this.ListItem_Delete_Click);
            // 
            // listViewPrinter1
            // 
            // 
            // 
            // 
            this.listViewPrinter1.CellFormat.CanWrap = true;
            this.listViewPrinter1.CellFormat.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            // 
            // 
            // 
            this.listViewPrinter1.FooterFormat.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Italic);
            // 
            // 
            // 
            this.listViewPrinter1.GroupHeaderFormat.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold);
            // 
            // 
            // 
            this.listViewPrinter1.HeaderFormat.Font = new System.Drawing.Font("Verdana", 24F);
            this.listViewPrinter1.IsListHeaderOnEachPage = false;
            // 
            // 
            // 
            this.listViewPrinter1.ListHeaderFormat.CanWrap = true;
            this.listViewPrinter1.ListHeaderFormat.Font = new System.Drawing.Font("Verdana", 12F);
            this.listViewPrinter1.Watermark = "";
            // 
            // DataQueryFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(958, 694);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.miniToolStrip;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "DataQueryFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "报表查询";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.DataQueryFrm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.SortpanalBar.ResumeLayout(false);
            this.SortpanalBar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.PanelDevice.ResumeLayout(false);
            this.PanelDevice.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.MenuStrip miniToolStrip;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem TolMenuSaveAS;
        private System.Windows.Forms.ToolStripStatusLabel tolModelInfo;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel TolMsgInfo;
        private System.Windows.Forms.ToolStripMenuItem TolMenuSaveAS_ALL;
        private System.Windows.Forms.ToolStripMenuItem TolMenuSaveAS_Selected;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem ListItem_Edit;
        private System.Windows.Forms.ToolStripMenuItem ListItem_Delete;
        private System.Windows.Forms.Panel PanelDevice;
        private System.Windows.Forms.Label LblDeviceLabel;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel SortpanalBar;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblMatrixbar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox CmboxDeviceClass;
        private System.Windows.Forms.ToolStripMenuItem TolMenuPrint;
        private System.Windows.Forms.ToolStripMenuItem PrintTol_List;
        private BrightIdeasSoftware.ListViewPrinter listViewPrinter1;
    }
}