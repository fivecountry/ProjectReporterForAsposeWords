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
using ProjectReporter.DB.Services;

namespace ProjectReporter.Forms
{
    public partial class UnitExtSelectForm : Form
    {
        UnitExtService _unitInforService = new UnitExtService();

        public UnitExt SelectedUnitExt { get; private set; }

        public UnitExtSelectForm(string unitID)
        {
            InitializeComponent();

            UpdateUnitList();

            leSearchList.EditValue = unitID;
        }

        private void UpdateUnitList()
        {
            var unitList = _unitInforService.GetUnitInforList();

            leSearchList.Properties.DataSource = unitList;
            leSearchList.Properties.DisplayMember = "ID";
            leSearchList.Properties.ValueMember = "ID";

            if (MainForm.Instance.ProjectObj != null)
            {
                leSearchList.EditValue = MainForm.Instance.ProjectObj.UnitID;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (leSearchList.EditValue == null)
            {
                btnCancel.PerformClick();
                return;
            }

            SelectedUnitExt = ConnectionManager.Context.table("UnitExt").where("ID='" + leSearchList.EditValue + "'").select("*").getItem<UnitExt>(new UnitExt());

            DialogResult = DialogResult.OK;
        }
    }
}