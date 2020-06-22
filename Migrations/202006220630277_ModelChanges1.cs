namespace Diagnostic_Medical_Center.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModelChanges1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Admins", "Password", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Agents", "Password", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Doctors", "Password", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Patients", "Password", c => c.String(nullable: false, maxLength: 100));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Patients", "Password", c => c.String(nullable: false));
            AlterColumn("dbo.Doctors", "Password", c => c.String(nullable: false));
            AlterColumn("dbo.Agents", "Password", c => c.String(nullable: false));
            AlterColumn("dbo.Admins", "Password", c => c.String(nullable: false));
        }
    }
}
