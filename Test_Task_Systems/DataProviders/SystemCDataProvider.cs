using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Test_Task_Systems.DataAccess.Entities;
using System.Data.Entity.Infrastructure;
using Test_Task_Systems;
using Test_Task_Systems.DataAccess.Contexts;
using Test_Task_Systems.DataAccess.Entities.SystemC;
using Test_Task_Systems.DataAccess.ViewModels;
using Test_Task_Systems.Mapper;

namespace Test_Task_Systems.DataProviders
{
    public class SystemCDataProvider : IDataProvider
    {
        private IDbContextFactory<SystemCDbContext> _factory;

        public SystemCDataProvider(IDbContextFactory<SystemCDbContext> factory)
        {
            _factory = factory;
        }

        public IList<InsurancePolicyViewModel> GetActualPolicies()
        {
            List<InsurancePolicyViewModel> policyList = new List<InsurancePolicyViewModel>();
            using (var context = _factory.Create())
            {
                var policies = context.InsurancePolicies.ToArray();
                if (policies == null)
                {
                    return null;
                }
                policyList = new List<InsurancePolicyViewModel>(policies.ToList().Select(pol => pol.MapPolicy()));
            }
            return policyList;
        }

        public IList<BeneficiaryViewModel> GetBeneficiariesByPolicy(int policyNumber)
        {
            List<BeneficiaryViewModel> beneficiariesList = new List<BeneficiaryViewModel>();
            using (var context = _factory.Create())
            {
                var policy = context.InsurancePolicies.FirstOrDefault(pol => pol.Number == policyNumber);
                if (policy == null)
                {
                    return null;
                }
                var beneficiaries = context.Beneficiaries.Where(ben => ben.InsurancePolicyGuid == policy.InsurerGuid);
                beneficiariesList = new List<BeneficiaryViewModel>(beneficiaries.ToList().Select(ben => ben.MapBeneficiary()));
            }
            return beneficiariesList;
        }

        public InsurerViewModel GetInsurerByPhone(string phone)
        {
            return new InsurerViewModel();
        }

        public IList<InsurancePolicyViewModel> GetPolicyByAgent(string agentName)
        {
            List<InsurancePolicyViewModel> policiesList = new List<InsurancePolicyViewModel>();
            using (var context = _factory.Create())
            {
                var agent = context.Agents.First(a => a.Name == agentName);
                if (agent == null)
                {
                    return null;
                }
                var policies = context.InsurancePolicies.Where(pol => pol.AgentGuid == agent.Guid);
                policiesList = new List<InsurancePolicyViewModel>(policies.ToList().Select(pol => pol.MapPolicy()));
            }
            return policiesList;
        }

        public InsurancePolicyViewModel GetPolicyByInsurerPhone(string phone)
        {
            return new InsurancePolicyViewModel();
        }       
    }
}