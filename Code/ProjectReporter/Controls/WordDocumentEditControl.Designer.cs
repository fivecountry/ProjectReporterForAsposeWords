namespace ProjectReporter.Controls
{
    partial class WordDocumentEditControl
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

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.plContent = new System.Windows.Forms.Panel();
            this.tableLayoutPanel20 = new ProjectReporter.Controls.HSkinTableLayoutPanel();
            this.btnComsel = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.kryptonLabel67 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.lbcomattpath = new ComponentFactory.Krypton.Toolkit.KryptonLinkLabel();
            this.txtWordContent = new System.Windows.Forms.RichTextBox();
            this.ofdUpload = new System.Windows.Forms.OpenFileDialog();
            this.plContent.SuspendLayout();
            this.tableLayoutPanel20.SuspendLayout();
            this.SuspendLayout();
            // 
            // plContent
            // 
            this.plContent.BackColor = System.Drawing.Color.Transparent;
            this.plContent.Controls.Add(this.txtWordContent);
            this.plContent.Controls.Add(this.tableLayoutPanel20);
            this.plContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.plContent.Location = new System.Drawing.Point(0, 0);
            this.plContent.Name = "plContent";
            this.plContent.Size = new System.Drawing.Size(1018, 529);
            this.plContent.TabIndex = 8;
            // 
            // tableLayoutPanel20
            // 
            this.tableLayoutPanel20.BorderColor = System.Drawing.Color.Black;
            this.tableLayoutPanel20.ColumnCount = 3;
            this.tableLayoutPanel20.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel20.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel20.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableLayoutPanel20.Controls.Add(this.btnComsel, 2, 0);
            this.tableLayoutPanel20.Controls.Add(this.kryptonLabel67, 0, 0);
            this.tableLayoutPanel20.Controls.Add(this.lbcomattpath, 1, 0);
            this.tableLayoutPanel20.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel20.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel20.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.tableLayoutPanel20.Name = "tableLayoutPanel20";
            this.tableLayoutPanel20.RowCount = 1;
            this.tableLayoutPanel20.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel20.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel20.Size = new System.Drawing.Size(1018, 44);
            this.tableLayoutPanel20.TabIndex = 5;
            // 
            // btnComsel
            // 
            this.btnComsel.Location = new System.Drawing.Point(871, 3);
            this.btnComsel.Name = "btnComsel";
            this.btnComsel.Size = new System.Drawing.Size(82, 34);
            this.btnComsel.TabIndex = 5;
            this.btnComsel.Values.Text = "上传附件";
            this.btnComsel.Click += new System.EventHandler(this.btnComsel_Click);
            // 
            // kryptonLabel67
            // 
            this.kryptonLabel67.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonLabel67.Location = new System.Drawing.Point(3, 3);
            this.kryptonLabel67.Name = "kryptonLabel67";
            this.kryptonLabel67.Size = new System.Drawing.Size(54, 38);
            this.kryptonLabel67.StateCommon.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.kryptonLabel67.TabIndex = 1;
            this.kryptonLabel67.Values.Text = "附件";
            // 
            // lbcomattpath
            // 
            this.lbcomattpath.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbcomattpath.Location = new System.Drawing.Point(63, 3);
            this.lbcomattpath.Name = "lbcomattpath";
            this.lbcomattpath.Size = new System.Drawing.Size(802, 38);
            this.lbcomattpath.StateCommon.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lbcomattpath.TabIndex = 8;
            this.lbcomattpath.Values.Text = "0";
            this.lbcomattpath.LinkClicked += new System.EventHandler(this.lbcomattpath_LinkClicked);
            // 
            // txtWordContent
            // 
            this.txtWordContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtWordContent.Location = new System.Drawing.Point(0, 44);
            this.txtWordContent.Name = "txtWordContent";
            this.txtWordContent.Size = new System.Drawing.Size(1018, 485);
            this.txtWordContent.TabIndex = 6;
            this.txtWordContent.Text = "";
            // 
            // ofdUpload
            // 
            this.ofdUpload.Filter = "DOC文件|*.doc|DOCX文件|*.docx";
            // 
            // WordDocumentEditControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.plContent);
            this.Name = "WordDocumentEditControl";
            this.Size = new System.Drawing.Size(1018, 529);
            this.plContent.ResumeLayout(false);
            this.tableLayoutPanel20.ResumeLayout(false);
            this.tableLayoutPanel20.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel plContent;
        private HSkinTableLayoutPanel tableLayoutPanel20;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnComsel;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel67;
        private ComponentFactory.Krypton.Toolkit.KryptonLinkLabel lbcomattpath;
        private System.Windows.Forms.RichTextBox txtWordContent;
        private System.Windows.Forms.OpenFileDialog ofdUpload;
    }
}
