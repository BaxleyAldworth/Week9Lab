namespace Week9Lab.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedPostID : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Posts");
            AddColumn("dbo.Posts", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Posts", "Id");
            DropColumn("dbo.Posts", "PostId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Posts", "PostId", c => c.String(nullable: false, maxLength: 128));
            DropPrimaryKey("dbo.Posts");
            DropColumn("dbo.Posts", "Id");
            AddPrimaryKey("dbo.Posts", "PostId");
        }
    }
}
