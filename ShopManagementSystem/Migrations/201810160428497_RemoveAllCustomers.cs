namespace ShopManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveAllCustomers : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Carts", "Customer_Id", "dbo.Customers");
            DropForeignKey("dbo.Sells", "CustomerId", "dbo.Customers");
            DropIndex("dbo.Carts", new[] { "Customer_Id" });
            DropIndex("dbo.Sells", new[] { "CustomerId" });
            DropColumn("dbo.Carts", "Customer_Id");
            DropColumn("dbo.Sells", "CustomerId");
            DropTable("dbo.Customers");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RegNo = c.String(maxLength: 100),
                        Name = c.String(nullable: false, maxLength: 100),
                        Email = c.String(maxLength: 100),
                        Address = c.String(maxLength: 500),
                        Phone = c.String(nullable: false, maxLength: 100),
                        EntryDate = c.String(nullable: false, maxLength: 100),
                        EntryMonth = c.String(),
                        EntryYear = c.String(),
                        ActionType = c.String(),
                        ActionDate = c.String(),
                        ActionBy = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Sells", "CustomerId", c => c.Int(nullable: false));
            AddColumn("dbo.Carts", "Customer_Id", c => c.Int());
            CreateIndex("dbo.Sells", "CustomerId");
            CreateIndex("dbo.Carts", "Customer_Id");
            AddForeignKey("dbo.Sells", "CustomerId", "dbo.Customers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Carts", "Customer_Id", "dbo.Customers", "Id");
        }
    }
}
