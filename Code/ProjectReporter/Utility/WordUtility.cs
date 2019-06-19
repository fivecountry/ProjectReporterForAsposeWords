﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.IO;
using Microsoft.Office.Interop.Word;

namespace ProjectReporter.Utility
{
    public class WordUtility
    {
        private _Application wordApp = null;
        private _Document wordDoc = null;

        public _Application Applicaton
        {
            get { return wordApp; }
            set { wordApp = value; }
        }

        public _Document WordDoc
        {
            get { return wordDoc; }
            set { wordDoc = value; }
        }

        /// <summary>
        /// 通过模板创建新文件
        /// </summary>
        /// <param name="filePath"></param>
        public void CreateNewDocument(string filePath)
        {
            //killWnWordProcess();
            wordApp = new ApplicationClass();
            wordApp.DisplayAlerts = WdAlertLevel.wdAlertsNone;
            wordApp.Visible = false;
            object missing = System.Reflection.Missing.Value;
            object templateName = filePath;
            wordDoc = wordApp.Documents.Open(ref templateName, ref missing,
                ref missing, ref missing, ref missing, ref missing, ref missing,
                ref missing, ref missing, ref missing, ref missing, ref missing,
                ref missing, ref missing, ref missing, ref missing);
        }

        /// <summary>
        /// 保存文档
        /// </summary>
        /// <param name="filePath"></param>
        public void SaveDocument(string filePath)
        {
            object fileName = filePath;
            object format = WdSaveFormat.wdFormatDocument; //保存格式
            object missing = System.Reflection.Missing.Value;
            wordDoc.SaveAs(ref fileName, ref format, ref missing,
                ref missing, ref missing, ref missing, ref missing, ref missing,
                ref missing, ref missing, ref missing, ref missing, ref missing,
                ref missing, ref missing, ref missing);
            //关闭wordDoc,wordApp对象
            object saveChanges = WdSaveOptions.wdSaveChanges;
            object originalFormat = WdOriginalFormat.wdOriginalDocumentFormat;
            object routeDocument = false;
            wordDoc.Close(ref saveChanges, ref originalFormat, ref routeDocument);
            wordApp.Quit(ref saveChanges, ref originalFormat, ref routeDocument);
        }

        /// <summary>
        /// 选择书签
        /// </summary>
        /// <param name="bookmark">书签</param>
        /// <returns></returns>
        public bool SelectBookMark(string bookmark)
        {
            object bkObj = bookmark;
            if (wordApp.ActiveDocument.Bookmarks.Exists(bookmark))
            {
                wordApp.ActiveDocument.Bookmarks.get_Item(ref bkObj).Select();
                return true;
            }
            return false;
        }

        public void AddBookMark(string bookMarkName)
        {
            Microsoft.Office.Interop.Word.Range r = wordApp.Selection.Range;
            object rng = (object)r;
            wordApp.ActiveDocument.Bookmarks.Add(bookMarkName, ref rng);
            wordApp.ActiveDocument.Bookmarks.DefaultSorting = 0;
            wordApp.ActiveDocument.Bookmarks.ShowHidden = false;
        }

        /// <summary>
        /// 在书签处插入值
        /// </summary>
        /// <param name="bookmark">书签</param>
        /// <param name="value">要插入的值</param>
        /// <returns></returns>
        public bool InsertValue(string bookmark, string value)
        {
            object bkObj = bookmark;
            if (wordApp.ActiveDocument.Bookmarks.Exists(bookmark))
            {
                wordApp.ActiveDocument.Bookmarks.get_Item(ref bkObj).Select();
                wordApp.Selection.TypeText(value);
                return true;
            }
            return false;
        }

        /// <summary>
        /// 在书签处插入值(改变字体在小及是否加粗)
        /// </summary>
        /// <param name="bookmark">书签</param>
        /// <param name="value">要插入的值</param>
        /// <returns></returns>
        public bool InsertValue(string bookmark, string value, int fontSize, bool isBold)
        {
            object bkObj = bookmark;
            if (wordApp.ActiveDocument.Bookmarks.Exists(bookmark))
            {
                wordApp.ActiveDocument.Bookmarks.get_Item(ref bkObj).Select();

                //保存先前的设置
                float lastSize = wordApp.Selection.Font.Size;
                int lastBold = wordApp.Selection.Font.Bold;

                //设置字号及是否加粗
                wordApp.Selection.Font.Size = fontSize;
                wordApp.Selection.Font.Bold = isBold ? 1 : 0;

                wordApp.Selection.TypeText(value);

                //恢复先前的设置
                wordApp.Selection.Font.Size = lastSize;
                wordApp.Selection.Font.Bold = lastBold;

                return true;
            }
            return false;
        }

