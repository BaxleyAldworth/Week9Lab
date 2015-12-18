namespace Week9Lab.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class editingmodels : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "Email", c => c.String());
            DropColumn("dbo.Users", "LoginId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "LoginId", c => c.String());
            DropColumn("dbo.Users", "Email");
        }
    }
}
