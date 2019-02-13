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

namespace ProjectReporter.Forms
{
    public partial class UnitAndUnitExtSelectForm : Form
    {
        public Unit SelectedUnit { get; private set; }

        public UnitAndUnitExtSelectForm(string unitID)
        {
            InitializeComponent();

            UpdateUnitList();

            lueUnitList.EditValue = unitID;
        }

        private void UpdateUnitList()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("ID", typeof(string));
            dt.Columns.Add("UnitName", typeof(string));
            dt.Columns.Add("UnitType", typeof(string));
            dt.Columns.Add("UnitBankUser", typeof(string));
            dt.Columns.Add("UnitBankName", typeof(string));
            dt.Columns.Add("UnitBankNo", typeof(string));
            dt.Columns.Add("FlagName", typeof(string));
            dt.Columns.Add("NormalName", typeof(string));
            dt.Columns.Add("Address", typeof(string));
            dt.Columns.Add("ContactName", typeof(string));
            dt.Columns.Add("Telphone", typeof(string));
            dt.Columns.Add("IsUserAdded", typeof(bool));
            dt.Columns.Add("Secret", typeof(string));

            List<Unit> list = ConnectionManager.Context.table("Unit").select("*").getList<Unit>(new Unit());
            List<UnitExt> extList = ConnectionManager.Context.table("UnitExt").select("*").getList<UnitExt>(new UnitExt());
            if (list != null && extList != null)
            {
                int index = 0;

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

                            dt.Rows.Add(cells.ToArray());
                        }
                    }
                }
            }

            lueUnitList.Properties.DataSource = dt;
            lueUnitList.Properties.DisplayMember = "UnitName";
            lueUnitList.Properties.ValueMember = "UnitBankNo";
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (lueUnitList.EditValue == null)
            {
                btnCancel.PerformClick();
                return;
            }

            SelectedUnit = ConnectionManager.Context.table("Unit").where("ID='" + lueUnitList.EditValue + "'").select("*").getItem<Unit>(new Unit());

            DialogResult = DialogResult.OK;
        }
    }
}