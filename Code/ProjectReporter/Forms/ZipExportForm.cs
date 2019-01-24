using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using ProjectReporter.Utility;
using System.Threading;
using ProjectReporter.DB;
using System.Diagnostics;

namespace ProjectReporter.Forms
{
    public partial class ZipExportForm : BaseForm
    {
        public ZipExportForm(string toZipFile)
        {
            InitializeComponent();

            ToZipFile = toZipFile;

            ConvertToZip();
        }

        private void ConvertToZip()
        {
            ShowProgress(10, "正在准备导出...");
            ThreadPool.QueueUserWorkItem(new WaitCallback(delegate(object o)
                {
                    try
                    {
                        FileInfo fi = new FileInfo(ToZipFile);

                        ShowProgress(30, "正在准备生成Word...");

                        //生成Word文件
                        WordExportForm wef = new WordExportForm(Path.Combine(fi.DirectoryName, "申报书.doc"));
                        wef.ShowDialog();

                        ShowProgress(60, "正在准备打包数据文件");

                        //打包数据文件
                        Process.Start(Application.ExecutablePath, "Export:" + ToZipFile);
                        MainForm.Instance.ProjectObj = null;
                        Application.Exit();

                        if (IsHandleCreated)
                        {
                            Invoke(new MethodInvoker(delegate()
                                {
                                    pbar.Value = 100;
                                    lbmsg.Text = "导出完成";
                                    Close();
                                }));
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("打包失败!Ex:" + ex.ToString());
                        Close();
                    }
                }));
        }

        public string ToZipFile { get; set; }

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