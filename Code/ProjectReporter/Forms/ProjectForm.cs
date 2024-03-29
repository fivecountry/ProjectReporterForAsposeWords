﻿using ProjectReporter.DB.Entitys;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ProjectReporter.Forms
{
    public partial class ProjectForm : Form
    {
        public ProjectForm()
        {
            InitializeComponent();

            updateProjects();
        }

        private void updateProjects()
        {
            tvProject.Nodes.Clear();
            string[] dirs = System.IO.Directory.GetDirectories(MainForm.BaseDir);
            foreach (string s in dirs)
            {
                System.IO.DirectoryInfo di = new System.IO.DirectoryInfo(s);
                Project proj = getProjectObject(s);
                if (proj != null && proj.Name != null && proj.Name.Length >= 1)
                {
                    if (di.Name == "Current")
                    {
                        Text = "项目管理(当前:" + proj.Name + ")";
                    }
                    else
                    {
                        TreeNode tn = new TreeNode();
                        tn.Text = di.Name + "(" + proj.Name + ")";
                        tn.Name = di.Name;
                        tn.Tag = proj;
                        tvProject.Nodes.Add(tn);
                    }
                }
            }
        }

        /// <summary>
        /// 获得项目信息
        /// </summary>
        /// <param name="projectDir"></param>
        /// <returns></returns>
        public Project getProjectObject(string projectDir)
        {
            Project proj = null;
            string dbFile = System.IO.Path.Combine(projectDir, "static.db");

            if (System.IO.File.Exists(dbFile))
            {
                System.Data.SQLite.SQLiteFactory factory = new System.Data.SQLite.SQLiteFactory();
                Noear.Weed.DbContext context = new Noear.Weed.DbContext("main", "Data Source=" + dbFile, factory);
                context.IsSupportInsertAfterSelectIdentity = false;
                context.IsSupportGCAfterDispose = true;
                try
                {
                    proj = context.table("Project").where("Type='" + "项目" + "'").select("*").getItem<Project>(new Project());
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.ToString());
                }
                finally
                {
                    try
                    {
                        factory.Dispose();
                    }
                    catch (Exception ex) { }
                    factory = null;

                    try
                    {
                        context.Dispose();
                    }
                    catch (Exception ex) { }
                    context = null;
                }
            }

            return proj;
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            if (tvProject.SelectedNode != null && System.IO.Directory.Exists(System.IO.Path.Combine(MainForm.BaseDir, tvProject.SelectedNode.Name)))
            {
                if (MessageBox.Show("真的要切换吗？", "提示", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                {
                    string uuid = MainForm.Instance.ProjectObj != null ? MainForm.Instance.ProjectObj.ID : Guid.NewGuid().ToString();

                    //关闭连接
                    ProjectReporter.DB.ConnectionManager.Close();

                    //当前项目目录
                    string currentPath = System.IO.Path.Combine(MainForm.BaseDir, "Current");

                    //目标目录
                    string destPath = System.IO.Path.Combine(MainForm.BaseDir, uuid);

                    //移动当前目录
                    if (System.IO.Directory.Exists(currentPath))
                    {
                        if (System.IO.Directory.Exists(destPath))
                        {
                            System.IO.Directory.Delete(destPath, true);
                        }

                        System.IO.Directory.Move(currentPath, destPath);
                    }

                    //将这个目录切换为当前目录
                    System.IO.Directory.Move(System.IO.Path.Combine(MainForm.BaseDir, tvProject.SelectedNode.Name), currentPath);

                    MainForm.Instance.EnabledShowBackupHint = false;
                    ProjectReporter.DB.ConnectionManager.Close();
                    System.Diagnostics.Process.Start(Application.ExecutablePath);
                    MainForm.Instance.ProjectObj = null;
                    Application.Exit();
                }
            }
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            if (ofdSelect.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                //新项目目录
                string newProjectDir = System.IO.Path.Combine(MainForm.BaseDir, Guid.NewGuid().ToString());

                SuperCodeFactoryUILib.Forms.CircleProgressBarDialog dialog = new SuperCodeFactoryUILib.Forms.CircleProgressBarDialog();
                dialog.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                dialog.TransparencyKey = dialog.BackColor;
                dialog.ProgressBar.ForeColor = Color.Red;
                dialog.MessageLabel.ForeColor = Color.Blue;
                dialog.Start(new EventHandler<SuperCodeFactoryUILib.Forms.CircleProgressBarEventArgs>(delegate(object thisObj, SuperCodeFactoryUILib.Forms.CircleProgressBarEventArgs args)
                {
                    try
                    {
                        dialog.ReportProgress(20, 100);
                        dialog.ReportInfo("创建导入目录");
                        try
                        {
                            System.Threading.Thread.Sleep(1000);
                        }
                        catch (Exception ex) { }

                        //创建目录
                        try
                        {
                            System.IO.Directory.CreateDirectory(newProjectDir);
                        }
                        catch (Exception ex) { }

                        dialog.ReportProgress(40, 100);
                        dialog.ReportInfo("准备解包");

                        //解压需要导入的包                        
                        new ProjectReporter.Utility.FileZipOpr().UnZipFile(ofdSelect.FileName, newProjectDir, string.Empty, true);
                    }
                    catch (Exception ex)
                    {
                        dialog.ReportProgress(90, 100);
                        dialog.ReportInfo("解包出错，正在删除导入目录");
                        try
                        {
                            System.Threading.Thread.Sleep(1000);
                        }
                        catch (Exception exx) { }

                        if (System.IO.Directory.Exists(newProjectDir))
                        {
                            System.IO.Directory.Delete(newProjectDir);
                        }
                    }

                    dialog.ReportProgress(98, 100);
                    dialog.ReportInfo("刷新列表");
                    try
                    {
                        System.Threading.Thread.Sleep(1000);
                    }
                    catch (Exception ex) { }

                    //更新列表
                    Invoke(new MethodInvoker(delegate()
                        {
                            updateProjects();
                        }));                    
                }));
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (tvProject.SelectedNode != null)
            {
                if (MessageBox.Show("真的要删除吗？", "提示", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                {
                    try
                    {
                        System.IO.Directory.Delete(System.IO.Path.Combine(MainForm.BaseDir, tvProject.SelectedNode.Name), true);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("删除错误！Ex:" + ex.ToString());
                    }

                    updateProjects();
                }
            }
        }
    }
}