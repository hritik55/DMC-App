namespace Diagnostic_Medical_Center.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changedServices1 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.MedicareServices", "DoctorId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.MedicareServices", "DoctorId", c => c.String());
        }
    }
}
