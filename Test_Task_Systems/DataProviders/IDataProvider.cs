using System.Collections.Generic;
using Test_Task_Systems.DataAccess.ViewModels;
namespace Test_Task_Systems.DataProviders
{
    public interface IDataProvider
    {
        InsurerViewModel GetInsurerByPhone(string phone);
        InsurancePolicyViewModel GetPolicyByInsurerPhone(string phone);
        IList<InsurancePolicyViewModel> GetActualPolicies();
        IList<BeneficiaryViewModel> GetBeneficiariesByPolicy(int policyNumber);
        IList<InsurancePolicyViewModel> GetPolicyByAgent(string agentName);
    }
}
