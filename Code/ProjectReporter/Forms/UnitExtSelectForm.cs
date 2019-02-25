using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;
using DevExpress.XtraGrid.Columns;
using ProjectReporter.DB.Services;
using ProjectReporter.DB.Entitys;
using ProjectReporter.Properties;

namespace ProjectReporter.Forms
{
    public partial class UnitExtSelectForm : KryptonForm
    {
        UnitExtService _unitInforService = new UnitExtService();

        public UnitExt SelectedUnitExt { get; private set; }

        public UnitExtSelectForm(string unitID)
        {
            InitializeComponent();

            ((DataGridViewImageColumn)dgvDetail.Columns[dgvDetail.Columns.Count - 1]).Image = Resources.DELETE_28;
            UpdateUnitList();

            //显示选定项
            leSearchList.EditValue = unitID;
        }

        public UnitExtSelectForm() : this(string.Empty) { }

        private void UpdateUnitList()
        {
            dgvDetail.Rows.Clear();
            var unitList = _unitInforService.GetUnitInforList();

            leSearchList.Properties.DataSource = unitList;
            leSearchList.Properties.DisplayMember = "UnitBankNo";
            leSearchList.Properties.ValueMember = "ID";

            int rrIndex = 0;
            foreach (UnitExt unit in unitList)
            {
                rrIndex++;
                List<object> cells = new List<object>();
                cells.Add(rrIndex);
                cells.Add(unit.UnitName);
                cells.Add(unit.UnitType);
                cells.Add(unit.UnitBankUser);
                cells.Add(unit.UnitBankName);
                cells.Add(unit.UnitBankNo);
                cells.Add(unit.IsUserAdded >= 1 ? true : false);

                int rIndex = dgvDetail.Rows.Add(cells.ToArray());
                dgvDetail.Rows[rIndex].Tag = unit;
            }
        }

        private void UpdateUnitList(string[] idList)
        {
            dgvDetail.Rows.Clear();
            var unitList = _unitInforService.GetUnitInforList(idList);
            int rrIndex = 0;
            foreach (UnitExt unit in unitList)
            {
                rrIndex++;
                List<object> cells = new List<object>();
                cells.Add(rrIndex);
                cells.Add(unit.UnitName);
                cells.Add(unit.UnitType);
                cells.Add(unit.UnitBankUser);
                cells.Add(unit.UnitBankName);
                cells.Add(unit.UnitBankNo);
                cells.Add(unit.IsUserAdded >= 1 ? true : false);

                int rIndex = dgvDetail.Rows.Add(cells.ToArray());
                dgvDetail.Rows[rIndex].Tag = unit;
            }
        }

        private void dgvDetail_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvDetail.Columns.Count - 1)
            {
                if (dgvDetail.Rows[e.RowIndex].Tag != null)
                {
                    UnitExt uii = (UnitExt)dgvDetail.Rows[e.RowIndex].Tag;

                    if (uii.IsUserAdded == 0)
                    {
                        MessageBox.Show("对不起，只能删除用户添加的数据！");
                    }
                    else
                    {
                        if (MessageBox.Show("真的要删除吗？", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            _unitInforService.DeleteUnitInfors(new List<string>(new string[] { uii.ID }));
                            UpdateUnitList();
                        }
                    }                    
                }
                else
                {
                    if (dgvDetail.Rows.Count > e.RowIndex)
                    {
                        if (MessageBox.Show("真的要删除吗？", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            dgvDetail.Rows.RemoveAt(e.RowIndex);
                        }
                    }
                }
            }
        }

        private void dgvDetail_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvDetail_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            ((DataGridViewImageCell)dgvDetail.Rows[e.RowIndex].Cells[dgvDetail.Columns.Count - 1]).Value = Resources.DELETE_28;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            NewUnitForm addUnit = new NewUnitForm(null);
            if (addUnit.ShowDialog() == DialogResult.OK)
            {
                UpdateUnitList();
            }
        }

        private void leSearchList_EditValueChanged(object sender, EventArgs e)
        {
            if (leSearchList.EditValue != null)
            {
                List<string> idList = new List<string>();
                idList.Add(leSearchList.EditValue.ToString());

                UpdateUnitList(idList.ToArray());
            }
            else
            {
                UpdateUnitList();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvDetail.SelectedRows.Count >= 1)
            {
                UnitExt extObj = (UnitExt)dgvDetail.SelectedRows[0].Tag;
                if (extObj.IsUserAdded == 1)
                {
                    NewUnitForm addUnit = new NewUnitForm(extObj);
                    if (addUnit.ShowDialog() == DialogResult.OK)
                    {
                        UpdateUnitList();
                    }
                }
                else
                {
                    MessageBox.Show("对不起，只能编辑用户自定义的单位！");
                }
            }
        }

        private void dgvDetail_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvDetail.SelectedRows.Count >= 1)
            {
                SelectedUnitExt = (UnitExt)dgvDetail.SelectedRows[0].Tag;
                DialogResult = DialogResult.OK;
            }
        }
    }
}