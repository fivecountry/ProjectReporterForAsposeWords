using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using ComponentFactory.Krypton.Navigator;

namespace ProjectReporter.Controls
{
    public partial class KeTiDetailEditor : BaseEditor
    {
        public string RTFFileFirstName { get; set; }

        public string RTFEditorNameKey { get; set; }

        public string TitleLabelText { get { return TitleLabelControl.Text; } set { TitleLabelControl.Text = value; } }

        public Label TitleLabelControl
        {
            get { return lblTitle; }
        }

        public bool EnabledSaveButton { get { return btnSave.Enabled; } set { btnSave.Enabled = value; } }

        public bool EnabledLastButton { get { return btnLast.Enabled; } set { btnLast.Enabled = value; } }

        public bool EnabledNextButton { get { return btnNext.Enabled; } set { btnNext.Enabled = value; } }

        public KryptonNavigator DetailTabs
        {
            get { return knKetiDetailTabs; }
        }

        public KeTiDetailEditor()
        {
            InitializeComponent();

            RTFFileFirstName = "rtpinput_";
            RTFEditorNameKey = "feUI";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            ProjectReporter.Forms.UIDoWorkProcessForm upf = new Forms.UIDoWorkProcessForm();
            upf.EnabledDisplayProgress = false;
            upf.LabalText = "正在保存,请等待...";
            upf.ShowProgress();

            try
            {
                OnSaveEvent();
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

        private void btnLast_Click(object sender, EventArgs e)
        {
            OnLastEvent();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            OnNextEvent();
        }

        public override void ClearView()
        {
            base.ClearView();

            txtInfo.Clear();
            txtDest.Clear();
            txtContent.Clear();
            txtNeed.Clear();
        }

        public override void OnSaveEvent()
        {
            base.OnSaveEvent();

            txtInfo.SaveFile(GetInfoFilePath());
            txtDest.SaveDoc(GetDestFilePath());
            txtContent.SaveDoc(GetContentFilePath());
            txtNeed.SaveDoc(GetNeedFilePath());
        }

        public string GetNeedFilePath()
        {
            return Path.Combine(MainForm.ProjectFilesDir, RTFFileFirstName + Name.Replace(RTFEditorNameKey, string.Empty) + "_need" + ".doc");
        }

        public string GetContentFilePath()
        {
            return Path.Combine(MainForm.ProjectFilesDir, RTFFileFirstName + Name.Replace(RTFEditorNameKey, string.Empty) + "_cnt" + ".doc");
        }

        public string GetDestFilePath()
        {
            return Path.Combine(MainForm.ProjectFilesDir, RTFFileFirstName + Name.Replace(RTFEditorNameKey, string.Empty) + "_dest" + ".doc");
        }

        public string GetInfoFilePath()
        {
            return Path.Combine(MainForm.ProjectFilesDir, RTFFileFirstName + Name.Replace(RTFEditorNameKey, string.Empty) + "_info" + ".rtf");
        }

        public override void RefreshView()
        {
            base.RefreshView();

            if (File.Exists(GetInfoFilePath()))
            {
                txtInfo.LoadFile(GetInfoFilePath());
            }

            if (File.Exists(GetDestFilePath()))
            {
                txtDest.LoadDoc(GetDestFilePath());
            }

            if (File.Exists(GetContentFilePath()))
            {
                txtContent.LoadDoc(GetContentFilePath());
            }

            if (File.Exists(GetNeedFilePath()))
            {
                txtNeed.LoadDoc(GetNeedFilePath());
            }
        }

        public override bool IsInputCompleted()
        {
            return File.Exists(GetInfoFilePath()) && File.Exists(GetDestFilePath()) && File.Exists(GetContentFilePath()) && File.Exists(GetNeedFilePath());
        }
    }
}