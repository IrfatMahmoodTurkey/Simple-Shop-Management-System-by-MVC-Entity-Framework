namespace ShopManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateDamageAndLossTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Damageds",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ItemId = c.Int(nullable: false),
                        CompanyId = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                        Discount = c.Int(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Date = c.DateTime(nullable: false),
                        ActionType = c.String(),
                        ActionDate = c.String(),
                        ActionBy = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Companies", t => t.CompanyId)
                .ForeignKey("dbo.Items", t => t.ItemId)
                .Index(t => t.CompanyId)
                .Index(t => t.ItemId);
            
            CreateTable(
                "dbo.Losses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ItemId = c.Int(nullable: false),
                        CompanyId = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                        Discount = c.Int(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Date = c.DateTime(nullable: false),
                        ActionType = c.String(),
                        ActionDate = c.String(),
                        ActionBy = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Companies", t => t.CompanyId)
                .ForeignKey("dbo.Items", t => t.ItemId)
                .Index(t => t.CompanyId)
                .Index(t => t.ItemId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Losses", "ItemId", "dbo.Items");
            DropForeignKey("dbo.Losses", "CompanyId", "dbo.Companies");
            DropForeignKey("dbo.Damageds", "ItemId", "dbo.Items");
            DropForeignKey("dbo.Damageds", "CompanyId", "dbo.Companies");
            DropIndex("dbo.Losses", new[] { "ItemId" });
            DropIndex("dbo.Losses", new[] { "CompanyId" });
            DropIndex("dbo.Damageds", new[] { "ItemId" });
            DropIndex("dbo.Damageds", new[] { "CompanyId" });
            DropTable("dbo.Losses");
            DropTable("dbo.Damageds");
        }
    }
}
