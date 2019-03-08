﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ProjectReporter.DB.Entitys;
using ProjectReporter.DB;
using ProjectReporter.Forms;
using ProjectReporter.DB.Services;
using ComponentFactory.Krypton.Toolkit;

namespace ProjectReporter.Controls
{
    public partial class NewProjectEditor : BaseEditor
    {
        UnitExtService _unitInforService = new UnitExtService();

        public Person ProjectPersonObj { get; private set; }

        public NewProjectEditor()
        {
            InitializeComponent();
            //toCenter();
            cbxSecret.SelectedIndex = 0;
        }

        public void toCenter()
        {
            //if (plMainddd != null)
            //{
            //    plMainddd.Left = (Width - plMainddd.Width) / 2;
            //    plMainddd.Top = (Height - plMainddd.Height) / 2;
            //}
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);

            //toCenter();
        }

        public void LoadProject()
        {
            if (MainForm.Instance.ProjectObj != null)
            {
                txtProjectName.Text = MainForm.Instance.ProjectObj.Name;
                cbxSecret.SelectedItem = MainForm.Instance.ProjectObj.SecretLevel;
                txtTotalTime.Text = MainForm.Instance.ProjectObj.TotalTime + "";
                txtTotalMoney.Text = MainForm.Instance.ProjectObj.TotalMoney + "";
                txtKeyWords.Text = MainForm.Instance.ProjectObj.Keywords;

                Unit unitObj = ConnectionManager.Context.table("Unit").where("ID='" + MainForm.Instance.ProjectObj.UnitID + "'").select("*").getItem<Unit>(new Unit());
                if (unitObj != null)
                {
                    txtUnitName.Text = unitObj.UnitName;
                    //txtFlagName.Text = unitObj.FlagName;
                    txtNormalName.Text = unitObj.NormalName;
                    txtContactName.Text = unitObj.ContactName;
                    txtAddress.Text = unitObj.Address;
                    txtTelephone.Text = unitObj.Telephone;
                }
            }

            UpdateUnitList();
            UpdatePersonList();
        }

        public override void ClearView()
        {
            //cbxPersonList.Items.Clear();
            //leSearchList.Properties.DataSource = null;
            //cbxUnitA.Items.Clear();
            //cbxUnitB.Items.Clear();
            //cbxUnitC.Items.Clear();

            txtProjectName.Text = string.Empty;
            txtTotalTime.Text = string.Empty;
            txtTotalMoney.Text = string.Empty;
            cbxSecret.SelectedIndex = 0;
            txtMPersonName.Text = string.Empty;
            txtTelephone.Text = string.Empty;
            txtAddress.Text = string.Empty;
            txtKeyWords.Text = string.Empty;
        }

        private void UpdateUnitList()
        {
            var unitList = _unitInforService.GetUnitInforList();

            //leSearchList.Properties.DataSource = unitList;
            //leSearchList.Properties.DisplayMember = "UnitBankNo";
            //leSearchList.Properties.ValueMember = "ID";

            if (MainForm.Instance.ProjectObj != null)
            {
                leSearchList.EditValue = MainForm.Instance.ProjectObj.UnitID;
            }
        }

