using System;
using advt.Common;

namespace advt.Service.MemberProvider
{
    /// <summary>
    /// Web 安全机制
    /// </summary>
    public class MyWebSecurity
    {
        /// <summary>
        /// 用户登入模组
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password">明码</param>
        /// <param name="CookieTime"></param>
        /// <returns></returns>
        public static Entity.advt_users Login(string userName, string password, int CookieTime = 0)
        {

            string CookiePWD = GetDBPwd(password); // MD5密码.

            Entity.advt_users advt_users = MyMembership.ValidateUser(userName, CookiePWD); //验证用户信息.

            return advt_users;


        }

        //MyFormsAuthentication
        //FormsAuthentication.SignOut();

        /// <summary>
        /// 新建用户，返回用户ID
        /// </summary>
        /// <param name="userName">用户名称</param>
        /// <param name="password">密码</param>
        /// <returns>新建用户ID</returns>
        public static int CreateUserAndAccount(Entity.advt_users model)
        {
            Entity.advt_users info = new Entity.advt_users();
            info.username = model.username;
            info.email = model.email;
            info.password = GetDBPwd(model.password);
            info.lastip = Common.wbRequest.GetIP();
            info.createdate = DateTime.Now;
            info.status = (int)Entity.Status.Normal.Enable;
            info.sex = model.sex;
            int userid = Data.advt_users.Insert_advt_users(info , new string[] { "username", "password", "lastip", "createdate", "status", "sex", "showemail","email"});
            return userid;

        }

        /// <summary>
        /// 保存数据库中的密码格式(加密PWD)
        /// </summary>
        /// <param name="password">明码</param>
        /// <returns></returns>
        public static string GetDBPwd(string password)
        {
            return Utils.MD5(password);
        }

    }

}
