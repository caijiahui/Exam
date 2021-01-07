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
        #region advt_CMSCategory , (Ver:2.3.8) at: 2018/5/9 15:06:21
        #region Var: 
        private string[] advt_CMSCategory_key_a = { "id" };
        private string advt_CMSCategory_item_str = "[id],[pid],[categoryname],[createdt],[createdt_show],[updatedt],[updatedt_show],[username],[ursername_show],[state],[state_show],[attachment],[attachment_show],[casename],[casename_show],[description],[description_show],[item1],[item1_show],[item2],[item2_show],[item3],[item3_show],[item4],[item4_show],[item5],[item5_show],[item6],[item6_show],[item7],[item7_show],[item8],[item8_show],[item9],[item9_show],[item10],[item10_show]";
        private string[][] advt_CMSCategory_item_prop_a =
        {
            new string[] {"id", "Int", "4"},
            new string[] {"pid", "Int", "4"},
            new string[] {"categoryname", "NVarChar", "50"},
            new string[] {"createdt", "NVarChar", "50"},
            new string[] {"createdt_show", "Bit", "1"},
            new string[] {"updatedt", "NVarChar", "50"},
            new string[] {"updatedt_show", "Bit", "1"},
            new string[] {"username", "NVarChar", "50"},
            new string[] {"ursername_show", "Bit", "1"},
            new string[] {"state", "NVarChar", "50"},
            new string[] {"state_show", "Bit", "1"},
            new string[] {"attachment", "NVarChar", "50"},
            new string[] {"attachment_show", "Bit", "1"},
            new string[] {"casename", "NVarChar", "50"},
            new string[] {"casename_show", "Bit", "1"},
            new string[] {"description", "NVarChar", "50"},
            new string[] {"description_show", "Bit", "1"},
            new string[] {"item1", "NVarChar", "50"},
            new string[] {"item1_show", "Bit", "1"},
            new string[] {"item2", "NVarChar", "50"},
            new string[] {"item2_show", "Bit", "1"},
            new string[] {"item3", "NVarChar", "50"},
            new string[] {"item3_show", "Bit", "1"},
            new string[] {"item4", "NVarChar", "50"},
            new string[] {"item4_show", "Bit", "1"},
            new string[] {"item5", "NVarChar", "50"},
            new string[] {"item5_show", "Bit", "1"},
            new string[] {"item6", "NVarChar", "50"},
            new string[] {"item6_show", "Bit", "1"},
            new string[] {"item7", "NVarChar", "50"},
            new string[] {"item7_show", "Bit", "1"},
            new string[] {"item8", "NVarChar", "50"},
            new string[] {"item8_show", "Bit", "1"},
            new string[] {"item9", "NVarChar", "50"},
            new string[] {"item9_show", "Bit", "1"},
            new string[] {"item10", "NVarChar", "50"},
            new string[] {"item10_show", "Bit", "1"}
        };
        #endregion

        public IDataReader Get_All_advt_CMSCategory(object objparams)
        {
            StringBuilder commandText = new StringBuilder();
            commandText.AppendLine(" SELECT " + advt_CMSCategory_item_str + "");
            commandText.AppendLine("   FROM [advt_CMSCategory]");
            commandText.AppendLine("   " + SqlHelper.Get_Where_Obj(objparams));
            List<DbParameter> l_parms = SqlHelper.Get_List_Params(advt_CMSCategory_item_prop_a, objparams);
            return DbHelper.PE.ExecuteReader(CommandType.Text, commandText.ToString(), l_parms.ToArray());
        }

        public int Insert_advt_CMSCategory(Entity.advt_CMSCategory info, string[] Include, string[] Exclude)
        {
            List<DbParameter> l_parms = new List<DbParameter>();
            StringBuilder commandText = new StringBuilder();
            string item_name = string.Empty;
            string item_value = string.Empty;
            SqlHelper.Get_Inserte_Set(advt_CMSCategory_item_prop_a, Include, Exclude, info, ref item_name, ref item_value, ref l_parms);
            commandText.AppendLine("INSERT INTO [advt_CMSCategory] (" + item_name + ") VALUES (" + item_value + ")");
            return DbHelper.PE.ExecuteNonQuery(CommandType.Text, commandText.ToString(), l_parms.ToArray());
        }

        public int Update_advt_CMSCategory(Entity.advt_CMSCategory info, string[] Include, string[] Exclude)
        {
            List<DbParameter> l_parms = new List<DbParameter>();
            StringBuilder commandText = new StringBuilder();
            string set_str = string.Empty;
            SqlHelper.Get_Update_Set(advt_CMSCategory_key_a, advt_CMSCategory_item_prop_a, Include, Exclude, info, ref set_str, ref l_parms);
            commandText.AppendLine(" UPDATE [advt_CMSCategory]");
            commandText.AppendLine("   SET " + set_str);
            commandText.AppendLine("   " + SqlHelper.Get_Where_Str(advt_CMSCategory_key_a));
            return DbHelper.PE.ExecuteNonQuery(CommandType.Text, commandText.ToString(), l_parms.ToArray());
        }

        public int Delete_advt_CMSCategory(int id)
        {
            StringBuilder commandText = new StringBuilder();
            commandText.AppendLine(" DELETE FROM [advt_CMSCategory]");
            commandText.AppendLine("   " + SqlHelper.Get_Where_Str(advt_CMSCategory_key_a));
            List<DbParameter> l_parms = new List<DbParameter>();
            l_parms.Add(SqlHelper.MakeInParam("@id", (DbType)SqlDbType.Int, 4, id));
            return DbHelper.PE.ExecuteNonQuery(CommandType.Text, commandText.ToString(), l_parms.ToArray());
        }
        #endregion
    }
}
