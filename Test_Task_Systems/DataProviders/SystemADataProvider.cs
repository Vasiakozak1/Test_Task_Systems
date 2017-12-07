using System;
using System.Data.Entity.Infrastructure;
using System.Collections.Generic;
using Test_Task_Systems.DataAccess.Entities;
using Test_Task_Systems.DataAccess.Contexts;
using System.Linq;
using Test_Task_Systems.DataAccess.Entities.SystemA;
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
            List<InsurancePolicyViewModel> insuranceList = new List<InsurancePolicyViewModel>();

            using (var context = _factory.Create())
            {
                var policies = context.InsurancePolicies;
                if (policies != null)
                {
                    foreach (var pol in policies)
                    {
                        insuranceList.Add(new InsurancePolicyViewModel
                        {
                            Id = pol.InsurerId,
                            Number = pol.Number,
                            AgentName = pol.AgentName,
                            IsActive = pol.IsActive,
                            Insurer = this.GetInsurerViewModel(pol.Insurer),
                            Beneficiaries = this.GetBeneficiariesViewModel(pol.Beneficiaries)
                        });
                    }
                }               
            }
            return insuranceList;
        }

        public IList<BeneficiaryViewModel> GetBeneficiariesByPolicy(int policyId)
        {
            List<BeneficiaryViewModel> benefList = new List<BeneficiaryViewModel>();

            using (var context = _factory.Create())
            {
                var beneficiaries = context.Beneficiaries.Where(b => b.InsurancePolicyId == policyId);
                if (beneficiaries != null)
                {
                    foreach (var ben in beneficiaries)
                    {
                        benefList.Add(new BeneficiaryViewModel
                        {
                            Id = ben.Id,
                            Name = ben.Name
                        });
                    }
                }              
            }
            return benefList;
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
            List<InsurancePolicyViewModel> insurancePolicyViewModelList = new List<InsurancePolicyViewModel>();
            using (var context = _factory.Create())
            {
                var insPolicies = context.InsurancePolicies.Where(pol => pol.AgentName == agentName);
                if (insPolicies != null)
                {
                    foreach (var pol in insPolicies)
                    {
                        insurancePolicyViewModelList.Add(new InsurancePolicyViewModel
                        {
                            Id = pol.InsurerId,
                            Number = pol.Number,
                            AgentName = pol.AgentName,
                            IsActive = pol.IsActive,
                            Insurer = this.GetInsurerViewModel(pol.Insurer),
                            Beneficiaries = this.GetBeneficiariesViewModel(pol.Beneficiaries)
                        });
                    }
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
                if (insurer != null)
                {
                    var insPolicy = context.InsurancePolicies.First(insP => insP.InsurerId == insurer.InsurancePolicyId);
                    if (insPolicy != null)
                    {
                        policyViewModel = new InsurancePolicyViewModel
                        {
                            Id = insPolicy.InsurerId,
                            Number = insPolicy.Number,
                            AgentName = insPolicy.AgentName,
                            IsActive = insPolicy.IsActive,
                            Insurer = this.GetInsurerViewModel(insPolicy.Insurer),
                            Beneficiaries = this.GetBeneficiariesViewModel(insPolicy.Beneficiaries)
                        };
                    }
                    
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