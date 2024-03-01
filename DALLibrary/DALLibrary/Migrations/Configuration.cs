﻿namespace DALLibrary.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DALLibrary.Data.ClinicDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DALLibrary.Data.ClinicDbContext context)
        {
            base.Seed(context);

            //  This method will be called after migrating to the latest version.
            context.Database.ExecuteSqlCommand("DBCC CHECKIDENT('Patients', RESEED, 1000)");
            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
        }
    }
}
