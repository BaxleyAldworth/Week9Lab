namespace Week9Lab.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class deletedfollowandprofile : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Profiles", "UserId_UserId", "dbo.Users");
            DropForeignKey("dbo.Profiles", "Userprofile_UserId", "dbo.Users");
            DropForeignKey("dbo.Users", "ProfileInfo_ProfileId", "dbo.Profiles");
            DropIndex("dbo.Users", new[] { "ProfileInfo_ProfileId" });
            DropIndex("dbo.Profiles", new[] { "UserId_UserId" });
            DropIndex("dbo.Profiles", new[] { "Userprofile_UserId" });
            DropColumn("dbo.Users", "ProfileInfo_ProfileId");
            DropTable("dbo.Profiles");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Profiles",
                c => new
                    {
                        ProfileId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Bio = c.String(),
                        Website = c.String(),
                        DOB = c.DateTime(nullable: false),
                        MyProperty = c.Int(nullable: false),
                        UserId_UserId = c.Int(),
                        Userprofile_UserId = c.Int(),
                    })
                .PrimaryKey(t => t.ProfileId);
            
            AddColumn("dbo.Users", "ProfileInfo_ProfileId", c => c.Int());
            CreateIndex("dbo.Profiles", "Userprofile_UserId");
            CreateIndex("dbo.Profiles", "UserId_UserId");
            CreateIndex("dbo.Users", "ProfileInfo_ProfileId");
            AddForeignKey("dbo.Users", "ProfileInfo_ProfileId", "dbo.Profiles", "ProfileId");
            AddForeignKey("dbo.Profiles", "Userprofile_UserId", "dbo.Users", "UserId");
            AddForeignKey("dbo.Profiles", "UserId_UserId", "dbo.Users", "UserId");
        }
    }
}
