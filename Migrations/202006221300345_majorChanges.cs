namespace Diagnostic_Medical_Center.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class majorChanges : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.Appointments");
            DropTable("dbo.MedicareServices");
            DropForeignKey("dbo.Appointments", "Doctors_Id", "dbo.Doctors");
            DropForeignKey("dbo.MedicareServices", "Doctor_Id", "dbo.Doctors");
            DropForeignKey("dbo.Appointments", "Patients_Id", "dbo.Patients");
            DropIndex("dbo.Appointments", new[] { "Doctors_Id" });
            DropIndex("dbo.Appointments", new[] { "Patients_Id" });
            DropIndex("dbo.MedicareServices", new[] { "Doctor_Id" });
            DropPrimaryKey("dbo.Admins");
            DropPrimaryKey("dbo.Agents");
            DropPrimaryKey("dbo.Doctors");
            DropPrimaryKey("dbo.Patients");
            DropPrimaryKey("dbo.Users");
            AddColumn("dbo.Doctors", "DoctorId", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.Patients", "Doctor_DoctorId", c => c.String(maxLength: 128));
            AddColumn("dbo.Tests", "isActiveRequest", c => c.Boolean(nullable: false));
            AddColumn("dbo.Tests", "Description", c => c.String());
            AddColumn("dbo.Tests", "PatientId", c => c.String());
            AddColumn("dbo.Tests", "Patient_UserId", c => c.String(maxLength: 128));
            AlterColumn("dbo.Admins", "VendorId", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Agents", "AgentId", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Patients", "UserId", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Tests", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Users", "UserId", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.Admins", "VendorId");
            AddPrimaryKey("dbo.Agents", "AgentId");
            AddPrimaryKey("dbo.Doctors", "DoctorId");
            AddPrimaryKey("dbo.Patients", "UserId");
            AddPrimaryKey("dbo.Users", "UserId");
            CreateIndex("dbo.Patients", "Doctor_DoctorId");
            CreateIndex("dbo.Tests", "Patient_UserId");
            AddForeignKey("dbo.Tests", "Patient_UserId", "dbo.Patients", "UserId");
            AddForeignKey("dbo.Patients", "Doctor_DoctorId", "dbo.Doctors", "DoctorId");
            DropColumn("dbo.Admins", "Id");
            DropColumn("dbo.Agents", "Id");
            DropColumn("dbo.Doctors", "Id");
            DropColumn("dbo.Doctors", "UserId");
            DropColumn("dbo.Patients", "Id");
            DropColumn("dbo.Users", "Id");
           
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.MedicareServices",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ServiceID = c.String(),
                        ServiceName = c.String(nullable: false),
                        Eligibility = c.String(),
                        IsAvailable = c.Boolean(nullable: false),
                        Doctor_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Appointments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AppointmentOn = c.DateTime(nullable: false),
                        ApprovalStatus = c.Boolean(nullable: false),
                        PatientID = c.String(),
                        DoctorID = c.String(),
                        Doctors_Id = c.Int(),
                        Patients_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Users", "Id", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.Patients", "Id", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.Doctors", "UserId", c => c.String(nullable: false));
            AddColumn("dbo.Doctors", "Id", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.Agents", "Id", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.Admins", "Id", c => c.Int(nullable: false, identity: true));
            DropForeignKey("dbo.Patients", "Doctor_DoctorId", "dbo.Doctors");
            DropForeignKey("dbo.Tests", "Patient_UserId", "dbo.Patients");
            DropIndex("dbo.Tests", new[] { "Patient_UserId" });
            DropIndex("dbo.Patients", new[] { "Doctor_DoctorId" });
            DropPrimaryKey("dbo.Users");
            DropPrimaryKey("dbo.Patients");
            DropPrimaryKey("dbo.Doctors");
            DropPrimaryKey("dbo.Agents");
            DropPrimaryKey("dbo.Admins");
            AlterColumn("dbo.Users", "UserId", c => c.String(nullable: false));
            AlterColumn("dbo.Tests", "Name", c => c.String());
            AlterColumn("dbo.Patients", "UserId", c => c.String(nullable: false));
            AlterColumn("dbo.Agents", "AgentId", c => c.String(nullable: false));
            AlterColumn("dbo.Admins", "VendorId", c => c.String(nullable: false));
            DropColumn("dbo.Tests", "Patient_UserId");
            DropColumn("dbo.Tests", "PatientId");
            DropColumn("dbo.Tests", "Description");
            DropColumn("dbo.Tests", "isActiveRequest");
            DropColumn("dbo.Patients", "Doctor_DoctorId");
            DropColumn("dbo.Doctors", "DoctorId");
            AddPrimaryKey("dbo.Users", "Id");
            AddPrimaryKey("dbo.Patients", "Id");
            AddPrimaryKey("dbo.Doctors", "Id");
            AddPrimaryKey("dbo.Agents", "Id");
            AddPrimaryKey("dbo.Admins", "Id");
            CreateIndex("dbo.MedicareServices", "Doctor_Id");
            CreateIndex("dbo.Appointments", "Patients_Id");
            CreateIndex("dbo.Appointments", "Doctors_Id");
            AddForeignKey("dbo.Appointments", "Patients_Id", "dbo.Patients", "Id");
            AddForeignKey("dbo.MedicareServices", "Doctor_Id", "dbo.Doctors", "Id");
            AddForeignKey("dbo.Appointments", "Doctors_Id", "dbo.Doctors", "Id");
        }
    }
}
