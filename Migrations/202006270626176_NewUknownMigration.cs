namespace Diagnostic_Medical_Center.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewUknownMigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TestRequests", "isActiveRequest", c => c.Boolean(nullable: false));
            AlterColumn("dbo.TestRequests", "result", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.TestRequests", "result", c => c.String(nullable: false));
            DropColumn("dbo.TestRequests", "isActiveRequest");
        }
    }
}
