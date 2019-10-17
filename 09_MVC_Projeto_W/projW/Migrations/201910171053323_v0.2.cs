namespace projW.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v02 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Clientes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Tarefas", "ClienteID", c => c.Int(nullable: false));
            CreateIndex("dbo.Tarefas", "ClienteID");
            AddForeignKey("dbo.Tarefas", "ClienteID", "dbo.Clientes", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tarefas", "ClienteID", "dbo.Clientes");
            DropIndex("dbo.Tarefas", new[] { "ClienteID" });
            DropColumn("dbo.Tarefas", "ClienteID");
            DropTable("dbo.Clientes");
        }
    }
}
