namespace ShopManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeleteCartTable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Carts", "CompanyId", "dbo.Companies");
            DropForeignKey("dbo.Carts", "ItemId", "dbo.Items");
            DropIndex("dbo.Carts", new[] { "CompanyId" });
            DropIndex("dbo.Carts", new[] { "ItemId" });
            DropTable("dbo.Carts");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Carts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ItemId = c.Int(nullable: false),
                        CompanyId = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                        Discount = c.Int(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.Carts", "ItemId");
            CreateIndex("dbo.Carts", "CompanyId");
            AddForeignKey("dbo.Carts", "ItemId", "dbo.Items", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Carts", "CompanyId", "dbo.Companies", "Id", cascadeDelete: true);
        }
    }
}
