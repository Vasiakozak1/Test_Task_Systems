using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace Test_Task_Systems.DataAccess.Entities.SystemA
{
    public class Beneficiary
    {
        [Key]
        public Guid Guid { get; set; }
        public string Name { get; set; }
        [ForeignKey("InsurancePolicy")]
        public Guid InsurancePolicyGuid { get; set; }
        public virtual InsurancePolicy InsurancePolicy { get; set; }
    }
}