        /// <summary>
        /// 在书签处插入值(改变字体在小及是否加粗)
        /// </summary>
        /// <param name="bookmark">书签</param>
        /// <param name="value">要插入的值</param>
        /// <returns></returns>
        public bool InsertValue(string bookmark, string value, int fontSize, bool isBold, bool isItalic)
        {
            object bkObj = bookmark;
            if (wordApp.ActiveDocument.Bookmarks.Exists(bookmark))
            {
                wordApp.ActiveDocument.Bookmarks.get_Item(ref bkObj).Select();

                //保存先前的设置
                float lastSize = wordApp.Selection.Font.Size;
                int lastBold = wordApp.Selection.Font.Bold;
                int lastItalic = wordApp.Selection.Font.Italic;

                //设置字号及是否加粗
                wordApp.Selection.Font.Size = fontSize;
                wordApp.Selection.Font.Bold = isBold ? 1 : 0;
                wordApp.Selection.Font.Italic = isItalic ? 1 : 0;

                wordApp.Selection.TypeText(value);

                //恢复先前的设置
                wordApp.Selection.Font.Size = lastSize;
                wordApp.Selection.Font.Bold = lastBold;
                wordApp.Selection.Font.Italic = lastItalic;

                return true;
            }
            return false;
        }

        /// <summary>
        /// 在书签处插入值(改变字体在小及是否加粗)
        /// </summary>
        /// <param name="bookmark">书签</param>
        /// <param name="value">要插入的值</param>
        /// <returns></returns>
        public bool InsertValue(string bookmark, string value, int fontSize, bool isBold, bool isItalic, bool isUnderline)
        {
            object bkObj = bookmark;
            if (wordApp.ActiveDocument.Bookmarks.Exists(bookmark))
            {
                wordApp.ActiveDocument.Bookmarks.get_Item(ref bkObj).Select();

                //保存先前的设置
                float lastSize = wordApp.Selection.Font.Size;
                int lastBold = wordApp.Selection.Font.Bold;
                int lastItalic = wordApp.Selection.Font.Italic;
                WdUnderline lastUnderline = wordApp.Selection.Font.Underline;

                //设置字号及是否加粗
                wordApp.Selection.Font.Size = fontSize;
                wordApp.Selection.Font.Bold = isBold ? 1 : 0;
                wordApp.Selection.Font.Italic = isItalic ? 1 : 0;
                wordApp.Selection.Font.Underline = isUnderline ? WdUnderline.wdUnderlineSingle : WdUnderline.wdUnderlineNone;

                wordApp.Selection.TypeText(value);

                //恢复先前的设置
                wordApp.Selection.Font.Size = lastSize;
                wordApp.Selection.Font.Bold = lastBold;
                wordApp.Selection.Font.Italic = lastItalic;
                wordApp.Selection.Font.Underline = lastUnderline;

                return true;
            }
            return false;
        }

        /// <summary>
        /// 在书签处插入文件
        /// </summary>
        /// <param name="bookmark">书签</param>
        /// <param name="value">要插入的文件路径</param>
        /// <returns></returns>
        public bool InsertFile(string bookmark, string filePath, bool enabledDeleteEnterFlag)
        {
            if (File.Exists(filePath))
            {
                object value = System.Reflection.Missing.Value;
                object bkObj = bookmark;
                if (File.Exists(filePath))
                {
                    if (wordApp.ActiveDocument.Bookmarks.Exists(bookmark))
                    {
                        wordApp.ActiveDocument.Bookmarks.get_Item(ref bkObj).Select();
                        wordApp.Selection.InsertFile(filePath, ref value, ref value, ref value, ref value);

                        if (enabledDeleteEnterFlag)
                        {
                            wordApp.Selection.Delete(ref value, ref value);
                        }
                        return true;
                    }
                }
                return false;
            }
            else
            {
                return false;
            }
        }

