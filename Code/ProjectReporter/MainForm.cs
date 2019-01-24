using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using ComponentFactory.Krypton.Navigator;
using ProjectReporter.Controls;
using ProjectReporter.Forms;
using ProjectReporter.DB.Entitys;
using ProjectReporter.DB;

namespace ProjectReporter
{
    public partial class MainForm : Form
    {
        private bool EnabledRefreshPage = false;

        public static MainForm Instance { get; set; }

        /// <summary>
        /// 基础目录
        /// </summary>
        public static string BaseDir = Path.Combine(Application.StartupPath, "Data");

        /// <summary>
        /// 工程目录
        /// </summary>
        public static string ProjectDir = string.Empty;

        /// <summary>
        /// 附件目录
        /// </summary>
        public static string ProjectFilesDir = string.Empty;

        /// <summary>
        /// 编辑控件Map
        /// </summary>
        public SortedList<string, BaseEditor> EditorMaps = new SortedList<string, BaseEditor>();

        /// <summary>
        /// 工程说明控件
        /// </summary>
        public NewProjectEditor ProjectInfo { get { return this.fnpDefault; } }

        /// <summary>
        /// 工程对象
        /// </summary>
        public Project ProjectObj { get; set; }

        public MainForm()
        {
            InitializeComponent();

            Instance = this;
        }

        /// <summary>
        /// 初始化
        /// </summary>
        public void InitAll()
        {
            
        }

        /// <summary>
        /// 将TabPage选择归0
        /// </summary>
        public void ClearPageSelected()
        {
            edithost2.SelectedIndex = 0;
            foreach (KryptonPage kp in edithost2.Pages)
            {
                if (kp.Controls.Count > 0)
                {
                    if (kp.Controls[0] is KryptonNavigator)
                    {
                        ((KryptonNavigator)kp.Controls[0]).SelectedIndex = 0;
                    }
                }
            }
        }

        private void btninit_Click(object sender, EventArgs e)
        {
            ClearForm frmClear = new ClearForm();
            frmClear.ClearOK += new ClearForm.ClearOKHandler(this.frmclear_ClearOK);
            frmClear.ShowDialog();
        }

        private void frmclear_ClearOK(object sender, EventArgs e)
        {
            ClearPageSelected();
            SwitchToCreateEditor();
        }

