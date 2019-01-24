namespace ProjectReporter.Forms
{
    partial class ZipImportForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.lbmsg = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.btnConfirm = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.kryptonPanel1 = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.pbar = new System.Windows.Forms.ProgressBar();
            this.lbcontinue = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.btnCancel = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lbmsg
            // 
            this.lbmsg.Location = new System.Drawing.Point(99, 56);
            this.lbmsg.Name = "lbmsg";
            this.lbmsg.Size = new System.Drawing.Size(10, 20);
            this.lbmsg.TabIndex = 9;
            this.lbmsg.Values.Text = "    ";
            // 
            // btnConfirm
            // 
            this.btnConfirm.Location = new System.Drawing.Point(177, 58);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(90, 25);
            this.btnConfirm.TabIndex = 6;
            this.btnConfirm.Values.Text = "确定";
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.pbar);
            this.kryptonPanel1.Controls.Add(this.lbmsg);
            this.kryptonPanel1.Controls.Add(this.btnConfirm);
            this.kryptonPanel1.Controls.Add(this.lbcontinue);
            this.kryptonPanel1.Controls.Add(this.btnCancel);
            this.kryptonPanel1.Controls.Add(this.pictureBox1);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Size = new System.Drawing.Size(375, 90);
            this.kryptonPanel1.StateCommon.Color1 = System.Drawing.Color.White;
            this.kryptonPanel1.StateCommon.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.SolidAllLine;
            this.kryptonPanel1.TabIndex = 1;
            // 
            // pbar
            // 
            this.pbar.Location = new System.Drawing.Point(95, 27);
            this.pbar.Name = "pbar";
            this.pbar.Size = new System.Drawing.Size(268, 23);
            this.pbar.TabIndex = 1;
            this.pbar.Visible = false;
            // 
            // lbcontinue
            // 
            this.lbcontinue.Location = new System.Drawing.Point(95, 8);
            this.lbcontinue.Name = "lbcontinue";
            this.lbcontinue.Size = new System.Drawing.Size(265, 20);
            this.lbcontinue.TabIndex = 8;
            this.lbcontinue.Values.Text = "导入申请将会清空系统中当前数据，是否继续?";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(273, 58);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(90, 25);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Values.Text = "取消";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.pictureBox1.Image = global::ProjectReporter.Properties.Resources.Import_128;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(86, 90);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // ZipImportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(375, 90);
            this.Controls.Add(this.kryptonPanel1);
            this.Name = "ZipImportForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ZipImportForm";
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            this.kryptonPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonLabel lbmsg;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnConfirm;
        private ComponentFactory.Krypton.Toolkit.KryptonPanel kryptonPanel1;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel lbcontinue;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnCancel;
        private System.Windows.Forms.ProgressBar pbar;
        private System.Windows.Forms.PictureBox pictureBox1;

    }
}