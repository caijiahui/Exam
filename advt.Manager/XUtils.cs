using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using advt.Common;
using System.Web;
using System.Text.RegularExpressions;
using advt.Config;
using System.Web.Routing;
using System.Net.Mail;
using System.Data;
using System.Data.OleDb;

namespace advt.Manager
{
    /// <summary>
    /// 一般为直接返回到View中的Html (View通用)
    /// </summary>
    public class XUtils
    {

        /// <summary>
        /// 验证码生成的取值范围
        /// </summary>
        private static string[] verifycodeRange = { "1","2","3","4","5","6","7","8","9",
                                                    "a","b","c","d","e","f","g",
                                                    "h","j","k","m","n","p","q","r",
                                                    "s","t","u","v","w","x","y"};
        /// <summary>
        /// 生成验证码所使用的随机数发生器
        /// </summary>
        private static Random verifycodeRandom = new Random();

        /// <summary>
        /// 打开的时候返回Html的容器ID号
        /// </summary>
        /// <returns></returns>
        public static string rRandom()
        {
            return new Random().Next(10000, 99999).ToString();
        }

        /// <summary>
        /// 打开的时候返回Html的容器ID号
        /// </summary>
        /// <returns></returns>
        public static string get_AjaxTarget()
        {
            return Common.wbRequest.GetString("ajaxtarget").Trim();
        }

        /// <summary>
        /// showid
        /// </summary>
        /// <returns></returns>
        public static string get_fwin_ShowID()
        {
            return get_AjaxTarget().Replace("fwin_content_", ""); ;
        }

        /// <summary>
        /// js 在window load 事件中添加。干扰字符请：HttpUtility.JavaScriptStringEncode(script);
        /// </summary>
        /// <param name="script"></param>
        /// <returns></returns>
        public static string JS_Win_load(string script)
        {
            if (string.IsNullOrEmpty(script)) return string.Empty;
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<script type=\"text/javascript\">");
            sb.AppendLine(" _attachEvent(window, 'load', function(){");
            sb.AppendLine(script);
            sb.AppendLine(" }, document);");
            sb.AppendLine("</script>");
            return sb.ToString();
        }


        /// <summary>
        /// Ep:Tel: @XUtils.WordWrap(V_eRMA_Location_Report.Phone_Report) 
        /// </summary>
        /// <param name="str"></param>
        /// <param name="splitstr">[br]|<br></param>
        /// <returns></returns>
        public static MvcHtmlString WordWrap(string str)
        {
            return WordWrap(str, "<br>|<BR>|[br]");
        }

