namespace ShopManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class versionItemSetupUpdate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Items", "SerialNo", c => c.String(maxLength: 50));
            AddColumn("dbo.Items", "Quantity", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Items", "Quantity");
            DropColumn("dbo.Items", "SerialNo");
        }
    }
}
