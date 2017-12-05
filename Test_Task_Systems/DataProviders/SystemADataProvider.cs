using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Test_Task_Systems.DataAccess.Entities;

namespace Test_Task_Systems.DataProviders
{
    public class SystemADataProvider : IDataProvider
    {
        private string _connStr;
        public SystemADataProvider(string connStr)
        {
            _connStr = connStr;
        }

        public IEnumerable<InsurancePolicyViewModel> GetActualPolicies()
        {
            List<InsurancePolicyViewModel> insuranceList = new List<InsurancePolicyViewModel>();


            return null;
        }

        public IEnumerable<BeneficiaryViewModel> GetBeneficiariesByPolicy()
        {
            throw new NotImplementedException();
        }

        public InsurerViewModel GetInsurerByPhone(string phone)
        {
            throw new NotImplementedException();
        }

        public InsurancePolicyViewModel GetPolicyByAgent()
        {
            throw new NotImplementedException();
        }

        public InsurancePolicyViewModel GetPolicyByInsurerPhone(string phone)
        {
            throw new NotImplementedException();
        }
    }
}