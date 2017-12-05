using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.Infrastructure;
using System.Data.Entity;
using System.Configuration;
using Test_Task_Systems.DataAccess.Contexts;
namespace Test_Task_Systems
{
    public class SystemsDbContextFactory<TContext> : IDbContextFactory<TContext> where TContext : DbContext
    {
        public SystemsDbContextFactory(string connectionString)
        {
            this.ConnectionString = connectionString;
        }
        private string ConnectionString;

        public TContext Create()
        {
            return (TContext)Activator.CreateInstance(typeof(TContext), this.ConnectionString); //magic
        }
        
    }
}
