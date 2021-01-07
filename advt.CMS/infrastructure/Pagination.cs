using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web.Mvc;
using System.Web.Routing;
using System.Reflection;
using advt.Common;

namespace System.Web.Mvc
{

        //public ActionResult Index(Int32? Page)
        //{
        //    ViewBag.Index = Page != null ? Page : 1;
        //    ViewBag.PageSize = 8;
        //    ViewBag.RecordCount = 9999999;
        //    return View();
        //}

// ajax-... @Html.Pagination((int)ViewBag.PageSize, (int)ViewBag.Index, (int)ViewBag.RecordCount, new { @AjaxScript_type = 1, @ViewType = 1 })
//<h2>自定义方式分页(分部模版)</h2>
//<div class="Pagination">@Html.Pagination((int)ViewBag.PageSize, (int)ViewBag.Index, (int)ViewBag.RecordCount, new { @ViewType = 3, @Template = "{List}", @Postfix = ".html", @VirtualPath = "/news-list-", @Identifier = "page", @Encrypt = false })</div>
//<div class="fclear"></div>
//<h2>自定义方式分页</h2>
//<div class="Pagination">@Html.Pagination((int)ViewBag.PageSize, (int)ViewBag.Index, (int)ViewBag.RecordCount, new { @ViewType = 3, @Postfix = ".html", @VirtualPath = "/news-list-" })</div>
//<h2>GET方式分页(英文)</h2>
//<div class="Pagination">@Html.Pagination((int)ViewBag.PageSize, (int)ViewBag.Index, (int)ViewBag.RecordCount, new { @ViewType = 1, @Identifier = "page", @Encrypt = false })</div>
//<div class="fclear"></div>
//<h2>GET方式分页</h2>
//<div class="Pagination">@Html.Pagination((int)ViewBag.PageSize, (int)ViewBag.Index, (int)ViewBag.RecordCount, new { @ViewType = 0, @Identifier = "page", @Encrypt = false })</div>


