namespace PE.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial_DB_Ssetup : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Equipas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Equipas");
        }
    }
}
