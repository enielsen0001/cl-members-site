namespace memberSite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addeduseridtojobposts : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.JobPosts", "RegisteredUserID", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.JobPosts", "RegisteredUserID");
        }
    }
}
