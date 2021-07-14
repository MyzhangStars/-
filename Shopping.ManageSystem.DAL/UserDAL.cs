using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shopping.ManageSystem.Model;

namespace Shopping.ManageSystem.DAL
{
    public class UserDAL
    {
        //定义一个私有字段--上下文对象
        public MyDbContext mc;
        //构造函数
        public UserDAL()
        {
            //实例化上下文对象
            mc = new MyDbContext();
        }

        //用户登录
        public User UserLogin(string UserName, string UserPass)
        {
            return mc.Users.Where(m => m.UserName.Equals(UserName) && m.UserPass.Equals(UserPass)).FirstOrDefault();
        }

        //用户注册功能
        public int UserCreate(User m)
        {
            //添加数据
            mc.Users.Add(m);
            //返回受影响行数
            return mc.SaveChanges();
        }
        
        //用户唯一性
        public int UniqueUserName(string userName)
        {
            return mc.Users.Where(m => m.UserName.Equals(userName)).Count();
        }

        //用户管理功能
        public List<User> UserShow()
        {
            return mc.Users.ToList();
        }

        //用户逻辑删除(支持批量)
        public int UserDelete(string id)
        {
            //准备SQL语句
            var sql = $"update UserInfo set Is_Delete=1 where UserID in ({id})";
            //执行SQL语句
            return mc.Database.ExecuteSqlCommand(sql);
        }

        //反填数据
        public User UserEdit(int id)
        {
            return mc.Users.Find(id);
        }

        //修改数据
        public int UserUpdate(User m)
        {
            mc.Entry<User>(m).State = System.Data.Entity.EntityState.Modified;
            return mc.SaveChanges();
        }
    }
}
