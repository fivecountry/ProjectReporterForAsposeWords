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
        /// <summary>
        /// Word是否已经安装
        /// </summary>
        public bool IsWordInstalled = false;

        /// <summary>
        /// word版本
        /// </summary>
        public string WordVersion = string.Empty;

        /// <summary>
        /// 是否显示备份提示
        /// </summary>
        public bool EnabledShowBackupHint = true;

        private bool EnabledRefreshPage = false;

        public static MainForm Instance { get; set; }

        /// <summary>
        /// 基础目录
        /// </summary>
        public static string BaseDir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data");

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
        /// 编辑控件检索表
        /// </summary>
        public List<BaseEditor> EditorIndexLists = new List<BaseEditor>();

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

            //检查是否已经安装Word
            IsWordInstalled = ProjectReporter.Utility.WordUtility.OfficeIsInstall(out WordVersion);
            //btnwordview.Enabled = IsWordInstalled;
            //btnExport.Enabled = IsWordInstalled;
        }

        /// <summary>
        /// 初始化
        /// </summary>
        public void InitAll()
        {
            txtReportReadme.LoadDoc(Path.Combine(Application.StartupPath, Path.Combine("Helper", "introduction.rtf")));
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
            //保存所有
            //if (SaveAll())
            //{
                if (ProjectObj != null)
                {
                    WordExportForm frmExportWord = new WordExportForm(Path.Combine(MainForm.ProjectDir, "项目申报书.doc"));
                    frmExportWord.ShowDialog();

                    if (File.Exists(Path.Combine(MainForm.ProjectDir, "项目申报书.doc")))
                    {
                        try
                        {
                            System.Diagnostics.Process.Start(Path.Combine(MainForm.ProjectDir, "项目申报书.doc"));
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("对不起,打开项目申报书失败!Ex:" + ex.ToString());
                        }
                    }
                }
                else
                {
                    MessageBox.Show("对不起，请填写项目信息！");
                }
            //}
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            //保存所有
            if (SaveAll())
            {
                if (File.Exists(Path.Combine(MainForm.ProjectDir, "项目申报书.doc")) == false)
                {
                    MessageBox.Show("对不起，请先点击预览按钮生成项目申报书！");
                    return;
                }

                if (File.Exists(Path.Combine(MainForm.ProjectDir, "建议书.doc")) == false)
                {
                    MessageBox.Show("对不起，请上传项目建议书！");
                    return;
                }

                if (!this.IsInputCompleted())
                {
                    MessageBox.Show("请将所有内容填写完整再点击上报!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                if (!this.IsRightMoneyOrTime())
                {
                    return;
                }

                string unitName = ConnectionManager.Context.table("Unit").where("ID = (select UnitID from Project where ID = '" + ProjectObj.ID + "')").select("UnitName").getValue<string>(string.Empty);
                string personName = ConnectionManager.Context.table("Person").where("ID=(select PersonID from Task where Role = '负责人' and  ProjectID = '" + ProjectObj.ID + "')").select("Name").getValue<string>(string.Empty);
                string docName = unitName + "_" + personName;

                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "zip files(*.zip)|*.zip";
                saveFileDialog.FileName = docName + ".zip";
                saveFileDialog.FilterIndex = 0;
                saveFileDialog.RestoreDirectory = true;

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    new ZipExportForm(saveFileDialog.FileName).ShowDialog();
                }
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
                    if (GetPageControl(be) != null)
                    {
                        MessageBox.Show("对不起，页签(" + GetPageControl(be).Text + ")未填写完成，请检查！");
                    }
                    return false;
                }
            }

            return true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string unitName = ConnectionManager.Context.table("Unit").where("ID = (select UnitID from Project where ID = '" + ProjectObj.ID + "')").select("UnitName").getValue<string>(string.Empty);
            string personName = ConnectionManager.Context.table("Person").where("ID=(select PersonID from Task where Role = '负责人' and  ProjectID = '" + ProjectObj.ID + "')").select("Name").getValue<string>(string.Empty);
            string docName = unitName + "_" + personName;

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "zip files(*.zip)|*.zip";
            saveFileDialog.FileName = docName + ".zip";
            saveFileDialog.FilterIndex = 0;
            saveFileDialog.RestoreDirectory = true;

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                new ZipExportForm(saveFileDialog.FileName).ShowDialog();
            }
        }

        private void maintimer_Tick(object sender, EventArgs e)
        {
            this.lbcurtime.Text = "欢迎您！当前时间 " + DateTime.Now.ToString("yyyy年M月d日 H:mm:ss");
        }

        private void btnquit_Click(object sender, EventArgs e)
        {
            try
            {
                Application.Exit();
            }
            catch (Exception ex)
            {
                try
                {
                    System.Diagnostics.Process.GetCurrentProcess().Kill();
                }
                catch (Exception exx) { }
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);

            if (EnabledShowBackupHint)
            {
                if (MessageBox.Show("真的要保存吗？", "提示", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                {
                    //先保存
                    SaveAll();

                    //询问是否备份
                    //if (ProjectObj != null)
                    //{
                    //    DialogResult dialogResult = MessageBox.Show("退出前是否备份打包数据？", "提示", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Asterisk);
                    //    if (dialogResult == DialogResult.Yes)
                    //    {
                    //        this.btnSave_Click(this, e);
                    //    }
                    //}
                }
            }
            else
            {
                ConnectionManager.Close();
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

            if (IsWordInstalled == false)
            {
                MessageBox.Show("对不起，您可能没有安装Microsoft Office2007或Microsoft Office2010或安装异常，可能无法正常使用预览和导出功能！");
            }
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
                MessageBox.Show("对不起，数据库加载失败！Ex:" + ex.ToString());
                Application.Exit();
            }
        }

        private void LoadEditorEvents()
        {
            #region 控件列表
            EditorIndexLists = new List<BaseEditor>();
            EditorIndexLists.Add(feUI0);
            EditorIndexLists.Add(feUI1);
            EditorIndexLists.Add(feUI2);
            EditorIndexLists.Add(feUI3);
            //EditorIndexLists.Add(feUI30);
            EditorIndexLists.Add(feUI4);
            EditorIndexLists.Add(feUI5);
            EditorIndexLists.Add(feUI6);
            EditorIndexLists.Add(feUI7);
            EditorIndexLists.Add(feUI8);
            EditorIndexLists.Add(feUI9);
            EditorIndexLists.Add(feUI10);
            EditorIndexLists.Add(feUI11);
            //controlList.Add(feUI12);
            EditorIndexLists.Add(feUI13);
            EditorIndexLists.Add(feUI14);
            EditorIndexLists.Add(feUI15);
            EditorIndexLists.Add(feUI16);
            EditorIndexLists.Add(feUI17);
            EditorIndexLists.Add(feUI18);
            EditorIndexLists.Add(feUI19);
            EditorIndexLists.Add(feUI20);
            //EditorIndexLists.Add(feUI21);
            //EditorIndexLists.Add(feUI22);
            //EditorIndexLists.Add(feUI23);
            EditorIndexLists.Add(feUI24);
            EditorIndexLists.Add(feUI25);
            //EditorIndexLists.Add(feUI31);
            #endregion

            foreach (BaseEditor be in EditorIndexLists)
            {
                EditorMaps.Add(be.Name, be);

                be.SaveEvent += new SaveOrLastOrNextEventDelegate(be_SaveEvent);
                be.LastEvent += new SaveOrLastOrNextEventDelegate(be_LastEvent);
                be.NextEvent += new SaveOrLastOrNextEventDelegate(be_NextEvent);
            }
        }

        void be_NextEvent(object sender, EventArgs args)
        {
            BaseEditor current = (BaseEditor)sender;

            if (current.EnabledAutoNextPage)
            {
                //切换到下一页(正常顺序)
                SwitchToNextPage(current);
            }
            else
            {
                //使用自定义切换
                current.NextPage();
            }
        }

        /// <summary>
        /// 切换到下一页(正常顺序)
        /// </summary>
        /// <param name="current"></param>
        public void SwitchToNextPage(BaseEditor current)
        {
            //保存当前页
            SaveEditor(current);
            
            //下一步
            int currentIndex = EditorIndexLists.IndexOf(current);
            if (currentIndex + 1 >= EditorIndexLists.Count)
            {
                return;
            }
            else
            {
                BaseEditor next = EditorIndexLists[currentIndex + 1];
                if (next.Parent is KryptonPage)
                {
                    //上一个页签归0
                    KryptonNavigator subTab = GetTabControl(current);
                    subTab.SelectedIndex = 0;

                    //目标子Tab切换
                    subTab = GetTabControl(next);
                    subTab.SelectedPage = GetPageControl(next);

                    //主Tab切换
                    edithost2.SelectedPage = ((KryptonPage)subTab.Parent);
                }

                //刷新视图
                next.RefreshView();
            }
        }

        public void SaveEditor(BaseEditor current)
        {
            ProjectReporter.Forms.UIDoWorkProcessForm upf = new Forms.UIDoWorkProcessForm();
            upf.EnabledDisplayProgress = false;
            upf.LabalText = "正在保存,请等待...";
            upf.ShowProgress();

            try
            {
                //保存
                current.OnSaveEvent();
            }
            catch (Exception ex)
            {
                MessageBox.Show("保存失败！Ex:" + ex.ToString());
            }
            finally
            {
                upf.Close();
            }
        }

        /// <summary>
        /// 获得编辑控件所在的KryptonNavigator
        /// </summary>
        /// <param name="baseEditor"></param>
        /// <returns></returns>
        public KryptonNavigator GetTabControl(BaseEditor baseEditor)
        {
            return ((KryptonNavigator)GetPageControl(baseEditor).Parent.Parent);
        }

        /// <summary>
        /// 获得编辑控件所在的KryptonPage
        /// </summary>
        /// <param name="baseEditor"></param>
        /// <returns></returns>
        public KryptonPage GetPageControl(BaseEditor baseEditor)
        {
            return ((KryptonPage)baseEditor.Parent);
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

            string[] chsNumbers = new string[] { "一、", "二、", "三、", "四、", "五、", "六、", "七、", "八、", "九、", "十、", "十一、", "", "", "", "", "", "", "", "", };

            int iconIndex = 0;
            foreach (KryptonPage kp in edithost2.Pages)
            {
                Bitmap bmp = new Bitmap(200, 55);
                Graphics g = Graphics.FromImage(bmp);
                try
                {
                    //背景透明
                    g.FillRectangle(new SolidBrush(Color.Transparent), new Rectangle(0, 0, bmp.Width, bmp.Height));

                    // 取图标
                    //Image img = GetBarButtonIcon(iconIndex);
                    Image img = null;
                    if (iconIndex <= 1)
                    {
                        img = GetBarButtonIcon(iconIndex);
                    }

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
                        g.DrawString(chsNumbers[iconIndex - 2] + kp.Text, new Font("微软雅黑", 11), new SolidBrush(Color.Black), new RectangleF(10, 0, bmp.Width - 10, bmp.Height), sf);
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
                    return ProjectReporter.Properties.Resources.tianbao;
                case 1:
                    return ProjectReporter.Properties.Resources.xiangmuxinxi;
                case 2:
                    return ProjectReporter.Properties.Resources.II_1;
                case 3:
                    return ProjectReporter.Properties.Resources.II_2;
                case 4:
                    return ProjectReporter.Properties.Resources.II_3;
                case 5:
                    return ProjectReporter.Properties.Resources.II_4;
                case 6:
                    return ProjectReporter.Properties.Resources.II_5;
                case 7:
                    return ProjectReporter.Properties.Resources.II_6;
                case 8:
                    return ProjectReporter.Properties.Resources.II_7;
                case 9:
                    return ProjectReporter.Properties.Resources.II_8;
                case 10:
                    return ProjectReporter.Properties.Resources.II_9;
                case 11:
                    return ProjectReporter.Properties.Resources.II_10;
                case 12:
                    return ProjectReporter.Properties.Resources.II_11;
                case 13:
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
            RefreshAllEditor();

            //显示编辑控件
            //fnpDefault.Top = 0;
            //edithost2.Top = 0;
            //fnpDefault.Dock = DockStyle.None;
            //edithost2.Dock = DockStyle.None;
            //fnpDefault.Visible = false;
            //edithost2.Visible = true;
            //edithost2.Dock = DockStyle.Fill;

            SwitchToReportPage(2);
        }

        /// <summary>
        /// 切换到指定标签页
        /// </summary>
        /// <param name="pageIndex"></param>
        private void SwitchToReportPage(int pageIndex)
        {
            if (edithost2.Pages.Count > pageIndex)
            {
                edithost2.SelectedIndex = pageIndex;
            }
        }

        /// <summary>
        /// 刷新视图
        /// </summary>
        public void RefreshEditorWithoutRTFTextEditor()
        {
            if (ProjectObj != null)
            {
                fnpDefault.LoadProject();

                foreach (BaseEditor be in EditorMaps.Values)
                {
                    if (be is RTFTextEditor)
                    {
                        continue;
                    }

                    be.RefreshView();
                }
            }
        }

        public void RefreshAllEditor()
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
            //显示项目信息编辑控件
            //fnpDefault.Top = 0;
            //edithost2.Top = 0;
            //fnpDefault.Dock = DockStyle.None;
            //edithost2.Dock = DockStyle.None;
            //fnpDefault.Dock = DockStyle.Fill;
            //edithost2.Visible = false;
            //fnpDefault.Visible = true;

            SwitchToReportPage(0);
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
                UnitForm = new UnitExtSelectForm();
            }
            UnitForm.WindowState = FormWindowState.Normal;
            UnitForm.Show();
            UnitForm.BringToFront();
        }

        public PersonManagerForm PersonForm { get; set; }

        public UnitExtSelectForm UnitForm { get; set; }

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
            //try
            //{
            //    if (EnabledRefreshPage)
            //    {
            //        EnabledRefreshPage = false;

            //        if (ProjectObj != null)
            //        {
            //            //刷新视图
            //            RefreshAllEditor();
            //        }
            //        else
            //        {
            //            fnpDefault.LoadProject();
            //        }
            //    }
            //}
            //catch (Exception ex) { }
        }

        private void edithost2_SelectedPageChanged(object sender, EventArgs e)
        {
            if (ProjectObj == null)
            {
                if (edithost2.SelectedIndex >= 2)
                {
                    SwitchToReportPage(1);
                }
            }
        }

        /// <summary>
        /// 检查时间与金额一致性
        /// </summary>
        /// <returns></returns>
        private bool IsRightMoneyOrTime()
        {
            //项目总时间
            int totalTime = ConnectionManager.Context.table("Project").where("Type = '项目'").select("TotalTime").getValue<int>(0);

            //项目总金额
            decimal totalMoney = ConnectionManager.Context.table("Project").where("Type = '项目'").select("TotalMoney").getValue<decimal>(0);

            //经费表总额
            string projectMoneyStr = ConnectionManager.Context.table("MoneyAndYear").where("Name = 'ProjectRFA'").select("Value").getValue<string>("0");
            decimal projectMoney = 0;
            try
            {
                projectMoney = decimal.Parse(projectMoneyStr);
            }
            catch (Exception ex) { }

            //阶段总额
            long totalStepMoney = ConnectionManager.Context.table("Step").where("ProjectID = '" + MainForm.Instance.ProjectObj.ID + "'").select("sum(StepMoney)").getValue<long>(0);

            //阶段总时间
            long totalStepTime = (long)Math.Round(ConnectionManager.Context.table("Step").where("ProjectID = '" + MainForm.Instance.ProjectObj.ID + "'").select("sum(StepTime)").getValue<long>(0) / 12d);

            //课题阶段经费总额
            long totalKetiStepMoney = ConnectionManager.Context.table("ProjectAndStep").where("StepID in (select ID from Step where ProjectID in (select ID from Project where Type = '课题'))").select("sum(Money)").getValue<long>(0);

            //阶段经费表
            Noear.Weed.DataList dlStepList = ConnectionManager.Context.table("Step").where("ProjectID = '" + MainForm.Instance.ProjectObj.ID + "'").select("StepIndex,StepMoney").getDataList();

            //课题阶段经费表
            int totalRightStepCount = 0;
            int totalStepCount = 0;
            if (dlStepList != null && dlStepList.getRowCount() >= 1)
            {
                //阶段数量
                totalStepCount = dlStepList.getRowCount();

                //检查课题阶段金额
                foreach (Noear.Weed.DataItem di in dlStepList.getRows())
                {
                    try
                    {
                        int stepIndex = di.getInt("StepIndex");
                        long stepMoney = long.Parse(di.get("StepMoney").ToString());
                        long subjectStepMoney = ConnectionManager.Context.table("ProjectAndStep").where("StepID in (select ID from Step where ProjectID in (select ID from Project where Type = '课题') and StepIndex = " + stepIndex + ")").select("sum(Money)").getValue<long>(0);

                        //判断阶段经费是不是相等
                        if (stepMoney == subjectStepMoney)
                        {
                            totalRightStepCount++;
                        }
                    }
                    catch (Exception ex) { }
                }
            }

            if (totalMoney != projectMoney)
            {
                MessageBox.Show("对不起，项目总金额与经费表总金额不同，请检查!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (totalMoney != totalStepMoney)
            {
                MessageBox.Show("对不起，项目总金额与阶段总金额不同，请检查!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (totalMoney != totalKetiStepMoney)
            {
                MessageBox.Show("对不起，项目总金额与课题阶段总金额不同，请检查!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (totalTime != totalStepTime)
            {
                MessageBox.Show("对不起，项目总时间与阶段总时间不同，请检查!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (totalRightStepCount != totalStepCount)
            {
                MessageBox.Show("对不起，阶段金额与课题阶段金额不同，请检查!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            //判断条件是否符合
            return totalMoney == projectMoney && totalMoney == totalStepMoney && totalMoney == totalKetiStepMoney && totalTime == totalStepTime && totalRightStepCount == totalStepCount;
        }

        /// <summary>
        /// 保存所有
        /// </summary>
        public bool SaveAll()
        {
            //显示提示窗体
            UIDoWorkProcessForm upf = new UIDoWorkProcessForm();
            upf.EnabledDisplayProgress = true;
            upf.ProgresBarMaximum = EditorIndexLists.Count;
            upf.ShowProgress();

            //循环所有控件，一个一个保存
            try
            {
                foreach (BaseEditor be in EditorIndexLists)
                {
                    //保存
                    try
                    {
                        be.OnSaveEvent();
                    }
                    catch (Exception ex)
                    {
                        if (GetPageControl(be) != null)
                        {
                            MessageBox.Show("对不起，页签(" + GetPageControl(be).Text + ")保存失败！Ex:" + ex.ToString());
                            return false;
                        }
                    }

                    //进度条移动
                    upf.Next();
                }
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.ToString());
                return false;
            }
            finally
            {
                upf.Close();
            }

            return true;
        }

        private void btnSave2_Click(object sender, EventArgs e)
        {
            SaveAll();
            MessageBox.Show("保存完成！");
        }

        private void btnUploadReport_Click(object sender, EventArgs e)
        {
            ProjectDocForm form = new ProjectDocForm();
            form.ShowDialog();
        }
    }
}