        private void btnwordview_Click(object sender, EventArgs e)
        {
            if (!this.IsInputCompleted())
            {
                MessageBox.Show("请将所有内容填写完整再点击预览!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            WordExportForm frmExportWord = new WordExportForm(string.Empty);
            frmExportWord.ShowDialog();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            if (!this.IsInputCompleted())
            {
                MessageBox.Show("请将所有内容填写完整再点击上报!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "zip files(*.zip)|*.zip";
            saveFileDialog.FileName = ProjectObj.Name + "_上报文件.zip";
            saveFileDialog.FilterIndex = 2;
            saveFileDialog.RestoreDirectory = true;

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                new ZipExportForm(saveFileDialog.FileName).ShowDialog();
            }
        }

        /// <summary>
        /// 判断是否输入完成
        /// </summary>
        /// <returns></returns>
        public bool IsInputCompleted()
        {
            foreach (BaseEditor be in EditorMaps.Values)
            {
                if (be.IsInputCompleted())
                {
                    continue;
                }
                else 
                {
                    return false;
                }
            }

            return true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //if (!this.canSwitch)
            //{
            //    MessageBox.Show("当前页面还未保存，请保存后再试。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //    return;
            //}
            //ApplyUserBaseInfoService applyUserBaseInfoService = new ApplyUserBaseInfoService();
            //ApplyUserInfo userBaseInfo = applyUserBaseInfoService.GetUserBaseInfo();
            //SaveFileDialog saveFileDialog = new SaveFileDialog();
            //saveFileDialog.Filter = " zip files(*.zip)|*.zip";
            //saveFileDialog.FileName = userBaseInfo.Unit + "_" + userBaseInfo.ApplyUserName + ".zip";
            //saveFileDialog.FilterIndex = 2;
            //saveFileDialog.RestoreDirectory = true;
            //if (saveFileDialog.ShowDialog() == DialogResult.OK)
            //{
            //    new frmExportWord(EntityElement.ExportType.ToZipFile, false)
            //    {
            //        Savefilename = saveFileDialog.FileName
            //    }.ShowDialog();
            //}
        }

        private void maintimer_Tick(object sender, EventArgs e)
        {
            this.lbcurtime.Text = "欢迎您！当前时间 " + DateTime.Now.ToString("yyyy年M月d日 H:mm:ss");
        }

        private void btnquit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);

            if (ProjectObj != null)
            {
                DialogResult dialogResult = MessageBox.Show("退出前是否备份打包数据？", "提示", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Asterisk);
                if (dialogResult == DialogResult.Yes)
                {
                    this.btnSave_Click(this, e);
                }
            }
        }

        private void btnhelp_Click(object sender, EventArgs e)
        {
            HelpForm frmhelp = new HelpForm();
            frmhelp.ShowDialog();
        }

        private void logicform_Load(object sender, EventArgs e)
        {
            fnpDefault.ParentForm = this;

            #region 适配背景
            int width = Screen.PrimaryScreen.Bounds.Width;
            int num = width;
            if (num <= 1280)
            {
                if (num == 1024)
                {
                    this.topBanner.Image = global::ProjectReporter.Properties.Resources.BANNER1024;
                    //this.edithost.SelectedIndex = 0;
                }
                if (num == 1280)
                {
                    this.topBanner.Image = global::ProjectReporter.Properties.Resources.BANNER1280;
                    //this.edithost.SelectedIndex = 0;
                }
            }
            else
            {
                if (num == 1366)
                {
                    this.topBanner.Image = global::ProjectReporter.Properties.Resources.BANNER1366;
                    //this.edithost.SelectedIndex = 0;
                }
                if (num == 1440)
                {
                    this.topBanner.Image = global::ProjectReporter.Properties.Resources.BANNER1440;
                    //this.edithost.SelectedIndex = 0;
                }
                if (num == 1920)
                {
                    this.topBanner.Image = global::ProjectReporter.Properties.Resources.BANNER1920;
                    //this.edithost.SelectedIndex = 0;
                }
            }
            this.topBanner.Image = global::ProjectReporter.Properties.Resources.BANNER1366;
            #endregion

            //加载按钮图片
            LoadContentEditorTabPageButtons();

            //加载按钮事件
            LoadEditorEvents();

            //载入工程
            LoadProjects();            
        }

        public void LoadProjects()
        {
            try
            {
                List<Project> pList = ConnectionManager.Context.table("Project").where("Type='" + "项目" + "'").select("*").getList<Project>(new Project());
                if (pList != null && pList.Count >= 1)
                {
                    ProjectObj = pList[0];
                    fnpDefault.LoadProject();
                    SwitchToContentEditor();
                }
                else
                {
                    SwitchToCreateEditor();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("对不起，数据库加载失败！");
                Application.Exit();
            }
        }

        private void LoadEditorEvents()
        {
            #region 控件列表
            List<Control> controlList = new List<Control>();
            controlList.Add(feUI1);
            controlList.Add(feUI2);
            controlList.Add(feUI3);
            controlList.Add(feUI4);
            controlList.Add(feUI5);
            controlList.Add(feUI6);
            controlList.Add(feUI7);
            controlList.Add(feUI8);
            controlList.Add(feUI9);
            controlList.Add(feUI10);
            controlList.Add(feUI11);
            controlList.Add(feUI12);
            controlList.Add(feUI13);
            controlList.Add(feUI14);
            controlList.Add(feUI15);
            controlList.Add(feUI16);
            controlList.Add(feUI17);
            controlList.Add(feUI18);
            controlList.Add(feUI19);
            controlList.Add(feUI20);
            controlList.Add(feUI21);
            controlList.Add(feUI22);
            controlList.Add(feUI23);
            controlList.Add(feUI24);
            controlList.Add(feUI25);
            #endregion

            foreach (Control c in controlList)
            {
                BaseEditor be = (BaseEditor)c;
                EditorMaps.Add(be.Name, be);

                be.SaveEvent += new SaveOrLastOrNextEventDelegate(be_SaveEvent);
                be.LastEvent += new SaveOrLastOrNextEventDelegate(be_LastEvent);
                be.NextEvent += new SaveOrLastOrNextEventDelegate(be_NextEvent);
            }
        }

        void be_NextEvent(object sender, EventArgs args)
        {
            BaseEditor current = (BaseEditor)sender;

            //保存
            current.OnSaveEvent();

            //下一步
            string nextName = "feUI" + (Int32.Parse(current.Name.Replace("feUI", string.Empty)) + 1);
            if (EditorMaps.ContainsKey(nextName))
            {
                BaseEditor next = EditorMaps[nextName];
                if (next.Parent is KryptonPage)
                {
                    //上一个页签归0
                    KryptonNavigator subTab = ((KryptonNavigator)((KryptonPage)current.Parent).Parent.Parent);
                    subTab.SelectedIndex = 0;

                    //目标子Tab切换
                    subTab = ((KryptonNavigator)((KryptonPage)next.Parent).Parent.Parent);
                    subTab.SelectedPage = (KryptonPage)next.Parent;

                    //主Tab切换
                    edithost2.SelectedPage = ((KryptonPage)subTab.Parent);
                }

                //刷新视图
                next.RefreshView();
            }
        }

        void be_LastEvent(object sender, EventArgs args)
        {
            SwitchToCreateEditor();
        }

        void be_SaveEvent(object sender, EventArgs args)
        {
            BaseEditor current = (BaseEditor)sender;

            //保存RTF
            //if (current is RTFTextEditor)
            //{
            //    ((RTFTextEditor)current).RichTextBoxControl.SaveFile(Path.Combine(ProjectFilesDir, current.Name + ".rtf"));
            //}
        }

        private void LoadContentEditorTabPageButtons()
        {
            StringFormat sf = new StringFormat();
            sf.Alignment = StringAlignment.Near;
            sf.LineAlignment = StringAlignment.Center;
            sf.Trimming = StringTrimming.Word;
            sf.FormatFlags = StringFormatFlags.LineLimit;

            int iconIndex = 0;
            foreach (KryptonPage kp in edithost2.Pages)
            {
                Bitmap bmp = new Bitmap(240, 55);
                Graphics g = Graphics.FromImage(bmp);
                try
                {
                    //背景透明
                    g.FillRectangle(new SolidBrush(Color.Transparent), new Rectangle(0, 0, bmp.Width, bmp.Height));

                    // 取图标
                    Image img = GetBarButtonIcon(iconIndex);

                    if (img != null)
                    {
                        //画图标                    
                        g.DrawImage(img, new Rectangle(10, (55 - 32) / 2, 32, 32));

                        //画字符串
                        g.DrawString(kp.Text, new Font("微软雅黑", 11), new SolidBrush(Color.Black), new RectangleF(52, 0, bmp.Width - 52, bmp.Height), sf);
                    }
                    else
                    {
                        //画字符串
                        g.DrawString(kp.Text, new Font("微软雅黑", 11), new SolidBrush(Color.Black), new RectangleF(10, 0, bmp.Width - 10, bmp.Height), sf);
                    }
                }
                catch (Exception ex) { }
                finally
                {
                    g.Dispose();
                }

                kp.ImageSmall = bmp;
                kp.Text = string.Empty;
                kp.TextTitle = string.Empty;
                kp.TextDescription = string.Empty;

                iconIndex++;
            }
        }

        private Image GetBarButtonIcon(int index)
        {
            switch (index)
            {
                case 0:
                    return ProjectReporter.Properties.Resources.II_1;
                case 1:
                    return ProjectReporter.Properties.Resources.II_2;
                case 2:
                    return ProjectReporter.Properties.Resources.II_3;
                case 3:
                    return ProjectReporter.Properties.Resources.II_4;
                case 4:
                    return ProjectReporter.Properties.Resources.II_5;
                case 5:
                    return ProjectReporter.Properties.Resources.II_6;
                case 6:
                    return ProjectReporter.Properties.Resources.II_7;
                case 7:
                    return ProjectReporter.Properties.Resources.II_8;
                case 8:
                    return ProjectReporter.Properties.Resources.II_9;
                case 9:
                    return ProjectReporter.Properties.Resources.II_10;
                case 10:
                    return ProjectReporter.Properties.Resources.II_11;
                case 11:
                    return ProjectReporter.Properties.Resources.II_12;

                default:
                    return null;
            }
        }

        public void SwitchToContentEditor()
        {
            //显示项目名称
            this.Text = this.Tag + " (项目:" + ProjectObj.Name + ")";

            //刷新Editor控件组
            RefreshEditor();

            //显示编辑控件
            fnpDefault.Top = 0;
            edithost2.Top = 0;
            fnpDefault.Dock = DockStyle.None;
            edithost2.Dock = DockStyle.None;
            fnpDefault.Visible = false;
            edithost2.Visible = true;
            edithost2.Dock = DockStyle.Fill;
        }

        /// <summary>
        /// 刷新视图
        /// </summary>
        public void RefreshEditor()
        {
            if (ProjectObj != null)
            {
                fnpDefault.LoadProject();

                foreach (BaseEditor be in EditorMaps.Values)
                {
                    be.RefreshView();
                }
            }
        }

        public void SwitchToCreateEditor()
        {
            fnpDefault.Top = 0;
            edithost2.Top = 0;
            fnpDefault.Dock = DockStyle.None;
            edithost2.Dock = DockStyle.None;
            fnpDefault.Dock = DockStyle.Fill;
            edithost2.Visible = false;
            fnpDefault.Visible = true;

            fnpDefault.LoadProject();
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Multiselect = false;
            openFileDialog.RestoreDirectory = true;
            openFileDialog.Filter = "Zip压缩文件(*.zip)|*.zip";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                ZipImportForm frmRequestImport = new ZipImportForm(openFileDialog.FileName);
                frmRequestImport.ImportOK += new ImportOKHandler(this.ifrmRequestImport_ImportOK);
                frmRequestImport.ShowDialog();
            }
        }

        private void ifrmRequestImport_ImportOK(object sender, EventArgs e)
        {
            //载入工程
            LoadProjects();
        }

        private void pagewantChange_Selecting(object sender, KryptonPageCancelEventArgs e)
        {
            //if (!this.canSwitch)
            //{
            //    e.Cancel = true;
            //    if (this.preusercontrol != null)
            //    {
            //        this.preusercontrol = null;
            //        return;
            //    }
            //    MessageBox.Show("检测到当前页面部分必填字段未填写完成，无法切换到其他页面", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //}
        }

        private void item_OnSaveCheckDeny(object sender, EventArgs e)
        {
            //this.canSwitch = false;
            //this.preusercontrol = (UserControl)sender;
        }

        private void item_OnSaveCheckPassed(object sender, EventArgs e)
        {
            //this.canSwitch = true;
        }

        private void logicform_Resize(object sender, EventArgs e)
        {
            int num = 540;
            int num2 = base.ClientSize.Height - this.kpcontact.Height;
            this.kpcontact.Top = num + (num2 - num) / 4;
        }

        private void btnPersonManager_Click(object sender, EventArgs e)
        {
            EnabledRefreshPage = true;

            if (PersonForm == null || PersonForm.IsDisposed)
            {
                PersonForm = new PersonManagerForm();
            }
            PersonForm.WindowState = FormWindowState.Normal;
            PersonForm.Show();
            PersonForm.BringToFront();
        }

        private void btnUnitManager_Click(object sender, EventArgs e)
        {
            EnabledRefreshPage = true;

            if (UnitForm == null || UnitForm.IsDisposed)
            {
                UnitForm = new UnitManagerForm();
            }
            UnitForm.WindowState = FormWindowState.Normal;
            UnitForm.Show();
            UnitForm.BringToFront();
        }

        public PersonManagerForm PersonForm { get; set; }

        public UnitManagerForm UnitForm { get; set; }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (System.IO.Directory.Exists(Path.Combine(Application.StartupPath, "TempDocs")))
            {
                try
                {
                    System.IO.Directory.Delete(Path.Combine(Application.StartupPath, "TempDocs"), true);
                }
                catch (Exception ex) { }
            }
        }

        private void MainForm_Activated(object sender, EventArgs e)
        {
            try
            {
                if (EnabledRefreshPage)
                {
                    EnabledRefreshPage = false;

                    if (ProjectObj != null)
                    {
                        //刷新视图
                        RefreshEditor();
                    }
                    else
                    {
                        fnpDefault.LoadProject();
                    }
                }
            }
            catch (Exception ex) { }
        }
    }
}