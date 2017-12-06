using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Test_Task_Systems.DataProviders;
using System.Data.Entity.Infrastructure;
using Test_Task_Systems.DataAccess.Contexts;
namespace Test_Task_Systems.Controllers
{
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
    }
}
