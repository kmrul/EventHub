namespace EventHub.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddForeignKeyPropertyToEvent : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Events", "Organizer_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Events", new[] { "Organizer_Id" });
            RenameColumn(table: "dbo.Events", name: "Organizer_Id", newName: "OrganizerId");
            AddColumn("dbo.Events", "CategoryId", c => c.Byte(nullable: false));
            AlterColumn("dbo.Events", "OrganizerId", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.Events", "OrganizerId");
            AddForeignKey("dbo.Events", "OrganizerId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Events", "OrganizerId", "dbo.AspNetUsers");
            DropIndex("dbo.Events", new[] { "OrganizerId" });
            AlterColumn("dbo.Events", "OrganizerId", c => c.String(maxLength: 128));
            DropColumn("dbo.Events", "CategoryId");
            RenameColumn(table: "dbo.Events", name: "OrganizerId", newName: "Organizer_Id");
            CreateIndex("dbo.Events", "Organizer_Id");
            AddForeignKey("dbo.Events", "Organizer_Id", "dbo.AspNetUsers", "Id");
        }
    }
}
