using System;
using System.Data;
using System.Linq;
using advt.Entity;
using System.Collections.Generic;


namespace advt.Data
{
    public partial class ExamType
    {
        #region ExamType , (Ver:2.3.8) at: 2021/1/7 15:58:19

        public static List<Entity.ExamType> Get_All_ExamType(object objparams)
        {
            IDataReader reader = DatabaseProvider.GetInstance().Get_All_ExamType(objparams);
            return SqlHelper.GetReaderToList<Entity.ExamType>(reader);
        }

        public static List<Entity.ExamType> Get_All_ExamType()
        {
            return Get_All_ExamType(null);
        }

        public static Entity.ExamType Get_ExamType(object objparams)
        {
            IDataReader reader = DatabaseProvider.GetInstance().Get_All_ExamType(objparams);
            return SqlHelper.GetReaderToFirstOrDefault<Entity.ExamType>(reader);
        }

        public static Entity.ExamType Get_ExamType(int ID)
        {
            return Get_ExamType(new { ID = ID });
        }

        public static int Insert_ExamType(Entity.ExamType info)
        {
            return Insert_ExamType(info, null, null);
        }

        public static int Insert_ExamType(Entity.ExamType info, string[] Include)
        {
            return Insert_ExamType(info, Include, null);
        }

        public static int Insert_ExamType(Entity.ExamType info, string[] Include, string[] Exclude)
        {
            return DatabaseProvider.GetInstance().Insert_ExamType(info, Include, Exclude);
        }

        public static int Update_ExamType(Entity.ExamType info)
        {
            return Update_ExamType(info, null, null);
        }

        public static int Update_ExamType(Entity.ExamType info, string[] Include)
        {
            return Update_ExamType(info, Include, null);
        }

        public static int Update_ExamType(Entity.ExamType info, string[] Include, string[] Exclude)
        {
            return DatabaseProvider.GetInstance().Update_ExamType(info, Include, Exclude);
        }

        public static int Delete_ExamType(int ID)
        {
            return DatabaseProvider.GetInstance().Delete_ExamType(ID);
        }
        #endregion
    }
}