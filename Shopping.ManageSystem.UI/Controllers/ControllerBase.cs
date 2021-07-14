using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Shopping.ManageSystem.UI.Filters;

namespace Shopping.ManageSystem.UI.Controllers
{
    [MyAuthorize]
    public class ControllerBase : Controller
    {
    }
}