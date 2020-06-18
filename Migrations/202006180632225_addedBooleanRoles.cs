namespace Diagnostic_Medical_Center.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedBooleanRoles : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "IsAdmin", c => c.Boolean(nullable: false));
            AddColumn("dbo.Users", "IsDoctor", c => c.Boolean(nullable: false));
            AddColumn("dbo.Users", "IsAgent", c => c.Boolean(nullable: false));
            AddColumn("dbo.Users", "IsPatient", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "IsPatient");
            DropColumn("dbo.Users", "IsAgent");
            DropColumn("dbo.Users", "IsDoctor");
            DropColumn("dbo.Users", "IsAdmin");
        }
    }
}
