using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shopping.ManageSystem.Model
{
    [Table("OrderForm_Product")]
    /// <summary>
    /// 商品订单表
    /// </summary>
    public class OrderForm_Product
    {

        public int OrderForm_ProductID { get; set; }//订单商品ID

        [ForeignKey("OrderFroms")]
        public int OrderFormID { get; set; }//订单ID

        [ForeignKey("Products")]
        public int ProductID { get; set; }//商品ID

        public int ProductNum { get; set; }//商品购买数量

        public virtual OrderFrom OrderFroms { get; set; }//订单表

        public virtual Product Products { get; set; }//商品表
    }
}
