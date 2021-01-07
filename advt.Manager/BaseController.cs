using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using advt.Common;
using System.Web.Optimization;
using System.Web;
using System.Text.RegularExpressions;

namespace advt.Manager
{
    /// <summary>
    /// 基础 控制器
    /// </summary>
    public class BaseController : Controller
    {
        protected string _AttachmentUploadDirectory = "~/Attachment";
        protected string _AttachmentUploadDirectory_temp = "~/Attachment/temp";

        /// <summary>
        /// 是自适应站点
        /// </summary>
        public bool IsRWDPage
        {
            get
            {
                return true;
                //return Global.IsRWDPage();
            }
        }

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (!filterContext.IsChildAction)
            {
                ShowPage_Before();
            }
            base.OnActionExecuting(filterContext);
        }

        /// <summary>
        /// 存储Crystal的序号用于Print
        /// </summary>
        public string CrystalReport_CookieName = "CrystalReport";

        //public bool IsAuthenticated
        //{
        //    get
        //    {
        //        return Manager.Login.IsAuthenticated;
        //    }
        //}
        private void ShowPage_Before()
        {
            try
            {
                Title = advt.Config.BaseConfigs.GetBaseConfig().CompanyInfo;

                Meta_keywords = "";

                Meta_description = "";

                string realurl = Common.wbRequest.GetUrl();

                if (realurl.IndexOf("common/attachment/download") > -1) return;

                Entity.advt_log advt_log = new Entity.advt_log();

                advt_log.id = Guid.NewGuid();

                advt_log.type = 1;

                if (UserContext != null) advt_log.uid = UserID;

                string ser = Request.ServerVariables["LOCAL_ADDR"];

                string form_data = string.Empty;

                if (Request.Form.AllKeys.Count() > 0)
                {
                    for (int i = 0; i < Request.Form.AllKeys.Count(); i++)
                    {
                        if (Request.Form[i] != null && !Request.Form.AllKeys[i].Equals("__RequestVerificationToken", StringComparison.CurrentCultureIgnoreCase))
                        {
                            form_data += "&" + Request.Form.Keys[i].ToString() + "=" + Request.Form[i].ToString();
                        }
                    }
                }

                if (Request.QueryString.AllKeys.Count() > 0)
                {
                    form_data += "[QStr:]";

                    for (int i = 0; i < Request.QueryString.AllKeys.Count(); i++)
                    {
                        if (Request.QueryString[i] != null)
                        {
                            form_data += "&" + Request.QueryString.Keys[i].ToString() + "=" + Request.QueryString[i].ToString();
                        }
                    }
                }

                string fromip = Common.wbRequest.GetIP();

                advt_log.fromip = fromip;

                advt_log.data = "(" + ser + ")" + "[FData]" + form_data.Trim('&');

                if (Request.UrlReferrer != null) advt_log.fromurl = Request.UrlReferrer.AbsoluteUri;

                advt_log.url = realurl;

                advt_log.createdt = DateTime.Now;

                Data.advt_log.Insert_advt_log(advt_log);
            }
            catch
            {
            }
        }
        protected Entity.advt_users advt_user
        {
            get
            {
                return Login.UserContext;
            }
        }

        #region Var
        /// <summary>
        /// 用户信息，如果没取到说明用户没有登录
        /// </summary>
        public Entity.advt_users UserContext
        {
            get
            {
                return Login.UserContext;
            }
        }

        /// <summary>
        /// 用户ID(必须存在才可以登入)
        /// </summary>
        public int UserID
        {
            get
            {
                if (UserContext != null)
                    return UserContext.id;
                else
                    return 0;
            }
        }

        public string Meta_keywords
        {
            get { return ViewBag.meta_keywords as string; }
            set { ViewBag.meta_keywords = value; }
        }

        public string Meta_description
        {
            get { return ViewBag.meta_description as string; }
            set { ViewBag.meta_description = value; }
        }

