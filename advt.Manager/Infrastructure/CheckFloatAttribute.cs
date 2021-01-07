using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using advt.Common;

namespace System.Web.Mvc
{
    public class CheckFloatAttribute : FilterAttribute, IActionFilter
    {
        public string LayOut { get; set; }
        public string LayOut_Empty { get; set; }

        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
            var result = filterContext.Result as ViewResult;
            if (result != null)
            {
                if (wbRequest.GetInt("inajax", 0) == 1)
                {
                    //判斷為彈出對話框，選擇Empty模板
                    if (LayOut_Empty != null)
                        result.MasterName = LayOut_Empty;
                    else
                        result.MasterName = "~/Views/Shared/_Layout_Empty.cshtml";
                }
                else
                {
                    if (LayOut == null)
                        result.MasterName = "~/Views/Shared/_Layout.cshtml";
                    else
                        result.MasterName = LayOut;
                }
            }
        }

        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
        }
    }
}