        private void UpdatePersonList()
        {   
            if (MainForm.Instance.ProjectObj != null)
            {
                ProjectPersonObj = ConnectionManager.Context.table("Person").where("ID in (select PersonID from task where Role='负责人' and Type='项目' and ProjectID = '" + MainForm.Instance.ProjectObj.ID + "')").select("*").getItem<Person>(new Person());

            }

            //显示项目负责人信息
            if (ProjectPersonObj != null)
            {
                txtMPersonName.Text = ProjectPersonObj.Name;
                txtMPersonIDCard.Text = ProjectPersonObj.IDCard;
                //cbxMPersonSex.Text = ProjectPersonObj.Sex;
                //txtMPersonJob.Text = ProjectPersonObj.Job;
                //txtMPersonTelephone.Text = ProjectPersonObj.Telephone;
                //txtMPersonMobilephone.Text = ProjectPersonObj.MobilePhone;
                //txtMPersonBirthday.DateTime = ProjectPersonObj.Birthday != null ? ProjectPersonObj.Birthday.Value : DateTime.Now;
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (MainForm.Instance != null)
            {
                long result = SaveProject();

                if (result >= 0)
                {
                    MainForm.Instance.SwitchToContentEditor();
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            long result = SaveProject();

            if (result >= 0)
            {
                MessageBox.Show("保存完成!");
            }
        }

        private long SaveProject()
        {
            if (string.IsNullOrEmpty(txtMPersonName.Text))
            {
                MessageBox.Show("对不起,请输入项目负责人姓名!");
                return -1;
            }
            if (string.IsNullOrEmpty(txtMPersonIDCard.Text))
            {
                MessageBox.Show("对不起,请输入项目负责人身份证!");
                return -1;
            }
            if (string.IsNullOrEmpty(txtUnitName.Text))
            {
                MessageBox.Show("对不起,请输入单位名称!");
                return -1;
            }
            if (string.IsNullOrEmpty(txtProjectName.Text))
            {
                MessageBox.Show("对不起,请输入工程名称!");
                return -1;
            }
            if (string.IsNullOrEmpty(txtTotalTime.Text))
            {
                MessageBox.Show("对不起,请输入研究周期!");
                return -1;
            }
            if (string.IsNullOrEmpty(txtTotalMoney.Text))
            {
                MessageBox.Show("对不起,请输入研究经费!");
                return -1;
            }
            if (string.IsNullOrEmpty(txtKeyWords.Text))
            {
                MessageBox.Show("对不起,请输入关键字!");
                return -1;
            }
            int result = 0;
            decimal result2 = 0;
            if (int.TryParse(txtTotalTime.Text, out result) == false)
            {
                MessageBox.Show("对不起,研究周期格式不正确");
                return -1;
            }
            if (decimal.TryParse(txtTotalMoney.Text, out result2) == false)
            {
                MessageBox.Show("对不起,研究经费格式不正确");
                return -1;
            }

            if (leSearchList.EditValue == null || leSearchList.EditValue == "")
            {
                MessageBox.Show("对不起，请选择申报单位");
                return -1;
            }

            if (string.IsNullOrEmpty(txtContactName.Text))
            {
                MessageBox.Show("对不起，请输入联系人");
                return -1;
            }

            if (string.IsNullOrEmpty(txtTelephone.Text))
            {
                MessageBox.Show("对不起，请输入联系电话");
                return -1;
            }

            if (string.IsNullOrEmpty(txtAddress.Text))
            {
                MessageBox.Show("对不起，请输入通信地址");
                return -1;
            }

            //if (string.IsNullOrEmpty(txtFlagName.Text))
            //{
            //    MessageBox.Show("对不起，请输入公章名称");
            //    return -1;
            //}

            //if (string.IsNullOrEmpty(txtNormalName.Text))
            //{
            //    MessageBox.Show("对不起，请输入常用名");
            //    return -1;
            //}

            //项目负责人
            if (MainForm.Instance.ProjectObj != null)
            {
                ConnectionManager.Context.table("Task").where("Role='负责人' and Type='项目' and ProjectID='" + MainForm.Instance.ProjectObj.ID + "'").delete();
            }

            string projectIDs = string.Empty;
            if (MainForm.Instance.ProjectObj == null)
            {
                projectIDs = Guid.NewGuid().ToString();
            }
            else
            {
                projectIDs = MainForm.Instance.ProjectObj.ID;
            }

            if (ProjectPersonObj != null)
            {
                ConnectionManager.Context.table("Person").where("ID = '" + ProjectPersonObj.ID + "'").delete();
            }
            ProjectPersonObj = new Person();
            ProjectPersonObj.ID = Guid.NewGuid().ToString();
            ProjectPersonObj.Name = txtMPersonName.Text;
            ProjectPersonObj.UnitID = leSearchList.EditValue.ToString();
            ProjectPersonObj.IDCard = txtMPersonIDCard.Text;
            //ProjectPersonObj.IDCard = txtMPersonIDCard.Text;
            //ProjectPersonObj.Sex = cbxMPersonSex.Text;
            //ProjectPersonObj.Job = txtMPersonJob.Text;
            //ProjectPersonObj.Birthday = txtMPersonBirthday.DateTime;
            //ProjectPersonObj.Telephone = txtMPersonTelephone.Text;
            //ProjectPersonObj.MobilePhone = txtMPersonMobilephone.Text;
            ProjectPersonObj.copyTo(ConnectionManager.Context.table("Person")).insert();

            //ComboboxItem unitSelectedItem = ((ComboboxItem)cbxUnitA.Items[cbxUnitA.SelectedIndex]);
            Task projectPerson = new Task();
            projectPerson.ID = Guid.NewGuid().ToString();
            projectPerson.PersonID = ProjectPersonObj.ID;
            projectPerson.IDCard = ProjectPersonObj.IDCard;
            projectPerson.ProjectID = projectIDs;
            projectPerson.Role = "负责人";
            projectPerson.Type = "项目";
            projectPerson.copyTo(ConnectionManager.Context.table("Task")).insert();

            //工程
            if (MainForm.Instance.ProjectObj == null)
            {
                MainForm.Instance.ProjectObj = new Project();
            }

            MainForm.Instance.ProjectObj.ParentID = string.Empty;
            MainForm.Instance.ProjectObj.UnitID = leSearchList.EditValue.ToString();
            MainForm.Instance.ProjectObj.Type = "项目";
            MainForm.Instance.ProjectObj.SecretLevel = cbxSecret.SelectedItem != null ? cbxSecret.SelectedItem.ToString() : "公开";
            MainForm.Instance.ProjectObj.Name = txtProjectName.Text;
            MainForm.Instance.ProjectObj.TotalTime = int.Parse(txtTotalTime.Text);
            MainForm.Instance.ProjectObj.TotalMoney = decimal.Parse(txtTotalMoney.Text);
            MainForm.Instance.ProjectObj.Keywords = txtKeyWords.Text;

            //创建单位信息
            ConnectionManager.Context.table("Unit").where("ID='" + MainForm.Instance.ProjectObj.UnitID + "'").delete();
            Unit newUnit = new Unit();
            newUnit.ID = MainForm.Instance.ProjectObj.UnitID;
            newUnit.UnitName = txtUnitName.Text;
            //newUnit.FlagName = txtFlagName.Text;
            newUnit.NormalName = txtNormalName.Text;
            newUnit.ContactName = txtContactName.Text;
            newUnit.Telephone = txtTelephone.Text;
            newUnit.Address = txtAddress.Text;
            newUnit.UnitType = "申报单位";
            newUnit.SecretQualification = "未知";
            newUnit.copyTo(ConnectionManager.Context.table("Unit")).insert();

            //添加/修改工程
            if (string.IsNullOrEmpty(MainForm.Instance.ProjectObj.ID))
            {
                MainForm.Instance.ProjectObj.ID = projectIDs;

                //创建候选单位
                BuildWhiteList();

                return MainForm.Instance.ProjectObj.copyTo(ConnectionManager.Context.table("Project")).insert();
            }
            else
            {
                //创建候选单位
                BuildWhiteList();

                return MainForm.Instance.ProjectObj.copyTo(ConnectionManager.Context.table("Project")).where("ID='" + MainForm.Instance.ProjectObj.ID + "'").update();
            }
        }

        private void cbxPersonList_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (cbxPersonList.SelectedItem != null)
            //{
            //    ComboboxItem selected = (ComboboxItem)cbxPersonList.SelectedItem;
            //    Person pp = (Person)selected.Value;
            //    txtTelphone.Text = pp.Telephone;
            //    txtAddress.Text = pp.Address;
            //}
        }

        private void cbxUnitA_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (cbxUnitA.SelectedIndex >= 0)
            //{
            //    Unit uu = (Unit)((ComboboxItem)cbxUnitA.Items[cbxUnitA.SelectedIndex]).Value;
            //    txtFlagName.Text = uu.FlagName;
            //    txtNormalName.Text = uu.NormalName;
            //}
        }

        public void BuildUnitRecord(string unitExtId, string unitName, string contactName, string telephone, string unitType, string unitAddress)
        {
            ConnectionManager.Context.table("Unit").where("ID='" + unitExtId + "'").delete();

            Unit newUnit = new Unit();
            newUnit.ID = unitExtId;
            newUnit.UnitName = unitName;
            newUnit.FlagName = unitName;
            newUnit.NormalName = unitName;
            newUnit.ContactName = contactName;
            newUnit.Telephone = telephone;
            newUnit.Address = unitAddress;
            newUnit.UnitType = unitType;
            newUnit.SecretQualification = "未知";
            newUnit.copyTo(ConnectionManager.Context.table("Unit")).insert();
        }

        /// <summary>
        /// 创建候选牵头单位
        /// </summary>
        private void BuildWhiteList()
        {
            //删除所有记录
            ConnectionManager.Context.table("WhiteList").delete();

            //创建新的记录
            WhiteList wl = new WhiteList();
            wl.ID = Guid.NewGuid().ToString();
            wl.ProjectID = MainForm.Instance.ProjectObj.ID;
            wl.UnitID = MainForm.Instance.ProjectObj.UnitID;
            wl.copyTo(ConnectionManager.Context.table("WhiteList")).insert();
        }

        private void leSearchList_EditValueChanged(object sender, EventArgs e)
        {
            Unit unitObj = ConnectionManager.Context.table("Unit").where("ID='" + leSearchList.EditValue + "'").select("*").getItem<Unit>(new Unit());
            if (unitObj != null)
            {
                txtUnitName.Text = unitObj.UnitName;
                txtContactName.Text = unitObj.ContactName;
                txtTelephone.Text = unitObj.Telephone;
                txtAddress.Text = unitObj.Address;
                txtNormalName.Text = unitObj.NormalName;
            }
        }

        private void NewProjectEditor_SizeChanged(object sender, EventArgs e)
        {
            //plMain.Left = (Width - plMain.Width) / 2;
            //plMain.Top = (Height - plMain.Height) / 2;
        }
    }

