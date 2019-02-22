namespace ProjectReporter.Forms
{
    partial class UnitExtSelectForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.dgvDetail = new ComponentFactory.Krypton.Toolkit.KryptonDataGridView();
            this.selpersonid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colName = new ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn();
            this.colType = new ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn();
            this.colBankUserName = new ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn();
            this.colBankName = new ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn();
            this.colBankNo = new ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn();
            this.colUserAddeds = new ComponentFactory.Krypton.Toolkit.KryptonDataGridViewCheckBoxColumn();
            this.delete = new System.Windows.Forms.DataGridViewImageColumn();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.leSearchList = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.leSearchListView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gcID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcUnitName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcUnitType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcUnitBankUser = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcUnitBankName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcUnitBankNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnAdd = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnEdit = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.leSearchList.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.leSearchListView)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.dgvDetail);
            this.panelControl1.Controls.Add(this.panelControl2);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(1084, 504);
            this.panelControl1.TabIndex = 0;
            // 
            // dgvDetail
            // 
            this.dgvDetail.AllowUserToAddRows = false;
            this.dgvDetail.AllowUserToResizeRows = false;
            this.dgvDetail.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            this.dgvDetail.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.selpersonid,
            this.colName,
            this.colType,
            this.colBankUserName,
            this.colBankName,
            this.colBankNo,
            this.colUserAddeds,
            this.delete});
            this.dgvDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDetail.Location = new System.Drawing.Point(2, 44);
            this.dgvDetail.MultiSelect = false;
            this.dgvDetail.Name = "dgvDetail";
            this.dgvDetail.ReadOnly = true;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("仿宋_GB2312", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDetail.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvDetail.RowTemplate.Height = 28;
            this.dgvDetail.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDetail.Size = new System.Drawing.Size(1080, 458);
            this.dgvDetail.StateCommon.Background.Color1 = System.Drawing.Color.White;
            this.dgvDetail.StateCommon.BackStyle = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.GridBackgroundList;
            this.dgvDetail.StateCommon.HeaderColumn.Content.Font = new System.Drawing.Font("黑体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dgvDetail.StateCommon.HeaderColumn.Content.TextH = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Center;
            this.dgvDetail.TabIndex = 5;
            this.dgvDetail.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDetail_CellContentClick);
            this.dgvDetail.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDetail_CellContentDoubleClick);
            this.dgvDetail.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDetail_CellEndEdit);
            this.dgvDetail.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dgvDetail_RowsAdded);
            // 
            // selpersonid
            // 
            this.selpersonid.HeaderText = "序号";
            this.selpersonid.Name = "selpersonid";
            this.selpersonid.ReadOnly = true;
            this.selpersonid.Width = 50;
            // 
            // colName
            // 
            this.colName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colName.HeaderText = "单位名称";
            this.colName.Name = "colName";
            this.colName.ReadOnly = true;
            this.colName.Visible = false;
            this.colName.Width = 187;
            // 
            // colType
            // 
            this.colType.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colType.HeaderText = "类型";
            this.colType.Name = "colType";
            this.colType.ReadOnly = true;
            this.colType.Visible = false;
            this.colType.Width = 100;
            // 
            // colBankUserName
            // 
            this.colBankUserName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colBankUserName.HeaderText = "开户名称";
            this.colBankUserName.Name = "colBankUserName";
            this.colBankUserName.ReadOnly = true;
            this.colBankUserName.Visible = false;
            this.colBankUserName.Width = 187;
            // 
            // colBankName
            // 
            this.colBankName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colBankName.HeaderText = "开户行";
            this.colBankName.Name = "colBankName";
            this.colBankName.ReadOnly = true;
            this.colBankName.Width = 423;
            // 
            // colBankNo
            // 
            this.colBankNo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colBankNo.HeaderText = "帐户";
            this.colBankNo.Name = "colBankNo";
            this.colBankNo.ReadOnly = true;
            this.colBankNo.Width = 423;
            // 
            // colUserAddeds
            // 
            this.colUserAddeds.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.NullValue = false;
            this.colUserAddeds.DefaultCellStyle = dataGridViewCellStyle3;
            this.colUserAddeds.FalseValue = null;
            this.colUserAddeds.HeaderText = "用户自定义";
            this.colUserAddeds.IndeterminateValue = null;
            this.colUserAddeds.Name = "colUserAddeds";
            this.colUserAddeds.ReadOnly = true;
            this.colUserAddeds.TrueValue = null;
            this.colUserAddeds.Width = 98;
            // 
            // delete
            // 
            this.delete.HeaderText = "删除";
            this.delete.Name = "delete";
            this.delete.ReadOnly = true;
            this.delete.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.delete.Width = 45;
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.leSearchList);
            this.panelControl2.Controls.Add(this.btnAdd);
            this.panelControl2.Controls.Add(this.btnEdit);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl2.Location = new System.Drawing.Point(2, 2);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(1080, 42);
            this.panelControl2.TabIndex = 6;
            // 
            // leSearchList
            // 
            this.leSearchList.EditValue = "";
            this.leSearchList.Location = new System.Drawing.Point(39, 12);
            this.leSearchList.Name = "leSearchList";
            this.leSearchList.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.leSearchList.Properties.ShowFooter = false;
            this.leSearchList.Properties.View = this.leSearchListView;
            this.leSearchList.Size = new System.Drawing.Size(515, 20);
            this.leSearchList.TabIndex = 29;
            this.leSearchList.EditValueChanged += new System.EventHandler(this.leSearchList_EditValueChanged);
            // 
            // leSearchListView
            // 
            this.leSearchListView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gcID,
            this.gcUnitName,
            this.gcUnitType,
            this.gcUnitBankUser,
            this.gcUnitBankName,
            this.gcUnitBankNo});
            this.leSearchListView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.leSearchListView.Name = "leSearchListView";
            this.leSearchListView.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.leSearchListView.OptionsView.ShowGroupPanel = false;
            // 
            // gcID
            // 
            this.gcID.FieldName = "ID";
            this.gcID.Name = "gcID";
            // 
            // gcUnitName
            // 
            this.gcUnitName.Caption = "单位名称";
            this.gcUnitName.FieldName = "UnitName";
            this.gcUnitName.Name = "gcUnitName";
            // 
            // gcUnitType
            // 
            this.gcUnitType.Caption = "单位类型";
            this.gcUnitType.FieldName = "UnitType";
            this.gcUnitType.Name = "gcUnitType";
            // 
            // gcUnitBankUser
            // 
            this.gcUnitBankUser.Caption = "开户名称";
            this.gcUnitBankUser.FieldName = "UnitBankUser";
            this.gcUnitBankUser.Name = "gcUnitBankUser";
            // 
            // gcUnitBankName
            // 
            this.gcUnitBankName.Caption = "开户行名称";
            this.gcUnitBankName.FieldName = "UnitBankName";
            this.gcUnitBankName.Name = "gcUnitBankName";
            this.gcUnitBankName.Visible = true;
            this.gcUnitBankName.VisibleIndex = 0;
            // 
            // gcUnitBankNo
            // 
            this.gcUnitBankNo.Caption = "账号";
            this.gcUnitBankNo.FieldName = "UnitBankNo";
            this.gcUnitBankNo.Name = "gcUnitBankNo";
            this.gcUnitBankNo.Visible = true;
            this.gcUnitBankNo.VisibleIndex = 1;
            // 
            // btnAdd
            // 
            this.btnAdd.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnAdd.Location = new System.Drawing.Point(898, 2);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(90, 38);
            this.btnAdd.StateCommon.Content.LongText.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnAdd.StateCommon.Content.ShortText.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnAdd.TabIndex = 28;
            this.btnAdd.Values.Text = "添加";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnEdit.Location = new System.Drawing.Point(988, 2);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(90, 38);
            this.btnEdit.StateCommon.Content.LongText.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnEdit.StateCommon.Content.ShortText.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnEdit.TabIndex = 27;
            this.btnEdit.Values.Text = "编辑";
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // UnitExtSelectForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1084, 504);
            this.Controls.Add(this.panelControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "UnitExtSelectForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "单位选择";
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.leSearchList.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.leSearchListView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridView dgvDetail;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnEdit;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnAdd;
        private DevExpress.XtraEditors.SearchLookUpEdit leSearchList;
        private DevExpress.XtraGrid.Views.Grid.GridView leSearchListView;
        private DevExpress.XtraGrid.Columns.GridColumn gcUnitName;
        private DevExpress.XtraGrid.Columns.GridColumn gcUnitType;
        private DevExpress.XtraGrid.Columns.GridColumn gcUnitBankUser;
        private DevExpress.XtraGrid.Columns.GridColumn gcUnitBankName;
        private DevExpress.XtraGrid.Columns.GridColumn gcUnitBankNo;
        private DevExpress.XtraGrid.Columns.GridColumn gcID;
        private System.Windows.Forms.DataGridViewTextBoxColumn selpersonid;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn colName;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn colType;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn colBankUserName;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn colBankName;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridViewTextBoxColumn colBankNo;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridViewCheckBoxColumn colUserAddeds;
        private System.Windows.Forms.DataGridViewImageColumn delete;
    }
}