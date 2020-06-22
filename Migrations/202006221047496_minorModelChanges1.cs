namespace Diagnostic_Medical_Center.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class minorModelChanges1 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Appointments", name: "DoctorId_Id", newName: "Doctors_Id");
            RenameColumn(table: "dbo.Appointments", name: "Patient_Id", newName: "Patients_Id");
            RenameIndex(table: "dbo.Appointments", name: "IX_DoctorId_Id", newName: "IX_Doctors_Id");
            RenameIndex(table: "dbo.Appointments", name: "IX_Patient_Id", newName: "IX_Patients_Id");
            AddColumn("dbo.Appointments", "PatientID", c => c.String());
            AddColumn("dbo.Appointments", "DoctorID", c => c.String());
            DropColumn("dbo.Appointments", "status");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Appointments", "status", c => c.Boolean(nullable: false));
            DropColumn("dbo.Appointments", "DoctorID");
            DropColumn("dbo.Appointments", "PatientID");
            RenameIndex(table: "dbo.Appointments", name: "IX_Patients_Id", newName: "IX_Patient_Id");
            RenameIndex(table: "dbo.Appointments", name: "IX_Doctors_Id", newName: "IX_DoctorId_Id");
            RenameColumn(table: "dbo.Appointments", name: "Patients_Id", newName: "Patient_Id");
            RenameColumn(table: "dbo.Appointments", name: "Doctors_Id", newName: "DoctorId_Id");
        }
    }
}
