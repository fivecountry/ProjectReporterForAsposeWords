using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ProjectReporter.Controls;
using System.IO;

namespace ProjectReporter.Controls
{
    public partial class RTFTextEditor : BaseEditor
    {
        public string RTFFileFirstName { get; set; }

        public string RTFEditorNameKey { get; set; }

        public string TitleLabelText { get { return TitleLabelControl.Text; } set { TitleLabelControl.Text = value; } }

        public Label TitleLabelControl
        {
            get { return lblTitle; }
        }

        public RichTextBoxTableClass RichTextBoxControl
        {
            get { return txtContent; }
        }

        public bool EnabledSaveButton { get { return btnSave.Enabled; } set { btnSave.Enabled = value; } }

        public bool EnabledLastButton { get { return btnLast.Enabled; } set { btnLast.Enabled = value; } }

        public bool EnabledNextButton { get { return btnNext.Enabled; } set { btnNext.Enabled = value; } }

        public RTFTextEditor()
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

            RichTextBoxControl.Clear();
        }

        public override void OnSaveEvent()
        {
            base.OnSaveEvent();

            RichTextBoxControl.SaveFile(Path.Combine(MainForm.ProjectFilesDir, RTFFileFirstName + Name.Replace(RTFEditorNameKey, string.Empty) + ".rtf"));
        }

        public override void RefreshView()
        {
            base.RefreshView();

            if (File.Exists(Path.Combine(MainForm.ProjectFilesDir, RTFFileFirstName + Name.Replace(RTFEditorNameKey, string.Empty) + ".rtf")))
            {
                RichTextBoxControl.LoadFile(Path.Combine(MainForm.ProjectFilesDir, RTFFileFirstName + Name.Replace(RTFEditorNameKey, string.Empty) + ".rtf"));
            }
        }

        public override bool IsInputCompleted()
        {
            return File.Exists(Path.Combine(MainForm.ProjectFilesDir, RTFFileFirstName + Name.Replace(RTFEditorNameKey, string.Empty) + ".rtf"));
        }
    }
}