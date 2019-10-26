namespace EventHub.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitAgainMigrations : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Events", "Price", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Events", "Description", c => c.String());
            AddColumn("dbo.Events", "ShortDescription", c => c.String());
            AddColumn("dbo.Events", "Image", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Events", "Image");
            DropColumn("dbo.Events", "ShortDescription");
            DropColumn("dbo.Events", "Description");
            DropColumn("dbo.Events", "Price");
        }
    }
}