        public void CopyCurrent()
        {
            object _unitObj = Microsoft.Office.Interop.Word.WdUnits.wdLine;
            object _extendObj = Microsoft.Office.Interop.Word.WdMovementType.wdExtend;

            //复制这个标签的内容
            wordApp.Selection.EndKey(ref _unitObj, ref _extendObj);
            wordApp.Selection.Copy();
        }

        public void NewLine()
        {
            wordApp.Selection.TypeParagraph();
        }

        public void SetText(string text)
        {
            //输入文字
            wordApp.Selection.TypeText(text);
        }

        public void PasteAndFormat()
        {
            //粘贴内容
            wordApp.Selection.PasteAndFormat(WdRecoveryType.wdPasteDefault);
        }

        public void Delete()
        {
            object objValue = System.Reflection.Missing.Value;
            wordApp.Selection.Delete(ref objValue, ref objValue);
        }

        public void DeleteCurrentAll()
        {
            object _unitObj = Microsoft.Office.Interop.Word.WdUnits.wdLine;
            object _extendObj = Microsoft.Office.Interop.Word.WdMovementType.wdExtend;

            wordApp.Selection.EndKey(ref _unitObj, ref _extendObj);

            object objValue = System.Reflection.Missing.Value;
            wordApp.Selection.Delete(ref objValue, ref objValue);
        }

        public void DeleteCurrentAndLast()
        {
            object _unitObj = Microsoft.Office.Interop.Word.WdUnits.wdLine;
            object _countObj = 1;
            object _extendObj = Microsoft.Office.Interop.Word.WdMovementType.wdExtend;

            wordApp.Selection.MoveUp(ref _unitObj, ref _countObj,ref _extendObj);

            object objValue = System.Reflection.Missing.Value;
            wordApp.Selection.Delete(ref objValue, ref objValue);
        }

        /// <summary>
        /// 替换指定文本
        /// </summary>
        /// <param name="dicts">Key=关键字,Value实际内容</param>
        public void ReplaceAll(Dictionary<string, string> dicts)
        {
            if (dicts != null)
            {
                foreach (var item in dicts)
                {
                    ReplaceA(item.Key.Trim(), item.Value.Trim());
                }
            }
        }

        /// <summary> 
        /// 字符串替换A 
        /// </summary> 
        /// <param name="strOld">旧的</param> 
        /// <param name="strNew">新的</param> 
        public void ReplaceA(string strOld, string strNew)
        {
            object _nullobj = System.Reflection.Missing.Value;
            wordApp.Selection.Find.ClearFormatting();
            wordApp.Selection.Find.Replacement.ClearFormatting();
            wordApp.Selection.Find.Text = strOld;
            wordApp.Selection.Find.Replacement.Text = strNew;
            //wordApp.Selection.Find.Replacement.Text = "{%TEMPLATE%}"; 
            //wordApp.Selection.TypeText(strNew); 

            object objReplace = Microsoft.Office.Interop.Word.WdReplace.wdReplaceAll;
            wordApp.Selection.Find.Execute(ref _nullobj, ref _nullobj, ref _nullobj,
                                       ref _nullobj, ref _nullobj, ref _nullobj,
                                       ref _nullobj, ref _nullobj, ref _nullobj,
                                       ref _nullobj, ref objReplace, ref _nullobj,
                                       ref _nullobj, ref _nullobj, ref _nullobj);
        }

        /// <summary> 
        /// 字符串替换A 
        /// </summary> 
        /// <param name="strOld">旧的</param> 
        /// <param name="strNew">新的</param> 
        public void ReplaceB(string strOld, string strNew)
        {
            wordApp.Selection.Find.ClearFormatting();
            wordApp.Selection.Find.Replacement.ClearFormatting();
            wordApp.Selection.Find.Text = strOld;
            //wordApp.Selection.Find.Replacement.Text = strNew; 
            wordApp.Selection.Find.Replacement.Text = strNew;
            //wordApp.Selection.Find.Execute(); 
            wordApp.Selection.TypeText(strNew);

            //  object objReplace = Microsoft.Office.Interop.Word.WdReplace.wdReplaceAll; 
            // _app.Selection.Find.Execute(ref _nullobj, ref _nullobj, ref _nullobj, 
            //ref _nullobj, ref _nullobj, ref _nullobj, 
            //ref _nullobj, ref _nullobj, ref _nullobj, 
            //ref _nullobj, ref objReplace, ref _nullobj, 
            //ref _nullobj, ref _nullobj, ref _nullobj); 
        }

