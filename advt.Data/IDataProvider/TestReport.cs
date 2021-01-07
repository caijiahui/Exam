using System;
using System.Data;

using System.Collections.Generic;
using advt.Entity;

namespace advt.Data
{

    public partial interface IDataProvider
    {

        #region TestReport , (Ver:2.3.8) at: 2018/6/4 14:36:56

        IDataReader Get_All_TestReport(int id);

        IDataReader Get_All_TestReport(object objparams);
        IDataReader Get_Test_R(string name);

        int Insert_TestReport(Entity.TestReport info, string[] Include, string[] Exclude);

        int Update_TestReport(Entity.TestReport info, string[] Include, string[] Exclude);

        int Update_TestReport_Name(Entity.TestReport info);
        int Delete_TestReport(int id);

        #endregion
    }
}
