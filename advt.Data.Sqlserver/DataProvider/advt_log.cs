using System;
using System.Data;
using System.Data.Common;
using System.Data.Sql;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using advt.Common;
using System.Collections.Generic;
using advt.Data;
using advt.Entity;

namespace advt.Data.SqlServer
{
    public partial class DataProvider : advt.Data.IDataProvider
    {

        #region advt_log , (Ver:2.3.8) at: 2018/5/5 17:38:29
        #region Var: 
        private string[] advt_log_key_a = { "id" };
        private string advt_log_item_str = "[id],[type],[uid],[data],[fromip],[url],[fromurl],[description],[createdt]";
        private string[][] advt_log_item_prop_a = 
        {
            new string[] {"id", "UniqueIdentifier", "16"},
            new string[] {"type", "TinyInt", "1"},
            new string[] {"uid", "Int", "4"},
            new string[] {"data", "NText", "2147483646"},
            new string[] {"fromip", "NVarChar", "200"},
            new string[] {"url", "NVarChar", "2000"},
            new string[] {"fromurl", "NVarChar", "2000"},
            new string[] {"description", "NText", "2147483646"},
            new string[] {"createdt", "DateTime", "8"}
        };
        #endregion

        public IDataReader Get_All_advt_log(object objparams)
        {
            StringBuilder commandText = new StringBuilder();
            commandText.AppendLine(" SELECT " + advt_log_item_str + "");
            commandText.AppendLine("   FROM [advt_log]");
            commandText.AppendLine("   " + SqlHelper.Get_Where_Obj(objparams));
            List<DbParameter> l_parms = SqlHelper.Get_List_Params(advt_log_item_prop_a, objparams);
            return DbHelper.PE.ExecuteReader(CommandType.Text, commandText.ToString(), l_parms.ToArray());
        }

        public int Insert_advt_log(Entity.advt_log info, string[] Include, string[] Exclude)
        {
            List<DbParameter> l_parms = new List<DbParameter>();
            StringBuilder commandText = new StringBuilder();
            string item_name = string.Empty;
            string item_value = string.Empty;
            SqlHelper.Get_Inserte_Set(advt_log_item_prop_a, Include, Exclude, info, ref item_name, ref item_value, ref l_parms);
            commandText.AppendLine("INSERT INTO [advt_log] (" + item_name + ") VALUES (" + item_value + ")");
            return DbHelper.PE.ExecuteNonQuery(CommandType.Text, commandText.ToString(), l_parms.ToArray());
        }

        public int Update_advt_log(Entity.advt_log info, string[] Include, string[] Exclude)
        {
            List<DbParameter> l_parms = new List<DbParameter>();
            StringBuilder commandText = new StringBuilder();
            string set_str = string.Empty;
            SqlHelper.Get_Update_Set(advt_log_key_a, advt_log_item_prop_a, Include, Exclude, info, ref set_str, ref l_parms);
            commandText.AppendLine(" UPDATE [advt_log]");
            commandText.AppendLine("   SET " + set_str);
            commandText.AppendLine("   " + SqlHelper.Get_Where_Str(advt_log_key_a));
            return DbHelper.PE.ExecuteNonQuery(CommandType.Text, commandText.ToString(), l_parms.ToArray());
        }

        public int Delete_advt_log(Guid id)
        {
            StringBuilder commandText = new StringBuilder();
            commandText.AppendLine(" DELETE FROM [advt_log]");
            commandText.AppendLine("   " + SqlHelper.Get_Where_Str(advt_log_key_a));
            List<DbParameter> l_parms = new List<DbParameter>();
            l_parms.Add(SqlHelper.MakeInParam("@id", (DbType)SqlDbType.UniqueIdentifier, 16, id));
            return DbHelper.PE.ExecuteNonQuery(CommandType.Text, commandText.ToString(), l_parms.ToArray());
        }
        #endregion
    }
}
