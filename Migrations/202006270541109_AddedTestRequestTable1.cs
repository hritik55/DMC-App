namespace Diagnostic_Medical_Center.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedTestRequestTable1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TestRequests",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DoctorId = c.String(nullable: false),
                        PatientId = c.String(nullable: false),
                        TestId = c.Int(nullable: false),
                        AppointmentId = c.Int(nullable: false),
                        result = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.TestRequests");
        }
    }
}
