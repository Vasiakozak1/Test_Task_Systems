using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
namespace Test_Task_Systems.DataAccess.Entities.SystemC
{
    public class Beneficiary
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [ForeignKey("InsurancePolicy")]
        public int InsurancePolicyId { get; set; }
        public InsurancePolicy InsurancePolicy { get; set; }
    }
}
