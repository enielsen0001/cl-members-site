using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace memberSite.Models
{
    public class MemberSiteDB : DbContext
    {
        private string _schemaName = string.Empty;

        public MemberSiteDB(string connectionName, string schemaName) :base(connectionName)
        {
            _schemaName = schemaName;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer<MemberSiteDB>(new CreateDatabaseIfNotExists<MemberSiteDB>());
            modelBuilder.Entity<UserDetails>().ToTable("UsersDetails", _schemaName);
            modelBuilder.Entity<Comment>().ToTable("Comments", _schemaName);
            modelBuilder.Entity<JobPost>().ToTable("JobPosts", _schemaName);
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