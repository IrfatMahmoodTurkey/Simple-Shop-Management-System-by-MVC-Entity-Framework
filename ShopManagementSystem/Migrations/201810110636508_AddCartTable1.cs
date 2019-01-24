namespace ShopManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCartTable1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Carts", "CompanyId", c => c.Int(nullable: false));
            CreateIndex("dbo.Carts", "CompanyId");
            AddForeignKey("dbo.Carts", "CompanyId", "dbo.Companies", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Carts", "CompanyId", "dbo.Companies");
            DropIndex("dbo.Carts", new[] { "CompanyId" });
            DropColumn("dbo.Carts", "CompanyId");
        }
    }
}
