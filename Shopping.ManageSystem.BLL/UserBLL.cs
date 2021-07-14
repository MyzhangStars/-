using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shopping.ManageSystem.Model;
using Shopping.ManageSystem.DAL;

namespace Shopping.ManageSystem.BLL
{
    public class UserBLL
    {
        //实例化UserDAL层
        UserDAL userDAL = new UserDAL();
        //用户登录
        public User UserLogin(string UserName, string UserPass)
        {
            return userDAL.UserLogin(UserName, UserPass);
        }
        //用户注册功能
        public int UserCreate(User m)
        {
            //返回数据到UserDAL层
            return userDAL.UserCreate(m);
        }
        //用户唯一性
        public int UniqueUserName(string userName)
        {
            //返回数据到UserDAL层
            return userDAL.UniqueUserName(userName);
        }
        //用户管理功能
        public List<User> UserShow()
        {
            //返回数据到UserDAL层
            return userDAL.UserShow();
        }

        //用户逻辑删除(支持批量)
        public int UserDelete(string id)
        {
            //返回数据到UserDAL层
            return userDAL.UserDelete(id);
        }

        //反填数据
        public User UserEdit(int id)
        {
            return userDAL.UserEdit(id);
        }

        //修改数据
        public int UserUpdate(User m)
        {
            return userDAL.UserUpdate(m);
        }
    }
}
