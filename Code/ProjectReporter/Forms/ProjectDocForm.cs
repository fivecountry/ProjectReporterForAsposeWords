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
        private string lastFilePath = string.Empty;

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
            string[] files = Directory.GetFiles(MainForm.ProjectDir);
            foreach (string s in files)
            {
                FileInfo fi = new FileInfo(s);
                if (fi.Name.StartsWith("建议书"))
                {
                    lastFilePath = s;
                    lbcomattpath.Text = fi.Name;
                    lbcomattpath.Tag = null;
                    break;
                }
            }
        }

        private void btnComsel_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.FileName = string.Empty;
            ofd.Filter = "DOC文件|*.doc|DOCX文件|*.docx";
            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                lbcomattpath.Text = new FileInfo(ofd.FileName).Name;
                lbcomattpath.Tag = ofd.FileName;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            ProjectReporter.Forms.UIDoWorkProcessForm upf = new Forms.UIDoWorkProcessForm();
            upf.EnabledDisplayProgress = false;
            upf.LabalText = "正在保存,请等待...";
            upf.ShowProgress();

            if (lbcomattpath.Tag != null)
            {
                try
                {
                    if (lastFilePath != string.Empty)
                    {
                        File.Delete(lastFilePath);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("删除失败！Ex:" + ex.ToString());
                }

                try
                {
                    File.Copy(lbcomattpath.Tag.ToString(), Path.Combine(MainForm.ProjectDir, "建议书" + Path.GetExtension(lbcomattpath.Tag.ToString())), true);
                    UpdateLabel();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("上传失败！Ex:" + ex.ToString());
                }
            }
            try
            {
                System.Threading.Thread.Sleep(1000);
            }
            catch (Exception ex) { }

            upf.Close();

            MessageBox.Show("操作完成");
            Close();
        }

        private void lbcomattpath_LinkClicked(object sender, EventArgs e)
        {
            string path = Path.Combine(MainForm.ProjectDir, lbcomattpath.Text);
            if (File.Exists(path))
            {
                try
                {
                    System.Diagnostics.Process.Start(path);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("对不起，打开打败！Ex:" + ex.ToString());
                }
            }
        }
    }
}