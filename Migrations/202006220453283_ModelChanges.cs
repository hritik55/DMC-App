namespace Diagnostic_Medical_Center.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModelChanges : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Appointments", "PatientId", "dbo.Patients");
            DropForeignKey("dbo.Appointments", "DoctorId", "dbo.Doctors");
            DropIndex("dbo.Appointments", new[] { "PatientId" });
            DropIndex("dbo.Appointments", new[] { "DoctorId" });
            RenameColumn(table: "dbo.Appointments", name: "PatientId", newName: "Patient_Id");
            RenameColumn(table: "dbo.Appointments", name: "DoctorId", newName: "DoctorId_Id");
            AddColumn("dbo.Admins", "RoleId", c => c.Int(nullable: false));
            AddColumn("dbo.Admins", "UserRoles_Id", c => c.Int());
            AddColumn("dbo.Agents", "RoleId", c => c.Int(nullable: false));
            AddColumn("dbo.Agents", "UserRoles_Id", c => c.Int());
            AddColumn("dbo.Patients", "RoleID", c => c.Int(nullable: false));
            AddColumn("dbo.Patients", "UserRole_Id", c => c.Int());
            AddColumn("dbo.Doctors", "RoleId", c => c.Int(nullable: false));
            AddColumn("dbo.Doctors", "UserRole_Id", c => c.Int());
            AddColumn("dbo.Users", "RoleId", c => c.Int(nullable: false));
            AddColumn("dbo.Users", "UserRole_Id", c => c.Int());
            AlterColumn("dbo.Appointments", "Patient_Id", c => c.Int());
            AlterColumn("dbo.Appointments", "DoctorId_Id", c => c.Int());
            AlterColumn("dbo.UserRoles", "UserRoleName", c => c.String(nullable: false));
            CreateIndex("dbo.Admins", "UserRoles_Id");
            CreateIndex("dbo.Agents", "UserRoles_Id");
            CreateIndex("dbo.Appointments", "DoctorId_Id");
            CreateIndex("dbo.Appointments", "Patient_Id");
            CreateIndex("dbo.Doctors", "UserRole_Id");
            CreateIndex("dbo.Patients", "UserRole_Id");
            CreateIndex("dbo.Users", "UserRole_Id");
            AddForeignKey("dbo.Admins", "UserRoles_Id", "dbo.UserRoles", "Id");
            AddForeignKey("dbo.Agents", "UserRoles_Id", "dbo.UserRoles", "Id");
            AddForeignKey("dbo.Doctors", "UserRole_Id", "dbo.UserRoles", "Id");
            AddForeignKey("dbo.Patients", "UserRole_Id", "dbo.UserRoles", "Id");
            AddForeignKey("dbo.Users", "UserRole_Id", "dbo.UserRoles", "Id");
            AddForeignKey("dbo.Appointments", "Patient_Id", "dbo.Patients", "Id");
            AddForeignKey("dbo.Appointments", "DoctorId_Id", "dbo.Doctors", "Id");
            DropColumn("dbo.Users", "IsAdmin");
            DropColumn("dbo.Users", "IsDoctor");
            DropColumn("dbo.Users", "IsAgent");
            DropColumn("dbo.Users", "IsPatient");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "IsPatient", c => c.Boolean(nullable: false));
            AddColumn("dbo.Users", "IsAgent", c => c.Boolean(nullable: false));
            AddColumn("dbo.Users", "IsDoctor", c => c.Boolean(nullable: false));
            AddColumn("dbo.Users", "IsAdmin", c => c.Boolean(nullable: false));
            DropForeignKey("dbo.Appointments", "DoctorId_Id", "dbo.Doctors");
            DropForeignKey("dbo.Appointments", "Patient_Id", "dbo.Patients");
            DropForeignKey("dbo.Users", "UserRole_Id", "dbo.UserRoles");
            DropForeignKey("dbo.Patients", "UserRole_Id", "dbo.UserRoles");
            DropForeignKey("dbo.Doctors", "UserRole_Id", "dbo.UserRoles");
            DropForeignKey("dbo.Agents", "UserRoles_Id", "dbo.UserRoles");
            DropForeignKey("dbo.Admins", "UserRoles_Id", "dbo.UserRoles");
            DropIndex("dbo.Users", new[] { "UserRole_Id" });
            DropIndex("dbo.Patients", new[] { "UserRole_Id" });
            DropIndex("dbo.Doctors", new[] { "UserRole_Id" });
            DropIndex("dbo.Appointments", new[] { "Patient_Id" });
            DropIndex("dbo.Appointments", new[] { "DoctorId_Id" });
            DropIndex("dbo.Agents", new[] { "UserRoles_Id" });
            DropIndex("dbo.Admins", new[] { "UserRoles_Id" });
            AlterColumn("dbo.UserRoles", "UserRoleName", c => c.String());
            AlterColumn("dbo.Appointments", "DoctorId_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Appointments", "Patient_Id", c => c.Int(nullable: false));
            DropColumn("dbo.Users", "UserRole_Id");
            DropColumn("dbo.Users", "RoleId");
            DropColumn("dbo.Doctors", "UserRole_Id");
            DropColumn("dbo.Doctors", "RoleId");
            DropColumn("dbo.Patients", "UserRole_Id");
            DropColumn("dbo.Patients", "RoleID");
            DropColumn("dbo.Agents", "UserRoles_Id");
            DropColumn("dbo.Agents", "RoleId");
            DropColumn("dbo.Admins", "UserRoles_Id");
            DropColumn("dbo.Admins", "RoleId");
            RenameColumn(table: "dbo.Appointments", name: "DoctorId_Id", newName: "DoctorId");
            RenameColumn(table: "dbo.Appointments", name: "Patient_Id", newName: "PatientId");
            CreateIndex("dbo.Appointments", "DoctorId");
            CreateIndex("dbo.Appointments", "PatientId");
            AddForeignKey("dbo.Appointments", "DoctorId", "dbo.Doctors", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Appointments", "PatientId", "dbo.Patients", "Id", cascadeDelete: true);
        }
    }
}
