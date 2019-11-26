namespace MVC_tracking_exercise.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class one : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Envios", "Codigo", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Envios", "Codigo", c => c.Int(nullable: false));
        }
    }
}
