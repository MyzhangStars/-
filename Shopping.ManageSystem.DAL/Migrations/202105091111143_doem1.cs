namespace Shopping.ManageSystem.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class doem1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.OrderForm_Product",
                c => new
                    {
                        OrderForm_ProductID = c.Int(nullable: false, identity: true),
                        OrderFormID = c.Int(nullable: false),
                        ProductID = c.Int(nullable: false),
                        ProductNum = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.OrderForm_ProductID)
                .ForeignKey("dbo.Order", t => t.OrderFormID, cascadeDelete: true)
                .ForeignKey("dbo.ProductInfo", t => t.ProductID, cascadeDelete: true)
                .Index(t => t.OrderFormID)
                .Index(t => t.ProductID);
            
            CreateTable(
                "dbo.Order",
                c => new
                    {
                        OrderFromID = c.Int(nullable: false, identity: true),
                        OrderFromNum = c.String(),
                        OrderFromTime = c.DateTime(nullable: false),
                        UserID = c.Int(nullable: false),
                        OrderFromState = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.OrderFromID)
                .ForeignKey("dbo.UserInfo", t => t.UserID, cascadeDelete: true)
                .Index(t => t.UserID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrderForm_Product", "ProductID", "dbo.ProductInfo");
            DropForeignKey("dbo.OrderForm_Product", "OrderFormID", "dbo.Order");
            DropForeignKey("dbo.Order", "UserID", "dbo.UserInfo");
            DropIndex("dbo.Order", new[] { "UserID" });
            DropIndex("dbo.OrderForm_Product", new[] { "ProductID" });
            DropIndex("dbo.OrderForm_Product", new[] { "OrderFormID" });
            DropTable("dbo.Order");
            DropTable("dbo.OrderForm_Product");
        }
    }
}
