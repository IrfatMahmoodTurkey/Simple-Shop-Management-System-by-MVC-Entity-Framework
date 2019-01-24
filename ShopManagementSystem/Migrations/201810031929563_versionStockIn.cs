namespace ShopManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class versionStockIn : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.StockIns",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CompanyId = c.Int(nullable: false),
                        ItemId = c.Int(nullable: false),
                        Date = c.String(nullable: false),
                        StockInQuantity = c.Int(nullable: false),
                        Month = c.String(),
                        Year = c.String(),
                        Total = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ActionType = c.String(),
                        ActionDate = c.String(),
                        ActionBy = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Companies", t => t.CompanyId, cascadeDelete: false)
                .ForeignKey("dbo.Items", t => t.ItemId, cascadeDelete: false)
                .Index(t => t.CompanyId)
                .Index(t => t.ItemId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.StockIns", "ItemId", "dbo.Items");
            DropForeignKey("dbo.StockIns", "CompanyId", "dbo.Companies");
            DropIndex("dbo.StockIns", new[] { "ItemId" });
            DropIndex("dbo.StockIns", new[] { "CompanyId" });
            DropTable("dbo.StockIns");
        }
    }
}