    public delegate void EditValueChangedDelegate(object sender, EventArgs e);

    public class BankSelectButton : KryptonButton
    {
        public BankSelectButton():base()
        {
            Text = "请选择开户帐号！";
        }

        public event EditValueChangedDelegate EditValueChanged;

        private object _editValue = null;

        public object EditValue
        {
            get
            {
                return _editValue;
            }

            set
            {
                _editValue = value;
                if (value != null && ConnectionManager.Context != null)
                {
                    EditText = ConnectionManager.Context.table("UnitExt").where("ID='" + value + "'").select("UnitBankNo").getValue<string>("请选择开户帐号！");
                }
            }
        }

        public string EditText
        {
            get { return Text; }

            set { Text = value; }
        }

        protected override void OnClick(EventArgs e)
        {
            base.OnClick(e);

            UnitExtSelectForm selectForm = new UnitExtSelectForm(string.Empty);
            //UnitExtSelectForm selectForm = new UnitExtSelectForm(EditValue != null ? EditValue.ToString() : string.Empty);
            if (selectForm.ShowDialog() == DialogResult.OK)
            {
                EditValue = selectForm.SelectedUnitExt.ID;
                Text = selectForm.SelectedUnitExt.UnitBankNo;

                if (EditValueChanged != null)
                {
                    EditValueChanged(this, new EventArgs());
                }
            }
        }
    }
}