using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ProjectReporter.Utility;
using System.IO;
using ProjectReporter.DB.Entitys;
using ProjectReporter.DB;
using System.Diagnostics;
using ProjectReporter.Controls;

namespace ProjectReporter.Forms
{
    public partial class WordExportForm : BaseForm
    {
        string uploadA = string.Empty;

        string uploadBTemp = string.Empty;

        string uploadB = string.Empty;

        protected object defaultValue = System.Reflection.Missing.Value;

        public WordExportForm(string toWordFile)
        {
            InitializeComponent();

            this.ToWordFile = toWordFile;
            this.picbox.Image = global::ProjectReporter.Properties.Resources.ToWord;
            this.pbar.Maximum = 80;

            string[] filess = Directory.GetFiles(MainForm.ProjectFilesDir);
            foreach (string f in filess)
            {
                if (f.Contains("upload_1"))
                {
                    uploadA = f;
                }
                else if (f.Contains("upload_2"))
                {
                    uploadBTemp = f;
                }
            }
            //将Image转换为RTF文件并设置段落为最小值25
            if (File.Exists(uploadBTemp))
            {
                uploadB = Path.Combine(MainForm.ProjectFilesDir, Guid.NewGuid().ToString() + ".rtf");
                ConvertToRTF(uploadBTemp, uploadB, new RichTextBoxTableClass());
            }

            BaseForm.AsyncDelegate del = delegate
            {
                this.setprogress(0, "准备数据...");
                                
                //生成Word
                this.ExportWord();
            };
            base.BeginInvoke(del);
        }

        private void setprogress(int cval, string msg)
        {
            BaseForm.MethodInvoker uiDelegate = delegate
            {
                if (cval == this.pbar.Maximum)
                {
                    this.Close();
                }
                this.pbar.Value = cval;
                this.lbmsg.Text = msg;
            };
            base.UpdateUI(uiDelegate, this);
        }

