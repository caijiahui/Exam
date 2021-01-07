using System;

namespace advt.Service.MemberProvider
{
    /// <summary>
    /// 管理验证信息的存储。加密等等。
    /// </summary>
    public class MyFormsAuthentication
    {
        /// <summary>
        /// 写入Cookie
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="persistCookie"></param>
        public static void SetAuthCookie(string id, bool persistCookie, string ipAddress)
        {
            throw new NotImplementedException();
        }
    }
}
