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
            this.ofdUpload = new System.Windows.Forms.OpenFileDialog();
            this.tableLayoutPanel20 = new ProjectReporter.Controls.HSkinTableLayoutPanel();
            this.kryptonLabel67 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.lblDocPath = new ComponentFactory.Krypton.Toolkit.KryptonLinkLabel();
            this.btnUploadDoc = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnNewDoc = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.tableLayoutPanel20.SuspendLayout();
            this.SuspendLayout();
            // 
            // ofdUpload
            // 
            this.ofdUpload.Filter = "DOC文件|*.doc|DOCX文件|*.docx";
            // 
            // tableLayoutPanel20
            // 
            this.tableLayoutPanel20.BorderColor = System.Drawing.Color.Black;
            this.tableLayoutPanel20.ColumnCount = 4;
            this.tableLayoutPanel20.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel20.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel20.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 90F));
            this.tableLayoutPanel20.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 90F));
            this.tableLayoutPanel20.Controls.Add(this.kryptonLabel67, 0, 0);
            this.tableLayoutPanel20.Controls.Add(this.lblDocPath, 1, 0);
            this.tableLayoutPanel20.Controls.Add(this.btnUploadDoc, 3, 0);
            this.tableLayoutPanel20.Controls.Add(this.btnNewDoc, 2, 0);
            this.tableLayoutPanel20.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel20.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel20.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.tableLayoutPanel20.Name = "tableLayoutPanel20";
            this.tableLayoutPanel20.RowCount = 1;
            this.tableLayoutPanel20.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel20.Size = new System.Drawing.Size(1018, 45);
            this.tableLayoutPanel20.TabIndex = 5;
            // 
            // kryptonLabel67
            // 
            this.kryptonLabel67.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonLabel67.Location = new System.Drawing.Point(3, 3);
            this.kryptonLabel67.Name = "kryptonLabel67";
            this.kryptonLabel67.Size = new System.Drawing.Size(54, 39);
            this.kryptonLabel67.StateCommon.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.kryptonLabel67.TabIndex = 1;
            this.kryptonLabel67.Values.Text = "附件";
            // 
            // lblDocPath
            // 
            this.lblDocPath.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDocPath.Location = new System.Drawing.Point(63, 0);
            this.lblDocPath.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.lblDocPath.Name = "lblDocPath";
            this.lblDocPath.Size = new System.Drawing.Size(772, 45);
            this.lblDocPath.StateCommon.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDocPath.TabIndex = 8;
            this.lblDocPath.Values.Text = "0";
            this.lblDocPath.LinkClicked += new System.EventHandler(this.lblDocPath_LinkClicked);
            // 
            // btnUploadDoc
            // 
            this.btnUploadDoc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnUploadDoc.Location = new System.Drawing.Point(931, 3);
            this.btnUploadDoc.Name = "btnUploadDoc";
            this.btnUploadDoc.Size = new System.Drawing.Size(84, 39);
            this.btnUploadDoc.TabIndex = 5;
            this.btnUploadDoc.Values.Text = "上传文档";
            this.btnUploadDoc.Click += new System.EventHandler(this.btnUploadDoc_Click);
            // 
            // btnNewDoc
            // 
            this.btnNewDoc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnNewDoc.Location = new System.Drawing.Point(841, 3);
            this.btnNewDoc.Name = "btnNewDoc";
            this.btnNewDoc.Size = new System.Drawing.Size(84, 39);
            this.btnNewDoc.TabIndex = 5;
            this.btnNewDoc.Values.Text = "新建文档";
            this.btnNewDoc.Click += new System.EventHandler(this.btnNewDoc_Click);
            // 
            // WordDocumentEditControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel20);
            this.Name = "WordDocumentEditControl";
            this.Size = new System.Drawing.Size(1018, 529);
            this.tableLayoutPanel20.ResumeLayout(false);
            this.tableLayoutPanel20.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private HSkinTableLayoutPanel tableLayoutPanel20;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnUploadDoc;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel67;
        private ComponentFactory.Krypton.Toolkit.KryptonLinkLabel lblDocPath;
        private System.Windows.Forms.OpenFileDialog ofdUpload;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnNewDoc;
    }
}