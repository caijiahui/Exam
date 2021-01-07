using System;
using System.Data;

using System.Collections.Generic;
using advt.Entity;

namespace advt.Data
{

    public partial interface IDataProvider
    {

        #region advt_user_group_mapping , (Ver:2.3.8) at: 2018/5/5 17:38:29

        IDataReader Get_All_advt_user_group_mapping(object objparams);

        int Insert_advt_user_group_mapping(Entity.advt_user_group_mapping info, string[] Include, string[] Exclude);

        int Update_advt_user_group_mapping(Entity.advt_user_group_mapping info, string[] Include, string[] Exclude);

        int Delete_advt_user_group_mapping(int id);

        #endregion
    }
}
