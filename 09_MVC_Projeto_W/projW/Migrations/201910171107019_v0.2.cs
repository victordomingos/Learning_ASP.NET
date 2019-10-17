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
            
            CreateTable(
                "dbo.Tarefas",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Titulo = c.String(),
                        Equipa = c.String(),
                        DataRegisto = c.DateTime(nullable: false),
                        DataLimite = c.DateTime(nullable: false),
                        SujeitaCoima = c.Boolean(nullable: false),
                        TipoImportancia = c.String(),
                        Descritivo = c.String(),
                        Estado = c.Boolean(nullable: false),
                        ClienteID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Clientes", t => t.ClienteID, cascadeDelete: true)
                .Index(t => t.ClienteID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tarefas", "ClienteID", "dbo.Clientes");
            DropIndex("dbo.Tarefas", new[] { "ClienteID" });
            DropTable("dbo.Tarefas");
            DropTable("dbo.Clientes");
        }
    }
}
