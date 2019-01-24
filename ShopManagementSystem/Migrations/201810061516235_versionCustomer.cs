namespace ShopManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class versionCustomer : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
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
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Customers");
        }
    }
}
