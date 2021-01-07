using System;
using System.Data;

using System.Collections.Generic;
using advt.Entity;

namespace advt.Data
{

    public partial interface IDataProvider
    {

        #region advt_users_type , (Ver:2.3.8) at: 2018/5/22 10:15:17

        IDataReader Get_All_advt_users_type(int id);
        IDataReader Get_advt_users_type_join_user(int PageSize, int pageIndex,string username);

        IDataReader Get_All_advt_users_type(object objparams);

        int Insert_advt_users_type(Entity.advt_users_type info, string[] Include, string[] Exclude);
        int Update_advt_users_type_username(Entity.advt_users_type info);

        int Update_advt_users_type(Entity.advt_users_type info, string[] Include, string[] Exclude);

        int Delete_advt_users_type(int id);

        #endregion
    }
}
