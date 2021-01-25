namespace Library_MVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial41 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Books", "Status", c => c.Int(nullable: false));
            DropColumn("dbo.Books", "Available");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Books", "Available", c => c.Int(nullable: false));
            DropColumn("dbo.Books", "Status");
        }
    }
}
