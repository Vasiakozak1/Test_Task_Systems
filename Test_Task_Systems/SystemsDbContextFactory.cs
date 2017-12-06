using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.Infrastructure;
using System.Data.Entity;
using System.Configuration;
using Test_Task_Systems.DataAccess.Contexts;
using Test_Task_Systems.DataProviders;
namespace Test_Task_Systems
{
    public class SystemsDbContextFactory<TContext> : IDbContextFactory<TContext> where TContext : DbContext
    {
        private IConnectionService _connectionService;
        public SystemsDbContextFactory(IConnectionService connectionService)
        {
            this._connectionService = connectionService;
        }
        public TContext Create()
        {
            return (TContext)Activator.CreateInstance(typeof(TContext), this._connectionService.GetConnectionString()); //magic
        }
        
    }
}
