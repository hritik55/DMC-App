namespace Diagnostic_Medical_Center.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedMedicareServices : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MedicareServices", "ServiceName", c => c.String(nullable: false));
            AddColumn("dbo.MedicareServices", "Eligibility", c => c.String());
            AddColumn("dbo.MedicareServices", "IsAvailable", c => c.Boolean(nullable: false));
            DropColumn("dbo.MedicareServices", "Name");
        }
        
        public override void Down()
        {
            AddColumn("dbo.MedicareServices", "Name", c => c.String());
            DropColumn("dbo.MedicareServices", "IsAvailable");
            DropColumn("dbo.MedicareServices", "Eligibility");
            DropColumn("dbo.MedicareServices", "ServiceName");
        }
    }
}
