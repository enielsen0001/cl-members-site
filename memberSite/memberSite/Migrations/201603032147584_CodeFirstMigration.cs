namespace memberSite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CodeFirstMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserDetailsModels",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        PhoneNumber = c.String(),
                        Email = c.String(),
                        WebsiteURL = c.String(),
                        GitHubURL = c.String(),
                        LinkedinURL = c.String(),
                        pathToImg = c.String(),
                        pathToFile = c.String(),
                        About = c.String(),
                        FrontEnd = c.String(),
                        PHP = c.String(),
                        DotNet = c.String(),
                        RubyOnRails = c.String(),
                        iOS = c.String(),
                        Android = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.UserDetailsModels");
        }
    }
}
