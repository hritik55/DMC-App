namespace Diagnostic_Medical_Center.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tempRoleTable1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.UserRoles", "UserRoleName", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.UserRoles", "UserRoleName", c => c.Int(nullable: false));
        }
    }
}
