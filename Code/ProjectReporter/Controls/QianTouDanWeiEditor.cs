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
    public partial class QianTouDanWeiEditor : BaseEditor
    {
        public QianTouDanWeiEditor()
        {
            InitializeComponent();

            dgvDetail[dgvDetail.Columns.Count - 1, 0].Value = global::ProjectReporter.Properties.Resources.DELETE_28;
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

            UpdateUnitList();
            UpdateQianTouDanWeiList();
        }

        private void UpdateQianTouDanWeiList()
        {
            WhiteDataList = ConnectionManager.Context.table("WhiteList").where("ProjectID='" + MainForm.Instance.ProjectObj.ID + "'").select("*").getList<WhiteList>(new WhiteList());
            dgvDetail.Rows.Clear();
            if (WhiteDataList != null)
            {
                dgvDetail[dgvDetail.Columns.Count - 1, 0].Value = ProjectReporter.Properties.Resources.DELETE_28;
                int indexx = 0;
                foreach (WhiteList wl in WhiteDataList)
                {
                    Unit unitObj = ConnectionManager.Context.table("Unit").where("ID='" + wl.UnitID + "'").select("*").getItem<Unit>(new Unit());
                    if (unitObj != null && unitObj.ID != null && unitObj.ID.Length >= 1)
                    {
                        indexx++;
                        List<object> cells = new List<object>();
                        cells.Add(indexx + "");
                        cells.Add(unitObj.UnitName);
                        cells.Add(unitObj.Address);
                        cells.Add(unitObj.ContactName);
                        cells.Add(unitObj.Telephone);

                        int rowIndex = dgvDetail.Rows.Add(cells.ToArray());
                        dgvDetail.Rows[rowIndex].Tag = wl;
                    }
                }
            }
        }

        public override void OnSaveEvent()
        {
            base.OnSaveEvent();

            foreach (DataGridViewRow dgvRow in dgvDetail.Rows)
            {
                WhiteList wlObj = null;
                if (dgvRow.Tag == null)
                {
                    wlObj = new WhiteList();
                    wlObj.ProjectID = MainForm.Instance.ProjectObj.ID;
                }
                else
                {
                    wlObj = (WhiteList)dgvRow.Tag;
                }

                if (dgvRow.Cells[1].Value == null || string.IsNullOrEmpty(dgvRow.Cells[1].Value.ToString()))
                {
                    continue;
                }

                if (UnitDict.ContainsKey(dgvRow.Cells[1].Value.ToString()))
                {
                    wlObj.UnitID = UnitDict[dgvRow.Cells[1].Value.ToString()].ID;

                    if (string.IsNullOrEmpty(wlObj.ID))
                    {
                        //insert
                        wlObj.ID = Guid.NewGuid().ToString();
                        wlObj.copyTo(ConnectionManager.Context.table("WhiteList")).insert();
                    }
                    else
                    {
                        //update
                        wlObj.copyTo(ConnectionManager.Context.table("WhiteList")).where("ID='" + wlObj.ID + "'").update();
                    }
                }
            }

            UpdateQianTouDanWeiList();
        }

        private void UpdateUnitList()
        {
            List<Unit> unitList = ConnectionManager.Context.table("Unit").select("*").getList<Unit>(new Unit());
            if (unitList != null)
            {
                ((KryptonDataGridViewComboBoxColumn)dgvDetail.Columns[1]).Items.Clear();
                UnitDict.Clear();
                foreach (Unit u in unitList)
                {
                    ((KryptonDataGridViewComboBoxColumn)dgvDetail.Columns[1]).Items.Add(u.UnitName);
                    UnitDict.Add(u.UnitName, u);
                }
            }
        }

        public Dictionary<string, Unit> UnitDict = new Dictionary<string, Unit>();

        private void dgvDetail_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvDetail.Rows.Count >= 1)
            {
                if (dgvDetail.Rows[e.RowIndex].Tag != null)
                {
                    WhiteList wlObj = (WhiteList)dgvDetail.Rows[e.RowIndex].Tag;
                    if (e.ColumnIndex == dgvDetail.Columns.Count - 1)
                    {
                        if (MessageBox.Show("真的要删除吗?", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            ConnectionManager.Context.table("WhiteList").where("ID='" + wlObj.ID + "'").delete();
                            UpdateQianTouDanWeiList();
                        }
                    }
                }
                else
                {
                    if (e.ColumnIndex == dgvDetail.Columns.Count - 1)
                    {
                        if (MessageBox.Show("真的要删除吗?", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            try
                            {
                                dgvDetail.Rows.RemoveAt(e.RowIndex);
                            }
                            catch (Exception ex)
                            {
                                UpdateQianTouDanWeiList();
                            }
                        }
                    }
                }
            }
        }

        private void dgvDetail_CellParsing(object sender, DataGridViewCellParsingEventArgs e)
        {
            if (e.ColumnIndex == 1)
            {
                KryptonDataGridViewComboBoxCell comboboxCell = (KryptonDataGridViewComboBoxCell)dgvDetail.Rows[e.RowIndex].Cells[e.ColumnIndex];
                if (comboboxCell.EditedFormattedValue != null)
                {
                    string key = comboboxCell.EditedFormattedValue.ToString();

                    if (UnitDict.ContainsKey(key))
                    {
                        Unit unitObj = UnitDict[key];
                        if (unitObj != null)
                        {
                            dgvDetail[2, e.RowIndex].Value = unitObj.Address;
                            dgvDetail[3, e.RowIndex].Value = unitObj.ContactName;
                            dgvDetail[4, e.RowIndex].Value = unitObj.Telephone;
                        }
                    }
                }
            }
        }

        public List<WhiteList> WhiteDataList { get; set; }

        public override bool IsInputCompleted()
        {
            if (dgvDetail.Rows.Count == 0)
            {
                MessageBox.Show("对不起,请选择一个牵头单位!");
            }

            return dgvDetail.Rows.Count >= 1;
        }
    }
}