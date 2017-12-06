using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Test_Task_Systems.DataAccess.Entities;
namespace Test_Task_Systems.DataProviders
{
    public static class MergeExtensions
    {
        public static IList<InsurancePolicyViewModel> MergePolicyLists(this IList<InsurancePolicyViewModel> first, IList<InsurancePolicyViewModel> second)
        {
            return first.Join(second, pol => pol.Id, pol => pol.Id, (one, two) =>
              {
                  InsurancePolicyViewModel result = new InsurancePolicyViewModel
                  {
                      Id = one.Id,
                      Number = one.Number
                  };
                  if (one.DateFrom == default(DateTime) || one.DateTill == default(DateTime))
                  {
                      result.IsActive = one.IsActive;
                      result.DateFrom = two.DateFrom;
                      result.DateTill = two.DateTill;
                  }
                  if (one.AgentName == null)
                  {
                      result.AgentName = two.AgentName;
                  }
                  else
                  {
                      result.AgentName = one.AgentName;
                  }
                  if (one.Insurer.Phone == null)
                  {
                      result.Insurer = two.Insurer;
                  }
                  else
                  {
                      result.Insurer = one.Insurer;
                  }
                  if (one.Beneficiaries == null)
                  {
                      result.Beneficiaries = two.Beneficiaries;
                  }
                  else
                  {
                      result.Beneficiaries = one.Beneficiaries;
                  }
                  return result;
              }).ToList();
        }
        public static IList<BeneficiaryViewModel> MergeBeneficiaries(this IList<BeneficiaryViewModel> first, IList<BeneficiaryViewModel> second)
        {
            return first.Join(second, b => b.Id, b => b.Id, (one, two) =>
              {
                  BeneficiaryViewModel result = new BeneficiaryViewModel();
                  if (first.Count == 0)
                  {
                      return one;
                  }
                  return two;                  
              }).ToList();
        }
        public static InsurerViewModel MergeInsurers(this InsurerViewModel first, InsurerViewModel second)
        {
            if (first.Id == 0)
                return second;
            InsurerViewModel result = new InsurerViewModel
            {
                FirstName = first.FirstName,
                LastName = first.LastName,
                Id = first.Id
            };
            if (first.Phone == null)
            {
                result.Phone = second.Phone;
            }
            else
            {
                result.Phone = first.Phone;
            }
            return result;
        }
        public static InsurancePolicyViewModel MergePolicies(this InsurancePolicyViewModel one, InsurancePolicyViewModel two)
        {
            if (one.Id == 0)
                return two;
            InsurancePolicyViewModel result = new InsurancePolicyViewModel
            {
                Id = one.Id,
                Number = one.Number
            };
            if (one.DateFrom == default(DateTime) || one.DateTill == default(DateTime))
            {
                result.IsActive = one.IsActive;
                result.DateFrom = two.DateFrom;
                result.DateTill = two.DateTill;
            }
            if (one.AgentName == null)
            {
                result.AgentName = two.AgentName;
            }
            else
            {
                result.AgentName = one.AgentName;
            }
            if (one.Insurer.Phone == null)
            {
                result.Insurer = two.Insurer;
            }
            else
            {
                result.Insurer = one.Insurer;
            }
            if (one.Beneficiaries == null)
            {
                result.Beneficiaries = two.Beneficiaries;
            }
            else
            {
                result.Beneficiaries = one.Beneficiaries;
            }

            return result;
        }
    }
}