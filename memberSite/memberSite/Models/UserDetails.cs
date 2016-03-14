using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace memberSite.Models
{
    public class UserDetails
    {
        public UserDetails()
        {
            Comments = new List<Comment>();
        }

        public virtual ICollection<Comment> Comments
        {
            get; set;
        }

        public int ID
        {
            get; set;
        }

        public string RegisteredUserID
        {
            get; set;
        }

        [Required]
        [StringLength(25)]
        public string FirstName
        {
            get; set;
        }

        [Required]
        [StringLength(50)]
        public string LastName
        {
            get; set;
        }

        [StringLength(12)]
        public string PhoneNumber
        {
            get; set;
        }

        [StringLength(100)]
        public string Email
        {
            get; set;
        }

        [StringLength(300)]
        public string WebsiteURL
        {
            get; set;
        }

        [StringLength(300)]
        public string GitHubURL
        {
            get; set;
        }

        [StringLength(300)]
        public string LinkedinURL
        {
            get; set;
        }

        
        public string EmailHash
        {
            get; set;
        }

        [StringLength(1500)]
        public string About
        {
            get; set;
        }

        
        public bool FrontEnd
        {
            get; set;
        }

        
        public bool PHP
        {
            get; set;
        }

        
        public bool DotNet
        {
            get; set;
        }

        
        public bool RubyOnRails
        {
            get; set;
        }

        
        public bool iOS
        {
            get; set;
        }

        
        public bool Android
        {
            get; set;
        }


        //How long do you want your property to be at most ?
        //(Best practice advices against magic numbers)
        private int AboutLimit = 200;

        
        //and let this property mimic the "full" one  
        [Display(Name = "About")]
        public string AboutTrimmed
        {
            get
            {
                if (this.About.Length > this.AboutLimit)
                    return this.About.Substring(0, this.AboutLimit) + "...";
                else
                    return this.About;
            }
        }
    }
}