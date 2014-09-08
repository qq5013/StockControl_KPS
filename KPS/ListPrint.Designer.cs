namespace KPS
{
    partial class ListPrint
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ListPrint));
            this.panel1 = new System.Windows.Forms.Panel();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.PrintMenus = new System.Windows.Forms.MenuStrip();
            this.TolMenuPrint = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1.SuspendLayout();
            this.PrintMenus.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = global::KPS.Properties.Resources.MainBgImg_V02;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Controls.Add(this.webBrowser1);
            this.panel1.Controls.Add(this.PrintMenus);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 24);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(814, 573);
            this.panel1.TabIndex = 0;
            // 
            // webBrowser1
            // 
            this.webBrowser1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowser1.Location = new System.Drawing.Point(0, 25);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(814, 548);
            this.webBrowser1.TabIndex = 1;
            // 
            // PrintMenus
            // 
            this.PrintMenus.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TolMenuPrint});
            this.PrintMenus.Location = new System.Drawing.Point(0, 0);
            this.PrintMenus.Name = "PrintMenus";
            this.PrintMenus.Size = new System.Drawing.Size(814, 25);
            this.PrintMenus.TabIndex = 0;
            this.PrintMenus.Text = "menuStrip1";
            // 
            // TolMenuPrint
            // 
            this.TolMenuPrint.Name = "TolMenuPrint";
            this.TolMenuPrint.Size = new System.Drawing.Size(44, 21);
            this.TolMenuPrint.Text = "打印";
            this.TolMenuPrint.Click += new System.EventHandler(this.TolMenuPrint_Click);
            // 
            // ListPrint
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(820, 600);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.PrintMenus;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(820, 600);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(820, 600);
            this.Name = "ListPrint";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "打印效果预览";
            this.Load += new System.EventHandler(this.ListPrint_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.PrintMenus.ResumeLayout(false);
            this.PrintMenus.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.WebBrowser webBrowser1;
        private System.Windows.Forms.MenuStrip PrintMenus;
        private System.Windows.Forms.ToolStripMenuItem TolMenuPrint;
    }
}