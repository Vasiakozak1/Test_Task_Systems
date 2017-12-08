using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Test_Task_Systems.DataAccess.Entities.SystemC
{
    public class Beneficiary
    {
        [Key]
        public Guid Guid { get; set; }
        public string Name { get; set; }
        [ForeignKey("InsurancePolicy")]
        public Guid InsurancePolicyGuid { get; set; }
        public InsurancePolicy InsurancePolicy { get; set; }
    }
}
