using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shopping.ManageSystem.DAL;
using Shopping.ManageSystem.Model;

namespace Shopping.ManageSystem.BLL
{
    public class OrderFromBLL
    {
        //实例化dal
        OrderFromDAL OrderDAL = new OrderFromDAL();

        //显示
        public List<OrderFrom> OrderFromShow()
        {
            return OrderDAL.OrderFromShow();
        }
    }
}
