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
    public partial class NewUnitForm : Form
    {
        public NewUnitForm()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (txtPassword.Text == DateTime.Now.Year.ToString())
            {
                if (string.IsNullOrEmpty(txtUnitName.Text))
                {
                    MessageBox.Show("请输入单位名称！");
                    return;
                }
                if (string.IsNullOrEmpty(cbxUnitType.Text))
                {
                    MessageBox.Show("请输入单位类型！");
                    return;
                }
                if (string.IsNullOrEmpty(txtUnitBankUser.Text))
                {
                    MessageBox.Show("请输入账号名称！");
                    return;
                }
                if (string.IsNullOrEmpty(txtUnitBankName.Text))
                {
                    MessageBox.Show("请输入开户行名称！");
                    return;
                }
                if (string.IsNullOrEmpty(txtUnitBankNo.Text))
                {
                    MessageBox.Show("请输入账号！");
                    return;
                }

                long existCount = ConnectionManager.Context.table("UnitExt").where("ID='" + txtUnitBankNo.Text + "'").select("count(*)").getValue<long>(0);
                if (existCount >= 1)
                {
                    MessageBox.Show("账号已存在,请重新输入！");
                    return;
                }

                UnitExt unitExt = new UnitExt();
                unitExt.UnitName = txtUnitName.Text;
                unitExt.UnitType = cbxUnitType.Text;
                unitExt.UnitBankUser = txtUnitBankUser.Text;
                unitExt.UnitBankName = txtUnitBankName.Text;
                unitExt.UnitBankNo = txtUnitBankNo.Text;
                unitExt.IsUserAdded = 1;
                unitExt.ID = unitExt.UnitBankNo;
                unitExt.copyTo(ConnectionManager.Context.table("UnitExt")).insert();

                Unit unitInf = new Unit();
                unitInf.ID = unitExt.ID;
                unitInf.UnitName = txtUnitName.Text;
                unitInf.FlagName = txtFlagName.Text;
                unitInf.NormalName = txtNormalName.Text;
                unitInf.Address = txtAddress.Text;
                unitInf.ContactName = txtContactName.Text;
                unitInf.Telephone = txtTelephone.Text;
                unitInf.SecretQualification = cbxSecretQualification.Text;
                unitInf.copyTo(ConnectionManager.Context.table("Unit")).insert();                 

                DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("对不起，密码错误！");
            }
        }
    }
}