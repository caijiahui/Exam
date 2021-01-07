using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace advt.BLL
{
    public class Nav
    {
        public static List<Entity.advt_page> Get_All_advt_page_By_UserGroup_Cache(int usergroupid)
        {
            return Data.advt_page.Get_All_advt_page_By_UserGroup_Cache(usergroupid);
        }
    }
}
