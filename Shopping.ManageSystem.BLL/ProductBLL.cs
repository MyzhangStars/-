using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shopping.ManageSystem.DAL;
using Shopping.ManageSystem.Model;

namespace Shopping.ManageSystem.BLL
{
    public class ProductBLL
    {
        //实例化ProductDAL
        ProductDAL productDAL = new ProductDAL();

        //绑定下拉
        public List<ProductCategory> Binding()
        {
            return productDAL.Binding();
        }

        //产品名称唯一判断
        public Product UniqueProductName(string ProductName)
        {
            return productDAL.UniqueProductName(ProductName);
        }

        //产品添加
        public int ProductCreate(Product obj)
        {
            return productDAL.ProductCreate(obj);
        }

        //产品显示
        public List<Product> ProductShow()
        {
            return productDAL.ProductShow();
        }

        //产品逻辑删除
        public int ProductDelete(string id)
        {
            return productDAL.ProductDelete(id);
        }

        //产品反填
        public Product ProductEdit(int id)
        {
            return productDAL.ProductEdit(id);
        }

        //产品修改
        public int ProductUpdate(Product obj)
        {
            return productDAL.ProductUpdate(obj);
        }

        //导入
        public int ProductVastCreate(List<Product> obj)
        {
            return productDAL.ProductVastCreate(obj);
        }
    }
}
