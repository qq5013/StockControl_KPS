namespace KPS
{
    partial class ConfirmFrm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConfirmFrm));
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.picState = new System.Windows.Forms.PictureBox();
            this.lblTipDetail = new System.Windows.Forms.Label();
            this.panel7 = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnQuery = new System.Windows.Forms.Button();
            this.panel5 = new System.Windows.Forms.Panel();
            this.TipTypeImgList = new System.Windows.Forms.ImageList(this.components);
            this.panel4.SuspendLayout();
            this.panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picState)).BeginInit();
            this.panel7.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel4
            // 
            this.panel4.BackgroundImage = global::KPS.Properties.Resources.MainBgImg_V02;
            this.panel4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel4.Controls.Add(this.panel6);
            this.panel4.Controls.Add(this.panel7);
            this.panel4.Controls.Add(this.panel5);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(3, 24);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(367, 191);
            this.panel4.TabIndex = 0;
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.Transparent;
            this.panel6.Controls.Add(this.picState);
            this.panel6.Controls.Add(this.lblTipDetail);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel6.Location = new System.Drawing.Point(0, 21);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(367, 110);
            this.panel6.TabIndex = 3;
            // 
            // picState
            // 
            this.picState.Location = new System.Drawing.Point(12, 38);
            this.picState.Name = "picState";
            this.picState.Size = new System.Drawing.Size(32, 32);
            this.picState.TabIndex = 1;
            this.picState.TabStop = false;
            // 
            // lblTipDetail
            // 
            this.lblTipDetail.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblTipDetail.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblTipDetail.Location = new System.Drawing.Point(53, 3);
            this.lblTipDetail.Name = "lblTipDetail";
            this.lblTipDetail.Size = new System.Drawing.Size(311, 104);
            this.lblTipDetail.TabIndex = 0;
            this.lblTipDetail.Text = "  您的试用申请已成功提交，请您注意查收邮件以激活系统，谢谢!";
            this.lblTipDetail.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.Transparent;
            this.panel7.Controls.Add(this.btnCancel);
            this.panel7.Controls.Add(this.btnQuery);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel7.Location = new System.Drawing.Point(0, 131);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(367, 60);
            this.panel7.TabIndex = 2;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(263, 11);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 34);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "取 消";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnQuery
            // 
            this.btnQuery.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnQuery.Location = new System.Drawing.Point(182, 11);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(75, 34);
            this.btnQuery.TabIndex = 0;
            this.btnQuery.Text = "确 定";
            this.btnQuery.UseVisualStyleBackColor = true;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.Transparent;
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(367, 21);
            this.panel5.TabIndex = 0;
            // 
            // TipTypeImgList
            // 
            this.TipTypeImgList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("TipTypeImgList.ImageStream")));
            this.TipTypeImgList.TransparentColor = System.Drawing.Color.Transparent;
            this.TipTypeImgList.Images.SetKeyName(0, "Tip1.png");
            this.TipTypeImgList.Images.SetKeyName(1, "Tip2.png");
            this.TipTypeImgList.Images.SetKeyName(2, "Tip3.png");
            this.TipTypeImgList.Images.SetKeyName(3, "Tip4.png");
            this.TipTypeImgList.Images.SetKeyName(4, "Tip5.png");
            // 
            // ConfirmFrm
            // 
            this.ClientSize = new System.Drawing.Size(373, 218);
            this.Controls.Add(this.panel4);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximizeBoxSize = new System.Drawing.Size(0, 0);
            this.MaximumSize = new System.Drawing.Size(373, 218);
            this.MinimizeBox = false;
            this.MinimizeBoxSize = new System.Drawing.Size(0, 0);
            this.MinimumSize = new System.Drawing.Size(373, 218);
            this.Name = "ConfirmFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "提示";
            this.panel4.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picState)).EndInit();
            this.panel7.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.PictureBox picState;
        private System.Windows.Forms.Label lblTipDetail;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnQuery;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.ImageList TipTypeImgList;
    }
}