namespace memberSite.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<memberSite.Models.MemberSiteDB>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        //protected override void Seed(memberSite.Models.MemberSiteDB context)
        //{
        //    //  This method will be called after migrating to the latest version.

        //    //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
        //    //  to avoid creating duplicate seed data. E.g.
        //    //
        //    //    context.People.AddOrUpdate(
        //    //      p => p.FullName,
        //    //      new Person { FullName = "Andrew Peters" },
        //    //      new Person { FullName = "Brice Lambson" },
        //    //      new Person { FullName = "Rowan Miller" }
        //    //    );
        //    //
        //}

        protected override void Seed(memberSite.Models.MemberSiteDB context)
        {
            
            var roleManager = new RoleManager<Microsoft.AspNet.Identity.EntityFramework.IdentityRole>(new RoleStore<IdentityRole>(new ApplicationDbContext()));

            if (!roleManager.RoleExists("Admin"))
                roleManager.Create(new IdentityRole("Admin"));

            if (!roleManager.RoleExists("Alumni"))
                roleManager.Create(new IdentityRole("Alumni"));

            if (!roleManager.RoleExists("Employer"))
                roleManager.Create(new IdentityRole("Employer"));
            
        }

        
    }
}
