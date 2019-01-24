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
    public partial class FuZeRenEditor : BaseEditor
    {
        public FuZeRenEditor()
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

            UpdateFuZeRenList();
        }

        private void UpdateFuZeRenList()
        {
            TaskList = ConnectionManager.Context.table("Task").where("Type='" + "项目" + "' and Role = '" + "负责人" + "' and ProjectId = '" + MainForm.Instance.ProjectObj.ID + "'").select("*").getList<Task>(new Task());

            int indexx = 0;
            dgvDetail.Rows.Clear();
            foreach (Task task in TaskList)
            {
                string personKey = string.Empty;
                Person personObj= null;
                foreach(KeyValuePair<string,Person> kvp in PersonDict)
                {
                   if (kvp.Value.ID != null && kvp.Value.ID.Equals(task.PersonID))
                   {
                      personObj = kvp.Value;
                      personKey = kvp.Key;
                   }
                }

                if (personObj == null)
                {
                    continue;
                }

                indexx++;
                List<object> cells = new List<object>();
                cells.Add(indexx + "");
                cells.Add(personKey);
                cells.Add(personObj.Sex);
                cells.Add(personObj.Birthday);
                cells.Add(personObj.Job);
                cells.Add(personObj.Telephone);
                cells.Add(personObj.MobilePhone);

                int rowIndex = dgvDetail.Rows.Add(cells.ToArray());
                dgvDetail.Rows[rowIndex].Tag = task;
            }
        }

        public override void OnSaveEvent()
        {
            base.OnSaveEvent();

            foreach (DataGridViewRow dgvRow in dgvDetail.Rows)
            {
                Task data = null;
                if (dgvRow.Tag != null)
                {
                    data = (Task)dgvRow.Tag;

                    if (PersonDict.ContainsKey(dgvRow.Cells[1].Value.ToString()))
                    {
                        data.PersonID = PersonDict[dgvRow.Cells[1].Value.ToString()].ID;
                        data.IDCard = PersonDict[dgvRow.Cells[1].Value.ToString()].IDCard;

                        data.copyTo(ConnectionManager.Context.table("Task")).where("ID='" + data.ID + "'").update();
                    }
                }
            }

            UpdateFuZeRenList();
        }

        private void UpdatePersonList()
        {
            PersonList = ConnectionManager.Context.table("Person").select("*").getList<Person>(new Person());
            if (PersonList != null)
            {
                ((KryptonDataGridViewComboBoxColumn)dgvDetail.Columns[1]).Items.Clear();
                PersonDict.Clear();
                foreach (Person p in PersonList)
                {
                    string key = p.Name + "(" + p.IDCard + ")";
                    ((KryptonDataGridViewComboBoxColumn)dgvDetail.Columns[1]).Items.Add(key);
                    PersonDict.Add(key, p);
                }
            }
        }

        protected List<Person> PersonList = new List<Person>();

        protected Dictionary<string, Person> PersonDict = new Dictionary<string, Person>();

        protected List<Task> TaskList { get; set; }

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
                            dgvDetail[2, e.RowIndex].Value = person.Sex;
                            dgvDetail[3, e.RowIndex].Value = person.Birthday;
                            dgvDetail[4, e.RowIndex].Value = person.Job;
                            dgvDetail[5, e.RowIndex].Value = person.Telephone;
                            dgvDetail[6, e.RowIndex].Value = person.MobilePhone;
                        }
                    }
                }
            }
        }

        public override bool IsInputCompleted()
        {
            if (dgvDetail.Rows.Count == 0)
            {
                MessageBox.Show("对不起,请选择一个项目负责人!");
            }

            return dgvDetail.Rows.Count >= 1;
        }
    }
}