﻿namespace ProjectReporter.Forms
{
    partial class NewGuGanLianXiRenForm
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
            this.btnUnitSelect = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.dePersonBirthday = new DevExpress.XtraEditors.DateEdit();
            this.cbxPersonSex = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTaskContent = new System.Windows.Forms.TextBox();
            this.txtPersonTelephone = new System.Windows.Forms.TextBox();
            this.txtPersonSpecialty = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtPersonJob = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtPersonIDCard = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtUnitName = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtPersonName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.plButtons = new DevExpress.XtraEditors.PanelControl();
            this.btnOK = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnCancel = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.txtWorkTimeInYear = new ComponentFactory.Krypton.Toolkit.KryptonNumericUpDown();
            this.label12 = new System.Windows.Forms.Label();
            this.cbxItemJobs = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtUnitAddress = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txtUnitContactName = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.txtUnitTelephone = new System.Windows.Forms.TextBox();
            this.plWorkUnit = new ComponentFactory.Krypton.Toolkit.KryptonGroupBox();
            this.plPersonInfo = new ComponentFactory.Krypton.Toolkit.KryptonGroupBox();
            this.label16 = new System.Windows.Forms.Label();
            this.txtPersonMobilePhone = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.txtPersonAddress = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.plContent)).BeginInit();
            this.plContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dePersonBirthday.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dePersonBirthday.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbxPersonSex)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.plButtons)).BeginInit();
            this.plButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbxItemJobs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.plWorkUnit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.plWorkUnit.Panel)).BeginInit();
            this.plWorkUnit.Panel.SuspendLayout();
            this.plWorkUnit.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.plPersonInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.plPersonInfo.Panel)).BeginInit();
            this.plPersonInfo.Panel.SuspendLayout();
            this.plPersonInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // plContent
            // 
            this.plContent.Controls.Add(this.label18);
            this.plContent.Controls.Add(this.plPersonInfo);
            this.plContent.Controls.Add(this.plWorkUnit);
            this.plContent.Controls.Add(this.txtWorkTimeInYear);
            this.plContent.Controls.Add(this.cbxItemJobs);
            this.plContent.Controls.Add(this.label2);
            this.plContent.Controls.Add(this.txtTaskContent);
            this.plContent.Controls.Add(this.label11);
            this.plContent.Controls.Add(this.label12);
            this.plContent.Controls.Add(this.plButtons);
            this.plContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.plContent.Location = new System.Drawing.Point(0, 0);
            this.plContent.Name = "plContent";
            this.plContent.Size = new System.Drawing.Size(478, 626);
            this.plContent.TabIndex = 10;
            // 
            // btnUnitSelect
            // 
            this.btnUnitSelect.Location = new System.Drawing.Point(141, 3);
            this.btnUnitSelect.Name = "btnUnitSelect";
            this.btnUnitSelect.Size = new System.Drawing.Size(300, 29);
            this.btnUnitSelect.TabIndex = 15;
            this.btnUnitSelect.Values.Text = "点击选择开户帐号！";
            this.btnUnitSelect.Click += new System.EventHandler(this.btnUnitSelect_Click);
            // 
            // dePersonBirthday
            // 
            this.dePersonBirthday.EditValue = null;
            this.dePersonBirthday.Location = new System.Drawing.Point(141, 143);
            this.dePersonBirthday.Name = "dePersonBirthday";
            this.dePersonBirthday.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dePersonBirthday.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dePersonBirthday.Size = new System.Drawing.Size(300, 20);
            this.dePersonBirthday.TabIndex = 14;
            // 
            // cbxPersonSex
            // 
            this.cbxPersonSex.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxPersonSex.DropDownWidth = 300;
            this.cbxPersonSex.Items.AddRange(new object[] {
            "男",
            "女"});
            this.cbxPersonSex.Location = new System.Drawing.Point(141, 114);
            this.cbxPersonSex.Name = "cbxPersonSex";
            this.cbxPersonSex.Size = new System.Drawing.Size(300, 22);
            this.cbxPersonSex.TabIndex = 13;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(12, 559);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(142, 14);
            this.label2.TabIndex = 10;
            this.label2.Text = "每年为本项目工作时间：";
            // 
            // txtTaskContent
            // 
            this.txtTaskContent.Location = new System.Drawing.Point(151, 492);
            this.txtTaskContent.Multiline = true;
            this.txtTaskContent.Name = "txtTaskContent";
            this.txtTaskContent.Size = new System.Drawing.Size(313, 57);
            this.txtTaskContent.TabIndex = 9;
            // 
            // txtPersonTelephone
            // 
            this.txtPersonTelephone.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtPersonTelephone.Location = new System.Drawing.Point(141, 170);
            this.txtPersonTelephone.Name = "txtPersonTelephone";
            this.txtPersonTelephone.Size = new System.Drawing.Size(300, 22);
            this.txtPersonTelephone.TabIndex = 9;
            // 
            // txtPersonSpecialty
            // 
            this.txtPersonSpecialty.Location = new System.Drawing.Point(141, 86);
            this.txtPersonSpecialty.Name = "txtPersonSpecialty";
            this.txtPersonSpecialty.Size = new System.Drawing.Size(300, 22);
            this.txtPersonSpecialty.TabIndex = 9;
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(13, 512);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(142, 17);
            this.label11.TabIndex = 8;
            this.label11.Text = "                  任务分工：";
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(69, 173);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(77, 14);
            this.label10.TabIndex = 8;
            this.label10.Text = "    座    机：";
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(69, 145);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(77, 14);
            this.label9.TabIndex = 8;
            this.label9.Text = "  出生年月：";
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(69, 117);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(77, 14);
            this.label8.TabIndex = 8;
            this.label8.Text = "    性    别：";
            // 
            // txtPersonJob
            // 
            this.txtPersonJob.Location = new System.Drawing.Point(141, 58);
            this.txtPersonJob.Name = "txtPersonJob";
            this.txtPersonJob.Size = new System.Drawing.Size(300, 22);
            this.txtPersonJob.TabIndex = 9;
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(69, 89);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(77, 14);
            this.label7.TabIndex = 8;
            this.label7.Text = "  从事专业：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(77, 61);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 14);
            this.label5.TabIndex = 8;
            this.label5.Text = "职务职称：";
            // 
            // txtPersonIDCard
            // 
            this.txtPersonIDCard.Location = new System.Drawing.Point(141, 30);
            this.txtPersonIDCard.Name = "txtPersonIDCard";
            this.txtPersonIDCard.Size = new System.Drawing.Size(300, 22);
            this.txtPersonIDCard.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(77, 33);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 14);
            this.label4.TabIndex = 8;
            this.label4.Text = " 身 份 证：";
            // 
            // txtUnitName
            // 
            this.txtUnitName.Location = new System.Drawing.Point(141, 39);
            this.txtUnitName.Name = "txtUnitName";
            this.txtUnitName.Size = new System.Drawing.Size(300, 22);
            this.txtUnitName.TabIndex = 9;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(77, 42);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(67, 14);
            this.label6.TabIndex = 8;
            this.label6.Text = "单位名称：";
            // 
            // txtPersonName
            // 
            this.txtPersonName.Location = new System.Drawing.Point(141, 2);
            this.txtPersonName.Name = "txtPersonName";
            this.txtPersonName.Size = new System.Drawing.Size(300, 22);
            this.txtPersonName.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(77, 5);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 14);
            this.label3.TabIndex = 8;
            this.label3.Text = "  姓    名：";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(53, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 14);
            this.label1.TabIndex = 8;
            this.label1.Text = "单位开户帐号：";
            // 
            // plButtons
            // 
            this.plButtons.Controls.Add(this.btnOK);
            this.plButtons.Controls.Add(this.btnCancel);
            this.plButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.plButtons.Location = new System.Drawing.Point(2, 588);
            this.plButtons.Name = "plButtons";
            this.plButtons.Size = new System.Drawing.Size(474, 36);
            this.plButtons.TabIndex = 7;
            // 
            // btnOK
            // 
            this.btnOK.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnOK.Location = new System.Drawing.Point(292, 2);
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
            this.btnCancel.Location = new System.Drawing.Point(382, 2);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(90, 32);
            this.btnCancel.StateCommon.Content.LongText.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCancel.StateCommon.Content.ShortText.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCancel.TabIndex = 27;
            this.btnCancel.Values.Text = "取消";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // txtWorkTimeInYear
            // 
            this.txtWorkTimeInYear.Location = new System.Drawing.Point(151, 558);
            this.txtWorkTimeInYear.Name = "txtWorkTimeInYear";
            this.txtWorkTimeInYear.Size = new System.Drawing.Size(112, 22);
            this.txtWorkTimeInYear.TabIndex = 16;
            // 
            // label12
            // 
            this.label12.Location = new System.Drawing.Point(14, 467);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(144, 14);
            this.label12.TabIndex = 8;
            this.label12.Text = "               项目中职务：";
            // 
            // cbxItemJobs
            // 
            this.cbxItemJobs.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxItemJobs.DropDownWidth = 300;
            this.cbxItemJobs.Location = new System.Drawing.Point(151, 464);
            this.cbxItemJobs.Name = "cbxItemJobs";
            this.cbxItemJobs.Size = new System.Drawing.Size(313, 22);
            this.cbxItemJobs.TabIndex = 13;
            // 
            // label13
            // 
            this.label13.Location = new System.Drawing.Point(77, 70);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(67, 14);
            this.label13.TabIndex = 8;
            this.label13.Text = "通信地址：";
            // 
            // txtUnitAddress
            // 
            this.txtUnitAddress.Location = new System.Drawing.Point(141, 67);
            this.txtUnitAddress.Name = "txtUnitAddress";
            this.txtUnitAddress.Size = new System.Drawing.Size(300, 22);
            this.txtUnitAddress.TabIndex = 9;
            // 
            // label14
            // 
            this.label14.Location = new System.Drawing.Point(77, 98);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(67, 14);
            this.label14.TabIndex = 8;
            this.label14.Text = " 联 系 人：";
            // 
            // txtUnitContactName
            // 
            this.txtUnitContactName.Location = new System.Drawing.Point(141, 95);
            this.txtUnitContactName.Name = "txtUnitContactName";
            this.txtUnitContactName.Size = new System.Drawing.Size(300, 22);
            this.txtUnitContactName.TabIndex = 9;
            // 
            // label15
            // 
            this.label15.Location = new System.Drawing.Point(77, 126);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(67, 14);
            this.label15.TabIndex = 8;
            this.label15.Text = "联系电话：";
            // 
            // txtUnitTelephone
            // 
            this.txtUnitTelephone.Location = new System.Drawing.Point(141, 123);
            this.txtUnitTelephone.Name = "txtUnitTelephone";
            this.txtUnitTelephone.Size = new System.Drawing.Size(300, 22);
            this.txtUnitTelephone.TabIndex = 9;
            // 
            // plWorkUnit
            // 
            this.plWorkUnit.Location = new System.Drawing.Point(8, 2);
            this.plWorkUnit.Name = "plWorkUnit";
            // 
            // plWorkUnit.Panel
            // 
            this.plWorkUnit.Panel.Controls.Add(this.txtUnitName);
            this.plWorkUnit.Panel.Controls.Add(this.txtUnitAddress);
            this.plWorkUnit.Panel.Controls.Add(this.txtUnitContactName);
            this.plWorkUnit.Panel.Controls.Add(this.txtUnitTelephone);
            this.plWorkUnit.Panel.Controls.Add(this.btnUnitSelect);
            this.plWorkUnit.Panel.Controls.Add(this.label1);
            this.plWorkUnit.Panel.Controls.Add(this.label6);
            this.plWorkUnit.Panel.Controls.Add(this.label13);
            this.plWorkUnit.Panel.Controls.Add(this.label14);
            this.plWorkUnit.Panel.Controls.Add(this.label15);
            this.plWorkUnit.Size = new System.Drawing.Size(456, 176);
            this.plWorkUnit.TabIndex = 17;
            this.plWorkUnit.Values.Heading = "工作单位";
            // 
            // plPersonInfo
            // 
            this.plPersonInfo.Location = new System.Drawing.Point(8, 181);
            this.plPersonInfo.Name = "plPersonInfo";
            // 
            // plPersonInfo.Panel
            // 
            this.plPersonInfo.Panel.Controls.Add(this.txtPersonName);
            this.plPersonInfo.Panel.Controls.Add(this.dePersonBirthday);
            this.plPersonInfo.Panel.Controls.Add(this.txtPersonIDCard);
            this.plPersonInfo.Panel.Controls.Add(this.cbxPersonSex);
            this.plPersonInfo.Panel.Controls.Add(this.txtPersonJob);
            this.plPersonInfo.Panel.Controls.Add(this.txtPersonAddress);
            this.plPersonInfo.Panel.Controls.Add(this.txtPersonMobilePhone);
            this.plPersonInfo.Panel.Controls.Add(this.txtPersonTelephone);
            this.plPersonInfo.Panel.Controls.Add(this.txtPersonSpecialty);
            this.plPersonInfo.Panel.Controls.Add(this.label3);
            this.plPersonInfo.Panel.Controls.Add(this.label4);
            this.plPersonInfo.Panel.Controls.Add(this.label5);
            this.plPersonInfo.Panel.Controls.Add(this.label7);
            this.plPersonInfo.Panel.Controls.Add(this.label17);
            this.plPersonInfo.Panel.Controls.Add(this.label8);
            this.plPersonInfo.Panel.Controls.Add(this.label16);
            this.plPersonInfo.Panel.Controls.Add(this.label9);
            this.plPersonInfo.Panel.Controls.Add(this.label10);
            this.plPersonInfo.Size = new System.Drawing.Size(456, 279);
            this.plPersonInfo.TabIndex = 18;
            this.plPersonInfo.Values.Heading = "人员信息";
            // 
            // label16
            // 
            this.label16.Location = new System.Drawing.Point(69, 201);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(77, 14);
            this.label16.TabIndex = 8;
            this.label16.Text = "    手    机：";
            // 
            // txtPersonMobilePhone
            // 
            this.txtPersonMobilePhone.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtPersonMobilePhone.Location = new System.Drawing.Point(141, 198);
            this.txtPersonMobilePhone.Name = "txtPersonMobilePhone";
            this.txtPersonMobilePhone.Size = new System.Drawing.Size(300, 22);
            this.txtPersonMobilePhone.TabIndex = 9;
            // 
            // label17
            // 
            this.label17.Location = new System.Drawing.Point(69, 229);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(77, 14);
            this.label17.TabIndex = 8;
            this.label17.Text = "  通信地址：";
            // 
            // txtPersonAddress
            // 
            this.txtPersonAddress.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtPersonAddress.Location = new System.Drawing.Point(141, 226);
            this.txtPersonAddress.Name = "txtPersonAddress";
            this.txtPersonAddress.Size = new System.Drawing.Size(300, 22);
            this.txtPersonAddress.TabIndex = 9;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(265, 562);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(19, 14);
            this.label18.TabIndex = 19;
            this.label18.Text = "月";
            // 
            // NewGuGanLianXiRenForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(478, 626);
            this.Controls.Add(this.plContent);
            this.Name = "NewGuGanLianXiRenForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "添加/修改负责人及研究骨干";
            ((System.ComponentModel.ISupportInitialize)(this.plContent)).EndInit();
            this.plContent.ResumeLayout(false);
            this.plContent.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dePersonBirthday.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dePersonBirthday.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbxPersonSex)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.plButtons)).EndInit();
            this.plButtons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cbxItemJobs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.plWorkUnit.Panel)).EndInit();
            this.plWorkUnit.Panel.ResumeLayout(false);
            this.plWorkUnit.Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.plWorkUnit)).EndInit();
            this.plWorkUnit.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.plPersonInfo.Panel)).EndInit();
            this.plPersonInfo.Panel.ResumeLayout(false);
            this.plPersonInfo.Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.plPersonInfo)).EndInit();
            this.plPersonInfo.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl plContent;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnUnitSelect;
        private DevExpress.XtraEditors.DateEdit dePersonBirthday;
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox cbxPersonSex;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtTaskContent;
        private System.Windows.Forms.TextBox txtPersonTelephone;
        private System.Windows.Forms.TextBox txtPersonSpecialty;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtPersonJob;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtPersonIDCard;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtUnitName;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtPersonName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.PanelControl plButtons;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnOK;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnCancel;
        private ComponentFactory.Krypton.Toolkit.KryptonNumericUpDown txtWorkTimeInYear;
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox cbxItemJobs;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtUnitTelephone;
        private System.Windows.Forms.TextBox txtUnitContactName;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtUnitAddress;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private ComponentFactory.Krypton.Toolkit.KryptonGroupBox plWorkUnit;
        private ComponentFactory.Krypton.Toolkit.KryptonGroupBox plPersonInfo;
        private System.Windows.Forms.TextBox txtPersonAddress;
        private System.Windows.Forms.TextBox txtPersonMobilePhone;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label18;
    }
}