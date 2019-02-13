using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
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

            ((KryptonDataGridViewComboBoxColumn)dgvDetail.Columns[dgvDetail.Columns.Count - 2]).Items.Add("无");
            ((KryptonDataGridViewComboBoxColumn)dgvDetail.Columns[dgvDetail.Columns.Count - 2]).Items.Add("一级");
            ((KryptonDataGridViewComboBoxColumn)dgvDetail.Columns[dgvDetail.Columns.Count - 2]).Items.Add("二级");
            ((KryptonDataGridViewComboBoxColumn)dgvDetail.Columns[dgvDetail.Columns.Count - 2]).Items.Add("三级");

            ((KryptonDataGridViewComboBoxColumn)dgvDetail.Columns[2]).Items.Add("航天科技");
            ((KryptonDataGridViewComboBoxColumn)dgvDetail.Columns[2]).Items.Add("航空科技");
        }

        private void UnitManagerForm_Load(object sender, EventArgs e)
        {
            UpdateList();
        }

        private void UpdateList()
        {
            List<Unit> list = ConnectionManager.Context.table("Unit").select("*").getList<Unit>(new Unit());
            List<UnitExt> extList = ConnectionManager.Context.table("UnitExt").select("*").getList<UnitExt>(new UnitExt());
            if (list != null && extList != null)
            {
                int index = 0;
                dgvDetail.Rows.Clear();
                //dgvDetail[dgvDetail.Columns.Count - 1, 0].Value = ProjectReporter.Properties.Resources.DELETE_28;

                foreach (UnitExt uee in extList)
                {
                    IEnumerable<Unit> subs = list.Where(d => d.ID == uee.ID);
                    if (subs != null)
                    {
                        List<Unit> unitLi = new List<Unit>(subs);
                        if (unitLi != null && unitLi.Count >= 1)
                        {
                            Unit u = unitLi[0];
                            index++;

                            List<object> cells = new List<object>();
                            cells.Add(index + "");                //序号
                            cells.Add(u.UnitName);                //单位名称

                            cells.Add(uee.UnitType);              //单位类型
                            cells.Add(uee.UnitBankUser);          //开户名称
                            cells.Add(uee.UnitBankName);          //开户行
                            cells.Add(uee.UnitBankNo);            //银行帐号

                            cells.Add(u.FlagName);                //公章名称
                            cells.Add(u.NormalName);              //单位常用名
                            cells.Add(u.Address);                 //通信地址
                            cells.Add(u.ContactName);             //联系人
                            cells.Add(u.Telephone);               //联系电话

                            cells.Add(uee.IsUserAdded == 1 ? true : false);  //用户自定义

                            cells.Add(u.SecretQualification);     //保密资质

                            int rowindex = dgvDetail.Rows.Add(cells.ToArray());
                            dgvDetail.Rows[rowindex].Tag = u;
                        }
                    }
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
                uu.FlagName = dgvRow.Cells[6].Value.ToString();
                uu.NormalName = dgvRow.Cells[7].Value.ToString();
                uu.Address = dgvRow.Cells[8].Value.ToString();
                uu.ContactName = dgvRow.Cells[9].Value.ToString();
                uu.Telephone = dgvRow.Cells[10].Value.ToString();
                uu.SecretQualification = dgvRow.Cells[12].Value.ToString();
                uu.copyTo(ConnectionManager.Context.table("Unit")).where("ID='" + uu.ID + "'").update();                
                
                UnitExt unitExt= ConnectionManager.Context.table("UnitExt").where("ID='" + uu.ID + "'").select("*").getItem<UnitExt>(new UnitExt());
                if (unitExt == null)
                {
                    continue;
                }

                unitExt.UnitName = uu.UnitName;
                unitExt.UnitType = dgvRow.Cells[2].Value.ToString();
                unitExt.UnitBankUser = dgvRow.Cells[3].Value.ToString();
                unitExt.UnitBankName = dgvRow.Cells[4].Value.ToString();
                unitExt.UnitBankNo = dgvRow.Cells[5].Value.ToString();
                unitExt.copyTo(ConnectionManager.Context.table("UnitExt").where("ID='" + uu.ID + "'")).update();
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
                MessageBox.Show("对不起,请选择单位类型!");
                return true;
            }
            if (dgvRow.Cells[3].Value == null)
            {
                MessageBox.Show("对不起,请输入开户名称!");
                return true;
            }
            if (dgvRow.Cells[4].Value == null)
            {
                MessageBox.Show("对不起,请输入开户行!");
                return true;
            }
            if (dgvRow.Cells[5].Value == null)
            {
                MessageBox.Show("对不起,请输入帐号!");
                return true;
            }
            if (dgvRow.Cells[6].Value == null)
            {
                MessageBox.Show("对不起,请输入公章名称!");
                return true;
            }
            if (dgvRow.Cells[7].Value == null)
            {
                MessageBox.Show("对不起,请输入常用名称!");
                return true;
            }
            if (dgvRow.Cells[8].Value == null)
            {
                MessageBox.Show("对不起,请输入通信地址!");
                return true;
            }
            if (dgvRow.Cells[9].Value == null)
            {
                MessageBox.Show("对不起,请输入联系人!");
                return true;
            }
            if (dgvRow.Cells[10].Value == null)
            {
                MessageBox.Show("对不起,请输入联系电话!");
                return true;
            }
            if (dgvRow.Cells[12].Value == null)
            {
                MessageBox.Show("对不起,请输入保密资质!");
                return true;
            }
            if (!FormatCheckTool.IsTelephone(dgvRow.Cells[10].Value.ToString()))
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
            if (dgvRow.Cells[7].Value == null)
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
            if (dgvRow.Cells[11].Value == null)
            {
                emptyCount++;
            }
            if (dgvRow.Cells[12].Value == null)
            {
                emptyCount++;
            }

            return emptyCount >= 10;
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
                                    ConnectionManager.Context.table("UnitExt").where("ID='" + uu.ID + "'").delete();
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

        private void btnNewUnit_Click(object sender, EventArgs e)
        {
            NewUnitForm nuf = new NewUnitForm();
            if (nuf.ShowDialog() == DialogResult.OK)
            {
                UpdateList();
            }
        }
    }
}