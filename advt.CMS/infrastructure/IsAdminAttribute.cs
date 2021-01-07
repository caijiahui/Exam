using System;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Text;
using advt.Common;
using advt.Entity.Global;
using advt.Data;
using advt.Entity;
using advt.Manager;

namespace advt.CMS
{

    [AttributeUsage(AttributeTargets.All, AllowMultiple = true)]
    public class IsAdminAttribute : MyAuthorizeAttribute
    {
        
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            if (!base.AuthorizeCore(httpContext)) return false;
            return Login.Isadmin;
        }

        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            base.OnAuthorization(filterContext);
            if (!Login.Isadmin)
            {
                filterContext.Result = new RedirectResult("~/Account/Login");
            }
        }

    }

    
}
