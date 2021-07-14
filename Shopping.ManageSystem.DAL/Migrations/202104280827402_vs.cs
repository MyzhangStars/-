namespace Shopping.ManageSystem.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class vs : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ProductInfo",
                c => new
                    {
                        ProductID = c.Int(nullable: false, identity: true),
                        ProductName = c.String(maxLength: 20),
                        ProductPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Is_Delete = c.Boolean(nullable: false),
                        ProductImg = c.String(),
                        CategoryID = c.Int(nullable: false),
                        ProductTime = c.DateTime(nullable: false),
                        ProductDesc = c.String(),
                    })
                .PrimaryKey(t => t.ProductID)
                .ForeignKey("dbo.Category", t => t.CategoryID, cascadeDelete: true)
                .Index(t => t.CategoryID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProductInfo", "CategoryID", "dbo.Category");
            DropIndex("dbo.ProductInfo", new[] { "CategoryID" });
            DropTable("dbo.ProductInfo");
        }
    }
}
