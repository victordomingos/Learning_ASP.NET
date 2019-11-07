namespace Fornecedores.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class e : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Fornecedors",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        codigo = c.String(),
                        nome_do_fornecedor = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Fornecedors");
        }
    }
}
