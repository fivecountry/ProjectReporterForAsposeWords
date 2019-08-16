namespace ProjectReporter.Forms
{
    partial class ProjectForm
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
            this.plContent = new DevExpress.XtraEditors.PanelControl();
            this.plButtons = new DevExpress.XtraEditors.PanelControl();
            this.tvProject = new System.Windows.Forms.TreeView();
            this.btnOpen = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnLoad = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.ofdSelect = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.plContent)).BeginInit();
            this.plContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.plButtons)).BeginInit();
            this.plButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // plContent
            // 
            this.plContent.Controls.Add(this.tvProject);
            this.plContent.Controls.Add(this.plButtons);
            this.plContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.plContent.Location = new System.Drawing.Point(0, 0);
            this.plContent.Name = "plContent";
            this.plContent.Size = new System.Drawing.Size(685, 576);
            this.plContent.TabIndex = 9;
            // 
            // plButtons
            // 
            this.plButtons.Controls.Add(this.btnLoad);
            this.plButtons.Controls.Add(this.btnOpen);
            this.plButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.plButtons.Location = new System.Drawing.Point(2, 538);
            this.plButtons.Name = "plButtons";
            this.plButtons.Size = new System.Drawing.Size(681, 36);
            this.plButtons.TabIndex = 7;
            // 
            // tvProject
            // 
            this.tvProject.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvProject.Font = new System.Drawing.Font("宋体", 14.25F);
            this.tvProject.FullRowSelect = true;
            this.tvProject.HideSelection = false;
            this.tvProject.Location = new System.Drawing.Point(2, 2);
            this.tvProject.Name = "tvProject";
            this.tvProject.Size = new System.Drawing.Size(681, 536);
            this.tvProject.TabIndex = 8;
            // 
            // btnOpen
            // 
            this.btnOpen.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnOpen.Location = new System.Drawing.Point(604, 2);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(75, 32);
            this.btnOpen.StateCommon.Content.LongText.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnOpen.StateCommon.Content.ShortText.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnOpen.TabIndex = 29;
            this.btnOpen.Values.Text = "打开";
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // btnLoad
            // 
            this.btnLoad.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnLoad.Location = new System.Drawing.Point(529, 2);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(75, 32);
            this.btnLoad.StateCommon.Content.LongText.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnLoad.StateCommon.Content.ShortText.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnLoad.TabIndex = 30;
            this.btnLoad.Values.Text = "导入";
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // ofdSelect
            // 
            this.ofdSelect.Filter = "Zip压缩文件(*.zip)|*.zip";
            // 
            // ProjectForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(685, 576);
            this.Controls.Add(this.plContent);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ProjectForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "项目管理";
            ((System.ComponentModel.ISupportInitialize)(this.plContent)).EndInit();
            this.plContent.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.plButtons)).EndInit();
            this.plButtons.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl plContent;
        private DevExpress.XtraEditors.PanelControl plButtons;
        private System.Windows.Forms.TreeView tvProject;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnOpen;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnLoad;
        private System.Windows.Forms.OpenFileDialog ofdSelect;
    }
}