        /// <summary>
        /// Head Title
        /// </summary>
        public string Title
        {
            get { return ViewBag.Title as string; }
            set { ViewBag.Title = value; }
        }

        #endregion

        #region Function
        /// <summary>
        /// dialog 模式  alert,right 有确定按钮,confirm,有确定和取消按钮,notice有确定按钮,info没有按钮
        /// </summary>
        protected enum MsgMode
        {
            /// <summary>
            /// 有确定按钮
            /// </summary>
            alert,
            /// <summary>
            /// 有确定按钮
            /// </summary>
            right,
            /// <summary>
            /// 有确定和取消按钮
            /// </summary>
            confirm,
            /// <summary>
            /// 有确定按钮
            /// </summary>
            notice,
            /// <summary>
            /// 没有按钮
            /// </summary>
            info
        }

        public void alert_rwd(string msg)
        {
            Dialog_RWD(new { msg = msg });
        }

        protected void Dialog_RWD(object option)
        {
            string msg = Utils.GetValueStringByProp(option, "msg");//(必填) 提示信息内容
            string mode = Utils.GetValueStringByProp(option, "mode") == string.Empty ? MsgMode.alert.ToString() : Utils.GetValueStringByProp(option, "mode");//对话框模式
           
            StringBuilder sb = new StringBuilder();
            sb.Append("<div class=\"alert alert-warning alert-fixed-top\">");
            sb.Append("<div class=\"container\">");
            sb.Append("<a href=\"#\" class=\"close\" data-dismiss=\"alert\">&times;</a>");
            sb.AppendFormat("<p class=\"alert-tt\"><strong>{0}</strong></p>", "警告！");
            sb.AppendFormat("<p class=\"alert-msg\">{0}</p>", msg);
            sb.Append("</div>");
            sb.Append("</div>");

            TempData["MSG"] += sb.ToString();
        }

        /// <summary>
        /// msg('msg');
        /// </summary>
        /// <param name="msg"></param>
        public void msg(string msgstr)
        {
            msg(msgstr, string.Empty);
        }

        /// <summary>
        /// msg('msg',url);
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="url"></param>
        protected void msg(string msg, string url)
        {
            Dialog(new
            {
                msg = msg,
                mode = MsgMode.notice.ToString(),
                locationtime = string.IsNullOrEmpty(url) ? "" : "3",
                func = string.IsNullOrEmpty(url) ? "" : ("function(){window.location.href=\"" + JavaScriptStringEncode(url) + "\";}")
            });
        }

        /// <summary>
        /// msg('msg',url);
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="url"></param>
        public void right(string msgstr)
        {
            right(msgstr, string.Empty);
        }

        /// <summary>
        /// msg('msg',url);
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="url"></param>
        protected void right(string msg, string url)
        {
            Dialog(new
            {
                msg = msg,
                mode = MsgMode.right.ToString(),
                locationtime = string.IsNullOrEmpty(url) ? "" : "3",
                func = string.IsNullOrEmpty(url) ? "" : ("function(){window.location.href=\"" + JavaScriptStringEncode(url) + "\";}")
            });
        }

        /// <summary>
        /// msg('msg');
        /// </summary>
        /// <param name="msg"></param>
        public void alert(string msg)
        {
            alert(msg, string.Empty);
        }

        /// <summary>
        /// msg('msg',url);
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="url"></param>
        protected void alert(string msg, string url)
        {
            Dialog(new
            {
                msg = msg,
                mode = MsgMode.alert.ToString(),
                locationtime = string.IsNullOrEmpty(url) ? "" : "3",
                func = string.IsNullOrEmpty(url) ? "" : ("function(){window.location.href=\"" + JavaScriptStringEncode(url) + "\";}")
            });
        }

