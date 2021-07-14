using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Shopping.ManageSystem.Model;
using Shopping.ManageSystem.BLL;
using Webdiyer.WebControls.Mvc;
using Shopping.ManageSystem.Common;

namespace Shopping.ManageSystem.UI.Controllers
{
    public class UserController : ControllerBase
    {
        //实例化UserBLL
        UserBLL userBLL = new UserBLL();

        //页面显示
        public ActionResult UserIndex(int pageIndex=1,int pageSize=2,string Is_Delete="",string userName="")
        {
            //获取数据
            List<User> userModels = userBLL.UserShow();

            //根据删除状态精确查询
            if (!string.IsNullOrEmpty(Is_Delete))
            {
                userModels = (from u in userModels where u.Is_Delete.Equals(Convert.ToBoolean(Is_Delete)) select u).ToList();
            }

            //根据用户名模糊查询
            if (!string.IsNullOrEmpty(userName))
            {
                userModels = (from u in userModels where u.UserName.Contains(userName) select u).ToList();
            }

            //获取数据条数
            int rCount = userModels.Count();
            //分页
            List<User> data = userModels.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();

            PagedList<User> PageData = new PagedList<User>(data, pageIndex, pageSize, rCount);

            if (Request.IsAjaxRequest())
            {
                return PartialView("_PartialUser", PageData);
            }

            return View(PageData);
        }
        //用户注册
        public JsonResult UserCreate(User m)
        {
            //MD5加密
            m.UserPass = SecurityHelper.Md5Security(m.UserPass);

            int h = userBLL.UserCreate(m);
            if (h > 0)
            {
                return Json(new { Code = 1, Message = "添加成功" });
            }
            else
            {
                return Json(new { Code = 2, Message = "添加失败" });
            }
        }

        //用户唯一性判断
        public JsonResult UniqueUserName(string userName)
        {
            int h = userBLL.UniqueUserName(userName);
            if (h>0)
            {
                return Json(new { valid= false, Message = "the message" });
            }
            else
            {
                return Json(new { valid = true, Message = "the message" });
            }
        }

        //用户逻辑删除（支持批删）
        public ActionResult UserDelete(string id)
        {
            int h = userBLL.UserDelete(id);
            if (h > 0)
            {
                return Json(new { Code = 1, Message = "删除成功" });
            }
            else
            {
                return Json(new { Code = 2, Message = "删除失败" });
            }
        }

        //反填修改数据
        public ActionResult UserEdit(int uid)
        {
            User userModel = userBLL.UserEdit(uid);
            if (userModel!=null)
            {
                return Json(new {Code = 1,Data=userModel});
            }
            else
            {
                return Json(new {Code = 2, Data = userModel});
            }
        }

        //修改
        public ActionResult UserUpdate(User m)
        {
            m.UserTime = DateTime.Now;
            int h = userBLL.UserUpdate(m);
            if (h > 0)
            {
                return Json(new { Code = 1, Message = "编辑成功" });
            }
            else
            {
                return Json(new { Code = 2, Message = "编辑失败" });
            }
        }
    }
}