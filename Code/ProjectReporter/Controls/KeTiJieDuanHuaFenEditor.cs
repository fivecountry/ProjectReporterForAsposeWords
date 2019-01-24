using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;
using ProjectReporter.DB;
using ProjectReporter.DB.Entitys;

namespace ProjectReporter.Controls
{
    public partial class KeTiJieDuanHuaFenEditor : BaseEditor
    {
        public KeTiJieDuanHuaFenEditor()
        {
            InitializeComponent();

            //dgvDetail[dgvDetail.Columns.Count - 1, 0].Value = global::ProjectReporter.Properties.Resources.DELETE_28;
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

        private void dgvDetail_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            ((KryptonDataGridView)sender)[((KryptonDataGridView)sender).Columns.Count - 1, e.RowIndex == 0 ? e.RowIndex : e.RowIndex - 1].Value = global::ProjectReporter.Properties.Resources.DELETE_28;
        }

        private void dgvDetail_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        public override void ClearView()
        {
            base.ClearView();

            dgvDetail.Rows.Clear();
        }

        public override void RefreshView()
        {
            base.RefreshView();

            UpdateStepList();
        }

        private void UpdateStepList()
        {
            KeTiList = ConnectionManager.Context.table("Project").where("Type='" + "课题" + "' and ParentID='" + MainForm.Instance.ProjectObj.ID + "'").select("*").getList<Project>(new Project());
            StepList = ConnectionManager.Context.table("Step").where("ProjectID in (select ID from Project where Type='" + "课题" + "' and ParentID='" + MainForm.Instance.ProjectObj.ID + "')").select("*").getList<Step>(new Step());
            if (StepList != null && KeTiList != null && StepList.Count >= 1 && KeTiList.Count >= 1)
            {
                int indexx = 0;
                dgvDetail.Rows.Clear();
                foreach (Step step in StepList)
                {
                    ProjectAndStep projectAndStep = ConnectionManager.Context.table("ProjectAndStep").where("StepID='" + step.ID + "'").select("*").getItem<ProjectAndStep>(new ProjectAndStep());
                    Project ketiProject = null;
                    foreach (Project pp in KeTiList)
                    {
                        if (pp.ID != null && pp.ID.Equals(step.ProjectID))
                        {
                            ketiProject = pp;
                            break;
                        }
                    }

                    if (ketiProject == null || projectAndStep == null)
                    {
                        continue;
                    }
                    
                    indexx++;
                    List<object> cells = new List<object>();
                    cells.Add(indexx + "");
                    cells.Add(ketiProject.Name);
                    cells.Add(step.StepIndex);
                    cells.Add(projectAndStep.StepContent);
                    cells.Add(projectAndStep.StepResult);
                    cells.Add(projectAndStep.Method);
                    cells.Add(projectAndStep.Money);

                    int rowIndex = dgvDetail.Rows.Add(cells.ToArray());
                    dgvDetail.Rows[rowIndex].Tag = step;
                }
            }
        }

        public override void OnSaveEvent()
        {
            base.OnSaveEvent();

            foreach (DataGridViewRow dgvRow in dgvDetail.Rows)
            {
                if (dgvRow.Tag != null)
                {
                    Step step = (Step)dgvRow.Tag;

                    if (dgvRow.Cells[3].Value == null || string.IsNullOrEmpty(dgvRow.Cells[3].Value.ToString()))
                    {
                        MessageBox.Show("对不起,请输入研究内容");
                        return;
                    }
                    if (dgvRow.Cells[4].Value == null || string.IsNullOrEmpty(dgvRow.Cells[4].Value.ToString()))
                    {
                        MessageBox.Show("对不起,请输入研究成果");
                        return;
                    }
                    if (dgvRow.Cells[5].Value == null || string.IsNullOrEmpty(dgvRow.Cells[5].Value.ToString()))
                    {
                        MessageBox.Show("对不起,请输入考核方式");
                        return;
                    }
                    if (dgvRow.Cells[6].Value == null || string.IsNullOrEmpty(dgvRow.Cells[6].Value.ToString()))
                    {
                        MessageBox.Show("对不起,请输入阶段经费");
                        return;
                    }

                    ProjectAndStep pas = ConnectionManager.Context.table("ProjectAndStep").where("StepID='" + step.ID + "'").select("*").getItem<ProjectAndStep>(new ProjectAndStep());
                    pas.StepContent = dgvRow.Cells[3].Value.ToString();
                    pas.StepResult = dgvRow.Cells[4].Value.ToString();
                    pas.Method = dgvRow.Cells[5].Value.ToString();
                    pas.Money = decimal.Parse(dgvRow.Cells[6].Value.ToString());

                    pas.copyTo(ConnectionManager.Context.table("ProjectAndStep")).where("ID='" + pas.ID + "'").update();
                }
            }

            UpdateStepList();
        }

        public List<Project> KeTiList { get; set; }

        public List<Step> StepList { get; set; }

        public override bool IsInputCompleted()
        {
            if (dgvDetail.Rows.Count == 0)
            {
                MessageBox.Show("对不起,请输入课题阶段信息!");
            }

            return dgvDetail.Rows.Count >= 1;
        }
    }
}