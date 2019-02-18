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
            this.leSearchList = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.leSearchListView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gcID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcUnitName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcUnitType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcUnitBankUser = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcUnitBankName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcUnitBankNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnCancel = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnOK = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            ((System.ComponentModel.ISupportInitialize)(this.leSearchList.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.leSearchListView)).BeginInit();
            this.SuspendLayout();
            // 
            // leSearchList
            // 
            this.leSearchList.EditValue = "";
            this.leSearchList.Location = new System.Drawing.Point(12, 12);
            this.leSearchList.Name = "leSearchList";
            this.leSearchList.Properties.Appearance.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.leSearchList.Properties.Appearance.Options.UseFont = true;
            this.leSearchList.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.leSearchList.Properties.ShowClearButton = false;
            this.leSearchList.Properties.ShowFooter = false;
            this.leSearchList.Properties.View = this.leSearchListView;
            this.leSearchList.Size = new System.Drawing.Size(476, 38);
            this.leSearchList.TabIndex = 31;
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
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(253, 66);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(65, 39);
            this.btnCancel.StateCommon.Content.ShortText.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCancel.TabIndex = 32;
            this.btnCancel.Values.Text = "取消";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(157, 66);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(65, 39);
            this.btnOK.StateCommon.Content.ShortText.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnOK.TabIndex = 33;
            this.btnOK.Values.Text = "确定";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // UnitExtSelectForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(500, 113);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.leSearchList);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "UnitExtSelectForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "开户帐号选择";
            ((System.ComponentModel.ISupportInitialize)(this.leSearchList.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.leSearchListView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SearchLookUpEdit leSearchList;
        private DevExpress.XtraGrid.Views.Grid.GridView leSearchListView;
        private DevExpress.XtraGrid.Columns.GridColumn gcID;
        private DevExpress.XtraGrid.Columns.GridColumn gcUnitName;
        private DevExpress.XtraGrid.Columns.GridColumn gcUnitType;
        private DevExpress.XtraGrid.Columns.GridColumn gcUnitBankUser;
        private DevExpress.XtraGrid.Columns.GridColumn gcUnitBankName;
        private DevExpress.XtraGrid.Columns.GridColumn gcUnitBankNo;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnCancel;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnOK;
    }
}