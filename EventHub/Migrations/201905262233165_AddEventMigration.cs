namespace EventHub.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddEventMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Events",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OrganizerId = c.String(nullable: false, maxLength: 128),
                        DateTime = c.DateTime(nullable: false),
                        Name = c.String(nullable: false, maxLength: 255),
                        Vanue = c.String(nullable: false, maxLength: 255),
                        CategoryId = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.OrganizerId, cascadeDelete: true)
                .Index(t => t.OrganizerId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Events", "OrganizerId", "dbo.AspNetUsers");
            DropIndex("dbo.Events", new[] { "OrganizerId" });
            DropTable("dbo.Events");
        }
    }
}
