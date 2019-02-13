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
    public partial class frmUnitManage : KryptonForm
    {
        UnitExtService _unitInforService = new UnitExtService();

        public frmUnitManage()
        {
            InitializeComponent();

            ((DataGridViewImageColumn)dgvDetail.Columns[dgvDetail.Columns.Count - 1]).Image = Resources.DELETE_28;

            UpdateUnitList();
        }

        private void UpdateUnitList()
        {
            dgvDetail.Rows.Clear();
            var unitList = _unitInforService.GetUnitInforList();

            leSearchList.Properties.DataSource = unitList;
            leSearchList.Properties.DisplayMember = "UnitName";
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            List<UnitExt> _updateList = new List<UnitExt>();
            foreach (DataGridViewRow dgvRow in dgvDetail.Rows)
            {
                if (dgvRow.Cells[1].Value == null || dgvRow.Cells[2].Value == null || dgvRow.Cells[3].Value == null || dgvRow.Cells[4].Value == null || dgvRow.Cells[5].Value == null)
                {
                    continue;
                }

                UnitExt unitInfor = new UnitExt();
                if (dgvRow.Tag != null)
                {
                    unitInfor = (UnitExt)dgvRow.Tag;
                }
                else
                {
                    unitInfor.IsUserAdded = 1;
                }

                unitInfor.UnitName = dgvRow.Cells[1].Value.ToString();
                unitInfor.UnitType = dgvRow.Cells[2].Value.ToString();
                unitInfor.UnitBankUser = dgvRow.Cells[3].Value.ToString();
                unitInfor.UnitBankName = dgvRow.Cells[4].Value.ToString();
                unitInfor.UnitBankNo = dgvRow.Cells[5].Value.ToString();
                
                _updateList.Add(unitInfor);
            }
            _unitInforService.UpdateUnitInfors(_updateList);

            //刷新
            UpdateUnitList();
            MessageBox.Show("保存完成！");
        }

        private void dgvDetail_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            ((DataGridViewImageCell)dgvDetail.Rows[e.RowIndex].Cells[dgvDetail.Columns.Count - 1]).Value = Resources.DELETE_28;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmAddUnit addUnit = new frmAddUnit();
            if (addUnit.ShowDialog() == DialogResult.OK)
            {
                UpdateUnitList();
            }
        }

        private void leSearchList_EditValueChanged(object sender, EventArgs e)
        {
            List<string> idList = new List<string>();
            int[] handleRows = leSearchListView.GetSelectedRows();
            foreach (int rowHandle in handleRows)
            {
                object obj = leSearchListView.GetRowCellValue(rowHandle, "ID");
                if (obj != null)
                {
                    idList.Add(obj.ToString());
                }
            }

            UpdateUnitList(idList.ToArray());
        }
    }
}