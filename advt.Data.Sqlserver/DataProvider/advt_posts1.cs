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

        #region advt_posts1 , (Ver:2.3.8) at: 2018/5/5 17:38:29
        #region Var: 
        private string[] advt_posts1_key_a = { "id" };
        private string advt_posts1_item_str = "[id],[fid],[tid],[pid],[name],[message],[ip],[htmlon],[smileon],[attachment],[createdt],[createby],[available]";
        private string[][] advt_posts1_item_prop_a = 
        {
            new string[] {"id", "Int", "4"},
            new string[] {"fid", "Int", "4"},
            new string[] {"tid", "Int", "4"},
            new string[] {"pid", "Int", "4"},
            new string[] {"name", "NVarChar", "200"},
            new string[] {"message", "NText", "2147483646"},
            new string[] {"ip", "NVarChar", "50"},
            new string[] {"htmlon", "TinyInt", "1"},
            new string[] {"smileon", "TinyInt", "1"},
            new string[] {"attachment", "Int", "4"},
            new string[] {"createdt", "DateTime", "8"},
            new string[] {"createby", "Int", "4"},
            new string[] {"available", "TinyInt", "1"}
        };
        #endregion

        public IDataReader Get_All_advt_posts1(object objparams)
        {
            StringBuilder commandText = new StringBuilder();
            commandText.AppendLine(" SELECT " + advt_posts1_item_str + "");
            commandText.AppendLine("   FROM [advt_posts1]");
            commandText.AppendLine("   " + SqlHelper.Get_Where_Obj(objparams));
            List<DbParameter> l_parms = SqlHelper.Get_List_Params(advt_posts1_item_prop_a, objparams);
            return DbHelper.PE.ExecuteReader(CommandType.Text, commandText.ToString(), l_parms.ToArray());
        }

        public int Insert_advt_posts1(Entity.advt_posts1 info, string[] Include, string[] Exclude)
        {
            List<DbParameter> l_parms = new List<DbParameter>();
            StringBuilder commandText = new StringBuilder();
            string item_name = string.Empty;
            string item_value = string.Empty;
            SqlHelper.Get_Inserte_Set(advt_posts1_item_prop_a, Include, Exclude, info, ref item_name, ref item_value, ref l_parms);
            commandText.AppendLine("INSERT INTO [advt_posts1] (" + item_name + ") VALUES (" + item_value + ")");
            return DbHelper.PE.ExecuteNonQuery(CommandType.Text, commandText.ToString(), l_parms.ToArray());
        }

        public int Update_advt_posts1(Entity.advt_posts1 info, string[] Include, string[] Exclude)
        {
            List<DbParameter> l_parms = new List<DbParameter>();
            StringBuilder commandText = new StringBuilder();
            string set_str = string.Empty;
            SqlHelper.Get_Update_Set(advt_posts1_key_a, advt_posts1_item_prop_a, Include, Exclude, info, ref set_str, ref l_parms);
            commandText.AppendLine(" UPDATE [advt_posts1]");
            commandText.AppendLine("   SET " + set_str);
            commandText.AppendLine("   " + SqlHelper.Get_Where_Str(advt_posts1_key_a));
            return DbHelper.PE.ExecuteNonQuery(CommandType.Text, commandText.ToString(), l_parms.ToArray());
        }

        public int Delete_advt_posts1(int id)
        {
            StringBuilder commandText = new StringBuilder();
            commandText.AppendLine(" DELETE FROM [advt_posts1]");
            commandText.AppendLine("   " + SqlHelper.Get_Where_Str(advt_posts1_key_a));
            List<DbParameter> l_parms = new List<DbParameter>();
            l_parms.Add(SqlHelper.MakeInParam("@id", (DbType)SqlDbType.Int, 4, id));
            return DbHelper.PE.ExecuteNonQuery(CommandType.Text, commandText.ToString(), l_parms.ToArray());
        }
        #endregion
    }
}
