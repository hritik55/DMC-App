namespace Diagnostic_Medical_Center.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newChanges : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Admins",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Age = c.Int(nullable: false),
                        Sex = c.Int(nullable: false),
                        PhoneNo = c.String(),
                        IsAvailable = c.Boolean(nullable: false),
                        RegistrationStatus = c.Boolean(nullable: false),
                        VendorId = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Tests",
                c => new
                    {
                        TestId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.TestId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        Role_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetRoles", t => t.Role_Id)
                .Index(t => t.Role_Id);
            
            AddColumn("dbo.Agents", "Sex", c => c.Int(nullable: false));
            AddColumn("dbo.Doctors", "Sex", c => c.Int(nullable: false));
          
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.AspNetRoles", "RoleName", c => c.String());
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Users", "Role_Id", "dbo.AspNetRoles");
            DropIndex("dbo.Users", new[] { "Role_Id" });
            DropPrimaryKey("dbo.AspNetRoles");
            AlterColumn("dbo.AspNetRoles", "Id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Doctors", "PhoneNo", c => c.String());
            AlterColumn("dbo.Doctors", "LastName", c => c.String());
            AlterColumn("dbo.Doctors", "FirstName", c => c.String());
            DropColumn("dbo.AspNetRoles", "Discriminator");
            DropColumn("dbo.AspNetRoles", "Name");
            DropColumn("dbo.Doctors", "Sex");
            DropColumn("dbo.Agents", "Sex");
            DropTable("dbo.Users");
            DropTable("dbo.Tests");
            DropTable("dbo.Admins");
            AddPrimaryKey("dbo.AspNetRoles", "Id");
            RenameTable(name: "dbo.AspNetRoles", newName: "Roles");
        }
    }
}
