﻿using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace Test_Task_Systems.DataAccess.Entities.SystemB
{
    public class Insurer
    {
        [Key, ForeignKey("InsurancePolicy")]
        public Guid InsurancePolicyGuid { get; set; }
        public virtual InsurancePolicy InsurancePolicy { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
    }
}
