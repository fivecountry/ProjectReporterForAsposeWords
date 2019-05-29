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
    public partial class KeTiLianXiEditor : BaseEditor
    {
        public KeTiLianXiEditor()
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

        public override void ClearView()
        {
            base.ClearView();

            dgvDetail.Rows.Clear();
        }

        public override void RefreshView()
        {
            base.RefreshView();

            UpdatePersonList();

            UpdateKeTiLianXiList();
        }

        private void UpdateKeTiLianXiList()
        {
            KeTiList = ConnectionManager.Context.table("Project").where("ParentID = '" + MainForm.Instance.ProjectObj.ID + "'").select("*").getList<Project>(new Project());

            dgvDetail.Rows.Clear();
            int indexx = 0;
            foreach (Project proj in KeTiList)
            {
                Unit unitObj = ConnectionManager.Context.table("Unit").where("ID='" + proj.UnitID + "'").select("*").getItem<Unit>(new Unit());
                List<Task> taskList = ConnectionManager.Context.table("Task").where("ProjectID = '" + proj.ID + "' and Type='课题' and Role='负责人'").select("*").getList<Task>(new Task());
                if (taskList != null)
                {
                    foreach (Task taskObj in taskList)
                    {
                        Person personObj = ConnectionManager.Context.table("Person").where("ID ='" + taskObj.PersonID + "'").select("*").getItem<Person>(new Person());

                        if (unitObj == null || string.IsNullOrEmpty(unitObj.ID))
                        {
                            continue;
                        }
                        if (personObj == null || string.IsNullOrEmpty(personObj.ID))
                        {
                            continue;
                        }
                        if (taskObj == null || string.IsNullOrEmpty(taskObj.ID))
                        {
                            continue;
                        }

                        indexx++;
                        List<object> cells = new List<object>();
                        cells.Add(indexx + "");
                        cells.Add(proj.Name + "," + taskObj.Role);
                        cells.Add(personObj.Name + "(" + personObj.IDCard + ")");
                        cells.Add(personObj.Sex);
                        cells.Add(personObj.Birthday != null ? personObj.Birthday.Value.ToShortDateString() : "未知");
                        cells.Add(personObj.Job);
                        cells.Add(personObj.MobilePhone);
                        cells.Add(unitObj.UnitName + "," + unitObj.Address);

                        int rowIndex = dgvDetail.Rows.Add(cells.ToArray());
                        dgvDetail.Rows[rowIndex].Tag = proj;
                    }
                }
            }
        }

        public override void OnSaveEvent()
        {
            base.OnSaveEvent();

            foreach (DataGridViewRow dgvRow in dgvDetail.Rows)
            {
                Project data = null;
                if (dgvRow.Tag != null)
                {
                    data = (Project)dgvRow.Tag;

                    if (PersonDict.ContainsKey(dgvRow.Cells[2].Value.ToString()))
                    {
                        Task ddd = ConnectionManager.Context.table("Task").where("ProjectID='" + data.ID + "' and Type = '课题'  and Role='负责人'").select("*").getItem<Task>(new Task());
                        ddd.PersonID = PersonDict[dgvRow.Cells[2].Value.ToString()].ID;
                        ddd.IDCard = PersonDict[dgvRow.Cells[2].Value.ToString()].IDCard;

                        ddd.copyTo(ConnectionManager.Context.table("Task")).where("ID='" + ddd.ID + "'").update();
                    }
                }
            }

            UpdateKeTiLianXiList();
        }

        private void UpdatePersonList()
        {
            PersonList = ConnectionManager.Context.table("Person").select("*").getList<Person>(new Person());
            if (PersonList != null)
            {
                ((KryptonDataGridViewComboBoxColumn)dgvDetail.Columns[2]).Items.Clear();
                PersonDict.Clear();
                foreach (Person p in PersonList)
                {
                    string key = p.Name + "(" + p.IDCard + ")";
                    ((KryptonDataGridViewComboBoxColumn)dgvDetail.Columns[2]).Items.Add(key);
                    PersonDict.Add(key, p);
                }
            }
        }

        protected List<Person> PersonList = new List<Person>();

        protected Dictionary<string, Person> PersonDict = new Dictionary<string, Person>();

        public List<Project> KeTiList { get; set; }

        private void dgvDetail_CellParsing(object sender, DataGridViewCellParsingEventArgs e)
        {
            if (e.ColumnIndex == 2)
            {
                if (dgvDetail.Rows[e.RowIndex].Tag != null)
                {
                    Project proj = (Project)dgvDetail.Rows[e.RowIndex].Tag;
                    KryptonDataGridViewComboBoxCell comboboxCell = (KryptonDataGridViewComboBoxCell)dgvDetail.Rows[e.RowIndex].Cells[e.ColumnIndex];
                    if (comboboxCell.EditedFormattedValue != null)
                    {
                        string key = comboboxCell.EditedFormattedValue.ToString();

                        if (PersonDict.ContainsKey(key))
                        {
                            Person personObj = PersonDict[key];
                            Unit unitObj = ConnectionManager.Context.table("Unit").where("ID='" + proj.UnitID + "'").select("*").getItem<Unit>(new Unit());                                                        
                            if (unitObj != null)
                            {
                                dgvDetail[3, e.RowIndex].Value = personObj.Sex;
                                dgvDetail[4, e.RowIndex].Value = personObj.Birthday;
                                dgvDetail[5, e.RowIndex].Value = personObj.Job;
                                dgvDetail[6, e.RowIndex].Value = personObj.MobilePhone;
                                dgvDetail[7, e.RowIndex].Value = unitObj.UnitName + "," + unitObj.Address;
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
                MessageBox.Show("对不起,请输入课题联系人信息!");
            }

            return dgvDetail.Rows.Count >= 1;
        }
    }
}