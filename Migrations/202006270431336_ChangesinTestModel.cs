namespace Diagnostic_Medical_Center.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangesinTestModel : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Tests", "MedicareService_ServiceID", "dbo.MedicareServices");
            DropForeignKey("dbo.PatientTests", "Test_TestId", "dbo.Tests");
            DropIndex("dbo.Tests", new[] { "MedicareService_ServiceID" });
            RenameColumn(table: "dbo.Tests", name: "MedicareService_ServiceID", newName: "ServiceID");
            DropPrimaryKey("dbo.Tests");
            AlterColumn("dbo.Tests", "TestId", c => c.Int(nullable: false));
            AlterColumn("dbo.Tests", "ServiceID", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Tests", "TestId");
            CreateIndex("dbo.Tests", "ServiceID");
            AddForeignKey("dbo.Tests", "ServiceID", "dbo.MedicareServices", "ServiceID", cascadeDelete: true);
            AddForeignKey("dbo.PatientTests", "Test_TestId", "dbo.Tests", "TestId", cascadeDelete: true);
            DropColumn("dbo.Tests", "isActiveRequest");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Tests", "isActiveRequest", c => c.Boolean(nullable: false));
            DropForeignKey("dbo.PatientTests", "Test_TestId", "dbo.Tests");
            DropForeignKey("dbo.Tests", "ServiceID", "dbo.MedicareServices");
            DropIndex("dbo.Tests", new[] { "ServiceID" });
            DropPrimaryKey("dbo.Tests");
            AlterColumn("dbo.Tests", "ServiceID", c => c.Int());
            AlterColumn("dbo.Tests", "TestId", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Tests", "TestId");
            RenameColumn(table: "dbo.Tests", name: "ServiceID", newName: "MedicareService_ServiceID");
            CreateIndex("dbo.Tests", "MedicareService_ServiceID");
            AddForeignKey("dbo.PatientTests", "Test_TestId", "dbo.Tests", "TestId", cascadeDelete: true);
            AddForeignKey("dbo.Tests", "MedicareService_ServiceID", "dbo.MedicareServices", "ServiceID");
        }
    }
}
