namespace Library_MVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Books", "Client_ClientId", c => c.Int());
            AddColumn("dbo.Clients", "Address", c => c.String());
            AddColumn("dbo.Clients", "MovieCard", c => c.String());
            AddColumn("dbo.Clients", "Age", c => c.Int(nullable: false));
            AddColumn("dbo.Clients", "Telephone", c => c.String());
            AlterColumn("dbo.Clients", "Name", c => c.String(nullable: false));
            CreateIndex("dbo.Books", "Client_ClientId");
            AddForeignKey("dbo.Books", "Client_ClientId", "dbo.Clients", "ClientId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Books", "Client_ClientId", "dbo.Clients");
            DropIndex("dbo.Books", new[] { "Client_ClientId" });
            AlterColumn("dbo.Clients", "Name", c => c.String());
            DropColumn("dbo.Clients", "Telephone");
            DropColumn("dbo.Clients", "Age");
            DropColumn("dbo.Clients", "MovieCard");
            DropColumn("dbo.Clients", "Address");
            DropColumn("dbo.Books", "Client_ClientId");
        }
    }
}