        /// <summary>
        /// Ep:Tel: @XUtils.WordWrap(V_eRMA_Location_Report.Phone_Report, "<br />|<br/>|<br>|<BR>") 
        /// </summary>
        /// <param name="str"></param>
        /// <param name="splitstr">[br]|<br></param>
        /// <returns></returns>
        public static MvcHtmlString WordWrap(string str, string splitstr)
        {
            if (string.IsNullOrEmpty(str)) return new MvcHtmlString(string.Empty);

            if (splitstr != "")
            {
                foreach (string sp_str in splitstr.Split('|'))
                {
                    if (sp_str != "")
                    {
                        str = str.Replace(sp_str, "\r\n");
                    }
                }
            }
            str = Utils.HtmlEncode(str).Replace("\r\n", "<br>");
            return new MvcHtmlString(str);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="str"></param>
        /// <param name="splitstr">[br]|<br></param>
        /// <returns></returns>
        public static MvcHtmlString WordWrap_Input(string str, string width, string cls, string splitstr = "")
        {
            if (string.IsNullOrEmpty(str)) return new MvcHtmlString(string.Empty);

            if (splitstr != "")
            {
                foreach (string sp_str in splitstr.Split('|'))
                {
                    if (sp_str != "")
                    {
                        str = str.Replace(sp_str, "\r\n");
                    }
                }
            }
            if (!string.IsNullOrEmpty(cls))
                cls = " class=\"" + cls + "\"";
            else
                cls = string.Empty;

            if (!string.IsNullOrEmpty(width))
                width = " style=\"width: " + width + "px;\"";
            else
                width = string.Empty;

            StringBuilder sb = new StringBuilder();
            foreach (string line in Utils.SplitString(str, "\r\n"))
            {
                sb.AppendFormat("<input" + cls + width + " type=\"text\" value=\"" + Utils.HtmlEncode(line) + "\" />");
            }
            return new MvcHtmlString(sb.ToString());
        }


        /// <summary>
        /// 是否是ajax(true,false), inajax = 1是，= 0否，-1没值
        /// </summary>
        public static HtmlString HTML_NoData
        {
            get
            {
                return new HtmlString("<div class=\"box box-primary nodata top10\">"
+ "<div class=\"box-header with-border\">"
+ "<h3 class=\"box-title\">温馨提醒</h3>"
+ "</div>"
+ "<div class=\"box-body text-danger text-center\">"
+ "抱歉，系统中没有资料。"
+ "</div>"
+ "</div>");
            }
        }

        /// <summary>
        /// 是否是ajax(true,false), inajax = 1是，= 0否，-1没值
        /// </summary>
        public static bool Inajax
        {
            get
            {
                int int_inajax = Common.wbRequest.GetInt("inajax", -1);
                return int_inajax == 1;
            }
        }

        public static HtmlString ClassInfloat(string classname = "infloat")
        {
            return new HtmlString(Inajax ? " class='" + classname + "'" : "");
        }

        /// <summary>
        /// Ajax的时候 Dialog的随机数。唯一Key
        /// </summary>
        public static string Inajax_key
        {
            get
            {
                return wbRequest.GetString("k").Trim();
            }
        }

        /// <summary>
        /// 是否标记为ajax
        /// </summary>
        public static HtmlString InajaxFlag
        {
            get
            {
                return Inajax ? new HtmlString("data-ajax=\"true\"") : null;
            }
        }

        /// <summary>
        /// 写登录用户的cookie (密码为MD5)
        /// </summary>
        /// <param name="userinfo">用户信息</param>
        /// <param name="expires">cookie有效期(分)</param>
        /// <param name="passwordkey">用户密码Key</param>
        /// <param name="invisible">用户当前的登录模式(正常或隐身)</param>
        public static void WriteUserCookie(Entity.advt_users advt_users, int expires, string passwordkey, int invisible)
        {
            if (advt_users == null) return;

            HttpCookie cookie = new HttpCookie(Config.BaseConfigs.Cookiename);
            cookie.Values["id"] = advt_users.id.ToString();
            cookie.Values["pwd"] = Utils.UrlEncode(XUtils.SetCookiePassword(advt_users.password, passwordkey));
            cookie.Values["invisible"] = invisible.ToString();
            if (expires > 0)
            {
                cookie.Expires = DateTime.Now.AddMinutes(expires);
            }
            string cookieDomain = Config.BaseConfigs.Cookiedomain;
            if (cookieDomain != string.Empty
                && HttpContext.Current.Request.Url.Host.IndexOf(cookieDomain.TrimStart('.')) > -1
                && XUtils.IsValidDomain(HttpContext.Current.Request.Url.Host))
            {
                cookie.Domain = cookieDomain;
            }
            HttpContext.Current.Response.AppendCookie(cookie);
        }

        /// <summary>
        /// 清除登录cookie
        /// </summary>
        public static void ClearCookie()
        {
            ClearCookie(Config.BaseConfigs.Cookiename);
        }

        /// <summary>
        /// 清除登录cookie
        /// </summary>
        /// <param name="cookieName">可以指定清楚的CookieName</param>
        public static void ClearCookie(string cookieName)
        {
            HttpCookie cookie = new HttpCookie(cookieName);
            cookie.Values.Clear();
            cookie.Expires = DateTime.Now.AddYears(-1);
            string cookieDomain = Config.BaseConfigs.Cookiedomain;
            if (cookieDomain != string.Empty
                && HttpContext.Current.Request.Url.Host.IndexOf(cookieDomain.TrimStart('.')) > -1
                && IsValidDomain(HttpContext.Current.Request.Url.Host))
                cookie.Domain = cookieDomain;
            HttpContext.Current.Response.AppendCookie(cookie);
        }

        /// <summary>
        /// 是否为有效域
        /// </summary>
        /// <param name="host">域名</param>
        /// <returns></returns>
        public static bool IsValidDomain(string host)
        {
            if (host.IndexOf(".") == -1)
                return false;

            return new Regex(@"^\d+$").IsMatch(host.Replace(".", string.Empty)) ? false : true;
        }

        /// <summary>
        /// 返回论坛用户密码cookie明文
        /// </summary>
        /// <param name="password">密码密文</param>
        /// <param name="key">密钥</param>
        /// <returns></returns>
        public static string GetCookiePassword(string password, string key)
        {
            return DES.Decode(Utils.UrlDecode(password).Replace("[", "+"), key);
        }

        /// <summary>
        /// 返回密码密文
        /// </summary>
        /// <param name="password">密码明文</param>
        /// <param name="key">密钥</param>
        /// <returns></returns>
        public static string SetCookiePassword(string password, string key)
        {
            return DES.Encode(password, key).Replace("+", "[");
        }

        /// <summary>
        /// 返回用户安全问题答案的存储数据
        /// </summary>
        /// <param name="questionid">问题id</param>
        /// <param name="answer">答案</param>
        /// <returns></returns>
        public static string GetUserSecques(int questionid, string answer)
        {
            if (questionid > 0)
                return Utils.MD5(answer + Utils.MD5(questionid.ToString())).Substring(15, 8);

            return "";
        }
        /// <summary>
        /// 产生验证码
        /// </summary>
        /// <param name="len">长度</param>
        /// <param name="OnlyNum">是否仅为数字</param>
        /// <returns>string</returns>
        public static string CreateAuthStr(int len, bool OnlyNum)
        {
            int number;
            StringBuilder checkCode = new StringBuilder();

            for (int i = 0; i < len; i++)
            {
                if (!OnlyNum)
                    number = verifycodeRandom.Next(0, verifycodeRange.Length);
                else
                    number = verifycodeRandom.Next(0, 10);

                checkCode.Append(verifycodeRange[number]);
            }
            return checkCode.ToString();
        }

        public static HtmlString GetClassBySession(object viewbag, string key)
        {
            if (viewbag != null)
            {
                if (viewbag.ToString() == key)
                {
                    return new HtmlString(" class=\"active\"");
                }
            }
            return null;
        }
        
        /// <summary>
        /// 发送邮件的部分
        /// </summary>
        /// <param name="option">
        /// subject:发送邮件的标题.
        /// from: 发送邮件的人邮件地址. default:"erma@advantech.com.tw"
        /// to: 接收邮件的人邮件地址. 多个用","隔开. (必填项，如果不填退出发送邮件Function)
        /// body: 收信的内容.
        /// cc: 抄送. ex: new string[] { "test@advantech.com.cn"};
        /// bcc: 暗送. ex: new string[] { "test@advantech.com.cn"};
        /// attachments: 附件.  ex: List《System.Net.Mail.Attachment》;
        /// </param>
        public static bool SendEmail(object option)
        {
            return true;
        }

        /// <summary>
        /// 获取 Excel 中的数据
        /// </summary>
        /// <param name="fileName">文件的 fullName</param>
        /// <param name="selectCommandText">selectCommandText</param>
        /// <returns></returns>
        public static DataSet GetDataFromExcel(string fileName, string[] selectCommandText)
        {
            DataSet ds = new DataSet();

            string connectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + fileName + ";Extended Properties=Excel 8.0;";
            OleDbConnection conn = new OleDbConnection(connectionString);

            try
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();

                for (int i = 0; i < selectCommandText.Length; i++)
                {
                    using (OleDbDataAdapter oda = new OleDbDataAdapter(selectCommandText[i], conn))
                    {
                        oda.Fill(ds, "Table" + i.ToString());
                    }
                }
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }

            foreach (DataTable dt in ds.Tables)
            {
                RemoveNullRowsFromDT(dt);
            }

            ds.AcceptChanges();

            return ds;
        }

        /// <summary>
        /// 移除 DataTable 不存在数据或数据全为空的行
        /// </summary>
        /// <param name="dataTable"></param>
        private static void RemoveNullRowsFromDT(DataTable dataTable)
        {
            int rowNums = dataTable.Rows.Count;
            for (int i = rowNums - 1; i >= 0; i--)
            {
                bool flag = true;
                DataRow dr = dataTable.Rows[i];
                for (int j = 0; j < dataTable.Columns.Count; j++)
                {
                    if (!String.IsNullOrWhiteSpace(dr[j].ToString()))
                    {
                        flag = false;
                        break;
                    }
                }
                if (flag)
                    dr.Delete();
            }

            dataTable.AcceptChanges();
        }

    }
}
