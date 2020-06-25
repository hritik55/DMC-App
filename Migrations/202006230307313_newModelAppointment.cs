namespace Diagnostic_Medical_Center.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newModelAppointment : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Appointments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AppointmentDay = c.DateTime(nullable: false),
                        Approved = c.Boolean(nullable: false),
                        Completed = c.Boolean(nullable: false),
                        Doctor_DoctorId = c.String(maxLength: 128),
                        Patient_UserId = c.String(maxLength: 128),
                        Service_ServiceID = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Doctors", t => t.Doctor_DoctorId)
                .ForeignKey("dbo.Patients", t => t.Patient_UserId)
                .ForeignKey("dbo.MedicareServices", t => t.Service_ServiceID)
                .Index(t => t.Doctor_DoctorId)
                .Index(t => t.Patient_UserId)
                .Index(t => t.Service_ServiceID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Appointments", "Service_ServiceID", "dbo.MedicareServices");
            DropForeignKey("dbo.Appointments", "Patient_UserId", "dbo.Patients");
            DropForeignKey("dbo.Appointments", "Doctor_DoctorId", "dbo.Doctors");
            DropIndex("dbo.Appointments", new[] { "Service_ServiceID" });
            DropIndex("dbo.Appointments", new[] { "Patient_UserId" });
            DropIndex("dbo.Appointments", new[] { "Doctor_DoctorId" });
            DropTable("dbo.Appointments");
        }
    }
}
