namespace Library_MVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial23 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Books", "Status", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Books", "Status");
        }
    }
}
