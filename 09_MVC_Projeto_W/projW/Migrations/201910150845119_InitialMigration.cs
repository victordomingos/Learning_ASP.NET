namespace projW.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
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
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Tarefas");
        }
    }
}
