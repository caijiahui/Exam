using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace advt.WinService
{
    public partial class ServiceTest : ServiceBase
    {
        System.Timers.Timer timer1;

        public static bool isStart { get; set; } = false;

        public static string localpath { get; set; }

        public ServiceTest()
        {
            InitializeComponent();
            localpath = Config.BaseConfigs.GetBaseConfig().ReportServicePath;
        }
        protected override void OnStart(string[] args)
        {
            timer1 = new System.Timers.Timer();
            timer1.Interval = 20000;
            timer1.Elapsed += new System.Timers.ElapsedEventHandler(TMStart_Elapsed);
            timer1.Enabled = true;
            timer1.Start();
        }
        protected override void OnStop()
        {
            this.timer1.Enabled = false;
        }
        protected override void OnPause()
        {
            base.OnPause();
        }
        protected override void OnContinue()
        {
            base.OnContinue();
        }
        protected override void OnShutdown()
        {
            base.OnShutdown();
        }
        private void TMStart_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            if (isStart)
            {
                return;
            }

            isStart = true;
            var path = $"{localpath}\\Waiting_Write";
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
                                Data.TestReport.Insert_TestReport(model, null, new string[] { "id" });
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    isStart = false;
                    string errorpath = $"{localpath}\\Error\\error.txt";

                    StreamWriter sw = new StreamWriter(errorpath, true, Encoding.Default); //此处false为新写入的文件覆盖以前的文件,改为true就是追加.
                    sw.WriteLine(OrignFile + ex);
                    sw.Close();

                    throw;
                }

            }

            isStart = false;
        }
    }
}
