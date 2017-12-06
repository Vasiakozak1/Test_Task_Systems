using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test_Task_Systems.DataAccess.Entities;
namespace Test_Task_Systems.DataProviders
{
    public interface IDataProvider
    {
        InsurerViewModel GetInsurerByPhone(string phone);
        InsurancePolicyViewModel GetPolicyByInsurerPhone(string phone);
        IList<InsurancePolicyViewModel> GetActualPolicies();
        IList<BeneficiaryViewModel> GetBeneficiariesByPolicy(int policyId);
        IList<InsurancePolicyViewModel> GetPolicyByAgent(string agentName);
    }
}
