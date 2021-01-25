namespace Library_MVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial4 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Books", "Available", c => c.Int(nullable: false));
            DropColumn("dbo.Books", "Status");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Books", "Status", c => c.String());
            DropColumn("dbo.Books", "Available");
        }
    }
}
