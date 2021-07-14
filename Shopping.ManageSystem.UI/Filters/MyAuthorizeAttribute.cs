using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Shopping.ManageSystem.UI.Filters
{
    public class MyAuthorizeAttribute : AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            //判断是否已登录
            if (filterContext.HttpContext.Session["UserName"]==null)
            {
                //未登录进行登录
                filterContext.Result = new RedirectResult("/Login/LoginIndex");
            }

            return;
        }
    }
}