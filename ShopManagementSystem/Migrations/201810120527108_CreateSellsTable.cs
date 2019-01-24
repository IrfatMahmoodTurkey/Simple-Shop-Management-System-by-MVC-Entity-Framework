namespace ShopManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateSellsTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Sells",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ItemId = c.Int(nullable: false),
                        CompanyId = c.Int(nullable: false),
                        CustomerId = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                        Discount = c.Int(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Date = c.String(nullable: false),
                        ActionType = c.String(),
                        ActionDate = c.String(),
                        ActionBy = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Companies", t => t.CompanyId)
                .ForeignKey("dbo.Customers", t => t.CustomerId)
                .ForeignKey("dbo.Items", t => t.ItemId)
                .Index(t => t.CompanyId)
                .Index(t => t.CustomerId)
                .Index(t => t.ItemId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Sells", "ItemId", "dbo.Items");
            DropForeignKey("dbo.Sells", "CustomerId", "dbo.Customers");
            DropForeignKey("dbo.Sells", "CompanyId", "dbo.Companies");
            DropIndex("dbo.Sells", new[] { "ItemId" });
            DropIndex("dbo.Sells", new[] { "CustomerId" });
            DropIndex("dbo.Sells", new[] { "CompanyId" });
            DropTable("dbo.Sells");
        }
    }
}
