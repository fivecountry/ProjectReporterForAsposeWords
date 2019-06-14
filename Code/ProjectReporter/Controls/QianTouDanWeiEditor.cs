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
    public partial class QianTouDanWeiEditor : BaseEditor
    {
        public QianTouDanWeiEditor()
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

            UpdateUnitList();
            UpdateQianTouDanWeiList();
        }

        private void UpdateQianTouDanWeiList()
        {
            WhiteDataList = ConnectionManager.Context.table("WhiteList").where("ProjectID='" + MainForm.Instance.ProjectObj.ID + "'").select("*").getList<WhiteList>(new WhiteList());
            dgvDetail.Rows.Clear();
            if (WhiteDataList != null)
            {
                //dgvDetail[dgvDetail.Columns.Count - 1, 0].Value = ProjectReporter.Properties.Resources.DELETE_28;
                int indexx = 0;
                foreach (WhiteList wl in WhiteDataList)
                {
                    Unit unitObj = ConnectionManager.Context.table("Unit").where("ID='" + wl.UnitID + "'").select("*").getItem<Unit>(new Unit());
                    //UnitExt unitExtObj = ConnectionManager.Context.table("UnitExt").where("ID='" + wl.UnitID + "'").select("*").getItem<UnitExt>(new UnitExt());
                    //if (unitObj != null && unitExtObj != null && unitObj.ID != null && unitObj.ID.Length >= 1)
                    if (unitObj != null && unitObj.ID != null && unitObj.ID.Length >= 1)
                    {
                        indexx++;
                        List<object> cells = new List<object>();
                        cells.Add(indexx + "");
                        //cells.Add(unitExtObj.UnitBankNo);
                        cells.Add(string.Empty);
                        cells.Add(unitObj.UnitName);
                        cells.Add(unitObj.Address);
                        cells.Add(unitObj.ContactName);
                        cells.Add(unitObj.Telephone);

                        int rowIndex = dgvDetail.Rows.Add(cells.ToArray());
                        dgvDetail.Rows[rowIndex].Tag = wl;

                        //dgvDetail.Rows[rowIndex].Cells[1].Tag = unitExtObj.ID;
                        dgvDetail.Rows[rowIndex].Cells[1].Tag = unitObj.ID;
                    }
                }
            }
        }

        public override void OnSaveEvent()
        {
            base.OnSaveEvent();

            //foreach (DataGridViewRow dgvRow in dgvDetail.Rows)
            //{
            //    WhiteList wlObj = null;
            //    if (dgvRow.Tag == null)
            //    {
            //        wlObj = new WhiteList();
            //        wlObj.ProjectID = MainForm.Instance.ProjectObj.ID;
            //    }
            //    else
            //    {
            //        wlObj = (WhiteList)dgvRow.Tag;
            //    }

            //    if (dgvRow.Cells[1].Value == null || dgvRow.Cells[2].Value == null || dgvRow.Cells[3].Value == null || dgvRow.Cells[4].Value == null || dgvRow.Cells[5].Value == null)
            //    {
            //        continue;
            //    }

            //    if (dgvRow.Cells[1].Tag == null)
            //    {
            //        continue;
            //    }

            //    wlObj.UnitID = dgvRow.Cells[1].Tag.ToString();

            //    //创建单位信息
            //    ConnectionManager.Context.table("Unit").where("ID='" + wlObj.UnitID + "'").delete();
            //    Unit newUnit = new Unit();
            //    newUnit.ID = wlObj.UnitID;
            //    newUnit.UnitName = dgvRow.Cells[2].Value.ToString();
            //    newUnit.FlagName = dgvRow.Cells[2].Value.ToString();
            //    newUnit.NormalName = dgvRow.Cells[2].Value.ToString();
            //    newUnit.ContactName = dgvRow.Cells[4].Value.ToString();
            //    newUnit.Telephone = dgvRow.Cells[5].Value.ToString();
            //    newUnit.Address = dgvRow.Cells[3].Value.ToString();
            //    newUnit.UnitType = "候选单位";
            //    newUnit.SecretQualification = "未知";
            //    newUnit.copyTo(ConnectionManager.Context.table("Unit")).insert();

            //    if (string.IsNullOrEmpty(wlObj.ID))
            //    {
            //        //insert
            //        wlObj.ID = Guid.NewGuid().ToString();
            //        wlObj.copyTo(ConnectionManager.Context.table("WhiteList")).insert();
            //    }
            //    else
            //    {
            //        //update
            //        wlObj.copyTo(ConnectionManager.Context.table("WhiteList")).where("ID='" + wlObj.ID + "'").update();
            //    }
            //}

            //UpdateQianTouDanWeiList();
        }

        private void UpdateUnitList()
        {
            List<UnitExt> unitList = ConnectionManager.Context.table("UnitExt").select("*").getList<UnitExt>(new UnitExt());
            if (unitList != null)
            {
                ////((KryptonDataGridViewComboBoxColumn)dgvDetail.Columns[1]).Items.Clear();
                //UnitDict.Clear();
                //foreach (UnitExt u in unitList)
                //{
                //    //((KryptonDataGridViewComboBoxColumn)dgvDetail.Columns[1]).Items.Add(u.UnitName);
                //    UnitDict.Add(u.UnitName, u);
                //}
            }
        }

        //public Dictionary<string, UnitExt> UnitDict = new Dictionary<string, UnitExt>();

        private void dgvDetail_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //if (dgvDetail.Rows.Count >= 1)
            //{
            //    if (dgvDetail.Rows[e.RowIndex].Tag != null)
            //    {
            //        WhiteList wlObj = (WhiteList)dgvDetail.Rows[e.RowIndex].Tag;
            //        if (e.ColumnIndex == dgvDetail.Columns.Count - 1)
            //        {
            //            if (MessageBox.Show("真的要删除吗?", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
            //            {
            //                ConnectionManager.Context.table("WhiteList").where("ID='" + wlObj.ID + "'").delete();
            //                UpdateQianTouDanWeiList();
            //            }
            //        }
            //        else if (e.ColumnIndex == 1)
            //        {
            //            UnitExtSelectForm usf = new UnitExtSelectForm(wlObj.UnitID);
            //            if (usf.ShowDialog() == DialogResult.OK)
            //            {
            //                if (usf.SelectedUnitExt != null)
            //                {
            //                    dgvDetail.Rows[e.RowIndex].Cells[1].Value = usf.SelectedUnitExt.UnitBankNo;
            //                    dgvDetail.Rows[e.RowIndex].Cells[1].Tag = usf.SelectedUnitExt.ID;
            //                }
            //            }
            //        }
            //    }
            //    else
            //    {
            //        if (e.ColumnIndex == dgvDetail.Columns.Count - 1)
            //        {
            //            if (MessageBox.Show("真的要删除吗?", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
            //            {
            //                try
            //                {
            //                    dgvDetail.Rows.RemoveAt(e.RowIndex);
            //                }
            //                catch (Exception ex)
            //                {
            //                    UpdateQianTouDanWeiList();
            //                }
            //            }
            //        }
            //        else if (e.ColumnIndex == 1)
            //        {
            //            UnitExtSelectForm usf = new UnitExtSelectForm(string.Empty);
            //            if (usf.ShowDialog() == DialogResult.OK)
            //            {
            //                if (usf.SelectedUnitExt != null)
            //                {
            //                    dgvDetail.Rows[e.RowIndex].Cells[1].Value = usf.SelectedUnitExt.UnitBankNo;
            //                    dgvDetail.Rows[e.RowIndex].Cells[1].Tag = usf.SelectedUnitExt.ID;
            //                }
            //            }
            //        }
            //    }
            //}
        }

        private void dgvDetail_CellParsing(object sender, DataGridViewCellParsingEventArgs e)
        {
            //if (e.ColumnIndex == 1)
            //{
            //    KryptonDataGridViewComboBoxCell comboboxCell = (KryptonDataGridViewComboBoxCell)dgvDetail.Rows[e.RowIndex].Cells[e.ColumnIndex];
            //    if (comboboxCell.EditedFormattedValue != null)
            //    {
            //        string key = comboboxCell.EditedFormattedValue.ToString();

            //        if (UnitDict.ContainsKey(key))
            //        {
            //            Unit unitObj = UnitDict[key];
            //            if (unitObj != null)
            //            {
            //                dgvDetail[2, e.RowIndex].Value = unitObj.Address;
            //                dgvDetail[3, e.RowIndex].Value = unitObj.ContactName;
            //                dgvDetail[4, e.RowIndex].Value = unitObj.Telephone;
            //            }
            //        }
            //    }
            //}
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