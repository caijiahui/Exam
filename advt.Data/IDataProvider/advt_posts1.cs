using System;
using System.Data;

using System.Collections.Generic;
using advt.Entity;

namespace advt.Data
{

    public partial interface IDataProvider
    {

        #region advt_posts1 , (Ver:2.3.8) at: 2018/5/5 17:38:29

        IDataReader Get_All_advt_posts1(object objparams);

        int Insert_advt_posts1(Entity.advt_posts1 info, string[] Include, string[] Exclude);

        int Update_advt_posts1(Entity.advt_posts1 info, string[] Include, string[] Exclude);

        int Delete_advt_posts1(int id);

        #endregion
    }
}
