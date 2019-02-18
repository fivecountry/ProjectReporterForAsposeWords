using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;
using ProjectReporter.DB.Services;
using ProjectReporter.DB.Entitys;

namespace ProjectReporter.Forms
{
    public partial class NewUnitForm : KryptonForm
    {
        private UnitExtService _unitInforService = new UnitExtService();
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
                if (string.IsNullOrEmpty(txtUnitType.Text))
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

                UnitExt unitInfo = new UnitExt();
                unitInfo.UnitName = txtUnitName.Text;
                unitInfo.UnitType = txtUnitType.Text;
                unitInfo.UnitBankUser = txtUnitBankUser.Text;
                unitInfo.UnitBankName = txtUnitBankName.Text;
                unitInfo.UnitBankNo = txtUnitBankNo.Text;
                unitInfo.IsUserAdded = 1;

                _unitInforService.UpdateUnitInfors(new List<UnitExt>(new UnitExt[] { unitInfo }));

                DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("对不起，密码错误！");
            }
            
        }
    }
}