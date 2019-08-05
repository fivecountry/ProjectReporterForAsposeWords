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

        [Editor("System.ComponentModel.Design.MultilineStringEditor, System.Design, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(System.Drawing.Design.UITypeEditor))]
        public string TitleLabelText { get { return TitleLabelControl.Text; } set { TitleLabelControl.Text = value; } }

        public AutoHeightLabel TitleLabelControl
        {
            get { return lblTitle; }
        }

        public WordDocumentEditControl RichTextBoxControl
        {
            get { return txtContent; }
        }

        public bool EnabledLabelAutoHeight
        {
            get
            {
                return TitleLabelControl.AutoHeight;
            }
            set
            {
                TitleLabelControl.AutoHeight = value;
                
                //检查是否需要计算标签高度
                if (value)
                {
                    //计算标签高度
                    TitleLabelControl.countLabelHeight();
                }
            }
        }

        public int TitleLabelHeight
        {
            get { return TitleLabelControl.Height; }
            set { TitleLabelControl.Height = value; }
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

            RichTextBoxControl.Clear();
        }

        public override void OnSaveEvent()
        {
            base.OnSaveEvent();

            RichTextBoxControl.SaveDoc(GetTextFilePath());
        }

        public string GetTextFilePath()
        {
            return Path.Combine(MainForm.ProjectFilesDir, RTFFileFirstName + Name.Replace(RTFEditorNameKey, string.Empty) + ".doc");
        }

        public override void RefreshView()
        {
            base.RefreshView();

            if (File.Exists(GetTextFilePath()))
            {
                RichTextBoxControl.LoadDoc(GetTextFilePath());
            }
        }

        public override bool IsInputCompleted()
        {
            return File.Exists(GetTextFilePath());
        }
    }
}