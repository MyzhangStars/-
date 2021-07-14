namespace Shopping.ManageSystem.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class doem : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Category",
                c => new
                    {
                        CategoryID = c.Int(nullable: false, identity: true),
                        CategoryName = c.String(maxLength: 20),
                        CategoryCode = c.String(maxLength: 20),
                    })
                .PrimaryKey(t => t.CategoryID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Category");
        }
    }
}
