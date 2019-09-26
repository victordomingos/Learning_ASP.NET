namespace LT.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<LT.DAL.DbContactos>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "LT.DAL.DbContactos";
        }

        protected override void Seed(LT.DAL.DbContactos context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
