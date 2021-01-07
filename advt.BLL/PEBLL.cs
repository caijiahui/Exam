using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace advt.BLL
{
    public class PEBLL
    {
       public static int Update_advt_CMSCategory(Entity.advt_CMSCategory info, string[] Include, string[] Exclude)
        {
            var data = Data.advt_CMSCategory.Update_advt_CMSCategory(info,Include,Exclude);
            return data;
        }
        public static List<KeyValuePair<string, string>> Get_All_State()
        {
            List<KeyValuePair<string, string>> List = new List<KeyValuePair<string, string>>();
            List.Add(new KeyValuePair<string, string>("Open", "Open"));
            List.Add(new KeyValuePair<string, string>("Close", "Close"));
            return List;
        }
        public static List<KeyValuePair<int,string>> Get_All_CategoryName()
        {
            List<KeyValuePair<int, string>> List = new List<KeyValuePair<int, string>>();
            var model = Data.advt_CMSCategory.Get_All_advt_CMSCategory();
            foreach (var item in model)
            {
                List.Add(new KeyValuePair<int, string>(item.id, item.categoryname));
            }
            return List;
        }
        public static List<KeyValuePair<string,string>> Get_All_Bit()
        {
            List<KeyValuePair<string, string>> List = new List<KeyValuePair<string, string>>();
            List.Add(new KeyValuePair<string, string>("packing", "组装"));
            List.Add(new KeyValuePair<string, string>("test", "测试"));
            return List;
        }
        public static List<KeyValuePair<string, string>> Get_All_Location()
        {
            List<KeyValuePair<string, string>> List = new List<KeyValuePair<string, string>>();
            List.Add(new KeyValuePair<string, string>("PE", "PE"));
            return List;
        }
        public static List<KeyValuePair<string, string>> Get_All_L_type()
        {
            List<KeyValuePair<string, string>> List = new List<KeyValuePair<string, string>>();
            List.Add(new KeyValuePair<string, string>("Administrators", "Administrators"));
            List.Add(new KeyValuePair<string, string>("Common", "Common"));
            return List;
        }
    }
}
