namespace Diagnostic_Medical_Center.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedmedicaremodel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MedicareServices",
                c => new
                    {
                        ServiceID = c.Int(nullable: false),
                        ServiceName = c.String(nullable: false),
                        Eligibility = c.String(),
                        DoctorId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.ServiceID)
                .ForeignKey("dbo.Doctors", t => t.DoctorId)
                .Index(t => t.DoctorId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MedicareServices", "DoctorId", "dbo.Doctors");
            DropIndex("dbo.MedicareServices", new[] { "DoctorId" });
            DropTable("dbo.MedicareServices");
        }
    }
}
