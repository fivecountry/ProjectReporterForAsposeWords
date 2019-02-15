namespace ProjectReporter.Forms
{
    partial class UnitAndUnitExtSelectForm
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
            this.lueUnitList = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.searchLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gcID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcUnitName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcUnitType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcUnitBankUser = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcUnitBankName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcUnitBankNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcFlagName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcNormalName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcAddress = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcContactName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcTelphone = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcIsUserAdded = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcSecret = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnOK = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnCancel = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            ((System.ComponentModel.ISupportInitialize)(this.lueUnitList.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).BeginInit();
            this.SuspendLayout();
            // 
            // lueUnitList
            // 
            this.lueUnitList.Location = new System.Drawing.Point(12, 12);
            this.lueUnitList.Name = "lueUnitList";
            this.lueUnitList.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.lueUnitList.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueUnitList.Properties.ShowClearButton = false;
            this.lueUnitList.Properties.ShowFooter = false;
            this.lueUnitList.Properties.View = this.searchLookUpEdit1View;
            this.lueUnitList.Size = new System.Drawing.Size(432, 18);
            this.lueUnitList.TabIndex = 13;
            // 
            // searchLookUpEdit1View
            // 
            this.searchLookUpEdit1View.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gcID,
            this.gcUnitName,
            this.gcUnitType,
            this.gcUnitBankUser,
            this.gcUnitBankName,
            this.gcUnitBankNo,
            this.gcFlagName,
            this.gcNormalName,
            this.gcAddress,
            this.gcContactName,
            this.gcTelphone,
            this.gcIsUserAdded,
            this.gcSecret});
            this.searchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.searchLookUpEdit1View.Name = "searchLookUpEdit1View";
            this.searchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.searchLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // gcID
            // 
            this.gcID.Caption = "ID";
            this.gcID.FieldName = "ID";
            this.gcID.Name = "gcID";
            this.gcID.Visible = true;
            this.gcID.VisibleIndex = 0;
            // 
            // gcUnitName
            // 
            this.gcUnitName.Caption = "单位名称";
            this.gcUnitName.FieldName = "UnitName";
            this.gcUnitName.Name = "gcUnitName";
            this.gcUnitName.Visible = true;
            this.gcUnitName.VisibleIndex = 1;
            // 
            // gcUnitType
            // 
            this.gcUnitType.Caption = "单位类型";
            this.gcUnitType.FieldName = "UnitType";
            this.gcUnitType.Name = "gcUnitType";
            this.gcUnitType.Visible = true;
            this.gcUnitType.VisibleIndex = 2;
            // 
            // gcUnitBankUser
            // 
            this.gcUnitBankUser.Caption = "开户名称";
            this.gcUnitBankUser.FieldName = "UnitBankUser";
            this.gcUnitBankUser.Name = "gcUnitBankUser";
            this.gcUnitBankUser.Visible = true;
            this.gcUnitBankUser.VisibleIndex = 3;
            // 
            // gcUnitBankName
            // 
            this.gcUnitBankName.Caption = "开户行";
            this.gcUnitBankName.FieldName = "UnitBankName";
            this.gcUnitBankName.Name = "gcUnitBankName";
            this.gcUnitBankName.Visible = true;
            this.gcUnitBankName.VisibleIndex = 4;
            // 
            // gcUnitBankNo
            // 
            this.gcUnitBankNo.Caption = "银行帐号";
            this.gcUnitBankNo.FieldName = "UnitBankNo";
            this.gcUnitBankNo.Name = "gcUnitBankNo";
            this.gcUnitBankNo.Visible = true;
            this.gcUnitBankNo.VisibleIndex = 5;
            // 
            // gcFlagName
            // 
            this.gcFlagName.Caption = "公章名称";
            this.gcFlagName.FieldName = "FlagName";
            this.gcFlagName.Name = "gcFlagName";
            this.gcFlagName.Visible = true;
            this.gcFlagName.VisibleIndex = 6;
            // 
            // gcNormalName
            // 
            this.gcNormalName.Caption = "常用名称";
            this.gcNormalName.FieldName = "NormalName";
            this.gcNormalName.Name = "gcNormalName";
            this.gcNormalName.Visible = true;
            this.gcNormalName.VisibleIndex = 7;
            // 
            // gcAddress
            // 
            this.gcAddress.Caption = "通信地址";
            this.gcAddress.FieldName = "Address";
            this.gcAddress.Name = "gcAddress";
            this.gcAddress.Visible = true;
            this.gcAddress.VisibleIndex = 8;
            // 
            // gcContactName
            // 
            this.gcContactName.Caption = "联系人";
            this.gcContactName.FieldName = "ContactName";
            this.gcContactName.Name = "gcContactName";
            this.gcContactName.Visible = true;
            this.gcContactName.VisibleIndex = 9;
            // 
            // gcTelphone
            // 
            this.gcTelphone.Caption = "联系电话";
            this.gcTelphone.FieldName = "Telphone";
            this.gcTelphone.Name = "gcTelphone";
            this.gcTelphone.Visible = true;
            this.gcTelphone.VisibleIndex = 10;
            // 
            // gcIsUserAdded
            // 
            this.gcIsUserAdded.Caption = "用户自定义";
            this.gcIsUserAdded.FieldName = "IsUserAdded";
            this.gcIsUserAdded.Name = "gcIsUserAdded";
            this.gcIsUserAdded.Visible = true;
            this.gcIsUserAdded.VisibleIndex = 11;
            // 
            // gcSecret
            // 
            this.gcSecret.Caption = "保密资质";
            this.gcSecret.FieldName = "Secret";
            this.gcSecret.Name = "gcSecret";
            this.gcSecret.Visible = true;
            this.gcSecret.VisibleIndex = 12;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(128, 40);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(65, 25);
            this.btnOK.TabIndex = 14;
            this.btnOK.Values.Text = "确定";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(224, 40);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(65, 25);
            this.btnCancel.TabIndex = 14;
            this.btnCancel.Values.Text = "取消";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // UnitAndUnitExtSelectForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(460, 71);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.lueUnitList);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "UnitAndUnitExtSelectForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "单位选择";
            ((System.ComponentModel.ISupportInitialize)(this.lueUnitList.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SearchLookUpEdit lueUnitList;
        private DevExpress.XtraGrid.Views.Grid.GridView searchLookUpEdit1View;
        private DevExpress.XtraGrid.Columns.GridColumn gcID;
        private DevExpress.XtraGrid.Columns.GridColumn gcUnitName;
        private DevExpress.XtraGrid.Columns.GridColumn gcUnitType;
        private DevExpress.XtraGrid.Columns.GridColumn gcUnitBankUser;
        private DevExpress.XtraGrid.Columns.GridColumn gcUnitBankName;
        private DevExpress.XtraGrid.Columns.GridColumn gcUnitBankNo;
        private DevExpress.XtraGrid.Columns.GridColumn gcFlagName;
        private DevExpress.XtraGrid.Columns.GridColumn gcNormalName;
        private DevExpress.XtraGrid.Columns.GridColumn gcAddress;
        private DevExpress.XtraGrid.Columns.GridColumn gcContactName;
        private DevExpress.XtraGrid.Columns.GridColumn gcTelphone;
        private DevExpress.XtraGrid.Columns.GridColumn gcIsUserAdded;
        private DevExpress.XtraGrid.Columns.GridColumn gcSecret;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnOK;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnCancel;
    }
}