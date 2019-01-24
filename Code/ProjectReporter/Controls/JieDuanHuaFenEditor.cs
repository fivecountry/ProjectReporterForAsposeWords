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
    public partial class JieDuanHuaFenEditor : BaseEditor
    {
        public JieDuanHuaFenEditor()
        {
            InitializeComponent();

            dgvDetail[dgvDetail.Columns.Count - 1, 0].Value = global::ProjectReporter.Properties.Resources.DELETE_28;
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

        public override void ClearView()
        {
            base.ClearView();

            txtTotalTime.Value = 0;
            txtTotalMoney.Value = 0;
            txtStepCount.Value = 0;

            dgvDetail.Rows.Clear();
        }

        public override void RefreshView()
        {
            base.RefreshView();

            txtTotalTime.Value = MainForm.Instance.ProjectObj.TotalTime != null ? MainForm.Instance.ProjectObj.TotalTime.Value : 0;
            txtTotalMoney.Value = MainForm.Instance.ProjectObj.TotalMoney != null ? MainForm.Instance.ProjectObj.TotalMoney.Value : 0;
            txtStepCount.Value = 0;

            UpdateStepList();
        }

        public void UpdateStepList()
        {
            StepList = ConnectionManager.Context.table("Step").where("ProjectID='" + MainForm.Instance.ProjectObj.ID + "'").select("*").getList<Step>(new Step());
            KeTiList = ConnectionManager.Context.table("Project").where("Type='" + "课题" + "' and ParentID='" + MainForm.Instance.ProjectObj.ID + "'").select("*").getList<Project>(new Project());

            int indexx = 0;
            dgvDetail.Rows.Clear();
            ((DataGridViewImageColumn)dgvDetail.Columns[dgvDetail.Columns.Count - 1]).Image = ProjectReporter.Properties.Resources.DELETE_28;
            foreach (Step step in StepList)
            {
                List<object> cells = new List<object>();
                indexx++;
                cells.Add(indexx+"");
                cells.Add(step.StepIndex != null ? step.StepIndex.Value : 0);
                cells.Add(step.StepTime != null ? step.StepTime.Value : 0);


                int rowIndex = dgvDetail.Rows.Add(cells.ToArray());
                dgvDetail.Rows[rowIndex].Tag = step;
            }

            txtStepCount.Value = StepList != null ? StepList.Count : 0;
        }

        public override void OnSaveEvent()
        {
            base.OnSaveEvent();

            foreach (DataGridViewRow dgvRow in dgvDetail.Rows)
            {
                int lastStepIndex = -1;

                #region 添加Step到项目
                Step step = null;
                if (dgvRow.Tag == null)
                {
                    //新行
                    step = new Step();
                    step.ProjectID = MainForm.Instance.ProjectObj.ID;
                }
                else
                {
                    //已在数据
                    step = (Step)dgvRow.Tag;

                    //当前的StepIndex 
                    lastStepIndex = step.StepIndex != null ? step.StepIndex.Value : -1;
                }

                if (dgvRow.Cells[1].Value == null)
                {   
                    break;
                }

                if (dgvRow.Cells[2].Value == null)
                {
                    MessageBox.Show("对不起,请输入阶段时长");
                    break;
                }

                step.StepIndex = Int32.Parse(((KryptonDataGridViewNumericUpDownCell)dgvRow.Cells[1]).Value.ToString());
                step.StepTime = Int32.Parse(((KryptonDataGridViewNumericUpDownCell)dgvRow.Cells[2]).Value.ToString());

                if (string.IsNullOrEmpty(step.ID))
                {
                    step.ID = Guid.NewGuid().ToString();
                    step.copyTo(ConnectionManager.Context.table("Step")).insert();

                    //添加ProjectAndStep数据
                    ProjectAndStep projectAndStep = new ProjectAndStep();
                    projectAndStep.ID = Guid.NewGuid().ToString();
                    projectAndStep.StepID = step.ID;
                    projectAndStep.copyTo(ConnectionManager.Context.table("ProjectAndStep")).insert();
                }
                else
                {
                    step.copyTo(ConnectionManager.Context.table("Step")).where("ID='" + step.ID + "'").update();
                }
                #endregion

                #region 添加课题的Step
                if (KeTiList != null)
                {
                    if (lastStepIndex == -1)
                    {
                        lastStepIndex = step.StepIndex != null ? step.StepIndex.Value : -1;
                    }

                    foreach (Project keti in KeTiList)
                    {
                       Step ketiStep = ConnectionManager.Context.table("Step").where("ProjectID='" + keti.ID + "' and StepIndex = " + lastStepIndex).select("*").getItem<Step>(new Step());
                       if (ketiStep != null && !string.IsNullOrEmpty(ketiStep.ID))
                       {
                           //已存在
                           ketiStep.StepIndex = step.StepIndex;
                           ketiStep.StepTime = step.StepTime;

                           ketiStep.copyTo(ConnectionManager.Context.table("Step")).where("ID='" + ketiStep.ID + "'").update();
                       }
                       else
                       {
                           //要添加
                           ketiStep = new Step();
                           ketiStep.ID = Guid.NewGuid().ToString();
                           ketiStep.ProjectID = keti.ID;
                           ketiStep.StepIndex = step.StepIndex;
                           ketiStep.StepTime = step.StepTime;

                           ketiStep.copyTo(ConnectionManager.Context.table("Step")).insert();


                           //添加ProjectAndStep数据
                           ProjectAndStep projectAndStep = new ProjectAndStep();
                           projectAndStep.ID = Guid.NewGuid().ToString();
                           projectAndStep.StepID = ketiStep.ID;
                           projectAndStep.copyTo(ConnectionManager.Context.table("ProjectAndStep")).insert();
                       }
                    }
                }
                #endregion
            }

            MainForm.Instance.RefreshEditor();
        }

        public List<Step> StepList { get; set; }

        private void dgvDetail_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvDetail.Rows.Count >= 1)
            {
                Step step = (Step)dgvDetail.Rows[e.RowIndex].Tag;
                if (step != null)
                {
                    if (MessageBox.Show("真的要删除吗?", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        ConnectionManager.Context.table("Step").where("ID='" + step.ID + "'").delete();
                        ConnectionManager.Context.table("ProjectAndStep").where("StepID='" + step.ID + "'").delete();

                        if (KeTiList != null)
                        {
                            foreach (Project keti in KeTiList)
                            {
                                Step substep = ConnectionManager.Context.table("Step").where("ProjectID='" + keti.ID + "' and StepIndex =" + step.StepIndex).select("*").getItem<Step>(new Step());
                                ConnectionManager.Context.table("Step").where("ProjectID='" + keti.ID + "' and StepIndex =" + step.StepIndex).delete();

                                if (substep == null || string.IsNullOrEmpty(substep.ID))
                                {
                                    continue;
                                }

                                ConnectionManager.Context.table("ProjectAndStep").where("StepID='" + substep.ID + "'").delete();
                            }
                        }

                        MainForm.Instance.RefreshEditor();
                    }
                }else
                {
                    if (e.ColumnIndex == dgvDetail.Columns.Count - 1)
                    {
                        if (MessageBox.Show("真的要删除吗?", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            try
                            {
                                dgvDetail.Rows.RemoveAt(e.RowIndex);
                            }
                            catch (Exception ex)
                            {
                                UpdateStepList();
                            }
                        }
                    }
                }
            }
        }

        public List<Project> KeTiList { get; set; }

        public override bool IsInputCompleted()
        {
            if (dgvDetail.Rows.Count == 0)
            {
                MessageBox.Show("对不起,请输入阶段信息!");
            }

            return dgvDetail.Rows.Count >= 1;
        }
    }
}