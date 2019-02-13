namespace ProjectReporter.Forms
{
    partial class NewUnitForm
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
            this.plButtons = new DevExpress.XtraEditors.PanelControl();
            this.btnOK = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnCancel = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.plContent = new DevExpress.XtraEditors.PanelControl();
            this.cbxUnitType = new System.Windows.Forms.ComboBox();
            this.txtUnitBankNo = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtUnitBankName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtUnitBankUser = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtUnitName = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtFlagName = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtNormalName = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtContactName = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtTelephone = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.cbxSecretQualification = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.plButtons)).BeginInit();
            this.plButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.plContent)).BeginInit();
            this.plContent.SuspendLayout();
            this.SuspendLayout();
            // 
            // plButtons
            // 
            this.plButtons.Controls.Add(this.btnOK);
            this.plButtons.Controls.Add(this.btnCancel);
            this.plButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.plButtons.Location = new System.Drawing.Point(2, 394);
            this.plButtons.Name = "plButtons";
            this.plButtons.Size = new System.Drawing.Size(393, 36);
            this.plButtons.TabIndex = 7;
            // 
            // btnOK
            // 
            this.btnOK.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnOK.Location = new System.Drawing.Point(211, 2);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(90, 32);
            this.btnOK.StateCommon.Content.LongText.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnOK.StateCommon.Content.ShortText.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnOK.TabIndex = 28;
            this.btnOK.Values.Text = "保存";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnCancel.Location = new System.Drawing.Point(301, 2);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(90, 32);
            this.btnCancel.StateCommon.Content.LongText.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCancel.StateCommon.Content.ShortText.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCancel.TabIndex = 27;
            this.btnCancel.Values.Text = "取消";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // plContent
            // 
            this.plContent.Controls.Add(this.cbxSecretQualification);
            this.plContent.Controls.Add(this.txtTelephone);
            this.plContent.Controls.Add(this.txtContactName);
            this.plContent.Controls.Add(this.txtAddress);
            this.plContent.Controls.Add(this.txtNormalName);
            this.plContent.Controls.Add(this.txtFlagName);
            this.plContent.Controls.Add(this.cbxUnitType);
            this.plContent.Controls.Add(this.label12);
            this.plContent.Controls.Add(this.label11);
            this.plContent.Controls.Add(this.label10);
            this.plContent.Controls.Add(this.label9);
            this.plContent.Controls.Add(this.label8);
            this.plContent.Controls.Add(this.txtUnitBankNo);
            this.plContent.Controls.Add(this.label7);
            this.plContent.Controls.Add(this.txtPassword);
            this.plContent.Controls.Add(this.label5);
            this.plContent.Controls.Add(this.txtUnitBankName);
            this.plContent.Controls.Add(this.label4);
            this.plContent.Controls.Add(this.txtUnitBankUser);
            this.plContent.Controls.Add(this.label3);
            this.plContent.Controls.Add(this.label2);
            this.plContent.Controls.Add(this.txtUnitName);
            this.plContent.Controls.Add(this.label6);
            this.plContent.Controls.Add(this.label1);
            this.plContent.Controls.Add(this.plButtons);
            this.plContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.plContent.Location = new System.Drawing.Point(0, 0);
            this.plContent.Name = "plContent";
            this.plContent.Size = new System.Drawing.Size(397, 432);
            this.plContent.TabIndex = 8;
            // 
            // cbxUnitType
            // 
            this.cbxUnitType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxUnitType.FormattingEnabled = true;
            this.cbxUnitType.Items.AddRange(new object[] {
            "航天科技",
            "航空科技"});
            this.cbxUnitType.Location = new System.Drawing.Point(79, 87);
            this.cbxUnitType.Name = "cbxUnitType";
            this.cbxUnitType.Size = new System.Drawing.Size(300, 22);
            this.cbxUnitType.TabIndex = 10;
            // 
            // txtUnitBankNo
            // 
            this.txtUnitBankNo.Location = new System.Drawing.Point(79, 171);
            this.txtUnitBankNo.Name = "txtUnitBankNo";
            this.txtUnitBankNo.Size = new System.Drawing.Size(300, 22);
            this.txtUnitBankNo.TabIndex = 9;
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(79, 32);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '#';
            this.txtPassword.Size = new System.Drawing.Size(300, 22);
            this.txtPassword.TabIndex = 0;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 174);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 14);
            this.label5.TabIndex = 8;
            this.label5.Text = "  账    号：";
            // 
            // txtUnitBankName
            // 
            this.txtUnitBankName.Location = new System.Drawing.Point(79, 143);
            this.txtUnitBankName.Name = "txtUnitBankName";
            this.txtUnitBankName.Size = new System.Drawing.Size(300, 22);
            this.txtUnitBankName.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 146);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 14);
            this.label4.TabIndex = 8;
            this.label4.Text = " 开 户 行：";
            // 
            // txtUnitBankUser
            // 
            this.txtUnitBankUser.Location = new System.Drawing.Point(79, 115);
            this.txtUnitBankUser.Name = "txtUnitBankUser";
            this.txtUnitBankUser.Size = new System.Drawing.Size(300, 22);
            this.txtUnitBankUser.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 118);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 14);
            this.label3.TabIndex = 8;
            this.label3.Text = "开户名称：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 90);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 14);
            this.label2.TabIndex = 8;
            this.label2.Text = "单位类型：";
            // 
            // txtUnitName
            // 
            this.txtUnitName.Location = new System.Drawing.Point(79, 59);
            this.txtUnitName.Name = "txtUnitName";
            this.txtUnitName.Size = new System.Drawing.Size(300, 22);
            this.txtUnitName.TabIndex = 9;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(15, 35);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(67, 14);
            this.label6.TabIndex = 8;
            this.label6.Text = "添加密码：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 14);
            this.label1.TabIndex = 8;
            this.label1.Text = "单位名称：";
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(7, 202);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(77, 14);
            this.label7.TabIndex = 8;
            this.label7.Text = "  公章名称：";
            // 
            // txtFlagName
            // 
            this.txtFlagName.Location = new System.Drawing.Point(79, 199);
            this.txtFlagName.Name = "txtFlagName";
            this.txtFlagName.Size = new System.Drawing.Size(300, 22);
            this.txtFlagName.TabIndex = 9;
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(7, 230);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(77, 14);
            this.label8.TabIndex = 8;
            this.label8.Text = "  常用名称：";
            // 
            // txtNormalName
            // 
            this.txtNormalName.Location = new System.Drawing.Point(79, 227);
            this.txtNormalName.Name = "txtNormalName";
            this.txtNormalName.Size = new System.Drawing.Size(300, 22);
            this.txtNormalName.TabIndex = 9;
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(7, 258);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(77, 14);
            this.label9.TabIndex = 8;
            this.label9.Text = "  通信地址：";
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(79, 255);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(300, 22);
            this.txtAddress.TabIndex = 9;
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(7, 286);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(77, 14);
            this.label10.TabIndex = 8;
            this.label10.Text = "     联系人：";
            // 
            // txtContactName
            // 
            this.txtContactName.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtContactName.Location = new System.Drawing.Point(79, 283);
            this.txtContactName.Name = "txtContactName";
            this.txtContactName.Size = new System.Drawing.Size(300, 22);
            this.txtContactName.TabIndex = 9;
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(7, 314);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(77, 14);
            this.label11.TabIndex = 8;
            this.label11.Text = "  联系电话：";
            // 
            // txtTelephone
            // 
            this.txtTelephone.Location = new System.Drawing.Point(79, 311);
            this.txtTelephone.Name = "txtTelephone";
            this.txtTelephone.Size = new System.Drawing.Size(300, 22);
            this.txtTelephone.TabIndex = 9;
            // 
            // label12
            // 
            this.label12.Location = new System.Drawing.Point(7, 342);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(77, 14);
            this.label12.TabIndex = 8;
            this.label12.Text = "  保密资质：";
            // 
            // cbxSecretQualification
            // 
            this.cbxSecretQualification.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxSecretQualification.FormattingEnabled = true;
            this.cbxSecretQualification.Items.AddRange(new object[] {
            "无",
            "一级",
            "二级",
            "三级"});
            this.cbxSecretQualification.Location = new System.Drawing.Point(79, 339);
            this.cbxSecretQualification.Name = "cbxSecretQualification";
            this.cbxSecretQualification.Size = new System.Drawing.Size(300, 22);
            this.cbxSecretQualification.TabIndex = 11;
            // 
            // NewUnitForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(397, 432);
            this.Controls.Add(this.plContent);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "NewUnitForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "添加单位";
            ((System.ComponentModel.ISupportInitialize)(this.plButtons)).EndInit();
            this.plButtons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.plContent)).EndInit();
            this.plContent.ResumeLayout(false);
            this.plContent.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl plButtons;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnOK;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnCancel;
        private DevExpress.XtraEditors.PanelControl plContent;
        private System.Windows.Forms.TextBox txtUnitName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtUnitBankNo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtUnitBankName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtUnitBankUser;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.ComboBox cbxUnitType;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtTelephone;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtContactName;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtNormalName;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtFlagName;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cbxSecretQualification;
    }
}