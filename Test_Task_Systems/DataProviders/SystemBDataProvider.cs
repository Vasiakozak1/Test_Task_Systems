using System;
using System.Collections.Generic;
using System.Linq;
using Test_Task_Systems.DataAccess.Contexts;
using System.Data.Entity.Infrastructure;
using Test_Task_Systems.DataAccess.Entities.SystemB;
using Test_Task_Systems.DataAccess.ViewModels;
using Test_Task_Systems.Mapper;

namespace Test_Task_Systems.DataProviders
{
    public class SystemBDataProvider : IDataProvider
    {
        private IDbContextFactory<SystemBDbContext> _factory;

        public SystemBDataProvider(IDbContextFactory<SystemBDbContext> factory)
        {
            _factory = factory;
        }

        public IList<InsurancePolicyViewModel> GetActualPolicies()
        {
            List<InsurancePolicyViewModel> policiesList = new List<InsurancePolicyViewModel>();
            using (var context = _factory.Create())
            {
                var policies = context.InsurancePolicies.ToList();
                if (policies == null)
                {
                    return null;
                }
                policiesList = new List<InsurancePolicyViewModel>(policies.ToList().Select(pol => pol.MapPolicy()));
            }
            return policiesList;
        }

        public IList<BeneficiaryViewModel> GetBeneficiariesByPolicy(int policyNumber)
        {
            return new List<BeneficiaryViewModel>();
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
            List<InsurancePolicyViewModel> policiesList = new List<InsurancePolicyViewModel>();
            using (var context = _factory.Create())
            {
                var agent = context.Agents.First(a => a.Name == agentName);
                if (agent == null || agent.InsurancePolicies == null)
                {
                    return null;
                }
                policiesList = new List<InsurancePolicyViewModel>(agent.InsurancePolicies.ToList().Select(pol => pol.MapPolicy()));
            }
            return policiesList;
        }

        public InsurancePolicyViewModel GetPolicyByInsurerPhone(string phone)
        {
            InsurancePolicyViewModel policyViewModel = null;
            using (var context = _factory.Create())
            {
                var insurer = context.Insurers.First(i => i.Phone == phone);
                if (insurer == null)
                {
                    return null;
                }
                var policy = context.InsurancePolicies.First(pol => pol.InsurerGuid == insurer.InsurancePolicyGuid);
                policyViewModel = policy.MapPolicy();
            }
            return policyViewModel;
        }       
    }
}