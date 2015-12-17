namespace Week9Lab.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeprops : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Posts",
                c => new
                    {
                        PostId = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Message = c.String(),
                        ImageUrl = c.String(),
                        User_UserId = c.Int(),
                    })
                .PrimaryKey(t => t.PostId)
                .ForeignKey("dbo.Users", t => t.User_UserId)
                .Index(t => t.User_UserId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        LoginId = c.String(),
                        Password = c.String(),
                        ProfileInfo_ProfileId = c.Int(),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.Profiles", t => t.ProfileInfo_ProfileId)
                .Index(t => t.ProfileInfo_ProfileId);
            
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
                .PrimaryKey(t => t.ProfileId)
                .ForeignKey("dbo.Users", t => t.UserId_UserId)
                .ForeignKey("dbo.Users", t => t.Userprofile_UserId)
                .Index(t => t.UserId_UserId)
                .Index(t => t.Userprofile_UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "ProfileInfo_ProfileId", "dbo.Profiles");
            DropForeignKey("dbo.Profiles", "Userprofile_UserId", "dbo.Users");
            DropForeignKey("dbo.Profiles", "UserId_UserId", "dbo.Users");
            DropForeignKey("dbo.Posts", "User_UserId", "dbo.Users");
            DropIndex("dbo.Profiles", new[] { "Userprofile_UserId" });
            DropIndex("dbo.Profiles", new[] { "UserId_UserId" });
            DropIndex("dbo.Users", new[] { "ProfileInfo_ProfileId" });
            DropIndex("dbo.Posts", new[] { "User_UserId" });
            DropTable("dbo.Profiles");
            DropTable("dbo.Users");
            DropTable("dbo.Posts");
        }
    }
}
