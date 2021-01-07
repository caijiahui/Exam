using System;
using System.Data;
using System.Linq;
using advt.Entity;
using System.Collections.Generic;

namespace advt.Data
{
    public partial class TestReport
    {

        #region TestReport , (Ver:2.3.8) at: 2018/6/4 14:36:56

        public static List<Entity.TestReport> Get_All_TestReport(int id)
        {
            IDataReader reader = DatabaseProvider.GetInstance().Get_All_TestReport(id);
            return SqlHelper.GetReaderToList<Entity.TestReport>(reader);
        }

        public static List<Entity.TestReport> Get_All_TestReport(object objparams)
        {
            IDataReader reader = DatabaseProvider.GetInstance().Get_All_TestReport(objparams);
            return SqlHelper.GetReaderToList<Entity.TestReport>(reader);
        }

        public static List<Entity.TestReport> Get_All_TestReport()
        {
            return Get_All_TestReport(null);
        }

        public static Entity.TestReport Get_TestReport(object objparams)
        {
            IDataReader reader = DatabaseProvider.GetInstance().Get_All_TestReport(objparams);
            return SqlHelper.GetReaderToFirstOrDefault<Entity.TestReport>(reader);
        }
        public static Entity.TestReport Get_Test(string name)
        {
            IDataReader reader = DatabaseProvider.GetInstance().Get_Test_R(name);
            return SqlHelper.GetReaderToFirstOrDefault<Entity.TestReport>(reader);
        }

        public static Entity.TestReport Get_TestReport(int id)
        {
            return Get_TestReport(new { id = id });
        }
        public static Entity.TestReport Get_TestReport(string name)
        {
            return Get_TestReport(new { name = name });
        }

        public static int Insert_TestReport(Entity.TestReport info)
        {
            return Insert_TestReport(info, null, null);
        }

        public static int Insert_TestReport(Entity.TestReport info, string[] Include)
        {
            return Insert_TestReport(info, Include, null);
        }

        public static int Insert_TestReport(Entity.TestReport info, string[] Include, string[] Exclude)
        {
            return DatabaseProvider.GetInstance().Insert_TestReport(info, Include, Exclude);
        }

        public static int Update_TestReport(Entity.TestReport info)
        {
            return Update_TestReport(info, null, null);
        }
        public static int Update_TestReport_Name(Entity.TestReport info)
        {
            return DatabaseProvider.GetInstance().Update_TestReport_Name(info);
        }

        public static int Update_TestReport(Entity.TestReport info, string[] Include)
        {
            return Update_TestReport(info, Include, null);
        }


        public static int Update_TestReport(Entity.TestReport info, string[] Include, string[] Exclude)
        {
            return DatabaseProvider.GetInstance().Update_TestReport(info, Include, Exclude);
        }

        public static int Delete_TestReport(int id)
        {
            return DatabaseProvider.GetInstance().Delete_TestReport(id);
        }
        #endregion
    }
}