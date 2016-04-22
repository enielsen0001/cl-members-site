
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace memberSite.Models
{
    public class MemberSiteDB : DbContext
    {
        

        public MemberSiteDB() :base("name=DefaultConnection")
        {
            
        }

        //public static ApplicationDbContext Create()
        //{
        //    return new ApplicationDbContext();
        //}

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        //    Database.SetInitializer(new MigrateDatabaseToLatestVersion<MemberSiteDB, Migrations.
        //        Configuration>());
            base.OnModelCreating(modelBuilder);
        }


        public DbSet<UserDetails> UsersDetails
        {
            get; set;
        }
        public DbSet<Comment> Comments
        {
            get; set;
        }

        public System.Data.Entity.DbSet<memberSite.Models.JobPost> JobPosts
        {
            get; set;
        }
    }
}