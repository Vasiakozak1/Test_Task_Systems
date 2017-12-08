using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_Task_Systems.DataAccess.Entities.SystemC
{
    public class Agent
    {
        [Key]
        public Guid Guid { get; set; }
        public string Name { get; set; }

        public virtual ICollection<InsurancePolicy> InsurancePolicies { get; set; }
    }
}
