using System;
using System.Data;
using System.Linq;
using advt.Entity;
using System.Collections.Generic;


namespace advt.Data
{
    public partial class advt_Category
    {

        #region advt_Category , (Ver:2.3.8) at: 2018/5/5 17:38:29

        public static List<Entity.advt_Category> Get_All_advt_Category(object objparams)
        {
            IDataReader reader = DatabaseProvider.GetInstance().Get_All_advt_Category(objparams);
            return SqlHelper.GetReaderToList<Entity.advt_Category>(reader);
        }

        public static List<Entity.advt_Category> Get_All_advt_Category()
        {
            return Get_All_advt_Category(null);
        }

        public static Entity.advt_Category Get_advt_Category(object objparams)
        {
            IDataReader reader = DatabaseProvider.GetInstance().Get_All_advt_Category(objparams);
            return SqlHelper.GetReaderToFirstOrDefault<Entity.advt_Category>(reader);
        }

        public static Entity.advt_Category Get_advt_Category(int id)
        {
            return Get_advt_Category(new { id = id });
        }

        public static int Insert_advt_Category(Entity.advt_Category info)
        {
            return Insert_advt_Category(info, null, null);
        }

        public static int Insert_advt_Category(Entity.advt_Category info, string[] Include)
        {
            return Insert_advt_Category(info, Include, null);
        }

        public static int Insert_advt_Category(Entity.advt_Category info, string[] Include, string[] Exclude)
        {
            return DatabaseProvider.GetInstance().Insert_advt_Category(info, Include, Exclude);
        }

        public static int Update_advt_Category(Entity.advt_Category info)
        {
            return Update_advt_Category(info, null, null);
        }

        public static int Update_advt_Category(Entity.advt_Category info, string[] Include)
        {
            return Update_advt_Category(info, Include, null);
        }

        public static int Update_advt_Category(Entity.advt_Category info, string[] Include, string[] Exclude)
        {
            return DatabaseProvider.GetInstance().Update_advt_Category(info, Include, Exclude);
        }

        public static int Delete_advt_Category(int id)
        {
            return DatabaseProvider.GetInstance().Delete_advt_Category(id);
        }
        #endregion
    }
}