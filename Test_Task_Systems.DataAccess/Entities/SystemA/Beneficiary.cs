using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;
namespace Test_Task_Systems.DataAccess.Entities.SystemA
{
    public class Beneficiary
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [ForeignKey("InsurancePolicy")]
        public int InsurancePolicyId { get; set; }
    }
}
