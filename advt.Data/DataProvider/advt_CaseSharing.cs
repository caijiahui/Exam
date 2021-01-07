using System;
using System.Data;
using System.Linq;
using advt.Entity;
using System.Collections.Generic;


namespace advt.Data
{
    public partial class advt_users_type
    {

        #region advt_users_type , (Ver:2.3.8) at: 2018/5/22 10:15:17

        public static List<Entity.advt_users_type> Get_All_advt_users_type(int id)
        {
            IDataReader reader = DatabaseProvider.GetInstance().Get_All_advt_users_type(id);
            return SqlHelper.GetReaderToList<Entity.advt_users_type>(reader);
        }
        public static List<Entity.advt_users_type> Get_advt_users_type_join_user(int PageSize, int pageIndex,string username)
        {
            IDataReader reader = DatabaseProvider.GetInstance().Get_advt_users_type_join_user(PageSize,pageIndex,username);
            return SqlHelper.GetReaderToList<Entity.advt_users_type>(reader);
        }
        public static List<Entity.advt_users_type> Get_All_advt_users_type(object objparams)
        {
            IDataReader reader = DatabaseProvider.GetInstance().Get_All_advt_users_type(objparams);
            return SqlHelper.GetReaderToList<Entity.advt_users_type>(reader);
        }

        public static List<Entity.advt_users_type> Get_All_advt_users_type()
        {
            return Get_All_advt_users_type(null);
        }

        public static Entity.advt_users_type Get_advt_users_type(object objparams)
        {
            IDataReader reader = DatabaseProvider.GetInstance().Get_All_advt_users_type(objparams);
            return SqlHelper.GetReaderToFirstOrDefault<Entity.advt_users_type>(reader);
        }

        public static Entity.advt_users_type Get_advt_users_type(int id)
        {
            return Get_advt_users_type(new { id = id });
        }
        public static Entity.advt_users_type Get_advt_users_type(string username)
        {
            return Get_advt_users_type(new { username = username });
        }

        public static int Insert_advt_users_type(Entity.advt_users_type info)
        {
            return Insert_advt_users_type(info, null, null);
        }

        public static int Insert_advt_users_type(Entity.advt_users_type info, string[] Include)
        {
            return Insert_advt_users_type(info, Include, null);
        }

        public static int Insert_advt_users_type(Entity.advt_users_type info, string[] Include, string[] Exclude)
        {
            return DatabaseProvider.GetInstance().Insert_advt_users_type(info, Include, Exclude);
        }
        public static int Update_advt_users_type_username(Entity.advt_users_type info)
        {
            return DatabaseProvider.GetInstance().Update_advt_users_type_username(info);
        }

        public static int Update_advt_users_type(Entity.advt_users_type info)
        {
            return Update_advt_users_type(info, null, null);
        }

        public static int Update_advt_users_type(Entity.advt_users_type info, string[] Include)
        {
            return Update_advt_users_type(info, Include, null);
        }

        public static int Update_advt_users_type(Entity.advt_users_type info, string[] Include, string[] Exclude)
        {
            return DatabaseProvider.GetInstance().Update_advt_users_type(info, Include, Exclude);
        }

        public static int Delete_advt_users_type(int id)
        {
            return DatabaseProvider.GetInstance().Delete_advt_users_type(id);
        }
        #endregion
    }
}