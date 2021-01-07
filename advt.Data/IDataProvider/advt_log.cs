using System;
using System.Data;

using System.Collections.Generic;
using advt.Entity;

namespace advt.Data
{

    public partial interface IDataProvider
    {

        #region advt_log , (Ver:2.3.8) at: 2018/5/5 17:38:29

        IDataReader Get_All_advt_log(object objparams);

        int Insert_advt_log(Entity.advt_log info, string[] Include, string[] Exclude);

        int Update_advt_log(Entity.advt_log info, string[] Include, string[] Exclude);

        int Delete_advt_log(Guid id);

        #endregion
    }
}
