﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;
using ProjectReporter.Forms;
using ProjectReporter.DB;
using ProjectReporter.DB.Entitys;
using ComponentFactory.Krypton.Navigator;
using System.IO;

namespace ProjectReporter.Controls
{
    public partial class KeTiTianBaoEditor : BaseEditor
    {
        private KryptonNavigator ParentNavigator = null;

        public KeTiTianBaoEditor()
        {
            InitializeComponent();

            EnabledAutoNextPage = false;

            //显示图标
            dgvDetail[dgvDetail.Columns.Count - 1, 0].Value = global::ProjectReporter.Properties.Resources.exclamation_16;
            dgvDetail[dgvDetail.Columns.Count - 2, 0].Value = global::ProjectReporter.Properties.Resources.DELETE_28;
            dgvDetail[dgvDetail.Columns.Count - 3, 0].Value = "填报课题内容";

            //显示密级
            ((KryptonDataGridViewComboBoxColumn)dgvDetail.Columns[2]).Items.Add("公开");
            ((KryptonDataGridViewComboBoxColumn)dgvDetail.Columns[2]).Items.Add("秘密");
            ((KryptonDataGridViewComboBoxColumn)dgvDetail.Columns[2]).Items.Add("机密");
            ((KryptonDataGridViewComboBoxColumn)dgvDetail.Columns[2]).Items.Add("绝密");
        }

        private void UpdateUnitList()
        {
            UnitList = ConnectionManager.Context.table("UnitExt").select("*").getList<UnitExt>(new UnitExt());
            if (UnitList != null)
            {
                //((KryptonDataGridViewComboBoxColumn)dgvDetail.Columns[4]).Items.Clear();
                //foreach (Unit u in UnitList)
                //{
                //    ((KryptonDataGridViewComboBoxColumn)dgvDetail.Columns[4]).Items.Add(u.UnitName);
                //}
            }
        }

        private void UpdatePersonList()
        {
            //PersonList = ConnectionManager.Context.table("Person").select("*").getList<Person>(new Person());
            //if (PersonList != null)
            //{
            //    ((KryptonDataGridViewComboBoxColumn)dgvDetail.Columns[3]).Items.Clear();
            //    PersonDict.Clear();
            //    foreach (Person p in PersonList)
            //    {
            //        string key = p.Name + "(" + p.IDCard + ")";
            //        ((KryptonDataGridViewComboBoxColumn)dgvDetail.Columns[3]).Items.Add(key);
            //        PersonDict.Add(key, p);
            //    }
            //}
        }

        private void UpdateKeTiList()
        {
            KeTiList = ConnectionManager.Context.table("Project").where("Type='" + "课题" + "' and ParentID='" + MainForm.Instance.ProjectObj.ID + "'").select("*").getList<Project>(new Project());

            dgvDetail.Rows.Clear();
            ((DataGridViewImageColumn)dgvDetail.Columns[dgvDetail.Columns.Count - 1]).Image = ProjectReporter.Properties.Resources.DELETE_28;
            int indexx = 0;
            foreach (Project keti in KeTiList)
            {
                string personName = string.Empty;
                string personIdCard = string.Empty;
                string unitName = string.Empty;
                //string content = string.Empty;
                string unitBankNo = string.Empty;
                string unitExtId = string.Empty;
                Person personObj = null;
                Unit unitObj = null;
                UnitExt unitExtObj = null;

                Task ketiTask = ConnectionManager.Context.table("Task").where("ProjectID='" + keti.ID + "'").select("*").getItem<Task>(new Task());
                if (ketiTask != null)
                {
                    //content = ketiTask.Content;

                    personObj = ConnectionManager.Context.table("Person").where("ID='" + ketiTask.PersonID + "'").select("*").getItem<Person>(new Person());
                    unitObj = ConnectionManager.Context.table("Unit").where("ID='" + keti.UnitID + "'").select("*").getItem<Unit>(new Unit());
                    unitExtObj = ConnectionManager.Context.table("UnitExt").where("ID='" + keti.UnitID + "'").select("*").getItem<UnitExt>(new UnitExt());

                    if (personObj != null)
                    {
                        personName = personObj.Name;
                        personIdCard = personObj.IDCard;
                    }

                    if (unitObj != null)
                    {
                        unitName = unitObj.UnitName;
                    }

                    if (unitExtObj != null)
                    {
                        unitBankNo = unitExtObj.UnitBankNo;
                        unitExtId = unitExtObj.ID;
                    }
                }

                indexx++;
                List<object> cells = new List<object>();
                cells.Add(indexx + "");
                cells.Add(keti.Name);
                cells.Add(keti.SecretLevel);
                cells.Add(personName);
                cells.Add(personIdCard);
                cells.Add(unitName);
                cells.Add(unitBankNo);
                cells.Add(ketiTask.TotalMoney);
                cells.Add(keti.Type2 == "总体课题");
                cells.Add("填报课题内容");

                int rowIndex = dgvDetail.Rows.Add(cells.ToArray());
                dgvDetail.Rows[rowIndex].Tag = keti;

                dgvDetail.Rows[rowIndex].Cells[6].Tag = unitExtId;
                dgvDetail.Rows[rowIndex].Cells[5].Tag = unitObj;
            }
        }

