namespace LT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ListaDeContactos",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Cliente = c.String(),
                        Telefone = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ListaDeContactos");
        }
    }
}
