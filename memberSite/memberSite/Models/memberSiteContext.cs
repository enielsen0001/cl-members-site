using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace memberSite.Models
{
    public class MemberSiteDB : DbContext
    {
        public MemberSiteDB() : base("name=DefaultConnection")
        {
        }

        public DbSet<UserDetails> UsersDetails
        {
            get; set;
        }
        public DbSet<Comment> Comments
        {
            get; set;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //one-to-many 
            modelBuilder.Entity<Comment>()
                        .HasOptional(s => s.userDetail)
                        .WithMany(s => s.Comments)
                        .HasForeignKey(s => s.RegisteredUserID);

        }
    }
}