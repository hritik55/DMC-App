namespace Diagnostic_Medical_Center.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changedServices : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MedicareServices", "DoctorId", c => c.String());
            AddColumn("dbo.MedicareServices", "Doctor_Id", c => c.Int());
            CreateIndex("dbo.MedicareServices", "Doctor_Id");
            AddForeignKey("dbo.MedicareServices", "Doctor_Id", "dbo.Doctors", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MedicareServices", "Doctor_Id", "dbo.Doctors");
            DropIndex("dbo.MedicareServices", new[] { "Doctor_Id" });
            DropColumn("dbo.MedicareServices", "Doctor_Id");
            DropColumn("dbo.MedicareServices", "DoctorId");
        }
    }
}
