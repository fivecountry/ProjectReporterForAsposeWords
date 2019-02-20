using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

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

        public KeTiDetailEditor()
        {
            InitializeComponent();

            RTFFileFirstName = "rtpinput_";
            RTFEditorNameKey = "feUI";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            OnSaveEvent();
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
            txtDest.SaveFile(GetDestFilePath());
            txtContent.SaveFile(GetContentFilePath());
            txtNeed.SaveFile(GetNeedFilePath());
        }

        private string GetNeedFilePath()
        {
            return Path.Combine(MainForm.ProjectFilesDir, RTFFileFirstName + Name.Replace(RTFEditorNameKey, string.Empty) + "_need" + ".rtf");
        }

        private string GetContentFilePath()
        {
            return Path.Combine(MainForm.ProjectFilesDir, RTFFileFirstName + Name.Replace(RTFEditorNameKey, string.Empty) + "_cnt" + ".rtf");
        }

        private string GetDestFilePath()
        {
            return Path.Combine(MainForm.ProjectFilesDir, RTFFileFirstName + Name.Replace(RTFEditorNameKey, string.Empty) + "_dest" + ".rtf");
        }

        private string GetInfoFilePath()
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
                txtDest.LoadFile(GetDestFilePath());
            }

            if (File.Exists(GetContentFilePath()))
            {
                txtContent.LoadFile(GetContentFilePath());
            }

            if (File.Exists(GetNeedFilePath()))
            {
                txtNeed.LoadFile(GetNeedFilePath());
            }
        }

        public override bool IsInputCompleted()
        {
            return File.Exists(GetInfoFilePath()) && File.Exists(GetDestFilePath()) && File.Exists(GetContentFilePath()) && File.Exists(GetNeedFilePath());
        }
    }
}