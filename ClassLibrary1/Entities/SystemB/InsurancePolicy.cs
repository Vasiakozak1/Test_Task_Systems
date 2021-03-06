﻿using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace Test_Task_Systems.DataAccess.Entities.SystemB
{
    public class InsurancePolicy
    {
        [Key, ForeignKey("Insurer")]
        public Guid InsurerGuid { get; set; }
        public virtual Insurer Insurer { get; set; }
        public int Number { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTill { get; set; }

        [ForeignKey("Agent")]
        public Guid AgentGuid { get; set; }
        public virtual Agent Agent { get; set; }
    }
}
