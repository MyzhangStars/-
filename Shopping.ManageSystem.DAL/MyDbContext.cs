namespace Shopping.ManageSystem.DAL
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using Shopping.ManageSystem.Model;

    public class MyDbContext : DbContext
    {
        //您的上下文已配置为从您的应用程序的配置文件(App.config 或 Web.config)
        //使用“MyDbContext”连接字符串。默认情况下，此连接字符串针对您的 LocalDb 实例上的
        //“Shopping.ManageSystem.DAL.MyDbContext”数据库。
        // 
        //如果您想要针对其他数据库和/或数据库提供程序，请在应用程序配置文件中修改“MyDbContext”
        //连接字符串。
        public MyDbContext()
            : base("name=MyDbContext")
        {
        }

        //为您要在模型中包含的每种实体类型都添加 DbSet。有关配置和使用 Code First  模型
        //的详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=390109。

        //用户管理表
        public virtual DbSet<User> Users { get; set; }

        //产品分类表
        public virtual DbSet<ProductCategory> ProductCategorys { get; set; }

        //商品信息表
        public virtual DbSet<Product> Products { get; set; }

        //订单表
        public virtual DbSet<OrderFrom> OrderFroms { get; set; }

        //订单商品表
        public virtual DbSet<OrderForm_Product> OrderForm_Products { get; set; }
    }
}