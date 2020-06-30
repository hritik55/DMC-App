namespace Diagnostic_Medical_Center.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedTestRequestTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tests", "Appointment_Id", c => c.Int());
            CreateIndex("dbo.Tests", "Appointment_Id");
            AddForeignKey("dbo.Tests", "Appointment_Id", "dbo.Appointments", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tests", "Appointment_Id", "dbo.Appointments");
            DropIndex("dbo.Tests", new[] { "Appointment_Id" });
            DropColumn("dbo.Tests", "Appointment_Id");
        }
    }
}
