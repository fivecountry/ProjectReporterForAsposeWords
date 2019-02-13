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
    public partial class NewPersonForm : Form
    {
        public Person PersonObj { get; private set; }

        public NewPersonForm(Person personObj)
        {
            InitializeComponent();

            UpdateUnitList();

            this.PersonObj = personObj;
            if (this.PersonObj != null)
            {
                lueUnitList.EditValue = this.PersonObj.UnitID;
                txtName.Text = PersonObj.Name;
                txtIDCard.Text = PersonObj.IDCard;
                txtJob.Text = PersonObj.Job;
                txtSpecialty.Text = PersonObj.Specialty;
                cbxSex.Text = PersonObj.Sex;
                deBirthday.DateTime = PersonObj.Birthday != null ? PersonObj.Birthday.Value : DateTime.Now;
                txtTelphone.Text = PersonObj.Telephone;
                txtMobilePhone.Text = PersonObj.MobilePhone;
                txtAddress.Text = PersonObj.Address;
            }

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

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (lueUnitList.EditValue == null)
            {
                MessageBox.Show("请选择所属单位！");
                return;
            }
            if (string.IsNullOrEmpty(txtName.Text))
            {
                MessageBox.Show("请输入姓名！");
                return;
            }
            if (string.IsNullOrEmpty(txtIDCard.Text))
            {
                MessageBox.Show("请输入身份证号码！");
                return;
            }
            if (string.IsNullOrEmpty(txtJob.Text))
            {
                MessageBox.Show("请输入职务职称！");
                return;
            }
            if (string.IsNullOrEmpty(txtSpecialty.Text))
            {
                MessageBox.Show("请输入从事专业！");
                return;
            }
            if (string.IsNullOrEmpty(cbxSex.Text))
            {
                MessageBox.Show("请输入性别！");
                return;
            }
            if (deBirthday.DateTime == null)
            {
                MessageBox.Show("请输入生日！");
                return;
            }
            if (string.IsNullOrEmpty(txtTelphone.Text))
            {
                MessageBox.Show("请输入座机！");
                return;
            }
            if (string.IsNullOrEmpty(txtMobilePhone.Text))
            {
                MessageBox.Show("请输入手机！");
                return;
            }
            if (string.IsNullOrEmpty(txtAddress.Text))
            {
                MessageBox.Show("请输入通信地址！");
                return;
            }

            if (PersonObj == null)
            {
                PersonObj = new Person();
            }
            PersonObj.UnitID = lueUnitList.EditValue.ToString();
            PersonObj.Name = txtName.Text;
            PersonObj.IDCard = txtIDCard.Text;
            PersonObj.Job = txtJob.Text;
            PersonObj.Specialty = txtSpecialty.Text;
            PersonObj.Sex = cbxSex.Text;
            PersonObj.Birthday = deBirthday.DateTime;
            PersonObj.Telephone = txtTelphone.Text;
            PersonObj.MobilePhone = txtMobilePhone.Text;
            PersonObj.Address = txtAddress.Text;

            if (string.IsNullOrEmpty(PersonObj.ID))
            {
                PersonObj.ID = Guid.NewGuid().ToString();
                PersonObj.copyTo(ConnectionManager.Context.table("Person")).insert();
            }
            else
            {
                PersonObj.copyTo(ConnectionManager.Context.table("Person")).where("ID='" + PersonObj.ID + "'").update();
            }

            DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}