using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ProjectReporter.DB;
using ProjectReporter.DB.Entitys;
using ComponentFactory.Krypton.Toolkit;
using ProjectReporter.Utility;

namespace ProjectReporter.Forms
{
    public partial class PersonManagerForm : Form
    {
        public PersonManagerForm()
        {
            InitializeComponent();

            //性别
            ((KryptonDataGridViewComboBoxColumn)dgvDetail.Columns[6]).Items.Add("男");
            ((KryptonDataGridViewComboBoxColumn)dgvDetail.Columns[6]).Items.Add("女");

            //单位
            UpdateListColumnComboboxList();
        }

        private void UpdateListColumnComboboxList()
        {
            UnitList = ConnectionManager.Context.table("Unit").select("*").getList<Unit>(new Unit());
            KryptonDataGridViewComboBoxColumn unitCombobox = (KryptonDataGridViewComboBoxColumn)dgvDetail.Columns[1];
            if (UnitList != null)
            {
                unitCombobox.Items.Clear();
                foreach (Unit u in UnitList)
                {
                    unitCombobox.Items.Add(u.UnitName);
                }
            }
        }

        private void frmPersonManager_Load(object sender, EventArgs e)
        {
            UpdateList();
        }

        /// <summary>
        /// 刷新数据
        /// </summary>
        private void UpdateList()
        {
            if (dgvDetail.Rows.Count > 0)
            {
                dgvDetail[dgvDetail.Columns.Count - 1, 0].Value = ProjectReporter.Properties.Resources.DELETE_28;
            }

            dgvDetail.Rows.Clear();
            List<Person> list = ConnectionManager.Context.table("Person").select("*").getList<Person>(new Person());
            if (list != null)
            {
                int index = 0;
                foreach (Person p in list)
                {
                    string UnitName = string.Empty;
                    UnitName = ConnectionManager.Context.table("Unit").where("ID='" + p.UnitID + "'").select("UnitName").getValue<string>(string.Empty);

                    index++;
                    List<object> cells = new List<object>();
                    cells.Add(index);
                    cells.Add(UnitName);
                    cells.Add(p.Name);
                    cells.Add(p.IDCard);
                    cells.Add(p.Job);
                    cells.Add(p.Specialty);
                    cells.Add(p.Sex);
                    cells.Add(p.Birthday);
                    cells.Add(p.Telephone);
                    cells.Add(p.MobilePhone);
                    cells.Add(p.Address);

                    int rowIndex = dgvDetail.Rows.Add(cells.ToArray());
                    dgvDetail.Rows[rowIndex].Tag = p;
                }
            }
        }

        private void dgvDetail_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            dgvDetail[dgvDetail.Columns.Count - 1, e.RowIndex].Value = ProjectReporter.Properties.Resources.DELETE_28;
        }

