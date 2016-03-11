namespace memberSite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class firstMigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Comments", "RegisteredUserID", c => c.String());
            AddColumn("dbo.UserDetails", "RegisteredUserID", c => c.String());
            DropColumn("dbo.Comments", "UserID");
            DropColumn("dbo.UserDetails", "UserID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.UserDetails", "UserID", c => c.String());
            AddColumn("dbo.Comments", "UserID", c => c.String());
            DropColumn("dbo.UserDetails", "RegisteredUserID");
            DropColumn("dbo.Comments", "RegisteredUserID");
        }
    }
}
