namespace memberSite.Migrations
{
    using System.Data.Entity.Migrations;
    using Microsoft.AspNet.Identity;
    using Models;
    using Microsoft.AspNet.Identity.EntityFramework;
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
            //if there isn't an admin, create one
            var roleManager = new RoleManager<Microsoft.AspNet.Identity.EntityFramework.IdentityRole>(new RoleStore<IdentityRole>(new ApplicationDbContext()));

            if (!roleManager.RoleExists("Admin"))
                roleManager.Create(new IdentityRole("Admin"));

            if (!roleManager.RoleExists("Alumni"))
                roleManager.Create(new IdentityRole("Alumni"));

            if (!roleManager.RoleExists("Employer"))
                roleManager.Create(new IdentityRole("Employer"));
            


            //        if (!context.Roles.Any(r => r.Name == "AppAdmin"))
            //        {
            //            var store = new RoleStore<IdentityRole>(context);
            //    var manager = new RoleManager<IdentityRole>(store);
            //    var role = new IdentityRole { Name = "AppAdmin" };

            //    manager.Create(role);
            //        }

            //        if (!context.Users.Any(u => u.UserName == "founder"))
            //        {
            //            var store = new UserStore<ApplicationUser>(context);
            //var manager = new UserManager<ApplicationUser>(store);
            //var user = new ApplicationUser { UserName = "founder" };

            //manager.Create(user, "ChangeItAsap!");
            //            manager.AddToRole(user.Id, "AppAdmin");
        }
        }
    }