        private void dgvDetail_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvDetail.Rows.Count >= 1)
            {
                Project kett = ((Project)dgvDetail.Rows[e.RowIndex].Tag);
                if (kett != null)
                {
                    if (e.ColumnIndex == dgvDetail.Columns.Count - 1)
                    {
                        KeTiXiangXiForm form = new KeTiXiangXiForm(kett);
                        form.ShowDialog();
                    }
                    else if (e.ColumnIndex == dgvDetail.Columns.Count - 2)
                    {
                        #region 删除数据
                        if (MessageBox.Show("真的要删除吗?", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {

                            ConnectionManager.Context.table("Project").where("ID='" + kett.ID + "'").delete();
                            ConnectionManager.Context.table("Task").where("ProjectID='" + kett.ID + "'").delete();
                            ConnectionManager.Context.table("ProjectAndStep").where("StepID in (select ID from Step where ProjectID = '" + kett.ID + "')").delete();
                            ConnectionManager.Context.table("Step").where("ProjectID = '" + kett.ID + "'").delete();
                            ConnectionManager.Context.table("MoneyAndYear").where("ProjectID='" + kett.ID + "'").delete();
                            ConnectionManager.Context.table("MoneyAndType").where("ProjectID='" + kett.ID + "'").delete();

                            //UpdateKeTiList();
                            MainForm.Instance.RefreshEditorWithoutRTFTextEditor();
                        }
                        #endregion
                    }
                    else if (e.ColumnIndex == 6)
                    {
                        UnitExtSelectForm usf = new UnitExtSelectForm(kett.UnitID);
                        if (usf.ShowDialog() == DialogResult.OK)
                        {
                            if (usf.SelectedUnitExt != null)
                            {
                                dgvDetail.Rows[e.RowIndex].Cells[6].Value = usf.SelectedUnitExt.UnitBankNo;
                                dgvDetail.Rows[e.RowIndex].Cells[6].Tag = usf.SelectedUnitExt.ID;

                                Unit unitObj = ConnectionManager.Context.table("Unit").where("ID='" + usf.SelectedUnitExt.ID + "'").select("*").getItem<Unit>(new Unit());
                                if (unitObj != null)
                                {
                                    dgvDetail.Rows[e.RowIndex].Cells[5].Value = unitObj.UnitName;
                                    dgvDetail.Rows[e.RowIndex].Cells[5].Tag = unitObj;
                                }
                            }
                        }
                    }
                    else if (e.ColumnIndex == dgvDetail.Columns.Count - 3)
                    {
                        BuildOneKeTiDetailPageWithKeTiRow(e.RowIndex);
                    }
                }
                else if (e.ColumnIndex == dgvDetail.Columns.Count - 2)
                {
                    if (MessageBox.Show("真的要删除吗?", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        try
                        {
                            dgvDetail.Rows.RemoveAt(e.RowIndex);
                        }
                        catch (Exception ex)
                        {
                            UpdateKeTiList();
                        }
                    }
                }
                else if (e.ColumnIndex == 6)
                {
                    UnitExtSelectForm usf = new UnitExtSelectForm(string.Empty);
                    if (usf.ShowDialog() == DialogResult.OK)
                    {
                        if (usf.SelectedUnitExt != null)
                        {
                            dgvDetail.Rows[e.RowIndex].Cells[6].Value = usf.SelectedUnitExt.UnitBankNo;
                            dgvDetail.Rows[e.RowIndex].Cells[6].Tag = usf.SelectedUnitExt.ID;

                            Unit unitObj = ConnectionManager.Context.table("Unit").where("ID='" + usf.SelectedUnitExt.ID + "'").select("*").getItem<Unit>(new Unit());
                            if (unitObj != null)
                            {
                                dgvDetail.Rows[e.RowIndex].Cells[5].Value = unitObj.UnitName;
                                dgvDetail.Rows[e.RowIndex].Cells[5].Tag = unitObj;
                            }
                        }
                    }
                }
                else if (e.ColumnIndex == dgvDetail.Columns.Count - 3)
                {
                    BuildOneKeTiDetailPageWithKeTiRow(e.RowIndex);
                }
            }
        }

        private void BuildOneKeTiDetailPageWithKeTiRow(int rowIndex)
        {
            if (dgvDetail.Rows[rowIndex].Cells[1].Value == null)
            {
                return;
            }

            string ketiName = dgvDetail.Rows[rowIndex].Cells[1].Value.ToString();
            string ketiID = string.Empty;
            Project ketiProj =  (Project)dgvDetail.Rows[rowIndex].Tag;
            if (ketiProj == null)
            {
                if (dgvDetail.Rows[rowIndex].Cells[0].Tag == null)
                {
                    //需要生成一个课题ID,然后生成标签
                    ketiID = Guid.NewGuid().ToString();

                    //记录一下提前生成的课题ID
                    dgvDetail.Rows[rowIndex].Cells[0].Tag = ketiID;
                }
                else
                {
                    ketiID = dgvDetail.Rows[rowIndex].Cells[0].Tag.ToString();
                }
            }
            else
            {
                //直接重新生成标签就可以
                ketiID = ketiProj.ID;
            }

            //查找是否已存在
            KryptonPage oldPage = null;
            foreach (KryptonPage kp in ParentNavigator.Pages)
            {
                if (kp.Name == ketiID)
                {
                    oldPage = kp;
                    break;
                }
            }
            
            if (oldPage == null)
            {
                oldPage = BuildOneKetiReadmePage(ketiID, ketiName);
            }

            ParentNavigator.SelectedPage = oldPage;
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
            ((KryptonDataGridView)sender)[((KryptonDataGridView)sender).Columns.Count - 1, e.RowIndex].Value = global::ProjectReporter.Properties.Resources.exclamation_16;
            ((KryptonDataGridView)sender)[((KryptonDataGridView)sender).Columns.Count - 2, e.RowIndex].Value = global::ProjectReporter.Properties.Resources.DELETE_28;
            ((KryptonDataGridView)sender)[((KryptonDataGridView)sender).Columns.Count - 3, e.RowIndex].Value = "填报课题内容";

            if (((KryptonDataGridView)sender)[6, e.RowIndex].Value == null || ((KryptonDataGridView)sender)[6, e.RowIndex].Value == "")
            {
                ((KryptonDataGridView)sender)[6, e.RowIndex].Value = "选择单位帐号";
            }
        }

        public override void OnSaveEvent()
        {
            base.OnSaveEvent();

            if (GetZongZiKetiCount() == 1)
            {
                int saveCount = 0;
                Project proj = null;
                foreach (DataGridViewRow dgvRow in dgvDetail.Rows)
                {
                    Person personObj = null;

                    if (dgvRow.Tag == null)
                    {
                        //新行
                        proj = new Project();
                    }
                    else
                    {
                        //已存在数据
                        proj = (Project)dgvRow.Tag;
                    }

                    if (dgvRow.Cells[2].Value == null)
                    {
                        break;
                    }

                    if (dgvRow.Cells[1].Value == null)
                    {
                        MessageBox.Show("对不起,请输入课题名称!");
                        return;
                    }

                    if (dgvRow.Cells[3].Value == null)
                    {
                        MessageBox.Show("对不起,请输入负责人姓名");
                        return;
                    }
                    if (dgvRow.Cells[4].Value == null)
                    {
                        MessageBox.Show("对不起,请输入负责人身份证");
                        return;
                    }
                    if (dgvRow.Cells[5].Value == null)
                    {
                        MessageBox.Show("对不起,请输入承担单位名称!");
                        return;
                    }
                    if (dgvRow.Cells[6].Tag == null)
                    {
                        MessageBox.Show("对不起,请选择承担单位开户帐号!");
                        return;
                    }

                    decimal totalMoney = 0;
                    if (dgvRow.Cells[7].Value != null && decimal.TryParse(dgvRow.Cells[7].Value.ToString(), out totalMoney) == false)
                    {
                        MessageBox.Show("对不起,请输入正确的研究经费!");
                        return;
                    }

                    saveCount++;
                    if (saveCount >= 11)
                    {
                        MessageBox.Show("对不起，最多只能添加10个课题！");
                        break;
                    }

                    ConnectionManager.Context.table("Person").where("IDCard = '" + dgvRow.Cells[4].Value + "'").delete();
                    personObj = new Person();
                    personObj.ID = Guid.NewGuid().ToString();
                    personObj.Name = dgvRow.Cells[3].Value.ToString();
                    personObj.UnitID = dgvRow.Cells[6].Tag.ToString();
                    personObj.IDCard = dgvRow.Cells[4].Value.ToString();
                    //ProjectPersonObj.IDCard = txtMPersonIDCard.Text;
                    //ProjectPersonObj.Sex = cbxMPersonSex.Text;
                    //ProjectPersonObj.Job = txtMPersonJob.Text;
                    //ProjectPersonObj.Birthday = txtMPersonBirthday.DateTime;
                    //ProjectPersonObj.Telephone = txtMPersonTelephone.Text;
                    //ProjectPersonObj.MobilePhone = txtMPersonMobilephone.Text;
                    personObj.copyTo(ConnectionManager.Context.table("Person")).insert();

                    //课题部分
                    proj.Name = dgvRow.Cells[1].Value.ToString();
                    proj.SecretLevel = dgvRow.Cells[2].Value.ToString();
                    proj.Type = "课题";
                    proj.ParentID = MainForm.Instance.ProjectObj.ID;
                    proj.UnitID = dgvRow.Cells[6].Tag.ToString();
                    proj.Type2 = dgvRow.Cells[8].Value != null ? (((bool)dgvRow.Cells[8].Value) == true ? "总体课题" : "非总体课题") : "非总体课题";

                    //创建课题单位
                    if (dgvRow.Cells[5].Tag != null && ((Unit)dgvRow.Cells[5].Tag).ID != null)
                    {
                        Unit unitObj = (Unit)dgvRow.Cells[5].Tag;
                        unitObj.UnitName = dgvRow.Cells[5].Value.ToString();
                        BuildUnitRecord(proj.UnitID, unitObj.UnitName, unitObj.ContactName, unitObj.Telephone, unitObj.UnitType, unitObj.Address);
                    }
                    else
                    {
                        BuildUnitRecord(proj.UnitID, dgvRow.Cells[5].Value.ToString(), "未知", "未知", "课题单位", "未知");
                    }

                    //添加或更新课题数据
                    if (string.IsNullOrEmpty(proj.ID))
                    {
                        //新行
                        if (dgvRow.Cells[0].Tag != null)
                        {
                            //点击了生成标签页，存在已生成的ID
                            proj.ID = dgvRow.Cells[0].Tag.ToString();
                        }
                        else
                        {
                            //没有点击生成标签页，需要生成ID
                            proj.ID = Guid.NewGuid().ToString();
                        }

                        proj.copyTo(ConnectionManager.Context.table("Project")).insert();
                    }
                    else
                    {
                        //更新
                        proj.copyTo(ConnectionManager.Context.table("Project")).where("ID='" + proj.ID + "'").update();
                    }

                    //任务分工部分
                    Task task = ConnectionManager.Context.table("Task").where("ProjectID='" + proj.ID + "' and Role = '负责人'").select("*").getItem<Task>(new Task());
                    if (task == null || string.IsNullOrEmpty(task.ID))
                    {
                        //新行
                        task = new Task();
                        task.ProjectID = proj.ID;
                    }

                    task.PersonID = personObj.ID;
                    task.IDCard = personObj.IDCard;
                    task.Role = "负责人";
                    task.Type = "课题";
                    task.TotalMoney = totalMoney;
                    task.TotalTime = 0;

                    if (string.IsNullOrEmpty(task.ID))
                    {
                        task.ID = Guid.NewGuid().ToString();
                        task.copyTo(ConnectionManager.Context.table("Task")).insert();
                    }
                    else
                    {
                        task.copyTo(ConnectionManager.Context.table("Task")).where("ID='" + task.ID + "'").update();
                    }
                }

                //同步阶段数据
                SyncStepList();

                //更新课题列表
                UpdateKeTiList();
            }
            else
            {
                MessageBox.Show("对不起,必须并且只能有一个总体课题!");
            }
        }

        public override void ClearView()
        {
            base.ClearView();

            dgvDetail.Rows.Clear();
        }

        public override void RefreshView()
        {
            base.RefreshView();

            //获得上一级的Tab控件
            ParentNavigator = MainForm.Instance.GetTabControl(this);

            //显示负责人
            UpdatePersonList();

            //显示负责单位
            UpdateUnitList();

            //课题列表
            UpdateKeTiList();

            //显示课题详细
            BuildKetiReadmPages();
        }

        //public List<Person> PersonList { get; set; }

        public List<UnitExt> UnitList { get; set; }

        public List<Project> KeTiList { get; set; }

        //protected Dictionary<string, Person> PersonDict = new Dictionary<string, Person>();

        public override bool IsInputCompleted()
        {
            if (dgvDetail.Rows.Count == 0)
            {
                MessageBox.Show("对不起,请输入课题信息!");
            }

            return dgvDetail.Rows.Count >= 1;
        }

        /// <summary>
        /// 同步一下阶段信息的修改
        /// </summary>
        private void SyncStepList()
        {
            foreach (BaseEditor be in MainForm.Instance.EditorMaps.Values)
            {
                if (be is JieDuanHuaFenEditor)
                {
                    //刷新列表
                    be.RefreshView();

                    //尝试创建4个初始项目
                    ((JieDuanHuaFenEditor)be).Build4StepItems();

                    //保存数据
                    be.OnSaveEvent();
                    break;
                }
            }
        }

        /// <summary>
        /// 查询总体课题数量
        /// </summary>
        /// <returns></returns>
        private int GetZongZiKetiCount()
        {
            int result = 1;
            //foreach (DataGridViewRow dgvRow in dgvDetail.Rows)
            //{
            //    if (dgvRow.Cells[8].Value != null && ((bool)dgvRow.Cells[8].Value) == true)
            //    {
            //        result += 1;
            //    }
            //}
            return result;
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

        public void BuildKetiReadmPages()
        {
            if (KeTiList != null)
            {
                //删除除第一页之外其它标签页
                List<KryptonPage> deletePageList = new List<KryptonPage>();
                foreach (KryptonPage kp in ParentNavigator.Pages)
                {
                    if (kp.Tag != null && kp.Tag.ToString() == "KeTiDynamic")
                    {
                        deletePageList.Add(kp);
                    }
                }
                foreach (KryptonPage kpp in deletePageList)
                {
                    ParentNavigator.Pages.Remove(kpp);
                }

                foreach (Project proj in KeTiList)
                {
                    BuildOneKetiReadmePage(proj.ID, proj.Name);
                }
            }
        }

        private KryptonPage BuildOneKetiReadmePage(string ketiID, string ketiName)
        {
            KryptonPage kp = new KryptonPage();
            kp.Name = ketiID;
            kp.Text = ketiName;
            kp.Tag = "KeTiDynamic";

            KeTiDetailEditor rtfTextEditor = new KeTiDetailEditor();
            rtfTextEditor.TitleLabelText = "课题(" + ketiName + ")详细内容";
            rtfTextEditor.Dock = DockStyle.Fill;
            rtfTextEditor.BackColor = Color.White;

            rtfTextEditor.RTFFileFirstName = "keti_" + rtfTextEditor.RTFFileFirstName;
            rtfTextEditor.Name = rtfTextEditor.RTFEditorNameKey + ketiID;
            rtfTextEditor.RefreshView();
            rtfTextEditor.NextEvent += RtfTextEditor_NextEvent;

            kp.Controls.Add(rtfTextEditor);

            //插入到课题关系之前
            ParentNavigator.Pages.Insert(ParentNavigator.Pages.Count - 1, kp);
            return kp;
        }

        private void RtfTextEditor_NextEvent(object sender, EventArgs args)
        {
            KeTiDetailEditor textEditor = (KeTiDetailEditor)sender;
            textEditor.OnSaveEvent();

            if (textEditor.DetailTabs.Pages.Count - 1 == textEditor.DetailTabs.SelectedIndex)
            {
                if (ParentNavigator.Pages.Count - 2 == ParentNavigator.SelectedIndex)
                {
                    //切换到下一页(课题关系)
                    MainForm.Instance.SwitchToNextPage(this);
                }
                else
                {
                    ParentNavigator.SelectedIndex += 1;
                }
            }
            else
            {
                textEditor.DetailTabs.SelectedIndex += 1;
            }
        }

        private void dgvDetail_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (e.ColumnIndex == 1 && e.RowIndex == 0)
            {
                ttcHintTool.HideHint();
                ttcHintTool.ShowHint("项目原则上需设置一个总体课题，由牵头申报单位承担，课题负责人由项目负责人担任。", dgvDetail.PointToScreen(dgvDetail.GetCellDisplayRectangle(1, e.RowIndex, false).Location));
            }
        }

        public override void NextPage()
        {
            base.NextPage();

            //判断列表中是否有数据，如果有则执行课题页签下一页的过程，如果没有则调用系统的下一页
            if (dgvDetail.Rows.Count >= 2)
            {
                BuildOneKeTiDetailPageWithKeTiRow(0);
            }
            else
            {
                MainForm.Instance.SwitchToNextPage(this);
            }
        }
    }
}