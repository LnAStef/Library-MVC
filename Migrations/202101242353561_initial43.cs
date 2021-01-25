namespace Library_MVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial43 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Clients", "HomeAddress", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Clients", "HomeAddress");
        }
    }
}
