namespace Diagnostic_Medical_Center.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DropTestTable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Tests", "ServiceID", "dbo.MedicareServices");
            DropForeignKey("dbo.PatientTests", "Patient_UserId", "dbo.Patients");
            DropForeignKey("dbo.PatientTests", "Test_TestId", "dbo.Tests");
            DropForeignKey("dbo.Tests", "Appointment_Id", "dbo.Appointments");
            DropIndex("dbo.Tests", new[] { "ServiceID" });
            DropIndex("dbo.Tests", new[] { "Appointment_Id" });
            DropIndex("dbo.PatientTests", new[] { "Patient_UserId" });
            DropIndex("dbo.PatientTests", new[] { "Test_TestId" });
            AddColumn("dbo.TestRequests", "baseValue", c => c.String());
            CreateIndex("dbo.TestRequests", "AppointmentId");
            AddForeignKey("dbo.TestRequests", "AppointmentId", "dbo.Appointments", "Id", cascadeDelete: true);
            DropColumn("dbo.TestRequests", "TestId");
            DropTable("dbo.Tests");
            DropTable("dbo.PatientTests");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.PatientTests",
                c => new
                    {
                        Patient_UserId = c.String(nullable: false, maxLength: 128),
                        Test_TestId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Patient_UserId, t.Test_TestId });
            
            CreateTable(
                "dbo.Tests",
                c => new
                    {
                        TestId = c.Int(nullable: false),
                        Name = c.String(nullable: false),
                        Description = c.String(),
                        ServiceID = c.Int(nullable: false),
                        Appointment_Id = c.Int(),
                    })
                .PrimaryKey(t => t.TestId);
            
            AddColumn("dbo.TestRequests", "TestId", c => c.Int(nullable: false));
            DropForeignKey("dbo.TestRequests", "AppointmentId", "dbo.Appointments");
            DropIndex("dbo.TestRequests", new[] { "AppointmentId" });
            DropColumn("dbo.TestRequests", "baseValue");
            CreateIndex("dbo.PatientTests", "Test_TestId");
            CreateIndex("dbo.PatientTests", "Patient_UserId");
            CreateIndex("dbo.Tests", "Appointment_Id");
            CreateIndex("dbo.Tests", "ServiceID");
            AddForeignKey("dbo.Tests", "Appointment_Id", "dbo.Appointments", "Id");
            AddForeignKey("dbo.PatientTests", "Test_TestId", "dbo.Tests", "TestId", cascadeDelete: true);
            AddForeignKey("dbo.PatientTests", "Patient_UserId", "dbo.Patients", "UserId", cascadeDelete: true);
            AddForeignKey("dbo.Tests", "ServiceID", "dbo.MedicareServices", "ServiceID", cascadeDelete: true);
        }
    }
}
