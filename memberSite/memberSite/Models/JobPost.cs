using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace memberSite.Models
{
    public class JobPost
    {
        public int ID
        {
            get; set;
        }
        public string Date
        {
            get; set;
        }
        public string Title
        {
            get; set;
        }
        public string PostBody
        {
            get; set;
        }
        public string Company
        {
            get; set;
        }
        public string RegisteredUserID
        {
            get; set;
        }
    }
}