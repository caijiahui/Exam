//using System;
//using System.Data;
//using System.Data.Common;
//using System.Data.Sql;
//using System.Linq;
//using System.Text;
//using System.Text.RegularExpressions;
//using advt.Common;
//using System.Collections.Generic;
//using advt.Data;
//using advt.Entity;

//namespace advt.Data.SqlServer
//{
//    public partial class DataProvider : advt.Data.IDataProvider
//    {

//        #region advt_Attach_Files , (Ver:2.3.8) at: 2018/5/10 14:41:37
//        #region Var: 
//        private string[] advt_Attach_Files_key_a = { "id" };
//        private string advt_Attach_Files_item_str = "[id],[FType],[FileName],[SaveName],[Folder],[ServerName]";
//        private string[][] advt_Attach_Files_item_prop_a =
//        {
//            new string[] {"id", "Char", "32"},
//            new string[] {"FType", "VarChar", "50"},
//            new string[] {"FileName", "NVarChar", "100"},
//            new string[] {"SaveName", "NVarChar", "100"},
//            new string[] {"Folder", "VarChar", "6"},
//            new string[] {"ServerName", "VarChar", "500"}
//        };
//        #endregion

//        public IDataReader Get_All_advt_Attach_Files(string id)
//        {
//            StringBuilder commandText = new StringBuilder();
//            commandText.AppendLine(" SELECT " + advt_Attach_Files_item_str + "");
//            commandText.AppendLine("   FROM [advt_Attach_Files]");
//            commandText.AppendLine("   WHERE [id]=@id");
//            List<DbParameter> l_parms = new List<DbParameter>();
//            l_parms.Add(SqlHelper.MakeInParam("@id", (DbType)SqlDbType.Char, 32, id));
//            return DbHelper.PE.ExecuteReader(CommandType.Text, commandText.ToString(), l_parms.ToArray());
//        }

//        public IDataReader Get_All_advt_Attach_FilesInfo(object objparams)
//        {
//            StringBuilder commandText = new StringBuilder();
//            commandText.AppendLine(" SELECT " + advt_Attach_Files_item_str + "");
//            commandText.AppendLine("   FROM [advt_Attach_Files]");
//            commandText.AppendLine("   " + SqlHelper.Get_Where_Obj(objparams));
//            List<DbParameter> l_parms = SqlHelper.Get_List_Params(advt_Attach_Files_item_prop_a, objparams);
//            return DbHelper.PE.ExecuteReader(CommandType.Text, commandText.ToString(), l_parms.ToArray());
//        }

//        public int Insert_advt_Attach_FilesInfo(Entity.advt_Attach_Files info, string[] Include, string[] Exclude)
//        {
//            List<DbParameter> l_parms = new List<DbParameter>();
//            StringBuilder commandText = new StringBuilder();
//            string item_name = string.Empty;
//            string item_value = string.Empty;
//            SqlHelper.Get_Inserte_Set(advt_Attach_Files_item_prop_a, Include, Exclude, info, ref item_name, ref item_value, ref l_parms);
//            commandText.AppendLine("INSERT INTO [advt_Attach_Files] (" + item_name + ") VALUES (" + item_value + ")");
//            return DbHelper.PE.ExecuteNonQuery(CommandType.Text, commandText.ToString(), l_parms.ToArray());
//        }

//        public int Update_advt_Attach_FilesInfo(Entity.advt_Attach_Files info, string[] Include, string[] Exclude)
//        {
//            List<DbParameter> l_parms = new List<DbParameter>();
//            StringBuilder commandText = new StringBuilder();
//            string set_str = string.Empty;
//            SqlHelper.Get_Update_Set(advt_Attach_Files_key_a, advt_Attach_Files_item_prop_a, Include, Exclude, info, ref set_str, ref l_parms);
//            commandText.AppendLine(" UPDATE [advt_Attach_Files]");
//            commandText.AppendLine("   SET " + set_str);
//            commandText.AppendLine("   " + SqlHelper.Get_Where_Str(advt_Attach_Files_key_a));
//            return DbHelper.PE.ExecuteNonQuery(CommandType.Text, commandText.ToString(), l_parms.ToArray());
//        }

//        public int Delete_advt_Attach_FilesInfo(string id)
//        {
//            StringBuilder commandText = new StringBuilder();
//            commandText.AppendLine(" DELETE FROM [advt_Attach_Files]");
//            commandText.AppendLine("   " + SqlHelper.Get_Where_Str(advt_Attach_Files_key_a));
//            List<DbParameter> l_parms = new List<DbParameter>();
//            l_parms.Add(SqlHelper.MakeInParam("@id", (DbType)SqlDbType.Char, 32, id));
//            return DbHelper.PE.ExecuteNonQuery(CommandType.Text, commandText.ToString(), l_parms.ToArray());
//        }
//        #endregion
//    }
//}
