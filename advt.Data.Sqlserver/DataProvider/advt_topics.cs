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
        #region advt_topics , (Ver:2.3.8) at: 2018/5/11 14:13:11
        #region Var: 
        private string[] advt_topics_key_a = { "id" };
        private string advt_topics_item_str = "[id],[fid],[tid],[pid],[createdt],[updatedt],[username],[state],[attachment],[filename],[casename],[description],[available],[item1],[item2],[item3],[item4],[item5],[item6],[item7],[item8],[item9],[item10]";
        private string[][] advt_topics_item_prop_a =
        {
            new string[] {"id", "Int", "4"},
            new string[] {"fid", "Int", "4"},
            new string[] {"tid", "Int", "4"},
            new string[] {"pid", "Int", "4"},
            new string[] {"createdt", "DateTime", "8"},
            new string[] {"updatedt", "DateTime", "8"},
            new string[] {"username", "NVarChar", "50"},
            new string[] {"state", "NVarChar", "20"},
            new string[] {"attachment", "NVarChar", "300"},
            new string[] {"filename", "NVarChar", "100"},
            new string[] {"casename", "NVarChar", "100"},
            new string[] {"description", "NVarChar", "1000"},
            new string[] {"available", "TinyInt", "1"},
            new string[] {"item1", "NVarChar", "1000"},
            new string[] {"item2", "NVarChar", "1000"},
            new string[] {"item3", "NVarChar", "1000"},
            new string[] {"item4", "NVarChar", "1000"},
            new string[] {"item5", "NVarChar", "1000"},
            new string[] {"item6", "NVarChar", "1000"},
            new string[] {"item7", "NVarChar", "1000"},
            new string[] {"item8", "NVarChar", "1000"},
            new string[] {"item9", "DateTime", "8"},
            new string[] {"item10", "NVarChar", "1000"}
        };
        #endregion

        public IDataReader Get_All_advt_topics(object objparams)
        {
            StringBuilder commandText = new StringBuilder();
            commandText.AppendLine(" SELECT " + advt_topics_item_str + "");
            commandText.AppendLine("   FROM [advt_topics]");
            commandText.AppendLine("   " + SqlHelper.Get_Where_Obj(objparams));
            List<DbParameter> l_parms = SqlHelper.Get_List_Params(advt_topics_item_prop_a, objparams);
            return DbHelper.PE.ExecuteReader(CommandType.Text, commandText.ToString(), l_parms.ToArray());
        }
        public IDataReader Get_All_Advt_topic_id(int PageSize, int pageIndex, int id, string searchdata, string startdt, string enddt)
        {
            StringBuilder commandText = new StringBuilder();
            //DateTime start = Convert.ToDateTime(startdt);
            //DateTime end = Convert.ToDateTime(enddt);
            //if (!string.IsNullOrEmpty(searchdata))
                searchdata = "%" + Utils.ChkSQL(searchdata) + "%";
            if (startdt == "")
                startdt = null;
            if (enddt == "")
                enddt = null;
            //commandText.AppendLine("select * from advt_topics  a where tid =@id and (a.username = @searchdata or a.description like @searchdata  ");
            //commandText.AppendLine("  or a.state = @searchdata or a.casename = @searchdata or a.item1 like @searchdata or a.item2 = @searchdata or a.item3 = @searchdata or a.item4 = @searchdata ");
            //commandText.AppendLine(" or a.item5 = @searchdata or a.item6 = @searchdata or a.item7 = @searchdata or a.item8 = @searchdata or a.item10 = @searchdata ) ");
            //commandText.AppendLine("  and (isnull(@startdt,'')=''and isnull(@enddt,'')='' or a.createdt>=@startdt and a.createdt<=@enddt) ");
            commandText.AppendLine("select * from ( select ids = Row_Number() over(order by createdt desc),* from advt_topics where tid=@id and available=2 ");
            commandText.AppendLine(" and (username like @searchdata or description like @searchdata or state like @searchdata or casename like @searchdata or item1 like @searchdata or item2 like @searchdata ");
            commandText.AppendLine(" or item3 like @searchdata or item4 like @searchdata  or item5 like @searchdata or item6 like @searchdata or item7 like @searchdata or item8 like @searchdata  or item10 like @searchdata or state like @searchdata) ");
            commandText.AppendLine(" and ((isnull(@startdt,'')=''and isnull(@enddt,'')='' or CONVERT(char(10),createdt,120)>=@startdt and CONVERT(char(10),createdt,120)<=@enddt) ) )tmp ");
            commandText.AppendLine(" where isnull(@startRow,0) = 0 and isnull(@endrow,0)=0 or tmp.ids>=@startRow and tmp.ids<=@endrow");
            int startRow = 0;
            int endRow = 0;
            if (PageSize != 0 && pageIndex != 0)
            {
                startRow = (pageIndex - 1) * PageSize + 1;
                endRow = startRow + PageSize - 1;
            }
            List<DbParameter> l_parms = new List<DbParameter>();
            l_parms.Add(SqlHelper.MakeInParam("@id", (DbType)SqlDbType.Int, 4, id));
            l_parms.Add(SqlHelper.MakeInParam("@searchdata", (DbType)SqlDbType.NVarChar, 100, searchdata));
            l_parms.Add(SqlHelper.MakeInParam("@startdt", (DbType)SqlDbType.DateTime, 50, startdt));
            l_parms.Add(SqlHelper.MakeInParam("@enddt", (DbType)SqlDbType.DateTime, 50, enddt));
            l_parms.Add(SqlHelper.MakeInParam("@startRow", (DbType)SqlDbType.Int, 4, startRow));
            l_parms.Add(SqlHelper.MakeInParam("@endRow", (DbType)SqlDbType.Int, 4, endRow));
            return DbHelper.PE.ExecuteReader(CommandType.Text,commandText.ToString(),l_parms.ToArray());
        }

        public int Insert_advt_topics(Entity.advt_topics info, string[] Include, string[] Exclude)
        {
            List<DbParameter> l_parms = new List<DbParameter>();
            StringBuilder commandText = new StringBuilder();
            string item_name = string.Empty;
            string item_value = string.Empty;
            SqlHelper.Get_Inserte_Set(advt_topics_item_prop_a, Include, Exclude, info, ref item_name, ref item_value, ref l_parms);
            commandText.AppendLine("INSERT INTO [advt_topics] (" + item_name + ") VALUES (" + item_value + ")");
            return DbHelper.PE.ExecuteNonQuery(CommandType.Text, commandText.ToString(), l_parms.ToArray());
        }

        public int Update_advt_topics(Entity.advt_topics info, string[] Include, string[] Exclude)
        {
            List<DbParameter> l_parms = new List<DbParameter>();
            StringBuilder commandText = new StringBuilder();
            string set_str = string.Empty;
            SqlHelper.Get_Update_Set(advt_topics_key_a, advt_topics_item_prop_a, Include, Exclude, info, ref set_str, ref l_parms);
            commandText.AppendLine(" UPDATE [advt_topics]");
            commandText.AppendLine("   SET " + set_str);
            commandText.AppendLine("   " + SqlHelper.Get_Where_Str(advt_topics_key_a));
            return DbHelper.PE.ExecuteNonQuery(CommandType.Text, commandText.ToString(), l_parms.ToArray());
        }

        public int Delete_advt_topics(int id)
        {
            StringBuilder commandText = new StringBuilder();
            commandText.AppendLine(" DELETE FROM [advt_topics]");
            commandText.AppendLine("   " + SqlHelper.Get_Where_Str(advt_topics_key_a));
            List<DbParameter> l_parms = new List<DbParameter>();
            l_parms.Add(SqlHelper.MakeInParam("@id", (DbType)SqlDbType.Int, 4, id));
            return DbHelper.PE.ExecuteNonQuery(CommandType.Text, commandText.ToString(), l_parms.ToArray());
        }
        #endregion
    }
}
