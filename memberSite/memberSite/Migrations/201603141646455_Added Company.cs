namespace memberSite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedCompany : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.JobPosts", "Company", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.JobPosts", "Company");
        }
    }
}