        /// <summary>
        ///弹出对话框，
        ///弹出层
        ///msg:   (必填) 提示信息内容
        ///mode:  'alert' 对话框模式
        ///              alert/right:有确定按钮
        ///              confirm:有确定和取消按钮
        ///              notice:有确定按钮
        ///              info:没有按钮
        ///t:    '提示信息' 对话框标题	
        ///func:     点“确定”执行的函数
        ///cover:         是否显示一个遮罩覆盖整个页面 1: 是 0:否
        ///funccancel:    点“取消”执行的函数	
        ///leftmsg:      底部左侧信息
        ///confirmtxt:   '确定' 确定按钮的文字	
        ///canceltxt:    '取消' 取消按钮的文字	
        ///closetime:    自动关闭的时间,单位“秒”  leftmsg: 强制更改为“n 秒后窗口关闭”
        ///locationtime: 自动跳转时间，单位“秒”   leftmsg: 强制更改为“n 秒后页面跳转”
        /// </summary>
        /// <param name="option"></param>
        protected void Dialog(object option)
        {
            string msg = Utils.GetValueStringByProp(option, "msg");//(必填) 提示信息内容
            string mode = Utils.GetValueStringByProp(option, "mode") == string.Empty ? MsgMode.alert.ToString() : Utils.GetValueStringByProp(option, "mode");//对话框模式
            string t = Utils.GetValueStringByProp(option, "t");// '提示信息' 对话框标题	
            string func = Utils.GetValueStringByProp(option, "func");// 点“确定”执行的函数	
            string cover = TypeConverter.ObjectToInt(Utils.GetValueStringByProp(option, "cover"), 1).ToString(); //1 (mode = 'info' 时为 0) 是否显示一个遮罩覆盖整个页面	 1: 是 0:否
            string funccancel = Utils.GetValueStringByProp(option, "funccancel");//点“取消”执行的函数	
            string leftmsg = Utils.GetValueStringByProp(option, "leftmsg"); //底部左侧信息	
            string confirmtxt = Utils.GetValueStringByProp(option, "confirmtxt"); //'确定' 确定按钮的文字	
            string canceltxt = Utils.GetValueStringByProp(option, "canceltxt"); //取消' 取消按钮的文字	
            string closetime = Utils.GetValueStringByProp(option, "closetime"); // 自动关闭的时间,单位“秒”  leftmsg: 强制更改为“n 秒后窗口关闭”
            string locationtime = Utils.GetValueStringByProp(option, "locationtime"); //自动跳转时间，单位“秒”   leftmsg: 强制更改为“n 秒后页面跳转”

            if (func == string.Empty) func = "''";
            if (funccancel == string.Empty) funccancel = "''";

            StringBuilder sb = new StringBuilder();
            bool hasview = true;
            if (!hasview)
            {
                sb.AppendLine(Styles.Render("~/Content/css").ToString());
            }
            string JS_Win_load_str = string.Format("showDialog('{0}','{1}','{2}',{3},'{4}',{5},'{6}','{7}','{8}','{9}','{10}');"
                , JavaScriptStringEncode(msg)
                , JavaScriptStringEncode(mode)
                , JavaScriptStringEncode(t)
                , func
                , cover
                , funccancel
                , JavaScriptStringEncode(leftmsg)
                , JavaScriptStringEncode(confirmtxt)
                , JavaScriptStringEncode(canceltxt)
                , closetime
                , locationtime);
            sb.AppendLine(XUtils.JS_Win_load(JS_Win_load_str));

            TempData["MSG"] += sb.ToString();

        }

        /// <summary>
        /// Script 编码
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        protected string JavaScriptStringEncode(string message)
        {
            if (string.IsNullOrEmpty(message))
            {
                return message;
            }
            return HttpUtility.JavaScriptStringEncode(message);
        }

        protected ActionResult RedirectToLocal(string returnUrl)
        {
            return RedirectToLocal(returnUrl
                , Url.Action(string.Empty, "Home", new { Area = "" }));
        }

        protected ActionResult RedirectToLocal(string returnUrl, string home)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return this.Redirect(returnUrl);
            }
            else
            {
                return this.Redirect(home);
            }
        }

        #endregion
    }
}
