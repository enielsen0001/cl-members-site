namespace memberSite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedJobPost : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.JobPosts",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Date = c.String(),
                        Title = c.String(),
                        PostBody = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.JobPosts");
        }
    }
}
