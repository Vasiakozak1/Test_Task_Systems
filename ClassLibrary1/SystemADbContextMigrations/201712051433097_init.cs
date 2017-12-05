namespace Test_Task_Systems.DataAccess.SystemADbContextMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
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
                "dbo.InsurancePolicies",
                c => new
                    {
                        InsurerId = c.Int(nullable: false, identity: true),
                        Number = c.Int(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        AgentName = c.String(),
                    })
                .PrimaryKey(t => t.InsurerId);
            
            CreateTable(
                "dbo.Insurers",
                c => new
                    {
                        InsurancePolicyId = c.Int(nullable: false),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Phone = c.String(),
                    })
                .PrimaryKey(t => t.InsurancePolicyId)
                .ForeignKey("dbo.InsurancePolicies", t => t.InsurancePolicyId)
                .Index(t => t.InsurancePolicyId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Beneficiaries", "InsurancePolicyId", "dbo.InsurancePolicies");
            DropForeignKey("dbo.Insurers", "InsurancePolicyId", "dbo.InsurancePolicies");
            DropIndex("dbo.Insurers", new[] { "InsurancePolicyId" });
            DropIndex("dbo.Beneficiaries", new[] { "InsurancePolicyId" });
            DropTable("dbo.Insurers");
            DropTable("dbo.InsurancePolicies");
            DropTable("dbo.Beneficiaries");
        }
    }
}
