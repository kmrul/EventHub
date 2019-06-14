namespace EventHub.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCanceledToEvent : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Events", "IsCanceled", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Events", "IsCanceled");
        }
    }
}
