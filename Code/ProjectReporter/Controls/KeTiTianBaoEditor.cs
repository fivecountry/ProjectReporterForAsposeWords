using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;
using ProjectReporter.Forms;
using ProjectReporter.DB;
using ProjectReporter.DB.Entitys;

namespace ProjectReporter.Controls
{
    public partial class KeTiTianBaoEditor : BaseEditor
    {
        public KeTiTianBaoEditor()
        {
            InitializeComponent();

            //显示图标
            dgvDetail[dgvDetail.Columns.Count - 1, 0].Value = global::ProjectReporter.Properties.Resources.exclamation_16;
            dgvDetail[dgvDetail.Columns.Count - 2, 0].Value = global::ProjectReporter.Properties.Resources.DELETE_28;

            //显示密级
            ((KryptonDataGridViewComboBoxColumn)dgvDetail.Columns[2]).Items.Add("公开");
            ((KryptonDataGridViewComboBoxColumn)dgvDetail.Columns[2]).Items.Add("秘密");
            ((KryptonDataGridViewComboBoxColumn)dgvDetail.Columns[2]).Items.Add("机密");
            ((KryptonDataGridViewComboBoxColumn)dgvDetail.Columns[2]).Items.Add("绝密");
        }

        private void UpdateUnitList()
        {
            UnitList = ConnectionManager.Context.table("UnitExt").select("*").getList<UnitExt>(new UnitExt());
            if (UnitList != null)
            {
                //((KryptonDataGridViewComboBoxColumn)dgvDetail.Columns[4]).Items.Clear();
                //foreach (Unit u in UnitList)
                //{
                //    ((KryptonDataGridViewComboBoxColumn)dgvDetail.Columns[4]).Items.Add(u.UnitName);
                //}
            }
        }

        private void UpdatePersonList()
        {
            PersonList = ConnectionManager.Context.table("Person").select("*").getList<Person>(new Person());
            if (PersonList != null)
            {
                ((KryptonDataGridViewComboBoxColumn)dgvDetail.Columns[3]).Items.Clear();
                PersonDict.Clear();
                foreach (Person p in PersonList)
                {
                    string key = p.Name + "(" + p.IDCard + ")";
                    ((KryptonDataGridViewComboBoxColumn)dgvDetail.Columns[3]).Items.Add(key);
                    PersonDict.Add(key, p);
                }
            }
        }

        private void UpdateKeTiList()
        {
            KeTiList = ConnectionManager.Context.table("Project").where("Type='" + "课题" + "' and ParentID='" + MainForm.Instance.ProjectObj.ID + "'").select("*").getList<Project>(new Project());

            dgvDetail.Rows.Clear();
            ((DataGridViewImageColumn)dgvDetail.Columns[dgvDetail.Columns.Count - 1]).Image = ProjectReporter.Properties.Resources.DELETE_28;
            int indexx = 0;
            foreach (Project keti in KeTiList)
            {
                string personName = string.Empty;
                string unitName = string.Empty;
                string content = string.Empty;
                string unitBankNo = string.Empty;
                string unitExtId = string.Empty;

                Task ketiTask = ConnectionManager.Context.table("Task").where("ProjectID='" + keti.ID + "'").select("*").getItem<Task>(new Task());
                if (ketiTask != null)
                {
                    content = ketiTask.Content;

                    Person personObj = ConnectionManager.Context.table("Person").where("ID='" + ketiTask.PersonID + "'").select("*").getItem<Person>(new Person());
                    Unit unitObj = ConnectionManager.Context.table("Unit").where("ID='" + keti.UnitID + "'").select("*").getItem<Unit>(new Unit());
                    UnitExt unitExtObj = ConnectionManager.Context.table("UnitExt").where("ID='" + keti.UnitID + "'").select("*").getItem<UnitExt>(new UnitExt());

                    if (personObj != null)
                    {
                        personName = personObj.Name + "(" + personObj.IDCard + ")";
                    }

                    if (unitObj != null)
                    {
                        unitName = unitObj.UnitName;
                    }

                    if (unitExtObj != null)
                    {
                        unitBankNo = unitExtObj.UnitBankNo;
                        unitExtId = unitExtObj.ID;
                    }
                }

                indexx++;
                List<object> cells = new List<object>();
                cells.Add(indexx + "");
                cells.Add(keti.Name);
                cells.Add(keti.SecretLevel);
                cells.Add(personName);
                cells.Add(unitName);
                cells.Add(unitBankNo);
                cells.Add(content);
                cells.Add(keti.Type2 == "总体课题");

                int rowIndex = dgvDetail.Rows.Add(cells.ToArray());
                dgvDetail.Rows[rowIndex].Tag = keti;

                dgvDetail.Rows[rowIndex].Cells[5].Tag = unitExtId;
            }
        }

