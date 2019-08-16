using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using Aspose.Words;

namespace ProjectReporter.Controls
{
    public partial class WordDocumentEditControl : UserControl
    {
        public string FilePath { get; set; }

        public WordDocumentEditControl()
        {
            InitializeComponent();
        }

        private void lblDocPath_LinkClicked(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(FilePath))
            {
                return;
            }
            else
            {
                Process.Start(FilePath);
            }
        }

        private void btnUploadDoc_Click(object sender, EventArgs e)
        {
            if (ofdUpload.ShowDialog() == DialogResult.OK)
            {
                lblDocPath.Text = new FileInfo(ofdUpload.FileName).Name;
            }
        }

        private void btnNewDoc_Click(object sender, EventArgs e)
        {
            lblDocPath.Text = "临时文档_" + DateTime.Now.Ticks + ".doc";
            FilePath = string.Empty;
            ofdUpload.FileName = Path.Combine(MainForm.ProjectDir, Path.Combine("Temp", lblDocPath.Text));
            try
            {
                Directory.CreateDirectory(new FileInfo(ofdUpload.FileName).DirectoryName);
            }
            catch (Exception ex) { }
            WordDocument wd = new WordDocument();
            wd.WordDoc.Save(ofdUpload.FileName);

            try
            {
                Process.Start(ofdUpload.FileName);
            }
            catch (Exception ex) { }
        }

        public void Clear()
        {
            FilePath = string.Empty;
            ofdUpload.FileName = string.Empty;
            lblDocPath.Text = string.Empty;
        }

        /// <summary>
        /// 保存并格式化RTF文档
        /// </summary>
        /// <param name="toFile"></param>
        public void SaveDoc(string toFile)
        {
            FilePath = toFile;

            if (File.Exists(ofdUpload.FileName))
            {
                File.Copy(ofdUpload.FileName, toFile, true);
            }

            LoadDoc(toFile);
        }

        /// <summary>
        /// 载入文档
        /// </summary>
        /// <param name="rtfFile"></param>
        public void LoadDoc(string rtfFiles)
        {
            btnNewDoc.Enabled = false;
            FilePath = rtfFiles;

            if (System.IO.File.Exists(FilePath))
            {
                //wbWordContent.Navigate("file://" + FilePath);
                lblDocPath.Text = new FileInfo(FilePath).Name;
            }
        }
    }
}