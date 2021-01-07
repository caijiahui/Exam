using System;
using System.Data;
using System.Data.Common;
using System.Data.Sql;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using advt.Common;
using System.Collections.Generic;
using advt.Entity;

namespace advt.Data.SqlServer
{
    public partial class DataProvider : advt.Data.IDataProvider
    {


        #region advt_users_type , (Ver:2.3.8) at: 2018/5/22 10:52:23
        #region Var: 
        private string[] ExamType_key_a = { "id" };
        private string ExamType_item_str = "[id],[TypeName],[CreateUser],[CreateDate]";
        #endregion

        public IDataReader Get_All_ExamType(int id)
        {
            try
            {
                StringBuilder commandText = new StringBuilder();
                commandText.AppendLine(" SELECT " + ExamType_item_str + "");
                commandText.AppendLine("   FROM [ExamType]");
                commandText.AppendLine("   WHERE [id]=@id");
                List<DbParameter> l_parms = new List<DbParameter>();
                l_parms.Add(SqlHelper.MakeInParam("@id", (DbType)SqlDbType.Int, 4, id));
                return DbHelper.PE.ExecuteReader(CommandType.Text, commandText.ToString(), l_parms.ToArray());
            }
            catch (Exception ex)
            {

                throw;
            }
            
        }
        #endregion
    }
}
