using System;
using System.Data;
using System.Linq;
using advt.Entity;
using System.Collections.Generic;


namespace advt.Data
{
    public partial class advt_page
    {

        public static List<Entity.advt_page> Get_All_advt_page_By_UserGroup_Cache(int user_group_id)
        {
            string Key = Cache.CacheKeys.CMS_ADVT_PAGE + "/USERGROUPID" + user_group_id;
            Cache.WbCache wc = Cache.WbCache.GetCacheService();
            List<Entity.advt_page> ladvt_page = wc.RetrieveObject(Key) as List<Entity.advt_page>;
            if (ladvt_page == null)
            {
                ladvt_page = Get_All_advt_page_By_UserGroup(user_group_id);
                wc.AddObject(Key, ladvt_page, 3600);
            }
            return ladvt_page;
        }

        public static List<Entity.advt_page> Get_All_advt_page_By_UserGroup(int user_group_id)
        {
            IDataReader reader = DatabaseProvider.GetInstance().Get_All_advt_page_By_UserGroup(user_group_id);
            return SqlHelper.GetReaderToList<Entity.advt_page>(reader);
        }

        #region advt_page , (Ver:2.3.8) at: 2018/5/5 17:38:29

        public static List<Entity.advt_page> Get_All_advt_page(object objparams)
        {
            IDataReader reader = DatabaseProvider.GetInstance().Get_All_advt_page(objparams);
            return SqlHelper.GetReaderToList<Entity.advt_page>(reader);
        }

        public static List<Entity.advt_page> Get_All_advt_page()
        {
            return Get_All_advt_page(null);
        }

        public static Entity.advt_page Get_advt_page(object objparams)
        {
            IDataReader reader = DatabaseProvider.GetInstance().Get_All_advt_page(objparams);
            return SqlHelper.GetReaderToFirstOrDefault<Entity.advt_page>(reader);
        }

        public static Entity.advt_page Get_advt_page(int id)
        {
            return Get_advt_page(new { id = id });
        }

        public static int Insert_advt_page(Entity.advt_page info)
        {
            return Insert_advt_page(info, null, null);
        }

        public static int Insert_advt_page(Entity.advt_page info, string[] Include)
        {
            return Insert_advt_page(info, Include, null);
        }

        public static int Insert_advt_page(Entity.advt_page info, string[] Include, string[] Exclude)
        {
            return DatabaseProvider.GetInstance().Insert_advt_page(info, Include, Exclude);
        }

        public static int Update_advt_page(Entity.advt_page info)
        {
            return Update_advt_page(info, null, null);
        }

        public static int Update_advt_page(Entity.advt_page info, string[] Include)
        {
            return Update_advt_page(info, Include, null);
        }

        public static int Update_advt_page(Entity.advt_page info, string[] Include, string[] Exclude)
        {
            return DatabaseProvider.GetInstance().Update_advt_page(info, Include, Exclude);
        }

        public static int Delete_advt_page(int id)
        {
            return DatabaseProvider.GetInstance().Delete_advt_page(id);
        }
        #endregion
    }
}