        private void dgvDetail_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvDetail.Rows.Count >= 1)
            {
                Project kett = ((Project)dgvDetail.Rows[e.RowIndex].Tag);
                if (kett != null)
                {
                    if (e.ColumnIndex == dgvDetail.Columns.Count - 1)
                    {
                        KeTiXiangXiForm form = new KeTiXiangXiForm(kett);
                        form.ShowDialog();
                    }
                    else if (e.ColumnIndex == dgvDetail.Columns.Count - 2)
                    {
                        #region 删除数据
                        if (MessageBox.Show("真的要删除吗?", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {

                            ConnectionManager.Context.table("Project").where("ID='" + kett.ID + "'").delete();
                            ConnectionManager.Context.table("Task").where("ProjectID='" + kett.ID + "'").delete();
                            ConnectionManager.Context.table("ProjectAndStep").where("StepID in (select ID from Step where ProjectID = '" + kett.ID + "')").delete();
                            ConnectionManager.Context.table("Step").where("ProjectID = '" + kett.ID + "'").delete();
                            ConnectionManager.Context.table("MoneyAndYear").where("ProjectID='" + kett.ID + "'").delete();
                            ConnectionManager.Context.table("MoneyAndType").where("ProjectID='" + kett.ID + "'").delete();

                            //UpdateKeTiList();
                            MainForm.Instance.RefreshEditor();
                        }
                        #endregion
                    }
                    else if (e.ColumnIndex == 5)
                    {
                        UnitExtSelectForm usf = new UnitExtSelectForm(kett.UnitID);
                        if (usf.ShowDialog() == DialogResult.OK)
                        {
                            if (usf.SelectedUnitExt != null)
                            {
                                dgvDetail.Rows[e.RowIndex].Cells[5].Value = usf.SelectedUnitExt.UnitBankNo;
                                dgvDetail.Rows[e.RowIndex].Cells[5].Tag = usf.SelectedUnitExt.ID;
                            }
                        }
                    }
                }
                else if (e.ColumnIndex == dgvDetail.Columns.Count - 2)
                {
                    if (MessageBox.Show("真的要删除吗?", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        try
                        {
                            dgvDetail.Rows.RemoveAt(e.RowIndex);
                        }
                        catch (Exception ex)
                        {
                            UpdateKeTiList();
                        }
                    }
                }
                else if (e.ColumnIndex == 5)
                {
                    UnitExtSelectForm usf = new UnitExtSelectForm(string.Empty);
                    if (usf.ShowDialog() == DialogResult.OK)
                    {
                        if (usf.SelectedUnitExt != null)
                        {
                            dgvDetail.Rows[e.RowIndex].Cells[5].Value = usf.SelectedUnitExt.UnitBankNo;
                            dgvDetail.Rows[e.RowIndex].Cells[5].Tag = usf.SelectedUnitExt.ID;
                        }
                    }
                }
            }
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
            ((KryptonDataGridView)sender)[((KryptonDataGridView)sender).Columns.Count - 1, e.RowIndex].Value = global::ProjectReporter.Properties.Resources.exclamation_16;
            ((KryptonDataGridView)sender)[((KryptonDataGridView)sender).Columns.Count - 2, e.RowIndex].Value = global::ProjectReporter.Properties.Resources.DELETE_28;
        }

        public override void OnSaveEvent()
        {
            base.OnSaveEvent();

            if (GetZongZiKetiCount() == 1)
            {
                Project proj = null;
                foreach (DataGridViewRow dgvRow in dgvDetail.Rows)
                {
                    Person personObj = null;

                    if (dgvRow.Tag == null)
                    {
                        //新行
                        proj = new Project();
                    }
                    else
                    {
                        //已存在数据
                        proj = (Project)dgvRow.Tag;
                    }

                    if (dgvRow.Cells[2].Value == null)
                    {
                        break;
                    }

                    if (dgvRow.Cells[1].Value == null)
                    {
                        MessageBox.Show("对不起,请输入课题名称!");
                        return;
                    }

                    if (dgvRow.Cells[3].Value == null)
                    {
                        MessageBox.Show("对不起,请选择负责人");
                        return;
                    }

                    if (dgvRow.Cells[4].Value == null)
                    {
                        MessageBox.Show("对不起,请输入承担单位名称!");
                        return;
                    }
                    if (dgvRow.Cells[5].Tag == null)
                    {
                        MessageBox.Show("对不起,请选择承担单位开户帐号!");
                        return;
                    }

                    //查找负责人
                    if (PersonDict != null)
                    {
                        if (PersonDict.ContainsKey(dgvRow.Cells[3].Value.ToString()))
                        {
                            personObj = PersonDict[dgvRow.Cells[3].Value.ToString()];
                        }
                    }

                    if (personObj == null)
                    {
                        MessageBox.Show("对不起,请选择负责人!");
                        return;
                    }

                    //课题部分
                    proj.Name = dgvRow.Cells[1].Value.ToString();
                    proj.SecretLevel = dgvRow.Cells[2].Value.ToString();
                    proj.Type = "课题";
                    proj.ParentID = MainForm.Instance.ProjectObj.ID;
                    proj.UnitID = dgvRow.Cells[5].Tag.ToString();
                    proj.Type2 = dgvRow.Cells[7].Value != null ? (((bool)dgvRow.Cells[7].Value) == true ? "总体课题" : "非总体课题") : "非总体课题";

                    //创建课题单位
                    BuildUnitRecord(proj.UnitID, dgvRow.Cells[4].Value.ToString(), "未知...");

                    //添加或更新课题数据
                    if (string.IsNullOrEmpty(proj.ID))
                    {
                        //新行
                        proj.ID = Guid.NewGuid().ToString();
                        proj.copyTo(ConnectionManager.Context.table("Project")).insert();
                    }
                    else
                    {
                        //更新
                        proj.copyTo(ConnectionManager.Context.table("Project")).where("ID='" + proj.ID + "'").update();
                    }

                    //任务分工部分
                    Task task = ConnectionManager.Context.table("Task").where("ProjectID='" + proj.ID + "' and Role = '负责人'").select("*").getItem<Task>(new Task());
                    if (task == null || string.IsNullOrEmpty(task.ID))
                    {
                        //新行
                        task = new Task();
                        task.ProjectID = proj.ID;
                    }

                    task.PersonID = personObj.ID;
                    task.IDCard = personObj.IDCard;
                    task.Role = "负责人";
                    task.Type = "课题";
                    task.Content = dgvRow.Cells[6].Value != null ? dgvRow.Cells[6].Value.ToString() : string.Empty;
                    task.TotalTime = 0;

                    if (string.IsNullOrEmpty(task.ID))
                    {
                        task.ID = Guid.NewGuid().ToString();
                        task.copyTo(ConnectionManager.Context.table("Task")).insert();
                    }
                    else
                    {
                        task.copyTo(ConnectionManager.Context.table("Task")).where("ID='" + task.ID + "'").update();
                    }
                }

                //同步阶段数据
                SyncStepList();

                //更新课题列表
                UpdateKeTiList();
            }
            else
            {
                MessageBox.Show("对不起,必须并且只能有一个总体课题!");
            }
        }

        public override void ClearView()
        {
            base.ClearView();

            dgvDetail.Rows.Clear();
        }

        public override void RefreshView()
        {
            base.RefreshView();

            //显示负责人
            UpdatePersonList();

            //显示负责单位
            UpdateUnitList();

            //课题列表
            UpdateKeTiList();
        }

        public List<Person> PersonList { get; set; }

        public List<UnitExt> UnitList { get; set; }

        public List<Project> KeTiList { get; set; }

        protected Dictionary<string, Person> PersonDict = new Dictionary<string, Person>();

        public override bool IsInputCompleted()
        {
            if (dgvDetail.Rows.Count == 0)
            {
                MessageBox.Show("对不起,请输入课题信息!");
            }

            return dgvDetail.Rows.Count >= 1;
        }

        /// <summary>
        /// 同步一下阶段信息的修改
        /// </summary>
        private void SyncStepList()
        {
            foreach (BaseEditor be in MainForm.Instance.EditorMaps.Values)
            {
                if (be is JieDuanHuaFenEditor)
                {
                    be.RefreshView();
                    be.OnSaveEvent();
                    break;
                }
            }
        }

        /// <summary>
        /// 查询总体课题数量
        /// </summary>
        /// <returns></returns>
        private int GetZongZiKetiCount()
        {
            int result = 0;
            foreach (DataGridViewRow dgvRow in dgvDetail.Rows)
            {
                if (dgvRow.Cells[7].Value != null && ((bool)dgvRow.Cells[7].Value) == true)
                {
                    result += 1;
                }
            }
            return result;
        }

        public void BuildUnitRecord(string unitId, string unitName, string unitAddress)
        {
            ConnectionManager.Context.table("Unit").where("ID='" + unitId + "'").delete();

            Unit newUnit = new Unit();
            newUnit.ID = unitId;
            newUnit.UnitName = unitName;
            newUnit.FlagName = unitName;
            newUnit.NormalName = unitName;
            newUnit.ContactName = "未知";
            newUnit.Telephone = "未知";
            newUnit.Address = unitAddress;
            newUnit.UnitType = "课题单位";
            newUnit.SecretQualification = "未知";
            newUnit.copyTo(ConnectionManager.Context.table("Unit")).insert();
        }
    }
}