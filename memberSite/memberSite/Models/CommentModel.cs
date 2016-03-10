using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace memberSite.Models
{
    public class CommentModel
    {
        public int ID
        {
            get; set;
        }

        public virtual UserDetailsModel UserID
        {
            get; set;
        }

        public virtual UserDetailsModel FirstName
        {
            get; set;
        }

        public virtual UserDetailsModel LastName
        {
            get; set;
        }

        public virtual UserDetailsModel EmailHash
        {
            get; set;
        }

        public DateTime Date
        {
            get; set;
        }

        public string Comment
        {
            get; set;
        }
    }
}