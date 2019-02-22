using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using ProjectReporter.Forms;
using System.Diagnostics;
using ProjectReporter.Utility;

namespace ProjectReporter
{
    static class Program
    {
        private static ApplicationContext context;

        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            #region 初始化目录
            //InitProjectDir("P" + Process.GetCurrentProcess().Id + "-Project");
            TryInitProjectDir("Current");

            if (args.Length >= 1)
            {
                //需要导入文件
                FileZipOpr fzo = new FileZipOpr();

                if (args[0] != null)
                {
                    if (args[0].StartsWith("Export:"))
                    {
                        //导出
                        string toZipFile = args[0].Replace("Export:", string.Empty);
                        string toZipDir = new FileInfo(toZipFile).DirectoryName;
                        string docFile = Path.Combine(toZipDir, "申报书.doc");
                        if (File.Exists(docFile))
                        {
                            File.Copy(docFile, Path.Combine(MainForm.ProjectDir, "申报书.doc"), true);
                        }

                        //打包文件
                        fzo.ZipFileDirectory(MainForm.ProjectDir, toZipFile);

                        //删除临时Doc文件
                        File.Delete(Path.Combine(MainForm.ProjectDir, "申报书.doc"));
                    }
                    else if (args[0].StartsWith("Clear:"))
                    {
                        Directory.Delete(MainForm.ProjectDir, true);
                        TryInitProjectDir("Current");
                    }
                    else
                    {
                        //导入

                        //备份当前的数据库
                        if (Directory.Exists(Path.Combine(MainForm.BaseDir, "import-backup")))
                        {
                            Directory.Delete(Path.Combine(MainForm.BaseDir, "import-backup"), true);
                        }
                        Directory.Move(MainForm.ProjectDir, Path.Combine(MainForm.BaseDir, "import-backup"));
                        Directory.CreateDirectory(MainForm.ProjectDir);

                        //解压需要导入的包                        
                        fzo.UnZipFile(args[0], MainForm.ProjectDir, string.Empty, true);
                    }
                }

                //打开DB文件连接
                TryOpenProjectDirDB();
            }
            else
            {
                //打开DB文件连接
                TryOpenProjectDirDB();
            }

            #endregion

            #region 启动窗体
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            WelcomeForm startform = new WelcomeForm();
            startform.Show();
            Program.context = new ApplicationContext();
            Program.context.Tag = startform;
            Application.Idle += new EventHandler(Program.Application_Idle);
            Application.Run(Program.context);
            #endregion
        }

        private static void Application_Idle(object sender, EventArgs e)
        {
            Application.Idle -= new EventHandler(Program.Application_Idle);
            if (Program.context.MainForm == null)
            {
                MainForm logicform = new MainForm();
                Program.context.MainForm = logicform;
                logicform.InitAll();
                WelcomeForm startform = (WelcomeForm)Program.context.Tag;
                startform.Close();
                logicform.Show();
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