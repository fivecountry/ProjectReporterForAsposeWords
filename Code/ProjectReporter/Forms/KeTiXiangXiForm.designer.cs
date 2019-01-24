namespace ProjectReporter.Forms
{
    partial class KeTiXiangXiForm
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
            this.freEditor = new ProjectReporter.Controls.RTFTextEditor();
            this.SuspendLayout();
            // 
            // freEditor
            // 
            this.freEditor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.freEditor.EnabledLastButton = false;
            this.freEditor.EnabledNextButton = false;
            this.freEditor.EnabledSaveButton = true;
            this.freEditor.Location = new System.Drawing.Point(0, 0);
            this.freEditor.Name = "freEditor";
            this.freEditor.ParentForm = null;
            this.freEditor.RTFEditorNameKey = "feUI";
            this.freEditor.RTFFileFirstName = "rtpinput_";
            this.freEditor.Size = new System.Drawing.Size(917, 624);
            this.freEditor.TabIndex = 0;
            this.freEditor.TitleLabelText = "研究目标、研究内容、关键技术及研究思路（详细说明课题包含的关键技术及研究思路）、承担单位与负责人（涉密课题的承担单位必须具有与课题密级相应的保密资质）等";
            this.freEditor.SaveEvent += new ProjectReporter.Controls.SaveOrLastOrNextEventDelegate(this.freEditor_SaveEvent);
            // 
            // KeTiXiangXiForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(917, 624);
            this.Controls.Add(this.freEditor);
            this.DoubleBuffered = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "KeTiXiangXiForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "课题X详情";
            this.ResumeLayout(false);

        }

        #endregion

        private ProjectReporter.Controls.RTFTextEditor freEditor;
    }
}