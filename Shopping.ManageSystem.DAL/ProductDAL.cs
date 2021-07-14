using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shopping.ManageSystem.Model;

namespace Shopping.ManageSystem.DAL
{
    /// <summary>
    /// 商品信息DAL层
    /// </summary>
    public class ProductDAL
    {
        //定义一个私有字段--上下文对象
        private MyDbContext mc;
        //构造函数
        public ProductDAL()
        {
            //实例化上下文对象
            mc = new MyDbContext();
        }

        //绑定下拉
        public List<ProductCategory> Binding()
        {
            return mc.ProductCategorys.ToList();
        }

        //产品名称唯一判断
        public Product UniqueProductName(string ProductName)
        {
            return mc.Products.Where(m => m.ProductName.Equals(ProductName)).FirstOrDefault();
        }

        //产品添加
        public int ProductCreate(Product obj)
        {
            //添加数据
            mc.Products.Add(obj);
            //返回受影响行数
            return mc.SaveChanges();
        }

        //产品显示
        public List<Product> ProductShow()
        {
            var query = from a in mc.Products.Include("CategoryModels")
                        select a;
            return query.ToList();
        }

        //产品逻辑删除
        public int ProductDelete(string id)
        {
            var sql = $"update ProductInfo set Is_Delete= 1 where ProductID in ({id})";
            return mc.Database.ExecuteSqlCommand(sql);
        }

        //产品反填
        public Product ProductEdit(int id)
        {
            return mc.Products.Find(id);
        }

        //产品修改
        public int ProductUpdate(Product obj)
        {
            mc.Entry<Product>(obj).State = System.Data.Entity.EntityState.Modified;
            return mc.SaveChanges();
        }

        //导入
        public int ProductVastCreate(List<Product> obj)
        {
            foreach (var item in obj)
            {
                mc.Entry(item).State = System.Data.Entity.EntityState.Added;
            }
            return mc.SaveChanges();
        }


        //导出


    }
}
