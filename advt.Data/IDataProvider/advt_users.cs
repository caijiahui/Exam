using System;
using System.Data;

using System.Collections.Generic;
using advt.Entity;

namespace advt.Data
{

    public partial interface IDataProvider
    {
        int Update_advt_users_LastIP(int Userid, string FromIP);

        #region advt_users , (Ver:2.3.8) at: 2018/5/5 17:38:29

        IDataReader Get_All_advt_users(object objparams);

        int Insert_advt_users(Entity.advt_users info, string[] Include, string[] Exclude);

        int Update_advt_users(Entity.advt_users info, string[] Include, string[] Exclude);

        int Delete_advt_users(int id);

        #endregion
    }
}
