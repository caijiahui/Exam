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
        private string[] advt_users_type_key_a = { "id" };
        private string advt_users_type_item_str = "[id],[username],[type],[location]";
        private string[][] advt_users_type_item_prop_a =
        {
            new string[] {"id", "Int", "4"},
            new string[] {"username", "VarChar", "100"},
            new string[] {"type", "VarChar", "50"},
            new string[] {"location", "VarChar", "50"}
        };
        #endregion

        public IDataReader Get_All_advt_users_type(int id)
        {
            StringBuilder commandText = new StringBuilder();
            commandText.AppendLine(" SELECT " + advt_users_type_item_str + "");
            commandText.AppendLine("   FROM [advt_users_type]");
            commandText.AppendLine("   WHERE [id]=@id");
            List<DbParameter> l_parms = new List<DbParameter>();
            l_parms.Add(SqlHelper.MakeInParam("@id", (DbType)SqlDbType.Int, 4, id));
            return DbHelper.PE.ExecuteReader(CommandType.Text, commandText.ToString(), l_parms.ToArray());
        }
        public IDataReader Get_advt_users_type_join_user(int PageSize, int pageIndex,string username)
        {
            StringBuilder commandText = new StringBuilder();
            if(!string.IsNullOrEmpty(username))
            {
                username = "%" + username + "%";
            }
            int startRow = 0;
            int endRow = 0;
            if (PageSize != 0 && pageIndex != 0)
            {
                startRow = (pageIndex - 1) * PageSize + 1;
                endRow = startRow + PageSize - 1;
            }
            commandText.AppendLine(" select * from (select ids=ROW_NUMBER()over(order by location  desc),a.username,b.location,b.type ");
            commandText.AppendLine("  from advt_users a left join advt_users_type b on a.username = b.username ");
            commandText.AppendLine(" where(ISNULL(@username,'')=''or a.username like @username)) tmp");
            commandText.AppendLine(" where (isnull(@startRow,0) = 0 and isnull(@endrow,0)=0 or tmp.ids>=@startRow and tmp.ids<=@endrow)");
            List<DbParameter> l_parms = new List<DbParameter>();
            l_parms.Add(SqlHelper.MakeInParam("@username", (DbType)SqlDbType.VarChar, 100, username));
            l_parms.Add(SqlHelper.MakeInParam("@startRow", (DbType)SqlDbType.Int, 4, startRow));
            l_parms.Add(SqlHelper.MakeInParam("@endRow", (DbType)SqlDbType.Int, 4, endRow));
            return DbHelper.PE.ExecuteReader(CommandType.Text, commandText.ToString(), l_parms.ToArray());
        }

        public IDataReader Get_All_advt_users_type(object objparams)
        {
            StringBuilder commandText = new StringBuilder();
            commandText.AppendLine(" SELECT " + advt_users_type_item_str + "");
            commandText.AppendLine("   FROM [advt_users_type]");
            commandText.AppendLine("   " + SqlHelper.Get_Where_Obj(objparams));
            List<DbParameter> l_parms = SqlHelper.Get_List_Params(advt_users_type_item_prop_a, objparams);
            return DbHelper.PE.ExecuteReader(CommandType.Text, commandText.ToString(), l_parms.ToArray());
        }

        public int Insert_advt_users_type(Entity.advt_users_type info, string[] Include, string[] Exclude)
        {
            List<DbParameter> l_parms = new List<DbParameter>();
            StringBuilder commandText = new StringBuilder();
            string item_name = string.Empty;
            string item_value = string.Empty;
            SqlHelper.Get_Inserte_Set(advt_users_type_item_prop_a, Include, Exclude, info, ref item_name, ref item_value, ref l_parms);
            commandText.AppendLine("INSERT INTO [advt_users_type] (" + item_name + ") VALUES (" + item_value + ")");
            return DbHelper.PE.ExecuteNonQuery(CommandType.Text, commandText.ToString(), l_parms.ToArray());
        }
        public int Update_advt_users_type_username(Entity.advt_users_type info)
        {
            StringBuilder commandText = new StringBuilder();
            commandText.AppendLine(" update advt_users_type set [type]=@type, location = @location where username = @username");
            List<DbParameter> l_parms = new List<DbParameter>();
            l_parms.Add(SqlHelper.MakeInParam("@type", (DbType)SqlDbType.VarChar, 50, info.type));
            l_parms.Add(SqlHelper.MakeInParam("@location", (DbType)SqlDbType.VarChar, 50, info.location));
            l_parms.Add(SqlHelper.MakeInParam("@username", (DbType)SqlDbType.VarChar, 50, info.username));
            return DbHelper.PE.ExecuteNonQuery(CommandType.Text, commandText.ToString(), l_parms.ToArray());
        }

        public int Update_advt_users_type(Entity.advt_users_type info, string[] Include, string[] Exclude)
        {
            List<DbParameter> l_parms = new List<DbParameter>();
            StringBuilder commandText = new StringBuilder();
            string set_str = string.Empty;
            SqlHelper.Get_Update_Set(advt_users_type_key_a, advt_users_type_item_prop_a, Include, Exclude, info, ref set_str, ref l_parms);
            commandText.AppendLine(" UPDATE [advt_users_type]");
            commandText.AppendLine("   SET " + set_str);
            commandText.AppendLine("   " + SqlHelper.Get_Where_Str(advt_users_type_key_a));
            return DbHelper.PE.ExecuteNonQuery(CommandType.Text, commandText.ToString(), l_parms.ToArray());
        }

        public int Delete_advt_users_type(int id)
        {
            StringBuilder commandText = new StringBuilder();
            commandText.AppendLine(" DELETE FROM [advt_users_type]");
            commandText.AppendLine("   " + SqlHelper.Get_Where_Str(advt_users_type_key_a));
            List<DbParameter> l_parms = new List<DbParameter>();
            l_parms.Add(SqlHelper.MakeInParam("@id", (DbType)SqlDbType.Int, 4, id));
            return DbHelper.PE.ExecuteNonQuery(CommandType.Text, commandText.ToString(), l_parms.ToArray());
        }
        #endregion
    }
}
