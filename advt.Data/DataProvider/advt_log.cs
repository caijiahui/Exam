using System;
using System.Data;
using System.Linq;
using advt.Entity;
using System.Collections.Generic;


namespace advt.Data
{
    public partial class advt_log
    {

        #region advt_log , (Ver:2.3.8) at: 2018/5/5 17:38:29

        public static List<Entity.advt_log> Get_All_advt_log(object objparams)
        {
            IDataReader reader = DatabaseProvider.GetInstance().Get_All_advt_log(objparams);
            return SqlHelper.GetReaderToList<Entity.advt_log>(reader);
        }

        public static List<Entity.advt_log> Get_All_advt_log()
        {
            return Get_All_advt_log(null);
        }

        public static Entity.advt_log Get_advt_log(object objparams)
        {
            IDataReader reader = DatabaseProvider.GetInstance().Get_All_advt_log(objparams);
            return SqlHelper.GetReaderToFirstOrDefault<Entity.advt_log>(reader);
        }

        public static Entity.advt_log Get_advt_log(Guid id)
        {
            return Get_advt_log(new { id = id });
        }

        public static int Insert_advt_log(Entity.advt_log info)
        {
            return Insert_advt_log(info, null, null);
        }

        public static int Insert_advt_log(Entity.advt_log info, string[] Include)
        {
            return Insert_advt_log(info, Include, null);
        }

        public static int Insert_advt_log(Entity.advt_log info, string[] Include, string[] Exclude)
        {
            return DatabaseProvider.GetInstance().Insert_advt_log(info, Include, Exclude);
        }

        public static int Update_advt_log(Entity.advt_log info)
        {
            return Update_advt_log(info, null, null);
        }

        public static int Update_advt_log(Entity.advt_log info, string[] Include)
        {
            return Update_advt_log(info, Include, null);
        }

        public static int Update_advt_log(Entity.advt_log info, string[] Include, string[] Exclude)
        {
            return DatabaseProvider.GetInstance().Update_advt_log(info, Include, Exclude);
        }

        public static int Delete_advt_log(Guid id)
        {
            return DatabaseProvider.GetInstance().Delete_advt_log(id);
        }
        #endregion
    }
}