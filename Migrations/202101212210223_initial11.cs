namespace Library_MVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial11 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Clients", "LibraryCard", c => c.String());
            DropColumn("dbo.Clients", "MovieCard");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Clients", "MovieCard", c => c.String());
            DropColumn("dbo.Clients", "LibraryCard");
        }
    }
}
