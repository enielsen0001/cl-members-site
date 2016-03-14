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

        public System.Data.Entity.DbSet<memberSite.Models.JobPost> JobPosts
        {
            get; set;
        }
    }
}