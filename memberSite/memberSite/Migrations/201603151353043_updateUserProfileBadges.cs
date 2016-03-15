namespace memberSite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateUserProfileBadges : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserDetails", "MeanJS", c => c.Boolean(nullable: false));
            AddColumn("dbo.UserDetails", "Mentor", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.UserDetails", "Mentor");
            DropColumn("dbo.UserDetails", "MeanJS");
        }
    }
}
