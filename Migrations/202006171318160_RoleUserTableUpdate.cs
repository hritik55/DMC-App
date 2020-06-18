namespace Diagnostic_Medical_Center.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RoleUserTableUpdate : DbMigration
    {
        public override void Up()
        {
           
            DropForeignKey("dbo.Users", "Role_Id", "dbo.AspNetRoles");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropIndex("dbo.Roles", "RoleNameIndex");
            DropIndex("dbo.Users", new[] { "Role_Id" });
            RenameColumn(table: "dbo.Users", name: "Role_Id", newName: "RoleId");
            DropPrimaryKey("dbo.Roles");
 
            
            
            AlterColumn("dbo.Roles", "Id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Users", "RoleId", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Roles", "Id");
            CreateIndex("dbo.Users", "RoleId");
            AddForeignKey("dbo.Users", "RoleId", "dbo.Roles", "Id", cascadeDelete: true);
           
            
        }
        
        public override void Down()
        {
            AddColumn("dbo.Roles", "Discriminator", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.Roles", "Name", c => c.String(nullable: false, maxLength: 256));
            DropForeignKey("dbo.Users", "RoleId", "dbo.Roles");
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Users", new[] { "RoleId" });
            DropPrimaryKey("dbo.Roles");
            AlterColumn("dbo.Users", "RoleId", c => c.String(maxLength: 128));
            AlterColumn("dbo.Roles", "Id", c => c.String(nullable: false, maxLength: 128));
            DropColumn("dbo.Roles", "RoleName");
            DropTable("dbo.AspNetRoles");
            AddPrimaryKey("dbo.Roles", "Id");
            RenameColumn(table: "dbo.Users", name: "RoleId", newName: "Role_Id");
            CreateIndex("dbo.Users", "Role_Id");
            CreateIndex("dbo.Roles", "Name", unique: true, name: "RoleNameIndex");
            AddForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Users", "Role_Id", "dbo.AspNetRoles", "Id");
            RenameTable(name: "dbo.Roles", newName: "AspNetRoles");
        }
    }
}
