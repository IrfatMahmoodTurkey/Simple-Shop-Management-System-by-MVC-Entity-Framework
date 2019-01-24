namespace ShopManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateSellsDate : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Sells", "Date", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Sells", "Date", c => c.String(nullable: false));
        }
    }
}
