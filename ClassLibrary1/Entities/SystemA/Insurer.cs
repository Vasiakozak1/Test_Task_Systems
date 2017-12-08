using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Test_Task_Systems.DataAccess.Entities.SystemA
{
    public class Insurer
    {
        [Key, ForeignKey("InsurancePolicy")]
        public Guid InsurancePolicyGuid { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }

        public virtual InsurancePolicy InsurancePolicy { get; set; }
    }
}
