using ComponentFactory.Krypton.Toolkit;
namespace ProjectReporter.Controls
{
	partial class NewProjectEditor
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
            this.btnReport = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnSave = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.plContent = new System.Windows.Forms.Panel();
            this.hSkinTableLayoutPanel1 = new ProjectReporter.Controls.HSkinTableLayoutPanel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.txtContactName = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel11 = new System.Windows.Forms.Panel();
            this.txtTotalMoney = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.panel12 = new System.Windows.Forms.Panel();
            this.txtTelphone = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.panel10 = new System.Windows.Forms.Panel();
            this.txtProjectName = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.panel9 = new System.Windows.Forms.Panel();
            this.txtTotalTime = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.panel5 = new System.Windows.Forms.Panel();
            this.txtFlagName = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.panel7 = new System.Windows.Forms.Panel();
            this.txtAddress = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.panel8 = new System.Windows.Forms.Panel();
            this.txtNormalName = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.leSearchList = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.leSearchListView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gcID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcUnitName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcUnitType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcUnitBankUser = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcUnitBankName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcUnitBankNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.label17 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cbxSecret = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.txtKeyWords = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.panel6 = new System.Windows.Forms.Panel();
            this.cbxPersonList = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.label15 = new System.Windows.Forms.Label();
            this.plLeftTitle = new System.Windows.Forms.Panel();
            this.lblLeftTitle = new System.Windows.Forms.Label();
            this.plTop = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.lblTopTitle = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.plMain = new System.Windows.Forms.Panel();
            this.plBottom = new System.Windows.Forms.Panel();
            this.plContent.SuspendLayout();
            this.hSkinTableLayoutPanel1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel11.SuspendLayout();
            this.panel12.SuspendLayout();
            this.panel10.SuspendLayout();
            this.panel9.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel8.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.leSearchList.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.leSearchListView)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbxSecret)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbxPersonList)).BeginInit();
            this.plLeftTitle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.plTop)).BeginInit();
            this.plTop.SuspendLayout();
            this.plMain.SuspendLayout();
            this.plBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnReport
            // 
            this.btnReport.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnReport.Location = new System.Drawing.Point(1136, 0);
            this.btnReport.Margin = new System.Windows.Forms.Padding(3, 8, 3, 3);
            this.btnReport.Name = "btnReport";
            this.btnReport.Size = new System.Drawing.Size(90, 44);
            this.btnReport.TabIndex = 2;
            this.btnReport.Values.Text = "下一页";
            this.btnReport.Click += new System.EventHandler(this.btnReport_Click);
            // 
            // btnSave
            // 
            this.btnSave.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnSave.Location = new System.Drawing.Point(1046, 0);
            this.btnSave.Margin = new System.Windows.Forms.Padding(3, 8, 3, 3);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(90, 44);
            this.btnSave.TabIndex = 2;
            this.btnSave.Values.Text = "保存";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // plContent
            // 
            this.plContent.BackColor = System.Drawing.Color.Transparent;
            this.plContent.Controls.Add(this.hSkinTableLayoutPanel1);
            this.plContent.Controls.Add(this.plLeftTitle);
            this.plContent.Dock = System.Windows.Forms.DockStyle.Top;
            this.plContent.Location = new System.Drawing.Point(0, 100);
            this.plContent.Name = "plContent";
            this.plContent.Size = new System.Drawing.Size(1226, 436);
            this.plContent.TabIndex = 2;
            // 
            // hSkinTableLayoutPanel1
            // 
            this.hSkinTableLayoutPanel1.BorderColor = System.Drawing.Color.Black;
            this.hSkinTableLayoutPanel1.ColumnCount = 5;
            this.hSkinTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.04542F));
            this.hSkinTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 21.06813F));
            this.hSkinTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 24.95633F));
            this.hSkinTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.97379F));
            this.hSkinTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 24.95633F));
            this.hSkinTableLayoutPanel1.Controls.Add(this.panel4, 1, 4);
            this.hSkinTableLayoutPanel1.Controls.Add(this.label3, 0, 4);
            this.hSkinTableLayoutPanel1.Controls.Add(this.panel11, 4, 7);
            this.hSkinTableLayoutPanel1.Controls.Add(this.panel12, 4, 4);
            this.hSkinTableLayoutPanel1.Controls.Add(this.panel10, 1, 0);
            this.hSkinTableLayoutPanel1.Controls.Add(this.panel9, 1, 7);
            this.hSkinTableLayoutPanel1.Controls.Add(this.panel5, 1, 2);
            this.hSkinTableLayoutPanel1.Controls.Add(this.panel7, 1, 5);
            this.hSkinTableLayoutPanel1.Controls.Add(this.panel8, 1, 3);
            this.hSkinTableLayoutPanel1.Controls.Add(this.panel2, 1, 1);
            this.hSkinTableLayoutPanel1.Controls.Add(this.label17, 0, 7);
            this.hSkinTableLayoutPanel1.Controls.Add(this.label11, 0, 0);
            this.hSkinTableLayoutPanel1.Controls.Add(this.label12, 0, 1);
            this.hSkinTableLayoutPanel1.Controls.Add(this.label13, 0, 2);
            this.hSkinTableLayoutPanel1.Controls.Add(this.label14, 0, 3);
            this.hSkinTableLayoutPanel1.Controls.Add(this.label16, 0, 5);
            this.hSkinTableLayoutPanel1.Controls.Add(this.label18, 3, 0);
            this.hSkinTableLayoutPanel1.Controls.Add(this.label19, 3, 4);
            this.hSkinTableLayoutPanel1.Controls.Add(this.label20, 3, 7);
            this.hSkinTableLayoutPanel1.Controls.Add(this.panel1, 4, 0);
            this.hSkinTableLayoutPanel1.Controls.Add(this.label2, 3, 1);
            this.hSkinTableLayoutPanel1.Controls.Add(this.panel3, 4, 1);
            this.hSkinTableLayoutPanel1.Controls.Add(this.panel6, 1, 6);
            this.hSkinTableLayoutPanel1.Controls.Add(this.label15, 0, 6);
            this.hSkinTableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.hSkinTableLayoutPanel1.Location = new System.Drawing.Point(80, 0);
            this.hSkinTableLayoutPanel1.Name = "hSkinTableLayoutPanel1";
            this.hSkinTableLayoutPanel1.RowCount = 8;
            this.hSkinTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.49952F));
            this.hSkinTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.49953F));
            this.hSkinTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.49953F));
            this.hSkinTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.49953F));
            this.hSkinTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.49953F));
            this.hSkinTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.49953F));
            this.hSkinTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.50328F));
            this.hSkinTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.49953F));
            this.hSkinTableLayoutPanel1.Size = new System.Drawing.Size(1146, 436);
            this.hSkinTableLayoutPanel1.TabIndex = 1;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.White;
            this.hSkinTableLayoutPanel1.SetColumnSpan(this.panel4, 2);
            this.panel4.Controls.Add(this.txtContactName);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(161, 217);
            this.panel4.Margin = new System.Windows.Forms.Padding(1);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(524, 52);
            this.panel4.TabIndex = 10;
            // 
            // txtContactName
            // 
            this.txtContactName.AlwaysActive = false;
            this.txtContactName.Location = new System.Drawing.Point(10, 10);
            this.txtContactName.Name = "txtContactName";
            this.txtContactName.Size = new System.Drawing.Size(496, 29);
            this.txtContactName.StateActive.Content.Padding = new System.Windows.Forms.Padding(0);
            this.txtContactName.StateCommon.Content.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtContactName.StateCommon.Content.Padding = new System.Windows.Forms.Padding(0);
            this.txtContactName.StateDisabled.Content.Padding = new System.Windows.Forms.Padding(0);
            this.txtContactName.StateNormal.Content.Padding = new System.Windows.Forms.Padding(0);
            this.txtContactName.TabIndex = 15;
            // 
            // label3
            // 
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(3, 216);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(154, 54);
            this.label3.TabIndex = 9;
            this.label3.Text = "联系人：";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panel11
            // 
            this.panel11.BackColor = System.Drawing.Color.White;
            this.panel11.Controls.Add(this.txtTotalMoney);
            this.panel11.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel11.Location = new System.Drawing.Point(858, 379);
            this.panel11.Margin = new System.Windows.Forms.Padding(1);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(287, 56);
            this.panel11.TabIndex = 7;
            // 
            // txtTotalMoney
            // 
            this.txtTotalMoney.AlwaysActive = false;
            this.txtTotalMoney.Location = new System.Drawing.Point(10, 14);
            this.txtTotalMoney.Name = "txtTotalMoney";
            this.txtTotalMoney.Size = new System.Drawing.Size(268, 29);
            this.txtTotalMoney.StateActive.Content.Padding = new System.Windows.Forms.Padding(0);
            this.txtTotalMoney.StateCommon.Content.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtTotalMoney.StateCommon.Content.Padding = new System.Windows.Forms.Padding(0);
            this.txtTotalMoney.StateDisabled.Content.Padding = new System.Windows.Forms.Padding(0);
            this.txtTotalMoney.StateNormal.Content.Padding = new System.Windows.Forms.Padding(0);
            this.txtTotalMoney.TabIndex = 15;
            // 
            // panel12
            // 
            this.panel12.BackColor = System.Drawing.Color.White;
            this.panel12.Controls.Add(this.txtTelphone);
            this.panel12.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel12.Location = new System.Drawing.Point(858, 217);
            this.panel12.Margin = new System.Windows.Forms.Padding(1);
            this.panel12.Name = "panel12";
            this.panel12.Size = new System.Drawing.Size(287, 52);
            this.panel12.TabIndex = 8;
            // 
            // txtTelphone
            // 
            this.txtTelphone.AlwaysActive = false;
            this.txtTelphone.Location = new System.Drawing.Point(10, 11);
            this.txtTelphone.Name = "txtTelphone";
            this.txtTelphone.Size = new System.Drawing.Size(268, 29);
            this.txtTelphone.StateActive.Content.Padding = new System.Windows.Forms.Padding(0);
            this.txtTelphone.StateCommon.Content.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtTelphone.StateCommon.Content.Padding = new System.Windows.Forms.Padding(0);
            this.txtTelphone.StateDisabled.Content.Padding = new System.Windows.Forms.Padding(0);
            this.txtTelphone.StateNormal.Content.Padding = new System.Windows.Forms.Padding(0);
            this.txtTelphone.TabIndex = 15;
            // 
            // panel10
            // 
            this.panel10.BackColor = System.Drawing.Color.White;
            this.hSkinTableLayoutPanel1.SetColumnSpan(this.panel10, 2);
            this.panel10.Controls.Add(this.txtProjectName);
            this.panel10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel10.Location = new System.Drawing.Point(161, 1);
            this.panel10.Margin = new System.Windows.Forms.Padding(1);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(524, 52);
            this.panel10.TabIndex = 6;
            // 
            // txtProjectName
            // 
            this.txtProjectName.AlwaysActive = false;
            this.txtProjectName.Location = new System.Drawing.Point(10, 11);
            this.txtProjectName.Name = "txtProjectName";
            this.txtProjectName.Size = new System.Drawing.Size(496, 29);
            this.txtProjectName.StateActive.Content.Padding = new System.Windows.Forms.Padding(0);
            this.txtProjectName.StateCommon.Content.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtProjectName.StateCommon.Content.Padding = new System.Windows.Forms.Padding(0);
            this.txtProjectName.StateDisabled.Content.Padding = new System.Windows.Forms.Padding(0);
            this.txtProjectName.StateNormal.Content.Padding = new System.Windows.Forms.Padding(0);
            this.txtProjectName.TabIndex = 15;
            // 
            // panel9
            // 
            this.panel9.BackColor = System.Drawing.Color.White;
            this.hSkinTableLayoutPanel1.SetColumnSpan(this.panel9, 2);
            this.panel9.Controls.Add(this.txtTotalTime);
            this.panel9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel9.Location = new System.Drawing.Point(161, 379);
            this.panel9.Margin = new System.Windows.Forms.Padding(1);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(524, 56);
            this.panel9.TabIndex = 9;
            // 
            // txtTotalTime
            // 
            this.txtTotalTime.AlwaysActive = false;
            this.txtTotalTime.Location = new System.Drawing.Point(10, 14);
            this.txtTotalTime.Name = "txtTotalTime";
            this.txtTotalTime.Size = new System.Drawing.Size(496, 29);
            this.txtTotalTime.StateActive.Content.Padding = new System.Windows.Forms.Padding(0);
            this.txtTotalTime.StateCommon.Content.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtTotalTime.StateCommon.Content.Padding = new System.Windows.Forms.Padding(0);
            this.txtTotalTime.StateDisabled.Content.Padding = new System.Windows.Forms.Padding(0);
            this.txtTotalTime.StateNormal.Content.Padding = new System.Windows.Forms.Padding(0);
            this.txtTotalTime.TabIndex = 15;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.White;
            this.hSkinTableLayoutPanel1.SetColumnSpan(this.panel5, 4);
            this.panel5.Controls.Add(this.txtFlagName);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(161, 109);
            this.panel5.Margin = new System.Windows.Forms.Padding(1);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(984, 52);
            this.panel5.TabIndex = 5;
            // 
            // txtFlagName
            // 
            this.txtFlagName.AlwaysActive = false;
            this.txtFlagName.Location = new System.Drawing.Point(10, 11);
            this.txtFlagName.Name = "txtFlagName";
            this.txtFlagName.Size = new System.Drawing.Size(965, 29);
            this.txtFlagName.StateActive.Content.Padding = new System.Windows.Forms.Padding(0);
            this.txtFlagName.StateCommon.Content.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtFlagName.StateCommon.Content.Padding = new System.Windows.Forms.Padding(0);
            this.txtFlagName.StateDisabled.Content.Padding = new System.Windows.Forms.Padding(0);
            this.txtFlagName.StateNormal.Content.Padding = new System.Windows.Forms.Padding(0);
            this.txtFlagName.TabIndex = 15;
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.White;
            this.hSkinTableLayoutPanel1.SetColumnSpan(this.panel7, 4);
            this.panel7.Controls.Add(this.txtAddress);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel7.Location = new System.Drawing.Point(161, 271);
            this.panel7.Margin = new System.Windows.Forms.Padding(1);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(984, 52);
            this.panel7.TabIndex = 7;
            // 
            // txtAddress
            // 
            this.txtAddress.AlwaysActive = false;
            this.txtAddress.Location = new System.Drawing.Point(10, 12);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(965, 29);
            this.txtAddress.StateActive.Content.Padding = new System.Windows.Forms.Padding(0);
            this.txtAddress.StateCommon.Content.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtAddress.StateCommon.Content.Padding = new System.Windows.Forms.Padding(0);
            this.txtAddress.StateDisabled.Content.Padding = new System.Windows.Forms.Padding(0);
            this.txtAddress.StateNormal.Content.Padding = new System.Windows.Forms.Padding(0);
            this.txtAddress.TabIndex = 15;
            // 
            // panel8
            // 
            this.panel8.BackColor = System.Drawing.Color.White;
            this.hSkinTableLayoutPanel1.SetColumnSpan(this.panel8, 4);
            this.panel8.Controls.Add(this.txtNormalName);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel8.Location = new System.Drawing.Point(161, 163);
            this.panel8.Margin = new System.Windows.Forms.Padding(1);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(984, 52);
            this.panel8.TabIndex = 8;
            // 
            // txtNormalName
            // 
            this.txtNormalName.AlwaysActive = false;
            this.txtNormalName.Location = new System.Drawing.Point(10, 11);
            this.txtNormalName.Name = "txtNormalName";
            this.txtNormalName.Size = new System.Drawing.Size(965, 29);
            this.txtNormalName.StateActive.Content.Padding = new System.Windows.Forms.Padding(0);
            this.txtNormalName.StateCommon.Content.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtNormalName.StateCommon.Content.Padding = new System.Windows.Forms.Padding(0);
            this.txtNormalName.StateDisabled.Content.Padding = new System.Windows.Forms.Padding(0);
            this.txtNormalName.StateNormal.Content.Padding = new System.Windows.Forms.Padding(0);
            this.txtNormalName.TabIndex = 15;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.hSkinTableLayoutPanel1.SetColumnSpan(this.panel2, 2);
            this.panel2.Controls.Add(this.leSearchList);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(161, 55);
            this.panel2.Margin = new System.Windows.Forms.Padding(1);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(524, 52);
            this.panel2.TabIndex = 18;
            // 
            // leSearchList
            // 
            this.leSearchList.EditValue = "";
            this.leSearchList.Location = new System.Drawing.Point(10, 10);
            this.leSearchList.Name = "leSearchList";
            this.leSearchList.Properties.Appearance.Font = new System.Drawing.Font("微软雅黑", 15F);
            this.leSearchList.Properties.Appearance.Options.UseFont = true;
            this.leSearchList.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.leSearchList.Properties.NullText = "请选择申请单位！";
            this.leSearchList.Properties.ShowClearButton = false;
            this.leSearchList.Properties.ShowFooter = false;
            this.leSearchList.Properties.View = this.leSearchListView;
            this.leSearchList.Size = new System.Drawing.Size(496, 34);
            this.leSearchList.TabIndex = 30;
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
            this.gcUnitName.Visible = true;
            this.gcUnitName.VisibleIndex = 0;
            // 
            // gcUnitType
            // 
            this.gcUnitType.Caption = "单位类型";
            this.gcUnitType.FieldName = "UnitType";
            this.gcUnitType.Name = "gcUnitType";
            this.gcUnitType.Visible = true;
            this.gcUnitType.VisibleIndex = 1;
            // 
            // gcUnitBankUser
            // 
            this.gcUnitBankUser.Caption = "开户名称";
            this.gcUnitBankUser.FieldName = "UnitBankUser";
            this.gcUnitBankUser.Name = "gcUnitBankUser";
            this.gcUnitBankUser.Visible = true;
            this.gcUnitBankUser.VisibleIndex = 2;
            // 
            // gcUnitBankName
            // 
            this.gcUnitBankName.Caption = "开户行名称";
            this.gcUnitBankName.FieldName = "UnitBankName";
            this.gcUnitBankName.Name = "gcUnitBankName";
            this.gcUnitBankName.Visible = true;
            this.gcUnitBankName.VisibleIndex = 3;
            // 
            // gcUnitBankNo
            // 
            this.gcUnitBankNo.Caption = "账号";
            this.gcUnitBankNo.FieldName = "UnitBankNo";
            this.gcUnitBankNo.Name = "gcUnitBankNo";
            this.gcUnitBankNo.Visible = true;
            this.gcUnitBankNo.VisibleIndex = 4;
            // 
            // label17
            // 
            this.label17.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label17.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label17.Location = new System.Drawing.Point(3, 378);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(154, 58);
            this.label17.TabIndex = 10;
            this.label17.Text = "研究周期(年)：";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label11
            // 
            this.label11.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label11.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label11.Location = new System.Drawing.Point(3, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(154, 54);
            this.label11.TabIndex = 1;
            this.label11.Text = "项目名称：";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label12
            // 
            this.label12.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label12.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label12.Location = new System.Drawing.Point(3, 54);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(154, 54);
            this.label12.TabIndex = 4;
            this.label12.Text = "申报单位：";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label13
            // 
            this.label13.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label13.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label13.Location = new System.Drawing.Point(3, 108);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(154, 54);
            this.label13.TabIndex = 5;
            this.label13.Text = "公章名称：";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label14
            // 
            this.label14.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label14.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label14.Location = new System.Drawing.Point(3, 162);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(154, 54);
            this.label14.TabIndex = 7;
            this.label14.Text = "常用名：";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label16
            // 
            this.label16.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label16.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label16.Location = new System.Drawing.Point(3, 270);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(154, 54);
            this.label16.TabIndex = 9;
            this.label16.Text = "通信地址：";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label18
            // 
            this.label18.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label18.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label18.Location = new System.Drawing.Point(689, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(165, 54);
            this.label18.TabIndex = 11;
            this.label18.Text = "密级：";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label19
            // 
            this.label19.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label19.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label19.Location = new System.Drawing.Point(689, 216);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(165, 54);
            this.label19.TabIndex = 12;
            this.label19.Text = "联系电话：";
            this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label20
            // 
            this.label20.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label20.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label20.Location = new System.Drawing.Point(689, 378);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(165, 58);
            this.label20.TabIndex = 13;
            this.label20.Text = "研究经费(万)：";
            this.label20.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.cbxSecret);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(860, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(283, 48);
            this.panel1.TabIndex = 17;
            // 
            // cbxSecret
            // 
            this.cbxSecret.AlwaysActive = false;
            this.cbxSecret.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxSecret.DropDownWidth = 121;
            this.cbxSecret.FormattingEnabled = true;
            this.cbxSecret.Items.AddRange(new object[] {
            "公开",
            "秘密",
            "机密",
            "绝密"});
            this.cbxSecret.Location = new System.Drawing.Point(8, 8);
            this.cbxSecret.Name = "cbxSecret";
            this.cbxSecret.Size = new System.Drawing.Size(121, 33);
            this.cbxSecret.StateCommon.ComboBox.Content.Font = new System.Drawing.Font("微软雅黑", 15F);
            this.cbxSecret.StateCommon.ComboBox.Content.Padding = new System.Windows.Forms.Padding(0);
            this.cbxSecret.StateCommon.Item.Content.LongText.Font = new System.Drawing.Font("微软雅黑", 15F);
            this.cbxSecret.StateCommon.Item.Content.Padding = new System.Windows.Forms.Padding(0);
            this.cbxSecret.StateCommon.Item.Content.ShortText.Font = new System.Drawing.Font("微软雅黑", 15F);
            this.cbxSecret.TabIndex = 20;
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(689, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(165, 54);
            this.label2.TabIndex = 19;
            this.label2.Text = "关键字：";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.Controls.Add(this.txtKeyWords);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(858, 55);
            this.panel3.Margin = new System.Windows.Forms.Padding(1);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(287, 52);
            this.panel3.TabIndex = 20;
            // 
            // txtKeyWords
            // 
            this.txtKeyWords.AlwaysActive = false;
            this.txtKeyWords.Location = new System.Drawing.Point(10, 11);
            this.txtKeyWords.Name = "txtKeyWords";
            this.txtKeyWords.Size = new System.Drawing.Size(268, 29);
            this.txtKeyWords.StateActive.Content.Padding = new System.Windows.Forms.Padding(0);
            this.txtKeyWords.StateCommon.Content.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtKeyWords.StateCommon.Content.Padding = new System.Windows.Forms.Padding(0);
            this.txtKeyWords.StateDisabled.Content.Padding = new System.Windows.Forms.Padding(0);
            this.txtKeyWords.StateNormal.Content.Padding = new System.Windows.Forms.Padding(0);
            this.txtKeyWords.TabIndex = 15;
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.White;
            this.hSkinTableLayoutPanel1.SetColumnSpan(this.panel6, 2);
            this.panel6.Controls.Add(this.cbxPersonList);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel6.Location = new System.Drawing.Point(161, 325);
            this.panel6.Margin = new System.Windows.Forms.Padding(1);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(524, 52);
            this.panel6.TabIndex = 6;
            // 
            // cbxPersonList
            // 
            this.cbxPersonList.AlwaysActive = false;
            this.cbxPersonList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxPersonList.DropDownWidth = 121;
            this.cbxPersonList.FormattingEnabled = true;
            this.cbxPersonList.Location = new System.Drawing.Point(10, 10);
            this.cbxPersonList.Name = "cbxPersonList";
            this.cbxPersonList.Size = new System.Drawing.Size(496, 33);
            this.cbxPersonList.StateCommon.ComboBox.Content.Font = new System.Drawing.Font("微软雅黑", 15F);
            this.cbxPersonList.StateCommon.ComboBox.Content.Padding = new System.Windows.Forms.Padding(0);
            this.cbxPersonList.StateCommon.Item.Content.LongText.Font = new System.Drawing.Font("微软雅黑", 15F);
            this.cbxPersonList.StateCommon.Item.Content.Padding = new System.Windows.Forms.Padding(0);
            this.cbxPersonList.StateCommon.Item.Content.ShortText.Font = new System.Drawing.Font("微软雅黑", 15F);
            this.cbxPersonList.TabIndex = 21;
            this.cbxPersonList.SelectedIndexChanged += new System.EventHandler(this.cbxPersonList_SelectedIndexChanged);
            // 
            // label15
            // 
            this.label15.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label15.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label15.Location = new System.Drawing.Point(3, 324);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(154, 54);
            this.label15.TabIndex = 8;
            this.label15.Text = "项目负责人：";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // plLeftTitle
            // 
            this.plLeftTitle.BackColor = System.Drawing.Color.White;
            this.plLeftTitle.Controls.Add(this.lblLeftTitle);
            this.plLeftTitle.Dock = System.Windows.Forms.DockStyle.Left;
            this.plLeftTitle.Location = new System.Drawing.Point(0, 0);
            this.plLeftTitle.Name = "plLeftTitle";
            this.plLeftTitle.Size = new System.Drawing.Size(80, 436);
            this.plLeftTitle.TabIndex = 0;
            // 
            // lblLeftTitle
            // 
            this.lblLeftTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblLeftTitle.Font = new System.Drawing.Font("微软雅黑", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblLeftTitle.Location = new System.Drawing.Point(0, 0);
            this.lblLeftTitle.Name = "lblLeftTitle";
            this.lblLeftTitle.Size = new System.Drawing.Size(80, 281);
            this.lblLeftTitle.TabIndex = 0;
            this.lblLeftTitle.Text = "项目信息";
            // 
            // plTop
            // 
            this.plTop.Controls.Add(this.lblTopTitle);
            this.plTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.plTop.Location = new System.Drawing.Point(0, 0);
            this.plTop.Margin = new System.Windows.Forms.Padding(1);
            this.plTop.Name = "plTop";
            this.plTop.Size = new System.Drawing.Size(1226, 100);
            this.plTop.StateCommon.Color1 = System.Drawing.Color.White;
            this.plTop.TabIndex = 3;
            // 
            // lblTopTitle
            // 
            this.lblTopTitle.AllowDrop = true;
            this.lblTopTitle.AutoSize = false;
            this.lblTopTitle.Location = new System.Drawing.Point(80, 3);
            this.lblTopTitle.Name = "lblTopTitle";
            this.lblTopTitle.Size = new System.Drawing.Size(1143, 94);
            this.lblTopTitle.StateCommon.ShortText.Color1 = System.Drawing.Color.Black;
            this.lblTopTitle.StateCommon.ShortText.Font = new System.Drawing.Font("微软雅黑", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblTopTitle.TabIndex = 0;
            this.lblTopTitle.Values.Text = "本人保证所填写的信息均真实有效，无任何虚假信息。\r\n本人完全清楚本声明的法律后果，如有不实，愿意承担相应的法律责任。";
            // 
            // plMain
            // 
            this.plMain.BackColor = System.Drawing.Color.Transparent;
            this.plMain.Controls.Add(this.plBottom);
            this.plMain.Controls.Add(this.plContent);
            this.plMain.Controls.Add(this.plTop);
            this.plMain.Location = new System.Drawing.Point(25, 20);
            this.plMain.Name = "plMain";
            this.plMain.Size = new System.Drawing.Size(1226, 604);
            this.plMain.TabIndex = 4;
            // 
            // plBottom
            // 
            this.plBottom.Controls.Add(this.btnSave);
            this.plBottom.Controls.Add(this.btnReport);
            this.plBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.plBottom.Location = new System.Drawing.Point(0, 560);
            this.plBottom.Name = "plBottom";
            this.plBottom.Size = new System.Drawing.Size(1226, 44);
            this.plBottom.TabIndex = 4;
            // 
            // NewProjectEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.plMain);
            this.Name = "NewProjectEditor";
            this.Size = new System.Drawing.Size(1422, 669);
            this.plContent.ResumeLayout(false);
            this.hSkinTableLayoutPanel1.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel11.ResumeLayout(false);
            this.panel11.PerformLayout();
            this.panel12.ResumeLayout(false);
            this.panel12.PerformLayout();
            this.panel10.ResumeLayout(false);
            this.panel10.PerformLayout();
            this.panel9.ResumeLayout(false);
            this.panel9.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.leSearchList.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.leSearchListView)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cbxSecret)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cbxPersonList)).EndInit();
            this.plLeftTitle.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.plTop)).EndInit();
            this.plTop.ResumeLayout(false);
            this.plMain.ResumeLayout(false);
            this.plBottom.ResumeLayout(false);
            this.ResumeLayout(false);

		}

		#endregion

        private KryptonButton btnSave;
        private KryptonButton btnReport;
        private HSkinTableLayoutPanel hSkinTableLayoutPanel1;
        private System.Windows.Forms.Panel plContent;
        private System.Windows.Forms.Panel plLeftTitle;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
        private KryptonTextBox txtFlagName;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private KryptonComboBox cbxSecret;
        private KryptonPanel plTop;
        private KryptonLabel lblTopTitle;
        private System.Windows.Forms.Label lblLeftTitle;
        private System.Windows.Forms.Panel plMain;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel panel7;
        private KryptonTextBox txtAddress;
        private System.Windows.Forms.Panel panel8;
        private KryptonTextBox txtNormalName;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Panel panel10;
        private KryptonTextBox txtProjectName;
        private System.Windows.Forms.Panel panel11;
        private System.Windows.Forms.Panel panel12;
        private KryptonTextBox txtTelphone;
        private KryptonTextBox txtTotalMoney;
        private KryptonTextBox txtTotalTime;
        private KryptonComboBox cbxPersonList;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel3;
        private KryptonTextBox txtKeyWords;
        private System.Windows.Forms.Panel panel4;
        private KryptonTextBox txtContactName;
        private System.Windows.Forms.Label label3;
        private DevExpress.XtraEditors.SearchLookUpEdit leSearchList;
        private DevExpress.XtraGrid.Views.Grid.GridView leSearchListView;
        private DevExpress.XtraGrid.Columns.GridColumn gcID;
        private DevExpress.XtraGrid.Columns.GridColumn gcUnitName;
        private DevExpress.XtraGrid.Columns.GridColumn gcUnitType;
        private DevExpress.XtraGrid.Columns.GridColumn gcUnitBankUser;
        private DevExpress.XtraGrid.Columns.GridColumn gcUnitBankName;
        private DevExpress.XtraGrid.Columns.GridColumn gcUnitBankNo;
        private System.Windows.Forms.Panel plBottom;
    }
}