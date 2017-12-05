using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Test_Task_Systems.DataAccess.Entities.SystemB;
namespace Test_Task_Systems.DataAccess.Contexts
{
    public class SystemBDbContext: DbContext
    {
        public IDbSet<Agent> Agents { get; set; }
        public IDbSet<InsurancePolicy> InsurancePolicies { get; set; }
        public IDbSet<Insurer> Insurers { get; set; }

        public SystemBDbContext(string connStr): base(connStr) { }
        public SystemBDbContext() : base() { }
    }
}
