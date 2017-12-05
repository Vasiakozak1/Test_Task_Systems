using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace Test_Task_Systems.DataAccess.Entities.SystemA
{
    public class InsurancePolicy
    {
        [Key, ForeignKey("Insurer")]
        public int InsurerId { get; set; }
        public int Number { get; set; }
        public bool IsActive { get; set; }
        public string AgentName { get; set; }

        public virtual ICollection<Beneficiary> Beneficiaries { get; set; }
        public virtual Insurer Insurer { get; set; }
    }
}
