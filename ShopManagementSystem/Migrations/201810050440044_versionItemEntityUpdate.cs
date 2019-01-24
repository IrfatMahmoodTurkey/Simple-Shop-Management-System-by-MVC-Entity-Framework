namespace ShopManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class versionItemEntityUpdate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Items", "SellPrice", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Items", "SellPrice");
        }
    }
}
