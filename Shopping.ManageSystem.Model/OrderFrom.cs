using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Shopping.ManageSystem.Model
{
    [Table("Order")]
    /// <summary>
    /// 订单表
    /// </summary>
    public class OrderFrom
    {
        [Key]
        public int OrderFromID { get; set; }//订单ID
        public string OrderFromNum { get; set; }//订单号
        public DateTime OrderFromTime { get; set; }//修改时间
        [ForeignKey("Users")]
        public int UserID { get; set; }//用户ID

        public int OrderFromState { get; set; }//订单状态

        //导航属性
        public virtual User Users { get; set; }
    }
}
