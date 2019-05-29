namespace ProjectReporter.Controls
{
    partial class FuZeRenEditor
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tableLayoutPanel15 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnLast = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnSave = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnNext = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.plTitle = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.plContent = new System.Windows.Forms.Panel();
            this.dgvDetail = new ComponentFactory.Krypton.Toolkit.KryptonDataGridView();
            this.selpersonid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colXingMing = new ComponentFactory.Krypton.Toolkit.KryptonDataGridViewComboBoxColumn();
            this.colXingBie = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colChuShengNianYue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colZhiWuMingCheng = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colZuoJI = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colShouJi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.delete = new System.Windows.Forms.DataGridViewImageColumn();
            this.tableLayoutPanel15.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.plTitle)).BeginInit();
            this.plTitle.SuspendLayout();
            this.plContent.SuspendLayout();
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
            this.tableLayoutPanel15.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel15.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel15.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel15.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel15.Size = new System.Drawing.Size(923, 562);
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
            this.tableLayoutPanel1.Location = new System.Drawing.Point(53, 505);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(817, 34);
            this.tableLayoutPanel1.TabIndex = 6;
            // 
            // btnLast
            // 
            this.btnLast.Location = new System.Drawing.Point(720, 3);
            this.btnLast.Name = "btnLast";
            this.btnLast.Size = new System.Drawing.Size(1, 25);
            this.btnLast.TabIndex = 1;
            this.btnLast.Values.Text = "返回";
            this.btnLast.Visible = false;
            this.btnLast.Click += new System.EventHandler(this.btnLast_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(620, 3);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(90, 25);
            this.btnSave.TabIndex = 0;
            this.btnSave.Values.Text = "保存";
            this.btnSave.Visible = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(720, 3);
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
            this.plTitle.Location = new System.Drawing.Point(54, 20);
            this.plTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.plTitle.Name = "plTitle";
            this.plTitle.Padding = new System.Windows.Forms.Padding(6, 0, 0, 0);
            this.plTitle.Size = new System.Drawing.Size(815, 30);
            this.plTitle.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("楷体_GB2312", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(809, 30);
            this.label1.TabIndex = 0;
            this.label1.Text = "项目负责人";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // plContent
            // 
            this.plContent.BackColor = System.Drawing.Color.Transparent;
            this.plContent.Controls.Add(this.dgvDetail);
            this.plContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.plContent.Location = new System.Drawing.Point(53, 53);
            this.plContent.Name = "plContent";
            this.plContent.Size = new System.Drawing.Size(817, 446);
            this.plContent.TabIndex = 7;
            // 
            // dgvDetail
            // 
            this.dgvDetail.AllowUserToAddRows = false;
            this.dgvDetail.AllowUserToDeleteRows = false;
            this.dgvDetail.AllowUserToResizeRows = false;
            this.dgvDetail.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            this.dgvDetail.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.selpersonid,
            this.colXingMing,
            this.colXingBie,
            this.colChuShengNianYue,
            this.colZhiWuMingCheng,
            this.colZuoJI,
            this.colShouJi,
            this.delete});
            this.dgvDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDetail.Location = new System.Drawing.Point(0, 0);
            this.dgvDetail.MultiSelect = false;
            this.dgvDetail.Name = "dgvDetail";
            dataGridViewCellStyle2.Font = new System.Drawing.Font("仿宋_GB2312", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDetail.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvDetail.RowTemplate.Height = 28;
            this.dgvDetail.Size = new System.Drawing.Size(817, 446);
            this.dgvDetail.StateCommon.Background.Color1 = System.Drawing.Color.White;
            this.dgvDetail.StateCommon.BackStyle = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.GridBackgroundList;
            this.dgvDetail.StateCommon.HeaderColumn.Content.Font = new System.Drawing.Font("黑体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dgvDetail.StateCommon.HeaderColumn.Content.TextH = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Center;
            this.dgvDetail.TabIndex = 3;
            this.dgvDetail.CellParsing += new System.Windows.Forms.DataGridViewCellParsingEventHandler(this.dgvDetail_CellParsing);
            this.dgvDetail.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dgvDetail_RowsAdded);
            // 
            // selpersonid
            // 
            this.selpersonid.HeaderText = "序号";
            this.selpersonid.Name = "selpersonid";
            this.selpersonid.ReadOnly = true;
            this.selpersonid.Width = 80;
            // 
            // colXingMing
            // 
            this.colXingMing.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colXingMing.DropDownWidth = 121;
            this.colXingMing.HeaderText = "姓名(身份证号)";
            this.colXingMing.Name = "colXingMing";
            this.colXingMing.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colXingMing.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colXingMing.Width = 149;
            // 
            // colXingBie
            // 
            this.colXingBie.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colXingBie.HeaderText = "性别";
            this.colXingBie.Name = "colXingBie";
            this.colXingBie.ReadOnly = true;
            // 
            // colChuShengNianYue
            // 
            this.colChuShengNianYue.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colChuShengNianYue.HeaderText = "出生年月";
            this.colChuShengNianYue.Name = "colChuShengNianYue";
            this.colChuShengNianYue.ReadOnly = true;
            // 
            // colZhiWuMingCheng
            // 
            this.colZhiWuMingCheng.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colZhiWuMingCheng.HeaderText = "职务职称";
            this.colZhiWuMingCheng.Name = "colZhiWuMingCheng";
            this.colZhiWuMingCheng.ReadOnly = true;
            // 
            // colZuoJI
            // 
            this.colZuoJI.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colZuoJI.HeaderText = "座机";
            this.colZuoJI.Name = "colZuoJI";
            this.colZuoJI.ReadOnly = true;
            // 
            // colShouJi
            // 
            this.colShouJi.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colShouJi.HeaderText = "手机";
            this.colShouJi.Name = "colShouJi";
            this.colShouJi.ReadOnly = true;
            // 
            // delete
            // 
            this.delete.HeaderText = "删除";
            this.delete.Name = "delete";
            this.delete.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.delete.Visible = false;
            this.delete.Width = 45;
            // 
            // FuZeRenEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel15);
            this.Name = "FuZeRenEditor";
            this.Size = new System.Drawing.Size(923, 562);
            this.tableLayoutPanel15.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.plTitle)).EndInit();
            this.plTitle.ResumeLayout(false);
            this.plContent.ResumeLayout(false);
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
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel plContent;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridView dgvDetail;
        private System.Windows.Forms.DataGridViewTextBoxColumn selpersonid;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridViewComboBoxColumn colXingMing;
        private System.Windows.Forms.DataGridViewTextBoxColumn colXingBie;
        private System.Windows.Forms.DataGridViewTextBoxColumn colChuShengNianYue;
        private System.Windows.Forms.DataGridViewTextBoxColumn colZhiWuMingCheng;
        private System.Windows.Forms.DataGridViewTextBoxColumn colZuoJI;
        private System.Windows.Forms.DataGridViewTextBoxColumn colShouJi;
        private System.Windows.Forms.DataGridViewImageColumn delete;
    }
}
