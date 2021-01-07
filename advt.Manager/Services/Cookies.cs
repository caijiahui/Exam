using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace advt.Manager.Services
{
    /// <summary>
    /// Cookie 服务
    /// </summary>
    public class Cookies
    {
        /// <summary>
        /// 选择Cookie保存时间.
        /// </summary>
        public static List<SelectListItem> CookieTimesList
        {
            get
            {
                List<SelectListItem> linfo = new List<SelectListItem>();
                linfo.Add(new SelectListItem { Text = "===不保存===", Value = "0" });
                linfo.Add(new SelectListItem { Text = "一星期", Value = "10080" });
                linfo.Add(new SelectListItem { Text = "一个月", Value = "302400" });
                linfo.Add(new SelectListItem { Text = "一年", Value = "3679200" });
                return linfo;
            }
        }
    }
}
