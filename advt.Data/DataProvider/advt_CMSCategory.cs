using System;
using System.Data;
using System.Linq;
using advt.Entity;
using System.Collections.Generic;


namespace advt.Data
{
    public partial class advt_CMSCategory
    {

        #region advt_CMSCategory , (Ver:2.3.8) at: 2018/5/5 17:38:29

        public static List<Entity.advt_CMSCategory> Get_All_advt_CMSCategory(object objparams)
        {
            IDataReader reader = DatabaseProvider.GetInstance().Get_All_advt_CMSCategory(objparams);
            return SqlHelper.GetReaderToList<Entity.advt_CMSCategory>(reader);
        }

        public static List<Entity.advt_CMSCategory> Get_All_advt_CMSCategory()
        {
            return Get_All_advt_CMSCategory(null);
        }

        public static Entity.advt_CMSCategory Get_advt_CMSCategory(object objparams)
        {
            IDataReader reader = DatabaseProvider.GetInstance().Get_All_advt_CMSCategory(objparams);
            return SqlHelper.GetReaderToFirstOrDefault<Entity.advt_CMSCategory>(reader);
        }

        public static Entity.advt_CMSCategory Get_advt_CMSCategory(int id)
        {
            return Get_advt_CMSCategory(new { id = id });
        }

        public static int Insert_advt_CMSCategory(Entity.advt_CMSCategory info)
        {
            return Insert_advt_CMSCategory(info, null, null);
        }

        public static int Insert_advt_CMSCategory(Entity.advt_CMSCategory info, string[] Include)
        {
            return Insert_advt_CMSCategory(info, Include, null);
        }

        public static int Insert_advt_CMSCategory(Entity.advt_CMSCategory info, string[] Include, string[] Exclude)
        {
            return DatabaseProvider.GetInstance().Insert_advt_CMSCategory(info, Include, Exclude);
        }

        public static int Update_advt_CMSCategory(Entity.advt_CMSCategory info)
        {
            return Update_advt_CMSCategory(info, null, null);
        }

        public static int Update_advt_CMSCategory(Entity.advt_CMSCategory info, string[] Include)
        {
            return Update_advt_CMSCategory(info, Include, null);
        }

        public static int Update_advt_CMSCategory(Entity.advt_CMSCategory info, string[] Include, string[] Exclude)
        {
            return DatabaseProvider.GetInstance().Update_advt_CMSCategory(info, Include, Exclude);
        }

        public static int Delete_advt_CMSCategory(int id)
        {
            return DatabaseProvider.GetInstance().Delete_advt_CMSCategory(id);
        }
        #endregion
    }
}