using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace ProjectReporter.Controls
{
    public partial class WordDocumentEditControl : UserControl
    {
        public string FilePath { get; set; }

        public WordDocumentEditControl()
        {
            InitializeComponent();
        }

        private void lbcomattpath_LinkClicked(object sender, EventArgs e)
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

        private void btnComsel_Click(object sender, EventArgs e)
        {
            if (ofdUpload.ShowDialog() == DialogResult.OK)
            {
                lbcomattpath.Text = new FileInfo(ofdUpload.FileName).Name;
            }
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
            FilePath = rtfFiles;

            if (System.IO.File.Exists(FilePath))
            {
                txtWordContent.LoadFile(FilePath);
            }
        }
    }
}