using System;
using System.Data;
using System.Linq;
using advt.Entity;
using System.Collections.Generic;


namespace advt.Data
{
    public partial class advt_posts1
    {

        #region advt_posts1 , (Ver:2.3.8) at: 2018/5/5 17:38:29

        public static List<Entity.advt_posts1> Get_All_advt_posts1(object objparams)
        {
            IDataReader reader = DatabaseProvider.GetInstance().Get_All_advt_posts1(objparams);
            return SqlHelper.GetReaderToList<Entity.advt_posts1>(reader);
        }

        public static List<Entity.advt_posts1> Get_All_advt_posts1()
        {
            return Get_All_advt_posts1(null);
        }

        public static Entity.advt_posts1 Get_advt_posts1(object objparams)
        {
            IDataReader reader = DatabaseProvider.GetInstance().Get_All_advt_posts1(objparams);
            return SqlHelper.GetReaderToFirstOrDefault<Entity.advt_posts1>(reader);
        }

        public static Entity.advt_posts1 Get_advt_posts1(int id)
        {
            return Get_advt_posts1(new { id = id });
        }

        public static int Insert_advt_posts1(Entity.advt_posts1 info)
        {
            return Insert_advt_posts1(info, null, null);
        }

        public static int Insert_advt_posts1(Entity.advt_posts1 info, string[] Include)
        {
            return Insert_advt_posts1(info, Include, null);
        }

        public static int Insert_advt_posts1(Entity.advt_posts1 info, string[] Include, string[] Exclude)
        {
            return DatabaseProvider.GetInstance().Insert_advt_posts1(info, Include, Exclude);
        }

        public static int Update_advt_posts1(Entity.advt_posts1 info)
        {
            return Update_advt_posts1(info, null, null);
        }

        public static int Update_advt_posts1(Entity.advt_posts1 info, string[] Include)
        {
            return Update_advt_posts1(info, Include, null);
        }

        public static int Update_advt_posts1(Entity.advt_posts1 info, string[] Include, string[] Exclude)
        {
            return DatabaseProvider.GetInstance().Update_advt_posts1(info, Include, Exclude);
        }

        public static int Delete_advt_posts1(int id)
        {
            return DatabaseProvider.GetInstance().Delete_advt_posts1(id);
        }
        #endregion
    }
}