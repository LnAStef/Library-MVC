namespace Library_MVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial12 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Books", "SerialNumber", c => c.String());
            DropColumn("dbo.Books", "BookUrl");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Books", "BookUrl", c => c.String());
            DropColumn("dbo.Books", "SerialNumber");
        }
    }
}
