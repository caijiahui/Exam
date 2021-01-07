using System;
using System.Data;
using System.Linq;
using advt.Entity;
using System.Collections.Generic;


namespace advt.Data
{
    public partial class advt_user_group
    {

        #region advt_user_group , (Ver:2.3.8) at: 2018/5/5 17:38:29

        public static List<Entity.advt_user_group> Get_All_advt_user_group(object objparams)
        {
            IDataReader reader = DatabaseProvider.GetInstance().Get_All_advt_user_group(objparams);
            return SqlHelper.GetReaderToList<Entity.advt_user_group>(reader);
        }

        public static List<Entity.advt_user_group> Get_All_advt_user_group()
        {
            string Key = Cache.CacheKeys.CMS_ADVT_USER_GROUP;

            Cache.WbCache wc = Cache.WbCache.GetCacheService();
            List<Entity.advt_user_group> ladvt_user_group = wc.RetrieveObject(Key) as List<Entity.advt_user_group>;

            if (ladvt_user_group == null)
            {
                ladvt_user_group = Get_All_advt_user_group(null);
                wc.AddObject(Key, ladvt_user_group, 6000);
            }

            return ladvt_user_group;
        }

        public static Entity.advt_user_group Get_advt_user_group(object objparams)
        {
            IDataReader reader = DatabaseProvider.GetInstance().Get_All_advt_user_group(objparams);
            return SqlHelper.GetReaderToFirstOrDefault<Entity.advt_user_group>(reader);
        }

        public static Entity.advt_user_group Get_advt_user_group(int id)
        {
            return Get_advt_user_group(new { id = id });
        }

        public static int Insert_advt_user_group(Entity.advt_user_group info)
        {
            return Insert_advt_user_group(info, null, null);
        }

        public static int Insert_advt_user_group(Entity.advt_user_group info, string[] Include)
        {
            return Insert_advt_user_group(info, Include, null);
        }

        public static int Insert_advt_user_group(Entity.advt_user_group info, string[] Include, string[] Exclude)
        {
            return DatabaseProvider.GetInstance().Insert_advt_user_group(info, Include, Exclude);
        }

        public static int Update_advt_user_group(Entity.advt_user_group info)
        {
            return Update_advt_user_group(info, null, null);
        }

        public static int Update_advt_user_group(Entity.advt_user_group info, string[] Include)
        {
            return Update_advt_user_group(info, Include, null);
        }

        public static int Update_advt_user_group(Entity.advt_user_group info, string[] Include, string[] Exclude)
        {
            return DatabaseProvider.GetInstance().Update_advt_user_group(info, Include, Exclude);
        }

        public static int Delete_advt_user_group(int id)
        {
            return DatabaseProvider.GetInstance().Delete_advt_user_group(id);
        }
        #endregion
    }
}