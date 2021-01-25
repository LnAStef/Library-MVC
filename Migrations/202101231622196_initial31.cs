namespace Library_MVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial31 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Books", "Name");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Books", "Name", c => c.String(nullable: false));
        }
    }
}
