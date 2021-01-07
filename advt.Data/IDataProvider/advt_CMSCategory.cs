using System;
using System.Data;

using System.Collections.Generic;
using advt.Entity;

namespace advt.Data
{

    public partial interface IDataProvider
    {

        #region advt_CMSCategory , (Ver:2.3.8) at: 2018/5/5 17:38:29

        IDataReader Get_All_advt_CMSCategory(object objparams);

        int Insert_advt_CMSCategory(Entity.advt_CMSCategory info, string[] Include, string[] Exclude);

        int Update_advt_CMSCategory(Entity.advt_CMSCategory info, string[] Include, string[] Exclude);

        int Delete_advt_CMSCategory(int id);

        #endregion
    }
}
