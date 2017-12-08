using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Test_Task_Systems.DataAccess.Entities;
using Test_Task_Systems.DataAccess.ViewModels;
using System.Reflection;
namespace Test_Task_Systems.DataProviders
{
    public static class MergeExtensions
    {
        public static IList<InsurancePolicyViewModel> MergePolicyLists(this IList<InsurancePolicyViewModel> firstList, IList<InsurancePolicyViewModel> secondList)
        {
            List<InsurancePolicyViewModel> policies = new List<InsurancePolicyViewModel>();
            for (int i = 0; i < firstList.Count; i++)
            {
                policies.Add(MergePolicies(firstList[i], secondList[i]));
            }
            return policies;
        }

        public static InsurancePolicyViewModel MergePolicies(this InsurancePolicyViewModel one, InsurancePolicyViewModel two)
        {
            if (one.Guid == Guid.Empty)
                return two;
            InsurancePolicyViewModel resultPolicy = new InsurancePolicyViewModel
            {
                Guid = one.Guid,
                Number = one.Number,
                AgentName = one.AgentName,
                IsActive = two.IsActive,
                DateFrom = one.DateFrom,
                DateTill = one.DateTill,
                Insurer = one.Insurer,
                Beneficiaries = one.Beneficiaries
            };
            if (resultPolicy.DateFrom == default(DateTime) || resultPolicy.DateTill == default(DateTime))
            {
                resultPolicy.DateFrom = two.DateFrom;
                resultPolicy.DateTill = two.DateTill;
                resultPolicy.IsActive = one.IsActive;
            }
            resultPolicy.IsActive = DateTime.Now >= resultPolicy.DateFrom && DateTime.Now <= resultPolicy.DateTill ? true : false;
            if (resultPolicy.AgentName == null)
            {
                resultPolicy.AgentName = two.AgentName;
            }
            if (resultPolicy.Insurer.Phone == null)
            {
                resultPolicy.Insurer = two.Insurer;
            }
            if (resultPolicy.Beneficiaries == null || resultPolicy.Beneficiaries.Count == 0)
            {
                resultPolicy.Beneficiaries = two.Beneficiaries;
            }
            return resultPolicy;
        }

        public static IList<BeneficiaryViewModel> MergeBeneficiaries(this IList<BeneficiaryViewModel> first, IList<BeneficiaryViewModel> second)
        {
            if (first.Count == 0)
                return second;
            return first;
        }

        public static InsurerViewModel MergeInsurers(this InsurerViewModel first, InsurerViewModel second)
        {
            if (first.Guid == Guid.Empty)
                return second;
            InsurerViewModel insurer = new InsurerViewModel
            {
                Guid = first.Guid,
                FirstName = first.FirstName,
                LastName = first.LastName,
                Phone = first.Phone
            };
            if (insurer.Phone == null)
                insurer.Phone = second.Phone;
            return insurer;
        }
        
    }
}