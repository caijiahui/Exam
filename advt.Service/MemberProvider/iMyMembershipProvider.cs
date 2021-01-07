
namespace advt.Service.MemberProvider
{
    public interface iMyMembershipProvider
    {
        /// <summary>
        /// 用户提供验证
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        Entity.advt_users ValidateUser(string username, string password);
    }
}
