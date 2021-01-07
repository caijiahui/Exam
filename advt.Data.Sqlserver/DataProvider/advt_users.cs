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
        public int Update_advt_users_LastIP(int userid, string FromIP)
        {
            StringBuilder commandText = new StringBuilder();
            commandText.AppendLine(" UPDATE [advt_users]");
            commandText.AppendLine("   SET [lastip]=@lastip");
            commandText.AppendLine(" WHERE [id]=@userid");
            List<DbParameter> l_parms = new List<DbParameter>();
            l_parms.Add(SqlHelper.MakeInParam("@userid", (DbType)SqlDbType.Int, 4, userid));
            l_parms.Add(SqlHelper.MakeInParam("@lastip", (DbType)SqlDbType.Char, 15, FromIP));
            return DbHelper.PE.ExecuteNonQuery(CommandType.Text, commandText.ToString(), l_parms.ToArray());
        }


        #region advt_users , (Ver:2.3.8) at: 2018/5/5 17:38:29
        #region Var: 
        private string[] advt_users_key_a = { "id" };
        private string advt_users_item_str = "[id],[username],[firstname],[lastname],[nickname],[password],[sex],[lastip],[regip],[phone],[qq],[msn],[email],[description],[roles],[usergroupid],[createdate],[extcredits2],[extcredits1],[status]";
        private string[][] advt_users_item_prop_a = 
        {
            new string[] {"id", "Int", "4"},
            new string[] {"username", "VarChar", "100"},
            new string[] {"firstname", "NVarChar", "100"},
            new string[] {"lastname", "NVarChar", "100"},
            new string[] {"nickname", "NVarChar", "50"},
            new string[] {"password", "NChar", "64"},
            new string[] {"sex", "TinyInt", "1"},
            new string[] {"lastip", "VarChar", "50"},
            new string[] {"regip", "VarChar", "50"},
            new string[] {"phone", "VarChar", "50"},
            new string[] {"qq", "VarChar", "50"},
            new string[] {"msn", "VarChar", "50"},
            new string[] {"email", "VarChar", "50"},
            new string[] {"description", "NVarChar", "200"},
            new string[] {"roles", "TinyInt", "1"},
            new string[] {"usergroupid", "Int", "4"},
            new string[] {"createdate", "DateTime", "8"},
            new string[] {"extcredits2", "Decimal", "20"},
            new string[] {"extcredits1", "Decimal", "20"},
            new string[] {"status", "TinyInt", "1"}
        };
        #endregion

        public IDataReader Get_All_advt_users(object objparams)
        {
            StringBuilder commandText = new StringBuilder();
            commandText.AppendLine(" SELECT " + advt_users_item_str + "");
            commandText.AppendLine("   FROM [advt_users]");
            commandText.AppendLine("   " + SqlHelper.Get_Where_Obj(objparams));
            List<DbParameter> l_parms = SqlHelper.Get_List_Params(advt_users_item_prop_a, objparams);
            return DbHelper.PE.ExecuteReader(CommandType.Text, commandText.ToString(), l_parms.ToArray());
        }

        public int Insert_advt_users(Entity.advt_users info, string[] Include, string[] Exclude)
        {
            List<DbParameter> l_parms = new List<DbParameter>();
            StringBuilder commandText = new StringBuilder();
            string item_name = string.Empty;
            string item_value = string.Empty;
            SqlHelper.Get_Inserte_Set(advt_users_item_prop_a, Include, Exclude, info, ref item_name, ref item_value, ref l_parms);
            commandText.AppendLine("INSERT INTO [advt_users] (" + item_name + ") VALUES (" + item_value + ");SELECT @@IDENTITY AS ID;");
            return DbHelper.PE.ExecuteNonQuery(CommandType.Text, commandText.ToString(), l_parms.ToArray());
        }

        public int Update_advt_users(Entity.advt_users info, string[] Include, string[] Exclude)
        {
            List<DbParameter> l_parms = new List<DbParameter>();
            StringBuilder commandText = new StringBuilder();
            string set_str = string.Empty;
            SqlHelper.Get_Update_Set(advt_users_key_a, advt_users_item_prop_a, Include, Exclude, info, ref set_str, ref l_parms);
            commandText.AppendLine(" UPDATE [advt_users]");
            commandText.AppendLine("   SET " + set_str);
            commandText.AppendLine("   " + SqlHelper.Get_Where_Str(advt_users_key_a));
            return DbHelper.PE.ExecuteNonQuery(CommandType.Text, commandText.ToString(), l_parms.ToArray());
        }

        public int Delete_advt_users(int id)
        {
            StringBuilder commandText = new StringBuilder();
            commandText.AppendLine(" DELETE FROM [advt_users]");
            commandText.AppendLine("   " + SqlHelper.Get_Where_Str(advt_users_key_a));
            List<DbParameter> l_parms = new List<DbParameter>();
            l_parms.Add(SqlHelper.MakeInParam("@id", (DbType)SqlDbType.Int, 4, id));
            return DbHelper.PE.ExecuteNonQuery(CommandType.Text, commandText.ToString(), l_parms.ToArray());
        }
        #endregion
    }
}
