namespace MVCSBD_Sklep.Migrations.XmoreltronikEntities
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class XmoreltronikConfiguration : DbMigrationsConfiguration<Models.XmoreltronikEntities>
    {
        public XmoreltronikConfiguration()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"Migrations\XmoreltronikEntities";
            ContextKey = "MVCSBD_Sklep.Models.XmoreltronikEntities";
        }

        protected override void Seed(Models.XmoreltronikEntities context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
