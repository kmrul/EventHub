namespace EventHub.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateCategoryIdRename : DbMigration
    {
        public override void Up()
        {
            //DropForeignKey("dbo.Events", "Category_Id", "dbo.AspNetUsers");
            //DropIndex("dbo.Events", new[] { "Category_Id" });
            //DropIndex("dbo.Events", new[] { "CategoryId" });
            //AlterColumn("dbo.Events", "CategoryId", c => c.String(nullable: false, maxLength: 128));
            //RenameColumn(table: "dbo.Events", name: "Category_Id", newName: "CategoryId");
            //CreateIndex("dbo.Events", "CategoryId");
            //AddForeignKey("dbo.Events", "CategoryId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            //AlterColumn("dbo.Events", "CategoryId", c => c.String(nullable: false, maxLength: 128));
            //DropForeignKey("dbo.Events", "Category_Id", "dbo.AspNetUsers");
            //DropIndex("dbo.Events", new[] { "Category_Id" });
            //AlterColumn("dbo.Events", "CategoryId", c => c.String(maxLength: 128));
            //RenameColumn(table: "dbo.Events", name: "CategoryId", newName: "Category_Id");
            //CreateIndex("dbo.Events", "Category_Id");
            //AddForeignKey("dbo.Events", "Category_Id", "dbo.AspNetUsers", "Id");
        }
    }
}
