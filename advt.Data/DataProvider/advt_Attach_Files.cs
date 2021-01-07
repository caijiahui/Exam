//using System;
//using System.Data;
//using System.Linq;
//using advt.Entity;
//using System.Collections.Generic;


//namespace advt.Data
//{
//    public partial class advt_Attach_Files
//    {

//        #region advt_Attach_Files , (Ver:2.3.8) at: 2018/5/10 14:41:37

//        public static List<Entity.advt_Attach_Files> Get_All_advt_Attach_FilesInfo(string id)
//        {
//            IDataReader reader = DatabaseProvider.GetInstance().Get_All_advt_Attach_Files(id);
//            return SqlHelper.GetReaderToList<Entity.advt_Attach_Files>(reader);
//        }

//        public static List<Entity.advt_Attach_Files> Get_All_advt_Attach_FilesInfo(object objparams)
//        {
//            IDataReader reader = DatabaseProvider.GetInstance().Get_All_advt_Attach_Files(objparams);
//            return SqlHelper.GetReaderToList<Entity.advt_Attach_Files>(reader);
//        }

//        public static List<Entity.advt_Attach_Files> Get_All_advt_Attach_Files()
//        {
//            return Get_All_advt_Attach_Files();
//        }

//        public static Entity.advt_Attach_Files Get_advt_Attach_FilesInfo(object objparams)
//        {
//            IDataReader reader = DatabaseProvider.GetInstance().Get_All_advt_Attach_Files(objparams);
//            return SqlHelper.GetReaderToFirstOrDefault<Entity.advt_Attach_Files>(reader);
//        }

//        public static Entity.advt_Attach_Files Get_advt_Attach_FilesInfo(string id)
//        {
//            return Get_advt_Attach_FilesInfo(new { id = id });
//        }

//        public static int Insert_advt_Attach_FilesInfo(Entity.advt_Attach_Files info)
//        {
//            return Insert_advt_Attach_FilesInfo(info, null, null);
//        }

//        public static int Insert_advt_Attach_FilesInfo(Entity.advt_Attach_Files info, string[] Include)
//        {
//            return Insert_advt_Attach_FilesInfo(info, Include, null);
//        }

//        public static int Insert_advt_Attach_FilesInfo(Entity.advt_Attach_Files info, string[] Include, string[] Exclude)
//        {
//            return DatabaseProvider.GetInstance().Insert_advt_Attach_Files(info, Include, Exclude);
//        }

//        public static int Update_advt_Attach_Files(Entity.advt_Attach_Files info)
//        {
//            return Update_advt_Attach_Files(info, null, null);
//        }

//        public static int Update_advt_Attach_Files(Entity.advt_Attach_Files info, string[] Include)
//        {
//            return Update_advt_Attach_Files(info, Include, null);
//        }

//        public static int Update_advt_Attach_Files(Entity.advt_Attach_Files info, string[] Include, string[] Exclude)
//        {
//            return DatabaseProvider.GetInstance().Update_advt_Attach_Files(info, Include, Exclude);
//        }

//        public static int Delete_advt_Attach_Files(string id)
//        {
//            return DatabaseProvider.GetInstance().Delete_advt_Attach_Files(id);
//        }
//        #endregion
//    }
//}