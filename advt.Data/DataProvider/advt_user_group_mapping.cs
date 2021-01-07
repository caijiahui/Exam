using System;
using System.Data;
using System.Linq;
using advt.Entity;
using System.Collections.Generic;


namespace advt.Data
{
    public partial class advt_user_group_mapping
    {

        #region advt_user_group_mapping , (Ver:2.3.8) at: 2018/5/5 17:38:29

        public static List<Entity.advt_user_group_mapping> Get_All_advt_user_group_mapping(object objparams)
        {
            IDataReader reader = DatabaseProvider.GetInstance().Get_All_advt_user_group_mapping(objparams);
            return SqlHelper.GetReaderToList<Entity.advt_user_group_mapping>(reader);
        }

        public static List<Entity.advt_user_group_mapping> Get_All_advt_user_group_mapping()
        {
            return Get_All_advt_user_group_mapping(null);
        }

        public static Entity.advt_user_group_mapping Get_advt_user_group_mapping(object objparams)
        {
            IDataReader reader = DatabaseProvider.GetInstance().Get_All_advt_user_group_mapping(objparams);
            return SqlHelper.GetReaderToFirstOrDefault<Entity.advt_user_group_mapping>(reader);
        }

        public static Entity.advt_user_group_mapping Get_advt_user_group_mapping(int id)
        {
            return Get_advt_user_group_mapping(new { id = id });
        }

        public static int Insert_advt_user_group_mapping(Entity.advt_user_group_mapping info)
        {
            return Insert_advt_user_group_mapping(info, null, null);
        }

        public static int Insert_advt_user_group_mapping(Entity.advt_user_group_mapping info, string[] Include)
        {
            return Insert_advt_user_group_mapping(info, Include, null);
        }

        public static int Insert_advt_user_group_mapping(Entity.advt_user_group_mapping info, string[] Include, string[] Exclude)
        {
            return DatabaseProvider.GetInstance().Insert_advt_user_group_mapping(info, Include, Exclude);
        }

        public static int Update_advt_user_group_mapping(Entity.advt_user_group_mapping info)
        {
            return Update_advt_user_group_mapping(info, null, null);
        }

        public static int Update_advt_user_group_mapping(Entity.advt_user_group_mapping info, string[] Include)
        {
            return Update_advt_user_group_mapping(info, Include, null);
        }

        public static int Update_advt_user_group_mapping(Entity.advt_user_group_mapping info, string[] Include, string[] Exclude)
        {
            return DatabaseProvider.GetInstance().Update_advt_user_group_mapping(info, Include, Exclude);
        }

        public static int Delete_advt_user_group_mapping(int id)
        {
            return DatabaseProvider.GetInstance().Delete_advt_user_group_mapping(id);
        }
        #endregion
    }
}