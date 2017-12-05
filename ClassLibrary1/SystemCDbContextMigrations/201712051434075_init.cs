namespace Test_Task_Systems.DataAccess.SystemCDbContextMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Agents",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.InsurancePolicies",
                c => new
                    {
                        InsurerId = c.Int(nullable: false, identity: true),
                        Number = c.Int(nullable: false),
                        DateFrom = c.DateTime(nullable: false),
                        DateTill = c.DateTime(nullable: false),
                        AgentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.InsurerId)
                .ForeignKey("dbo.Agents", t => t.AgentId, cascadeDelete: true)
                .Index(t => t.AgentId);
            
            CreateTable(
                "dbo.Beneficiaries",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        InsurancePolicyId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.InsurancePolicies", t => t.InsurancePolicyId, cascadeDelete: true)
                .Index(t => t.InsurancePolicyId);
            
            CreateTable(
                "dbo.Insurers",
                c => new
                    {
                        InsurancePolicyId = c.Int(nullable: false),
                        FirstName = c.String(),
                        LastName = c.String(),
                    })
                .PrimaryKey(t => t.InsurancePolicyId)
                .ForeignKey("dbo.InsurancePolicies", t => t.InsurancePolicyId)
                .Index(t => t.InsurancePolicyId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Insurers", "InsurancePolicyId", "dbo.InsurancePolicies");
            DropForeignKey("dbo.Beneficiaries", "InsurancePolicyId", "dbo.InsurancePolicies");
            DropForeignKey("dbo.InsurancePolicies", "AgentId", "dbo.Agents");
            DropIndex("dbo.Insurers", new[] { "InsurancePolicyId" });
            DropIndex("dbo.Beneficiaries", new[] { "InsurancePolicyId" });
            DropIndex("dbo.InsurancePolicies", new[] { "AgentId" });
            DropTable("dbo.Insurers");
            DropTable("dbo.Beneficiaries");
            DropTable("dbo.InsurancePolicies");
            DropTable("dbo.Agents");
        }
    }
}
