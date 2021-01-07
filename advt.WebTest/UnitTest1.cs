using System;
using System.Diagnostics;
using System.IO;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace advt.WebTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var path = @"E:\Production\CTOS_Test_Report\Waiting_Write";
            var files = Directory.GetDirectories(path);
            DirectoryInfo dir = new DirectoryInfo(files[0]);
            var allfiles = dir.GetFiles("*.htm", SearchOption.AllDirectories);
            var month = DateTime.Now.Month;
            var year = DateTime.Now.Year;
            foreach (FileInfo FileName in allfiles)//第二个参数表示搜索包含子目录中的文件；
            {
                var OrignFile = FileName.FullName;
                try
                {
                    var DirectoryName = FileName.DirectoryName;
                    var testname = FileName.ToString().Substring(0, FileName.ToString().IndexOf("."));
                    var exists = Data.TestReport.Get_Test(testname);
                    if (exists == null)
                    {
                        Encoding encode = Encoding.GetEncoding("GB2312");
                        using (FileStream fs = new FileStream(OrignFile, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                        {
                            using (StreamReader myStreamReader = new StreamReader(fs, encode))
                            {
                                string strhtml = myStreamReader.ReadToEnd();
                                Entity.TestReport model = new Entity.TestReport();
                                model.name = testname;
                                model.content = strhtml;
                                model.createdate = DateTime.Now;
                                myStreamReader.Dispose();
                                //Data.TestReport.Insert_TestReport(model, null, new string[] { "id" });

                            }
                        }
                        var day = DateTime.Now.Day;
                        string daycompletepath = @"E:\Production\CTOS_Test_Report\DayCompleted\" + year + month + day;
                        string daycompletefilename = daycompletepath + @"\" + FileName;
                        if (!Directory.Exists(daycompletepath))
                        {
                            Directory.CreateDirectory(daycompletepath);  //创建目录
                        }
                        if (File.Exists(daycompletefilename))
                        {
                            if (File.GetAttributes(daycompletefilename).ToString().IndexOf("ReadOnly") != -1)
                                File.SetAttributes(daycompletefilename, FileAttributes.Normal);
                            File.Delete(daycompletefilename);//不能删除只读文件
                        }
                        File.Move(OrignFile, daycompletefilename);
                    }
                    else
                    {
                        string completepath = @"E:\Production\CTOS_Test_Report\Completed\" + year + month;
                        string completefilename = completepath + @"\" + FileName;
                        if (!Directory.Exists(completepath))
                        {
                            Directory.CreateDirectory(completepath);  //创建目录
                        }
                        //if (File.Exists(completefilename))
                        //{
                        //    if (File.GetAttributes(completefilename).ToString().IndexOf("ReadOnly") != -1)
                        //        File.SetAttributes(completefilename, FileAttributes.Normal);
                        //    File.Delete(completefilename);//不能删除只读文件
                        //}
                        File.Move(OrignFile, completefilename);
                    }
                }
                catch (Exception ex)
                {
                    string errorpath = @"E:\Production\CTOS_Test_Report\Error\error.txt";
                    //string errorpath = @"D:\Production\Attachment\Error\" + year + month;
                    //if (!Directory.Exists(errorpath))
                    //{
                    //    Directory.CreateDirectory(errorpath);  //创建目录
                    //}
                    StreamWriter sw = new StreamWriter(errorpath, true, Encoding.Default); //此处false为新写入的文件覆盖以前的文件,改为true就是追加.
                    sw.WriteLine(OrignFile + ex);
                    sw.Close();
                    //string errorfilename = errorpath + @"\" + FileName;
                    //File.Move(OrignFile, errorpath);
                    throw;
                }
            }
        


    }
    }
}
