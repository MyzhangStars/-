using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web;


namespace Shopping.ManageSystem.Model
{
    [Table("ProductInfo")]
    /// <summary>
    /// 商品信息表
    /// </summary>
    public class Product
    {
        [Key]
        public int ProductID { get; set; }//产品编号

        [StringLength(20)]
        public string ProductName { get; set; }//产品名称

        public decimal ProductPrice { get; set; }//产品价格

        public bool Is_Delete { get; set; }//是否逻辑删除

        public string ProductImg { get; set; }//产品图片

        [ForeignKey("CategoryModels")]
        public int CategoryID { get; set; }//产品分类

        public DateTime ProductTime { get; set; }//编辑时间

        public string ProductDesc { get; set; }//产品介绍

        //导航属性
        public virtual ProductCategory CategoryModels { get; set; }
    }
}
