using System;
using System.Data;
using System.Linq;
using advt.Entity;
using System.Collections.Generic;


namespace advt.Data
{
    public partial class advt_users
    {
        public static int Update_advt_users_LastIP(int Userid, string FromIP)
        {
            return DatabaseProvider.GetInstance().Update_advt_users_LastIP(Userid, FromIP);
        }

        #region advt_users , (Ver:2.3.8) at: 2018/5/5 17:38:29

        public static List<Entity.advt_users> Get_All_advt_users(object objparams)
        {
            IDataReader reader = DatabaseProvider.GetInstance().Get_All_advt_users(objparams);
            return SqlHelper.GetReaderToList<Entity.advt_users>(reader);
        }

        public static List<Entity.advt_users> Get_All_advt_users()
        {
            return Get_All_advt_users(null);
        }

        public static Entity.advt_users Get_advt_users(object objparams)
        {
            IDataReader reader = DatabaseProvider.GetInstance().Get_All_advt_users(objparams);
            return SqlHelper.GetReaderToFirstOrDefault<Entity.advt_users>(reader);
        }

        public static Entity.advt_users Get_advt_users(int id)
        {
            return Get_advt_users(new { id = id });
        }
        public static Entity.advt_users Get_advt_user(string username,string password)
        {
            return Get_advt_users(new { username,password });
        }

        public static int Insert_advt_users(Entity.advt_users info)
        {
            return Insert_advt_users(info, null, null);
        }

        public static int Insert_advt_users(Entity.advt_users info, string[] Include)
        {
            return Insert_advt_users(info, Include, null);
        }

        public static int Insert_advt_users(Entity.advt_users info, string[] Include, string[] Exclude)
        {
            return DatabaseProvider.GetInstance().Insert_advt_users(info, Include, Exclude);
        }

        public static int Update_advt_users(Entity.advt_users info)
        {
            return Update_advt_users(info, null, null);
        }

        public static int Update_advt_users(Entity.advt_users info, string[] Include)
        {
            return Update_advt_users(info, Include, null);
        }

        public static int Update_advt_users(Entity.advt_users info, string[] Include, string[] Exclude)
        {
            return DatabaseProvider.GetInstance().Update_advt_users(info, Include, Exclude);
        }

        public static int Delete_advt_users(int id)
        {
            return DatabaseProvider.GetInstance().Delete_advt_users(id);
        }
        #endregion
    }
}