using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.IO;
using Aspose.Words;
using Microsoft.Win32;

namespace ProjectReporter.Utility
{
    public class WordUtility
    {
        public WordDocument WordDoc { get; set; }

        /// <summary>
        /// 通过模板创建新文件
        /// </summary>
        /// <param name="filePath"></param>
        public void CreateNewDocument(string filePath)
        {
            WordDoc = new WordDocument(filePath);
        }

        /// <summary>
        /// 保存文档
        /// </summary>
        /// <param name="filePath"></param>
        public void SaveDocument(string filePath)
        {
            WordDoc.WordDoc.Save(filePath, SaveFormat.Doc);
        }

        /// <summary>
        /// 选择书签
        /// </summary>
        /// <param name="bookmark">书签</param>
        /// <returns></returns>
        public bool SelectBookMark(string bookmark)
        {
            return WordDoc.WordDocBuilder.MoveToBookmark(bookmark);
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
            if (WordDoc.WordDocBuilder.MoveToBookmark(bookmark))
            {
                WordDoc.WordDocBuilder.Write(value);
                return true;
            }
            return true;
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
            if (WordDoc.WordDocBuilder.MoveToBookmark(bookmark))
            {
                //保存先前的设置
                double lastSize = WordDoc.WordDocBuilder.Font.Size;
                bool lastBold = WordDoc.WordDocBuilder.Font.Bold;
                bool lastItalic = WordDoc.WordDocBuilder.Font.Italic;
                Underline lastUnderline = WordDoc.WordDocBuilder.Font.Underline;

                //设置字号及是否加粗
                WordDoc.WordDocBuilder.Font.Size = fontSize;
                WordDoc.WordDocBuilder.Font.Bold = isBold;
                WordDoc.WordDocBuilder.Font.Italic = isItalic;
                WordDoc.WordDocBuilder.Font.Underline = isUnderline ? Underline.Single : Underline.None;

                WordDoc.WordDocBuilder.Write(value);

                //恢复先前的设置
                WordDoc.WordDocBuilder.Font.Size = lastSize;
                WordDoc.WordDocBuilder.Font.Bold = lastBold;
                WordDoc.WordDocBuilder.Font.Italic = lastItalic;
                WordDoc.WordDocBuilder.Font.Underline = lastUnderline;

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
                object bkObj = bookmark;
                if (File.Exists(filePath))
                {
                    if (WordDoc.WordDocBuilder.MoveToBookmark(bookmark))
                    {
                        WordDoc.insertDocumentAfterBookMark(new Document(filePath), bookmark, enabledDeleteEnterFlag);
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

        public void Delete()
        {
            //object objValue = System.Reflection.Missing.Value;
            //wordApp.Selection.Delete(ref objValue, ref objValue);
        }

        public void DeleteCurrentAll()
        {
            //object _unitObj = Microsoft.Office.Interop.Word.WdUnits.wdLine;
            //object _extendObj = Microsoft.Office.Interop.Word.WdMovementType.wdExtend;

            //wordApp.Selection.EndKey(ref _unitObj, ref _extendObj);

            //object objValue = System.Reflection.Missing.Value;
            //wordApp.Selection.Delete(ref objValue, ref objValue);
        }

        public void DeleteCurrentAndLast()
        {
            //object _unitObj = Microsoft.Office.Interop.Word.WdUnits.wdLine;
            //object _countObj = 1;
            //object _extendObj = Microsoft.Office.Interop.Word.WdMovementType.wdExtend;

            //wordApp.Selection.MoveUp(ref _unitObj, ref _countObj,ref _extendObj);

            //object objValue = System.Reflection.Missing.Value;
            //wordApp.Selection.Delete(ref objValue, ref objValue);
        }

        /// <summary> 
        /// 字符串替换A 
        /// </summary> 
        /// <param name="strOld">旧的</param> 
        /// <param name="strNew">新的</param> 
        public void ReplaceA(string strOld, string strNew)
        {
            WordDoc.WordDoc.Range.Replace(strOld, strNew, false, false);
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
                if (WordDoc.WordDocBuilder.MoveToBookmark(bookmark))
                {
                    WordDoc.WordDocBuilder.InsertImage(picturePath);
                }
            }
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

        /// <summary>
        /// 通过注册表检测office版本
        /// </summary>
        /// <param name="OfficeVersion">储存office版本的字符串</param>
        /// <returns></returns>
        public static bool OfficeIsInstall(out string OfficeVersion)
        {
            OfficeVersion = "";
            Microsoft.Win32.RegistryKey regKey = null;
            Microsoft.Win32.RegistryKey regSubKey2 = null;
            Microsoft.Win32.RegistryKey regSubKey3 = null;

            regKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry32);
            regSubKey2 = regKey.OpenSubKey(@"SOFTWARE\Microsoft\Office\12.0\Common\InstallRoot", false);
            regSubKey3 = regKey.OpenSubKey(@"SOFTWARE\Microsoft\Office\14.0\Common\InstallRoot", false);
            if (regSubKey3 != null && regSubKey3.GetValue("Path") != null)
            {
                OfficeVersion = "2010";
                return true;
            }
            else if (regSubKey2 != null && regSubKey2.GetValue("Path") != null)
            {
                OfficeVersion = "2007";
                return true;
            }
            else
            {

                regKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64);
                regSubKey2 = regKey.OpenSubKey(@"SOFTWARE\Microsoft\Office\12.0\Common\InstallRoot", false);
                regSubKey3 = regKey.OpenSubKey(@"SOFTWARE\Microsoft\Office\14.0\Common\InstallRoot", false);
                if (regSubKey3 != null && regSubKey3.GetValue("Path") != null)
                {
                    OfficeVersion = "2010";
                    return true;
                }
                else if (regSubKey2 != null && regSubKey2.GetValue("Path") != null)
                {
                    OfficeVersion = "2007";
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }
}