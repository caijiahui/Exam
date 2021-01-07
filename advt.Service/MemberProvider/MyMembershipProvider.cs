using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using advt.Data;

namespace advt.Service.MemberProvider
{
    public class MyMembershipProvider : iMyMembershipProvider
    {
        /// <summary>
        /// 用户提供验证
        /// </summary>
        /// <param name="username">用户名</param>
        /// <param name="password">密码</param>
        /// <returns></returns>
        public Entity.advt_users ValidateUser(string username, string password)
        {
            //TODO:...
            Entity.advt_users info = Data.advt_users.Get_advt_users(new { username = username });//需要修改
            if (info != null && info.password.Equals(password))
                return info;
            else
                return null;
        }
    }
}
