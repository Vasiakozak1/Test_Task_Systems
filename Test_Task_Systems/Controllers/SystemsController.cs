using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Test_Task_Systems.DataProviders;
using System.Data.Entity.Infrastructure;
using Test_Task_Systems.DataAccess.Contexts;
using Test_Task_Systems.DataAccess.Entities;
namespace Test_Task_Systems.Controllers
{
    [RoutePrefix("api/Systems")]
    public class SystemsController : ApiController
    {
        private DataProviderCollection _provider;
        public SystemsController(IConnectionService connectionService, IDbContextFactory<SystemADbContext> systemAFactory,
            IDbContextFactory<SystemBDbContext> systemBFactory, IDbContextFactory<SystemCDbContext> systemCFactory)
        {
            IDataProvider[] dataProviders = new IDataProvider[]
            {
                new SystemADataProvider(systemAFactory),
                new SystemBDataProvider(systemBFactory),
                new SystemCDataProvider(systemCFactory)
            };
            _provider = new DataProviderCollection(connectionService, dataProviders);
        }

        [Route("GetActualPolicies")]
        [HttpGet]
        public IEnumerable<InsurancePolicyViewModel> GetActualPolicies()
        {
            return _provider.GetActualPolicies();
        }

        [Route("GetBeneficiariesByPolicy/{policyId}")]
        [HttpGet]
        public IEnumerable<BeneficiaryViewModel> GetBeneficiariesByPolicy(int policyId)
        {
            return _provider.GetBeneficiariesByPolicy(policyId);
        }

        [Route("GetInsurerByPhone/{phone}")]
        [HttpGet]
        public InsurerViewModel GetInsurerByPhone(string phone)
        {
            return _provider.GetInsurerByPhone(phone);
        }

        [Route("GetPolicyByAgent/{agentName}")]
        [HttpGet]
        public IEnumerable<InsurancePolicyViewModel> GetPolicyByAgent(string agentName)
        {
            return _provider.GetPolicyByAgent(agentName);
        }

        [Route("GetPolicyByInsurerPhone/{phone}")]
        [HttpGet]
        public InsurancePolicyViewModel GetPolicyByInsurerPhone(string phone)
        {
            return _provider.GetPolicyByInsurerPhone(phone);
        }
    }
}
