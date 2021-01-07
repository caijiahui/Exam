using System;
using System.Data;
using System.Linq;
using advt.Entity;
using System.Collections.Generic;


namespace advt.Data
{
    public partial class ExamSubject
    {

        #region ExamSubject , (Ver:2.3.8) at: 2021/1/7 16:05:32

        public static List<Entity.ExamSubject> Get_All_ExamSubject(object objparams)
        {
            IDataReader reader = DatabaseProvider.GetInstance().Get_All_ExamSubject(objparams);
            return SqlHelper.GetReaderToList<Entity.ExamSubject>(reader);
        }

        public static List<Entity.ExamSubject> Get_All_ExamSubject()
        {
            return Get_All_ExamSubject(null);
        }

        public static Entity.ExamSubject Get_ExamSubject(object objparams)
        {
            IDataReader reader = DatabaseProvider.GetInstance().Get_All_ExamSubject(objparams);
            return SqlHelper.GetReaderToFirstOrDefault<Entity.ExamSubject>(reader);
        }

        public static Entity.ExamSubject Get_ExamSubject(int ID)
        {
            return Get_ExamSubject(new { ID = ID });
        }

        public static int Insert_ExamSubject(Entity.ExamSubject info)
        {
            return Insert_ExamSubject(info, null, null);
        }

        public static int Insert_ExamSubject(Entity.ExamSubject info, string[] Include)
        {
            return Insert_ExamSubject(info, Include, null);
        }

        public static int Insert_ExamSubject(Entity.ExamSubject info, string[] Include, string[] Exclude)
        {
            return DatabaseProvider.GetInstance().Insert_ExamSubject(info, Include, Exclude);
        }

        public static int Update_ExamSubject(Entity.ExamSubject info)
        {
            return Update_ExamSubject(info, null, null);
        }

        public static int Update_ExamSubject(Entity.ExamSubject info, string[] Include)
        {
            return Update_ExamSubject(info, Include, null);
        }

        public static int Update_ExamSubject(Entity.ExamSubject info, string[] Include, string[] Exclude)
        {
            return DatabaseProvider.GetInstance().Update_ExamSubject(info, Include, Exclude);
        }

        public static int Delete_ExamSubject(int ID)
        {
            return DatabaseProvider.GetInstance().Delete_ExamSubject(ID);
        }
        #endregion
    }
}