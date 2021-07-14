using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using Shopping.ManageSystem.BLL;
using Shopping.ManageSystem.Model;
using Shopping.ManageSystem.Common;

namespace Shopping.ManageSystem.UI.Controllers
{
    public class LoginController : Controller
    {
        //实例化bll
        UserBLL userBLL = new UserBLL();

        //用户登录页面
        public ActionResult LoginIndex()
        {
            return View();
        }

        public ActionResult UserLogin(UserViewModel user)
        {
            if ((Session["CheckCode"] + "").ToLower() == user.ValidateCode.ToLower())
            {
                //MD5加密
                user.UserPass = SecurityHelper.Md5Security(user.UserPass);
                //获取查询数据
                User userModel = userBLL.UserLogin(user.UserName, user.UserPass);

                //判断账号密码是否正确
                if (userModel != null)
                {
                    //session传值
                    Session["UserName"] = userModel.UserName;
                    //登录成功传值
                    return Json(new { Code = 1, Message = "登录成功" });
                }
                else
                {
                    //登录失败传值
                    return Json(new { Code = 2, Message = "登录失败" });
                }
            }
            else
            {
                //验证码错误传值
                return Json(new { Code = 3, Message = "验证码不正确" });
            }
        }
    }
}