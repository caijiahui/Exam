using System;
using System.Data;

using System.Collections.Generic;
using advt.Entity;

namespace advt.Data
{

    public partial interface IDataProvider
    {
        IDataReader Get_All_advt_page_By_UserGroup(int user_group_id);

        #region advt_page , (Ver:2.3.8) at: 2018/5/5 17:38:29

        IDataReader Get_All_advt_page(object objparams);

        int Insert_advt_page(Entity.advt_page info, string[] Include, string[] Exclude);

        int Update_advt_page(Entity.advt_page info, string[] Include, string[] Exclude);

        int Delete_advt_page(int id);

        #endregion
    }
}