        private bool ExportWord()
        {
            //Word路径
            string toWordPath = string.Empty;

            this.setprogress(10, "准备Word...");
            string msg = "";
            if (!FileOp.RunWordInstCheck(out msg))
            {
                BaseForm.MethodInvoker uiDelegate = delegate
                {
                    MessageBox.Show(msg, "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.Close();
                };
                base.UpdateUI(uiDelegate, this);
                return false;
            }
            if (MainForm.Instance.ProjectObj == null)
            {
                return false;
            }

            string fileName = MainForm.Instance.ProjectObj.Name + "-项目建议书.docx";
            WordUtility wu = new WordUtility();
            wu.CreateNewDocument(Path.Combine(Path.Combine(Application.StartupPath, "Helper"), "newtemplete.docx"));

            try
            {
                this.setprogress(20, "准备数据...");

                #region 查询项目负责人及单位信息
                Person projectPersonObj = ConnectionManager.Context.table("Person").where("ID in (select PersonID from task where Role='负责人' and Type='项目' and ProjectID = '" + MainForm.Instance.ProjectObj.ID + "')").select("*").getItem<Person>(new Person());
                if (projectPersonObj == null)
                {
                    return false;
                }
                Unit projectUnitObj = ConnectionManager.Context.table("Unit").where("ID = '" + MainForm.Instance.ProjectObj.UnitID + "'").select("*").getItem<Unit>(new Unit());
                if (projectUnitObj == null)
                {
                    return false;
                }
                #endregion

                this.setprogress(30, "写入基本信息...");

                #region 固定文本替换
                wu.InsertValue("项目名称", MainForm.Instance.ProjectObj.Name);
                wu.InsertValue("首页密级", MainForm.Instance.ProjectObj.SecretLevel);
                wu.InsertValue("单位名称", projectUnitObj.UnitName);
                wu.InsertValue("单位常用名", projectUnitObj.NormalName);
                wu.InsertValue("项目负责人", projectPersonObj.Name);
                wu.InsertValue("单位联系人", projectUnitObj.ContactName);
                wu.InsertValue("联系电话", projectUnitObj.Telephone);
                wu.InsertValue("通信地址", projectUnitObj.Address);
                wu.InsertValue("研究周期", MainForm.Instance.ProjectObj.TotalTime + "");
                wu.InsertValue("研究经费", MainForm.Instance.ProjectObj.TotalMoney + "");
                wu.InsertValue("项目关键字", MainForm.Instance.ProjectObj.Keywords != null ? MainForm.Instance.ProjectObj.Keywords.Replace(";", " ") : string.Empty);

                List<Project> ketiList = ConnectionManager.Context.table("Project").where("ParentID = '" + MainForm.Instance.ProjectObj.ID + "'").select("*").getList<Project>(new Project());
                wu.InsertValue("课题数量", ketiList.Count + "");

                wu.InsertValue("研究周期B", MainForm.Instance.ProjectObj.TotalTime + "");
                wu.InsertValue("研究经费B", MainForm.Instance.ProjectObj.TotalMoney + "");

                List<Step> projectStepList = ConnectionManager.Context.table("Step").where("ProjectID = '" + MainForm.Instance.ProjectObj.ID + "'").select("*").getList<Step>(new Step());
                wu.InsertValue("阶段数量", projectStepList.Count + "");
                StringBuilder stepBuilders = new StringBuilder();
                foreach (Step step in projectStepList)
                {
                    stepBuilders.Append("阶段").Append(step.StepIndex).Append("为").Append(step.StepTime).Append("月").Append(",");
                }
                wu.InsertValue("阶段时间摘要", stepBuilders.ToString());

                wu.InsertValue("项目负责人B", projectPersonObj.Name);
                wu.InsertValue("项目负责人性别", projectPersonObj.Sex);
                wu.InsertValue("项目负责人生日", (projectPersonObj.Birthday != null ? projectPersonObj.Birthday.Value.ToShortDateString() : "未知"));
                wu.InsertValue("项目负责人职务", projectPersonObj.Job);
                wu.InsertValue("项目负责人座机", projectPersonObj.Telephone);
                wu.InsertValue("项目负责人手机", projectPersonObj.MobilePhone);

                Unit whiteUnit = ConnectionManager.Context.table("Unit").where("ID in (select UnitID from WhiteList where ProjectID = '" + MainForm.Instance.ProjectObj.ID + "')").select("*").getItem<Unit>(new Unit());
                wu.InsertValue("候选单位名称", whiteUnit.UnitName);
                wu.InsertValue("候选单位联系人", whiteUnit.ContactName);
                wu.InsertValue("候选单位联系电话", whiteUnit.Telephone);
                wu.InsertValue("候选单位通信地址", whiteUnit.Address);
                #endregion

                this.setprogress(40, "写入文档文件...");

                #region 插入固定RTF文件
                wu.InsertFile("项目摘要", Path.Combine(MainForm.ProjectFilesDir, "rtpinput_0.rtf"), true);
                wu.InsertFile("基本概念及内涵", Path.Combine(MainForm.ProjectFilesDir, "rtpinput_1.rtf"), true);
                wu.InsertFile("军事需求分析", Path.Combine(MainForm.ProjectFilesDir, "rtpinput_2.rtf"), true);
                wu.InsertFile("研究现状", Path.Combine(MainForm.ProjectFilesDir, "rtpinput_3.rtf"), true);
                wu.InsertFile("研究目标", Path.Combine(MainForm.ProjectFilesDir, "rtpinput_4.rtf"), false);
                wu.InsertFile("基础性问题", Path.Combine(MainForm.ProjectFilesDir, "rtpinput_5.rtf"), true);
                wu.InsertFile("课题之间的关系", Path.Combine(MainForm.ProjectFilesDir, "rtpinput_7.rtf"), true);
                wu.InsertFile("研究成果及考核指标", Path.Combine(MainForm.ProjectFilesDir, "rtpinput_8.rtf"), true);
                wu.InsertFile("评估方案", Path.Combine(MainForm.ProjectFilesDir, "rtpinput_9.rtf"), true);
                wu.InsertFile("预期效益", Path.Combine(MainForm.ProjectFilesDir, "rtpinput_10.rtf"), true);
                wu.InsertFile("项目负责人C", Path.Combine(MainForm.ProjectFilesDir, "rtpinput_14.rtf"), true);
                wu.InsertFile("研究团队", Path.Combine(MainForm.ProjectFilesDir, "rtpinput_15.rtf"), true);
                wu.InsertFile("研究基础与保障条件", Path.Combine(MainForm.ProjectFilesDir, "rtpinput_17.rtf"), true);
                wu.InsertFile("组织实施与风险控制", Path.Combine(MainForm.ProjectFilesDir, "rtpinput_18.rtf"), true);
                wu.InsertFile("与有关计划关系", Path.Combine(MainForm.ProjectFilesDir, "rtpinput_19.rtf"), false);

                wu.InsertFile("附件1", uploadA, true);
                wu.InsertFile("附件2", uploadB, true);

                #endregion

                List<KeyValuePair<string, Project>> ketiMap = new List<KeyValuePair<string, Project>>();
                #region 插入课题详细RTF
                try
                {                    
                    ketiMap.Add(new KeyValuePair<string, Project>("项目", MainForm.Instance.ProjectObj));

                    //替换课题详细内容
                    int ketiIndex = 1;
                    foreach (Project proj in ketiList)
                    {
                        string ketiCode = "课题" + ketiIndex;

                        wu.SelectBookMark("课题详细_" + ketiIndex);
                        wu.ReplaceA("F2-" + ketiIndex, ketiCode + ":" + proj.Name);

                        //研究目标，研究内容，技术要求等文档
                        wu.InsertFile("课题详细_" + ketiIndex + "_1", Path.Combine(MainForm.ProjectFilesDir, "keti_rtpinput_" + proj.ID + "_dest" + ".rtf"), true);
                        wu.InsertFile("课题详细_" + ketiIndex + "_2", Path.Combine(MainForm.ProjectFilesDir, "keti_rtpinput_" + proj.ID + "_cnt" + ".rtf"), true);
                        wu.InsertFile("课题详细_" + ketiIndex + "_3", Path.Combine(MainForm.ProjectFilesDir, "keti_rtpinput_" + proj.ID + "_need" + ".rtf"), true);

                        //负责人
                        string fuzeUnit = string.Empty;
                        string fuzePerson = string.Empty;
                        fuzeUnit = ConnectionManager.Context.table("Unit").where("ID = (select UnitID from Project where ID = (select ProjectID from Task where Role= '负责人' and ProjectID = '" + proj.ID + "'))").select("UnitName").getValue<string>(string.Empty);
                        fuzePerson = ConnectionManager.Context.table("Person").where("ID = (select PersonID from Task where Role= '负责人' and ProjectID = '" + proj.ID + "')").select("Name").getValue<string>(string.Empty);

                        wu.InsertValue("课题详细_" + ketiIndex + "_4", "  负责人：" + fuzePerson + "\n  负责单位：" + fuzeUnit);

                        //金额
                        string moneyStr = "0";
                        Task ketiTask = ConnectionManager.Context.table("Task").where("ProjectID='" + proj.ID + "'").select("*").getItem<Task>(new Task());
                        if (ketiTask != null)
                        {
                            moneyStr = "  " + ketiTask.TotalMoney + "万";
                        }
                        wu.InsertValue("课题详细_" + ketiIndex + "_5", moneyStr);

                        ketiIndex++;

                        if (ketiMap.Count == 1)
                        {
                            ketiMap.Add(new KeyValuePair<string, Project>(ketiCode, proj));
                        }
                        else
                        {
                            ketiMap.Add(new KeyValuePair<string, Project>(ketiCode, proj));
                        }
                    }

                    //删除多余的项目
                    int delCount = 10 - ketiList.Count;
                    if (delCount >= 1)
                    {
                        for (int kk = 0; kk < delCount; kk++)
                        {
                            wu.SelectBookMark("课题详细_" + ketiIndex);
                            wu.DeleteCurrentAll();

                            wu.SelectBookMark("课题详细_" + ketiIndex + "_1");
                            wu.DeleteCurrentAndLast();
                            wu.Delete();

                            wu.SelectBookMark("课题详细_" + ketiIndex + "_2");
                            wu.DeleteCurrentAndLast();
                            wu.Delete();

                            wu.SelectBookMark("课题详细_" + ketiIndex + "_3");
                            wu.DeleteCurrentAndLast();
                            wu.Delete();

                            wu.SelectBookMark("课题详细_" + ketiIndex + "_4");
                            wu.DeleteCurrentAndLast();
                            wu.Delete();

                            wu.SelectBookMark("课题详细_" + ketiIndex + "_5");
                            wu.DeleteCurrentAndLast();
                            wu.Delete();

                            ketiIndex++;
                        }
                    }

                    //插入课题摘要
                    int indexx = 0;
                    StringBuilder ketiStringBuilder = new StringBuilder();
                    foreach (Project proj in ketiList)
                    {
                        indexx++;
                        Task tt = ConnectionManager.Context.table("Task").where("ProjectID = '" + proj.ID + "'").select("*").getItem<Task>(new Task());

                        string shortContent = string.Empty;
                        shortContent = File.ReadAllText(Path.Combine(MainForm.ProjectFilesDir, "keti_rtpinput_" + proj.ID + "_info" + ".rtf"));

                        //ketiStringBuilder.Append("课题").Append(indexx).Append("(").Append(proj.Type2.Contains("非") ? string.Empty : proj.Type2).Append(proj.Type2.Contains("非") ? string.Empty : ",").Append(proj.SecretLevel).Append("):").Append(proj.Name).Append(",").Append(shortContent).Append("\n");
                        ketiStringBuilder.Append("课题").Append(indexx).Append("(").Append(proj.SecretLevel).Append("):").Append(proj.Name).Append(",").Append(shortContent).Append("\n");
                    }
                    wu.InsertValue("课题摘要", ketiStringBuilder.ToString());
                }
                catch (Exception ex)
                {
                    System.Console.WriteLine(ex.ToString());
                }
                #endregion

                this.setprogress(50, "写入阶段信息...");

                #region 插入阶段划分和经费安排数据
                try
                {
                    foreach (Microsoft.Office.Interop.Word.Table table in wu.Applicaton.ActiveDocument.Tables)
                    {
                        if (table.Range.Text.Contains("第一阶段：X月"))
                        {
                            //填充行和列
                            int rowCount = ketiList.Count + 1;
                            int colCount = projectStepList.Count;
                            table.Select();
                            for (int k = 0; k < rowCount - 1; k++)
                            {
                                table.Rows.Add(ref defaultValue);
                            }
                            for (int k = 0; k < colCount - 1; k++)
                            {
                                table.Columns.Add(ref defaultValue);
                            }

                            //创建列标题
                            int colIndex = 2;
                            foreach (Step step in projectStepList)
                            {
                                table.Cell(1, colIndex).Range.Text = "阶段" + step.StepIndex + "(" + step.StepTime + "个月)";
                                table.Cell(1, colIndex).VerticalAlignment = Microsoft.Office.Interop.Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;
                                colIndex++;
                            }

                            //创建数据
                            int rowIndex = 2;
                            foreach (KeyValuePair<string, Project> kvp in ketiMap)
                            {
                                int totalMoney = 0;
                                //获取并填冲数据
                                int dataColIndex = 2;
                                List<Step> curStepList = ConnectionManager.Context.table("Step").where("ProjectID = '" + kvp.Value.ID + "'").select("*").getList<Step>(new Step());
                                foreach (Step curStep in curStepList)
                                {
                                    ProjectAndStep curProjectAndStep = ConnectionManager.Context.table("ProjectAndStep").where("StepID = '" + curStep.ID + "'").select("*").getItem<ProjectAndStep>(new ProjectAndStep());

                                    StringBuilder sb = new StringBuilder();
                                    //阶段数据
                                    if (kvp.Key == "项目")
                                    {
                                        //项目数据  研究内容,阶段目标,阶段经费
                                        sb.Append("研究内容:").Append(curProjectAndStep.StepContent).Append("\n").Append("阶段目标:").Append(curStep.StepDest).Append("\n").Append("阶段经费:").Append(curStep.StepMoney);
                                    }
                                    else
                                    {
                                        //课题数据  研究内容,阶段成果,考核方式,阶段经费
                                        sb.Append("研究内容:").Append(curProjectAndStep.StepContent).Append("\n").Append("阶段成果:").Append(curProjectAndStep.StepResult).Append("\n").Append("考核方式:").Append(curProjectAndStep.Method).Append("\n").Append("阶段经费:").Append(curProjectAndStep.Money);
                                        totalMoney += (int)curProjectAndStep.Money;
                                    }

                                    table.Cell(rowIndex, dataColIndex).Range.Text = sb.ToString();
                                    dataColIndex++;
                                }

                                //行标题
                                if (kvp.Key != "项目")
                                {
                                    table.Cell(rowIndex, 1).Range.Text = kvp.Key + "(" + totalMoney + "万)";
                                }
                                else
                                {
                                    table.Cell(rowIndex, 1).Range.Text = kvp.Key;
                                }

                                rowIndex++;
                            }
                            break;
                        }
                    }
                }
                catch (Exception ex)
                {
                    System.Console.WriteLine(ex.ToString());
                }
                #endregion

                this.setprogress(60, "写入课题负责人及研究骨干信息...");

                #region 插入课题负责人及研究骨干情况表
                try
                {
                    foreach (Microsoft.Office.Interop.Word.Table table in wu.Applicaton.ActiveDocument.Tables)
                    {
                        if (table.Range.Text.Contains("为本课题"))
                        {
                            //获得课题与研究骨干关系表
                            List<Task> taskList = ConnectionManager.Context.table("Task").where("ProjectID in (select ID from Project where ParentID = '" + MainForm.Instance.ProjectObj.ID + "') or ProjectID='" + MainForm.Instance.ProjectObj.ID + "'").select("*").getList<Task>(new Task());

                            //生成行和列
                            int rowCount = taskList.Count;
                            table.Select();
                            for (int k = 0; k < rowCount - 1; k++)
                            {
                                table.Rows.Add(ref defaultValue);
                            }

                            //填冲数据
                            int rowIndex = 2;
                            foreach (Task curTask in taskList)
                            {
                                #region 提取人员信息
                                Project taskKeti = ConnectionManager.Context.table("Project").where("ID='" + curTask.ProjectID + "'").select("*").getItem<Project>(new Project());
                                Person person = ConnectionManager.Context.table("Person").where("ID='" + curTask.PersonID + "'").select("*").getItem<Person>(new Person());
                                Unit unit = ConnectionManager.Context.table("Unit").where("ID='" + person.UnitID + "'").select("*").getItem<Unit>(new Unit());
                                #endregion

                                table.Cell(rowIndex, 1).Range.Text = (rowIndex - 1).ToString();
                                table.Cell(rowIndex, 2).Range.Text = person.Name;
                                table.Cell(rowIndex, 3).Range.Text = person.IDCard;
                                table.Cell(rowIndex, 4).Range.Text = unit.UnitName;
                                table.Cell(rowIndex, 5).Range.Text = person.Job;
                                table.Cell(rowIndex, 6).Range.Text = person.Specialty;

                                string KetiInProject = string.Empty;
                                foreach (KeyValuePair<string, Project> kvp in ketiMap)
                                {
                                    if (kvp.Value.ID == curTask.ProjectID)
                                    {
                                        KetiInProject = kvp.Key + curTask.Role;
                                        break;
                                    }
                                }
                                table.Cell(rowIndex, 7).Range.Text = KetiInProject;

                                table.Cell(rowIndex, 8).Range.Text = curTask.Content;
                                table.Cell(rowIndex, 9).Range.Text = curTask.TotalTime.ToString();

                                rowIndex++;
                            }

                            break;
                        }
                    }
                }
                catch (Exception ex)
                {
                    System.Console.WriteLine(ex.ToString());
                }
                #endregion

                this.setprogress(70, "写入经费预算...");

                #region 插入经费预算表
                try
                {
                    ProjectBudgetInfo pbinfo = ProjectReporter.Controls.JingFeiYuSuanEditor.GetBudgetInfoObject(MainForm.Instance.ProjectObj.ID);
                    if (pbinfo != null)
                    {
                        wu.InsertValue("本项目申请经费", pbinfo.ProjectRFA + "");
                        wu.InsertValue("本项目自筹经费", pbinfo.ProjectZiChouJingFei + "");

                        string bookmark = "ProjectRFAs";
                        object obj4 = pbinfo.ProjectRFA;
                        wu.InsertValue(bookmark, obj4 != null ? obj4.ToString() : "0");
                        bookmark = "ProjectRFA";
                        wu.InsertValue(bookmark, obj4 + "万");
                        bookmark = "ProjectRFA1";
                        obj4 = pbinfo.ProjectRFA1;
                        wu.InsertValue(bookmark, obj4 != null ? obj4.ToString() : "0");
                        bookmark = "ProjectRFA1_1";
                        obj4 = pbinfo.ProjectRFA1_1;
                        wu.InsertValue(bookmark, obj4 != null ? obj4.ToString() : "0");
                        bookmark = "ProjectRFA1_1_1";
                        obj4 = pbinfo.ProjectRFA1_1_1;
                        wu.InsertValue(bookmark, obj4 != null ? obj4.ToString() : "0");
                        bookmark = "ProjectRFA1_1_2";
                        obj4 = pbinfo.ProjectRFA1_1_2;
                        wu.InsertValue(bookmark, obj4 != null ? obj4.ToString() : "0");
                        bookmark = "ProjectRFA1_1_3";
                        obj4 = pbinfo.ProjectRFA1_1_3;
                        wu.InsertValue(bookmark, obj4 != null ? obj4.ToString() : "0");
                        bookmark = "ProjectRFA1_2";
                        obj4 = pbinfo.ProjectRFA1_2;
                        wu.InsertValue(bookmark, obj4 != null ? obj4.ToString() : "0");
                        bookmark = "ProjectRFA1_3";
                        obj4 = pbinfo.ProjectRFA1_3;
                        wu.InsertValue(bookmark, obj4 != null ? obj4.ToString() : "0");
                        bookmark = "ProjectRFA1_4";
                        obj4 = pbinfo.ProjectRFA1_4;
                        wu.InsertValue(bookmark, obj4 != null ? obj4.ToString() : "0");
                        bookmark = "ProjectRFA1_5";
                        obj4 = pbinfo.ProjectRFA1_5;
                        wu.InsertValue(bookmark, obj4 != null ? obj4.ToString() : "0");
                        bookmark = "ProjectRFA1_6";
                        obj4 = pbinfo.ProjectRFA1_6;
                        wu.InsertValue(bookmark, obj4 != null ? obj4.ToString() : "0");
                        bookmark = "ProjectRFA1_7";
                        obj4 = pbinfo.ProjectRFA1_7;
                        wu.InsertValue(bookmark, obj4 != null ? obj4.ToString() : "0");
                        bookmark = "ProjectRFA1_8";
                        obj4 = pbinfo.ProjectRFA1_8;
                        wu.InsertValue(bookmark, obj4 != null ? obj4.ToString() : "0");
                        bookmark = "ProjectRFA1_9";
                        obj4 = pbinfo.ProjectRFA1_9;
                        wu.InsertValue(bookmark, obj4 != null ? obj4.ToString() : "0");
                        bookmark = "ProjectRFA2";
                        obj4 = pbinfo.ProjectRFA2;
                        wu.InsertValue(bookmark, obj4 != null ? obj4.ToString() : "0");
                        bookmark = "ProjectRFA2_1";
                        obj4 = pbinfo.ProjectRFA2_1;
                        wu.InsertValue(bookmark, obj4 != null ? obj4.ToString() : "0");
                        bookmark = "ProjectOutlay1";
                        obj4 = pbinfo.Projectoutlay1;
                        wu.InsertValue(bookmark, obj4 != null ? obj4.ToString() : "0");
                        bookmark = "ProjectOutlay2";
                        obj4 = pbinfo.Projectoutlay2;
                        wu.InsertValue(bookmark, obj4 != null ? obj4.ToString() : "0");
                        bookmark = "ProjectOutlay3";
                        obj4 = pbinfo.Projectoutlay3;
                        wu.InsertValue(bookmark, obj4 != null ? obj4.ToString() : "0");
                        bookmark = "ProjectOutlay4";
                        obj4 = pbinfo.Projectoutlay4;
                        wu.InsertValue(bookmark, obj4 != null ? obj4.ToString() : "0");
                        bookmark = "ProjectOutlay5";
                        obj4 = pbinfo.Projectoutlay5;
                        wu.InsertValue(bookmark, obj4 != null ? obj4.ToString() : "0");
                        bookmark = "ProjectRFARm";
                        obj4 = pbinfo.ProjectRFArm;
                        wu.InsertValue(bookmark, obj4 != null ? obj4.ToString() : string.Empty);
                        bookmark = "ProjectRFA1Rm";
                        obj4 = pbinfo.ProjectRFA1rm;
                        wu.InsertValue(bookmark, obj4 != null ? obj4.ToString() : string.Empty);
                        bookmark = "ProjectRFA1_1Rm";
                        obj4 = pbinfo.ProjectRFA1_1rm;
                        wu.InsertValue(bookmark, obj4 != null ? obj4.ToString() : string.Empty);
                        bookmark = "ProjectRFA1_1_1Rm";
                        obj4 = pbinfo.ProjectRFA1_1_1rm;
                        wu.InsertValue(bookmark, obj4 != null ? obj4.ToString() : string.Empty);
                        bookmark = "ProjectRFA1_1_2Rm";
                        obj4 = pbinfo.ProjectRFA1_1_2rm;
                        wu.InsertValue(bookmark, obj4 != null ? obj4.ToString() : string.Empty);
                        bookmark = "ProjectRFA1_1_3Rm";
                        obj4 = pbinfo.ProjectRFA1_1_3rm;
                        wu.InsertValue(bookmark, obj4 != null ? obj4.ToString() : string.Empty);
                        bookmark = "ProjectRFA1_2Rm";
                        obj4 = pbinfo.ProjectRFA1_2rm;
                        wu.InsertValue(bookmark, obj4 != null ? obj4.ToString() : string.Empty);
                        bookmark = "ProjectRFA1_3Rm";
                        obj4 = pbinfo.ProjectRFA1_3rm;
                        wu.InsertValue(bookmark, obj4 != null ? obj4.ToString() : string.Empty);
                        bookmark = "ProjectRFA1_4Rm";
                        obj4 = pbinfo.ProjectRFA1_4rm;
                        wu.InsertValue(bookmark, obj4 != null ? obj4.ToString() : string.Empty);
                        bookmark = "ProjectRFA1_5Rm";
                        obj4 = pbinfo.ProjectRFA1_5rm;
                        wu.InsertValue(bookmark, obj4 != null ? obj4.ToString() : string.Empty);
                        bookmark = "ProjectRFA1_6Rm";
                        obj4 = pbinfo.ProjectRFA1_6rm;
                        wu.InsertValue(bookmark, obj4 != null ? obj4.ToString() : string.Empty);
                        bookmark = "ProjectRFA1_7Rm";
                        obj4 = pbinfo.ProjectRFA1_7rm;
                        wu.InsertValue(bookmark, obj4 != null ? obj4.ToString() : string.Empty);
                        bookmark = "ProjectRFA1_8Rm";
                        obj4 = pbinfo.ProjectRFA1_8rm;
                        wu.InsertValue(bookmark, obj4 != null ? obj4.ToString() : string.Empty);
                        bookmark = "ProjectRFA1_9Rm";
                        obj4 = pbinfo.ProjectRFA1_9rm;
                        wu.InsertValue(bookmark, obj4 != null ? obj4.ToString() : string.Empty);
                        bookmark = "ProjectRFA2Rm";
                        obj4 = pbinfo.ProjectRFA2rm;
                        wu.InsertValue(bookmark, obj4 != null ? obj4.ToString() : string.Empty);
                        bookmark = "ProjectRFA2_1Rm";
                        obj4 = pbinfo.ProjectRFA2_1rm;
                        wu.InsertValue(bookmark, obj4 != null ? obj4.ToString() : string.Empty);
                    }
                }
                catch (Exception ex)
                {
                    System.Console.WriteLine(ex.ToString());
                }
                #endregion

                this.setprogress(75, "写入联系方式...");

                #region 插入联系方式
                try
                {
                    foreach (Microsoft.Office.Interop.Word.Table table in wu.Applicaton.ActiveDocument.Tables)
                    {
                        if (table.Range.Text.Contains("各课题联系方式"))
                        {
                            int titleIndex = table.Rows.Count - 1;
                            int dataIndex = table.Rows.Count;

                            //构造联系方式行
                            int rowCountt = (ketiList.Count * 3) - 1;
                            for (int k = 0; k < rowCountt; k++)
                            {
                                table.Select();
                                table.Rows.Add(ref defaultValue);
                            }
                            //合并单元格
                            if (rowCountt >= 2)
                            {
                                for (int k = 0; k < ketiList.Count; k++)
                                {
                                    //计算开始位置
                                    int rowStart = dataIndex + (k * 3);
                                    int rowEnd = rowStart + 2;

                                    #region 写入标签                                    
                                    table.Cell(rowStart, 1).Range.Text = "课题" + (k + 1);
                                    table.Cell(rowStart, 1).VerticalAlignment = Microsoft.Office.Interop.Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;

                                    table.Cell(rowStart, 1).Select();
                                    wu.Applicaton.Selection.ParagraphFormat.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphCenter;

                                    table.Cell(rowStart, 2).Range.Text = "负责人";
                                    table.Cell(rowStart, 2).VerticalAlignment = Microsoft.Office.Interop.Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;

                                    table.Cell(rowStart, 2).Select();
                                    wu.Applicaton.Selection.ParagraphFormat.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphCenter;

                                    table.Cell(rowStart, 4).Range.Text = "性别";
                                    table.Cell(rowStart, 4).VerticalAlignment = Microsoft.Office.Interop.Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;

                                    table.Cell(rowStart, 4).Select();
                                    wu.Applicaton.Selection.ParagraphFormat.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphCenter;

                                    table.Cell(rowStart, 6).Range.Text = "出生年月";
                                    table.Cell(rowStart, 6).VerticalAlignment = Microsoft.Office.Interop.Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;

                                    table.Cell(rowStart, 6).Select();
                                    wu.Applicaton.Selection.ParagraphFormat.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphCenter;

                                    table.Cell(rowStart + 1, 2).Range.Text = "职务职称";
                                    table.Cell(rowStart + 1, 2).VerticalAlignment = Microsoft.Office.Interop.Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;

                                    table.Cell(rowStart + 1, 2).Select();
                                    wu.Applicaton.Selection.ParagraphFormat.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphCenter;

                                    table.Cell(rowStart + 1, 4).Range.Text = "座机";
                                    table.Cell(rowStart + 1, 4).VerticalAlignment = Microsoft.Office.Interop.Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;

                                    table.Cell(rowStart + 1, 4).Select();
                                    wu.Applicaton.Selection.ParagraphFormat.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphCenter;

                                    table.Cell(rowStart + 1, 6).Range.Text = "手机";
                                    table.Cell(rowStart + 1, 6).VerticalAlignment = Microsoft.Office.Interop.Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;

                                    table.Cell(rowStart + 1, 6).Select();
                                    wu.Applicaton.Selection.ParagraphFormat.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphCenter;

                                    table.Cell(rowStart + 2, 2).Range.Text = "承担单位及通信地址";
                                    table.Cell(rowStart + 2, 2).VerticalAlignment = Microsoft.Office.Interop.Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;

                                    table.Cell(rowStart + 2, 2).Select();
                                    wu.Applicaton.Selection.ParagraphFormat.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphCenter;

                                    #endregion

                                    #region 写入实际数据
                                    Project proj = ketiList[k];
                                    Unit unitObj = ConnectionManager.Context.table("Unit").where("ID='" + proj.UnitID + "'").select("*").getItem<Unit>(new Unit());
                                    Task taskObj = ConnectionManager.Context.table("Task").where("ProjectID = '" + proj.ID + "' and Type='课题' and Role='负责人'").select("*").getItem<Task>(new Task());
                                    Person personObj = ConnectionManager.Context.table("Person").where("ID ='" + taskObj.PersonID + "'").select("*").getItem<Person>(new Person());

                                    table.Cell(rowStart, 3).Range.Text = personObj.Name;
                                    table.Cell(rowStart, 3).VerticalAlignment = Microsoft.Office.Interop.Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;

                                    table.Cell(rowStart, 3).Select();
                                    wu.Applicaton.Selection.ParagraphFormat.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphLeft;

                                    table.Cell(rowStart, 5).Range.Text = personObj.Sex;
                                    table.Cell(rowStart, 5).VerticalAlignment = Microsoft.Office.Interop.Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;

                                    table.Cell(rowStart, 5).Select();
                                    wu.Applicaton.Selection.ParagraphFormat.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphLeft;

                                    table.Cell(rowStart, 7).Range.Text = personObj.Birthday != null ? personObj.Birthday.Value.ToShortDateString() : string.Empty;
                                    table.Cell(rowStart, 7).VerticalAlignment = Microsoft.Office.Interop.Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;

                                    table.Cell(rowStart, 7).Select();
                                    wu.Applicaton.Selection.ParagraphFormat.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphLeft;

                                    table.Cell(rowStart + 1, 3).Range.Text = personObj.Job;
                                    table.Cell(rowStart + 1, 3).VerticalAlignment = Microsoft.Office.Interop.Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;

                                    table.Cell(rowStart + 1, 3).Select();
                                    wu.Applicaton.Selection.ParagraphFormat.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphLeft;

                                    table.Cell(rowStart + 1, 5).Range.Text = personObj.Telephone;
                                    table.Cell(rowStart + 1, 5).VerticalAlignment = Microsoft.Office.Interop.Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;

                                    table.Cell(rowStart + 1, 5).Select();
                                    wu.Applicaton.Selection.ParagraphFormat.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphLeft;

                                    table.Cell(rowStart + 1, 7).Range.Text = personObj.MobilePhone;
                                    table.Cell(rowStart + 1, 7).VerticalAlignment = Microsoft.Office.Interop.Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;

                                    table.Cell(rowStart + 1, 7).Select();
                                    wu.Applicaton.Selection.ParagraphFormat.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphLeft;

                                    table.Cell(rowStart + 2, 3).Range.Text = unitObj.UnitName + "," + unitObj.Address;
                                    table.Cell(rowStart + 2, 3).VerticalAlignment = Microsoft.Office.Interop.Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;

                                    table.Cell(rowStart + 2, 3).Select();
                                    wu.Applicaton.Selection.ParagraphFormat.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphLeft;

                                    #endregion

                                    //合并单元格
                                    wu.MergeCell(table, rowEnd, 3, rowEnd, 7);
                                    wu.MergeCell(table, rowStart, 1, rowEnd, 1);
                                }
                            }
                            else
                            {
                                table.Rows[titleIndex].Delete();
                                table.Rows[dataIndex].Delete();
                            }

                            break;
                        }
                    }
                }
                catch (Exception ex)
                {
                    System.Console.WriteLine(ex.ToString());
                }
                #endregion

                #region 更新目录

                try
                {   
                    wu.WordDoc.Styles["目录 1"].Font.NameFarEast = "黑体";
                    wu.WordDoc.Styles["目录 1"].Font.Size = 14;
                    wu.WordDoc.Styles["目录 1"].Font.Bold = 0;
                    wu.WordDoc.Styles["目录 1"].Font.Italic = 0;

                    wu.WordDoc.Styles["目录 2"].Font.NameFarEast = "楷体";
                    wu.WordDoc.Styles["目录 2"].Font.NameAscii = wu.WordDoc.Styles["目录 1"].Font.NameAscii;
                    wu.WordDoc.Styles["目录 2"].Font.NameBi = wu.WordDoc.Styles["目录 1"].Font.NameBi;
                    wu.WordDoc.Styles["目录 2"].Font.NameOther = wu.WordDoc.Styles["目录 1"].Font.NameOther;
                    wu.WordDoc.Styles["目录 2"].Font.Size = 12;
                    wu.WordDoc.Styles["目录 2"].Font.Bold = 0;
                    wu.WordDoc.Styles["目录 2"].Font.Italic = 0;

                    wu.WordDoc.Styles["目录 3"].Font.NameFarEast = "楷体";
                    wu.WordDoc.Styles["目录 3"].Font.NameAscii = wu.WordDoc.Styles["目录 1"].Font.NameAscii;
                    wu.WordDoc.Styles["目录 3"].Font.NameBi = wu.WordDoc.Styles["目录 1"].Font.NameBi;
                    wu.WordDoc.Styles["目录 3"].Font.NameOther = wu.WordDoc.Styles["目录 1"].Font.NameOther;
                    wu.WordDoc.Styles["目录 3"].Font.Size = 12;
                    wu.WordDoc.Styles["目录 3"].Font.Bold = 0;
                    wu.WordDoc.Styles["目录 3"].Font.Italic = 0;

                    object missing = System.Reflection.Missing.Value;
                    Microsoft.Office.Interop.Word.Range myRange = wu.WordDoc.TablesOfContents[1].Range;
                    wu.WordDoc.TablesOfContents[1].Delete();                    
                    object useHeadingStyle = true; //使用Head样式
                    object upperHeadingLevel = 1;  //最大一级
                    object lowerHeadingLevel = 2;  //最小三级
                    object useHypeLinks = true;
                    //TablesOfContents的Add方法添加目录
                    wu.WordDoc.TablesOfContents.Add(myRange, ref useHeadingStyle,
                        ref upperHeadingLevel, ref lowerHeadingLevel,
                        ref missing, ref missing, ref missing, ref missing,
                        ref missing, ref useHypeLinks, ref missing, ref missing);
                    wu.WordDoc.TablesOfContents[1].TabLeader = Microsoft.Office.Interop.Word.WdTabLeader.wdTabLeaderDots;
                }
                catch (Exception ex) { }

                wu.WordDoc.ResetFormFields();
                wu.WordDoc.Fields.Update();
                #endregion

                #region 页脚内容
                //wu.Applicaton.ActiveWindow.View.SeekView = Microsoft.Office.Interop.Word.WdSeekView.wdSeekCurrentPageFooter;
                //wu.Applicaton.Selection.HeaderFooter.LinkToPrevious = false;
                //wu.Applicaton.Selection.HeaderFooter.Range.ParagraphFormat.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphRight;
                //wu.Applicaton.ActiveWindow.ActivePane.Selection.InsertAfter("此文档生成于" + DateTime.Now.ToString());

                ////跳出页眉页脚设置
                //wu.Applicaton.ActiveWindow.View.SeekView = Microsoft.Office.Interop.Word.WdSeekView.wdSeekMainDocument;
                #endregion

                #region 设置表头重复

                //foreach (Microsoft.Office.Interop.Word.Table table in wu.Applicaton.ActiveDocument.Tables)
                //{
                //    if (table.Range.Text.Contains("申请经费"))
                //    {
                //        //设置经费预算表头重复
                //        if (table.Rows.Count >= 1)
                //        {
                //            try
                //            {
                //                table.Rows[1].HeadingFormat = (int)Microsoft.Office.Interop.Word.WdConstants.wdToggle;
                //            }
                //            catch (Exception ex)
                //            {
                //                System.Console.WriteLine(ex.ToString());
                //            }
                //        }
                //    }
                //    else
                //    {
                //        //设置其它表头重复
                //        if (table.Rows.Count >= 1)
                //        {
                //            try
                //            {
                //                //object _unitObj = Microsoft.Office.Interop.Word.WdUnits.wdLine;
                //                //object _extendObj = Microsoft.Office.Interop.Word.WdMovementType.wdExtend;

                //                //table.Cell(1, 1).Range.Select();

                //                //wu.Applicaton.Selection.HomeKey(ref _unitObj);
                //                //for (int k = 0; k < table.Rows[1].Cells.Count; k++)
                //                //{
                //                //    wu.Applicaton.Selection.EndKey(ref _unitObj, ref _extendObj);
                //                //}
                //                //wu.Applicaton.Selection.Rows.HeadingFormat = (int)Microsoft.Office.Interop.Word.WdConstants.wdToggle;

                //                table.Rows[1].HeadingFormat = (int)Microsoft.Office.Interop.Word.WdConstants.wdToggle;
                //            }
                //            catch (Exception ex)
                //            {
                //                System.Console.WriteLine(ex.ToString());
                //                System.Console.WriteLine(table.Range.Text.Replace(" ", string.Empty));
                //            }
                //        }
                //    }
                //}

                #endregion

                #region 显示文档或生成文档

                //临时文件及目录
                string tempDir = Path.Combine(Application.StartupPath, "TempDocs");
                if (!Directory.Exists(tempDir))
                {
                    Directory.CreateDirectory(tempDir);
                }
                string tempFile = Path.Combine(tempDir, Guid.NewGuid().ToString() + ".doc");
                if (string.IsNullOrEmpty(ToWordFile))
                {
                    //预览文档,需要显示
                    wu.SaveDocument(tempFile);
                    toWordPath = tempFile;

                    //打开Word文件
                    Process.Start(toWordPath);
                }
                else
                {
                    //导出时生成文档,不需要显示
                    wu.SaveDocument(ToWordFile);
                    toWordPath = ToWordFile;
                }
                #endregion
            }
            catch (Exception ex)
            {
                BaseForm.MethodInvoker uiDelegate4 = delegate
                {
                    MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.Close();
                };
                base.UpdateUI(uiDelegate4, this);

                wu.killWnWordProcess();
            }

            this.setprogress(80, "");
            return true;
        }

        public string ToWordFile { get; set; }

        public void ConvertToRTF(string imageFile, string tempRTFFile,RichTextBoxTableClass richTextObj)
        {
            try
            {
                Bitmap bmp = new Bitmap(imageFile);
                Clipboard.SetDataObject(bmp);
                DataFormats.Format dataFormat = DataFormats.GetFormat(DataFormats.Bitmap);
                if (richTextObj.CanPaste(dataFormat))
                {
                    richTextObj.Paste(dataFormat);
                }

                richTextObj.SelectAll();
                richTextObj.SetLineSpace(25);

                richTextObj.SaveFile(tempRTFFile);
            }
            catch (Exception exc)
            {
                System.Console.WriteLine(exc.ToString());
            }
        }
    }
}