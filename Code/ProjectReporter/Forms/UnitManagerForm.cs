using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ProjectReporter.DB.Entitys;
using ProjectReporter.DB;
using ComponentFactory.Krypton.Toolkit;
using ProjectReporter.Utility;

namespace ProjectReporter.Forms
{
    public partial class UnitManagerForm : Form
    {
        public UnitManagerForm()
        {
            InitializeComponent();

            ((KryptonDataGridViewComboBoxColumn)dgvDetail.Columns[7]).Items.Add("无");
            ((KryptonDataGridViewComboBoxColumn)dgvDetail.Columns[7]).Items.Add("一级");
            ((KryptonDataGridViewComboBoxColumn)dgvDetail.Columns[7]).Items.Add("二级");
            ((KryptonDataGridViewComboBoxColumn)dgvDetail.Columns[7]).Items.Add("三级");
        }

        private void UnitManagerForm_Load(object sender, EventArgs e)
        {
            UpdateList();
        }

        private void UpdateList()
        {
            List<Unit> list = ConnectionManager.Context.table("Unit").select("*").getList<Unit>(new Unit());
            if (list != null)
            {
                int index = 0;
                dgvDetail.Rows.Clear();
                dgvDetail[dgvDetail.Columns.Count - 1, 0].Value = ProjectReporter.Properties.Resources.DELETE_28;
                foreach (Unit u in list)
                {
                    index++;
                    List<string> cells = new List<string>();
                    cells.Add(index + "");
                    cells.Add(u.UnitName);
                    cells.Add(u.FlagName);
                    cells.Add(u.NormalName);
                    cells.Add(u.Address);
                    cells.Add(u.ContactName);
                    cells.Add(u.Telephone);
                    cells.Add(u.SecretQualification);

                    int rowindex = dgvDetail.Rows.Add(cells.ToArray());
                    dgvDetail.Rows[rowindex].Tag = u;
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow dgvRow in dgvDetail.Rows)
            {
                Unit uu = null;
                if (dgvRow.Tag == null)
                {
                    //新建
                    uu = new Unit();
                }
                else
                {
                    //修改
                    uu = (Unit)dgvRow.Tag;
                }

                if (IsNotSave(dgvRow))
                {
                    continue;
                }

                if (IsErrorData(dgvRow))
                {
                    return;
                }

                uu.UnitName = dgvRow.Cells[1].Value.ToString();
                uu.FlagName = dgvRow.Cells[2].Value.ToString();
                uu.NormalName = dgvRow.Cells[3].Value.ToString();
                uu.Address = dgvRow.Cells[4].Value.ToString();
                uu.ContactName = dgvRow.Cells[5].Value.ToString();
                uu.Telephone = dgvRow.Cells[6].Value.ToString();
                uu.SecretQualification = dgvRow.Cells[7].Value.ToString();

                if (string.IsNullOrEmpty(uu.ID))
                {
                    uu.ID = Guid.NewGuid().ToString();
                    uu.copyTo(ConnectionManager.Context.table("Unit")).insert();
                }
                else
                {
                    uu.copyTo(ConnectionManager.Context.table("Unit")).where("ID='" + uu.ID + "'").update();
                }
            }

            UpdateList();
            MessageBox.Show("保存完成");
            Close();
        }

        private bool IsErrorData(DataGridViewRow dgvRow)
        {
            if (dgvRow.Cells[1].Value == null)
            {
                MessageBox.Show("对不起,请输入单位名称!");
                return true;
            }
            if (dgvRow.Cells[2].Value == null)
            {
                MessageBox.Show("对不起,请输入公章名称!");
                return true;
            }
            if (dgvRow.Cells[3].Value == null)
            {
                MessageBox.Show("对不起,请输入常用名称!");
                return true;
            }
            if (dgvRow.Cells[4].Value == null)
            {
                MessageBox.Show("对不起,请输入通信地址!");
                return true;
            }
            if (dgvRow.Cells[5].Value == null)
            {
                MessageBox.Show("对不起,请输入联系人!");
                return true;
            }
            if (dgvRow.Cells[6].Value == null)
            {
                MessageBox.Show("对不起,请输入联系电话!");
                return true;
            }
            if (dgvRow.Cells[7].Value == null)
            {
                MessageBox.Show("对不起,请输入保密资质!");
                return true;
            }
            if (!FormatCheckTool.IsTelephone(dgvRow.Cells[6].Value.ToString()))
            {
                MessageBox.Show("对不起,请输入正确的联系电话!");
                return true;
            }

            return false;
        }

        private bool IsNotSave(DataGridViewRow dgvRow)
        {
            int emptyCount = 0;
            if (dgvRow.Cells[1].Value == null)
            {
                emptyCount++;
            }
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
            if (dgvRow.Cells[6].Value == null)
            {
                emptyCount++;
            }

            return emptyCount >= 6;
        }

        private void dgvDetail_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvDetail.Rows.Count > e.RowIndex)
            {
                if (e.ColumnIndex == dgvDetail.Columns.Count - 1)
                {
                    if (dgvDetail.Rows[e.RowIndex].Tag != null)
                    {
                        Unit uu = (Unit)dgvDetail.Rows[e.RowIndex].Tag;

                        long pcount = ConnectionManager.Context.table("Project").where("UnitID='" + uu.ID + "'").select("count(*)").getValue<long>(0);
                        long rcount = ConnectionManager.Context.table("Person").where("UnitID='" + uu.ID + "'").select("count(*)").getValue<long>(0);

                        if (pcount <= 0 && rcount <= 0)
                        {
                            if (MessageBox.Show("真的要删除吗?", "提示", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                            {
                                try
                                {
                                    ConnectionManager.Context.table("Unit").where("ID='" + uu.ID + "'").delete();
                                }
                                catch (Exception ex) { }

                                UpdateList();
                            }
                        }
                        else
                        {
                            MessageBox.Show("对不起,这个单位已被指派,不能删除!");
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

        private void dgvDetail_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            dgvDetail[dgvDetail.Columns.Count - 1, e.RowIndex].Value = ProjectReporter.Properties.Resources.DELETE_28;
        }

        private void dgvDetail_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }
    }
}