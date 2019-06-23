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

            dgvDetail.Paint += dgvDetail_Paint;
            //dgvDetail[dgvDetail.Columns.Count - 1, 0].Value = global::ProjectReporter.Properties.Resources.DELETE_28;
        }

        void dgvDetail_Paint(object sender, PaintEventArgs e)
        {
            //字符串显示格式
            StringFormat sf = new StringFormat();
            sf.Alignment = StringAlignment.Center;
            sf.LineAlignment = StringAlignment.Center;

            //合并列表
            List<KeyValuePair<int, int>> mergeList = new List<KeyValuePair<int, int>>();

            //处理列合并
            #region 1. 首先确定哪些可以合并
            int rowCount = dgvDetail.Rows.Count;
            object lastValue = null;
            int startRowIndex = -1;
            int endRowIndex = -1;
            for (int k = 0; k < rowCount; k++)
            {
                object value = dgvDetail.Rows[k].Cells[1].Value;
                if (k == 0)
                {
                    lastValue = value;
                    startRowIndex = k;
                    endRowIndex = -1;
                }
                else
                {
                    if (value == lastValue)
                    {
                        endRowIndex = k;
                        continue;
                    }
                    else
                    {
                        if (endRowIndex > startRowIndex)
                        {
                            mergeList.Add(new KeyValuePair<int, int>(startRowIndex, endRowIndex)); 
                        }

                        lastValue = value;
                        startRowIndex = k;
                        endRowIndex = -1;
                    }
                }
            }
            if (endRowIndex > startRowIndex)
            {
                mergeList.Add(new KeyValuePair<int, int>(startRowIndex, endRowIndex));
            }
            #endregion

            #region 2. 重新绘制单元格文本
            foreach (KeyValuePair<int, int> kvps in mergeList)
            {
                if (kvps.Value > kvps.Key)
                {
                    //可显示的文本
                    string rowText = dgvDetail.Rows[kvps.Key].Cells[1].Value != null ? dgvDetail.Rows[kvps.Key].Cells[1].Value.ToString() : string.Empty;

                    //开始的单元格显示范围
                    Rectangle rectStart = dgvDetail.GetCellDisplayRectangle(1, kvps.Key, false);
                    for (int displayIndex = kvps.Key + 1; displayIndex <= kvps.Value; displayIndex++)
                    {
                        Rectangle rectEnd = dgvDetail.GetCellDisplayRectangle(1, displayIndex, false);
                        rectStart.Height += rectEnd.Height;   
                    }
                    
                    //覆盖已经输出的文字
                    e.Graphics.FillRectangle(new SolidBrush(Color.White), new Rectangle(rectStart.X + 2, rectStart.Y + 2, rectStart.Width - 4, rectStart.Height - 4));

                    //重新绘制文本
                    e.Graphics.DrawString(rowText, new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134))), new SolidBrush(Color.Black), new RectangleF(rectStart.X + 2, rectStart.Y + 2, rectStart.Width - 4, rectStart.Height - 4), sf);

                    //绘制底部边框线
                    //e.Graphics.DrawLine(new Pen(new SolidBrush(Color.LightGray), 1), new Point(rectStart.Left, rectStart.Bottom), new Point(rectStart.Right, rectStart.Bottom));
                }
            }
            #endregion
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
            ((KryptonDataGridView)sender).Rows[e.RowIndex == 0 ? e.RowIndex : e.RowIndex - 1].Height = 150;
            ((KryptonDataGridView)sender).Rows[((KryptonDataGridView)sender).Rows.Count - 1].Height = 150;
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
            if (MainForm.Instance.ProjectObj != null)
            {
                KeTiList = ConnectionManager.Context.table("Project").where("Type='" + "课题" + "' and ParentID='" + MainForm.Instance.ProjectObj.ID + "'").select("*").getList<Project>(new Project());
                StepList = ConnectionManager.Context.table("Step").where("ProjectID in (select ID from Project where Type='" + "课题" + "' and ParentID='" + MainForm.Instance.ProjectObj.ID + "')").select("*").getList<Step>(new Step());
                if (StepList != null && KeTiList != null && StepList.Count >= 1 && KeTiList.Count >= 1)
                {
                    //数据行列表，先生成然后等待排序
                    List<DataGridViewRow> rowList = new List<DataGridViewRow>();

                    int indexx = 0;
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
                        cells.Add(projectAndStep.StepDest);
                        cells.Add(projectAndStep.StepContent);
                        cells.Add(projectAndStep.StepResult);
                        cells.Add(projectAndStep.StepTarget);
                        cells.Add(projectAndStep.Money);

                        DataGridViewRow dgvRow = new DataGridViewRow();
                        dgvRow.CreateCells(dgvDetail, cells.ToArray());
                        dgvRow.Tag = step;

                        rowList.Add(dgvRow);
                    }

                    foreach (DataGridViewColumn col in dgvDetail.Columns)
                    {
                        col.SortMode = DataGridViewColumnSortMode.NotSortable;
                    }

                    dgvDetail.Rows.Clear();
                    foreach (IGrouping<object, DataGridViewRow> group in rowList.GroupBy(x => x.Cells[1].Value))
                    {
                        foreach (DataGridViewRow student in group.OrderBy(a => (int)a.Cells[2].Value))//不排序直接输出的话：Student student in group
                        {
                            dgvDetail.Rows.Add(student);
                        }
                    }
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
                        MessageBox.Show("对不起,请输入完成内容及阶段目标");
                        return;
                    }

                    dgvRow.Cells[4].Value = "暂时不用";
                    if (dgvRow.Cells[4].Value == null || string.IsNullOrEmpty(dgvRow.Cells[4].Value.ToString()))
                    {
                        MessageBox.Show("对不起,请输入完成内容");
                        return;
                    }
                    if (dgvRow.Cells[5].Value == null || string.IsNullOrEmpty(dgvRow.Cells[5].Value.ToString()))
                    {
                        MessageBox.Show("对不起,请输入阶段成果、考核指标及考核方式");
                        return;
                    }

                    dgvRow.Cells[6].Value = "暂时不用";
                    if (dgvRow.Cells[6].Value == null || string.IsNullOrEmpty(dgvRow.Cells[6].Value.ToString()))
                    {
                        MessageBox.Show("对不起,请输入考核指标");
                        return;
                    }
                    if (dgvRow.Cells[7].Value == null || string.IsNullOrEmpty(dgvRow.Cells[7].Value.ToString()))
                    {
                        MessageBox.Show("对不起,请输入阶段经费(万)");
                        return;
                    }

                    ProjectAndStep pas = ConnectionManager.Context.table("ProjectAndStep").where("StepID='" + step.ID + "'").select("*").getItem<ProjectAndStep>(new ProjectAndStep());
                    pas.StepDest = dgvRow.Cells[3].Value.ToString();
                    pas.StepContent = dgvRow.Cells[4].Value.ToString();
                    pas.StepResult = dgvRow.Cells[5].Value.ToString();
                    pas.StepTarget = dgvRow.Cells[6].Value.ToString();
                    pas.Money = decimal.Parse(dgvRow.Cells[7].Value.ToString());

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

        private void dgvDetail_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvDetail_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex == 3)
            {
                string content = dgvDetail.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null ? dgvDetail.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() : string.Empty;
                ProjectReporter.Forms.TextBoxForm textboxForm = new Forms.TextBoxForm(content);
                if (textboxForm.ShowDialog() == DialogResult.OK)
                {
                    dgvDetail.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = textboxForm.SelectedText;
                }
            }
            else if (e.ColumnIndex == 5)
            {
                string content = dgvDetail.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null ? dgvDetail.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() : string.Empty;
                ProjectReporter.Forms.TextBoxForm textboxForm = new Forms.TextBoxForm(content);
                if (textboxForm.ShowDialog() == DialogResult.OK)
                {
                    dgvDetail.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = textboxForm.SelectedText;
                }
            }
        }

        private void btnExcelLoad_Click(object sender, EventArgs e)
        {

        }

        private void lklDownloadFuJian_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }
    }
}