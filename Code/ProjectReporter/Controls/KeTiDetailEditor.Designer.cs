﻿namespace ProjectReporter.Controls
{
    partial class KeTiDetailEditor
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
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.knKetiDetailTabs = new ComponentFactory.Krypton.Navigator.KryptonNavigator();
            this.kpInfo = new ComponentFactory.Krypton.Navigator.KryptonPage();
            this.txtInfo = new ProjectReporter.Controls.RichTextBoxTableClass();
            this.kpDest = new ComponentFactory.Krypton.Navigator.KryptonPage();
            this.txtDest = new ProjectReporter.Controls.RichTextBoxTableClass();
            this.kpContent = new ComponentFactory.Krypton.Navigator.KryptonPage();
            this.txtContent = new ProjectReporter.Controls.RichTextBoxTableClass();
            this.kpNeed = new ComponentFactory.Krypton.Navigator.KryptonPage();
            this.txtNeed = new ProjectReporter.Controls.RichTextBoxTableClass();
            this.tableLayoutPanel15 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnLast = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnSave = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnNext = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.plTitle = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.plContent = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.knKetiDetailTabs)).BeginInit();
            this.knKetiDetailTabs.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kpInfo)).BeginInit();
            this.kpInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kpDest)).BeginInit();
            this.kpDest.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kpContent)).BeginInit();
            this.kpContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kpNeed)).BeginInit();
            this.kpNeed.SuspendLayout();
            this.tableLayoutPanel15.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.plTitle)).BeginInit();
            this.plTitle.SuspendLayout();
            this.plContent.SuspendLayout();
            this.SuspendLayout();
            // 
            // knKetiDetailTabs
            // 
            this.knKetiDetailTabs.Button.ButtonDisplayLogic = ComponentFactory.Krypton.Navigator.ButtonDisplayLogic.None;
            this.knKetiDetailTabs.Button.CloseButtonAction = ComponentFactory.Krypton.Navigator.CloseButtonAction.None;
            this.knKetiDetailTabs.Button.CloseButtonDisplay = ComponentFactory.Krypton.Navigator.ButtonDisplay.Hide;
            this.knKetiDetailTabs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.knKetiDetailTabs.Location = new System.Drawing.Point(0, 0);
            this.knKetiDetailTabs.Name = "knKetiDetailTabs";
            this.knKetiDetailTabs.Pages.AddRange(new ComponentFactory.Krypton.Navigator.KryptonPage[] {
            this.kpInfo,
            this.kpDest,
            this.kpContent,
            this.kpNeed});
            this.knKetiDetailTabs.SelectedIndex = 0;
            this.knKetiDetailTabs.Size = new System.Drawing.Size(752, 336);
            this.knKetiDetailTabs.TabIndex = 0;
            this.knKetiDetailTabs.Text = "kryptonNavigator1";
            // 
            // kpInfo
            // 
            this.kpInfo.AutoHiddenSlideSize = new System.Drawing.Size(200, 200);
            this.kpInfo.Controls.Add(this.txtInfo);
            this.kpInfo.Flags = 65534;
            this.kpInfo.LastVisibleSet = true;
            this.kpInfo.MinimumSize = new System.Drawing.Size(50, 50);
            this.kpInfo.Name = "kpInfo";
            this.kpInfo.Size = new System.Drawing.Size(750, 309);
            this.kpInfo.Text = "简述";
            this.kpInfo.ToolTipTitle = "Page ToolTip";
            this.kpInfo.UniqueName = "480A3E3DB4644E2359A73CEE17D437D9";
            // 
            // txtInfo
            // 
            this.txtInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtInfo.Location = new System.Drawing.Point(0, 0);
            this.txtInfo.Name = "txtInfo";
            this.txtInfo.Size = new System.Drawing.Size(750, 309);
            this.txtInfo.TabIndex = 0;
            this.txtInfo.Text = "";
            // 
            // kpDest
            // 
            this.kpDest.AutoHiddenSlideSize = new System.Drawing.Size(200, 200);
            this.kpDest.Controls.Add(this.txtDest);
            this.kpDest.Flags = 65534;
            this.kpDest.LastVisibleSet = true;
            this.kpDest.MinimumSize = new System.Drawing.Size(50, 50);
            this.kpDest.Name = "kpDest";
            this.kpDest.Size = new System.Drawing.Size(750, 309);
            this.kpDest.Text = "研究目标";
            this.kpDest.ToolTipTitle = "Page ToolTip";
            this.kpDest.UniqueName = "A7C07E934B1F414E99B2655E2A0D8ECC";
            // 
            // txtDest
            // 
            this.txtDest.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtDest.Location = new System.Drawing.Point(0, 0);
            this.txtDest.Name = "txtDest";
            this.txtDest.Size = new System.Drawing.Size(750, 309);
            this.txtDest.TabIndex = 1;
            this.txtDest.Text = "";
            // 
            // kpContent
            // 
            this.kpContent.AutoHiddenSlideSize = new System.Drawing.Size(200, 200);
            this.kpContent.Controls.Add(this.txtContent);
            this.kpContent.Flags = 65534;
            this.kpContent.LastVisibleSet = true;
            this.kpContent.MinimumSize = new System.Drawing.Size(50, 50);
            this.kpContent.Name = "kpContent";
            this.kpContent.Size = new System.Drawing.Size(750, 309);
            this.kpContent.Text = "研究内容";
            this.kpContent.ToolTipTitle = "Page ToolTip";
            this.kpContent.UniqueName = "D7C9060B093A424227B510727F20F652";
            // 
            // txtContent
            // 
            this.txtContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtContent.Location = new System.Drawing.Point(0, 0);
            this.txtContent.Name = "txtContent";
            this.txtContent.Size = new System.Drawing.Size(750, 309);
            this.txtContent.TabIndex = 1;
            this.txtContent.Text = "";
            // 
            // kpNeed
            // 
            this.kpNeed.AutoHiddenSlideSize = new System.Drawing.Size(200, 200);
            this.kpNeed.Controls.Add(this.txtNeed);
            this.kpNeed.Flags = 65534;
            this.kpNeed.LastVisibleSet = true;
            this.kpNeed.MinimumSize = new System.Drawing.Size(50, 50);
            this.kpNeed.Name = "kpNeed";
            this.kpNeed.Size = new System.Drawing.Size(750, 309);
            this.kpNeed.Text = "关键技术及研究思路";
            this.kpNeed.ToolTipTitle = "Page ToolTip";
            this.kpNeed.UniqueName = "C96959D95BED456940AB08FF33E3497B";
            // 
            // txtNeed
            // 
            this.txtNeed.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtNeed.Location = new System.Drawing.Point(0, 0);
            this.txtNeed.Name = "txtNeed";
            this.txtNeed.Size = new System.Drawing.Size(750, 309);
            this.txtNeed.TabIndex = 1;
            this.txtNeed.Text = "";
            // 
            // tableLayoutPanel15
            // 
            this.tableLayoutPanel15.ColumnCount = 3;
            this.tableLayoutPanel15.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel15.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel15.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel15.Controls.Add(this.tableLayoutPanel1, 1, 3);
            this.tableLayoutPanel15.Controls.Add(this.plTitle, 1, 1);
            this.tableLayoutPanel15.Controls.Add(this.plContent, 1, 2);
            this.tableLayoutPanel15.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel15.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel15.Name = "tableLayoutPanel15";
            this.tableLayoutPanel15.RowCount = 5;
            this.tableLayoutPanel15.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel15.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel15.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel15.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel15.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel15.Size = new System.Drawing.Size(858, 502);
            this.tableLayoutPanel15.TabIndex = 5;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 0F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.Controls.Add(this.btnLast, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnSave, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnNext, 3, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(53, 445);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(752, 34);
            this.tableLayoutPanel1.TabIndex = 6;
            // 
            // btnLast
            // 
            this.btnLast.Location = new System.Drawing.Point(655, 3);
            this.btnLast.Name = "btnLast";
            this.btnLast.Size = new System.Drawing.Size(1, 25);
            this.btnLast.TabIndex = 1;
            this.btnLast.Values.Text = "返回";
            this.btnLast.Visible = false;
            this.btnLast.Click += new System.EventHandler(this.btnLast_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(555, 3);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(90, 25);
            this.btnSave.TabIndex = 0;
            this.btnSave.Values.Text = "保存";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(655, 3);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(90, 25);
            this.btnNext.TabIndex = 2;
            this.btnNext.Values.Text = "下一步";
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // plTitle
            // 
            this.plTitle.Controls.Add(this.lblTitle);
            this.plTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.plTitle.Location = new System.Drawing.Point(50, 20);
            this.plTitle.Margin = new System.Windows.Forms.Padding(0);
            this.plTitle.Name = "plTitle";
            this.plTitle.Size = new System.Drawing.Size(758, 80);
            this.plTitle.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitle.Font = new System.Drawing.Font("楷体_GB2312", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(758, 80);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = ".............";
            // 
            // plContent
            // 
            this.plContent.BackColor = System.Drawing.Color.Transparent;
            this.plContent.Controls.Add(this.knKetiDetailTabs);
            this.plContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.plContent.Location = new System.Drawing.Point(53, 103);
            this.plContent.Name = "plContent";
            this.plContent.Size = new System.Drawing.Size(752, 336);
            this.plContent.TabIndex = 7;
            // 
            // KeTiDetailEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel15);
            this.Name = "KeTiDetailEditor";
            this.Size = new System.Drawing.Size(858, 502);
            ((System.ComponentModel.ISupportInitialize)(this.knKetiDetailTabs)).EndInit();
            this.knKetiDetailTabs.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kpInfo)).EndInit();
            this.kpInfo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kpDest)).EndInit();
            this.kpDest.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kpContent)).EndInit();
            this.kpContent.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kpNeed)).EndInit();
            this.kpNeed.ResumeLayout(false);
            this.tableLayoutPanel15.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.plTitle)).EndInit();
            this.plTitle.ResumeLayout(false);
            this.plContent.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private ComponentFactory.Krypton.Navigator.KryptonNavigator knKetiDetailTabs;
        private ComponentFactory.Krypton.Navigator.KryptonPage kpInfo;
        private ComponentFactory.Krypton.Navigator.KryptonPage kpDest;
        private ComponentFactory.Krypton.Navigator.KryptonPage kpContent;
        private ComponentFactory.Krypton.Navigator.KryptonPage kpNeed;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel15;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnLast;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnSave;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnNext;
        private ComponentFactory.Krypton.Toolkit.KryptonPanel plTitle;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel plContent;
        private RichTextBoxTableClass txtInfo;
        private RichTextBoxTableClass txtDest;
        private RichTextBoxTableClass txtContent;
        private RichTextBoxTableClass txtNeed;
    }
}