namespace projW.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Clientes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NomeCliente = c.String(),
                        CodigoInternoCliente = c.String(),
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
                        Descritivo = c.String(),
                        Estado = c.Boolean(nullable: false),
                        ClienteID = c.Int(nullable: false),
                        TipoPrioridadeID = c.Int(nullable: false),
                        TipoTarefaID = c.Int(nullable: false),
                        FuncionarioID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Clientes", t => t.ClienteID, cascadeDelete: true)
                .ForeignKey("dbo.Funcionarios", t => t.FuncionarioID, cascadeDelete: true)
                .ForeignKey("dbo.TipoPrioridades", t => t.TipoPrioridadeID, cascadeDelete: true)
                .ForeignKey("dbo.TipoTarefas", t => t.TipoTarefaID, cascadeDelete: true)
                .Index(t => t.ClienteID)
                .Index(t => t.TipoPrioridadeID)
                .Index(t => t.TipoTarefaID)
                .Index(t => t.FuncionarioID);
            
            CreateTable(
                "dbo.Funcionarios",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NomeFuncionario = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.LinhaDeTarefas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Descritivo = c.String(),
                        DataDaLinha = c.DateTime(nullable: false),
                        TarefaID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Tarefas", t => t.TarefaID, cascadeDelete: true)
                .Index(t => t.TarefaID);
            
            CreateTable(
                "dbo.TipoPrioridades",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DesignacaoPrioridade = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TipoTarefas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DesignacaoTipoTarefa = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tarefas", "TipoTarefaID", "dbo.TipoTarefas");
            DropForeignKey("dbo.Tarefas", "TipoPrioridadeID", "dbo.TipoPrioridades");
            DropForeignKey("dbo.LinhaDeTarefas", "TarefaID", "dbo.Tarefas");
            DropForeignKey("dbo.Tarefas", "FuncionarioID", "dbo.Funcionarios");
            DropForeignKey("dbo.Tarefas", "ClienteID", "dbo.Clientes");
            DropIndex("dbo.LinhaDeTarefas", new[] { "TarefaID" });
            DropIndex("dbo.Tarefas", new[] { "FuncionarioID" });
            DropIndex("dbo.Tarefas", new[] { "TipoTarefaID" });
            DropIndex("dbo.Tarefas", new[] { "TipoPrioridadeID" });
            DropIndex("dbo.Tarefas", new[] { "ClienteID" });
            DropTable("dbo.TipoTarefas");
            DropTable("dbo.TipoPrioridades");
            DropTable("dbo.LinhaDeTarefas");
            DropTable("dbo.Funcionarios");
            DropTable("dbo.Tarefas");
            DropTable("dbo.Clientes");
        }
    }
}
