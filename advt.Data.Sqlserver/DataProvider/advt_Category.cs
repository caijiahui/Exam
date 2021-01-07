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

        #region advt_Category , (Ver:2.3.8) at: 2018/5/5 17:38:29
        #region Var: 
        private string[] advt_Category_key_a = { "id" };
        private string advt_Category_item_str = "[id],[name],[pid],[prop],[type],[description],[displayorder],[available],[origin_id],[source],[product_qty],[ico_addr],[origin_ico_id],[allowdisplay],[allowprominent]";
        private string[][] advt_Category_item_prop_a = 
        {
            new string[] {"id", "Int", "4"},
            new string[] {"name", "NVarChar", "100"},
            new string[] {"pid", "Int", "4"},
            new string[] {"prop", "Int", "4"},
            new string[] {"type", "TinyInt", "1"},
            new string[] {"description", "NVarChar", "4000"},
            new string[] {"displayorder", "Int", "4"},
            new string[] {"available", "TinyInt", "1"},
            new string[] {"origin_id", "NVarChar", "100"},
            new string[] {"source", "Int", "4"},
            new string[] {"product_qty", "Int", "4"},
            new string[] {"ico_addr", "NVarChar", "4000"},
            new string[] {"origin_ico_id", "NVarChar", "100"},
            new string[] {"allowdisplay", "Bit", "1"},
            new string[] {"allowprominent", "Bit", "1"}
        };
        #endregion

        public IDataReader Get_All_advt_Category(object objparams)
        {
            StringBuilder commandText = new StringBuilder();
            commandText.AppendLine(" SELECT " + advt_Category_item_str + "");
            commandText.AppendLine("   FROM [advt_Category]");
            commandText.AppendLine("   " + SqlHelper.Get_Where_Obj(objparams));
            List<DbParameter> l_parms = SqlHelper.Get_List_Params(advt_Category_item_prop_a, objparams);
            return DbHelper.PE.ExecuteReader(CommandType.Text, commandText.ToString(), l_parms.ToArray());
        }

        public int Insert_advt_Category(Entity.advt_Category info, string[] Include, string[] Exclude)
        {
            List<DbParameter> l_parms = new List<DbParameter>();
            StringBuilder commandText = new StringBuilder();
            string item_name = string.Empty;
            string item_value = string.Empty;
            SqlHelper.Get_Inserte_Set(advt_Category_item_prop_a, Include, Exclude, info, ref item_name, ref item_value, ref l_parms);
            commandText.AppendLine("INSERT INTO [advt_Category] (" + item_name + ") VALUES (" + item_value + ")");
            return DbHelper.PE.ExecuteNonQuery(CommandType.Text, commandText.ToString(), l_parms.ToArray());
        }

        public int Update_advt_Category(Entity.advt_Category info, string[] Include, string[] Exclude)
        {
            List<DbParameter> l_parms = new List<DbParameter>();
            StringBuilder commandText = new StringBuilder();
            string set_str = string.Empty;
            SqlHelper.Get_Update_Set(advt_Category_key_a, advt_Category_item_prop_a, Include, Exclude, info, ref set_str, ref l_parms);
            commandText.AppendLine(" UPDATE [advt_Category]");
            commandText.AppendLine("   SET " + set_str);
            commandText.AppendLine("   " + SqlHelper.Get_Where_Str(advt_Category_key_a));
            return DbHelper.PE.ExecuteNonQuery(CommandType.Text, commandText.ToString(), l_parms.ToArray());
        }

        public int Delete_advt_Category(int id)
        {
            StringBuilder commandText = new StringBuilder();
            commandText.AppendLine(" DELETE FROM [advt_Category]");
            commandText.AppendLine("   " + SqlHelper.Get_Where_Str(advt_Category_key_a));
            List<DbParameter> l_parms = new List<DbParameter>();
            l_parms.Add(SqlHelper.MakeInParam("@id", (DbType)SqlDbType.Int, 4, id));
            return DbHelper.PE.ExecuteNonQuery(CommandType.Text, commandText.ToString(), l_parms.ToArray());
        }
        #endregion
    }
}
