using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Test_Task_Systems.DataAccess.Entities.SystemA;
namespace Test_Task_Systems.DataAccess.Contexts
{
    public class SystemADbContext: DbContext
    {
        public IDbSet<Insurer> Insurers { get; set; }
        public IDbSet<Beneficiary> Beneficiaries { get; set; }
        public IDbSet<InsurancePolicy> InsurancePolicies { get; set; }

        public SystemADbContext(string connStr) : base(connStr) { }
        public SystemADbContext() : base() { }
    }
}
