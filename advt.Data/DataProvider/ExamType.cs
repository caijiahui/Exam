using System;
using System.Data;
using System.Linq;
using advt.Entity;
using System.Collections.Generic;


namespace advt.Data
{
    public partial class ExamType
    {

        public static List<Entity.ExamType> Get_All_ExamType(int id)
        {
            IDataReader reader = DatabaseProvider.GetInstance().Get_All_ExamType(id);
            return SqlHelper.GetReaderToList<Entity.ExamType>(reader);
        }
    }
}