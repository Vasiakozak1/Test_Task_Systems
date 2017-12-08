using System;
using System.Data.Entity.Infrastructure;
using System.Collections.Generic;
using Test_Task_Systems.DataAccess.Contexts;
using System.Linq;
using Test_Task_Systems.DataAccess.Entities.SystemA;
using Test_Task_Systems.DataAccess.ViewModels;
using Test_Task_Systems.Mapper;
namespace Test_Task_Systems.DataProviders
{
    public class SystemADataProvider : IDataProvider
    {
        private IDbContextFactory<SystemADbContext> _factory;
        public SystemADataProvider(IDbContextFactory<SystemADbContext> factory)
        {
            _factory = factory;
        }

        public IList<InsurancePolicyViewModel> GetActualPolicies()
        {
            List<InsurancePolicyViewModel> insuranceList;

            using (var context = _factory.Create())
            {
                var policies = context.InsurancePolicies;
                if (policies == null)
                {
                    return null;
                }
                insuranceList = new List<InsurancePolicyViewModel>(policies.ToList().Select(pol => pol.MapPolicy()));
            }
            return insuranceList;
        }

        public IList<BeneficiaryViewModel> GetBeneficiariesByPolicy(int policyNumber)
        {
            using (var context = _factory.Create())
            {
                var policy = context.InsurancePolicies.FirstOrDefault(pol => pol.Number == policyNumber);
                if (policy == null)
                {
                    return null;
                }
                var beneficiaries = context.Beneficiaries.Where(ben => ben.InsurancePolicyGuid == policy.InsurerGuid);
                return new List<BeneficiaryViewModel>(beneficiaries.ToList().Select(ben => ben.MapBeneficiary()));
            }
        }

        public InsurerViewModel GetInsurerByPhone(string phone)
        {
            InsurerViewModel insurerViewModel = null;
            using (var context = _factory.Create())
            {
                var insurer = context.Insurers.First(ins => ins.Phone == phone);
                insurerViewModel = insurer.MapInsurer();
            }
            return insurerViewModel;
        }
        
        public IList<InsurancePolicyViewModel> GetPolicyByAgent(string agentName)
        {
            List<InsurancePolicyViewModel> insurancePolicyViewModelList = new List<InsurancePolicyViewModel>();
            using (var context = _factory.Create())
            {
                var insPolicies = context.InsurancePolicies.Where(pol => pol.AgentName == agentName);
                if (insPolicies != null)
                {
                    insurancePolicyViewModelList = new List<InsurancePolicyViewModel>(insPolicies.ToList().Select(pol => pol.MapPolicy()));
                }
            }
            return insurancePolicyViewModelList;
        }

        public InsurancePolicyViewModel GetPolicyByInsurerPhone(string phone)
        {
            InsurancePolicyViewModel policyViewModel = null;
            using (var context = _factory.Create())
            {
                var insurer = context.Insurers.First(ins => ins.Phone == phone);
                if (insurer == null)
                {
                    return null;
                }
                var insPolicy = context.InsurancePolicies.First(insP => insP.InsurerGuid == insurer.InsurancePolicyGuid);
                policyViewModel = insPolicy.MapPolicy();
            }
            return policyViewModel;
        }
    }
}