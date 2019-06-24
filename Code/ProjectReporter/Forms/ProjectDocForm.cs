using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ProjectReporter.Forms
{
    public partial class ProjectDocForm : Form
    {
        public ProjectDocForm()
        {
            InitializeComponent();
        }

        private void ProjectDocForm_Load(object sender, EventArgs e)
        {
            UpdateLabel();
        }

        private void UpdateLabel()
        {
            if (File.Exists(Path.Combine(MainForm.ProjectDir, "建议书.doc")))
            {
                lbcomattpath.Text = "建议书.doc";
                lbcomattpath.Tag = null;
            }
        }

        private void btnComsel_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.FileName = string.Empty;
            ofd.Filter = "*.doc|*.doc";
            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                lbcomattpath.Text = new FileInfo(ofd.FileName).Name;
                lbcomattpath.Tag = ofd.FileName;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (lbcomattpath.Tag != null)
            {
                try
                {
                    File.Copy(lbcomattpath.Tag.ToString(), Path.Combine(MainForm.ProjectDir, "建议书.doc"), true);
                    UpdateLabel();
                    MessageBox.Show("上传完成！");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("上传失败！Ex:" + ex.ToString());
                }
                finally
                {
                    Close();
                }
            }
        }

        private void lbcomattpath_LinkClicked(object sender, EventArgs e)
        {
            string path = Path.Combine(MainForm.ProjectDir, "建议书.doc");
            if (File.Exists(path))
            {
                System.Diagnostics.Process.Start(path);
            }
        }
    }
}