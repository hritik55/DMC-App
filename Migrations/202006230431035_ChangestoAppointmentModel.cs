namespace Diagnostic_Medical_Center.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangestoAppointmentModel : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Appointments", name: "Doctor_DoctorId", newName: "DoctorId");
            RenameIndex(table: "dbo.Appointments", name: "IX_Doctor_DoctorId", newName: "IX_DoctorId");
            AddColumn("dbo.Appointments", "MedicareID", c => c.Int(nullable: false));
            AddColumn("dbo.Appointments", "PatientId", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Appointments", "PatientId");
            DropColumn("dbo.Appointments", "MedicareID");
            RenameIndex(table: "dbo.Appointments", name: "IX_DoctorId", newName: "IX_Doctor_DoctorId");
            RenameColumn(table: "dbo.Appointments", name: "DoctorId", newName: "Doctor_DoctorId");
        }
    }
}
