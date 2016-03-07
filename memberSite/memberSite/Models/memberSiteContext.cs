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

        public DbSet<UserDetailsModel> UserDetails
        {
            get; set;
        }

    }
}