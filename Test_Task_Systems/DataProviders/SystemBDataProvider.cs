using System;
using System.Collections.Generic;
using System.Linq;
using Test_Task_Systems.DataAccess.Entities;
using Test_Task_Systems.DataAccess.Contexts;
using System.Data.Entity.Infrastructure;
using Test_Task_Systems.DataAccess.Entities.SystemB;

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
                if (policies != null)
                {
                    foreach (var pol in policies)
                    {
                        policiesList.Add(new InsurancePolicyViewModel
                        {
                            Id = pol.InsurerId,
                            Number = pol.Number,
                            DateFrom = pol.DateFrom,
                            DateTill = pol.DateTill,
                            Insurer = this.GetInsurerViewModel(pol.Insurer)
                        });
                    }
                }
            }
            return policiesList;
        }

        public IList<BeneficiaryViewModel> GetBeneficiariesByPolicy(int policyId)
        {
            return new List<BeneficiaryViewModel>();
        }

        public InsurerViewModel GetInsurerByPhone(string phone)
        {
            InsurerViewModel insurerViewModel = null;
            using (var context = _factory.Create())
            {
                var insurer = context.Insurers.First(ins => ins.Phone == phone);
                if (insurer != null)
                {
                    insurerViewModel = new InsurerViewModel
                    {
                        Id = insurer.InsurancePolicyId,
                        FirstName = insurer.FirstName,
                        LastName = insurer.LastName,
                        Phone = insurer.Phone
                    };
                }
            }
            return insurerViewModel;
        }

        public IList<InsurancePolicyViewModel> GetPolicyByAgent(string agentName)
        {
            List<InsurancePolicyViewModel> policiesList = new List<InsurancePolicyViewModel>();
            using (var context = _factory.Create())
            {
                var agent = context.Agents.First(a => a.Name == agentName);
                if (agent != null && agent.InsurancePolicies != null)
                {
                    foreach (var pol in agent.InsurancePolicies)
                    {
                        policiesList.Add(new InsurancePolicyViewModel
                        {
                            Id = pol.InsurerId,
                            Number = pol.Number,
                            DateFrom = pol.DateFrom,
                            DateTill = pol.DateTill,
                            Insurer = this.GetInsurerViewModel(pol.Insurer)
                        });
                    }
                }
            }
            return policiesList;
        }

        public InsurancePolicyViewModel GetPolicyByInsurerPhone(string phone)
        {
            InsurancePolicyViewModel policyViewModel = null;
            using (var context = _factory.Create())
            {
                var insurer = context.Insurers.First(i => i.Phone == phone);
                if (insurer != null)
                {
                    var policy = context.InsurancePolicies.First(pol => pol.InsurerId == insurer.InsurancePolicyId);
                    policyViewModel = new InsurancePolicyViewModel
                    {
                        Id = policy.InsurerId,
                        Number = policy.Number,
                        DateFrom = policy.DateFrom,
                        DateTill = policy.DateTill,     
                        Insurer = this.GetInsurerViewModel(policy.Insurer)
                    };
                }
            }
            return policyViewModel;
        }
        private InsurerViewModel GetInsurerViewModel(Insurer insurer)
        {
            if (insurer == null)
                return null;
            return new InsurerViewModel
            {
                Id = insurer.InsurancePolicyId,
                FirstName = insurer.FirstName,
                LastName = insurer.LastName,
                Phone = insurer.Phone
            };
        }
        
    }
}