using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using advt.Common;
using advt.Config;
using System.Web.Security;
using Newtonsoft.Json;

namespace advt.Manager
{
    public class LoginBase : iLogin
    {
        public void ClearSession()
        {
            HttpContext httpContext = HttpContext.Current;
            httpContext.Session["UserContext"] = null;
        }

        public bool Isadmin
        {
            get
            {
                if (UserContext != null)
                    return UserContext.roles == (byte)Entity.Status.RoleStatus.Admin;
                else
                    return false;
            }
        }

        public bool ValidateUser
        {
            get
            {
                return UserContext != null;
            }
        }

        /// <summary>
        /// 用户信息
        /// </summary>
        /// <param name="httpContext"></param>
        /// <returns></returns>
        public Entity.advt_users UserContext
        {
            get
            {
                HttpContext httpContext = HttpContext.Current;

                if (httpContext.Session["UserContext"] != null)
                {
                    return httpContext.Session["UserContext"] as Entity.advt_users;
                }
                else
                {
                    int id = TypeConverter.ObjectToInt(Utils.GetCookie(Config.BaseConfigs.Cookiename, "id"));
                    if (id <= 0) return null;
                    string pwd = Utils.GetCookie(Config.BaseConfigs.Cookiename, "pwd");
                    pwd = XUtils.GetCookiePassword(pwd, Config.BaseConfigs.Passwordkey);
                    if (pwd.Equals(string.Empty)) return null;
                    //Check PWD
                    Entity.advt_users userinfo = Data.advt_users.Get_advt_users(id);
                    if(userinfo!=null)
                    {
                        if (userinfo.password.Equals(pwd) && userinfo.status != (int)Entity.Status.Normal.Disable)
                        {
                            httpContext.Session["UserContext"] = userinfo;
                            Data.advt_users.Update_advt_users_LastIP(userinfo.id, Common.wbRequest.GetIP());
                        }
                    }
                    else
                    {
                        httpContext.Session["UserContext"] = null;
                        Utils.WriteCookie(Config.BaseConfigs.Cookiename, "");
                    }

                }
                if (httpContext.Session["UserContext"] != null)
                {

                    Entity.advt_users advt_users = httpContext.Session["UserContext"] as Entity.advt_users;

                    if (!httpContext.User.Identity.IsAuthenticated)
                    {
                        string nickname = advt_users.nickname;
                        if (string.IsNullOrWhiteSpace(nickname)) nickname = advt_users.firstname + advt_users.lastname;
                        if (string.IsNullOrWhiteSpace(nickname)) nickname = advt_users.username;

                        string Datastr = JsonConvert.SerializeObject(new Entity.Global.TicketData
                        {
                            name = advt_users.username.Trim(),
                            nickname = nickname,
                            ipaddress = Common.wbRequest.GetIP(),
                            role = BLL.Login.GetChatRoles(advt_users)
                        });

                        UserLogin(advt_users.id.ToString(), Datastr, false, Config.BaseConfigs.Cookiedomain);
                    }

                    return advt_users;
                }
                else
                {
                    if (httpContext.User.Identity.IsAuthenticated)
                    {
                        FormsAuthentication.SignOut();
                    }
                    return null;
                }


            }
            set
            {
                HttpContext httpContext = HttpContext.Current;
                httpContext.Session["UserContext"] = value;
            }
        }


        public static void UserLogin(string loginName, string UserData, bool RememberMe, string cookieDomain)
        {
            //设置用户的 cookie 的值
            FormsAuthentication.SetAuthCookie(loginName, RememberMe);

            //获取用户的 cookie 
            HttpCookie cookie = FormsAuthentication.GetAuthCookie(loginName, false, FormsAuthentication.FormsCookiePath);

            //给用户的 cookie 的值加上 cookie 的域 和 过期日期
            //向客户端重写同名的 用户 cookie
            FormsAuthenticationTicket oldTicket = FormsAuthentication.Decrypt(cookie.Value);
            FormsAuthenticationTicket newTicket = new FormsAuthenticationTicket(
                1,
                oldTicket.Name,
                oldTicket.IssueDate,
                oldTicket.Expiration,
                oldTicket.IsPersistent,
                UserData == string.Empty ? oldTicket.UserData : UserData,
                FormsAuthentication.FormsCookiePath);
            cookie.Domain = cookieDomain;
            cookie.Value = FormsAuthentication.Encrypt(newTicket);
            System.Web.HttpContext.Current.Response.Cookies.Add(cookie);
        }

    }
}
