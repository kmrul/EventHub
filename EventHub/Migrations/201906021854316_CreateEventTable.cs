namespace EventHub.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateEventTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Events",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateTime = c.DateTime(nullable: false),
                        Name = c.String(nullable: false, maxLength: 255),
                        Vanue = c.String(nullable: false, maxLength: 255),
                        Category_Id = c.Int(),
                        Organizer_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.Category_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.Organizer_Id)
                .Index(t => t.Category_Id)
                .Index(t => t.Organizer_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Events", "Organizer_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Events", "Category_Id", "dbo.Categories");
            DropIndex("dbo.Events", new[] { "Organizer_Id" });
            DropIndex("dbo.Events", new[] { "Category_Id" });
            DropTable("dbo.Events");
            DropTable("dbo.Categories");
        }
    }
}
