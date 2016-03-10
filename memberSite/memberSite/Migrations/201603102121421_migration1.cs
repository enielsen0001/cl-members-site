namespace memberSite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migration1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Comments", "userDetail_ID", "dbo.UserDetails");
            DropIndex("dbo.Comments", new[] { "userDetail_ID" });
            DropColumn("dbo.Comments", "UserID");
            RenameColumn(table: "dbo.Comments", name: "userDetail_ID", newName: "UserID");
            DropPrimaryKey("dbo.UserDetails");
            AlterColumn("dbo.Comments", "UserID", c => c.String(maxLength: 128));
            AlterColumn("dbo.Comments", "UserID", c => c.String(maxLength: 128));
            AlterColumn("dbo.UserDetails", "ID", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.UserDetails", "ID");
            CreateIndex("dbo.Comments", "UserID");
            AddForeignKey("dbo.Comments", "UserID", "dbo.UserDetails", "ID");
            DropColumn("dbo.UserDetails", "UserID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.UserDetails", "UserID", c => c.String());
            DropForeignKey("dbo.Comments", "UserID", "dbo.UserDetails");
            DropIndex("dbo.Comments", new[] { "UserID" });
            DropPrimaryKey("dbo.UserDetails");
            AlterColumn("dbo.UserDetails", "ID", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Comments", "UserID", c => c.Int());
            AlterColumn("dbo.Comments", "UserID", c => c.String());
            AddPrimaryKey("dbo.UserDetails", "ID");
            RenameColumn(table: "dbo.Comments", name: "UserID", newName: "userDetail_ID");
            AddColumn("dbo.Comments", "UserID", c => c.String());
            CreateIndex("dbo.Comments", "userDetail_ID");
            AddForeignKey("dbo.Comments", "userDetail_ID", "dbo.UserDetails", "ID");
        }
    }
}