    /// <summary>
    /// HTML 扩展控件
    /// </summary>
    public static partial class HtmlExtension
    {
        #region 分页控件
        /// <summary>
        /// * <span>共：{RecordCount}条 {PageSize}条/页 {CurrentPage}页/{PageCount}页</span> {List}
        /// * <span>Page {CurrentPage} of {PageCount} ({RecordCount} items) PageSize：{PageSize}</span> {List}
        /// * @ViewType = 0,   0中文 1英文 2自定义中文 3自定义英文
        /// * @Template = "<span>共：{RecordCount}条 {PageSize}条/页 {CurrentPage}页/{PageCount}页</span> {List}", 
        /// * @Postfix = "", 
        /// * @VirtualPath = "", 
        /// * @Identifier = "page", 
        /// * @Encrypt = false },
        /// * @SearchParameter {...},(Ajax Model)
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="PageSize">单页条数</param>
        /// <param name="CurrentPage">当前页</param>
        /// <param name="RecordCount">总记录数</param>
        /// <param name="Attribute">扩展参数</param>
        /// <returns></returns>
        public static MvcHtmlString Pagination(this HtmlHelper helper, Int32 PageSize, Int32 CurrentPage, Int32 RecordCount, Object Attribute)
        {
            String ajaxupdate = string.Empty;

            // Dialog窗口id， 默认为空
            String AjaxScript = Utils.GetString(Utils.GetValueByProp(Attribute, "AjaxScript"));

            // 查询的参数, 默认为空
            String SearchParameter = Utils.GetString(Utils.GetValueByProp(Attribute, "SearchParameter"));

            // AjaxScript_type: 0: no ajax; 1: data-...; 2: onclick='@AjaxScript'
            // 默认为 2
            Int32 AjaxScript_type = Utils.GetInt32(Utils.GetValueByProp(Attribute, "AjaxScript_type"));

            if (AjaxScript_type == 1)
                ajaxupdate = Utils.GetString(Utils.GetValueByProp(Attribute, "ajaxupdate"),
                    "#fwin_dialog_content" + advt.Manager.XUtils.Inajax_key);

            // 视图类型， 0/3： 中文； 1：英文；
            // 默认为 0
            Int32 ViewType = Utils.GetInt32(Utils.GetValueByProp(Attribute, "ViewType"));

            // 默认为 {List}
            String Template = Utils.GetString(Utils.GetValueByProp(Attribute, "Template"), "{List}");

            // 默认为空
            String Postfix = Utils.GetString(Utils.GetValueByProp(Attribute, "Postfix"));

            // 默认为 根目录
            String VirtualPath = Utils.GetString(Utils.GetValueByProp(Attribute, "VirtualPath"), "/");

            // 默认为 page
            String Identifier = Utils.GetString(Utils.GetValueByProp(Attribute, "Identifier"), "page");

            // 默认为 false
            Boolean Encrypt = Utils.GetBoolean(Utils.GetValueByProp(Attribute, "Encrypt"));

            Template = !String.IsNullOrEmpty(Template) ? String.Format("{0}{1}", "\n\t", Utils.SetString(Template)) 
                : (ViewType == 0 || ViewType == 3) ? "\t<span>共：{RecordCount}条 {PageSize}条/页 {CurrentPage}页/{PageCount}页</span> {List}" 
                    : "\t<span>Page {CurrentPage} of {PageCount} ({RecordCount} items) PageSize：{PageSize}</span> {List}";

            if (AjaxScript != "")
            {
                if (SearchParameter.Equals(string.Empty))
                    SearchParameter = helper.PageParameterExceptScriptObj("");
                SearchParameter = SearchParameter.Equals(string.Empty) ? "" : ", " + SearchParameter;
            }

            Int32 pagecount = (Int32)Math.Ceiling((Double)RecordCount / (Double)PageSize);
            Int32 startPage = 0;
            Int32 endPage = 0;

            if (pagecount <= 10 || CurrentPage <= 3)
            {
                startPage = 1;
                endPage = 10 > pagecount ? pagecount : 10;
            }
            else
            {
                if (pagecount - CurrentPage <= 7)
                {
                    startPage = pagecount - 9;
                    endPage = pagecount;
                }
                else
                {
                    startPage = CurrentPage - 2;
                    endPage = CurrentPage + 7;
                }
            }

            Postfix = ViewType == 0 || ViewType == 1 ? "" : Postfix;

            StringBuilder html = new StringBuilder();
            html.AppendLine("<ul class=\"pagination\">");
            String CurrUrl = ""; // 当前的 URL

            if (ViewType == 0 || ViewType == 1)
            {
                CurrUrl = System.Web.HttpContext.Current.Request.RawUrl;
                CurrUrl = Utils.DeleteUrlParameter(Identifier);
                Identifier = Identifier + "=";
            }
            else
            {
                CurrUrl = VirtualPath;
                Identifier = "";
            }

            // 当前页数不为首页时添加
            if (CurrentPage > 1)
            {
                if (AjaxScript_type == 2)
                {
                    html.AppendFormat("\n\t<li><a onclick=\"{1}(1{4})\" title=\"{0}\"><<</a></li>\n\t<li><a onclick=\"{1}({2})\" title=\"{3}\"><</a></li>\n",
                        ViewType == 0 || ViewType == 3 ? "首页" : "First",
                        AjaxScript,
                        CurrentPage - 1,
                        ViewType == 0 || ViewType == 3 ? "上一页" : "Previous"
                        , SearchParameter
                        );
                }
                else if (AjaxScript_type == 1)
                {
                    html.AppendFormat("\n\t<li><a data-ajax=\"true\" data-ajax-update=\"{1}\" href=\"{0}{2}1\" title=\"{4}\"><<</a></li>\n\t<li><a data-ajax=\"true\" data-ajax-update=\"{1}\" href=\"{0}{2}{3}\" title=\"{5}\"><</a></li>\n",
                        CurrUrl,
                        ajaxupdate,
                        Identifier,
                        CurrentPage - 1,
                        ViewType == 0 || ViewType == 3 ? "首页" : "First",
                        ViewType == 0 || ViewType == 3 ? "上一页" : "Previous"
                        );
                }
                else if (AjaxScript_type == 0)
                {
                    html.AppendFormat("\n\t<li><a href=\"{0}{1}1\" title=\"{2}\"><<</a></li>\n\t<li><a href=\"{0}{1}{3}\" title=\"{4}\"><</a></li>\n",
                        CurrUrl,
                        Identifier,
                        ViewType == 0 || ViewType == 3 ? "首页" : "First",
                        CurrentPage - 1,
                        ViewType == 0 || ViewType == 3 ? "上一页" : "Previous"
                        );
                }
            }

            // 当前页数不为首页时添加
            if (CurrentPage > 10)
            {
                if (AjaxScript_type == 2)
                {
                    html.AppendFormat("\t<li><a onclick=\"{0}({1}{3})\" title=\"{2}\">....</a></li>\n",
                        AjaxScript,
                        CurrentPage - 10,
                        ViewType == 0 || ViewType == 3 ? "上10页" : "Previous Ten Pages"
                        , SearchParameter
                        );
                }
                else if (AjaxScript_type == 1)
                {
                    html.AppendFormat("\t<li><a data-ajax=\"true\" data-ajax-update=\"{1}\" href=\"{0}{2}{3}\" title=\"{1}\">....</a></li>\n",
                        CurrUrl,
                        ajaxupdate,
                        Identifier,
                        CurrentPage - 10,
                        ViewType == 0 || ViewType == 3 ? "上10页" : "Previous Ten Pages"
                        );
                }
                else if (AjaxScript_type == 0)
                {
                    html.AppendFormat("\t<li><a href=\"{0}{1}{2}\" title=\"{3}\">....</a></li>\n",
                        CurrUrl,
                        Identifier,
                        CurrentPage - 10,
                        ViewType == 0 || ViewType == 3 ? "上10页" : "Previous Ten Pages"
                        );
                }
            }

            for (Int32 j = startPage; j <= endPage; j++)
            {

                if (AjaxScript_type == 2)
                {
                    html.Append(CurrentPage == j ? String.Format("\t<li class=\"active\"><a href=\"javascript:void(0)\">{0}</a></li> \n", j)
                        : String.Format("\t<li><a onclick=\"{1}({2}{3})\" title=\"{2}\">{2}</a></li> \n", CurrUrl, AjaxScript, j, SearchParameter));
                }
                else if (AjaxScript_type == 1)
                {
                    html.Append(CurrentPage == j ? String.Format("\t<li class=\"active\"><a href=\"javascript:void(0)\">{0}</a></li> \n", j)
                        : String.Format("\t<li><a data-ajax=\"true\" data-ajax-update=\"{1}\" href=\"{0}{2}{3}\" title=\"{3}\">{3}</a></li> \n",
                            CurrUrl, ajaxupdate, Identifier, j, SearchParameter));
                }
                else if (AjaxScript_type == 0)
                {
                    html.Append(CurrentPage == j ? String.Format("\t<li class=\"active\"><a href=\"javascript:void(0)\">{0}</a></li> \n", j)
                        : String.Format("\t<li><a href=\"{0}{1}{2}\" title=\"{2}\">{2}</a></li> \n", CurrUrl, Identifier, j));
                }
            }

            // Inherit，显示 "下一页" 标签
            if (pagecount - CurrentPage > 10)
            {
                if (AjaxScript_type == 2)
                {
                    html.AppendFormat("\t<li><a onclick=\"{1}({2}{4})\" title=\"{3}\">....</a></li>\n",
                        CurrUrl,
                        AjaxScript,
                        (CurrentPage + 10),
                        ViewType == 0 || ViewType == 3 ? "下10页" : "Next Ten Pages",
                        SearchParameter
                        );
                }
                else if (AjaxScript_type == 1)
                {
                    html.AppendFormat("\t<li><a data-ajax=\"true\" data-ajax-update=\"{1}\" href=\"{0}{2}{3}\" title=\"{4}\">....</a></li>\n",
                        CurrUrl,
                        ajaxupdate,
                        Identifier,
                        (CurrentPage + 10),
                        ViewType == 0 || ViewType == 3 ? "下10页" : "Next Ten Pages"
                        );
                }
                else if (AjaxScript_type == 0)
                {
                    html.AppendFormat("\t<li><a href=\"{0}{1}{2}\" title=\"{3}\">....</a></li>\n",
                        CurrUrl,
                        Identifier,
                        (CurrentPage + 10),
                        ViewType == 0 || ViewType == 3 ? "下10页" : "Next Ten Pages"
                        );
                }
            }

            // Inherit，显示 "下一页" 和 "尾页" 标签
            if (pagecount > CurrentPage)
            {
                if (AjaxScript_type == 2)
                {
                    html.AppendFormat("\t<li><a onclick=\"{1}({2}{6})\" title=\"{3}\">></a></li> \n\t<li><a onclick=\"{1}({4})\" title=\"{5}\">>></a></li> \n",
                        CurrUrl,
                        AjaxScript,
                        (CurrentPage + 1),
                        ViewType == 0 || ViewType == 3 ? "下一页" : "Next",
                        pagecount,
                        ViewType == 0 || ViewType == 3 ? "末页" : "Last", 
                        SearchParameter
                        );
                }
                else if (AjaxScript_type == 1)
                {
                    html.AppendFormat("\t<li><a data-ajax=\"true\" data-ajax-update=\"{1}\" href=\"{0}{2}{3}\" title=\"{4}\">></a></li> \n\t<li><a data-ajax=\"true\" data-ajax-update=\"{1}\" href=\"{0}{2}{5}\" title=\"{6}\">>></a></li>  \n",
                        CurrUrl,
                        ajaxupdate,
                        Identifier,
                        (CurrentPage + 1),
                        ViewType == 0 || ViewType == 3 ? "下一页" : "Next",
                        pagecount,
                        ViewType == 0 || ViewType == 3 ? "末页" : "Last"
                        );
                }
                else if (AjaxScript_type == 0)
                {
                    html.AppendFormat("\t<li><a href=\"{0}{1}{2}\" title=\"{3}\">></a></li> \n\t<li><a href=\"{0}{1}{4}\" title=\"{5}\">>></a></li> \n",
                        CurrUrl,
                        Identifier,
                        (CurrentPage + 1),
                        ViewType == 0 || ViewType == 3 ? "下一页" : "Next",
                        pagecount,
                        ViewType == 0 || ViewType == 3 ? "末页" : "Last"
                        );
                }
            }
            html.AppendLine("</ul>");
            String tx = Template.Replace("{RecordCount}", RecordCount.ToString()).Replace("{PageSize}", PageSize.ToString()).Replace("{PageCount}", pagecount.ToString()).Replace("{CurrentPage}", CurrentPage.ToString()).Replace("{List}", html.ToString());

            return MvcHtmlString.Create(tx);
        }
        public static string PageParameterExceptScriptObj(this HtmlHelper helper, string key)
        {
            string[] allkeys = HttpContext.Current.Request.QueryString.AllKeys;
            if (allkeys.Length == 0) allkeys = HttpContext.Current.Request.Form.AllKeys;

            string getkey = string.Empty;
            if (getkey.Equals(string.Empty))
                return "{" + string.Empty + "}";
            else
                return "{" + getkey.Substring(1) + "}";
        }

        #endregion

    }
}