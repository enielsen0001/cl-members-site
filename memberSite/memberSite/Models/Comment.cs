using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace memberSite.Models
{
    public class Comment
    {
        public int ID
        {
            get; set;
        }

        public string RegisteredUserID
        {
            get; set;
        }

        [ForeignKey("RegisteredUserID")]
        public virtual UserDetails userDetail
        {
            get; set;
        }

        public string Date
        {
            get; set;
        }

        public string Subject
        {
            get; set;
        }

        public string CommentText
        {
            get; set;
        }
    }
}