using System;
using System.Data;
using System.Linq;
using advt.Entity;
using System.Collections.Generic;


namespace advt.Data
{
    public partial class advt_topics
    {

        #region advt_topics , (Ver:2.3.8) at: 2018/5/5 17:38:29

        public static List<Entity.advt_topics> Get_All_advt_topics(object objparams)
        {
            IDataReader reader = DatabaseProvider.GetInstance().Get_All_advt_topics(objparams);
            return SqlHelper.GetReaderToList<Entity.advt_topics>(reader);
        }
        //public static List<Entity.advt_topics> Get_All_Advt_topicByFid(int tid)
        //{
        //    IDataReader reader = DatabaseProvider.GetInstance().Get_All_advt_topicsbytid(tid);
        //    return SqlHelper.GetReaderToList<Entity.advt_topics>(reader);
        //}
        public static List<Entity.advt_topics> Get_All_Advt_topic_id(int PageSize, int pageIndex,int tid, string searchdata, string startdt, string enddt)
        {
            IDataReader reader = DatabaseProvider.GetInstance().Get_All_Advt_topic_id(PageSize, pageIndex, tid, searchdata,startdt,enddt);
            return SqlHelper.GetReaderToList<Entity.advt_topics>(reader);
        }

        public static List<Entity.advt_topics> Get_All_advt_topics()
        {
            return Get_All_advt_topics(null);
        }

        public static Entity.advt_topics Get_advt_topics(object objparams)
        {
            IDataReader reader = DatabaseProvider.GetInstance().Get_All_advt_topics(objparams);
            return SqlHelper.GetReaderToFirstOrDefault<Entity.advt_topics>(reader);
        }

        public static Entity.advt_topics Get_advt_topics(int id)
        {
            return Get_advt_topics(new { id = id });
        }

        public static int Insert_advt_topics(Entity.advt_topics info)
        {
            return Insert_advt_topics(info, null, null);
        }

        public static int Insert_advt_topics(Entity.advt_topics info, string[] Include)
        {
            return Insert_advt_topics(info, Include, null);
        }

        public static int Insert_advt_topics(Entity.advt_topics info, string[] Include, string[] Exclude)
        {
            return DatabaseProvider.GetInstance().Insert_advt_topics(info, Include, Exclude);
        }

        public static int Update_advt_topics(Entity.advt_topics info)
        {
            return Update_advt_topics(info, null, null);
        }

        public static int Update_advt_topics(Entity.advt_topics info, string[] Include)
        {
            return Update_advt_topics(info, Include, null);
        }

        public static int Update_advt_topics(Entity.advt_topics info, string[] Include, string[] Exclude)
        {
            return DatabaseProvider.GetInstance().Update_advt_topics(info, Include, Exclude);
        }

        public static int Delete_advt_topics(int id)
        {
            return DatabaseProvider.GetInstance().Delete_advt_topics(id);
        }
        #endregion
    }
}