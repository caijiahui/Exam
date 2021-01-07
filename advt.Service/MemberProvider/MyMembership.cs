using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace advt.Service.MemberProvider
{
    /// <summary>
    /// MemberShip 你懂的。
    /// </summary>
    public class MyMembership
    {
        private static object lockHelper = new object();
        private static iMyMembershipProvider s_Provider;
        private static void GetProvider()
        {
            try
            {
                s_Provider = (iMyMembershipProvider)new MyMembershipProvider();
            }
            catch
            {
                throw new Exception("Database Error!");
            }
        }
        public static iMyMembershipProvider GetInstance()
        {
            if (s_Provider == null)
            {
                lock (lockHelper)
                {
                    if (s_Provider == null)
                    {
                        GetProvider();
                    }
                }
            }
            return s_Provider;
        }

        /// <summary>
        /// 用户验证，到DB验证(⊙o⊙)哦~
        /// </summary>
        /// <param name="username">用户名</param>
        /// <param name="password">MD5后密码</param>
        /// <returns></returns>
        public static Entity.advt_users ValidateUser(string username, string password)
        {
            return GetInstance().ValidateUser(username, password);
        }
    }
}
