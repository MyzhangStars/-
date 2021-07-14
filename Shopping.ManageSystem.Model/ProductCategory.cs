using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Shopping.ManageSystem.Model
{
    [Table("Category")]
    /// <summary>
    /// 产品分类表
    /// </summary>
    public class ProductCategory
    {
        [Key]
        public int CategoryID { get; set; }//主键

        [StringLength(20)]
        public string CategoryName { get; set; }//分类名称

        [StringLength(20)]
        public string CategoryCode { get; set; }//分类码
    }
}