        private void dgvDetail_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvDetail.Rows.Count > e.RowIndex)
            {
                if (e.ColumnIndex == dgvDetail.Columns.Count - 1)
                {
                    if (dgvDetail.Rows[e.RowIndex].Tag != null)
                    {
                        Person p = (Person)dgvDetail.Rows[e.RowIndex].Tag;
                        long personCount = ConnectionManager.Context.table("Task").where("PersonID = '" + p.ID + "'").select("count(*)").getValue<long>(0);

                        if (personCount <= 0)
                        {
                            //删除
                            if (MessageBox.Show("真的要删除吗?", "提示", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                            {
                                try
                                {

                                    ConnectionManager.Context.table("Person").where("ID='" + p.ID + "'").delete();
                                }
                                catch (Exception ex) { }

                                UpdateList();
                            }
                        }
                        else
                        {
                            MessageBox.Show("对不起,这个人不能删除,因为正在使用!");
                        }
                    }
                    else
                    {
                        if (MessageBox.Show("真的要删除吗?", "提示", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                        {
                            dgvDetail.Rows.RemoveAt(e.RowIndex);
                        }
                    }
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow dgvRow in dgvDetail.Rows)
            {
                try
                {
                    Person p = null;
                    if (dgvRow.Tag == null)
                    {
                        //新对象
                        p = new Person();
                    }
                    else
                    {
                        //已存在记录
                        p = (Person)dgvRow.Tag;
                    }

                    if (IsNotSave(dgvRow))
                    {
                        continue;
                    }

                    if (IsErrorData(dgvRow))
                    {
                        return;
                    }

                    p.UnitID = GetUnitID(((KryptonDataGridViewComboBoxCell)dgvRow.Cells[1]).Value.ToString());
                    p.Name = dgvRow.Cells[2].Value.ToString();
                    p.IDCard = dgvRow.Cells[3].Value.ToString();
                    p.Job = dgvRow.Cells[4].Value.ToString();
                    p.Specialty = dgvRow.Cells[5].Value.ToString();
                    p.Sex = ((KryptonDataGridViewComboBoxCell)dgvRow.Cells[6]).Value.ToString();
                    p.Birthday = DateTime.Parse(((KryptonDataGridViewDateTimePickerCell)dgvRow.Cells[7]).Value.ToString());
                    p.Telephone = dgvRow.Cells[8].Value.ToString();
                    p.MobilePhone = dgvRow.Cells[9].Value.ToString();
                    p.Address = dgvRow.Cells[10].Value.ToString();

                    if (string.IsNullOrEmpty(p.ID))
                    {
                        p.ID = Guid.NewGuid().ToString();
                        p.copyTo(ConnectionManager.Context.table("Person")).insert();
                    }
                    else
                    {
                        p.copyTo(ConnectionManager.Context.table("Person")).where("ID='" + p.ID + "'").update();
                    }
                }
                catch (Exception ex) { }
            }

            //更新列表
            UpdateList();

            MessageBox.Show("保存完成");
            Close();
        }

        private string GetUnitID(string unitName)
        {
            if (string.IsNullOrEmpty(unitName) || UnitList== null)
            {
                return string.Empty;
            }
            else
            {
                foreach (Unit u in UnitList)
                {
                    if (u.UnitName == unitName)
                    {
                        return u.ID;
                    }
                }

                return string.Empty;
            }
        }

        private bool IsErrorData(DataGridViewRow dgvRow)
        {
            if (((KryptonDataGridViewComboBoxCell)dgvRow.Cells[1]).Value == null)
            {
                MessageBox.Show("对不起,请选择所属单位!");
                return true;
            }
            if (((KryptonDataGridViewComboBoxCell)dgvRow.Cells[6]).Value == null)
            {
                MessageBox.Show("对不起,请选择性别!");
                return true;
            }
            
            if (dgvRow.Cells[2].Value == null)
            {
                MessageBox.Show("对不起,请输入姓名!");
                return true;
            }

            if (dgvRow.Cells[3].Value == null)
            {
                MessageBox.Show("对不起,请输入身份证号!");
                return true;
            }

            if (dgvRow.Cells[4].Value == null)
            {
                MessageBox.Show("对不起,请输入职务!");
                return true;
            }

            if (dgvRow.Cells[5].Value == null)
            {
                MessageBox.Show("对不起,请输入专业!");
                return true;
            }

            if (dgvRow.Cells[8].Value == null)
            {
                MessageBox.Show("对不起,请输入座机号码!");
                return true;
            }

            if (dgvRow.Cells[9].Value == null)
            {
                MessageBox.Show("对不起,请输入手机号码!");
                return true;
            }

            if (dgvRow.Cells[10].Value == null)
            {
                MessageBox.Show("对不起,请输入通信地址!");
                return true;
            }

            if (!FormatCheckTool.IsIDcard(dgvRow.Cells[3].Value.ToString()))
            {
                MessageBox.Show("对不起,请输入正确的身份证号!");
                return true;
            }

            if (!FormatCheckTool.IsTelephone(dgvRow.Cells[8].Value.ToString()))
            {
                MessageBox.Show("对不起,请输入正确的座机号!");
                return true;
            }

            if (!FormatCheckTool.IsHandset(dgvRow.Cells[9].Value.ToString()))
            {
                MessageBox.Show("对不起,请输入正确的手机号!");
                return true;
            }
            return false;
        }

        private bool IsNotSave(DataGridViewRow dgvRow)
        {
            int emptyCount = 0;

            if (dgvRow.Cells[2].Value == null)
            {
                emptyCount++;
            }

            if (dgvRow.Cells[3].Value == null)
            {
                emptyCount++;
            }

            if (dgvRow.Cells[4].Value == null)
            {
                emptyCount++;
            }

            if (dgvRow.Cells[5].Value == null)
            {
                emptyCount++;
            }

            if (dgvRow.Cells[8].Value == null)
            {
                emptyCount++;
            }

            if (dgvRow.Cells[9].Value == null)
            {
                emptyCount++;
            }

            if (dgvRow.Cells[10].Value == null)
            {
                emptyCount++;
            }

            return emptyCount >= 7;
        }

        private void dgvDetail_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

        public List<Unit> UnitList { get; set; }

        private void PersonManagerForm_Activated(object sender, EventArgs e)
        {
            UpdateListColumnComboboxList();
        }
    }

    public class ComboboxItem
    {
        public ComboboxItem(string n, object v)
        {
            this.Name = n;
            this.Value = v;
        }

        public string Name { get; set; }

        public object Value { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}