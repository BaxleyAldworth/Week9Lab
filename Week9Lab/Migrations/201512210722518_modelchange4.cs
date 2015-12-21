namespace Week9Lab.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modelchange4 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Users", newName: "UsersFollwedVMs");
            DropForeignKey("dbo.Posts", "User_UserId", "dbo.Users");
            DropIndex("dbo.Posts", new[] { "User_UserId" });
            RenameColumn(table: "dbo.Posts", name: "User_UserId", newName: "User_Id");
            DropPrimaryKey("dbo.UsersFollwedVMs");
            AddColumn("dbo.UsersFollwedVMs", "Id", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.UsersFollwedVMs", "UserName", c => c.String());
            AddColumn("dbo.UsersFollwedVMs", "FirstName", c => c.String());
            AddColumn("dbo.UsersFollwedVMs", "LastName", c => c.String());
            AddColumn("dbo.UsersFollwedVMs", "Discriminator", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.UsersFollwedVMs", "User_Id", c => c.String(maxLength: 128));
            AlterColumn("dbo.Posts", "User_Id", c => c.String(maxLength: 128));
            AlterColumn("dbo.UsersFollwedVMs", "AlreadyFollowing", c => c.Boolean());
            AddPrimaryKey("dbo.UsersFollwedVMs", "Id");
            CreateIndex("dbo.Posts", "User_Id");
            CreateIndex("dbo.UsersFollwedVMs", "User_Id");
            AddForeignKey("dbo.UsersFollwedVMs", "User_Id", "dbo.UsersFollwedVMs", "Id");
            AddForeignKey("dbo.Posts", "User_Id", "dbo.UsersFollwedVMs", "Id");
            DropColumn("dbo.UsersFollwedVMs", "UserId");
            DropColumn("dbo.UsersFollwedVMs", "Unfollow");
        }
        
        public override void Down()
        {
            AddColumn("dbo.UsersFollwedVMs", "Unfollow", c => c.Boolean(nullable: false));
            AddColumn("dbo.UsersFollwedVMs", "UserId", c => c.Int(nullable: false, identity: true));
            DropForeignKey("dbo.Posts", "User_Id", "dbo.UsersFollwedVMs");
            DropForeignKey("dbo.UsersFollwedVMs", "User_Id", "dbo.UsersFollwedVMs");
            DropIndex("dbo.UsersFollwedVMs", new[] { "User_Id" });
            DropIndex("dbo.Posts", new[] { "User_Id" });
            DropPrimaryKey("dbo.UsersFollwedVMs");
            AlterColumn("dbo.UsersFollwedVMs", "AlreadyFollowing", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Posts", "User_Id", c => c.Int());
            DropColumn("dbo.UsersFollwedVMs", "User_Id");
            DropColumn("dbo.UsersFollwedVMs", "Discriminator");
            DropColumn("dbo.UsersFollwedVMs", "LastName");
            DropColumn("dbo.UsersFollwedVMs", "FirstName");
            DropColumn("dbo.UsersFollwedVMs", "UserName");
            DropColumn("dbo.UsersFollwedVMs", "Id");
            AddPrimaryKey("dbo.UsersFollwedVMs", "UserId");
            RenameColumn(table: "dbo.Posts", name: "User_Id", newName: "User_UserId");
            CreateIndex("dbo.Posts", "User_UserId");
            AddForeignKey("dbo.Posts", "User_UserId", "dbo.Users", "UserId");
            RenameTable(name: "dbo.UsersFollwedVMs", newName: "Users");
        }
    }
}
