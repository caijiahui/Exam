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

        #region TestReport , (Ver:2.3.8) at: 2018/6/4 14:36:56
        #region Var: 
        private string[] TestReport_key_a = { "id" };
        private string TestReport_item_str = "[id],[name],[content],[createdate]";
        private string[][] TestReport_item_prop_a =
        {
            new string[] {"id", "Int", "4"},
            new string[] {"name", "NVarChar", "100"},
            new string[] {"content", "NText", "2147483646"},
            new string[] {"createdate", "DateTime", "8"}
        };
        #endregion

        public IDataReader Get_All_TestReport(int id)
        {
            StringBuilder commandText = new StringBuilder();
            commandText.AppendLine(" SELECT " + TestReport_item_str + "");
            commandText.AppendLine("   FROM [TestReport]");
            commandText.AppendLine("   WHERE [id]=@id");
            List<DbParameter> l_parms = new List<DbParameter>();
            l_parms.Add(SqlHelper.MakeInParam("@id", (DbType)SqlDbType.Int, 4, id));
            return DbHelper.CTOSCustomer.ExecuteReader(CommandType.Text, commandText.ToString(), l_parms.ToArray());
        }
        public IDataReader Get_Test_R(string name)
        {
            StringBuilder commandText = new StringBuilder();
            commandText.AppendLine(" SELECT " + TestReport_item_str + "");
            commandText.AppendLine("   FROM [TestReport]");
            commandText.AppendLine("   WHERE [name]=@name");
            List<DbParameter> l_parms = new List<DbParameter>();
            l_parms.Add(SqlHelper.MakeInParam("@name", (DbType)SqlDbType.NVarChar, 100, name));
            return DbHelper.CTOSCustomer.ExecuteReader(CommandType.Text, commandText.ToString(), l_parms.ToArray());
        }

        public IDataReader Get_All_TestReport(object objparams)
        {
            StringBuilder commandText = new StringBuilder();
            commandText.AppendLine(" SELECT " + TestReport_item_str + "");
            commandText.AppendLine("   FROM [TestReport]");
            commandText.AppendLine("   " + SqlHelper.Get_Where_Obj(objparams));
            List<DbParameter> l_parms = SqlHelper.Get_List_Params(TestReport_item_prop_a, objparams);
            return DbHelper.CTOSCustomer.ExecuteReader(CommandType.Text, commandText.ToString(), l_parms.ToArray());
        }

        public int Insert_TestReport(Entity.TestReport info, string[] Include, string[] Exclude)
        {
            List<DbParameter> l_parms = new List<DbParameter>();
            StringBuilder commandText = new StringBuilder();
            string item_name = string.Empty;
            string item_value = string.Empty;
            SqlHelper.Get_Inserte_Set(TestReport_item_prop_a, Include, Exclude, info, ref item_name, ref item_value, ref l_parms);
            commandText.AppendLine("INSERT INTO [TestReport] (" + item_name + ") VALUES (" + item_value + ")");
            return DbHelper.CTOSCustomer.ExecuteNonQuery(CommandType.Text, commandText.ToString(), l_parms.ToArray());
        }

        public int Update_TestReport(Entity.TestReport info, string[] Include, string[] Exclude)
        {
            List<DbParameter> l_parms = new List<DbParameter>();
            StringBuilder commandText = new StringBuilder();
            string set_str = string.Empty;
            SqlHelper.Get_Update_Set(TestReport_key_a, TestReport_item_prop_a, Include, Exclude, info, ref set_str, ref l_parms);
            commandText.AppendLine(" UPDATE [TestReport]");
            commandText.AppendLine("   SET " + set_str);
            commandText.AppendLine("   " + SqlHelper.Get_Where_Str(TestReport_key_a));
            return DbHelper.CTOSCustomer.ExecuteNonQuery(CommandType.Text, commandText.ToString(), l_parms.ToArray());
        }
        public int Update_TestReport_Name(Entity.TestReport info)
        {
            List<DbParameter> l_parms = new List<DbParameter>();
            StringBuilder commandText = new StringBuilder();
            commandText.AppendLine(" update TestReport set content = @content,createdate=@createdate where name=@name ");
            l_parms.Add(SqlHelper.MakeInParam("@content", (DbType)SqlDbType.NText, 2147483646, info.content));
            l_parms.Add(SqlHelper.MakeInParam("@createdate", (DbType)SqlDbType.DateTime,8,info.createdate));
            l_parms.Add(SqlHelper.MakeInParam("@name", (DbType)SqlDbType.NVarChar, 100, info.name));
            return DbHelper.CTOSCustomer.ExecuteNonQuery(CommandType.Text, commandText.ToString(), l_parms.ToArray());
        }
        public int Delete_TestReport(int id)
        {
            StringBuilder commandText = new StringBuilder();
            commandText.AppendLine(" DELETE FROM [TestReport]");
            commandText.AppendLine("   " + SqlHelper.Get_Where_Str(TestReport_key_a));
            List<DbParameter> l_parms = new List<DbParameter>();
            l_parms.Add(SqlHelper.MakeInParam("@id", (DbType)SqlDbType.Int, 4, id));
            return DbHelper.CTOSCustomer.ExecuteNonQuery(CommandType.Text, commandText.ToString(), l_parms.ToArray());
        }
        #endregion
    }
}
