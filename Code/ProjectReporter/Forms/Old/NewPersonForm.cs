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
        public UnitExt CurrentUnitExt { get; private set; }

        public NewPersonForm(Person personObj)
        {
            InitializeComponent();

            this.PersonObj = personObj;
            if (this.PersonObj != null)
            {
                CurrentUnitExt = ConnectionManager.Context.table("UnitExt").where("ID='" + this.PersonObj.UnitID + "'").select("*").getItem<UnitExt>(new UnitExt());
                if (CurrentUnitExt != null)
                {
                    btnUnitSelect.Text = CurrentUnitExt.UnitBankNo;
                }

                Unit unitObj = ConnectionManager.Context.table("Unit").where("ID='" + this.PersonObj.UnitID + "'").select("*").getItem<Unit>(new Unit());
                if (unitObj != null)
                {
                    txtUnitName.Text = unitObj.UnitName;
                }

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

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (CurrentUnitExt == null)
            {
                btnUnitSelect.Text = "点击选择开户帐号！";
                MessageBox.Show("请选择所属单位开户帐号！");
                return;
            }
            if (string.IsNullOrEmpty(txtUnitName.Text))
            {
                MessageBox.Show("请输入单位名称！");
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

            PersonObj.UnitID = CurrentUnitExt.ID;
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

            BuildUnitRecord(PersonObj.UnitID, txtUnitName.Text, "未知...");

            DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void btnUnitSelect_Click(object sender, EventArgs e)
        {
            UnitExtSelectForm uesf = new UnitExtSelectForm(PersonObj != null ? PersonObj.UnitID : string.Empty);
            if (uesf.ShowDialog() == DialogResult.OK && uesf.SelectedUnitExt != null)
            {
                btnUnitSelect.Text = uesf.SelectedUnitExt.UnitBankNo;
                CurrentUnitExt = uesf.SelectedUnitExt;
            }
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
            newUnit.UnitType = "人员所属单位";
            newUnit.SecretQualification = "未知";
            newUnit.copyTo(ConnectionManager.Context.table("Unit")).insert();
        }
    }
}