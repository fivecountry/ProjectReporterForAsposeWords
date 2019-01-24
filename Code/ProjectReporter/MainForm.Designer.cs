using ComponentFactory.Krypton.Navigator;
using ProjectReporter.Controls;
using ComponentFactory.Krypton.Toolkit;
using System.Timers;
using System.Windows.Forms;
namespace ProjectReporter
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.kryptonPanel1 = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.btnUnitManager = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnPersonManager = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btninit = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnImport = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnwordview = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnSave = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnExport = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnhelp = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnquit = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.lbcurtime = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.buttonSpecAny1 = new ComponentFactory.Krypton.Toolkit.ButtonSpecAny();
            this.maintimer = new System.Windows.Forms.Timer(this.components);
            this.kryptonManager1 = new ComponentFactory.Krypton.Toolkit.KryptonManager(this.components);
            this.topBanner = new System.Windows.Forms.PictureBox();
            this.kpcontactinner = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.kryptonWrapLabel1 = new ComponentFactory.Krypton.Toolkit.KryptonWrapLabel();
            this.edithost2 = new ComponentFactory.Krypton.Navigator.KryptonNavigator();
            this.kryptonNavigator22 = new ComponentFactory.Krypton.Navigator.KryptonPage();
            this.kryptonNavigator7 = new ComponentFactory.Krypton.Navigator.KryptonNavigator();
            this.kpfPage1 = new ComponentFactory.Krypton.Navigator.KryptonPage();
            this.feUI1 = new ProjectReporter.Controls.RTFTextEditor();
            this.kpfPage2 = new ComponentFactory.Krypton.Navigator.KryptonPage();
            this.feUI2 = new ProjectReporter.Controls.RTFTextEditor();
            this.kpfPage3 = new ComponentFactory.Krypton.Navigator.KryptonPage();
            this.feUI3 = new ProjectReporter.Controls.RTFTextEditor();
            this.kryptonPage3 = new ComponentFactory.Krypton.Navigator.KryptonPage();
            this.kryptonNavigator8 = new ComponentFactory.Krypton.Navigator.KryptonNavigator();
            this.kryptonPage17 = new ComponentFactory.Krypton.Navigator.KryptonPage();
            this.feUI4 = new ProjectReporter.Controls.RTFTextEditor();
            this.kryptonPage4 = new ComponentFactory.Krypton.Navigator.KryptonPage();
            this.kryptonNavigator9 = new ComponentFactory.Krypton.Navigator.KryptonNavigator();
            this.kryptonPage18 = new ComponentFactory.Krypton.Navigator.KryptonPage();
            this.feUI5 = new ProjectReporter.Controls.RTFTextEditor();
            this.kryptonPage5 = new ComponentFactory.Krypton.Navigator.KryptonPage();
            this.kryptonNavigator10 = new ComponentFactory.Krypton.Navigator.KryptonNavigator();
            this.kryptonPage19 = new ComponentFactory.Krypton.Navigator.KryptonPage();
            this.feUI6 = new ProjectReporter.Controls.KeTiTianBaoEditor();
            this.kryptonPage16 = new ComponentFactory.Krypton.Navigator.KryptonPage();
            this.feUI7 = new ProjectReporter.Controls.RTFTextEditor();
            this.kryptonPage6 = new ComponentFactory.Krypton.Navigator.KryptonPage();
            this.kryptonNavigator11 = new ComponentFactory.Krypton.Navigator.KryptonNavigator();
            this.kryptonPage20 = new ComponentFactory.Krypton.Navigator.KryptonPage();
            this.feUI8 = new ProjectReporter.Controls.RTFTextEditor();
            this.kryptonPage56 = new ComponentFactory.Krypton.Navigator.KryptonPage();
            this.feUI9 = new ProjectReporter.Controls.RTFTextEditor();
            this.kryptonPage34 = new ComponentFactory.Krypton.Navigator.KryptonPage();
            this.feUI10 = new ProjectReporter.Controls.RTFTextEditor();
            this.kryptonPage7 = new ComponentFactory.Krypton.Navigator.KryptonPage();
            this.kryptonNavigator12 = new ComponentFactory.Krypton.Navigator.KryptonNavigator();
            this.kryptonPage21 = new ComponentFactory.Krypton.Navigator.KryptonPage();
            this.feUI11 = new ProjectReporter.Controls.JieDuanHuaFenEditor();
            this.kryptonPage35 = new ComponentFactory.Krypton.Navigator.KryptonPage();
            this.feUI12 = new ProjectReporter.Controls.XiangMuJieDuanHuaFenEditor();
            this.kryptonPage32 = new ComponentFactory.Krypton.Navigator.KryptonPage();
            this.feUI13 = new ProjectReporter.Controls.KeTiJieDuanHuaFenEditor();
            this.kryptonPage57 = new ComponentFactory.Krypton.Navigator.KryptonPage();
            this.kryptonNavigator13 = new ComponentFactory.Krypton.Navigator.KryptonNavigator();
            this.kryptonPage22 = new ComponentFactory.Krypton.Navigator.KryptonPage();
            this.feUI14 = new ProjectReporter.Controls.RTFTextEditor();
            this.kryptonPage36 = new ComponentFactory.Krypton.Navigator.KryptonPage();
            this.feUI15 = new ProjectReporter.Controls.RTFTextEditor();
            this.kryptonPage37 = new ComponentFactory.Krypton.Navigator.KryptonPage();
            this.feUI16 = new ProjectReporter.Controls.YanJiuGuGanEditor();
            this.kryptonPage9 = new ComponentFactory.Krypton.Navigator.KryptonPage();
            this.kryptonNavigator14 = new ComponentFactory.Krypton.Navigator.KryptonNavigator();
            this.kryptonPage23 = new ComponentFactory.Krypton.Navigator.KryptonPage();
            this.feUI17 = new ProjectReporter.Controls.RTFTextEditor();
            this.kryptonPage10 = new ComponentFactory.Krypton.Navigator.KryptonPage();
            this.kryptonNavigator15 = new ComponentFactory.Krypton.Navigator.KryptonNavigator();
            this.kryptonPage24 = new ComponentFactory.Krypton.Navigator.KryptonPage();
            this.feUI18 = new ProjectReporter.Controls.RTFTextEditor();
            this.kryptonPage11 = new ComponentFactory.Krypton.Navigator.KryptonPage();
            this.kryptonNavigator16 = new ComponentFactory.Krypton.Navigator.KryptonNavigator();
            this.kryptonPage25 = new ComponentFactory.Krypton.Navigator.KryptonPage();
            this.feUI19 = new ProjectReporter.Controls.RTFTextEditor();
            this.kryptonPage12 = new ComponentFactory.Krypton.Navigator.KryptonPage();
            this.kryptonNavigator17 = new ComponentFactory.Krypton.Navigator.KryptonNavigator();
            this.kryptonPage26 = new ComponentFactory.Krypton.Navigator.KryptonPage();
            this.feUI20 = new ProjectReporter.Controls.JingFeiYuSuanEditor();
            this.kryptonPage13 = new ComponentFactory.Krypton.Navigator.KryptonPage();
            this.kryptonNavigator18 = new ComponentFactory.Krypton.Navigator.KryptonNavigator();
            this.kryptonPage27 = new ComponentFactory.Krypton.Navigator.KryptonPage();
            this.feUI21 = new ProjectReporter.Controls.FuZeRenEditor();
            this.kryptonPage38 = new ComponentFactory.Krypton.Navigator.KryptonPage();
            this.feUI22 = new ProjectReporter.Controls.QianTouDanWeiEditor();
            this.kryptonPage39 = new ComponentFactory.Krypton.Navigator.KryptonPage();
            this.feUI23 = new ProjectReporter.Controls.KeTiLianXiEditor();
            this.kryptonPage14 = new ComponentFactory.Krypton.Navigator.KryptonPage();
            this.kryptonNavigator19 = new ComponentFactory.Krypton.Navigator.KryptonNavigator();
            this.kryptonPage28 = new ComponentFactory.Krypton.Navigator.KryptonPage();
            this.feUI24 = new ProjectReporter.Controls.XiangMuJingFeiGaiSuanShuoMingEditor();
            this.kryptonPage15 = new ComponentFactory.Krypton.Navigator.KryptonPage();
            this.kryptonNavigator20 = new ComponentFactory.Krypton.Navigator.KryptonNavigator();
            this.kryptonPage29 = new ComponentFactory.Krypton.Navigator.KryptonPage();
            this.feUI25 = new ProjectReporter.Controls.BaoMiZiZhiFuYinJianEditor();
            this.fnpDefault = new ProjectReporter.Controls.NewProjectEditor();
            this.kpcontact = new ProjectReporter.Controls.HSkinTableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.topBanner)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kpcontactinner)).BeginInit();
            this.kpcontactinner.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edithost2)).BeginInit();
            this.edithost2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonNavigator22)).BeginInit();
            this.kryptonNavigator22.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonNavigator7)).BeginInit();
            this.kryptonNavigator7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kpfPage1)).BeginInit();
            this.kpfPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kpfPage2)).BeginInit();
            this.kpfPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kpfPage3)).BeginInit();
            this.kpfPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPage3)).BeginInit();
            this.kryptonPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonNavigator8)).BeginInit();
            this.kryptonNavigator8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPage17)).BeginInit();
            this.kryptonPage17.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPage4)).BeginInit();
            this.kryptonPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonNavigator9)).BeginInit();
            this.kryptonNavigator9.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPage18)).BeginInit();
            this.kryptonPage18.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPage5)).BeginInit();
            this.kryptonPage5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonNavigator10)).BeginInit();
            this.kryptonNavigator10.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPage19)).BeginInit();
            this.kryptonPage19.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPage16)).BeginInit();
            this.kryptonPage16.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPage6)).BeginInit();
            this.kryptonPage6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonNavigator11)).BeginInit();
            this.kryptonNavigator11.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPage20)).BeginInit();
            this.kryptonPage20.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPage56)).BeginInit();
            this.kryptonPage56.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPage34)).BeginInit();
            this.kryptonPage34.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPage7)).BeginInit();
            this.kryptonPage7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonNavigator12)).BeginInit();
            this.kryptonNavigator12.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPage21)).BeginInit();
            this.kryptonPage21.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPage35)).BeginInit();
            this.kryptonPage35.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPage32)).BeginInit();
            this.kryptonPage32.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPage57)).BeginInit();
            this.kryptonPage57.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonNavigator13)).BeginInit();
            this.kryptonNavigator13.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPage22)).BeginInit();
            this.kryptonPage22.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPage36)).BeginInit();
            this.kryptonPage36.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPage37)).BeginInit();
            this.kryptonPage37.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPage9)).BeginInit();
            this.kryptonPage9.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonNavigator14)).BeginInit();
            this.kryptonNavigator14.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPage23)).BeginInit();
            this.kryptonPage23.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPage10)).BeginInit();
            this.kryptonPage10.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonNavigator15)).BeginInit();
            this.kryptonNavigator15.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPage24)).BeginInit();
            this.kryptonPage24.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPage11)).BeginInit();
            this.kryptonPage11.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonNavigator16)).BeginInit();
            this.kryptonNavigator16.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPage25)).BeginInit();
            this.kryptonPage25.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPage12)).BeginInit();
            this.kryptonPage12.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonNavigator17)).BeginInit();
            this.kryptonNavigator17.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPage26)).BeginInit();
            this.kryptonPage26.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPage13)).BeginInit();
            this.kryptonPage13.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonNavigator18)).BeginInit();
            this.kryptonNavigator18.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPage27)).BeginInit();
            this.kryptonPage27.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPage38)).BeginInit();
            this.kryptonPage38.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPage39)).BeginInit();
            this.kryptonPage39.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPage14)).BeginInit();
            this.kryptonPage14.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonNavigator19)).BeginInit();
            this.kryptonNavigator19.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPage28)).BeginInit();
            this.kryptonPage28.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPage15)).BeginInit();
            this.kryptonPage15.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonNavigator20)).BeginInit();
            this.kryptonNavigator20.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPage29)).BeginInit();
            this.kryptonPage29.SuspendLayout();
            this.SuspendLayout();
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.btnUnitManager);
            this.kryptonPanel1.Controls.Add(this.btnPersonManager);
            this.kryptonPanel1.Controls.Add(this.btninit);
            this.kryptonPanel1.Controls.Add(this.btnImport);
            this.kryptonPanel1.Controls.Add(this.btnwordview);
            this.kryptonPanel1.Controls.Add(this.btnSave);
            this.kryptonPanel1.Controls.Add(this.btnExport);
            this.kryptonPanel1.Controls.Add(this.btnhelp);
            this.kryptonPanel1.Controls.Add(this.btnquit);
            this.kryptonPanel1.Controls.Add(this.lbcurtime);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Size = new System.Drawing.Size(1458, 40);
            this.kryptonPanel1.TabIndex = 1;
            // 
            // btnUnitManager
            // 
            this.btnUnitManager.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnUnitManager.Location = new System.Drawing.Point(648, 0);
            this.btnUnitManager.Name = "btnUnitManager";
            this.btnUnitManager.Size = new System.Drawing.Size(90, 40);
            this.btnUnitManager.StateCommon.Content.ShortText.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnUnitManager.TabIndex = 27;
            this.btnUnitManager.Values.Text = "单位管理";
            this.btnUnitManager.Click += new System.EventHandler(this.btnUnitManager_Click);
            // 
            // btnPersonManager
            // 
            this.btnPersonManager.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnPersonManager.Location = new System.Drawing.Point(738, 0);
            this.btnPersonManager.Name = "btnPersonManager";
            this.btnPersonManager.Size = new System.Drawing.Size(90, 40);
            this.btnPersonManager.StateCommon.Content.ShortText.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnPersonManager.TabIndex = 26;
            this.btnPersonManager.Values.Text = "人员管理";
            this.btnPersonManager.Click += new System.EventHandler(this.btnPersonManager_Click);
            // 
            // btninit
            // 
            this.btninit.Dock = System.Windows.Forms.DockStyle.Right;
            this.btninit.Location = new System.Drawing.Point(828, 0);
            this.btninit.Name = "btninit";
            this.btninit.Size = new System.Drawing.Size(90, 40);
            this.btninit.StateCommon.Back.Image = global::ProjectReporter.Properties.Resources.New;
            this.btninit.TabIndex = 25;
            this.btninit.Values.Text = "";
            this.btninit.Click += new System.EventHandler(this.btninit_Click);
            // 
            // btnImport
            // 
            this.btnImport.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnImport.Location = new System.Drawing.Point(918, 0);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(90, 40);
            this.btnImport.StateCommon.Back.Image = global::ProjectReporter.Properties.Resources.Import;
            this.btnImport.TabIndex = 24;
            this.btnImport.Values.Text = "";
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // btnwordview
            // 
            this.btnwordview.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnwordview.Location = new System.Drawing.Point(1008, 0);
            this.btnwordview.Name = "btnwordview";
            this.btnwordview.Size = new System.Drawing.Size(90, 40);
            this.btnwordview.StateCommon.Back.Image = global::ProjectReporter.Properties.Resources.preview;
            this.btnwordview.TabIndex = 23;
            this.btnwordview.Values.Text = "";
            this.btnwordview.Click += new System.EventHandler(this.btnwordview_Click);
            // 
            // btnSave
            // 
            this.btnSave.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnSave.Location = new System.Drawing.Point(1098, 0);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(90, 40);
            this.btnSave.StateCommon.Back.Image = global::ProjectReporter.Properties.Resources.TEMPSAVE;
            this.btnSave.TabIndex = 22;
            this.btnSave.Values.Text = "";
            this.btnSave.Visible = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnExport
            // 
            this.btnExport.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnExport.Location = new System.Drawing.Point(1188, 0);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(90, 40);
            this.btnExport.StateCommon.Back.Image = global::ProjectReporter.Properties.Resources.UpLoad;
            this.btnExport.TabIndex = 13;
            this.btnExport.Values.Text = "";
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // btnhelp
            // 
            this.btnhelp.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnhelp.Location = new System.Drawing.Point(1278, 0);
            this.btnhelp.Name = "btnhelp";
            this.btnhelp.Size = new System.Drawing.Size(90, 40);
            this.btnhelp.StateCommon.Back.Image = global::ProjectReporter.Properties.Resources.Help;
            this.btnhelp.StateCommon.Content.ShortText.Font = new System.Drawing.Font("黑体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnhelp.TabIndex = 10;
            this.btnhelp.Values.Text = "";
            this.btnhelp.Click += new System.EventHandler(this.btnhelp_Click);
            // 
            // btnquit
            // 
            this.btnquit.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnquit.Location = new System.Drawing.Point(1368, 0);
            this.btnquit.Name = "btnquit";
            this.btnquit.Size = new System.Drawing.Size(90, 40);
            this.btnquit.StateCommon.Back.Image = global::ProjectReporter.Properties.Resources.Quit;
            this.btnquit.TabIndex = 5;
            this.btnquit.Values.Text = "";
            this.btnquit.Click += new System.EventHandler(this.btnquit_Click);
            // 
            // lbcurtime
            // 
            this.lbcurtime.Dock = System.Windows.Forms.DockStyle.Left;
            this.lbcurtime.Location = new System.Drawing.Point(0, 0);
            this.lbcurtime.Name = "lbcurtime";
            this.lbcurtime.Size = new System.Drawing.Size(78, 40);
            this.lbcurtime.StateCommon.ShortText.Font = new System.Drawing.Font("楷体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbcurtime.TabIndex = 4;
            this.lbcurtime.Values.Text = "欢迎您！";
            // 
            // buttonSpecAny1
            // 
            this.buttonSpecAny1.UniqueName = "CB556486DAA54590678FC8384AD53700";
            // 
            // maintimer
            // 
            this.maintimer.Enabled = true;
            this.maintimer.Interval = 1000;
            this.maintimer.Tick += new System.EventHandler(this.maintimer_Tick);
            // 
            // kryptonManager1
            // 
            this.kryptonManager1.GlobalPaletteMode = ComponentFactory.Krypton.Toolkit.PaletteModeManager.Office2010Silver;
            // 
            // topBanner
            // 
            this.topBanner.Dock = System.Windows.Forms.DockStyle.Top;
            this.topBanner.Location = new System.Drawing.Point(0, 0);
            this.topBanner.Name = "topBanner";
            this.topBanner.Size = new System.Drawing.Size(1366, 120);
            this.topBanner.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.topBanner.TabIndex = 0;
            this.topBanner.TabStop = false;
            // 
            // kpcontactinner
            // 
            this.kpcontactinner.Controls.Add(this.kryptonWrapLabel1);
            this.kpcontactinner.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kpcontactinner.Location = new System.Drawing.Point(1, 1);
            this.kpcontactinner.Margin = new System.Windows.Forms.Padding(1);
            this.kpcontactinner.Name = "kpcontactinner";
            this.kpcontactinner.Size = new System.Drawing.Size(0, 95);
            this.kpcontactinner.TabIndex = 3;
            // 
            // kryptonWrapLabel1
            // 
            this.kryptonWrapLabel1.Font = new System.Drawing.Font("黑体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.kryptonWrapLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(59)))), ((int)(((byte)(59)))));
            this.kryptonWrapLabel1.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.TitleControl;
            this.kryptonWrapLabel1.Location = new System.Drawing.Point(5, 22);
            this.kryptonWrapLabel1.Margin = new System.Windows.Forms.Padding(0);
            this.kryptonWrapLabel1.Name = "kryptonWrapLabel1";
            this.kryptonWrapLabel1.Size = new System.Drawing.Size(0, 16);
            this.kryptonWrapLabel1.StateCommon.Font = new System.Drawing.Font("黑体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            // 
            // edithost2
            // 
            this.edithost2.AllowPageReorder = false;
            this.edithost2.Bar.BarMapText = ComponentFactory.Krypton.Navigator.MapKryptonPageText.Text;
            this.edithost2.Bar.BarOrientation = ComponentFactory.Krypton.Toolkit.VisualOrientation.Left;
            this.edithost2.Bar.ItemMaximumSize = new System.Drawing.Size(300, 200);
            this.edithost2.Bar.ItemMinimumSize = new System.Drawing.Size(240, 30);
            this.edithost2.Bar.ItemOrientation = ComponentFactory.Krypton.Toolkit.ButtonOrientation.FixedTop;
            this.edithost2.Button.CloseButtonDisplay = ComponentFactory.Krypton.Navigator.ButtonDisplay.Hide;
            this.edithost2.Location = new System.Drawing.Point(18, 125);
            this.edithost2.Name = "edithost2";
            this.edithost2.NavigatorMode = ComponentFactory.Krypton.Navigator.NavigatorMode.BarRibbonTabGroup;
            this.edithost2.Pages.AddRange(new ComponentFactory.Krypton.Navigator.KryptonPage[] {
            this.kryptonNavigator22,
            this.kryptonPage3,
            this.kryptonPage4,
            this.kryptonPage5,
            this.kryptonPage6,
            this.kryptonPage7,
            this.kryptonPage57,
            this.kryptonPage9,
            this.kryptonPage10,
            this.kryptonPage11,
            this.kryptonPage12,
            this.kryptonPage13,
            this.kryptonPage14,
            this.kryptonPage15});
            this.edithost2.SelectedIndex = 0;
            this.edithost2.Size = new System.Drawing.Size(1356, 515);
            this.edithost2.TabIndex = 4;
            this.edithost2.Visible = false;
            // 
            // kryptonNavigator22
            // 
            this.kryptonNavigator22.AutoHiddenSlideSize = new System.Drawing.Size(200, 200);
            this.kryptonNavigator22.Controls.Add(this.kryptonNavigator7);
            this.kryptonNavigator22.Flags = 65534;
            this.kryptonNavigator22.LastVisibleSet = true;
            this.kryptonNavigator22.MinimumSize = new System.Drawing.Size(50, 50);
            this.kryptonNavigator22.Name = "kryptonNavigator22";
            this.kryptonNavigator22.Size = new System.Drawing.Size(1114, 513);
            this.kryptonNavigator22.Text = "概述";
            this.kryptonNavigator22.ToolTipTitle = "Page ToolTip";
            this.kryptonNavigator22.UniqueName = "33D955EDE7674DC864A18B2B491B4501";
            // 
            // kryptonNavigator7
            // 
            this.kryptonNavigator7.Button.CloseButtonDisplay = ComponentFactory.Krypton.Navigator.ButtonDisplay.Hide;
            this.kryptonNavigator7.Button.ContextButtonDisplay = ComponentFactory.Krypton.Navigator.ButtonDisplay.Hide;
            this.kryptonNavigator7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonNavigator7.Location = new System.Drawing.Point(0, 0);
            this.kryptonNavigator7.Name = "kryptonNavigator7";
            this.kryptonNavigator7.Pages.AddRange(new ComponentFactory.Krypton.Navigator.KryptonPage[] {
            this.kpfPage1,
            this.kpfPage2,
            this.kpfPage3});
            this.kryptonNavigator7.SelectedIndex = 0;
            this.kryptonNavigator7.Size = new System.Drawing.Size(1114, 513);
            this.kryptonNavigator7.TabIndex = 1;
            this.kryptonNavigator7.Text = "kryptonNavigator7";
            // 
            // kpfPage1
            // 
            this.kpfPage1.AutoHiddenSlideSize = new System.Drawing.Size(200, 200);
            this.kpfPage1.Controls.Add(this.feUI1);
            this.kpfPage1.Flags = 65534;
            this.kpfPage1.LastVisibleSet = true;
            this.kpfPage1.MinimumSize = new System.Drawing.Size(50, 50);
            this.kpfPage1.Name = "kpfPage1";
            this.kpfPage1.Size = new System.Drawing.Size(1112, 483);
            this.kpfPage1.StateCommon.Tab.Content.ShortText.Font = new System.Drawing.Font("黑体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.kpfPage1.Text = "基本概念及内涵";
            this.kpfPage1.ToolTipTitle = "Page ToolTip";
            this.kpfPage1.UniqueName = "601ED654FB3447B6B3944404A612B730";
            // 
            // feUI1
            // 
            this.feUI1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.feUI1.EnabledLastButton = true;
            this.feUI1.EnabledNextButton = true;
            this.feUI1.EnabledSaveButton = true;
            this.feUI1.Location = new System.Drawing.Point(0, 0);
            this.feUI1.Name = "feUI1";
            this.feUI1.ParentForm = null;
            this.feUI1.RTFEditorNameKey = "feUI";
            this.feUI1.RTFFileFirstName = "rtpinput_";
            this.feUI1.Size = new System.Drawing.Size(1112, 483);
            this.feUI1.TabIndex = 1;
            this.feUI1.TitleLabelText = "简要介绍相关研究对象的基本概念及内涵等";
            // 
            // kpfPage2
            // 
            this.kpfPage2.AutoHiddenSlideSize = new System.Drawing.Size(200, 200);
            this.kpfPage2.Controls.Add(this.feUI2);
            this.kpfPage2.Flags = 65534;
            this.kpfPage2.LastVisibleSet = true;
            this.kpfPage2.MinimumSize = new System.Drawing.Size(50, 50);
            this.kpfPage2.Name = "kpfPage2";
            this.kpfPage2.Size = new System.Drawing.Size(1112, 483);
            this.kpfPage2.StateCommon.Tab.Content.ShortText.Font = new System.Drawing.Font("黑体", 12F);
            this.kpfPage2.Text = "军事需求分析";
            this.kpfPage2.ToolTipTitle = "Page ToolTip";
            this.kpfPage2.UniqueName = "ABAECFFE58E74F8CD4AB0726EF7D36D1";
            // 
            // feUI2
            // 
            this.feUI2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.feUI2.EnabledLastButton = true;
            this.feUI2.EnabledNextButton = true;
            this.feUI2.EnabledSaveButton = true;
            this.feUI2.Location = new System.Drawing.Point(0, 0);
            this.feUI2.Name = "feUI2";
            this.feUI2.ParentForm = null;
            this.feUI2.RTFEditorNameKey = "feUI";
            this.feUI2.RTFFileFirstName = "rtpinput_";
            this.feUI2.Size = new System.Drawing.Size(1112, 483);
            this.feUI2.TabIndex = 1;
            this.feUI2.TitleLabelText = "分析本项目有关军事需求背景，提出面临的困难和瓶颈问题等";
            // 
            // kpfPage3
            // 
            this.kpfPage3.AutoHiddenSlideSize = new System.Drawing.Size(200, 200);
            this.kpfPage3.Controls.Add(this.feUI3);
            this.kpfPage3.Flags = 65534;
            this.kpfPage3.LastVisibleSet = true;
            this.kpfPage3.MinimumSize = new System.Drawing.Size(50, 50);
            this.kpfPage3.Name = "kpfPage3";
            this.kpfPage3.Size = new System.Drawing.Size(1112, 483);
            this.kpfPage3.StateCommon.Tab.Content.ShortText.Font = new System.Drawing.Font("黑体", 12F);
            this.kpfPage3.Text = "研究状态";
            this.kpfPage3.ToolTipTitle = "Page ToolTip";
            this.kpfPage3.UniqueName = "BBF2813E462E4E455599AA44FDC01FC7";
            // 
            // feUI3
            // 
            this.feUI3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.feUI3.EnabledLastButton = true;
            this.feUI3.EnabledNextButton = true;
            this.feUI3.EnabledSaveButton = true;
            this.feUI3.Location = new System.Drawing.Point(0, 0);
            this.feUI3.Name = "feUI3";
            this.feUI3.ParentForm = null;
            this.feUI3.RTFEditorNameKey = "feUI";
            this.feUI3.RTFFileFirstName = "rtpinput_";
            this.feUI3.Size = new System.Drawing.Size(1112, 483);
            this.feUI3.TabIndex = 1;
            this.feUI3.TitleLabelText = "全面客观地论述国内外研究现状，重点聚焦与本项目核心问题相关的技术研究情况，包括研究水平、差距不足等，注重定量描述，避免泛泛而谈";
            // 
            // kryptonPage3
            // 
            this.kryptonPage3.AutoHiddenSlideSize = new System.Drawing.Size(200, 200);
            this.kryptonPage3.Controls.Add(this.kryptonNavigator8);
            this.kryptonPage3.Flags = 65534;
            this.kryptonPage3.LastVisibleSet = true;
            this.kryptonPage3.MinimumSize = new System.Drawing.Size(50, 50);
            this.kryptonPage3.Name = "kryptonPage3";
            this.kryptonPage3.Size = new System.Drawing.Size(1114, 513);
            this.kryptonPage3.Text = "研究目标";
            this.kryptonPage3.ToolTipTitle = "Page ToolTip";
            this.kryptonPage3.UniqueName = "540D0A4E78A5440A5AA9F8F65E37CC83";
            // 
            // kryptonNavigator8
            // 
            this.kryptonNavigator8.Button.CloseButtonDisplay = ComponentFactory.Krypton.Navigator.ButtonDisplay.Hide;
            this.kryptonNavigator8.Button.ContextButtonDisplay = ComponentFactory.Krypton.Navigator.ButtonDisplay.Hide;
            this.kryptonNavigator8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonNavigator8.Location = new System.Drawing.Point(0, 0);
            this.kryptonNavigator8.Name = "kryptonNavigator8";
            this.kryptonNavigator8.Pages.AddRange(new ComponentFactory.Krypton.Navigator.KryptonPage[] {
            this.kryptonPage17});
            this.kryptonNavigator8.SelectedIndex = 0;
            this.kryptonNavigator8.Size = new System.Drawing.Size(1114, 513);
            this.kryptonNavigator8.TabIndex = 2;
            this.kryptonNavigator8.Text = "kryptonNavigator8";
            // 
            // kryptonPage17
            // 
            this.kryptonPage17.AutoHiddenSlideSize = new System.Drawing.Size(200, 200);
            this.kryptonPage17.Controls.Add(this.feUI4);
            this.kryptonPage17.Flags = 65534;
            this.kryptonPage17.LastVisibleSet = true;
            this.kryptonPage17.MinimumSize = new System.Drawing.Size(50, 50);
            this.kryptonPage17.Name = "kryptonPage17";
            this.kryptonPage17.Size = new System.Drawing.Size(1112, 483);
            this.kryptonPage17.StateCommon.Tab.Content.ShortText.Font = new System.Drawing.Font("黑体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.kryptonPage17.Text = "研究目标";
            this.kryptonPage17.ToolTipTitle = "Page ToolTip";
            this.kryptonPage17.UniqueName = "601ED654FB3447B6B3944404A612B730";
            // 
            // feUI4
            // 
            this.feUI4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.feUI4.EnabledLastButton = true;
            this.feUI4.EnabledNextButton = true;
            this.feUI4.EnabledSaveButton = true;
            this.feUI4.Location = new System.Drawing.Point(0, 0);
            this.feUI4.Name = "feUI4";
            this.feUI4.ParentForm = null;
            this.feUI4.RTFEditorNameKey = "feUI";
            this.feUI4.RTFFileFirstName = "rtpinput_";
            this.feUI4.Size = new System.Drawing.Size(1112, 483);
            this.feUI4.TabIndex = 1;
            this.feUI4.TitleLabelText = "凝练提出项目研究目标，表述需明确、具体、准确，避免过于笼统。";
            // 
            // kryptonPage4
            // 
            this.kryptonPage4.AutoHiddenSlideSize = new System.Drawing.Size(200, 200);
            this.kryptonPage4.Controls.Add(this.kryptonNavigator9);
            this.kryptonPage4.Flags = 65534;
            this.kryptonPage4.LastVisibleSet = true;
            this.kryptonPage4.MinimumSize = new System.Drawing.Size(50, 50);
            this.kryptonPage4.Name = "kryptonPage4";
            this.kryptonPage4.Size = new System.Drawing.Size(1114, 513);
            this.kryptonPage4.Text = "基础性问题";
            this.kryptonPage4.ToolTipTitle = "Page ToolTip";
            this.kryptonPage4.UniqueName = "B93B5040088B4E9AB9AF4D3CA00B7065";
            // 
            // kryptonNavigator9
            // 
            this.kryptonNavigator9.Button.CloseButtonDisplay = ComponentFactory.Krypton.Navigator.ButtonDisplay.Hide;
            this.kryptonNavigator9.Button.ContextButtonDisplay = ComponentFactory.Krypton.Navigator.ButtonDisplay.Hide;
            this.kryptonNavigator9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonNavigator9.Location = new System.Drawing.Point(0, 0);
            this.kryptonNavigator9.Name = "kryptonNavigator9";
            this.kryptonNavigator9.Pages.AddRange(new ComponentFactory.Krypton.Navigator.KryptonPage[] {
            this.kryptonPage18});
            this.kryptonNavigator9.SelectedIndex = 0;
            this.kryptonNavigator9.Size = new System.Drawing.Size(1114, 513);
            this.kryptonNavigator9.TabIndex = 2;
            this.kryptonNavigator9.Text = "kryptonNavigator9";
            // 
            // kryptonPage18
            // 
            this.kryptonPage18.AutoHiddenSlideSize = new System.Drawing.Size(200, 200);
            this.kryptonPage18.Controls.Add(this.feUI5);
            this.kryptonPage18.Flags = 65534;
            this.kryptonPage18.LastVisibleSet = true;
            this.kryptonPage18.MinimumSize = new System.Drawing.Size(50, 50);
            this.kryptonPage18.Name = "kryptonPage18";
            this.kryptonPage18.Size = new System.Drawing.Size(1112, 483);
            this.kryptonPage18.StateCommon.Tab.Content.ShortText.Font = new System.Drawing.Font("黑体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.kryptonPage18.Text = "基础性问题";
            this.kryptonPage18.ToolTipTitle = "Page ToolTip";
            this.kryptonPage18.UniqueName = "601ED654FB3447B6B3944404A612B730";
            // 
            // feUI5
            // 
            this.feUI5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.feUI5.EnabledLastButton = true;
            this.feUI5.EnabledNextButton = true;
            this.feUI5.EnabledSaveButton = true;
            this.feUI5.Location = new System.Drawing.Point(0, 0);
            this.feUI5.Name = "feUI5";
            this.feUI5.ParentForm = null;
            this.feUI5.RTFEditorNameKey = "feUI";
            this.feUI5.RTFFileFirstName = "rtpinput_";
            this.feUI5.Size = new System.Drawing.Size(1112, 483);
            this.feUI5.TabIndex = 1;
            this.feUI5.TitleLabelText = "围绕项目研究目标，突出国防基础研究的任务特点，梳理提出本项目需要重点研究解决的基础性问题(简要描述每个问题，200字以内)";
            // 
            // kryptonPage5
            // 
            this.kryptonPage5.AutoHiddenSlideSize = new System.Drawing.Size(200, 200);
            this.kryptonPage5.Controls.Add(this.kryptonNavigator10);
            this.kryptonPage5.Flags = 65534;
            this.kryptonPage5.LastVisibleSet = true;
            this.kryptonPage5.MinimumSize = new System.Drawing.Size(50, 50);
            this.kryptonPage5.Name = "kryptonPage5";
            this.kryptonPage5.Size = new System.Drawing.Size(1114, 513);
            this.kryptonPage5.StateCommon.Tab.Content.ShortText.Font = new System.Drawing.Font("黑体", 12F);
            this.kryptonPage5.Text = "课题分解";
            this.kryptonPage5.ToolTipTitle = "Page ToolTip";
            this.kryptonPage5.UniqueName = "13F717104302419853A02559F94C24C0";
            // 
            // kryptonNavigator10
            // 
            this.kryptonNavigator10.Button.CloseButtonDisplay = ComponentFactory.Krypton.Navigator.ButtonDisplay.Hide;
            this.kryptonNavigator10.Button.ContextButtonDisplay = ComponentFactory.Krypton.Navigator.ButtonDisplay.Hide;
            this.kryptonNavigator10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonNavigator10.Location = new System.Drawing.Point(0, 0);
            this.kryptonNavigator10.Name = "kryptonNavigator10";
            this.kryptonNavigator10.Pages.AddRange(new ComponentFactory.Krypton.Navigator.KryptonPage[] {
            this.kryptonPage19,
            this.kryptonPage16});
            this.kryptonNavigator10.SelectedIndex = 0;
            this.kryptonNavigator10.Size = new System.Drawing.Size(1114, 513);
            this.kryptonNavigator10.TabIndex = 2;
            this.kryptonNavigator10.Text = "kryptonNavigator10";
            // 
            // kryptonPage19
            // 
            this.kryptonPage19.AutoHiddenSlideSize = new System.Drawing.Size(200, 200);
            this.kryptonPage19.Controls.Add(this.feUI6);
            this.kryptonPage19.Flags = 65534;
            this.kryptonPage19.LastVisibleSet = true;
            this.kryptonPage19.MinimumSize = new System.Drawing.Size(50, 50);
            this.kryptonPage19.Name = "kryptonPage19";
            this.kryptonPage19.Size = new System.Drawing.Size(1112, 483);
            this.kryptonPage19.StateCommon.Tab.Content.ShortText.Font = new System.Drawing.Font("黑体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.kryptonPage19.Text = "课题填报";
            this.kryptonPage19.ToolTipTitle = "Page ToolTip";
            this.kryptonPage19.UniqueName = "601ED654FB3447B6B3944404A612B730";
            // 
            // feUI6
            // 
            this.feUI6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.feUI6.KeTiList = null;
            this.feUI6.Location = new System.Drawing.Point(0, 0);
            this.feUI6.Name = "feUI6";
            this.feUI6.ParentForm = null;
            this.feUI6.PersonList = null;
            this.feUI6.Size = new System.Drawing.Size(1112, 483);
            this.feUI6.TabIndex = 0;
            this.feUI6.UnitList = null;
            // 
            // kryptonPage16
            // 
            this.kryptonPage16.AutoHiddenSlideSize = new System.Drawing.Size(200, 200);
            this.kryptonPage16.Controls.Add(this.feUI7);
            this.kryptonPage16.Flags = 65534;
            this.kryptonPage16.LastVisibleSet = true;
            this.kryptonPage16.MinimumSize = new System.Drawing.Size(50, 50);
            this.kryptonPage16.Name = "kryptonPage16";
            this.kryptonPage16.Size = new System.Drawing.Size(1112, 483);
            this.kryptonPage16.StateCommon.Tab.Content.ShortText.Font = new System.Drawing.Font("黑体", 12F);
            this.kryptonPage16.Text = "课题关系";
            this.kryptonPage16.ToolTipTitle = "Page ToolTip";
            this.kryptonPage16.UniqueName = "0EA59E7B7C584FAB7B913DD4E0F47344";
            // 
            // feUI7
            // 
            this.feUI7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.feUI7.EnabledLastButton = true;
            this.feUI7.EnabledNextButton = true;
            this.feUI7.EnabledSaveButton = true;
            this.feUI7.Location = new System.Drawing.Point(0, 0);
            this.feUI7.Name = "feUI7";
            this.feUI7.ParentForm = null;
            this.feUI7.RTFEditorNameKey = "feUI";
            this.feUI7.RTFFileFirstName = "rtpinput_";
            this.feUI7.Size = new System.Drawing.Size(1112, 483);
            this.feUI7.TabIndex = 0;
            this.feUI7.TitleLabelText = "基础性问题与课题之间的关系、各课题之间的关系（简要叙述，建议500字之内，可用图表示）";
            // 
            // kryptonPage6
            // 
            this.kryptonPage6.AutoHiddenSlideSize = new System.Drawing.Size(200, 200);
            this.kryptonPage6.Controls.Add(this.kryptonNavigator11);
            this.kryptonPage6.Flags = 65534;
            this.kryptonPage6.LastVisibleSet = true;
            this.kryptonPage6.MinimumSize = new System.Drawing.Size(50, 50);
            this.kryptonPage6.Name = "kryptonPage6";
            this.kryptonPage6.Size = new System.Drawing.Size(1114, 513);
            this.kryptonPage6.StateCommon.Tab.Content.ShortText.Font = new System.Drawing.Font("黑体", 12F);
            this.kryptonPage6.Text = "研究成果";
            this.kryptonPage6.ToolTipTitle = "Page ToolTip";
            this.kryptonPage6.UniqueName = "5297DB54E6BA4C245BB6C2878CDD190E";
            // 
            // kryptonNavigator11
            // 
            this.kryptonNavigator11.Button.CloseButtonDisplay = ComponentFactory.Krypton.Navigator.ButtonDisplay.Hide;
            this.kryptonNavigator11.Button.ContextButtonDisplay = ComponentFactory.Krypton.Navigator.ButtonDisplay.Hide;
            this.kryptonNavigator11.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonNavigator11.Location = new System.Drawing.Point(0, 0);
            this.kryptonNavigator11.Name = "kryptonNavigator11";
            this.kryptonNavigator11.Pages.AddRange(new ComponentFactory.Krypton.Navigator.KryptonPage[] {
            this.kryptonPage20,
            this.kryptonPage56,
            this.kryptonPage34});
            this.kryptonNavigator11.SelectedIndex = 0;
            this.kryptonNavigator11.Size = new System.Drawing.Size(1114, 513);
            this.kryptonNavigator11.TabIndex = 2;
            this.kryptonNavigator11.Text = "kryptonNavigator11";
            // 
            // kryptonPage20
            // 
            this.kryptonPage20.AutoHiddenSlideSize = new System.Drawing.Size(200, 200);
            this.kryptonPage20.Controls.Add(this.feUI8);
            this.kryptonPage20.Flags = 65534;
            this.kryptonPage20.LastVisibleSet = true;
            this.kryptonPage20.MinimumSize = new System.Drawing.Size(50, 50);
            this.kryptonPage20.Name = "kryptonPage20";
            this.kryptonPage20.Size = new System.Drawing.Size(1112, 483);
            this.kryptonPage20.StateCommon.Tab.Content.ShortText.Font = new System.Drawing.Font("黑体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.kryptonPage20.Text = "研究成果及考核指标";
            this.kryptonPage20.ToolTipTitle = "Page ToolTip";
            this.kryptonPage20.UniqueName = "601ED654FB3447B6B3944404A612B730";
            // 
            // feUI8
            // 
            this.feUI8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.feUI8.EnabledLastButton = true;
            this.feUI8.EnabledNextButton = true;
            this.feUI8.EnabledSaveButton = true;
            this.feUI8.Location = new System.Drawing.Point(0, 0);
            this.feUI8.Name = "feUI8";
            this.feUI8.ParentForm = null;
            this.feUI8.RTFEditorNameKey = "feUI";
            this.feUI8.RTFFileFirstName = "rtpinput_";
            this.feUI8.Size = new System.Drawing.Size(1112, 483);
            this.feUI8.TabIndex = 0;
            this.feUI8.TitleLabelText = "分类逐项列出研究成果及考核指标。研究成果形式包括研究报告、试验（测试）方案、试验（测试）结果分析报告、样品、样机、试验（验证）系统、数据库、软件、工程工艺、标准（" +
    "规范）等。指标体系应系统完整。";
            // 
            // kryptonPage56
            // 
            this.kryptonPage56.AutoHiddenSlideSize = new System.Drawing.Size(200, 200);
            this.kryptonPage56.Controls.Add(this.feUI9);
            this.kryptonPage56.Flags = 65534;
            this.kryptonPage56.LastVisibleSet = true;
            this.kryptonPage56.MinimumSize = new System.Drawing.Size(50, 50);
            this.kryptonPage56.Name = "kryptonPage56";
            this.kryptonPage56.Size = new System.Drawing.Size(1112, 483);
            this.kryptonPage56.StateCommon.Tab.Content.ShortText.Font = new System.Drawing.Font("黑体", 12F);
            this.kryptonPage56.Text = "评估方案";
            this.kryptonPage56.ToolTipTitle = "Page ToolTip";
            this.kryptonPage56.UniqueName = "574DDD6C923E47C0F39DA10BA065E942";
            // 
            // feUI9
            // 
            this.feUI9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.feUI9.EnabledLastButton = true;
            this.feUI9.EnabledNextButton = true;
            this.feUI9.EnabledSaveButton = true;
            this.feUI9.Location = new System.Drawing.Point(0, 0);
            this.feUI9.Name = "feUI9";
            this.feUI9.ParentForm = null;
            this.feUI9.RTFEditorNameKey = "feUI";
            this.feUI9.RTFFileFirstName = "rtpinput_";
            this.feUI9.Size = new System.Drawing.Size(1112, 483);
            this.feUI9.TabIndex = 1;
            this.feUI9.TitleLabelText = "围绕课题的研究成果及考核指标，提出具体的评估方案。可考虑通过国标、检测机构、企业标准测量、实验等多种方法，具体落实各项指标的评测。对可能影响指标评测结果的各种边界" +
    "因素条件，均应明确说明，避免理解歧义。";
            // 
            // kryptonPage34
            // 
            this.kryptonPage34.AutoHiddenSlideSize = new System.Drawing.Size(200, 200);
            this.kryptonPage34.Controls.Add(this.feUI10);
            this.kryptonPage34.Flags = 65534;
            this.kryptonPage34.LastVisibleSet = true;
            this.kryptonPage34.MinimumSize = new System.Drawing.Size(50, 50);
            this.kryptonPage34.Name = "kryptonPage34";
            this.kryptonPage34.Size = new System.Drawing.Size(1112, 483);
            this.kryptonPage34.StateCommon.Tab.Content.ShortText.Font = new System.Drawing.Font("黑体", 12F);
            this.kryptonPage34.Text = "预期收益";
            this.kryptonPage34.ToolTipTitle = "Page ToolTip";
            this.kryptonPage34.UniqueName = "754BF6994CBD4D55D0B8360A0FB0EBB3";
            // 
            // feUI10
            // 
            this.feUI10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.feUI10.EnabledLastButton = true;
            this.feUI10.EnabledNextButton = true;
            this.feUI10.EnabledSaveButton = true;
            this.feUI10.Location = new System.Drawing.Point(0, 0);
            this.feUI10.Name = "feUI10";
            this.feUI10.ParentForm = null;
            this.feUI10.RTFEditorNameKey = "feUI";
            this.feUI10.RTFFileFirstName = "rtpinput_";
            this.feUI10.Size = new System.Drawing.Size(1112, 483);
            this.feUI10.TabIndex = 1;
            this.feUI10.TitleLabelText = "简要描述该项目研究成果得到应用后，对解决国防科技现实瓶颈问题和支撑未来技术发展方面的预期支撑作用。";
            // 
            // kryptonPage7
            // 
            this.kryptonPage7.AutoHiddenSlideSize = new System.Drawing.Size(200, 200);
            this.kryptonPage7.Controls.Add(this.kryptonNavigator12);
            this.kryptonPage7.Flags = 65534;
            this.kryptonPage7.LastVisibleSet = true;
            this.kryptonPage7.MinimumSize = new System.Drawing.Size(50, 50);
            this.kryptonPage7.Name = "kryptonPage7";
            this.kryptonPage7.Size = new System.Drawing.Size(1114, 513);
            this.kryptonPage7.StateCommon.Tab.Content.ShortText.Font = new System.Drawing.Font("黑体", 12F);
            this.kryptonPage7.Text = "研究周期，阶段划分,经费安排";
            this.kryptonPage7.ToolTipTitle = "Page ToolTip";
            this.kryptonPage7.UniqueName = "F158AADCAF8141AD73A57971DD95510D";
            // 
            // kryptonNavigator12
            // 
            this.kryptonNavigator12.Button.CloseButtonDisplay = ComponentFactory.Krypton.Navigator.ButtonDisplay.Hide;
            this.kryptonNavigator12.Button.ContextButtonDisplay = ComponentFactory.Krypton.Navigator.ButtonDisplay.Hide;
            this.kryptonNavigator12.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonNavigator12.Location = new System.Drawing.Point(0, 0);
            this.kryptonNavigator12.Name = "kryptonNavigator12";
            this.kryptonNavigator12.Pages.AddRange(new ComponentFactory.Krypton.Navigator.KryptonPage[] {
            this.kryptonPage21,
            this.kryptonPage35,
            this.kryptonPage32});
            this.kryptonNavigator12.SelectedIndex = 0;
            this.kryptonNavigator12.Size = new System.Drawing.Size(1114, 513);
            this.kryptonNavigator12.TabIndex = 2;
            this.kryptonNavigator12.Text = "kryptonNavigator12";
            // 
            // kryptonPage21
            // 
            this.kryptonPage21.AutoHiddenSlideSize = new System.Drawing.Size(200, 200);
            this.kryptonPage21.Controls.Add(this.feUI11);
            this.kryptonPage21.Flags = 65534;
            this.kryptonPage21.LastVisibleSet = true;
            this.kryptonPage21.MinimumSize = new System.Drawing.Size(50, 50);
            this.kryptonPage21.Name = "kryptonPage21";
            this.kryptonPage21.Size = new System.Drawing.Size(1112, 483);
            this.kryptonPage21.StateCommon.Tab.Content.ShortText.Font = new System.Drawing.Font("黑体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.kryptonPage21.Text = "阶段划分";
            this.kryptonPage21.ToolTipTitle = "Page ToolTip";
            this.kryptonPage21.UniqueName = "601ED654FB3447B6B3944404A612B730";
            // 
            // feUI11
            // 
            this.feUI11.Dock = System.Windows.Forms.DockStyle.Fill;
            this.feUI11.KeTiList = null;
            this.feUI11.Location = new System.Drawing.Point(0, 0);
            this.feUI11.Name = "feUI11";
            this.feUI11.ParentForm = null;
            this.feUI11.Size = new System.Drawing.Size(1112, 483);
            this.feUI11.StepList = null;
            this.feUI11.TabIndex = 0;
            // 
            // kryptonPage35
            // 
            this.kryptonPage35.AutoHiddenSlideSize = new System.Drawing.Size(200, 200);
            this.kryptonPage35.Controls.Add(this.feUI12);
            this.kryptonPage35.Flags = 65534;
            this.kryptonPage35.LastVisibleSet = true;
            this.kryptonPage35.MinimumSize = new System.Drawing.Size(50, 50);
            this.kryptonPage35.Name = "kryptonPage35";
            this.kryptonPage35.Size = new System.Drawing.Size(1112, 483);
            this.kryptonPage35.StateCommon.Tab.Content.ShortText.Font = new System.Drawing.Font("黑体", 12F);
            this.kryptonPage35.Text = "项目阶段划分和经费安排";
            this.kryptonPage35.ToolTipTitle = "Page ToolTip";
            this.kryptonPage35.UniqueName = "FD6AE7543C1D4A5774B98E493AE5CFE1";
            // 
            // feUI12
            // 
            this.feUI12.Dock = System.Windows.Forms.DockStyle.Fill;
            this.feUI12.Location = new System.Drawing.Point(0, 0);
            this.feUI12.Name = "feUI12";
            this.feUI12.ParentForm = null;
            this.feUI12.Size = new System.Drawing.Size(1112, 483);
            this.feUI12.StepList = null;
            this.feUI12.TabIndex = 0;
            // 
            // kryptonPage32
            // 
            this.kryptonPage32.AutoHiddenSlideSize = new System.Drawing.Size(200, 200);
            this.kryptonPage32.Controls.Add(this.feUI13);
            this.kryptonPage32.Flags = 65534;
            this.kryptonPage32.LastVisibleSet = true;
            this.kryptonPage32.MinimumSize = new System.Drawing.Size(50, 50);
            this.kryptonPage32.Name = "kryptonPage32";
            this.kryptonPage32.Size = new System.Drawing.Size(1112, 483);
            this.kryptonPage32.StateCommon.Tab.Content.ShortText.Font = new System.Drawing.Font("黑体", 12F);
            this.kryptonPage32.Text = "课题阶段划分和经费安排";
            this.kryptonPage32.ToolTipTitle = "Page ToolTip";
            this.kryptonPage32.UniqueName = "495C9294D0324F2FC4A9E7BAF9BBDADF";
            // 
            // feUI13
            // 
            this.feUI13.Dock = System.Windows.Forms.DockStyle.Fill;
            this.feUI13.KeTiList = null;
            this.feUI13.Location = new System.Drawing.Point(0, 0);
            this.feUI13.Name = "feUI13";
            this.feUI13.ParentForm = null;
            this.feUI13.Size = new System.Drawing.Size(1112, 483);
            this.feUI13.StepList = null;
            this.feUI13.TabIndex = 0;
            // 
            // kryptonPage57
            // 
            this.kryptonPage57.AutoHiddenSlideSize = new System.Drawing.Size(200, 200);
            this.kryptonPage57.Controls.Add(this.kryptonNavigator13);
            this.kryptonPage57.Flags = 65534;
            this.kryptonPage57.LastVisibleSet = true;
            this.kryptonPage57.MinimumSize = new System.Drawing.Size(50, 50);
            this.kryptonPage57.Name = "kryptonPage57";
            this.kryptonPage57.Size = new System.Drawing.Size(1114, 513);
            this.kryptonPage57.Text = "项目负责人和研究团队";
            this.kryptonPage57.ToolTipTitle = "Page ToolTip";
            this.kryptonPage57.UniqueName = "780B046A569041D364A55E5A6D1390E7";
            // 
            // kryptonNavigator13
            // 
            this.kryptonNavigator13.Button.CloseButtonDisplay = ComponentFactory.Krypton.Navigator.ButtonDisplay.Hide;
            this.kryptonNavigator13.Button.ContextButtonDisplay = ComponentFactory.Krypton.Navigator.ButtonDisplay.Hide;
            this.kryptonNavigator13.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonNavigator13.Location = new System.Drawing.Point(0, 0);
            this.kryptonNavigator13.Name = "kryptonNavigator13";
            this.kryptonNavigator13.Pages.AddRange(new ComponentFactory.Krypton.Navigator.KryptonPage[] {
            this.kryptonPage22,
            this.kryptonPage36,
            this.kryptonPage37});
            this.kryptonNavigator13.SelectedIndex = 0;
            this.kryptonNavigator13.Size = new System.Drawing.Size(1114, 513);
            this.kryptonNavigator13.TabIndex = 2;
            this.kryptonNavigator13.Text = "kryptonNavigator13";
            // 
            // kryptonPage22
            // 
            this.kryptonPage22.AutoHiddenSlideSize = new System.Drawing.Size(200, 200);
            this.kryptonPage22.Controls.Add(this.feUI14);
            this.kryptonPage22.Flags = 65534;
            this.kryptonPage22.LastVisibleSet = true;
            this.kryptonPage22.MinimumSize = new System.Drawing.Size(50, 50);
            this.kryptonPage22.Name = "kryptonPage22";
            this.kryptonPage22.Size = new System.Drawing.Size(1112, 483);
            this.kryptonPage22.StateCommon.Tab.Content.ShortText.Font = new System.Drawing.Font("黑体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.kryptonPage22.Text = "项目负责人";
            this.kryptonPage22.ToolTipTitle = "Page ToolTip";
            this.kryptonPage22.UniqueName = "601ED654FB3447B6B3944404A612B730";
            // 
            // feUI14
            // 
            this.feUI14.Dock = System.Windows.Forms.DockStyle.Fill;
            this.feUI14.EnabledLastButton = true;
            this.feUI14.EnabledNextButton = true;
            this.feUI14.EnabledSaveButton = true;
            this.feUI14.Location = new System.Drawing.Point(0, 0);
            this.feUI14.Name = "feUI14";
            this.feUI14.ParentForm = null;
            this.feUI14.RTFEditorNameKey = "feUI";
            this.feUI14.RTFFileFirstName = "rtpinput_";
            this.feUI14.Size = new System.Drawing.Size(1112, 483);
            this.feUI14.TabIndex = 0;
            this.feUI14.TitleLabelText = "介绍项目负责人的职务职称、受教育情况、履历，代表性论文、专著、专利、奖励、人才计划资助情况，以及近五年主持的相关国家科技计划项目情况，限800字以内。要求实事求是" +
    "填报，有关信息纳入科研诚信评价体系。";
            // 
            // kryptonPage36
            // 
            this.kryptonPage36.AutoHiddenSlideSize = new System.Drawing.Size(200, 200);
            this.kryptonPage36.Controls.Add(this.feUI15);
            this.kryptonPage36.Flags = 65534;
            this.kryptonPage36.LastVisibleSet = true;
            this.kryptonPage36.MinimumSize = new System.Drawing.Size(50, 50);
            this.kryptonPage36.Name = "kryptonPage36";
            this.kryptonPage36.Size = new System.Drawing.Size(1112, 483);
            this.kryptonPage36.StateCommon.Tab.Content.ShortText.Font = new System.Drawing.Font("黑体", 12F);
            this.kryptonPage36.Text = "研究团队";
            this.kryptonPage36.ToolTipTitle = "Page ToolTip";
            this.kryptonPage36.UniqueName = "F752A029EC6448616BB52A255B09A3EB";
            // 
            // feUI15
            // 
            this.feUI15.Dock = System.Windows.Forms.DockStyle.Fill;
            this.feUI15.EnabledLastButton = true;
            this.feUI15.EnabledNextButton = true;
            this.feUI15.EnabledSaveButton = true;
            this.feUI15.Location = new System.Drawing.Point(0, 0);
            this.feUI15.Name = "feUI15";
            this.feUI15.ParentForm = null;
            this.feUI15.RTFEditorNameKey = "feUI";
            this.feUI15.RTFFileFirstName = "rtpinput_";
            this.feUI15.Size = new System.Drawing.Size(1112, 483);
            this.feUI15.TabIndex = 0;
            this.feUI15.TitleLabelText = "简要介绍本项目除项目负责人外的课题负责人的职务职称、受教育情况、履历，代表性论文、专著、专利、奖励、人才计划资助情况，以及近五年主持的相关国家科技计划项目情况，限" +
    "1000字以内。要求实事求是填报，有关信息纳入科研诚信评价体系。";
            // 
            // kryptonPage37
            // 
            this.kryptonPage37.AutoHiddenSlideSize = new System.Drawing.Size(200, 200);
            this.kryptonPage37.Controls.Add(this.feUI16);
            this.kryptonPage37.Flags = 65534;
            this.kryptonPage37.LastVisibleSet = true;
            this.kryptonPage37.MinimumSize = new System.Drawing.Size(50, 50);
            this.kryptonPage37.Name = "kryptonPage37";
            this.kryptonPage37.Size = new System.Drawing.Size(1112, 483);
            this.kryptonPage37.StateCommon.Tab.Content.ShortText.Font = new System.Drawing.Font("黑体", 12F);
            this.kryptonPage37.Text = "负责人及研究骨干情况表";
            this.kryptonPage37.ToolTipTitle = "Page ToolTip";
            this.kryptonPage37.UniqueName = "028323267E084C75BB94C0590A833220";
            // 
            // feUI16
            // 
            this.feUI16.Dock = System.Windows.Forms.DockStyle.Fill;
            this.feUI16.Location = new System.Drawing.Point(0, 0);
            this.feUI16.Name = "feUI16";
            this.feUI16.ParentForm = null;
            this.feUI16.PersonList = null;
            this.feUI16.Size = new System.Drawing.Size(1112, 483);
            this.feUI16.TabIndex = 0;
            this.feUI16.TaskList = null;
            // 
            // kryptonPage9
            // 
            this.kryptonPage9.AutoHiddenSlideSize = new System.Drawing.Size(200, 200);
            this.kryptonPage9.Controls.Add(this.kryptonNavigator14);
            this.kryptonPage9.Flags = 65534;
            this.kryptonPage9.LastVisibleSet = true;
            this.kryptonPage9.MinimumSize = new System.Drawing.Size(50, 50);
            this.kryptonPage9.Name = "kryptonPage9";
            this.kryptonPage9.Size = new System.Drawing.Size(1114, 513);
            this.kryptonPage9.Text = "研究基础与保障条件";
            this.kryptonPage9.ToolTipTitle = "Page ToolTip";
            this.kryptonPage9.UniqueName = "BF17E2B2C8BE4ACA6E85DA05AED1A4F8";
            // 
            // kryptonNavigator14
            // 
            this.kryptonNavigator14.Button.CloseButtonDisplay = ComponentFactory.Krypton.Navigator.ButtonDisplay.Hide;
            this.kryptonNavigator14.Button.ContextButtonDisplay = ComponentFactory.Krypton.Navigator.ButtonDisplay.Hide;
            this.kryptonNavigator14.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonNavigator14.Location = new System.Drawing.Point(0, 0);
            this.kryptonNavigator14.Name = "kryptonNavigator14";
            this.kryptonNavigator14.Pages.AddRange(new ComponentFactory.Krypton.Navigator.KryptonPage[] {
            this.kryptonPage23});
            this.kryptonNavigator14.SelectedIndex = 0;
            this.kryptonNavigator14.Size = new System.Drawing.Size(1114, 513);
            this.kryptonNavigator14.TabIndex = 2;
            this.kryptonNavigator14.Text = "kryptonNavigator14";
            // 
            // kryptonPage23
            // 
            this.kryptonPage23.AutoHiddenSlideSize = new System.Drawing.Size(200, 200);
            this.kryptonPage23.Controls.Add(this.feUI17);
            this.kryptonPage23.Flags = 65534;
            this.kryptonPage23.LastVisibleSet = true;
            this.kryptonPage23.MinimumSize = new System.Drawing.Size(50, 50);
            this.kryptonPage23.Name = "kryptonPage23";
            this.kryptonPage23.Size = new System.Drawing.Size(1112, 483);
            this.kryptonPage23.StateCommon.Tab.Content.ShortText.Font = new System.Drawing.Font("黑体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.kryptonPage23.Text = "研究基础与保障条件";
            this.kryptonPage23.ToolTipTitle = "Page ToolTip";
            this.kryptonPage23.UniqueName = "601ED654FB3447B6B3944404A612B730";
            // 
            // feUI17
            // 
            this.feUI17.Dock = System.Windows.Forms.DockStyle.Fill;
            this.feUI17.EnabledLastButton = true;
            this.feUI17.EnabledNextButton = true;
            this.feUI17.EnabledSaveButton = true;
            this.feUI17.Location = new System.Drawing.Point(0, 0);
            this.feUI17.Name = "feUI17";
            this.feUI17.ParentForm = null;
            this.feUI17.RTFEditorNameKey = "feUI";
            this.feUI17.RTFFileFirstName = "rtpinput_";
            this.feUI17.Size = new System.Drawing.Size(1112, 483);
            this.feUI17.TabIndex = 0;
            this.feUI17.TitleLabelText = "已有研究基础和软硬件保障条件，包括国家研究中心、国家重点实验室、国家工程（技术）中心等，以及自筹经费情况，800字以内";
            // 
            // kryptonPage10
            // 
            this.kryptonPage10.AutoHiddenSlideSize = new System.Drawing.Size(200, 200);
            this.kryptonPage10.Controls.Add(this.kryptonNavigator15);
            this.kryptonPage10.Flags = 65534;
            this.kryptonPage10.LastVisibleSet = true;
            this.kryptonPage10.MinimumSize = new System.Drawing.Size(50, 50);
            this.kryptonPage10.Name = "kryptonPage10";
            this.kryptonPage10.Size = new System.Drawing.Size(1114, 513);
            this.kryptonPage10.Text = "组织实施与风险控制";
            this.kryptonPage10.ToolTipTitle = "Page ToolTip";
            this.kryptonPage10.UniqueName = "64FF431C8C73448C93B2B612393E27DF";
            // 
            // kryptonNavigator15
            // 
            this.kryptonNavigator15.Button.CloseButtonDisplay = ComponentFactory.Krypton.Navigator.ButtonDisplay.Hide;
            this.kryptonNavigator15.Button.ContextButtonDisplay = ComponentFactory.Krypton.Navigator.ButtonDisplay.Hide;
            this.kryptonNavigator15.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonNavigator15.Location = new System.Drawing.Point(0, 0);
            this.kryptonNavigator15.Name = "kryptonNavigator15";
            this.kryptonNavigator15.Pages.AddRange(new ComponentFactory.Krypton.Navigator.KryptonPage[] {
            this.kryptonPage24});
            this.kryptonNavigator15.SelectedIndex = 0;
            this.kryptonNavigator15.Size = new System.Drawing.Size(1114, 513);
            this.kryptonNavigator15.TabIndex = 2;
            this.kryptonNavigator15.Text = "kryptonNavigator15";
            // 
            // kryptonPage24
            // 
            this.kryptonPage24.AutoHiddenSlideSize = new System.Drawing.Size(200, 200);
            this.kryptonPage24.Controls.Add(this.feUI18);
            this.kryptonPage24.Flags = 65534;
            this.kryptonPage24.LastVisibleSet = true;
            this.kryptonPage24.MinimumSize = new System.Drawing.Size(50, 50);
            this.kryptonPage24.Name = "kryptonPage24";
            this.kryptonPage24.Size = new System.Drawing.Size(1112, 483);
            this.kryptonPage24.StateCommon.Tab.Content.ShortText.Font = new System.Drawing.Font("黑体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.kryptonPage24.Text = "组织实施与风险控制";
            this.kryptonPage24.ToolTipTitle = "Page ToolTip";
            this.kryptonPage24.UniqueName = "601ED654FB3447B6B3944404A612B730";
            // 
            // feUI18
            // 
            this.feUI18.Dock = System.Windows.Forms.DockStyle.Fill;
            this.feUI18.EnabledLastButton = true;
            this.feUI18.EnabledNextButton = true;
            this.feUI18.EnabledSaveButton = true;
            this.feUI18.Location = new System.Drawing.Point(0, 0);
            this.feUI18.Name = "feUI18";
            this.feUI18.ParentForm = null;
            this.feUI18.RTFEditorNameKey = "feUI";
            this.feUI18.RTFFileFirstName = "rtpinput_";
            this.feUI18.Size = new System.Drawing.Size(1112, 483);
            this.feUI18.TabIndex = 0;
            this.feUI18.TitleLabelText = "对本项目可能存在的技术和管理风险进行分析，提出思路举措，500字以内";
            // 
            // kryptonPage11
            // 
            this.kryptonPage11.AutoHiddenSlideSize = new System.Drawing.Size(200, 200);
            this.kryptonPage11.Controls.Add(this.kryptonNavigator16);
            this.kryptonPage11.Flags = 65534;
            this.kryptonPage11.LastVisibleSet = true;
            this.kryptonPage11.MinimumSize = new System.Drawing.Size(50, 50);
            this.kryptonPage11.Name = "kryptonPage11";
            this.kryptonPage11.Size = new System.Drawing.Size(1114, 513);
            this.kryptonPage11.Text = "与有关计划关系";
            this.kryptonPage11.ToolTipTitle = "Page ToolTip";
            this.kryptonPage11.UniqueName = "9F9CA2564E80459900A74DF275E4928A";
            // 
            // kryptonNavigator16
            // 
            this.kryptonNavigator16.Button.CloseButtonDisplay = ComponentFactory.Krypton.Navigator.ButtonDisplay.Hide;
            this.kryptonNavigator16.Button.ContextButtonDisplay = ComponentFactory.Krypton.Navigator.ButtonDisplay.Hide;
            this.kryptonNavigator16.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonNavigator16.Location = new System.Drawing.Point(0, 0);
            this.kryptonNavigator16.Name = "kryptonNavigator16";
            this.kryptonNavigator16.Pages.AddRange(new ComponentFactory.Krypton.Navigator.KryptonPage[] {
            this.kryptonPage25});
            this.kryptonNavigator16.SelectedIndex = 0;
            this.kryptonNavigator16.Size = new System.Drawing.Size(1114, 513);
            this.kryptonNavigator16.TabIndex = 2;
            this.kryptonNavigator16.Text = "kryptonNavigator16";
            // 
            // kryptonPage25
            // 
            this.kryptonPage25.AutoHiddenSlideSize = new System.Drawing.Size(200, 200);
            this.kryptonPage25.Controls.Add(this.feUI19);
            this.kryptonPage25.Flags = 65534;
            this.kryptonPage25.LastVisibleSet = true;
            this.kryptonPage25.MinimumSize = new System.Drawing.Size(50, 50);
            this.kryptonPage25.Name = "kryptonPage25";
            this.kryptonPage25.Size = new System.Drawing.Size(1112, 483);
            this.kryptonPage25.StateCommon.Tab.Content.ShortText.Font = new System.Drawing.Font("黑体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.kryptonPage25.Text = "与有关计划关系";
            this.kryptonPage25.ToolTipTitle = "Page ToolTip";
            this.kryptonPage25.UniqueName = "601ED654FB3447B6B3944404A612B730";
            // 
            // feUI19
            // 
            this.feUI19.Dock = System.Windows.Forms.DockStyle.Fill;
            this.feUI19.EnabledLastButton = true;
            this.feUI19.EnabledNextButton = true;
            this.feUI19.EnabledSaveButton = true;
            this.feUI19.Location = new System.Drawing.Point(0, 0);
            this.feUI19.Name = "feUI19";
            this.feUI19.ParentForm = null;
            this.feUI19.RTFEditorNameKey = "feUI";
            this.feUI19.RTFFileFirstName = "rtpinput_";
            this.feUI19.Size = new System.Drawing.Size(1112, 483);
            this.feUI19.TabIndex = 0;
            this.feUI19.TitleLabelText = "介绍与本项目研究内容相关的国家和军队各类科技计划安排情况，对本项目与有关计划安排的界面关系进行说明。";
            // 
            // kryptonPage12
            // 
            this.kryptonPage12.AutoHiddenSlideSize = new System.Drawing.Size(200, 200);
            this.kryptonPage12.Controls.Add(this.kryptonNavigator17);
            this.kryptonPage12.Flags = 65534;
            this.kryptonPage12.LastVisibleSet = true;
            this.kryptonPage12.MinimumSize = new System.Drawing.Size(50, 50);
            this.kryptonPage12.Name = "kryptonPage12";
            this.kryptonPage12.Size = new System.Drawing.Size(1114, 513);
            this.kryptonPage12.Text = "经费预算表";
            this.kryptonPage12.ToolTipTitle = "Page ToolTip";
            this.kryptonPage12.UniqueName = "653A059D00A044506E9EA0998FA3DDAE";
            // 
            // kryptonNavigator17
            // 
            this.kryptonNavigator17.Button.CloseButtonDisplay = ComponentFactory.Krypton.Navigator.ButtonDisplay.Hide;
            this.kryptonNavigator17.Button.ContextButtonDisplay = ComponentFactory.Krypton.Navigator.ButtonDisplay.Hide;
            this.kryptonNavigator17.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonNavigator17.Location = new System.Drawing.Point(0, 0);
            this.kryptonNavigator17.Name = "kryptonNavigator17";
            this.kryptonNavigator17.Pages.AddRange(new ComponentFactory.Krypton.Navigator.KryptonPage[] {
            this.kryptonPage26});
            this.kryptonNavigator17.SelectedIndex = 0;
            this.kryptonNavigator17.Size = new System.Drawing.Size(1114, 513);
            this.kryptonNavigator17.TabIndex = 2;
            this.kryptonNavigator17.Text = "kryptonNavigator17";
            // 
            // kryptonPage26
            // 
            this.kryptonPage26.AutoHiddenSlideSize = new System.Drawing.Size(200, 200);
            this.kryptonPage26.Controls.Add(this.feUI20);
            this.kryptonPage26.Flags = 65534;
            this.kryptonPage26.LastVisibleSet = true;
            this.kryptonPage26.MinimumSize = new System.Drawing.Size(50, 50);
            this.kryptonPage26.Name = "kryptonPage26";
            this.kryptonPage26.Size = new System.Drawing.Size(1112, 483);
            this.kryptonPage26.StateCommon.Tab.Content.ShortText.Font = new System.Drawing.Font("黑体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.kryptonPage26.Text = "经费预算表";
            this.kryptonPage26.ToolTipTitle = "Page ToolTip";
            this.kryptonPage26.UniqueName = "601ED654FB3447B6B3944404A612B730";
            // 
            // feUI20
            // 
            this.feUI20.Dock = System.Windows.Forms.DockStyle.Fill;
            this.feUI20.Location = new System.Drawing.Point(0, 0);
            this.feUI20.Name = "feUI20";
            this.feUI20.ParentForm = null;
            this.feUI20.Size = new System.Drawing.Size(1112, 483);
            this.feUI20.TabIndex = 0;
            // 
            // kryptonPage13
            // 
            this.kryptonPage13.AutoHiddenSlideSize = new System.Drawing.Size(200, 200);
            this.kryptonPage13.Controls.Add(this.kryptonNavigator18);
            this.kryptonPage13.Flags = 65534;
            this.kryptonPage13.LastVisibleSet = true;
            this.kryptonPage13.MinimumSize = new System.Drawing.Size(50, 50);
            this.kryptonPage13.Name = "kryptonPage13";
            this.kryptonPage13.Size = new System.Drawing.Size(1114, 513);
            this.kryptonPage13.Text = "联系方式";
            this.kryptonPage13.ToolTipTitle = "Page ToolTip";
            this.kryptonPage13.UniqueName = "172B3150655F44437CB6F969A363B0D1";
            // 
            // kryptonNavigator18
            // 
            this.kryptonNavigator18.Button.CloseButtonDisplay = ComponentFactory.Krypton.Navigator.ButtonDisplay.Hide;
            this.kryptonNavigator18.Button.ContextButtonDisplay = ComponentFactory.Krypton.Navigator.ButtonDisplay.Hide;
            this.kryptonNavigator18.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonNavigator18.Location = new System.Drawing.Point(0, 0);
            this.kryptonNavigator18.Name = "kryptonNavigator18";
            this.kryptonNavigator18.Pages.AddRange(new ComponentFactory.Krypton.Navigator.KryptonPage[] {
            this.kryptonPage27,
            this.kryptonPage38,
            this.kryptonPage39});
            this.kryptonNavigator18.SelectedIndex = 0;
            this.kryptonNavigator18.Size = new System.Drawing.Size(1114, 513);
            this.kryptonNavigator18.TabIndex = 2;
            this.kryptonNavigator18.Text = "kryptonNavigator18";
            // 
            // kryptonPage27
            // 
            this.kryptonPage27.AutoHiddenSlideSize = new System.Drawing.Size(200, 200);
            this.kryptonPage27.Controls.Add(this.feUI21);
            this.kryptonPage27.Flags = 65534;
            this.kryptonPage27.LastVisibleSet = true;
            this.kryptonPage27.MinimumSize = new System.Drawing.Size(50, 50);
            this.kryptonPage27.Name = "kryptonPage27";
            this.kryptonPage27.Size = new System.Drawing.Size(1112, 483);
            this.kryptonPage27.StateCommon.Tab.Content.ShortText.Font = new System.Drawing.Font("黑体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.kryptonPage27.Text = "项目负责人";
            this.kryptonPage27.ToolTipTitle = "Page ToolTip";
            this.kryptonPage27.UniqueName = "601ED654FB3447B6B3944404A612B730";
            // 
            // feUI21
            // 
            this.feUI21.Dock = System.Windows.Forms.DockStyle.Fill;
            this.feUI21.Location = new System.Drawing.Point(0, 0);
            this.feUI21.Name = "feUI21";
            this.feUI21.ParentForm = null;
            this.feUI21.Size = new System.Drawing.Size(1112, 483);
            this.feUI21.TabIndex = 0;
            // 
            // kryptonPage38
            // 
            this.kryptonPage38.AutoHiddenSlideSize = new System.Drawing.Size(200, 200);
            this.kryptonPage38.Controls.Add(this.feUI22);
            this.kryptonPage38.Flags = 65534;
            this.kryptonPage38.LastVisibleSet = true;
            this.kryptonPage38.MinimumSize = new System.Drawing.Size(50, 50);
            this.kryptonPage38.Name = "kryptonPage38";
            this.kryptonPage38.Size = new System.Drawing.Size(1112, 483);
            this.kryptonPage38.StateCommon.Tab.Content.ShortText.Font = new System.Drawing.Font("黑体", 12F);
            this.kryptonPage38.Text = "候选牵头单位";
            this.kryptonPage38.ToolTipTitle = "Page ToolTip";
            this.kryptonPage38.UniqueName = "227CA1483BF642FD51853E16BE752DBA";
            // 
            // feUI22
            // 
            this.feUI22.Dock = System.Windows.Forms.DockStyle.Fill;
            this.feUI22.Location = new System.Drawing.Point(0, 0);
            this.feUI22.Name = "feUI22";
            this.feUI22.ParentForm = null;
            this.feUI22.Size = new System.Drawing.Size(1112, 483);
            this.feUI22.TabIndex = 0;
            this.feUI22.WhiteDataList = null;
            // 
            // kryptonPage39
            // 
            this.kryptonPage39.AutoHiddenSlideSize = new System.Drawing.Size(200, 200);
            this.kryptonPage39.Controls.Add(this.feUI23);
            this.kryptonPage39.Flags = 65534;
            this.kryptonPage39.LastVisibleSet = true;
            this.kryptonPage39.MinimumSize = new System.Drawing.Size(50, 50);
            this.kryptonPage39.Name = "kryptonPage39";
            this.kryptonPage39.Size = new System.Drawing.Size(1112, 483);
            this.kryptonPage39.StateCommon.Tab.Content.ShortText.Font = new System.Drawing.Font("黑体", 12F);
            this.kryptonPage39.Text = "课题负责人联系方式";
            this.kryptonPage39.ToolTipTitle = "Page ToolTip";
            this.kryptonPage39.UniqueName = "4F697550E94641F0CCB45CBC51B8FCC0";
            // 
            // feUI23
            // 
            this.feUI23.Dock = System.Windows.Forms.DockStyle.Fill;
            this.feUI23.KeTiList = null;
            this.feUI23.Location = new System.Drawing.Point(0, 0);
            this.feUI23.Name = "feUI23";
            this.feUI23.ParentForm = null;
            this.feUI23.Size = new System.Drawing.Size(1112, 483);
            this.feUI23.TabIndex = 0;
            // 
            // kryptonPage14
            // 
            this.kryptonPage14.AutoHiddenSlideSize = new System.Drawing.Size(200, 200);
            this.kryptonPage14.Controls.Add(this.kryptonNavigator19);
            this.kryptonPage14.Flags = 65534;
            this.kryptonPage14.LastVisibleSet = true;
            this.kryptonPage14.MinimumSize = new System.Drawing.Size(50, 50);
            this.kryptonPage14.Name = "kryptonPage14";
            this.kryptonPage14.Size = new System.Drawing.Size(1114, 513);
            this.kryptonPage14.Text = "附件1：项目经费概算说明";
            this.kryptonPage14.ToolTipTitle = "Page ToolTip";
            this.kryptonPage14.UniqueName = "731B68AD43EC48C05E8F6DFC19C05EA6";
            // 
            // kryptonNavigator19
            // 
            this.kryptonNavigator19.Button.CloseButtonDisplay = ComponentFactory.Krypton.Navigator.ButtonDisplay.Hide;
            this.kryptonNavigator19.Button.ContextButtonDisplay = ComponentFactory.Krypton.Navigator.ButtonDisplay.Hide;
            this.kryptonNavigator19.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonNavigator19.Location = new System.Drawing.Point(0, 0);
            this.kryptonNavigator19.Name = "kryptonNavigator19";
            this.kryptonNavigator19.Pages.AddRange(new ComponentFactory.Krypton.Navigator.KryptonPage[] {
            this.kryptonPage28});
            this.kryptonNavigator19.SelectedIndex = 0;
            this.kryptonNavigator19.Size = new System.Drawing.Size(1114, 513);
            this.kryptonNavigator19.TabIndex = 2;
            this.kryptonNavigator19.Text = "kryptonNavigator19";
            // 
            // kryptonPage28
            // 
            this.kryptonPage28.AutoHiddenSlideSize = new System.Drawing.Size(200, 200);
            this.kryptonPage28.Controls.Add(this.feUI24);
            this.kryptonPage28.Flags = 65534;
            this.kryptonPage28.LastVisibleSet = true;
            this.kryptonPage28.MinimumSize = new System.Drawing.Size(50, 50);
            this.kryptonPage28.Name = "kryptonPage28";
            this.kryptonPage28.Size = new System.Drawing.Size(1112, 483);
            this.kryptonPage28.StateCommon.Tab.Content.ShortText.Font = new System.Drawing.Font("黑体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.kryptonPage28.Text = "附件1：项目经费概算说明";
            this.kryptonPage28.ToolTipTitle = "Page ToolTip";
            this.kryptonPage28.UniqueName = "601ED654FB3447B6B3944404A612B730";
            // 
            // feUI24
            // 
            this.feUI24.Dock = System.Windows.Forms.DockStyle.Fill;
            this.feUI24.FilePath = null;
            this.feUI24.Location = new System.Drawing.Point(0, 0);
            this.feUI24.Name = "feUI24";
            this.feUI24.ParentForm = null;
            this.feUI24.Size = new System.Drawing.Size(1112, 483);
            this.feUI24.TabIndex = 0;
            // 
            // kryptonPage15
            // 
            this.kryptonPage15.AutoHiddenSlideSize = new System.Drawing.Size(200, 200);
            this.kryptonPage15.Controls.Add(this.kryptonNavigator20);
            this.kryptonPage15.Flags = 65534;
            this.kryptonPage15.LastVisibleSet = true;
            this.kryptonPage15.MinimumSize = new System.Drawing.Size(50, 50);
            this.kryptonPage15.Name = "kryptonPage15";
            this.kryptonPage15.Size = new System.Drawing.Size(1114, 513);
            this.kryptonPage15.Text = "附件2：保密资质复印件";
            this.kryptonPage15.ToolTipTitle = "Page ToolTip";
            this.kryptonPage15.UniqueName = "D78B4567092948836CBCFFE1A3F46C58";
            // 
            // kryptonNavigator20
            // 
            this.kryptonNavigator20.Button.CloseButtonDisplay = ComponentFactory.Krypton.Navigator.ButtonDisplay.Hide;
            this.kryptonNavigator20.Button.ContextButtonDisplay = ComponentFactory.Krypton.Navigator.ButtonDisplay.Hide;
            this.kryptonNavigator20.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonNavigator20.Location = new System.Drawing.Point(0, 0);
            this.kryptonNavigator20.Name = "kryptonNavigator20";
            this.kryptonNavigator20.Pages.AddRange(new ComponentFactory.Krypton.Navigator.KryptonPage[] {
            this.kryptonPage29});
            this.kryptonNavigator20.SelectedIndex = 0;
            this.kryptonNavigator20.Size = new System.Drawing.Size(1114, 513);
            this.kryptonNavigator20.TabIndex = 2;
            this.kryptonNavigator20.Text = "kryptonNavigator20";
            // 
            // kryptonPage29
            // 
            this.kryptonPage29.AutoHiddenSlideSize = new System.Drawing.Size(200, 200);
            this.kryptonPage29.Controls.Add(this.feUI25);
            this.kryptonPage29.Flags = 65534;
            this.kryptonPage29.LastVisibleSet = true;
            this.kryptonPage29.MinimumSize = new System.Drawing.Size(50, 50);
            this.kryptonPage29.Name = "kryptonPage29";
            this.kryptonPage29.Size = new System.Drawing.Size(1112, 483);
            this.kryptonPage29.StateCommon.Tab.Content.ShortText.Font = new System.Drawing.Font("黑体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.kryptonPage29.Text = "附件2：保密资质复印件";
            this.kryptonPage29.ToolTipTitle = "Page ToolTip";
            this.kryptonPage29.UniqueName = "601ED654FB3447B6B3944404A612B730";
            // 
            // feUI25
            // 
            this.feUI25.Dock = System.Windows.Forms.DockStyle.Fill;
            this.feUI25.FilePath = null;
            this.feUI25.Location = new System.Drawing.Point(0, 0);
            this.feUI25.Name = "feUI25";
            this.feUI25.ParentForm = null;
            this.feUI25.Size = new System.Drawing.Size(1112, 483);
            this.feUI25.TabIndex = 0;
            // 
            // fnpDefault
            // 
            this.fnpDefault.Location = new System.Drawing.Point(0, 46);
            this.fnpDefault.Name = "fnpDefault";
            this.fnpDefault.ParentForm = null;
            this.fnpDefault.Size = new System.Drawing.Size(553, 60);
            this.fnpDefault.TabIndex = 3;
            // 
            // kpcontact
            // 
            this.kpcontact.BorderColor = System.Drawing.Color.Black;
            this.kpcontact.Location = new System.Drawing.Point(0, 0);
            this.kpcontact.Name = "kpcontact";
            this.kpcontact.Size = new System.Drawing.Size(200, 100);
            this.kpcontact.TabIndex = 0;
            // 
            // MainForm
            // 
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1458, 671);
            this.Controls.Add(this.edithost2);
            this.Controls.Add(this.fnpDefault);
            this.Controls.Add(this.kryptonPanel1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Tag = "基础加强计划重点基础研究项目申报系统";
            this.Text = "基础加强计划重点基础研究项目申报系统";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Activated += new System.EventHandler(this.MainForm_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.logicform_Load);
            this.Resize += new System.EventHandler(this.logicform_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            this.kryptonPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.topBanner)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kpcontactinner)).EndInit();
            this.kpcontactinner.ResumeLayout(false);
            this.kpcontactinner.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edithost2)).EndInit();
            this.edithost2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonNavigator22)).EndInit();
            this.kryptonNavigator22.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonNavigator7)).EndInit();
            this.kryptonNavigator7.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kpfPage1)).EndInit();
            this.kpfPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kpfPage2)).EndInit();
            this.kpfPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kpfPage3)).EndInit();
            this.kpfPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPage3)).EndInit();
            this.kryptonPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonNavigator8)).EndInit();
            this.kryptonNavigator8.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPage17)).EndInit();
            this.kryptonPage17.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPage4)).EndInit();
            this.kryptonPage4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonNavigator9)).EndInit();
            this.kryptonNavigator9.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPage18)).EndInit();
            this.kryptonPage18.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPage5)).EndInit();
            this.kryptonPage5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonNavigator10)).EndInit();
            this.kryptonNavigator10.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPage19)).EndInit();
            this.kryptonPage19.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPage16)).EndInit();
            this.kryptonPage16.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPage6)).EndInit();
            this.kryptonPage6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonNavigator11)).EndInit();
            this.kryptonNavigator11.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPage20)).EndInit();
            this.kryptonPage20.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPage56)).EndInit();
            this.kryptonPage56.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPage34)).EndInit();
            this.kryptonPage34.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPage7)).EndInit();
            this.kryptonPage7.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonNavigator12)).EndInit();
            this.kryptonNavigator12.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPage21)).EndInit();
            this.kryptonPage21.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPage35)).EndInit();
            this.kryptonPage35.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPage32)).EndInit();
            this.kryptonPage32.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPage57)).EndInit();
            this.kryptonPage57.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonNavigator13)).EndInit();
            this.kryptonNavigator13.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPage22)).EndInit();
            this.kryptonPage22.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPage36)).EndInit();
            this.kryptonPage36.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPage37)).EndInit();
            this.kryptonPage37.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPage9)).EndInit();
            this.kryptonPage9.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonNavigator14)).EndInit();
            this.kryptonNavigator14.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPage23)).EndInit();
            this.kryptonPage23.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPage10)).EndInit();
            this.kryptonPage10.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonNavigator15)).EndInit();
            this.kryptonNavigator15.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPage24)).EndInit();
            this.kryptonPage24.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPage11)).EndInit();
            this.kryptonPage11.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonNavigator16)).EndInit();
            this.kryptonNavigator16.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPage25)).EndInit();
            this.kryptonPage25.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPage12)).EndInit();
            this.kryptonPage12.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonNavigator17)).EndInit();
            this.kryptonNavigator17.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPage26)).EndInit();
            this.kryptonPage26.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPage13)).EndInit();
            this.kryptonPage13.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonNavigator18)).EndInit();
            this.kryptonNavigator18.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPage27)).EndInit();
            this.kryptonPage27.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPage38)).EndInit();
            this.kryptonPage38.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPage39)).EndInit();
            this.kryptonPage39.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPage14)).EndInit();
            this.kryptonPage14.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonNavigator19)).EndInit();
            this.kryptonNavigator19.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPage28)).EndInit();
            this.kryptonPage28.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPage15)).EndInit();
            this.kryptonPage15.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonNavigator20)).EndInit();
            this.kryptonNavigator20.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPage29)).EndInit();
            this.kryptonPage29.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        
        private KryptonPanel kryptonPanel1;

        private KryptonLabel lbcurtime;

        private ButtonSpecAny buttonSpecAny1;

        private System.Windows.Forms.Timer maintimer;

        private KryptonButton btnquit;

        private KryptonButton btnExport;

        private KryptonButton btnhelp;

        private KryptonManager kryptonManager1;

        private PictureBox topBanner;

        private KryptonButton btninit;

        private KryptonButton btnImport;

        private KryptonButton btnwordview;

        private KryptonButton btnSave;

        private KryptonWrapLabel kryptonWrapLabel1;

        private KryptonPanel kpcontactinner;

        private HSkinTableLayoutPanel kpcontact;
        private NewProjectEditor fnpDefault;
        private KryptonNavigator edithost2;
        private KryptonPage kryptonNavigator22;
        private KryptonNavigator kryptonNavigator7;
        private KryptonPage kpfPage1;
        private KryptonPage kryptonPage3;
        private KryptonPage kryptonPage4;
        private KryptonPage kryptonPage5;
        private KryptonPage kryptonPage6;
        private KryptonPage kryptonPage7;
        private KryptonPage kryptonPage57;
        private KryptonPage kryptonPage9;
        private KryptonPage kryptonPage10;
        private KryptonPage kryptonPage11;
        private KryptonPage kryptonPage12;
        private KryptonPage kryptonPage13;
        private KryptonPage kryptonPage14;
        private KryptonPage kryptonPage15;
        private KryptonNavigator kryptonNavigator8;
        private KryptonPage kryptonPage17;
        private KryptonNavigator kryptonNavigator9;
        private KryptonPage kryptonPage18;
        private KryptonNavigator kryptonNavigator10;
        private KryptonPage kryptonPage19;
        private KryptonNavigator kryptonNavigator11;
        private KryptonPage kryptonPage20;
        private KryptonNavigator kryptonNavigator12;
        private KryptonPage kryptonPage21;
        private KryptonNavigator kryptonNavigator13;
        private KryptonPage kryptonPage22;
        private KryptonNavigator kryptonNavigator14;
        private KryptonPage kryptonPage23;
        private KryptonNavigator kryptonNavigator15;
        private KryptonPage kryptonPage24;
        private KryptonNavigator kryptonNavigator16;
        private KryptonPage kryptonPage25;
        private KryptonNavigator kryptonNavigator17;
        private KryptonPage kryptonPage26;
        private KryptonNavigator kryptonNavigator18;
        private KryptonPage kryptonPage27;
        private KryptonNavigator kryptonNavigator19;
        private KryptonPage kryptonPage28;
        private KryptonNavigator kryptonNavigator20;
        private KryptonPage kryptonPage29;
        private KryptonPage kpfPage2;
        private KryptonPage kpfPage3;
        private KryptonPage kryptonPage16;
        private KryptonPage kryptonPage56;
        private KryptonPage kryptonPage34;
        private KryptonPage kryptonPage35;
        private KryptonPage kryptonPage36;
        private KryptonPage kryptonPage37;
        private RTFTextEditor feUI3;
        private RTFTextEditor feUI2;
        private RTFTextEditor feUI1;
        private RTFTextEditor feUI4;
        private RTFTextEditor feUI5;
        private KeTiTianBaoEditor feUI6;
        private RTFTextEditor feUI7;
        private RTFTextEditor feUI8;
        private RTFTextEditor feUI9;
        private RTFTextEditor feUI10;
        private JieDuanHuaFenEditor feUI11;
        private KryptonPage kryptonPage32;
        private XiangMuJieDuanHuaFenEditor feUI12;
        private KeTiJieDuanHuaFenEditor feUI13;
        private RTFTextEditor feUI14;
        private RTFTextEditor feUI15;
        private YanJiuGuGanEditor feUI16;
        private RTFTextEditor feUI17;
        private RTFTextEditor feUI18;
        private RTFTextEditor feUI19;
        private KryptonPage kryptonPage38;
        private KryptonPage kryptonPage39;
        private FuZeRenEditor feUI21;
        private QianTouDanWeiEditor feUI22;
        private KeTiLianXiEditor feUI23;
        private JingFeiYuSuanEditor feUI20;
        private XiangMuJingFeiGaiSuanShuoMingEditor feUI24;
        private BaoMiZiZhiFuYinJianEditor feUI25;
        private KryptonButton btnPersonManager;
        private KryptonButton btnUnitManager;
    }
}

