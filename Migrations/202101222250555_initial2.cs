namespace Library_MVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Books", "Client_ClientId1", c => c.Int());
            CreateIndex("dbo.Books", "Client_ClientId1");
            AddForeignKey("dbo.Books", "Client_ClientId1", "dbo.Clients", "ClientId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Books", "Client_ClientId1", "dbo.Clients");
            DropIndex("dbo.Books", new[] { "Client_ClientId1" });
            DropColumn("dbo.Books", "Client_ClientId1");
        }
    }
}
