namespace Test_Task_Systems.DataAccess.SystemCDbContextMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddGuid : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Agents",
                c => new
                    {
                        Guid = c.Guid(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Guid);
            
            CreateTable(
                "dbo.InsurancePolicies",
                c => new
                    {
                        InsurerGuid = c.Guid(nullable: false),
                        Number = c.Int(nullable: false),
                        DateFrom = c.DateTime(nullable: false),
                        DateTill = c.DateTime(nullable: false),
                        AgentGuid = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.InsurerGuid)
                .ForeignKey("dbo.Agents", t => t.AgentGuid, cascadeDelete: true)
                .Index(t => t.AgentGuid);
            
            CreateTable(
                "dbo.Beneficiaries",
                c => new
                    {
                        Guid = c.Guid(nullable: false),
                        Name = c.String(),
                        InsurancePolicyGuid = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Guid)
                .ForeignKey("dbo.InsurancePolicies", t => t.InsurancePolicyGuid, cascadeDelete: true)
                .Index(t => t.InsurancePolicyGuid);
            
            CreateTable(
                "dbo.Insurers",
                c => new
                    {
                        InsurancePolicyGuid = c.Guid(nullable: false),
                        FirstName = c.String(),
                        LastName = c.String(),
                    })
                .PrimaryKey(t => t.InsurancePolicyGuid)
                .ForeignKey("dbo.InsurancePolicies", t => t.InsurancePolicyGuid)
                .Index(t => t.InsurancePolicyGuid);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Insurers", "InsurancePolicyGuid", "dbo.InsurancePolicies");
            DropForeignKey("dbo.Beneficiaries", "InsurancePolicyGuid", "dbo.InsurancePolicies");
            DropForeignKey("dbo.InsurancePolicies", "AgentGuid", "dbo.Agents");
            DropIndex("dbo.Insurers", new[] { "InsurancePolicyGuid" });
            DropIndex("dbo.Beneficiaries", new[] { "InsurancePolicyGuid" });
            DropIndex("dbo.InsurancePolicies", new[] { "AgentGuid" });
            DropTable("dbo.Insurers");
            DropTable("dbo.Beneficiaries");
            DropTable("dbo.InsurancePolicies");
            DropTable("dbo.Agents");
        }
    }
}
