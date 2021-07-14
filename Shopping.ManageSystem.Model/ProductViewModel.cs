using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Web;


namespace Shopping.ManageSystem.Model
{
    /// <summary>
    /// 商品信息表
    /// </summary>
    public class ProductViewModel
    {
        [Key]
        public int ProductID { get; set; }//产品编号

        public string ProductName { get; set; }//产品名称

        public decimal ProductPrice { get; set; }//产品价格

        public bool Is_Delete { get; set; }//是否逻辑删除

        public string ProductImg { get; set; }//产品图片

        public int CategoryID { get; set; }//产品分类

        public string CategoryName { get; set; }//产品分类

        public DateTime ProductTime { get; set; }//编辑时间

        public string ProductDesc { get; set; }//产品介绍
    }
}
