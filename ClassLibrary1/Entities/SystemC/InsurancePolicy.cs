using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Test_Task_Systems.DataAccess.Entities.SystemC
{
    public class InsurancePolicy
    {
        [Key, ForeignKey("Insurer")]
        public int InsurerId { get; set; }
        public virtual Insurer Insurer { get; set; }
        public int Number { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTill { get; set; }
        public virtual ICollection<Beneficiary> Beneficiaries { get; set; }
        [ForeignKey("Agent")]
        public int AgentId { get; set; }
        public virtual Agent Agent { get; set; }
    }
}
