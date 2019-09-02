using ProjectReporter.Utility;
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
    public partial class WelcomeForm : Form
    {
        /// <summary>
        /// 启动参数
        /// </summary>
        public string[] StartupParams { get; set; }

        public WelcomeForm()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            try
            {
                bwWorkers.RunWorkerAsync();
            }
            catch (Exception exxx)
            {
                MessageBox.Show("启动失败！Ex:" + exxx.ToString(), "错误", MessageBoxButtons.OK);
            }
        }

        /// <summary>
        /// 显示文字提示
        /// </summary>
        /// <param name="txt"></param>
        private void printHint(string txt)
        {
            if (IsHandleCreated)
            {
                Invoke(new MethodInvoker(delegate() 
                    {
                        lbMessage.Text = txt;
                    }));
            }
        }

        private void bwWorkers_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                printHint("正在准备数据，请稍等......");

                #region 初始化目录
                //InitProjectDir("P" + Process.GetCurrentProcess().Id + "-Project");
                Program.TryInitProjectDir("Current");

                if (StartupParams.Length >= 1)
                {
                    //需要导入文件
                    FileZipOpr fzo = new FileZipOpr();

                    if (StartupParams[0] != null)
                    {
                        if (StartupParams[0].StartsWith("Export:"))
                        {
                            printHint("正在导出数据，请稍等......");

                            //导出
                            string toZipFile = StartupParams[0].Replace("Export:", string.Empty);
                            string toZipDir = new FileInfo(toZipFile).DirectoryName;
                            //string docFile = Path.Combine(toZipDir, "申报书.doc");
                            //if (File.Exists(docFile))
                            //{
                            //    File.Copy(docFile, Path.Combine(MainForm.ProjectDir, "申报书.doc"), true);
                            //}

                            //打包文件
                            fzo.ZipFileDirectory(MainForm.ProjectDir, toZipFile);

                            //删除临时Doc文件
                            //File.Delete(Path.Combine(MainForm.ProjectDir, "申报书.doc"));
                        }
                        else if (StartupParams[0].StartsWith("Clear:"))
                        {
                            printHint("正在清理数据，请稍等......");

                            Directory.Delete(MainForm.ProjectDir, true);
                            Program.TryInitProjectDir("Current");

                            //复制摘要模板
                            //File.Copy(Path.Combine(Application.StartupPath, Path.Combine("Helper", "xiangmuzhaiyaomoban.rtf")), Path.Combine(MainForm.ProjectFilesDir, "rtpinput_0.rtf"), true);
                        }
                        else
                        {
                            //导入
                            printHint("正在导入数据，请稍等......");

                            //检查是否需要备份
                            if (StartupParams[1] != null && StartupParams[1].Length >= 2)
                            {
                                //备份当前的数据库
                                if (Directory.Exists(Path.Combine(MainForm.BaseDir, StartupParams[1])))
                                {
                                    Directory.Delete(Path.Combine(MainForm.BaseDir, StartupParams[1]), true);
                                }
                                Directory.Move(MainForm.ProjectDir, Path.Combine(MainForm.BaseDir, StartupParams[1]));
                            }
                            else
                            {
                                //删除当前目录
                                if (Directory.Exists(MainForm.ProjectDir))
                                {
                                    Directory.Delete(MainForm.ProjectDir, true);
                                }
                            }

                            //创建新目录
                            Directory.CreateDirectory(MainForm.ProjectDir);

                            //解压需要导入的包                        
                            fzo.UnZipFile(StartupParams[0], MainForm.ProjectDir, string.Empty, true);
                        }
                    }

                    //打开DB文件连接
                    Program.TryOpenProjectDirDB();
                }
                else
                {
                    //打开DB文件连接
                    Program.TryOpenProjectDirDB();

                    //复制摘要模板
                    if (!File.Exists(Path.Combine(MainForm.ProjectFilesDir, "rtpinput_0.rtf")))
                    {
                        File.Copy(Path.Combine(Application.StartupPath, Path.Combine("Helper", "xiangmuzhaiyaomoban.rtf")), Path.Combine(MainForm.ProjectFilesDir, "rtpinput_0.rtf"));
                    }
                }
                #endregion

                printHint("正在启动中，请稍等......");

                #region 启动窗体
                if (IsHandleCreated)
                {
                    Invoke(new MethodInvoker(delegate()
                        {
                            try
                            {
                                //显示主窗体
                                MainForm logicform = new MainForm();
                                Program.context.MainForm = logicform;
                                logicform.InitAll();
                                logicform.Show();

                                //关闭欢迎窗体
                                WelcomeForm startform = (WelcomeForm)Program.context.Tag;
                                startform.Close();                                
                            }
                            catch (Exception exxx)
                            {
                                MessageBox.Show("启动失败！Ex:" + exxx.ToString(), "错误", MessageBoxButtons.OK);
                            }
                        }));
                }
                else
                {
                    throw new Exception("数据没有准备好！");
                }
                #endregion
            }
            catch (Exception exxx)
            {
                MessageBox.Show("启动失败！Ex:" + exxx.ToString(), "错误", MessageBoxButtons.OK);

                //重新启动
                System.Diagnostics.Process.Start(Application.ExecutablePath);

                //退出当前程序
                Application.Exit();
            }
        }
    }
}