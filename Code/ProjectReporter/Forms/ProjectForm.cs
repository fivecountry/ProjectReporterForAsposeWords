using ProjectReporter.DB.Entitys;
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
                    TreeNode tn = new TreeNode();
                    tn.Text = di.Name + "(" + proj.Name + ")";
                    tn.Name = proj.ID;
                    tn.Tag = proj;
                    tvProject.Nodes.Add(tn);
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

        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            if (ofdSelect.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                //新项目目录
                string newProjectDir = System.IO.Path.Combine(MainForm.BaseDir, Guid.NewGuid().ToString());

                try
                {
                    //创建目录
                    try
                    {
                        System.IO.Directory.CreateDirectory(newProjectDir);
                    }
                    catch (Exception ex) { }

                    //解压需要导入的包                        
                    new ProjectReporter.Utility.FileZipOpr().UnZipFile(ofdSelect.FileName, newProjectDir, string.Empty, true);
                }
                catch (Exception ex)
                {
                    if (System.IO.Directory.Exists(newProjectDir))
                    {
                        System.IO.Directory.Delete(newProjectDir);
                    }
                }
                
                //更新列表
                updateProjects();
            }
        }
    }
}