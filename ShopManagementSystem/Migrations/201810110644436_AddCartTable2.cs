namespace ShopManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCartTable2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Carts", "CustomerId", c => c.Int(nullable: false));
            CreateIndex("dbo.Carts", "CustomerId");
            AddForeignKey("dbo.Carts", "CustomerId", "dbo.Customers", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Carts", "CustomerId", "dbo.Customers");
            DropIndex("dbo.Carts", new[] { "CustomerId" });
            DropColumn("dbo.Carts", "CustomerId");
        }
    }
}
