namespace Diagnostic_Medical_Center.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class minorModelChanges : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MedicareServices", "ServiceID", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.MedicareServices", "ServiceID");
        }
    }
}
