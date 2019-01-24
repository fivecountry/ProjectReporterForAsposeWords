using System;
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

namespace ProjectReporter.Controls
{
    public partial class NewProjectEditor : BaseEditor
    {
        public NewProjectEditor()
        {
            InitializeComponent();
            toCenter();
            cbxSecret.SelectedIndex = 0;
        }

        public void toCenter()
        {
            if (plTop != null)
            {
                plTop.Left = (Width - plTop.Width) / 2;
                plTop.Top = (Height - plTop.Height) / 2;
            }
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);

            toCenter();
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
            }

            UpdateUnitList();
            UpdatePersonList();
        }

        public override void ClearView()
        {
            cbxPersonList.Items.Clear();
            cbxUnitA.Items.Clear();
            //cbxUnitB.Items.Clear();
            //cbxUnitC.Items.Clear();

            txtProjectName.Text = string.Empty;
            txtTotalTime.Text = string.Empty;
            txtTotalMoney.Text = string.Empty;
            cbxSecret.SelectedIndex = 0;
            cbxPersonList.Text = string.Empty;
            txtTelphone.Text = string.Empty;
            txtAddress.Text = string.Empty;
            txtKeyWords.Text = string.Empty;
        }

        private void UpdateUnitList()
        {
            cbxUnitA.Items.Clear();
            List<Unit> list = ConnectionManager.Context.table("Unit").select("*").getList<Unit>(new Unit());
            foreach (Unit u in list)
            {
                cbxUnitA.Items.Add(new ComboboxItem(u.UnitName, u));

                if (MainForm.Instance.ProjectObj != null)
                {
                    if (MainForm.Instance.ProjectObj.UnitID == u.ID)
                    {
                        cbxUnitA.SelectedIndex = cbxUnitA.Items.Count - 1;
                    }
                }
            }
        }

        private void UpdatePersonList()
        {
            Person projectPersonObj = null;
            if (MainForm.Instance.ProjectObj != null)
            {
                projectPersonObj = ConnectionManager.Context.table("Person").where("ID in (select PersonID from task where Role='负责人' and Type='项目' and ProjectID = '" + MainForm.Instance.ProjectObj.ID + "')").select("*").getItem<Person>(new Person());

            }
            cbxPersonList.Items.Clear();
            List<Person> list = ConnectionManager.Context.table("Person").select("*").getList<Person>(new Person());

            foreach (Person p in list)
            {
                string pName = p.Name + "(" + p.IDCard + ")";
                ComboboxItem item = new ComboboxItem(pName, p);
                cbxPersonList.Items.Add(item);

                if (projectPersonObj != null && projectPersonObj.ID == p.ID)
                {
                    cbxPersonList.SelectedItem = item;
                }
            }
        }

        private void btnReport_Click(object sender, EventArgs e)
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

            if (cbxPersonList.SelectedIndex < 0)
            {
                MessageBox.Show("对不起,请选择项目负责人");
                return -1;
            }

            if (cbxUnitA.SelectedIndex < 0)
            {
                MessageBox.Show("对不起，请选择申报单位");
                return -1;
            }

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

            ComboboxItem personSelectedItem = (ComboboxItem)cbxPersonList.Items[cbxPersonList.SelectedIndex];
            ComboboxItem unitSelectedItem = ((ComboboxItem)cbxUnitA.Items[cbxUnitA.SelectedIndex]);
            Task projectPerson = new Task();
            projectPerson.ID = Guid.NewGuid().ToString();
            projectPerson.PersonID = ((Person)personSelectedItem.Value).ID;
            projectPerson.IDCard = ((Person)personSelectedItem.Value).IDCard;
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
            MainForm.Instance.ProjectObj.UnitID = ((Unit)unitSelectedItem.Value).ID;
            MainForm.Instance.ProjectObj.Type = "项目";
            MainForm.Instance.ProjectObj.SecretLevel = cbxSecret.SelectedItem != null ? cbxSecret.SelectedItem.ToString() : "公开";
            MainForm.Instance.ProjectObj.Name = txtProjectName.Text;
            MainForm.Instance.ProjectObj.TotalTime = int.Parse(txtTotalTime.Text);
            MainForm.Instance.ProjectObj.TotalMoney = decimal.Parse(txtTotalMoney.Text);
            MainForm.Instance.ProjectObj.Keywords = txtKeyWords.Text;

            if (string.IsNullOrEmpty(MainForm.Instance.ProjectObj.ID))
            {
                MainForm.Instance.ProjectObj.ID = projectIDs;
                return MainForm.Instance.ProjectObj.copyTo(ConnectionManager.Context.table("Project")).insert();
            }
            else
            {
                return MainForm.Instance.ProjectObj.copyTo(ConnectionManager.Context.table("Project")).where("ID='" + MainForm.Instance.ProjectObj.ID + "'").update();
            }
        }

        private void cbxPersonList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxPersonList.SelectedItem != null)
            {
                ComboboxItem selected = (ComboboxItem)cbxPersonList.SelectedItem;
                Person pp = (Person)selected.Value;
                txtTelphone.Text = pp.Telephone;
                txtAddress.Text = pp.Address;
            }
        }

        private void cbxUnitA_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxUnitA.SelectedIndex >= 0)
            {
                Unit uu = (Unit)((ComboboxItem)cbxUnitA.Items[cbxUnitA.SelectedIndex]).Value;
                txtFlagName.Text = uu.FlagName;
                txtNormalName.Text = uu.NormalName;
            }
        }
    }
}