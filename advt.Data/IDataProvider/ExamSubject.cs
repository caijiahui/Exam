using System;
using System.Data;

using System.Collections.Generic;
using advt.Entity;

namespace advt.Data
{

    public partial interface IDataProvider
    {
        #region ExamSubject , (Ver:2.3.8) at: 2021/1/7 16:05:32

        IDataReader Get_All_ExamSubject(object objparams);

        int Insert_ExamSubject(Entity.ExamSubject info, string[] Include, string[] Exclude);

        int Update_ExamSubject(Entity.ExamSubject info, string[] Include, string[] Exclude);

        int Delete_ExamSubject(int ID);

        #endregion
    }
}
