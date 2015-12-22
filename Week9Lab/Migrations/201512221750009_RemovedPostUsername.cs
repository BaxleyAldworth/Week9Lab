namespace Week9Lab.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovedPostUsername : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Posts", "UserName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Posts", "UserName", c => c.String());
        }
    }
}
