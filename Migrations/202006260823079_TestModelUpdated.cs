namespace Diagnostic_Medical_Center.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TestModelUpdated : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Tests", "Patient_UserId", "dbo.Patients");
            DropIndex("dbo.Tests", new[] { "Patient_UserId" });
            CreateTable(
                "dbo.PatientTests",
                c => new
                    {
                        Patient_UserId = c.String(nullable: false, maxLength: 128),
                        Test_TestId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Patient_UserId, t.Test_TestId })
                .ForeignKey("dbo.Patients", t => t.Patient_UserId, cascadeDelete: true)
                .ForeignKey("dbo.Tests", t => t.Test_TestId, cascadeDelete: true)
                .Index(t => t.Patient_UserId)
                .Index(t => t.Test_TestId);
            
            AddColumn("dbo.Tests", "MedicareService_ServiceID", c => c.Int());
            CreateIndex("dbo.Tests", "MedicareService_ServiceID");
            AddForeignKey("dbo.Tests", "MedicareService_ServiceID", "dbo.MedicareServices", "ServiceID");
            DropColumn("dbo.Tests", "PatientId");
            DropColumn("dbo.Tests", "Patient_UserId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Tests", "Patient_UserId", c => c.String(maxLength: 128));
            AddColumn("dbo.Tests", "PatientId", c => c.String());
            DropForeignKey("dbo.Tests", "MedicareService_ServiceID", "dbo.MedicareServices");
            DropForeignKey("dbo.PatientTests", "Test_TestId", "dbo.Tests");
            DropForeignKey("dbo.PatientTests", "Patient_UserId", "dbo.Patients");
            DropIndex("dbo.PatientTests", new[] { "Test_TestId" });
            DropIndex("dbo.PatientTests", new[] { "Patient_UserId" });
            DropIndex("dbo.Tests", new[] { "MedicareService_ServiceID" });
            DropColumn("dbo.Tests", "MedicareService_ServiceID");
            DropTable("dbo.PatientTests");
            CreateIndex("dbo.Tests", "Patient_UserId");
            AddForeignKey("dbo.Tests", "Patient_UserId", "dbo.Patients", "UserId");
        }
    }
}
