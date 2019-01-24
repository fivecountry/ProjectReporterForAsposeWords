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
			this.pictureBox1 = new PictureBox();
			this.kryptonPanel1 = new KryptonPanel();
			this.lbinfo = new KryptonLabel();
			this.btnCancel = new KryptonButton();
			this.btnConfirm = new KryptonButton();
			((ISupportInitialize)this.pictureBox1).BeginInit();
			((ISupportInitialize)this.kryptonPanel1).BeginInit();
			this.kryptonPanel1.SuspendLayout();
			base.SuspendLayout();
			this.pictureBox1.BackColor = Color.Transparent;
			this.pictureBox1.Dock = DockStyle.Left;
            this.pictureBox1.Image = global::ProjectReporter.Properties.Resources.CLEAN;
			this.pictureBox1.Location = new Point(0, 0);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new Size(86, 90);
			this.pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
			this.pictureBox1.TabIndex = 0;
			this.pictureBox1.TabStop = false;
			this.kryptonPanel1.Controls.Add(this.lbinfo);
			this.kryptonPanel1.Controls.Add(this.btnCancel);
			this.kryptonPanel1.Controls.Add(this.btnConfirm);
			this.kryptonPanel1.Controls.Add(this.pictureBox1);
			this.kryptonPanel1.Dock = DockStyle.Fill;
			this.kryptonPanel1.Location = new Point(0, 0);
			this.kryptonPanel1.Name = "kryptonPanel1";
			this.kryptonPanel1.Size = new Size(375, 90);
			this.kryptonPanel1.StateCommon.Color1 = Color.White;
			this.kryptonPanel1.StateCommon.ColorStyle = PaletteColorStyle.SolidAllLine;
			this.kryptonPanel1.TabIndex = 1;
			this.lbinfo.Location = new Point(94, 12);
			this.lbinfo.Name = "lbinfo";
			this.lbinfo.Size = new Size(269, 20);
			this.lbinfo.TabIndex = 3;
			this.lbinfo.Values.Text = "是否确认清空用户所有填报数据，并初始化？";
			this.btnCancel.Location = new Point(273, 53);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new Size(90, 25);
			this.btnCancel.TabIndex = 2;
			this.btnCancel.Values.Text = "取消";
			this.btnCancel.Click += new EventHandler(this.btnCancel_Click);
			this.btnConfirm.Location = new Point(166, 53);
			this.btnConfirm.Name = "btnConfirm";
			this.btnConfirm.Size = new Size(90, 25);
			this.btnConfirm.TabIndex = 1;
			this.btnConfirm.Values.Text = "确认";
			this.btnConfirm.Click += new EventHandler(this.btnConfirm_Click);
			base.AutoScaleDimensions = new SizeF(6f, 12f);
            ////base.AutoScaleMode = AutoScaleMode.Font;
			base.ClientSize = new Size(375, 90);
			base.Controls.Add(this.kryptonPanel1);
            //base.FormBorderStyle = FormBorderStyle.None;
			base.Name = "frmClear";
			base.StartPosition = FormStartPosition.CenterScreen;
			this.Text = "frmClear";
			((ISupportInitialize)this.pictureBox1).EndInit();
			((ISupportInitialize)this.kryptonPanel1).EndInit();
			this.kryptonPanel1.ResumeLayout(false);
			this.kryptonPanel1.PerformLayout();
			base.ResumeLayout(false);
		}
	}
}