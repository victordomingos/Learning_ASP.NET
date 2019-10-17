namespace projW.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v021 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Clientes", "Nome", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Clientes", "Nome", c => c.Int(nullable: false));
        }
    }
}
