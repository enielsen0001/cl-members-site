namespace memberSite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        RegisteredUserID = c.String(),
                        Date = c.String(),
                        Subject = c.String(),
                        CommentText = c.String(),
                        userDetail_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.UserDetails", t => t.userDetail_ID)
                .Index(t => t.userDetail_ID);
            
            CreateTable(
                "dbo.UserDetails",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        RegisteredUserID = c.String(),
                        FirstName = c.String(nullable: false, maxLength: 25),
                        LastName = c.String(nullable: false, maxLength: 50),
                        PhoneNumber = c.String(maxLength: 12),
                        Email = c.String(maxLength: 100),
                        WebsiteURL = c.String(maxLength: 300),
                        GitHubURL = c.String(maxLength: 300),
                        LinkedinURL = c.String(maxLength: 300),
                        EmailHash = c.String(),
                        About = c.String(maxLength: 1500),
                        FrontEnd = c.Boolean(nullable: false),
                        PHP = c.Boolean(nullable: false),
                        DotNet = c.Boolean(nullable: false),
                        RubyOnRails = c.Boolean(nullable: false),
                        iOS = c.Boolean(nullable: false),
                        Android = c.Boolean(nullable: false),
                        MeanJS = c.Boolean(nullable: false),
                        Mentor = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.JobPosts",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Date = c.String(),
                        Title = c.String(),
                        PostBody = c.String(),
                        Company = c.String(),
                        RegisteredUserID = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Comments", "userDetail_ID", "dbo.UserDetails");
            DropIndex("dbo.Comments", new[] { "userDetail_ID" });
            DropTable("dbo.JobPosts");
            DropTable("dbo.UserDetails");
            DropTable("dbo.Comments");
        }
    }
}