        /// <summary>
        ///插入表格
        /// </summary>
        /// <param name="bookmark">书签</param>
        /// <param name="rows"></param>
        /// <param name="columns"></param>
        /// <param name="width"></param>
        /// <returns></returns>
        public Table InsertTable(string bookmark, int rows, int columns, float width)
        {
            object miss = System.Reflection.Missing.Value;
            object oStart = bookmark;
            Range range = wordDoc.Bookmarks.get_Item(ref oStart).Range; //表格插入位置
            Table newTable = wordDoc.Tables.Add(range, rows, columns, ref miss, ref miss);
            newTable.Borders.Enable = 1;//允许有边框，默认没有边框，（1，实现边框，2/3，虚线边框）
            newTable.Borders.OutsideLineWidth = WdLineWidth.wdLineWidth050pt;//边框宽度
            if (width != 0)
            {
                newTable.PreferredWidth = width; //表格宽度
            }
            newTable.AllowPageBreaks = false;
            return newTable;
        }

        /// <summary>
        /// 合并单元格
        /// </summary>
        /// <param name="table">表</param>
        /// <param name="row1">开始行号</param>
        /// <param name="column1">开始列号</param>
        /// <param name="row2">结束行号</param>
        /// <param name="column2">结束列号</param>
        public void MergeCell(Microsoft.Office.Interop.Word.Table table, int row1, int column1, int row2, int column2)
        {
            table.Cell(row1, column1).Merge(table.Cell(row2, column2));
        }

        /// <summary>
        /// 设置表格内容对齐方式
        /// </summary>
        /// <param name="table">表</param>
        /// <param name="Align">水平方向：-1，左对齐；0,居中；1,右对齐</param>
        /// <param name="Vertical">垂直方向：-1，顶端;0,居中；1,底端</param>
        public void SetParagraph_Table(Microsoft.Office.Interop.Word.Table table, int Align, int Vertical)
        {
            switch (Align)
            {
                case -1:
                    table.Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphLeft;
                    break;
                case 0:
                    table.Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
                    break;
                case 1:
                    table.Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphRight;
                    break;
            }
            switch (Vertical)
            {
                case -1:
                    table.Range.Cells.VerticalAlignment = WdCellVerticalAlignment.wdCellAlignVerticalTop;
                    break;
                case 0:
                    table.Range.Cells.VerticalAlignment = WdCellVerticalAlignment.wdCellAlignVerticalCenter;
                    break;
                case 1:
                    table.Range.Cells.VerticalAlignment = WdCellVerticalAlignment.wdCellAlignVerticalBottom;
                    break;
            }
        }

        /// <summary>
        /// 设置表格字体
        /// </summary>
        /// <param name="table"></param>
        /// <param name="fontName"></param>
        /// <param name="size"></param>
        public void SetFont_Table(Microsoft.Office.Interop.Word.Table table, string fontName, double size)
        {
            if (size != 0)
            {
                table.Range.Font.Size = Convert.ToSingle(size);
            }
            if (fontName != "")
                table.Range.Font.Name = fontName;
        }

        /// <summary>
        /// 是否使用边框
        /// </summary>
        /// <param name="n">表格的序号</param>
        /// <param name="use">是或否</param>
        public void UseBroder(int n, bool use)
        {
            if (use)
                wordDoc.Content.Tables[n].Borders.Enable = 1;
            else
                wordDoc.Content.Tables[n].Borders.Enable = 2;
        }

        /// <summary>
        /// 给第n个表格添加行
        /// </summary>
        /// <param name="n"></param>
        public void AddRow(int n)
        {
            object miss = System.Reflection.Missing.Value;
            wordDoc.Content.Tables[n].Rows.Add(ref miss);
        }

        /// <summary>
        /// 给表格添加一行
        /// </summary>
        /// <param name="table"></param>
        public void AddRows(Microsoft.Office.Interop.Word.Table table)
        {
            object miss = System.Reflection.Missing.Value;
            table.Rows.Add(ref miss);
        }

