namespace MVC_tracking_exercise.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Zero : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Destinatarios",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Envios",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Codigo = c.String(),
                        Estado = c.String(),
                        DataExpedicao = c.DateTime(nullable: false),
                        DestinatarioId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Destinatarios", t => t.DestinatarioId, cascadeDelete: true)
                .Index(t => t.DestinatarioId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Envios", "DestinatarioId", "dbo.Destinatarios");
            DropIndex("dbo.Envios", new[] { "DestinatarioId" });
            DropTable("dbo.Envios");
            DropTable("dbo.Destinatarios");
        }
    }
}
