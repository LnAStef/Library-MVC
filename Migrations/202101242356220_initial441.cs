namespace Library_MVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial441 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Clients", "ExpirationDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Clients", "PackageType", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Clients", "PackageType");
            DropColumn("dbo.Clients", "ExpirationDate");
        }
    }
}
