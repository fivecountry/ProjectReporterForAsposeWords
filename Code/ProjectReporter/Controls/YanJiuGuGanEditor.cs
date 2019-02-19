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
using ProjectReporter.Forms;

namespace ProjectReporter.Controls
{
    public partial class YanJiuGuGanEditor : BaseEditor
    {
        public YanJiuGuGanEditor()
        {
            InitializeComponent();

            dgvDetail[dgvDetail.Columns.Count - 1, 0].Value = global::ProjectReporter.Properties.Resources.DELETE_28;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            NewGuGanLianXiRenForm form = new NewGuGanLianXiRenForm(null);
            if (form.ShowDialog() == DialogResult.OK)
            {
                RefreshView();
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

        private void dgvDetail_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            ((KryptonDataGridView)sender)[((KryptonDataGridView)sender).Columns.Count - 1, e.RowIndex == 0 ? e.RowIndex : e.RowIndex - 1].Value = global::ProjectReporter.Properties.Resources.DELETE_28;
        }

        public override void ClearView()
        {
            base.ClearView();

            dgvDetail.Rows.Clear();
        }

        public override void RefreshView()
        {
            base.RefreshView();

            UpatePersonList();

            UpdateJobList();

            UpdateTaskList();
        }

        private void UpdateJobList()
        {
            KryptonDataGridViewComboBoxColumn comboboxColumn = (KryptonDataGridViewComboBoxColumn)dgvDetail.Columns[5];
            comboboxColumn.Items.Clear();
            JobDict.Clear();

            //项目的负责人和成员
            string projectA = "项目-负责人";
            string projectB = "项目-成员";
            ((KryptonDataGridViewComboBoxColumn)dgvDetail.Columns[5]).Items.Add(projectA);
            ((KryptonDataGridViewComboBoxColumn)dgvDetail.Columns[5]).Items.Add(projectB);
            JobDict.Add(projectA, MainForm.Instance.ProjectObj);
            JobDict.Add(projectB, MainForm.Instance.ProjectObj);

            List<Project> ketiList = ConnectionManager.Context.table("Project").where("ParentID='" + MainForm.Instance.ProjectObj.ID + "'").select("*").getList<Project>(new Project());
            if (ketiList != null)
            {
                foreach (Project proj in ketiList)
                {
                    projectA = proj.Name + "-负责人";
                    projectB = proj.Name + "-成员";
                    ((KryptonDataGridViewComboBoxColumn)dgvDetail.Columns[5]).Items.Add(projectA);
                    ((KryptonDataGridViewComboBoxColumn)dgvDetail.Columns[5]).Items.Add(projectB);
                    JobDict.Add(projectA, proj);
                    JobDict.Add(projectB, proj);
                }
            }
        }

        private void UpdateTaskList()
        {
            TaskList = ConnectionManager.Context.table("Task").where("ProjectID in (select ID from Project where ParentID = '" + MainForm.Instance.ProjectObj.ID + "') or ProjectID='" + MainForm.Instance.ProjectObj.ID + "'").select("*").getList<Task>(new Task());

            int indexx = 0;
            dgvDetail.Rows.Clear();
            ((DataGridViewImageColumn)dgvDetail.Columns[dgvDetail.Columns.Count - 2]).Image = ProjectReporter.Properties.Resources.DELETE_28;
            foreach (Task task in TaskList)
            {
                indexx++;
                Person person = null;
                Unit unit = null;
                foreach (Person p in PersonList)
                {
                    if (p.ID != null && p.ID.Equals(task.PersonID))
                    {
                        person = p;
                        break;
                    }
                }
                
                if (person == null || string.IsNullOrEmpty(person.ID))
                {
                    continue;
                }

                unit = ConnectionManager.Context.table("Unit").where("ID='" + person.UnitID + "'").select("*").getItem<Unit>(new Unit());

                if (unit == null || string.IsNullOrEmpty(unit.ID))
                {
                    continue;
                }

                List<object> cells = new List<object>();
                cells.Add(indexx + "");
                cells.Add(person.Name + "(" + person.IDCard + ")");
                cells.Add(unit.UnitName);
                cells.Add(person.Job);
                cells.Add(person.Specialty);

                string roleName = string.Empty;
                foreach (KeyValuePair<string, Project> kvp in JobDict)
                {
                    if (kvp.Value.ID != null && kvp.Value.ID.Equals(task.ProjectID))
                    {
                        if (kvp.Key.EndsWith(task.Role))
                        {
                            roleName = kvp.Key;
                            break;
                        }
                    }
                }
                cells.Add(roleName);

                cells.Add(task.Content);
                cells.Add(task.TotalTime);

                int rowIndex = dgvDetail.Rows.Add(cells.ToArray());
                dgvDetail.Rows[rowIndex].Tag = task;
            }
        }

        private void UpatePersonList()
        {
            KryptonDataGridViewComboBoxColumn comobobxColumn = ((KryptonDataGridViewComboBoxColumn)dgvDetail.Columns[1]);
            comobobxColumn.Items.Clear();
            PersonDict.Clear();

            PersonList = ConnectionManager.Context.table("Person").select("*").getList<Person>(new Person());
            if (PersonList != null)
            {
                foreach (Person person in PersonList)
                {
                    string key = person.Name + "(" + person.IDCard + ")";
                    PersonDict.Add(key, person);

                    comobobxColumn.Items.Add(key);
                }
            }
        }

        public override void OnSaveEvent()
        {
            base.OnSaveEvent();

            foreach (DataGridViewRow dgvRow in dgvDetail.Rows)
            {
                Task task = null;
                if (dgvRow.Tag == null)
                {
                    //新行
                    task = new Task();
                    task.ProjectID = MainForm.Instance.ProjectObj.ID;
                    task.Type = "项目";
                }
                else
                {
                    //已存在
                    task = (Task)dgvRow.Tag;
                }

                if (dgvRow.Cells[1].Value == null || string.IsNullOrEmpty(dgvRow.Cells[1].Value.ToString()))
                {
                    continue;
                }
                if (dgvRow.Cells[5].Value == null || string.IsNullOrEmpty(dgvRow.Cells[5].Value.ToString()))
                {
                    MessageBox.Show("对不起,请选择项目内职务");
                    return;
                }
                if (dgvRow.Cells[6].Value == null || string.IsNullOrEmpty(dgvRow.Cells[6].Value.ToString()))
                {
                    MessageBox.Show("对不起,请输入任务分工");
                    return;
                }
                if (dgvRow.Cells[7].Value == null || string.IsNullOrEmpty(dgvRow.Cells[7].Value.ToString()))
                {
                    MessageBox.Show("对不起,请输入每年为项目工作时间(月)");
                    return;
                }

                if (PersonDict.ContainsKey(dgvRow.Cells[1].Value.ToString()))
                {
                    task.PersonID = PersonDict[dgvRow.Cells[1].Value.ToString()].ID;
                    task.IDCard = PersonDict[dgvRow.Cells[1].Value.ToString()].IDCard;
                }
                else
                {
                    MessageBox.Show("对不起,人员不存在");
                    return;
                }

                string roleName = dgvRow.Cells[5].Value.ToString();
                if (JobDict.ContainsKey(roleName))
                {
                    if (roleName.StartsWith("项目-"))
                    {
                        //项目
                        task.Type = "项目";
                        task.Role = roleName.Replace("项目-", string.Empty);
                    }
                    else
                    {
                        //课题
                        task.Type = "课题";
                        task.Role = roleName.Split('-')[1];
                    }

                    task.ProjectID = JobDict[roleName].ID;
                }

                task.Content = dgvRow.Cells[6].Value.ToString();
                task.TotalTime = Int32.Parse(dgvRow.Cells[7].Value.ToString());

                if (string.IsNullOrEmpty(task.ID))
                {
                    //insert
                    task.ID = Guid.NewGuid().ToString();
                    task.copyTo(ConnectionManager.Context.table("Task")).insert();
                }
                else
                {
                    //update
                    task.copyTo(ConnectionManager.Context.table("Task")).where("ID='" + task.ID + "'").update();
                }
            }

            MainForm.Instance.RefreshEditor();
        }

        public List<Person> PersonList { get; set; }

        protected Dictionary<string, Person> PersonDict = new Dictionary<string, Person>();

        protected Dictionary<string, Project> JobDict = new Dictionary<string, Project>();

        private void dgvDetail_CellParsing(object sender, DataGridViewCellParsingEventArgs e)
        {
            if (e.ColumnIndex == 1)
            {
                KryptonDataGridViewComboBoxCell comboboxCell = (KryptonDataGridViewComboBoxCell)dgvDetail.Rows[e.RowIndex].Cells[e.ColumnIndex];
                if (comboboxCell.EditedFormattedValue != null)
                {
                    string key = comboboxCell.EditedFormattedValue.ToString();

                    if (PersonDict.ContainsKey(key))
                    {
                        Person person = PersonDict[key];

                        Unit unitObj = ConnectionManager.Context.table("Unit").where("ID='" + person.UnitID + "'").select("*").getItem<Unit>(new Unit());
                        if (unitObj != null)
                        {
                            dgvDetail[2, e.RowIndex].Value = unitObj.UnitName;
                            dgvDetail[3, e.RowIndex].Value = person.Job;
                            dgvDetail[4, e.RowIndex].Value = person.Specialty;
                        }
                    }
                }
            }
        }

        public List<Task> TaskList { get; set; }

        private void dgvDetail_EditModeChanged(object sender, EventArgs e)
        {
            //if (dgvDetail.SelectedRows != null && dgvDetail.SelectedRows.Count >= 1)
            //{
            //    DataGridViewRow dgvRow = dgvDetail.SelectedRows[0];
            //    if (dgvRow.Cells[1].Value != null)
            //    {
            //        string key = dgvRow.Cells[1].Value.ToString();

            //        if (PersonDict.ContainsKey(key))
            //        {
            //            Person person = PersonDict[key];

            //            Unit unitObj = ConnectionManager.Context.table("Unit").where("ID='" + person.UnitID + "'").select("*").getItem<Unit>(new Unit());
            //            if (unitObj != null)
            //            {
            //                dgvRow.Cells[2].Value = unitObj.UnitName;
            //                dgvRow.Cells[3].Value = person.Job;
            //                dgvRow.Cells[4].Value = person.Specialty;
            //            }
            //        }
            //    }
            //}
        }

        private void dgvDetail_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvDetail.Rows.Count >= 1)
            {
                if (e.ColumnIndex == dgvDetail.Columns.Count - 1)
                {
                    if (dgvDetail.Rows[e.RowIndex].Tag != null)
                    {
                        Task task = (Task)dgvDetail.Rows[e.RowIndex].Tag;

                        NewGuGanLianXiRenForm form = new NewGuGanLianXiRenForm(task);
                        if (form.ShowDialog() == DialogResult.OK)
                        {
                            RefreshView();
                        }
                    }
                }

                if (e.ColumnIndex == dgvDetail.Columns.Count - 2)
                {
                    if (dgvDetail.Rows[e.RowIndex].Tag != null)
                    {
                        Task task = (Task)dgvDetail.Rows[e.RowIndex].Tag;
                        if (MessageBox.Show("真的要删除吗?", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            ConnectionManager.Context.table("Task").where("ID='" + task.ID + "'").delete();
                            MainForm.Instance.RefreshEditor();
                        }
                    }
                    else
                    {
                        if (e.ColumnIndex == dgvDetail.Columns.Count - 2)
                        {
                            if (MessageBox.Show("真的要删除吗?", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
                            {
                                try
                                {
                                    dgvDetail.Rows.RemoveAt(e.RowIndex);
                                }
                                catch (Exception ex)
                                {
                                    UpdateTaskList();
                                }
                            }
                        }
                    }
                }
            }
        }

        public override bool IsInputCompleted()
        {
            if (dgvDetail.Rows.Count == 0)
            {
                MessageBox.Show("对不起,请输入研究骨干信息!");
            }

            return dgvDetail.Rows.Count >= 1;
        }

        private void dgvDetail_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvDetail.Rows[e.RowIndex].Tag != null)
            {
                Task task = (Task)dgvDetail.Rows[e.RowIndex].Tag;
                NewGuGanLianXiRenForm form = new NewGuGanLianXiRenForm(task);
                if (form.ShowDialog() == DialogResult.OK)
                {
                    RefreshView();
                }
            }
        }
    }
}