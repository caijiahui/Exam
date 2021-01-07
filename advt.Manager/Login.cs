using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace advt.Manager
{

    public class Login
    {
        private static iLogin ilogin;

        static Login()
        {
            ilogin = new LoginBase();
        }

        #region Var.

        #endregion

        #region LoginBase

        /// <summary>
        /// 当前用户时间
        /// </summary>
        public static DateTime DateTimeNow
        {
            get
            {
                return DateTime.Now;
            }
        }

        public static iLogin GetLogin()
        {
            return ilogin;
        }

        /// <summary>
        /// 清理Session缓存。
        /// </summary>
        public static void ClearSession()
        {
            GetLogin().ClearSession();
        }

        public static bool Isadmin
        {
            //get
            //{
            //    return GetLogin().Isadmin;
            //}
            get
            {
                HttpContext httpContext = HttpContext.Current;
                if (httpContext.Session["Isadmin"] != null)
                {
                    return (bool)httpContext.Session["Isadmin"];
                }
                else
                {

                    if (UserContext != null)
                    {
                        bool isadmin = true;
                        return isadmin;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
        }
        //public static bool IsAuthenticated
        //{
        //    get
        //    {
        //        return ERMA_User != null;
        //    }
        //}
        public Entity.advt_users UserInfo { get; set; }


        /// <summary>
        /// 用户信息
        /// </summary>
        /// <param name="httpContext"></param>
        /// <returns></returns>
        public static int UserID
        {
            get
            {
                if (ValidateUser)
                    return UserContext.id;
                else
                    return 0;
            }
        }

        /// <summary>
        /// 用户信息
        /// </summary>
        /// <param name="httpContext"></param>
        /// <returns></returns>
        public static Entity.advt_users UserContext
        {
            get
            {
                return GetLogin().UserContext;
            }
            set
            {
                GetLogin().UserContext = value;
            }
        }
      

        public static bool isGroupAdmin
        {
            get
            {
                return UserContext != null && (((UserContext.roles ?? 0) & ((byte)Entity.Status.RoleStatus.Groupadmin | (byte)Entity.Status.RoleStatus.Admin)) > 0);
            }
        }


        /// <summary>
        /// 验证用户是否登入
        /// </summary>
        /// <param name="httpContext"></param>
        /// <returns></returns>
        public static bool ValidateUser
        {
            get
            {
                return GetLogin().ValidateUser;
            }
        }
        #endregion


        public static bool IsAuthenticated_Page(int usergroupid, string area, string action, string controller)
        {
            if (usergroupid < 1) return false;

            return BLL.Nav.Get_All_advt_page_By_UserGroup_Cache(usergroupid).Where(
                a => a.parea.Equals(area, StringComparison.OrdinalIgnoreCase)
                    && a.paction.Equals(action, StringComparison.OrdinalIgnoreCase)
                    && a.pcontroller.Equals(controller, StringComparison.OrdinalIgnoreCase)).FirstOrDefault() != null;
        }

    }
}
