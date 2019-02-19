namespace ProjectReporter.Controls
{
    partial class KeTiTianBaoEditor
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tableLayoutPanel15 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnLast = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnSave = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnNext = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.plTitle = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.plContent = new System.Windows.Forms.Panel();
            this.kvKetiTabs = new ComponentFactory.Krypton.Navigator.KryptonNavigator();
            this.kpKetiItems = new ComponentFactory.Krypton.Navigator.KryptonPage();
            this.dgvDetail = new ComponentFactory.Krypton.Toolkit.KryptonDataGridView();
            this.selpersonid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colKeTiMingCheng = new ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn();
            this.colMiJi = new ComponentFactory.Krypton.Toolkit.KryptonDataGridViewComboBoxColumn();
            this.colFuZeRen = new ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn();
            this.colPersonIDCard = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colChengDanDanWeiMingCheng = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colChengDanDanWeiKaiHuXhangHao = new ComponentFactory.Krypton.Toolkit.KryptonDataGridViewButtonColumn();
            this.colNeiRong = new ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn();
            this.colZongTiKeTi = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colMakePage = new ComponentFactory.Krypton.Toolkit.KryptonDataGridViewButtonColumn();
            this.delete = new System.Windows.Forms.DataGridViewImageColumn();
            this.colDetail = new System.Windows.Forms.DataGridViewImageColumn();
            this.tableLayoutPanel15.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.plTitle)).BeginInit();
            this.plTitle.SuspendLayout();
            this.plContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kvKetiTabs)).BeginInit();
            this.kvKetiTabs.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kpKetiItems)).BeginInit();
            this.kpKetiItems.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetail)).BeginInit();
            this.SuspendLayout();
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
            this.tableLayoutPanel15.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel15.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel15.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel15.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel15.Size = new System.Drawing.Size(789, 511);
            this.tableLayoutPanel15.TabIndex = 4;
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
            this.tableLayoutPanel1.Location = new System.Drawing.Point(53, 454);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(683, 34);
            this.tableLayoutPanel1.TabIndex = 6;
            // 
            // btnLast
            // 
            this.btnLast.Location = new System.Drawing.Point(586, 3);
            this.btnLast.Name = "btnLast";
            this.btnLast.Size = new System.Drawing.Size(1, 25);
            this.btnLast.TabIndex = 1;
            this.btnLast.Values.Text = "返回";
            this.btnLast.Visible = false;
            this.btnLast.Click += new System.EventHandler(this.btnLast_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(486, 3);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(90, 25);
            this.btnSave.TabIndex = 0;
            this.btnSave.Values.Text = "保存";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(586, 3);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(90, 25);
            this.btnNext.TabIndex = 2;
            this.btnNext.Values.Text = "下一步";
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // plTitle
            // 
            this.plTitle.Controls.Add(this.label1);
            this.plTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.plTitle.Location = new System.Drawing.Point(50, 20);
            this.plTitle.Margin = new System.Windows.Forms.Padding(0);
            this.plTitle.Name = "plTitle";
            this.plTitle.Size = new System.Drawing.Size(689, 80);
            this.plTitle.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("楷体_GB2312", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(689, 80);
            this.label1.TabIndex = 0;
            this.label1.Text = "围绕如何全面、有效实现项目目标，进行课题分解，明确每个课题的密级，并简述研究内容；项目必须设置一个总体课题，由牵头申报单位承担，课题负责人由项目负责人担任；牵头申" +
    "报单位承担的课题数不超过课题总数的三分之二";
            // 
            // plContent
            // 
            this.plContent.BackColor = System.Drawing.Color.Transparent;
            this.plContent.Controls.Add(this.kvKetiTabs);
            this.plContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.plContent.Location = new System.Drawing.Point(53, 103);
            this.plContent.Name = "plContent";
            this.plContent.Size = new System.Drawing.Size(683, 345);
            this.plContent.TabIndex = 7;
            // 
            // kvKetiTabs
            // 
            this.kvKetiTabs.Button.ButtonDisplayLogic = ComponentFactory.Krypton.Navigator.ButtonDisplayLogic.NextPrevious;
            this.kvKetiTabs.Button.CloseButtonAction = ComponentFactory.Krypton.Navigator.CloseButtonAction.None;
            this.kvKetiTabs.Button.CloseButtonDisplay = ComponentFactory.Krypton.Navigator.ButtonDisplay.Hide;
            this.kvKetiTabs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kvKetiTabs.Location = new System.Drawing.Point(0, 0);
            this.kvKetiTabs.Name = "kvKetiTabs";
            this.kvKetiTabs.Pages.AddRange(new ComponentFactory.Krypton.Navigator.KryptonPage[] {
            this.kpKetiItems});
            this.kvKetiTabs.SelectedIndex = 0;
            this.kvKetiTabs.Size = new System.Drawing.Size(683, 345);
            this.kvKetiTabs.TabIndex = 4;
            // 
            // kpKetiItems
            // 
            this.kpKetiItems.AutoHiddenSlideSize = new System.Drawing.Size(200, 200);
            this.kpKetiItems.Controls.Add(this.dgvDetail);
            this.kpKetiItems.Flags = 65534;
            this.kpKetiItems.LastVisibleSet = true;
            this.kpKetiItems.MinimumSize = new System.Drawing.Size(50, 50);
            this.kpKetiItems.Name = "kpKetiItems";
            this.kpKetiItems.Size = new System.Drawing.Size(681, 318);
            this.kpKetiItems.Text = "课题列表";
            this.kpKetiItems.ToolTipTitle = "Page ToolTip";
            this.kpKetiItems.UniqueName = "E9C2A15C70F847D472B1468CE3270072";
            // 
            // dgvDetail
            // 
            this.dgvDetail.AllowUserToResizeRows = false;
            this.dgvDetail.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            this.dgvDetail.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.selpersonid,
            this.colKeTiMingCheng,
            this.colMiJi,
            this.colFuZeRen,
            this.colPersonIDCard,
            this.colChengDanDanWeiMingCheng,
            this.colChengDanDanWeiKaiHuXhangHao,
            this.colNeiRong,
            this.colZongTiKeTi,
            this.colMakePage,
            this.delete,
            this.colDetail});
            this.dgvDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDetail.Location = new System.Drawing.Point(0, 0);
            this.dgvDetail.MultiSelect = false;
            this.dgvDetail.Name = "dgvDetail";
            dataGridViewCellStyle1.Font = new System.Drawing.Font("仿宋_GB2312", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDetail.RowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvDetail.RowTemplate.Height = 28;
            this.dgvDetail.Size = new System.Drawing.Size(681, 318);
            this.dgvDetail.StateCommon.Background.Color1 = System.Drawing.Color.White;
            this.dgvDetail.StateCommon.BackStyle = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.GridBackgroundList;
            this.dgvDetail.StateCommon.HeaderColumn.Content.Font = new System.Drawing.Font("黑体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dgvDetail.StateCommon.HeaderColumn.Content.TextH = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Center;
            this.dgvDetail.TabIndex = 3;
            this.dgvDetail.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDetail_CellContentClick);
            this.dgvDetail.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dgvDetail_RowsAdded);
            // 
            // selpersonid
            // 
            this.selpersonid.HeaderText = "序号";
            this.selpersonid.Name = "selpersonid";
            this.selpersonid.ReadOnly = true;
            this.selpersonid.Width = 50;
            // 
            // colKeTiMingCheng
            // 
            this.colKeTiMingCheng.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colKeTiMingCheng.HeaderText = "课题名称";
            this.colKeTiMingCheng.Name = "colKeTiMingCheng";
            this.colKeTiMingCheng.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colKeTiMingCheng.Width = 5;
            // 
            // colMiJi
            // 
            this.colMiJi.DropDownWidth = 121;
            this.colMiJi.HeaderText = "密级";
            this.colMiJi.Name = "colMiJi";
            this.colMiJi.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colMiJi.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colMiJi.Width = 50;
            // 
            // colFuZeRen
            // 
            this.colFuZeRen.HeaderText = "负责人";
            this.colFuZeRen.Name = "colFuZeRen";
            this.colFuZeRen.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colFuZeRen.Width = 80;
            // 
            // colPersonIDCard
            // 
            this.colPersonIDCard.HeaderText = "身份证号";
            this.colPersonIDCard.Name = "colPersonIDCard";
            this.colPersonIDCard.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colPersonIDCard.Width = 120;
            // 
            // colChengDanDanWeiMingCheng
            // 
            this.colChengDanDanWeiMingCheng.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colChengDanDanWeiMingCheng.HeaderText = "承担单位名称";
            this.colChengDanDanWeiMingCheng.Name = "colChengDanDanWeiMingCheng";
            // 
            // colChengDanDanWeiKaiHuXhangHao
            // 
            this.colChengDanDanWeiKaiHuXhangHao.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colChengDanDanWeiKaiHuXhangHao.HeaderText = "承担单位开户帐号";
            this.colChengDanDanWeiKaiHuXhangHao.Name = "colChengDanDanWeiKaiHuXhangHao";
            this.colChengDanDanWeiKaiHuXhangHao.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colChengDanDanWeiKaiHuXhangHao.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // colNeiRong
            // 
            this.colNeiRong.HeaderText = "内容";
            this.colNeiRong.Name = "colNeiRong";
            this.colNeiRong.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colNeiRong.Width = 200;
            // 
            // colZongTiKeTi
            // 
            this.colZongTiKeTi.HeaderText = "总体课题";
            this.colZongTiKeTi.Name = "colZongTiKeTi";
            this.colZongTiKeTi.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colZongTiKeTi.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colZongTiKeTi.Width = 76;
            // 
            // colMakePage
            // 
            this.colMakePage.HeaderText = "";
            this.colMakePage.Name = "colMakePage";
            this.colMakePage.ReadOnly = true;
            this.colMakePage.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colMakePage.Text = "生成详细页";
            // 
            // delete
            // 
            this.delete.HeaderText = "删除";
            this.delete.Image = global::ProjectReporter.Properties.Resources.DELETE_16;
            this.delete.Name = "delete";
            this.delete.ReadOnly = true;
            this.delete.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.delete.Width = 45;
            // 
            // colDetail
            // 
            this.colDetail.HeaderText = "详细";
            this.colDetail.Image = global::ProjectReporter.Properties.Resources.exclamation_16;
            this.colDetail.Name = "colDetail";
            this.colDetail.ReadOnly = true;
            this.colDetail.Visible = false;
            this.colDetail.Width = 45;
            // 
            // KeTiTianBaoEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel15);
            this.Name = "KeTiTianBaoEditor";
            this.Size = new System.Drawing.Size(789, 511);
            this.tableLayoutPanel15.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.plTitle)).EndInit();
            this.plTitle.ResumeLayout(false);
            this.plContent.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kvKetiTabs)).EndInit();
            this.kvKetiTabs.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kpKetiItems)).EndInit();
            this.kpKetiItems.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetail)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel15;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnLast;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnSave;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnNext;
        private ComponentFactory.Krypton.Toolkit.KryptonPanel plTitle;
        private System.Windows.Forms.Panel plContent;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridView dgvDetail;
        private System.Windows.Forms.Label label1;
        private ComponentFactory.Krypton.Navigator.KryptonNavigator kvKetiTabs;
        private ComponentFactory.Krypton.Navigator.KryptonPage kpKetiItems;
        private System.Windows.Forms.DataGridViewTextBoxColumn selpersonid;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn colKeTiMingCheng;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridViewComboBoxColumn colMiJi;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn colFuZeRen;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPersonIDCard;
        private System.Windows.Forms.DataGridViewTextBoxColumn colChengDanDanWeiMingCheng;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridViewButtonColumn colChengDanDanWeiKaiHuXhangHao;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn colNeiRong;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colZongTiKeTi;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridViewButtonColumn colMakePage;
        private System.Windows.Forms.DataGridViewImageColumn delete;
        private System.Windows.Forms.DataGridViewImageColumn colDetail;
    }
}
