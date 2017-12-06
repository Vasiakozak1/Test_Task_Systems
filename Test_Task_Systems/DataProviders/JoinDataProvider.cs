using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Test_Task_Systems.DataAccess.Entities;
using System.Data.Entity.Infrastructure;
using Test_Task_Systems.DataAccess.Contexts;
namespace Test_Task_Systems.DataProviders
{
    public class JoinDataProvider : IDataProvider
    {
        private SystemADataProvider _systemA;
        private SystemBDataProvider _systemB;
        private SystemCDataProvider _systemC;
        public JoinDataProvider(IDbContextFactory<SystemADbContext> aFactory, IDbContextFactory<SystemBDbContext> bFactory, IDbContextFactory<SystemCDbContext> cFacrtory)
        {
            _systemA = new SystemADataProvider(aFactory);
            _systemB = new SystemBDataProvider(bFactory);
            _systemC = new SystemCDataProvider(cFacrtory);
        }


        public IList<InsurancePolicyViewModel> GetActualPolicies()
        {
            var systemAPolicies = _systemA.GetActualPolicies();
            var systemBPolicies = _systemB.GetActualPolicies();
            var systemCPolicies = _systemC.GetActualPolicies();
            IList<InsurancePolicyViewModel> result = new List<InsurancePolicyViewModel>();
            for (int i = 0; i < systemAPolicies.Count; i++)
            {
                result.Add(new InsurancePolicyViewModel
                {
                    Id = systemAPolicies[i].Id,
                    Number = systemAPolicies[i].Number,
                    AgentName = systemAPolicies[i].AgentName,
                    IsActive = systemAPolicies[i].IsActive,
                    DateFrom = systemBPolicies[i].DateFrom,
                    DateTill = systemBPolicies[i].DateTill,
                    Insurer = systemAPolicies[i].Insurer,
                    Beneficiaries = systemAPolicies[i].Beneficiaries                        
                });
                
            }
            return result;
        }

        public IList<BeneficiaryViewModel> GetBeneficiariesByPolicy(int policyId)
        {
            throw new NotImplementedException();
        }

        public InsurerViewModel GetInsurerByPhone(string phone)
        {
            throw new NotImplementedException();
        }

        public IList<InsurancePolicyViewModel> GetPolicyByAgent(string agentName)
        {
            throw new NotImplementedException();
        }

        public InsurancePolicyViewModel GetPolicyByInsurerPhone(string phone)
        {
            throw new NotImplementedException();
        }
    }
}