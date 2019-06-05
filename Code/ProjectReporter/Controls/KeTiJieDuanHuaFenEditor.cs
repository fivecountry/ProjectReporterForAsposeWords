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

                dgvDetail.Sort(dgvDetail.Columns[1], ListSortDirection.Ascending);
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