namespace Diagnostic_Medical_Center.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newMigration : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Admins", "FirstName", c => c.String(nullable: false));
            AlterColumn("dbo.Admins", "PhoneNo", c => c.String(nullable: false));
            AlterColumn("dbo.Admins", "VendorId", c => c.String(nullable: false));
            AlterColumn("dbo.Admins", "Password", c => c.String(nullable: false));
            AlterColumn("dbo.Agents", "FirstName", c => c.String(nullable: false));
            AlterColumn("dbo.Agents", "PhoneNo", c => c.String(nullable: false));
            AlterColumn("dbo.Agents", "AgentId", c => c.String(nullable: false));
            AlterColumn("dbo.Agents", "Password", c => c.String(nullable: false));
            AlterColumn("dbo.Doctors", "UserId", c => c.String(nullable: false));
            AlterColumn("dbo.Doctors", "Password", c => c.String(nullable: false));
            AlterColumn("dbo.Patients", "FirstName", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Patients", "UserId", c => c.String(nullable: false));
            AlterColumn("dbo.Patients", "Password", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Patients", "Password", c => c.String());
            AlterColumn("dbo.Patients", "UserId", c => c.String());
            AlterColumn("dbo.Patients", "FirstName", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Doctors", "Password", c => c.String());
            AlterColumn("dbo.Doctors", "UserId", c => c.String());
            AlterColumn("dbo.Agents", "Password", c => c.String());
            AlterColumn("dbo.Agents", "AgentId", c => c.String());
            AlterColumn("dbo.Agents", "PhoneNo", c => c.String());
            AlterColumn("dbo.Agents", "FirstName", c => c.String());
            AlterColumn("dbo.Admins", "Password", c => c.String());
            AlterColumn("dbo.Admins", "VendorId", c => c.String());
            AlterColumn("dbo.Admins", "PhoneNo", c => c.String());
            AlterColumn("dbo.Admins", "FirstName", c => c.String());
        }
    }
}
