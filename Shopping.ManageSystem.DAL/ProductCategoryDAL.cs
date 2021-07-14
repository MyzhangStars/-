using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shopping.ManageSystem.Model;

namespace Shopping.ManageSystem.DAL
{
    /// <summary>
    /// 产品分类（CategoryDAL）层
    /// </summary>
    public class ProductCategoryDAL
    {
        //定义一个私有字段-上下文对象
        private MyDbContext mc;

        //构造函数
        public ProductCategoryDAL()
        {
            //实例化上下文对象
            mc = new MyDbContext();
        }

        //分类码唯一约束
        public ProductCategory UniqueCategory(string CategoryCode)
        {
            //根据分类码进行查询 
            return mc.ProductCategorys.Where(m => m.CategoryCode.Equals(CategoryCode)).FirstOrDefault();
        }

        //添加分类
        public int CategoryCreate(ProductCategory obj)
        {
            //添加
            mc.ProductCategorys.Add(obj);
            //返回受影响行数
            return mc.SaveChanges();
        }

        //显示分类
        public List<ProductCategory> CategoryShow()
        {
            //返回数据
            return mc.ProductCategorys.ToList();
        }

        //反填
        public ProductCategory CategoryEdit(int id)
        {
            //返回数据
            return mc.ProductCategorys.Find(id);
        }

        //修改
        public int CategoryUpdate(ProductCategory obj)
        {
            //修改数据
            mc.Entry<ProductCategory>(obj).State = System.Data.Entity.EntityState.Modified;
            return mc.SaveChanges();
        }

        //删除
        public int CategroyDetele(int id)
        {
            //删除查询到的数据
            mc.ProductCategorys.Remove(mc.ProductCategorys.Find(id));
            //返回受影响行数
            return mc.SaveChanges();
        }
    }
}
