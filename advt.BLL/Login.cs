using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace advt.BLL
{
    public class Login
    {
        public static Entity.advt_users Get_User(string username)
        {
            return Data.advt_users.Get_advt_users(new { username = username });
        }

        public static List<Entity.advt_user_group> GetAllUserGroup()
        {
            return Data.advt_user_group.Get_All_advt_user_group();
        }

        public static int GetChatRoles(Entity.advt_users advt_users)
        {
            return 1;//advt_users.usergroupid != null && (advt_users.usergroupid == 3 || advt_users.usergroupid == 1) ? 1 : 0;
        }

        public static bool CheckUserName(string username)
        {
            if (username == null) return false;
            return Regex.IsMatch(username, "^[\\w]+$");
        }

        public static bool CheckMobile(string Mobile)
        {
            if (Mobile == null) return false;
            return Regex.IsMatch(Mobile, "^([+]?)[\\d]+$");
        }

        public static bool CheckPhone(string Phone)
        {
            if (Phone == null) return false;
            return Regex.IsMatch(Phone, "^[\\d \\+]+$");
        }
    }
}
