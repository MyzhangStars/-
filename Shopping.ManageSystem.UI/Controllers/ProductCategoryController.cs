using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Shopping.ManageSystem.BLL;
using Shopping.ManageSystem.Model;
using Webdiyer.WebControls.Mvc;

namespace Shopping.ManageSystem.UI.Controllers
{
    public class ProductCategoryController : ControllerBase
    {
        //实例化CategoryBLL
        ProductCategoryBLL categoryBLL = new ProductCategoryBLL();

        //显示+分页
        public ActionResult CategoryIndex(int pageIndex=1,int pageSize=2)
        {
            //获取数据
            List<ProductCategory> categoryModels = categoryBLL.CategoryShow();
            //获取总条数
            int rCount = categoryModels.Count();
            //分页数据
            List<ProductCategory> data = categoryModels.OrderBy(m=>m.CategoryID).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();

            PagedList<ProductCategory> PageData = new PagedList<ProductCategory>(data, pageIndex, pageSize, rCount);

            //判断是否为ajax无刷新
            if (Request.IsAjaxRequest())
            {
                return PartialView("_PartialCategory", PageData);
            }

            return View(PageData);
        }

        [HttpPost]
        //添加分类
        public ActionResult CategoryCreate(ProductCategory obj)
        {
            //调用添加方法
            int count = categoryBLL.CategoryCreate(obj);
            //判断是否添加成功
            if (count>0)
            {
                //JSON返回
                return Json(new { Code = 1, Message = "添加成功" });
            }
            else
            {
                return Json(new { Code = 2, Message = "添加失败" });
            }
        }

        public ActionResult UniqueCategory(string CategoryCode)
        {
            ProductCategory model = categoryBLL.UniqueCategory(CategoryCode);
            if (model!=null)
            {
                return Json(new { valid = false, Message = "the message" });
            }
            else
            {
                return Json(new { valid = true, Message = "the message" });
            }
        }

        public ActionResult CategoryDelete(int id)
        {
            int h = categoryBLL.CategroyDetele(id);
            if (h>0)
            {
                return Json(new { Code = 1, Message = "删除成功" });
            }
            else
            {
                return Json(new { Code = 2, Message = "删除失败" });
            }
        }
    }
}