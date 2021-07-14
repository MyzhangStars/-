using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Shopping.ManageSystem.UI.Controllers
{
    public class IndexController : ControllerBase
    {
        // GET: Index
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Secede()
        {
            Session["UserName"] = null;
            return Content("<script>alert('成功退出');window.location.href='/Login/LoginIndex'</script>");
        }
    }
}