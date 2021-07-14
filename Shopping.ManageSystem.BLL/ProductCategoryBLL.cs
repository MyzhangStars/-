using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shopping.ManageSystem.DAL;
using Shopping.ManageSystem.Model;

namespace Shopping.ManageSystem.BLL
{
    /// <summary>
    /// 产品分类（CategoryBLL）层
    /// </summary>
    public class ProductCategoryBLL
    {
        //实例化CategoryDAL
        ProductCategoryDAL categoryDAL = new ProductCategoryDAL();

        //分类码唯一约束
        public ProductCategory UniqueCategory(string CategoryCode)
        {
            return categoryDAL.UniqueCategory(CategoryCode);
        }


        //添加分类
        public int CategoryCreate(ProductCategory obj)
        {
            return categoryDAL.CategoryCreate(obj);
        }

        //显示分类
        public List<ProductCategory> CategoryShow()
        {
            //返回数据
            return categoryDAL.CategoryShow();
        }

        //反填
        public ProductCategory CategoryEdit(int id)
        {
            //返回数据
            return categoryDAL.CategoryEdit(id);
        }

        //修改
        public int CategoryUpdate(ProductCategory obj)
        {
            return categoryDAL.CategoryUpdate(obj);
        }

        //删除
        public int CategroyDetele(int id)
        {
            return categoryDAL.CategroyDetele(id);
        }
    }
}
