using System.ComponentModel.DataAnnotations;

namespace memberSite.Models
{
    public class UserDetailsModel
    {
        public int ID
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

        [StringLength(150)]
        public string pathToImg
        {
            get; set;
        }

        [StringLength(150)]
        public string pathToFile
        {
            get; set;
        }

        [StringLength(1500)]
        public string About
        {
            get; set;
        }

        [StringLength(50)]
        public string FrontEnd
        {
            get; set;
        }

        [StringLength(50)]
        public string PHP
        {
            get; set;
        }

        [StringLength(50)]
        public string DotNet
        {
            get; set;
        }

        [StringLength(50)]
        public string RubyOnRails
        {
            get; set;
        }

        [StringLength(50)]
        public string iOS
        {
            get; set;
        }

        [StringLength(50)]
        public string Android
        {
            get; set;
        }
    }
}