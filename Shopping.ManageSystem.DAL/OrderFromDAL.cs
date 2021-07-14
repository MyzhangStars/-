using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shopping.ManageSystem.Model;

namespace Shopping.ManageSystem.DAL
{
    public class OrderFromDAL
    {
        //定义一个私有字段
        private MyDbContext mc;

        //构造函数
        public OrderFromDAL()
        {
            mc = new MyDbContext();
        }

        //显示
        public List<OrderFrom> OrderFromShow()
        {
            var query = from a in mc.OrderFroms.Include("Users") select a;
            return query.ToList();
        }


    }
}
