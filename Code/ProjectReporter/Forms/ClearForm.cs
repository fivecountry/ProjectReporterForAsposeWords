using ComponentFactory.Krypton.Toolkit;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using ProjectReporter.Utility;
using ProjectReporter.Controls;
using ProjectReporter.DB;
using System.Diagnostics;

namespace ProjectReporter.Forms
{
	public class ClearForm : BaseForm
	{
		public delegate void ClearOKHandler(object sender, EventArgs e);

		private IContainer components;

		private PictureBox pictureBox1;

		private KryptonPanel kryptonPanel1;

		private KryptonLabel lbinfo;

		private KryptonButton btnCancel;

		private KryptonButton btnConfirm;

		public event ClearForm.ClearOKHandler ClearOK;

		protected virtual void OnClearOKEvent(EventArgs e)
		{
			if (this.ClearOK != null)
			{
				this.ClearOK(this, e);
			}
		}

		public ClearForm()
		{
			this.InitializeComponent();
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			base.Close();
		}

		private void btnConfirm_Click(object sender, EventArgs e)
		{
            MainForm.Instance.EnabledShowBackupHint = false;
            ConnectionManager.Close();
            Process.Start(Application.ExecutablePath, "Clear:All");
            MainForm.Instance.ProjectObj = null;
            Application.Exit();
        }

		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		private void InitializeComponent()
		{
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.kryptonPanel1 = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.lbinfo = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.btnCancel = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnConfirm = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.pictureBox1.Image = global::ProjectReporter.Properties.Resources.CLEAN;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(86, 90);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.lbinfo);
            this.kryptonPanel1.Controls.Add(this.btnCancel);
            this.kryptonPanel1.Controls.Add(this.btnConfirm);
            this.kryptonPanel1.Controls.Add(this.pictureBox1);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Size = new System.Drawing.Size(416, 90);
            this.kryptonPanel1.StateCommon.Color1 = System.Drawing.Color.White;
            this.kryptonPanel1.StateCommon.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.SolidAllLine;
            this.kryptonPanel1.TabIndex = 1;
            // 
            // lbinfo
            // 
            this.lbinfo.Location = new System.Drawing.Point(87, 12);
            this.lbinfo.Name = "lbinfo";
            this.lbinfo.Size = new System.Drawing.Size(323, 24);
            this.lbinfo.TabIndex = 3;
            this.lbinfo.Values.Text = "是否确认清空用户所有填报数据，并初始化？";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(273, 42);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(90, 36);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Values.Text = "取消";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnConfirm
            // 
            this.btnConfirm.Location = new System.Drawing.Point(166, 42);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(90, 36);
            this.btnConfirm.TabIndex = 1;
            this.btnConfirm.Values.Text = "确认";
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // ClearForm
            // 
            this.ClientSize = new System.Drawing.Size(416, 90);
            this.Controls.Add(this.kryptonPanel1);
            this.Name = "ClearForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmClear";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            this.kryptonPanel1.PerformLayout();
            this.ResumeLayout(false);

		}
	}
}