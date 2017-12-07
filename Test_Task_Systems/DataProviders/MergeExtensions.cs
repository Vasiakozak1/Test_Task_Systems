using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Test_Task_Systems.DataAccess.Entities;
namespace Test_Task_Systems.DataProviders
{
    public static class MergeExtensions
    {      
        public static IList<InsurancePolicyViewModel> MergePolicyLists(this IList<InsurancePolicyViewModel> firstList, IList<InsurancePolicyViewModel> secondList)
        {
            List<InsurancePolicyViewModel> resultPolicies = new List<InsurancePolicyViewModel>();
            for (int i = 0; i < firstList.Count; i++)
            {
                InsurancePolicyViewModel temp = new InsurancePolicyViewModel
                {
                    Id = firstList[i].Id,
                    Number = firstList[i].Number,
                    AgentName = firstList[i].AgentName,
                    IsActive = secondList[i].IsActive,
                    DateFrom = firstList[i].DateFrom,
                    DateTill = firstList[i].DateTill,
                    Insurer = firstList[i].Insurer,
                    Beneficiaries = firstList[i].Beneficiaries
                };

                if (temp.DateFrom == default(DateTime) || temp.DateTill == default(DateTime))
                {
                    temp.DateFrom = secondList[i].DateFrom;
                    temp.DateTill = secondList[i].DateTill;
                    temp.IsActive = firstList[i].IsActive;
                }
                temp.IsActive = DateTime.Now >= temp.DateFrom && DateTime.Now <= temp.DateTill ? true : false;
                if (temp.AgentName == null)
                {
                    temp.AgentName = secondList[i].AgentName;
                }
                if (temp.Insurer.Phone == null)
                {
                    temp.Insurer = secondList[i].Insurer;
                }
                if (temp.Beneficiaries == null || temp.Beneficiaries.Count == 0)
                {
                    temp.Beneficiaries = secondList[i].Beneficiaries;
                }
                resultPolicies.Add(temp);
            }
            return resultPolicies;
        }

        public static InsurancePolicyViewModel MergePolicies(this InsurancePolicyViewModel one, InsurancePolicyViewModel two)
        {
            if (one.Id == 0)
                return two;
            InsurancePolicyViewModel resultPolicy = new InsurancePolicyViewModel
            {
                Id = one.Id,
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
            if (first.Id == 0)
                return second;
            InsurerViewModel insurer = new InsurerViewModel
            {
                Id = first.Id,
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