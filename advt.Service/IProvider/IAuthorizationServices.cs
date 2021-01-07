using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace advt.Service.IProvider
{
    public interface IAuthorizationServices
    {
        Entity.advt_users Login(string userName, string password, int CookieTime = 0);

        /// <summary>
        /// 判斷該使用者是否有權限
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns>回傳User_ID</returns>
        Entity.advt_users Authenticate(string userName, string password);
    }
}
