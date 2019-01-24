using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace ProjectReporter.Forms
{
    public partial class KeTiXiangXiForm : Form
    {
        private DB.Entitys.Project KeTiObj;

        public KeTiXiangXiForm(DB.Entitys.Project kett)
        {
            this.KeTiObj = kett;
            InitializeComponent();

            this.Text = "课题(" + this.KeTiObj.Name + ")详情";
            freEditor.RTFFileFirstName = "keti_" + freEditor.RTFFileFirstName;
            freEditor.Name = freEditor.RTFEditorNameKey + KeTiObj.ID;

            if (!File.Exists(Path.Combine(MainForm.ProjectFilesDir, freEditor.RTFFileFirstName + kett.ID + ".rtf")))
            {
                File.Copy(Path.Combine(Application.StartupPath, "Helper//xitixiangxi.rtf"), Path.Combine(MainForm.ProjectFilesDir, freEditor.RTFFileFirstName + kett.ID + ".rtf"));
            }

            freEditor.RefreshView();   
        }

        private void freEditor_SaveEvent(object sender, EventArgs args)
        {
            MessageBox.Show("保存完成");
            Close();
        }
    }
}