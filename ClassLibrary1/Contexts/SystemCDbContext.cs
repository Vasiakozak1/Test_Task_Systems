using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Test_Task_Systems.DataAccess.Entities.SystemC;
namespace Test_Task_Systems.DataAccess.Contexts
{
    public class SystemCDbContext: DbContext
    {
        public IDbSet<Agent> Agents { get; set; }
        public IDbSet<Beneficiary> Beneficiaries { get; set; }
        public IDbSet<InsurancePolicy> InsurancePolicies { get; set; }
        public IDbSet<Insurer> Insurers { get; set; }

        public SystemCDbContext(string connStr) : base(connStr) { }
        public SystemCDbContext() : base() { }
    }
}
