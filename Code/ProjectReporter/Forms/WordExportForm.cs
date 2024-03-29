﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ProjectReporter.Utility;
using System.IO;
using ProjectReporter.DB.Entitys;
using ProjectReporter.DB;
using System.Diagnostics;
using ProjectReporter.Controls;
using Aspose.Words;

namespace ProjectReporter.Forms
{
    public partial class WordExportForm : BaseForm
    {
        string uploadA = string.Empty;

        string uploadC = string.Empty;

        //string uploadBTemp = string.Empty;

        //string uploadB = string.Empty;

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
                    //uploadBTemp = f;
                }
                else if (f.Contains("upload_3"))
                {
                    uploadC = f;
                }
            }
            //将Image转换为RTF文件并设置段落为最小值25
            //if (File.Exists(uploadBTemp))
            //{
                //uploadB = uploadBTemp;
                //uploadB = Path.Combine(MainForm.ProjectFilesDir, Guid.NewGuid().ToString() + ".rtf");
                //ConvertToRTF(uploadBTemp, uploadB, new RichTextBoxTableClass());
            //}

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

                #region 查找需要生成的节点的样式
                Aspose.Words.Lists.List numberList = null;
                ParagraphFormat paragraphFormat = null;
                NodeCollection nodes = wu.Document.WordDoc.GetChildNodes(NodeType.Paragraph, true);
                foreach (Node node in nodes)
                {
                    if (node.Range.Text.Contains("F2-1"))
                    {
                        if (numberList == null)
                        {
                            numberList = ((Paragraph)node).ListFormat.List;
                            paragraphFormat = ((Paragraph)node).ParagraphFormat;
                        }

                        node.Remove();
                    }
                }
                #endregion

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
                wu.InsertValue("申报领域", MainForm.Instance.ProjectObj.Domain);
                wu.InsertValue("申报方向", MainForm.Instance.ProjectObj.Direction);
                wu.InsertValue("单位名称", projectUnitObj.UnitName);
                wu.InsertValue("单位常用名", projectUnitObj.NormalName);
                wu.InsertValue("项目负责人", projectPersonObj.Name);
                wu.InsertValue("单位联系人", projectUnitObj.ContactName);
                wu.InsertValue("联系电话", projectUnitObj.Telephone, 18, false, false, true);
                wu.InsertValue("通信地址", projectUnitObj.Address);
                wu.InsertValue("研究周期", MainForm.Instance.ProjectObj.TotalTime + "");
                wu.InsertValue("研究经费", MainForm.Instance.ProjectObj.TotalMoney + "");
                wu.InsertValue("项目关键字", MainForm.Instance.ProjectObj.Keywords != null ? MainForm.Instance.ProjectObj.Keywords : string.Empty);

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
                if (stepBuilders.Length > 1)
                {
                    stepBuilders.Remove(stepBuilders.Length - 1, 1);
                }
                wu.InsertValue("阶段时间摘要", stepBuilders.ToString());

                wu.InsertValue("项目负责人B", projectPersonObj.Name);
                wu.InsertValue("项目负责人性别", projectPersonObj.Sex);
                wu.InsertValue("项目负责人生日", (projectPersonObj.Birthday != null ? projectPersonObj.Birthday.Value.ToString("yyyy-MM-dd") : "未知"));
                wu.InsertValue("项目负责人职务", projectPersonObj.Job);
                wu.InsertValue("项目负责人座机", projectPersonObj.Specialty);
                wu.InsertValue("项目负责人手机", projectPersonObj.MobilePhone);

                Unit whiteUnit = ConnectionManager.Context.table("Unit").where("ID in (select UnitID from WhiteList where ProjectID = '" + MainForm.Instance.ProjectObj.ID + "')").select("*").getItem<Unit>(new Unit());
                wu.InsertValue("候选单位名称", whiteUnit.UnitName);
                wu.InsertValue("候选单位联系人", whiteUnit.ContactName);
                wu.InsertValue("候选单位联系电话", whiteUnit.Telephone);
                wu.InsertValue("候选单位通信地址", whiteUnit.Address);
                #endregion

                this.setprogress(40, "写入文档文件...");

                #region 插入固定RTF文件
                wu.InsertFile("项目摘要", Path.Combine(MainForm.ProjectFilesDir, "rtpinput_0.doc"), true);
                wu.InsertFile("基本概念及内涵", Path.Combine(MainForm.ProjectFilesDir, "rtpinput_1.doc"), true);
                wu.InsertFile("军事需求分析", Path.Combine(MainForm.ProjectFilesDir, "rtpinput_2.doc"), true);
                wu.InsertFile("研究现状", Path.Combine(MainForm.ProjectFilesDir, "rtpinput_3.doc"), true);
                wu.InsertFile("研究目标", Path.Combine(MainForm.ProjectFilesDir, "rtpinput_4.doc"), false);
                wu.InsertFile("基础性问题", Path.Combine(MainForm.ProjectFilesDir, "rtpinput_5.doc"), true);
                wu.InsertFile("课题之间的关系", Path.Combine(MainForm.ProjectFilesDir, "rtpinput_7.doc"), true);
                wu.InsertFile("研究成果及考核指标", Path.Combine(MainForm.ProjectFilesDir, "rtpinput_8.doc"), true);
                wu.InsertFile("评估方案", Path.Combine(MainForm.ProjectFilesDir, "rtpinput_9.doc"), true);
                wu.InsertFile("预期效益", Path.Combine(MainForm.ProjectFilesDir, "rtpinput_10.doc"), true);
                wu.InsertFile("项目负责人C", Path.Combine(MainForm.ProjectFilesDir, "rtpinput_14.doc"), true);
                wu.InsertFile("研究团队", Path.Combine(MainForm.ProjectFilesDir, "rtpinput_15.doc"), true);
                wu.InsertFile("研究基础与保障条件", Path.Combine(MainForm.ProjectFilesDir, "rtpinput_17.doc"), true);
                wu.InsertFile("组织实施与风险控制", Path.Combine(MainForm.ProjectFilesDir, "rtpinput_18.doc"), true);
                wu.InsertFile("与有关计划关系", Path.Combine(MainForm.ProjectFilesDir, "rtpinput_19.doc"), false);

                wu.InsertFile("附件1", uploadA, true);

                //插入保密资质
                List<ExtFileList> list = ConnectionManager.Context.table("ExtFileList").where("ProjectID='" + MainForm.Instance.ProjectObj.ID + "'").select("*").getList<ExtFileList>(new ExtFileList());
                foreach (ExtFileList efl in list)
                {
                    if (efl.IsIgnore == 0)
                    {
                        //图片文件
                        string picFile = Path.Combine(MainForm.ProjectFilesDir, efl.RealFileName);

                        //检查图片是否存在，如果存在则插入
                        if (File.Exists(picFile))
                        {
                            wu.InsertPicture("附件2", picFile);
                        }
                    }
                }

                //处理诚信承诺书
                uploadC = Path.Combine(Application.StartupPath, Path.Combine("Helper", "chengnuoshu.doc"));
                wu.InsertFile("附件3", uploadC, true);
                wu.InsertValue("诚信负责人", MainForm.Instance.ProjectObj.Name);
                #endregion

                #region 插入课题详细标签
                // "课题详细_" + ketiIndex + "_5"
                wu.Document.WordDocBuilder.MoveToBookmark("课题详细标识");

                wu.Document.WordDocBuilder.ListFormat.List = numberList;
                double oldFirstLineIndent = wu.Document.WordDocBuilder.ParagraphFormat.FirstLineIndent;
                wu.Document.WordDocBuilder.ParagraphFormat.FirstLineIndent = paragraphFormat.FirstLineIndent;

                for (int kk = 0; kk < ketiList.Count; kk++)
                {
                    int ketiIndex = (kk + 1);

                    wu.Document.WordDocBuilder.ParagraphFormat.StyleIdentifier = StyleIdentifier.Heading2;
                    wu.Document.WordDocBuilder.Writeln("F2-" + ketiIndex);
                    wu.Document.WordDocBuilder.StartBookmark("课题详细_" + ketiIndex);
                    wu.Document.WordDocBuilder.EndBookmark("课题详细_" + ketiIndex);

                    wu.Document.WordDocBuilder.ParagraphFormat.StyleIdentifier = StyleIdentifier.Heading3;
                    wu.Document.WordDocBuilder.Writeln("、研究目标");
                    wu.Document.WordDocBuilder.StartBookmark("课题详细_" + ketiIndex + "_1");
                    wu.Document.WordDocBuilder.EndBookmark("课题详细_" + ketiIndex + "_1");

                    wu.Document.WordDocBuilder.Writeln("、研究内容");
                    wu.Document.WordDocBuilder.StartBookmark("课题详细_" + ketiIndex + "_2");
                    wu.Document.WordDocBuilder.EndBookmark("课题详细_" + ketiIndex + "_2");

                    wu.Document.WordDocBuilder.Writeln("、研究思路");
                    wu.Document.WordDocBuilder.StartBookmark("课题详细_" + ketiIndex + "_3");
                    wu.Document.WordDocBuilder.EndBookmark("课题详细_" + ketiIndex + "_3");

                    wu.Document.WordDocBuilder.Writeln("、负责单位及负责人");
                    wu.Document.WordDocBuilder.ParagraphFormat.ClearFormatting();
                    wu.Document.WordDocBuilder.Writeln("负责人:未知");
                    wu.Document.WordDocBuilder.Writeln("负责单位:未知");
                    //wu.Document.WordDocBuilder.StartBookmark("课题详细_" + ketiIndex + "_4");
                    //wu.Document.WordDocBuilder.EndBookmark("课题详细_" + ketiIndex + "_4");

                    wu.Document.WordDocBuilder.ParagraphFormat.StyleIdentifier = StyleIdentifier.Heading3;
                    wu.Document.WordDocBuilder.ParagraphFormat.FirstLineIndent = paragraphFormat.FirstLineIndent;
                    wu.Document.WordDocBuilder.Writeln("、研究经费");
                    wu.Document.WordDocBuilder.ParagraphFormat.ClearFormatting();
                    wu.Document.WordDocBuilder.Writeln("1000万");
                    //wu.Document.WordDocBuilder.StartBookmark("课题详细_" + ketiIndex + "_5");
                    //wu.Document.WordDocBuilder.EndBookmark("课题详细_" + ketiIndex + "_5");
                }

                wu.Document.WordDocBuilder.ListFormat.RemoveNumbers();
                wu.Document.WordDocBuilder.ParagraphFormat.FirstLineIndent = oldFirstLineIndent;
                #endregion

                List<KeyValuePair<string, Project>> ketiMap = new List<KeyValuePair<string, Project>>();
                #region 插入课题详细RTF

                string[] chsNumbers = new string[] { "", "一", "二", "三", "四", "五", "六", "七", "八", "九", "十", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "" };
                try
                {
                    ketiMap.Add(new KeyValuePair<string, Project>("项目", MainForm.Instance.ProjectObj));

                    //替换课题详细内容
                    int ketiIndex = 1;
                    foreach (Project proj in ketiList)
                    {
                        string ketiCode = "课题" + chsNumbers[ketiIndex];

                        wu.SelectBookMark("课题详细_" + ketiIndex);
                        wu.ReplaceA("F2-" + ketiIndex, ketiCode + ":" + proj.Name);

                        //研究目标，研究内容，技术要求等文档
                        wu.InsertFile("课题详细_" + ketiIndex + "_1", Path.Combine(MainForm.ProjectFilesDir, "keti_rtpinput_" + proj.ID + "_dest" + ".doc"), false);
                        wu.InsertFile("课题详细_" + ketiIndex + "_2", Path.Combine(MainForm.ProjectFilesDir, "keti_rtpinput_" + proj.ID + "_cnt" + ".doc"), false);
                        wu.InsertFile("课题详细_" + ketiIndex + "_3", Path.Combine(MainForm.ProjectFilesDir, "keti_rtpinput_" + proj.ID + "_need" + ".doc"), false);

                        //负责人
                        string fuzeUnit = string.Empty;
                        string fuzePerson = string.Empty;
                        fuzeUnit = ConnectionManager.Context.table("Unit").where("ID = (select UnitID from Project where ID = (select ProjectID from Task where Role= '负责人' and ProjectID = '" + proj.ID + "'))").select("UnitName").getValue<string>(string.Empty);
                        fuzePerson = ConnectionManager.Context.table("Person").where("ID = (select PersonID from Task where Role= '负责人' and ProjectID = '" + proj.ID + "')").select("Name").getValue<string>(string.Empty);

                        //wu.InsertValue("课题详细_" + ketiIndex + "_4", "  负责人：" + fuzePerson + "\n  负责单位：" + fuzeUnit, true);

                        //金额
                        string moneyStr = "0";
                        Task ketiTask = ConnectionManager.Context.table("Task").where("ProjectID='" + proj.ID + "'").select("*").getItem<Task>(new Task());
                        if (ketiTask != null)
                        {
                            moneyStr = "  " + ketiTask.TotalMoney + "万";
                        }
                        //wu.InsertValue("课题详细_" + ketiIndex + "_5", moneyStr, true);

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

                    //插入课题摘要
                    int indexx = 0;
                    StringBuilder ketiStringBuilder = new StringBuilder();
                    foreach (Project proj in ketiList)
                    {
                        indexx++;
                        Task tt = ConnectionManager.Context.table("Task").where("ProjectID = '" + proj.ID + "'").select("*").getItem<Task>(new Task());

                        string shortContent = "无";
                        if (File.Exists(Path.Combine(MainForm.ProjectFilesDir, "keti_rtpinput_" + proj.ID + "_info" + ".rtf")))
                        {
                            shortContent = File.ReadAllText(Path.Combine(MainForm.ProjectFilesDir, "keti_rtpinput_" + proj.ID + "_info" + ".rtf"));
                        }

                        //ketiStringBuilder.Append("课题").Append(indexx).Append("(").Append(proj.Type2.Contains("非") ? string.Empty : proj.Type2).Append(proj.Type2.Contains("非") ? string.Empty : ",").Append(proj.SecretLevel).Append("):").Append(proj.Name).Append(",").Append(shortContent).Append("\n");
                        ketiStringBuilder.Append("课题").Append(chsNumbers[indexx]).Append("(").Append(proj.SecretLevel).Append("):").Append(proj.Name).Append(",").Append(shortContent).Append("\n");
                    }
                    if (ketiStringBuilder.Length > 0)
                    {
                        ketiStringBuilder.Remove(ketiStringBuilder.Length - 1, 1);
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
                    //项目
                    NodeCollection ncc = wu.Document.WordDoc.GetChildNodes(Aspose.Words.NodeType.Table, true);
                    foreach (Aspose.Words.Tables.Table table in ncc)
                    {
                        if (table.Range.Text.Contains("进度要求"))
                        {
                            //填充行和列
                            int rowCount = projectStepList.Count;
                            //int colCount = 3;
                            //table.Select();
                            for (int k = 0; k < rowCount - 1; k++)
                            {
                                Aspose.Words.Tables.Row row = (Aspose.Words.Tables.Row)table.Rows[table.Rows.Count - 1].Clone(true);
                                table.Rows.Add(row);
                            }

                            ////创建列标题
                            //int colIndex = 2;
                            //foreach (Step step in projectStepList)
                            //{
                            //    table.Cell(1, colIndex).Range.Text = "阶段" + step.StepIndex + "(" + step.StepTime + "个月)";
                            //    table.Cell(1, colIndex).VerticalAlignment = Microsoft.Office.Interop.Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;
                            //    colIndex++;
                            //}

                            //创建数据
                            int rowIndex = 1;
                            foreach (KeyValuePair<string, Project> kvp in ketiMap)
                            {
                                if (kvp.Key == "项目")
                                {
                                    List<Step> curStepList = ConnectionManager.Context.table("Step").where("ProjectID = '" + kvp.Value.ID + "'").select("*").getList<Step>(new Step());
                                    foreach (Step curStep in curStepList)
                                    {
                                        ProjectAndStep curProjectAndStep = ConnectionManager.Context.table("ProjectAndStep").where("StepID = '" + curStep.ID + "'").select("*").getItem<ProjectAndStep>(new ProjectAndStep());

                                        //输出格式
                                        string outputFormat = "完成内容及阶段目标:\n{0}\n阶段成果、考核指标及考核方式:\n{1}\n阶段经费:{2}万";

                                        string resultStr = string.Empty;
                                        //阶段数据
                                        if (kvp.Key == "项目")
                                        {
                                            resultStr = string.Format(outputFormat, curStep.StepDest, curStep.StepResult, curStep.StepMoney);
                                        }
                                        else
                                        {
                                            resultStr = string.Format(outputFormat, curProjectAndStep.StepDest, curProjectAndStep.StepResult, curProjectAndStep.Money);
                                        }

                                        table.Rows[rowIndex].Cells[0].RemoveAllChildren();
                                        table.Rows[rowIndex].Cells[1].RemoveAllChildren();
                                        table.Rows[rowIndex].Cells[2].RemoveAllChildren();
                                        table.Rows[rowIndex].Cells[0].AppendChild(wu.GetCellContentObj(table, curStep.StepIndex + ""));
                                        table.Rows[rowIndex].Cells[1].AppendChild(wu.GetCellContentObj(table, curStep.StepTime + ""));
                                        table.Rows[rowIndex].Cells[2].AppendChild(wu.GetCellContentObj(table, resultStr));
                                        
                                        rowIndex++;
                                    }
                                }
                            }
                            break;
                        }
                    }

                    //课题
                    foreach (Aspose.Words.Tables.Table table in ncc)
                    {
                        if (table.Range.Text.Contains("第一阶段：X月"))
                        {
                            //填充行和列
                            //int rowCount = ketiList.Count + 1;
                            int rowCount = ketiList.Count;
                            int colCount = projectStepList.Count;
                            //table.Select();

                            Aspose.Words.Tables.Row topRowObj = table.Rows[0];
                            Aspose.Words.Tables.Row rowObj = table.Rows[1];
                            Aspose.Words.Tables.Cell topCellObj = topRowObj.Cells[topRowObj.Cells.Count - 1];
                            Aspose.Words.Tables.Cell cellObj = rowObj.Cells[topRowObj.Cells.Count - 1];
                            for (int f = 0; f < colCount - 1; f++)
                            {
                                topRowObj.Cells.Add((Aspose.Words.Tables.Cell)topCellObj.Clone(true));
                                rowObj.Cells.Add((Aspose.Words.Tables.Cell)cellObj.Clone(true));
                            }
                            for (int t = 0; t < rowCount - 1; t++)
                            {
                                Aspose.Words.Tables.Row row = (Aspose.Words.Tables.Row)table.Rows[table.Rows.Count - 1].Clone(true);
                                table.Rows.Add(row);
                            }

                            //创建列标题
                            int colIndex = 1;
                            foreach (Step step in projectStepList)
                            {
                                table.Rows[0].Cells[colIndex].RemoveAllChildren();
                                table.Rows[0].Cells[colIndex].AppendChild(wu.GetCellContentObj(table, "阶段" + step.StepIndex + "(" + step.StepTime + "个月)"));
                                //table.Cell(1, colIndex).VerticalAlignment = Microsoft.Office.Interop.Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;
                                colIndex++;
                            }

                            //创建数据
                            int rowIndex = 1;
                            foreach (KeyValuePair<string, Project> kvp in ketiMap)
                            {
                                if (kvp.Key == "项目")
                                {
                                    continue;
                                }

                                int totalMoney = 0;
                                //获取并填冲数据
                                int dataColIndex = 1;
                                List<Step> curStepList = ConnectionManager.Context.table("Step").where("ProjectID = '" + kvp.Value.ID + "'").select("*").getList<Step>(new Step());
                                foreach (Step curStep in curStepList)
                                {
                                    ProjectAndStep curProjectAndStep = ConnectionManager.Context.table("ProjectAndStep").where("StepID = '" + curStep.ID + "'").select("*").getItem<ProjectAndStep>(new ProjectAndStep());

                                    //输出格式
                                    string outputFormat = "完成内容及阶段目标:\n{0}\n阶段成果、考核指标及考核方式:\n{1}\n阶段经费:{2}万";

                                    string resultStr = string.Empty;
                                    //阶段数据
                                    if (kvp.Key == "项目")
                                    {
                                        resultStr = string.Format(outputFormat, curStep.StepDest, curStep.StepResult, curStep.StepMoney);
                                    }
                                    else
                                    {
                                        resultStr = string.Format(outputFormat, curProjectAndStep.StepDest, curProjectAndStep.StepResult, curProjectAndStep.Money);

                                        //计算总金额
                                        totalMoney += (int)curProjectAndStep.Money;
                                    }

                                    table.Rows[rowIndex].Cells[dataColIndex].RemoveAllChildren();
                                    table.Rows[rowIndex].Cells[dataColIndex].AppendChild(wu.GetCellContentObj(table, resultStr));
                                    dataColIndex++;
                                }

                                //行标题
                                if (kvp.Key != "项目")
                                {
                                    table.Rows[rowIndex].Cells[0].RemoveAllChildren();
                                    table.Rows[rowIndex].Cells[0].AppendChild(wu.GetCellContentObj(table, kvp.Key + "(" + totalMoney + "万)"));
                                }
                                else
                                {
                                    table.Rows[rowIndex].Cells[0].RemoveAllChildren();
                                    table.Rows[rowIndex].Cells[0].AppendChild(wu.GetCellContentObj(table, kvp.Key));
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
                    NodeCollection ncc = wu.Document.WordDoc.GetChildNodes(Aspose.Words.NodeType.Table, true);
                    foreach (Aspose.Words.Tables.Table table in ncc)
                    {
                        if (table.Range.Text.Contains("年投入"))
                        {
                            //获得课题与研究骨干关系表
                            List<Task> taskList = ConnectionManager.Context.table("Task").where("ProjectID in (select ID from Project where ParentID = '" + MainForm.Instance.ProjectObj.ID + "') or ProjectID='" + MainForm.Instance.ProjectObj.ID + "'").orderBy("DisplayOrder").select("*").getList<Task>(new Task());

                            //生成行和列
                            int rowCount = taskList.Count;
                            //table.Select();
                            for (int k = 0; k < rowCount - 1; k++)
                            {
                                table.Rows.Add((Aspose.Words.Tables.Row)table.Rows[table.Rows.Count - 1].Clone(true));
                            }

                            //填冲数据
                            int rowIndex = 1;
                            foreach (Task curTask in taskList)
                            {
                                #region 提取人员信息
                                Project taskKeti = ConnectionManager.Context.table("Project").where("ID='" + curTask.ProjectID + "'").select("*").getItem<Project>(new Project());
                                Person person = ConnectionManager.Context.table("Person").where("ID='" + curTask.PersonID + "'").select("*").getItem<Person>(new Person());
                                Unit unit = ConnectionManager.Context.table("Unit").where("ID='" + person.UnitID + "'").select("*").getItem<Unit>(new Unit());
                                #endregion

                                table.Rows[rowIndex].Cells[0].RemoveAllChildren();
                                table.Rows[rowIndex].Cells[1].RemoveAllChildren();
                                table.Rows[rowIndex].Cells[2].RemoveAllChildren();
                                table.Rows[rowIndex].Cells[3].RemoveAllChildren();
                                table.Rows[rowIndex].Cells[4].RemoveAllChildren();
                                table.Rows[rowIndex].Cells[5].RemoveAllChildren();
                                table.Rows[rowIndex].Cells[6].RemoveAllChildren();
                                table.Rows[rowIndex].Cells[7].RemoveAllChildren();
                                table.Rows[rowIndex].Cells[8].RemoveAllChildren();
                                table.Rows[rowIndex].Cells[9].RemoveAllChildren();

                                table.Rows[rowIndex].Cells[0].AppendChild(wu.GetCellContentObj(table, rowIndex.ToString()));
                                table.Rows[rowIndex].Cells[1].AppendChild(wu.GetCellContentObj(table, person.Name));
                                table.Rows[rowIndex].Cells[2].AppendChild(wu.GetCellContentObj(table, person.Sex));
                                table.Rows[rowIndex].Cells[3].AppendChild(wu.GetCellContentObj(table, person.Job));
                                table.Rows[rowIndex].Cells[4].AppendChild(wu.GetCellContentObj(table, person.Specialty));
                                table.Rows[rowIndex].Cells[5].AppendChild(wu.GetCellContentObj(table, unit.UnitName));
                                table.Rows[rowIndex].Cells[6].AppendChild(wu.GetCellContentObj(table, curTask.TotalTime.ToString()));
                                table.Rows[rowIndex].Cells[7].AppendChild(wu.GetCellContentObj(table, curTask.Content));
                                table.Rows[rowIndex].Cells[8].AppendChild(wu.GetCellContentObj(table, person.IDCard));

                                string KetiInProject = string.Empty;
                                foreach (KeyValuePair<string, Project> kvp in ketiMap)
                                {
                                    if (kvp.Value.ID == curTask.ProjectID)
                                    {
                                        KetiInProject = kvp.Key + curTask.Role;
                                        break;
                                    }
                                }
                                table.Rows[rowIndex].Cells[9].AppendChild(wu.GetCellContentObj(table, KetiInProject));

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
                        bookmark = "ProjectRFA1_3_1";
                        obj4 = pbinfo.ProjectRFA1_3_1;
                        wu.InsertValue(bookmark, obj4 != null ? obj4.ToString() : "0");
                        bookmark = "ProjectRFA1_3_2";
                        obj4 = pbinfo.ProjectRFA1_3_2;
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
                        bookmark = "ProjectRFA1_3_1Rm";
                        obj4 = pbinfo.ProjectRFA1_3_1rm;
                        wu.InsertValue(bookmark, obj4 != null ? obj4.ToString() : string.Empty);
                        bookmark = "ProjectRFA1_3_2Rm";
                        obj4 = pbinfo.ProjectRFA1_3_2rm;
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
                    NodeCollection ncc = wu.Document.WordDoc.GetChildNodes(Aspose.Words.NodeType.Table, true);
                    foreach (Aspose.Words.Tables.Table table in ncc)
                    {
                        if (table.Range.Text.Contains("各课题联系方式"))
                        {
                            int titleIndex = table.Rows.Count - 1;
                            int dataIndex = table.Rows.Count - 1;

                            //构造联系方式行
                            int rowCountt = (ketiList.Count * 3) - 1;
                            for (int k = 0; k < rowCountt; k++)
                            {
                                //table.Select();
                                table.Rows.Add((Aspose.Words.Tables.Row)table.Rows[table.Rows.Count -1].Clone(true));
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
                                    table.Rows[rowStart].Cells[0].RemoveAllChildren();
                                    table.Rows[rowStart].Cells[0].AppendChild(wu.GetCellContentObj(table, "课题" + chsNumbers[(k + 1)]));
                                    //table.Rows[rowStart].Cells[1).VerticalAlignment = Microsoft.Office.Interop.Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;

                                    //table.Rows[rowStart].Cells[1).Select();
                                    //wu.Applicaton.Selection.ParagraphFormat.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphCenter;

                                    table.Rows[rowStart].Cells[1].RemoveAllChildren();
                                    table.Rows[rowStart].Cells[1].AppendChild(wu.GetCellContentObj(table, "负责人"));
                                    //table.Rows[rowStart].Cells[2).VerticalAlignment = Microsoft.Office.Interop.Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;

                                    //table.Rows[rowStart].Cells[2).Select();
                                    //wu.Applicaton.Selection.ParagraphFormat.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphCenter;

                                    table.Rows[rowStart].Cells[3].RemoveAllChildren();
                                    table.Rows[rowStart].Cells[3].AppendChild(wu.GetCellContentObj(table, "性别"));
                                    //table.Rows[rowStart].Cells[4).VerticalAlignment = Microsoft.Office.Interop.Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;

                                    //table.Rows[rowStart].Cells[4).Select();
                                    //wu.Applicaton.Selection.ParagraphFormat.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphCenter;

                                    table.Rows[rowStart].Cells[5].RemoveAllChildren();
                                    table.Rows[rowStart].Cells[5].AppendChild(wu.GetCellContentObj(table, "出生年月"));
                                    //table.Rows[rowStart].Cells[6).VerticalAlignment = Microsoft.Office.Interop.Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;

                                    //table.Rows[rowStart].Cells[6).Select();
                                    //wu.Applicaton.Selection.ParagraphFormat.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphCenter;

                                    table.Rows[rowStart + 1].Cells[1].RemoveAllChildren();
                                    table.Rows[rowStart + 1].Cells[1].AppendChild(wu.GetCellContentObj(table, "职务职称"));
                                    //table.Rows[rowStart + 1].Cells[2).VerticalAlignment = Microsoft.Office.Interop.Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;

                                    //table.Rows[rowStart + 1].Cells[2).Select();
                                    //wu.Applicaton.Selection.ParagraphFormat.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphCenter;

                                    table.Rows[rowStart + 1].Cells[3].RemoveAllChildren();
                                    table.Rows[rowStart + 1].Cells[3].AppendChild(wu.GetCellContentObj(table, "技术方向"));
                                    //table.Rows[rowStart + 1].Cells[4).VerticalAlignment = Microsoft.Office.Interop.Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;

                                    //table.Rows[rowStart + 1].Cells[4).Select();
                                    //wu.Applicaton.Selection.ParagraphFormat.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphCenter;

                                    table.Rows[rowStart + 1].Cells[5].RemoveAllChildren();
                                    table.Rows[rowStart + 1].Cells[5].AppendChild(wu.GetCellContentObj(table, "手机"));
                                    //table.Rows[rowStart + 1].Cells[6).VerticalAlignment = Microsoft.Office.Interop.Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;

                                    //table.Rows[rowStart + 1].Cells[6).Select();
                                    //wu.Applicaton.Selection.ParagraphFormat.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphCenter;

                                    table.Rows[rowStart + 2].Cells[1].RemoveAllChildren();
                                    table.Rows[rowStart + 2].Cells[1].AppendChild(wu.GetCellContentObj(table, "承担单位及通信地址"));
                                    //table.Cell(rowStart + 2, 2).VerticalAlignment = Microsoft.Office.Interop.Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;

                                    //table.Cell(rowStart + 2, 2).Select();
                                    //wu.Applicaton.Selection.ParagraphFormat.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphCenter;

                                    #endregion

                                    #region 写入实际数据
                                    Project proj = ketiList[k];
                                    Unit unitObj = ConnectionManager.Context.table("Unit").where("ID='" + proj.UnitID + "'").select("*").getItem<Unit>(new Unit());
                                    Task taskObj = ConnectionManager.Context.table("Task").where("ProjectID = '" + proj.ID + "' and Type='课题' and Role='负责人'").select("*").getItem<Task>(new Task());
                                    Person personObj = ConnectionManager.Context.table("Person").where("ID ='" + taskObj.PersonID + "'").select("*").getItem<Person>(new Person());

                                    table.Rows[rowStart].Cells[2].RemoveAllChildren();
                                    table.Rows[rowStart].Cells[2].AppendChild(wu.GetCellContentObj(table, personObj.Name));
                                    //table.Rows[rowStart].Cells[3).VerticalAlignment = Microsoft.Office.Interop.Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;

                                    //table.Rows[rowStart].Cells[3).Select();
                                    //wu.Applicaton.Selection.ParagraphFormat.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphLeft;

                                    table.Rows[rowStart].Cells[4].RemoveAllChildren();
                                    table.Rows[rowStart].Cells[4].AppendChild(wu.GetCellContentObj(table, personObj.Sex));
                                    //table.Rows[rowStart].Cells[5).VerticalAlignment = Microsoft.Office.Interop.Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;

                                    //table.Rows[rowStart].Cells[5).Select();
                                    //wu.Applicaton.Selection.ParagraphFormat.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphLeft;

                                    table.Rows[rowStart].Cells[6].RemoveAllChildren();
                                    table.Rows[rowStart].Cells[6].AppendChild(wu.GetCellContentObj(table, personObj.Birthday != null ? personObj.Birthday.Value.ToString("yyyy-MM-dd") : string.Empty));
                                    //table.Rows[rowStart].Cells[7).VerticalAlignment = Microsoft.Office.Interop.Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;

                                    //table.Rows[rowStart].Cells[7).Select();
                                    //wu.Applicaton.Selection.ParagraphFormat.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphLeft;

                                    table.Rows[rowStart + 1].Cells[2].RemoveAllChildren();
                                    table.Rows[rowStart + 1].Cells[2].AppendChild(wu.GetCellContentObj(table, personObj.Job));
                                    //table.Rows[rowStart + 1].Cells[3).VerticalAlignment = Microsoft.Office.Interop.Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;

                                    //table.Rows[rowStart + 1].Cells[3).Select();
                                    //wu.Applicaton.Selection.ParagraphFormat.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphLeft;

                                    table.Rows[rowStart + 1].Cells[4].RemoveAllChildren();
                                    table.Rows[rowStart + 1].Cells[4].AppendChild(wu.GetCellContentObj(table, personObj.Specialty));
                                    //table.Rows[rowStart + 1].Cells[5).VerticalAlignment = Microsoft.Office.Interop.Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;

                                    //table.Rows[rowStart + 1].Cells[5).Select();
                                    //wu.Applicaton.Selection.ParagraphFormat.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphLeft;

                                    table.Rows[rowStart + 1].Cells[6].RemoveAllChildren();
                                    table.Rows[rowStart + 1].Cells[6].AppendChild(wu.GetCellContentObj(table, personObj.MobilePhone));
                                    //table.Rows[rowStart + 1].Cells[7).VerticalAlignment = Microsoft.Office.Interop.Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;

                                    //table.Rows[rowStart + 1].Cells[7).Select();
                                    //wu.Applicaton.Selection.ParagraphFormat.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphLeft;

                                    table.Rows[rowStart + 2].Cells[2].RemoveAllChildren();
                                    table.Rows[rowStart + 2].Cells[2].AppendChild(wu.GetCellContentObj(table, unitObj.UnitName + "," + unitObj.Address));
                                    //table.Cell(rowStart + 2, 3).VerticalAlignment = Microsoft.Office.Interop.Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;

                                    //table.Cell(rowStart + 2, 3).Select();
                                    //wu.Applicaton.Selection.ParagraphFormat.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphLeft;

                                    #endregion

                                    //合并单元格
                                    wu.Document.mergeCells(table.Rows[rowEnd].Cells[2], table.Rows[rowEnd].Cells[6], table);
                                    wu.Document.mergeCells(table.Rows[rowStart].Cells[0], table.Rows[rowEnd].Cells[0], table);
                                }
                            }
                            else
                            {
                                table.Rows[titleIndex].Remove();
                                table.Rows[dataIndex].Remove();
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

                //try
                //{   
                //    wu.WordDoc.Styles["目录 1"].Font.NameFarEast = "黑体";
                //    wu.WordDoc.Styles["目录 1"].Font.Size = 14;
                //    wu.WordDoc.Styles["目录 1"].Font.Bold = 0;
                //    wu.WordDoc.Styles["目录 1"].Font.Italic = 0;

                //    wu.WordDoc.Styles["目录 2"].Font.NameFarEast = "楷体";
                //    wu.WordDoc.Styles["目录 2"].Font.NameAscii = wu.WordDoc.Styles["目录 1"].Font.NameAscii;
                //    wu.WordDoc.Styles["目录 2"].Font.NameBi = wu.WordDoc.Styles["目录 1"].Font.NameBi;
                //    wu.WordDoc.Styles["目录 2"].Font.NameOther = wu.WordDoc.Styles["目录 1"].Font.NameOther;
                //    wu.WordDoc.Styles["目录 2"].Font.Size = 12;
                //    wu.WordDoc.Styles["目录 2"].Font.Bold = 0;
                //    wu.WordDoc.Styles["目录 2"].Font.Italic = 0;

                //    wu.WordDoc.Styles["目录 3"].Font.NameFarEast = "楷体";
                //    wu.WordDoc.Styles["目录 3"].Font.NameAscii = wu.WordDoc.Styles["目录 1"].Font.NameAscii;
                //    wu.WordDoc.Styles["目录 3"].Font.NameBi = wu.WordDoc.Styles["目录 1"].Font.NameBi;
                //    wu.WordDoc.Styles["目录 3"].Font.NameOther = wu.WordDoc.Styles["目录 1"].Font.NameOther;
                //    wu.WordDoc.Styles["目录 3"].Font.Size = 12;
                //    wu.WordDoc.Styles["目录 3"].Font.Bold = 0;
                //    wu.WordDoc.Styles["目录 3"].Font.Italic = 0;

                //    object missing = System.Reflection.Missing.Value;
                //    Microsoft.Office.Interop.Word.Range myRange = wu.WordDoc.TablesOfContents[1].Range;
                //    wu.WordDoc.TablesOfContents[1].Delete();                    
                //    object useHeadingStyle = true; //使用Head样式
                //    object upperHeadingLevel = 1;  //最大一级
                //    object lowerHeadingLevel = 2;  //最小三级
                //    object useHypeLinks = true;
                //    //TablesOfContents的Add方法添加目录
                //    wu.WordDoc.TablesOfContents.Add(myRange, ref useHeadingStyle,
                //        ref upperHeadingLevel, ref lowerHeadingLevel,
                //        ref missing, ref missing, ref missing, ref missing,
                //        ref missing, ref useHypeLinks, ref missing, ref missing);
                //    wu.WordDoc.TablesOfContents[1].TabLeader = Microsoft.Office.Interop.Word.WdTabLeader.wdTabLeaderDots;
                //}
                //catch (Exception ex) { }

                //wu.WordDoc.ResetFormFields();
                //wu.WordDoc.Fields.Update();
                wu.Document.WordDoc.UpdateFields();
                wu.Document.WordDoc.UpdateListLabels();
                wu.Document.WordDoc.UpdatePageLayout();
                wu.Document.WordDoc.UpdateTableLayout();
                wu.Document.WordDoc.UpdateThumbnail();
                wu.Document.WordDoc.UpdateWordCount();
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
            //try
            //{
            //    Bitmap bmp = new Bitmap(imageFile);
            //    Clipboard.SetDataObject(bmp);
            //    DataFormats.Format dataFormat = DataFormats.GetFormat(DataFormats.Bitmap);
            //    if (richTextObj.CanPaste(dataFormat))
            //    {
            //        richTextObj.Paste(dataFormat);
            //    }

            //    richTextObj.SelectAll();
            //    richTextObj.SetLineSpace(25);

            //    richTextObj.SaveFile(tempRTFFile);
            //}
            //catch (Exception exc)
            //{
            //    System.Console.WriteLine(exc.ToString());
            //}
        }
    }
}