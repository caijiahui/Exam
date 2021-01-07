using System;
using System.Data;

using System.Collections.Generic;
using advt.Entity;

namespace advt.Data
{

    public partial interface IDataProvider
    {
        #region ExamType , (Ver:2.3.8) at: 2021/1/7 15:58:19

        IDataReader Get_All_ExamType(object objparams);

        int Insert_ExamType(Entity.ExamType info, string[] Include, string[] Exclude);

        int Update_ExamType(Entity.ExamType info, string[] Include, string[] Exclude);

        int Delete_ExamType(int ID);

        #endregion
    }
}
