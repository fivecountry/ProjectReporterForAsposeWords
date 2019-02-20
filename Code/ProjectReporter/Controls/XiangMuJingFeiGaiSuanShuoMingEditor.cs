using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace ProjectReporter.Controls
{
    public partial class XiangMuJingFeiGaiSuanShuoMingEditor : BaseEditor
    {
        public string FilePath { get; set; }

        public string FileFirstName = "upload_1";

        public XiangMuJingFeiGaiSuanShuoMingEditor()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            OnSaveEvent();
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            OnLastEvent();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            OnNextEvent();
        }

        public override void ClearView()
        {
            base.ClearView();

            lbcomattpath.Text = string.Empty;
            FilePath = string.Empty;
        }

        public override void RefreshView()
        {
            base.RefreshView();

            if (Directory.Exists(MainForm.ProjectFilesDir))
            {
                string[] files = Directory.GetFiles(MainForm.ProjectFilesDir);
                if (files != null)
                {
                    foreach (string f in files)
                    {
                        FileInfo fi = new FileInfo(f);
                        if (fi.Name.StartsWith(FileFirstName))
                        {
                            FilePath = f;
                            lbcomattpath.Text = fi.Name.Replace(FileFirstName + "_", string.Empty);
                            break;
                        }
                    }
                }
            }
        }

        public override void OnSaveEvent()
        {
            base.OnSaveEvent();

            try
            {
                if (File.Exists(ofdUpload.FileName))
                {
                    if (File.Exists(FilePath))
                    {
                        File.Delete(FilePath);
                    }

                    File.Copy(ofdUpload.FileName, Path.Combine(MainForm.ProjectFilesDir, FileFirstName + "_" + new FileInfo(ofdUpload.FileName).Name));
                    RefreshView();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("保存失败!Ex:" + ex.ToString());
            }
        }

        private void btnComsel_Click(object sender, EventArgs e)
        {
            if (ofdUpload.ShowDialog() == DialogResult.OK)
            {
                lbcomattpath.Text = new FileInfo(ofdUpload.FileName).Name;
            }
        }

        public override bool IsInputCompleted()
        {
            return true;
        }

        private void lklDownloadFuJian_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) { }


        private void lklDownloadFuJian_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            string sourcePath = Path.Combine(Application.StartupPath, Path.Combine("Helper", "JingFeiFuJian.doc"));
            string destPath = Path.Combine(System.Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory), "项目经费概算说明.doc");
            File.Copy(sourcePath, destPath);
            MessageBox.Show("已下载到桌面！");
            Process.Start(destPath);
        }
    }
}