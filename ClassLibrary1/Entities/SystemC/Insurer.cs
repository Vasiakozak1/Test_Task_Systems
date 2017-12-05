using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Test_Task_Systems.DataAccess.Entities.SystemC
{
    public class Insurer
    {
        [Key, ForeignKey("InsurancePolicy")]
        public int InsurancePolicyId { get; set; }
        public virtual InsurancePolicy InsurancePolicy { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
