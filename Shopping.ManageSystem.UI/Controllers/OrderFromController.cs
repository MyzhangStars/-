using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Shopping.ManageSystem.Model;
using Shopping.ManageSystem.BLL;
using Webdiyer.WebControls.Mvc;

namespace Shopping.ManageSystem.UI.Controllers
{
    public class OrderFromController : Controller
    {
        //实例化bll
        OrderFromBLL OrderBLL = new OrderFromBLL();

        //订单显示+分页
        public ActionResult OrderIndex(int pageIndex=1,int pageSize=2)
        {
            //获取数据
            List<OrderFrom> orders = OrderBLL.OrderFromShow();

            //获取数据条数
            int rCount = orders.Count();

            List<OrderFrom> data =(orders.OrderBy(m => m.OrderFromID).Skip((pageIndex - 1) * pageSize).Take(pageSize)).ToList();
            //分页数据
            PagedList<OrderFrom> PageData = new PagedList<OrderFrom>(data, pageIndex, pageSize, rCount);



            //判断是否为Ajax请求
            if (Request.IsAjaxRequest())
            {
                return PartialView("_PartialOrder", PageData);
            }
            return View(PageData);
        }

    }
}