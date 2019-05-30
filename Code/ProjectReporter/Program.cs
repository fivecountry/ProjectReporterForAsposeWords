using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using ProjectReporter.Forms;
using System.Diagnostics;
using ProjectReporter.Utility;
using System.Threading;

namespace ProjectReporter
{
    static class Program
    {
        public static ApplicationContext context;

        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            try
            {
                //初始化
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);

                //创建欢迎窗体界面
                WelcomeForm startform = new WelcomeForm();

                //设置启动参数
                startform.StartupParams = args;

                //显示欢迎窗体
                startform.Show();

                //开始消息循环
                Program.context = new ApplicationContext();
                Program.context.Tag = startform;
                Application.Run(Program.context); 
            }
            catch (Exception exxx)
            {
                MessageBox.Show("启动失败！Ex:" + exxx.ToString(), "错误", MessageBoxButtons.OK);
            }
        }

        /// <summary>
        /// 初始化工程目录
        /// </summary>
        /// <param name="id"></param>
        public static void TryInitProjectDir(string id)
        {
            MainForm.ProjectDir = Path.Combine(MainForm.BaseDir, string.IsNullOrEmpty(id) ? Guid.NewGuid().ToString() : id);
            MainForm.ProjectFilesDir = Path.Combine(MainForm.ProjectDir, "Files");
            try
            {
                Directory.CreateDirectory(MainForm.BaseDir);
            }
            catch (Exception ex) { }
            try
            {
                Directory.CreateDirectory(MainForm.ProjectDir);
            }
            catch (Exception ex) { }
            try
            {
                Directory.CreateDirectory(MainForm.ProjectFilesDir);
            }
            catch (Exception ex) { }
        }

        /// <summary>
        /// 打开DB文件连接
        /// </summary>
        public static void TryOpenProjectDirDB()
        {
            string dbFile = Path.Combine(MainForm.ProjectDir, "static.db");

            //初始化DB
            InitDBFile(dbFile);

            if (File.Exists(dbFile))
            {
                return;
            }
            else
            {
                //复制空的DB文件
                File.Copy(Path.Combine(Application.StartupPath, "static.db"), dbFile);
            }
        }

        /// <summary>
        /// 初始化数据库
        /// </summary>
        /// <param name="dbFile"></param>
        private static void InitDBFile(string dbFile)
        {
            ProjectReporter.DB.ConnectionManager.Open(dbFile);
        }
    }
}