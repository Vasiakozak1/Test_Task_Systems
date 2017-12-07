using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Test_Task_Systems.DataAccess.Entities;
using System.Data.Entity.Infrastructure;
using Test_Task_Systems;
using Test_Task_Systems.DataAccess.Contexts;
using Test_Task_Systems.DataAccess.Entities.SystemC;

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
                if (policies != null)
                {
                    foreach (var pol in policies)
                    {
                        policyList.Add(new InsurancePolicyViewModel
                        {
                            Id = pol.InsurerId,
                            Number = pol.Number,
                            DateFrom = pol.DateFrom,
                            DateTill = pol.DateTill,
                            Insurer = this.GetInsurerViewModel(pol.Insurer),
                            Beneficiaries = this.GetBeneficiariesViewModel(pol.Beneficiaries)
                        });
                    }
                }
            }
            return policyList;
        }

        public IList<BeneficiaryViewModel> GetBeneficiariesByPolicy(int policyId)
        {
            List<BeneficiaryViewModel> beneficiariesList = new List<BeneficiaryViewModel>();
            using (var context = _factory.Create())
            {
                var beneficiaries = context.Beneficiaries.Where(ben => ben.InsurancePolicyId == policyId);
                if (beneficiaries != null)
                {
                    foreach (var ben in beneficiaries)
                    {
                        beneficiariesList.Add(new BeneficiaryViewModel
                        {
                            Id = ben.Id,
                            Name = ben.Name
                        });
                    }
                }
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
                if (agent != null)
                {
                    var policies = context.InsurancePolicies.Where(pol => pol.AgentId == agent.Id);
                    foreach (var pol in policies)
                    {
                        policiesList.Add(new InsurancePolicyViewModel
                        {
                            Id = pol.InsurerId,
                            Number = pol.Number,
                            DateFrom = pol.DateFrom,
                            DateTill = pol.DateTill,
                            Insurer = this.GetInsurerViewModel(pol.Insurer),
                            Beneficiaries = this.GetBeneficiariesViewModel(pol.Beneficiaries)
                        });
                    }
                }
            }
            return policiesList;
        }

        public InsurancePolicyViewModel GetPolicyByInsurerPhone(string phone)
        {
            return new InsurancePolicyViewModel();
        }
        private InsurerViewModel GetInsurerViewModel(Insurer insurer)
        {
            if (insurer == null)
                return null;
            return new InsurerViewModel
            {
                Id = insurer.InsurancePolicyId,
                FirstName = insurer.FirstName,
                LastName = insurer.LastName
            };
        }
        private ICollection<BeneficiaryViewModel> GetBeneficiariesViewModel(ICollection<Beneficiary> beneficiaries)
        {
            List<BeneficiaryViewModel> bens = new List<BeneficiaryViewModel>();
            foreach (var ben in beneficiaries)
            {
                bens.Add(new BeneficiaryViewModel
                {
                    Id = ben.Id,
                    Name = ben.Name
                });
            }
            return bens;
        }
    }
}