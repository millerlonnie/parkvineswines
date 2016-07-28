namespace WimbledonWines.Migrations
{
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<WimbledonWines.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
            ContextKey = "WimbledonWines.Models.ApplicationDbContext";
        }

        protected override void Seed(WimbledonWines.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
            
            context.Roles.AddOrUpdate(r => r.Name, //defining user roles
                  new IdentityRole { Name = "Admin" },
                  new IdentityRole { Name = "Member" },
                  new IdentityRole { Name = "Moderator" },
                  new IdentityRole { Name = "Junior" },
                  new IdentityRole { Name = "Candidate" }
                  );
            

        }
    }
}
