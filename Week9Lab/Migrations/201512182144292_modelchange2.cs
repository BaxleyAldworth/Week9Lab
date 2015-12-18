namespace Week9Lab.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modelchange2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "Follow", c => c.Boolean(nullable: false));
            AddColumn("dbo.Users", "Unfollow", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "Unfollow");
            DropColumn("dbo.Users", "Follow");
        }
    }
}
