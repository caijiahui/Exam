using System;
using System.Data;

using System.Collections.Generic;
using advt.Entity;

namespace advt.Data
{

    public partial interface IDataProvider
    {

        #region advt_topics , (Ver:2.3.8) at: 2018/5/5 17:38:29

        IDataReader Get_All_advt_topics(object objparams);
        IDataReader Get_All_Advt_topic_id(int PageSize, int pageIndex, int id, string searchdata, string startdt, string enddt);

        //IDataReader Get_All_advt_topicsbytid(int tid);
        int Insert_advt_topics(Entity.advt_topics info, string[] Include, string[] Exclude);

        int Update_advt_topics(Entity.advt_topics info, string[] Include, string[] Exclude);

        int Delete_advt_topics(int id);

        #endregion
    }
}
