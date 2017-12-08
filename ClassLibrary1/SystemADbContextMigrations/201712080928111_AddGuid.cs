namespace Test_Task_Systems.DataAccess.SystemADbContextMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddGuid : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Insurers", "InsurancePolicyGuid", "dbo.InsurancePolicies");
            DropForeignKey("dbo.Beneficiaries", "InsurancePolicyGuid", "dbo.InsurancePolicies");
            DropIndex("dbo.Insurers", new[] { "InsurancePolicyGuid" });
            DropPrimaryKey("dbo.Beneficiaries");
            DropPrimaryKey("dbo.InsurancePolicies");
            DropPrimaryKey("dbo.Insurers");
            AlterColumn("dbo.Beneficiaries", "Guid", c => c.Guid(nullable: false));
            AlterColumn("dbo.InsurancePolicies", "InsurerGuid", c => c.Guid(nullable: false));
            AlterColumn("dbo.Insurers", "InsurancePolicyGuid", c => c.Guid(nullable: false));
            AddPrimaryKey("dbo.Beneficiaries", "Guid");
            AddPrimaryKey("dbo.InsurancePolicies", "InsurerGuid");
            AddPrimaryKey("dbo.Insurers", "InsurancePolicyGuid");
            CreateIndex("dbo.Insurers", "InsurancePolicyGuid");
            AddForeignKey("dbo.Insurers", "InsurancePolicyGuid", "dbo.InsurancePolicies", "InsurerGuid");
            AddForeignKey("dbo.Beneficiaries", "InsurancePolicyGuid", "dbo.InsurancePolicies", "InsurerGuid", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Beneficiaries", "InsurancePolicyGuid", "dbo.InsurancePolicies");
            DropForeignKey("dbo.Insurers", "InsurancePolicyGuid", "dbo.InsurancePolicies");
            DropIndex("dbo.Insurers", new[] { "InsurancePolicyGuid" });
            DropPrimaryKey("dbo.Insurers");
            DropPrimaryKey("dbo.InsurancePolicies");
            DropPrimaryKey("dbo.Beneficiaries");
            AlterColumn("dbo.Insurers", "InsurancePolicyGuid", c => c.Guid(nullable: false, identity: true));
            AlterColumn("dbo.InsurancePolicies", "InsurerGuid", c => c.Guid(nullable: false, identity: true));
            AlterColumn("dbo.Beneficiaries", "Guid", c => c.Guid(nullable: false, identity: true));
            AddPrimaryKey("dbo.Insurers", "InsurancePolicyGuid");
            AddPrimaryKey("dbo.InsurancePolicies", "InsurerGuid");
            AddPrimaryKey("dbo.Beneficiaries", "Guid");
            CreateIndex("dbo.Insurers", "InsurancePolicyGuid");
            AddForeignKey("dbo.Beneficiaries", "InsurancePolicyGuid", "dbo.InsurancePolicies", "InsurerGuid", cascadeDelete: true);
            AddForeignKey("dbo.Insurers", "InsurancePolicyGuid", "dbo.InsurancePolicies", "InsurerGuid");
        }
    }
}