        /// <summary>
        /// 给表格添加行
        /// </summary>
        /// <param name="n">第n个表格</param>
        /// <param name="rows">添加的行数</param>
        public void AddRow(int n, int rows)
        {
            object miss = System.Reflection.Missing.Value;
            Microsoft.Office.Interop.Word.Table table = wordDoc.Content.Tables[n];
            for (int i = 0; i < rows; i++)
            {
                table.Rows.Add(ref miss);
            }
        }

        /// <summary>
        /// 填充表格的单元格
        /// </summary>
        /// <param name="table">表格</param>
        /// <param name="row">行号</param>
        /// <param name="column">列号</param>
        /// <param name="value">插入的内容</param>
        public void InsertCell(Microsoft.Office.Interop.Word.Table table, int row, int column, string value)
        {
            table.Cell(row, column).Range.Text = value;
        }

        /// <summary>
        /// 给文档中第n个表格插入内容
        /// </summary>
        /// <param name="n"></param>
        /// <param name="row">行号</param>
        /// <param name="column">列号</param>
        /// <param name="value">插入的内容</param>
        public void InsertCell(int n, int row, int column, string value)
        {
            wordDoc.Content.Tables[n].Cell(row, column).Range.Text = value;

        }

        /// <summary>
        /// 给表格插入一行数据
        /// </summary>
        /// <param name="n">文档中表格的序号</param>
        /// <param name="row">行号</param>
        /// <param name="columns">列数</param>
        /// <param name="values">插入的值</param>
        public void InsertCell(int n, int row, int columns, string[] values)
        {
            Microsoft.Office.Interop.Word.Table table = wordDoc.Content.Tables[n];
            for (int i = 0; i < columns; i++)
                table.Cell(row, i + 1).Range.Text = values[i];
        }

        /// <summary>
        /// 插入图片
        /// </summary>
        /// <param name="bookmark"></param>
        /// <param name="picturePath"></param>
        /// <param name="width"></param>
        /// <param name="hight"></param>
        public void InsertPicture(string bookmark, string picturePath, float width, float hight)
        {
            if (File.Exists(picturePath))
            {
                object miss = System.Reflection.Missing.Value;
                object oStart = bookmark;
                object linkToFile = false; //图片不为外部链接
                object saveWithDocment = true; //图片随文档一起保存
                object range = wordDoc.Bookmarks.get_Item(ref oStart).Range; //图片插入位置
                wordDoc.InlineShapes.AddPicture(picturePath, ref linkToFile, ref saveWithDocment, ref range);
                wordDoc.Application.ActiveDocument.InlineShapes[1].Width = width;
                wordDoc.Application.ActiveDocument.InlineShapes[1].Height = hight;
            }
        }

        /// <summary>
        /// 插入图片
        /// </summary>
        /// <param name="bookmark"></param>
        /// <param name="picturePath"></param>
        public void InsertPicture(string bookmark, string picturePath)
        {
            if (File.Exists(picturePath))
            {
                object miss = System.Reflection.Missing.Value;
                object oStart = bookmark;
                object linkToFile = false; //图片不为外部链接
                object saveWithDocment = true; //图片随文档一起保存
                object range = wordDoc.Bookmarks.get_Item(ref oStart).Range; //图片插入位置
                wordDoc.InlineShapes.AddPicture(picturePath, ref linkToFile, ref saveWithDocment, ref range);
            }
        }

        /// <summary>
        /// 插入一段文字
        /// </summary>
        /// <param name="bookmark"></param>
        /// <param name="text"></param>
        public void InsertText(string bookmark, string text)
        {
            object oStart = bookmark;
            object range = wordDoc.Bookmarks.get_Item(ref oStart).Range;
            Paragraph wp = wordDoc.Content.Paragraphs.Add(ref range);
            wp.Format.SpaceBefore = 6;
            wp.Range.Text = text;
            wp.Format.SpaceAfter = 24;
            wp.Range.InsertParagraphAfter();
            wordDoc.Paragraphs.Last.Range.Text = "\n";
        }

        /// <summary>
        /// 关闭Word进程
        /// </summary>
        public void killWnWordProcess()
        {
            System.Diagnostics.Process[] processes = System.Diagnostics.Process.GetProcessesByName("WINWORD");
            foreach (System.Diagnostics.Process process in processes)
            {
                bool b = process.MainWindowTitle == "";
                if (process.MainWindowTitle == "")
                {
                    process.Kill();
                }
            }
        }
    }
}