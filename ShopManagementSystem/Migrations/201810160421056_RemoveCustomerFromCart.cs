namespace ShopManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveCustomerFromCart : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Carts", "CustomerId", "dbo.Customers");
            DropIndex("dbo.Carts", new[] { "CustomerId" });
            AddColumn("dbo.Carts", "Customer_Id", c => c.Int());
            CreateIndex("dbo.Carts", "Customer_Id");
            AddForeignKey("dbo.Carts", "Customer_Id", "dbo.Customers", "Id");
            DropColumn("dbo.Carts", "CustomerId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Carts", "CustomerId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Carts", "Customer_Id", "dbo.Customers");
            DropIndex("dbo.Carts", new[] { "Customer_Id" });
            DropColumn("dbo.Carts", "Customer_Id");
            CreateIndex("dbo.Carts", "CustomerId");
            AddForeignKey("dbo.Carts", "CustomerId", "dbo.Customers", "Id", cascadeDelete: true);
        }
    }
}
