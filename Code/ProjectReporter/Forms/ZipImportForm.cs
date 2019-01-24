using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ProjectReporter.Utility;
using System.Threading;
using ProjectReporter.DB;
using System.IO;
using ProjectReporter.DB.Entitys;
using System.Diagnostics;

namespace ProjectReporter.Forms
{
    public delegate void ImportOKHandler(object sender, EventArgs e);
    
    public partial class ZipImportForm : BaseForm 
    {
        public event ImportOKHandler ImportOK;

        public ZipImportForm(string zipFile)
        {
            InitializeComponent();

            ZipPackageFile = zipFile;
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            Process.Start(Application.ExecutablePath, ZipPackageFile);

            MainForm.Instance.ProjectObj = null;
            Application.Exit();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        public string ZipPackageFile { get; set; }

        private void ShowProgress(int progress, string text)
        {
            if (IsHandleCreated)
            {
                Invoke(new MethodInvoker(delegate()
                {
                    pbar.Value = progress;
                    lbmsg.Text = text;
                }));
            }
        }
    }
}