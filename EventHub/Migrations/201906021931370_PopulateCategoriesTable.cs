namespace EventHub.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class PopulateCategoriesTable : DbMigration
    {
        public override void Up()
        {
            Sql("SET IDENTITY_INSERT Categories ON");
            Sql("INSERT INTO Categories (Id, Name) VALUES (1,'Educational')");
            Sql("INSERT INTO Categories (Id, Name) VALUES (2,'Social')");
            Sql("INSERT INTO Categories (Id, Name) VALUES (3,'Meetup')");
            Sql("INSERT INTO Categories (Id, Name) VALUES (4,'Non Profit')");
        }

        public override void Down()
        {
            Sql("DELETE FROM Categories WHERE Id IN (1,2,3,4)");
        }
    }
}
