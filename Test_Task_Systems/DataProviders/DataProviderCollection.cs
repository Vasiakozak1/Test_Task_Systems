using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using Test_Task_Systems.DataAccess.Entities;
using Test_Task_Systems.DataAccess.ViewModels;
namespace Test_Task_Systems.DataProviders
{
    public class DataProviderCollection: IDataProvider
    {
        private List<IDataProvider> _dataProviders;
        private IConnectionService _connectionService;
        private string[] _databases;
        public DataProviderCollection(IConnectionService connectionService, params IDataProvider[] providers)
        {
            _connectionService = connectionService;
            _databases = _connectionService.GetAvailableDatabases().ToArray();
            _dataProviders = new List<IDataProvider>(providers);
        }

        public IList<InsurancePolicyViewModel> GetActualPolicies()
        {
            List<InsurancePolicyViewModel> result = new List<InsurancePolicyViewModel>();
            for (int i = 0; i < _dataProviders.Count; i++)
            {
                _connectionService.SetCurrentDatabase(_databases[i]);
                if (result.Count == 0)
                {
                    result = new List<InsurancePolicyViewModel>(_dataProviders[i].GetActualPolicies());
                }
                else
                {
                    result = new List<InsurancePolicyViewModel>
                        (_dataProviders[i].GetActualPolicies().MergePolicyLists(result));
                }
                
            }
            return result;
        }

        public IList<BeneficiaryViewModel> GetBeneficiariesByPolicy(int policyNumber)
        {
            List<BeneficiaryViewModel> result = new List<BeneficiaryViewModel>();
            for (int i = 0; i < _dataProviders.Count; i++)
            {
                _connectionService.SetCurrentDatabase(_databases[i]);
                if (result.Count == 0)
                {
                    result = new List<BeneficiaryViewModel>(_dataProviders[i].GetBeneficiariesByPolicy(policyNumber));
                }
                else
                {
                    result = new List<BeneficiaryViewModel>(_dataProviders[i].GetBeneficiariesByPolicy(policyNumber).MergeBeneficiaries(result));
                }
            }
            return result;
        }

        public InsurerViewModel GetInsurerByPhone(string phone)
        {
            InsurerViewModel result = new InsurerViewModel();

            for (int i = 0; i < _dataProviders.Count; i++)
            {
                _connectionService.SetCurrentDatabase(_databases[i]);
                if (result.Guid == Guid.Empty)
                {
                    result = _dataProviders[i].GetInsurerByPhone(phone);
                }
                else
                {
                    result = _dataProviders[i].GetInsurerByPhone(phone).MergeInsurers(result); 
                }
            }
            return result;
        }

        public IList<InsurancePolicyViewModel> GetPolicyByAgent(string agentName)
        {
            List<InsurancePolicyViewModel> result = new List<InsurancePolicyViewModel>();

            for (int i = 0; i < _dataProviders.Count; i++)
            {
                _connectionService.SetCurrentDatabase(_databases[i]);
                if (result.Count == 0)
                {
                    result = new List<InsurancePolicyViewModel>(_dataProviders[i].GetPolicyByAgent(agentName));
                }
                else
                {
                    result = new List<InsurancePolicyViewModel>(_dataProviders[i].GetPolicyByAgent(agentName).MergePolicyLists(result));
                }
            }
            return result;
        }

        public InsurancePolicyViewModel GetPolicyByInsurerPhone(string phone)
        {
            InsurancePolicyViewModel result = new InsurancePolicyViewModel();

            for (int i = 0; i < _dataProviders.Count; i++)
            {
                _connectionService.SetCurrentDatabase(_databases[i]);
                if (result.Guid == Guid.Empty)
                {
                    result = _dataProviders[i].GetPolicyByInsurerPhone(phone);
                }
                else
                {
                    result = _dataProviders[i].GetPolicyByInsurerPhone(phone).MergePolicies(result);
                }
            }
            return result;
        }
    }
}